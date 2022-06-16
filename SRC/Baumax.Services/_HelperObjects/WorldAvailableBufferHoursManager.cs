using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using System.Diagnostics;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using Baumax.Services._HelperObjects.ExEntity;

namespace Baumax.Services._HelperObjects
{
    /*
     * select
     sw.Store_WorldID 
     ,sum(isnull(dp.WorkingHours,0)) WorkingHoursSum
from dbo.EmployeeDayStatePlanning dp
inner join Store_World sw
on
  dp.Store_WorldID = sw.Store_WorldID
where 
     dp.Date between '20080121' and '20080127' 
     and sw.StoreID = 1162
group by sw.Store_WorldID
     */
    public class WorldAvailableBufferHoursManager
    {
        #region fields

        //private BufferHourAvailableService _service = null;
        private StoreToWorld _storeworld;
        private BufferHours _bufferhours;
        private int _year = 0;
        private DateTime dateBeginYear;
        private DateTime dateEndYear;
        private DateTime _currentdate;
        int _BufferHoursPerWeek = 0;
        private int _number_weeks_in_year;

        public bool IgnoreSave = false;

        private List<BufferHourAvailable> _bufferhoursList = new List<BufferHourAvailable> ();
        private Dictionary <DateTime, BufferHourAvailable> _diction = new Dictionary<DateTime,BufferHourAvailable> ();

        #endregion


        public static Dictionary<long, int?> LoadPlannedWorkingHours(long storeid, DateTime monday)
        {
            return (ServerEnvironment.StoreToWorldService as StoreToWorldService).GetWorkingHoursByWorlds(storeid, monday, true);
        }
        public static Dictionary<long, int?> LoadActualWorkingHours(long storeid, DateTime monday)
        {
            return (ServerEnvironment.StoreToWorldService as StoreToWorldService).GetWorkingHoursByWorlds(storeid, monday, false);
        }
       
        #region properties

