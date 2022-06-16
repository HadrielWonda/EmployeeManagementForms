using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.Client
{
    public partial class FormWait : XtraForm
    {
        private static Thread _WaitWorker;
        private static readonly ManualResetEvent _FinishEvent = new ManualResetEvent(false);
        
        private FormWait()
        {
            InitializeComponent();
            lbl_WaitPlease.Text = Localizer.GetLocalized("WaitPlease");
        }
        
        public static void ShowWaitForm()
        {
            if (_WaitWorker == null)
            {
                _FinishEvent.Reset();
                _WaitWorker = new Thread(
                    delegate()
                        {
                            using (FormWait _WaitFrm = new FormWait())
                            {
                                _WaitFrm.Show();
                                while (!_FinishEvent.WaitOne(25, false))
                                    Application.DoEvents();
                            }
                        });
                _WaitWorker.SetApartmentState(ApartmentState.STA);
                _WaitWorker.IsBackground = true;
                _WaitWorker.Start();
            }
        }

        public static void HideWaitForm()
        {
            if (_WaitWorker != null)
            {
                _FinishEvent.Set();
                _WaitWorker.Join();
                _WaitWorker = null;
            }
        }
    }
}