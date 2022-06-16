using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Domain
{
    public enum CountryColorValueType:byte
    {
        SumOfAdditionalCharges = 1,
        SumOfStillAvailableWorkingHours = 2,
        SumOfCurrentEmployeeBalanceHours = 3,
        SumOfAdditionalChargesOverAllEmployee = 4,
        SumOfStillAvailableWorkingHoursOverAllEmployee = 5,
        SumOfCurrentEmployeeBalanceHoursOverAllEmployee = 6,
        DifferenceInPercentBetweenActualPlannedHoursAndEstimatedHours = 7,
        BenchmarkDifference = 8,
        AbsInPercentForEstimatedWorkingAmount = 9,
        TotalInPercentForEstimatedWorkingAmount = 10,
        ActualAbsInPercentForEstimatedWorkingAmount = 11,
        ActualTotalInPercentForEstimatedWorkingAmount = 12,
        ActualAbsInPercentForPlannedWorkingAmount = 13,
        ActualTotalInPercentForPlannedWorkingAmount = 14
    }
}
