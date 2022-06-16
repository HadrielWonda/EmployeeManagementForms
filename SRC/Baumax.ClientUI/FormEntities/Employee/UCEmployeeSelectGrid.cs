using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain ;
using Baumax.Environment ;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class UCEmployeeSelectGrid : UCBaseEntity 
    {
        public UCEmployeeSelectGrid()
        {
            InitializeComponent();
        }


        public void AssignEmployeeList(List<Domain.Employee> emplList)
        {
            gridControl.DataSource = emplList;
        }

        Domain.Employee GetEntityByRowHandle(int rowHandle)
        {
            Domain.Employee entity = null;
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                entity = (Domain.Employee)gridViewEntities.GetRow(rowHandle);
            }
            return entity;
        }

        public Domain.Employee FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                Domain.Employee entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null)
                    OnEmployeeSelected(entity);
            }
        }
        public delegate void DlgEmployeeSelected(Domain.Employee empl);
        public event DlgEmployeeSelected EmployeeSelected = null;

        protected virtual void OnEmployeeSelected(Domain.Employee empl)
        {
            Entity = empl;
            if (empl != null && EmployeeSelected != null)
                EmployeeSelected(empl);
        }


        public override bool IsValid()
        {
            if (FocusedEntity != null) return true;
            else return false;
        }

        public override bool Commit()
        {
            if (FocusedEntity != null)
            {
                Modified = true;
                Entity = FocusedEntity;
                return base.Commit();
            }
            else return false;
        }
    }
}
