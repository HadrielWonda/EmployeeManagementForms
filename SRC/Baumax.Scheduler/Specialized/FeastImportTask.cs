using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class FeastImportTask : Task
    {
        public FeastImportTask()
            : base("FeastImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Feast import started");

                ImportDataManager.Instance.Import(ImportType.Feast);

                Log.Debug("Feast import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
