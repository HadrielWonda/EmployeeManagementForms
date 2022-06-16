using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects
{
    public class WeekPair :IComparable <WeekPair>
    {
        private DateTime _Date;
        private EmployeeWeekTimeRecording _RecordingWeek = null;
        private EmployeeWeekTimePlanning _PlanningWeek = null;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        
        public EmployeeWeekTimeRecording RecordingWeek
        {
            get { return _RecordingWeek; }
            set { _RecordingWeek = value; }
        }
        
        public EmployeeWeekTimePlanning PlanningWeek
        {
            get { return _PlanningWeek; }
            set { _PlanningWeek = value; }
        }
        public WeekPair(DateTime date)
        {
            Date = date;
        }
        public WeekPair(DateTime date, EmployeeWeekTimeRecording week)
            : this(date)
        {
            RecordingWeek = week;
        }
        public WeekPair(DateTime date, EmployeeWeekTimePlanning week)
            : this(date)
        {
            PlanningWeek = week;
        }
        public int Saldo
        {
            get
            {
                if (RecordingWeek != null)
                    return RecordingWeek.Saldo;

                if (PlanningWeek != null)
                    return PlanningWeek.Saldo;
                throw new ArgumentException();
            }
        }
        public int CompareTo(WeekPair p)
        {
            if (p == null)
                throw new ArgumentNullException();

            return Date.CompareTo(p.Date);
        }
        
        public static List<WeekPair> BuildListOfWeekPairs(List<EmployeeWeekTimeRecording> recs, List<EmployeeWeekTimePlanning> plans)
        {
            Dictionary<DateTime, WeekPair> dict = new Dictionary<DateTime, WeekPair>(10);
            if (recs != null)
            {
                foreach (EmployeeWeekTimeRecording rec_week in recs)
                {
                    dict[rec_week.WeekBegin] = new WeekPair(rec_week.WeekBegin, rec_week);
                }
            }
            if (plans != null)
            {
                foreach (EmployeeWeekTimePlanning week in plans)
                {
                    if (!dict.ContainsKey(week.WeekBegin))
                    {
                       
                        dict[week.WeekBegin] = new WeekPair(week.WeekBegin, week);
                    }
                    else
                    {
                        dict[week.WeekBegin].PlanningWeek = week;
                    }
                }
            }
            List<WeekPair> resultList = null;
            if (dict.Count > 0)
            {
                resultList = new List<WeekPair>(dict.Values);
                resultList.Sort();
            }
            
            return resultList;
        }

        public static List<WeekPair> AddWeeks(List<WeekPair> weekpairs, List<EmployeeWeekTimeRecording> recs)
        {
            if (recs != null && weekpairs != null)
            {
                List<WeekPair> newpairs = new List<WeekPair>();
                List<DateTime> dates = new List<DateTime>(weekpairs .Count);
                for (int i = 0; i < weekpairs.Count; i++)
                {
                    dates.Add (weekpairs[i].Date);
                }
               
                dates.Sort ();
                int index = 0;
                foreach (EmployeeWeekTimeRecording rec_week in recs)
                {
                    index = dates.BinarySearch(rec_week.WeekBegin);
                    if (index >= 0)
                    {
                        weekpairs[index].RecordingWeek = rec_week;
                    }
                    else
                    {
                        newpairs.Add(new WeekPair(rec_week.WeekBegin, rec_week));
                    }
                }
                weekpairs.AddRange(newpairs );
                weekpairs.Sort ();
            }
            return weekpairs ;
        }
        public static List<WeekPair> AddWeeks(List<WeekPair> weekpairs, List<EmployeeWeekTimePlanning> recs)
        {
            if (recs != null && weekpairs != null)
            {
                List<WeekPair> newpairs = new List<WeekPair>();
                List<DateTime> dates = new List<DateTime>(weekpairs .Count);
                for (int i = 0; i < weekpairs.Count; i++)
                {
                    dates.Add (weekpairs[i].Date);
                }
               
                dates.Sort ();
                int index = 0;
                foreach (EmployeeWeekTimePlanning week in recs)
                {
                    index = dates.BinarySearch(week.WeekBegin);
                    if (index >= 0)
                    {
                        weekpairs[index].PlanningWeek = week;
                    }
                    else
                    {

                        newpairs.Add(new WeekPair(week.WeekBegin, week));
                    }
                }
                weekpairs.AddRange(newpairs);
                weekpairs.Sort ();
            }
            return weekpairs ;
        }
    }
}
