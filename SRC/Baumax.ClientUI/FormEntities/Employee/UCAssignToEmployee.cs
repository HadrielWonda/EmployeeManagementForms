using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.Employee
{
    using DevExpress.XtraGrid.Views.Grid.ViewInfo;
    using Baumax.Environment;

    public partial class UCAssignToEmployee : UCBaseEntity 
    {
        public UCAssignToEmployee()
        {
            InitializeComponent();
        }

        public AssignEmployeeState AssignState
        {
            get { return (AssignEmployeeState)Entity; }
        }


        public Domain.Employee ExtEmployee
        {
            get
            {
                if (AssignState != null)
                    return AssignState.ExtEmployee;
                else return null;
            }
        }

        protected override void EntityChanged()
        {
            Bind();
            base.EntityChanged();
        }

        public override void Bind()
        {
            if (AssignState != null)
            {
                teEmployee.Text = ExtEmployee.FirstName + " " + ExtEmployee.LastName;

                gridControlEmployee.DataSource = AssignState.Employees;
            }
            else
            {
                teEmployee.Text = String.Empty;
                gridControlEmployee.DataSource = null;
            }
            base.Bind();
        }

        
        private Domain.Employee GetRowByRowHandle(int rowHandle)
        {
            Domain.Employee empl = null;
            if (gridViewEmployee.IsDataRow(rowHandle))
            {
                empl = (Domain.Employee)gridViewEmployee.GetRow(gridViewEmployee.FocusedRowHandle);
            }

            return empl;

        }

        public Domain.Employee FocusedEntity
        {
            get
            {
                return GetRowByRowHandle(gridViewEmployee.FocusedRowHandle);
            }
        }

        private void gridControlEmployee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewEmployee.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEmployee.IsDataRow(info.RowHandle))
            {
                Domain.Employee entity = GetRowByRowHandle(info.RowHandle);
                if (entity != null) 
                    FireAssignEmployee(entity);
            }
        }

        public bool FireAssignEmployee(Baumax.Domain.Employee entity)
        {
            Debug.Assert(entity != null);
            Debug.Assert(ExtEmployee != null);
            Debug.Assert(AssignState != null);

            if (QuestionMessageYes(GetLocalized("QuestionAssignExternalEmployee")))
            {

                try
                {
                    ClientEnvironment.EmployeeService.Merge(entity.ID, ExtEmployee.ID);

                    AssignState.ToEmployee = entity;

                    if (this.Parent is XtraForm)
                    {
                        (this.Parent as XtraForm).DialogResult = DialogResult.OK;
                    }
                    return true;
                }
                catch (EmployeeMergeException ex)
                {
                    if (ex.EmployeeMergeError == EmployeeMergeError.CantMerge)
                    {
                        ErrorMessage(GetLocalized("ErrorCantMergeEmployees"));
                    }
                    else
                    {
                        ProcessEntityException(ex);
                    }
                    return false;
                }
            }
            return false;

        }

    }
}
