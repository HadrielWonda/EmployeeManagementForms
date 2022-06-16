using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;

using Baumax.Domain;
using Baumax.Contract;
using Baumax.Environment;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using DevExpress.Utils.Paint;
using DevExpress.XtraGrid;


namespace Baumax.ClientUI.FormEntities.TimePlanning.Daily
{
    public partial class UCWorldDailyView : UCBaseEntity 
    {
        //public const int MAXMINUTES = 24 * 60;
        string _NUMBER_OF_PEOPLE_ROW = "Number of people:";
        private DailyViewStyle m_currentView = DailyViewStyle.View60;

        private TimeColumnInfo[] m_columnsInfo = null;
        private Dictionary<TimeColumnInfo, GridColumn> m_columnsDiction = new Dictionary<TimeColumnInfo, GridColumn>();
        private WorldPlanningContext m_context = null;

        private DateTime m_viewDate = DateTime.Today;

        private EmployeeDayViewList m_dailyView = null;

        private IAbsenceManager m_absenceList = null;

        private FireChangedStoreOrWorld _OnChangeStoreOrWorld = null;
        private FireSaveEvent _OnSaveEvent = null;
        public bool bCashDesk = false;

        public int _LastSelectedTime = -1;
        private int _LastSelectedRowHandle = -1;

        public UCWorldDailyView()
        {
            
            InitializeComponent();
            BuildColumns();
            rgViewMode.EditValue = 2;
            _OnChangeStoreOrWorld += new FireChangedStoreOrWorld(m_context_OnChangedStoreOrWorld);

            Disposed += new EventHandler(UCWorldDailyView_Disposed);
            _OnSaveEvent += new FireSaveEvent(m_context_OnSaveEvent);

            deDate.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
            deDate.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
            panelControl4.Visible = false;

        }

        void UCWorldDailyView_Disposed(object sender, EventArgs e)
        {
            if (m_context != null)
            {
                m_context.OnChangedStoreOrWorld -= _OnChangeStoreOrWorld;
                m_context.OnSaveEvent -= _OnSaveEvent;
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                LocalizerControl.ComponentsLocalize(components);
                _NUMBER_OF_PEOPLE_ROW = GetLocalized("NumberOfPeoplePerHourPlan");
                UpdatePersonMinMaxInfo();
            }
        }

        public DateTime ViewDate
        {
            get { return m_viewDate; }
            set
            {
                if (m_viewDate != value)
                {
                    m_viewDate = value;
                    deDate.DateTime = m_viewDate;
                    OnChangedDate();
                }
            }
        }

