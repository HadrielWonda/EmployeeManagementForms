using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Dao.QueryResult
{
    [Serializable]
    public class EmployeePlanningDay
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
        private long _RelationWorldId;

        private int _CountWorkingTime = 0;
        private int _CountPlannedWorkingTime = 0;
        private int _CountAdditionalCharges = 0;
        public long LongAbsenceId = 0;
        public bool Modified = false;
        #endregion

        #region properties

        /*public Employee EmployeePlanning
        {
            get { return _employee; }
            set { _employee = value; }
        }
        */
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

        public decimal ContractHoursPerWeek
        {
            get { return _ContractHoursPerWeek; }
            set { _ContractHoursPerWeek = value; }
        }

        public int CountDailyWorkingHours
        {
            get { return _CountWorkingTime; }
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
            _CountWorkingTime = 0;
            CountDailyPlannedWorkingHours = 0;
        }

        public int Calculate()
        {
            _CountWorkingTime = 0;

            if (WorkingTimeList != null && WorkingTimeList.Count > 0)
            {
                foreach (WorkingTimePlanning wtp in WorkingTimeList)
                    _CountWorkingTime += (wtp.End - wtp.Begin);
            }

            _CountPlannedWorkingTime = _CountWorkingTime;

            if (AbsenceTimeList != null && AbsenceTimeList.Count > 0)
            {
                foreach (AbsenceTimePlanning atp in AbsenceTimeList)
                    if (atp.Absence.UseInCalck )  _CountPlannedWorkingTime += (atp.End - atp.Begin);
            }

            return _CountWorkingTime;
        }

        #endregion
    }
}
