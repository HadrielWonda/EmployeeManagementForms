using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.ClientUI.Printout;
using Baumax.Printouts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    using Baumax.Environment;
    using Baumax.Domain;
    using Baumax.ClientUI.FormEntities.TimePlanning.Daily;

    public partial class UCTimePlanning : UCBaseEntity 
    {
        private StoreViewList _storesViewList = null;
        private WorldPlanningContext _planningContext = new WorldPlanningContext();

        private UCWorldDailyView _dailyView = null;
        private TimeView _currentView = 0;// 0-Weekly, 1-Daily

        public UCTimePlanning()
        {
            InitializeComponent();
            radioGroupViews.SelectedIndex = 0;

            _planningContext.OnChangedModified += new FireChangedModified(_planningContext_OnChangedModified);
            _planningContext.OnChangedStoreOrWorld += new FireChangedStoreOrWorld(m_planningContext_OnChangedStoreOrWorld);
            _planningContext.ReadOnly = (ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.EmployeeDayStatePlanningService) & Baumax.Contract.AccessType.Write)
                == Baumax.Contract.AccessType.None;

        }

        void m_planningContext_OnChangedStoreOrWorld(bool anyEmployee)
        {
            btn_Print.Enabled = anyEmployee;
        }
        public override void SomethingDoBeforeDispose()
        {
            if (_planningContext != null)
            {

                _planningContext.QuestionToSaveAndSave();
                _planningContext.OnChangedModified -= new FireChangedModified(_planningContext_OnChangedModified);
                _planningContext.OnChangedStoreOrWorld -= new FireChangedStoreOrWorld(m_planningContext_OnChangedStoreOrWorld);
            }

            FormEmployeeWorkingModelApplied.HideForm();

            base.SomethingDoBeforeDispose();
        }
        public override void DoDispose()
        {
            if (_planningContext != null)
            {
                _planningContext.OnChangedModified -= new FireChangedModified(_planningContext_OnChangedModified);
            }

            FormEmployeeWorkingModelApplied.HideForm();

            base.DoDispose();
        }
        

        void _planningContext_OnChangedModified()
        {
            btn_Save.Enabled = _planningContext.ReadOnly |_planningContext.Modified;
        }

        #region View properties

        public bool IsWeeklyView
        {
            get { return _currentView == TimeView.Weekly ; }
        }
        public bool IsDailyView
        {
            get { return _currentView == TimeView.Daily; }
        }

        public TimeView CurrentView
        {
            get { return _currentView; }
            set
            {
                if (value != _currentView)
                {
                    _currentView = value;

                    if (_planningContext != null)
                        _planningContext.FireSave();

                    if (IsWeeklyView)
                        ShowWeeklyView();
                    else
                        ShowDailyView();
                }
            }
        }

        #endregion

        #region Service properties

        public long CurrentStoreId
        {
            get
            {
                if (lookUpEditStores.EditValue != null)
                    return (long)lookUpEditStores.EditValue;
                else return 0;
            }
        }

        public Store CurrentStore
        {
            get
            {
                long id = CurrentStoreId;
                if (id != 0)
                {
                    StoreView sv = _storesViewList.GetById(id);
                    if (sv != null)
                    {
                        return sv.Entity;
                    }
                }
                return null;
            }
        }

        public long CurrentCountryId
        {
            get
            {
                long id = CurrentStoreId;
                if (id != 0)
                {
                    StoreView sv = _storesViewList.GetById(id);
                    if (sv != null)
                    {
                        return sv.CountryID;
                    }
                }
                return 0;
            }
        }


        public StoreToWorld CurrentStoreToWorld
        {
            get
            {
                return storeWorldLookUpCtrl1.CurrentEntity;
            }
        }


        


        #endregion


        public void LoadStoreList()
        {
            ucWeekTimePlanning.Context = _planningContext;


            _storesViewList = new StoreViewList();
            _storesViewList.Init();
            _storesViewList.LoadAll();

            lookUpEditStores.Properties.DataSource = _storesViewList;

            if (_storesViewList.Count == 1)
            {
                lookUpEditStores.EditValue = _storesViewList[0].ID;
            }

            lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
            gridColumn_Country.GroupIndex = 0;
            gridColumn_Region.GroupIndex = 1;
            lookUpEditStores.Properties.View.ExpandAllGroups();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                LoadStoreList();
            }
        }

        private void UCTimePlanning_Resize(object sender, EventArgs e)
        {
            lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
        }

        private void lookUpEditStores_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentStoreId != 0)
            {

                _planningContext.SetStore(CurrentCountryId , CurrentStore);

                storeWorldLookUpCtrl1.EntityList = _planningContext.ListStoreWorlds;

                if (CurrentStoreId != 0)
                {
                    _planningContext.CurrentStoreWorld = CurrentStoreToWorld;

                }
            }
        }


        private void ShowDailyView()//DateTime date)
        {
            radioGroupViews.SelectedIndex = 1;
            if (_dailyView == null)
            {
                _dailyView = new UCWorldDailyView();
                _dailyView.Parent = pcDummy;
                _dailyView.Dock = DockStyle.Fill;
                _dailyView.EventChangedToWeeklyView += new ChangedToWeeklyView(m_dailyView_EventChangedToWeeklyView);
            }
            _dailyView.ViewDate = _planningContext.ViewDate;
            _dailyView.Context = _planningContext;
            _dailyView.Show();
            
            ucWeekTimePlanning.Hide();
        }
        private void ShowWeeklyView()
        {
            radioGroupViews.SelectedIndex = 0;
            if (_dailyView != null)
            {
                _dailyView.Hide();
                _dailyView.Context = null;
            }
            ucWeekTimePlanning.Show();
            ucWeekTimePlanning.RefreshGrid();
            if (ucWeekTimePlanning.Context != null)
                ucWeekTimePlanning.OnChangedContext();
        }
        void m_dailyView_EventChangedToWeeklyView()
        {
            CurrentView = TimeView.Weekly ;            
        }

        private void ucWeekTimePlanning_EventChangedToDailyView(DateTime date)
        {
            _planningContext.ViewDate = date;
            CurrentView = TimeView.Daily;   
        }

        private void storeWorldLookUpCtrl1_EditValueChanged(object sender, EventArgs e)
        {
            if (_planningContext.CurrentStoreWorld != CurrentStoreToWorld)
            {
                _planningContext.CurrentStoreWorld = CurrentStoreToWorld;

            }

        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            //CurrentView = Convert.ToInt32(radioGroup1.EditValue);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentView = (TimeView)Convert.ToInt32(radioGroupViews.EditValue);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _planningContext.FireSave();
            _planningContext.SaveContext2(true);
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                radioGroupViews.Properties.Items[0].Description = GetLocalized("WeeklyView");
                radioGroupViews.Properties.Items[1].Description = GetLocalized("DaylyView");

                if (storeWorldLookUpCtrl1.Properties.Columns.Count == 1)
                {
                    storeWorldLookUpCtrl1.Properties.Columns[0].Caption = GetLocalized("World");
                }
            }
        }
		
		private void btn_Print_Click(object sender, EventArgs e)
		{
            if (_planningContext != null && _planningContext.PlanningEmployees != null
                && _planningContext.PlanningEmployees.Count > 0)
            {
                if (CurrentCountryId > 0 && CurrentStoreId > 0)
                {
                    using (FormPrintTimePlanning formPrint = new FormPrintTimePlanning())
                    {
                        formPrint.CountryID = CurrentCountryId;
                        formPrint.StoreID = CurrentStoreId;
                        formPrint.StoreWorldID = CurrentStoreToWorld != null ? CurrentStoreToWorld.ID : 0;
                        formPrint.StartDate = IsDailyView ? _dailyView.ViewDate : ucWeekTimePlanning.BeginDate;

                        // acpro #125528
                        // pass sorting info
                        GridView gridView = null;
                        switch(CurrentView)
                        {
                            case TimeView.Daily:
                                if ((_dailyView != null) && (_dailyView.gridView != null) && (_dailyView.gridView.SortInfo != null))
                                {
                                    gridView = _dailyView.gridView;
                                }
                                break;
                            case TimeView.Weekly:
                                if ((ucWeekTimePlanning != null) && (ucWeekTimePlanning.gridView != null) && (ucWeekTimePlanning.gridView.SortInfo != null))
                                {
                                    gridView = ucWeekTimePlanning.gridView;
                                }
                                break;
                        }
                        if (gridView != null)
                        {
                            List<SortField> sortFields = new List<SortField>();
                            for (int i = 0; i < gridView.SortInfo.Count; i++)
                            {
                                if (gridView.SortInfo[i].Column != null)
                                {
                                    sortFields.Add(
                                        new SortField(gridView.SortInfo[i].Column.FieldName,
                                                      gridView.SortInfo[i].SortOrder));
                                }
                            }
                            if (sortFields.Count != 0)
                            {
                                formPrint.SortFields = sortFields.ToArray();
                            }
                        }

                        formPrint.ShowDialog(FindForm());
                    }
                }
            }
        }

        private void chk_ShowHideWorkingModelMessages_CheckedChanged(object sender, EventArgs e)
        {
            FormEmployeeWorkingModelApplied.AllowShow = chk_ShowHideWorkingModelMessages.Checked;

            if (FormEmployeeWorkingModelApplied.AllowShow)
            {

                if (ucWeekTimePlanning.Visible)
                    ucWeekTimePlanning.PlayWorkingModelMessages();
                if (_dailyView != null && _dailyView.Visible)
                    _dailyView.PlayWorkingModelMessages();


                
            }
        }

        private void btn_ShowHideWorkingModelMessages_Click(object sender, EventArgs e)
        {
            if (!FormEmployeeWorkingModelApplied.AllowShow)
            {
                FormEmployeeWorkingModelApplied.AllowShow = true;
                if (ucWeekTimePlanning.Visible)
                    ucWeekTimePlanning.PlayWorkingModelMessages();
                if (_dailyView != null && _dailyView.Visible)
                    _dailyView.PlayWorkingModelMessages();
            }
        }
    }
}
