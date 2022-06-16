using System;
using System.Collections;
using System.ComponentModel;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    public partial class UCGetValueFromStore : UCBaseEntity
    {
        private StoreManagerContext _context;
        private const int actualBusinessVol = 0;
        private const int cashDeskVol = 1;
        private const int targetVol = 2;
        private bool isLoaded = false;
        
        public UCGetValueFromStore()
        {
            InitializeComponent();
            if (ClientEnvironment.IsRuntimeMode)
            {
                //lookUpEditStoresFrom.Properties.PopupFormWidth = lookUpEditStoresFrom.Width;
                //lookUpEditStoresTo.Properties.PopupFormWidth = lookUpEditStoresTo.Width;
                gridColumn_Country.GroupIndex = 0;
                gridColumn_Region.GroupIndex = 1;
                gridColumn_CountryTo.GroupIndex = 0;
                gridColumn_RegionTo.GroupIndex = 1;
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mode = actualBusinessVol;
            endDate = beginDate = (short)DateTime.Now.Year;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width/2;
            radioGroup.Properties.Items[actualBusinessVol].Description = GetLocalized("actualBusinessVol");
            radioGroup.Properties.Items[cashDeskVol].Description = GetLocalized("cashDeskVol");
            radioGroup.Properties.Items[targetVol].Description = GetLocalized("targetVol");
            isLoaded = true;
        }

        #region Field

        public StoreManagerContext Context
        {
            get { return _context; }
        }

        private StoreViewList ListOfStoresView
        {
            get { return Context.ListOfStoresView; }
        }

        private long fromStoreID
        {
            get
            {
                if (lookUpEditStoresFrom.EditValue != null)
                    return Convert.ToInt64(lookUpEditStoresFrom.EditValue);
                return 0;
            }
        }

        private long toStoreID
        {
            get
            {
                if (lookUpEditStoresTo.EditValue != null)
                    return Convert.ToInt64(lookUpEditStoresTo.EditValue);
                return 0;
            }
            set { lookUpEditStoresTo.EditValue = value; }
        }

        private short beginDate
        {
            get { return Convert.ToInt16(se_Start.EditValue); }
            set { se_Start.EditValue = value; }
        }

        private short endDate
        {
            get { return Convert.ToInt16(se_End.EditValue); }
            set { se_End.EditValue = value; }
        }

        private int mode
        {

            get { return Convert.ToInt32(radioGroup.SelectedIndex); }
            set { radioGroup.SelectedIndex = value; }
        }

        [Browsable(false)]
        public Store EntityStore
        {
            get { return (Store)Entity; }
            set { Entity = value; }
        }
        #endregion
        
        public void SetStoreContext(StoreManagerContext context)
        {
            _context = context;
            lookUpEditStoresFrom.Properties.DataSource = ListOfStoresView;
            lookUpEditStoresTo.Properties.DataSource = ListOfStoresView;
            lookUpEditStoresFrom.EditValue = null;
            lookUpEditStoresTo.EditValue = null;
            if (Context.CurrentView != null)
            {
                toStoreID = Context.CurrentView.ID;
                lookUpEditStoresTo.Enabled = false;
            }
            lookUpEditStoresFrom.Properties.View.ExpandAllGroups();
            lookUpEditStoresTo.Properties.View.ExpandAllGroups();
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(components);
        }

        public override bool IsValid()
        {
            if (toStoreID == 0)
            {
                ErrorMessage(GetLocalized("Selectcountrydestination"));
                lookUpEditStoresTo.Focus();
                return 
                    false;
            }
            if (fromStoreID == 0)
            {
                ErrorMessage(GetLocalized("Selectcountrysource"));
                lookUpEditStoresFrom.Focus();
                return 
                    false;
            }
            if (beginDate > endDate)
            {
                ErrorMessage(GetLocalized("ErrorDateRange"));
                return 
                    false;
            }
            if (!isDataFromNotEmpty())
            {
                ErrorMessage(GetLocalized("NoDataToCopy"));
                 return 
                    false;
            }
            if (isDataFromToExist())
            {
                ErrorMessage(GetLocalized("DataForTheSelectedTimeRangeExistsAlready"));
                return
                    false;
            }
            return true;
        }
        
        private void lookUpEditStoreTo_QueryPopUp(object sender, CancelEventArgs e)
        {
            lookUpEditStoresTo.Properties.PopupFormWidth = lookUpEditStoresTo.Width;
        }

        private void lookUpEditStoresFrom_QueryPopUp(object sender, CancelEventArgs e)
        {
            lookUpEditStoresFrom.Properties.PopupFormWidth = lookUpEditStoresFrom.Width;
        }

        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
              bt_Copy.Enabled = false;
              MakeCopy();
              bt_Copy.Enabled = true;
            }
        }

        protected void MakeCopy()
        {
           using (CopyingWaitForm waitFrm = new CopyingWaitForm())
            {
                waitFrm.mode = mode;
                waitFrm.fromStoreID = fromStoreID;
                waitFrm.toStoreID = toStoreID;
                waitFrm.beginDate = beginDate;
                waitFrm.endDate = endDate;
                waitFrm.ShowDialog();
                if (waitFrm.error != null)
                    throw new ApplicationException("CopyWaitForm", waitFrm.error);
                switch(waitFrm.result)
                {
                    case BVcopyFromStoreResult.DataExistsInSelectedTimeRange:
                        ErrorMessage(GetLocalized("DataForTheSelectedTimeRangeExistsAlready"));
                        break;
                    case BVcopyFromStoreResult.NoDataCopy:
                        ErrorMessage(GetLocalized("NoDataToCopy"));
                        break;
                    case BVcopyFromStoreResult.Success:
                        LoadTimeRangeTo();
                        break;
                    default:
                        throw new ApplicationException("CopyWaitForm - result error");
                }
            }
        }
        
        private void LoadTimeRangeFrom() 
        {
            if (fromStoreID <= 0)
            {
                gridControlDateFrom.DataSource = null;
            }
            else
            {
                gridControlDateFrom.BeginUpdate();
                try
                {
                    gridControlDateFrom.DataSource = null;
                    FillDataSourseFrom(gridControlDateFrom); 
                }
                finally
                {
                    gridControlDateFrom.EndUpdate();
                }
            }
        }

        private void LoadTimeRangeTo()
        {
            if (toStoreID <= 0)
            {
                gridControlDateTo.DataSource = null;
            }
            else
            {
                gridControlDateTo.BeginUpdate();
                try
                {
                    gridControlDateTo.DataSource = null;
                    FillDataSourseTo(gridControlDateTo);
                }
                finally
                {
                    gridControlDateTo.EndUpdate();
                }
            }
        }

        private void FillDataSourseFrom(GridControl grid)
        {
            if (isLoaded)
            {
                grid.DataSource = GetDataToGridFrom();
            }
        }

        private void FillDataSourseTo(GridControl grid)
        {
            if (isLoaded)
            {
                grid.DataSource = GetDataToGridTo();
            }
        }

        private bool isDataFromNotEmpty()
        {
            if (gridControlDateFrom.DataSource == null || gridViewDateFrom.RowCount == 0)
                return false;
            if (mode == targetVol)
            {
              BVTargetByYearInfo entity;
              for (int i = 0; i < gridViewDateFrom.RowCount; i++ )
                {
                    entity = (BVTargetByYearInfo)GetEntityByRowHandle(i, gridViewDateFrom); 
                    if (entity != null && entity.Year >= beginDate && entity.Year <= endDate)
                        return true;
                }  
            }
            else
            {
                BVActualByYearInfo entity;
                for (int i = 0; i < gridViewDateFrom.RowCount; i++)
                {
                    entity = (BVActualByYearInfo)GetEntityByRowHandle(i, gridViewDateFrom);
                    if (entity != null && entity.Year >= beginDate && entity.Year <= endDate)
                        return true;
                }  
            }
            return false;
        }

        private bool isDataFromToExist()
        {
            if (gridControlDateTo.DataSource == null || gridViewDateTo.RowCount == 0)
                return false;
            if (mode == targetVol)
            {
                BVTargetByYearInfo entityFrom, entityTo;
                for (int i = 0; i < gridViewDateFrom.RowCount; i++)
                {
                    entityFrom = (BVTargetByYearInfo)GetEntityByRowHandle(i, gridViewDateFrom);
                    for (int j = 0; j < gridViewDateTo.RowCount; j++)
                    {
                        entityTo = (BVTargetByYearInfo)GetEntityByRowHandle(i, gridViewDateTo);
                        if (entityFrom != null && entityTo != null && entityTo.Year == entityFrom.Year && entityTo.Year >= beginDate && entityTo.Year <= endDate)
                            return true;
                    }
                }
            }
            else
            {
                BVActualByYearInfo entityFrom, entityTo;
                for (int i = 0; i < gridViewDateFrom.RowCount; i++)
                {
                    entityFrom = (BVActualByYearInfo)GetEntityByRowHandle(i, gridViewDateFrom);
                    for (int j = 0; j < gridViewDateTo.RowCount; j++)
                    {
                        entityTo = (BVActualByYearInfo)GetEntityByRowHandle(j, gridViewDateTo);
                        if (entityFrom != null && entityTo != null && entityTo.Year == entityFrom.Year && entityTo.Year >= beginDate && entityTo.Year <= endDate)
                            return true;
                    }
                }
            }
            return false;
        }
        
        private object GetEntityByRowHandle(int rowHandle, GridView gridview)
        {

            if (gridview.IsDataRow(rowHandle))
                return gridview.GetRow(rowHandle);
            else 
                return null;

        }
        
        private IList GetDataToGridFrom()
        {
            switch (mode)
            {
                case actualBusinessVol:
                    return ClientEnvironment.StoreService.BVActualByYearInfoGet(Convert.ToInt16(DateTime.Now.Date.Year +1), fromStoreID);
                case cashDeskVol:
                    return ClientEnvironment.StoreService.BVCcrYearInfoGet(Convert.ToInt16(DateTime.Now.Date.Year +1), fromStoreID);
                case targetVol:
                    return ClientEnvironment.StoreService.BVTargetByYearInfoGet(Convert.ToInt16(DateTime.Now.Date.Year +1), fromStoreID);
                default:
                    throw new ApplicationException("Get Value From invalid mode in case GetDataToGridFrom");
            }
        }

        private IList GetDataToGridTo()
        {
            switch (mode)
            {
                case actualBusinessVol:
                    return ClientEnvironment.StoreService.BVActualByYearInfoGet(Convert.ToInt16(DateTime.Now.Date.Year + 1), toStoreID);
                case cashDeskVol:
                    return ClientEnvironment.StoreService.BVCcrYearInfoGet(Convert.ToInt16(DateTime.Now.Date.Year + 1), toStoreID);
                case targetVol:
                    return ClientEnvironment.StoreService.BVTargetByYearInfoGet(Convert.ToInt16(DateTime.Now.Date.Year + 1), toStoreID);
                default:
                    throw new ApplicationException("Get Value From invalid mode in case GetDataToGridTo");
            }
        }
        
        private void StoreFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                LoadTimeRangeFrom();
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                if (mode == targetVol)
                {
                    gc_BeginDate.Visible = 
                        gc2_BeginDate.Visible =
                        gc_EndDate.Visible =
                        gc2_EndDate.Visible = false;
                    gc_MonthBegin.Visible =
                        gc_MonthEnd.Visible =
                        gc2_MonthBegin.Visible =
                        gc2_MonthEnd.Visible = true;
                    gc_yearappearance.VisibleIndex =
                        gc2_yearappearance.VisibleIndex = 0;
                    gc_MonthBegin.VisibleIndex =
                        gc2_MonthBegin.VisibleIndex = 1;
                    gc_MonthEnd.VisibleIndex =
                        gc2_MonthEnd.VisibleIndex = 2;
                      
                   
                }
                else
                {
                    gc_BeginDate.Visible =
                        gc2_BeginDate.Visible =
                        gc_EndDate.Visible =
                        gc2_EndDate.Visible = true;
                    gc_MonthBegin.Visible =
                        gc_MonthEnd.Visible =
                        gc2_MonthBegin.Visible =
                        gc2_MonthEnd.Visible = false; 
                    gc_yearappearance.VisibleIndex =
                        gc2_yearappearance.VisibleIndex = 0;
                    gc_BeginDate.VisibleIndex =
                        gc2_BeginDate.VisibleIndex = 1;
                    gc_EndDate.VisibleIndex =
                        gc2_EndDate.VisibleIndex = 2;
                      
                }
               LoadTimeRangeFrom();
               LoadTimeRangeTo();
            }
        }

        private void StoresTo_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                LoadTimeRangeTo();
        }

        private void seEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoaded && (beginDate > endDate))
                endDate = beginDate;
        }

        private void splitContainer_SizeChanged(object sender, EventArgs e)
        {
            if (isLoaded && splitContainerControl1.Width >1)
            {
                splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
                
            }
        }

        private void lookupEditStoreFrom_SizeChanged(object sender, EventArgs e)
        {
            lookUpEditStoresFrom.Properties.PopupFormWidth = lookUpEditStoresFrom.Width;
        }

        private void lookUpEditStoreTo_SizeChanged(object sender, EventArgs e)
        {
            lookUpEditStoresTo.Properties.PopupFormWidth = lookUpEditStoresTo.Width;
        }
    }
}
