using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
    [Serializable]
    public class ImportLongTimeAbsenceData
    {
        public string PersID;
        public short Code;
        public string CodeName;
        public DateTime BeginTime;
        public DateTime EndTime;
    }
}
