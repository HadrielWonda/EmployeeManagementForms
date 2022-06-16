using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities
{
    public partial class FormLongTimeAbsenceEmployees : FormBaseEntity 
    {
        public FormLongTimeAbsenceEmployees()
        {
            InitializeComponent();

            EntityControl = ucLongTimeAbsenceEmployees1;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();

            if (ClientEnvironment.IsRuntimeMode)
            {
                button_Cancel.Text = GetLocalized("Close");
            }
        }
    }
}