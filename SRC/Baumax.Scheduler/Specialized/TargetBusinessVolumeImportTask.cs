using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class TargetBusinessVolumeImportTask : Task
    {
        public TargetBusinessVolumeImportTask()
            : base("TargetBusinessVolumeImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("TargetBusinessVolume import started");

                ImportDataManager.Instance.Import(ImportType.TargetBusinessVolume);

                Log.Debug("TargetBusinessVolume import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
