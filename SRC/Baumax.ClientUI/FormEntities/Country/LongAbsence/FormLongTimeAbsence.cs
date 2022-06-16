using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using DevExpress.XtraEditors;
using Baumax.Domain;
namespace Baumax.ClientUI.FormEntities
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

        protected override bool SaveEntity()
        {
            try
            {
                return base.SaveEntity();
            }
            catch (ValidationException)
            {
                string str = GetLocalized("ErrorUniqueAbsenceNameOrAbb");
                if (String.IsNullOrEmpty(str)) str = "Absence name or abbreviation not unique";
                ErrorMessage(str);
                return false;
            }
            catch (EntityException ex)
            {
                ProcessEntityException(ex);
                return false;
            }
        }
    }
}