using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;

namespace Baumax.Printouts.ManpowerTimePlanning
{
	public partial class ManpowerTimePlanningPrintout : ReportBase
	{
		private ViewType _viewType;
		private DateTime _viewDate, _startDate, _endDate;
		private bool _additionalManual, _manualOnly, _hideSums;
		private long _countryID;
		private long _storeID;
		private long[] _storeToWorldIDs;
        private SortField[] _sortFields;
        private Dictionary<StoreToWorld, StoreWorldWeekPlanningState> _bindingHash = new Dictionary<StoreToWorld, StoreWorldWeekPlanningState>();
		private TimePlanningReportContext _planningContext;
		private WeeklyPlanningPrintController _weeklyReportPrintController;

        public ManpowerTimePlanningPrintout()
		{
			InitializeComponent();
            
			if (ClientEnvironment.IsRuntimeMode)
			{
				ReportLocalizer.Localize(this);
			}
		}

		public void BuildWithCriteria(long countryID, long storeID, long? storeToWorldID, ViewType viewType, DateTime startDate, bool additionalManual, bool manualOnly, bool hideSums, SortField[] sortFields)
		{
			_viewType = viewType;

			if(startDate < DateTimeSql.DatetimeMin || startDate > DateTimeSql.DatetimeMax)
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
			} else if (viewType == ViewType.Daily)
			{
				_viewDate = startDate;
				_startDate = DateTimeHelper.GetMonday(startDate);
				_endDate = DateTimeHelper.GetSunday(startDate);
			}

			_countryID = countryID;
			_storeID = storeID;
		    _sortFields = sortFields;

			// Use A4 landscape for single world and A3 for all worlds
			if (storeToWorldID.HasValue)
			{
				_storeToWorldIDs = new long[] { storeToWorldID.Value };
				PaperKind = PaperKind.A4;
				Landscape = true;
			} else
			{
				PaperKind = PaperKind.A3;
				Landscape = false;
			}
			
			_additionalManual = additionalManual;
			_manualOnly = manualOnly;
			_hideSums = hideSums;

			PrintHeader();

			LoadData();
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
				lbCell_TimeRange.Text = string.Format("{0} :   {1}",
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

            _planningContext = new TimePlanningReportContext(_countryID, _storeID, _startDate, _endDate);
            List<long> spanIDs = new List<long>();
            foreach (StoreToWorld world in worldsDataSource)
            {
                StoreWorldWeekPlanningState state = _planningContext.GetWorldPlanningState(world.ID);
                if (state.List == null || state.List.Count == 0)
                    spanIDs.Add(world.ID);
                else
                    _bindingHash[world] = state;
            }

            worldsDataSource.RemoveAll(delegate(StoreToWorld stw) { return spanIDs.Contains(stw.ID); });
            worldsDataSource.Sort(new WorldComparer());
            DataSource = worldsDataSource;
			//
			// Planning Context
			//
			
			
			if (_viewType == ViewType.Weekly)
			{
				_weeklyReportPrintController = new WeeklyPlanningPrintController(_planningContext);
				_weeklyReportPrintController.ManualFill = _additionalManual;
				_weeklyReportPrintController.ManualFillOnly = _manualOnly;
				_weeklyReportPrintController.HideSums = _hideSums;
			}
			field_WorldName.DataBindings.Add("Text", DataSource, "WorldName", Localizer.GetLocalized("World") + ": {0}");
		}

		private void BuildWeeklyReport(long worldID)
		{
			_weeklyReportPrintController.CurrentWorldID = worldID;

			if (_hideSums)
			{
				TimePlanningWeelkyNoSummary detailsSubreport = new TimePlanningWeelkyNoSummary();
				detailsSubreport.Controller = _weeklyReportPrintController;

				subreportDetails.ReportSource = detailsSubreport;
			} else
			{
				TimePlanningWeekly detailsSubreport = new TimePlanningWeekly();
				detailsSubreport.Controller = _weeklyReportPrintController;
				
				subreportDetails.ReportSource = detailsSubreport;
			}
		}

		private void BuildDailyReport (EmployeeDayViewList dayViewList)
		{
			TimePlanningDaily report = new TimePlanningDaily();
			report.PlanningContext = _planningContext;
			report.DayViewList = dayViewList;

			report.ViewDate = _viewDate;
			report.ManualFill = _additionalManual;
			report.ManualFillOnly = _manualOnly;
			report.HideSums = _hideSums;

			subreportDetails.ReportSource = report;
		}

		private void subreportDetails_BeforePrint(object sender, PrintEventArgs e)
		{
			StoreToWorld currentWorld = (StoreToWorld)GetCurrentRow();
			StoreWorldWeekPlanningState weekPlanningState = _bindingHash[currentWorld];
			if (weekPlanningState != null)
			{
				weekPlanningState.Calculate();
			}
			else
			{
				e.Cancel = true;
				return;
			}

			object dataSource;

			if (_viewType == ViewType.Weekly)
			{
                // acpro #125528
                dataSource = SortUtils<EmployeePlanningWeek>.Sort(weekPlanningState.List, _sortFields);
				BuildWeeklyReport(currentWorld.ID);
			}
			else
			{
				EmployeeDayViewList dayViewList = weekPlanningState.GetDailyListView(_viewDate);
				if (dayViewList == null)
				{
					e.Cancel = true;
					return;
				}

                // acpro #125528
                dataSource = SortUtils<EmployeePlanningWeek>.Sort(dayViewList.DayWeeklyList, _sortFields);
				BuildDailyReport(dayViewList);
			}

			
			subreportDetails.ReportSource.PaperKind = PaperKind;
			subreportDetails.ReportSource.Landscape = Landscape;

			subreportDetails.ReportSource.DataSource = dataSource;
		}
	}
}