        protected BufferHourAvailableService Service
        {
            get
            {
                return ServerEnvironment.StoreService.BufferHourAvailableService as BufferHourAvailableService;
            }
        }
        public int BufferHoursPerWeek
        {
            get { return _BufferHoursPerWeek; }
            protected set { _BufferHoursPerWeek = value; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public int NumberOfWeekInYear
        {
            get { return _number_weeks_in_year; }
            protected set { _number_weeks_in_year = value; }
        }

        public BufferHours BufferHours
        {
            get { return _bufferhours; }
            protected set { _bufferhours = value; }
        }

        public StoreToWorld StoreWorld
        {
            get { return _storeworld; }
            protected set { _storeworld = value; }
        }
        public DateTime CurrentDate
        {
            get { return _currentdate; }
            set 
            {
                if (value.DayOfWeek != DayOfWeek.Monday)
                    throw new ArgumentException();
                if (_currentdate != value)
                {
                    _currentdate = value;
                    BuildDates();
                }
            }
        }

        public int Count
        {
            get
            {
                return _diction.Count;
            }
        }

        #endregion

        #region ctor

        public WorldAvailableBufferHoursManager()
        {
        }

        public WorldAvailableBufferHoursManager(StoreToWorld storeworld, DateTime date)
            : this()
        {
            Debug.Assert(storeworld != null);

            StoreWorld = storeworld;
            CurrentDate = date;
            LoadBufferHours();
        }

        public WorldAvailableBufferHoursManager(StoreToWorld storeworld, int year)
            : this()
        {
            Debug.Assert(storeworld != null);


            StoreWorld = storeworld;
            CurrentDate = DateTimeHelper.GetBeginYearDate(year);

            Debug.Assert(year == Year);
            LoadBufferHours();
        }

        public WorldAvailableBufferHoursManager(StoreToWorld storeworld, BufferHours entity)
            : this()
        {
            Debug.Assert(entity != null);
            Debug.Assert(storeworld != null);

            StoreWorld = storeworld;
            BufferHours = entity;
            CurrentDate = DateTimeHelper.GetBeginYearDate(entity.Year);

            Debug.Assert(entity.Year == Year);
            CheckBufferHours();
        }
        #endregion


        protected virtual void _DoUpdateEntity(BufferHourAvailable entity)
        {
            if (!IgnoreSave)
            {
                //if (entity.IsNew)
                //    Service.Save(entity);
                //else
                //    Service.Update(entity);
                Service.SaveOrUpdate2(entity);
            }
        }

        protected virtual void _DoDeleteEntity(BufferHourAvailable entity)
        {
            Service.Delete(entity);
        }

        private void LoadBufferHours()
        {
            BufferHours = ExStoreToWorld.GetBufferHours(StoreWorld, Year);//ServerEnvironment.BufferHoursService.GetBufferHours(StoreWorld.ID, (short)Year);
            CheckBufferHours();
        }



        private void CheckBufferHours()
        {
            BufferHoursPerWeek = 0;
            if (BufferHours != null)
            {
                BufferHoursPerWeek = BufferHours.GetWeekStepValue(BufferHours);

                if (BufferHours.ValueWeek != BufferHoursPerWeek)
                {
                    BufferHours.ValueWeek = BufferHoursPerWeek;
                    ServerEnvironment.BufferHoursService.SaveOrUpdate(BufferHours);
                }
            }
        }
        private void BuildDates()
        {
            Year = DateTimeHelper.GetYearByDate(CurrentDate);
            NumberOfWeekInYear = DateTimeHelper.GetCountWeekInYear(Year);
            dateBeginYear = DateTimeHelper.GetBeginYearDate(Year);
            dateEndYear = DateTimeHelper.GetEndYearDate(Year);
        }

        // date must be monday
        private void ValidateDate(DateTime date)
        {
            CurrentDate = date;

            _bufferhoursList = Service.GetAvailableBufferHoursForYear(StoreWorld.ID, _year);

            if (_bufferhoursList != null)
            {
                _bufferhoursList.Sort(new ComparerAvailableBufferHours());
            }
            
            CheckAndBuildAllYearEntity();
        }

        internal void CheckAndBuildAllYearEntity()
        {
            if (Count == NumberOfWeekInYear) return;

            DateTime date = dateBeginYear;
            byte week = 1;
            int availablebuffer = 0;
            while (date < dateEndYear)
            {
                if (!_diction.ContainsKey(date))
                {
                    availablebuffer += BufferHoursPerWeek ;

                    BufferHourAvailable entity = new BufferHourAvailable();
                    entity.StoreWorldID = StoreWorld.ID;
                    entity.WeekBegin = date;
                    entity.WeekEnd = DateTimeHelper.GetSunday(date);//entity.WeekBegin.AddDays(6);
                    entity.WeekNumber = week;
                    entity.Year = (short)_year;
                    entity.SumFromPlanning = null;
                    entity.SumFromRecording = null;
                    entity.AvailableBufferHour = availablebuffer;

                    _DoUpdateEntity(entity);
                    AddEntityToList(entity);
                }
                week += 1;
                date = DateTimeHelper.GetNextMonday(date);//date.AddDays(7);
            }
        }

        public BufferHourAvailable this[DateTime date]
        {
            get
            {
                BufferHourAvailable entity = null;
                _diction.TryGetValue(date, out entity);
                return entity;
            }
        }

        public int GetPrevAvailableBufferForWeek(DateTime date)
        {
            Debug.Assert(date.DayOfWeek == DayOfWeek.Monday);

            int prevBuffer = 0;

            if (dateBeginYear < date)// can't look on previous year
            {
                DateTime prevWeekMonday = date.AddDays(-7);

                BufferHourAvailable entity = Service.GetBufferHoursAvailable(StoreWorld.ID, prevWeekMonday);
                if (entity != null)
                {
                    prevBuffer = (int)entity.AvailableBufferHour;
                }
                else
                {
                    CheckAndBuildAllYearEntity();
                    prevBuffer = GetPrevAvailableBuffer(date);
                }
            }

            return prevBuffer;
        }
        
        public void RecalculateAfterChangedBufferValue()
        {
            if (_bufferhoursList != null)
            {
                _bufferhoursList.Sort(new ComparerAvailableBufferHours());
                double prev_buffer = 0;
                foreach (BufferHourAvailable entity in _bufferhoursList)
                {
                    if (entity.Update(prev_buffer, BufferHoursPerWeek))
                    {
                        _DoUpdateEntity(entity);
                    }
                    prev_buffer = entity.AvailableBufferHour;
                }
            }

        }


        private int GetPrevAvailableBuffer(DateTime date)
        {
            Debug.Assert(date.DayOfWeek == DayOfWeek.Monday);

            DateTime prevWeekMonday = date.AddDays(-7);
            BufferHourAvailable entity = this[prevWeekMonday];

            return (entity != null) ? (int)entity.AvailableBufferHour : 0;
        }

        public void UpdateEstimation()
        {
            if (_bufferhoursList != null)
            {
                //EstimatedWorldHoursBuilder estimateBuilder = new EstimatedWorldHoursBuilder();

                _bufferhoursList.Sort(new ComparerAvailableBufferHours());
                //double prev_buffer = 0;
                //foreach (BufferHourAvailable entity in _bufferhoursList)
                //{
                //    if (entity.IsExistsEstimate)
                //    {
                //        entity.SumActualBVEstimated = estimateBuilder.Build(StoreWorld, entity.WeekBegin, entity.WeekEnd);
                //    }
                //}

                YearlyEstimatedWorldHoursBuilder estimateLoader = new YearlyEstimatedWorldHoursBuilder();
                int[] sums = estimateLoader.BuildYear(StoreWorld, Year);

                int iCount = Math.Min(_bufferhoursList.Count, sums.Length);
                if (sums.Length != _bufferhoursList.Count)
                {
                    Debug.Assert(false);
                }

                BufferHourAvailable buffer = null;
                for (int i = 0; i < iCount; i++)
                {
                    buffer = _bufferhoursList[i];
                    if (buffer.IsExistsEstimate)
                    {
                        buffer.SumActualBVEstimated = sums[i];// estimateBuilder.Build(StoreWorld, entity.WeekBegin, entity.WeekEnd);
                    }
                }
 

            }
        }

        public void RecalculateYear()
        {
            if (_bufferhoursList != null)
            {
                _bufferhoursList.Sort(new ComparerAvailableBufferHours());

                int[] planned_sums = (ServerEnvironment.StoreToWorldService as StoreToWorldService).GetWorldWorkingHoursForYearAsWeeksSum(StoreWorld.ID, Year, true);
                int[] actual_sums = (ServerEnvironment.StoreToWorldService as StoreToWorldService).GetWorldWorkingHoursForYearAsWeeksSum(StoreWorld.ID, Year, false);
                YearlyEstimatedWorldHoursBuilder estimateLoader = new YearlyEstimatedWorldHoursBuilder();
                int[] estimate_sums = estimateLoader.BuildYear(StoreWorld, Year);

                if (planned_sums != null && actual_sums != null && estimate_sums != null &&
                    planned_sums.Length == actual_sums.Length &&
                    planned_sums.Length == estimate_sums.Length &&
                    planned_sums.Length == NumberOfWeekInYear &&
                    _bufferhoursList.Count == planned_sums.Length &&
                    _bufferhoursList.Count == NumberOfWeekInYear)
                {
                    BufferHourAvailable buffer = null;

                    for (int i = 0; i < NumberOfWeekInYear; i++)
                    {
                        buffer = _bufferhoursList[i];
                        if (buffer.IsExistsEstimate)
                        {
                            buffer.SumActualBVEstimated = estimate_sums[i];
                        }
                        if (buffer.IsExistsPlanning)
                        {
                            buffer.SumFromPlanning = planned_sums[i];
                        }
                        if (buffer.IsExistsRecording)
                        {
                            buffer.SumFromRecording = actual_sums[i];
                        }
                    }
                }

                Update();
            }

        }

        private int LoadEstimateSum(BufferHourAvailable entity)
        {
            EstimatedWorldHoursBuilder2 b = new EstimatedWorldHoursBuilder2();

            int value = b.Build(StoreWorld, entity.WeekBegin, entity.WeekEnd);
            if (entity.SumActualBVEstimated != value)
            {
                entity.SumActualBVEstimated = value;
                _DoUpdateEntity(entity);
            }

            return value;
        }

        public void UpdatePlanningSum(DateTime dateMonday, int sum_of_hours)
        {
            BufferHourAvailable entity = this[dateMonday];

            int prevBuffer = GetPrevAvailableBuffer(dateMonday);

            if (entity == null)
                return ;

            if (!entity.IsExistsEstimate)
            {
                LoadEstimateSum(entity); 
            }

            if (sum_of_hours != entity.SumFromPlanning)
            {
                entity.SumFromPlanning = sum_of_hours;

                if (!entity.IsExistsRecording)
                {

                    if (entity.Update(prevBuffer, BufferHoursPerWeek))
                    {
                        UpdateBufferHoursSumFrom(entity);
                    }
                }
                _DoUpdateEntity(entity);
            }


        }
        public void UpdateActualSum(DateTime dateMonday, int sum_of_hours)
        {
            BufferHourAvailable entity = this[dateMonday];

            int prevBuffer = GetPrevAvailableBuffer(dateMonday);

            if (entity == null)
                return;

            if (!entity.IsExistsEstimate)
            {
                LoadEstimateSum(entity);
            }

            if (sum_of_hours != entity.SumFromRecording)
            {
                entity.SumFromRecording = sum_of_hours;
                if (entity.Update(prevBuffer, BufferHoursPerWeek))
                {
                    UpdateBufferHoursSumFrom(entity);
                }
                _DoUpdateEntity(entity);
            }


        }
        private void UpdateBufferHoursSumFrom(BufferHourAvailable prevEntity)
        {
            Debug.Assert(prevEntity != null);


            if (BufferHours == null || BufferHours.Value == 0) return;

            // if last week in year - return
            if (prevEntity.WeekNumber == NumberOfWeekInYear) return;



            DateTime date = prevEntity.WeekBegin.AddDays(7);
            BufferHourAvailable entity = this[date];

            if (entity == null) return;

            if (entity.Update(prevEntity.AvailableBufferHour, BufferHoursPerWeek))
            {
                _DoUpdateEntity(entity);
                UpdateBufferHoursSumFrom(entity);
            }
        }


        internal void AddEntityToList(BufferHourAvailable entity)
        {
            if (_diction.ContainsKey(entity.WeekBegin))
            {
                _DoDeleteEntity(entity);
                return;
            }

            if (_bufferhoursList == null)
                _bufferhoursList = new List<BufferHourAvailable>();
            _bufferhoursList.Add(entity);
            _diction[entity.WeekBegin] = entity;
        }

        internal void AddEntityToList(List<BufferHourAvailable> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (BufferHourAvailable entity in entities)
                    AddEntityToList(entity);
            }
        }

        public void Load()
        {
            AddEntityToList(Service.GetAvailableBufferHoursForYear(StoreWorld.ID, Year));
        }

        public void Clear()
        {
            _diction.Clear();
            _bufferhoursList.Clear();
        }

        public void Update()
        {
            if (_bufferhoursList != null)
            {
                _bufferhoursList.Sort(new ComparerAvailableBufferHours());
                double prev_buffer = 0;
                foreach (BufferHourAvailable entity in _bufferhoursList)
                {
                    entity.Update(prev_buffer, BufferHoursPerWeek);
                    _DoUpdateEntity(entity);
                    prev_buffer = entity.AvailableBufferHour;
                }
            }
        }

        class ComparerAvailableBufferHours : IComparer<BufferHourAvailable>
        {
            public int Compare(BufferHourAvailable left, BufferHourAvailable right)
            {
                int y = left.Year - right.Year;

                if (y == 0)
                    y = left.WeekNumber - right.WeekNumber;

                return y;
            }
        }

    }