        public override bool ReadOnly
        {
            get
            {
                if (m_context != null && m_context.ReadOnly) return true;

                return (ViewDate < DateTime.Today);
            }
            set
            {
                base.ReadOnly = value;
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
                        m_context.OnSaveEvent -= _OnSaveEvent; 
                    }
                    m_context = value;
                    if (m_context != null)
                    {
                        m_context.OnChangedStoreOrWorld += _OnChangeStoreOrWorld;
                        m_context.OnSaveEvent += _OnSaveEvent; 
                    }

                    OnChangedContext();
                }
            }
        }

        void m_context_OnSaveEvent()
        {
            UpdateEmployeePlanningDays();
        }


        void m_context_OnChangedStoreOrWorld(bool anyEmployee)
        {
            gridControl.DataSource = null;
            OnChangedContext();
        }


        public DailyViewStyle CurrentView
        {
            get
            {
                return m_currentView;
            }
            set
            {
                if (value != m_currentView)
                {
                    m_currentView = value;
                    OnChangedView();
                }

            }
        }

        protected virtual void OnChangedView()
        {
            if (Context != null)
            {
                if (Context.BeginTime > ViewDate || ViewDate > Context.EndTime)
                {
                    Context.LoadByDate(ViewDate);
                }
            }

            BuildColumns();
        }
        
        public virtual void OnChangedContext()
        {
            if (Context != null)
            {
                m_absenceList = Context.Absences;


                m_viewDate = Context.ViewDate;
                deDate.DateTime = m_viewDate;


                OnChangedDate();
                
            }
            else
            {
                gridControl.DataSource = null;
                
                m_dailyView = null;
                panelControl4.Visible = false;
            }

            UpdatePersonMinMaxInfo();
        }

        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
            if (!IsDesignMode)
            {
                riHwgrLookup.DataSource = ClientEnvironment.HWGRService.FindAll();

                gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                                                       {
                                                           new GridColumnSortInfo(gc_HWGR, ColumnSortOrder.Ascending),
                                                           new GridColumnSortInfo(gc_Employee, ColumnSortOrder.Ascending)
                                                       });
            }
        }

        protected void UpdateAvailableBuffer()
        {
            if (Context != null && Context.WeeklyWorldState != null)
            {
                int value = 0;
                if (Context.WeeklyWorldState.StoreWorldInfo != null)
                {
                    lblAvailableWorldBufferHours.Visible = Context.WeeklyWorldState.StoreWorldInfo.ExistBufferHours;
                    value = Context.WeeklyWorldState.StoreWorldInfo.CurrentBufferHours ;
                }

                lblAvailableWorldBufferHours.Text = GetLocalized("AvailableWorldBufferHours") + " " +
                    TextParser.TimeToString(value);
                
            }
            else
            {
                lblAvailableWorldBufferHours.Text = GetLocalized("AvailableWorldBufferHours");
            }
        }
        private void ClearWorldInfo()
        {
            lblMinimumPresence.Text = GetLocalized("MinimumPresence");
            lblMaximumPresence.Text = GetLocalized("MaximumPresence");
            lblAvailableWorldBufferHours.Text = GetLocalized("AvailableWorldBufferHours");
            lblTargetedHours.Text = GetLocalized("TargetedHours");
            lblDifference.Text = GetLocalized("Difference");
        }

        protected void UpdatePersonMinMaxInfo()
        {
            if (Context == null)
            {
                ClearWorldInfo();
            }
            else
            {
                if (Context.WeeklyWorldState != null && Context.WeeklyWorldState.StoreWorldInfo != null)
                {
                    
                    WorldPlanningInfo winfo = Context.WeeklyWorldState.StoreWorldInfo;

                    if (winfo.IsCashDesk)
                    {
                        panelControlWorldInfo.Visible = false;
                    }
                    else
                    {
                        panelControlWorldInfo.Visible = true;

                        lblMinimumPresence.Text = GetLocalized("MinimumPresence") + " " + winfo.MinimumPresence.ToString();
                        lblMaximumPresence.Text = GetLocalized("MaximumPresence") + " " + winfo.MaximumPresence.ToString();

                        StoreWorldPlanningInfo stinfo = winfo as StoreWorldPlanningInfo;
                        lblTargetedHours.Text = GetLocalized("TargetedHours") + " " + TextParser.TimeToString(stinfo.GetTargetValue(ViewDate.DayOfWeek));
                    }
                }
                else
                {
                    ClearWorldInfo();
                }
            }
        }

        private void UpdateDifference()
        {
            if (Context != null && Context.WeeklyWorldState != null && Context.WeeklyWorldState.StoreWorldInfo != null)
            {
                if (!Context.WeeklyWorldState.StoreWorldInfo.IsCashDesk)
                {
                    lblDifference.Visible = true;
                    StoreWorldPlanningInfo stinfo = Context.WeeklyWorldState.StoreWorldInfo as StoreWorldPlanningInfo;
                    if (stinfo != null)
                    {
                        int targetedHour = stinfo.GetTargetValue(ViewDate.DayOfWeek);
                        int plannedHour = m_dailyView.TotalPlannedWorkingHours;

                        int diff = plannedHour - targetedHour;
                        double diffPercent = (targetedHour != 0)?(100 / (double)targetedHour) * plannedHour - 100:0;

                        lblDifference.Text = GetLocalized("Difference") + " " + String.Format("{0} / {1:F2}%", TextParser.TimeToString (diff), diffPercent);
                    }
                }
                else
                {
                    lblDifference.Visible = false;
                }
            }
        }

        protected virtual void OnChangedDate()
        {
            if (Context != null)
            {
                Context.LoadByDate(ViewDate);
                PrepareColumnsView();

                m_dailyView = Context.GetDailyEmployeeList();


                if (Context.WeeklyWorldState != null && Context.WeeklyWorldState.StoreWorldInfo != null
                    && (Context.WeeklyWorldState.StoreWorldInfo is CashDeskPlanningInfo))
                {
                    panelControl4.Visible = true;
                    bCashDesk = true;
                    ucCashDeskDailyPlannedInfo1.ViewDate = Context.ViewDate;
                    ucCashDeskDailyPlannedInfo1.CashDeskInfo = Context.WeeklyWorldState.StoreWorldInfo as CashDeskPlanningInfo;
                    ucCashDeskDailyPlannedInfo1.ColorManager = Context.CountryColors;
                    m_dailyView._bCashDesk = true;
                //    ucCashDeskDailyPlannedInfo1.AssignPlannedInfo(m_dailyView.GetUnitsPerHour());
                }
                else
                {
                    if (m_dailyView != null)
                        m_dailyView._bCashDesk = false;
                    bCashDesk = false;
                    panelControl4.Visible = false;
                    ucCashDeskDailyPlannedInfo1.CashDeskInfo = null;// Context.WeeklyWorldState.StoreWorldInfo as CashDeskPlanningInfo;
                    ucCashDeskDailyPlannedInfo1.ColorManager = null;// Context.CountryColors;

                }
                UpdatePersonMinMaxInfo();
                UpdateEmployeePlanningDays();

                gridControl.DataSource = null;
                if (m_dailyView != null)
                {
                    gridControl.DataSource = m_dailyView.DayWeeklyList;
                }

                
            }
        }

        #region create/remove columns

        void PrepareColumnsView()
        {
            if (Context != null && 
                Context.StoreDays != null && 
                Context.StoreDays.ContainsKey (ViewDate ))
            {
                StoreDay day = Context.StoreDays[ViewDate];

                if (m_columnsInfo != null)
                {
                    for (int i = 0; i < m_columnsInfo.Length; i++)
                    {
                        if (m_columnsInfo[i].FromTime < (int)day.OpenTime || (int)day.CloseTime <= m_columnsInfo[i].FromTime)
                        {
                            m_columnsInfo[i].IsOpening = false;
                            m_columnsDiction[m_columnsInfo[i]].AppearanceCell.BackColor = Color.LightGray;
                        }
                    }



                }
            }
            MakeVisibleFirstThreeHours();
        }

        void MakeVisibleFirstThreeHours()
        {
            if (Context != null && Context.StoreDays != null)
            {
                StoreDay day = Context.StoreDays[ViewDate];
                if (m_columnsInfo != null)
                {
                    gridView.FocusedColumn = m_columnsDiction[m_columnsInfo[m_columnsInfo.Length -1]];
                    for (int i = 0; i < m_columnsInfo.Length; i++)
                    {
                        if (m_columnsInfo[i].FromTime <= day.OpenTime && day.OpenTime <= m_columnsInfo[i].FromTime)
                        {

                            gridView.FocusedColumn = m_columnsDiction[m_columnsInfo[i]];//.Column;
                            return;
                        }
                    }
                }
            }
        }

        private void DeleteColumns()
        {
            int iCount = gridView.Columns.Count;
            GridColumn column = null;
            for (int i = iCount-1; i >=0; i--)
            {
                column = gridView.Columns[i];
                if (column.Name.StartsWith("gcHour"))
                {
                    gridView.Columns.Remove(column);
                }
            }
            m_columnsInfo = null;
            m_columnsDiction.Clear();
        }


        
        public void BuildColumns()
        {

            gridView.BeginDataUpdate();
            try
            {
                DeleteColumns();
                GridColumn column = null;

                int iStep = (int)m_currentView;

                int iMax = Utills.MinutesInDay ;

                int iCount = iMax / iStep;
                int iHour = 0;
                int iMinute = 0;
                m_columnsInfo = new TimeColumnInfo[iCount];

                for (int i = 0; i < iCount; i++)
                {
                    column = gridView.Columns.Add();
                    column.Name = "gcHour_" + i;
                    column.Caption = TextParser.BuildColumnCaption(iHour, iMinute, iStep);
                        //String.Format("{0}:{1}", iHour.ToString("00"), iMinute.ToString("00"));
                    column.MinWidth = 40;
                    column.Visible = true;
                    //column.VisibleIndex = i;// 1 + i;
                    column.Width = 45;

                    //column.AppearanceHeader.Options.UseTextOptions = true;
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    //column.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsColumn.AllowEdit = false;
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    column.SummaryItem.Tag = i;
                    

                    m_columnsInfo[i] = new TimeColumnInfo(iHour * 60 + iMinute, iHour * 60 + iMinute + iStep, true);
                    column.Tag = m_columnsInfo[i];
                    m_columnsDiction[m_columnsInfo[i]] = column;

                    iMinute += iStep;
                    if (iMinute == 60)
                    {
                        iHour++;
                        iMinute = 0;
                    }
                }
                PrepareColumnsView();
            }
            finally
            {
                gridView.EndDataUpdate();
            }
        }


        #endregion

        private void MakeVisibleSelectedTime()
        {
            if (_LastSelectedTime != -1 && _LastSelectedTime > 0 && m_columnsInfo != null)
            {
                gridView.FocusedRowHandle = _LastSelectedRowHandle;

                foreach (TimeColumnInfo cinfo in m_columnsInfo)
                {
                    if (cinfo.FromTime <= _LastSelectedTime && _LastSelectedTime <= cinfo.ToTime)
                    {
                        gridView.FocusedColumn = m_columnsDiction[cinfo];
                        break;
                    }
                }

                gridView.Focus();
                gridView.SelectCell(_LastSelectedRowHandle, gridView.FocusedColumn);
                
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iValue = Convert.ToInt32(rgViewMode.EditValue);
            TimeColumnInfo infoColumn = GetColumnInfo(gridView.FocusedColumn);
            _LastSelectedTime = -1;
            if (infoColumn != null)
            {
                _LastSelectedTime = infoColumn.FromTime;
            }
            _LastSelectedRowHandle = gridView.FocusedRowHandle;
            if (iValue == 0) CurrentView = DailyViewStyle.View15;
            else
                if (iValue == 1) CurrentView = DailyViewStyle.View30;
                else
                    if (iValue == 2) CurrentView = DailyViewStyle.View60;

            MakeVisibleSelectedTime();
            _LastSelectedTime = -1;
            _LastSelectedRowHandle = -1;
        }




        public EmployeePlanningWeek GetEntityByRowHandle(int rowHandle)
        {
            if (gridView.IsDataRow(rowHandle))
            {
                EmployeePlanningWeek w = (EmployeePlanningWeek)gridView.GetRow(rowHandle);
                return w ;
            }
            else return null;
        }

        public EmployeePlanningWeek FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView.FocusedRowHandle);
            }
        }

        public EmployeeDayView GetEmployeeDayView(int rowhandle)
        {
            EmployeePlanningWeek employee = GetEntityByRowHandle(rowhandle);

            if (employee == null) return null;

            return m_dailyView.GetByEmployeeId(employee.EmployeeId );

        }
        public EmployeeDayView GetEmployeeDayView()
        {
            return GetEmployeeDayView(gridView.FocusedRowHandle);
        }

        private TimeColumnInfo GetColumnInfo(GridColumn column)
        {
            if (column != null && column.Tag != null)
                return column.Tag as TimeColumnInfo;

            return null;
        }

        private void gridViewHalfHour_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ReadOnly) return;

            GridHitInfo info = gridView.CalcHitInfo(e.X, e.Y);
            if (info.InRow)
            {
                TimeColumnInfo timeinfo = GetColumnInfo(info.Column);

                if (timeinfo != null)
                {

                    EmployeeDayView dayView = GetEmployeeDayView();

                    if (dayView != null)
                    {

                        if (dayView.IsBuzyByTimeRange(timeinfo.FromTime, timeinfo.ToTime))
                            dayView.RemoveWorkingTime(timeinfo.FromTime, timeinfo.ToTime);
                        else
                            dayView.AddWorkingTime(timeinfo.FromTime, timeinfo.ToTime);

                        if (dayView.Modified) Context.Modified = true;

                        UpdateEmployeePlanningDays();

                    }
                }
            }
        }


        private void gridViewHalfHour_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            EmployeePlanningWeek empl = GetEntityByRowHandle(e.RowHandle);
            EmployeeDayView dayView = null;

            if (empl != null && m_dailyView != null)
                dayView = m_dailyView.GetByEmployeeId(empl.EmployeeId );
            
            if (e.Column == gc_AllreadyPlannedWorkingHours)
            {
                if (dayView != null && dayView.PlanningDay != null)
                    e.Value = DateTimeHelper.IntTimeToStr(dayView.PlanningDay.CountDailyPlannedWorkingHours);
            }
            
        }

        private void workingTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;
            
            EmployeeDayView dayView = GetEmployeeDayView();

            if (gridView.SelectedRowsCount == 1)
            {
                GridCell[] cells = gridView.GetSelectedCells();

                if (cells.Length > 1)
                {
                    bool ignore = false;
                    for (int i = 0; i < cells.Length ; i++)
                    {
                        if (cells[i].Column.Tag == null) ignore = true;
                    }
                    if (!ignore)
                    {
                        
                        
                        if (dayView != null)
                        {

                            foreach (GridCell cell in cells)
                            {
                                TimeColumnInfo infocolumn = GetColumnInfo(cell.Column);
                                if (infocolumn != null)
                                {
                                    dayView.AddWorkingTime(infocolumn.FromTime , infocolumn.ToTime );
                                }
                            }
                            if (dayView.Modified) Context.Modified = true;
                        }

                        UpdateEmployeePlanningDays();
                    }
                }
                else 
                {
                    if (cells != null && cells.Length == 1)
                    {


                        TimeColumnInfo info = GetColumnInfo(cells[0].Column);
                        StoreDay sd = Context.StoreDays[Context.ViewDate];
                        if (info != null)
                        {


                            using (FormEnterWorkingTime form = new FormEnterWorkingTime())
                            {
                                if (sd.OpenTime == 0)
                                    form.BeginTime = 9 * 60;
                                else
                                    form.BeginTime = sd.OpenTime;

                                form.EndTime = sd.CloseTime;
                                if (sd.CloseTime == 0)
                                    form.EndTime = 18 * 60;
                                else
                                    form.EndTime = sd.CloseTime;

                                form.BeginTime = info.FromTime;

                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    int bt = form.BeginTime;
                                    int et = form.EndTime;


                                    if (dayView != null)
                                    {
                                        dayView.AddWorkingTime(bt, et);
                                        if (dayView.Modified) Context.Modified = true;
                                    }

                                    UpdateEmployeePlanningDays();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_WeeklyView_Click(object sender, EventArgs e)
        {
            OnChangedToWeeklyView(); 
        }

        public event ChangedToWeeklyView EventChangedToWeeklyView = null;

        protected virtual void OnChangedToWeeklyView()
        {
            if (EventChangedToWeeklyView != null)
                EventChangedToWeeklyView();
        }

        
        #region Process absences

        private void ProcessNewAbsence(Absence absence)
        {
            if (absence != null)
            {
                if (absence.Value > 0)
                {
                    ProcessFixedTimeAbsence(absence);
                }
                else if (absence.IsFixed)
                {
                    ProcessCountAliquotAbsence(absence);
                }
                else if (absence.WithoutFixedTime)
                {
                    ProcessNotFixedTimeAbsence(absence);
                }
               
            }
        }

        private void ProcessNotFixedTimeAbsence(Absence absence)
        {
            if (absence.WithoutFixedTime)
            {
                if (gridView.SelectedRowsCount == 1)
                {

                    using (FormEnterAbsenceTime form = new FormEnterAbsenceTime())
                    {

                        if (form.ShowDialog() == DialogResult.OK)
                        {

                            
                            EmployeeDayView dayView = GetEmployeeDayView(); 
                            if (dayView != null)
                            {
                                dayView.SetAbsence(absence, form.BeginTime, form.EndTime);
                                if (dayView.Modified) Context.Modified = true;
                                UpdateEmployeePlanningDays();
                            }

                            
                        }
                    }

                }
            }
        }

        private void ProcessFixedTimeAbsence(Absence absence)
        {
            if (absence.Value > 0)
            {
                int count = (int)(absence.Value * 60);

                if (gridView.SelectedRowsCount == 1)
                {
                    
                    EmployeeDayView dayView = GetEmployeeDayView(); 
                    TimeColumnInfo info = GetColumnInfo(gridView.FocusedColumn);

                    if (dayView != null && info != null)
                    {
                        dayView.SetAbsence(absence, info.FromTime, info.FromTime + count);
                        if (dayView.Modified) Context.Modified = true;
                        UpdateEmployeePlanningDays();
                        
                    }
                }
            }
        }

        private void ProcessCountAliquotAbsence(Absence absence)
        {
            if (absence.IsFixed)
            {

                if (gridView.SelectedRowsCount == 1)
                {
                    EmployeeDayView dayView = GetEmployeeDayView();

                    TimeColumnInfo info = GetColumnInfo(gridView.FocusedColumn);

                    if (dayView != null && info != null)
                    {
                        int count = DateTimeHelper.RoundToQuoter((short)((dayView.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek) ));

                        dayView.SetAbsence(absence, info.FromTime, info.FromTime + count);
                        if (dayView.Modified) Context.Modified = true;
                        UpdateEmployeePlanningDays();
                    }
                }
            }
        }

        #endregion

        

        private void deDate_DateTimeChanged(object sender, EventArgs e)
        {
            ViewDate = deDate.DateTime;
        }

        private void gridViewHalfHour_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            
            // if cell focused or selected do nothing
            if (gridView.IsCellSelected(e.RowHandle,e.Column) && e.Column.Tag != null)// != gc_Employee)
            {
                e.Appearance.BackColor = Color.Gold ;
                e.Handled = false;
                return;
            }
            
            // if is not hour column return 
            if (e.Column.Tag == null)
            {
                //e.Handled = false;
                DrawFixedCells(e);
                return;
            }



            StoreDay storeday = Context.StoreDays[Context.ViewDate];

            TimeColumnInfo infoColumn = GetColumnInfo(e.Column);

            if (infoColumn == null) return;

            EmployeeDayView dayView = GetEmployeeDayView(e.RowHandle);
            
            if (dayView == null) return;
            int index = infoColumn.FromTime / 15;

            Painters.DrawDailyViewCell(e, index, CurrentView,storeday, dayView);

            
        }

        private void DrawFixedCells(RowCellCustomDrawEventArgs e)
        {
            EmployeePlanningWeek empl = GetEntityByRowHandle(e.RowHandle);
            if (Context != null)
            {
                if (e.Column == gc_PlusMinusHours)
                {
                    int value = empl.CountWeeklyPlusMinusHours;

                    Color color = Context.CountryColors.GetColorByEmployeePlusMinus(value);
                    e.Appearance.ForeColor = color;
                }
                if (e.Column == gc_SummOfAdditionalCharges)
                {
                    int value = empl.CountWeeklyAdditionalCharges ;

                    Color color = Context.CountryColors.GetColorByEmployeeAdditionalCharges(value);
                    e.Appearance.ForeColor = color;
                }
                if (e.Column == gc_EmployeeBalanceHours)
                {
                    int value = empl.Saldo;

                    Color color = Context.CountryColors.GetColorByEmployeeBalanceHours(value);
                    e.Appearance.ForeColor = color;
                }
            }

            Painters.DrawFixedCells(e, empl.FullName, e.RowHandle == gridView.FocusedRowHandle);

            e.Handled = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = ReadOnly;

            if (gridView.SelectedRowsCount > 1) e.Cancel = true;
        }

        private void tm_ClearTime_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;


            if (gridView.SelectedRowsCount == 1)
            {
                GridCell[] cells = gridView.GetSelectedCells();

                if (cells != null && cells.Length >= 1)
                {
                    bool ignore = false;
                    for (int i = 0; i < cells.Length; i++)
                    {
                        if (cells[i].Column.Tag == null) ignore = true;
                    }
                    if (!ignore)
                    {
                        EmployeePlanningWeek empl = FocusedEntity;
                        if (empl != null)
                        {
                            EmployeeDayView dayView = m_dailyView.GetByEmployeeId(empl.EmployeeId );
                            if (dayView != null)
                            {
                                int begin = GetColumnInfo(cells[0].Column).FromTime;
                                int end = GetColumnInfo(cells[cells.Length - 1].Column).FromTime;
                                for (int i = begin; i < end + (int)CurrentView; i += (int)CurrentView)
                                {
                                    dayView.RemoveWorkingTime(i, i + (int)CurrentView);
                                }
                                if (dayView.Modified) Context.Modified = true;
                            }
                        }
                        UpdateEmployeePlanningDays();

                        return;
                    }
                }
            }
        }


        private void UpdateEmployeePlanningDays()
        {

            if (m_dailyView != null)
            {
                foreach (EmployeeDayView edv in m_dailyView.Values)
                {
                    if (edv.Modified)
                    {
                        edv.UpdateEmployeePlanningDay();
                        Context.Absences.FillAbsencePlanningTimes(edv.PlanningDay.AbsenceTimeList);
                    }
                }
            }

            CalculateColumnSum();
            gridView.UpdateTotalSummary();
            gridView.RefreshData();
            UpdateAvailableBuffer();
            UpdateDifference();
        }

        private void btnApplyWM_Click(object sender, EventArgs e)
        {
            if (m_dailyView != null)
            {
                foreach (EmployeeDayView edv in m_dailyView.Values)
                {
                    if (edv.Modified)
                    {
                        edv.UpdateEmployeePlanningDay();
                    }



                }
            }
        }

        private void mi_FillAllAsWorkingTime_Click(object sender, EventArgs e)
        {
            FillAllAsWorkingTime();
        }

        private void FillAllAsWorkingTime()
        {
            StoreDay storeday = Context.StoreDays[ViewDate];
            if (storeday.ClosedDay || storeday.CloseTime == 0) return;
            int beginIndex = storeday.OpenTime / 15;
            int endIndex = storeday.CloseTime / 15;
            foreach (EmployeeDayView edv in m_dailyView.Values)
            {
                for (int i = beginIndex; i < endIndex; i++)
                {
                    if (!edv.IsAbsenceTime(i))
                        edv.SetAsWorkingTimeIfEmpty (i);
                }
                if (edv.Modified) Context.Modified = true;
            }

            UpdateEmployeePlanningDays();
        }

        private void mi_Absence_Click(object sender, EventArgs e)
        {
            using (FormSelectAbsence formSelectAbsence = new FormSelectAbsence())
            {
                formSelectAbsence.IsPlanning = true;
                formSelectAbsence.Absences = Context.Absences.ToList;
                StoreDay sd = Context.StoreDays[ViewDate];
                formSelectAbsence.ShowTimePanel = false;
                formSelectAbsence.SetDayInfo(sd.OpenTime, sd.CloseTime, Context.StoreDays.AvgDayInWeek);


                if (formSelectAbsence.Execute())
                {
                    ProcessNewAbsence(formSelectAbsence.SelectedAbsence);
                    UpdateEmployeePlanningDays();
                }
            }
        }

        private void gridViewHalfHour_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            /*if (e.ControllerRow != gridViewHalfHour.FocusedRowHandle && e.Action== CollectionChangeAction.Add )
            {
                gridViewHalfHour.UnselectRow(e.ControllerRow);
            }*/
        }

        private void mi_MarkAsAbsence_Click(object sender, EventArgs e)
        {
            using (FormSelectAbsence formSelectAbsence = new FormSelectAbsence())
            {
                formSelectAbsence.IsPlanning = true;
                formSelectAbsence.Absences = Context.Absences.ToList;
                StoreDay sd = Context.StoreDays[ViewDate];
                formSelectAbsence.ShowTimePanel = false;
                formSelectAbsence.SetDayInfo(sd.OpenTime, sd.CloseTime, Context.StoreDays.AvgDayInWeek);


                if (formSelectAbsence.Execute())
                {
                    if (gridView.SelectedRowsCount == 1)
                    {

                        EmployeeDayView dayView = GetEmployeeDayView(); //m_dailyView.GetByEmployeeId(empl.EmployeeId);
                        TimeColumnInfo info = null;

                        GridCell[] cells = gridView.GetSelectedCells();

                        if (dayView != null && cells != null && cells.Length > 0)
                        {
                            foreach (GridCell cell in cells)
                            {
                                info = GetColumnInfo(cell.Column);
                                if (info != null)
                                {
                                    dayView.SetAbsence(formSelectAbsence.SelectedAbsence, info.FromTime, info.ToTime);
                                }
                            }
                            if (dayView.Modified) Context.Modified = true;
                            UpdateEmployeePlanningDays();
                            
                        }
                    }
                }
            }
        }


        void CalculateColumnSum()
        {
            if (m_dailyView != null)
            {
                m_dailyView.RecalculateTotals();
                if (bCashDesk )
                    ucCashDeskDailyPlannedInfo1.AssignPlannedInfo(m_dailyView.GetTotalsSumByHours());
            }
            PlayWorkingModelMessages();
            
        }
        GridCell[] selectedCell = null;
        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
           GridHitInfo info = gridView.CalcHitInfo(e.Location);

           if (e.Button == MouseButtons.Left)
           {
               if (info.InRowCell)
               {
                   if (gridView.SelectedRowsCount == 1)
                   {
                       selectedCell = gridView.GetSelectedCells();

                       if (selectedCell != null && selectedCell.Length == 1)
                           selectedCell = null;
                   }
               }
           }
        }

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView.CalcHitInfo(e.Location);

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
            if (e.Button == MouseButtons.Left && info.InRowCell)
            {
                if (selectedCell != null && selectedCell.Length > 1)
                {
                    if (selectedCell[0].RowHandle == info.RowHandle)
                    {
                        bool bOk = false;
                        foreach (GridCell cell in selectedCell)
                        {
                            if (cell.Column == info.Column)
                            {
                                bOk = true;
                                break;
                            }
                        }

                        if (bOk && !ReadOnly)
                        {
                            EmployeeDayView dayView = GetEmployeeDayView(info.RowHandle); //m_dailyView.GetByEmployeeId(empl.EmployeeId);
                            TimeColumnInfo columninfo = null;

                            if (dayView != null)
                            {
                                foreach (GridCell cell in selectedCell)
                                {
                                    columninfo = GetColumnInfo(cell.Column);
                                    if (columninfo != null)
                                    {
                                        dayView.AddWorkingTime(columninfo.FromTime, columninfo.ToTime);
                                    }
                                }
                                if (dayView.Modified) Context.Modified = true;
                                UpdateEmployeePlanningDays();

                            }
                            selectedCell = null;
                        }
                    }
                }
            }
        }

        public void PlayWorkingModelMessages()
        {
            if (m_context != null)
            {
                if (m_context.WeeklyWorldState != null)
                {
                    if (FormEmployeeWorkingModelApplied.AllowShow)
                    {
                        FormEmployeeWorkingModelApplied.PlayEmployeeWeeks(m_context, m_context.WeeklyWorldState.List);

                    }
                }
                else
                {
                    FormEmployeeWorkingModelApplied.HideForm();
                }
            }
        }

        #region Footer methonds 

        private void gridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            TimeColumnInfo columnInfo = e.Column.Tag as TimeColumnInfo;

            if (columnInfo != null)
            {
                DrawHourlyFooter(columnInfo, e);
            }
            else if (e.Column == gc_Employee /*|| e.Column == gc_HWGR*/)
            {
                DrawHeaderFooter(e);
            }
            else if (e.Column == gc_AllreadyPlannedWorkingHours)
            {
                DrawAllreadyPlannedFooterCells(e);
            }
        }

        private string FooterHoursAsString(int minutes)
        {
            double value = minutes;
            if (CurrentView == DailyViewStyle.View60)
            {
                return String.Format("{0:F2}", value / 60);
            }
            else if (CurrentView == DailyViewStyle.View30)
            {
                return String.Format("{0:F1}", value / 30);
            }
            else return String.Format("{0:F0}", value / 15);
        }
        private void DrawAllreadyPlannedFooterCells(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            int value = 0;

            if (m_dailyView != null)
                value = m_dailyView.TotalPlannedWorkingHours;

            e.Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near ;

            e.Info.DisplayText = DateTimeHelper.IntTimeToStr(value);

            e.Painter.DrawObject(e.Info);

            value = (m_dailyView != null) ? m_dailyView.TotalPlannedHoursPerDay : 0;
            
            Rectangle oldBounds = e.Info.Bounds;
            string oldText = e.Info.DisplayText;
            e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
            e.Info.DisplayText = FooterHoursAsString(value);

            e.Painter.DrawObject(e.Info);

            e.Info.Bounds = oldBounds;
            e.Info.DisplayText = oldText;

            e.Handled = true;
        }

        private void DrawHeaderFooter(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Painter.DrawObject(e.Info);

            int iWidth = (gc_HWGR.Visible) ? gc_HWGR.Width : 0;

            Rectangle oldBounds = e.Info.Bounds;
            string oldText = e.Info.DisplayText;

            e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width + iWidth, e.Info.Bounds.Height);

            e.Info.DisplayText = _NUMBER_OF_PEOPLE_ROW;
            DevExpress.Utils.HorzAlignment oldHAlignment = e.Info.Appearance.TextOptions.HAlignment;
            e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Painter.DrawObject(e.Info);
            e.Info.Bounds = oldBounds;
            e.Info.DisplayText = oldText;
            e.Info.Appearance.TextOptions.HAlignment = oldHAlignment;
            e.Handled = true;
        }

        private void DrawHourlyFooter(TimeColumnInfo columnInfo, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {

            int value = (m_dailyView != null) ? m_dailyView.GetTotals(columnInfo.FromTime, CurrentView) : 0;
            RectangleF oldClipBounds = e.Graphics.ClipBounds;
            Rectangle newClipBounds = Rectangle.Round(oldClipBounds);
            newClipBounds.Height = e.Bounds.Height * 2 + 1;

            DevExpress.Utils.Paint.Clipping clip = null;
            System.Drawing.Drawing2D.GraphicsState GState = null;
            bool bClipping = false;
            
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

                e.Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                e.Info.DisplayText = DateTimeHelper.IntTimeToStr(value);
                e.Painter.DrawObject(e.Info);


                Rectangle oldBounds = e.Info.Bounds;
                string oldText = e.Info.DisplayText;
                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
                e.Info.DisplayText = FooterHoursAsString(value);


                e.Painter.DrawObject(e.Info);
                e.Info.Bounds = oldBounds;
                e.Info.DisplayText = oldText;

            }
            finally
            {
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

        #endregion

    }
}
