using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.General
{
    public partial class EstimationWaitForm : XtraForm
    {
        private long _Completed;

        private delegate void ChangeStateDelegate();

        public EstimationWaitForm()
        {
            InitializeComponent();
            btn_OK.Enabled = false;
            //TODO: subcribe only for appropriate event
            if (ClientEnvironment.IsRuntimeMode)
            {
                ClientEnvironment.StoreService.EstimateWorkingHoursComplete += EstimateComplete;
                ClientEnvironment.StoreService.EstimateCashDeskPeopleComplete += EstimateComplete;
            }
        }

        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                Text = Localizer.GetLocalized("EstimateEstimating");
                lbl_EstimationInProgress.Text = Localizer.GetLocalized("EstimateEstimationInProgress");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = Interlocked.Read(ref _Completed) <= 0;
            if (!e.Cancel)
            {
                ClientEnvironment.StoreService.EstimateWorkingHoursComplete -= EstimateComplete;
                ClientEnvironment.StoreService.EstimateCashDeskPeopleComplete -= EstimateComplete;
            }
        }

        
        private void ChangeState()
        {
            if (InvokeRequired)
                Invoke(new ChangeStateDelegate(ChangeState));
            else
            {
                if (Interlocked.Read(ref _Completed) > 0)
                {
                    btn_OK.Enabled = true;
                    lbl_EstimationInProgress.Text = Localizer.GetLocalized("EstimateEstimationDone");
                    progressBar.Properties.Stopped = true;
                }
            }
        }

        private void EstimateComplete(object sender, Baumax.Contract.OperationCompleteEventArgs e)
        {
            Interlocked.Increment(ref _Completed);
            ChangeState();
        }
    }
}