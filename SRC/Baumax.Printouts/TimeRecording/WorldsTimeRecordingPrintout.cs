using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;

namespace Baumax.Printouts.TimeRecording
{
    public partial class WorldsTimeRecordingPrintout : ReportBase
    {
        private ViewType _viewType;
        private DateTime _viewDate, _startDate, _endDate;
        private bool _printPlannedValues, _hideSums;
        private long _countryID;
        private long _storeID;
        private long[] _storeToWorldIDs;
        private SortField[] _sortFields;
        private Dictionary<StoreToWorld, StoreWorldWeekState[]> _hashStates = new Dictionary<StoreToWorld, StoreWorldWeekState[]>();

        private WorldsTimeRecordingPrintoutContext _timeRecordingContext;
        private WorldsTimeRecordingWeekly _weeklyPrintout;
        private WorldsTimeRecordingDaily _dailyPrintout;

        public WorldsTimeRecordingPrintout()
        {
            InitializeComponent();
            // 
            if (ClientEnvironment.IsRuntimeMode)
            {
                ReportLocalizer.Localize(this);
            }
        }

        public void BuildWithCriteria(long countryID, long storeID, long? storeToWorldID, ViewType viewType,
                                      DateTime startDate, bool printPlannedValues, bool hideSums, SortField[] sortFields)
        {
            _viewType = viewType;

            if (startDate < DateTimeSql.DatetimeMin || startDate > DateTimeSql.DatetimeMax.AddDays(-7))
            {
                throw new ValidationException("ErrorBeginDateIncorrect", null);
            }

            if (viewType == ViewType.Weekly)
            {
                if (startDate.DayOfWeek != DayOfWeek.Monday)
                {
                    throw new ValidationException("ErrorBeginDateIncorrect", null);
                }
                _startDate = startDate;
                _endDate = DateTimeHelper.GetSunday(startDate);

                // Init subreport
                _weeklyPrintout = new WorldsTimeRecordingWeekly();
                _weeklyPrintout.Init(_timeRecordingContext, _startDate, _printPlannedValues, _hideSums);
                subreportDetails.ReportSource = _weeklyPrintout;
            }
            else if (viewType == ViewType.Daily)
            {
                _viewDate = startDate;
                _startDate = DateTimeHelper.GetMonday(startDate);
                _endDate = DateTimeHelper.GetSunday(startDate);

                // Init subreport
                _dailyPrintout = new WorldsTimeRecordingDaily();
                _dailyPrintout.Init(_timeRecordingContext, _startDate, _printPlannedValues, _hideSums);
                subreportDetails.ReportSource = _dailyPrintout;
            }

            _countryID = countryID;
            _storeID = storeID;
            _sortFields = sortFields;

            // Use A4 landscape for single world and A3 for all worlds
            if (storeToWorldID.HasValue)
            {
                _storeToWorldIDs = new long[] {storeToWorldID.Value};
                PaperKind = PaperKind.A4;
                Landscape = true;
            }
            else
            {
                PaperKind = PaperKind.A3;
                Landscape = false;
            }

            _printPlannedValues = printPlannedValues;
            _hideSums = hideSums;

            PrintHeader();

            LoadData();

            // Init subreport
            if (viewType == ViewType.Weekly)
            {
                _weeklyPrintout = new WorldsTimeRecordingWeekly();
                _weeklyPrintout.Init(_timeRecordingContext, _startDate, _printPlannedValues, _hideSums);
                subreportDetails.ReportSource = _weeklyPrintout;
            }
            else if (viewType == ViewType.Daily)
            {
                _dailyPrintout = new WorldsTimeRecordingDaily();
                _dailyPrintout.Init(_timeRecordingContext, _startDate, _printPlannedValues, _hideSums);
                subreportDetails.ReportSource = _dailyPrintout;
            }
        }

