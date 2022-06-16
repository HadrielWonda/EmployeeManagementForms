using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Estimate
{
    [Serializable]
    public class BusinessVolumeCRR
    {
        public DateTime Date;
        public byte Hour;
        public int Number;
    }
}