    public class StoreBufferHoursAvailableManager
    {
        #region fields

        private Dictionary<long, WorldAvailableBufferHoursManager> _diction = new Dictionary<long, WorldAvailableBufferHoursManager>();
        private int _year;
        private long _storeid;

        #endregion

        #region properties

        public int Year
        {
            get { return _year; }
            protected set { _year = value; }
        }
        public long StoreId
        {
            get { return _storeid; }
            protected set { _storeid = value; }
        }

        protected BufferHourAvailableService Service
        {
            get
            {
                return ServerEnvironment.StoreService.BufferHourAvailableService as BufferHourAvailableService;
            }
        }

        #endregion

        #region ctor

        public StoreBufferHoursAvailableManager(long storeid, int year)
        {
            StoreId = storeid;
            Year = year;
            Init(null);
        }
        public StoreBufferHoursAvailableManager(long storeid, DateTime monday)
        {
            StoreId = storeid;
            Year = DateTimeHelper.GetYearByDate(monday);
            Init(null);
        }
        public StoreBufferHoursAvailableManager(long storeid, DateTime monday, List<StoreToWorld> lstWorlds)
        {
            StoreId = storeid;
            Year = DateTimeHelper.GetYearByDate(monday);
            Init(lstWorlds);
        }

        #endregion

