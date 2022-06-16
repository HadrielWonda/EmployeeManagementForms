using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Absences;

namespace Baumax.Contract.TimePlanning
{
    [Serializable]
    public sealed class EmployeeTimeRange : /*BaseEntity, */IComparable<EmployeeTimeRange>, IEmployeeTimeRange
    {

        #region fields

        private long _EmployeeID;
        private short _Begin;
        private short _End;
        private long _AbsenceID;
        [NonSerialized]
        private Absence _Absence;
        private DateTime _Date;
        private short _Time;

        #endregion

        #region properties

        //public decimal Days
        //{
        //    get { return EmployeeCoefficientManager.GetRealDays(_Time); }
        //}
        public short Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public short Begin
        {
            get { return _Begin; }
            set { _Begin = value; }
        }

        public short End
        {
            get { return _End; }
            set { _End = value; }
        }

        public long EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        public long AbsenceID
        {
            get { return _AbsenceID; }
            set { _AbsenceID = value; }
        }

        public Absence Absence
        {
            get { return _Absence; }
            set { _Absence = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public bool IsWorkingRange
        {
            get { return AbsenceID <= 0 ;}
        }

        #endregion

        
        public void FillQuotesHours(int[] quotes)
        {
            if (!IsWorkingRange) return;

            if (quotes == null || quotes.Length != 24)
                throw new ArgumentException();

            for (int i = Begin ; i < End; i+=15)
            {
                quotes[i / 60] += 15;
            }
        }
        public int CompareTo(EmployeeTimeRange entity)
        {

            int i = EmployeeID.CompareTo(entity.EmployeeID);
            if (i == 0)
            {
                if ((i = Date.CompareTo(entity.Date)) == 0)
                    return Begin - entity.Begin;
                else return i;
            }
            else
                return i;
        }

        public void Assign(IEmployeeTimeRange entity)
        {
            EmployeeID = entity.EmployeeID;
            Begin= entity.Begin;
            End = entity.End;
            AbsenceID = entity.AbsenceID ;
            Absence = entity.Absence ;
            Date = entity.Date;
            Time = entity.Time;
        }

        public void AssignTo(IEmployeeTimeRange entity)
        {
            entity.EmployeeID = EmployeeID;
            entity.Begin = Begin;
            entity.End = End;
            entity.AbsenceID = AbsenceID;
            entity.Absence = Absence;
            entity.Date = Date;
            entity.Time = Time;
        }

        public EmployeeTimeRange()
        {

        }
        public EmployeeTimeRange(IEmployeeTimeRange entity)
        {
            Assign(entity);
        }

        public override string ToString()
        {
            if (IsWorkingRange)
                return TextParser.TimeRangeToString(Begin, End);
            else 
                return TextParser.AbsenceTimeRangeToString(Begin, End, Absence != null ?Absence.CharID : String.Empty );
        }
    }




    public static class EmployeeTimeRangeHelper
    {
        public static bool CompareTwoList(List<EmployeeTimeRange> leftList, List<EmployeeTimeRange> rightList)
        {
            if (leftList == null && rightList == null) return true;
            if (leftList == null && rightList != null) return false;
            if (leftList != null && rightList == null) return false;

            if (leftList.Count != rightList.Count) return false;

            for (int i = 0; i < leftList.Count; i++)
            {
                if (!IsEqual(leftList[i], rightList[i])) return false;
            }
            return true;
        }

        public static bool IsEqual(EmployeeTimeRange left, EmployeeTimeRange right)
        {
            if (left == null)
                throw new ArgumentNullException();
            if (right == null)
                throw new ArgumentNullException();

            return (left.EmployeeID == right.EmployeeID) &&
                (left.Date == right.Date) &&
                (left.AbsenceID == right.AbsenceID) &&
                (left.Begin == right.Begin) &&
                (left.End == right.End);
        }

        public static void GetWorkingAndAbsenceTimeRange(List<EmployeeTimeRange> lst, List<EmployeeTimeRange> lstWork, List<EmployeeTimeRange> lstAbsences)
        {
            if (lstWork == null)
                throw new ArgumentNullException();
            if (lstAbsences == null) 
                throw new ArgumentNullException();

            if (lst != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].AbsenceID <= 0)
                        lstWork.Add(lst[i]);
                    else
                        lstAbsences.Add(lst[i]);
                }
            }
        }

