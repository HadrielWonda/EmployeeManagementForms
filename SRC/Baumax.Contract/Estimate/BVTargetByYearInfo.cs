using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;

namespace Baumax.Contract
{
    [Serializable]
    public class BVTargetByYearInfo : IKey<string>
    {
        private long _StoreID;
        private short _Year;
        private byte _MonthBegin;
        private byte _MonthEnd;

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

        public byte MonthBegin
        {
            get { return _MonthBegin; }
            set { _MonthBegin = value; }
        }

        public byte MonthEnd
        {
            get { return _MonthEnd; }
            set { _MonthEnd = value; }
        }

        #region IKey<> implementation

        public string GetKey()
        {
            return StoreID.ToString() + Year.ToString();
        }
        #endregion

    }
}