        public WorldAvailableBufferHoursManager GetManager(long storeworldid)
        {
            WorldAvailableBufferHoursManager m = null;
            _diction.TryGetValue(storeworldid, out m);
            return m;
        }

        protected void Init(List<StoreToWorld> worlds)
        {
            if (StoreId <= 0) return;

            List<StoreToWorld> lstWorlds = worlds;

            if (lstWorlds == null)
            {
                lstWorlds = new StoreWorldListSrv(StoreId);
            }

            WorldAvailableBufferHoursManager bhm = null;
            foreach (StoreToWorld sw in lstWorlds)
            {
                _diction[sw.ID] = new WorldAvailableBufferHoursManager(sw, Year);
            }

            List<BufferHourAvailable> lst = Service.GetAvailableBufferHoursForStore(StoreId, Year);
            if (lst != null && lst.Count > 0)
            {
                WorldAvailableBufferHoursManager m = null;
                foreach (BufferHourAvailable b in lst)
                {
                    if ((m != null && m.StoreWorld.ID == b.StoreWorldID ) ||
                     (_diction.TryGetValue (b.StoreWorldID, out m)))
                    {
                        m.AddEntityToList(b);
                    }
                }
            }
            foreach (WorldAvailableBufferHoursManager manager in _diction.Values)
            {
                manager.CheckAndBuildAllYearEntity();
            }
        }


