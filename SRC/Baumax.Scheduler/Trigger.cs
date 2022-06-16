using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Text;
using Baumax.Scheduler.Config;
using Common.Logging;

namespace Baumax.Scheduler
{
    [Serializable]
    public abstract class Trigger : ITrigger
    {
        static readonly protected ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private bool _active = true;
        private string _name = String.Empty;
        private DateTime m_Start;
        private DateTime _nextDateTime;
        private Jobs m_Jobs = new Jobs();

        protected DateTime? _lastExecutionDateTime;

        public Trigger()
		{
		}

		public Trigger(string name)
		{
			_name = name;
		}

        public Trigger(string name, DateTime start)
            : this(name)
        {
            m_Start = start;
        }

        public Jobs Jobs
        {
            get { return m_Jobs; }
            set { m_Jobs = value; }
        }
        /// <summary>
        /// Gets or sets whether the task is active. Inactive tasks are not executed, but participates in scheduling as active tasks
        /// </summary>
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        /// <summary>
        /// Next scheduled execution time; The property should be used to change NextDateTime from external
        /// </summary>
        public DateTime NextDateTime
        {
            get { return _nextDateTime; }
            protected set
            {
                _nextDateTime = value;
                _lastExecutionDateTime = null;
                OnTaskTimeChanged();
            }
        }

        public DateTime Start
        {
            get { return m_Start; }
            set
            {
                m_Start = value;
                NextDateTime = CalculateNextExecutionTime();
            }
        }

        /// <summary>
        /// Task name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    value = String.Empty;
                }
                if (_name != value)
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Force task to recalculate NextDateTime. 
        /// </summary>
        public void RecalculateNextDateTime()
        {
            _lastExecutionDateTime = _nextDateTime;
            _nextDateTime = CalculateNextExecutionTime();
            if (Log.IsDebugEnabled)
                Log.Debug(string.Format("Trigger '{0}' next execution DateTime changed: {1}", Name, NextDateTime));
        }

        /// <summary>
        /// Inheritor classes should provide calculation of next execution DateTime
        /// </summary>
        /// <returns>DateTime of next execution</returns>
        protected internal abstract DateTime CalculateNextExecutionTime();

        public override string ToString()
        {
            return Name;
        }

        public virtual void SaveValues(IDictionary<string, string> cfg)
        {
            cfg.Add("Name", Name);
            cfg.Add("Active", Active.ToString());
            cfg.Add("Start", Start.ToString(CultureInfo.GetCultureInfo(0x0C07))); //de-At
            StringBuilder sb = new StringBuilder();
            foreach (IJob job in m_Jobs)
            {
                sb.AppendFormat("{0}:", job.Name);
            }
            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            cfg.Add("Jobs", sb.ToString());
        }

        public virtual void LoadValues(IDictionary<string, string> cfg, IJobResolver jobResolver)
        {
            Name = cfg["Name"];
            Active = bool.Parse(cfg["Active"]);
            Start = DateTime.Parse(cfg["Start"], CultureInfo.GetCultureInfo(0x0C07));//de-at

            m_Jobs.Clear();
            string[] jobs = cfg["Jobs"].Split(':');
            foreach (string jobName in jobs)
            {
                m_Jobs.Add(jobResolver.GetJobByName(jobName));
            }
        }

        /// <summary>
        /// When NextDateTime of Task is changed from external, Scheduler should be notified to recalculate timer
        /// </summary>
        protected virtual void OnTaskTimeChanged()
        {
            Log.Debug(string.Format("Trigger '{0}' next execution DateTime changed: {1}", Name, NextDateTime));
        }

    }
}
