using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class TimePlanningImportTask : Task
    {
        public TimePlanningImportTask()
            : base("TimePLanningImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("TimePLanning import started");

                ImportDataManager.Instance.Import(ImportType.TimePlanning);

                Log.Debug("TimePLanning import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