        public void UpdatePlanningSum(long storeid, DateTime monday)
        {
            Dictionary<long, int?> diction = ExStoreToWorld.GetPlannedWorkingSumByStore(storeid, monday);

            if (diction != null)
            {
                WorldAvailableBufferHoursManager manager = null;
                int? sum = null;
                foreach (long sw_id in diction.Keys)
                {
                    manager = GetManager(sw_id);

                    if (manager != null)
                    {
                        sum = diction[sw_id];
                        if (sum.HasValue)
                            manager.UpdatePlanningSum(monday, sum.Value);
                    }
                }
            }
        }
        public void UpdateActualSum(long storeid, DateTime monday)
        {
            Dictionary<long, int?> diction = WorldAvailableBufferHoursManager.LoadActualWorkingHours(storeid, monday);

            if (diction != null)
            {
                WorldAvailableBufferHoursManager manager = null;
                int? sum = null;
                foreach (long sw_id in diction.Keys)
                {
                    manager = GetManager(sw_id);

                    _diction.TryGetValue(sw_id, out manager);

                    if (manager != null)
                    {
                        sum = diction[sw_id];
                        if (sum.HasValue)
                            manager.UpdateActualSum(monday, sum.Value);
                    }
                }
            }




        }



        public void UpdateWholeYear2()
        {
            int count_of_week = DateTimeHelper.GetCountWeekInYear(Year);
            DateTime monday = DateTimeHelper.GetBeginYearDate(Year);

            // block database updates
            foreach (WorldAvailableBufferHoursManager m in _diction.Values)
            {
                m.IgnoreSave = true;
                m.UpdateEstimation();
            }

            for (int i = 0; i < count_of_week; i++)
            {
                UpdatePlanningSum(_storeid, monday);
                UpdateActualSum(_storeid, monday);

                monday = DateTimeHelper.GetNextMonday(monday);
            }
            foreach (WorldAvailableBufferHoursManager m in _diction.Values)
            {
                m.IgnoreSave = false;
                m.Update();
            }

        }
        public void UpdateWholeYear()
        {
            foreach (WorldAvailableBufferHoursManager m in _diction.Values)
            {
                m.RecalculateYear();
            }
        }


        #region static function

        public static void UpdatePlanningBufferHours(long storeid, DateTime monday)
        {
            (new StoreBufferHoursAvailableManager(storeid, monday)).UpdatePlanningSum(storeid, monday); 
        }

        public static void UpdateActualBufferHours(long storeid, DateTime monday)
        {
            (new StoreBufferHoursAvailableManager(storeid, monday)).UpdateActualSum(storeid, monday);
        }

        public static void UpdateBufferHours(long storeid, DateTime monday, bool bPlanning)
        {
            if (bPlanning)
                UpdatePlanningBufferHours(storeid, monday);
            else
                UpdateActualBufferHours(storeid, monday);
        }

        public static void UpdateWholeYear(long storeid, int year)
        {
            (new StoreBufferHoursAvailableManager(storeid, year)).UpdateWholeYear();
        }

        #endregion
    }
}