        public static List<EmployeeTimeRange> GetTimeRanges(List<WorkingTimePlanning> worksList, List<AbsenceTimePlanning> absenceList)
        {
            List<EmployeeTimeRange> result = new List<EmployeeTimeRange>();
            if (worksList != null && worksList.Count > 0)
            {
                foreach (WorkingTimePlanning entity in worksList)
                {
                    result.Add(new EmployeeTimeRange(entity));
                }
            }
            if (absenceList != null && absenceList.Count > 0)
            {
                foreach (AbsenceTimePlanning entity in absenceList)
                {
                    result.Add(new EmployeeTimeRange(entity));
                }
            }

            result.Sort();

            return result;
        }

        public static List<EmployeeTimeRange> GetTimeRanges(List<WorkingTimeRecording> worksList, List<AbsenceTimeRecording> absenceList)
        {
            List<EmployeeTimeRange> result = new List<EmployeeTimeRange>();
            if (worksList != null && worksList.Count > 0)
            {
                foreach (WorkingTimeRecording entity in worksList)
                {
                    result.Add(new EmployeeTimeRange(entity));
                }
            }
            if (absenceList != null && absenceList.Count > 0)
            {
                foreach (AbsenceTimeRecording entity in absenceList)
                {
                    result.Add(new EmployeeTimeRange(entity));
                }
            }

            result.Sort();

            return result;
        }

        public static void FillEmployeeWeeks(List<EmployeeWeek> lstWeeks, List<WorkingTimePlanning> worksList, List<AbsenceTimePlanning> absenceList)
        {
            List<EmployeeTimeRange> ranges = GetTimeRanges(worksList, absenceList);

            if (ranges.Count > 0 && lstWeeks != null && lstWeeks.Count > 0)
            {
                foreach (EmployeeTimeRange range in ranges)
                {
                    foreach (EmployeeWeek week in lstWeeks)
                    {
                        if (range.EmployeeID == week.EmployeeId)
                        {
                            if (DateTimeHelper.Between(range.Date, week.BeginDate, week.EndDate))
                            {
                                EmployeeDay day = week.GetDay(range.Date);

                                if (day.TimeList == null)
                                    day.TimeList = new List<EmployeeTimeRange>();

                                day.TimeList.Add(range);
                            }
                        }
                    }
                }
            }

        }
        public static void FillEmployeeWeeks(List<EmployeeWeek> lstWeeks, List<WorkingTimeRecording> worksList, List<AbsenceTimeRecording> absenceList)
        {
            List<EmployeeTimeRange> ranges = GetTimeRanges(worksList, absenceList);

            if (ranges.Count > 0 && lstWeeks != null && lstWeeks.Count > 0)
            {
                foreach (EmployeeTimeRange range in ranges)
                {
                    foreach (EmployeeWeek week in lstWeeks)
                    {
                        if (range.EmployeeID == week.EmployeeId)
                        {
                            if (DateTimeHelper.Between(range.Date, week.BeginDate, week.EndDate))
                            {
                                EmployeeDay day = week.GetDay(range.Date);

                                if (day.TimeList == null)
                                    day.TimeList = new List<EmployeeTimeRange>();

                                day.TimeList.Add(range);
                            }
                        }
                    }
                }
            }

        }


