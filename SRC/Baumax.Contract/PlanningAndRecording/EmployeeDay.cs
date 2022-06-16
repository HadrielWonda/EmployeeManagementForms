using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.TimePlanning
{
    [Serializable]
    public sealed class EmployeeDay/*:BaseEntity*/
    {
        #region  fields

        private long _EmployeeId = 0;
        private DateTime _date;


        private long _StoreId = 0;
        private long _RelationWorldId = 0;
        // I think don't need this field=> id exists relation=> exists contract
        private bool _HasContract = false;
        
        private List<EmployeeTimeRange> _TimeList;
        [NonSerialized]
        private List<EmployeeWorkingModel> _WorkingModels = null;
        
        private int _CountWorkingTime = 0;
        private int _CountPlannedWorkingTime = 0;
        private int _CountAdditionalCharges = 0;
        private StoreDay _storeday = null;
        public long LongAbsenceId = 0;
        //[NonSerialized]
        //private int _CountUnitsPerDay = 0;
        [NonSerialized]
        public bool Modified = false;

        #endregion

        #region properties

        public long EmployeeId
        {
            get { return _EmployeeId; }
            set {_EmployeeId = value;}
        }


        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public StoreDay StoreDay
        {
            get { return _storeday; }
            set { _storeday = value; }
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
            get { return _RelationWorldId > 0; }
        }
        public long StoreId
        {
            get { return _StoreId; }
            set { _StoreId = value; }
        }
        public long StoreWorldId
        {
            get { return _RelationWorldId; }
            set { _RelationWorldId = value; }
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

        
        // need for cash desk world - every working or part hour as 1 units
        //(if 15 minute on hour = also 1 unit)
        //public int CountUnitsPerDay
        //{
        //    get { return _CountUnitsPerDay; }
        //    set { _CountUnitsPerDay = value; }
        //}

        public List<EmployeeTimeRange> TimeList
        {
            get { return _TimeList; }
            set { _TimeList = value; }
        }

        public List<EmployeeWorkingModel> WorkingModels
        {
            get { return _WorkingModels; }
            set { _WorkingModels = value; }
        }

        public bool IsValidDay
        {
            get
            {
                return HasContract && HasRelation && !HasLongAbsence;
            }
        }
        #endregion

        #region Constructor

        public EmployeeDay(long employeeid, DateTime d):this()
        {
            EmployeeId = employeeid;
            Date = d;
        }
        public EmployeeDay()
        {
            
        }
        public EmployeeDay(EmployeeDayStatePlanning entity):this()
        {
            EmployeeDayProcessor.AssignDay(entity, this);
        }
        public EmployeeDay(EmployeeDayStateRecording entity):this()
        {
            EmployeeDayProcessor.AssignDay(entity, this);
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
            CountDailyAdditionalCharges = 0;
        }

        public int Calculate()
        {
            CountDailyWorkingHours = 0;
            CountDailyPlannedWorkingHours = 0;
            CountDailyAdditionalCharges = 0;

            if (TimeList != null && TimeList.Count > 0)
            {
                EmployeeTimeRange timerange;
                for (int i = 0; i < TimeList.Count; i++)
                {
                    timerange = TimeList[i];
                    if (timerange.IsWorkingRange)
                    {
                        CountDailyWorkingHours += timerange.Time;
                        CountDailyPlannedWorkingHours += timerange.Time;
                    }
                    else
                    {
#if DEBUG
                        if (timerange.AbsenceID > 0 && timerange.Absence == null)
                            throw new ArgumentNullException();
#endif
                        if (timerange.Absence != null && timerange.Absence.UseInCalck)
                            CountDailyPlannedWorkingHours += timerange.End - timerange.Begin;
                    }
                }
            }

            return CountDailyWorkingHours;
        }

        public void FillQuoters(int[] quoters)
        {
            if (quoters == null || quoters.Length != 24)
                throw new ArgumentException();

            if (TimeList != null)
            {
                foreach (EmployeeTimeRange wtp in TimeList)
                {
                    wtp.FillQuotesHours(quoters);
                }
            }
        }

        #endregion
    }

    public class EmployeeDayProcessor
    {
        public static int GetUnits(short beginTime, short endTime)
        {
            int begin = beginTime / 60; // we need hour
            int end = endTime / 60;

            if (endTime % 60 != 0)
            {
                endTime++;
            }

            return (end - begin);
        }

        public static EmployeeDayStatePlanning CreatePlanningEntity(EmployeeDay day)
        {
            EmployeeDayStatePlanning entity = new EmployeeDayStatePlanning();
            return AssignToPlanning(entity, day);

        }
        public static EmployeeDayStatePlanning AssignToPlanning(EmployeeDayStatePlanning entity, EmployeeDay day)
        {
            //entity.ID = day.ID;
            entity.EmployeeID = day.EmployeeId;
            entity.Date = day.Date;
            entity.SumOfAddHours = day.CountDailyAdditionalCharges;
            entity.AllreadyPlannedHours = day.CountDailyPlannedWorkingHours;
            entity.WorkingHours = day.CountDailyWorkingHours;
            entity.StoreWorldId = day.StoreWorldId;
            return entity;
        }
        public static bool IsEqual(EmployeeDayStatePlanning entity, EmployeeDay day)
        {
            return (entity.EmployeeID == day.EmployeeId) &&
                (entity.Date == day.Date) &&
                (entity.SumOfAddHours == day.CountDailyAdditionalCharges) &&
                (entity.AllreadyPlannedHours == day.CountDailyPlannedWorkingHours) &&
                (entity.WorkingHours == day.CountDailyWorkingHours) &&
                (entity.StoreWorldId == day.StoreWorldId);
        }

        public static EmployeeDayStateRecording CreateRecordingEntity(EmployeeDay day)
        {
            EmployeeDayStateRecording entity = new EmployeeDayStateRecording();
            return AssignToRecording(entity, day);

        }
        public static EmployeeDayStateRecording AssignToRecording(EmployeeDayStateRecording entity, EmployeeDay day)
        {
            //entity.ID = day.ID;
            entity.EmployeeID = day.EmployeeId;
            entity.Date = day.Date;
            entity.SumOfAddHours = day.CountDailyAdditionalCharges;
            entity.AllreadyPlannedHours = day.CountDailyPlannedWorkingHours;
            entity.WorkingHours = day.CountDailyWorkingHours;
            entity.StoreWorldId = day.StoreWorldId;
            return entity;
        }
        public static bool IsEqual(EmployeeDayStateRecording entity, EmployeeDay day)
        {
            return (entity.EmployeeID == day.EmployeeId) &&
                (entity.Date == day.Date) &&
                (entity.SumOfAddHours == day.CountDailyAdditionalCharges) &&
                (entity.AllreadyPlannedHours == day.CountDailyPlannedWorkingHours) &&
                (entity.WorkingHours == day.CountDailyWorkingHours) &&
                (entity.StoreWorldId == day.StoreWorldId);
        }
        public static EmployeeDay CreateDay(EmployeeDayStatePlanning entity)
        {
            EmployeeDay day = new EmployeeDay();

            return AssignDay(entity, day);
        }
        public static EmployeeDay AssignDay(EmployeeDayStatePlanning entity, EmployeeDay day)
        {
            //day.ID = entity.ID;
            day.EmployeeId = entity.EmployeeID;
            day.Date = entity.Date;
            day.CountDailyAdditionalCharges = entity.SumOfAddHours;
            day.CountDailyPlannedWorkingHours = entity.AllreadyPlannedHours;
            day.CountDailyWorkingHours = entity.WorkingHours;
            day.StoreWorldId = entity.StoreWorldId;
            return day;
        }

        public static EmployeeDay CreateDay(EmployeeDayStateRecording entity)
        {
            EmployeeDay day = new EmployeeDay();
            return AssignDay(entity, day);
        }
        public static EmployeeDay AssignDay(EmployeeDayStateRecording entity, EmployeeDay day)
        {
            //day.ID = entity.ID;
            day.EmployeeId = entity.EmployeeID;
            day.Date = entity.Date;
            day.CountDailyAdditionalCharges = entity.SumOfAddHours;
            day.CountDailyPlannedWorkingHours = entity.AllreadyPlannedHours;
            day.CountDailyWorkingHours = entity.WorkingHours;
            day.StoreWorldId = entity.StoreWorldId;
            return day;
        }


        public static List<EmployeeDay> ConvertFrom(List<EmployeeDayStatePlanning> lst)
        {
            List<EmployeeDay> result = null;
            if (lst != null)
            {
                result = new List<EmployeeDay>();
                foreach (EmployeeDayStatePlanning entity in lst)
                    result.Add(CreateDay (entity));
            }

            return result;
        }
        public static List<EmployeeDay> ConvertFrom(List<EmployeeDayStateRecording> lst)
        {
            List<EmployeeDay> result = null;
            if (lst != null)
            {
                result = new List<EmployeeDay>();
                foreach (EmployeeDayStateRecording entity in lst)
                    result.Add(CreateDay(entity));
            }

            return result;
        }

        public static List<EmployeeDayStatePlanning> ConvertToPlanningList(List<EmployeeDay> lst)
        {
            List<EmployeeDayStatePlanning> result = null;
            if (lst != null)
            {
                result = new List<EmployeeDayStatePlanning>();
                foreach (EmployeeDay entity in lst)
                    result.Add(CreatePlanningEntity(entity));
            }

            return result;
        }
        public static List<EmployeeDayStateRecording> ConvertToRecoringList(List<EmployeeDay> lst)
        {
            List<EmployeeDayStateRecording> result = null;
            if (lst != null)
            {
                result = new List<EmployeeDayStateRecording>();
                foreach (EmployeeDay entity in lst)
                    result.Add(CreateRecordingEntity(entity));
            }

            return result;
        }


        public static bool IsNeedSave(EmployeeDay employeeday)
        {
            if (employeeday == null) return false;


            return employeeday.HasRelation & employeeday.HasContract & !employeeday.HasLongAbsence;
        }

    }
}
