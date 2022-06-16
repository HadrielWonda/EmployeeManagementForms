using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormAssignEmployeeToWorld : FormBaseEntity 
    {
        public FormAssignEmployeeToWorld()
        {
            InitializeComponent();
            EntityControl = ucAssignEmployeeToWorld1;
        }

        public void SetWorldList(List<StoreToWorld> lst)
        {
            ucAssignEmployeeToWorld1.SetStoreWorldList(lst);
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


                string str = GetLocalized("NewAssignEmplToWorld");

                if (Entity is BaseEntity)
                {
                    if (!(Entity as BaseEntity).IsNew)
                        str = GetLocalized("EditAssignEmplToWorld");
                }

                if (!String.IsNullOrEmpty(str))
                    lblCaption.Text = str;
            }
        }
    }
}