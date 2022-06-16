using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain ;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormSelectEmployee : FormBaseEntity
    {
        public FormSelectEmployee()
        {
            InitializeComponent();
            EntityControl = ucEmployeeSelectGrid1 ;
        }

        private void ucEmployeeSelectGrid1_EmployeeSelected(Baumax.Domain.Employee empl)
        {
            if (empl != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        public void InitGrid(List<Domain.Employee> empls)
        {
            ucEmployeeSelectGrid1.AssignEmployeeList(empls);
        }
    }
}