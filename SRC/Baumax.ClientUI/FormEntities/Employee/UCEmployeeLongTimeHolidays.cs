using System;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.Employee
{
	public partial class UCEmployeeLongTimeHolidays : UCBaseEntity
	{
		private LongTimeAbsenceManager m_ListAbsence = null;

		public UCEmployeeLongTimeHolidays()
		{
			InitializeComponent();
		}

		private void InitDateEditMinMax()
		{
			deBeginDate.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
			deBeginDate.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
			deEndDate.Properties.MinValue =   DateTimeSql.SmallDatetimeMin;
			deEndDate.Properties.MaxValue =   DateTimeSql.SmallDatetimeMax;
		}

		public EmployeeContext Context
		{
			get { return (EmployeeContext)Entity; }
			set
			{
				if(value != null)
				{
					Entity = value;
				}
			}
		}

		private LongTimeAbsenceManager ListAbsence
		{
			get { return m_ListAbsence; }
		}

		private void FillEmployeesGrid()
		{
			gridLookUpEditEmployees.Properties.DataSource = Context.EmployeeList;
			if(Context.EmployeeList.Count > 0)
			{
				EmployeeID = Context.EmployeeList[0].ID;
			}
		}

		private void BuildTestAbsenceList()
		{
			m_ListAbsence = new LongTimeAbsenceManager(Context.CurrentCountryID);
			lookUpAbsence.Properties.DataSource = ListAbsence;
			if(ListAbsence.Count > 0)
			{
				lookUpAbsence.EditValue = ListAbsence[0].ID;
			}
		}

		#region Long absence control properties

		public long EmployeeID
		{
			get
			{
				if(gridLookUpEditEmployees.EditValue == null)
				{
					return 0;
				}
				return Convert.ToInt64(gridLookUpEditEmployees.EditValue);
			}
			set { gridLookUpEditEmployees.EditValue = value; }
		}

		public long LongTimeAbsenceID
		{
			get
			{
				if(lookUpAbsence.EditValue == null)
				{
					return 0;
				}
				return Convert.ToInt64(lookUpAbsence.EditValue);
			}
			set { lookUpAbsence.EditValue = value; }
		}

		public DateTime BeginTime
		{
			get { return deBeginDate.DateTime; }
			set { deBeginDate.DateTime = value; }
		}

		public DateTime EndTime
		{
			get { return deEndDate.DateTime; }
			set { deEndDate.DateTime = value; }
		}

		#endregion

		private void deEndDate_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if(e.Button.Kind == ButtonPredefines.Delete)
			{
				EndTime = DateTimeSql.SmallDatetimeMax;
			}
		}

		protected override void EntityChanged()
		{
			base.EntityChanged();

			BeginTime = DateTime.Today;
			EndTime = DateTimeSql.SmallDatetimeMax;
			BuildTestAbsenceList();
			InitDateEditMinMax();
			FillEmployeesGrid();
			if(Entity != null)
			{
				gridLookUpEditEmployees.EditValue = Context.EmployeeAbsence.EmployeeID;

				if(Context.EmployeeAbsence.IsNew)
				{
					//Context.EmployeeAbsence.BeginTime = DateTime.Today;
					//Context.EmployeeAbsence.EndTime = DateTimeSql.SmallDatetimeMax;
					if(ListAbsence.Count > 0)
					{
						Context.EmployeeAbsence.LongTimeAbsenceID = ListAbsence[0].ID;
					}
					if(Context.EmployeeAbsence.EmployeeID <= 0)
					{
						if(Context.EmployeeList.Count > 0)
						{
							Context.EmployeeAbsence.EmployeeID = Context.EmployeeList[0].ID;
						}
					}
				}

				EmployeeID = Context.EmployeeAbsence.EmployeeID;
				BeginTime = Context.EmployeeAbsence.BeginTime;
				EndTime = Context.EmployeeAbsence.EndTime;
				LongTimeAbsenceID = Context.EmployeeAbsence.LongTimeAbsenceID;

				SetEditMode();
			}
		}

		private void SetEditMode()
		{
			if(Context.EmployeeAbsence == null)
			{
				gridLookUpEditEmployees.Enabled = false;
				lookUpAbsence.Enabled = false;
				deBeginDate.Enabled = false;
				deEndDate.Enabled = false;
			} else
			{
				if(Context.EmployeeAbsence.IsNew)
				{
					gridLookUpEditEmployees.Enabled = true;
					lookUpAbsence.Enabled = true;
					deBeginDate.Enabled = true;
                    deBeginDate.Properties.MinValue = DateTime.Today;
					deEndDate.Enabled = true;
				} else
				{
					//gridLookUpEditEmployees.Enabled = false;
                    gridLookUpEditEmployees.Properties.ReadOnly = true;

					if(BeginTime <= DateTime.Today)
					{
						lookUpAbsence.Properties.ReadOnly = true;//.Enabled = false;
						deBeginDate.Properties.ReadOnly = true;//.Enabled = false;
						deEndDate.Enabled = true;
					} else
					{
						lookUpAbsence.Enabled = true;
						deBeginDate.Enabled = true;
						deEndDate.Enabled = true;
					}
				}
			}
		}

		public override bool IsValid()
		{
			bool isValid = true;
			if(EmployeeID == 0)
			{
				isValid = false;
				gridLookUpEditEmployees.ErrorText = GetLocalized("InvalidValue");
			} else
			{
				gridLookUpEditEmployees.ErrorText = String.Empty;
			}

			if(LongTimeAbsenceID == 0)
			{
				isValid = false;
				lookUpAbsence.ErrorText = GetLocalized("ErrorSelectLongTimeAbsence");
			} else
			{
				lookUpAbsence.ErrorText = String.Empty;
			}

			if(BeginTime > EndTime && BeginTime > deEndDate.Properties.MinValue)
			{
				isValid = false;
				deEndDate.ErrorText = GetLocalized("InvalidDateRange");
			} else
			{
				deEndDate.ErrorText = String.Empty;
			}

			if(!isValid)
			{
				return false;
			}

			return base.IsValid();
		}

		public bool IsModified()
		{
			return (Context.EmployeeAbsence.IsNew) || (LongTimeAbsenceID != Context.EmployeeAbsence.LongTimeAbsenceID) || (BeginTime != Context.EmployeeAbsence.BeginTime) || (EndTime != Context.EmployeeAbsence.EndTime);
		}

		private void CopyAbsence(EmployeeLongTimeAbsence source, EmployeeLongTimeAbsence dest)
		{
			dest.ID = source.ID;
			dest.BeginTime = source.BeginTime;
			dest.EndTime = source.EndTime;
			dest.LongTimeAbsenceID = source.LongTimeAbsenceID;
			dest.EmployeeFullName = source.EmployeeFullName;
			dest.EmployeeID = source.EmployeeID;
		}

		private void FillAbsence(EmployeeLongTimeAbsence dest)
		{
			dest.BeginTime = BeginTime.Date;
            dest.EndTime = EndTime.Date;
			dest.LongTimeAbsenceID = LongTimeAbsenceID;
			dest.EmployeeID = EmployeeID;
		}

		public override bool Commit()
		{
            if (IsValid() && !Context.SuspendedCall)
            {
                if (IsModified())
                {
                    try
                    {
                        EmployeeLongTimeAbsence safeCopy = new EmployeeLongTimeAbsence();
                        CopyAbsence(Context.EmployeeAbsence, safeCopy);

                        FillAbsence(safeCopy);

                        safeCopy = ClientEnvironment.EmployeeService.EmployeeTimeService.SaveLongTimeAbsence(safeCopy);
                        
                        CopyAbsence(safeCopy, Context.EmployeeAbsence);

                        Domain.Employee empl = Context.EmployeeList.GetItemByID(safeCopy.EmployeeID);
                        if (empl != null)
                        {
                            Context.EmployeeAbsence.EmployeeFullName = empl.FullName;
                            //
                            // If new long time absence falls on today, set LongTimeAbsenceExtits flag to employee
                            //
                            if (Context.EmployeeAbsence.BeginTime <= DateTime.Today && Context.EmployeeAbsence.EndTime >= DateTime.Today)
                            {
                                empl.LongTimeAbsenceExist = true;
                            }
                        }

                        Context.EmployeeAbsence.LongTimeAbsenceName = m_ListAbsence.GetAbsenceName(Context.EmployeeAbsence.LongTimeAbsenceID);

                        Modified = true;
                        return base.Commit();
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("ErrorLongTimeAbsenceRange"));
                        //ProcessEntityException(ex);
                        return false;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return false;
                    }
                }

                return true;
            }
            else
                if (Context.SuspendedCall)
                {
                    Context.EmployeeAbsence.EmployeeID = (long)gridLookUpEditEmployees.EditValue;
                    Context.EmployeeAbsence.LongTimeAbsenceID = (long)lookUpAbsence.EditValue;
                    Context.EmployeeAbsence.BeginTime = deBeginDate.DateTime;
                    Context.EmployeeAbsence.EndTime = deEndDate.DateTime;
                    return Modified = true;
                }
			return false;
		}

        public void SetMinDate(DateTime dateTime)
        {
            deBeginDate.Properties.MinValue = dateTime;
            deEndDate.Properties.MinValue = dateTime;
        }
    }
}