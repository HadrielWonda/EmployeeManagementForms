using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class EstimateResult
    {
        public bool Success;
        public object Data;
    }
}
