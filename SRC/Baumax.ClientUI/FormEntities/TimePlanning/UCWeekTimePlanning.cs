using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.Environment;
using DevExpress.Utils.Menu;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using Baumax.ClientUI.FormEntities.Employee;
using DevExpress.Utils.Drawing;
using DevExpress.Data;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCWeekTimePlanning : UCBaseEntity 
    {
        private CopyData _copyData = null;
        private StoreWorldWeekPlanningState _StoreWorldWeekState = null;

        private Dictionary<GridColumn, StoreDay> m_columnDiction = new Dictionary<GridColumn, StoreDay>(7);
        private GridColumn m_clickedColumn = null;

        private WorldPlanningContext m_context = null;

        private DateTime _BeginDate;
        private DateTime _EndDate;

        private string newLine = System.Environment.NewLine;

        private Dictionary<long, DateTime> _modifiedDays = new Dictionary<long, DateTime>();

        private List<HWGR> _CachedHwgrs;
        CashDeskWeeklyPlanningCalculator3 _calculator = new CashDeskWeeklyPlanningCalculator3();
        private UCCashDeskWeeklyInfo _ucCashDeskWeeklyInfo = null;
        #region member for drawing

        private Pen _focusedRectangleLine = new Pen(Color.Black);
        private Font _cellFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);//new Font("Verdana", 8F);
        private int _stringHeight = -1;

        #endregion

        public UCWeekTimePlanning()
        {
            InitializeComponent();
            
            BuildColumnDiction();

            _OnChangeStoreOrWorld = new FireChangedStoreOrWorld(m_context_OnChangedStoreOrWorld);
            
            _focusedRectangleLine.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            Disposed += new EventHandler(UCWeekTimePlanning_Disposed);
            deMonday.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
            deMonday.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
        }

        public bool CanEdit
        {
            get {
                    if (Context == null) return false;
                    return !Context.ReadOnly;
                }
        }

        void UCWeekTimePlanning_Disposed(object sender, EventArgs e)
        {
            if (Context != null) Context.OnChangedStoreOrWorld -= _OnChangeStoreOrWorld;
            _focusedRectangleLine.Dispose();
            _focusedRectangleLine = null;

        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                
                LocalizerControl.ComponentsLocalize(this.components);
                FillCaptionOfColumn();
            }
        }

        public void RefreshGrid()
        {
            gridView.RefreshData();
        }

        public DateTime BeginDate
        {
            get { return _BeginDate; }

            set
            {
                if (value != _BeginDate)
                {
                    _BeginDate = DateTimeHelper.GetMonday(value);
                    _EndDate = DateTimeHelper.GetSunday(BeginDate);

                    deMonday.DateTime = _BeginDate;
                    teSunday.Text = _EndDate.ToShortDateString();

                    if (Context != null) Context.LoadByWeek(_BeginDate, _EndDate);

                    //OnChangedContext();

                }

            }
        }
       
        public DateTime EndDate
        {
            get { return _EndDate; }
        }

        private void BuildColumnDiction()
        {
            m_columnDiction[gc_Monday] = null;
            m_columnDiction[gc_Tuesday] = null;
            m_columnDiction[gc_Wednesday] = null;
            m_columnDiction[gc_Thursday] = null;
            m_columnDiction[gc_Friday] = null;
            m_columnDiction[gc_Saturday] = null;
            m_columnDiction[gc_Sunday] = null;

            gc_Monday.Tag = DayOfWeek.Monday;
            gc_Tuesday.Tag = DayOfWeek.Tuesday;
            gc_Wednesday.Tag = DayOfWeek.Wednesday;
            gc_Thursday.Tag = DayOfWeek.Thursday;
            gc_Friday.Tag = DayOfWeek.Friday;
            gc_Saturday.Tag = DayOfWeek.Saturday;
            gc_Sunday.Tag = DayOfWeek.Sunday;

        }

        private void FillCaptionOfColumn()
        {
            if (Context != null && m_columnDiction != null && m_columnDiction.Count > 0)
            {
                foreach (GridColumn gc in m_columnDiction.Keys)
                {
                    StoreDay sd = m_columnDiction[gc];
                    if (sd != null)
                    {

                        gc.Caption = String.Format("{0}\n {2}\n {1}",
                            GetLocalized(sd.Date.DayOfWeek.ToString()),
                            DateTimeHelper.ShortTimeRangeToStr(sd.OpenTime, sd.CloseTime),
                            sd.Date.ToShortDateString());
                    }
                }
            }
        }
        private void FillGridColumns()
        {
            if (Context != null)
            {
                IStoreDaysList l = Context.StoreDays;
                if (l != null)
                {
                    m_columnDiction[gc_Monday] = l[Context.BeginTime];
                    m_columnDiction[gc_Tuesday] = l[Context.BeginTime.AddDays(1)];
                    m_columnDiction[gc_Wednesday] = l[Context.BeginTime.AddDays(2)];
                    m_columnDiction[gc_Thursday] = l[Context.BeginTime.AddDays(3)];
                    m_columnDiction[gc_Friday] = l[Context.BeginTime.AddDays(4)];
                    m_columnDiction[gc_Saturday] = l[Context.BeginTime.AddDays(5)];
                    m_columnDiction[gc_Sunday] = l[Context.BeginTime.AddDays(6)];

                    FillCaptionOfColumn();
                }
            }
        }

        public WorldPlanningContext Context
        {
            get { return m_context; }

            set 
            {
                if (m_context != value)
                {
                    if (m_context != null)
                    {
                        m_context.OnChangedStoreOrWorld -= _OnChangeStoreOrWorld;
                    }
                    m_context = value;
                    if (m_context != null)
                    {
                        m_context.OnChangedStoreOrWorld += _OnChangeStoreOrWorld;
                        _BeginDate = m_context.BeginTime;
                        _EndDate = m_context.EndTime;
                        deMonday.DateTime = _BeginDate;
                        teSunday.Text = _EndDate.ToShortDateString();
                    }
                }
            }
        }

        FireChangedStoreOrWorld _OnChangeStoreOrWorld = null;

        void m_context_OnChangedStoreOrWorld(bool anyEmployee)
        {
            OnChangedContext();
        }

        public bool IsInitGrid
        {
            get
            {
                return (gridControl.DataSource != null && gridView.RowCount > 0);
            }
        }

        public void OnChangedContext()
        {
            
            gridControl.DataSource = null;
            _StoreWorldWeekState = null;
            UpdateWorldEstimate();
            if (Context != null)
            {

                _StoreWorldWeekState = Context.WeeklyWorldState;

                gridControl.DataSource = null;
                if (_StoreWorldWeekState != null)
                {
                    gridControl.DataSource = _StoreWorldWeekState.List;
                    UpdateWorldEstimate();
                    BeginDate = Context.BeginTime;
                }
                
            }
            
            FillGridColumns();

            CalculateWeekly();
        }

        #region Grid column functionality
        
        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView.CalcHitInfo(e.Location);


            if (info.InColumn)
            {
                if (m_columnDiction.ContainsKey(info.Column) && m_clickedColumn == info.Column)
                {
                    if (IsInitGrid)
                    {
                        StoreDay sd = m_columnDiction[info.Column];
                        if (sd != null)
                        {
                            OnChangedToDailyView(sd.Date);
                        }
                    }
                }
            }
            else if (info.InRow && !info.InRowCell && info.HitTest == GridHitTest.RowIndicator)
            {
                DebugShowRowInfo();
            }

            
        }
        private void DebugShowRowInfo()
        {
            EmployeePlanningWeek weekview = GetEntityByRowHandle(gridView.FocusedRowHandle);

            if (weekview != null)
            {
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Last saldo : {0}\n", TextParser.TimeToString(weekview.LastSaldo));
                    sb.AppendFormat("Sunday: {0}\n", weekview.CountSunday);
                    sb.AppendFormat("Saturday: {0}\n", weekview.CountSaturday);
                    sb.AppendFormat("Work days before: {0}\n", weekview.WorkingDaysBefore);
                    sb.AppendFormat("Work days after: {0}\n", weekview.WorkingDaysAfter);
                    sb.AppendFormat("Month working time: {0}\n", TextParser.TimeToString(weekview.WorkingTimeByMonth));
                    

                    XtraMessageBox.Show(sb.ToString());
                }
            }
        }
        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView.CalcHitInfo(e.Location);

            if (info.InColumn)
                m_clickedColumn = info.Column;
            else
                m_clickedColumn = null;

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
                        gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                                        {
                                                                            new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                                                                            new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                                                                        });
                    else
                        gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                                        {
                                                                            new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder),
                                                                            new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder)
                                                                        });
                }
            }
        }

        #endregion


        public event ChangedToDailyView EventChangedToDailyView = null;
        protected virtual void OnChangedToDailyView(DateTime date)
        {
            if (EventChangedToDailyView != null)
                EventChangedToDailyView(date);
        }

        private void deMonday_DateTimeChanged(object sender, EventArgs e)
        {
            BeginDate = deMonday.DateTime;
            UpdateWeekNumber();
        }
        private void UpdateWeekNumber()
        {
            deMonday.Properties.Buttons[1].Caption = Convert.ToString(DateTimeHelper.GetWeekNumber(BeginDate, BeginDate));
        }

        #region control helper function and methods


        

        protected bool IsFocusedCell(GridColumn column, int rowHandle)
        {
            return (column == gridView.FocusedColumn &&
                            rowHandle == gridView.FocusedRowHandle);
        }

        protected bool IsEditingCell(GridColumn column, int rowHandle)
        {
            return (column == gridView.FocusedColumn &&
                            rowHandle == gridView.FocusedRowHandle
                            && gridView.IsEditorFocused);
        }

        public EmployeePlanningWeek GetEntityByRowHandle(int handle)
        {
            if (gridView.IsDataRow(handle))
                return (EmployeePlanningWeek)gridView.GetRow(handle);

            return null;
        }

        public StoreDay GetStoreDay(GridColumn column)
        {
            if (m_columnDiction.ContainsKey(column))
                return m_columnDiction[column];
            return null;
        }
        public EmployeePlanningDay GetPlanningDay()
        {
            return GetPlanningDay(gridView.FocusedColumn, gridView.FocusedRowHandle);
        }
        public EmployeePlanningDay GetPlanningDay(GridColumn column, int rowHandle)
        {
            StoreDay sd = GetStoreDay(column);

            if (sd == null) return null;

            EmployeePlanningWeek epw = GetEntityByRowHandle(rowHandle);

            if (epw == null) return null;

            if (epw.Days.ContainsKey(sd.Date))
                return epw.Days[sd.Date];

            return null;
        }


        #endregion

        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);

            if (!IsDesignMode)
            {
                _CachedHwgrs = ClientEnvironment.HWGRService.FindAll();
                riHwgrLookUpEdit.DataSource = _CachedHwgrs;
                gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                       {
                                                           new GridColumnSortInfo(gc_HWGR, ColumnSortOrder.Ascending),
                                                           new GridColumnSortInfo(gc_Employee, ColumnSortOrder.Ascending)
                                                       });
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            if (IsFocusedCell(e.Column, e.RowHandle))
            {
                EmployeePlanningDay dayPlan = GetPlanningDay(e.Column, e.RowHandle);

                if (dayPlan != null)
                {
                    StringBuilder sb = new StringBuilder();

                    List<__TimeRange> lstRanges = GetCellContent(dayPlan);

                    foreach (__TimeRange tr in lstRanges)
                        sb.AppendLine(tr.AsTimeEditString);

                    
                    e.Value = sb.ToString();
                }
            }
            EmployeePlanningWeek epw = GetEntityByRowHandle(e.RowHandle);

            /*if (e.Column.Equals(gc_AllreadyPlannedWorkingHours))
            {
                if (epw != null)
                    e.Value = DateTimeHelper.IntTimeToStr(epw.CountWeeklyPlanningWorkingHours);
                else
                    e.Value = DateTimeHelper.IntTimeToStr(0);
                return;
            }*/
            if (e.Column.Equals(gc_ContractWorkingHours))
            {
                if (!epw.IsValidWeek)
                    e.Value = "--:--";
                else 
                    e.Value = DateTimeHelper.IntTimeToStr(epw.ContractHoursPerWeek);
                return;
            }
            if (e.Column.Equals(gc_SummOfAdditionalCharges))
            {
                // acpro 121090 comment 4
                if (epw.AllIn || !epw.IsValidWeek )
                    e.Value = "--:--";
                else 
                    e.Value = DateTimeHelper.IntTimeToStr(epw.CountWeeklyAdditionalCharges);
                return;
            }
            if (e.Column.Equals(gc_PlusMinusHours))
            {
                if (!epw.IsValidWeek)
                    e.Value = "--:--";
                else 
                    e.Value = DateTimeHelper.IntTimeToStr(epw.CountWeeklyPlusMinusHours);
                return;
            }
            if (e.Column.Equals(gc_EmployeeBalanceHours))
            {
                if (epw.AllIn || !epw.IsValidWeek)
                    e.Value = "--:--";
                else 
                    e.Value = DateTimeHelper.IntTimeToStr(epw.Saldo);
                return;
            }
        }

        private void MoveToNextCell()
        {
            if (m_columnDiction.ContainsKey(gridView.FocusedColumn))
            {
                int currentRow = gridView.FocusedRowHandle ;
                StoreDay sd = m_columnDiction[gridView.FocusedColumn ];
                if (sd == null) return;

                if (sd.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (gridView.IsLastRow)
                        gridView.MoveFirst();
                    else
                        gridView.MoveNext();

                    gridView.FocusedColumn = gc_Monday;

                    gridView.MakeColumnVisible(gc_Monday);
                }
                else
                {
                    gridView.FocusedColumn = gridView.GetVisibleColumn(gridView.FocusedColumn.VisibleIndex + 1);
                    gridView.MakeColumnVisible(gc_Monday);
                }
                
            }
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;


                try
                {
                    if (gridView.IsEditing)
                    {
                        if (gridView.IsEditorFocused && gridView.ValidateEditor())
                            MoveToNextCell();
                    }
                    else MoveToNextCell();
                }
                catch (HideException){}

            }
            if (e.KeyCode == Keys.C && e.Control)
            {
                e.SuppressKeyPress = true;
                mi_Copy_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.V && e.Control)
            {
                e.SuppressKeyPress = true;
                mi_Paste_Click(null, null);
                return;
            }

            if (e.KeyCode == Keys.Home && e.Control)
            {
                ShowDebugForm();
            }
            if (e.KeyCode == Keys.End && e.Control)
            {
                EmployeePlanningWeek w = GetEntityByRowHandle(gridView.FocusedRowHandle);
                if (w != null)
                {
                    EmployeeInfoDebugForm f = new EmployeeInfoDebugForm();
                    f.ShowInfo(w.EmployeeId);
                }
            }
