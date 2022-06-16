using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities.Country;
using DevExpress.XtraEditors;
using Baumax.Environment;
using System.Collections;
using Baumax.Contract;
using Baumax.Localization;


namespace Baumax.ClientUI.FormEntities.EntityStore
{
    public partial class FormViewEstimateData : DevExpress.XtraEditors.XtraForm
    {
        public FormViewEstimateData()
        {
            InitializeComponent();

            dateEdit1.DateTime = DateTimeHelper.GetMonday(DateTime.Today);
            dateEdit2.DateTime = DateTimeHelper.GetSunday(DateTime.Today);

            lbl_BeginDate.Text = Localizer.GetLocalized("BeginDate");
            lbl_EndDate.Text = Localizer.GetLocalized("EndDate");
            btn_Apply.Text = Localizer.GetLocalized("Apply");
            btn_ClearEstimate.Text = Localizer.GetLocalized("ClearAllEstimate");
        }

        private long _StoreId;
        private string _StoreName;

        public long StoreId
        {
            get { return _StoreId; }
            set { _StoreId = value; }
        }

        public string StoreName
        {
            get { return _StoreName; }
            set { _StoreName = value; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (lookUpEdit1.EditValue != null)
            {
                //long worldid = (long)lookUpEdit1.EditValue;
                
                IList lstWorldDiff = ClientEnvironment.StoreToWorldService.GetEstWorldDiffData((short)dateEdit1.DateTime.Year, StoreId, 0);
                IList lstWorldHours = ClientEnvironment.StoreToWorldService.GetEstWorkingHours(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date, StoreId, 0);
                IList lstYearlyWorld = ClientEnvironment.StoreToWorldService.GetEstWorldYearValues((short)dateEdit1.DateTime.Year, StoreId, 0);

                gridControl1.DataSource = lstWorldDiff;
                gridControl2.DataSource = lstWorldHours;
                gridControl3.DataSource = lstYearlyWorld;

                gridView1.BestFitColumns();
                gridView2.BestFitColumns();
                gridView3.BestFitColumns();
                
            }
        }

        public void Init(long storeid, string storename)
        {
            StoreId = storeid;
            StoreName = storename;
            /*List<Domain.World> lstWorld = ClientEnvironment.WorldService.FindAll();
            lookUpEdit1.Properties.DataSource = lstWorld;
            if (lstWorld != null && lstWorld.Count > 0)
            {
                lookUpEdit1.EditValue = lstWorld[0].ID;
            }
            */
            Text = Localizer.GetLocalized("ViewEstimateData") + ": " + StoreName;
            ShowDialog();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to remove all estimate data for this store and year?", "Attention", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                ClientEnvironment.StoreToWorldService.ClearEstimation(StoreId, (short)dateEdit1.DateTime.Year);
                DialogResult = DialogResult.OK;
            }
        }

    }
}