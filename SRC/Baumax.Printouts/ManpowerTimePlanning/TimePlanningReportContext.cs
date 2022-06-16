using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.Printouts.ManpowerTimePlanning
{
	public class TimePlanningReportContext : IPlanningContext
	{
		private readonly IAbsenceManager _absences;
		private readonly IWorkingModelManager _workingModels;
		private readonly ILongTimeAbsenceManager _longAbsences;
		private readonly IStoreDaysList _storeDays;
		private readonly ICountryColorManager _countryColors;
		private readonly List<EmployeePlanningWeek> _storeEmployees;

		private readonly long _countryID;
		private readonly long _storeID;
		private readonly DateTime _startDate;
		private readonly DateTime _endDate;

		public TimePlanningReportContext(long countryID, long storeID, DateTime startDate, DateTime endDate)
		{
			_countryID = countryID;
			_storeID = storeID;
			_startDate = startDate;
			_endDate = endDate;

			_absences = new AbsenceManager(ClientEnvironment.AbsenceService);
			_absences.CountryId = _countryID;
			
			_longAbsences = new LongTimeAbsenceManager(ClientEnvironment.LongTimeAbsenceService);
			_longAbsences.CountryId = _countryID;
			
			_workingModels = new WorkingModelManager(ClientEnvironment.WorkingModelService);
			_workingModels.CountryId = _countryID;

			_countryColors = new CountryColorManager(ClientEnvironment.ColouringService);
			_countryColors.CountryId = _countryID;

			_storeDays = ClientEnvironment.StoreService.GetStoreDays(_storeID, StartDate, EndDate);

			_storeEmployees = ClientEnvironment.EmployeeService.GetTimePlannignEmployee2(_storeID, StartDate, EndDate);

            if (_storeEmployees != null)
            {
                foreach (EmployeePlanningWeek week in _storeEmployees)
                {
                    if (_storeDays.AvgDayInWeek == 0)
                        week.AvgDaysWeek = 5;
                    else 
                        week.AvgDaysWeek = _storeDays.AvgDayInWeek;
                    week.InitWeekState();
                }
            }
			LoadWorkingAndAbsencesHours();
            ApplyStoreDays();
		}
        private void ApplyStoreDays()
        {
            Dictionary<long, StoreDaysList> dict = new Dictionary<long, StoreDaysList>();
            dict[_storeID] = _storeDays as StoreDaysList;
            if (_storeEmployees != null && _storeEmployees.Count > 0)
            {
                foreach (EmployeePlanningWeek week in _storeEmployees)
                {
                    foreach (EmployeePlanningDay day in week.Days.Values)
                    {
                        if (day.HasRelation)
                        {
                            if (day.StoreId == _storeID)
                            {
                                day.StoreDay = StoreDays[day.Date];
                            }
                            else
                            {
                                if (!dict.ContainsKey(day.StoreId))
                                {
                                    dict[day.StoreId] = ClientEnvironment.StoreService.GetStoreDays(day.StoreId, _startDate, _endDate);
                                }

                            }
                        }
                    }
                }
            }

        }
		#region IPlanningContext Members

		public IAbsenceManager Absences
		{
			get { return _absences; }
		}

		public ICountryColorManager CountryColors
		{
			get { return _countryColors; }
		}

		public ILongTimeAbsenceManager LongAbsences
		{
			get { return _longAbsences; }
		}

		public IStoreDaysList StoreDays
		{
			get { return _storeDays; }
		}

		public IWorkingModelManager WorkingModels
		{
			get { return _workingModels; }
		}

		public DateTime StartDate
		{
			get { return _startDate; }
		}

		public DateTime EndDate
		{
			get { return _endDate; }
		}

		#endregion

		private void LoadWorkingAndAbsencesHours()
		{
			long[] ids = PlanningWeekProcessor.ListToEmployeeIds(_storeEmployees);

			List<WorkingTimePlanning> _workingTimes = ClientEnvironment.WorkingTimePlanningService.GetWorkingTimePlanningsByEmployeeIds(ids, StartDate, EndDate);
			List<AbsenceTimePlanning> _absenceTimes = ClientEnvironment.AbsenceTimePlanningService.GetAbsenceTimePlanningsByEmployeeIds(ids, StartDate, EndDate);

			Absences.FillAbsencePlanningTimes(_absenceTimes);

			PlanningWeekProcessor.AssignTimes(_storeEmployees, _workingTimes, _absenceTimes);

		}

		public StoreWorldWeekPlanningState GetWorldPlanningState(long worldID)
		{
			StoreWorldWeekPlanningState result = new StoreWorldWeekPlanningState(worldID, StartDate, EndDate);
			result.IContext = this;

			List<EmployeePlanningWeek> worldEmployees = PlanningWeekProcessor.GetEmployeesByWorld(worldID, _storeEmployees);

			if (worldEmployees != null)
			{
				result.List.AddRange(worldEmployees);
			}

			return result;
		}

		public string GetLongTimeAbbreviation(long id)
		{

			LongTimeAbsence absence = LongAbsences.GetById(id); ;
			string result = String.Empty;
			if (absence != null)
			{
				result = (absence.CharID != null) ? absence.CharID : String.Empty;
			}
			return result;
		}
        public int? GetLongTimeAbsenceColor(long id)
        {
            return LongAbsences.GetColor(id);
        }
	}
}