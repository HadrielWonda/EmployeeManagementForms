using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Common.Logging;
using Baumax.AppServer.Environment;

namespace Baumax.Import.Scheduler
{
    public class ImportFileManager
    {
        const string _LogSeparatorString = "-----------------------------------------------------";
        const string _RemoveStartMessage = "'{0}' remove files started";
        const string _RemoveCompleteMessage = "'{0}'remove files completed";

        static readonly ILog log;
        string _ImportedFolder;
        int _DaysFilesOutOfDate;
        string _LogFileName = "DeleteFilesOutOfDate.log";

        static bool _DeleteFilesRunning;
        static object _SyncDeleteFilesRunning = new Object();
        static object _SyncRoot = new Object();


        static ImportFileManager()
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private static volatile ImportFileManager _ImportFileManager;

        static public ImportFileManager Instance
		{
			get
			{
				if (_ImportFileManager == null)
				{
					lock (_SyncRoot)
					{
						if (_ImportFileManager == null)
						{
                            _ImportFileManager = new ImportFileManager();
						}
					}
				}
				return _ImportFileManager;
			}
		}

        private ImportFileManager()
        {
            _ImportedFolder = ServerEnvironment.ImportSettings.ImportedFolder;
            _DaysFilesOutOfDate = ServerEnvironment.ImportSettings.DaysFilesOutOfDate;
            _LogFileName = Path.Combine(ServerEnvironment.ImportSettings.ImportLogsFolder, _LogFileName);
        }


        static bool DeleteFilesRunning
        {
            set
            {
                lock (_SyncDeleteFilesRunning)
                {
                    if (_DeleteFilesRunning != value)
                    {
                        _DeleteFilesRunning = value;
                    }
                }
            }
            get
            {
                return _DeleteFilesRunning;
            }
        }


        public void DeleteFilesOutOfDate()
        {
            if (DeleteFilesRunning)
                throw new AnotherDeleteFilesOutOfDateRunning();
            else
                DeleteFilesRunning = true;
            try
            {
                deleteFilesOutOfDate();
            }
            finally
            {
                DeleteFilesRunning = false;
            }
        }

        private void deleteFilesOutOfDate()
        {
            AddTextToLogFile(string.Format(_RemoveStartMessage, DateTime.Now), true);
            string[] filesToDelete = GetFilesToDelete();
            for (int i = 0; i < filesToDelete.Length; i++)
            {
                File.Delete(filesToDelete[i]);
                AddTextToLogFile(filesToDelete[i], true);
            }
            AddTextToLogFile(string.Format(_RemoveCompleteMessage, DateTime.Now), true);
            AddTextToLogFile(_LogSeparatorString, true);
        }

        string[] GetFilesToDelete()
        {
            DateTime compareDate= DateTime.Now;
            compareDate= compareDate.AddDays((-1) * _DaysFilesOutOfDate);
            List<string> filesToDelete= new List<string> ();
            DirectoryInfo di = new DirectoryInfo(_ImportedFolder);
            FileInfo[] fi = di.GetFiles();
            foreach (FileInfo fiTemp in fi)
            {
                if (fiTemp.LastWriteTime <= compareDate)
                    filesToDelete.Add(fiTemp.FullName);
            }
            return filesToDelete.ToArray();
        }

        private void AddTextToLogFile(string message, bool newLine)
        {
            Util.AddTextToLogFile(_LogFileName, message, newLine);
        }
}

}
