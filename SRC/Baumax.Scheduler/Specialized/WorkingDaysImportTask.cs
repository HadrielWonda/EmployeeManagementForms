using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class WorkingDaysImportTask : Task
    {
        public WorkingDaysImportTask()
            : base("WorkingDaysImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("WorkingDays import started");

                ImportDataManager.Instance.Import(ImportType.WorkingDays);

                Log.Debug("WorkingDays import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
