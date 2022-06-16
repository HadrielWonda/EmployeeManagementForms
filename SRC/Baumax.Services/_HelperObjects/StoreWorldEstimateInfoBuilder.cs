using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Contract.Exceptions.EntityExceptions;
using System.Collections;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Estimate;
using Baumax.Services._HelperObjects.ExEntity;
using System.Diagnostics;

namespace Baumax.Services._HelperObjects
{
    class StoreWorldEstimateInfoBuilder
    {
        private StoreService _storeservice = null;
        private PersonMinMaxService _personminmaxservice = null;
        private StoreToWorldService _storetoworldservice = null;
        private BufferHoursService _bufferhoursservice = null;
        private BenchmarkService _benchmarkservice = null;
        private AvgAmountService _avgamountservice = null;


        private List<StoreToWorld> _listStoreToWorld = null;
        private long _storeid = 0;
        private long _countryid = 0;
        private TrendCorrectionHelper _trendhelper = null;
        private DateTime _monday = DateTimeSql.FirstMinMonday;
        private int _year = DateTime.Today.Year;


        public StoreWorldEstimateInfoBuilder(IStoreService storeservice,
                                             IStoreToWorldService storeworldservice
                                            )
        {

            if (storeservice == null)
            {
                throw new ArgumentNullException();
            }

            if (storeworldservice == null)
            {
                throw new ArgumentNullException();
            }

            _storeservice = (StoreService)storeservice;
            _storetoworldservice = (StoreToWorldService)storeworldservice;

            _personminmaxservice = (PersonMinMaxService)_storetoworldservice.PersonMinMaxService;
            _bufferhoursservice = (BufferHoursService)_storetoworldservice.BufferHoursService;
            _benchmarkservice = (BenchmarkService)_storeservice.BenchmarkService;
            _avgamountservice = (AvgAmountService)_storetoworldservice.AvgAmountService;
        }
        private bool _IsPlanning = true;

        public bool IsPlanning
        {
            get { return _IsPlanning; }
            set { _IsPlanning = value; }
        }
        public DateTime Monday
        {
            get { return _monday; }
        }

        public int Year
        {
            get { return _year; }
        }

        public long StoreId
        {
            get { return _storeid; }
            private set
            {
                if (_storeid != value)
                {
                    _storeid = value;
                    _listStoreToWorld = ExStoreToWorld.List(_storeid);
                    _trendhelper = null;
                    if (_storeid > 0)
                        _countryid = _storeservice.GetCountryByStoreId(_storeid);
                    else
                        _countryid = 0;
                }
            }
        }
        public long CountryId
        {
            get { return _countryid; }
        }

        public List<WorldPlanningInfo> GetAllWorldInfo(long storeid, DateTime beginWeekDate)
        {

            if (storeid <= 0)
            {
                throw new ArgumentException();
            }

            //if (!DateTimeHelper.IsHitInInterval(beginWeekDate, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax))
            //{
            //    throw new ArgumentException();
            //}
            StoreId = storeid;
            _monday = DateTimeHelper.GetMonday(beginWeekDate);
            _year = DateTimeHelper.GetYearByDate(Monday);

            List<WorldPlanningInfo> resultList = new List<WorldPlanningInfo>();

            if (_listStoreToWorld != null)
            {
                foreach (StoreToWorld world in _listStoreToWorld)
                {
                    resultList.Add(GetWorldInfo(world, beginWeekDate));
                }
            }

            return resultList;
        }

