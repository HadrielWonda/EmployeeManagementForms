using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    /*
     * Result from query: which employee have contract end date != relation end date
     * Used in employee service
     */
    [Serializable]
    public class DiffContractRelation
    {
        public long EmployeeId = 0;
        public DateTime ContractEnd;
        public DateTime RelationEnd;
        public DiffContractRelation()
        {
            ContractEnd = DateTimeSql.SmallDatetimeMax;
            RelationEnd = DateTimeSql.SmallDatetimeMax;
        }
    }
}
