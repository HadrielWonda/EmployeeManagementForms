using System;
using System.Collections.Generic;
using System.Text;
using Baumax.AppServer.Environment;
using System.Collections;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Contract;
using System.Diagnostics;
namespace Baumax.Services._HelperObjects
{
    public class EstimatedWorldHoursBuilder
    {
        private TrendCorrectionHelper trendhelper = null;
        protected int ConvertToMinutes(decimal value)
        {
            return Convert.ToInt32(Math.Round(value * 60));
        }

        public int Build(StoreToWorld storeworld,DateTime beginWeek, DateTime endWeek)
        {
            return Build(storeworld.StoreID, storeworld.WorldID, storeworld.ID, beginWeek, endWeek);
        }
        public int Build(long storeid, long worldid, long storeworldid, DateTime beginWeek, DateTime endWeek)
        {
            int result = 0;

            IList lst = ServerEnvironment.StoreToWorldService.GetEstimatedWorldWorkingHours(beginWeek, endWeek, storeid, worldid);

            if (lst != null)
            {
                if (trendhelper == null)
                {
                    trendhelper = new TrendCorrectionHelper(ServerEnvironment.TrendCorrectionService);

                    trendhelper.LoadByStoreAndDateRange(storeid, beginWeek, endWeek);
                }
                bool isExistsTrendCorrection = trendhelper.IsExistsForWorld(storeworldid);

                decimal trendcorrection = 1;

                foreach (EstimatedWorldWorkingHours workinghours in lst)
                {
                    if (isExistsTrendCorrection)
                    {
                        trendcorrection = Convert.ToDecimal(trendhelper.GetTrendCorrection(storeworldid, workinghours.Date));

                        result += ConvertToMinutes(workinghours.WorkingHours * trendcorrection);
                    }
                    else
                        result += ConvertToMinutes(workinghours.WorkingHours);
                }
            }
            return result;
        }


        //public int[] Build(StoreToWorld storeworld, int year)
        //{
        //    return Build(storeworld.StoreID, storeworld.WorldID, storeworld.ID, year);
        //}
        //public int[] Build(long storeid, long worldid, long storeworldid, int year)
        //{
        //    //EstimatedHours.Clear();
        //    //EstimatedHours.Capacity = 370;
        //    int result = 0;
        //    //TotalSum = 0;
        //    DateTime begin = DateTimeHelper.GetBeginYearDate(year);
        //    DateTime end = DateTimeHelper.GetEndYearDate(year);
        //    int count_weeks = DateTimeHelper.GetCountWeekInYear(year);

        //    int[] sums = new int[count_weeks];
        //    for (int i = 0; i < count_weeks; i++)
        //    {
        //        sums[i] = 0;   
        //    }
        //    IList lst = ServerEnvironment.StoreToWorldService.GetEstimatedWorldWorkingHours(begin, end, storeid, worldid);

        //    if (lst != null)
        //    {
                
        //        trendhelper = new TrendCorrectionHelper(ServerEnvironment.TrendCorrectionService);

        //        trendhelper.LoadByStoreAndDateRange(storeid, begin, end);

        //        bool isExistsTrendCorrection = trendhelper.IsExistsForWorld(storeworldid);

        //        decimal trendcorrection = 1;

        //        foreach (EstimatedWorldWorkingHours workinghours in lst)
        //        {
        //            result = 0;
        //            //EstimatedHours.Add(workinghours);

        //            if (isExistsTrendCorrection)
        //            {
        //                trendcorrection = Convert.ToDecimal(trendhelper.GetTrendCorrection(storeworldid, workinghours.Date));

        //                result = ConvertToMinutes(workinghours.WorkingHours * trendcorrection);
        //                    //(int)(workinghours.WorkingHours * 60 * trendcorrection);
        //            }
        //            else
        //                result = ConvertToMinutes(workinghours.WorkingHours);
        //                    //(int)(workinghours.WorkingHours * 60);

