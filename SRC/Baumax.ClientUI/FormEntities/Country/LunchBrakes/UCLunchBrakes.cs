using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities.Country.LunchBrakes;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCLunchBrakes : UCBaseEntity
    {
        private BindingTemplate<WorkingModel> _listEntities = null;
        private bool isUserWriteRight = UCCountryEdit.isUserWriteRight();
        private long[] _idsUsedWorkingModels = null;
        private bool deleteEnable = false;
        
        public UCLunchBrakes()
        {
            InitializeComponent();

            gridControlLunch.MouseDoubleClick += new MouseEventHandler(gridControl_MouseDoubleClick);
            if (!isUserWriteRight) gridControlLunch.ContextMenuStrip = null;
                 bartools.Visible = isUserWriteRight;
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
                 _idsUsedWorkingModels = ClientEnvironment.CountryService.GetInUseIDList(InUseEntity.WorkingModel, Country.ID);

         }
         
         /*
          * public bool IsUsedWorkingModel(long id)
         {
             if (_idsUsedWorkingModels == null || _idsUsedWorkingModels.Length == 0) return false;
             
             int index =  Array.FindIndex <long>(_idsUsedWorkingModels, 
                                                     delegate (long usedId) { return usedId == id;});

             return index != -1;
            
         }
          * */
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
        private WorkingModel GetEntityByRowHandle(int rowHandle)
         {
             WorkingModel entity = null;
             if (gridViewLunch.IsDataRow(rowHandle))
             {
                 entity = (WorkingModel)gridViewLunch.GetRow(rowHandle);
             }
             return entity;

         }

        public WorkingModel FocusedEntity
         {
             get
             {
                 return GetEntityByRowHandle(gridViewLunch.FocusedRowHandle);
             }
         }
        
         private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
         {
             if (!isUserWriteRight) return;
             GridHitInfo info = gridViewLunch.CalcHitInfo(e.X, e.Y);

             if (info.InRowCell && gridViewLunch.IsDataRow(info.RowHandle))
             {
                 WorkingModel entity = GetEntityByRowHandle(info.RowHandle);
                 if (entity != null) FireEditEntity(entity);
             }

         }

         protected override void OnLoad(EventArgs e)
         {
             base.OnLoad(e);
             InitTollBar();
             //hide delete button
         }

         void InitTollBar()
         {
             bartools.ClearLinks();
             bartools.ItemLinks.Add(bi_NewLunch);
             bartools.ItemLinks.Add(bi_editLunch);
             bartools.ItemLinks.Add(bi_deleteLunch);
         }
        
         void UpdateBarButtonEnable()
         {
             bi_editLunch.Enabled = FocusedEntity != null;
             bi_deleteLunch.Enabled = FocusedEntity != null  && deleteEnable;//&& !IsUsedWorkingModel(FocusedEntity.ID)
         }

        public void InitControl(List<WorkingModel> lst)
         {
             if (lst != null)
                 _listEntities = new BindingTemplate<WorkingModel>(lst);
             else
                 _listEntities = new BindingTemplate<WorkingModel>();

             if (Country != null)
             {
                 //GetCountryLunchModel
                 List<WorkingModel> lll = ClientEnvironment.WorkingModelService.GetCountryLunchModel(Country.ID, null, null); 
                 _listEntities.CopyList(lll);
             }

             if (_listEntities != null && _listEntities.Count > 0)
                 LoadUsedWorkingModels();

             gridControlLunch.DataSource = _listEntities;
         }

        public void FireEditEntity(WorkingModel c)
         {
             if (ReadOnly) return;
             WorkingModel entity = c;
             if (entity == null) entity = FocusedEntity;
             if (entity != null)
             {
                 FormLunchModel countryform = new FormLunchModel(entity);
                 countryform.Text = GetLocalized("editLunch");
                 countryform.isNew = false;
                 if (FocusedEntity != null && gridViewLunch.RowCount > 1)
                 {
                     countryform.setReadOnlyTypeLunch(FocusedEntity.IsDurationTime);
                 }
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

             WorkingModel entity = new WorkingModel();
             entity.CountryID = Country.ID;
             entity.WorkingModelType = WorkingModelType.LunchModel; 
             FormLunchModel countryform = new FormLunchModel(entity);
             countryform.Text = GetLocalized("NewLunch");
             countryform.isNew = true;
             if (FocusedEntity != null)
             {
                 countryform.setReadOnlyTypeLunch(FocusedEntity.IsDurationTime);
             }
             if (countryform.ShowDialog() == DialogResult.OK)
             {
                 _listEntities.Add((WorkingModel)countryform.Entity);
                 UpdateBarButtonEnable();
             }

         }

        public void FireDeleteEntity(WorkingModel c)
         {
             if (ReadOnly) return;
             WorkingModel entity = c;

             if (entity == null) entity = FocusedEntity;

             if (entity != null)
             {
                 //if (IsUsedWorkingModel(entity.ID)) return;

                 if (QuestionMessageYes(GetLocalized("QuestionDeleteLunchModel")))
                 {
                     try
                     {
                         ClientEnvironment.CountryService.WorkingModelService.DeleteByID(entity.ID);
                         _listEntities.Remove(entity);
                         UpdateBarButtonEnable();
                     }
                     catch (ValidationException)
                     {
                         ErrorMessage(GetLocalized("CantDeleteLunchModel"));
                     }
                     catch (EntityException ex)
                     {
                         ProcessEntityException(ex);
                     }

                 }
             }
         }
        
        private void gridView_KeyDown(object sender, KeyEventArgs e)
         {
             if (!isUserWriteRight) return;
             switch(e.KeyCode)
             {
                 case Keys.Insert: FireNewEntity(); 
                     break;
                 case Keys.Delete:
                     {
                         if (deleteEnable)
                            FireDeleteEntity(null);
                         break;   
                     }
             }
         }

         private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
         {
             if (FocusedEntity != null)
             {
                 if (FocusedEntity.BeginTime >= DateTime.Today)
                     deleteEnable = true;
                 else
                     deleteEnable = false;    
             }
             UpdateBarButtonEnable();
         }

        private void bi_NewLunch_ItemClick(object sender, ItemClickEventArgs e)
        {
            FireNewEntity();
        }

        private void bi_editLunch_ItemClick(object sender, ItemClickEventArgs e)
        {
            FireEditEntity(FocusedEntity);
        }

        private void bi_deletetLunch_ItemClick(object sender, ItemClickEventArgs e)
        {
            FireDeleteEntity(FocusedEntity);
        }

        private void newToolStripMenuItem_NewLunch_Click(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void toolStripMenuItem_editLunch_Click(object sender, EventArgs e)
        {
            FireEditEntity(null);
        }

        private void ToolStripMenuItem_deleteLunch_Click(object sender, EventArgs e)
        {
            FireDeleteEntity(null);
        }
        
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
           ToolStripMenuItem_deleteLunch.Enabled = FocusedEntity != null && deleteEnable;//&& !IsUsedWorkingModel(FocusedEntity.ID)
           toolStripMenuItem_editLunch.Enabled = FocusedEntity != null ;
        }

        private void gridViewLunch_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == gc_typeLunchModel)
            {
                if (e.IsGetData)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < _listEntities.Count)
                    {
                        WorkingModel wm = _listEntities[e.ListSourceRowIndex];
                        if (wm.IsDurationTime)
                            e.Value = GetLocalized("DurationTime");
                        else
                            e.Value = GetLocalized("DurationWorkingDay");
                    }
                }
            }
        }
        

    }
}
