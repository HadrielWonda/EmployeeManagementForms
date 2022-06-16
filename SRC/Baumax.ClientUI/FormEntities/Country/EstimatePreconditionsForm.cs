using System;
using System.Collections;
using System.Windows.Forms;
using Baumax.ClientUI.General;
using Baumax.Contract;
using Baumax.Contract.QueryResult;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class EstimatePreconditionsForm : XtraForm
    {
        protected const int _RedIconIndex = 1;
        protected const int _GreenIconIndex = 0;

        private bool _IsCashDesk;
        protected bool _IsNeedChangeBufferHours = false;

        public EstimatePreconditionsForm()
        {
            InitializeComponent();
            spin_Year.Value = DateTime.Now.Year;
        }

        public void ValidatePreconditions()
        {
            if (IsCashDesk)
                ValidateCashDesk();
            else
                ValidateWorkingHours();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                Text = Localizer.GetLocalized("EstimatePreconditions");
                btn_EstimateButton.Text = Localizer.GetLocalized("EstimateButton");
                btn_Cancel.Text = Localizer.GetLocalized("cancel");
                lbl_EstimateMuchTime.Text = Localizer.GetLocalized("EstimateMuchTime");
                grp_EstimatePreconditions.Text = Localizer.GetLocalized("EstimatePreconditions");
                lbl_Year.Text = Localizer.GetLocalized("Year");
                btn_Validate.Text = Localizer.GetLocalized("CheckPreconditions");

                ValidatePreconditions();
            }
        }

        protected virtual void ValidateCashDesk()
        {
            //bool canEstimate = true;
            IList info = ClientEnvironment.StoreService.CanEstimateCashDeskPeopleInfo(EstimationYear);
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

        protected virtual void ValidateWorkingHours()
        {
            //bool canEstimate = true;
            IList info = ClientEnvironment.StoreService.CanEstimateWorkingHoursInfo(EstimationYear);
            imageListBox.SuspendLayout();
            imageListBox.Items.Clear();
            foreach (CanEstimateWorkingHoursResult result in info)
            {
                        if (!result.Result)
                        {
                            //canEstimate = false;
                            switch(result.Condition)
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
            btn_CopyBH.Visible = _IsNeedChangeBufferHours;
#endif
            //btn_EstimateButton.Enabled = canEstimate;
        }

       
        
        protected virtual void MakeEstimation()
        {
            using (EstimationWaitForm waitFrm = new EstimationWaitForm())
            {
                if (IsCashDesk)
                    ClientEnvironment.StoreService.EstimateCashDeskPeople(EstimationYear);
                else
                    ClientEnvironment.StoreService.EstimateWorkingHours(EstimationYear);
                waitFrm.ShowDialog();
            }
        }

        protected static string GetLocalized(EstimateWorkingHoursCondition condition)
        {
            switch(condition)
            {
                case EstimateWorkingHoursCondition.ActualBVExists:
                    return Localizer.GetLocalized("EstimateActualBVExists");

                case EstimateWorkingHoursCondition.AddHoursCalcExists:
                    return Localizer.GetLocalized("EstimateAddHoursCalcExista");

                case EstimateWorkingHoursCondition.BufferHoursExists:
                    return Localizer.GetLocalized("EstimateBufferHoursExists");

                case EstimateWorkingHoursCondition.CountryPropExists:
                    return Localizer.GetLocalized("EstimateCountryPropExists");

                case EstimateWorkingHoursCondition.EmployeeAssigned:
                    return Localizer.GetLocalized("EstimateEmployeeAssigned");

                case EstimateWorkingHoursCondition.EveryWGRAssignedToWorldActualBV:
                    return Localizer.GetLocalized("EstimateEveryWGRAssignedToWorld");

                case EstimateWorkingHoursCondition.TargetBVExists:
                    return Localizer.GetLocalized("EstimateTargetBVExists");

                case EstimateWorkingHoursCondition.ClosedDaysExists:
                    return Localizer.GetLocalized("EstimateYearlyWorkTimeExists");

                case EstimateWorkingHoursCondition.MinPeopleExists:
                    return Localizer.GetLocalized("EstimateMinPeopleExists");

                case EstimateWorkingHoursCondition.OpeningTimesExists:
                    return Localizer.GetLocalized("EstimateOpeningTimesExists");

                case EstimateWorkingHoursCondition.AvgWorkingDaysExists:
                    return Localizer.GetLocalized("EstimateAvgWorkingDaysExists");

                case EstimateWorkingHoursCondition.EveryWGRAssignedToWorldTargetBV:
                    return Localizer.GetLocalized("EstimateEveryWGRAssignedToWorldTargetBV");

                default:
                    throw new ApplicationException("Add localizations");
            }
        }

        protected static string GetLocalized(EstimateCashDeskPeopleCondition condition)
        {
            switch(condition)
            {
                case EstimateCashDeskPeopleCondition.ActualBVExists:
                    return Localizer.GetLocalized("EstimateCashDeskActualBVExists");

                case EstimateCashDeskPeopleCondition.CountryPropExists:
                    return Localizer.GetLocalized("EstimateCountryPropExists");

                case EstimateCashDeskPeopleCondition.EmployeeAssigned:
                    return Localizer.GetLocalized("EstimateEmployeeAssigned");

                case EstimateCashDeskPeopleCondition.OpeningTimesExists:
                    return Localizer.GetLocalized("EstimateOpeningTimesExists");

                case EstimateCashDeskPeopleCondition.YearlyWorkTimeExists:
                    return Localizer.GetLocalized("EstimateYearlyWorkTimeExists");
                 
                case EstimateCashDeskPeopleCondition.MinMaxPeopleExists:
                    return Localizer.GetLocalized("EstimateMinPeopleExists");

                default:
                    throw new ApplicationException("Add localizations");
            }
        }

        public bool IsCashDesk
        {
            get { return _IsCashDesk; }
            set
            {
                _IsCashDesk = value;
            }
        }

        protected int EstimationYear
        {
            get { return (int) spin_Year.Value; }
            set { spin_Year.Value = value; }
        }

        private void btn_EstimateButton_Click(object sender, EventArgs e)
        {
            MakeEstimation();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            ValidatePreconditions();
        }

        private void spin_Year_EditValueChanged(object sender, EventArgs e)
        {
            ValidatePreconditions();
        }

        protected virtual void btn_CopyBH_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("OK");
        }
    }
}