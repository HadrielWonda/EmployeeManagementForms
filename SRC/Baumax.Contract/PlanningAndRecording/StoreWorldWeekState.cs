using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Baumax.Domain;

namespace Baumax.Contract.TimePlanning
{
    // class for group employee week by world of store

    public class StoreWorldWeekState
    {
        private const int SUM = 7;
        
        private StoreToWorld _storeworld;
        
        private DateTime _BeginWeekDate;
        private DateTime _EndWeekDate;

        private List<EmployeeWeek> _listemployeesweek = new List<EmployeeWeek>();
        private Dictionary<long, EmployeeWeek> _dictionEmployees = new Dictionary<long, EmployeeWeek>();

        private WeeklyDaysSum _dayssum = new WeeklyDaysSum();

        private int _CountWorldPlanningHours = 0;
        
        private bool _bPlanned = true;
        private IPlanningContext _context = null;
        private WorldPlanningInfo _StoreWorldInfo = null;
        private double _TargetedNetPerfomancePerHour = 0;

        public int[][] datas = new int[7][];

        public StoreWorldWeekState(StoreToWorld storeworld, DateTime begin, DateTime end)
        {
            StoreWorld = storeworld;
            Debug.Assert(begin < end);
            Debug.Assert(begin.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(end.DayOfWeek == DayOfWeek.Sunday);

            BeginWeekDate = begin;
            EndWeekDate = end;

            for (int i = 0; i < 7; i++)
            {
                datas[i] = new int[24];
            }
        }

        public StoreWorldWeekState(StoreToWorld storeworld, DateTime begin, DateTime end, bool bPlanned)
            :this(storeworld, begin,end)
        {
            _bPlanned = bPlanned;
        }
        public IPlanningContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
        #region week info propeties
        

        public bool PlannedWorld
        {
            get { return _bPlanned; }
            set { _bPlanned = value; }
        }

        public StoreToWorld  StoreWorld
        {
            get { return _storeworld; }
            set { _storeworld = value; }
        }

        public DateTime BeginWeekDate
        {
            get { return _BeginWeekDate; }
            set { _BeginWeekDate = value; }
        }


        public DateTime EndWeekDate
        {
            get { return _EndWeekDate; }
            set { _EndWeekDate = value; }
        }


        public List<EmployeeWeek> List
        {
            get { return _listemployeesweek; }
        }

        public EmployeeWeek this[long id]
        {
            get
            {
                if (_listemployeesweek.Count != _dictionEmployees.Count) BuildDiction();
                EmployeeWeek result = null;
                _dictionEmployees.TryGetValue(id, out result);
                return result;
            }

            set
            {
                if (value != null)
                {
                    EmployeeWeek week = this[id];
                    if (week != null)
                    {
                        _dictionEmployees.Remove(id);
                        _listemployeesweek.Remove(week);
                    }

                    _dictionEmployees[id] = value;
                    _listemployeesweek.Add(value);
                }
                else throw new NullReferenceException();
            }
        }

        private void BuildDiction()
        {
            _dictionEmployees.Clear ();
            if (_listemployeesweek != null)
            {
                foreach (EmployeeWeek ew in _listemployeesweek )
                    _dictionEmployees [ew.EmployeeId ] = ew;
            }
        }
        #endregion

        #region Week state properties

        public int CountWorldPlanningHours
        {
            get { return _CountWorldPlanningHours; }
            set { _CountWorldPlanningHours = value; }
        }

        public WorldPlanningInfo StoreWorldInfo
        {
            get { return _StoreWorldInfo; }
            set { _StoreWorldInfo = value; }
        }

        public bool IsCashDesk
        {
            get
            {
                if (StoreWorld!= null)
                {
                    return StoreWorld.IsCashDesk;
                }
                return false;
            }
        }

        public double TargetedNetPerfomancePerHour
        {
            get
            {
                return _TargetedNetPerfomancePerHour;
            }
            set
            {
                _TargetedNetPerfomancePerHour = value;
            }
        }


        public short MinimumPresence
        {
            get
            {
                return (StoreWorldInfo != null) ? StoreWorldInfo.MinimumPresence : (short)0;
            }
        }
        public short MaximumPresence
        {
            get
            {
                return (StoreWorldInfo != null) ? StoreWorldInfo.MaximumPresence : (short)0;
            }
        }

        public int WorldBufferHours
        {
            get
            {
                return (StoreWorldInfo != null) ? StoreWorldInfo.CurrentBufferHours : 0;
            }
        }
        public double Benchmark
        {
            get
            {
                return (StoreWorldInfo != null) ? StoreWorldInfo.Benchmark : 0;
            }
        }
        public decimal TargetedNetPerformancePerHour
        {
            get
            {
                return (StoreWorldInfo != null) ? StoreWorldInfo.TargetedNetPerformancePerHour : 0;
            }
        }

        #endregion

        #region Total sum functionality

        private void Clear()
        {
            _dayssum.Clear();
            //_daysUnitSum.Clear();

            if (IsCashDesk)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 24; j++)
                    {
                        datas[i][j] = 0;
                    }
                }
            }
        }

        private void CalculateDaysSum()
        {
            Clear();

            if (StoreWorld == null) return;
            if (_listemployeesweek != null && _listemployeesweek.Count > 0)
            {
                foreach (EmployeeWeek epw in _listemployeesweek)
                {
                    if (epw.IsValidWeek)
                    {
                        foreach (EmployeeDay epd in epw.DaysList)
                        {
                            if (epd.StoreWorldId == StoreWorld.ID)
                            {
                                _dayssum[epd.Date.DayOfWeek] += epd.CountDailyWorkingHours;
                                CountWorldPlanningHours += epd.CountDailyPlannedWorkingHours;
                                if (IsCashDesk)
                                {
                                    epd.FillQuoters(datas[(int)epd.Date.DayOfWeek]);
                                }
                            }
                        }
                        _dayssum.TotalContractWorkingHours += epw.ContractHoursPerWeek;
                        _dayssum.TotalPlannedHours += epw.CountWeeklyPlanningWorkingHours;
                        _dayssum.TotalAdditionalCharges += epw.CountWeeklyAdditionalCharges;
                        _dayssum.TotalPlusMinusHours += epw.CountWeeklyPlusMinusHours;
                        _dayssum.TotalSaldo += epw.Saldo;
                    }
                }
                DaysSum.BuildTotals();
            }
            if (StoreWorldInfo != null && CountWorldPlanningHours != 0)
            {
                TargetedNetPerfomancePerHour = (double)(StoreWorldInfo.TargetedNetPerformancePerHour / CountWorldPlanningHours);
            }
            else
            {
                TargetedNetPerfomancePerHour = 0;
            }
        }

        public WeeklyDaysSum DaysSum
        {
            get { return _dayssum; }
        }

        public int GetDaySum(DayOfWeek dayofweek)
        {
            Debug.Assert((int)dayofweek >= 0 && (int)dayofweek < 7);

            return DaysSum[dayofweek];
        }

        public int[] GetSums()
        {
            return DaysSum.GetSums();
        }
        

        public int SumWorkingHoursOfWeek
        {
            get
            {
                return DaysSum.TotalSum;
            }
        }
        
        public void Calculate(IWorkingModelManager wmmanager)
        {
            if (wmmanager != null)
            {
                foreach (EmployeeWeek epw in _listemployeesweek)
                {
                    wmmanager.CalculateNew(epw, PlannedWorld);
                }
            }
            CalculateDaysSum();

            if (StoreWorldInfo != null && (StoreWorldInfo is StoreWorldPlanningInfo))
            {
                (StoreWorldInfo as StoreWorldPlanningInfo).Calculate(GetSums());
            }
        }


        public void Calculate()
        {
            if (Context != null)
            {
                Calculate(Context.WorkingModels);
            }
            else
                Calculate(null);
        }

        #endregion

    }
}