        public WorldPlanningInfo GetWorldInfo(StoreToWorld storeworld, DateTime beginWeekDate)
        {

            Debug.Assert(beginWeekDate.DayOfWeek == DayOfWeek.Monday);

            if (storeworld == null)
            {
                throw new ArgumentException();
            }

            StoreId = storeworld.StoreID;

            if (storeworld.WorldTypeID == WorldType.CashDesk)
            {
                return GetCashDeskInfo(storeworld, beginWeekDate);
            }
            else
            {
                DateTime endWeekDate = DateTimeHelper.GetSunday(beginWeekDate);
                StoreWorldPlanningInfo worldinfo = new StoreWorldPlanningInfo();
                worldinfo.StoreWorldId = storeworld.ID;
                FillCommonInfoForWorld(worldinfo, storeworld, beginWeekDate, endWeekDate);
                
                IList listSums = _storetoworldservice.GetBusinessVolumes(IsPlanning, beginWeekDate, endWeekDate, storeworld.StoreID, storeworld.WorldID);
                if (listSums != null && listSums.Count == 1)
                {
                    BusinessVolumeTargActSum targsum = listSums[0] as BusinessVolumeTargActSum;
                    if (targsum != null)
                        worldinfo.TargetedNetPerformancePerHour = targsum.VolumeBC;
                }

                // for recording don't need load estimated (targeted hours)
                // will be used hours from planning
                if (IsPlanning)
                {
                    FillStoreWorldEstimateData(worldinfo, storeworld, beginWeekDate, endWeekDate);
                }

                return worldinfo;
            }


        }
        private void FillStoreWorldEstimateData(StoreWorldPlanningInfo worldinfo, StoreToWorld storeworld, DateTime begin, DateTime end)
        {
            //IList lst = _storetoworldservice.GetEstimatedWorldWorkingHours(begin, end, storeworld.StoreID, storeworld.WorldID);

            //if (lst != null)
            //{
            //    if (_trendhelper == null)
            //    {
            //        _trendhelper = new TrendCorrectionHelper(_storeservice.TrendCorrectionService);
            //        _trendhelper.LoadByStoreAndDateRange(storeworld.StoreID, begin, end);
            //    }

            //    bool isExistsTrendCorrection = _trendhelper.IsExistsForWorld(storeworld.ID);

            //    decimal trendcorrection = 1;

            //    foreach (EstimatedWorldWorkingHours workinghours in lst)
            //    {
            //        if (isExistsTrendCorrection)
            //        {
            //            trendcorrection = Convert.ToDecimal(_trendhelper.GetTrendCorrection(storeworld.ID, workinghours.Date));
            //            worldinfo.SetTargetedHoursByDate(workinghours.Date, (int)(workinghours.WorkingHours * 60 * trendcorrection));
            //        }
            //        else
            //            worldinfo.SetTargetedHoursByDate(workinghours.Date, (int)(workinghours.WorkingHours * 60));
            //    }
            //}
            WeeklyEstimatedWorldHoursBuilder estimateLoader = new WeeklyEstimatedWorldHoursBuilder();
            estimateLoader.AssignTrendCorrecttionHelper(_trendhelper);
            int[] days = estimateLoader.BuildWeek(storeworld, begin);
            worldinfo.SetTargetedHours(days);
            //if (lst != null && estimateLoader.EstimatedHours != null)
            //{
            //    if (lst.Count == estimateLoader.EstimatedHours.Count)
            //    {
            //        for (int i = 0; i < 7; i++)
            //        {
            //            Debug.Assert(worldinfo.TargetedHours[i] == days[i]);
            //        }
            //    }
            //}

        }

        private void FillCommonInfoForWorld(WorldPlanningInfo worldinfo, StoreToWorld storeworld, DateTime begin, DateTime end)
        {
            short year = (short)DateTimeHelper.GetYearByDate(begin);

            PersonMinMax personMinMax = ExStoreToWorld.GetPersonMinMax(storeworld, year);

            WorldAvailableBufferHoursManager availBufferHours = new WorldAvailableBufferHoursManager(storeworld, begin);

            AvgAmount avgamount = _avgamountservice.GetAvgAmountByYear(CountryId, year);

            worldinfo.StoreWorldId = storeworld.ID;
            if (personMinMax != null)
            {
                worldinfo.MinimumPresence = personMinMax.Min;
                worldinfo.MaximumPresence = personMinMax.Max;
            }
            if (availBufferHours.BufferHours != null && availBufferHours.BufferHours.Value != 0)
            {
                worldinfo.AvailableWorldBufferHours = Convert.ToInt32(availBufferHours.GetPrevAvailableBufferForWeek(begin) +
                        availBufferHours.BufferHoursPerWeek);
            }
            else
                worldinfo.AvailableWorldBufferHours = Int32.MinValue;

            if (!worldinfo.IsCashDesk)
            {
                Benchmark benchmark = ExStoreToWorld.GetBenchmark(storeworld, year);//_benchmarkservice.GetBenchmark(storeworld.ID, year);
                if (benchmark != null)
                    worldinfo.Benchmark = benchmark.Value;
            }
        }

