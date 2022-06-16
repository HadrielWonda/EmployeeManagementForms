using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.Country.UIWorkingModel
{
    public partial class WModelList : UCBaseEntity
    {
        private BindingTemplate<Domain.WorkingModel> _listEntities = null;
        private bool isUserWriteRight = UCCountryEdit.isUserWriteRight();
        private long[] _idsUsedWorkingModels = null;

        public WModelList()
        {
            InitializeComponent();

            gridControl.MouseDoubleClick += new MouseEventHandler(gridControl_MouseDoubleClick);
            if (!isUserWriteRight) gridControl.ContextMenuStrip = null;
            bar2.Visible = isUserWriteRight;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                LocalizerControl.ComponentsLocalize(components);
            }
        }

        public void LoadUsedWorkingModels()
        {
            _idsUsedWorkingModels = null;
            if (Country != null)
                _idsUsedWorkingModels = ClientEnvironment.CountryService.GetInUseIDList(Baumax.Domain.InUseEntity.WorkingModel, Country.ID);

        }
        public bool IsUsedWorkingModel(long id)
        {
            if (_idsUsedWorkingModels == null || _idsUsedWorkingModels.Length == 0) return false;
             
            int index =  Array.FindIndex <long>(_idsUsedWorkingModels, 
                                                    delegate (long usedId) { return usedId == id;});

            return index != -1;
            
        }
        public Domain.Country Country
        {
            get { return (Domain.Country )Entity; }
            set { Entity = value; }
        }

        protected override void EntityChanged()
        {
            InitControl(null);
            UpdateBarButtonEnable();
        }
        private Domain.WorkingModel GetEntityByRowHandle(int rowHandle)
        {
            Domain.WorkingModel entity = null;
            if (gridView.IsDataRow(rowHandle))
            {
                entity = (Domain.WorkingModel)gridView.GetRow(rowHandle);
            }
            return entity;

        }

        public Domain.WorkingModel FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView.FocusedRowHandle);
            }
        }
        
        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            GridHitInfo info = gridView.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridView.IsDataRow(info.RowHandle))
            {
                Domain.WorkingModel entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) FireEditEntity(entity);
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitTollBar();
        }

        void InitTollBar()
        {
            bar2.ClearLinks();
            bar2.ItemLinks.Add(bi_NewWorkingModel);
            bar2.ItemLinks.Add(bi_EditWorkingModel);
            bar2.ItemLinks.Add(bi_DeleteWorkingModel);
        }
        
        void UpdateBarButtonEnable()
        {

            bi_EditWorkingModel.Enabled = FocusedEntity != null;
            bi_DeleteWorkingModel.Enabled = FocusedEntity != null && !IsUsedWorkingModel (FocusedEntity.ID);
        }

        public void InitControl(List<Domain.WorkingModel> lst)
        {
            if (lst != null)
                _listEntities = new BindingTemplate<Domain.WorkingModel>(lst);
            else 
                _listEntities = new BindingTemplate<Domain.WorkingModel>();

            if (Country != null)
            {
                List<Domain.WorkingModel> lll = ClientEnvironment.WorkingModelService.GetCountryWorkingModel(Country.ID, null,null);
                _listEntities.CopyList(lll);
            }

            if (_listEntities != null && _listEntities.Count > 0)
                LoadUsedWorkingModels();

            gridControl.DataSource = _listEntities;
        }

        public void FireEditEntity(Domain.WorkingModel c)
        {
            if (ReadOnly) return;
            Domain.WorkingModel entity = c;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                WorkingModelForm countryform = new WorkingModelForm(entity);
                if (countryform.ShowDialog() == DialogResult.OK)
                {
                    _listEntities.ResetItemById(entity.ID);
                }
            }
        }

        public void FireNewEntity()
        {
            if (ReadOnly) return;
            if (Country == null) return;

            Domain.WorkingModel entity = new Domain.WorkingModel();
            entity.CountryID = Country.ID;
            WorkingModelForm countryform = new WorkingModelForm(entity);
            if (countryform.ShowDialog() == DialogResult.OK)
            {
                _listEntities.Add((Domain.WorkingModel)countryform.Entity);
                UpdateBarButtonEnable();
            }

        }

        public void FireDeleteEntity(Domain.WorkingModel c)
        {
            if (ReadOnly) return;
            Domain.WorkingModel entity = c;

            if (entity == null) entity = FocusedEntity;

            if (entity != null)
            {
                if (IsUsedWorkingModel(entity.ID)) return;

                if (QuestionMessageYes(GetLocalized ("QuestionDeleteWorkingModel")))//"Are you sure to remove working model?"))
                {
                    try
                    {
                        ClientEnvironment.CountryService.WorkingModelService.DeleteByID(entity.ID);
                        _listEntities.Remove(entity);
                        UpdateBarButtonEnable();
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized ("CantDeleteWorkingModel"));
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                    }

                }
            }
        }
        public void FireRefreshEntities()
        {

        }
        private void toolStripMenuItem_NewWorkingModel_Click(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void toolStripMenuItem_EditWorkingModel_Click(object sender, EventArgs e)
        {
            FireEditEntity(null);
        }

        private void toolStripMenuItem_DeleteWorkingModel_Click(object sender, EventArgs e)
        {
            FireDeleteEntity(null);
        }

        private void toolStripMenuItem_RefreshWorkingModel_Click(object sender, EventArgs e)
        {
            FireRefreshEntities();
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuItem_DeleteWorkingModel.Enabled = FocusedEntity != null && !IsUsedWorkingModel(FocusedEntity.ID);
            toolStripMenuItem_EditWorkingModel.Enabled = FocusedEntity != null ;
        }

        private void bi_NewWorkingModel_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FireNewEntity();
        }

        private void bi_EditWorkingModel_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FireEditEntity(null);
        }

        private void bi_DeleteWorkingModel_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FireDeleteEntity(null);
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isUserWriteRight) return;
            switch(e.KeyCode)
            {
                case Keys.Insert: FireNewEntity(); 
                    break;
                case Keys.Delete: FireDeleteEntity(null);
                    break;
            }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateBarButtonEnable();
        }

        
    }
}

