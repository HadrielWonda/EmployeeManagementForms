using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.TimePlanning
{

    public class EmployeeRecordingDay
    {
        #region  fields

        private long _EmployeeId = 0;
        private DateTime _date;
        private bool _HasContract = false;
        private bool _HasRelation = false;
        private int _ContractHoursPerWeek = 0;
        private List<EmployeeTimeRange> _TimeList;
        private List<EmployeeRecordingWorkingModel> _WorkingModels = null;
        private long _RelationWorldId;
        private string _FullName = String.Empty;

        private int _CountWorkingTime = 0;
        private int _CountPlannedWorkingTime = 0;
        private int _CountAdditionalCharges = 0;

        public long LongAbsenceId = 0;
        [NonSerialized]
        public bool Modified = false;

        #endregion

        #region properties

        public long EmployeeId
        {
            get { return _EmployeeId; }
            set {_EmployeeId = value;}
        }

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public bool HasContract
        {
            get { return _HasContract; }
            set { _HasContract = value; }
        }

        public bool HasLongAbsence
        {
            get { return LongAbsenceId > 0; }
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

        public int ContractHoursPerWeek
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
            get { return 0; }
        }


        public List<EmployeeTimeRange> TimeList
        {
            get { return _TimeList; }
            set { _TimeList = value; }
        }

        public List<EmployeeRecordingWorkingModel> WorkingModels
        {
            get { return _WorkingModels; }
            set { _WorkingModels = value; }
        }

        #endregion

        #region Constructor

        public EmployeeRecordingDay(long employeeid, DateTime d)
        {
            EmployeeId = employeeid;
            Date = d;
        }

        #endregion

        #region Methods


        public void Clear()
        {
            if (TimeList != null)
            {
                Modified |= TimeList.Count > 0;
                TimeList.Clear();
            }
            CountDailyWorkingHours = 0;
            CountDailyPlannedWorkingHours = 0;
        }

        public int Calculate()
        {
            CountDailyWorkingHours = 0;

            if (TimeList != null && TimeList.Count > 0)
            {
                EmployeeTimeRange timerange;
                for (int i = 0; i < TimeList.Count; i++)
                {
                    timerange = TimeList[i];
                    if (timerange.AbsenceID == 0)
                    {
                        CountDailyWorkingHours += timerange.Time;
                        CountDailyPlannedWorkingHours += timerange.Time;
                    }
                    else
                    {
                        if (timerange.Absence != null && timerange.Absence.UseInCalck)
                            CountDailyPlannedWorkingHours += timerange.Time;
                    }
                }
            }

            return CountDailyWorkingHours;
        }

        #endregion
    }
}
