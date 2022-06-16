using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class WgrImportTask : Task
    {
        public WgrImportTask()
            : base("WgrImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Wgr import started");

                ImportDataManager.Instance.Import(ImportType.WGR);

                Log.Debug("Wgr import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
