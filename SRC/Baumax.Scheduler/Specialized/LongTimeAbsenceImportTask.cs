using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class LongTimeAbsenceImportTask : Task
    {
        public LongTimeAbsenceImportTask()
            : base("LongTimeAbsenceImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("LongTimeAbsence import started");

                ImportDataManager.Instance.Import(ImportType.LongTimeAbsence);

                Log.Debug("LongTimeAbsence import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
