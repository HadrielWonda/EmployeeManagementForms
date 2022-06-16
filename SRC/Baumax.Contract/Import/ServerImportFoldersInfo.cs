using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
    [Serializable]
    public struct ServerImportFoldersInfo
    {
        public string SourceFolder;
        public string ImportedFolder;
        public ServerImportFoldersInfo(string sourceFolder, string importedFolder)
        {
            SourceFolder = sourceFolder;
            ImportedFolder = importedFolder;
        }
    }
}
