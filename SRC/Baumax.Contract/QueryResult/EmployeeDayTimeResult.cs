using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class EmployeeDayTimeResult : ISerializable
    {
        private long _employeeID;
        private decimal _coefficient;
        private DateTime _contractBegin;
        private DateTime _contractEnd;

        public virtual DateTime ContractEnd
        {
            get { return _contractEnd; }
            set { _contractEnd = value; }
        }
        public virtual DateTime ContractBegin
        {
            get { return _contractBegin; }
            set { _contractBegin = value; }
        }
        public virtual decimal Coefficient
        {
            get { return _coefficient; }
            set { _coefficient = value; }
        }
        public virtual long EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        protected EmployeeDayTimeResult(SerializationInfo info, StreamingContext context)
        {
            _contractBegin = info.GetDateTime("cb");
            _contractEnd = info.GetDateTime("ce");
            _coefficient = info.GetDecimal("dt");
            _employeeID = info.GetInt64("em");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("cb", _contractBegin);
            info.AddValue("ce", _contractEnd);
            info.AddValue("dt", _coefficient);
            info.AddValue("em", _employeeID);
        }

        public EmployeeDayTimeResult()   { }
        
        public EmployeeDayTimeResult (long employeeID, DateTime begin, DateTime end, decimal coeficient)
        {
            _coefficient = coeficient;
            _contractBegin = begin;
            _contractEnd = end;
            _employeeID = employeeID;
        }
    }
}
