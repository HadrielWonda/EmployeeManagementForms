using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class CanEstimateCashDeskPeopleResult
    {
        public EstimateCashDeskPeopleCondition Condition;
        public bool Result;
    }
}
