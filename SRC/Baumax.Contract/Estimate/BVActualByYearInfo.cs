using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;

namespace Baumax.Contract
{
    [Serializable]
    public class BVActualByYearInfo: IKey<string>
    {
        private long _StoreID;
        private short _Year;
        private DateTime _DateBegin;
        private DateTime _DateEnd;

        public long StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
        }

        public short Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public DateTime DateBegin
        {
            get { return _DateBegin; }
            set { _DateBegin = value; }
        }

        public DateTime DateEnd
        {
            get { return _DateEnd; }
            set { _DateEnd = value; }
        }
        #region IKey<> implementation
        
        public string GetKey()
        {
            return StoreID.ToString() + Year.ToString();
        }
        #endregion
    }
}
