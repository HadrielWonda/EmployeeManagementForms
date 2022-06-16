using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Environment;
using Baumax.Domain;

namespace Baumax.Printouts.TimeRecording
{
	public class WorldsTimeRecordingPrintoutContext : IRecordingContext
	{
		private StoreDaysList _storeDays = null;
		private readonly AbsenceManager _countryAbsences = null;
		private readonly WorkingModelManagerNew _workingModelManager = null;
		private readonly LongTimeAbsenceManager _longAbsences = null;
		private readonly CountryColorManager _colorManager = null;

		private long _countryID;
		private long _storeID;
		private long _currentWorldID;
		private long _currentStoreToWorldID;

		private readonly DateTime _beginWeekDate;
		private readonly DateTime _endWeekDate;
		private readonly DateTime _viewDate;

		private StoreWorldWeekState _planningWorldState = null;
		private StoreWorldWeekState _actualWorldState = null;

		public WorldsTimeRecordingPrintoutContext(long countryID, long storeID, DateTime startDate, DateTime viewDate)
		{
			_countryID = countryID;
			_storeID = storeID;

			_countryAbsences = new AbsenceManager(ClientEnvironment.AbsenceService);
			_countryAbsences.CountryId = _countryID;

			_longAbsences = new LongTimeAbsenceManager(ClientEnvironment.LongTimeAbsenceService);
			_longAbsences.CountryId = _countryID;

			_workingModelManager = new WorkingModelManagerNew(ClientEnvironment.WorkingModelService);
			_workingModelManager.CountryId = _countryID;

			_colorManager = new CountryColorManager(ClientEnvironment.ColouringService);
			_colorManager.CountryId = _countryID;

			_beginWeekDate = DateTimeHelper.GetMonday(startDate);
			_endWeekDate = DateTimeHelper.GetSunday(startDate);
			_viewDate = viewDate;

			LoadStoreDayInfo();
		}		

		public ILongTimeAbsenceManager LongAbsences
		{
			get { return _longAbsences; }
		}

		public IAbsenceManager Absences
		{
			get { return _countryAbsences; }
		}

		public IWorkingModelManager WorkingModels
		{
			get { return _workingModelManager; }
		}

		public ICountryColorManager CountryColors
		{
			get { return _colorManager; }
		}

		public IStoreDaysList StoreDays
		{
			get { return _storeDays; }
		}

		public bool Modified
		{
			get { return false; }
			set
			{
				throw new NotSupportedException("The printout is readonly");
			}
		}

		public long CountryId
		{
			get { return _countryID; }
		}

		public long StoreId
		{
			get { return _storeID; }
		}

		public long StoreWorldId
		{
			get { return 0; }
		}

		public DateTime BeginWeekDate
		{
			get { return _beginWeekDate; }
		}

		public DateTime EndWeekDate
		{
			get { return _endWeekDate; }
		}

		public DateTime ViewDate
		{
			get { return _viewDate; }
		}

		public StoreWorldWeekState WorldPlanningState
		{
			get { return _planningWorldState; }
		}

		public StoreWorldWeekState WorldActualState
		{
			get { return _actualWorldState; }
		}

		public void SetCountryAndStore(long countryid, long storeid)
		{
			if(CountryId != countryid)
			{
				_countryID = countryid;
				Absences.CountryId = CountryId;
				WorkingModels.CountryId = CountryId;
				CountryColors.CountryId = CountryId;
				LongAbsences.CountryId = CountryId;
			}

			if(StoreId != storeid)
			{
				_storeID = storeid;
				_planningWorldState = null;
				_actualWorldState = null;
				LoadStoreDayInfo();
			}
		}

		public void SetViewDay(DateTime vday)
		{
			throw new NotSupportedException("Changing view date is not supported");
		}

		private void LoadStoreDayInfo()
		{
			if(_storeDays != null && _storeDays.StoreId == StoreId && _storeDays.BeginTime == BeginWeekDate)
			{
				return;
			}

			_storeDays = ClientEnvironment.StoreService.GetStoreDays(StoreId, BeginWeekDate, EndWeekDate);
		}

		public void LoadEmployeePlanningAndRecording(StoreToWorld world)
		{
			_currentWorldID = 0;

            if (world != null)
			{
                _currentWorldID = world.WorldID;

                List<EmployeeWeek> planningWeeks = ClientEnvironment.EmployeeService.GetTimePlannignEmployeeByWorld2(StoreId, _currentWorldID, BeginWeekDate, EndWeekDate);
				Absences.FillEmployeeWeek(planningWeeks);
                _planningWorldState = new StoreWorldWeekState(world, BeginWeekDate, EndWeekDate);
                EmployeeWeekProcessor.MarkAsPlannedWeek(planningWeeks);
                
				if(planningWeeks != null)
				{
                    _planningWorldState.List.AddRange(planningWeeks);
                    foreach (EmployeeWeek ew in planningWeeks)
                        ew.InitWeekState();
				}

				_planningWorldState.Context = this;
				_planningWorldState.Calculate();

                planningWeeks = ClientEnvironment.EmployeeService.GetTimeRecordingEmployeeByWorld(StoreId, _currentWorldID, BeginWeekDate, EndWeekDate);
				Absences.FillEmployeeWeek(planningWeeks);
                _actualWorldState = new StoreWorldWeekState(world, BeginWeekDate, EndWeekDate);
                EmployeeWeekProcessor.MarkAsRecordingWeek(planningWeeks);
				if(planningWeeks != null)
				{
					_actualWorldState.List.AddRange(planningWeeks);
                    foreach (EmployeeWeek ew in planningWeeks)
                        ew.InitWeekState();
				}

				_actualWorldState.Context = this;
				_actualWorldState.Calculate();
			}
		}

		public event ChangedContext ChangedContext
		{
			add { throw new NotSupportedException(); }
			remove { throw new NotSupportedException(); }
		}
	}
}