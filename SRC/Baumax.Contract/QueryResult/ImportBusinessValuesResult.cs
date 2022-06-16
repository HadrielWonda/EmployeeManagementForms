using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Import;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class ImportBusinessValuesResult
    {
        public BusinessVolumeType BusinessVolumeType;
        public bool Success;
        public int FilesCount; 
        public object Data;
    }
}
