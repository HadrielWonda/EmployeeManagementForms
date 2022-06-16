using System;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.Admin
{
    public partial class EmployeeListCtrl : UCBaseEntity
    {
        public EmployeeListCtrl()
        {
            InitializeComponent();
        }

        public EmployeeListCtrl(Form frm)
            : base(frm)
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
               ctrlEmployeeGrid.EmployeeList = ClientEnvironment.EmployeeService.FindAll();
            }
        }

        private void nbNew_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ctrlEmployeeGrid.Add();
        }

        private void nbEdit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ctrlEmployeeGrid.Edit();
        }

        private void nbDelete_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ctrlEmployeeGrid.Delete();
        }
    }
}
