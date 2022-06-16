using System;
using System.Collections.Generic;

namespace Baumax.Scheduler.Specialized
{
    [Serializable]
    public sealed class PeriodicTrigger : Trigger
	{
		private long _periodMilliseconds;

		public PeriodicTrigger()
		{
		}

        public PeriodicTrigger(string name, long periodMilliseconds) : base(name)
		{
			PeriodMilliseconds = periodMilliseconds;
		}

		public long PeriodMilliseconds
		{
			get { return _periodMilliseconds; }
			set
			{
				if (value <= 0)
				{
					throw new SchedulerException("Periodic task period must be greater than 0");
				}
				_periodMilliseconds = value;
				NextDateTime = CalculateNextExecutionTime();
			}
		}

        protected internal override DateTime CalculateNextExecutionTime()
		{
            if (!_lastExecutionDateTime.HasValue || _lastExecutionDateTime.Value == DateTime.MinValue)
			{
				return DateTime.Now.AddMilliseconds(_periodMilliseconds);
			} 
            else
			{
				return _lastExecutionDateTime.Value.AddMilliseconds(_periodMilliseconds);
			}
		}

        public override void SaveValues(IDictionary<string, string> cfg)
        {
            base.SaveValues(cfg);

            cfg.Add("PeriodMilliseconds", PeriodMilliseconds.ToString());
        }

        public override void LoadValues(IDictionary<string, string> cfg, IJobResolver jobResolver)
        {
            base.LoadValues(cfg, jobResolver);

            PeriodMilliseconds = long.Parse(cfg["PeriodMilliseconds"]);
        }
	}
}