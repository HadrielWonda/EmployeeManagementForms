using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    public enum Changed : short { NotChanged = 0, Changed = 1}

    [Serializable]
    public class ImportEmployeeResult
    {
        public bool Success;
        public object DataError;
        public object DataChanged;
    }

    [Serializable]
    public class EmployeeChanged
    {
        public long EmployeeID;
        public Changed Contract;
        public Changed AllIn;
        public Changed BalanceHours;
    }
}
