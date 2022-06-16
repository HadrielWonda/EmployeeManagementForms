using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Estimate
{
    [Serializable]
    public class BusinessVolumeTargActSum
    {
        public long StoreID;
        public long WorldID;
        public decimal VolumeBC;
        public decimal VolumeCC;
    }
}
