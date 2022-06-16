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
    public partial class FormEmployeeLongTimeAbsence : FormBaseEntity 
    {
        public FormEmployeeLongTimeAbsence()
        {
            InitializeComponent();
            EntityControl = ucEmployeeLongTimeHolidays1;
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

                if (Entity != null)
                {
                    EmployeeContext context = (EmployeeContext)Entity;

                    if (context.EmployeeAbsence.IsNew)
                        lblCaption.Text = GetLocalized("NewEmplLongTimeAbsence");
                    else
                        lblCaption.Text = GetLocalized("EditEmplLongTimeAbsence");
                }
            }
        }
    }
}