using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormAssignEmployeeToStore : FormBaseEntity 
    {
        Domain.Employee m_currentEmployee = null;
        private bool m_modified = false;

        public FormAssignEmployeeToStore()
        {
            InitializeComponent();
        }

        public Domain.Employee EntityEmployee
        {
            get
            {
                return (Domain.Employee)Entity;
            }
        }

        public override object Entity
        {
            get
            {
                return m_currentEmployee;
            }
            set
            {
                if (m_currentEmployee != value)
                {
                    m_currentEmployee = (Domain.Employee)value;
                    ChangedEmployee();
                }
            }
        }

        private void ChangedEmployee()
        {
            if (EntityEmployee != null)
            {
				teEmployee.Text = EntityEmployee.FullName;

                BeginTime = DateTime.Today;
                EndTime = BeginTime.AddDays(14);
            }
            LoadStores();

            InitMinMax();
        }

        private void LoadStores()
        {
            if (EntityEmployee != null)
            {
            	Store mainStore = ClientEnvironment.StoreService.FindById(EntityEmployee.MainStoreID);
				Domain.Region mainStoreRegion = ClientEnvironment.RegionService.FindById(mainStore.RegionID);

            	Store[] countryStores = ClientEnvironment.StoreService.GetStoresByCountryId(mainStoreRegion.CountryID);

            	// 1. remove Main Store
				// 2. ACPRO 119772 an employee might only be assigned within stores of the same country
				countryStores = Array.FindAll(countryStores, delegate (Store store)
            	                                {
            	                                	return store.ID != EntityEmployee.MainStoreID 
															&& store.ID != EntityEmployee.StoreID;
            	                                });

                gridControl1.DataSource = countryStores;
            }
        }

        public DateTime BeginTime
        {
            get { return deBeginTime.DateTime; }
            set { deBeginTime.DateTime = value; }
        }

        public DateTime EndTime
        {
            get { return deEndTime.DateTime; }
            set { deEndTime.DateTime = value; }
        }

        void InitMinMax()
        {
        	if(EntityEmployee == null)
        	{
        		deBeginTime.Properties.MinValue = DateTime.Today;//DateTimeSql.SmallDatetimeMin;
        		deBeginTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;

        		deEndTime.Properties.MinValue = DateTime.Today;//DateTimeSql.SmallDatetimeMin;
        		deEndTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
        	} else
        	{
				deBeginTime.Properties.MinValue = deEndTime.Properties.MinValue = DateTime.Today > EntityEmployee.ContractBegin ? DateTime.Today : EntityEmployee.ContractBegin;
				deEndTime.Properties.MaxValue = deEndTime.Properties.MaxValue = EntityEmployee.ContractEnd;
        	}
        }


        private Store GetEntityByRowHandle(int rowHandle)
        {
            if (gridViewEntities.IsDataRow(rowHandle))
                return (Store)gridViewEntities.GetRow(rowHandle);
            return null;
        }

        public Store FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }

        public override bool Modified
        {
            get
            {
                return m_modified;
            }
        }
        protected override bool ValidateEntity()
        {
            if (BeginTime > EndTime)
            {
                deEndTime.ErrorText = GetLocalized("InvalidValue");

                return false;
            }
            else deEndTime.ErrorText = String.Empty;

            if (FocusedEntity == null)
            {
                ErrorMessage(GetLocalized("ErrorSelectStore"));
                return false;
            }
            return (EntityEmployee != null && FocusedEntity != null);
        }

        protected override bool SaveEntity()
        {
            if (ValidateEntity())
            {
                EmployeeRelation relation = new EmployeeRelation();
                relation.StoreID = FocusedEntity.ID;
                relation.EmployeeID = EntityEmployee.ID;
                relation.BeginTime = BeginTime;
                relation.EndTime = EndTime;

                List<Domain.World> lst = ClientEnvironment.WorldService.FindAll();
                if (lst != null)
                {
                    foreach (Domain.World w in lst)
                    {
                        if (w.WorldTypeID == WorldType.Administration)
                            relation.WorldID = w.ID;
                    }
                }

                try
                {
                    ClientEnvironment.EmployeeRelationService.InsertDeligationToStore(relation);
                    m_modified = true;
                    return true;
                }
                catch (ValidationException ex)
                {
					string localizedMessage = GetLocalized(ex.Message);
					if (String.IsNullOrEmpty(localizedMessage))
					{
						localizedMessage = GetLocalized("ErrorAssignToWorldDateRangeIntersect");
					}
					ErrorMessage(localizedMessage);
                    return false;
                }

            }
            else
                return false;
            
        }
    }
}