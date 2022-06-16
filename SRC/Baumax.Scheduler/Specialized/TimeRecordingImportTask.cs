using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class TimeRecordingImportTask : Task
    {
        public TimeRecordingImportTask()
            : base("TimeRecordingImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("TimeRecording import started");

                ImportDataManager.Instance.Import(ImportType.TimeRecording);

                Log.Debug("TimeRecording import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
