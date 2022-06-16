using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.TimePlanning
{
    [Serializable]
    public sealed class EmployeePlanningDay
    {
        #region  fields

        //private Employee _employee;
        private DateTime _date;
        private EmployeePlanningWeek _owner = null;
        private bool _HasContract = false;
        private bool _HasLongAbsence = false;
        private bool _HasRelation = false;
        private decimal _ContractHoursPerWeek = 0;
        private List<WorkingTimePlanning> _WorkingTimeList;
        private List<AbsenceTimePlanning> _AbsenceTimeList;
        private List<EmployeePlanningWorkingModel> _WorkingModels = null;
        private long _RelationWorldId;
        private long _StoreId;
        
        private StoreDay _storeday = null;

        private int _CountWorkingTime = 0;
        private int _CountPlannedWorkingTime = 0;
        private int _CountAdditionalCharges = 0;
        public long LongAbsenceId = 0;
        public bool Modified = false;

        public int UnitPerDay = 0;
        #endregion

        #region properties

        public StoreDay StoreDay
        {
            get { return _storeday; }
            set { _storeday = value; }
        }

        public string FullName
        {
            get
            {
                if (PlanningWeek != null) return PlanningWeek.FullName;
                else return String.Empty;
            }
        }

        public long EmployeeId
        {
            get { return (PlanningWeek != null) ? PlanningWeek.EmployeeId : 0; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public EmployeePlanningWeek PlanningWeek
        {
            get
            {
                return _owner;
            }
        }

        public bool HasContract
        {
            get { return _HasContract; }
            set { _HasContract = value; }
        }

        public bool HasLongAbsence
        {
            get { return _HasLongAbsence; }
            set { _HasLongAbsence = value; }
        }

        public bool HasRelation
        {
            get { return _HasRelation; }
            set { _HasRelation = value; }
        }

        public long WorldId
        {
            get { return _RelationWorldId; }
            set { _RelationWorldId = value; }
        }
        public long StoreId
        {
            get { return _StoreId; }
            set { _StoreId = value; }
        }
        public decimal ContractHoursPerWeek
        {
            get { return _ContractHoursPerWeek; }
            set { _ContractHoursPerWeek = value; }
        }

        public int CountDailyWorkingHours
        {
            get { return _CountWorkingTime; }
            set { _CountWorkingTime = value; }
        }

        public int CountDailyPlannedWorkingHours
        {
            get { return _CountPlannedWorkingTime; }
            set { _CountPlannedWorkingTime = value; }
        }

        public int CountDailyAdditionalCharges
        {
            get { return _CountAdditionalCharges; }
            set { _CountAdditionalCharges = value; }
        }

        public int CountWeeklyAdditionalCharges
        {
            get { return PlanningWeek.CountWeeklyAdditionalCharges; }
        }
        public bool IsBlockedDay
        {
            get
            {
                return !HasRelation | !HasContract | HasLongAbsence;
            }
        }

        public List<WorkingTimePlanning> WorkingTimeList
        {
            get { return _WorkingTimeList; }
            set { _WorkingTimeList = value; }
        }

        public List<AbsenceTimePlanning> AbsenceTimeList
        {
            get { return _AbsenceTimeList; }
            set { _AbsenceTimeList = value; }
        }

        public List<EmployeePlanningWorkingModel> WorkingModels
        {
            get { return _WorkingModels; }
            set { _WorkingModels = value; }
        }
        #endregion

        #region Constructor

        public EmployeePlanningDay(EmployeePlanningWeek parent, /*Employee empl, */DateTime d)
        {
            _owner = parent;
            //_employee = empl;
            Date = d;
        }

        #endregion

        #region Methods


        public void Clear()
        {
            if (WorkingTimeList != null)
            {
                Modified |= WorkingTimeList.Count > 0;
                WorkingTimeList.Clear();
            }
            if (AbsenceTimeList != null)
            {
                Modified |= AbsenceTimeList.Count > 0;
                AbsenceTimeList.Clear();
            }
            CountDailyWorkingHours = 0;
            CountDailyPlannedWorkingHours = 0;
            CountDailyAdditionalCharges = 0;
            UnitPerDay = 0;
        }

        public int Calculate()
        {
            CountDailyWorkingHours = 0;
            CountDailyAdditionalCharges = 0;
            CountDailyPlannedWorkingHours = 0;
            UnitPerDay = 0;

            if (WorkingTimeList != null && WorkingTimeList.Count > 0)
            {
                int beginTime = 0, endTime = 0;
                foreach (WorkingTimePlanning wtp in WorkingTimeList)
                {
                    CountDailyWorkingHours += wtp.Time;
                    beginTime = wtp.Begin;
                    endTime = wtp.End;

                    beginTime = beginTime / 60; // we need hour
                    if (endTime % 60 != 0)
                    {
                        endTime = (endTime / 60) + 1;
                    }
                    else
                        endTime = (endTime / 60);
                    UnitPerDay += (endTime - beginTime);
                }
            }

            CountDailyPlannedWorkingHours = CountDailyWorkingHours;

            if (AbsenceTimeList != null && AbsenceTimeList.Count > 0)
            {
                foreach (AbsenceTimePlanning atp in AbsenceTimeList)
                    if (atp.Absence.UseInCalck) CountDailyPlannedWorkingHours += (atp.End - atp.Begin);// (atp.End - atp.Begin);
            }

            return CountDailyWorkingHours;
        }


        public void FillQuoters(int[] quoters)
        {
            if (WorkingTimeList != null)
            {
                foreach (WorkingTimePlanning wtp in WorkingTimeList)
                {
                    for (int i = wtp.Begin ; i < wtp.End; i+=15)
                    {
                        quoters[i / 60] += 15;
                    }
                }
            }
        }
        #endregion
    }
}