        private void PrintHeader()
        {
            Store store = ClientEnvironment.StoreService.FindById(_storeID);
            fieldCell_Store.Text = store.Name;

            if (_viewType == ViewType.Weekly)
                lbCell_TimeRange.Text = string.Format("{0}. {1}:   {2} - {3}",
                    DateTimeHelper.GetWeekNumber(_startDate),
                    Localizer.GetLocalized("Week"),
                    _startDate.ToShortDateString(),
                    _endDate.ToShortDateString());
            else
                lbCell_TimeRange.Text = string.Format("{0}:   {1}",
                    Localizer.GetLocalized("Date"),
                    _viewDate.ToShortDateString());
        }

        private void LoadData()
        {
            // Worlds
            List<StoreToWorld> worldsDataSource;
            if (_storeToWorldIDs == null)
            {
                worldsDataSource = ClientEnvironment.StoreToWorldService.FindAllForStore(_storeID);
            }
            else
            {
                worldsDataSource = ClientEnvironment.StoreToWorldService.FindByIDList(new List<long>(_storeToWorldIDs));
            }
            
            
            //
            // Planning Context
            //
            _timeRecordingContext = new WorldsTimeRecordingPrintoutContext(_countryID, _storeID, _startDate, _viewDate);
            List<long> spanIDs = new List<long>();
            foreach (StoreToWorld world in worldsDataSource)
            {
                _timeRecordingContext.LoadEmployeePlanningAndRecording(world);
                StoreWorldWeekState[] state = new StoreWorldWeekState[] { _timeRecordingContext.WorldPlanningState, 
                                                                          _timeRecordingContext.WorldActualState };
                _hashStates[world] = state;
                if (state[0].List == null || state[0].List.Count == 0
                 || state[1].List == null || state[1].List.Count == 0)
                    spanIDs.Add(world.ID);
            }
            worldsDataSource.RemoveAll(delegate(StoreToWorld stw) { return spanIDs.Contains(stw.ID); });
            worldsDataSource.Sort(new WorldComparer());
            DataSource = worldsDataSource;
            

            field_WorldName.DataBindings.Add("Text", DataSource, "WorldName", Localizer.GetLocalized("World") + ": {0}");
        }

        private void subreportDetails_BeforePrint(object sender, PrintEventArgs e)
        {
            StoreToWorld currentWorld = (StoreToWorld) GetCurrentRow();
            StoreWorldWeekState plannedWeekState = _hashStates[currentWorld][0];
            StoreWorldWeekState actualWeekState = _hashStates[currentWorld][1];

            if (plannedWeekState != null)
            {
                plannedWeekState.Calculate();
            }
            else
            {
                e.Cancel = true;
                return;
            }

            object dataSource = null;

            if (_viewType == ViewType.Weekly)
            {
                List<EmployeeWeekView> weekViews = new List<EmployeeWeekView>();

                if (plannedWeekState.List != null)
                {
                    foreach (EmployeeWeek ew in plannedWeekState.List)
                    {
                        Employee emp = ClientEnvironment.EmployeeService.FindById(ew.EmployeeId);
                        weekViews.Add(
                            new EmployeeWeekView(_timeRecordingContext, ew, actualWeekState[ew.EmployeeId],
                                                 emp.OrderHwgrID ?? 0));
                    }
                }

                // acpro #125528
                dataSource = SortUtils<EmployeeWeekView>.Sort(weekViews, _sortFields);

                _weeklyPrintout.StoreToWorldID = currentWorld.ID;
            }
            else
            {
                if (plannedWeekState.List != null)
                {
                    // acpro #125528
                    dataSource =
                        SortUtils<EmployeeWeek>.Sort(
                            plannedWeekState.List.FindAll(
                                delegate(EmployeeWeek ew) { return ew.IsHasWorldByDate(currentWorld.ID, _viewDate); }),
                            _sortFields);
                }
            }

            subreportDetails.ReportSource.PaperKind = PaperKind;
            subreportDetails.ReportSource.Landscape = Landscape;

            subreportDetails.ReportSource.DataSource = dataSource;
        }
    }
}