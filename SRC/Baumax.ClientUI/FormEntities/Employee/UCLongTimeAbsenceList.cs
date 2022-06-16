using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Templates ;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class UCLongTimeAbsenceList : UCBaseEntity 
    {
        BindingTemplate<LongTimeAbsence> m_absenceList = new BindingTemplate<LongTimeAbsence>();
        public UCLongTimeAbsenceList()
        {
            InitializeComponent();
        }

        LongTimeAbsence GetEntityByRowHandle(int rowHandle)
        {
            LongTimeAbsence absence = null;
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                absence = (LongTimeAbsence)gridViewEntities.GetRow(rowHandle);
            }
            return absence;
        }

        public LongTimeAbsence FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }
        private void bi_NewLongTimeAbsence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add();
        }

        private void bi_EditLongTimeAbsence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit();
        }

        private void bi_DeleteLongTimeAbsence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);
            }

        }
        private void UpdateButtonState()
        {
            LongTimeAbsence absence = FocusedEntity;

            bi_EditLongTimeAbsence.Enabled = absence != null;
            bi_DeleteLongTimeAbsence.Enabled = absence != null;
        }
        public override bool IsValid()
        {
            // hide button_ok event
            return false;
        }
        public override void Add()
        {
            using (FormLongTimeAbsence newAbsenceForm = new FormLongTimeAbsence())
            {
                LongTimeAbsence newAbsence = new LongTimeAbsence();
                newAbsenceForm.Entity = newAbsence;

                if (newAbsenceForm.ShowDialog() == DialogResult.OK)
                {
                    m_absenceList.Add(newAbsence);
                }
                UpdateButtonState();
            }
        }

        public override void Edit()
        {
            LongTimeAbsence absence = FocusedEntity;
            if (absence != null)
            {
                using (FormLongTimeAbsence newAbsenceForm = new FormLongTimeAbsence())
                {
                    newAbsenceForm.Entity = absence;

                    if (newAbsenceForm.ShowDialog() == DialogResult.OK)
                    {
                        m_absenceList.SetEntity(absence);
                    }
                }
                UpdateButtonState();
            }
        }

        public override void Delete()
        {
            LongTimeAbsence absence = FocusedEntity;
            if (absence != null)
            {
                if (QuestionMessageYes (GetLocalized ("QuestionDeleteLongTimeAbsence")))
                {
                    try
                    {
                        ClientEnvironment.LongTimeAbsenceService.DeleteByID(absence.ID);
                        m_absenceList.RemoveEntityById(absence.ID);
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("CantDeleteLongTimeAbsence"));
                        return;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return;
                    }
                }
                UpdateButtonState();
            }
        }

        public void InitLongTimeAbsence()
        {
            LoadLongTimeAbsence();
        }
        private void LoadLongTimeAbsence()
        {
            List<LongTimeAbsence> lst = 
                ClientEnvironment.LongTimeAbsenceService.FindAll();

            m_absenceList.CopyList(lst);

            if (gridControl.DataSource == null)
                gridControl.DataSource = m_absenceList;
            UpdateButtonState();
        }

        private void gridViewEntities_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                LongTimeAbsence entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) Edit();
            }
        }

        private void gridViewEntities_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert: Add(); break;
                case Keys.Delete: Delete(); break;
                case Keys.Enter: Edit(); break;
            }
        }

    }
}
