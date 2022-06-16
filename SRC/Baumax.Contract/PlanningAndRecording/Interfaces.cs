using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using System.Drawing;
using Baumax.Contract.WorkingModelConditions;

namespace Baumax.Contract.TimePlanning
{

    public interface IWorkingModelData
    {
        int WorkingTimeByMonth
        {
            get;
            set;
        }

        byte CountSunday
        {
            get;
            set;
        }

        byte CountSaturday
        {
            get;
            set;
        }

        byte WorkingDaysBefore
        {
            get;
            set;
        }

        byte WorkingDaysAfter
        {
            get;
            set;
        }
    }
    public interface IPlanningContext
    {
        IAbsenceManager Absences
        {
            get;
        }
        IWorkingModelManager WorkingModels
        {
            get;
        }
        ILongTimeAbsenceManager LongAbsences
        {
            get;
        }
        IStoreDaysList StoreDays
        {
            get;
        }
        ICountryColorManager CountryColors
        {
            get;
        }
        
    }


    public delegate void ChangedContext();

    public interface IRecordingContext : IPlanningContext
    {
        event ChangedContext ChangedContext ;
        long StoreWorldId { get; }
        StoreWorldWeekState WorldPlanningState { get;}
        StoreWorldWeekState WorldActualState { get;}
        bool Modified { get;set;}
        void SetViewDay(DateTime vday);
    }

    public interface IAbsenceManager
    {
        long CountryId
        {
            get;
            set;
        }
        int Count
        {
            get;
        }
        Absence this[long id]
        {
            get;
        }
        Absence GetById(long id);
        string GetAbbreviation(long id);
        Color GetColor(long id, Color def);
        Absence GetByAbbreviation(string charid);
        List<Absence> ToList
        {
            get;
        }
        void FillAbsencePlanningTimes(List<AbsenceTimePlanning> lst);
        void FillAbsencePlanningTimes(AbsenceTimePlanning entity);
        
        void FillEmployeeWeek(List<EmployeeWeek> entities);
        void FillEmployeeWeek(EmployeeWeek entity);
        void FillEmployeeDay(EmployeeDay emplday);
        
    }
    public interface IWorkingModelManager
    {
        long CountryId
        {
            get;
            set;
        }
        List<WorkingModel> List
        {
            get;
        }
        /*WorkingModelWrapper this[long wmid]
        {
            get;
        }*/
        void Calculate(EmployeePlanningWeek planningweek);
        void CalculateNew(EmployeeWeek planningweek, bool bPlanned);
    }

    public interface ILongTimeAbsenceManager
    {
        long CountryId
        {
            get;
            set;
        }
        int Count
        {
            get;
        }
        LongTimeAbsence this[long id]
        {
            get;
        }
        LongTimeAbsence GetById(long id);
        string GetAbbreviation(long id);
        LongTimeAbsence GetByAbbreviation(string charid);
        int? GetColor(long id);
        List<LongTimeAbsence> ToList
        {
            get;
        }
        void FillEmployeelongAbsences(List<EmployeeLongTimeAbsence> list);
    }

    public interface IStoreDaysList
    {
        long StoreId
        {
            get;
        }

        DateTime BeginTime
        {
            get;
        }

        DateTime EndTime
        {
            get;
        }

        double AvgDayInWeek
        {
            get ;
        }

        int CountWorkingDayOnWeek
        {
            get;
        }
        StoreDay this[DateTime dt]
        {
            get;
            set;
        }
        
        bool ContainsKey(DateTime dt);
        bool IsStoreWorkingDay(DateTime date);
        
        bool IsStoreFeastDay(DateTime date);
        
    }

    public interface ICountryColorManager
    {
        long CountryId
        {
            get;
            set;
        }
        int Count
        {
            get;
        }
        Color GetByTypeAndValue(CountryColorValueType type, double value);
        Color GetByTypeAndValue(CountryColorValueType type, double value, Color defColor);
        Color GetColorByEmployeeAdditionalCharges(double value);
        Color GetColorByEmployeePlusMinus(double value);
        Color GetColorByEmployeeBalanceHours(double value);
        Color GetColorByEmployeeAdditionalChargesOverAllEmployee(double value);
        Color GetColorByEmployeePlusMinusOverAllEmployee(double value);
        Color GetColorByEmployeeBalanceHoursOverAllEmployee(double value);
        Color GetColorByDifferenceInPercentPlannedAndEstimatedHours(double value);
    }
}
