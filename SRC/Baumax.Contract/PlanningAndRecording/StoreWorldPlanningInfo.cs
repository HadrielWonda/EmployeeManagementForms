using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Estimate;
using System.Diagnostics;

namespace Baumax.Contract.TimePlanning
{
    /*
     * Contain information about world of store by week
     */
    [Serializable ]
    public class WorldPlanningInfo
    {
        protected long _StoreWorldId;
        protected short _MinimumPresence = 0;
        protected short _MaximumPresence = 0;
        protected int _AvailableWorldBufferHours = 0;
        protected double _Benchmark = 0;
        protected decimal _TargetedNetPerformancePerHour = 0;
        //protected int _BufferHourStep = 0;
        [NonSerialized]
        protected int _CurrentBufferHours = 0;

        [NonSerialized]
        public int SumHoursForNetPerformance = 0;

        public WorldPlanningInfo()
        {
            
        }

        public bool ExistBufferHours
        {
            get { return _AvailableWorldBufferHours != Int32.MinValue; }
        }

        #region world database info

        public short MinimumPresence
        {
            get { return _MinimumPresence; }
            set { _MinimumPresence = value; }
        }

        public short MaximumPresence
        {
            get { return _MaximumPresence; }
            set { _MaximumPresence = value; }
        }

        public long StoreWorldId
        {
            get { return _StoreWorldId; }
            set { _StoreWorldId = value; }
        }

        public int AvailableWorldBufferHours
        {
            get { return _AvailableWorldBufferHours; }
            set { _AvailableWorldBufferHours = value; }
        }
        //public int BufferHourStep
        //{
        //    get { return _BufferHourStep; }
        //    set { _BufferHourStep = value; }
        //}
        public int CurrentBufferHours
        {
            get { return _CurrentBufferHours; }
            set { _CurrentBufferHours = value; }
        }

        public double Benchmark
        {
            get { return _Benchmark; }
            set { _Benchmark = value; }
        }

        public decimal TargetedNetPerformancePerHour
        {
            get { return _TargetedNetPerformancePerHour; }
            set { _TargetedNetPerformancePerHour = value; }
        }
        public virtual bool IsCashDesk
        {
            get { return false; }
        }
        #endregion
    }

    [Serializable]
    public sealed class StoreWorldPlanningInfo: WorldPlanningInfo
    {
        #region fields
        //private int[] _TargetedHours = new int[8];

        private IntArrayTP __targetedHours = new IntArrayTP (7);

        [NonSerialized ]
        private PercentArray __percentDifference = new PercentArray(7);

        [NonSerialized]
        private IntArrayTP __plannedHours = new IntArrayTP (7);

        #endregion

        #region properties

        public IntArrayTP TargetedHours
        {
            get
            {
                if (__targetedHours == null)
                    __targetedHours = new IntArrayTP(7);

                return __targetedHours;
            }
        }
        public IntArrayTP PlannedHours
        {
            get
            {
                if (__plannedHours == null)
                    __plannedHours = new IntArrayTP(7);

                return __plannedHours;
            }
        }
        public PercentArray Percents
        {
            get
            {
                if (__percentDifference == null)
                    __percentDifference = new PercentArray(7);

                return __percentDifference;
            }
        }

        #endregion

        public StoreWorldPlanningInfo()
        {
            TargetedHours.Clear();
        }

        public void Calculate(int[] inputHours)
        {
            if (inputHours == null || inputHours.Length < 7)
            {
                Debug.Assert(false);
                return;
            }

            for (int i = 0; i < 7; i++)
            {
                PlannedHours[i] = inputHours[i];
            }
            PlannedHours.Calculate ();

            Calculate();
        }

        public void Calculate(IntArrayTP inputHours)
        {
            if (inputHours == null || inputHours.Count != 7)
            {
                Debug.Assert(false);
                return;
            }

            for (int i = 0; i < 7; i++)
            {
                PlannedHours[i] = inputHours[i];
            }

            PlannedHours.Calculate();

            Calculate();
        }

        public void Calculate()
        {
            TargetedHours.Calculate();
            PlannedHours.Calculate();
            Percents.BuildPercent(TargetedHours, PlannedHours);

            if (ExistBufferHours)
                CurrentBufferHours = AvailableWorldBufferHours + (SumTargetedHours - SumPlannedHours);
            else
                CurrentBufferHours = 0;
        }

        public void SetTargetedHoursByDate(DateTime date, int hours)
        {
            TargetedHours[(int)date.DayOfWeek] = hours;
        }

