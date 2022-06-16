using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Scheduler.Specialized
{
    [Serializable]
    public sealed class MonthlyTrigger : Trigger
    {
        public MonthlyTrigger()
        {
        }

        public MonthlyTrigger(string name, DateTime start)
            : base(name, start)
        {
        }

        protected internal override DateTime CalculateNextExecutionTime()
        {
            if (!_lastExecutionDateTime.HasValue || _lastExecutionDateTime.Value == DateTime.MinValue)
            {
                if (DateTime.Now > Start)
                {
                    DateTime tm = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Start.Day, Start.Hour, Start.Minute, Start.Second, Start.Millisecond);

                    return tm.AddMonths(1);
                }
                else
                    return Start;
            }
            else if (DateTime.Now > _lastExecutionDateTime.Value)
            {
                return _lastExecutionDateTime.Value.AddMonths(1);
            }
            else
                return _lastExecutionDateTime.Value;
        }
    }
}
