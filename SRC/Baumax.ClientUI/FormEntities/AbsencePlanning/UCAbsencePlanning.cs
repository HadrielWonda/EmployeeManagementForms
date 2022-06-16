using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;
using System.Diagnostics;
using Baumax.Contract.Absences;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using Baumax.ClientUI.FormEntities.TimePlanning;
using Baumax.ClientUI.Printout;

namespace Baumax.ClientUI.FormEntities.AbsencePlanning
{
    public partial class UCAbsencePlanning : UCBaseEntity 
    {
        private int YEARLY_COLUMN_WIDTH = 30;
        private int MONTHLY_COLUMN_WIDTH = 70;

        //private string SHOW_HWGR = "Show HWGR";
        //private string HIDE_HWGR = "Hide HWGR";

        private StoreViewList m_storesViewList = null;
        private List<StoreToWorld> _ListStoreToWorld = null;
        private StoreToWorld _emptyworld = new StoreToWorld(-1, -1);
        private StoreToWorld _currentworld = null;
        private Dictionary<long, string> _hwgrNameDiction = new Dictionary<long, string>();
        private int _year = DateTime.Today.Year;
        private int _TodayYear = DateTime.Today.Year;
        private AbsencePlanningView _planningview = AbsencePlanningView.YearlyView; 
        private AbsencePlanningQuery _query = null;
        private AbsencePlanningResponse _response = null;
        private bool _UserCanEdit = true;
        private bool _allowEdit = false;
        private long _countryid = 0;
        private bool _bAustria  = false;
        private AbsenceManager _absencemanager = null;
        private LongTimeAbsenceManager _longabsencesmanager = null;

        private BindingList<BzEmployeeHoliday> _EmployeesList = null;
        private Dictionary<long, BzEmployeeHoliday> _indexIdToEntity = null;

        private Dictionary<long, BindingList<BzEmployeeHoliday>> _indexEmployeeByWorld = new Dictionary<long,BindingList<BzEmployeeHoliday>> ();

        long[] _ids_absences_from_server = null;
        long[] _ids_removed_absences = null;

        AbsenceTimeRangeList _list_New_Abences = null;
        private List<BandedGridColumn> _staticColumns = null;//new List<BandedGridColumn>();
        //private List<BandedGridColumn> _weekColumns = null;
        //private List<GridBand> _monthBands = null;

        private double[] _total_sum_by_weeks = new double [54];
        private double[] _total_sum_by_months = new double[12];
        private double[] _total_sum_by_days = new double[7];

        private YearWrapper _yearwrapper = null;
        private DateTime _currentMondayDate;

        public UCAbsencePlanning()
        {
            InitializeComponent();
            CurrentMondayDate = DateTimeHelper.GetMonday(DateTime.Today);
            _TodayYear = DateTimeHelper.GetYearByDate(DateTime.Today);
            _emptyworld.WorldName = String.Empty;// "All worlds";
            _emptyworld.ID = Int64.MinValue;

            _staticColumns = new List<BandedGridColumn>();
            _staticColumns.Add(gc_Employee);
            _staticColumns.Add(gc_HWGR);
            _staticColumns.Add(gc_NewHolidays) ;
            _staticColumns.Add(gc_OldHolidays);
            _staticColumns.Add(gc_AvailableHolidays) ;
            _staticColumns.Add(gc_UsedHolidays) ;
            _staticColumns.Add(gc_SpareHolidaysExc) ;
            _staticColumns.Add(gc_SpareHolidaysInc);

            gc_HWGR.Visible = false;

            _yearwrapper = new YearWrapper(_TodayYear);
            gcAbsencePlanning.ContextMenuStrip = cmAbsencePlanning;
            int[] years = new int[60];
            int y=0;
            for (int i = 2000; i <= 2059; i++)
            {
                years[y++] = i;
            }
            cbYears.Properties.Items.AddRange(years);

            cbYears.SelectedItem = Year;
            deMonday.Properties.MinValue = _yearwrapper.BeginYearDate;
            deMonday.Properties.MaxValue = _yearwrapper.EndYearDate;

            AllowEdit = Year >= _TodayYear;

            btn_TakeFromPrevYear.Enabled = false;
            lookUpEditStores.Properties.PopupFormWidth = 250;
        }


        #region properties
        private bool ShowHWGR
        {
            get
            {
                return gc_HWGR.Visible;
            }
            set
            {
                if (gc_HWGR.Visible != value)
                {
                    gc_HWGR.Visible = value;

                    checkEditShowHideHWGR.Checked = value;
                    menuitem_ShowHWGR.Checked = value;
                    //if (gc_HWGR.Visible)
                    //    checkEditShowHideHWGR.Text = HIDE_HWGR;
                    //else
                    //    checkEditShowHideHWGR.Text = SHOW_HWGR;
                }
            }
        }
        private AbsencePlanningView ViewAbsencePlanning
        {
            get { return _planningview; }
            set
            {
                if (_planningview != value)
                {
                    OnChangeView(value);
                }
            }
        }
        public DateTime CurrentMondayDate
        {
            get { return _currentMondayDate; }
            set
            {
                if (_currentMondayDate != value)
                {
                    _currentMondayDate = value;
                    deMonday.DateTime = value;

                    OnChangeWeek();
                }
            }
        }
        public Store CurrentStore
        {
            get
            {
                Store store = null;
                if (lookUpEditStores.EditValue != null)
                {
                    long id = (long)lookUpEditStores.EditValue;

                    StoreView sv = m_storesViewList.GetById(id);

                    if (sv != null)
                    {
                        store = sv.Entity;
                    }
                }
                return store;
            }
        }
        public long CurrentCountryId
        {
            get
            {

                long countryid = 0;
                Store store = CurrentStore;

                if (store != null)
                {
                    countryid = store.CountryID;
                }
                return countryid;
            }

        }
        public StoreToWorld CurrentStoreToWorld
        {
            get
            {
                return storeworldControl.CurrentEntity;
            }
        }
        public int Year
        {
            get { return _year; }
            set 
            {
                if (_year != value)
                {
                    OnChangeYear(value);
                }
            }
        }
        public bool IsAustria
        {
            get { return _bAustria; }
            set
            {
                if (_bAustria != value)
                {
                    _bAustria = value;
                    ApplyUserAccess();
                }
            }
        }
        private long OldCountryId
        {
            get { return _countryid; }
            set
            {
                _countryid = value;
            }
        }
        public bool UserCanEdit
        {
            get { return _UserCanEdit; }
            private set
            {
                _UserCanEdit = value;
                ApplyUserAccess();
            }
        }
        public bool AllowEdit
        {
            get
            {
                return _allowEdit;
            }

            set
            {
                _allowEdit = value;
                ApplyUserAccess();
            }
        }

        public override bool Modified
        {
            get
            {
                return base.Modified;
            }
            set
            {
                base.Modified = value;

                btn_Save.Enabled = Modified;
            }
        }
        #endregion



        public override void AssignLanguage()
        {
            
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                menuItem_View.Text = GetLocalized ("View");
                menuItem_MonthlyView.Text = GetLocalized("MonthlyView");
                menuItem_YearlyView.Text = GetLocalized("YearlyView");
                menuItem_WeeklyView.Text = GetLocalized("WeeklyView");


                cmiYearlyView.Text = menuItem_YearlyView.Text;
                cmiMonthlyView.Text = menuItem_MonthlyView.Text;
                cmiWeeklyView.Text = menuItem_WeeklyView.Text;

                menuItem_AddAbsences.Text = GetLocalized("AddAbsences");
                menuItem_DeleteAbsences.Text = GetLocalized("DeleteAbsences");

                menuItem_QuickAddAbsence.Text = GetLocalized("QuickAddAbsence");

                menuitem_ShowHWGR.Text = GetLocalized("ShowHWGR");

                checkEditShowHideHWGR.Text = GetLocalized("ShowHWGR");

                btnView.Text = GetLocalized(ViewAbsencePlanning.ToString());
                //btnView.ToolTip = btnView.Text;

                btn_TakeFromPrevYear.ToolTip = GetLocalized("CalculateForNexYear");
                btn_Save.ToolTip = GetLocalized("Save");
                btn_Print.ToolTip = GetLocalized("Print");

                AssignNameOfMonth();
            }
        }

        public override void SomethingDoBeforeDispose()
        {

            SaveData();
            base.SomethingDoBeforeDispose();
        }