        public void SetTargetedHours(int[] hours)
        {

            if (hours == null || hours.Length < 7)
            {
                Debug.Assert(false);
                return;
            }
            
            for (int i = 0; i < 7; i++)
            {
                TargetedHours[i] = hours[i];
                //_TargetedHours[i] = hours[i];
            }

            TargetedHours.Calculate();
        }
        public void SetTargetedHours(IntArrayTP hours)
        {

            if (hours == null || hours.Count != 7)
            {
                Debug.Assert(false);
                return;
            }

            for (int i = 0; i < 7; i++)
            {
                TargetedHours[i] = hours[i];
            }

            TargetedHours.Calculate();
        }
        #region properties of the results calculation

        public int SumTargetedHours
        {
            get { return TargetedHours.TotalSum; }
        }
        public int SumPlannedHours
        {
            get { return PlannedHours.TotalSum ; }
        }
        public double SumDifferencePercent
        {
            get { return Percents.AverageTotalSum; }
        }
        public double AbsSumDifferencePercent
        {
            get { return Percents.AbsAverageTotalSum; }
        }
        public double AbsSumDifferencePosPercent
        {
            get { return Percents.AvgPosTotalSum; }
        }
        public double AbsSumDifferenceNegPercent
        {
            get { return Percents.AvgNegTotalSum; }
        }

        #endregion 

        #region properties by day of week
        public int GetPlannedValue(DayOfWeek dw)
        {
            return PlannedHours[(int)dw];
        }

        public int GetTargetValue(DayOfWeek dw)
        {
            return TargetedHours[(int)dw];
        }
        public double GetDayPercent(DayOfWeek dw)
        {
            return Percents[(int)dw];
        }
        #endregion
    }


    [Serializable]
    public sealed class CashDeskPlanningInfo : WorldPlanningInfo
    {

        private short _CashDeskAmount = 35;

        List<DateCashDeskPeoplePerHour> _daycashdeskpeoples = new List<DateCashDeskPeoplePerHour>();
        [NonSerialized]
        Dictionary<DateTime, DateCashDeskPeoplePerHour> _diction = new Dictionary<DateTime, DateCashDeskPeoplePerHour>();

        private int _sum_planned_working_hours = 0;
        private int _sum_actual_working_hours = 0;

        public int SumPlannedWorkingHours
        {
            get { return _sum_planned_working_hours; }
            set 
            { 
                _sum_planned_working_hours = value;
                CalculateAvailableBuffer();
            }
        }
        

        public int SumActualWorkingHours
        {
            get { return _sum_actual_working_hours; }
            set { _sum_actual_working_hours = value; CalculateAvailableBuffer(); }
        }


        private void CalculateAvailableBuffer()
        {
            if (ExistBufferHours)
                CurrentBufferHours = AvailableWorldBufferHours - SumPlannedWorkingHours + SumActualWorkingHours;
        }
        
        public override bool IsCashDesk
        {
            get { return true; }
        }

        public void AddCashDeskItem(CashDeskPeoplePerHourEstimateShort item)
        {
            if (item == null)
            {
#if DEBUG
                throw new ArgumentNullException();
#else
                return;
#endif
            }

            DateCashDeskPeoplePerHour val = GetItem(item.Date, true);

            val.AddCashDeskPeoplePerHour(item);

        }

        //public void AddBusinessVolume(BusinessVolumeCRRSum item)
        //{
        //    if (item == null)
        //    {
        //        throw new ArgumentNullException();
        //    }

        //    DateCashDeskPeoplePerHour val = GetItem(item.Date, true);

        //    val.AddBusinessVolume (item);

        //}

        private DateCashDeskPeoplePerHour GetItem(DateTime date, bool bCreate)
        {
            DateCashDeskPeoplePerHour value = null;
            if (_diction == null)
                _diction = new Dictionary<DateTime, DateCashDeskPeoplePerHour>();

            if (!_diction.TryGetValue(date, out  value))
            {
                if (bCreate)
                {
                    value = new DateCashDeskPeoplePerHour(date);
                    _diction[date] = value;
                    _daycashdeskpeoples.Add(value);
                }
            }
            return value;
        }

        private void CreateDiction()
        {
            _diction = new Dictionary<DateTime, DateCashDeskPeoplePerHour>();
            if (_daycashdeskpeoples != null)
            {
                foreach (DateCashDeskPeoplePerHour item in _daycashdeskpeoples)
                {
                    _diction[item.Date] = item;
                }
            }
        }

        public DateCashDeskPeoplePerHour GetDayCashDeskData(DateTime date)
        {
            if ((_diction == null || _diction.Count == 0) && _daycashdeskpeoples.Count > 0)
            {
                CreateDiction();
            }

            return GetItem(date, false);
        }


        public short CashDeskAmount
        {
            get { return _CashDeskAmount; }
            set { _CashDeskAmount = value; }
        }

    }

}
