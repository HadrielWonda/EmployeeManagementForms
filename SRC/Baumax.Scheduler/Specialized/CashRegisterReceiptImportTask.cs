using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;
using Baumax.Import.Scheduler;

namespace Baumax.Scheduler.Specialized
{
    public sealed class CashRegisterReceiptImportTask : Task
    {
        public CashRegisterReceiptImportTask()
            : base("CashRegisterReceiptImportTask")
        {
        }

        public override void Run()
        {
            try
            {
                if (!Active)
                    return;

                base.Run();
                Log.Debug("CashRegisterReceipt import started");

                ImportDataManager.Instance.Import(ImportType.CashRegisterReceipt);

                Log.Debug("CashRegisterReceipt import successfully finished.");
            }
            finally
            {
                Running = false;
            }
        }
    }
}
