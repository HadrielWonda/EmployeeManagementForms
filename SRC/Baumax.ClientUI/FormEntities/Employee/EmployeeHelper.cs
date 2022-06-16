using System;
using System.Collections;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;

namespace Baumax.ClientUI.FormEntities.Employee
{
	/*
     Employee manager
     
     */

	public class EmployeeContext
	{
		private Store m_currentStore = null;

		private DateTime m_currentAsOfDate = DateTime.Today;

		private BindingTemplate<Domain.Employee> m_employeeList = null;

		private Domain.Employee m_currentEmployee = null;

		private EmployeeLongTimeAbsence m_currentEmplAbsence = null;

		private EmployeeRelation m_currentRelation = null;
		private BindingTemplate<EmployeeRelation> m_Relations = null;

		private readonly WorldDictionary m_worldDiction = new WorldDictionary();
		private readonly StoreDictionary m_storeDiction = new StoreDictionary();
        private readonly StoreShortList _storeShortList = new StoreShortList();

        private bool m_SuspendedCall = false;

	
		public EmployeeContext()
		{
			m_worldDiction.Refresh();
			m_storeDiction.Refresh();
		    _storeShortList.ReInit();
		}

		public BindingTemplate<Domain.Employee> EmployeeList
		{
			get { return m_employeeList; }
		}
        public bool SuspendedCall
        {
            get { return m_SuspendedCall; }
            set { m_SuspendedCall = value; }
        }
		public Store CurrentStore
		{
			get { return m_currentStore; }

			set
			{
				if(value != m_currentStore)
				{
					m_currentStore = value;
					OnCriteriaChanged();
				}
			}
		}

		public Domain.Employee CurrentEmployee
		{
			get { return m_currentEmployee; }

			set
			{
				if(value != m_currentEmployee)
				{
					m_currentEmployee = value;
				}
			}
		}

        public long CurrentEmployeeID
        {
            get { return m_currentEmployee.ID; }

            set
            {
                if (value != m_currentEmployee.ID)
                {
                    foreach (Domain.Employee employee in m_employeeList)
                        if (employee.ID == value)
                        {
                            m_currentEmployee = employee;
                            break;
                        }
                }
            }
        }

		public EmployeeLongTimeAbsence EmployeeAbsence
		{
			get { return m_currentEmplAbsence; }

			set
			{
				if(value != m_currentEmplAbsence)
				{
					m_currentEmplAbsence = value;
				}
			}
		}

		public EmployeeRelation CurrentRelation
		{
			get { return m_currentRelation; }

			set
			{
				if(value != m_currentRelation)
				{
					m_currentRelation = value;
				}
			}
		}

		public long CurrentCountryID
		{
			get
			{
				long id = 0;
				if(CurrentStore != null)
				{
					id = GetCountryIDByRegionID(CurrentStore.RegionID);
				}
				return id;
			}
		}

		public BindingTemplate<EmployeeRelation> Relations
		{
			get { return m_Relations; }
		}

		public DateTime CurrentAsOfDate
		{
			get { return m_currentAsOfDate; }
			set
			{
				if(value != m_currentAsOfDate)
				{
					m_currentAsOfDate = value;
					OnCriteriaChanged();
				}
			}
		}

		public void SetCriteria (Store currentStore, DateTime asOfDate)
		{
			m_currentStore = currentStore;
			m_currentAsOfDate = asOfDate;

			OnCriteriaChanged();
		}

		public string GetWorldName(long id)
		{
			return m_worldDiction.GetNameById(id);
		}

		public string GetStoreName(long id)
		{
			return m_storeDiction.GetStoreName(id);
		}

		protected virtual void OnCriteriaChanged()
		{
            if (CurrentStore == null) return;

			if(EmployeeList == null)
			{
				m_employeeList = new BindingTemplate<Domain.Employee>();
			} else
			{
				m_employeeList.Clear();
			}

            m_employeeList.CopyList(ClientEnvironment.EmployeeService.GetEmployeeList(CurrentStore.ID, CurrentAsOfDate, 
                CurrentStore.CountryID == ClientEnvironment.CountryService.AustriaCountryID));
            
            long countryid = CurrentCountryID;
            long austriaid = ClientEnvironment.CountryService.AustriaCountryID;

            foreach (Domain.Employee empl in m_employeeList)
            {
                empl.BalanceHours = Math.Round(empl.BalanceHours / 60, 2);

                if (countryid != austriaid)
                {
                    empl.AvailableHolidays = empl.OldHolidays + empl.NewHolidays;
                }
                //else
                //{
                //    empl.SpareHolidaysExc = empl.AvailableHolidays;
                //    empl.AvailableHolidays = 0;
                //}
            }
		}

