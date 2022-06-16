using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class AbsenceImportTask : Task
    {
        public AbsenceImportTask()
            : base("AbsenceImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Absence import started");

                ImportDataManager.Instance.Import(ImportType.Absence);

                Log.Debug("Absence import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
