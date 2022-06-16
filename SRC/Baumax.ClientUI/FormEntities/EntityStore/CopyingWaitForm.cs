using System;
using System.Drawing;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Import;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    public partial class CopyingWaitForm : XtraForm
    {

        public int mode;
        private const int actualBusinessVol = 0;
        private const int cashDeskVol = 1;
        private const int targetVol = 2;
        public long fromStoreID;
        public long toStoreID;
        public short beginDate;
        public short endDate;
        public BVcopyFromStoreResult result;
        public Exception error = null;
        public CopyingWaitForm()
        {
            InitializeComponent();
            bt_OK.Enabled = false;
            if (ClientEnvironment.IsRuntimeMode)
            {
               ClientEnvironment.StoreService.BVCopyFromStoreComplete += new OperationCompleteDelegate(StoreService_BVCopyFromStoreComplete);
            }
        }

        private void StoreService_BVCopyFromStoreComplete(object sender, OperationCompleteEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OperationCompleteDelegate(StoreService_BVCopyFromStoreComplete), new object[] { sender, e });
            }
            else
            {
                if (!e.Success)
                {
                    if (e.Param is Exception)
                    {
                        error = (Exception)e.Param;
                        DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        result = (BVcopyFromStoreResult)e.Param;
                        switch (result)
                        {
                            case BVcopyFromStoreResult.DataExistsInSelectedTimeRange:
                                DialogResult = DialogResult.Cancel;
                                break;
                            case BVcopyFromStoreResult.NoDataCopy:
                                DialogResult = DialogResult.Cancel;
                                break;
                            case BVcopyFromStoreResult.Success:

                                lb_mess.ForeColor = Color.Green;
                                lb_mess.Text = Localizer.GetLocalized("CopyingCompletedSuccessfully");
                                ProgressBar.Properties.Stopped = true;
                                bt_OK.Enabled = true;
                                break;
                            default:
                                error = new ApplicationException(result.ToString() + "Get Value From invalid result in case");
                                DialogResult = DialogResult.Cancel;
                                break;
                        }
                    }
                }
                else
                {
                    result = BVcopyFromStoreResult.Success;
                    ProgressBar.Properties.Stopped = true;
                    bt_OK.Enabled = true;
                    lb_mess.ForeColor = Color.Green;
                    lb_mess.Text = Localizer.GetLocalized("CopyingCompletedSuccessfully");
                }
            }
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                Text =
                lb_mess.Text = Localizer.GetLocalized("CopyBValue") + "...";
                lb_mess.ForeColor = Color.Black;
                
                switch (mode)
                {
                    case actualBusinessVol:
                       // ();
                        
                        ClientEnvironment.StoreService.BVCopyFromStoreAsync(BusinessVolumeType.Actual, beginDate, endDate,
                                                                                fromStoreID, toStoreID);
                        break;
                    case cashDeskVol:
                        ClientEnvironment.StoreService.BVCopyFromStoreAsync(BusinessVolumeType.CashRegisterReceipt, beginDate, endDate,
                                                                               fromStoreID, toStoreID);
                        break;
                    case targetVol:
                        ClientEnvironment.StoreService.BVCopyFromStoreAsync(BusinessVolumeType.Target, beginDate, endDate,
                                                                               fromStoreID, toStoreID);
                        break;
                    default:
                        DialogResult = DialogResult.Cancel;
                        break;
                }
            }
        }
    }
}
