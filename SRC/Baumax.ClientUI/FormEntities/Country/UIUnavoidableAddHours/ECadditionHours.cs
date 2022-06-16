using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class ECadditionHours : UCBaseEntity
    {

       public ECadditionHours()
        {
            InitializeComponent();
        }
        
        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
            if (Amount != null && !Amount.IsNew)
            {
                spinEdit_Year.Enabled = false;
                checkedListBoxControl_week.Enabled = false;
                Year = Amount.Year;
                checkedListBoxControl_week.Items[Amount.WeekDay - 1].CheckState = CheckState.Checked;
                BeginTime = Amount.BeginTime;
                EndTime = Amount.EndTime;
                if (Amount.BeginTime != 0 && Amount.EndTime == 0)
                    spinEdit_FactorE.Enabled = false;
                    else
                        if (Amount.BeginTime == 0 && Amount.EndTime != 0)
                            spinEdit_FactorB.Enabled = false;
            }
        }
     
        public CountryAdditionalHour Amount
        {
            get { return (CountryAdditionalHour)Entity; }
            set { Entity = value; }
        }

        public List<CountryAdditionalHour> AmountList;
        
        
        #region Fields of Entity
        string [] daysOfWeek = null;
        private Domain.Country _country;
        
        public short Year
        {
            get { return Convert.ToInt16(spinEdit_Year.EditValue); }
            set { spinEdit_Year.EditValue = value; }
        }
        
        public short BeginTime
        {
            get { return GetTimeShortByDateTime(timeEdit_BeginTime.EditValue); }
            set
            {   int hour, min;
                hour = value/60;
                min = value - hour*60;
                timeEdit_BeginTime.EditValue = new DateTime(DateTime.Today.Year, 1, 1, hour, min, 0);
            }
        }

        public short EndTime
        {
            get { return GetTimeShortByDateTime(timeEdit_EndTime.EditValue); }
            set
            {
                int hour, min;
                hour = value / 60;
                min = value - hour*60;
                timeEdit_EndTime.EditValue = new DateTime(DateTime.Today.Year, 1, 1, hour, min, 0);
            }
        }

        public decimal FactorBegin
        {
            get { return Convert.ToDecimal(spinEdit_FactorB.EditValue); }
            set { spinEdit_FactorB.EditValue = value; }
        }

        public decimal FactorEnd
        {
            get { return Convert.ToDecimal(spinEdit_FactorE.EditValue); }
            set { spinEdit_FactorE.EditValue = value; }
        }
        
        #endregion
        public override void Bind()
        {
           if (daysOfWeek == null)
            {
               daysOfWeek = new string[8];
               daysOfWeek[(int)BaumaxDayOfWeek.Monday] = GetLocalized(BaumaxDayOfWeek.Monday.ToString());
               daysOfWeek[(int)BaumaxDayOfWeek.Tuesday] = GetLocalized(BaumaxDayOfWeek.Tuesday.ToString());
               daysOfWeek[(int)BaumaxDayOfWeek.Wednesday] = GetLocalized(BaumaxDayOfWeek.Wednesday.ToString());
               daysOfWeek[(int)BaumaxDayOfWeek.Thursday] = GetLocalized(BaumaxDayOfWeek.Thursday.ToString());
               daysOfWeek[(int)BaumaxDayOfWeek.Friday] = GetLocalized(BaumaxDayOfWeek.Friday.ToString());
               daysOfWeek[(int)BaumaxDayOfWeek.Saturday] = GetLocalized(BaumaxDayOfWeek.Saturday.ToString());
               daysOfWeek[(int)BaumaxDayOfWeek.Sunday] = GetLocalized(BaumaxDayOfWeek.Sunday.ToString());
               for (int i = 0; i < checkedListBoxControl_week.ItemCount; i++)
                    checkedListBoxControl_week.Items[i].Value = daysOfWeek[i + 1].ToString();
            }
            base.Bind();
        }

        protected override void EntityChanged()
        {
            Bind();
        }
     
        public Domain.Country Country
        {
            get { return _country; }
            set
            {
                _country = value;
                Bind();
            }
        }

        private bool isCheckedListBoxSelected() 
        {
            for (int i = 0; i < checkedListBoxControl_week.ItemCount; i++)
            {
                if (checkedListBoxControl_week.Items[i].CheckState == CheckState.Checked)
                    return true;
            }
                return false;
        }
       
        public override bool IsValid()
        {
            if (!isCheckedListBoxSelected())
                 {
                     InfoMessage(GetLocalized("SelectDay"));
                     return false;
                 }

            if (BeginTime == 0 && EndTime == 0)
               {
                   timeEdit_BeginTime.ErrorText = timeEdit_EndTime.ErrorText = GetLocalized("WarningEndTime"); 
                   timeEdit_BeginTime.Focus();
                   return false;
               }
               else
                timeEdit_BeginTime.ErrorText =
                timeEdit_EndTime.ErrorText = String.Empty;
                
            
                
            if (BeginTime != 0 && EndTime != 0 && BeginTime > EndTime)
               {
                   timeEdit_BeginTime.ErrorText = timeEdit_EndTime.ErrorText = GetLocalized("WarningTime"); 
                   timeEdit_BeginTime.Focus();
                   return false;
               }
               else
                   timeEdit_BeginTime.ErrorText =
                   timeEdit_EndTime.ErrorText = String.Empty;
               
               return base.IsValid();
        }
      
        private bool IsModified()
        {
            if (Amount == null) 
                return false;

            return (Year != Amount.Year) ||
                (BeginTime != Amount.BeginTime) ||
                (EndTime != Amount.EndTime) ||
                (FactorBegin != Amount.FactorEarly) ||   
                (FactorEnd != Amount.FactorLate);
        }
        
        private bool isCountryAdditionalHourExist(List<CountryAdditionalHour> listOfExistEntity)
        
        {

            if (listOfExistEntity == null || listOfExistEntity.Count == 0)
                return false;
           
            foreach (CountryAdditionalHour hour in listOfExistEntity)
            {
               for (int i = 0; i < checkedListBoxControl_week.ItemCount; i++)
                {
                     if (checkedListBoxControl_week.Items[i].CheckState == CheckState.Checked && hour.WeekDay == i+1) 
                         return true;
                } 
            }
            return false;
        }
      
        public override bool Commit()
        {
            if (Amount == null || !IsValid()) 
                return false;
                try
                {
                    if (Amount.IsNew)
                    {
                        if (isCountryAdditionalHourExist(ClientEnvironment.CountryService.CountryAdditionalHourService.GetCountryAdditionalHourFiltered(Amount.CountryID, Year)))
                         {
                             ErrorMessage(GetLocalized("CountryAdditionalHourExist")); 
                             return false;
                          }   
                        AmountList = new List<CountryAdditionalHour>();
                        for (int i = 0; i < checkedListBoxControl_week.ItemCount; i++)
                        {
                            if (checkedListBoxControl_week.Items[i].CheckState == CheckState.Checked)
                            {
                                CountryAdditionalHour am = ClientEnvironment.CountryService.CountryAdditionalHourService.CreateEntity();
                                CountryAdditionalHour.CopyTo(Amount, am);
                                am.Year = Year;
                                am.BeginTime = BeginTime;
                                am.EndTime = EndTime;
                                am.FactorEarly = FactorBegin;
                                am.FactorLate = FactorEnd;
                                am.WeekDay = (byte)(i + 1);
                                AmountList.Add(am);
                            }
                        }
                        ClientEnvironment.CountryAdditionalHourService.SaveList(AmountList);
                        ClientEnvironment.StoreService.CalculateCountryAdditionalHours(Year, Amount.CountryID);
                    }
                    else if (IsModified())
                    {
                        CountryAdditionalHour am = ClientEnvironment.CountryService.CountryAdditionalHourService.CreateEntity();
                        CountryAdditionalHour.CopyTo(Amount, am);
                        am.BeginTime = BeginTime;
                        am.EndTime = EndTime;
                        am.FactorEarly = FactorBegin;
                        am.FactorLate = FactorEnd;
                        ClientEnvironment.CountryService.CountryAdditionalHourService.SaveOrUpdate(am);
                        ClientEnvironment.StoreService.CalculateCountryAdditionalHours(Year, Amount.CountryID);
                        CountryAdditionalHour.CopyTo(am, Amount);
                    }
                    else 
                        return false;
                    
                    Modified = true;
                    return base.Commit();
                }
                catch (ValidationException)
                {
                    ErrorMessage(GetLocalized("CountryAdditionalHourExist")); 
                }
                catch (EntityException)
                {
                    ErrorMessage(GetLocalized("ErrorAddCountryAdditionalHourExist")); 
                }
            return false;
        }

        private short GetTimeShortByDateTime(object dateTime)
        {
            DateTime time = (DateTime)dateTime;
            return (short) (time.Hour*60 + time.Minute);
        }

        private void timeEdit_BeginTime_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit_FactorB.Enabled = BeginTime != 0;
        }

        private void timeEdit_EndTime_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit_FactorE.Enabled = EndTime != 0;
        }
    }
}
