using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class UCBenchmarksView : UCBaseEntity 
    {

        StoreWorldController _StoreWorldList = null;
        BindingTemplate<Benchmark> _listBenchmarks = new BindingTemplate<Benchmark>();

        public UCBenchmarksView()
        {
            InitializeComponent();
             StartYear = EndYear = (short)DateTime.Today.Year;
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(components);
                
            }
        }
        public Store EntityStore
        {
            get { return (Store)Entity;}
            set 
            { 
                Entity = value; 
            }
        }

        public StoreWorldController SWController
        {
            get
            {
                return _StoreWorldList;
            }
            set
            {
                _StoreWorldList = value;
            }
        }

        public BindingTemplate<Benchmark> BenchmarksList
        {
            get
            {
                return _listBenchmarks;
            }
        }

        public short StartYear
        {
            get { return Convert.ToInt16(barEditItemStartYear.EditValue); }
            set { barEditItemStartYear.EditValue = value; }
        }
        public short EndYear
        {
            get
            {
                if (barEditItemEndYear.EditValue == null) 
                    return (short)DateTimeSql.SmallDatetimeMax.Year ;
                return Convert.ToInt16(barEditItemEndYear.EditValue);
            }
            set
            {
                if (value == -1) barEditItemEndYear.EditValue = null;
                else barEditItemEndYear.EditValue = value;
            }
        }
        public Benchmark FocusedEntity
        {
            get
            {
                return EntityFromRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }

        private Benchmark EntityFromRowHandle(int rowHandle)
        {
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                return (Benchmark)gridViewEntities.GetRow(rowHandle);
            }
            return null;
        }

        public bool IsExistsGroup
        {
            get
            {
                return gridViewEntities.GroupedColumns.Count > 0;
            }
        }



        private void EditEntity()
        {
            Benchmark bh = FocusedEntity;

            if (bh == null || SWController == null || EntityStore == null) return;

            if (CanEditEntity())
            {
                using (FormBenchmark formEdit = new FormBenchmark())
                {

                    List<StoreToWorld> lst = SWController.GetListByStoreId(EntityStore.ID);

                    formEdit.SetStoreWorlds(lst);
                    formEdit.EntityStore = EntityStore;

                    formEdit.SetReadOnly();
                    formEdit.EntityBenchmark = bh;

                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        BenchmarksList.ResetItemById(bh.ID);
                    }
                }
            }
        }
        private void NewEntity()
        {
            if (SWController == null || EntityStore == null) return;

            using (FormBenchmark formEdit = new FormBenchmark())
            {

                List<StoreToWorld> lst = SWController.GetListByStoreId(EntityStore.ID);

                formEdit.SetStoreWorlds(lst);
                formEdit.EntityStore = EntityStore;
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    short y = formEdit.EntityBenchmark.Year;
                    if (y >= StartYear && y <= EndYear)
                        BenchmarksList.Add(formEdit.EntityBenchmark);
                }
            }
        }

        private void DeleteEntity()
        {
            if (FocusedEntity != null)
            {
                if (QuestionMessageYes (GetLocalized ("QuestionDeleteBenchmark")))
                {
                    try
                    {
                        ClientEnvironment.BenchmarkService.DeleteByID(FocusedEntity.ID);
                        BenchmarksList.Remove(FocusedEntity);
                    }
                    catch(EntityException ex)
                    {
                        ProcessEntityException(ex);
                    }

                }
            }
        }

        private void LoadEntities()
        {

            gridControlEntities.BeginUpdate();
            try
            {

                BenchmarksList.Clear();
                if (EntityStore != null)
                {
                    List<Benchmark > cols = ClientEnvironment.StoreService.BenchmarkService.GetBenchmarkFiltered(EntityStore.ID, StartYear, EndYear);
                    if (SWController != null)
                    {
                        SWController.FillBechmarks(cols);
                    }
                    BenchmarksList.CopyList(cols);

                    
                }
                if (gridControlEntities.DataSource == null)
                    gridControlEntities.DataSource = BenchmarksList;

                UpdateButtonState();

            }
            finally
            {
                gridControlEntities.EndUpdate();
            }
        }

        private bool ValidateFilter()
        {
            if (StartYear > EndYear)
            {
                ErrorMessage(GetLocalized("InvalidTimeRange"));
                return false;
            }
            return true;
        }


        protected override void EntityChanged()
        {
            base.EntityChanged();


            LoadEntities();
        }

        private bool CanEditEntity()
        {
           if (FocusedEntity == null || !isUserWriteRight()) return false;

           if (FocusedEntity.Year >= DateTime.Today.Year) return true;
           else return false;
        }
        private bool CanDeleteEntity()
        {
            if (FocusedEntity == null || !isUserWriteRight()) return false;

            if (FocusedEntity.Year >= DateTime.Today.Year) return true;
            else return false;
        }

        private bool isUserWriteRight()
        {
            IAuthorizationService auth = ClientEnvironment.AuthorizationService;
            AccessType region = auth.GetAccess(ClientEnvironment.RegionService);
            if ((region & AccessType.Write) != 0)
                return true;
            else
                return false;
        }
        
        private void UpdateButtonState()
        {
            if (!isUserWriteRight())
            {
                bi_EditBenchmark.Visibility =
                    bi_NewBenchmark.Visibility = bi_DeleteBenchmark.Visibility = BarItemVisibility.Never;
                gridControlEntities.ContextMenuStrip = null;
            }
            bi_EditBenchmark.Enabled = mi_EditBenchmark.Enabled = CanEditEntity();
            bi_DeleteBenchmark.Enabled = mi_DeleteBenchmark.Enabled = CanDeleteEntity();
        }
        #region toolbar events

        private void bi_ApplyFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateFilter())
                LoadEntities();
        }

        private void bi_NewBenchmark_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewEntity();
        }
        private void bi_EditBenchmark_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditEntity();
        }

        private void seEndYear_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                EndYear = -1;
                if (ValidateFilter())
                    LoadEntities();
            }
        }

        private void seEndYear_ValueChanged(object sender, EventArgs e)
        {
            if (EndYear < StartYear)
                EndYear = StartYear;
        }

        #endregion


        #region GridControl event

        private void gridViewEntities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && CanDeleteEntity() && FocusedEntity != null)
            {
                DeleteEntity();
            }
            else if (e.KeyCode == Keys.Insert && isUserWriteRight())
            {
                NewEntity();
            }
        }
        private void gridControlEntities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!CanEditEntity()) return;
            
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                Benchmark  entity = EntityFromRowHandle(info.RowHandle);
                if (entity != null) EditEntity();
            }
        }
        #endregion

        #region PopupMenu events

        private void mi_NewBenchmark_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void mi_EditBenchmark_Click(object sender, EventArgs e)
        {
            EditEntity();
        }

        private void mi_ExpandedAll_Click(object sender, EventArgs e)
        {
            gridViewEntities.ExpandAllGroups();
        }

        private void mi_CollapseAll_Click(object sender, EventArgs e)
        {
            gridViewEntities.CollapseAllGroups();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            mi_CollapseAll.Enabled = IsExistsGroup;
            mi_ExpandedAll.Enabled = IsExistsGroup;
        }
           

        #endregion

        private void gridViewEntities_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void gridViewEntities_RowCountChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void bi_DeleteBenchmark_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteEntity();
        }

        private void mi_DeleteBenchmark_Click(object sender, EventArgs e)
        {
            DeleteEntity();
        }
    }
}
