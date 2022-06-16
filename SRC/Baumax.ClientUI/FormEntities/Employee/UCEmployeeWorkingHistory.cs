using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;
using System.Collections;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Templates;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class UCEmployeeWorkingHistory : UCBaseEntity 
    {
        public UCEmployeeWorkingHistory()
        {
            InitializeComponent();
            AccessType access =
                ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.EmployeeRelationService);

            ReadOnly = (access & AccessType.Write) == 0;
        }

        StoreWorldController swController = null;
        //BindingTemplate<EmployeeRelation> m_Relations = null;
        EmployeeContext Context
        {
            get
            {
                return (EmployeeContext)Entity;
            }
        }

        protected void LoadEmployeeRelation()
        {

            if (Context != null && Context.CurrentEmployee != null)
            {
                Context.LoadEmployeeRelation();
                gridControl.DataSource = Context.Relations ;
            }
            else
            {
                gridControl.DataSource = null;
            }
            //IList lst = ClientEnvironment.EmployeeRelationService.GetEmployeeRelations(Context.CurrentEmployee.ID);

            //Context.FillEmployeeRelation(lst);
            ///*
            //WorldDictionary worldDiction = new WorldDictionary();
            //worldDiction.Refresh();
            //worldDiction.FillEmployeeRelation(lst);
            //StoreDictionary storeDiction = new StoreDictionary();
            //storeDiction.Refresh();
            //storeDiction.FillEmployeeRelation(lst);
            // * */
            //m_Relations = new BindingTemplate<EmployeeRelation>(lst);

            //gridControl.DataSource = m_Relations;
            UpdateButtonState();
        }
        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                swController = new StoreWorldController();
                LoadEmployeeRelation();

                teEmployee.Text = Context.CurrentEmployee.FullName;
                //IList lst = ClientEnvironment.EmployeeRelationService.GetEmployeeRelations(Context.CurrentEmployee.ID);

                //Context.FillEmployeeRelation(lst);
                ///*
                //WorldDictionary worldDiction = new WorldDictionary();
                //worldDiction.Refresh();
                //worldDiction.FillEmployeeRelation(lst);
                //StoreDictionary storeDiction = new StoreDictionary();
                //storeDiction.Refresh();
                //storeDiction.FillEmployeeRelation(lst);
                // * */
                //m_Relations = new BindingTemplate<EmployeeRelation>(lst);

                //gridControl.DataSource = m_Relations;
                //UpdateButtonState();
            }
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);
                LocalizerControl.NavBarLocalize(this.navBarControl1);
            }
        }
        EmployeeRelation GetEntityByRowHandle(int rowHandle)
        {
            EmployeeRelation relation = null;
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                relation = (EmployeeRelation)gridViewEntities.GetRow(rowHandle);
            }
            return relation;
        }

        public EmployeeRelation FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }
		
        private void UpdateButtonState()
        {
        	bi_NewAssignEmplToWorld.Enabled = !IsContractExpired && !ReadOnly;
            bi_EditAssignEmplToWorld.Enabled = EditEnabled && !IsContractExpired;
            bi_DeleteAssignEmplToWorld.Enabled = DeleteEnabled;

            mi_NewAssignEmplToWorld.Enabled = !IsContractExpired && !ReadOnly;
			mi_EditAssignEmplToWorld.Enabled = EditEnabled && !IsContractExpired;
            mi_DeleteAssignEmplToWorld.Enabled = DeleteEnabled;
        }

        public override bool AddEnabled
        {
            get
            {
                return base.AddEnabled;
            }
        }
        public override bool EditEnabled
        {
            get
            {
                EmployeeRelation relation = FocusedEntity;
                bool result = false;
                if (relation != null && !ReadOnly)
                {
                    if (relation.EndTime > DateTime.Today)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        public override bool DeleteEnabled
        {
            get
            {
                EmployeeRelation relation = FocusedEntity;
                bool result = false;
                if (relation != null && !ReadOnly)
                {
                    if (relation.BeginTime > DateTime.Today)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

    	public bool IsContractExpired
    	{
    		get
    		{
    			return Context.CurrentEmployee.ContractEnd < DateTime.Today;
    		}
    	}

        public override void Add()
        {
            if (Context != null && FocusedEntity != null && Context.CurrentStore !=null)
            {


                List<Domain.StoreToWorld> lst = null;
                lst = swController.GetListByStoreId(Context.CurrentStore.ID);

                if (lst.Count == 0)
                {
                    lst = ClientEnvironment.StoreToWorldService.FindAllForStore(Context.CurrentStore.ID);
                    swController.AddList(lst);
                }

                using (FormAssignEmployeeToWorld assignform = new FormAssignEmployeeToWorld())
                {
                    Domain.Employee empl = Context.CurrentEmployee;

                    EmployeeRelation relation = new EmployeeRelation();

                    relation.EmployeeID = empl.ID;
                    relation.EmployeeName = empl.FullName;
                    relation.WorldID = 0;

                    if (FocusedEntity != null)
                    {
                        relation.WorldID = FocusedEntity.WorldID;
                        relation.BeginTime = FocusedEntity.BeginTime;
                        if (relation.BeginTime < DateTime.Today) relation.BeginTime = DateTime.Today;
                        relation.EndTime = FocusedEntity.EndTime;
                        if (relation.BeginTime > relation.EndTime)
                            relation.EndTime = Contract.DateTimeSql.SmallDatetimeMax;

                    }

                    Context.CurrentRelation = relation;
                    assignform.SetWorldList(swController.GetListByStoreId(Context.CurrentStore.ID));
                    assignform.Entity = Context;



                    if (assignform.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployeeRelation();

                        if (Context.Relations != null)
                        {
                            Domain.Employee employee = ClientEnvironment.EmployeeService.GetEmployeeByID(empl.ID, DateTime.Now);
                            if (Context.EmployeeList != null && employee != null)
                            {
								Context.EmployeeList.SetEntity(employee); 
                            }
                        }
                    }
                }
            }
        }

        public override void Edit()
        {
            if (Context != null && FocusedEntity != null && Context.CurrentStore != null)
            {


                List<Domain.StoreToWorld> lst = null;
                lst = swController.GetListByStoreId(Context.CurrentStore.ID);

                if (lst.Count == 0)
                {
                    lst = ClientEnvironment.StoreToWorldService.FindAllForStore(Context.CurrentStore.ID);
                    swController.AddList(lst);
                }
                using (FormAssignEmployeeToWorld assignform = new FormAssignEmployeeToWorld())
                {
                    Domain.Employee empl = Context.CurrentEmployee;
                    Context.CurrentRelation = FocusedEntity;

                    assignform.SetWorldList(swController.GetListByStoreId(Context.CurrentStore.ID));
                    assignform.Entity = Context;

                    

                    if (assignform.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployeeRelation();
                        //m_Relations.ResetItemById(Context.CurrentRelation.ID);
                    }
                }
            }
        }

        public override void Delete()
        {
            if (DeleteEnabled)
            {
                if (QuestionMessageYes(GetLocalized("QuestionDeleteEmployeeWorld")))
                {
                    EmployeeRelation relation = FocusedEntity;
                    try
                    {
                        ClientEnvironment.EmployeeRelationService.DeleteByID(relation.ID);
                        gridViewEntities.DeleteRow(gridViewEntities.FocusedRowHandle);
                    }
                    catch(EntityException ex)
                    {
                        ProcessEntityException(ex);
                    }
                }
            }
        }

        private void bi_New_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Add();
        }

        private void bi_Edit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Edit();
        }

        private void bi_Delete_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Delete();
        }

        private void gridViewEntities_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void gridViewEntities_RowCountChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void mi_NewAssignEmplToWorld_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void mi_EditAssignEmplToWorld_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void mi_DeleteAssignEmplToWorld_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                EmployeeRelation entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) Edit();
            }*/
        }

    }
}
