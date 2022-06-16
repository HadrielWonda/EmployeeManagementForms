using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using DevExpress.XtraGrid.Columns;
using Baumax.Domain;
using DevExpress.Utils;
using Baumax.Environment;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using Baumax.ClientUI.FormEntities.TimeRecording;
using System.Globalization;
using Baumax.ClientUI.FormEntities.Employee;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCWeekTimeRecording : UCBaseEntity 
    {

        private UCActualCashDeskWeeklyInfo _ucCashDeskInfo = null;
        private UCStoreWorldPlanningInfo _ucWorldInfo = null;

        private Dictionary<GridColumn, StoreDay> _plannedColumnDiction = new Dictionary<GridColumn, StoreDay>(7);
        private Dictionary<GridColumn, StoreDay> _actualColumnDiction = new Dictionary<GridColumn, StoreDay>(7);
        private WorldRecordingContext _context = null;

        private List<EmployeeWeekView> _weeksview = null;

        private CopyData _copyData = null;

        private Dictionary<GridSummaryItem, GridColumn> _summaryTocolumn = new Dictionary<GridSummaryItem, GridColumn>();
        private GridBand[] arr = new GridBand[7];
        private ChangedContext _Context_ChangeContext = null;
        public event EventHandler OnDataSourceChanged = null;

        public UCWeekTimeRecording()
        {
            InitializeComponent();

            _Context_ChangeContext = new ChangedContext(_context_ChangedContext);
            Disposed += new EventHandler(UCWeekTimeRecording_Disposed);
            GridViewRecording.KeyDown += new KeyEventHandler(View_KeyDown);

            ApplyAppearanceNoWrap(gbcSunday);
            ApplyAppearanceNoWrap(gbcMonday);
            ApplyAppearanceNoWrap(gbcTuesday);
            ApplyAppearanceNoWrap(gbcWednesday);
            ApplyAppearanceNoWrap(gbcThursday);
            ApplyAppearanceNoWrap(gbcFriday);
            ApplyAppearanceNoWrap(gbcSaturday);

            ApplyAppearanceWrap(band_ContractWorkingHours);
            //ApplyAppearanceWrap(band_Employee );
            //ApplyAppearanceWrap(band_HWGR);
            ApplyAppearanceWrap(band_EmployeeBalanceHours );
            ApplyAppearanceWrap(band_PlusMinusHours );
            ApplyAppearanceWrap(band_SummOfAdditionalCharges);
            
            foreach (BandedGridColumn gc in GridViewRecording.Columns)
            {
                if (gc != gc_HWGR && gc != gc_Employee)
                {
                    gc.OptionsColumn.AllowMove = false;
                    gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                }


                if (gc.SummaryItem != null)
                    _summaryTocolumn[gc.SummaryItem ] = gc;
            }


            BuildIndex();

            arr[0] = gbcSunday;
            arr[1] = gbcMonday;
            arr[2] = gbcTuesday;
            arr[3] = gbcWednesday;
            arr[4] = gbcThursday;
            arr[5] = gbcFriday;
            arr[6] = gbcSaturday;

            deMonday.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
            deMonday.Properties.MaxValue = DateTimeHelper.GetSunday (DateTime.Today );
            deMonday.DateTime = DateTimeHelper.GetMonday(DateTime.Today);
        }
        private void ApplyAppearanceWrap(GridBand band)
        {
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            band.OptionsBand.AllowMove = false;
            band.OptionsBand.ShowInCustomizationForm = false;
        }
        private void ApplyAppearanceNoWrap(GridBand band)
        {
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = WordWrap.NoWrap;
            band.OptionsBand.AllowMove = false;
            band.OptionsBand.ShowInCustomizationForm = false;
        }
        public bool IsUserCanEdit
        {
            get
            {
                Domain.User user = ClientEnvironment.AuthorizationService.GetCurrentUser();

                if (user != null && user.UserRoleID.HasValue)
                {
                    return (long)UserRoleId.Controlling != user.UserRoleID.Value;
                }
                else return false;
            }
        }

        void UCWeekTimeRecording_Disposed(object sender, EventArgs e)
        {
            Context = null;
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                LocalizerControl.ComponentsLocalize(this.components);
                PrepareColumns();
            }
        }
        public WorldRecordingContext Context
        {
            get { return _context; }
            set
            {
                if (_context != value)
                {
                    if (_context != null)
                        _context.ChangedContext -= _Context_ChangeContext;
                    
                    _context = value;

                    if (_context != null)
                        _context.ChangedContext += _Context_ChangeContext;

                    OnChangedContext();

                }
            }
        }

        

        void _context_ChangedContext()
        {
            OnChangedContext();
        }

        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
            if (!IsDesignMode)
            {
                riHwgrLookup.DataSource = ClientEnvironment.HWGRService.FindAll();
                GridViewRecording.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                                new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                                new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                                });
            }
        }

        protected void OnChangedContext()
        {
            _weeksview = null;
            gcTimeRecording.DataSource = null;

            PrepareColumns();

            if (Context != null)
            {
                _weeksview = new List<EmployeeWeekView>();
                StoreWorldWeekState planWeeks = Context.WorldPlanningState;
                StoreWorldWeekState actualWeeks = Context.WorldActualState;

                if (planWeeks != null)
                {
                    EmployeeWeekView view = null;
                    EmployeeWeek week = null;
                    if (planWeeks.List != null)
                    {
                        foreach (EmployeeWeek ew in planWeeks.List)
                        {
                            week = actualWeeks[ew.EmployeeId];

                            Domain.Employee emp = ClientEnvironment.EmployeeService.FindById(ew.EmployeeId);
                            view = new EmployeeWeekView(Context, ew, week, emp.OrderHwgrID ?? 0);
                            _weeksview.Add(view);
                        }
                    }
                }
                ShowWorldOrCashDeskInfoControl();
                CalculateWeekly();
                //Context.Modified = false;
                gcTimeRecording.DataSource = _weeksview;
                if (OnDataSourceChanged != null)
                    OnDataSourceChanged(_weeksview != null && _weeksview.Count > 0, null);

                deMonday.DateTime = Context.BeginWeekDate;

            }
        }

        

        public void RefreshGrid()
        {
            GridViewRecording.RefreshData();
        }

        public void ShowWorldOrCashDeskInfoControl()
        {
            if (Context != null)
            {
                StoreWorldWeekState worldstate = Context.WorldActualState;

                if (worldstate != null)
                {
                    if (worldstate.IsCashDesk)
                    {
                        ShowWorldInfoControl(false);
                        ShowCashDeskInfoControl(true);

                        StoreWorldWeekState planningworldstate = Context.WorldPlanningState;
                        _ucCashDeskInfo.ColorManager = Context.CountryColors;
                        _ucCashDeskInfo.CashDeskInfo = (worldstate.StoreWorldInfo as CashDeskPlanningInfo);
                        planningworldstate.Calculate();
                        _ucCashDeskInfo.SetPlannedCashDeskUnits(planningworldstate.GetSums (), planningworldstate.datas);
                    }
                    else
                    {
                        ShowWorldInfoControl(true);
                        ShowCashDeskInfoControl(false);

                        _ucWorldInfo.WorldInfo = worldstate.StoreWorldInfo as StoreWorldPlanningInfo;
                        _ucWorldInfo.ColorManager = Context.CountryColors;

                    }
                }
                else
                {
                    if (_ucWorldInfo != null)
                        _ucWorldInfo.WorldInfo = null;
                    if (_ucCashDeskInfo != null)
                        _ucCashDeskInfo.Clear();
                }
            }
        }

        private void ShowWorldInfoControl(bool bShow)
        {
            if (bShow)
            {
                if (_ucWorldInfo == null)
                {
                    _ucWorldInfo = new UCStoreWorldPlanningInfo();
                    _ucWorldInfo.IsPlanned = false; 
                    _ucWorldInfo.Parent = splitContainer1.Panel2;
                    _ucWorldInfo.Dock = DockStyle.Fill;
                }
                _ucWorldInfo.Visible = true;
            }
            else
            {
                if (_ucWorldInfo != null)
                {
                    _ucWorldInfo.Visible = false;
                    _ucWorldInfo.WorldInfo = null;
                    _ucWorldInfo.ColorManager = null;
                }
            }
        }
        private void ShowCashDeskInfoControl(bool bShow)
        {
            if (bShow)
            {
                 
                if (_ucCashDeskInfo == null)
                {
                    _ucCashDeskInfo = new UCActualCashDeskWeeklyInfo();
                    _ucCashDeskInfo.Parent = splitContainer1.Panel2;
                    _ucCashDeskInfo.Dock = DockStyle.Fill;
                }
                _ucCashDeskInfo.Visible = true;
            }
            else
            {
                if (_ucCashDeskInfo != null)
                {
                    _ucCashDeskInfo.CashDeskInfo = null;
                    _ucCashDeskInfo.Visible = false;
                }
            }
        }

        private void PrepareColumns()
        {
            _plannedColumnDiction[gc_Monday] = null;
            _plannedColumnDiction[gc_Tuesday] = null;
            _plannedColumnDiction[gc_Wednesday] = null;
            _plannedColumnDiction[gc_Thursday] = null;
            _plannedColumnDiction[gc_Friday] = null;
            _plannedColumnDiction[gc_Saturday] = null;
            _plannedColumnDiction[gc_Sunday] = null;

            _actualColumnDiction[gcMondayRec] = null;
            _actualColumnDiction[gcTuesdayRec] = null;
            _actualColumnDiction[gcWednesdayRec] = null;
            _actualColumnDiction[gcThursdayRec] = null;
            _actualColumnDiction[gcFridayRec] = null;
            _actualColumnDiction[gcSaturdayRec] = null;
            _actualColumnDiction[gcSundayRec] = null;

            if (Context != null)
            {
                IStoreDaysList storedays = Context.StoreDays;


                if (storedays != null)
                {
                    DateTime dt = storedays.BeginTime;
                    StoreDay sd = storedays[dt];
                    _plannedColumnDiction[gc_Monday] = sd;
                    _actualColumnDiction[gcMondayRec] = sd;
                    sd = storedays[dt.AddDays(1)];
                    _plannedColumnDiction[gc_Tuesday] = sd;
                    _actualColumnDiction[gcTuesdayRec] = sd;
                    sd = storedays[dt.AddDays(2)];
                    _plannedColumnDiction[gc_Wednesday] = sd;
                    _actualColumnDiction[gcWednesdayRec] = sd;
                    sd = storedays[dt.AddDays(3)];
                    _plannedColumnDiction[gc_Thursday] = sd;
                    _actualColumnDiction[gcThursdayRec] = sd;
                    sd = storedays[dt.AddDays(4)];
                    _plannedColumnDiction[gc_Friday] = sd;
                    _actualColumnDiction[gcFridayRec] = sd;
                    sd = storedays[dt.AddDays(5)];
                    _plannedColumnDiction[gc_Saturday] = sd;
                    _actualColumnDiction[gcSaturdayRec] = sd;
                    sd = storedays[dt.AddDays(6)];
                    _plannedColumnDiction[gc_Sunday] = sd;
                    _actualColumnDiction[gcSundayRec] = sd;

                    GridBand gb = null;
                    for (int i = 0; i < 7; i++)
                    {
                        dt = storedays.BeginTime.AddDays(i);
                        gb = arr[(int)dt.DayOfWeek];
                        sd = storedays[dt];
                        gb.Caption = String.Format("{2}\n{1}\n{0}",
                                DateTimeHelper.ShortTimeRangeToStr(sd.OpenTime, sd.CloseTime),
                                dt.ToString("dd.MM.yyyy"),
                                GetLocalized(dt.DayOfWeek.ToString()));
                    }


                }
                else
                {
                    BuildDefaultBandName();
                }



            }
            else
            {
                BuildDefaultBandName();
            }




        }

        private void BuildDefaultBandName()
        {
            GridBand gb = null;
            DateTime dtBegin = DateTimeHelper.GetMonday(DateTime.Today);
            DateTime dtEnd = DateTimeHelper.GetSunday(dtBegin);
            DateTime dt;
            for (int i = 0; i < 7; i++)
            {
                dt = dtBegin.AddDays(i);
                gb = arr[(int)dt.DayOfWeek];
                gb.Caption = String.Format("{0}",
                        GetLocalized(dt.DayOfWeek.ToString()));
            }
        }

        private void CalculateWeekly()
        {
            if (Context != null && Context.WorldActualState != null)
            {
                StoreWorldWeekState actualWeeks = Context.WorldActualState;

                actualWeeks.Calculate();

                if (actualWeeks.IsCashDesk)
                {
                    if (_ucCashDeskInfo != null)
                        _ucCashDeskInfo.SetActualCashDeskUnits (actualWeeks.GetSums(), actualWeeks.datas);
                }
                else
                {
                    if (_ucWorldInfo != null)
                        _ucWorldInfo.UpdateInfo();
                }
                PlayWorkingModelMessages();
                RefreshGrid();
            }
        }
        #region control helper function and methods


        protected bool IsFocusedCell(GridColumn column, int rowHandle)
        {
            return (column == GridViewRecording.FocusedColumn &&
                            rowHandle == GridViewRecording.FocusedRowHandle);
        }

        protected bool IsEditingCell(GridColumn column, int rowHandle)
        {
            return (column == GridViewRecording.FocusedColumn &&
                            rowHandle == GridViewRecording.FocusedRowHandle
                            && GridViewRecording.IsEditorFocused);
        }

        public EmployeeWeekView GetEntityByRowHandle(int handle)
        {
            if (GridViewRecording.IsDataRow(handle))
                return (EmployeeWeekView)GridViewRecording.GetRow(handle);

            return null;
        }

        public StoreDay GetStoreDay(GridColumn column)
        {
            if (_plannedColumnDiction.ContainsKey(column))
                return _plannedColumnDiction[column];

            if (_actualColumnDiction.ContainsKey(column))
                return _actualColumnDiction[column];

            return null;
        }

        public EmployeeDay GetEmployeeDay()
        {
            return GetEmployeeDay(GridViewRecording.FocusedColumn, GridViewRecording.FocusedRowHandle);
        }
        

        EmployeeDay GetEmployeeDay(GridColumn column, int rowHandle)
        {
            EmployeeWeekView weekview = null;
            if (GridViewRecording.IsDataRow(rowHandle))
            {
                weekview = (EmployeeWeekView)GridViewRecording.GetRow(rowHandle);


                if (_plannedColumnDiction.ContainsKey(column))
                {
                    StoreDay sd = GetStoreDay(column);
                    if (sd != null)
                    {
                        return weekview.PlanningWeek.GetDay(sd.Date);
                    }
                }

                if (_actualColumnDiction.ContainsKey(column))
                {
                    StoreDay sd = GetStoreDay(column);
                    if (sd != null)
                    {
                        return weekview.ActualWeek.GetDay(sd.Date);
                    }
                }
            }
            return null;
        }

        public bool IsPlannedColumn(GridColumn column)
        {
            return _plannedColumnDiction.ContainsKey(column);
        }
        public bool IsActualColumn(GridColumn column)
        {
            return _actualColumnDiction.ContainsKey(column);
        }

        public bool IsEditableDay(EmployeeDay employeeday)
        {
            if (Context == null) return false;
            if (employeeday == null) return false;
            if (employeeday.StoreWorldId != Context.StoreWorldId) return false;
            if (employeeday.StoreId != Context.StoreId ) return false;

            if (employeeday.HasLongAbsence) return false;
            if (!employeeday.HasRelation) return false;
            if (!employeeday.HasContract) return false;
            if (employeeday.Date >= DateTime.Today) return false;
            if (!Context.AllowEdit (employeeday.Date )) return false;
            return IsUserCanEdit;
        }
        #endregion

        private void GridViewRecording_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            EmployeeDay ed = GetEmployeeDay(e.Column, e.RowHandle);
            StoreDay sd = GetStoreDay(e.Column);
            bool focusedCell = IsFocusedCell(e.Column, e.RowHandle);

            if (ed != null && sd != null && Context != null)
            {
                Painters.DrawCell(Context.StoreId, Context, ed, e.Cache, e.Bounds, focusedCell);
                e.Handled = true;
            }
        }
        private int _stringHeight = -1;
        private void GridViewRecording_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {

            EmployeeWeekView pl_week = GetEntityByRowHandle(e.RowHandle);
            
            if (pl_week == null) return;

            if (_stringHeight == -1)
            {
                Graphics graphics = gcTimeRecording.CreateGraphics();

                Size sf = graphics.MeasureString("222", Painters._cellFont).ToSize();
                _stringHeight = sf.Height;

            }

            int maxCountLine = 0;
            int countLine = 0;
            foreach (EmployeeDay epd in pl_week.PlanningWeek.DaysList)
            {
                if (epd.TimeList != null) countLine = epd.TimeList.Count;
                maxCountLine = Math.Max(maxCountLine, countLine);
            }
            foreach (EmployeeDay epd in pl_week.ActualWeek.DaysList)
            {
                if (epd.TimeList != null) countLine = epd.TimeList.Count;
                maxCountLine = Math.Max(maxCountLine, countLine);
            }
            int cellHeight = maxCountLine * _stringHeight + maxCountLine*2;

            if (cellHeight > 0) e.RowHeight = cellHeight;


        }


        private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (!IsUserCanEdit)
            {
                e.Cancel = true;
                return;
            }
            EmployeeDay epd = GetEmployeeDay();

            if (Context != null && epd != null)
            {
                e.Cancel = !IsEditableDay(epd);
            }
            else e.Cancel = true;
        }

        public string[] GetCellContent(EmployeeDay day)
        {

            if (day == null || day.TimeList == null || day.TimeList.Count == 0) return null;
            string[] arr = new string[day.TimeList.Count];
            int i = 0;
            foreach (EmployeeTimeRange range in day.TimeList)
            {
                if (range.Absence != null)
                    arr[i] = TextParser.AbsenceTimeRangeToEditString(range.Begin, range.End, range.Absence.CharID);
                else
                    arr[i] = TextParser.TimeRangeToEditString(range.Begin, range.End);
                i++;
            }

            return arr;
        }
        private void GridViewRecording_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (IsFocusedCell(e.Column, e.RowHandle))
            {
                EmployeeDay dayPlan = GetEmployeeDay(e.Column, e.RowHandle);

                if (dayPlan != null && _actualColumnDiction.ContainsKey (e.Column ))
                {
                    StringBuilder sb = new StringBuilder();

                    string[] lstStrings = GetCellContent(dayPlan);
                    if (lstStrings != null)
                    {
                        foreach (string tr in lstStrings)
                            sb.AppendLine(tr);
                    }


                    e.Value = sb.ToString();
                }
            }
        }

        /*private void CheckCountAliquotAbsences(List<__TimeRange> lst, StoreDay sd, int countMinute)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (__TimeRange tr in lst)
                {
                    if (!String.IsNullOrEmpty(tr.AbsenceCode) && tr.EndTime == 0)
                    {
                        Absence absence = Context.Absences.GetByAbbreviation(tr.AbsenceCode);
                        if (absence != null)
                        {
                            if (absence.IsFixed)
                            {
                                tr.BeginTime = sd.OpenTime;
                                if (sd.OpenTime + countMinute > Utills.MinutesInDay)

                                    tr.EndTime = Utills.MinutesInDay;
                                else
                                    tr.EndTime = (short)(sd.OpenTime + countMinute);
                            }
                        }
                    }
                }
            }
        }*/
        private void CheckCountAliquotAbsences(List<__TimeRange> lst, StoreDay sd, int countMinute)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (__TimeRange tr in lst)
                {
                    if (!String.IsNullOrEmpty(tr.AbsenceCode) && tr.EndTime == 0)
                    {
                        Absence absence = Context.Absences.GetByAbbreviation(tr.AbsenceCode);
                        if (absence != null)
                        {
                            if (absence.IsFixed)
                            {

                                tr.BeginTime = sd.OpenTime;
                                if (sd.OpenTime + countMinute > Utills.MinutesInDay)

                                    tr.EndTime = Utills.MinutesInDay;
                                else
                                    tr.EndTime = (short)(sd.OpenTime + countMinute);
                            }
                            else if (absence.Value != 0)
                            {
                                tr.BeginTime = sd.OpenTime;
                                if (sd.OpenTime + absence.Value * 60 > Utills.MinutesInDay)

                                    tr.EndTime = Utills.MinutesInDay;
                                else
                                    tr.EndTime = (short)(sd.OpenTime + absence.Value * 60);
                            }
                        }
                    }
                }
            }
        }
        private void GridViewRecording_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (!CanEdit) return;

            String s = (string)e.Value;

            try
            {
                EmployeeWeekView weekview = GetEntityByRowHandle(GridViewRecording.FocusedRowHandle);
                EmployeeDay epd = GetEmployeeDay();

                StoreDay sd = Context.StoreDays[epd.Date];

                int count = (short)((weekview.ActualWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek));
                ParserEx ex = new ParserEx(Context.Absences, sd.OpenTime, sd.CloseTime, count);
                ex.ParserText(s);
                List<__TimeRange> lst = ex.Ranges;



/*                EmployeeWeekView weekview = GetEntityByRowHandle(GridViewRecording.FocusedRowHandle);
                EmployeeDay epd = GetEmployeeDay();

                StoreDay sd = Context.StoreDays[epd.Date];
                int count = DateTimeHelper.RoundToQuoter ((short)((weekview.ActualWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek)));



                List<__TimeRange> lst = TextParser.ParseText2(sd,s);

                int count = DateTimeHelper.RoundToQuoter((short)((weekview.ActualWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek)));
 */
                //CheckCountAliquotAbsences(lst, sd, count);

                if (CompareWithOriginalData(lst, epd))
                {
                    if (epd.TimeList != null)
                        Context.Absences.FillEmployeeDay(epd);


                    CalculateWeekly();
                    epd.Modified = true;
                    Context.Modified = true;
                }
                e.Valid = true;

                /*
                RecordingDayView dayView = new RecordingDayView();
                RecordingDayView dayViewOriginal = new RecordingDayView();
                dayViewOriginal.RecordingDay = epd;
                dayView.RecordingDay = epd;
                dayView.ClearRecording();
                if (lst != null)
                {
                    foreach (__TimeRange tr in lst)
                    {
                        if (String.IsNullOrEmpty(tr.AbsenceCode))
                        {
                            dayView.MarkAsWorkingTime(tr.BeginTime, tr.EndTime);
                        }
                        else
                        {
                            Absence absence = Context.Absences.GetByAbbreviation(tr.AbsenceCode);
                            if (absence != null)
                                dayView.MarkAsAbsenceTime(tr.BeginTime, tr.EndTime, absence);
                        }
                    }
                }
                

                if (!dayView.Compare(dayViewOriginal))
                {
                    dayView.UpdateRecordingDay ();

                    if (epd.TimeList != null)
                        Context.Absences.FillEmployeeDay (epd);
                    CalculateWeekly();
                    epd.Modified = true;
                    Context.Modified = true;

                }
                e.Valid = true;
                */
                
            }
            catch (Exception ex)
            {
                e.Valid = false;
                XtraMessageBox.Show(ex.Message);
            }


            
        
        }
        private bool CompareWithOriginalData(List<__TimeRange> ranges, EmployeeDay day)
        {
            bool bModified = false;

            string[] originalList = GetCellContent(day);
            List<__TimeRange> newList = ranges;
            if (ranges == null)
                newList = new List<__TimeRange>();
            if (originalList == null)
                originalList = new string[] { };

            if (newList.Count == originalList.Length)
            {
                Dictionary<string, __TimeRange> diction = new Dictionary<string, __TimeRange>();
                foreach (__TimeRange r in newList)
                    diction[r.AsTimeEditString] = r;


                foreach (string new_range in originalList)
                {
                    string key = new_range;
                    if (!diction.ContainsKey(key))
                    {
                        bModified = true;
                    }
                }
            }
            else bModified = true;
            if (bModified)
            {
                FillPlanningDayByTimeRange(ranges, day);
            }

            return bModified;
        }
        private void FillPlanningDayByTimeRange(List<__TimeRange> ranges, EmployeeDay day)
        {
            if (ranges == null || ranges.Count == 0)
            {
                day.TimeList = null;
                day.Modified = true;
                return;
            }

            day.TimeList = null;

            foreach (__TimeRange range in ranges)
            {
                if (range.Validation())
                {
                    if (!String.IsNullOrEmpty(range.AbsenceCode))
                    {
                        Absence absence = Context.Absences.GetByAbbreviation(range.AbsenceCode);
                        if (absence != null)
                        {
                            EmployeeTimeRange entity = new EmployeeTimeRange();
                            entity.Date = day.Date;
                            entity.AbsenceID = absence.ID;
                            entity.Begin = range.BeginTime;
                            entity.End = range.EndTime;
                            entity.Time = (short)(entity.End - entity.Begin);
                            entity.EmployeeID = day.EmployeeId;

                            if (day.TimeList == null)
                                day.TimeList = new List<EmployeeTimeRange>();
                            day.TimeList.Add(entity);
                        }
                    }
                    else
                    {
                        EmployeeTimeRange entity = new EmployeeTimeRange();
                        entity.Date = day.Date;
                        entity.Begin = range.BeginTime;
                        entity.End = range.EndTime;
                        entity.Time = (short)(entity.End - entity.Begin);
                        entity.EmployeeID = day.EmployeeId;

                        if (day.TimeList == null)
                            day.TimeList = new List<EmployeeTimeRange>();
                        day.TimeList.Add(entity);
                    }
                }
            }
            day.Modified = true;

        }

        GridColumn[] indexPlannedColumn = new GridColumn[7];
        GridColumn[] indexActualColumn = new GridColumn[7];
        void BuildIndex()
        {
            indexActualColumn[(int)DayOfWeek.Monday] = gcMondayRec;
            indexActualColumn[(int)DayOfWeek.Tuesday] = gcTuesdayRec;
            indexActualColumn[(int)DayOfWeek.Wednesday] = gcWednesdayRec;
            indexActualColumn[(int)DayOfWeek.Thursday] = gcThursdayRec;
            indexActualColumn[(int)DayOfWeek.Friday] = gcFridayRec;
            indexActualColumn[(int)DayOfWeek.Saturday] = gcSaturdayRec;
            indexActualColumn[(int)DayOfWeek.Sunday] = gcSundayRec;

            indexPlannedColumn[(int)DayOfWeek.Monday] = gc_Monday;
            indexPlannedColumn[(int)DayOfWeek.Tuesday] = gc_Tuesday;
            indexPlannedColumn[(int)DayOfWeek.Wednesday] = gc_Wednesday;
            indexPlannedColumn[(int)DayOfWeek.Thursday] = gc_Thursday;
            indexPlannedColumn[(int)DayOfWeek.Friday] = gc_Friday;
            indexPlannedColumn[(int)DayOfWeek.Saturday] = gc_Saturday;
            indexPlannedColumn[(int)DayOfWeek.Sunday] = gc_Sunday;

        }
        private void MoveToNextCell()
        {
            int resultRow = GridViewRecording.FocusedRowHandle;
            GridColumn resultColumn = GridViewRecording.FocusedColumn;
            
            StoreDay storeday = GetStoreDay (resultColumn );

            if (storeday == null)// not days column
            {
                if (resultColumn == gc_Employee) resultColumn = indexActualColumn[(int)DayOfWeek.Monday];
                else
                {
                    if (GridViewRecording.IsLastRow)
                        GridViewRecording.MoveFirst();
                    else
                        GridViewRecording.MoveNext();

                    resultRow = GridViewRecording.FocusedRowHandle;
                    resultColumn = indexActualColumn[(int)DayOfWeek.Monday];
                }

                storeday = GetStoreDay(resultColumn);
            }

            if (storeday != null)
            {
                if (_plannedColumnDiction.ContainsKey(resultColumn))
                {
                    resultColumn = indexActualColumn[(int)storeday.Date.DayOfWeek];
                }
                if (storeday.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (GridViewRecording.IsLastRow)
                        GridViewRecording.MoveFirst();
                    else
                        GridViewRecording.MoveNext();
                    resultColumn = indexActualColumn[(int)DayOfWeek.Monday];

                    GridViewRecording.FocusedColumn = resultColumn;

                    GridViewRecording.MakeColumnVisible(resultColumn);
                }
                else
                {
                    DayOfWeek dw = storeday.Date.AddDays (1).DayOfWeek;

                    resultColumn = indexActualColumn[(int)dw];

                    GridViewRecording.FocusedColumn = resultColumn;

                    GridViewRecording.MakeColumnVisible(resultColumn);
                }


            }
        }

        private void View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;


                try
                {
                    if (GridViewRecording.IsEditing)
                    {
                        if (GridViewRecording.IsEditorFocused && GridViewRecording.ValidateEditor())
                            MoveToNextCell();
                    }
                    else MoveToNextCell();
                }
                catch (HideException) { }

            }
            if (e.KeyCode == Keys.C && e.Control)
            {
                e.SuppressKeyPress = true;
                CopyTimes();
                return;
            }
            if (e.KeyCode == Keys.V && e.Control)
            {
                e.SuppressKeyPress = true;
                PasteTimes();
                return;
            }

            if (e.KeyCode == Keys.Home && e.Control)
            {
                ShowDebugForm();
                return;
            }

            if (e.KeyCode == Keys.Oemplus && e.Control)
            {

                EmployeeWeekView w = GetEntityByRowHandle(GridViewRecording.FocusedRowHandle);
                if (w != null)
                {
                    EmployeeInfoDebugForm f = new EmployeeInfoDebugForm();
                    f.ShowInfo(w.EmployeeId);
                }
            }

        }
        private void ShowDebugForm()
        {
            using (DebugFormViewAllWorkingModel form = new DebugFormViewAllWorkingModel())
            {
                form.FillGrid(_context, _context.WorldActualState.List);
                form.ShowDialog();
            }
        }

        #region menu and copy /paste methods

        private void CopyTimes()
        {

            EmployeeDay planningday = GetEmployeeDay();
            if (planningday != null)
            {
                if (_copyData == null) _copyData = new CopyData();

                _copyData.Assign(planningday);
            }
        }

        private void PasteTimes()
        {
            if (!IsUserCanEdit) return;
            EmployeeDay planningday = GetEmployeeDay();
            if (planningday != null && 
                Context != null && 
                !IsPlannedColumn (GridViewRecording.FocusedColumn ) &&
                IsEditableDay (planningday ))
            {
                if (_copyData != null)
                {
                    _copyData.AssignTo(planningday);
                    CalculateWeekly();
                    Context.Modified = true;
                    planningday.Modified = true;
                }
            }
        }

        private void ResetTimes()
        {
            if (!IsUserCanEdit) return;
            EmployeeDay planningday = GetEmployeeDay();
            if (planningday != null &&
                Context != null &&
                !IsPlannedColumn(GridViewRecording.FocusedColumn) &&
                IsEditableDay(planningday))
            {
                if (planningday.TimeList != null && planningday.TimeList.Count > 0)
                {
                    planningday.TimeList = null;
                    CalculateWeekly();
                    Context.Modified = true;
                    planningday.Modified = true;
                }
            }
        }

        private void AddAbsenceTimes()
        {
            if (!IsUserCanEdit) return;
            EmployeeDay planningday = GetEmployeeDay();


            if (planningday != null &&
                Context != null &&
                !IsPlannedColumn(GridViewRecording.FocusedColumn) &&
                IsEditableDay(planningday))
            {
                using (FormSelectAbsence formSelectAbsence = new FormSelectAbsence())
                {

                    formSelectAbsence.Absences = Context.Absences.ToList;
                    StoreDay sd = Context.StoreDays[planningday.Date];
                    formSelectAbsence.ShowTimePanel = true;
                    formSelectAbsence.SetDayInfo(sd.OpenTime, sd.CloseTime, Context.StoreDays.AvgDayInWeek);


                    if (formSelectAbsence.Execute())
                    {
                        Absence absence = formSelectAbsence.SelectedAbsence;
                        short begintime = sd.OpenTime;
                        short endtime = sd.CloseTime;



                        RecordingDayView dayview = new RecordingDayView();
                        dayview.RecordingDay = planningday;
                        RecordingDayView dayviewCopy = new RecordingDayView();
                        dayviewCopy.RecordingDay = planningday;
                        EmployeeTimeRange entity = new EmployeeTimeRange();
                        entity.EmployeeID = planningday.EmployeeId;
                        entity.AbsenceID = absence.ID;
                        entity.Absence = absence;
                        entity.Date = planningday.Date;
                        if (absence.IsFixed)
                        {
                            EmployeeWeekView weekview = GetEntityByRowHandle(GridViewRecording.FocusedRowHandle);
                            //int count = DateTimeHelper.RoundToQuoter((short)((weekview.ActualWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek)));
                            int count = (short)((weekview.ActualWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek));
                            if (Utills.MinutesInDay < ((int)begintime + count))
                                endtime = Utills.MinutesInDay;
                            else
                                endtime = (short)(begintime + count);

                            entity.Begin = begintime;
                            entity.End = endtime;
                            //dayview.MarkAsAbsenceTime(begintime, endtime, absence);
                        }
                        else
                            if (absence.Value != 0)
                            {
                                int count = DateTimeHelper.RoundToQuoter((short)(absence.Value * 60));
                                if (Utills.MinutesInDay < ((int)begintime + count))
                                    endtime = Utills.MinutesInDay;
                                else
                                    endtime = (short)(begintime + count);
                                entity.Begin = begintime;
                                entity.End = endtime;

                                //dayview.MarkAsAbsenceTime(begintime, endtime, absence);
                            }
                            else
                            {
                                entity.Begin = formSelectAbsence.BeginTime;
                                entity.End = formSelectAbsence.EndTime;

                                //dayview.MarkAsAbsenceTime(formSelectAbsence.BeginTime, formSelectAbsence.EndTime, absence);
                            }


                        //dayview.MarkAsAbsenceTime(formSelectAbsence.BeginTime, formSelectAbsence.EndTime, formSelectAbsence.SelectedAbsence);
                        if (EmployeeTimeRangeHelper.InsertTimeRange(planningday, entity))
                        {
                            Context.Modified = true;
                            planningday.Modified = true;
                            CalculateWeekly();
                        }
                        //if (!dayview.Compare(dayviewCopy))
                        //{
                        //    dayview.UpdateRecordingDay();

                        //    Context.Modified = true;
                        //    planningday.Modified = true;
                        //    CalculateWeekly();
                        //}
                    }
                }
            }
        }

        private class CopyData
        {
            public List<EmployeeTimeRange> Times = new List<EmployeeTimeRange>();

            public void Assign(EmployeeDay employeeday)
            {
                Clear();
                if (employeeday.TimeList != null)
                {
                    EmployeeTimeRange newrange = null;
                    foreach (EmployeeTimeRange range in employeeday.TimeList)
                    {
                        newrange = new EmployeeTimeRange(range);
                        //newrange.ID = -1;//newitem
                        Times.Add(newrange);
                    }
                }


            }

            public void Clear()
            {
                if (Times != null)
                    Times.Clear();
            }


            public void AssignTo(EmployeeDay employeeday)
            {
                employeeday.TimeList = null;

                if (Times != null)
                {
                    employeeday.TimeList = new List<EmployeeTimeRange> ();
                    EmployeeTimeRange en = null;
                    foreach (EmployeeTimeRange range in Times)
                    {
                        en = new EmployeeTimeRange(range);
                        en.EmployeeID = employeeday.EmployeeId;
                        //en.ID = 0;
                        en.Date = employeeday.Date;
                        employeeday.TimeList.Add (en);
                    }

                }

                
                employeeday.Modified = true;
            }
        }

        private void contextMenuWeekly_Opening(object sender, CancelEventArgs e)
        {
            EmployeeDay planningday = GetEmployeeDay();

            if (!IsUserCanEdit || Context == null || planningday == null || GridViewRecording.RowCount == 0)
            {
                e.Cancel = true;
                return;
            }

            bool bPlanned = IsPlannedColumn(GridViewRecording.FocusedColumn);
            bool bEditable = IsEditableDay(planningday);

            mi_Copy.Enabled = true;
            mi_Paste.Enabled = (_copyData != null) && bEditable && !bPlanned;
            mi_Absence.Enabled = mi_ClearTime.Enabled = bEditable && !bPlanned;
            e.Cancel = false;
        }

        private void mi_Copy_Click(object sender, EventArgs e)
        {
            CopyTimes();
        }

        private void mi_Paste_Click(object sender, EventArgs e)
        {
            PasteTimes();
        }

        private void mi_ClearTime_Click(object sender, EventArgs e)
        {
            ResetTimes();
        }

        

        private void mi_Absence_Click(object sender, EventArgs e)
        {
            AddAbsenceTimes();
        }
        #endregion


        private int GetColumnSumByColumn(GridColumn column)
        {
            if (Context == null || 
                Context.WorldActualState == null || 
                Context.WorldPlanningState == null) 
                return 0;

            StoreDay sd = GetStoreDay(column);
            StoreWorldWeekState weekstate = null;
            if (sd != null)
            {
                if (IsPlannedColumn(column))
                {
                    weekstate = Context.WorldPlanningState;
                    return weekstate.DaysSum[sd.Date.DayOfWeek];

                }
                else if (IsActualColumn(column))
                {
                    weekstate = Context.WorldActualState;
                    return weekstate.DaysSum[sd.Date.DayOfWeek];
                }
            }

            
            if (column == gcContractHoursPerWeek )
            {
                weekstate = Context.WorldActualState;
                return weekstate.DaysSum.TotalContractWorkingHours ;
            }
            //if (gcActualHours == column)
            //{
            //    weekstate = Context.WorldActualState;
            //    return weekstate.DaysSum.TotalPlannedHours;
            //}
            if (gcAdditionalHoursActual == column)
            {
                weekstate = Context.WorldActualState;
                return weekstate.DaysSum.TotalAdditionalCharges;
            }
            if (gcPlusMinusHoursActual == column)
            {
                weekstate = Context.WorldActualState;
                return weekstate.DaysSum.TotalPlusMinusHours ;
            }
            if (gcSaldoActual == column)
            {
                weekstate = Context.WorldActualState;
                return weekstate.DaysSum.TotalSaldo;
            }
            //if (gcPlannedHours == column)
            //{
            //    weekstate = Context.WorldPlanningState;
            //    return weekstate.DaysSum.TotalPlannedHours;
            //}
            if (gcAdditionalHoursPlanned == column)
            {
                weekstate = Context.WorldPlanningState;
                return weekstate.DaysSum.TotalAdditionalCharges;
            }
            if (gcPlusMinusHoursPlanned == column)
            {
                weekstate = Context.WorldPlanningState;
                return weekstate.DaysSum.TotalPlusMinusHours;
            }
            if (gcSaldoPlanned == column)
            {
                weekstate = Context.WorldPlanningState ;
                return weekstate.DaysSum.TotalSaldo;
            }

            return 0;
            
        }

        private void GridViewRecording_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridColumn column = null;
            e.TotalValue = "00:00";
            e.TotalValueReady = true;

            if (Context != null && _summaryTocolumn.TryGetValue((GridSummaryItem)e.Item, out column))
            {
                int result = GetColumnSumByColumn(column);
                e.TotalValue = TextParser.TimeToString(result);

            }
        }

        private void deMonday_DateTimeChanged(object sender, EventArgs e)
        {
            DateTime date = DateTimeHelper.GetMonday (deMonday.DateTime.Date);
            teSunday.Text = DateTimeHelper.GetSunday(date).ToString("dd.MM.yyyy");
            if (Context != null)
            {
                Context.SetViewDay(date);
            }
            deMonday.DateTime = date;
            UpdateWeekNumber();
        }
        private void UpdateWeekNumber()
        {
            deMonday.Properties.Buttons[1].Caption = Convert.ToString(DateTimeHelper.GetWeekNumber(deMonday.DateTime, deMonday.DateTime));
        }
        private void repItemCellData_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            EmployeeDay dayPlan = GetEmployeeDay();

            if (dayPlan != null && _actualColumnDiction.ContainsKey(GridViewRecording.FocusedColumn ))
            {
                StringBuilder sb = new StringBuilder();

                string[] lstStrings = GetCellContent(dayPlan);
                if (lstStrings != null)
                {
                    foreach (string tr in lstStrings)
                        sb.AppendLine(tr);
                }


                e.Value = sb.ToString();
            }
        }

        public event ChangedToDailyView EventChangedToDailyView = null;
        protected virtual void OnChangedToDailyView(DateTime date)
        {
            if (EventChangedToDailyView != null)
                EventChangedToDailyView(date);
        }

        private void GridViewRecording_MouseUp(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                BandedGridHitInfo info =
                    GridViewRecording.CalcHitInfo(e.Location);

                if (info.InBandPanel && info.Band != null)
                {
                    GridBand band = info.Band;
                    BandedGridColumn column = band.Columns[0];
                    StoreDay sd = GetStoreDay(column);

                    if (sd != null)
                    {
                        if (Context != null)
                        {
                            Context.SetViewDay(sd.Date);
                            OnChangedToDailyView(sd.Date);
                        }
                    }
                }
            }*/
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ShowHidePlannedRow.Checked)
            {
                GridViewRecording.BeginDataUpdate();
                
                foreach (GridColumn c in _plannedColumnDiction.Keys)
                {
                    c.Visible = true;
                    
                    (c as BandedGridColumn).RowIndex = 0;
                   
                }
                gcPlusMinusHoursPlanned.Visible = true;
                gcPlusMinusHoursPlanned.RowIndex = 0;
                gcAdditionalHoursPlanned.Visible = true;
                gcAdditionalHoursPlanned.RowIndex = 0;
                gcSaldoPlanned.Visible = true;
                gcSaldoPlanned.RowIndex = 0;

                foreach (GridColumn c in _actualColumnDiction.Keys)
                {
                    (c as BandedGridColumn).AutoFillDown = false;
                    (c as BandedGridColumn).RowIndex = 1;
                }
                gcPlusMinusHoursActual.AutoFillDown = false;
                gcPlusMinusHoursActual.RowIndex = 1;
                gcAdditionalHoursActual.AutoFillDown = false;
                gcAdditionalHoursActual.RowIndex = 1;
                gcSaldoActual.AutoFillDown = false;
                gcSaldoActual.RowIndex = 1;

                GridViewRecording.EndDataUpdate();
            }
            else
            {
                foreach (GridColumn c in _plannedColumnDiction.Keys)
                {
                    //(c as BandedGridColumn).RowIndex = 0;
                    c.Visible = false;
                }
                gcPlusMinusHoursPlanned.Visible = false;
                gcAdditionalHoursPlanned.Visible = false;
                gcSaldoPlanned.Visible = false;

                foreach (GridColumn c in _actualColumnDiction.Keys)
                {
                    (c as BandedGridColumn).AutoFillDown = true;
                }
                gcPlusMinusHoursActual.AutoFillDown = true;
                gcAdditionalHoursActual.AutoFillDown = true;
                gcSaldoActual.AutoFillDown = true;

            }
        }

        private void gcTimeRecording_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BandedGridHitInfo info =
                    GridViewRecording.CalcHitInfo(e.Location);

                if (info.InBandPanel && info.Band != null && info.Band == _clickedBand)
                {
                    GridBand band = info.Band;
                    BandedGridColumn column = band.Columns[0];
                    if (column == gc_HWGR || column == gc_Employee)
                    {
                        column.SortMode = ColumnSortMode.DisplayText;
                        if (column.SortOrder == ColumnSortOrder.Ascending)
                            column.SortOrder = ColumnSortOrder.Descending;
                        else
                            column.SortOrder = ColumnSortOrder.Ascending;
                        
                        if (column == gc_HWGR)
                            GridViewRecording.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                                new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                                new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                                });
                        else
                            GridViewRecording.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                                new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder),
                                new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder)
                                });
                    }
                    else
                    {
                        StoreDay sd = GetStoreDay(column);

                        if (sd != null)
                        {
                            if (Context != null)
                            {
                                Context.SetViewDay(sd.Date);
                                OnChangedToDailyView(sd.Date);
                            }
                        }
                    }
                }
