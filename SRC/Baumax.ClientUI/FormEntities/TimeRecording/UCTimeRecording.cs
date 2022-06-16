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
using Baumax.Environment;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using DevExpress.XtraGrid.Views.Grid;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCTimeRecording : UCBaseEntity
    {
        private StoreViewList _storesViewList = null;
        private int _currentView = 0; // 0-Weekly, 1-Daily
        private WorldRecordingContext _context = null;
        private UCWeekTimeRecording _weekControl = null;
        private UCDayTimeRecording _dayControl = null;
        private FireChangedModified _OnModifiedNotify = null;
        private ChangedToDailyView _OnChangedToDailyView = null;

        public UCTimeRecording()
        {
            InitializeComponent();
            if (!IsDesignMode)
            {
                _OnChangedToDailyView = new ChangedToDailyView(m_WeekControl_EventChangedToDailyView);
                _context = new WorldRecordingContext(
                    ClientEnvironment.LongTimeAbsenceService,
                    ClientEnvironment.AbsenceService,
                    ClientEnvironment.WorkingModelService,
                    ClientEnvironment.ColouringService,
                    ClientEnvironment.EmployeeService,
                    ClientEnvironment.StoreService,
                    ClientEnvironment.WorkingTimePlanningService,
                    ClientEnvironment.AbsenceTimePlanningService,
                    ClientEnvironment.WorkingTimeRecordingService,
                    ClientEnvironment.AbsenceTimeRecordingService);
                _context.ChangedModified += new FireChangedModified(OnNotyfyModified);
                ShowWeeklyView(true);
            }
            Disposed += new EventHandler(UCTimeRecording_Disposed);
        }

        private void UCTimeRecording_Disposed(object sender, EventArgs e)
        {
        }

        public bool IsUserCanEdit
        {
            get
            {
                Domain.User user = ClientEnvironment.AuthorizationService.GetCurrentUser();

                if (user != null && user.UserRoleID.HasValue)
                {
                    return (long) UserRoleId.Controlling != user.UserRoleID.Value;
                }
                else
                {
                    return false;
                }
            }
        }

        public void OnNotyfyModified()
        {
            btn_Save.Enabled = _context.Modified && IsUserCanEdit;
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

        public void LoadStoreList()
        {
            _storesViewList = new StoreViewList();
            _storesViewList.Init();
            _storesViewList.LoadAll();
            _storesViewList.RemoveAustriaStores();

            lookUpEditStores.Properties.DataSource = _storesViewList;

            if (_storesViewList.Count == 1)
            {
                lookUpEditStores.EditValue = _storesViewList[0].ID;
            }

            lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
            gridColumn_Country.GroupIndex = 0;
            gridColumn_Region.GroupIndex = 1;
            lookUpEditStores.Properties.View.ExpandAllGroups();
            storeWorldLookUpCtrl1.InitFirstValue = false;
        }

        private void UCTimeRecording_Resize(object sender, EventArgs e)
        {
            lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsDesignMode)
            {
                LoadStoreList();
            }
        }

        private void lookUpEditStores_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditStores.EditValue != null)
            {
                long storeid = (long) lookUpEditStores.EditValue;
                StoreView storeview = _storesViewList.GetById(storeid);
                if (storeview != null)
                {
                    _context.SetCountryAndStore(storeview.CountryID, storeview.ID);

                    storeWorldLookUpCtrl1.EntityList = null;

                    storeWorldLookUpCtrl1.EntityList = _context.WorldList;
                }
            }
        }

        private void storeWorldLookUpCtrl1_EditValueChanged(object sender, EventArgs e)
        {
            StoreToWorld sw = storeWorldLookUpCtrl1.CurrentEntity;

            if (sw != null)
            {
                _context.SetStoreWorld(sw);
            }
            
        }

        #region View properties

        public bool IsWeeklyView
        {
            get { return _currentView == 0; }
        }

        public bool IsDailyView
        {
            get { return _currentView == 1; }
        }

        public int CurrentView
        {
            get { return _currentView; }
            set
            {
                if (value != _currentView)
                {
                    _currentView = value;
                    OnChangedView();
                }
            }
        }

        private void OnChangedView()
        {
            if (IsWeeklyView)
            {
                ShowWeeklyView(true);
            }
            else
            {
                ShowDailyView(true);
            }
        }

        private void ShowWeeklyView(bool bShow)
        {
            if (bShow)
            {
                ShowDailyView(false);

                if (_weekControl == null)
                {
                    _weekControl = new UCWeekTimeRecording();
                    _weekControl.Parent = pcClient;
                    _weekControl.Dock = DockStyle.Fill;
                }
                else
                    _weekControl.OnDataSourceChanged -= OnDataSourceChanged;
                _weekControl.OnDataSourceChanged += OnDataSourceChanged;
                _weekControl.Context = _context;
                _weekControl.EventChangedToDailyView += _OnChangedToDailyView;
                
                _weekControl.Show();
            }
            else
            {
                if (_weekControl != null)
                {
                    _weekControl.Visible = false;
                    _weekControl.Context = null;
                    _weekControl.EventChangedToDailyView -= _OnChangedToDailyView;
                    //_weekControl.Dispose();
                    //_weekControl = null;
                    _weekControl.Hide();
                }
            }
        }

        private void m_WeekControl_EventChangedToDailyView(DateTime date)
        {
            radioGroupViews.SelectedIndex = 1;
        }

        private void ShowDailyView(bool bShow)
        {
            if (bShow)
            {
                ShowWeeklyView(false);
                if (_dayControl == null)
                {
                    _dayControl = new UCDayTimeRecording();
                    _dayControl.Parent = pcClient;
                    _dayControl.Dock = DockStyle.Fill;
                    
                }
                else
                    _dayControl.OnDataSourceChanged -= OnDataSourceChanged;
                _dayControl.Context = _context;
                _dayControl.OnDataSourceChanged += OnDataSourceChanged;
                _dayControl.Show();
            }
            else
            {
                if (_dayControl != null)
                {
                    _dayControl.Visible = false;
                    _dayControl.Context = null;
                    _dayControl.Hide();
                }
                //_dayControl.Dispose();
                //_dayControl = null;
            }
        }

        void OnDataSourceChanged(object sender, EventArgs e)
        {
            btn_Print.Enabled = (bool)sender;
        }

        #endregion

        private void radioGroupViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentView = Convert.ToInt32(radioGroupViews.EditValue);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (_context.WorldActualState != null)
            {
                _context.QuestionToSaveAndSave(false);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (_context != null && _context.CountryId > 0 && _context.StoreId > 0 && _context.StoreWorldId > 0)
            {
                using (FormPrintWorldsTimeRecording formPrint = new FormPrintWorldsTimeRecording())
                {
                    formPrint.CountryID = _context.CountryId;
                    formPrint.StoreID = _context.StoreId;
                    formPrint.StoreToWorldID = _context.StoreWorldId;
                    formPrint.StartDate = IsDailyView ? _context.ViewDate : _context.BeginWeekDate;

                    // acpro #125528
                    // pass sorting info
                    GridView gridView = null;
                    if(IsDailyView)
                    {
                        gridView = _dayControl.gridView;
                    }
                    else if (IsWeeklyView)
                    {
                        gridView = _weekControl.GridViewRecording;
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

        private void btn_ShowHideWorkingModelMessages_Click(object sender, EventArgs e)
        {
            if (!FormEmployeeWorkingModelApplied.IsVisible)
            {
                FormEmployeeWorkingModelApplied.AllowShow = true;
                if (_weekControl != null && _weekControl.Visible)
                {
                    _weekControl.PlayWorkingModelMessages();
                }
                if (_dayControl != null && _dayControl.Visible)
                {
                    _dayControl.PlayWorkingModelMessages();
                }
            }
        }

        public override void SomethingDoBeforeDispose()
        {
            if (_context != null)
            {
                _context.QuestionToSaveAndSave();
            }

            FormEmployeeWorkingModelApplied.HideForm();

            base.SomethingDoBeforeDispose();
        }

        public override void DoDispose()
        {
            if (_context != null)
            {
                _context.ChangedModified -= new FireChangedModified(OnNotyfyModified);
                if (_weekControl != null)
                {
                    _weekControl.Context = null;
                }
                if (_dayControl != null)
                {
                    _dayControl.Context = null;
                }

                _context = null;
            }

            FormEmployeeWorkingModelApplied.HideForm();

            base.DoDispose();
        }
    }
}