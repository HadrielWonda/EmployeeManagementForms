using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System.Collections;

namespace Baumax.Contract
{
    public interface IEmployeeTimeRange
    {
        long EmployeeID { get;set;}
        short Begin { get;set;}
        short End { get;set;}
        //decimal Days { get; }
        short Time { get; set;}
        long AbsenceID { get;set;}
        DateTime Date { get;set;}
        Absence Absence { get;set;}
    }

    public interface IEmployeeWeek
    {
        long ID { get;set; }

        bool IsPlannedWeek { get;}

        long EmployeeID
        {
            get;
            set;
        }

        long OrderHWGR
        { 
            get; 
            set;
        }

        int WorkingHours
        {
            get;
            set;
        }

        byte WeekNumber
        {
            get;
            set;
        }

        DateTime WeekBegin
        {
            get;
            set;
        }

        DateTime WeekEnd
        {
            get;
            set;
        }

        int PlusMinusHours
        {
            get;
            set;
        }

        int Saldo
        {
            get;
            set;
        }

        int PlannedHours
        {
            get;
            set;
        }

        int ContractHours
        {
            get;
            set;
        }

        int AdditionalCharge
        {
            get ;
            set ;
        }
        bool CustomEdit
        {
            get;
            set;
        }
        bool AllIn
        {
            get;
            set;
        }
    }


    public interface IBaumaxEmployeeWeek
    {
        bool CustomEdit
        {
            get;
            set;
        }
        bool PlannedWeek
        {
            get ;
            set;
        }
        int WorkingTimeByMonth
        {
            get  ; 
            set  ; 
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
        }
        byte WorkingDaysAfter
        {
            get;
        }
        bool IsSundayWorking
        {
            get;
        }
        bool IsSaturdayWorking
        {
            get;
        }
        int CountWorkingSundayPerMonth
        {
            get;
        }
        int CountWorkingSundayAndSaturdayPerMonth
        {
            get;
        }

        int ContractHoursPerWeek
        {
            get ;
            set ;
        }

        long EmployeeId
        {
            get ;
            set ;
        }


        string FullName
        {
            get;
        }
        DateTime BeginDate
        {
            get ;
            set ;
        }

        DateTime EndDate
        {
            get ;
            set ;
        }
        int CountWeeklyPlanningWorkingHours
        {
            get ;
            set ;
        }



        int CountWeeklyPlusMinusHours
        {
            get ;
            set ;
        }



        int CountWeeklyAdditionalCharges
        {
            get ;
            set ;
        }



        int CountWeeklyWorkingHours
        {
            get ;
            set ;
        }


        int Saldo
        {
            get ;
            set ;
        }


        int LastSaldo
        {
            get ;
            set ;
        }

        EmployeeDay GetDay(DateTime date);


        IList DaysList
        {
            get;
        }

        bool IsHasWorld(long worldid);

        bool IsHasWorldByDate(long worldid, DateTime date);

        int CountPlannedHoursByWorld(long worldid);

        void CalculateBeforeWorkingModels();
        void CalculateAfterWorkingModels();
    }


    public interface IEmployeeDay
    {
        #region Public Properties

        int WorkingHours
        {
            get;
            set;
        }

        DateTime Date
        {
            get;
            set;
        }

        int AllreadyPlannedHours
        {
            get;
            set;
        }

        int SumOfAddHours
        {
            get;
            set;
        }

        int PlusMinusHours
        {
            get;
            set;
        }

        int EmplBalanceHours
        {
            get;
            set;
        }

        long EmployeeID
        {
            get;
            set;
        }
        long StoreWorldId
        {
            get;
            set;
        }
        #endregion
    }
}
