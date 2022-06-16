using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class WorldImportTask : Task
    {
        public WorldImportTask()
            : base("WorldImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("World import started");

                ImportDataManager.Instance.Import(ImportType.World);

                Log.Debug("World import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
