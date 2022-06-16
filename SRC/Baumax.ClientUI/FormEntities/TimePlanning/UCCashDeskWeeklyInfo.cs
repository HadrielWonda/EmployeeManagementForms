using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCCashDeskWeeklyInfo : UCBaseEntity 
    {
        public UCCashDeskWeeklyInfo()
        {
            InitializeComponent();
        }

        private string __MinimumPresence = "Minimum presence:";
        private string __MaximumPresence = "Maximum presence:";
        private string __AvailableWorldBufferHours = "Available world-buffer hours:";
        
        private CashDeskPlanningInfo _cashdeskinfo = null;

        public CashDeskPlanningInfo CashDeskInfo
        {
            get { return _cashdeskinfo; }
            set 
            { 
                _cashdeskinfo = value;
                UpdateStoreWorldInfo();
            }
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                __MinimumPresence = GetLocalized("MinimumPresence");
                __MaximumPresence = GetLocalized("MaximumPresence");

                __AvailableWorldBufferHours = GetLocalized("AvailableWorldBufferHours");

                UpdateStoreWorldInfo();
            }
        }

        public void UpdateStoreWorldInfo()
        {
            short min = 0;
            short max = 0;
            int available = 0;

            if (CashDeskInfo != null)
            {
                min = CashDeskInfo.MinimumPresence;
                max = CashDeskInfo.MaximumPresence;
                available = CashDeskInfo.CurrentBufferHours;
                lblAvailableWorldBufferHours.Visible = CashDeskInfo.ExistBufferHours;
            }
            if (Visible)
            {
                lblMinimumPresence.Text = String.Format("{0} {1}", __MinimumPresence, min);
                lblMaximumPresence.Text = String.Format("{0} {1}", __MaximumPresence, max);

                lblAvailableWorldBufferHours.Text = String.Format("{0}  {1}", __AvailableWorldBufferHours, TextParser.TimeToString(available));
            }
        }

    }
}
