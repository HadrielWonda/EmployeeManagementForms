using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCTimeRange : XtraUserControl
    {
        public void SetErrorBeginTime (bool error)
        {
            if (error)
                dxErrorProvider.SetError(edBeginTime, Localizer.GetLocalized("ErrorDateRange"));
            else
                dxErrorProvider.SetErrorType(edBeginTime, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
        }

        public DateTime BeginTime
        {
            get { return edBeginTime.DateTime; }
            set 
            { 
                edBeginTime.DateTime = value;
                edBeginTime.Enabled = value < DateTime.Today;
            }
        }
        public DateTime EndTime
        {
            get { return edEndTime.DateTime; }
            set 
            { 
                edEndTime.DateTime = value;
                edEndTime.Enabled = value >= DateTime.Today;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                edBeginTime.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;
                edBeginTime.Properties.MinValue = Contract.DateTimeSql.SmallDatetimeMin;

                edEndTime.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;
                edEndTime.Properties.MinValue = Contract.DateTimeSql.SmallDatetimeMin;
            }
        }
        public UCTimeRange()
        {
            InitializeComponent();
            
        }

        private void edBeginTime_EditValueChanged(object sender, EventArgs e)
        {
            DateTime begin = (DateTime)edBeginTime.EditValue;
            Utility.GetMonday(ref begin);
            edBeginTime.EditValue = begin;
        }

        private void edEndTime_EditValueChanged(object sender, EventArgs e)
        {
            DateTime end = (DateTime)edEndTime.EditValue;
            Utility.GetSunday(ref end);
            edEndTime.EditValue = end;
        }
    }
}
