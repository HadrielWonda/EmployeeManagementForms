using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class ActualBusinessVolumeImportTask : Task
    {
        public ActualBusinessVolumeImportTask()
            : base("ActualBusinessVolumeImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("ActualBusinessVolume import started");

                ImportDataManager.Instance.Import(ImportType.ActualBusinessVolume);

                Log.Debug("ActualBusinessVolume import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