		public void FillEmployeeRelation(IList lstRelations)
		{
			if(lstRelations != null)
			{
				foreach(EmployeeRelation relation in lstRelations)
				{
                    //acpro #119772
					//relation.StoreName = m_storeDiction.GetStoreName(relation.StoreID);
				    StoreShort storeShort = _storeShortList.GetById(relation.StoreID);
				    relation.StoreName = storeShort != null ? storeShort.StoreName : string.Empty;
					if(relation.WorldID.HasValue)
					{
						relation.WorldName = m_worldDiction.GetNameById(relation.WorldID.Value);
					}
				}
			}
		}

		public long GetCountryIDByRegionID(long regionid)
		{
			Domain.Region region = ClientEnvironment.RegionService.FindById(regionid);
			if(region != null)
			{
				return region.CountryID;
			} else
			{
				return 0;
			}
		}

		public void LoadEmployeeRelation()
		{
			if(CurrentEmployee != null)
			{
				IList lst = ClientEnvironment.EmployeeRelationService.GetEmployeeRelations(CurrentEmployee.ID);
				m_Relations = new BindingTemplate<EmployeeRelation>(lst);
				FillEmployeeRelation(m_Relations);
			} else
			{
				m_Relations.Clear();
				m_Relations = null;
			}
		}
	}

	public class LongTimeAbsenceManager : BindingTemplate<LongTimeAbsence>
	{
		private long m_CountryID = 0;

		public LongTimeAbsenceManager(long countryid)
		{
			CountryID = countryid;
		}

		public long CountryID
		{
			get { return m_CountryID; }
			set
			{
				if(value != m_CountryID)
				{
					m_CountryID = value;
					LoadAbsences(CountryID);
				}
			}
		}

		public void LoadAbsences(long countryid)
		{
			Clear();
			if(countryid > 0)
			{
				CopyList(ClientEnvironment.LongTimeAbsenceService.FindAllByCountry(countryid));
			}
		}

		public string GetAbsenceName(long absId)
		{
			string name = String.Empty;
			LongTimeAbsence abs = GetItemByID(absId);

			if(abs != null)
			{
				name = abs.CodeName;
			}

			return name;
		}
	}

	internal class EmployeeHelper
	{
		public static Domain.Employee CreateCopy(Domain.Employee source)
		{
			Domain.Employee dest = new Domain.Employee();
			Copy(source, dest);
			return dest;
		}

		public static void Copy(Domain.Employee source, Domain.Employee dest)
		{
			BaseEntity.CopyTo(source, dest);
			/*dest.ID = source.ID;
			dest.StoreID = source.StoreID;
			dest.Import = source.Import;
			dest.CreateDate = source.CreateDate;
			dest.LastName = source.LastName;
			dest.MainStoreID = source.MainStoreID;
			dest.NewHolidays = source.NewHolidays;
			dest.OldHolidays = source.OldHolidays;
			dest.PersID = source.PersID;
			dest.SpareHolidaysExc = source.SpareHolidaysExc;
			dest.SpareHolidaysInc = source.SpareHolidaysInc;
			dest.WorldID = source.WorldID;
			dest.UsedHolidays = source.UsedHolidays;
			dest.HWGR_ID = source.HWGR_ID;
			dest.AvailableHolidays = source.AvailableHolidays;
			dest.BalanceHours = source.BalanceHours;
			dest.ContractBegin = source.ContractBegin;
			dest.ContractEnd = source.ContractEnd;
			dest.ContractWorkingHours = source.ContractWorkingHours;
			dest.FirstName = source.FirstName;
			dest.EmployeeContractID = source.EmployeeContractID;
			dest.EmployeeRelationsID = source.EmployeeRelationsID;
            dest.BeginTime = source.BeginTime;
            dest.EndTime = source.EndTime;
             */
		}
	}
}