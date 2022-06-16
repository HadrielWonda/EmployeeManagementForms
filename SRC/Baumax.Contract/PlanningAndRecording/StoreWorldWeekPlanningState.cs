using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Baumax.Contract.TimePlanning
{

    public class StoreWorldWeekPlanningState
    {
        private long _storeworldid;
        private DateTime _BeginWeekDate;
        private DateTime _EndWeekDate;
        private List<EmployeePlanningWeek> _listemployeesweek = new List<EmployeePlanningWeek> ();
        private Dictionary<long, EmployeePlanningWeek> _dictionEmployees = new Dictionary<long, EmployeePlanningWeek>();

        //private int[] _DaysSums = new int[8];

        private SummariesByWorld _summary = null;

        //private int _CountWorldPlanningHours = 0;
        //private int _ColumnSumContractWorkingHoursPerWeek = 0;
        //private int _ColumnSumAlreadyPlannedWorkingHours = 0;
        //private int _ColumnSumAdditionalCharges = 0;
        //private int _ColumnSumPlusMinusHours = 0;
        //private int _ColumnSumSaldo = 0;

        private WorldPlanningInfo _StoreWorldInfo = null;

        private IPlanningContext _context = null;

        public StoreWorldWeekPlanningState(long storeworldid, DateTime begin, DateTime end)
        {
            Debug.Assert(begin < end);
            Debug.Assert(begin.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(end.DayOfWeek == DayOfWeek.Sunday);

            BeginWeekDate = begin;
            EndWeekDate = end;
            StoreWorldId = storeworldid;

            _summary = new SummariesByWorld(storeworldid);
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
                if (StoreWorldInfo != null)
                {
                    return StoreWorldInfo.IsCashDesk;
                }
                return false;
            }
        }

        public IPlanningContext IContext
        {
            get { return _context; }
            set { _context = value; }
        }

        public void Free()
        {
            _context = null;
            _listemployeesweek.Clear();
            _dictionEmployees.Clear();
            _StoreWorldInfo = null;

            _summary.Clear();

        }
        #region week info propeties

        public SummariesByWorld Summary
        {
            get
            {
                if (_summary == null)
                {
                    _summary = new SummariesByWorld(StoreWorldId);
                }
                return _summary;
            }
        }
        public long StoreWorldId
        {
            get { return _storeworldid; }
            protected set { _storeworldid = value; }
        }

        public DateTime BeginWeekDate
        {
            get { return _BeginWeekDate; }
            protected set { _BeginWeekDate = value; }
        }
        

        public DateTime EndWeekDate
        {
            get { return _EndWeekDate; }
            protected set { _EndWeekDate = value; }
        }

        public List<EmployeePlanningWeek> List
        {
            get { return _listemployeesweek; }
        }

        public EmployeeDayViewList GetDailyListView(DateTime date)
        {
             EmployeeDayViewList lst = new EmployeeDayViewList(this, date);

             return lst; 
        }
        public EmployeePlanningWeek this[long id]
        {
            get
            {
                EmployeePlanningWeek result = null;
                _dictionEmployees.TryGetValue (id, out result);
                return result;
            }

            set
            {
                if (value != null)
                {
                    EmployeePlanningWeek week = this[id];
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

        #endregion

        #region Week state properties

        public int CountWorldPlanningHours
        {
            get 
            {
                return Summary.CountWorldPlanningHours;
                //_CountWorldPlanningHours; 
            }
            //protected set { _CountWorldPlanningHours = value; }
        }
        public int ColumnSumContractWorkingHoursPerWeek
        {
            get { return Summary.ColumnSumContractWorkingHoursPerWeek; }
            //protected set { _ColumnSumContractWorkingHoursPerWeek = value; }
        }


        public int ColumnSumAlreadyPlannedWorkingHours
        {
            get { return Summary.ColumnSumAlreadyPlannedWorkingHours; }
            //protected set { _ColumnSumAlreadyPlannedWorkingHours = value; }
        }


        public int ColumnSumAdditionalCharges
        {
            get { return Summary.ColumnSumAdditionalCharges; }
            //protected set { _ColumnSumAdditionalCharges = value; }
        }


        public int ColumnSumPlusMinusHours
        {
            get { return Summary.ColumnSumPlusMinusHours; }
            //protected set { _ColumnSumPlusMinusHours = value; }
        }


        public int ColumnSumSaldo
        {
            get { return Summary.ColumnSumSaldo; }
            //protected set { _ColumnSumSaldo = value; }
        }
        #endregion

        #region Total sum functionality

        
        protected virtual void CalculateDaysSum()
        {

            Summary.ProccessWeek(_listemployeesweek, IsCashDesk);


        }


        public int GetDaySum(DayOfWeek dayofweek)
        {
            return Summary.DaysSum[(int)dayofweek];
        }
        
        public int SumWorkingHoursOfWeek
        {
            get 
            {
                return Summary.DaysSum.TotalSum;
            }
        }

        public void Calculate()
        {
            if (IContext != null)
            {
                foreach (EmployeePlanningWeek epw in _listemployeesweek)
                {
                    IContext.WorkingModels.Calculate(epw);
                }
            }
            CalculateDaysSum();

            if (StoreWorldInfo != null)
            {
                StoreWorldInfo.SumHoursForNetPerformance = Summary.CountWorldPlanningHours;

                if (!IsCashDesk)
                {
                    StoreWorldPlanningInfo storeinfo = StoreWorldInfo as StoreWorldPlanningInfo;

                    Debug.Assert(storeinfo != null);

                    if (storeinfo != null)
                    {
                        storeinfo.Calculate(Summary.DaysSum);
                    }

                }
                else
                {
                    CashDeskPlanningInfo cashinfo = StoreWorldInfo as CashDeskPlanningInfo;
                    Debug.Assert(cashinfo != null);

                    if (cashinfo != null)
                    {
                        cashinfo.SumActualWorkingHours = SumWorkingHoursOfWeek;
                    }
                }
            }
        }

        #endregion

    }


    public class SummariesByWorld
    {
        #region fields

        private long _filter_store_world_id = 0;
        private IntArrayTP _DaysSums = new IntArrayTP(7);
        private int[][] _CashDeskUnitsPerHour = null;

        private int _CountWorldPlanningHours = 0;
        private int _ColumnSumContractWorkingHoursPerWeek = 0;
        private int _ColumnSumAlreadyPlannedWorkingHours = 0;
        private int _ColumnSumAdditionalCharges = 0;
        private int _ColumnSumPlusMinusHours = 0;
        private int _ColumnSumSaldo = 0;

        #endregion

        #region ctor 

        public SummariesByWorld(){}

        public SummariesByWorld(long filter_world_id)
        {
            _filter_store_world_id = filter_world_id;
        }

        #endregion

        #region properties

        public long FilterStoreWorldId
        {
            get { return _filter_store_world_id; }
            set
            {
                _filter_store_world_id = value;
            }
        }
        public int[][] CashDeskUnitsPerHour
        {
            get
            {
                if (_CashDeskUnitsPerHour == null)
                {
                    _CashDeskUnitsPerHour = new int[7][];
                    for (int i = 0; i < 7; i++)
                    {
                        _CashDeskUnitsPerHour[i] = new int[24];
                    }
                    ClearUnits();
                }
                return _CashDeskUnitsPerHour;
            }
        }
        public IntArrayTP DaysSum
        {
            get { return _DaysSums; }
        }
        
        public int CountWorldPlanningHours
        {
            get { return _CountWorldPlanningHours; }
            protected set { _CountWorldPlanningHours = value; }
        }
        public int ColumnSumContractWorkingHoursPerWeek
        {
            get { return _ColumnSumContractWorkingHoursPerWeek; }
            protected set { _ColumnSumContractWorkingHoursPerWeek = value; }
        }


        public int ColumnSumAlreadyPlannedWorkingHours
        {
            get { return _ColumnSumAlreadyPlannedWorkingHours; }
            protected set { _ColumnSumAlreadyPlannedWorkingHours = value; }
        }


        public int ColumnSumAdditionalCharges
        {
            get { return _ColumnSumAdditionalCharges; }
            protected set { _ColumnSumAdditionalCharges = value; }
        }


        public int ColumnSumPlusMinusHours
        {
            get { return _ColumnSumPlusMinusHours; }
            protected set { _ColumnSumPlusMinusHours = value; }
        }


        public int ColumnSumSaldo
        {
            get { return _ColumnSumSaldo; }
            protected set { _ColumnSumSaldo = value; }
        }
        #endregion

        protected virtual void ClearUnits()
        {
            if (_CashDeskUnitsPerHour != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 24; j++)
                    {
                        _CashDeskUnitsPerHour[i][j] = 0;
                    }

                }
            }
        }
        public virtual void Clear()
        {
            DaysSum.Clear();

            CountWorldPlanningHours = 0;
            ColumnSumContractWorkingHoursPerWeek = 0;
            ColumnSumAlreadyPlannedWorkingHours = 0;
            ColumnSumAdditionalCharges = 0;
            ColumnSumPlusMinusHours = 0;
            ColumnSumSaldo = 0;
            ClearUnits();
            
        }

        
        protected virtual void ProccessDay(EmployeePlanningDay employee_day, bool cashdesk)
        {
            if (employee_day.WorldId == FilterStoreWorldId)
            {
                int index = (int)employee_day.Date.DayOfWeek;

                DaysSum[index] += employee_day.CountDailyWorkingHours;
                CountWorldPlanningHours += employee_day.CountDailyPlannedWorkingHours;
                if (cashdesk)
                {
                    employee_day.FillQuoters(CashDeskUnitsPerHour[index]);
                }
            }
        }
        protected virtual void ProccessWeek(EmployeePlanningWeek employee_week, bool cashdesk)
        {
            foreach (EmployeePlanningDay epd in employee_week.Days.Values)
            {
                if (epd.WorldId == FilterStoreWorldId)
                {
                    ProccessDay(epd, cashdesk);
                }
            }
            ColumnSumContractWorkingHoursPerWeek += employee_week.ContractHoursPerWeek;
            ColumnSumAlreadyPlannedWorkingHours += employee_week.CountWeeklyPlanningWorkingHours;
            ColumnSumAdditionalCharges += employee_week.CountWeeklyAdditionalCharges;
            ColumnSumPlusMinusHours += employee_week.CountWeeklyPlusMinusHours;
            ColumnSumSaldo += employee_week.Saldo;
            
        }

        protected virtual void BeforeProcess()
        {
            Clear();
        }
        protected virtual void AfterProcess()
        {
            DaysSum.Calculate();
        }
        public virtual void ProccessWeek(List<EmployeePlanningWeek> employee_weeks, bool cashdesk)
        {
            BeforeProcess();

            foreach (EmployeePlanningWeek week in employee_weeks)
            {
                ProccessWeek(week, cashdesk);
            }
            AfterProcess();
        }
    }
}
