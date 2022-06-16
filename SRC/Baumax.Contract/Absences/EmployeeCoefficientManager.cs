using System;
using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using System.Collections;
using Baumax.Domain;

namespace Baumax.Contract.Absences
{
    //public class EmployeeCoefficientManager
    //{
    //    protected IEmployeeHolidaysInfoService _Service;
    //    protected Dictionary<long, List<EmployeeDayTimeResult>> _DayTimes = new Dictionary<long, List<EmployeeDayTimeResult>>();
    //    private long _StoreID;
    //    private int _Year;
    //    private const int avgWeeksDefault = 1; // may be need correct value !!!!!

    //    protected EmployeeCoefficientManager(long storeid, int year) 
    //    {
    //        _StoreID = storeid;
    //        _Year = year;
    //    }

    //    public EmployeeCoefficientManager (IEmployeeHolidaysInfoService service, long storeid, int year):this(storeid, year)
    //    {
    //        _Service = service;
    //        Init(_Service.GetEmployeeCoefficints(_StoreID, _Year));
    //    }
    
    //    public EmployeeCoefficientManager (List<EmployeeDayTimeResult> list, long storeID, int year):this(storeID, year)
    //    {
    //        Init(list);
    //    }

    //    public EmployeeCoefficientManager (List<EmployeeContract> contracts, decimal avgWeeks, long storeid, short year) : this(storeid, year)
    //    {
    //        if (contracts != null)
    //        {
    //            foreach (EmployeeContract contract in contracts)
    //            {
    //                if (!_DayTimes.ContainsKey(contract.EmployeeID))
    //                    _DayTimes[contract.EmployeeID] = new List<EmployeeDayTimeResult>();
    //                if (avgWeeks != 0)
    //                {
    //                    _DayTimes[contract.EmployeeID].Add(new EmployeeDayTimeResult(
    //                            contract.EmployeeID, contract.ContractBegin, contract.ContractEnd,
    //                            (contract.ContractWorkingHours / avgWeeks) / (SharedConsts.DayMinutes / 60)));    
    //                }
    //                else
    //                {
    //                    _DayTimes[contract.EmployeeID].Add(new EmployeeDayTimeResult(
    //                        contract.EmployeeID, contract.ContractBegin, contract.ContractEnd,
    //                        (contract.ContractWorkingHours / avgWeeksDefault) / (SharedConsts.DayMinutes / 60)));
    //                }
                    
    //            }        
    //        }
    //    }

    //    public int Year
    //    {
    //        get { return _Year; }
    //        set { _Year = value; }
    //    }
    //    public long StoreID
    //    {
    //        get { return _StoreID; }
    //        set { _StoreID = value; }
    //    }

    //    private void Init(List<EmployeeDayTimeResult> employees)
    //    {
            
    //        if (employees != null)
    //            foreach (EmployeeDayTimeResult dayTime in employees)
    //            {
    //                long id = dayTime.EmployeeID;

    //                if (!_DayTimes.ContainsKey(id))
    //                    _DayTimes.Add(id, new List<EmployeeDayTimeResult>());
    //                _DayTimes[id].Add(dayTime);
    //            }
    //    }

    //    public void FillTime(IEmployeeTimeRange absence)
    //    { 
    //        if (_DayTimes.ContainsKey(absence.EmployeeID))
    //            foreach (EmployeeDayTimeResult dayTime in _DayTimes[absence.EmployeeID])
    //                if (absence.Date >= dayTime.ContractBegin && absence.Date <= dayTime.ContractEnd)
    //                {
    //                    absence.Time = (short)((absence.End - absence.Begin) / dayTime.Coefficient);
    //                    break;
    //                }
    //    }

    //    public decimal GetDays(long employeeID, DateTime date, int minutes)
    //    {
    //        if (_DayTimes.ContainsKey(employeeID))
    //            foreach (EmployeeDayTimeResult dayTime in _DayTimes[employeeID])
    //                if (date >= dayTime.ContractBegin && date <= dayTime.ContractEnd)
    //                    return ((decimal)minutes/SharedConsts.DayMinutes) / dayTime.Coefficient;
    //        return 0m;
    //    }

    //    public decimal GetMinutes(long employeeID, DateTime date)
    //    {
    //        if (_DayTimes.ContainsKey(employeeID))
    //            foreach (EmployeeDayTimeResult dayTime in _DayTimes[employeeID])
    //                if (date >= dayTime.ContractBegin && date <= dayTime.ContractEnd)
    //                    return SharedConsts.DayMinutes * dayTime.Coefficient;
    //        return 0;
    //    }

    //    /// <param name="absences">Must be IEmployeeTimeRange collection</param>
    //    public void FillTimes(IEnumerable absences)
    //    {
    //        foreach (IEmployeeTimeRange absence in absences)
    //            FillTime (absence);
    //    }

    //    public decimal this[long employee, DateTime date]
    //    {
    //        get 
    //        {
    //            if (_DayTimes.ContainsKey(employee))
    //                foreach (EmployeeDayTimeResult result in _DayTimes[employee])
    //                    if (result.ContractBegin <= date && result.ContractEnd >= date)
    //                        return result.Coefficient;
    //            return 1m;
    //        }
    //    }

    //    public static decimal GetRealDays (short minutes)
    //    {
    //        return minutes / SharedConsts.DayMinutes;
    //    }

    //    public static short GetEntityTime (short begin, short end, decimal contractHours, decimal weekDays)
    //    {
    //        return (short)((end - begin) /
    //               ((decimal)(contractHours / weekDays) /
    //                    SharedConsts.DayMinutes));
    //    }

    //    public static short GetEntityTime (short begin, short end, decimal coeficient)
    //    {
    //        return (short)((end - begin) / coeficient);
    //    }
    //}
}