        public static bool InsertTimeRange(EmployeePlanningDay day, AbsenceTimePlanning newrange)
        {

            List<IEmployeeTimeRange> ranges = new List<IEmployeeTimeRange>();

            if (day.WorkingTimeList != null)
            {
                foreach (WorkingTimePlanning r in day.WorkingTimeList)
                    ranges.Add(r);
            }

            if (day.AbsenceTimeList != null)
            {
                foreach (AbsenceTimePlanning r in day.AbsenceTimeList)
                    ranges.Add(r);
            }
            ranges.Sort();
            // if newrange is part of exists range - return
            foreach (IEmployeeTimeRange range in ranges)
            {
                if (range.AbsenceID == newrange.AbsenceID && range.Begin <= newrange.Begin && newrange.End <= range.End ) return false;
            }
            //ranges.Add(newrange);
            ranges.Sort();

            
            foreach (IEmployeeTimeRange range in ranges)
            {
                if (newrange.Begin <= range.Begin && range.End <= newrange.End)
                {
                    range.Begin = range.End;
                }
                else if (range.Begin <= newrange.Begin && newrange.Begin <= range.End)
                {
                    range.End = (short)(newrange.Begin - 1);
                }
                else if (range.Begin <= newrange.End && newrange.End <= range.End)
                {
                    range.Begin = (short)(newrange.End + 1);
                }
            }
            if (day.AbsenceTimeList == null)
                day.AbsenceTimeList = new List<AbsenceTimePlanning>(1);
            if (day.AbsenceTimeList != null)
            {
                day.AbsenceTimeList.Add(newrange);
            }
            for (int i = day.AbsenceTimeList.Count - 1; i >= 0; i--)
            {
                if (day.AbsenceTimeList[i].Begin >= day.AbsenceTimeList[i].End) day.AbsenceTimeList.RemoveAt(i);
            }
            if (day.WorkingTimeList != null)
            {
                for (int i = day.WorkingTimeList.Count - 1; i >= 0; i--)
                {
                    if (day.WorkingTimeList[i].Begin >= day.WorkingTimeList[i].End) day.WorkingTimeList.RemoveAt(i);
                }
            }
            for (int i = day.AbsenceTimeList.Count - 1; i >= 1; i--)
            {
                if (day.AbsenceTimeList[i].AbsenceID == day.AbsenceTimeList[i - 1].AbsenceID &&
                    day.AbsenceTimeList[i].Begin - 1 == day.AbsenceTimeList[i - 1].End)
                {
                    day.AbsenceTimeList[i - 1].End = day.AbsenceTimeList[i].End;
                    day.AbsenceTimeList.RemoveAt(i);
                }
            }
            return true;
        }
        public static bool InsertTimeRange(EmployeeDay day, EmployeeTimeRange newrange)
        {

            List<IEmployeeTimeRange> ranges = new List<IEmployeeTimeRange>();

            if (day.TimeList != null)
            {
                foreach (EmployeeTimeRange r in day.TimeList)
                    ranges.Add(r);
            }
            ranges.Sort();
            // if newrange is part of exists range - return
            foreach (IEmployeeTimeRange range in ranges)
            {
                if (range.AbsenceID == newrange.AbsenceID && range.Begin <= newrange.Begin && newrange.End <= range.End) return false;
            }
            //ranges.Add(newrange);
            ranges.Sort();


            foreach (IEmployeeTimeRange range in ranges)
            {
                if (DateTimeHelper.IsIntersectInc(range.Begin, range.End, newrange.Begin, newrange.End))
                {
                    // if old range part of new range - mark as delete
                    if (newrange.Begin <= range.Begin && range.End <= newrange.End)
                    {
                        range.Begin = range.End;
                    }
                    else if (range.Begin <= newrange.Begin && newrange.Begin <= range.End)
                    {
                        range.End = (short)(newrange.Begin - 1);
                    }
                    else if (range.Begin <= newrange.End && newrange.End <= range.End)
                    {
                        range.Begin = (short)(newrange.End + 1);
                    }
                }
            }
            if (day.TimeList == null)
                day.TimeList = new List<EmployeeTimeRange>(1);
            if (day.TimeList != null)
            {
                day.TimeList.Add(newrange);
            }

            day.TimeList.Sort();
            for (int i = day.TimeList.Count - 1; i >= 0; i--)
            {
                if (day.TimeList[i].Begin >= day.TimeList[i].End) day.TimeList.RemoveAt(i);
            }

            for (int i = day.TimeList.Count - 1; i >= 1; i--)
            {
                if (day.TimeList[i].AbsenceID == day.TimeList[i - 1].AbsenceID &&
                    day.TimeList[i].Begin - 1 == day.TimeList[i - 1].End)
                {
                    day.TimeList[i - 1].End = day.TimeList[i].End;
                    day.TimeList.RemoveAt(i);
                }
            }
            return true;
        }
    }
}
