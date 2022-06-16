using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Baumax.Dao.TimePlanning
{
    public class StoreWorldWeekPlanningState
    {

        private long _storeworldid;
        private long _worldId;
        private DateTime _BeginWeekDate;
        private DateTime _EndWeekDate;
        private List<EmployeePlanningWeek> _listemployeesweek = new List<EmployeePlanningWeek> ();
        private Dictionary<long, EmployeePlanningWeek> _dictionEmployees = new Dictionary<long, EmployeePlanningWeek>();

        private int[] _DaysSums = new int[8];

        private int _CountWorldPlanningHours = 0;
        private int _ColumnSumContractWorkingHoursPerWeek = 0;
        private int _ColumnSumAlreadyPlannedWorkingHours = 0;
        private int _ColumnSumAdditionalCharges = 0;
        private int _ColumnSumPlusMinusHours = 0;
        private int _ColumnSumSaldo = 0;

        private StoreWorldPlanningInfo _StoreWorldInfo = null;

        private IPlanningContext _context = null;

        public StoreWorldWeekPlanningState(long worldid, DateTime begin, DateTime end)
        {
            Debug.Assert(begin < end);
            //Debug.Assert (begin == end.Subtract (TimeSpan.FromDays(7)));
            Debug.Assert(begin.DayOfWeek == DayOfWeek.Monday);
            Debug.Assert(end.DayOfWeek == DayOfWeek.Sunday);

            WorldId = worldid;
            BeginWeekDate = begin;
            EndWeekDate = end;
        }
        public StoreWorldWeekPlanningState(long storeworldid, long worldid, DateTime begin, DateTime end)
            :this(worldid, begin,end)
        {
            StoreWorldId = storeworldid;
        }



        public StoreWorldPlanningInfo StoreWorldInfo
        {
            get { return _StoreWorldInfo; }
            set { _StoreWorldInfo = value; }
        }
        public IPlanningContext IContext
        {
            get { return _context; }
            set { _context = value; }
        }
        #region week info propeties

        public long StoreWorldId
        {
            get { return _storeworldid; }
            set { _storeworldid = value; }
        }
        

        public long WorldId
        {
            get { return _worldId; }
            set { _worldId = value; }
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
            get { return _CountWorldPlanningHours; }
            set { _CountWorldPlanningHours = value; }
        }
        public int ColumnSumContractWorkingHoursPerWeek
        {
            get { return _ColumnSumContractWorkingHoursPerWeek; }
            set { _ColumnSumContractWorkingHoursPerWeek = value; }
        }


        public int ColumnSumAlreadyPlannedWorkingHours
        {
            get { return _ColumnSumAlreadyPlannedWorkingHours; }
            set { _ColumnSumAlreadyPlannedWorkingHours = value; }
        }


        public int ColumnSumAdditionalCharges
        {
            get { return _ColumnSumAdditionalCharges; }
            set { _ColumnSumAdditionalCharges = value; }
        }


        public int ColumnSumPlusMinusHours
        {
            get { return _ColumnSumPlusMinusHours; }
            set { _ColumnSumPlusMinusHours = value; }
        }


        public int ColumnSumSaldo
        {
            get { return _ColumnSumSaldo; }
            set { _ColumnSumSaldo = value; }
        }
        #endregion

        #region Total sum functionality

        private void Clear()
        {
            for (int i = 0; i < 8; i++)
            {
                _DaysSums[i] = 0;
            }
            CountWorldPlanningHours = 0;
            ColumnSumContractWorkingHoursPerWeek = 0;
            ColumnSumAlreadyPlannedWorkingHours = 0;
            ColumnSumAdditionalCharges = 0;
            ColumnSumPlusMinusHours = 0;
            ColumnSumSaldo = 0;
        }

        private void CalculateDaysSum()
        {
            Clear();
            foreach (EmployeePlanningWeek epw in _listemployeesweek)
            {
                foreach (EmployeePlanningDay epd in epw.Days.Values )
                {
                    _DaysSums[(int)epd.Date.DayOfWeek] += epd.CountDailyWorkingHours;
                    if (epd.WorldId == WorldId)
                    {
                        CountWorldPlanningHours += epd.CountDailyPlannedWorkingHours;
                    }
                }
                ColumnSumContractWorkingHoursPerWeek += epw.ContractHoursPerWeek;
                ColumnSumAlreadyPlannedWorkingHours += epw.CountWeeklyPlanningWorkingHours;
                ColumnSumAdditionalCharges += epw.CountWeeklyAdditionalCharges;
                ColumnSumPlusMinusHours += epw.CountWeeklyPlusMinusHours;
                ColumnSumSaldo += epw.Saldo;
            }
            
            for (int i = 0; i < 7; i++)
            {
                _DaysSums[7] += _DaysSums[i];
            }
        }


        public int GetDaySum(DayOfWeek dayofweek)
        {
            return _DaysSums[(int)dayofweek]; 
        }
        public int SumWorkingHoursOfWeek
        {
            get 
            {
                return _DaysSums[7];
            }
        }

        public void Calculate()
        {
            if (IContext != null)
            {
                foreach (EmployeePlanningWeek epw in _listemployeesweek)
                {
                    IContext.WorkingModels.Calculate(IContext.StoreDays, epw);
                }
            }
            CalculateDaysSum();
        }
        #endregion

    }
}
