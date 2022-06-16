using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Baumax.Domain;
using Common.Logging;

namespace Baumax.Scheduler
{
    [Serializable]
    public sealed class Job : Task, IJob 
    {
        private Tasks m_Tasks = new Tasks();
        private ITask m_OnErrorTask;
        private bool m_StopOnError;

        public Job()
        {}

        public Job(string name) : base(name)
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                if (Running && !ParallelRunEnabled)
                    return;

                Running = true;
                _lastExecutionDateTime = DateTime.Now;

                if (Log.IsDebugEnabled)
                {
                    User usr;
                    LocalDataStoreSlot slot = Thread.GetNamedDataSlot("User");
                    usr = (User)Thread.GetData(slot);
                    string name = usr == null ? "" : usr.LoginName;

                    Log.Debug(string.Format("Job '{0}' running under user '{1}'", Name, name));
                }

                foreach (ITask task in m_Tasks)
                {
                    if (!RunTask(task))
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Job:{0} failed", Name), ex);
                throw;
            }
            finally
            {
                Running = false;
            }
        }

        private bool RunTask(ITask task)
        {
            if (task != null && task.Active)
            {
                try
                {
                    task.Run();
                }
                catch (Exception ex)
                {
                    Log.Warn(string.Format("Running of Task:'{0}' in Job:'{1}' failed", task.Name, Name), ex);

                    if (task != m_OnErrorTask)
                        RunTask(m_OnErrorTask);

                    return !StopOnError;
                }
            }

            return true;
        }

        #region IJob Members

        public Tasks Tasks
        {
            get { return m_Tasks; }
            set { m_Tasks = value; }
        }

        public ITask OnErrorTask
        {
            get { return m_OnErrorTask; }
            set { m_OnErrorTask = value;}
        }

        public bool StopOnError
        {
            get { return m_StopOnError; }
            set{ m_StopOnError = value;}
        }

        public void LoadValues(IDictionary<string, string> cfg, ITaskResolver taskResolver)
        {
            LoadValues(cfg);

            OnErrorTask = taskResolver.GetTaskByName(cfg["OnErrorTask"]);
            StopOnError = bool.Parse(cfg["StopOnError"]);

            Tasks.Clear();
            string[] tasks = cfg["Tasks"].Split(':');
            foreach (string taskName in tasks)
            {
                Tasks.Add(taskResolver.GetTaskByName(taskName));
            }
        }

        public override void SaveValues(IDictionary<string, string> cfg)
        {
            base.SaveValues(cfg);

            if (OnErrorTask != null)
                cfg["OnErrorTask"] = OnErrorTask.Name;
            else
                cfg["OnErrorTask"] = "";

            cfg["StopOnError"] = StopOnError.ToString();
            StringBuilder sb = new StringBuilder();
            foreach (ITask task in m_Tasks)
            {
                sb.AppendFormat("{0}:", task.Name);
            }

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            cfg.Add("Tasks", sb.ToString());
        }

        #endregion
    }
}
