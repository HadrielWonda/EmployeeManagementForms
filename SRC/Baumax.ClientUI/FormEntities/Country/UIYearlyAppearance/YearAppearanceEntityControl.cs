using System;
using System.Collections.Generic;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class YearAppearanceEntityControl : UCBaseEntity
    {
        public YearAppearanceEntityControl()
        {
            InitializeComponent();
            Year = (short)DateTime.Today.Year;
        }

        public AvgAmount Amount
        {
            get { return (AvgAmount)Entity; }
            set
            {
                Entity = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                if (!Amount.IsNew)
                    spinEditYear.Enabled = false;
                else
                {
                    Year = (short)DateTime.Now.Year;
                    Weeks = 45;
                    AvgHoursPerDay = 8;
                    CashDeskAmount = 40;
                    AvgRestingTime = 60;
                }
            }
            
        }

        protected override void EntityChanged()
        {
            if (Amount != null)
            {
                Bind();
            }
        }
        public short Year
        {
            get { return Convert.ToInt16(spinEditYear.EditValue); }
            set { spinEditYear.EditValue = value; }
        }

        public byte Weeks
        {
            get { return Convert.ToByte(spinEditAvgWeeks.EditValue); }
            set { spinEditAvgWeeks.EditValue = value; }
        }

        public short AvgHoursPerDay
        {
            get { return Convert.ToInt16(spinEditAvgHoursPerDay.EditValue); }
            set { spinEditAvgHoursPerDay.EditValue = value; }
        }

        public short CashDeskAmount
        {
            get { return Convert.ToInt16(spinEditAvgCashDeskAmount.EditValue); }
            set { spinEditAvgCashDeskAmount.EditValue = value; }
        }
        public short AvgRestingTime
        {
            get { return Convert.ToInt16(spinEditAvgRestingTime.EditValue);}
            set { spinEditAvgRestingTime.EditValue = value;}
        }


        public override void Bind()
        {
            if (Amount == null) return;
            base.Bind();
            if (!Amount.IsNew ) Year = Amount.Year;
            Weeks = Amount.AvgWeeks;
            AvgHoursPerDay = Amount.AvgContractTime;
            CashDeskAmount = Amount.CashDeskAmount;
            AvgRestingTime = Amount.AvgRestingTime;
        }

        bool IsModified()
        {
            if (Amount == null) return false;

            return (Year != Amount.Year) ||
                (Weeks != Amount.AvgWeeks) ||
                (AvgHoursPerDay != Amount.AvgContractTime) ||
                (CashDeskAmount != Amount.CashDeskAmount) ||
                (AvgRestingTime != Amount.AvgRestingTime);
        }

     /*  public void CopyEntity(AvgAmount source, AvgAmount dest)
        {
            dest.ID = source.ID;
            dest.CountryID = source.CountryID;
            dest.Year = source.Year;
            dest.AvgWeeks = source.AvgWeeks;
            dest.AvgHoursPerDay = source.AvgHoursPerDay;
            dest.CashDeskAmount = source.CashDeskAmount;
        }
    */   
        bool CheckExistingEntityByYear(short _year, long _countryID)
        {
           
            List<AvgAmount> _list = ClientEnvironment.AvgAmountService.GetCountryAvgAmounts(_countryID);
            if (_list == null || _list.Count == 0) return false;
                else 
                    foreach (AvgAmount _amount in _list)
                    {
                        if (_amount.Year == _year) return true;
                    }
            return false;
        }
        
        
        public override bool Commit()
        {
            if (Amount == null) return false;


            if (IsModified ())
            {
                

                AvgAmount am = ClientEnvironment.CountryService.AvgAmountService.CreateEntity();
                                
                AvgAmount.CopyTo(Amount, am);

                am.Year = Year;
                am.AvgWeeks = Weeks;
                am.AvgContractTime = AvgHoursPerDay;
                am.CashDeskAmount = CashDeskAmount;
                am.AvgRestingTime = AvgRestingTime;
                try
                {
                    if (Amount.IsNew)
                    {
                        if (!CheckExistingEntityByYear(am.Year, am.CountryID)) 
                            am = ClientEnvironment.AvgAmountService.Save(am);
                        else
                        {
                            ErrorMessage(GetLocalized("YearExist"));
                            return false;
                        }
                          
                    }
                    else
                    {
                         if (CheckExistingEntityByYear(am.Year, am.CountryID) && am.Year != Amount.Year)
                         {
                              ErrorMessage(GetLocalized("YearExist"));
                             return false;
                         }
                             
                         else
                             ClientEnvironment.AvgAmountService.SaveOrUpdate(am);
                    }
                        

                    AvgAmount.CopyTo(am, Amount);

                    Modified = true;
                  
                    return base.Commit ();
                }
                
                catch (ValidationException)
                {
                    ErrorMessage(GetLocalized("YearExist"));
                }
                
                catch (EntityException ex)
                {
                    ErrorMessage(GetLocalized("ErrorImportPropExistsForYear"));
                    ProcessEntityException(ex);
                }
                
                catch(Exception e)
                {
                    ErrorMessage(e.Message);
                }
                
            }
            return false;
        }
        
    }
}

