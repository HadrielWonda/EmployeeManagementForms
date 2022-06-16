using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class RegionImportTask : Task
    {
        public RegionImportTask()
            : base("RegionImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Region import started");

                ImportDataManager.Instance.Import(ImportType.Region);

                Log.Debug("Region import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
