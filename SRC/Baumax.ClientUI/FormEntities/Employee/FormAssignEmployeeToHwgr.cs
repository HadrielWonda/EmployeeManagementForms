using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.Domain;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormAssignEmployeeToHwgr :  FormBaseEntity 
    {
        public FormAssignEmployeeToHwgr()
        {
            InitializeComponent();
            EntityControl = ucAssignEmployeeToHWGR;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();

            if (!DesignMode)
            {
                this.Text = GetLocalized("AssignEmployeeToHWGR");
            }
        }
    }
}