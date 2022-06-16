using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract;
using DevExpress.XtraEditors;

using Baumax.Environment ;
using Baumax.Domain ;
using Baumax.Templates;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities
{
    using Baumax.ClientUI.FormEntities.Employee;

    public partial class UCLongTimeAbsenceEmployees : UCBaseEntity 
    {

        BindingTemplate<EmployeeLongTimeAbsence> m_EmployeesLongTimeAbsence = new BindingTemplate<EmployeeLongTimeAbsence> ();
        
        DateTime? todayDate = DateTime.Today;

        public UCLongTimeAbsenceEmployees()
        {
            InitializeComponent();

            gridControlEntities.DataSource = EmployeesLongTimeAbsence;
            AccessType access =
                ClientEnvironment.AuthorizationService.GetAccess(
                    ClientEnvironment.EmployeeService.EmployeeLongTimeAbsenceService);
            ReadOnly = (access & AccessType.Write) == 0;
        }


        public EmployeeContext Context
        {
            get
            {
                 return (EmployeeContext)Entity;
            }
        }

        public BindingTemplate<EmployeeLongTimeAbsence> EmployeesLongTimeAbsence
        {
            get
            {
                return m_EmployeesLongTimeAbsence;
            }
        }

        private void InitToolBar()
        {
            bar2.LinksPersistInfo.Clear();
            bar2.ItemLinks.Clear();

            bar2.ItemLinks.Add(bi_View);
            bar2.ItemLinks.Add(bi_NewEmplLongTimeAbsence);
            bar2.ItemLinks.Add(bi_EditEmplLongTimeAbsence);
            bar2.ItemLinks.Add(bi_DeleteEmplLongTimeAbsence);
        }

        protected override void EntityChanged()
        {
            LoadEmployeesLongTimeAbsence();
            base.EntityChanged();
        }

        protected override void OnLoad(EventArgs e)
        {
            DevExpress.XtraGrid.StyleFormatCondition fCond = (DevExpress.XtraGrid.StyleFormatCondition)gridViewEntities.FormatConditions[0];
            fCond.Value1 = DateTime.Today;
            fCond = (DevExpress.XtraGrid.StyleFormatCondition)gridViewEntities.FormatConditions[1];
            fCond.Value1 = DateTime.Today;

            InitToolBar();
            base.OnLoad(e);
        }

        public void LoadEmployeesLongTimeAbsence()
        {
            EmployeesLongTimeAbsence.Clear();

            if (Context != null)
            {
                gridViewEntities.BeginDataUpdate();
                try
                {
                    EmployeeLongTimeAbsence[] array = ClientEnvironment.EmployeeService.GetLongAbsenceEmployees(Context.CurrentStore.ID, todayDate);

                    if (array != null)
                    {
                        EmployeesLongTimeAbsence.CopyList((IList)array);
                    }
                }
                finally
                {
                    gridViewEntities.EndDataUpdate ();
                }
            }
            UpdateToolBarItems();
        }


        private EmployeeLongTimeAbsence GetEntityByRowHandle(int rowHandle)
        {
            EmployeeLongTimeAbsence absence = null;
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                absence = (EmployeeLongTimeAbsence)gridViewEntities.GetRow(rowHandle);
            }
            return absence;
        }

        public EmployeeLongTimeAbsence FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }

        private void UpdateToolBarItems()
        {
            bi_NewEmplLongTimeAbsence.Enabled = !ReadOnly;
            bi_EditEmplLongTimeAbsence.Enabled = EditEnabled;
            bi_DeleteEmplLongTimeAbsence.Enabled = DeleteEnabled;
        }

        public override bool EditEnabled
        {
            get
            {
                bool result = false;
                if (FocusedEntity != null && !ReadOnly)
                {
                    if (FocusedEntity.EndTime > DateTime.Today)
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
                bool result = false;
                if (FocusedEntity != null && !ReadOnly)
                {
                    if (FocusedEntity.BeginTime > DateTime.Today)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        private void bi_ViewToday_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!todayDate.HasValue)
            {
                todayDate = DateTime.Today;
                LoadEmployeesLongTimeAbsence();
            }
        }

        private void bi_ViewAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (todayDate.HasValue)
            {
                todayDate = null;
                LoadEmployeesLongTimeAbsence();
            }
        }

        private void gridViewEntities_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateToolBarItems();
        }

        private void gridViewEntities_RowCountChanged(object sender, EventArgs e)
        {
            UpdateToolBarItems();
        }

        
        private void bi_NewLongTimeAbsence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FireNewEntity();
        }

        private void bi_EditLongTimeAbsence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FireEditEntity();
        }

        private void bi_DeleteLongTimeAbsence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FireDeleteEntity();
        }

        private void gridControlEntities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                Domain.EmployeeLongTimeAbsence entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null)
                {
                    FireEditEntity();
                }
            }
        }

        public void FireNewEntity()
        {
            if (Context != null)
            {
                Context.EmployeeAbsence = new EmployeeLongTimeAbsence();
                using (FormEmployeeLongTimeAbsence form = new FormEmployeeLongTimeAbsence())
                {
                    form.Entity = Context;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                    	EmployeesLongTimeAbsence.Add(Context.EmployeeAbsence);
						Context.EmployeeList.ResetItemById(Context.EmployeeAbsence.EmployeeID);
                    }
                }
            }
        }

        public void FireEditEntity()
        {
            if (Context != null && FocusedEntity != null && EditEnabled)
            {
                Context.EmployeeAbsence = FocusedEntity;
                using (Employee.FormEmployeeLongTimeAbsence form = new Employee.FormEmployeeLongTimeAbsence())
                {
                    form.Entity = Context;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        EmployeesLongTimeAbsence.ResetItemById(Context.EmployeeAbsence.ID);
						Context.EmployeeList.ResetItemById(Context.EmployeeAbsence.EmployeeID);
                    }
                }
            }
        }

        public void FireDeleteEntity()
        {
            if (Context != null && FocusedEntity != null && DeleteEnabled)
            {
                EmployeeLongTimeAbsence newAbsence = FocusedEntity;

                if (QuestionMessageYes(GetLocalized("QuestionRemoveEmplLongTimeAbsence")))
                {
                    try
                    {
                        ClientEnvironment.EmployeeLongTimeAbsenceService.DeleteByID(newAbsence.ID);
                        EmployeesLongTimeAbsence.RemoveEntityById(newAbsence.ID);
						Domain.Employee employee = Context.EmployeeList.GetItemByID(newAbsence.EmployeeID);
						if (employee != null && newAbsence.BeginTime <= DateTime.Today && newAbsence.EndTime >= DateTime.Today)
						{
							employee.LongTimeAbsenceExist = false;
							Context.EmployeeList.ResetItemById(employee.ID);
						}
                    }
                    catch (EntityException ex)
                    {
                        ErrorMessage(GetLocalized("CantDeleteEmployeeLongTimeAbsence"));
                    }
                }
            } 
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);
            }
        }
        private void gridViewEntities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FireEditEntity();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                FireDeleteEntity();
            }
        }
    }
}
