using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class EmployeeImportTask : Task
    {
        public EmployeeImportTask()
            : base("EmployeeImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Employee import started");

                ImportDataManager.Instance.Import(ImportType.Employee);

                Log.Debug("Employee import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