        public void SaveData()
        {
            SaveData(true);
        }
        public void SaveData(bool bAsk)
        {
            if (Modified)
            {
                if (!bAsk || XtraMessageBox.Show(GetLocalized("QuestionSavePlannigData"), GetLocalized("Attention"), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    BuildResponse();

                    if (_response != null)
                    {
#if DEBUG
                        int iCountIds = (_response.DeletedIds != null) ? _response.DeletedIds.Length : 0;
                        int iCountEntities = (_response.ModifiedEntity != null) ? _response.ModifiedEntity.Length : 0;
                        int iCountNewAbsence = (_response.NewAbsences != null) ? _response.NewAbsences.Length : 0;

                        string s = String.Format(" ids-{0}, modified - {1}, new absences - {2}", iCountIds, iCountEntities, iCountNewAbsence);

                        InfoMessage(s);
#endif
                        AbsencePlanningResponse new_response = ClientEnvironment.EmployeeService.EmployeeTimeService.SaveAbsencePlanning(_response);

                        if (new_response != null)
                        {
                            SyncResponses(new_response);
                        }
                        _response = null;
                        Modified = false;
                    }
                }
            }
        }

        private void SyncResponses(AbsencePlanningResponse new_response)
        {
            

            if (new_response.DeletedIds != null && _ids_absences_from_server != null && _ids_absences_from_server.Length > 0)
            {
                foreach (long id in new_response.DeletedIds)
                {
                    int i = Array.BinarySearch<long>(_ids_absences_from_server, id);
                    if (i >= 0)
                    {
                        _ids_absences_from_server[i] = 0;
                    }
                }
            }

            if (new_response.ModifiedEntity != null && _response.ModifiedEntity != null)
            {
                foreach (EmployeeHolidaysInfo info in new_response.ModifiedEntity)
                {
                    foreach (EmployeeHolidaysInfo info1 in _response.ModifiedEntity)
                    {
                        if (info.EmployeeID == info1.EmployeeID)
                        {
                            info1.ID = info.ID;
                            break;
                        }
                    }
                }
            }
            List<long> ids = new List<long>();
            if (_ids_absences_from_server != null)
            {
                for (int i = 0; i < _ids_absences_from_server.Length; i++)
                {
                    if (_ids_absences_from_server[i] != 0)
                        ids.Add(_ids_absences_from_server[i]);
                }
            }

            if (new_response.NewAbsences != null && _response.NewAbsences != null)
            {
                
                    
                for (int i = 0; i < new_response.NewAbsences.Length; i++)
                {
                    _response.NewAbsences[i].ID = new_response.NewAbsences[i].ID;
                    ids.Add(new_response.NewAbsences[i].ID);
                }
                
            }
            _ids_absences_from_server = ids.ToArray();
        }

        protected virtual void ApplyUserAccess()
        {
            gvAbsencePlanning.OptionsBehavior.Editable = UserCanEdit && AllowEdit && !IsAustria ;
            gc_OldHolidays.OptionsColumn.AllowEdit = UserCanEdit && AllowEdit && !IsAustria;
            gc_OldHolidays.OptionsColumn.ReadOnly = !gc_OldHolidays.OptionsColumn.AllowEdit;
            gc_NewHolidays.OptionsColumn.AllowEdit = UserCanEdit && AllowEdit && !IsAustria;
            gc_NewHolidays.OptionsColumn.ReadOnly = !gc_NewHolidays.OptionsColumn.AllowEdit;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsDesignMode)
            {
                BuildYearlyColumns();


                BuildHWGRDiction();
                

                gvAbsencePlanning.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                                {
                                                                    new GridColumnSortInfo(gc_HWGR, ColumnSortOrder.Ascending),
                                                                    new GridColumnSortInfo(gc_Employee, ColumnSortOrder.Ascending)
                                                                });

                UserCanEdit = ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value != (long)UserRoleId.Controlling;

                storeworldControl.InitFirstValue = true;

                LoadStoreList();
             
            }
        }

        #region HWGR methods

        private void BuildHWGRDiction()
        {
            List<HWGR> lstHwgr = ClientEnvironment.HWGRService.FindAll();
            if (lstHwgr != null)
            {
                _hwgrNameDiction.Clear();
                foreach (HWGR hwgr in lstHwgr)
                {
                    _hwgrNameDiction[hwgr.ID] = hwgr.Name;
                }
            }
        }
        private string GetHwgrName(long hwgrid)
        {
            string name = String.Empty ;
            if (hwgrid > 0)
                _hwgrNameDiction.TryGetValue(hwgrid, out name);
            return name;
        }

        #endregion

        protected virtual void OnChangeYear(int year)
        {
            if (_year != year)
            {
                // ask to save data
                SaveData();
                _year = year;

                AllowEdit = Year >= _TodayYear;
                _yearwrapper = new YearWrapper(Year);
                deMonday.Properties.MinValue = _yearwrapper.BeginYearDate;
                deMonday.Properties.MaxValue = _yearwrapper.EndYearDate;

                if (_TodayYear < Year)
                {
                    CurrentMondayDate = _yearwrapper.BeginYearDate; 
                }
                else if (_TodayYear > Year)
                {
                    CurrentMondayDate = DateTimeHelper.GetMonday(_yearwrapper.EndYearDate); 
                }
                else
                    CurrentMondayDate = DateTimeHelper.GetMonday(DateTime.Today); 

                LoadHolidaysInfo();
                ChangeView();
                // load new data
            }
        }
        protected virtual void OnChangeWeek()
        {
            if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
            {
                BuildWeeklyColumns();
                ApplyFilterByWorld();
            }
        }
        protected virtual void OnChangeView(AbsencePlanningView newview)
        {
            if (newview != _planningview)
            {
                _planningview = newview;

                btnView.Text = GetLocalized(ViewAbsencePlanning.ToString ());
                ChangeView();
                //switch (_planningview)
                //{
                //    case AbsencePlanningView.Yearly: BuildYearlyColumns(); break;
                //    case AbsencePlanningView.Monthly: BuildMonthlyColumns(); break;
                //    case AbsencePlanningView.Weekly: BuildWeeklyColumns(); break;
                //    default:
                //        throw new InvalidEnumArgumentException();
                //}
            }
        }
        protected void ChangeView()
        {
            switch (_planningview)
            {
                case AbsencePlanningView.YearlyView: BuildYearlyColumns(); break;
                case AbsencePlanningView.MonthlyView: BuildMonthlyColumns(); break;
                case AbsencePlanningView.WeeklyView: BuildWeeklyColumns(); break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        protected virtual void OnChangeStore()
        {
            SaveData();
            Store store = CurrentStore;
            if (store != null)
            {
                if (store.CountryID != OldCountryId)
                {
                    OnChangeCountry(store.CountryID);
                }
            }
            LoadStoreWorlds();
            LoadHolidaysInfo();
            btn_Print.Enabled = true;
        }
        protected virtual void OnChangeCountry(long new_countryid)
        {
            if (new_countryid != OldCountryId)
            {
                OldCountryId = new_countryid;
                LoadCountryEnvironment();
            }
        }
        protected void OnChangeWorld(StoreToWorld sw)
        {
            if (sw != _currentworld)
            {
                _currentworld = sw;

                ApplyFilterByWorld();
            }
        }

        private void ApplyFilterByWorld()
        {
            BindingList<BzEmployeeHoliday> worldEmployeesList = null;
            if (_currentworld == null)
            {
                _currentworld = _emptyworld;
            }


            _indexEmployeeByWorld.TryGetValue(_currentworld.ID, out worldEmployeesList);


            if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
            {
                if (_currentworld != _emptyworld)
                {
                    BindingList<BzEmployeeHoliday> filteredEmployeesList = new BindingList<BzEmployeeHoliday>();
                    if (worldEmployeesList != null)
                    {
                        DateTime sunday = CurrentMondayDate.AddDays(6);
                        foreach (BzEmployeeHoliday entity in worldEmployeesList)
                        {
                            if (entity.Relations.IsExistsWorldAssignment(_currentworld, CurrentMondayDate, sunday))
                                filteredEmployeesList.Add(entity);
                        }
                    }
                    worldEmployeesList = filteredEmployeesList;
                }
            }

            gcAbsencePlanning.DataSource = worldEmployeesList;

            BuildTotalSums();
        }

        public void LoadStoreWorlds()
        {
            Store store = CurrentStore;

            _ListStoreToWorld = null;

            if (store != null)
            {
                _ListStoreToWorld = ClientEnvironment.StoreToWorldService.FindAllForStore(store.ID);
            }

            if (_ListStoreToWorld != null)
            {
                _ListStoreToWorld.Sort(new StoreToWorldSorter());
                _ListStoreToWorld.Insert (0, _emptyworld);
            }

            storeworldControl.EntityList = _ListStoreToWorld;

        }

        public void LoadStoreList()
        {
            m_storesViewList = new StoreViewList();
            m_storesViewList.Init();
            m_storesViewList.LoadAll();

            lookUpEditStores.Properties.DataSource = m_storesViewList;

            if (m_storesViewList.Count == 1)
            {
                lookUpEditStores.EditValue = m_storesViewList[0].ID;
            }

            //lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
            gridColumn_Country.GroupIndex = 0;
            gridColumn_Region.GroupIndex = 1;
            lookUpEditStores.Properties.View.ExpandAllGroups();

        }

        private void LoadCountryEnvironment()
        {
            if (_absencemanager == null)
                _absencemanager = new AbsenceManager(ClientEnvironment.AbsenceService, CurrentCountryId);

            _absencemanager.CountryId = CurrentCountryId;

            if (_longabsencesmanager == null)
                _longabsencesmanager = new LongTimeAbsenceManager(ClientEnvironment.LongTimeAbsenceService);

            _longabsencesmanager.CountryId = CurrentCountryId;

            BuildQuickAbsenceMenus();
        }

        private void ClearContext()
        {
            gcAbsencePlanning.DataSource = null;
            _query = null;
            if (_EmployeesList != null)
                _EmployeesList.Clear();

            if (_indexIdToEntity != null)
                _indexIdToEntity.Clear();

            if (_indexEmployeeByWorld != null)
                _indexEmployeeByWorld.Clear();

            _currentworld = null;
            _ids_absences_from_server = null;
            Modified = false;
            BuildTotalSums();
        }

        private void LoadHolidaysInfo()
        {
            Store store = CurrentStore;
            ClearContext();
            if (store != null)
            {
                _query = ClientEnvironment.EmployeeService.EmployeeTimeService.GetAllAbsencePlanning(store.ID, store.CountryID, Year, DateTime.Today);
                IsAustria = CurrentCountryId == ClientEnvironment.CountryService.AustriaCountryID;

                btn_TakeFromPrevYear.Enabled = !IsAustria && (Year >= _TodayYear)  && UserCanEdit ;
                if (_query != null && ProcessErrorQuery(_query))
                {
                    ProcessQuery(_query);

                    _currentworld = storeworldControl.CurrentEntity;
                    if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView )
                        OnChangeWeek();
                    else 
                        ApplyFilterByWorld();

                    ShowCurrentColumn();
                }
            }

        }

        private bool ProcessErrorQuery(AbsencePlanningQuery query)
        {
            if (query != null)
            {
                StringBuilder sb = new StringBuilder();

                if (query.AvgDaysPerWeek <= 0)
                {
                    sb.AppendLine(GetLocalized("NotExistsAvgDaysPerWeek"));
                }

                if (query.StoreDays == null || query.StoreDays.IsUndefined())
                {
                    sb.AppendLine(GetLocalized("NotExistsOpenTime"));
                }

                if (sb.Length > 0)
                {
                    string message = sb.ToString();
                    ErrorMessage(message, GetLocalized("Attention"));
                    return false;
                }
                return true;
            }
            else return false;
        }

        private void ProcessQuery(AbsencePlanningQuery query)
        {
            gcAbsencePlanning.DataSource = null;
            if (query == null) return;

            if (_absencemanager == null) return;

            if (query.Plannings != null && query.Plannings.Count > 0)
                _absencemanager.FillAbsencePlanningTimes(query.Plannings);

            if (query.Recordings != null && query.Recordings.Count > 0)
                _absencemanager.FillAbsenceRecordingTimes(query.Recordings);

            if (query.Longabsences != null && query.Longabsences.Count > 0)
                _longabsencesmanager.FillEmployeelongAbsences(query.Longabsences);

            

            ShowHideColumnForAustria();
            DictionListEmployeesContract c_indexer = null;
            if (query.Contracts != null)
            {
                c_indexer = new DictionListEmployeesContract(query.Contracts);
            }
            DictionListEmployeeRelations r_indexer = null;
            if (query.Relations != null)
            {
                r_indexer = new DictionListEmployeeRelations(query.Relations);
            }

            List<long> ids = new List<long>();

            if (query.Plannings != null)
            {
                foreach (AbsenceTimePlanning a in query.Plannings)
                    ids.Add(a.ID);
            }

            ids.Sort();
            _ids_absences_from_server = ids.ToArray();

            Dictionary<long, BzEmployeeHoliday> _index = new Dictionary<long, BzEmployeeHoliday>();
            if (query._holidays != null)
            {
                foreach (BzEmployeeHoliday e in query._holidays)
                    _index[e.EmployeeId] = e;

                List<EmployeeRelation> relations = null;
                List<EmployeeContract> contracts = null;
                foreach (BzEmployeeHoliday e in query._holidays)
                {
                    e.AvgDayInWeek = query.AvgDaysPerWeek;
                    e.IsAustria = IsAustria;
                    e.HwgrName = GetHwgrName(e.HwgrId);
                    if (r_indexer != null)
                        relations = r_indexer[e.EmployeeId];
                    if (c_indexer != null)
                        contracts = c_indexer[e.EmployeeId];
                    if (relations != null)
                        e.AddRelation(relations);
                    if (contracts != null)
                        e.AddContract(contracts);

                    if (query.Plannings != null)
                    {
                        foreach (AbsenceTimePlanning a in query.Plannings)
                        {
                            if (a.EmployeeID == e.EmployeeId)
                                e.AddAbsences(a);
                        }
                    }
                    if (query.Recordings != null)
                    {
                        foreach (AbsenceTimeRecording a in query.Recordings)
                        {
                            if (a.EmployeeID == e.EmployeeId)
                                e.AddAbsences(a);
                        }
                    }

                    if (query.Longabsences != null)
                    {
                        foreach (EmployeeLongTimeAbsence a in query.Longabsences)
                        {
                            if (a.EmployeeID == e.EmployeeId)
                            {
                                e.AddLongAbsence(a);
                            }
                        }
                    }
                    e.BuildWeeks();

                    if (_ListStoreToWorld != null)
                    {
                        foreach (StoreToWorld sw in _ListStoreToWorld)
                        {
                            if (sw == _emptyworld)// all worlds
                            {
                                continue;
                            }
                            if (e.Relations != null && e.Relations.IsExistsWorldAssignment(sw))
                            {
                                if (!_indexEmployeeByWorld.ContainsKey(sw.ID))
                                {
                                    _indexEmployeeByWorld[sw.ID] = new BindingList<BzEmployeeHoliday>();
                                }
                                _indexEmployeeByWorld[sw.ID].Add(e);
                            }
                        }

                        
                    }
                }
                _EmployeesList = null;
                _EmployeesList = new BindingList<BzEmployeeHoliday>(query._holidays);

                _indexEmployeeByWorld[_emptyworld.ID] = _EmployeesList;

            }



        }


        private void BuildDeltaForAbsences()
        {
            // build list of not new absences
            // do sub of set (ids from server and current id => ids deleted absences
            if (_EmployeesList != null)
            {
                List<long> ids = new List<long>();
                _list_New_Abences = new AbsenceTimeRangeList(20);
                foreach (BzEmployeeHoliday e in _EmployeesList)
                {
                    if (e.Absences != null)
                    {
                        ids.AddRange(e.Absences.GetIds());

                        List<AbsenceTimeRange> ls = e.Absences.GetNewEntities();
                        if (ls != null)
                            _list_New_Abences.AddRange(ls);
                    }
                }

                ids.Sort();
                List<long> deletedIds = new List<long>();
                // acpro item: 125506 - Absence Planning => Abences not deleted
                // shorj: what for ids.count should be >0 ?
                if (/*ids.Count > 0 && */_ids_absences_from_server.Length > 0)
                {
                    foreach (long id in _ids_absences_from_server)
                    {
                        if (id != 0 && ids.BinarySearch(id) < 0)
                        {
                            deletedIds.Add(id);
                        }
                    }
                }
                _ids_removed_absences  = deletedIds.ToArray();
            }
            
        }

        private void BuildResponse()
        {
            if (!Modified) return;

            _response = new AbsencePlanningResponse();
            _response.Year = Year;
            _response.StoreID = this.CurrentStore.ID;

            BuildDeltaForAbsences();

            _response.DeletedIds = _ids_removed_absences;
            _response.NewAbsences = _list_New_Abences.ToArray ();

            if (_EmployeesList != null)
            {
                List<EmployeeHolidaysInfo> lst = new List<EmployeeHolidaysInfo>();
                foreach (BzEmployeeHoliday entity in _EmployeesList)
                {
                    if (entity.IsModified())
                    {
                        lst.Add(entity.UpdateEntity());
                    }
                }
                _response.ModifiedEntity = lst.ToArray();
            }

        }

        private void ShowCurrentColumn()
        {
            if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
            {
                foreach (BandedGridColumn column in gvAbsencePlanning.Columns)
                {
                    if (column.Tag != null)
                    {
                        WeekBandInfo info = column.Tag as WeekBandInfo;
                        if (info != null)
                        {
                            if (info.Week == DateTimeHelper.GetWeekNumber(DateTime.Today))
                            {
                                gvAbsencePlanning.MakeColumnVisible(column);
                                return;
                            }
                        }
                    }
                }
            }
        }

        #region Build columns

        private bool IsFixedColumn(BandedGridColumn column)
        {
            return _staticColumns.IndexOf(column) >= 0;
        }
        private bool IsFixedBand(GridBand band)
        {
            return (band == gridBandEmployee) || (band == gridBandInfo);
        }
        private void RemoveColumnsAndBands()
        {
            for (int i = gvAbsencePlanning.Columns.Count - 1; i >= 0; i--)
            {
                if (!IsFixedColumn(gvAbsencePlanning.Columns[i]))
                    gvAbsencePlanning.Columns.RemoveAt(i);
            }
            for (int i = gvAbsencePlanning.Bands.Count - 1; i >= 0; i--)
            {
                if (!IsFixedBand(gvAbsencePlanning.Bands[i]))
                    gvAbsencePlanning.Bands.RemoveAt(i);
            }
        }
        public void AssignNameOfMonth()
        {
            if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView)
            {
                foreach (BandedGridColumn column in gvAbsencePlanning.Columns)
                {
                    if (column.Tag != null)
                    {
                        MonthBandInfo monthinfo = column.Tag as MonthBandInfo;
                        if (monthinfo != null)
                            column.Caption = GetColumnCaption(monthinfo);
                    }
                }
            }
            if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
            {
                foreach (GridBand band in gvAbsencePlanning.Bands)
                {
                    if (band.Tag != null)
                    {
                        MonthBandInfo monthinfo = band.Tag as MonthBandInfo;
                        if (monthinfo != null)
                            band.Caption = GetColumnCaption(monthinfo);
                    }
                }
            }

        }
        private void BuildYearlyColumns()
        {
            try
            {
                gvAbsencePlanning.BeginDataUpdate();
                RemoveColumnsAndBands();
                gvAbsencePlanning.OptionsView.ColumnAutoWidth = false;
                for (int i = 0; i < 12; i++)
                {
                    GridBand band = gvAbsencePlanning.Bands.AddBand(i.ToString());
                    band.MinWidth = 100;
                    band.Name = "band1_" + i;
                    band.OptionsBand.AllowSize = true;
                    band.OptionsBand.AllowMove = false;
                    band.OptionsBand.AllowHotTrack = false;
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    band.Caption = MonthsName.GetName(i + 1);
                    band.Tag = new MonthBandInfo(i + 1);

                    int[] weeks = _yearwrapper.GetWeekNumbersByMonths(i + 1);

                    band.Width = weeks.Length * YEARLY_COLUMN_WIDTH+4;

                    BandedGridColumn column = null;
                    DateTime monday, sunday;
                    for (int ii = 0; ii < weeks.Length; ii++)
                    {
                        _yearwrapper.GetWeekDateRange(weeks[ii], out monday, out sunday);
                        column = new BandedGridColumn();
                        column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        column.Caption = weeks[ii].ToString();
                        column.ToolTip = String.Format("{0} - {1}", monday.ToShortDateString(), sunday.ToShortDateString());
                        column.AutoFillDown = true;
                        column.Width = YEARLY_COLUMN_WIDTH;
                        column.MinWidth = YEARLY_COLUMN_WIDTH;
                        column.OptionsColumn.AllowEdit = false;
                        column.OptionsColumn.ReadOnly = true;
                        column.OptionsFilter.AllowAutoFilter = false;
                        column.OptionsFilter.AllowFilter = false;
                        column.OptionsFilter.AllowAutoFilter = false;
                        column.OptionsColumn.ShowInCustomizationForm = false;
                        column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        column.OptionsColumn.AllowMove = false;
                        column.OptionsColumn.AllowSize = true;

                        column.Visible = true;

                        band.Columns.Add(column);

                        column.Tag = new WeekBandInfo(weeks[ii]);
                        column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        column.SummaryItem.Tag = column.Tag;
                    }
                }
            }
            finally
            {
                gvAbsencePlanning.EndDataUpdate();
            }
        }
        private void BuildMonthlyColumns()
        {
            RemoveColumnsAndBands();
            gvAbsencePlanning.BeginDataUpdate();
            try
            {
                gvAbsencePlanning.OptionsView.ColumnAutoWidth = false;
                GridBand band = gvAbsencePlanning.Bands.AddBand(Year.ToString());
                band.OptionsBand.AllowSize = true;
                band.OptionsBand.AllowMove = false;
                band.OptionsBand.AllowHotTrack = false;
                band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                band.Caption = Year.ToString();
                band.Width = MONTHLY_COLUMN_WIDTH * 12;
                //band.Tag = 100;
                string caption;
                BandedGridColumn column = null;
                BandInfo info = null;
                List<BandedGridColumn> columns = new List<BandedGridColumn>();
                for (int i = 0; i < 12; i++)
                {
                    info = new MonthBandInfo(i + 1);
                    caption = GetColumnCaption(info);
                    column = new BandedGridColumn();
                    column.AppearanceHeader.Options.UseTextOptions = true;
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column.Caption = caption;
                    column.AutoFillDown = true;
                    column.Width = MONTHLY_COLUMN_WIDTH;
                    column.MinWidth = 40;
                    column.OptionsColumn.AllowEdit = false;
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsFilter.AllowAutoFilter = false;
                    column.OptionsFilter.AllowFilter = false;
                    column.OptionsFilter.AllowAutoFilter = false;
                    column.OptionsColumn.ShowInCustomizationForm = false;
                    column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    column.OptionsColumn.AllowMove = false;
                    column.Visible = true;
                    column.Tag = info;
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    column.SummaryItem.Tag = column.Tag;
                    gvAbsencePlanning.Columns.Add(column);
                    columns.Add(column);
                    band.Columns.Add(column);

                }
                foreach (BandedGridColumn c in columns)
                    c.Width = 80;
            }
            finally
            {
                gvAbsencePlanning.EndDataUpdate();
            }
        }
        private void BuildWeeklyColumns()
        {
            try
            {
                gvAbsencePlanning.BeginDataUpdate();
                RemoveColumnsAndBands();

                DateTime monday = CurrentMondayDate ;
                DateTime sunday = DateTimeHelper.GetSunday(monday);

                BandedGridColumn column = null;
                string caption;
                DateTime date;
                BandInfo info = null;
                for (int i = 0; i < 7; i++)
                {
                    date = monday.AddDays(i);
                    GridBand band = gvAbsencePlanning.Bands.AddBand(String.Format("{0}", GetLocalized(date.DayOfWeek.ToString())));
                    band.OptionsBand.AllowSize = true;
                    band.OptionsBand.AllowMove = false;
                    band.OptionsBand.AllowHotTrack = false;
                    band.AppearanceHeader.Options.UseTextOptions = true;
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    band.Width = 100;
                    band.MinWidth = 50;


                    info = new DayBandInfo(date);

                    caption = GetColumnCaption(info);// String.Format("{0}\n {2}\n {1}", GetLocalized(sd.Date.DayOfWeek.ToString()), DateTimeHelper.ShortTimeRangeToStr(sd.OpenTime, sd.CloseTime), sd.Date.ToShortDateString());

                    column = new BandedGridColumn();
                    column.AppearanceHeader.Options.UseTextOptions = true;
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.Caption = caption;
                    column.ToolTip = GetLocalized(date.DayOfWeek.ToString());
                    column.AutoFillDown = true;
                    column.Width = 40;
                    column.MinWidth = 40;
                    column.OptionsColumn.AllowEdit = false;
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsFilter.AllowAutoFilter = false;
                    column.OptionsFilter.AllowFilter = false;
                    column.OptionsFilter.AllowAutoFilter = false;
                    column.OptionsColumn.ShowInCustomizationForm = false;
                    column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    column.OptionsColumn.AllowMove = false;
                    column.Visible = true;
                    band.Columns.Add(column);
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //column.Width = 100;
                    column.Tag = info;
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    column.SummaryItem.Tag = column.Tag;
                }
                gvAbsencePlanning.OptionsView.ColumnAutoWidth = true;
            }
            finally
            {
                gvAbsencePlanning.EndDataUpdate();
            }
        }
        private string GetColumnCaption(BandInfo info)
        {
            if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView || ViewAbsencePlanning == AbsencePlanningView.YearlyView)
            {
                MonthBandInfo monthinfo = info as MonthBandInfo;
                if (monthinfo != null)
                    return MonthsName.GetName(monthinfo.Month);
            }
            if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
            {
                DayBandInfo dayinfo = info as DayBandInfo;
                if (dayinfo != null)
                {
                    if (_query != null && _query.StoreDays != null && _query.StoreDays.ContainsKey(dayinfo.Date))
                    {
                        StoreDay sd = _query.StoreDays[dayinfo.Date];

                        return String.Format("{0}\n {1}", sd.Date.ToShortDateString(), DateTimeHelper.ShortTimeRangeToStr(sd.OpenTime, sd.CloseTime));
                    }
                    else
                    {
                        return String.Format("{0}", dayinfo.Date.ToShortDateString());
                    }
                }
                
            }
            return String.Empty;
        }


        private void ShowHideColumnForAustria()
        {
            if (IsAustria && gc_NewHolidays.Visible == false) return;

            if (IsAustria)
            {
                gc_NewHolidays.Visible =
                    gc_OldHolidays.Visible = gc_AvailableHolidays.Visible = false;

                gridBandInfo.Columns.MoveTo(0, gc_SpareHolidaysExc);
                gridBandInfo.Columns.MoveTo(1, gc_UsedHolidays);
                gridBandInfo.Columns.MoveTo(2, gc_SpareHolidaysInc);
            }
            else
            {
                gc_NewHolidays.Visible =
                    gc_OldHolidays.Visible = gc_AvailableHolidays.Visible = true;
                
                gridBandInfo.Columns.MoveTo(0, gc_UsedHolidays);
                gridBandInfo.Columns.MoveTo(1, gc_SpareHolidaysExc);
                gridBandInfo.Columns.MoveTo(2, gc_SpareHolidaysInc);
            }
        }

        #endregion

        private void BuildTotalSums()
        {
            for (int i = 0; i < _total_sum_by_weeks.Length; i++)
            {
                _total_sum_by_weeks[i] = 0;
            }
            for (int i = 0; i < _total_sum_by_months.Length; i++)
            {
                _total_sum_by_months[i] = 0;
            }
            for (int i = 0; i < _total_sum_by_days.Length; i++)
            {
                _total_sum_by_days[i] = 0;
            }


            IList lst = gcAbsencePlanning.DataSource as IList;

            if (lst != null)
            {
                foreach (BzEmployeeHoliday entity in lst)
                    entity.FillTotalSums(_total_sum_by_weeks, _total_sum_by_months);

                if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
                {
                    int week = DateTimeHelper.GetWeekNumber(CurrentMondayDate);
                    foreach (BzEmployeeHoliday entity in lst)
                        entity.GetWeek(week).FillDaysSum(_total_sum_by_days);// FillTotalSums(_total_sum_by_weeks, _total_sum_by_months);
                }
                
            }
            gvAbsencePlanning.UpdateTotalSummary();
            
        }

        private void BuildQuickAbsenceMenus()
        {
            if (_absencemanager == null || _absencemanager.Count == 0)
            {
                menuItem_QuickAddAbsence.Visible = false;
                menuItemSeparatorQuick.Visible = false;
                menuItem_QuickAddAbsence.DropDownItems.Clear();
            }
            else
            {
                menuItem_QuickAddAbsence.Visible = false;
                menuItem_QuickAddAbsence.DropDownItems.Clear();
                EventHandler handler = new EventHandler(RuntimeMenuItemAbsence_Click);
                if (!UserCanEdit) return;
                List<Absence> lst = _absencemanager.ToList;
                foreach (Absence a in lst)
                {
                    if (a.AbsenceTypeID == AbsenceType.Holiday && a.IsFixed)
                    {
                        ToolStripMenuItem newItem = new ToolStripMenuItem(a.Name + "    (" + a.CharID + ')');
                        newItem.Tag = a;
                        newItem.Click += handler;
                        menuItem_QuickAddAbsence.DropDownItems.Add(newItem);
                    }
                }
                
                menuItemSeparatorQuick.Visible = menuItem_QuickAddAbsence.Visible = menuItem_QuickAddAbsence.DropDownItems.Count > 0;
            }
        }


        private void ProcessAbsence(Absence absence)
        {
            Debug.Assert(absence != null);
            if (absence == null) return;
            BzEmployeeHoliday employeeentity = GetFocusedEntity();

            List<DateTime> lstDates = CreateDateListFromSelectedRange();

            employeeentity.CheckDates(lstDates);

            Debug.Assert(employeeentity != null);
            if (employeeentity == null) return;



            if (lstDates != null && lstDates.Count > 0)
            {
                List<AbsenceTimeRange> newAbsences = new List<AbsenceTimeRange>();

                StoreDay storeday = null;
                AbsenceTimeRange absencetime = null;

                foreach (DateTime date in lstDates)
                {
                    storeday = _query.StoreDays[date];
                    Debug.Assert(storeday != null);

                    absencetime = new AbsenceTimeRange();
                    absencetime.ID = ClientEnvironment.AbsenceTimePlanningService.CreateEntity().ID;
                    absencetime.Date = date;
                    absencetime.AbsenceID = absence.ID;
                    absencetime.EmployeeID = employeeentity.EmployeeId;
                    absencetime.Absence = absence;
                    absencetime.Begin = storeday.OpenTime;
                    //absencetime.End = (short)(absencetime.Begin + DateTimeHelper.RoundToQuoter(employeeentity.GetAvgWorkingHourADay(date)));
                    absencetime.End = (short)(absencetime.Begin + employeeentity.GetAvgWorkingHourADay(date));
                    absencetime.Time = employeeentity.GetAbsenceTimeAsDay(absence, date, (absencetime.End - absencetime.Begin));


                    newAbsences.Add(absencetime);
                }
                if (newAbsences.Count > 0)
                {
                    employeeentity.SetAbsence(newAbsences);

                    BuildTotalSums();
                    gvAbsencePlanning.RefreshRow(gvAbsencePlanning.FocusedRowHandle);
                    Modified = true;
                }
            }
        }

        void RuntimeMenuItemAbsence_Click(object sender, EventArgs e)
        {
            if (sender == null) return;

            ToolStripMenuItem item = (sender as ToolStripMenuItem);

            Debug.Assert(item != null);

            Absence absence = (sender as ToolStripMenuItem).Tag as Absence;

            Debug.Assert(absence != null);

            if (absence == null) return;

            ProcessAbsence(absence);
        }

        private void lookUpEditStores_EditValueChanged(object sender, EventArgs e)

        {
            if (CurrentStore != null)
            {
                OnChangeStore();
                
            }
        }

        private void cmAbsencePlanning_Opening(object sender, CancelEventArgs e)
        {
            List<DateTime> dates = CreateDateListFromSelectedRangeForDelete();


            bool bSingleLine = (gvAbsencePlanning.SelectedRowsCount == 1);
            menuItem_AddAbsences.Enabled = UserCanEdit && gvAbsencePlanning.RowCount > 0 && AllowEdit && bSingleLine && (dates.Count > 0);
            menuItem_AddLongTimeAbsence.Enabled = UserCanEdit && gvAbsencePlanning.RowCount > 0 && AllowEdit && bSingleLine && (dates.Count > 0);
            menuItem_DeleteAbsences.Enabled = UserCanEdit && bSingleLine && AllowEdit && (dates.Count > 0);
            menuItem_QuickAddAbsence.Enabled = UserCanEdit && (menuItem_QuickAddAbsence.DropDownItems.Count > 0) && AllowEdit && bSingleLine && (dates.Count > 0);
            menuitem_ShowHWGR.Checked = ShowHWGR;
        }


        #region actions

        private List<DateTime> BuildDateListFromDateRange(DateTime a, DateTime b)
        {
            List<DateTime> dates = new List<DateTime>();

            for (DateTime d = a; d <= b;  d = d.AddDays(1))
            {
                dates.Add(d);
            }
            return dates;
        }

        private List<DateTime> FilterDateList(List<DateTime> inputDates, bool ignoreFeast, bool ignoreClosed, List<BaumaxDayOfWeek> days)
        {
            if (inputDates == null || inputDates.Count == 0) return null;

            List<DateTime> outputList = new List<DateTime>();
            StoreDay sd = null;
            BaumaxDayOfWeek dayofweek;
            bool bExistsDay = false;
            foreach (DateTime date in inputDates)
            {
                if (ignoreFeast || ignoreClosed)
                {
                    if (_query.StoreDays.TryGetValue(date, out sd))
                    {
                        if ((sd.Feast && ignoreFeast) || (sd.ClosedDay && ignoreClosed)) continue;

                    }
                    else continue;
                }
                if (days != null && days.Count > 0)
                {
                    dayofweek = DateTimeHelper.ConvertWindowsToBaumaxDayOfWeek(date.DayOfWeek);
                    bExistsDay = false;
                    foreach (BaumaxDayOfWeek b in days)
                    {
                        if (b == dayofweek)
                        {
                            bExistsDay = true;
                            break;
                        }
                    }
                    if (bExistsDay) continue;
                }

                outputList.Add(date);
                
            }

            return outputList;

        }

        private List<DateTime> PrepareDateList(DateTime a, DateTime b, bool ignoreFeast, bool ignoreClosed, List<BaumaxDayOfWeek> days)
        {
            List<DateTime> dates = BuildDateListFromDateRange(a, b);

            if (dates == null || dates.Count == 0) return null;

            return FilterDateList(dates, ignoreFeast, ignoreClosed, days);
        }
        
        protected virtual void OnAddAbsence()
        {
            if (Year < _TodayYear) return;

            BzEmployeeHoliday employeeentity = GetFocusedEntity();
            if (employeeentity == null) return;


            

            DateTime minDate = _yearwrapper.BeginYearDate;
            DateTime maxDate = _yearwrapper.EndYearDate;

            if (Year == _TodayYear)
            {
                minDate = DateTime.Today;
            }

            List<DateTime> lstDates = CreateDateListFromSelectedRange();
            lstDates.Sort();

            SelectAbsenceForm dialog = new SelectAbsenceForm();
            dialog.SetMinMaxDate(minDate, maxDate);

            if (lstDates != null && lstDates.Count > 0)
            {
                dialog.BeginDate = lstDates[0];
                dialog.EndDate = lstDates[lstDates.Count - 1];
            }
            else
            {
                dialog.BeginDate = minDate ;
                dialog.EndDate = minDate.AddDays (7);
            }

            StoreDay sd = _query.StoreDays[dialog.BeginDate];

            dialog.SetOpenCloseTime(sd.OpenTime, sd.CloseTime);

            dialog.AbsenceList = _absencemanager.ToList;

            if (dialog.Execute())
            {
                List<DateTime> dates = PrepareDateList(dialog.BeginDate, dialog.EndDate, dialog.IgnoreFeast, dialog.IgnoreClosedDay, dialog.IgnoredDays);
                employeeentity.CheckDates(dates);

                Absence absence = dialog.SelectedAbsence;
                if (dates != null && dates.Count > 0)
                {
                    List<AbsenceTimeRange> newAbsences = new List<AbsenceTimeRange>();
                    
                    StoreDay storeday = null;
                    AbsenceTimeRange absencetime = null;

                    foreach (DateTime date in dates)
                    {
                        storeday = _query.StoreDays[date];
                        Debug.Assert(storeday != null);

                        absencetime = new AbsenceTimeRange();
                        absencetime.ID = ClientEnvironment.AbsenceTimePlanningService.CreateEntity().ID;
                        absencetime.Date = date;
                        absencetime.Absence = absence;
                        absencetime.AbsenceID = absence.ID;
                        absencetime.EmployeeID = employeeentity.EmployeeId;

                        if (absence.IsFixed)
                        {
                            storeday = _query.StoreDays[date];
                            absencetime.Begin = storeday.OpenTime;
                            absencetime.End = (short)(absencetime.Begin + employeeentity.GetAvgWorkingHourADay(date));//DateTimeHelper.RoundToQuoter(employeeentity.GetAvgWorkingHourADay(date)));

                        }
                        else if (absence.Value != 0)
                        {
                            absencetime.Begin = storeday.OpenTime;
                            absencetime.End = (short)(absencetime.Begin + DateTimeHelper.RoundToQuoter((int)(absence.Value*60)));
                        }
                        else
                        {
                            absencetime.Begin = DateTimeHelper.RoundToQuoter(dialog.BeginTime);
                            absencetime.End = DateTimeHelper.RoundToQuoter(dialog.EndTime);
                            
                        }
                        absencetime.Time = employeeentity.GetAbsenceTimeAsDay(absencetime.Absence, date, (absencetime.End - absencetime.Begin));
                        

                        newAbsences.Add(absencetime);
                    }
                    if (newAbsences.Count > 0)
                    {
                        employeeentity.SetAbsence(newAbsences);

                        BuildTotalSums();
                        gvAbsencePlanning.RefreshRow(gvAbsencePlanning.FocusedRowHandle);
                        Modified = true;
                    }
                }
            }

            dialog.Dispose();
        }
        protected virtual void OnAddLongAbsence()
        {
        }
        protected virtual void OnDeleteAbsence()
        {

            if (!UserCanEdit || !AllowEdit) return;

            BzEmployeeHoliday entity = GetFocusedEntity();
            if (entity == null) return;

            bool wasDeleted = false;

            if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView)
            {
                int[] months = CreateMonthListFromSelectedRangeForDelete();
                if (months != null && months.Length > 0)
                {
                    wasDeleted = entity.DeleteMonthAbsences(months); ;
                }
            }

            if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
            {
                int[] weeks = CreateWeekListFromSelectedRangeForDelete();

                if (weeks != null && weeks.Length > 0)
                {
                    wasDeleted = entity.DeleteWeekAbsences(weeks);
                }
            }

            if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
            {
                List<DateTime> dates = CreateDateListFromSelectedRangeForDelete();
                if (dates != null && dates.Count > 0)
                {
                    wasDeleted = entity.DeleteAbsences(dates);
                }
            }

            if (wasDeleted)
            {
                gvAbsencePlanning.RefreshRow(gvAbsencePlanning.FocusedRowHandle);
                BuildTotalSums();
                Modified = true;
            }

        }

        protected virtual void OnAddQuickAbsence(MenuItem menuitem)
        {
        }


        #endregion


        BzEmployeeHoliday GetEntityByRowHandle(int rowHandle)
        {
            BzEmployeeHoliday entity = null;
            if (gvAbsencePlanning.IsDataRow(rowHandle))
            {
                entity = gvAbsencePlanning.GetRow(rowHandle) as BzEmployeeHoliday;
            }

            return entity;
        }

        BzEmployeeHoliday GetFocusedEntity()
        {

            return GetEntityByRowHandle(gvAbsencePlanning.FocusedRowHandle);
        }

        bool IsFocusedCell(int row, GridColumn column)
        {
            return gvAbsencePlanning.FocusedRowHandle == row &&
                gvAbsencePlanning.FocusedColumn == column;
        }

        private void DrawDisableCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            HatchBrush brush = new HatchBrush(HatchStyle.DiagonalCross, Color.LightGray, Color.White);
            try
            {
                Rectangle rec = Rectangle.Inflate(e.Bounds, -1, -1);
                e.Cache.DrawRectangle(e.Cache.GetPen(Color.LightGray), e.Bounds);
                e.Cache.FillRectangle(brush, rec);
            }
            finally
            {
                brush.Dispose();
            }
        }
        private void DrawLongAbsenceCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e, Color absence_color, string text)
        {
            HatchBrush brush = new HatchBrush(HatchStyle.Cross , Color.LightGray, absence_color);
            try
            {
                Rectangle rec = Rectangle.Inflate(e.Bounds, -1, -1);
                e.Cache.DrawRectangle(e.Cache.GetPen(Color.LightGray), e.Bounds);
                e.Cache.FillRectangle(brush, rec);
                e.Cache.DrawString(text, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds, e.Appearance.TextOptions.GetStringFormat());
            }
            finally
            {
                brush.Dispose();
            }
        }
        private void DrawWeekCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e, HolidayWeekInfo weekinfo)
        {
            bool bFocused = gvAbsencePlanning.IsCellSelected(e.RowHandle, e.Column);

            Color color = weekinfo.WeekColor;
            string value = weekinfo.Value;

            if (bFocused)
                color = Color.LightBlue;

            e.Appearance.BackColor = e.Appearance.BackColor2 = color;
            e.Cache.FillRectangle(e.Cache.GetSolidBrush(color), e.Bounds);
            e.Cache.DrawString(value, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds, e.Appearance.TextOptions.GetStringFormat());
            e.Handled = true;


        }

        private void DrawMonthCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e, HolidayMonthInfo monthinfo)
        {
            bool bFocused = gvAbsencePlanning.IsCellSelected(e.RowHandle, e.Column);

            Color color = monthinfo.MonthColor;
            string value = monthinfo.Value;

            if (bFocused)
                color = Color.LightBlue;

            e.Appearance.BackColor = e.Appearance.BackColor2 = color;
            e.Cache.FillRectangle(e.Cache.GetSolidBrush(color), e.Bounds);
            e.Cache.DrawString(value, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds, e.Appearance.TextOptions.GetStringFormat());
            e.Handled = true;
        }

        private void DrawWeekCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e, HolidayWeekInfo weekinfo, DateTime date)
        {
            bool bFocused = gvAbsencePlanning.IsCellSelected(e.RowHandle, e.Column);

            EmployeeLongTimeAbsence absence = weekinfo.GetEmployeeLongTimeAbsence(date);

            if (absence != null)
            {
                
                if (bFocused)
                {
                    e.Cache.FillRectangle(Color.LightBlue, Rectangle.Inflate(e.Bounds, 1, 1));
                    e.Cache.DrawRectangle(e.Cache.GetPen(Color.Black), Rectangle.Inflate(e.Bounds, 1, 1));
                }
                else
                {

                    Color color = Color.FromArgb(absence.Absence.Color);
                    e.Cache.FillRectangle(e.Cache.GetSolidBrush(color), e.Bounds);
                    
                }
                e.Cache.DrawString(absence.Absence.CharID, e.Appearance.Font, e.Cache.GetSolidBrush(e.Appearance.ForeColor), e.Bounds, e.Appearance.TextOptions.GetStringFormat());
            }
            else
            {
                if (bFocused)
                {
                    e.Cache.FillRectangle(Color.LightBlue, Rectangle.Inflate(e.Bounds, 1, 1));
                    e.Cache.DrawRectangle(e.Cache.GetPen(Color.Black), Rectangle.Inflate(e.Bounds, 1, 1));
                }
                List<AbsenceTimeRange> lst = weekinfo.GetAbsencesByDate(date);

                if (lst != null && lst.Count > 0)
                {
                    Font cellfont = e.Appearance.Font;
                    Rectangle cellBound = Rectangle.Inflate(e.Bounds , -1, -1);
                    Brush cellbrush = Brushes.White;
                    Brush absenceBrush = null;
                    StringFormat sformat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces |
                                            StringFormatFlags.NoWrap);
                    cellbrush = Brushes.Black;
                    
                    string str = String.Empty;
                    int heightCell = (int)(cellBound.Height);// / 2);
                    foreach (AbsenceTimeRange range in lst)
                    {
                        str = TextParser.AbsenceTimeRangeToString(range.Begin, range.End,  range.Absence.CharID);

                        Size sf = e.Cache.CalcTextSize(str, cellfont, sformat, 10000).ToSize();

                        absenceBrush = e.Cache.GetSolidBrush(Color.FromArgb(range.Absence.Color));
                        e.Cache.DrawString(str, cellfont, absenceBrush, cellBound, sformat);

                        cellBound.Y += sf.Height + 2;
                        heightCell -= (sf.Height + 2);
                        if ((heightCell - (sf.Height + 2)) < 0) break;
                    }
                }
            }

            e.Handled = true;


        }

        private void DrawBackgroundWeekDayCell(StoreDay storeday, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (IsFocusedCell(e.RowHandle, e.Column))
            //{
            //    Pen focusedRectangleLine = e.Cache.GetPen(Color.Black);
            //    e.Cache.FillRectangle(Painters.FOCUSED_COLOR, Rectangle.Inflate(e.Bounds, 1, 1));
            //    e.Cache.DrawRectangle(focusedRectangleLine, Rectangle.Inflate(e.Bounds, 1, 1));
            //}
            //else
            {
                Color color = Painters.EMPTY_COLOR;
                if (storeday.Feast) color = Painters.FEAST_COLOR;
                if (storeday.ClosedDay) color = Painters.CLOSEDDAY_COLOR;
                e.Cache.FillRectangle(color, Rectangle.Inflate(e.Bounds, 1, 1));
            }

        }
        private void gvAbsencePlanning_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Tag == null)
            {
                e.Handled = false;
                return;
            }


            
            BzEmployeeHoliday entity = GetEntityByRowHandle(e.RowHandle);


            if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
            {
                WeekBandInfo info = e.Column.Tag as WeekBandInfo;

                if (info == null || entity == null) return;

                HolidayWeekInfo weekinfo = entity.GetWeek(info.Week);

                if (weekinfo.IsDisableWeek())
                {
                    DrawDisableCell(e);
                    e.Handled = true;
                }
                else
                {
                    DrawWeekCell(e, weekinfo);
                }
            }
            if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
            {
                DayBandInfo info = e.Column.Tag as DayBandInfo;
                if (info == null || entity == null) return;


                StoreDay storeday = _query.StoreDays[info.Date];

                DrawBackgroundWeekDayCell(storeday, e);

                HolidayWeekInfo weekinfo = entity.GetWeek(info.WeekNumber);

                if (weekinfo.IsDisableDay(info.Date))
                {
                    DrawDisableCell(e);
                    e.Handled = true;
                }
                else
                {
                    DrawWeekCell(e, weekinfo, info.Date);
                }
            }

            if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView)
            {
                MonthBandInfo info = e.Column.Tag as MonthBandInfo;
                if (info == null || entity == null) return;
                HolidayMonthInfo monthinfo = entity.GetMonth(info.Month);

                if (monthinfo.DisableMonth )
                {
                    DrawDisableCell(e);
                    e.Handled = true;
                }
                else
                {
                    DrawMonthCell(e, monthinfo);
                }
            }
        }

        private void gvAbsencePlanning_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BzEmployeeHoliday entity = GetEntityByRowHandle (e.RowHandle );
            if (entity != null)
            {
                if (entity.IsModified())
                    Modified = true;
                _EmployeesList.ResetItem(_EmployeesList.IndexOf(entity));
            }
        }


        private void ValidateSelectedCell()
        {

            if (gvAbsencePlanning.SelectedRowsCount > 1) return;

            GridCell[] cells = 
                gvAbsencePlanning.GetSelectedCells();
            
            if (cells == null) return;

            if (cells.Length == 1 && IsFocusedCell(cells[0].RowHandle, cells[0].Column) ) return;

            BzEmployeeHoliday entity = null;
            foreach (GridCell cell in cells)
            {
                entity = GetEntityByRowHandle(cell.RowHandle);

                if (entity == null) continue;

                if (cell.Column.Tag != null)
                {
                    WeekBandInfo weekinfo = cell.Column.Tag as WeekBandInfo;

                    if (weekinfo != null)
                    {
                        HolidayWeekInfo week = entity.GetWeek(weekinfo.Week);

                        if (week != null)
                        {
                            if (week.IsDisableWeek() || (week.MondayDate < DateTime.Today))
                            {
                                if (!IsFocusedCell (cell.RowHandle , cell.Column ))
                                    gvAbsencePlanning.UnselectCell(cell);
                            }
                        }
                    }
                }
            }
        }


        private int[] CreateWeekListFromSelectedRangeForDelete()
        {
            List<int> weeks = new List<int>();


            if (gvAbsencePlanning.SelectedRowsCount > 1) return weeks.ToArray ();

            GridCell[] cells =
               gvAbsencePlanning.GetSelectedCells();

            if (cells != null)
            {
                foreach (GridCell cell in cells)
                {
                    if (cell.Column.Tag != null)
                    {
                        WeekBandInfo weekinfo = cell.Column.Tag as WeekBandInfo;
                        if (weekinfo == null) continue;

                        weeks.Add(weekinfo.Week);
                    }
                }
            }
            weeks.Sort();

            return weeks.ToArray ();
        }
        private int[] CreateMonthListFromSelectedRangeForDelete()
        {
            List<int> months = new List<int>();


            if (gvAbsencePlanning.SelectedRowsCount > 1) return months.ToArray();

            GridCell[] cells =
               gvAbsencePlanning.GetSelectedCells();

            if (cells != null)
            {
                foreach (GridCell cell in cells)
                {
                    if (cell.Column.Tag != null)
                    {
                        MonthBandInfo info = cell.Column.Tag as MonthBandInfo;
                        if (info == null) continue;

                        months.Add(info.Month);
                    }
                }
            }
            months.Sort();

            return months.ToArray();
        }
        private List<DateTime> CreateDateListFromSelectedRangeForDelete()
        {
            List<DateTime> dates = new List<DateTime>();


            if (gvAbsencePlanning.SelectedRowsCount > 1) return dates;

            GridCell[] cells =
               gvAbsencePlanning.GetSelectedCells();

            if (cells != null)
            {
                foreach (GridCell cell in cells)
                {
                    if (cell.Column.Tag != null)
                    {
                        if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
                        {
                            WeekBandInfo weekinfo = cell.Column.Tag as WeekBandInfo;
                            if (weekinfo == null) continue;
                            DateTime monday, sunday, date;
                            DateTimeHelper.GetDateRangeByWeekNumber(weekinfo.Week, Year, out monday, out sunday);
                            for (int i = 0; i < 7; i++)
                            {
                                date = monday.AddDays(i);
                                if (date >= DateTime.Today)
                                    dates.Add(date);
                            }
                            continue;
                        }
                        if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView)
                        {
                            MonthBandInfo monthinfo = cell.Column.Tag as MonthBandInfo;
                            if (monthinfo == null) continue;
                            DateTime monday, sunday;

                            DateTimeHelper.GetDateRangeByMonthNumber(Year, monthinfo.Month, out monday, out sunday);
                            for (DateTime date = monday; date <= sunday; date = date.AddDays(1))
                            {
                                if (date >= DateTime.Today && _query.StoreDays[date].IsWorkingDay)
                                    dates.Add(date);
                            }
                            continue;
                        }
                        if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
                        {
                            DayBandInfo info = cell.Column.Tag as DayBandInfo;
                            if (info != null && info.Date >= DateTime.Today)
                                dates.Add(info.Date);
                            continue;
                        }
                    }
                }
            }
            dates.Sort();

            return dates;
        }

        private List<DateTime> CreateDateListFromSelectedRange()
        {
            List<DateTime> dates = new List<DateTime>();


            if (gvAbsencePlanning.SelectedRowsCount > 1) return dates;

            GridCell[] cells =
               gvAbsencePlanning.GetSelectedCells();

            if (cells != null)
            {
                foreach (GridCell cell in cells)
                {
                    if (cell.Column.Tag != null)
                    {
                        if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
                        {
                            WeekBandInfo weekinfo = cell.Column.Tag as WeekBandInfo;
                            if (weekinfo == null) continue;
                            DateTime monday, sunday, date;
                            DateTimeHelper.GetDateRangeByWeekNumber(weekinfo.Week, Year, out monday, out sunday);
                            for (int i = 0; i < 7; i++)
                            {
                                date = monday.AddDays(i);
                                if (date >= DateTime.Today && _query.StoreDays[date].IsWorkingDay)
                                    dates.Add(date);
                            }
                            continue;
                        }
                        if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView)
                        {
                            MonthBandInfo monthinfo = cell.Column.Tag as MonthBandInfo;
                            if (monthinfo == null) continue;
                            DateTime monday, sunday;

                            DateTimeHelper.GetDateRangeByMonthNumber(Year, monthinfo.Month , out monday, out sunday);
                            for (DateTime date = monday; date <= sunday; date = date.AddDays (1))
                            {
                                if (date >= DateTime.Today && _query.StoreDays[date].IsWorkingDay)
                                    dates.Add(date);
                            }
                            continue;
                        }
                        if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
                        {
                            DayBandInfo info = cell.Column.Tag as DayBandInfo;
                            if (info == null) continue;
                            if (info.Date >= DateTime.Today && _query.StoreDays[info.Date].IsWorkingDay)
                                dates.Add(info.Date);
                            continue;
                        }
                    }
                }
            }
            dates.Sort();

            return dates;
        }

        private void gvAbsencePlanning_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //ValidateSelectedCell();

        }

        private void deMonday_DateTimeChanged(object sender, EventArgs e)
        {
            DateTime date = DateTimeHelper.GetMonday(deMonday.DateTime);
            CurrentMondayDate = date;
            if (CurrentMondayDate != deMonday.DateTime)
                deMonday.DateTime = CurrentMondayDate;
            UpdateWeekNumber();
        }
        private void UpdateWeekNumber()
        {
            deMonday.Properties.Buttons[1].Caption = Convert.ToString(DateTimeHelper.GetWeekNumber(CurrentMondayDate));
        }

        private void menuItem_DeleteAbsence_Click(object sender, EventArgs e)
        {
            OnDeleteAbsence();
        }

        private void menuItem_YearlyView_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item != null && item.Tag != null)
            {
                AbsencePlanningView viewtype = (AbsencePlanningView)Convert.ToInt32(item.Tag);
                ViewAbsencePlanning = viewtype;
            }
        }

        private void storeworldControl_EditValueChanged(object sender, EventArgs e)
        {
            StoreToWorld sw = storeworldControl.CurrentEntity;

            if (sw != null)
            {
                OnChangeWorld(sw);
            }
        }

        private void gvAbsencePlanning_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (IsFixedColumn(e.Column as BandedGridColumn))
            {
                e.Handled = false;
                return;
            }
            double value = 0;
            if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
            {
                WeekBandInfo info = e.Column.Tag as WeekBandInfo;

                if (info != null)
                {
                    value = _total_sum_by_weeks[info.Week - 1];
                }
            }
            if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView)
            {
                MonthBandInfo info = e.Column.Tag as MonthBandInfo;
                if (info != null)
                {
                    value = _total_sum_by_months[info.Month - 1];
                }
            }
            if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
            {
                DayBandInfo info = e.Column.Tag as DayBandInfo;
                if (info != null)
                {
                    value = _total_sum_by_days[(int)info.Date.DayOfWeek];
                }
            }


            e.Info.DisplayText = String.Format("{0:F1}", Math.Round(value / 1440, 1));
            e.Handled = false;
        }

        private void deMonday_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Left)
            {
                if (DateTimeHelper.GetWeekNumber(CurrentMondayDate) == 1) return;
                CurrentMondayDate = CurrentMondayDate.AddDays(-7);
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Right)
            {
                int weekcount = _yearwrapper.CountOfWeek;

                if (DateTimeHelper.GetWeekNumber(CurrentMondayDate) == weekcount) return;
                CurrentMondayDate = CurrentMondayDate.AddDays(7);
            }
        }

        private void cbYears_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int y = Convert.ToInt32(cbYears.SelectedItem);

            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Up)
            {
                if (y+1 <= 2059)
                    cbYears.SelectedItem = ++y;
            }
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Down)
            {
                if (y - 1 >= 2000)
                    cbYears.SelectedItem = --y;
            }

        }

        private void cbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = Convert.ToInt32(cbYears.SelectedItem);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }

        private void gcAbsencePlanning_MouseClick(object sender, MouseEventArgs e)
        {
            BandedGridHitInfo hitinfo = gvAbsencePlanning.CalcHitInfo(e.Location);

            if (hitinfo.InColumn && hitinfo.Column != null && hitinfo.Column.Tag != null)
            {
                WeekBandInfo info = hitinfo.Column.Tag as WeekBandInfo;

                if (info != null && hitinfo.Column == _clickedColumn)
                {
                    //info.Week 
                    DateTime date = _yearwrapper.GetMondayByWeek(info.Week);

                    CurrentMondayDate = date;
                    ViewAbsencePlanning = AbsencePlanningView.WeeklyView;

                }
            }
        }

        private void menuItem_AddAbsence_Click(object sender, EventArgs e)
        {
            OnAddAbsence();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            using (FormPrintAbsencePlanning form = new FormPrintAbsencePlanning())
            {
                Dictionary<System.Reflection.PropertyInfo, bool> fieldSort = new Dictionary<System.Reflection.PropertyInfo, bool>();
                foreach (GridColumn col in gvAbsencePlanning.SortedColumns)
                    fieldSort.Add(typeof(BzEmployeeHoliday).GetProperty(col.FieldName), col.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending);
                
                form.Arguments = new AbsencePrintArgs(ViewAbsencePlanning, Year, storeworldControl.WorldId ,_ListStoreToWorld,
                                    _indexEmployeeByWorld, (long)lookUpEditStores.EditValue, lookUpEditStores.Text, storeworldControl.Text,
                                    _planningview == AbsencePlanningView.WeeklyView ? DateTimeHelper.GetWeekNumber(deMonday.DateTime)
                                                                                : DateTimeHelper.GetMonthNumberByDate(deMonday.DateTime), fieldSort, _bAustria);
                form.ShowDialog(ClientEnvironment.MainForm);
            }
        }

        private void sortByHWGRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHWGR = !ShowHWGR;
        }
        BandedGridColumn _clickedColumn = null;
        private void gvAbsencePlanning_MouseDown(object sender, MouseEventArgs e)
        {
            BandedGridHitInfo info = gvAbsencePlanning.CalcHitInfo(e.Location);

            if (info.InColumn)
                _clickedColumn = info.Column;
            else 
                _clickedColumn = null;

            if (e.Button == MouseButtons.Left && info.InColumn)
            {
                GridColumn column = info.Column;

                if (column == gc_HWGR || column == gc_Employee)
                {
                    column.SortMode = ColumnSortMode.DisplayText;
                    if (column.SortOrder == ColumnSortOrder.Ascending)
                        column.SortOrder = ColumnSortOrder.Descending;
                    else
                        column.SortOrder = ColumnSortOrder.Ascending;

                    if (column == gc_HWGR)
                        gvAbsencePlanning.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                                        {
                                                                            new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                                                                            new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                                                                        });
                    else
                        gvAbsencePlanning.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                                        {
                                                                            new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder),
                                                                            new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder)
                                                                        });
                }
            }
        }

        private void checkEdit_ShowHideHWGR_CheckedChanged(object sender, EventArgs e)
        {
            ShowHWGR = checkEditShowHideHWGR.Checked;
        }

        private void gvAbsencePlanning_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        StringBuilder sb = new StringBuilder(10);
        private void gvAbsencePlanning_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_absencemanager != null)
            {
                if (Char.IsLetterOrDigit(e.KeyChar))
                    sb.Append(e.KeyChar);

                if (sb.Length > 6)
                {
                    sb.Length = 0;
                    return;
                }

                string s = sb.ToString();

                Absence absence = _absencemanager.GetByAbbreviation(s);


                if (absence != null && absence.IsFixed)
                {
                    ProcessAbsence(absence);
                    sb.Length = 0;
                }
            }
            else 
                sb.Length = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ViewAbsencePlanning == AbsencePlanningView.YearlyView)
                ViewAbsencePlanning = AbsencePlanningView.MonthlyView;
            else if (ViewAbsencePlanning == AbsencePlanningView.MonthlyView )
                ViewAbsencePlanning = AbsencePlanningView.WeeklyView ;
            else if (ViewAbsencePlanning == AbsencePlanningView.WeeklyView)
                ViewAbsencePlanning = AbsencePlanningView.YearlyView;

        }

        private void btnView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = btnView.Location ;
                p.Y += btnView.Height ;

                p = this.PointToScreen (p);
                cmView.Show(p); 
                //cmAbsencePlanning.Show(p);
            }
        }

        private void btn_TakeFromPrevYear_Click(object sender, EventArgs e)
        {
            if (UserCanEdit)
            {
                if (_TodayYear <= Year)
                {
                    if (!IsAustria)
                    {
                        SaveData(true);
                        if (QuestionMessageYes(GetLocalized("QuestionToMoveSpareHolidaysFromLastYear")))
                        {
                            ClientEnvironment.EmployeeHolidaysInfoService.MoveSpareHolidaysToYear(CurrentStore.ID, Year);
                            LoadHolidaysInfo();
                        }
                    }
                }
            }

        }

        private void lookUpEditStores_QueryPopUp(object sender, CancelEventArgs e)
        {
            //if (lookUpEditStores.Properties.PopupFormWidth < 300)
            //    lookUpEditStores.Properties.PopupFormWidth = 300;

        }
    }
}
