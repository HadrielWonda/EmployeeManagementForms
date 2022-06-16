using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class ECAvgWorkingDaysInWeek : UCBaseEntity
    {
        
        
        public ECAvgWorkingDaysInWeek()
        {
            InitializeComponent();
        }

       
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (ClientEnvironment.IsRuntimeMode && Amount.IsNew)
           {
               spinEdit_Years.EditValue = DateTime.Now.Year;
               spinEdit_AvgWDIWeek.EditValue = 1;
           }
            else spinEdit_Years.Enabled = false;
            
        }
       
        private Domain.Country _country;

        public Domain.Country Country
        {
            get { return _country; }
            set
            {
                _country = value;
                Bind();
            }
        }

        public short Year
        {
            get { return Convert.ToInt16(spinEdit_Years.EditValue); }
            set { spinEdit_Years.EditValue = value; }
        }

        public AvgWorkingDaysInWeek Amount
        {
            get { return (AvgWorkingDaysInWeek)Entity; }
            set
            {
                Entity = value;
            }
        }

        protected override void EntityChanged()
        {
            if (Amount != null)
            {
                Bind();
            }
        }

        public decimal Days
        {
            get { return Convert.ToDecimal(spinEdit_AvgWDIWeek.EditValue); }
            set { spinEdit_AvgWDIWeek.EditValue = value; }
        }

        public override void Bind()
        {
            if (Amount == null) return;
            base.Bind();
            if (!Amount.IsNew)
            {
                Year = Amount.Year;
                Days = Math.Round(Amount.DaysCount, 1); 
            }
        }

        bool IsModified()
        {
            if (Amount == null) return false;

            return (Year != Amount.Year) ||
                (Days != Amount.DaysCount);
        }

        public override bool Commit()
        {
            if (Amount == null) return false;
            
            if (IsModified())
            {
                AvgWorkingDaysInWeek am = ClientEnvironment.CountryService.AvgWorkingDaysInWeekService.CreateEntity();
                AvgWorkingDaysInWeek.CopyTo(Amount, am);

                am.Year = Year;
                am.DaysCount = Days;

                try
                {
                    if (Amount.IsNew)
                    {
                         List<AvgWorkingDaysInWeek> _check = ClientEnvironment.CountryService.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeekFiltered(am.CountryID, Year, Year);
                         if (_check == null || _check.Count == 0)
                             am = ClientEnvironment.CountryService.AvgWorkingDaysInWeekService.Save(am);
                         else
                         {
                             ErrorMessage(GetLocalized("CannotAddAverageDaysInWeek"));
                             return false;
                         }
                    }
                    else
                    {
                        if (Year < DateTime.Now.Year && am.Year == Amount.Year)
                        return false; 
                        
                        List<AvgWorkingDaysInWeek> _check = ClientEnvironment.CountryService.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeekFiltered(am.CountryID, Year, Year);
                        if (_check != null && _check.Count != 0 && am.Year != Amount.Year)
                        {
                            ErrorMessage(GetLocalized("CannotAddAverageDaysInWeek"));
                            return false;
                        }
                          
                        ClientEnvironment.CountryService.AvgWorkingDaysInWeekService.SaveOrUpdate(am); 
                    }

                    AvgWorkingDaysInWeek.CopyTo(am, Amount);
                    Modified = true;

                    return base.Commit();
                }
                catch (ValidationException)
                {
                    ErrorMessage(GetLocalized("CannotAddAverageDaysInWeek"));
                }
                catch (EntityException)
                {
                    ErrorMessage(GetLocalized("CannotAddAverageDaysInWeek"));
                }
            }
            return false;
        }
    }
}
