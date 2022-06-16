using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Domain
{
    public enum PersShowModeType : byte { PersonalID = 1, PersonalNumber = 2, All = 3 }

    public enum InUseEntity { Absence, AvgWorkingDaysInWeek, WorkingModel }

    public enum AbsenceType: byte { Absence = 1, Holiday = 2, Illness = 3 }

    public enum AbsencePlanningView
    {
        YearlyView = 1,
        MonthlyView = 2,
        WeeklyView = 3
    }

    [Flags]
    public enum WeeksDayMask:int
    {
        Empty = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    [Flags]
    public enum ConditionTypes:int
    {
        Empty = 0,
        DurationOfWorkingTime = 1,
        DurationOfWorkingTimeSingleDay = 2,
        DurationOfWorkingTimeByWeek = 4,
        DurationOfWorkingTimeByMonth = 8,
        DurationOfWorkingDay = 16,
        TimeBetweenPreviousDayWorkingTime = 32,
        WorkingTimeOutOfOpeningTimeOfStore = 64,
        WorkingTimeBetweenSeveralHours = 128,
        WorkingOnSpecialWeekdays = 256,
        WorkingOverEmployeeContractTime = 512,
        WorkingOverEmployeeCurrentBalanceHours = 1024,
        BalanceHoursReachesCertainAmount = 2048,
        BalanceHoursMustBeZeroEveryWeekMonthYear = 4096,
        WorkingOnFeast = 8192,
        WorkingOnSunday = 16384,
        WorkingOnSaturdayOrSunday = 32768,
        SaldoOnCertainWeeks = 65536
    }

	public enum WorldType : byte
	{
		Administration = 1,
		CashDesk = 2,
		World = 3
	}

    public enum WeekStateType : byte 
    { 
        Normal = 0
    }

    public enum WorkingModelType : byte
    {
        WorkingModel = 0,
        LunchModel = 1
    }

    public enum IsShowAbsence : byte
    { 
        PlanningRecording = 1,
        Planning = 2,
        Recording = 3,
        None = 4
    }

}
