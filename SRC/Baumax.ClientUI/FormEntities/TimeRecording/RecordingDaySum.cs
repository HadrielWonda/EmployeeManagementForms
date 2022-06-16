using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public class RecordingDaySum
    {
        const int MAXRANGES = 24 * 4;
        const int HOURS = 24;
        public int[] _plannedSum = new int[MAXRANGES];
        public int[] _actualSum = new int[MAXRANGES];

        public int[] _plannedSumUnits = new int[HOURS];
        public int[] _actualSumUnits = new int[HOURS];


        public int TotalContractHours = 0;
        public int TotalPlannedHours = 0;
        public int TotalAdditionalHours = 0;
        public int TotalPlusMinusHours = 0;
        public int TotalSaldo = 0;

        public int TotalActualContractHours = 0;
        public int TotalActualPlannedHours = 0;
        public int TotalActualAdditionalHours = 0;
        public int TotalActualPlusMinusHours = 0;
        public int TotalActualSaldo = 0;

        public int TotalActualWorkingHours = 0;

        public int[] GetPlannedUnits()
        {
            return _plannedSumUnits;
        }
        public int[] GetTargetedUnits()
        {
            return _actualSumUnits;
        }
        public int GetPlannedSum(int fromtime, int totime)
        {
            int resultSum = 0;
            for (int i = fromtime; i < totime; i+=15)
            {
                resultSum += _plannedSum[(int)(i / 15)];
            }
            return resultSum;
        }
        public int GetActualSum(int fromtime, int totime)
        {
            int resultSum = 0;
            for (int i = fromtime; i < totime; i += 15)
            {
                resultSum += _actualSum[(int)(i / 15)];
            }
            return resultSum;
        }

        public void Clear()
        {
            for (int i = 0; i < MAXRANGES; i++)
			{
                _plannedSum[i] = _actualSum[i] = 0;
                
			}
            for (int i = 0; i < HOURS; i++)
            {
                _plannedSumUnits[i] = _actualSumUnits[i] = 0;
            }
            TotalContractHours = 0;
            TotalPlannedHours = 0;
            TotalAdditionalHours = 0;
            TotalPlusMinusHours = 0;
            TotalSaldo = 0;

            TotalActualContractHours = 0;
            TotalActualPlannedHours = 0;
            TotalActualAdditionalHours = 0;
            TotalActualPlusMinusHours = 0;
            TotalActualSaldo = 0;

            TotalActualWorkingHours = 0;
        }


        public void AddRange(IList lst)
        {
            Clear();

            if (lst != null && lst.Count > 0)
            {
                RecordingDayView plannedView = null;
                RecordingDayView actualView = null;

                foreach (RecordingDayRow row in lst)
                {
                    plannedView = row.PlannedView;
                    actualView = row.ActualView;
                    short time = 0;
                    for (int i = 0; i < MAXRANGES; i++)
                    {
                        time = (short)(i*15);
                        if (plannedView.IsWorkingTime(time))
                            _plannedSum[i] += 15;
                        if (actualView.IsWorkingTime(time))
                        {
                            _actualSum[i] += 15;
                            TotalActualWorkingHours += 15;
                        }
                    }
                    TotalContractHours += row.PlannedWeek.ContractHoursPerWeek;
                    TotalActualContractHours = row.ActualWeek.ContractHoursPerWeek;

                    TotalPlannedHours += row.PlannedDay.CountDailyPlannedWorkingHours ;
                    TotalActualPlannedHours += row.ActualDay.CountDailyPlannedWorkingHours;

                    TotalAdditionalHours += row.PlannedDay.CountDailyAdditionalCharges ;
                    TotalActualAdditionalHours += row.ActualDay.CountDailyAdditionalCharges;

                    TotalPlusMinusHours += row.PlannedWeek.CountWeeklyPlusMinusHours;
                    TotalActualPlusMinusHours += row.ActualWeek.CountWeeklyPlusMinusHours;

                    TotalSaldo += row.PlannedWeek.Saldo;
                    TotalActualSaldo += row.ActualWeek.Saldo;

                }
                //int max = 0;
                for (int i = 0; i < HOURS; i++)
                {
                    _plannedSumUnits[i] = GetSumPerHour(i, _plannedSum);
                    _actualSumUnits[i] = GetSumPerHour(i, _actualSum);

                }

            }
        }

        private int GetUnitsPerHour(int hour, int[] sums)
        {
            int beginHour = hour * 4;

            int max = Int32.MinValue;
            max = Math.Max(max, sums[beginHour]);
            max = Math.Max(max, sums[beginHour+1]);
            max = Math.Max(max, sums[beginHour + 2]);
            max = Math.Max(max, sums[beginHour + 3]);
            return max / 15;
        }
        private int GetSumPerHour(int hour, int[] sums)
        {
            int beginHour = hour * 4;

            int value = 0;
            value += sums[beginHour];
            value += sums[beginHour+1];
            value += sums[beginHour+2];
            value += sums[beginHour+3];
            return value;
        }
    }
}
