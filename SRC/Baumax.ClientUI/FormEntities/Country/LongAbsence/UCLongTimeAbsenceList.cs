using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities.Country;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities
{
    public partial class UCLongTimeAbsenceList : UCBaseEntity 
    {
        BindingTemplate<LongTimeAbsence> m_absenceList = new BindingTemplate<LongTimeAbsence>();
        bool isUserWriteRight = UCCountryEdit.isUserWriteRight();

        public UCLongTimeAbsenceList()
        {
            InitializeComponent();
            bar1.Visible = isUserWriteRight;
            if (!isUserWriteRight) gridControl.ContextMenuStrip = null;
        }

        #region Grid service methods

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

        #endregion

        private void bi_NewLongTimeAbsence_ItemClick(object sender, ItemClickEventArgs e)
        {
            Add();
        }

        private void bi_EditLongTimeAbsence_ItemClick(object sender, ItemClickEventArgs e)
        {
            Edit();
        }

        private void bi_DeleteLongTimeAbsence_ItemClick(object sender, ItemClickEventArgs e)
        {
            Delete();
        }

        public Domain.Country EntityCountry
        {
            get
            {
                return (Domain.Country)Entity;
            }
        }

        protected override void EntityChanged()
        {
            if (EntityCountry != null)
            {
                LoadLongTimeAbsence();
            }
            base.EntityChanged();
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(components);
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
                newAbsence.CountryID = EntityCountry.ID;
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
                    Debug.Assert(absence.CountryID == EntityCountry.ID);
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
            m_absenceList.Clear();

            if (EntityCountry != null)
            {
                List<LongTimeAbsence> lst =
                    ClientEnvironment.LongTimeAbsenceService.FindAllByCountry(EntityCountry.ID);

                m_absenceList.CopyList(lst);
                    
                if (gridControl.DataSource == null)
                    gridControl.DataSource = m_absenceList;
            }
            UpdateButtonState();
        }

        private void gridViewEntities_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                LongTimeAbsence entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) Edit();
            }
        }

        private void gridViewEntities_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isUserWriteRight) return;
            switch (e.KeyCode)
            {
                case Keys.Insert: Add(); break;
                case Keys.Delete: Delete(); break;
                case Keys.Enter: Edit(); break;
            }
        }

        private void mi_NewLongtimeAbsence_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void mi_EditLongtimeAbsence_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void mi_DeleteLongtimeAbsence_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            LongTimeAbsence absence = FocusedEntity;
            mi_EditLongtimeAbsence.Enabled = absence != null; ;
            mi_DeleteLongtimeAbsence.Enabled = absence != null; ;
        }

    }
}
