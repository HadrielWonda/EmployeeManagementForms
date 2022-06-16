using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class StoreDelayInfo
    {
        private long storeID;
        private DateTime lastChange;

        public virtual long StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }

        public virtual DateTime LastChange
        {
            get { return lastChange; }
            set { lastChange = value; }
        }
    }
}
