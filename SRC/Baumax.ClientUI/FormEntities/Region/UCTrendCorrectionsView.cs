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
    public partial class UCTrendCorrectionsView : UCBaseEntity 
    {
        StoreWorldController _StoreWorldList = null;//new StoreWorldController();
        BindingTemplate<TrendCorrection> _listTrends = new BindingTemplate<TrendCorrection>();

        public UCTrendCorrectionsView()
        {
            InitializeComponent();
            biStartDate.EditValue = DateTime.Today;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartDate = DateTime.Today;
            EndDate = null;
            if (!IsDesignMode)
            {
                LoadEntities();
            }
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
            get { return (Store)Entity; }
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

        public BindingTemplate<TrendCorrection> TrendCorrectionList
        {
            get
            {
                return _listTrends;
            }
        }

        public TrendCorrection FocusedEntity
        {
            get
            {
                return EntityFromRowHandle(gridViewEntities.FocusedRowHandle);
            }
        }
        public bool IsExistsGroup
        {
            get
            {
                return gridViewEntities.GroupedColumns.Count > 0;
            }
        }
        private TrendCorrection EntityFromRowHandle(int rowHandle)
        {
            if (gridViewEntities.IsDataRow(rowHandle))
            {
                return (TrendCorrection)gridViewEntities.GetRow(rowHandle);
            }
            return null;
        }


        [Browsable (false)]
        public DateTime StartDate
        {
            get { return (DateTime)biStartDate.EditValue; }
            set { biStartDate.EditValue = value; }
        }
        [Browsable(false)]
        public DateTime? EndDate
        {
            get 
            {
                DateTime? dt = null;
                if (biEndDate.EditValue != null)
                {
                    dt = (DateTime)biEndDate.EditValue;
                    DateTime EndCorrectDate = new DateTime(dt.Value.Year, dt.Value.Month, dt.Value.Day, 23, 59, 59);
                    return EndCorrectDate;
                }
                return dt; 
            }
            set
            {
               biEndDate.EditValue = value;
            }
        }

        private void EditEntity()
        {
            TrendCorrection bh = FocusedEntity;

            if (bh == null || SWController == null || EntityStore == null) return;

            // Edit can now trendcorrection, can't edit last EndTime < Today
            if (CanEditEntity())
            {

                using (FormTrendCorrection formEdit = new FormTrendCorrection())
                {

                    List<StoreToWorld> lst = SWController.GetListByStoreId(EntityStore.ID);

                    formEdit.SetStoreWorlds(lst);
                    formEdit.EntityStore = EntityStore;

                    formEdit.SetReadOnly();
                    formEdit.Entity = bh;

                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        TrendCorrectionList.ResetItemById(bh.ID);
                    }
                }
            }
        }
        private void NewEntity()
        {
            if (SWController == null || EntityStore == null) return;

            using (FormTrendCorrection formEdit = new FormTrendCorrection())
            {

                List<StoreToWorld> lst = SWController.GetListByStoreId(EntityStore.ID);

                formEdit.SetStoreWorlds(lst);
                formEdit.EntityStore = EntityStore;
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    if (IsIncludeDateRange(StartDate, EndDate, formEdit.EntityTrend.BeginTime, formEdit.EntityTrend.EndTime))
                        TrendCorrectionList.Add(formEdit.EntityTrend); 
                    UpdateButtonState();
                }
            }
        }
        private void DeleteEntity()
        {
            if (EntityStore == null) return;
            
            TrendCorrection trend = FocusedEntity;

            if (trend == null) return;

            if (QuestionMessageYes(GetLocalized("QuestionDeleteTrendCorrection")))
            {
                try
                {
                    ClientEnvironment.StoreService.TrendCorrectionService.DeleteByID(trend.ID);

                    _listTrends.RemoveEntityById(trend.ID);
                    UpdateButtonState();
                }
                catch (EntityException)
                {
                    ErrorMessage(GetLocalized("CantDeleteTrendCorrection"), GetLocalized("Attention"));
                    return;
                }
            }

        }

        bool IsIncludeDateRange(DateTime filterBegin, DateTime? filterEnd, DateTime dBegin, DateTime dEnd)
        {

            if (filterEnd != null)
            {
                return (filterBegin <= dBegin) && (filterEnd >= dEnd);
            }
            else
            {
                return (filterBegin <= dBegin);
            }

        }

        private void LoadEntities()
        {

            if ((!EndDate.HasValue) || (StartDate <= EndDate) || EndDate == null)
            {
                gridControl.BeginUpdate();
                try
                {

                    TrendCorrectionList.Clear();
                    if (EntityStore != null)
                    {
                        List<TrendCorrection> cols = ClientEnvironment.StoreService.TrendCorrectionService.GetTrendCorrectionFiltered(EntityStore.ID, StartDate, EndDate);

                        TrendCorrectionList.CopyList(cols);

                        if (SWController != null)
                        {
                            foreach (TrendCorrection bh in TrendCorrectionList)
                            {
                                bh.WorldName = SWController.GetWorldNameById(bh.StoreWorldID);
                            }
                        }
                    }
                    if (gridControl.DataSource == null)
                        gridControl.DataSource = TrendCorrectionList;

                }
                finally
                {
                    gridControl.EndUpdate();
                }
                UpdateButtonState();
            }
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
            }
        }



        protected override void EntityChanged()
        {
            base.EntityChanged();
            LoadEntities();
            UpdateButtonState();
        }


        private bool CanEditEntity()
        {
            if (FocusedEntity == null || !isUserWriteRight()) return false;
            if (FocusedEntity.BeginTime.Date >= DateTime.Today.Date)
                return true;
            else return false;
        }

        private bool CanDeleteEntity()
        {
            if (FocusedEntity == null || !isUserWriteRight()) return false;
            if (FocusedEntity.BeginTime.Date >= DateTime.Today.Date)
                return true;
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
                bi_NewTrendCorrection.Visibility =
                   bi_EditTrendCorrection.Visibility =
                   bi_DeleteTrendCorrection.Visibility = BarItemVisibility.Never;
                gridControl.ContextMenuStrip = null;
                bi_NewTrendCorrection.Enabled = mi_NewTrendCorrection.Enabled = false;
            }
            bi_EditTrendCorrection.Enabled = mi_EditTrendCorrection.Enabled = CanEditEntity();
            bi_DeleteTrendCorrection.Enabled = mi_DeleteTrendCorrection.Enabled = CanDeleteEntity();
        }

        #region popup menu

        private void mi_NewTrendCorrection_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void mi_EditTrendCorrection_Click(object sender, EventArgs e)
        {
            EditEntity();
        }

        private void mi_DeleteTrendCorrection_Click(object sender, EventArgs e)
        {
            DeleteEntity();
        }
        private void mi_ExpandedAll_Click(object sender, EventArgs e)
        {
            gridViewEntities.ExpandAllGroups();
        }

        private void mi_CollpaseAll_Click(object sender, EventArgs e)
        {
            gridViewEntities.CollapseAllGroups();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            mi_CollapseAll.Enabled = IsExistsGroup;
            mi_ExpandedAll.Enabled = IsExistsGroup;
            mi_EditTrendCorrection.Enabled = CanEditEntity ();
            mi_DeleteTrendCorrection.Enabled = CanDeleteEntity();
        }

        #endregion


        #region toolbar items

        private void bi_Apply_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (EndDate == null || StartDate <= EndDate)
            {
                LoadEntities();
            }
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return;
            }
        }

        private void bi_NewTrendCorrection_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewEntity();
        }

        private void bi_EditTrendCorrection_ItemClick(object sender, ItemClickEventArgs e)
        {

            EditEntity();
        }

        private void bi_DeleteTrendCorrection_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteEntity();
        }

        #endregion

        #region GridControl events

        private void gridViewTrend_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isUserWriteRight()) return;
            if (e.KeyCode == Keys.Delete && FocusedEntity != null && CanDeleteEntity())
            {
                DeleteEntity();
            }
            else if (e.KeyCode == Keys.Insert && isUserWriteRight())
            {
                NewEntity();
            }
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!EditEnabled) return;
            GridHitInfo info = gridViewEntities.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewEntities.IsDataRow(info.RowHandle))
            {
                TrendCorrection entity = EntityFromRowHandle(info.RowHandle);
                if (entity != null) EditEntity();
            }
        }

        #endregion

        private void biEndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (EndDate == null || StartDate <= EndDate )
            {
                LoadEntities();
            }
            else
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return;
            }  
        }

       private void gridViewEntity_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            UpdateButtonState();
        }

        private void deEndDate_ButtonXClick(object sender, ButtonPressedEventArgs e)
        {
             if (e.Button.Kind == ButtonPredefines.Delete)
                        EndDate = null;
        }

   }
}
