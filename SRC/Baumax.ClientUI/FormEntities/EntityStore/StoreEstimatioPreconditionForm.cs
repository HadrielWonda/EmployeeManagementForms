using System;
using System.Collections;
using Baumax.ClientUI.FormEntities.Country;
using Baumax.ClientUI.General;
using Baumax.Contract;
using Baumax.Contract.QueryResult;
using Baumax.Environment;
using DevExpress.XtraEditors.Controls;
using Localizer=Baumax.Localization.Localizer;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    public partial class StoreEstimatioPreconditionForm : EstimatePreconditionsForm
    {
        private long _StoreId;
        private string _StoreName;

        public StoreEstimatioPreconditionForm()
        {
            InitializeComponent();
        }

        protected override void ValidateCashDesk()
        {
            //bool canEstimate = true;
            IList info = ClientEnvironment.StoreService.CanEstimateCashDeskPeopleInfo(StoreID, EstimationYear);
            imageListBox.SuspendLayout();
            imageListBox.Items.Clear();
            foreach (CanEstimateCashDeskPeopleResult result in info)
            {
                if (!result.Result)
                {
                    //canEstimate = false;
                    imageListBox.Items.Add(GetLocalized(result.Condition), _RedIconIndex);
                }
                else
                    imageListBox.Items.Add(GetLocalized(result.Condition), _GreenIconIndex);
            }
            imageListBox.ResumeLayout();
            //btn_EstimateButton.Enabled = canEstimate;
        }

        public string StoreName
        {
            get { return _StoreName; }
            set { _StoreName = value; }
        }

        public void Init(long storeid, string storename, bool IsCashDeskTrue)
        {
            StoreID = storeid;
            StoreName = storename;
            IsCashDesk = IsCashDeskTrue;
            lbCountry.Visible = true;
            btn_CopyBH.Enabled = false;
            btn_CopyBH.BorderStyle = BorderStyles.NoBorder;
            if (StoreName != null)
                lbCountry.Text = StoreName;
            ShowDialog();
        }

        protected override void ValidateWorkingHours()
        {
            //bool canEstimate = true;
            IList info = ClientEnvironment.StoreService.CanEstimateWorkingHoursInfo(_StoreId, EstimationYear);
            imageListBox.SuspendLayout();
            imageListBox.Items.Clear();
            foreach (CanEstimateWorkingHoursResult result in info)
            {
                if (!result.Result)
                {
                    //canEstimate = false;
                    switch (result.Condition)
                    {
                        case EstimateWorkingHoursCondition.BufferHoursExists:
                            {
                                string message = GetLocalized(result.Condition) + " (" + Localizer.GetLocalized("NoValueProvidedForWorld") + " 0 )";
                                imageListBox.Items.Add(message, _RedIconIndex);
                                _IsNeedChangeBufferHours = true;
                                break;
                            }
                        case EstimateWorkingHoursCondition.AddHoursCalcExists:
                            {
                                string message = GetLocalized(result.Condition) + " (" + Localizer.GetLocalized("NoValueProvidedForWorld") + " 1 )";
                                imageListBox.Items.Add(message, _RedIconIndex);
                                break;
                            }

                        default:
                            imageListBox.Items.Add(GetLocalized(result.Condition), _RedIconIndex);
                            break;
                    }
                }
                else
                    imageListBox.Items.Add(GetLocalized(result.Condition), _GreenIconIndex);


                if (result.Condition == EstimateWorkingHoursCondition.BufferHoursExists && result.Result)
                    _IsNeedChangeBufferHours = false;
            }
            imageListBox.ResumeLayout();
#if DEBUG
            //btn_CopyBH.Visible = _IsNeedChangeBufferHours;
#endif            
            //btn_EstimateButton.Enabled = canEstimate;
        }
        
        protected override void MakeEstimation()
        {
            using (EstimationWaitForm waitFrm = new EstimationWaitForm())
            {
                if (IsCashDesk)
                    ClientEnvironment.StoreService.EstimateCashDeskPeople(_StoreId, EstimationYear);
                else
                    ClientEnvironment.StoreService.EstimateWorkingHours(_StoreId, EstimationYear);
                waitFrm.ShowDialog();
            }
        }

        public long StoreID
        {
            get { return _StoreId; }
            set
            {
                _StoreId = value;
            }
        }

        protected override void btn_CopyBH_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("OK #2");
        }
    }
}