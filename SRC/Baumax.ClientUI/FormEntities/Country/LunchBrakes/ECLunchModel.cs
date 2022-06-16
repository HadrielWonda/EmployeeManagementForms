using System;
using System.Collections.Generic;
using System.Diagnostics;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country.LunchBrakes
{
    public partial class ECLunchModel : UCBaseEntity
    {
        public ECLunchModel()
        {
            InitializeComponent();
        }

        private bool isTypeReadOnly = false;
        private bool isUserConfirm = false;
        
#region Constant field
        
        const double defaultHoursLunch = -0.5;
        const double minHoursLunch = -5;
        const double maxHoursLunch = 5;
        const double defaultCondition = 4.5;
        const double minCondition = 0;
        const double maxCondition = 24;
#endregion
        
#region *****************Fields of Lunch model************************

        public WorkingModel LunchModelEntity
        {
            get
            {
                return (WorkingModel)Entity;
            }
            set
            {
                Entity = value;

            }
        }

        internal string lunchModelName
        {
            get
            {
                return textEditName.Text.Trim();
            }
            set
            {
                textEditName.Text = value;
            }
        }
        
        internal double Hours
        {
            get
            {
                return Convert.ToDouble(sEhour.EditValue);
            }
            set
            {
                sEhour.EditValue = value;
            }
        }

        internal bool IsDurationTime
        {
            get
            {
                return rb_DurationTime.Checked;
            }
            set
            {
               rb_DurationTime.Checked = value;
               rb_DurationWorkingDay.Checked = !value;
            }
        }

        internal double conditionTime
        {
            get
            {
                return Convert.ToDouble(sEcondition.EditValue);
            }
            set
            {
                sEcondition.EditValue = value;
            }
        }
        
        internal DateTime BeginDate
        {
            get
            {
                return deBeginTime.DateTime;
            }
            set
            {
                deBeginTime.DateTime = value;
            }
        }

        internal DateTime EndDate
        {
            get
            {
                return deEndTime.DateTime;
            }
            set
            {
                deEndTime.DateTime = value;
            }
        }

        public void isTypeLunchReadOnly(bool isDurationTime)
        {
            isTypeReadOnly = true; 
            if (isDurationTime)
                IsDurationTime = true;
            else
                IsDurationTime = false;
        }
#endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            deBeginTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
                deBeginTime.Properties.MinValue =
                    deEndTime.Properties.MinValue = DateTime.Today;
            deEndTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
            
            sEhour.Properties.MinValue = (decimal)minHoursLunch;
            sEhour.Properties.MaxValue = (decimal) maxHoursLunch;
            sEcondition.Properties.MinValue = (decimal) minCondition;
            sEcondition.Properties.MaxValue = (decimal)maxCondition;
            sEcondition.Visible =
                    lb_condition.Visible = true;
            if (isTypeReadOnly)
            {
               if (IsDurationTime) 
                   rb_DurationWorkingDay.Enabled = false;
               else
                   rb_DurationTime.Enabled = false;
            }
            else
            {
               IsDurationTime = true; 
            }
            Bind();
        }
        
        public override void Bind()
        {
            base.Bind();
            if (LunchModelEntity.IsNew)
            {
                if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                    BeginDate = DateTime.Today;
                else 
                    BeginDate = DateTimeHelper.GetNextMonday(DateTime.Today);
                EndDate = DateTimeSql.SmallDatetimeMax;
                Hours = defaultHoursLunch;
                conditionTime = defaultCondition;
            }
            else
            {
                lunchModelName = LunchModelEntity.Name;
                conditionTime = LunchModelEntity.ConditionTime;
                Hours = LunchModelEntity.HoursLunch;
                BeginDate = LunchModelEntity.BeginTime;
                EndDate = LunchModelEntity.EndTime;
                IsDurationTime = LunchModelEntity.IsDurationTime;
                
                if (BeginDate <= DateTime.Today) // set readonly state for past (BeginDate) Entity
                {
                    deBeginTime.Properties.ReadOnly = true;
                    sEhour.Enabled =
                        sEcondition.Enabled = false;
                }
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                rb_DurationTime.Text  = GetLocalized("DurationTime");
                rb_DurationWorkingDay.Text = GetLocalized("DurationWorkingDay");
            }
        }

        public override bool IsValid()
        {
            if (lunchModelName.Length == 0)
            {
                ErrorMessage(GetLocalized("err_enter_lunch_name"));
                textEditName.Focus();
                return false;
            }

            ValidateDateRange();

            if (BeginDate > EndDate)
            {
                ErrorMessage(GetLocalized("ErrorDateRange")); 
                deEndTime.Focus();
                return false;
            }

            if (LunchModelEntity.IsNew && isLunchModelExist(BeginDate, EndDate) && !isUserConfirm)
            {
                InfoMessage(GetLocalized("Lunchmodelwithsameparametrsexist"));
                isUserConfirm = true;
                return false;
            }
                
            return base.IsValid();
        }

        private void ValidateDateRange()
        {
            if (BeginDate < DateTimeSql.SmallDatetimeMin)
                BeginDate = DateTimeSql.SmallDatetimeMin;

            if (EndDate > DateTimeSql.SmallDatetimeMax)
                EndDate = DateTimeSql.SmallDatetimeMax;

        }

        public override bool Commit()
        {
            Debug.Assert(LunchModelEntity != null);

            if (IsValid())
            {
                if (IsModified())
                {
                   LunchModelEntity.Name = lunchModelName;
                   LunchModelEntity.ConditionTime = conditionTime;
                   LunchModelEntity.HoursLunch = Hours;
                   LunchModelEntity.IsDurationTime = IsDurationTime;
                   LunchModelEntity.BeginTime = BeginDate;
                   LunchModelEntity.EndTime = EndDate;
                   LunchModelEntity.LanguageID = SharedConsts.NeutralLangId;
                    try
                    {
                        if (LunchModelEntity.IsNew)
                        {
                            WorkingModel wm = ClientEnvironment.WorkingModelService.Save(LunchModelEntity);
                            LunchModelEntity.ID = wm.ID;
                        }
                        else
                            ClientEnvironment.WorkingModelService.SaveOrUpdate(LunchModelEntity);

                        Modified = true;
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("CantSaveLunchModel")); 
                        return false;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return false;
                    }
                }

                return base.Commit();
            }
            else return false;
        }

        public bool IsModified()
        {
            Debug.Assert(LunchModelEntity != null);

            if (LunchModelEntity.IsNew) return true;

            return ((LunchModelEntity.HoursLunch != Hours) ||
                (LunchModelEntity.ConditionTime != conditionTime) ||
                (LunchModelEntity.Name != lunchModelName) ||
                (LunchModelEntity.BeginTime != BeginDate) ||
                (LunchModelEntity.IsDurationTime != IsDurationTime) ||
                (LunchModelEntity.EndTime != EndDate));
        }

        private void BeginDate_EditValueChanged(object sender, EventArgs e)
        {
            if (BeginDate.DayOfWeek != DayOfWeek.Monday)
                fixBeginDate();
        }

        private void EndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (EndDate.DayOfWeek != DayOfWeek.Sunday)
                fixEndDate();
            if (EndDate < BeginDate)
                EndDate = DateTimeHelper.GetNextSunday(EndDate);
        }
        
        private void fixBeginDate()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && DateTimeHelper.IsDayInCurrentWeek(BeginDate))
                BeginDate = DateTime.Today;
            else
                if (DateTimeHelper.IsDayInCurrentWeek(BeginDate))
                    BeginDate = DateTimeHelper.GetNextMonday(BeginDate);
                else
                    BeginDate = DateTimeHelper.GetMonday(BeginDate);
        }

        private void fixEndDate()
        {
                EndDate = DateTimeHelper.GetSunday(EndDate);
        }
        
        private bool isLunchModelExist(DateTime aBegin, DateTime aEnd)
        {
            List<WorkingModel> listLunchModelExist = ClientEnvironment.WorkingModelService.GetCountryLunchModel((long)LunchModelEntity.CountryID, aBegin, aEnd); 
            if (listLunchModelExist == null || listLunchModelExist.Count == 0)
                return false;
            else
            {
                foreach (WorkingModel model in listLunchModelExist)
                {
                    if (Hours == model.HoursLunch && conditionTime == model.ConditionTime)
                        return true;
                }
                return false;
            }
        }
    }
}
