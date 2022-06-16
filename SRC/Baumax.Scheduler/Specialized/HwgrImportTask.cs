using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class HwgrImportTask : Task
    {
        public HwgrImportTask()
            : base("HwgrImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Hwgr import started");

                ImportDataManager.Instance.Import(ImportType.HWGR);

                Log.Debug("Hwgr import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
