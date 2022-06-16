using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class DeleteFilesOutOfDateTask : Task
    {
        public DeleteFilesOutOfDateTask()
            : base("DeleteFilesOutOfDateTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("Delete out of date files started");

                ImportFileManager.Instance.DeleteFilesOutOfDate(); 

                Log.Debug("Delete out of date files successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