        //            sums[DateTimeHelper.GetWeekNumber(workinghours.Date)-1] += result;
        //        }
        //    }
        //    return sums;
        //}


        
//        public bool TestAndCompare(StoreToWorld storeworld, int year)
//        {
//            bool equal = true;

//#if DEBUG
//            DateTime begin = DateTimeHelper.GetBeginYearDate(year);
//            DateTime end = DateTimeHelper.GetEndYearDate(year);
//            int count_weeks = DateTimeHelper.GetCountWeekInYear(year);

//            int[] sums = new int[count_weeks];

//            long ll = DateTime.Now.Ticks;
//            Debug.WriteLine("Begin 1:" +  ll); 
//            DateTime date = begin;
//            for (int i = 0; i < count_weeks; i++)
//            {
//                sums[i] = Build(storeworld, date, DateTimeHelper.GetSunday (date));

//                date = DateTimeHelper.GetNextMonday(date);
//            }
//            long ll2 = DateTime.Now.Ticks;
//            Debug.WriteLine("End 1:" + ll2 +  "  Time: " + Convert.ToString (ll2-ll));

//            ll = DateTime.Now.Ticks;
//            Debug.WriteLine("Begin 2:" + ll); 

//            int[] sums2 = Build(storeworld, year);

//            ll2 = DateTime.Now.Ticks;
//            Debug.WriteLine("End 2:" + ll2 + "  Time: " + Convert.ToString(ll2 - ll));

//            for (int i = 0; i < count_weeks; i++)
//            {
//                Debug.WriteLine(sums[i].ToString() + " ----------------- " + sums2[i]);

//                equal &= sums[i] == sums2[i];
//            }


            
//#endif
//            return equal;
//        }
    }

    public class EstimatedWorldHoursBuilder2
    {
        private TrendCorrectionHelper _trendhelper = null;
        private int _TotalSum = 0;
        private List<EstimatedWorldWorkingHours> _estimatedHours = new List<EstimatedWorldWorkingHours>(10);
        protected DateTime _begin;
        protected DateTime _end;
        protected long _storeid = 0;
        protected long _worldid = 0;
        protected long _storeworldid = 0;

        public List<EstimatedWorldWorkingHours> EstimatedHours
        {
            get { return _estimatedHours; }
        }
        public int TotalSum
        {
            get { return _TotalSum; }
            protected set { _TotalSum = value; }
        }
        protected int ConvertToMinutes(decimal value)
        {
            return Convert.ToInt32(Math.Round(value * 60));
        }

        protected virtual TrendCorrectionHelper GetTrendHelper()
        {
            if (_trendhelper == null)
            {
                _trendhelper = new TrendCorrectionHelper(ServerEnvironment.TrendCorrectionService);
                _trendhelper.LoadByStoreAndDateRange(_storeid, _begin, _end);
            }
            return _trendhelper;
        }
        protected virtual void ProcessValue(DateTime date, int value)
        {
            TotalSum += value;
        }

        protected virtual void Process()
        {
            EstimatedHours.Clear();
            EstimatedHours.Capacity = 370;
            TotalSum = 0;
            IList lst = ServerEnvironment.StoreToWorldService.GetEstimatedWorldWorkingHours(_begin, _end, _storeid, _worldid);
            if (lst != null)
            {
                TrendCorrectionHelper trendhelper = GetTrendHelper();
                bool isExistsTrendCorrection = trendhelper.IsExistsForWorld(_storeworldid);

                decimal trendcorrection = 1;

                int value = 0;
                foreach (EstimatedWorldWorkingHours workinghours in lst)
                {
                    EstimatedHours.Add(workinghours);

                    if (isExistsTrendCorrection)
                    {
                        trendcorrection = Convert.ToDecimal(trendhelper.GetTrendCorrection(_storeworldid, workinghours.Date));

                        value = ConvertToMinutes(workinghours.WorkingHours * trendcorrection);
                    }
                    else
                        value = ConvertToMinutes(workinghours.WorkingHours);

                    ProcessValue(workinghours.Date, value);
                }
            }
        }

