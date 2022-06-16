using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormAssignToEmployee : FormBaseEntity 
    {
        public FormAssignToEmployee()
        {
            InitializeComponent();
            EntityControl = ucAssignToEmployee1;
        }

        public override object Entity
        {
            get
            {
                return base.Entity;
            }
            set
            {
                base.Entity = value;

                string str = GetLocalized("AssignExternalEmployee");
                if (!String.IsNullOrEmpty(str))
                    lblCaption.Text = str;
            }
        }

        private void btn_Assign_Click(object sender, EventArgs e)
        {
            if (ucAssignToEmployee1.FocusedEntity != null)
            {
                if (ucAssignToEmployee1.FireAssignEmployee(ucAssignToEmployee1.FocusedEntity))
                    DialogResult = DialogResult.OK;

            }
        }
    }
}