        private CashDeskPlanningInfo GetCashDeskInfo(StoreToWorld storeworld, DateTime beginWeekDate)
        {
            if (storeworld == null)
                throw new ArgumentNullException();

            if (storeworld.WorldTypeID != WorldType.CashDesk)
                throw new ArgumentException("storeworld must be cashdesk");

            DateTime endWeekDate = DateTimeHelper.GetSunday (beginWeekDate );
            CashDeskPlanningInfo worldinfo = new CashDeskPlanningInfo();
            worldinfo.StoreWorldId = storeworld.ID;
            FillCommonInfoForWorld(worldinfo, storeworld, beginWeekDate, endWeekDate);

            if (IsPlanning)
            {
                FillCashDeskEstimateData(worldinfo, storeworld, beginWeekDate, endWeekDate);
                
            }
            
            return worldinfo;
        }


        private void FillCashDeskEstimateData(CashDeskPlanningInfo cashdesk, StoreToWorld storeworld, DateTime begin, DateTime end)
        {
            Debug.Assert(cashdesk != null);
            Debug.Assert(begin < end);
            Debug.Assert(begin.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(end.DayOfWeek == DayOfWeek.Sunday);

            if (cashdesk == null)
                return;

            if (_trendhelper == null)
            {
                _trendhelper = new TrendCorrectionHelper(_storeservice.TrendCorrectionService);
                _trendhelper.LoadByStoreAndDateRange(storeworld.StoreID, begin, end);
            }

            bool isExistsTrendCorrection = _trendhelper.IsExistsForWorld(storeworld.ID);
            decimal trendcorrection = 1;

            IList lst = _storetoworldservice.GetCashDeskPeopleEstimated(begin, end, storeworld.StoreID);

            if (lst != null)
            {
                foreach (CashDeskPeoplePerHourEstimateShort cashdeskitem in lst)
                {
                    if (isExistsTrendCorrection)
                    {
                        trendcorrection = Convert.ToDecimal(_trendhelper.GetTrendCorrection(storeworld.ID, cashdeskitem.Date));
                        cashdeskitem.PeoplePerHour = Convert.ToInt16(cashdeskitem.PeoplePerHour * trendcorrection);
                        cashdeskitem.TargReceiptsPerHour = cashdeskitem.TargReceiptsPerHour * trendcorrection;
                        cashdesk.AddCashDeskItem(cashdeskitem);
                    }
                    else
                    {
                        cashdesk.AddCashDeskItem(cashdeskitem);
                    }
                }
            }

            EstimatedWorldHoursBuilder2 estimatedHoursLoader = new EstimatedWorldHoursBuilder2();
            estimatedHoursLoader.AssignTrendCorrecttionHelper(_trendhelper);

            cashdesk.SumPlannedWorkingHours = estimatedHoursLoader.Build(storeworld, begin, end);


            //IList list = _storetoworldservice.GetEstimatedWorldWorkingHours(begin, end, storeworld.StoreID, storeworld.WorldID);
            //if (list != null)
            //{
            //    int totalTime = 0;
            //    foreach (EstimatedWorldWorkingHours workinghours in list)
            //    {
            //        if (isExistsTrendCorrection)
            //        {
            //            trendcorrection = Convert.ToDecimal(_trendhelper.GetTrendCorrection(storeworld.ID, workinghours.Date));
            //        }
            //        totalTime += (int)(workinghours.WorkingHours * 60 * trendcorrection);
            //    }

            //    cashdesk.SumPlannedWorkingHours = totalTime;
            //}
        }


    }
}
