using System;
using Baumax.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    [Serializable]
    public sealed class OneTimeTrigger : Trigger
	{
		public OneTimeTrigger()
		{
		}

        public OneTimeTrigger(string name, DateTime startDateTime)
		{
			if(startDateTime < DateTime.Now)
			{
				throw new SchedulerException("OneTime task date must be in the future");
			}
			Name = name;
			NextDateTime = startDateTime;
		}

		protected internal override DateTime CalculateNextExecutionTime()
		{
			return NextDateTime < DateTime.Now ? DateTime.MaxValue : NextDateTime;
		}
	}
}