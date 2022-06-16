using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
    [Serializable]
    public class ImportAbsenceData
    {
        public int SystemID;
        public string Name;
        public string CharID;

        public ImportAbsenceData()
        { 
        
        }
        
        public ImportAbsenceData(int systemID, string name, string charID)
        {
            SystemID = systemID;
            Name = name;
            CharID = charID;
        }
    }
}
