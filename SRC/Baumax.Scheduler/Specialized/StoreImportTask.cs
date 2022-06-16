using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class StoreImportTask : Task
    {
        public StoreImportTask()
            : base("StoreImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Store import started");

                ImportDataManager.Instance.Import(ImportType.Store);

                Log.Debug("Store import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
