using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Employee
{
    using Baumax.Domain;
    using Baumax.Environment;
    using System.Diagnostics;
    using Baumax.Contract.Exceptions.EntityExceptions;

    public partial class UCExternalEmployee : UCBaseEntity 
    {

        CountryDictionary m_listCountries = new CountryDictionary();
        RegionDictionary m_listRegions = new RegionDictionary();
        StoreDictionary m_ListStores = new StoreDictionary();


        public UCExternalEmployee()
        {
            InitializeComponent();

            seBalanceHours.Properties.MinValue = -1000;
            seOldHolidays.Properties.MinValue = Convert.ToDecimal(Int16.MinValue);
            seNewHolidays.Properties.MinValue = Convert.ToDecimal(Int16.MinValue);
            seHoursPerWeek.Properties.MinValue = 0;

            seBalanceHours.Properties.MaxValue = 1000;
            seOldHolidays.Properties.MaxValue = Convert.ToDecimal(Int16.MaxValue);
            seNewHolidays.Properties.MaxValue = Convert.ToDecimal(Int16.MaxValue);

            //seHoursPerWeek.Properties.MaxValue = Convert.ToDecimal(Byte.MaxValue);

            deBeginTime.Properties.MinValue = Contract.DateTimeSql.SmallDatetimeMin;
            deEndTime.Properties.MinValue = Contract.DateTimeSql.SmallDatetimeMin;
            deBeginTime.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;
            deEndTime.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;

            spinPersNumber.Properties.MaxValue = int.MaxValue;
        }

        void FillLists()
        {
            m_listCountries.Refresh ();
            m_listRegions.Refresh ();
            m_ListStores.Refresh ();
            Country[] arrCountry = new Country [m_listCountries.Count ];
            m_listCountries.Values.CopyTo (arrCountry, 0);
            lookUpCountries.Properties.DataSource = arrCountry;
        }

        private DateTime _filterdate = DateTime.Today ;


        /// <summary>
        /// FilterDate - date for build employee info, take from employee manager control
        /// take effect on relation and contract which will assign to employee entity
        /// </summary>

        public DateTime FilterDate
        {
            get { return _filterdate; }
            set { _filterdate = value; }
        }
	
        public Employee EntityEmployee
        {
            get
            {
                return (Employee)Entity;
            }
        }

        #region control entity properties

        public long CountryId
        {
            get
            {
                return (lookUpCountries.EditValue != null) ? Convert.ToInt64(lookUpCountries.EditValue) : (long)-1;
            }
            set
            {
                lookUpCountries.EditValue = value;
            }
        }
        public long RegionId
        {
            get
            {
                return (lookUpRegions.EditValue != null) ? Convert.ToInt64(lookUpRegions.EditValue) : (long)-1;
            }
            set
            {
                lookUpRegions.EditValue = value;
            }
        }

        public long StoreId
        {
            get
            {
                return (lookUpStores.EditValue != null) ? Convert.ToInt64(lookUpStores.EditValue) : (long)-1;
            }
            set
            {
                lookUpStores.EditValue = value;
            }
        }

        public long WorldId
        {
            get
            {
                return storeWorldLookUpCtrl.WorldId ;
            }
            set
            {
                storeWorldLookUpCtrl.WorldId = value;
            }
        }
       
    	public int? PersonalNumber
    	{
			get
			{
                if (spinPersNumber.EditValue != null)
                    return (int?)(decimal)spinPersNumber.EditValue;
                else 
                    return null;
			}
			set { spinPersNumber.EditValue = value; }
    	}

    	public string PersonalID
    	{
    		get { return txtPersonID.Text; }
			set { txtPersonID.EditValue = value; }
    	}

        public string FirstName
        {
            get { return teFirstName.Text.Trim (); ; }
            set { teFirstName.Text = value; }
        }

        public string LastName
        {
            get { return teLastName.Text.Trim(); ; }
            set { teLastName.Text = value; }
        }


        public decimal OldHolidays
        {
            get { return seOldHolidays.Value; }
            set { seOldHolidays.Value = value; }
        }
        public decimal NewHolidays
        {
            get { return seNewHolidays.Value; }
            set { seNewHolidays.Value = value; }
        }

        public decimal EmployeeBalanceHours
        {
            get { return seBalanceHours.Value; }
            set { seBalanceHours.Value = value; }
        }

        public DateTime BeginTime
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

        public DateTime EndTime
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

        public decimal ContractHoursPerWeek
        {
            get { return seHoursPerWeek.Value; }
            set { seHoursPerWeek.Value = value; }
        }
        #endregion

        private void SetStore(long storeid)
        {
            Domain.Store store = null;

            if (m_ListStores .TryGetValue (storeid, out store))
            {
                Domain.Region reg = null;
                if (m_listRegions.TryGetValue(store.RegionID, out reg))
                {
                    CountryId = reg.CountryID;
                    RegionId = reg.ID;
                    StoreId = storeid;
                    StoreWorldController sw = new StoreWorldController();
                    sw.LoadByStoreId(storeid);

                    storeWorldLookUpCtrl.EntityList = sw.GetListByStoreId(storeid);

                }
            }
        }

        private void SetEnabledState(bool bEnabled)
        {
            //lookUpCountries.Enabled = bEnabled;
            //lookUpRegions.Enabled = bEnabled;
            //lookUpStores.Enabled = bEnabled;

            teFirstName.Enabled = bEnabled;
            teLastName.Enabled = bEnabled;

            seOldHolidays.Enabled = bEnabled;
            seBalanceHours.Enabled = bEnabled;
        }

        private void SetEditMode()
        {
            lookUpCountries.Enabled = false;
            lookUpRegions.Enabled = false;
            lookUpStores.Enabled = false;
            storeWorldLookUpCtrl.Enabled = false;

            DateTime maxDate = ClientEnvironment.EmployeeService.EmployeeTimeService.GetMaxDateOfPlanningOrRecording(EntityEmployee.ID);
            
            deBeginTime.Enabled = false;

            deEndTime.Enabled = deEndTime.DateTime > maxDate && deEndTime.DateTime > DateTime.Today;

            seHoursPerWeek.Enabled = false;
        }

        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                SetEnabledState(true);
                FillLists();
                Employee empl = (Employee)Entity;

                SetStore(empl.MainStoreID);
            	PersonalID = empl.PersID;
            	PersonalNumber = empl.PersNumber;
                FirstName = empl.FirstName;
                LastName = empl.LastName;
                OldHolidays = empl.OldHolidays ;
                EmployeeBalanceHours = empl.BalanceHours ;
                NewHolidays = empl.NewHolidays;
                //BeginTime = (empl.ContractBegin.HasValue)? empl.ContractBegin.Value : DateTime.Today ;
                //EndTime = (empl.ContractEnd.HasValue) ? empl.ContractEnd.Value : Contract.DateTimeSql.SmallDatetimeMax;

                BeginTime = empl.ContractBegin ;
                EndTime = empl.ContractEnd;


                if (empl.WorldID.HasValue)
                    WorldId = empl.WorldID.Value;

                ContractHoursPerWeek = empl.ContractWorkingHours;

                if (!EntityEmployee.IsNew)
                    SetEditMode();

            }
            else
            {
                SetEnabledState(false);
            }
            base.EntityChanged();
        }

        public bool IsModified()
        {
           
             return (StoreId != EntityEmployee.MainStoreID) || // new replace
				 (PersonalID != EntityEmployee.PersID) ||
				 (PersonalNumber != EntityEmployee.PersNumber) ||
                (LastName != EntityEmployee.LastName) ||
                (FirstName != EntityEmployee.FirstName) ||
                (OldHolidays != EntityEmployee.OldHolidays ) ||
                (NewHolidays != EntityEmployee.NewHolidays) ||
                //(BeginTime != EntityEmployee.ContractBegin.Value) ||
                //(EndTime != EntityEmployee.ContractEnd.Value) ||
                (BeginTime != EntityEmployee.ContractBegin) ||
                (EndTime != EntityEmployee.ContractEnd) ||

                (ContractHoursPerWeek != EntityEmployee.ContractWorkingHours) ||
                (EmployeeBalanceHours != EntityEmployee.BalanceHours) ||
                (WorldId != EntityEmployee.WorldID);
              
        }

        public override bool IsValid()
        {
            bool valid = true;
            if (LastName.Length == 0)
            {
                teLastName.ErrorText = GetLocalized("SecondNameShouldBeNotEmpty");
                valid = false;
            }
            else teLastName.ErrorText = String.Empty ;

            if (FirstName.Length == 0)
            {
                teFirstName.ErrorText = GetLocalized("FirstNameShouldBeNotEmpty");
                valid = false;
            }
            else teFirstName.ErrorText = String.Empty;

            if (BeginTime > EndTime)
            {
                deEndTime.ErrorText = GetLocalized("ErrorDateRange");
                valid = false;
            }
            else deEndTime.ErrorText = String.Empty;
            if (ContractHoursPerWeek == 0)
            {
                seHoursPerWeek.ErrorText = GetLocalized("ErrorEnterHoursPerWeek");
                valid = false;
            }
            else seHoursPerWeek.ErrorText = String.Empty;

            if (WorldId <= 0)
            {
                storeWorldLookUpCtrl.ErrorText = GetLocalized("ErrorSelectWorld");
                valid = false;
            }
            else storeWorldLookUpCtrl.ErrorText = String.Empty; 

            if (!valid) return false;

            return base.IsValid();
        }

        public override bool Commit()
        {
            if (IsValid())
            {
                if (IsModified())
                {
                    Employee empl = EmployeeHelper.CreateCopy (EntityEmployee);

                    empl.MainStoreID = StoreId;
                	empl.PersID = PersonalID;
                	empl.PersNumber = PersonalNumber;
                    empl.FirstName = FirstName;
                    empl.LastName = LastName;
                    empl.OldHolidays = OldHolidays;
                    empl.BalanceHours = EmployeeBalanceHours;
                    empl.NewHolidays = NewHolidays;
                    empl.AvailableHolidays = empl.NewHolidays + empl.OldHolidays;
                    empl.ContractBegin = BeginTime;
                    empl.ContractEnd = EndTime;
                    empl.ContractWorkingHours = ContractHoursPerWeek;
                    empl.WorldID = WorldId;

                    Domain.Employee newEmpl = null;
                    try
                    {
                        decimal balance = empl.BalanceHours;

                        empl.BalanceHours *= 60;
                        if (empl.IsNew)
                        {
                            empl.CreateDate = DateTime.Today;
                            //newEmpl = ClientEnvironment.EmployeeService.Save(empl);
                        }
                        else
                        {
                            //newEmpl = ClientEnvironment.EmployeeService.SaveOrUpdate(empl);
                        }
                        newEmpl = ClientEnvironment.EmployeeService.SaveExternalEmployee(empl, FilterDate);
                        EmployeeHelper.Copy(newEmpl, EntityEmployee);
                        EntityEmployee.BalanceHours = balance;

                        //if (empl.IsNew)
                        //{
                        //    if (EntityEmployee.WorldID == null)
                        //    {
                        //        WorldDictionary wd = new WorldDictionary ();
                        //        wd.Refresh ();
                        //        EntityEmployee.WorldID = wd.GetAdministarionWorld();
                        //    }
                        //    if (EntityEmployee.StoreID <= 0)
                        //    {
                        //        EntityEmployee.StoreID = StoreId;
                        //    }
                        //}
                        Modified = true;
                    }
					catch (ValidationException ex)
					{
						string message = Localizer.GetLocalized(ex.Message);
						if (String.IsNullOrEmpty(message))
						{
							message = ex.Message;
						}
						ErrorMessage(message);
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
            return false;
        }

        private void lookUpCountries_EditValueChanged(object sender, EventArgs e)
        {
            List<Domain.Region> l = m_listRegions.GetRegionByCountry(CountryId);
            lookUpRegions.Properties.DataSource = l;

            if (l != null && l.Count > 0)
            {
                lookUpRegions.EditValue = l[0].ID;
            }
        }

        private void lookUpRegions_EditValueChanged(object sender, EventArgs e)
        {
            List<Domain.Store> l = m_ListStores.GetStoreByRegion(RegionId);
            lookUpStores.Properties.DataSource = l;
            if (l != null && l.Count > 0)
            {
                lookUpStores.EditValue = l[0].ID;
            }
        }

        private void deEndTime_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                EndTime = Contract.DateTimeSql.SmallDatetimeMax;
            }
        }
    }
}
