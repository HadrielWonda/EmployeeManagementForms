using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class CanEstimateWorkingHoursResult
    {
        public EstimateWorkingHoursCondition Condition;
        public bool Result;
    }
}