        public void AssignTrendCorrecttionHelper(TrendCorrectionHelper trends)
        {
            _trendhelper = trends;
        }
        public virtual int Build(StoreToWorld storeworld, DateTime beginWeek, DateTime endWeek)
        {
            return Build(storeworld.StoreID, storeworld.WorldID, storeworld.ID, beginWeek, endWeek);
        }
        public virtual int Build(long storeid, long worldid, long storeworldid, DateTime beginWeek, DateTime endWeek)
        {
            if (_storeid != 0 && (_storeid != storeid || beginWeek != _begin || endWeek != _end))
                _trendhelper = null;

            _storeid = storeid;
            _worldid = worldid;
            _storeworldid = storeworldid;
            _begin = beginWeek;
            _end = endWeek;

            Process();

            return TotalSum;

        }
    }

    public class WeeklyEstimatedWorldHoursBuilder:EstimatedWorldHoursBuilder2
    {
        int[] _days = new int[7];
        protected override void ProcessValue(DateTime date, int value)
        {
            base.ProcessValue(date, value);
            _days[(int)date.DayOfWeek] = value;
        }
        public int[] BuildWeek(StoreToWorld storeworld, DateTime monday)
        {
            return BuildWeek(storeworld.StoreID, storeworld.WorldID, storeworld.ID, monday);
        }
        public int[] BuildWeek(long storeid, long worldid, long storeworldid, DateTime monday)
        {
            Debug.Assert(monday.DayOfWeek == DayOfWeek.Monday);
            Build(storeid, worldid, storeworldid, monday, DateTimeHelper.GetSunday(monday));
            return _days;
        }

    }

    public class YearlyEstimatedWorldHoursBuilder : EstimatedWorldHoursBuilder2
    {
        private List<int> _weeks_sum = new List<int>(55);
        private int _count_weeks = 52;
        private int _year = DateTime.Today.Year;
 
        protected override void ProcessValue(DateTime date, int value)
        {
            base.ProcessValue(date, value);
            _weeks_sum[DateTimeHelper.GetWeekNumber(date) - 1] += value;
        }


        public int[] BuildYear(StoreToWorld storeworld, int year)
        {
            return BuildYear(storeworld.StoreID, storeworld.WorldID, storeworld.ID, year);
        }

        public int[] BuildYear(long storeid, long worldid, long storeworldid, int year)
        {
            _year = year;
            _count_weeks = DateTimeHelper.GetCountWeekInYear(year);
            _weeks_sum.Capacity = _count_weeks;
            _weeks_sum.Clear();
            for (int i = 0; i < _count_weeks; i++)
            {
                _weeks_sum.Add (0);
            }

            Build(storeid, worldid, storeworldid, DateTimeHelper.GetBeginYearDate(year), DateTimeHelper.GetEndYearDate(year));

            return _weeks_sum.ToArray ();
        }



        public bool TestAndCompare2(StoreToWorld storeworld, int year)
        {
            bool equal = true;

#if DEBUG
            DateTime begin = DateTimeHelper.GetBeginYearDate(year);
            DateTime end = DateTimeHelper.GetEndYearDate(year);
            int count_weeks = DateTimeHelper.GetCountWeekInYear(year);

            int[] sums = new int[count_weeks];
            int[] sums2 = new int[count_weeks];

            DateTime date = begin;

            EstimatedWorldHoursBuilder b = new EstimatedWorldHoursBuilder();
            EstimatedWorldHoursBuilder2 b2 = new EstimatedWorldHoursBuilder2();
            for (int i = 0; i < count_weeks; i++)
            {
                sums[i] = b.Build(storeworld, date, DateTimeHelper.GetSunday(date));
                sums2[i] = b2.Build(storeworld, date, DateTimeHelper.GetSunday(date));

                date = DateTimeHelper.GetNextMonday(date);
            }
            int[] sums3 = BuildYear(storeworld, year);

            for (int i = 0; i < count_weeks; i++)
            {
                Debug.WriteLine(sums[i].ToString() + " ----------------- " + sums2[i] + " ----- " + sums[i]);

                Debug.Assert(sums[i] == sums2[i]);
                Debug.Assert(sums[i] == sums3[i]);
                Debug.Assert(sums2[i] == sums3[i]);
                equal &= (sums[i] == sums2[i]) & (sums2[i] == sums3 [i]);
            }


#endif
            return equal;
        }
    }
}