//#if DEBUG
                else if (info.InRow && !info.InRowCell && info.HitTest == BandedGridHitTest.RowIndicator)
                {
                    DebugShowRowInfo();
                }
//#endif
            }
        }
        private void DebugShowRowInfo()
        {
            EmployeeWeekView weekview = (EmployeeWeekView)GridViewRecording.GetRow(GridViewRecording.FocusedRowHandle);

            if (weekview != null)
            {
                EmployeeWeek week = weekview.ActualWeek;
                if (week != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat ("Last saldo : {0}\n", TextParser.TimeToString(week.LastSaldo ));
                    sb.AppendFormat("Sunday: {0}\n", week.CountSunday );
                    sb.AppendFormat("Saturday: {0}\n", week.CountSaturday);
                    sb.AppendFormat("Work days before: {0}\n", week.WorkingDaysBefore);
                    sb.AppendFormat("Work days after: {0}\n", week.WorkingDaysAfter);

                    sb.AppendFormat("Month working time: {0}\n", TextParser.TimeToString(week.WorkingTimeByMonth));
                  
                    XtraMessageBox.Show(sb.ToString());
                }
            }
        }   
        private void mi_CopyFromPlanning_Click(object sender, EventArgs e)
        {
            CopyCurrentFromPlanning();
        }

        private void mi_CopyAllFromPlanning_Click(object sender, EventArgs e)
        {
            CopyAllFromPlanning();
        }

        private void CopyCurrentFromPlanning()
        {
            if (!IsUserCanEdit) return;

            EmployeeWeekView weekview = (EmployeeWeekView)GridViewRecording.GetRow(GridViewRecording.FocusedRowHandle);

            if (weekview != null)
            {
                if (weekview.CopyFromPlannedToActual(Context.AllowEditBeginDate, DateTime.Today))
                {
                    CalculateWeekly();
                    Context.Modified = true;
                }
            }
        }

        private void CopyAllFromPlanning()
        {
            if (!IsUserCanEdit) return;

            if (_weeksview != null)
            {
                bool modified = false;
                foreach (EmployeeWeekView weekview in _weeksview)
                {
                    modified |= weekview.CopyFromPlannedToActual(Context.AllowEditBeginDate , DateTime.Today);
                }

                if (modified)
                {
                    CalculateWeekly();
                    Context.Modified = true;
                }
            }
        }

        private void GridViewRecording_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            EmployeeWeekView weekview = GetEntityByRowHandle(e.RowHandle);
            if (Context == null) return;
            if (weekview != null)
            {

                if (e.Column == gcAdditionalHoursPlanned)
                {
                    int value = weekview.PlanningWeek.CountWeeklyAdditionalCharges;

                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalCharges(value);
                    e.Appearance.ForeColor = color;
                    return;
                }
                if (e.Column == gcPlusMinusHoursPlanned)
                {
                    int value = weekview.PlanningWeek.CountWeeklyPlusMinusHours ;

                    Color color = Context.CountryColors.GetColorByEmployeePlusMinus(value);
                    e.Appearance.ForeColor = color;
                    return;
                }
                if (e.Column == gcSaldoPlanned)
                {
                    int value = weekview.PlanningWeek.Saldo;

                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHours(value);
                    e.Appearance.ForeColor = color;
                    return;
                }
                if (e.Column == gcAdditionalHoursActual)
                {
                    int value = weekview.ActualWeek.CountWeeklyAdditionalCharges;

                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalCharges(value);
                    e.Appearance.ForeColor = color;
                    return;
                }
                if (e.Column == gcPlusMinusHoursActual)
                {
                    int value = weekview.ActualWeek.CountWeeklyPlusMinusHours;

                    Color color = Context.CountryColors.GetColorByEmployeePlusMinus(value);
                    e.Appearance.ForeColor = color;
                    return;
                }
                if (e.Column == gcSaldoActual)
                {
                    int value = weekview.ActualWeek.Saldo;

                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHours(value);
                    e.Appearance.ForeColor = color;
                    return;
                }
            }
        }

        private void GridViewRecording_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (Context.WorldActualState != null)
            {
                if (e.Column == gcPlusMinusHoursActual)
                {
                    int value = Context.WorldActualState.DaysSum.TotalPlusMinusHours ;
                    Color color = Context.CountryColors.GetColorByEmployeePlusMinusOverAllEmployee(value);

                    e.Appearance.ForeColor = color;
                    e.Handled = false;
                }
                else if (e.Column == gcAdditionalHoursActual)
                {
                    int value = Context.WorldActualState.DaysSum.TotalAdditionalCharges;
                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalChargesOverAllEmployee(value);
                    e.Appearance.ForeColor = color;
                    e.Handled = false;
                }
                else if (e.Column == gcSaldoActual)
                {
                    int value = Context.WorldActualState.DaysSum.TotalSaldo;
                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHoursOverAllEmployee(value);
                    e.Appearance.ForeColor = color;
                    e.Handled = false;

                } if (e.Column == gcPlusMinusHoursPlanned)
                {
                    int value = Context.WorldPlanningState.DaysSum.TotalPlusMinusHours;
                    Color color = Context.CountryColors.GetColorByEmployeePlusMinusOverAllEmployee(value);

                    e.Appearance.ForeColor = color;
                    e.Handled = false;
                }
                else if (e.Column == gcAdditionalHoursPlanned)
                {
                    int value = Context.WorldPlanningState.DaysSum.TotalAdditionalCharges;
                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalChargesOverAllEmployee(value);
                    e.Appearance.ForeColor = color;
                    e.Handled = false;
                }
                else if (e.Column == gcSaldoPlanned)
                {
                    int value = Context.WorldPlanningState .DaysSum.TotalSaldo;
                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHoursOverAllEmployee(value);
                    e.Appearance.ForeColor = color;
                    e.Handled = false;

                }
            }
        }


        public void PlayWorkingModelMessages()
        {
            if (Context != null && Context.WorldActualState != null)
            {
                if (FormEmployeeWorkingModelApplied.AllowShow)
                {
                    FormEmployeeWorkingModelApplied.PlayEmployeeWeeks(Context, Context.WorldActualState.List);

                }
            }
            else
            {
                FormEmployeeWorkingModelApplied.HideForm();
            }
        }
        GridBand _clickedBand = null;
        private void gcTimeRecording_MouseDown(object sender, MouseEventArgs e)
        {
            BandedGridHitInfo info =
                    GridViewRecording.CalcHitInfo(e.Location);

            if (info.InBandPanel)
            {
                _clickedBand = info.Band;
            }
        }

        private void gcTimeRecording_MouseMove(object sender, MouseEventArgs e)
        {
            _clickedBand = null;
        }
    }
}
