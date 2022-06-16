using System;
using System.Collections;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    public enum AResult { Success, Error }
    [Serializable]
    public class AssignResult
    {
        public AResult Result;
        public IList Data;
    }
}
