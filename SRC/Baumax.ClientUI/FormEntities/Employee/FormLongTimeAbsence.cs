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
    public partial class FormLongTimeAbsence : FormBaseEntity
    {
        public FormLongTimeAbsence()
        {
            InitializeComponent();
            EntityControl = ucLongTimeAbsence1;
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

                if (value != null)
                {
                    BaseEntity be = (value as BaseEntity);
                    if (be != null)
                    {
                        lblCaption.Text = (be.IsNew) ? GetLocalized("NewLongTimeAbsence") : GetLocalized("EditLongTimeAbsence");
                    }
                }
            }
        }
    }
}