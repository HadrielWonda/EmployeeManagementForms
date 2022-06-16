using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using Baumax.Contract;
using Baumax.Scheduler.Config;
using Baumax.Scheduler.Specialized;
using Common.Logging;
using Microsoft.Win32;
using Spring.Objects.Factory;
using Baumax.AppServer.Environment;
using Baumax.Domain;

namespace Baumax.Scheduler
{
	/// <summary>
	/// The service should be used for scheduled tasks execution.
	/// Every task is responsable for providing valid DateTime of execution, the scheduler service itself will not calculate next execution DateTime.
	/// Changes of system time are handled, and tasks are prompted to recalculate next execution DateTime.
	/// Usage:
	/// You should use Start and Stop methods to activate / deactivate the service (it can be done by using "init-method" and "destroy-method" attributes in Spring.NET context definition).
	/// Also, tasks list can be filled before the service is started via String.NET context XML. 
	/// Via code, new tasks can only be added using AddJob and AddJobRange methods.
	/// </summary>
    public sealed class Scheduler : IScheduler, IDisposable, IInitializingObject, IJobResolver, ITaskResolver
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Scheduler));

		private static readonly TriggerComparer comparer = new TriggerComparer();
	    private Configuration _Config;
	    private SchedulerSection _ConfigSection;

		//
	    private readonly Jobs m_Jobs;
	    private readonly Triggers m_Triggers;
        private readonly Tasks m_Tasks;

		private bool _started;
		private DateTime _nearest_time;

		// .ctor
		public Scheduler()
		{
			m_Jobs = new Jobs();
            m_Triggers = new Triggers();
            m_Tasks = new Tasks();

			//_timer = new Timer(OnNextEvent, null, Timeout.Infinite, Timeout.Infinite);
		}

	    public ICollection<IJob> Jobs
	    {
	        get { return m_Jobs.AsReadOnly(); }
	    }

        public ICollection<ITrigger> Triggers
	    {
	        get { return m_Triggers.AsReadOnly(); }
	    }

        public ICollection<ITask> Tasks
	    {
	        get { return m_Tasks.AsReadOnly(); }
	    }

	    #region Event Handlers

		/// <summary>
		/// Handles when system time is changed and prompts all tasks to recalculation next exectution time.
		/// </summary>
		private void OnSystemTimeChanged(object sender, EventArgs e)
		{
			Log.Debug("System time has been changed. Re-scheduling tasks");
            /*lock (Triggers)
			{
				for(int idx = 0; idx < Triggers.Count; idx++)
				{
                    Triggers[idx].RecalculateNextDateTime();
				}
				Triggers.Sort(comparer);
			}*/
			GetNextWakeTime();
		}

		#endregion

		#region IScheduler Members

		/// <summary>
		/// Add a new scheduled task; next execution DateTime will be calculated for the task
		/// </summary>
		/// <param name="job">Task to be added</param>
		/// <exception cref="SchedulerException">Thrown if the service is not started</exception>
		/// <exception cref="ArgumentNullException">Thrown if the task is NULL</exception>
		/// <exception cref="InvalidOperationException">Thrown if the task already belongs to another Scheduler</exception>
		public void AddJob(IJob job)
		{
			if(job == null)
				throw new ArgumentNullException("job");
			
			lock(m_Jobs)
			{
				if (m_Jobs.Contains(job.Name))
					throw new SchedulerException(String.Format("Job with the same name already exists: {0}", job.Name));

				m_Jobs.Add(job);
			}
			Log.Debug(string.Format("New Scheduled Task {0} added", job.Name));
		}

		/// <summary>
		/// Add several scheduled jobs; next execution DateTime will be calculated for the jobs
		/// </summary>
		/// <param name="jobs">Task to be added</param>
		/// <exception cref="SchedulerException">Thrown if the service is not started</exception>
		/// <exception cref="ArgumentNullException">Thrown if the task is NULL</exception>
		/// <exception cref="InvalidOperationException">Thrown if the task already belongs to another Scheduler</exception>
        public void AddJobRange(IEnumerable<IJob> jobs)
		{
			if(jobs == null)
				throw new ArgumentNullException("jobs");

			lock (m_Jobs)
			{
			    foreach (IJob job in jobs)
			    {
                    if (job == null)
                        throw new ArgumentNullException("jobs", String.Format("Job is null"));

                    if (m_Jobs.Contains(job.Name))
                        throw new SchedulerException(String.Format("Job with the same name already exists: '{0}'", job.Name));
                    
                    m_Jobs.Add(job);
                    Log.Debug(string.Format("New Scheduled Job '{0}' added", job.Name));
			    }
			}
		}

		/// <summary>
		/// RemoveJob Task 
		/// </summary>
		/// <param name="job">Task to be removed</param>
		/// <exception cref="SchedulerException">Thrown: 1) If the service is not started; 2) If provided Task is currently executing</exception>
		/// <exception cref="ArgumentNullException">Throw is provided Task is NULL</exception>
		/// <exception cref="InvalidOperationException">Thrown if provided Task doesn't belong to this Scheduler</exception>
		public void RemoveJob(IJob job)
		{
			if(job == null)
				throw new ArgumentNullException("job");

			if(job.Running)
				throw new SchedulerException(String.Format("Job '{0}' is currently running and can't be removed", job.Name));

			lock(m_Jobs)
			{
                if (!m_Jobs.Contains(job))
                    throw new InvalidOperationException(String.Format("Job '{0}' not assigned to Scheduler '{1}'", job.Name, this));

				m_Jobs.Remove(job);
			}
			Log.Debug(string.Format("Scheduled job {0} removed", job.Name));
		}

        public void AddTrigger(ITrigger trigger)
        {
            if (trigger == null)
                throw new ArgumentNullException("trigger");

            lock (m_Triggers)
            {
                if (m_Triggers.Contains(trigger.Name))
                    throw new SchedulerException(String.Format("Trigger with the same name already exists: {0}", trigger.Name));

                m_Triggers.Add(trigger);
            }
            Log.Debug(string.Format("Trigger '{0}' added", trigger.Name));
            GetNextWakeTime();
        }

        public void AddTriggerRange(IEnumerable<ITrigger> triggers)
        {
            if (triggers == null)
                throw new ArgumentNullException("triggers");

            lock (m_Triggers)
            {
                foreach (ITrigger trigger in triggers)
                {
                    if (trigger == null)
                        throw new ArgumentNullException("triggers", String.Format("trigger is null"));

                    if (m_Triggers.Contains(trigger.Name))
                        throw new SchedulerException(String.Format("trigger with the same name already exists: {0}", trigger.Name));

                    m_Triggers.Add(trigger);
                    Log.Debug(string.Format("Trigger '{0}' added", trigger.Name));
                }
            }
            GetNextWakeTime();
        }

        public void RemoveTrigger(ITrigger trigger)
        {
            if (trigger == null)
                throw new ArgumentNullException("trigger");

            lock (m_Triggers)
            {
                if (!m_Triggers.Contains(trigger))
                    throw new InvalidOperationException(String.Format("trigger '{0}' not assigned to Scheduler '{1}'", trigger.Name, this));

                m_Triggers.Remove(trigger);
            }
            Log.Debug(string.Format("Trigger '{0}' removed", trigger.Name));
        }

        public void AddTask(ITask task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            lock (m_Tasks)
            {
                if (m_Tasks.Contains(task.Name))
                    throw new SchedulerException(String.Format("Task with the same name already exists: {0}", task.Name));

                m_Tasks.Add(task);
            }
            Log.Debug(string.Format("Task '{0}' added", task.Name));
        }

        public void AddTaskRange(IEnumerable<ITask> tasks)
        {
            if (tasks == null)
                throw new ArgumentNullException("tasks");

            lock (m_Tasks)
            {
                foreach (ITask task in tasks)
                {
                    if (task == null)
                        throw new ArgumentNullException("tasks", String.Format("task is null"));

                    if (m_Tasks.Contains(task.Name))
                        throw new SchedulerException(String.Format("task with the same name already exists: {0}", task.Name));

                    m_Tasks.Add(task);
                    Log.Debug(string.Format("Task '{0}' added", task.Name));
                }
            }
        }

        public void RemoveTask(ITask task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            lock (m_Tasks)
            {
                if (!m_Tasks.Contains(task))
                    throw new InvalidOperationException(String.Format("task '{0}' not assigned to Scheduler '{1}'", task.Name, this));

                m_Tasks.Remove(task);
            }
            Log.Debug(string.Format("Task '{0}' removed", task.Name));
        }
		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			GC.SuppressFinalize(this);

			Stop();
		}

		~Scheduler()
		{
			Stop();
		}

		#endregion

		/// <summary>
		/// Start Scheduler; Start handling system time changes
		/// </summary>
		public void Start()
		{
            Log.Debug("Starting Scheduler");

            LoadConfig();

            /*InitConfig();

            ITask task = new TestTask();
            
            AddTask(task);

		    IJob testJob = new Job();
		    testJob.Name = "testJob";
		    testJob.Active = true;
		    testJob.StopOnError = true;
            testJob.Tasks.Add(task);
            
            AddJob(testJob);

		    ITrigger trigger = new DailyTrigger("test", DateTime.Now.AddMinutes(3));
            ITrigger trigger2 = new DailyTrigger("test2", DateTime.Now.AddMinutes(5));
            trigger.Jobs.Add(testJob);

            AddTrigger(trigger);
            AddTrigger(trigger2);*/

            SaveConfig();

            User user;
            try
            {
                if (ServerEnvironment.AuthorizationService.LoginVersionCheck(_ConfigSection.Login, _ConfigSection.Password, out user, ServerEnvironment.ServerVersion) != LoginResult.Successful)
                {
                    Log.Debug("Scheduler login failed");
                    return;
                }
                else
                    Log.Debug("Scheduler login successfull");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

			lock (m_Triggers)
			{
				m_Triggers.Sort(comparer);
			}
			//
			SystemEvents.TimeChanged += OnSystemTimeChanged;
			//
			_started = true;

			// Run
            InheritedContextAsyncStarter.Run(OnNextEvent);
		}

		/// <summary>
		/// Stop Scheduler; Stop handlng system time changes
		/// </summary>
		public void Stop()
		{
			if(_started)
			{
				Log.Debug("Stopping Scheduler service");

				ServerEnvironment.AuthorizationService.Logout();

                SystemEvents.TimeChanged -= OnSystemTimeChanged;

				//_timer.Change(Timeout.Infinite, Timeout.Infinite);
				
				lock(m_Jobs)
                lock(m_Triggers)
				{
                    //_timer.Dispose();
                    m_Jobs.Clear();
                    m_Triggers.Clear();
					_started = false;
				}
			}
		}

		//
        #region Private members

		/// <summary>
		/// Set delay timout for Timer - to sleep until next Task should be executed
		/// </summary>
		private TimeSpan GetNextWakeTime()
		{
			lock(m_Triggers)
			{
                if (m_Triggers.Count == 0)
				{
					//_timer.Change(Timeout.Infinite, Timeout.Infinite); // this will put the timer to sleep
                    if(Log.IsDebugEnabled)
                        Log.Debug("Scheduler freezed.");

                    return TimeSpan.FromMilliseconds(100);
				}
                _nearest_time = m_Triggers[0].NextDateTime;
				TimeSpan ts = _nearest_time.Subtract(DateTime.Now);
				if(ts < TimeSpan.Zero)
				{
					ts = TimeSpan.Zero; // cannot be negative !
				}
                if (Log.IsDebugEnabled)
                    Log.Debug(string.Format("Next Scheduler wakeup after: {0}", ts));
				//_timer.Change(Convert.ToInt64(ts.TotalMilliseconds), Timeout.Infinite); // invoke after the timespan}
			    return ts;
			}
		}

		/// <summary>
		/// Timer's delay timeout expired; Execute first Task is tasks list
		/// </summary>
        private void OnNextEvent() // obj ignored
		{
            while (true)
            {
                lock (m_Triggers)
                {
                    if (m_Triggers.Count == 0)
                        return;

                    ITrigger trigger = m_Triggers[0];
                    if (Log.IsDebugEnabled)
                        Log.Debug(string.Format("Kicked by trigger {0}", trigger.Name));

                    if (trigger.Active && trigger.NextDateTime <= DateTime.Now)
                        Execute(trigger.Jobs);

                    trigger.RecalculateNextDateTime();
                    m_Triggers.Sort(comparer);
                }
                Thread.Sleep(GetNextWakeTime());
                Thread.Sleep(100);
            }
		}

	    #endregion

        private static void Execute(IEnumerable<IJob> jobs)
        {
            foreach (IJob job in jobs)
            {
                if (job.Active)
                {
                    if (Log.IsDebugEnabled)
                        Log.Debug(string.Format("Starting job: {0}", job.Name));

                    InheritedContextAsyncStarter.Run(job.Run);
                }
            }
        }

        #region IInitializingObject Members

        public void AfterPropertiesSet()
        {
            Start();
        }

	    #endregion

        #region IJobResolver Members

        public IJob GetJobByName(string name)
        {
            return m_Jobs[name];
        }

        #endregion

        #region ITaskResolver Members

        public ITask GetTaskByName(string name)
        {
            return m_Tasks[name];
        }

        #endregion

        private void InitConfig()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scheduler.config");
            _Config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            _ConfigSection = _Config.Sections["Scheduler"] as SchedulerSection;
            if (_ConfigSection == null)
            {
                _ConfigSection = new SchedulerSection();
                _Config.Sections.Add("Scheduler", _ConfigSection);
                _ConfigSection = _Config.GetSection("Scheduler") as SchedulerSection;
                _ConfigSection.SectionInformation.ForceSave = false;
                _Config.Save(ConfigurationSaveMode.Full);
            }
        }

        private void LoadConfig()
        {
            m_Jobs.Clear();
            m_Tasks.Clear();
            m_Triggers.Clear();

            InitConfig();

            foreach (ConfigElement element in _ConfigSection.Tasks)
            {
                Type taskType = Type.GetType(element.TypeName);
                ConstructorInfo ci = taskType.GetConstructor(Type.EmptyTypes);
                ITask task = (ITask)ci.Invoke(new object[0]);
                
                ValuesCollection vc = ValuesCollection.FromString(element.Config);
                task.LoadValues(vc);

                m_Tasks.Add(task);
            }

            foreach (ConfigElement element in _ConfigSection.Jobs)
            {
                Type jobType = Type.GetType(element.TypeName);
                ConstructorInfo ci = jobType.GetConstructor(Type.EmptyTypes);
                IJob job = (IJob)ci.Invoke(new object[0]);

                ValuesCollection vc = ValuesCollection.FromString(element.Config);
                job.LoadValues(vc, this);

                m_Jobs.Add(job);
            }

            foreach (ConfigElement element in _ConfigSection.Triggers)
            {
                Type triggerType = Type.GetType(element.TypeName);
                ConstructorInfo ci = triggerType.GetConstructor(Type.EmptyTypes);
                ITrigger trigger = (ITrigger)ci.Invoke(new object[0]);
                
                ValuesCollection vc = ValuesCollection.FromString(element.Config);
                trigger.LoadValues(vc, this);

                m_Triggers.Add(trigger);
            }
        }

        public void SaveConfig()
        {
            if (string.IsNullOrEmpty(_ConfigSection.Login))
            {
                _ConfigSection.Login = "scheduler";
                _ConfigSection.Password = "";
            }

            _ConfigSection.Tasks.Clear();
            foreach (ITask task in m_Tasks)
            {
                string typeName = task.GetType().FullName;

                ConfigElement el = new ConfigElement();

                ValuesCollection vc = new ValuesCollection();
                task.SaveValues(vc);

                el.Config = vc.ToString();
                el.Name = task.Name;
                el.TypeName = typeName;
                _ConfigSection.Tasks.Add(el);
            }

            _ConfigSection.Jobs.Clear();
            foreach (IJob job in m_Jobs)
            {
                string typeName = job.GetType().FullName;

                ConfigElement el = new ConfigElement();
                
                ValuesCollection vc = new ValuesCollection();
                job.SaveValues(vc);

                el.Config = vc.ToString();
                el.Name = job.Name;
                el.TypeName = typeName;
                _ConfigSection.Jobs.Add(el);
            }

            _ConfigSection.Triggers.Clear();
            foreach (ITrigger trigger in m_Triggers)
            {
                string typeName = trigger.GetType().FullName;
                
                ValuesCollection vc = new ValuesCollection();
                ConfigElement el = new ConfigElement();

                trigger.SaveValues(vc);

                el.Name = trigger.Name;
                el.TypeName = typeName;
                el.Config = vc.ToString();

                _ConfigSection.Triggers.Add(el);
            }

            _Config.Save(ConfigurationSaveMode.Full);
        }
    }
}