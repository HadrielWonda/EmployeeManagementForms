using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class EstimatedWorldWorkingHours
    {
        public DateTime Date;
        public decimal WorkingHours;
    }
}
