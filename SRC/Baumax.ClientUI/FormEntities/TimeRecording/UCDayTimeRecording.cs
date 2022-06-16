using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using Baumax.Contract.TimePlanning;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid;
using Baumax.Contract;
using Baumax.Domain;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using Baumax.Environment;
using DevExpress.Utils.Drawing;


namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class UCDayTimeRecording : UCBaseEntity 
    {
        string _NUMBER_OF_PEOPLE_ROW = "Number of people:";
        private DailyViewStyle m_currentView = DailyViewStyle.View60;
        private TimeColumnInfo[] m_columnsInfo = null;
        private Dictionary<TimeColumnInfo, GridBand> m_DictionOfBands = new Dictionary<TimeColumnInfo, GridBand>();
        private Dictionary<GridSummaryItem, BandedGridColumn> m_SummaryItemToPlannedColumn = new Dictionary<GridSummaryItem, BandedGridColumn>();
        private Dictionary<GridSummaryItem, BandedGridColumn> m_SummaryItemToActualColumn = new Dictionary<GridSummaryItem, BandedGridColumn>();

        private Hashtable _fixedColumn = new Hashtable(10); 

        DateTime _viewDate; 
        WorldRecordingContext _context;
        BindingList<RecordingDayRow> _rowList = new BindingList<RecordingDayRow>();

        private ChangedContext _Context_ChangeContext = null;
        private RecordingDaySum _SumOfStoreWorldDay = new RecordingDaySum();


        public int _LastSelectedTime = -1;
        private int _LastSelectedRowHandle = -1;

        private bool IsShowPlannedRow
        {
            get
            {
                return chk_ShowHidePlannedRow.Checked;
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

        public void OnChangedContext()
        {
            if (Context != null)
            {
                if (deDate.DateTime.Date != Context.ViewDate.Date)
                {
                    deDate.DateTime = Context.ViewDate.Date;
                }

                if (OnDataSourceChanged != null)
                    OnDataSourceChanged(Context.WorldPlanningState != null
                                     && Context.WorldPlanningState.List != null
                                     && Context.WorldPlanningState.List.Count > 0, null);
            }
            BuildRows();
        }

        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
            if (!IsDesignMode)
            {
                riLookupHwgr.DataSource = ClientEnvironment.HWGRService.FindAll();
                gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                                new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                                new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                                });
            }
        }

        public void BuildRows()
        {
            if (Context != null)
            {
                _rowList.Clear();

                //gridControl.BeginUpdate();
                gridView.BeginDataUpdate();
                try
                {
                    StoreWorldWeekState plannedWeekState = Context.WorldPlanningState;
                    StoreWorldWeekState actualWeekState = Context.WorldActualState;
                    long storeworldid = Context.StoreWorldId;

                    EmployeeWeek plannedWeek = null;
                    EmployeeWeek actualWeek = null;

                    EmployeeDay plannedDay = null;
                    EmployeeDay actualDay = null;

                    RecordingDayView plannedView = null;
                    RecordingDayView actualView = null;
                    if (plannedWeekState != null && plannedWeekState.List != null)
                    {
                        foreach (EmployeeWeek ew in plannedWeekState.List)
                        {
                            if (ew.IsHasWorldByDate(storeworldid, Context.ViewDate))
                            {
                                actualWeek = actualWeekState[ew.EmployeeId];

                                plannedDay = ew.GetDay(Context.ViewDate);
                                actualDay = actualWeek.GetDay(Context.ViewDate);

                                plannedView = new RecordingDayView();
                                plannedView.RecordingDay = plannedDay;

                                actualView = new RecordingDayView();
                                actualView.RecordingDay = actualDay;

                                Domain.Employee emp = ClientEnvironment.EmployeeService.FindById(ew.EmployeeId);
                                _rowList.Add(new RecordingDayRow(ew, plannedView, actualWeek, actualView, emp.OrderHwgrID ?? 0));
                            }
                        }
                    }

                    _SumOfStoreWorldDay.AddRange(_rowList);
                }
                finally
                {
                    gridView.EndDataUpdate();
                    //gridControl.EndUpdate();
                }


            }
            else
            {
                _rowList.Clear();
                _SumOfStoreWorldDay.AddRange(_rowList);
            }
            UpdateWorldInfo();

        }
        private void ClearWorldInfo()
        {
            lblMaximumPresence.Text = GetLocalized("MinimumPresence");
            lblMinimumPresence.Text = GetLocalized("MinimumPresence");
            lblAvailableWorldBufferHours.Text = GetLocalized("AvailableWorldBufferHours");
            lblDifference.Text = GetLocalized("Difference");
            lblPlannedHours.Text = GetLocalized("PlannedHours");
        }
        private void UpdateWorldInfo()
        {
            ClearWorldInfo();
            if (Context != null)
            {
                StoreWorldWeekState actualWeekState = Context.WorldActualState;
                if (actualWeekState != null)
                {
                    if (actualWeekState.StoreWorldInfo != null)
                    {
                        WorldPlanningInfo worldinfo = actualWeekState.StoreWorldInfo;

                        if (!worldinfo.IsCashDesk)
                        {
                            if (ucActualCashDeskDailyInfo.Visible)
                            {
                                ucActualCashDeskDailyInfo.Visible = false;
                                ucActualCashDeskDailyInfo.CashDeskInfo = null;
                                panelControl2.Visible = true;
                            }

                            lblDifference.Visible = !worldinfo.IsCashDesk;
                            lblPlannedHours.Visible = !worldinfo.IsCashDesk;

                            lblMinimumPresence.Text = GetLocalized("MinimumPresence") + " " + worldinfo.MinimumPresence;
                            lblMaximumPresence.Text = GetLocalized("MaximumPresence") + " " + worldinfo.MaximumPresence;
                            lblAvailableWorldBufferHours.Text = GetLocalized("AvailableWorldBufferHours") + " " + TextParser.TimeToString(worldinfo.CurrentBufferHours);
                            lblAvailableWorldBufferHours.Visible = worldinfo.ExistBufferHours;
                            if (!worldinfo.IsCashDesk)
                            {
                                StoreWorldPlanningInfo swinfo = worldinfo as StoreWorldPlanningInfo;
                                int targethours = swinfo.GetTargetValue(Context.ViewDate.DayOfWeek);

                                lblPlannedHours.Text = GetLocalized("PlannedHours") + " " + TextParser.TimeToString(targethours);
                                int actualHours = actualWeekState.GetDaySum(Context.ViewDate.DayOfWeek);

                                double diffPercent = 0;
                                if (targethours != 0)
                                    diffPercent = (100 / (double)targethours) * actualHours - 100;

                                int diff = actualHours - targethours;
                                lblDifference.Text = GetLocalized("Difference") + " " + TextParser.TimeToString(diff) + "/" + String.Format("{0:F2}%", diffPercent);

                            }
                        }
                        else
                        {
                            if (panelControl2.Visible)
                            {
                                panelControl2.Visible = false;
                                ucActualCashDeskDailyInfo.Visible = true;
                            }
                            ucActualCashDeskDailyInfo.CashDeskInfo = worldinfo as CashDeskPlanningInfo;
                            ucActualCashDeskDailyInfo.ColorManager = Context.CountryColors;

                            ucActualCashDeskDailyInfo.AssignTargetedInfo(_SumOfStoreWorldDay.GetPlannedUnits());
                            ucActualCashDeskDailyInfo.AssignPlannedInfo(_SumOfStoreWorldDay.GetTargetedUnits());

                        }
                    }
                }
            }
        }
        public DateTime ViewDate
        {
            get { return _viewDate; }
            set { _viewDate = value; }
        }

        public UCDayTimeRecording()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                BuildFixedColumnDiction();
                BuildColumns();

                gridControl.DataSource = _rowList;
                _Context_ChangeContext = new ChangedContext(_context_ChangedContext);
            }
            Disposed += new EventHandler(UCDayTimeRecording_Disposed);
            deDate.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
            deDate.Properties.MaxValue = DateTime.Today;
        }

        public event EventHandler OnDataSourceChanged = null;


        void _context_ChangedContext()
        {
            OnChangedContext();
        }

        void UCDayTimeRecording_Disposed(object sender, EventArgs e)
        {
            if (Context != null)
                Context.ChangedContext -= _Context_ChangeContext;
        }


        #region properties for check enable/disable edit

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

        public bool IsEditableDay(EmployeeDay employeeday)
        {
            if (Context == null) return false;
            if (employeeday == null) return false;
            if (employeeday.StoreWorldId != Context.StoreWorldId) return false;
            if (employeeday.HasLongAbsence) return false;
            if (!employeeday.HasRelation) return false;
            if (!employeeday.HasContract) return false;
            if (!IsDateCanEdit(employeeday.Date)) return false;
            
            return IsUserCanEdit;
        }

        public bool IsDateCanEdit(DateTime date)
        {
            if (Context == null) return false;

            return Context.AllowEdit(date);
        }


        public bool AllowEdit
        {
            get
            {
                if (Context == null) return false;
                if (!IsDateCanEdit(Context.ViewDate)) return false;

                return IsUserCanEdit;
            }
        }

        #endregion 

        #region Columns functions

        private void BuildFixedColumnDiction()
        {
            _fixedColumn.Add(gc_Employee, null);
            //_fixedColumn.Add(gcActualHours, null);
            _fixedColumn.Add(gcAdditionalHoursActual, null);

            _fixedColumn.Add(gcAdditionalHoursPlanned , null);
            _fixedColumn.Add(gcContractHoursPerWeek , null);

            //_fixedColumn.Add(gcPlannedHours , null);
            _fixedColumn.Add(gcPlusMinusHoursActual , null);

            _fixedColumn.Add(gcPlusMinusHoursPlanned , null);
            _fixedColumn.Add(gcSaldoActual , null);

            _fixedColumn.Add(gcSaldoPlanned , null);
        }
        private bool IsFixedColumn(GridColumn column)
        {
            return _fixedColumn.ContainsKey(column);
        }
        public void BuildColumns()
        {

            gridView.BeginDataUpdate();
            try
            {
                DeleteColumns();
                BandedGridColumn plannedColumn = null;
                BandedGridColumn actualColumn = null;

                int iStep = (int)m_currentView;

                int iMax = Utills.MinutesInDay;

                int iCount = iMax / iStep;
                int iHour = 0;
                int iMinute = 0;
                m_columnsInfo = new TimeColumnInfo[iCount];
                GridBand band = null;
                for (int i = 0; i < iCount; i++)
                {
                    
                    //band = gridView.Bands.AddBand(String.Format("{0}:{1}", iHour.ToString("00"), iMinute.ToString("00")));
                    band = gridView.Bands.AddBand(TextParser.BuildColumnCaption(iHour, iMinute, iStep));
                    band.Tag = i;
                    band.MinWidth = 40;
                    band.Width = 45;
                    
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    band.AppearanceHeader.Options.UseTextOptions = true;

                    plannedColumn = gridView.Columns.Add();
                    plannedColumn.Name = "gcHour_" + i;
                    plannedColumn.MinWidth = 30;
                    plannedColumn.VisibleIndex = 1 + i;
                    plannedColumn.Visible = IsShowPlannedRow;
                    
                    plannedColumn.Width = 45;

                    plannedColumn.AppearanceHeader.Options.UseTextOptions = true;
                    plannedColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    plannedColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    plannedColumn.OptionsColumn.ReadOnly = true;
                    plannedColumn.OptionsColumn.AllowEdit = false;
                    plannedColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    plannedColumn.Tag = i;
                    plannedColumn.OptionsColumn.AllowFocus = false;
                    band.Columns.Add(plannedColumn);
                    m_SummaryItemToPlannedColumn[plannedColumn.SummaryItem] = plannedColumn;

                    actualColumn = gridView.Columns.Add();
                    actualColumn.Name = "gcHour1_" + i;
                    actualColumn.MinWidth = 30;
                    actualColumn.Visible = true;
                    actualColumn.VisibleIndex = 1 + i;
                    actualColumn.Width = 45;
                    actualColumn.RowIndex = 1;
                    actualColumn.AppearanceHeader.Options.UseTextOptions = true;
                    actualColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    actualColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    actualColumn.OptionsColumn.ReadOnly = true;
                    actualColumn.OptionsColumn.AllowEdit = false;
                    actualColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                    actualColumn.Tag = -i;
                    band.Columns.Add(actualColumn);

                    m_SummaryItemToActualColumn[actualColumn.SummaryItem] = actualColumn ;


                    m_columnsInfo[i] = new TimeColumnInfo(iHour * 60 + iMinute, iHour * 60 + iMinute + iStep, true);
                    band.Tag = m_columnsInfo[i];
                    m_DictionOfBands[m_columnsInfo[i]] = band;

                    iMinute += iStep;
                    if (iMinute == 60)
                    {
                        iHour++;
                        iMinute = 0;
                    }
                }
                
            }
            finally
            {
                gridView.EndDataUpdate();
            }
            PrepareColumnsView();
        }

        private void DeleteColumns()
        {
            int iCount = gridView.Columns.Count;
            //GridColumn column = null;
            BandedGridColumn column;
            
            for (int i = iCount - 1; i >= 0; i--)
            {
                column = gridView.Columns[i];
                if (column.Tag != null)
                {
                    gridView.Columns.Remove(column);
                }
            }
            iCount = gridView.Bands.Count;
            GridBand band = null;
            for (int i = iCount - 1; i >= 0; i--)
            {
                band = gridView.Bands[i];
                if (band.Tag != null)
                {
                    gridView.Bands.Remove(band);
                }
            }

            m_columnsInfo = null;
            m_DictionOfBands.Clear();
            m_SummaryItemToPlannedColumn.Clear();
            m_SummaryItemToActualColumn.Clear();
        }

        void PrepareColumnsView()
        {
            if (Context != null &&
                Context.StoreDays != null &&
                Context.StoreDays.ContainsKey(ViewDate))
            {
                StoreDay day = Context.StoreDays[ViewDate];

                if (m_columnsInfo != null)
                {
                    for (int i = 0; i < m_columnsInfo.Length; i++)
                    {
                        if (m_columnsInfo[i].FromTime < (int)day.OpenTime || (int)day.CloseTime <= m_columnsInfo[i].FromTime)
                        {
                            m_columnsInfo[i].IsOpening = false;

                            m_DictionOfBands[m_columnsInfo[i]].Columns [0].AppearanceCell.BackColor = Color.LightGray;
                            m_DictionOfBands[m_columnsInfo[i]].Columns[1].AppearanceCell.BackColor = Color.LightGray;
                        }
                    }



                }
            }
            MakeVisibleFirstThreeHours();
        }

        void MakeVisibleFirstThreeHours()
        {
            if (_LastSelectedTime >= 0)
            {
                MakeVisibleSelectedTime();
                return;
            }
            if (Context != null && Context.StoreDays != null)
            {
                StoreDay day = Context.StoreDays[Context.ViewDate];
                if (m_columnsInfo != null)
                {
                    gridView.FocusedColumn = m_DictionOfBands[m_columnsInfo[m_columnsInfo.Length - 1]].Columns[0];
                    for (int i = 0; i < m_columnsInfo.Length; i++)
                    {
                        if (m_columnsInfo[i].FromTime <= day.OpenTime && day.OpenTime <= m_columnsInfo[i].FromTime)
                        {

                            gridView.FocusedColumn = m_DictionOfBands[m_columnsInfo[i]].Columns[1];//.Column;
                            return;
                        }
                    }
                }
            }
        }


        private void MakeVisibleSelectedTime()
        {
            if (_LastSelectedTime != -1 && _LastSelectedTime > 0 && m_columnsInfo != null)
            {
                gridView.FocusedRowHandle = _LastSelectedRowHandle;

                foreach (TimeColumnInfo cinfo in m_columnsInfo)
                {
                    if (cinfo.FromTime <= _LastSelectedTime && _LastSelectedTime < cinfo.ToTime)
                    {
                        gridView.FocusedColumn = m_DictionOfBands[cinfo].Columns[1];
                        break;
                    }
                }

                gridView.Focus();

                gridView.SelectCell(_LastSelectedRowHandle, gridView.FocusedColumn);

                colmBegin = Math.Abs((int)gridView.FocusedColumn.Tag);
                colmEnd = colmBegin;
                selRowIndex = _LastSelectedRowHandle;
                selectedDayRow = GetEntityByRowHandle(_LastSelectedRowHandle);

            }
        }

        #endregion

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
                LocalizerControl.ComponentsLocalize(components);
                gridBand1.Caption = GetLocalized ("ActualWorkingHours");
                _NUMBER_OF_PEOPLE_ROW = GetLocalized("NumberOfPeoplePerHourRec");
                UpdateWorldInfo();
            }
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
            BuildColumns();
        }

        

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iValue = Convert.ToInt32(radioGroup1.EditValue);
            _LastSelectedTime = -1;
            _LastSelectedRowHandle = -1; 
            TimeColumnInfo cinfo = GetColumnInfo(gridView.FocusedColumn);
            if (cinfo != null)
            {
                _LastSelectedTime = cinfo.FromTime;
                _LastSelectedRowHandle = gridView.FocusedRowHandle;
            }
            if (iValue == 0) CurrentView = DailyViewStyle.View15;
            else
                if (iValue == 1) CurrentView = DailyViewStyle.View30;
                else
                    if (iValue == 2) CurrentView = DailyViewStyle.View60;

            _LastSelectedTime = -1;
            _LastSelectedRowHandle = -1; 
            //MakeVisibleSelectedTime();
        }

        private void deDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (Context != null)
            {
                if (Context.ViewDate.Date != deDate.DateTime.Date)
                {
                    if (Context.BeginWeekDate <= deDate.DateTime &&
                        deDate.DateTime <= Context.EndWeekDate)
                    {
                        Context.SetViewDay(deDate.DateTime.Date);
                        OnChangedContext();
                    }
                    else
                    {
                        Context.SetViewDay(deDate.DateTime.Date);
                    }
                }
            }
        }

        #region help function

        private TimeColumnInfo GetColumnInfo(GridColumn column)
        {
            if (column != null && column.Tag != null)
            {
                GridBand band = (column as BandedGridColumn).OwnerBand;
                if (band != null)
                    return band.Tag as TimeColumnInfo;
            }
            return null;
        }

        
        public RecordingDayRow GetEntityByRowHandle(int rowHandle)
        {
            if (gridView.IsDataRow(rowHandle))
            {
                RecordingDayRow w = (RecordingDayRow)gridView.GetRow(rowHandle);
                return w;
            }
            else return null;
        }

        public RecordingDayRow FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridView.FocusedRowHandle);
            }
        }

        #endregion

        private void gridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (Context == null) return;

            if (e.Column.Tag != null)
            {
                int begin = colmBegin;
                int end = colmEnd;

                if (begin > end)
                {
                    begin = colmEnd;
                    end = colmBegin;
                }
                int idx = (e.Column.Tag == null) ? -10 : Math.Abs((int)e.Column.Tag);
                BandedGridColumn cl = (e.Column as BandedGridColumn);
                if (cl.OwnerBand.Columns[1] == cl)
                {
                    if (e.RowHandle == selRowIndex && (begin <= idx && idx <= end))
                    {

                        e.Appearance.BackColor = Color.Gold;
                        e.Handled = false;
                        return;
                    }
                }
            }
            // if is not hour column return 
            if (IsFixedColumn (e.Column ))
            {
                e.Handled = false;
                //DrawFixedCells(e);
                return;
            }



            StoreDay storeday = Context.StoreDays[Context.ViewDate];

            TimeColumnInfo infoColumn = GetColumnInfo(e.Column);

            if (infoColumn == null) return;

            RecordingDayRow dayView = GetEntityByRowHandle(e.RowHandle);

            if (dayView == null) return;
            int index = infoColumn.FromTime / 15;

            if ((e.Column as BandedGridColumn).Name.StartsWith ("gcHour_"))
                Painters.DrawDailyViewCell2(e, index, CurrentView, storeday, dayView.PlannedView );
            else
                Painters.DrawDailyViewCell2(e, index, CurrentView, storeday, dayView.ActualView );


        }

        private void DrawFixedCells(RowCellCustomDrawEventArgs e)
        {
            RecordingDayRow empl = GetEntityByRowHandle(e.RowHandle);
            if (empl != null)
            {

                Painters.DrawFixedCells_2(e, empl.FullName, e.RowHandle == gridView.FocusedRowHandle, e.Column == gc_Employee);

                e.Handled = true;
            }
        }



        bool mousePress = false;
        int colmBegin = -1;
        int colmEnd = -1;
        int selRowIndex = -1;
        RecordingDayRow selectedDayRow = null;


        GridBand _clickedBand = null;
        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BandedGridHitInfo info = gridView.CalcHitInfo(e.Location);
                
                if (info.InBandPanel)// && info.Band != null)
                {
                    _clickedBand = info.Band;
                    //BandedGridColumn column = _clickedBand.Columns[0];
                    //if (column == gc_HWGR || column == gc_Employee)
                    //{
                    //    column.SortMode = ColumnSortMode.DisplayText;
                    //    if (column.SortOrder == ColumnSortOrder.Ascending)
                    //        column.SortOrder = ColumnSortOrder.Descending;
                    //    else
                    //        column.SortOrder = ColumnSortOrder.Ascending;

                    //    if (column == gc_HWGR)
                    //        gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                    //            new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                    //            new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                    //            });
                    //    else
                    //        gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                    //            new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder),
                    //            new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder)
                    //            });
                    //}
                }
                else if (info.InRowCell)
                {
                    if (info.Column.Tag != null)
                    {
                        colmBegin = Math.Abs((int) info.Column.Tag);
                        colmEnd = colmBegin;
                        selRowIndex = info.RowHandle;
                        selectedDayRow = GetEntityByRowHandle(info.RowHandle);
                        mousePress = true;
                        gridView.InvalidateRow(info.RowHandle);
                    }
                }
                
            }
        }

        private void gridView_MouseMove(object sender, MouseEventArgs e)
        {
            _clickedBand = null;

            if (mousePress)
            {
                BandedGridHitInfo info = gridView.CalcHitInfo(e.Location);
                
               

                if (info.InRowCell)
                {
                    if (info.Column.Tag != null)
                    {
                        colmEnd = Math.Abs((int)info.Column.Tag);
                        gridView.InvalidateRow(info.RowHandle);
                    }
                    else
                    {
                        if (info.Column.Fixed == FixedStyle.Left)
                        {
                            TimeColumnInfo tinfo = m_columnsInfo[0];
                            GridBand band = m_DictionOfBands [tinfo];
                            colmEnd = Math.Abs((int)band.Columns[1].Tag);
                            gridView.InvalidateRow(info.RowHandle);
                        }
                        else
                            if (info.Column.Fixed == FixedStyle.Right)
                            {
                                TimeColumnInfo tinfo = m_columnsInfo[m_columnsInfo.Length - 1];
                                GridBand band = m_DictionOfBands[tinfo];
                                colmEnd = Math.Abs((int)band.Columns[1].Tag);
                                gridView.InvalidateRow(info.RowHandle);
                            }
                    }
                }
            }

        }


        int lastBeginColumn = -1;
        int lastEndColumn = -1;
        int lastSelectedRow = -1;
        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mousePress)
                {
                    if (AllowEdit && !dblclick_event )
                    {
                        if (colmBegin == colmEnd && colmEnd != -1 && selRowIndex != -1)
                        {
                            if (lastBeginColumn != -1 && lastEndColumn != -1 && lastSelectedRow != -1)
                            {
                                if (selRowIndex == lastSelectedRow)
                                {
                                    if (!(lastBeginColumn == colmBegin && colmBegin == lastEndColumn))
                                    {
                                        if (lastBeginColumn <= colmBegin && colmBegin <= lastEndColumn)
                                        {
                                            RecordingDayRow row = GetEntityByRowHandle(lastSelectedRow);
                                            if (row != null && IsEditableDay(row.ActualDay))
                                            {
                                                TimeColumnInfo binfo = m_columnsInfo[lastBeginColumn];
                                                TimeColumnInfo einfo = m_columnsInfo[lastEndColumn];

                                                row.ActualView.MarkAsWorkingTime((short)binfo.FromTime, (short)einfo.ToTime);
                                                if (row.ActualView.Modified)
                                                {
                                                    row.ActualView.UpdateRecordingDay();
                                                    Calculate();
                                                    Context.Modified = true;
                                                    row.ActualView.Modified = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    lastBeginColumn = Math.Min(colmBegin, colmEnd);
                    lastEndColumn = Math.Max(colmBegin, colmEnd);
                    lastSelectedRow = selRowIndex;
                    dblclick_event = false;
                    mousePress = false;
                    gridView.Invalidate();
                }
            }

        }


        private void Calculate()
        {
            if (Context != null)
            {
                if (Context.WorldActualState != null)
                {
                    Context.WorldActualState.Calculate();
                    if (_rowList != null)
                        _SumOfStoreWorldDay.AddRange(_rowList);
                    UpdateWorldInfo();
                    gridView.RefreshData();

                    PlayWorkingModelMessages();
                }
            }
        }

        private void mi_MarkAsWorkingTime_Click(object sender, EventArgs e)
        {
            if (!AllowEdit) return;

            if (selectedDayRow != null)
            {
                if (IsEditableDay(selectedDayRow.ActualDay))
                {
                    if (colmBegin != -1)
                    {
                        int begin = Math.Min(colmBegin, colmEnd);
                        int end = Math.Max(colmBegin, colmEnd);


                        TimeColumnInfo binfo = m_columnsInfo[begin];
                        TimeColumnInfo einfo = m_columnsInfo[end];

                        selectedDayRow.ActualView.MarkAsWorkingTime((short)binfo.FromTime, (short)einfo.ToTime);
                        if (selectedDayRow.ActualView.Modified)
                        {
                            selectedDayRow.ActualView.UpdateRecordingDay();
                            Calculate();
                            Context.Modified = true;
                            selectedDayRow.ActualView.Modified = false;
                        }

                    }
                }
            }
        }

        private void copyFromPlannedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AllowEdit) return;
            RecordingDayRow entity = FocusedEntity;

            if (entity != null)
            {
                if (IsEditableDay(entity.ActualDay))
                {
                    RecordingDayView plannedView = entity.PlannedView;
                    RecordingDayView actualView = entity.ActualView;

                    if (!plannedView.Compare(actualView))
                    {
                        plannedView.CopyTo(actualView);
                        actualView.Modified = false;
                        actualView.UpdateRecordingDay();
                        Calculate();
                        Context.Modified = true;
                    }
                }

            }
        }

        private void mi_CopyAllFromPlanned_Click(object sender, EventArgs e)
        {
            if (!AllowEdit) return;
            if (_rowList != null && _rowList.Count > 0)
            {
                foreach (RecordingDayRow entity in _rowList)
                {
                    RecordingDayView plannedView = entity.PlannedView;
                    RecordingDayView actualView = entity.ActualView;
                    if (plannedView != null && actualView != null)
                    {
                        if (!plannedView.Compare(actualView))
                        {
                            plannedView.CopyTo(actualView);
                            actualView.Modified = false;
                            actualView.UpdateRecordingDay();
                        }
                    }
                    
                }
                Calculate();
                Context.Modified = true;
            }
        }

        private void mi_MarkAsAbsence_Click(object sender, EventArgs e)
        {
            if (!AllowEdit) return;
            using (FormSelectAbsence formSelectAbsence = new FormSelectAbsence())
            {
                formSelectAbsence.Absences = Context.Absences.ToList;
                StoreDay sd = Context.StoreDays[Context.ViewDate];
                formSelectAbsence.ShowTimePanel = false;
                formSelectAbsence.SetDayInfo(sd.OpenTime, sd.CloseTime, Context.StoreDays.AvgDayInWeek);


                if (formSelectAbsence.Execute())
                {
                    if (selectedDayRow != null)
                    {

                        if (colmBegin != -1)
                        {
                            int begin = Math.Min(colmBegin, colmEnd);
                            int end = Math.Max(colmBegin, colmEnd);


                            TimeColumnInfo binfo = m_columnsInfo[begin];
                            TimeColumnInfo einfo = m_columnsInfo[end];


                            selectedDayRow.ActualView.MarkAsAbsenceTime((short)binfo.FromTime, (short)einfo.ToTime, formSelectAbsence.SelectedAbsence);


                            if (selectedDayRow.ActualView.Modified)
                            {
                                selectedDayRow.ActualView.Modified = false;
                                selectedDayRow.ActualView.UpdateRecordingDay();
                                Calculate();
                                Context.Modified = true;
                            }
                            
                        }
                    }
                }
            }
        }

        private void tm_ClearTime_Click(object sender, EventArgs e)
        {
            if (!AllowEdit) return;
            if (selectedDayRow != null)
            {

                if (colmBegin != -1)
                {
                    int begin = Math.Min(colmBegin, colmEnd);
                    int end = Math.Max(colmBegin, colmEnd);


                    TimeColumnInfo binfo = m_columnsInfo[begin];
                    TimeColumnInfo einfo = m_columnsInfo[end];

                    selectedDayRow.ActualView.ResetTimeRange ((short)binfo.FromTime, (short)einfo.ToTime);
                    if (selectedDayRow.ActualView.Modified)
                    {
                        selectedDayRow.ActualView.Modified = false;
                        selectedDayRow.ActualView.UpdateRecordingDay();
                        Calculate();
                        Context.Modified = true;
                    }
                }
            }
        }

        private void mi_Absence_Click(object sender, EventArgs e)
        {
            if (!AllowEdit) return;
            using (FormSelectAbsence formSelectAbsence = new FormSelectAbsence())
            {

                formSelectAbsence.Absences = Context.Absences.ToList;
                StoreDay sd = Context.StoreDays[Context.ViewDate];
                formSelectAbsence.ShowTimePanel = false;
                formSelectAbsence.SetDayInfo(sd.OpenTime, sd.CloseTime, Context.StoreDays.AvgDayInWeek);


                if (formSelectAbsence.Execute())
                {
                    ProcessNewAbsence(formSelectAbsence.SelectedAbsence);
                }
            }
        }

        private void gridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridSummaryItem item = (GridSummaryItem)e.Item;
            e.TotalValue = TextParser.TimeToString (GetTotalSummary(item))  ;
            e.TotalValueReady = true;
        }

        private int GetTotalSummary(GridSummaryItem item)
        {
            if (m_SummaryItemToActualColumn.ContainsKey(item))
            {
                BandedGridColumn column = m_SummaryItemToActualColumn[item];
                TimeColumnInfo columninfo = (TimeColumnInfo)column.OwnerBand.Tag;
                int sum = _SumOfStoreWorldDay.GetActualSum(columninfo.FromTime, columninfo.ToTime); 
                return sum;
            }

            if (m_SummaryItemToPlannedColumn.ContainsKey(item))
            {
                BandedGridColumn column = m_SummaryItemToPlannedColumn[item];
                TimeColumnInfo columninfo = (TimeColumnInfo)column.OwnerBand.Tag;
                int sum = _SumOfStoreWorldDay.GetPlannedSum(columninfo.FromTime, columninfo.ToTime);
                return sum;
            }
            

            foreach (BandedGridColumn c in gridView.Columns)
            {
                if (c.SummaryItem == item)
                {
                    if (gcHoursActual == c)
                    {
                        return _SumOfStoreWorldDay.TotalActualPlannedHours ;
                    }
                    if (gcHoursPlanned == c)
                    {
                        return _SumOfStoreWorldDay.TotalPlannedHours ;
                    }
                }
            }
            return 0;

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
                using (FormEnterAbsenceTime form = new FormEnterAbsenceTime())
                {

                    if (form.ShowDialog() == DialogResult.OK)
                    {


                        RecordingDayRow row = FocusedEntity;
                        if (row != null)
                        {
                            row.ActualView.MarkAsAbsenceTime((short)form.BeginTime, (short)form.EndTime, absence);
                            if (row.ActualView.Modified)
                            {
                                row.ActualView.UpdateRecordingDay();
                                Context.Modified = true;
                                row.ActualView.Modified = false;
                                Calculate();
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

                    RecordingDayRow row = FocusedEntity;
                    TimeColumnInfo info = GetColumnInfo(gridView.FocusedColumn);

                    if (row != null && info != null)
                    {
                        row.ActualView.MarkAsAbsenceTime((short)info.FromTime, (short)(info.FromTime + count), absence);
                        if (row.ActualView.Modified)
                        {
                            row.ActualView.UpdateRecordingDay();
                            Context.Modified = true;
                            row.ActualView.Modified = false;
                            Calculate();
                        }
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
                    RecordingDayRow row = FocusedEntity;

                    TimeColumnInfo info = GetColumnInfo(gridView.FocusedColumn);

                    if (row != null && info != null)
                    {
                        int count = DateTimeHelper.RoundToQuoter((short)((row.ActualWeek.ContractHoursPerWeek / Context.StoreDays.AvgDayInWeek)));

                        row.ActualView.MarkAsAbsenceTime((short)info.FromTime, (short)(info.FromTime + count), absence);
                        if (row.ActualView.Modified)
                        {
                            row.ActualView.UpdateRecordingDay();
                            Context.Modified = true;
                            row.ActualView.Modified = false;
                            Calculate();
                        }
                    }
                }
            }
        }

        #endregion
        bool dblclick_event = false;
        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!AllowEdit) return;
            GridHitInfo info = gridView.CalcHitInfo(e.X, e.Y);
            if (info.InRow)
            {
                TimeColumnInfo timeinfo = GetColumnInfo(info.Column);

                if (timeinfo != null)
                {

                    RecordingDayRow row = FocusedEntity;

                    if (row != null)
                    {
                        if (!row.ActualView.IsEmpty((short)timeinfo.FromTime, (short)timeinfo.ToTime))
                            row.ActualView.ResetTimeRange((short)timeinfo.FromTime, (short)timeinfo.ToTime);
                        else
                            row.ActualView.MarkAsWorkingTime((short)timeinfo.FromTime, (short)timeinfo.ToTime);
                        row.ActualView.UpdateRecordingDay();
                        row.ActualView.Modified = false;
                        Context.Modified = true;
                        Calculate();
                    }
                    dblclick_event = true;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!AllowEdit)
            {
                e.Cancel = true;
                
            }

            if (gridView.RowCount == 0)
            {
                e.Cancel = true;
            }


            if (e.Cancel) return;
        }


        private void gridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column == gc_Employee)
            {
                DrawHeaderFooter(e);
            }
            else if (e.Column == gcHoursActual || e.Column == gcHoursPlanned )
            {
                e.Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                if (e.Column == gcHoursActual)
                    DrawAllreadyPlannedFooterCells(e);
            }
            else if (e.Column == gcHoursPlanned)
            {
                e.Info.DisplayText = DateTimeHelper.IntTimeToStr(_SumOfStoreWorldDay.TotalPlannedHours);
            }
            else
            {

                TimeColumnInfo columninfo = (e.Column as BandedGridColumn ).OwnerBand.Tag as TimeColumnInfo;
                if (columninfo != null)
                {
                    e.Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


                    if (m_SummaryItemToActualColumn.ContainsKey(e.Column.SummaryItem))
                        DrawHourlyFooter(columninfo, e);
                }
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
        private void DrawHeaderFooter(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Painter.DrawObject(e.Info);

            int iWidth = (gc_HWGR.Visible) ? gc_HWGR.Width : 0;

            Rectangle oldBounds = e.Info.Bounds;
            string oldText = e.Info.DisplayText;

            e.Info.Bounds = new Rectangle(oldBounds.Left, oldBounds.Bottom + 1, oldBounds.Width + iWidth, oldBounds.Height);
            if (chk_ShowHidePlannedRow.Checked)
                e.Info.Bounds = new Rectangle(oldBounds.Left, oldBounds.Bottom + 1, oldBounds.Width + iWidth, oldBounds.Height / 2 );

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

            int value = GetTotalSummary(e.Column.SummaryItem);
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


        private void DrawAllreadyPlannedFooterCells(DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            int value = 0;

            value = _SumOfStoreWorldDay.TotalActualPlannedHours;

            e.Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            e.Info.DisplayText = DateTimeHelper.IntTimeToStr(value);

            e.Painter.DrawObject(e.Info);

            value = _SumOfStoreWorldDay.TotalActualWorkingHours;

            Rectangle oldBounds = e.Info.Bounds;
            string oldText = e.Info.DisplayText;
            e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Bottom + 1, e.Info.Bounds.Width, e.Info.Bounds.Height);
            e.Info.DisplayText = FooterHoursAsString(value);

            e.Painter.DrawObject(e.Info);

            e.Info.Bounds = oldBounds;
            e.Info.DisplayText = oldText;

            e.Handled = true;
        }


        private void chk_ShowHidePlannedRow_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ShowHidePlannedRow.Checked)
                ShowPlannedRow();
            else
                HidePlannedRow();
        }

        private void HidePlannedRow()
        {
            gridView.BeginDataUpdate();
            try
            {
                foreach (BandedGridColumn column in gridView.Columns)
                {
                    if (column.Name.StartsWith("gcHour_"))
                        column.Visible = false;
                    if (column.Name.EndsWith("Planned"))
                        column.Visible = false;
                }
            }
            finally
            {
                gridView.EndDataUpdate();
            }
        }

        private void ShowPlannedRow()
        {
            gridView.BeginDataUpdate();
            try
            {
                foreach (BandedGridColumn column in gridView.Columns)
                {
                    if (column.Name.StartsWith("gcHour_"))
                    {
                        column.Visible = true;
                        column.RowIndex = 0;
                    }
                    if (column.Name.EndsWith("Planned"))
                    {
                        column.Visible = true;
                        column.RowIndex = 0;
                    }
                }
                foreach (BandedGridColumn column in gridView.Columns)
                {
                    if (column.Name.StartsWith("gcHour1_"))
                    {
                        column.Visible = true;
                        column.RowIndex = 1;
                    }
                    if (column.Name.EndsWith("Actual"))
                    {
                        column.Visible = true;
                        column.RowIndex = 1;
                    }
                }
            }
            finally
            {
                gridView.EndDataUpdate();
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

        private void gridControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BandedGridHitInfo info = gridView.CalcHitInfo(e.Location);

                if (info.InBandPanel && info.Band != null && info.Band == _clickedBand)
                {
                    BandedGridColumn column = _clickedBand.Columns[0];
                    if (column == gc_HWGR || column == gc_Employee)
                    {
                        column.SortMode = ColumnSortMode.DisplayText;
                        if (column.SortOrder == ColumnSortOrder.Ascending)
                            column.SortOrder = ColumnSortOrder.Descending;
                        else
                            column.SortOrder = ColumnSortOrder.Ascending;

                        if (column == gc_HWGR)
                            gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                                new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder),
                                new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder)
                                });
                        else
                            gridView.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] { 
                                new GridColumnSortInfo(gc_Employee, gc_Employee.SortOrder),
                                new GridColumnSortInfo(gc_HWGR, gc_HWGR.SortOrder)
                                });
                    }
                }
            }
        }


    }
}
