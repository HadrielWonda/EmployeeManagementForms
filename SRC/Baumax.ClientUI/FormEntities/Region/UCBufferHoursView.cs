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
    public partial class UCBufferHoursView : UCBaseEntity
    {
        StoreWorldController _StoreWorldList = null;//new StoreWorldController();
        BindingTemplate<BufferHours> _listBufferHours = new BindingTemplate<BufferHours>();

        public UCBufferHoursView()
        {
            InitializeComponent();
            StartYear = EndYear = (short)DateTime.Today.Year;
            mi_DeleteBufferHours.Visible = false;
            bi_DeleteBufferHours.Visibility = BarItemVisibility.Never;
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

        public BindingTemplate<BufferHours> BufferHoursList
        {
            get
            {
                return _listBufferHours;
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
                if (barEditItemEndYear.EditValue == null) return 2079;
                return Convert.ToInt16(barEditItemEndYear.EditValue);
            }
            set
            {
                if (value == -1) barEditItemEndYear.EditValue = null;
                else barEditItemEndYear.EditValue = value;
            }
        }
        public BufferHours FocusedEntity
        {
            get
            {
                return EntityFromRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }

        private BufferHours EntityFromRowHandle(int rowHandle)
        {
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                return (BufferHours)gridViewEntities.GetRow(rowHandle);
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
            BufferHours bh = FocusedEntity;

            if (bh == null || SWController == null || EntityStore == null) return;
            if (CanEditEntity())
            {
                FormSelectYear selectYear = new FormSelectYear();

                List<StoreToWorld> lst = SWController.GetListByStoreId(EntityStore.ID);

                selectYear.SetStoreWorlds(lst);
                selectYear.EntityStore = EntityStore;

                selectYear.SetReadOnly();
                selectYear.Entity = bh;

                if (selectYear.ShowDialog() == DialogResult.OK)
                {
                    BufferHoursList.ResetItemById(bh.ID);
                }
            }
        }

        private void DeleteEntity()
        {
            BufferHours bh = FocusedEntity;

            if (bh == null || SWController == null || EntityStore == null || !CanDeleteEntity()) return;
            
            if (QuestionMessageYes(GetLocalized("QuestionDeleteBufferHours"))) 
            {
                try
                {
                    ClientEnvironment.StoreService.BufferHoursService.DeleteByID(bh.ID);
                    BufferHoursList.RemoveEntityById(bh.ID);
                    UpdateButtonState();
                }
                catch (EntityException)
                {
                    ErrorMessage(GetLocalized("CantDeleteTrendCorrection"), GetLocalized("Attention"));
                    return;
                }
            }
        }
        
        private void NewEntity()
        {
            if (SWController == null || EntityStore == null) return;

            FormSelectYear selectYear = new FormSelectYear();

            List<StoreToWorld> lst = SWController.GetListByStoreId(EntityStore.ID);

            selectYear.SetStoreWorlds(lst);
            selectYear.EntityStore = EntityStore;
            if (selectYear.ShowDialog() == DialogResult.OK)
            {
                short y = selectYear.Entity.Year;
                if (y >= StartYear && y <= EndYear)
                    BufferHoursList.Add(selectYear.Entity);
            }
        }

        private void LoadEntities()
        {
            gridControlEntities.BeginUpdate();
            try
            {

                BufferHoursList.Clear();
                if (EntityStore != null)
                {
                    List<BufferHours> cols = ClientEnvironment.StoreService.BufferHoursService.GetBufferHoursFiltered(EntityStore.ID, StartYear, EndYear);
                    if (SWController != null)
                    {
                        SWController.FillBufferHours(cols);
                    }

                    BufferHoursList.CopyList(cols);

                }
                if (gridControlEntities.DataSource == null)
                    gridControlEntities.DataSource = BufferHoursList;

            }
            finally
            {
                gridControlEntities.EndUpdate();
            }
            UpdateButtonState();
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
            bi_EditBufferHours.Enabled = mi_EditBufferHours.Enabled = CanEditEntity();
            bi_DeleteBufferHours.Enabled = mi_DeleteBufferHours.Enabled = CanDeleteEntity();
            if (!isUserWriteRight())
            {
                bi_NewBufferHours.Enabled = mi_NewBufferHours.Enabled = false;
                bi_NewBufferHours.Visibility =
                    bi_EditBufferHours.Visibility = bi_DeleteBufferHours.Visibility = BarItemVisibility.Never;
                gridControlEntities.ContextMenuStrip = null;
            }
        }
        
        #region PopupMenu events

        private void mi_NewBufferHour_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void mi_EditBufferHour_Click(object sender, EventArgs e)
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
            mi_EditBufferHours.Enabled = CanEditEntity(); 
        }

        #endregion

        #region toolbar events

        private void bi_ApplyFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateFilter ())
                LoadEntities();
        }

        private void bi_NewBufferHours_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewEntity();
        }

        private void bi_EditBufferHours_ItemClick(object sender, ItemClickEventArgs e)
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



        #region GridControl events

        private void gridViewBufferHours_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Delete)
            {
                DeleteEntity();
            }
            else
              */  
                if (e.KeyCode == Keys.Insert && isUserWriteRight())
            {
                NewEntity();
            }
        }

        private void gridControlEntities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                BufferHours entity = EntityFromRowHandle(info.RowHandle);
                if (entity != null) EditEntity();
            }
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

        private void bi_DeleteBufferHours_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteEntity();
        }

        private void mi_DeleteBufferHour_Click(object sender, EventArgs e)
        {
            DeleteEntity();
        }
    }
}
