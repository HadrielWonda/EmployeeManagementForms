using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Common.Logging;
using System.IO;

namespace Baumax.Scheduler
{
	/// <summary>
	/// Base class for ScheduledTasks used by Scheduler
	/// </summary>
	public abstract class Task : ITask
	{
        static readonly protected ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private bool _active = true;
		private bool _running;
		private string _name = String.Empty;
	    private bool m_ParallelRunEnabled;

		protected DateTime? _lastExecutionDateTime;

		public Task()
		{
		}

		public Task(string name)
		{
			_name = name;
		}

		/// <summary>
		/// Gets whether the task is currently executing
		/// </summary>
		public bool Running
		{
			get { return _running; }
            protected set { _running = value; }
		}
		
		/// <summary>
		/// Task name
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if(value == null)
				{
					value = String.Empty;
				}
				if(_name != value)
				{
					_name = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets whether the task is active. Inactive tasks are not executed, but participates in scheduling as active tasks
		/// </summary>
		public bool Active
		{
			get { return _active; }
			set { _active = value; }
		}

	    public bool ParallelRunEnabled
	    {
	        get { return m_ParallelRunEnabled; }
	        set { m_ParallelRunEnabled = value; }
	    }

	    /// <summary>
	    /// Start task execution. For inactive task, only next execution DateTime will be recalculated
	    /// </summary>
	    public virtual void Run()
	    {
            if (!Active)
                return;

            if (Running && !ParallelRunEnabled)
                throw new SchedulerException("Cannot run in new thread since already running in differernt thread.");

            Running = true;
	        _lastExecutionDateTime = DateTime.Now;
	    }

		public override string ToString()
		{
			return Name;
		}
        
        #region ITask Members


        public virtual void SaveValues(IDictionary<string, string> cfg)
        {
            cfg["Name"] = Name;
            cfg["Active"] = Active.ToString();
            cfg["ParallelRunEnabled"] = ParallelRunEnabled.ToString();
        }

        public virtual void LoadValues(IDictionary<string, string> cfg)
        {
            Name  = cfg["Name"];
            Active = bool.Parse(cfg["Active"]);
            ParallelRunEnabled = bool.Parse(cfg["ParallelRunEnabled"]);
        }

        #endregion
    }
}