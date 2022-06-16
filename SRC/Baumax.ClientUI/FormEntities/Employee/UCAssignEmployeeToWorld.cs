using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Employee
{
    using Baumax.Contract;
    using Baumax.Environment;
    using Baumax.Domain ;
    using Baumax.Contract.Exceptions.EntityExceptions;

    public partial class UCAssignEmployeeToWorld : UCBaseEntity 
    {
        
        public EmployeeContext Context
        {
            get { return (EmployeeContext)Entity; }
        }

        List<StoreToWorld> m_WorldList = new List<StoreToWorld>();

        public UCAssignEmployeeToWorld()
        {
            InitializeComponent();
            
            BeginTime = DateTime.Today;
            EndTime = DateTime.Today.AddDays(14);

            if (ClientEnvironment.IsRuntimeMode)
                InitRepositoryItems();
        }

        private void InitRepositoryItems()
        {
            deBeginTime.Properties.MinValue = DateTime.Today;
            deBeginTime.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;

            deEndTime.Properties.MinValue = DateTime.Today;
            deEndTime.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;
        }

        #region Form properties

        public long StoreWorldId
        {
            get 
            {
                return storeWorldLookUpCtrl.WorldId ;
            }
            set { storeWorldLookUpCtrl.WorldId = value; }
        }

        public DateTime BeginTime
        {
            get { return Convert.ToDateTime (deBeginTime.EditValue ); }
            set { deBeginTime.EditValue = value; }
        }

        public DateTime EndTime
        {
            get { return Convert.ToDateTime(deEndTime.EditValue); }
            set { deEndTime.EditValue = value; }
        }

        #endregion

        protected override void EntityChanged()
        {
            Bind();
            base.EntityChanged();
        }

        public override void Bind()
        {
            if (Context != null)
            {
				// Emoloyee can be assigned to world only during his contract time.
            	deBeginTime.Properties.MinValue = deEndTime.Properties.MinValue = DateTime.Today  > Context.CurrentEmployee.ContractBegin ? DateTime.Today : Context.CurrentEmployee.ContractBegin;
				deEndTime.Properties.MaxValue = deEndTime.Properties.MaxValue = Context.CurrentEmployee.ContractEnd;

                if (Context.CurrentRelation.IsNew)
                {
                    teEmployeeName.Text = Context.CurrentEmployee.FullName;
                    teEmployeeName.Enabled = false;
                    //BeginTime = DateTime.Today;
                    //EndTime = DateTime.Today.AddDays(14);
                    BeginTime = Context.CurrentRelation.BeginTime;
                    EndTime = Context.CurrentRelation.EndTime;

                    if (Context.CurrentRelation.WorldID != null && Context.CurrentRelation.WorldID > 0)
                        StoreWorldId = Context.CurrentRelation.WorldID.Value;
                }
                else
                {
                    teEmployeeName.Text = Context.CurrentEmployee.FullName;
                    teEmployeeName.Enabled = false;
                    StoreWorldId = Context.CurrentRelation.WorldID.Value;
                    storeWorldLookUpCtrl.Enabled = false;
                    BeginTime = Context.CurrentRelation.BeginTime ;
                    EndTime = Context.CurrentRelation.EndTime;
                }
            }
             base.Bind();
        }

        public override bool IsValid()
        {
            bool valid = true;
            if (BeginTime > EndTime)
            {
                deEndTime.ErrorText = GetLocalized("ErrorDateRange");
                valid = false;
            }
            else deEndTime.ErrorText = String.Empty;

            if (StoreWorldId <= 0)
            {
                storeWorldLookUpCtrl.ErrorText = GetLocalized("ErrorSelectWorld");
                valid = false;
            }
            else storeWorldLookUpCtrl.ErrorText = String.Empty;

            if (!valid) return false;

            return base.IsValid();
        }
        public bool IsModified()
        {
            return true;
            /*if (Context.CurrentRelation.IsNew) return true;

            EmployeeRelation rel = Context.CurrentRelation;

            return (rel.BeginTime != BeginTime ||
                    rel.EndTime == EndTime ||
                    rel.WorldID == StoreWorldId); */
        }
        public override bool Commit()
        {
            if (IsValid())
            {
                if (IsModified())
                {
                    try
                    {


                        Context.CurrentRelation.WorldID = StoreWorldId;
                        Context.CurrentRelation.BeginTime = BeginTime;
                        Context.CurrentRelation.EndTime = EndTime;
                        Context.CurrentRelation.StoreID = Context.CurrentStore.ID;

                        //EmployeeRelationManager manager = new EmployeeRelationManager(Context.CurrentRelation.EmployeeID, Context.CurrentRelation.StoreID, ClientEnvironment.EmployeeRelationService);
                        //manager.InsertRelation(Context.CurrentRelation);

                        ClientEnvironment.EmployeeRelationService.InsertRelation(Context.CurrentRelation);

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
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return false;
                    }
                    Modified = true;
                }
                else Modified = false;

            }
            else return false;

            return base.Commit();
        }

        public void SetStoreWorldList(List<StoreToWorld> lst)
        {
            storeWorldLookUpCtrl.EntityList = lst;
        }
        /*
        private void seWorkingTimePerWeek_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                seWorkingTimePerWeek.EditValue = null;
            }
        }*/
    }
}
