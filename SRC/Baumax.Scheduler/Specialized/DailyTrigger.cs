using System;

namespace Baumax.Scheduler.Specialized
{
	/// <summary>
	/// Base Task for DailyTasks. This Task uses only time of day for execution scheduling
	/// </summary>
    [Serializable]
    public sealed class DailyTrigger : Trigger
	{
        public DailyTrigger()
        {
        }

        public DailyTrigger(string name, DateTime start)
            : base(name, start)
        {
        }

        protected internal override DateTime CalculateNextExecutionTime()
        {
            if (!_lastExecutionDateTime.HasValue || _lastExecutionDateTime.Value == DateTime.MinValue)
            {
                if (DateTime.Now > Start)
                {
                    DateTime tm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Start.Hour, Start.Minute, Start.Second, Start.Millisecond);

                    return tm.AddDays(1);
                }
                else
                    return Start;
            }
            else if (DateTime.Now > _lastExecutionDateTime.Value)
            {
                return _lastExecutionDateTime.Value.AddDays(1);
            }
            else
                return _lastExecutionDateTime.Value;
        }
	}
}