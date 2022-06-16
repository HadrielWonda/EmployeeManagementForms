using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using System.Diagnostics;
using Baumax.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class UCLongTimeAbsence : UCBaseEntity 
    {
        public UCLongTimeAbsence()
        {
            InitializeComponent();
        }

        internal string AbsenceName
        {
            get
            {
                return teAbsenceName.Text.Trim();
            }
            set
            {
                teAbsenceName.Text = value;
            }
        }

        public Domain.LongTimeAbsence EntityAbsence
        {
            get
            {
                return (Domain.LongTimeAbsence)Entity;
            }
        }

        protected override void EntityChanged()
        {
            base.EntityChanged();
            if (EntityAbsence != null)
            {
                AbsenceName = EntityAbsence.CodeName;
            }
            
        }
        public override bool IsValid()
        {
            if (String.IsNullOrEmpty(AbsenceName))
            {
                teAbsenceName.ErrorText = GetLocalized("InvalidValue");
                return false;
            }
            else teAbsenceName.ErrorText = String.Empty;

            return base.IsValid();
        }

        private void CopyAbsence(LongTimeAbsence source, LongTimeAbsence dest)
        {
            Debug.Assert(source != null);
            Debug.Assert(dest != null);
            Debug.Assert(!source.Equals(dest));

            dest.ID = source.ID;
            dest.Code = source.Code;
            dest.CodeName = source.CodeName;
            dest.Import = source.Import;
        }

        public bool IsModified()
        {
            if (EntityAbsence == null)
                return false;
            else
                return (AbsenceName != EntityAbsence.CodeName);
        }

        public override bool Commit()
        {
            if (IsModified() && IsValid())
            {

                LongTimeAbsence copyAbsence = new LongTimeAbsence();

                CopyAbsence(EntityAbsence, copyAbsence);

                copyAbsence.CodeName = AbsenceName;

//                if (copyAbsence.IsNew)
//                    copyAbsence = ClientEnvironment.LongTimeAbsenceService.Save(copyAbsence);
//                else
                try
                {
                    copyAbsence = ClientEnvironment.LongTimeAbsenceService.SaveOrUpdate(copyAbsence);

                    CopyAbsence(copyAbsence, EntityAbsence);
                    Modified = true;
                    return base.Commit();
                }
                catch (DBDuplicateKeyException)
                {
                    ErrorMessage(GetLocalized("LongTimeAbsenceNameExists"));
                    teAbsenceName.Focus();
                    return false;
                }
            }
            else return false;
        }
    }
}
