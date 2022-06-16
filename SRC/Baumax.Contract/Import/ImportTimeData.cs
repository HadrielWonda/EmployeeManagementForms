using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
    [Serializable]
    public class ImportTimeData
    {
        public string PersID;
        public DateTime Date;
        public string CharID;
        public short Begin;
        public short End;
    }
}
