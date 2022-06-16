using System;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldMinMax : UCBaseEntity
    {
        private StoreStructureContext context = null;
        private long m_storeWorldID = 0;
        private PersonMinMax m_focusedPerson;
        private bool isUserControlling = false;

        protected PersonMinMax FocusedPerson
        {
            get { return m_focusedPerson; }
            set 
            { 
                m_focusedPerson = value;

                if (context != null)
                    context.TakePersonMinMax.PersonMinMax = value;
            }
        }

        public UCWorldMinMax()
        {
            InitializeComponent();
            if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
            (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.Controlling))
            {
                isUserControlling = true;
                gridControl.ContextMenuStrip = null;
                layoutControlItem1.Visibility = 
                    lcRefresh.Visibility =
                    layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
             
            
              
                    //btnEdit.Enabled =
           //         btnDelete.Enabled = false;
            
        }

        protected override void  EntityChanged()
        {
 	        base.EntityChanged();
            if (Entity != null)
            {
                context = Entity as StoreStructureContext;
                edWorld.Properties.DataSource = context.TakeStoreWorld.GetStoreWorldList();
                edWorld.EditValue = context.StoreToWorldID;
            }
        }

        private void edWorld_EditValueChanged(object sender, EventArgs e)
        {
            m_storeWorldID = (long)edWorld.EditValue;
            gridControl.DataSource = context.TakePersonMinMax.GetListByWorld (m_storeWorldID);
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            btnAdd.ToolTip = Localizer.GetLocalized("AddPersonMinMax");
            btnEdit.ToolTip = Localizer.GetLocalized("EditPersonMinMax");
            btnDelete.ToolTip = Localizer.GetLocalized("DeletePersonMinMax");

            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(components);
        }

        private void cms_Opening(object sender, CancelEventArgs e)
        {
            
        }
        
        private void gridView_RowCountChanged(object sender, EventArgs e)
        {
            gridView_FocusedRowChanged(sender, null);
        }

        private PersonMinMax GetEntityByRowHandle(int rowhandle)
        {
            PersonMinMax entity = null;
            if (gridView.IsDataRow(rowhandle))
            {
                entity = gridView.GetRow(rowhandle) as PersonMinMax;
            }
            return entity;
        }
        public PersonMinMax FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView.FocusedRowHandle);
            }
        }

        private bool CanEditMinMaxPersons()
        {
            PersonMinMax entity = FocusedEntity;
            bool canEdit = true;

            if (entity == null) 
                canEdit = false;
            else
                if (entity.Year < DateTime.Today.Year) canEdit = false;
            return canEdit;

        }

        private bool CanDeleteMinMaxPersons()
        {
            PersonMinMax entity = FocusedEntity;
            bool canDelete = true;

            if (entity == null)
                canDelete = false;
            else
                if (entity.Year < DateTime.Today.Year) canDelete = false;

            return canDelete;

        }
        
        private void UpdateButtonState()
        {
                ts_DeletePersonMinMax.Enabled = btnDelete.Enabled = CanDeleteMinMaxPersons();
                ts_EditPersonMinMax.Enabled = btnEdit.Enabled = CanEditMinMaxPersons();
        }
        
        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            UpdateButtonState();
            FocusedPerson = FocusedEntity;
        }

        private void ts_AddNew_Click(object sender, EventArgs e)
        {
            using (FormWorldMinMaxEdit form = new FormWorldMinMaxEdit())
            {
                context.TakePersonMinMax.CreateNewPerson ((long)edWorld.EditValue);
                form.Entity = context;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    context.TakePersonMinMax.AddPerson();
                    if (gridControl.DataSource != null)
                    {
                        BindingList<PersonMinMax> lst = (BindingList<PersonMinMax>)gridControl.DataSource;
                        lst.Add(context.TakePersonMinMax.PersonMinMax);
                        context.TakePersonMinMax.PersonMinMax = FocusedEntity;
                    }
                    UpdateButtonState();
                }
                else
                {
                    context.TakePersonMinMax.PersonMinMax = FocusedEntity;
                }
            }
            
        }
        private void ts_Edit_Click(object sender, EventArgs e)
        {
            if (CanEditMinMaxPersons())
            {
                using (FormWorldMinMaxEdit form = new FormWorldMinMaxEdit())
                {
                    form.Entity = context;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (gridControl.DataSource != null)
                        {
                            BindingList<PersonMinMax> lst = (BindingList<PersonMinMax>)gridControl.DataSource;
                            lst.ResetBindings();
                            UpdateButtonState();
                        }
                    }
                    
                }
            }
        }

        private void ts_Delete_Click(object sender, EventArgs e)
        {
            if (CanDeleteMinMaxPersons ())
            {
                if (FocusedPerson.Year >= DateTime.Today.Year)
                    try
                    {
                        ClientEnvironment.PersonMinMaxService.Delete(FocusedPerson);
                        context.TakePersonMinMax.RemovePerson(FocusedPerson);
                        if (gridControl.DataSource != null)
                        {
                            BindingList<PersonMinMax> lst = (BindingList<PersonMinMax>)gridControl.DataSource;
                            lst.Remove(FocusedPerson);
                            context.TakePersonMinMax.PersonMinMax = FocusedEntity;
                            UpdateButtonState();
                        }

                        //edWorld_EditValueChanged(this, null);
                        //RefreshData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                        throw;
                    }
                else
                    XtraMessageBox.Show(Localizer.GetLocalized("NotDeletePast"),string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isUserControlling)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (FocusedPerson == null)
                            return;
                        ts_Edit_Click(this, null);
                        break;
                    case Keys.Insert:
                        ts_AddNew_Click(this, null);
                        break;
                    case Keys.Delete:
                        if (FocusedPerson == null)
                            return;
                        ts_Delete_Click(this, null);
                        break;
                }    
            }
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CanEditMinMaxPersons() && !isUserControlling)
                ts_Edit_Click(this, null);
        }
    }
}