//#if  DEBUG
            //if (e.KeyCode == Keys.D0 && e.Control)
            //{
            //    ClientEnvironment.EmployeeService.DebugRecalculation();
            //}
//#endif
        }

        private void ShowDebugForm()
        {
            DebugFormViewAllWorkingModel form = new DebugFormViewAllWorkingModel();
            form.FillGrid(m_context, _StoreWorldWeekState.List);
            form.ShowDialog ();
        }

        private void repositoryItemTimes_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            /*if (!CanEdit) return;
            EmployeePlanningDay dayPlan = GetPlanningDay();

            if (dayPlan != null && IsEditingCell (gridView.FocusedColumn , gridView.FocusedRowHandle))
            {
                if (errorValue != null)
                {
                    StringBuilder sb = new StringBuilder();
                    if (dayPlan.WorkingTimeList != null)
                    {

                        foreach (WorkingTimePlanning w in dayPlan.WorkingTimeList)
                        {
                            sb.AppendLine(TextParser.TimeRangeToEditString(w.Begin, w.End));
                        }
                    }

                    e.Value = sb.ToString();
                    e.Handled = true;
                }
                else
                {
                    e.Value = errorValue;
                    e.Handled = true;
                }
            }*/
        }

        private void gridView_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (Context != null)
            {
                StoreDay storeday = GetStoreDay(e.Column);

                if (storeday != null)
                {
                    DrawWeekDayCell(e);
                    e.Handled = true;
                    return;
                }
                

            }
            else e.Handled = false;
        }


        private void DrawWeekDayCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            StoreDay storeday = GetStoreDay(e.Column);

            EmployeePlanningDay epd = GetPlanningDay(e.Column, e.RowHandle);
            
            if (storeday == null || epd == null) return;

            DrawBackgroundWeekDayCell(storeday, epd, e);

            DrawWeekDayContent(storeday, epd, e);


        }

        private void DrawWeekDayContent(StoreDay storeday, EmployeePlanningDay epd, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if (epd.HasLongAbsence)
            {
                string s = Context.GetLongTimeAbbreviation(epd.LongAbsenceId);
                if (String.IsNullOrEmpty(s)) return;
                Font cellfont = _cellFont;
                Brush cellbrush = Brushes.White;
                Rectangle cellBound = Rectangle.Inflate(e.Bounds, -1, -1);
                StringFormat sformat = e.Column.AppearanceCell.TextOptions.GetStringFormat();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;
                e.Cache.DrawString(s, cellfont, e.Cache.GetSolidBrush(e.Appearance.ForeColor), cellBound, sformat);
            }
            else
            {
                List<string> lstValues = new List<string>();

                List<__TimeRange> lst = GetCellContent(epd);
                
                if (lst.Count > 0)
                {
                    Rectangle cellBound = Rectangle.Inflate(e.Bounds, -1, -1);
                    StringFormat sformat = e.Column.AppearanceCell.TextOptions.GetStringFormat();
                    sformat = new StringFormat();
                    sformat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces | 
                                            StringFormatFlags.NoWrap ;
                    
                    Font cellfont = _cellFont;
                    Brush cellbrush = Brushes.Black;
                    Brush absenceBrush = null;
                    string str = String.Empty;

                    foreach (__TimeRange sValue in lst)
                    {
                        str = sValue.AsTimeString;
                        SizeF sf = e.Cache.CalcTextSize(str, cellfont, sformat, 10000);
                        if (String.IsNullOrEmpty(sValue.AbsenceCode))
                        {
                            e.Cache.DrawString(str, cellfont, cellbrush, cellBound, sformat);
                        }
                        else
                        {
                            absenceBrush = e.Cache.GetSolidBrush(sValue.BeginColor);
                            e.Cache.DrawString(str, cellfont, absenceBrush, cellBound, sformat);
                            //absenceBrush.Dispose();
                        }

                       

                        cellBound.Y += (int)(sf.Height + 2);
                    }

                }
            }


        }
        
        private void DrawBackgroundWeekDayCell(StoreDay storeday, EmployeePlanningDay epd, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (IsFocusedCell(e.Column, e.RowHandle))
            {
                //color = Color.LightBlue;
                Pen focusedRectangleLine = e.Cache.GetPen (Color.Black);
                e.Cache.FillRectangle(Painters.FOCUSED_COLOR, Rectangle.Inflate(e.Bounds, 1, 1));
                e.Cache.DrawRectangle(focusedRectangleLine, Rectangle.Inflate(e.Bounds, 1, 1));
            }
            else
            {
                Color color = Painters.EMPTY_COLOR;
                if (storeday.Feast) color = Painters.FEAST_COLOR;
                if (storeday.ClosedDay) color = Painters.CLOSEDDAY_COLOR;
                if (epd.CountDailyAdditionalCharges > 0) color = Painters.ADDITIONAL_CHARGES_COLOR;// Color.Red;
                if (Context != null)
                {
                    if (epd.WorldId != Context.CurrentStoreWorldId || epd.HasLongAbsence)
                    {
                        color = Painters.DISABLE_COLOR;
                    }

                    if (epd.HasLongAbsence)
                    {
                        int? c = Context.GetLongTimeAbsenceColor(epd.LongAbsenceId);

                        if (c.HasValue)
                            color = Color.FromArgb(c.Value);
                    }
                }



                e.Cache.FillRectangle(color, Rectangle.Inflate(e.Bounds, 1, 1));
            }
             
        }

        public List<__TimeRange> GetCellContent(EmployeePlanningDay epd)
        {
            List<__TimeRange> result = new List<__TimeRange>();
            if (epd.WorkingTimeList != null)
            {
                foreach (WorkingTimePlanning wtp in epd.WorkingTimeList)
                    result.Add(new __TimeRange(wtp.Begin, wtp.End));
            }

            if (epd.AbsenceTimeList != null)
            {
                foreach (AbsenceTimePlanning atp in epd.AbsenceTimeList)
                    //if (atp.Absence != null && atp.Absence.IsFixed)
                    //{
                    //    result.Add(new __TimeRange(atp.Begin, atp.End, atp.Absence.CharID, Color.FromArgb(atp.Absence.Color)));
                    //}
                    //else
                        result.Add(new __TimeRange(atp.Begin, atp.End, atp.Absence.CharID, Color.FromArgb(atp.Absence.Color), false));
            }
            result.Sort ();

            return result;

        }

        private void gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (!CanEdit)
            {
                e.Cancel = true;
                return;
            }
            EmployeePlanningDay epd = GetPlanningDay();

            if (Context != null && epd != null)
            {
                bool b = Context.CurrentStoreWorldId != epd.WorldId;
                b |= epd.HasLongAbsence;
                b |= !epd.HasContract;
                b |= !epd.HasRelation;
                b |= (epd.Date < DateTime.Today);
                e.Cancel = b;
            }
            else e.Cancel = true;
        }

        private void gridView_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {

            EmployeePlanningWeek pl_week = GetEntityByRowHandle(e.RowHandle);
            
            if (_stringHeight == -1)
            {
                Graphics graphics = gridControl.CreateGraphics();
                try
                {
                    Size sf = graphics.MeasureString("222", _cellFont).ToSize();
                    _stringHeight = sf.Height;
                    //_stringHeight += 4;
                    gridView.RowHeight = _stringHeight;
                }
                finally
                {
                    graphics.Dispose();
                }
            }

            int maxCountLine = 0;
            int countLine = 0;
            foreach (EmployeePlanningDay epd in pl_week.Days.Values)
            {
                countLine = 0;
                if (epd.WorkingTimeList != null) countLine = epd.WorkingTimeList.Count;
                if (epd.AbsenceTimeList != null) countLine += epd.AbsenceTimeList.Count;
                maxCountLine = Math.Max(maxCountLine, countLine);
            }

            int cellHeight = maxCountLine * _stringHeight + maxCountLine * 2 + 2;

            if (cellHeight > 0) e.RowHeight = cellHeight;



            //int summHeight = 0;
            //int curHeight = 0;// e.RowHeight;
            //foreach (EmployeePlanningDay epd in pl_week.Days.Values)
            //{
            //    summHeight = 0;
            //    if (epd.WorkingTimeList != null) summHeight += epd.WorkingTimeList.Count;
            //    if (epd.AbsenceTimeList != null) summHeight += epd.AbsenceTimeList.Count;
            //    if (summHeight == 0) summHeight++;

            //    summHeight *= _stringHeight;

            //    summHeight += 4;
            //    curHeight = Math.Max(curHeight, summHeight);
            //    if (curHeight < summHeight) curHeight = summHeight;
            //}

            //if (curHeight > 0) e.RowHeight = curHeight;
                             

        }


        //private bool ValidateTimeRanges(List<__TimeRange> lst, out string errorText)
        //{
        //    errorText = String.Empty;
        //    if (lst == null || lst.Count == 0) return true;
        //    lst.Sort();

        //    foreach (__TimeRange tr in lst)
        //    {
        //        if (tr.BeginTime >= tr.EndTime)
        //        {
        //            errorText = GetLocalized("PlanningTimeRangeInvalid");
        //            if (String.IsNullOrEmpty(errorText))
        //                errorText = "Begin time-range should be less than end time-range";

        //            errorText = String.Format("{0}\n{1}", errorText, tr.AsTimeString);
        //            //ErrorMessage(sError);
        //            return false;
        //        }
        //    }


        //    __TimeRange prev = null;
        //    foreach (__TimeRange tr in lst)
        //    {
        //        if (prev == null)
        //        {
        //            prev = tr;
        //            continue;
        //        }
        //        if (prev.IsIntersect(tr))
        //        {
        //            errorText = GetLocalized("PlanningTimeRangeIntersect");
        //            if (String.IsNullOrEmpty(errorText))
        //                errorText = "Time-ranges intersect ";

        //            errorText = String.Format("{0}\n{1}\n{2}", errorText, prev.AsTimeString, tr.AsTimeString);
        //            //ErrorMessage(sError);
        //            return false;
        //        }
        //        prev = tr;
        //    }
        //    return true;

        //}
        string errorValue = null;

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
                            tr.AbsenceId = absence.ID;
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
        private void gridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (!CanEdit) return;

            String s = (string)e.Value;

            try
            {
                EmployeePlanningDay epd = GetPlanningDay();

                StoreDay sd = Context.StoreDays[epd.Date];
                


                int count = ((short)(Utills.AvgWorkingHoursPerDay(epd.PlanningWeek.ContractHoursPerWeek, Context.StoreDays.AvgDayInWeek)));

                ParserEx ex = new ParserEx(Context.Absences,sd.OpenTime, sd.CloseTime, count);
                ex.ParserText(s);
                List<__TimeRange> lst = ex.Ranges;
                /*EmployeePlanningDay epd = GetPlanningDay();

                StoreDay sd = Context.StoreDays[epd.Date];
                List<__TimeRange> lst = TextParser.ParseText2(sd,s);


                int count = DateTimeHelper.RoundToQuoter((short)(Utills.AvgWorkingHoursPerDay(epd.PlanningWeek.ContractHoursPerWeek , Context.StoreDays.AvgDayInWeek)));
                    //DateTimeHelper.RoundToQuoter((short)((epd.PlanningWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek)));
                CheckCountAliquotAbsences(lst, sd, count);

                TimeRangeValidator validator = new TimeRangeValidator();
                validator.AddAndValidate(lst);
                */
                if (CompareWithOriginalData(lst, epd))
                {
                    if (epd.AbsenceTimeList != null)
                        Context.Absences.FillAbsencePlanningTimes(epd.AbsenceTimeList);


                    Context.Modified = true;
                    CalculateWeekly();
                }
                /*
                EmployeeDayView dayView = new EmployeeDayView(epd.EmployeeId, epd.Date);
                EmployeeDayView dayViewOriginal = new EmployeeDayView(epd.EmployeeId, epd.Date);
                dayViewOriginal.SetEmployeePlanningDay(epd);
                dayView.PlanningDay = epd;
                dayView.Modified = true;
                if (lst != null)
                {
                    foreach (__TimeRange tr in lst)
                    {
                        if (String.IsNullOrEmpty(tr.AbsenceCode))
                        {
                            dayView.AddWorkingTime(tr.BeginTime, tr.EndTime);
                        }
                        else
                        {
                            Absence absence = Context.Absences.GetByAbbreviation(tr.AbsenceCode);
                            if (absence != null)
                                dayView.SetAbsence(absence, tr.BeginTime, tr.EndTime);
                        }
                    }
                }
                

                if (!dayView.Compare(dayViewOriginal))
                {
                    dayView.UpdateEmployeePlanningDay();

                    if (epd.AbsenceTimeList != null)
                        Context.Absences.FillAbsencePlanningTimes(epd.AbsenceTimeList);


                    Context.Modified = true;
                    CalculateWeekly();
                }
                 */
                e.Valid = true;

                
            }
            catch (Exception ex)
            {
                e.Valid = false;
                XtraMessageBox.Show(ex.Message);
            }


            
        }
        private bool CompareWithOriginalData(List<__TimeRange> ranges, EmployeePlanningDay day)
        {
            bool bModified = false;

            List<__TimeRange> originalList = GetCellContent(day);
            List<__TimeRange> newList = ranges;
            if (ranges == null)
                newList = new List<__TimeRange>();

            if (newList.Count == originalList.Count)
            {
                Dictionary<string, __TimeRange> diction = new Dictionary<string, __TimeRange>();
                foreach (__TimeRange r in newList)
                    diction[r.AsTimeString] = r;


                foreach (__TimeRange new_range in originalList)
                {
                    string key = new_range.AsTimeString;
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
        private void FillPlanningDayByTimeRange(List<__TimeRange> ranges, EmployeePlanningDay day)
        {
            if (ranges == null || ranges.Count == 0)
            {
                day.WorkingTimeList = null;
                day.AbsenceTimeList = null;
                day.Modified = true;
                return;
            }

            day.WorkingTimeList = null;
            day.AbsenceTimeList = null;

            foreach (__TimeRange range in ranges)
            {
                if (range.Validation())
                {
                    if (!String.IsNullOrEmpty(range.AbsenceCode))
                    {
                        Absence absence = Context.Absences.GetByAbbreviation(range.AbsenceCode);
                        if (absence != null)
                        {
                            AbsenceTimePlanning entity = new AbsenceTimePlanning();
                            entity.Date = day.Date;
                            entity.AbsenceID = absence.ID;
                            entity.Begin = range.BeginTime;
                            entity.End = range.EndTime;
                            entity.Time = (short)(entity.End - entity.Begin);
                            entity.EmployeeID = day.EmployeeId;

                            if (day.AbsenceTimeList == null)
                                day.AbsenceTimeList = new List<AbsenceTimePlanning>();
                            day.AbsenceTimeList.Add(entity);
                        }
                    }
                    else
                    {
                        WorkingTimePlanning entity = new WorkingTimePlanning();
                        entity.Date = day.Date;
                        entity.Begin = range.BeginTime;
                        entity.End = range.EndTime;
                        entity.Time = (short)(entity.End - entity.Begin);
                        entity.EmployeeID = day.EmployeeId;

                        if (day.WorkingTimeList == null)
                            day.WorkingTimeList = new List<WorkingTimePlanning>();
                        day.WorkingTimeList.Add(entity);
                    }
                }
            }
            day.Modified = true;

        }
        private void CalculateWeekly()
        {
            if (_StoreWorldWeekState != null)
            {
                _StoreWorldWeekState.Calculate();


                _UpdateWorldEstimateInfoControls();
            }
            PlayWorkingModelMessages();
            gridView.RefreshData();
        }

        private void _UpdateWorldEstimateInfoControls()
        {
            if (_StoreWorldWeekState.IsCashDesk)
            {
                _ucCashDeskWeeklyInfo.UpdateStoreWorldInfo ();//.UpdateInfo(_StoreWorldWeekState.GetDaySums());
                //_calculator.AssignPlannedInfo(_StoreWorldWeekState.GetDaySums(), _StoreWorldWeekState.datas);
                _calculator.AssignPlannedInfo(_StoreWorldWeekState.Summary);

            }
            else
                storeWorldPanleInfo1.UpdateInfo();
        }

        public  void PlayWorkingModelMessages()
        {
            if (_StoreWorldWeekState != null)
            {
                if (FormEmployeeWorkingModelApplied.AllowShow)
                {
                    FormEmployeeWorkingModelApplied.PlayEmployeeWeeks (m_context, _StoreWorldWeekState.List);
                    
                }
            }
            else
            {
                FormEmployeeWorkingModelApplied.HideForm ();
            }
        }

        private void UpdateWorldEstimate()
        {
            if (_StoreWorldWeekState != null)
            {
                if (_StoreWorldWeekState.IsCashDesk)
                {
                    panelControl3.Visible = true;
                    if (_ucCashDeskWeeklyInfo == null)
                    {
                        _ucCashDeskWeeklyInfo = new UCCashDeskWeeklyInfo();
                        _ucCashDeskWeeklyInfo.Parent = panelControl3;
                        _ucCashDeskWeeklyInfo.Dock = DockStyle.Fill;
                        //if (Context != null)
                        //    _ucCashDeskWeeklyInfo.ColorManager = Context.CountryColors;
                       
                    }
                    storeWorldPanleInfo1.Visible = false;
                    storeWorldPanleInfo1.WorldInfo = null;

                    _ucCashDeskWeeklyInfo.Visible = true;

                    _ucCashDeskWeeklyInfo.CashDeskInfo = _StoreWorldWeekState.StoreWorldInfo as CashDeskPlanningInfo;

                        //SetCashDeskInfo (_StoreWorldWeekState.StoreWorldInfo as CashDeskPlanningInfo, _StoreWorldWeekState.BeginWeekDate );
                    //_ucCashDeskWeeklyInfo.UpdateStoreWorldInfo();

                    _calculator.AssignCashDeskInfo(_StoreWorldWeekState.StoreWorldInfo as CashDeskPlanningInfo, _StoreWorldWeekState.BeginWeekDate);
                }
                else
                {
                    if (_ucCashDeskWeeklyInfo != null)
                    {
                        _ucCashDeskWeeklyInfo.Visible = false;
                        _ucCashDeskWeeklyInfo.CashDeskInfo = null;
                        _calculator.Clear();
                    }

                    panelControl3.Visible = true;
                     
                    if (Context != null)
                        storeWorldPanleInfo1.ColorManager = Context.CountryColors;
                    storeWorldPanleInfo1.Visible = true;
                    storeWorldPanleInfo1.WorldInfo = _StoreWorldWeekState.StoreWorldInfo as StoreWorldPlanningInfo;
                }
            }
            else
            {
                panelControl3.Visible = false;
            }
        }

        #region Context menu events

        private void contextMenuWeekly_Opening(object sender, CancelEventArgs e)
        {
            if (!CanEdit)
            {
                e.Cancel = true;
                return;
            }
            EmployeePlanningDay planningday = GetPlanningDay();
            if (m_columnDiction.ContainsKey(gridView.FocusedColumn) && planningday != null && Context != null)
            {
                mi_Copy.Enabled = true;
                mi_Paste.Enabled = (_copyData != null) && Context.CanEditEmployeeDay (planningday);
                mi_Absence.Enabled = mi_ClearTime.Enabled = Context.CanEditEmployeeDay(planningday);
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mi_Copy_Click(object sender, EventArgs e)
        {
            EmployeePlanningDay planningday = GetPlanningDay();
            if (planningday != null )//&& Context != null && Context.CanEditEmployeeDay (planningday ))
            {
                if (_copyData == null) _copyData = new CopyData();

                _copyData.Assign(planningday);
            }
        }

        private void mi_Paste_Click(object sender, EventArgs e)
        {
            if (!CanEdit) return;
            EmployeePlanningDay planningday = GetPlanningDay();
            if (planningday != null && Context != null && Context.CanEditEmployeeDay(planningday))
            {
                if (_copyData != null)
                {
                    _copyData.AssignTo(planningday);
                    CalculateWeekly();
                    if (planningday.Modified)
                    {
                        Context.Modified = true;
                    }

                }
            }

        }

        private void mi_Clear_Click(object sender, EventArgs e)
        {
            if (!CanEdit) return;
            EmployeePlanningDay planningday = GetPlanningDay();
            if (planningday != null && Context != null && Context.CanEditEmployeeDay(planningday))
            {
                planningday.Clear();
                if (planningday.Modified)
                    Context.Modified = true;
                CalculateWeekly();
            }
        }

        private void mi_Absence_Click(object sender, EventArgs e)
        {
            if (!CanEdit) return;
            EmployeePlanningDay planningday = GetPlanningDay();
            if (planningday != null && Context != null && Context.CanEditEmployeeDay(planningday))
            {
                using (FormSelectAbsence formSelectAbsence = new FormSelectAbsence())
                {
                    formSelectAbsence.IsPlanning = true;
                    formSelectAbsence.Absences = Context.Absences.ToList;
                    StoreDay sd = Context.StoreDays[planningday.Date];
                    formSelectAbsence.ShowTimePanel = true;
                    formSelectAbsence.SetDayInfo(sd.OpenTime, sd.CloseTime, Context.StoreDays.AvgDayInWeek);


                    if (formSelectAbsence.Execute())
                    {
                        EmployeeDayView dayview = new EmployeeDayView(planningday.EmployeeId, planningday.Date);
                        dayview.SetEmployeePlanningDay(planningday);

                        Absence absence = formSelectAbsence.SelectedAbsence;
                        short begintime = sd.OpenTime;
                        short endtime = sd.CloseTime;

                        AbsenceTimePlanning entity = new AbsenceTimePlanning();
                        entity.EmployeeID = planningday.EmployeeId;
                        entity.AbsenceID = absence.ID;
                        entity.Absence = absence;
                        entity.Date = planningday.Date;
                        if (absence.IsFixed)
                        {
                            //int count = DateTimeHelper.RoundToQuoter((short)((planningday.PlanningWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek)));
                            int count = (short)((planningday.PlanningWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek));
                            if (Utills.MinutesInDay < ((int)begintime + count))
                                endtime = Utills.MinutesInDay;
                            else
                                endtime = (short)(begintime + count);

                            entity.Begin = begintime;
                            entity.End = endtime;
                            
                            dayview.SetAbsence(absence, begintime, endtime);
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

                                dayview.SetAbsence(absence, begintime, endtime);
                            }
                            else
                            {
                                entity.Begin = formSelectAbsence.BeginTime;
                                entity.End = formSelectAbsence.EndTime;
                                dayview.SetAbsence(formSelectAbsence.SelectedAbsence, formSelectAbsence.BeginTime, formSelectAbsence.EndTime);
                            }

                        if (EmployeeTimeRangeHelper.InsertTimeRange(planningday, entity))
                        {
                            if (planningday.AbsenceTimeList != null)
                                Context.Absences.FillAbsencePlanningTimes(planningday.AbsenceTimeList);
                            planningday.Modified = true;
                            Context.Modified = true;
                            CalculateWeekly();
                        }
                        //if (dayview.Modified )
                        //{
                        //    dayview.UpdateEmployeePlanningDay();
                        //    if (planningday.AbsenceTimeList != null)
                        //        Context.Absences.FillAbsencePlanningTimes(planningday.AbsenceTimeList);
                        //    Context.Modified = true;
                        //    CalculateWeekly();
                        //}
                    }
                }
            }
        }

        #endregion

        private class CopyData
        {
            public List<WorkingTimePlanning> WorkingTimes = new List<WorkingTimePlanning> ();
            public List<AbsenceTimePlanning> AbsenceTimes = new List<AbsenceTimePlanning>();

            public void Assign(EmployeePlanningDay employeeday)
            {
                Clear();
                if (employeeday.WorkingTimeList != null)
                    WorkingTimes.AddRange(employeeday.WorkingTimeList);

                if (employeeday.AbsenceTimeList != null)
                    AbsenceTimes.AddRange(employeeday.AbsenceTimeList); 
            }

            public void Clear()
            {
                WorkingTimes.Clear();
                AbsenceTimes.Clear();
            }


            public void AssignTo(EmployeePlanningDay employeeday)
            {
                if (employeeday.WorkingTimeList == null)
                    employeeday.WorkingTimeList = new List<WorkingTimePlanning>();
                else employeeday.WorkingTimeList.Clear();

                WorkingTimePlanning entity = null;
                foreach (WorkingTimePlanning wtp in WorkingTimes)
                {
                    entity = new WorkingTimePlanning();
                    
                    entity.ID = 0;
                    entity.EmployeeID = employeeday.EmployeeId;
                    entity.Date = employeeday.Date;
                    entity.Begin = wtp.Begin;
                    entity.End = wtp.End;
                    entity.Time = (short)(entity.End - entity.Begin);
                    
                    employeeday.WorkingTimeList.Add(entity);
                    
                }
                


                if (employeeday.AbsenceTimeList == null)
                    employeeday.AbsenceTimeList = new List<AbsenceTimePlanning>();
                else employeeday.AbsenceTimeList.Clear();

                AbsenceTimePlanning entity1 = null;
                foreach (AbsenceTimePlanning atp in AbsenceTimes)
                {
                    entity1 = new AbsenceTimePlanning();
                    entity1.ID = 0;
                    entity1.EmployeeID = employeeday.EmployeeId;
                    entity1.Date = employeeday.Date;
                    entity1.Begin = atp.Begin;
                    entity1.End = atp.End;
                    entity1.AbsenceID = atp.AbsenceID;
                    entity1.Absence = atp.Absence;
                    
                    employeeday.AbsenceTimeList.Add(entity1);
                }
                
                employeeday.Modified = true;
            }
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            EmployeePlanningWeek epd = GetEntityByRowHandle(e.RowHandle);

            if (epd != null)
            {
                if (e.Column == gc_SummOfAdditionalCharges)
                {
                    int value = epd.CountWeeklyAdditionalCharges;

                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalCharges(value);
                    e.Appearance.ForeColor = color;
                }
                if (e.Column == gc_PlusMinusHours)
                {
                    int value = epd.CountWeeklyPlusMinusHours;

                    Color color = Context.CountryColors.GetColorByEmployeePlusMinus (value);
                    e.Appearance.ForeColor = color;

                }
                if (e.Column == gc_EmployeeBalanceHours)
                {
                    int value = epd.Saldo ;

                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHours (value);
                    e.Appearance.ForeColor = color;
                }
            }
        }

        private void gridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (_StoreWorldWeekState != null)
            {
                if (e.Column == gc_PlusMinusHours)
                {
                    int value = _StoreWorldWeekState.ColumnSumPlusMinusHours;
                    Color color = Context.CountryColors.GetColorByEmployeePlusMinusOverAllEmployee(value);
                    
                    e.Appearance.ForeColor = color;
                    e.Info.DisplayText = DateTimeHelper.IntTimeToStr(_StoreWorldWeekState.ColumnSumPlusMinusHours);
                    e.Handled = false;
                }
                else if (e.Column == gc_SummOfAdditionalCharges)
                {
                    int value = _StoreWorldWeekState.ColumnSumAdditionalCharges;
                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalChargesOverAllEmployee(value);
                    e.Appearance.ForeColor = color;
                    e.Info.DisplayText = DateTimeHelper.IntTimeToStr(_StoreWorldWeekState.ColumnSumAdditionalCharges);
                    e.Handled = false;
                }
                else if (e.Column == gc_EmployeeBalanceHours)
                {
                    int value = _StoreWorldWeekState.ColumnSumSaldo ;
                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHoursOverAllEmployee (value);
                    e.Appearance.ForeColor = color;
                    e.Info.DisplayText = DateTimeHelper.IntTimeToStr(_StoreWorldWeekState.ColumnSumSaldo);
                    e.Handled = false;

                }
                else if (e.Column == gc_ContractWorkingHours)
                {
                    e.Info.DisplayText = DateTimeHelper.IntTimeToStr(_StoreWorldWeekState.ColumnSumContractWorkingHoursPerWeek);
                    e.Handled = false;
                }
            }

            if (e.Column == gc_ContractWorkingHours)
            {
                DrawTotalFooter(e);
            }
 
            if (m_columnDiction.ContainsKey(e.Column))
            {
                
                DayOfWeek dw = (DayOfWeek)e.Column.Tag;

                if (_StoreWorldWeekState == null || !_StoreWorldWeekState.IsCashDesk) 
                    DrawDayOfWeek_CommonWorld(e, dw);
                else
                    DrawDayOfWeek_CashDesk(e, dw);
                
            }
            if (e.Column == gc_Employee )
            {
                DrawHeaderFooter(e);
            }
            
        }
        private void DrawHeaderFooter(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (_StoreWorldWeekState == null || !_StoreWorldWeekState.IsCashDesk)
            {
                String targHours = GetLocalized("TargetedHours");
                String DifferenceInPercent = GetLocalized("DifferenceInPercent");
                e.Painter.DrawObject(e.Info);

                int iWidth = (gc_HWGR.Visible) ? gc_HWGR.Width : 0;

                Rectangle oldBounds = e.Info.Bounds;
                string oldText = e.Info.DisplayText;

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width + iWidth, e.Info.Bounds.Height);

                e.Info.DisplayText = targHours;
                DevExpress.Utils.HorzAlignment oldHAlignment = e.Info.Appearance.TextOptions.HAlignment;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height * 2);
                e.Info.DisplayText = DifferenceInPercent;
                e.Painter.DrawObject(e.Info);


                e.Info.Bounds = oldBounds;
                e.Info.DisplayText = oldText;
                e.Info.Appearance.TextOptions.HAlignment = oldHAlignment;
            }
            else
            {
                String planHours = GetLocalized("PlannedHours");
                String targHours = GetLocalized("TargetedHours");
                String DifferenceInPercent = GetLocalized("DiffInPercent");

                e.Painter.DrawObject(e.Info);

                int iWidth = (gc_HWGR.Visible) ? gc_HWGR.Width : 0;

                Rectangle oldBounds = e.Info.Bounds;
                string oldText = e.Info.DisplayText;

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width + iWidth, e.Info.Bounds.Height);

                e.Info.DisplayText = planHours;
                DevExpress.Utils.HorzAlignment oldHAlignment = e.Info.Appearance.TextOptions.HAlignment;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = targHours;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = DifferenceInPercent;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = oldBounds;
                e.Info.DisplayText = oldText;
                e.Info.Appearance.TextOptions.HAlignment = oldHAlignment;
            }
            e.Handled = true;
        }
        private void DrawDayOfWeek_CommonWorld(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e, DayOfWeek dw)
        {
            StoreWorldPlanningInfo worldinfo = (_StoreWorldWeekState != null)?(_StoreWorldWeekState.StoreWorldInfo as StoreWorldPlanningInfo):null;
            string TargetedString = (worldinfo != null) ? TextParser.TimeToString(worldinfo.GetTargetValue(dw)) : "00:00";
            string PlannedString = (worldinfo != null) ? TextParser.TimeToString(worldinfo.GetPlannedValue(dw)) : "00:00";
            string DiffInPercentString = (worldinfo != null) ? TextParser.ToRoundSignPercent(worldinfo.GetDayPercent(dw)) : "0%";

            RectangleF oldClipBounds = e.Graphics.ClipBounds;
            Rectangle newClipBounds = Rectangle.Round(oldClipBounds);
            newClipBounds.Height = e.Bounds.Height * 4 + 2;

            DevExpress.Utils.Paint.Clipping clip = null;
            System.Drawing.Drawing2D.GraphicsState GState = null;
            bool bClipping = false;
            Color oldColor = e.Info.Appearance.ForeColor;

            try
            {
                if (newClipBounds.Height > oldClipBounds.Height)// if need change clip region
                {

                    GState = e.Graphics.Save();
                    e.Graphics.Clip = new System.Drawing.Region(newClipBounds);
                    clip = new DevExpress.Utils.Paint.Clipping();
                    clip.SetClipAPI(new GraphicsInfoArgs(e.Cache, newClipBounds), newClipBounds);
                    bClipping = true;
                }

                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = VertAlignment.Center;

                e.Info.DisplayText = PlannedString;
                e.Painter.DrawObject(e.Info);

                Rectangle oldBounds = e.Info.Bounds;

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = TargetedString;
                e.Painter.DrawObject(e.Info);

                if (Context != null && Context.CountryColors != null && worldinfo != null)
                {
                    Color color = Context.CountryColors.GetColorByDifferenceInPercentPlannedAndEstimatedHours(worldinfo.GetDayPercent(dw));
                    e.Info.Appearance.ForeColor = color;
                }
                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height * 2);
                e.Info.DisplayText = DiffInPercentString;
                e.Painter.DrawObject(e.Info);

                e.Info.Appearance.ForeColor = oldColor;


                e.Info.Bounds = oldBounds;
            }
            finally
            {
                e.Info.Appearance.ForeColor = oldColor;
                if (bClipping)
                {
                    clip.RestoreClipAPI(e.Graphics);
                    e.Graphics.Restore(GState);
                    e.Graphics.SetClip(oldClipBounds);
                    GState = null;
                    clip = null;
                }
            }
            e.Handled = true;
        }

        private void DrawTotalFooter(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (_StoreWorldWeekState == null || !_StoreWorldWeekState.IsCashDesk)
            {
                String firstTargetedSum = GetTargetedString();
                String secondDiff = GetDiffInPercent();

                int iWidth = gc_ContractWorkingHours.Width + gc_EmployeeBalanceHours.Width + gc_PlusMinusHours.Width + gc_SummOfAdditionalCharges.Width;
                e.Painter.DrawObject(e.Info);

                Rectangle oldBounds = e.Info.Bounds;

                string oldText = e.Info.DisplayText;

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width + iWidth, e.Info.Bounds.Height);

                e.Info.DisplayText = firstTargetedSum;
                DevExpress.Utils.HorzAlignment oldHAlignment = e.Info.Appearance.TextOptions.HAlignment;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height * 2);
                e.Info.DisplayText = secondDiff;
                e.Painter.DrawObject(e.Info);


                e.Info.Bounds = oldBounds;
                e.Info.DisplayText = oldText;
                e.Info.Appearance.TextOptions.HAlignment = oldHAlignment;
            }
            else
            {
                
                
                String firstTargetedSum = String.Format("{1:F2} - {0}",
                                            GetLocalized("PlannedCashDeskHoursPerWeek"),
                                            _calculator.PlannedUnits.Sum);

                String secondDiff = String.Format("{1:F2} - {0}",
                                            GetLocalized("TargetedCashDeskHoursPerWeek"),
                                            _calculator.TargetUnits.Sum);
                String thirdDiff = String.Format("{1}% - {0}",
                                            GetLocalized("DiffPerWeekInPercent"),
                                             Math.Round (_calculator.DiffTargetPlannedPercent.AbsAverage));

                int iWidth = gc_ContractWorkingHours.Width + gc_EmployeeBalanceHours.Width + gc_PlusMinusHours.Width + gc_SummOfAdditionalCharges.Width;
                e.Painter.DrawObject(e.Info);

                Rectangle oldBounds = e.Info.Bounds;

                string oldText = e.Info.DisplayText;

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width + iWidth, e.Info.Bounds.Height);

                e.Info.DisplayText = firstTargetedSum;
                DevExpress.Utils.HorzAlignment oldHAlignment = e.Info.Appearance.TextOptions.HAlignment;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = secondDiff;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = thirdDiff;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = oldBounds;
                e.Info.DisplayText = oldText;
                e.Info.Appearance.TextOptions.HAlignment = oldHAlignment;
            }
            e.Handled = true;
        }
        string GetDiffInPercent()
        {
        //string result = "00:00" + GetLocalized("SummTargetedHours");

            if (_StoreWorldWeekState != null && !_StoreWorldWeekState.IsCashDesk)
            {
                StoreWorldPlanningInfo worldinfo = (_StoreWorldWeekState != null) ? (_StoreWorldWeekState.StoreWorldInfo as StoreWorldPlanningInfo) : null;

                if (worldinfo != null)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(String.Format("{0}%", Math.Round (worldinfo.SumDifferencePercent)) + " " + GetLocalized("SummDifferenceInPercent"));
                    sb.AppendLine(TextParser.BuildDifferenceAbsoluteSumInPercent
                                    (
                                    Math.Round (worldinfo.AbsSumDifferencePercent),
                                    Math.Round (worldinfo.AbsSumDifferencePosPercent),
                                    Math.Round (worldinfo.AbsSumDifferenceNegPercent)
                                    ) + " " + GetLocalized("AbsoluteSummDifferenceInPercent"));
                    return sb.ToString();
                }
                
            }
            //else
            //    if (_StoreWorldWeekState != null && _StoreWorldWeekState.IsCashDesk)
            //    {
            //        return "0%";
            //    }

            StringBuilder sb1 = new StringBuilder();

            sb1.AppendLine(String.Format("{0}%", 0) + " " + GetLocalized("SummDifferenceInPercent"));
            sb1.AppendLine(TextParser.BuildDifferenceAbsoluteSumInPercent
                            (
                            0,
                            0,
                            0
                            ) + " " + GetLocalized("AbsoluteSummDifferenceInPercent"));
            return sb1.ToString();
        }
        string GetTargetedString()
        {
            string result = "00:00 " + GetLocalized("SummTargetedHours");
            if (_StoreWorldWeekState != null && !_StoreWorldWeekState.IsCashDesk)
            {
                StoreWorldPlanningInfo worldinfo = (_StoreWorldWeekState != null) ? (_StoreWorldWeekState.StoreWorldInfo as StoreWorldPlanningInfo) : null;

                if (worldinfo != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(TextParser.TimeToString(worldinfo.SumTargetedHours) + " " + GetLocalized("SummTargetedHours"));

                    result = sb.ToString();
                }
            }
            //else
            //    if (_StoreWorldWeekState != null && _StoreWorldWeekState.IsCashDesk)
            //    {
            //        result = "0,00";
            //    }

            return result;
        }




        private void DrawDayOfWeek_CashDesk(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e, DayOfWeek dw)
        {
            
            string PlannedHoursString = TextParser.TimeToString(_StoreWorldWeekState.GetDaySum (dw));
            string TargetedString = String.Format("{0:F2}",_calculator.TargetUnits.Elements[(int)dw]);
            string PlannedString = String.Format("{0:F2}",_calculator.PlannedUnits.Elements[(int)dw]);
            string DiffInPercentString = String.Format("{0}%", Math.Round (_calculator.DiffTargetPlannedPercent.Elements[(int)dw]));

            RectangleF oldClipBounds = e.Graphics.ClipBounds;
            Rectangle newClipBounds = Rectangle.Round(oldClipBounds);
            newClipBounds.Height = e.Bounds.Height * 4 + 2;

            DevExpress.Utils.Paint.Clipping clip = null;
            System.Drawing.Drawing2D.GraphicsState GState = null;
            bool bClipping = false;
            Color oldColor = e.Info.Appearance.ForeColor;
            try
            {
                if (newClipBounds.Height > oldClipBounds.Height)// if need change clip region
                {

                    GState = e.Graphics.Save();
                    e.Graphics.Clip = new System.Drawing.Region(newClipBounds);
                    clip = new DevExpress.Utils.Paint.Clipping();
                    clip.SetClipAPI(new GraphicsInfoArgs(e.Cache, newClipBounds), newClipBounds);
                    bClipping = true;
                }

                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = VertAlignment.Center;

                e.Info.DisplayText = PlannedHoursString;
                e.Painter.DrawObject(e.Info);

                Rectangle oldBounds = e.Info.Bounds;

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = PlannedString;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = TargetedString;
                e.Painter.DrawObject(e.Info);


                if (Context != null && Context.CountryColors != null && _calculator != null)
                {
                    Color color = Context.CountryColors.GetColorByDifferenceInPercentPlannedAndEstimatedHours(_calculator.DiffTargetPlannedPercent.Elements[(int)dw]);
                    e.Info.Appearance.ForeColor = color;
                }


                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = DiffInPercentString;
                e.Painter.DrawObject(e.Info);

                e.Info.Bounds = oldBounds;
            }
            finally
            {
                e.Info.Appearance.ForeColor = oldColor;
                if (bClipping)
                {
                    clip.RestoreClipAPI(e.Graphics);
                    e.Graphics.Restore(GState);
                    e.Graphics.SetClip(oldClipBounds);
                    GState = null;
                    clip = null;
                }
            }
            e.Handled = true;
        }

        private void gridView_Click(object sender, EventArgs e)
        {
            
        }
        /*private void gridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            
            if (m_columnDiction.ContainsKey (e.Column ))
            {
                e.Painter.DrawObject(e.Info);
                Rectangle r = e.Info.Bounds;
                string text = e.Info.DisplayText;
                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                //e.Info.DisplayText = 
                e.Painter.DrawObject(e.Info);
                e.Handled = true;
                e.Info.Bounds = r;
                e.Info.DisplayText = text;
            }
            else if (e.Column == gc_ContractWorkingHours)
            {
                int iWidth = gc_EmployeeBalanceHours.Width + gc_PlusMinusHours.Width + gc_SummOfAdditionalCharges.Width - 3;
                e.Painter.DrawObject(e.Info);
                Rectangle r = e.Info.Bounds;
                string text = e.Info.DisplayText;
                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width + iWidth, e.Info.Bounds.Height);
                e.Info.DisplayText = "Test string";
                e.Painter.DrawObject(e.Info);
                e.Handled = true;
                e.Info.Bounds = r;
                e.Info.DisplayText = text;

            }
        }*/
        

        
    }
}
