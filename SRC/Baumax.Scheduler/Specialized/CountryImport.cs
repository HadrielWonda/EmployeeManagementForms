using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class CountryImportTask : Task
    {
        public CountryImportTask()
            : base("CountryImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Country import started");
                
                ImportDataManager.Instance.Import(ImportType.Country);

                Log.Debug("Country import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
