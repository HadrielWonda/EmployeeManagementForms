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
    public partial class FormExternalEmployee : FormBaseEntity 
    {
        public FormExternalEmployee()
        {
            InitializeComponent();
            EntityControl = ucExternalEmployee1;
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
                    Domain.BaseEntity be = (Domain.BaseEntity )Entity;
                    string val = (be.IsNew) ? GetLocalized("NewExternalEmployee") : GetLocalized("EditExternalEmployee");
                    if (!String.IsNullOrEmpty(val))
                        lblCaption.Text = val;
                }
            }
        }

        public DateTime FilterDate
        {
            get 
            {
                if (EntityControl != null)
                {
                    return (EntityControl as UCExternalEmployee).FilterDate;
                }
                return DateTime.Today ; 
            }
            set 
            {
                if (EntityControl != null)
                {
                    (EntityControl as UCExternalEmployee).FilterDate = value;
                }
            }
        }

    }
}