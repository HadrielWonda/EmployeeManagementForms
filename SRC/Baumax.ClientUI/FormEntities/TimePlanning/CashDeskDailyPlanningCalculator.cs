using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.QueryResult;
using Baumax.Contract;
using System.Diagnostics;


namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    //public class CashDeskDailyPlanningCalculator
    //{
    //    //  Currently planned Cash desk people units
    //    public int[] PlannedCashDeskUnits = new int[24];
    //    public int CountPlannedUnitsPerDay = 0;
    //    public double CountPlannedUnitsPerHour = 0;


    //    public int[] DifferenceTargetedPlanned = new int[24];
    //    public double[] DifferenceTargetedPlannedBrackets = new double[24];
    //    public int TotalDifferenceTargetedPlanned = 0; 
    //    public int AbsTotalDifferenceTargetedPlanned = 0;
    //    public double TotalDifferenceTargetedPlannedBrackets = 0;
    //    public double AbsTotalDifferenceTargetedPlannedBrackets = 0;


    //    public double[] DifferenceTargetedPlannedPercent = new double[24];
    //    public double[] DifferenceTargetedPlannedBracketsPercent = new double[24];
    //    public double TotalDifferenceTargetedPlannedPercent = 0;
    //    public double AbsTotalDifferenceTargetedPlannedPercent = 0;
    //    public double TotalDifferenceTargetedPlannedBracketsPercent = 0;
    //    public double AbsTotalDifferenceTargetedPlannedBracketsPercent = 0;


    //    CashDeskPlanningInfo _CashDeskInfo = null;

    //    // Targted values
    //    public int[] TargetedCashDeskUnits = new int[24];
    //    public int[] TargetedCashRegister = new int[24];
    //    public double[] TargetedBrackets = new double[24];

    //    public int TotalTargetedCashDeskUnitsPerDay = 0;
    //    public double TotalTargetedBracketsPerDay = 0;
    //    public double TotalTargetedCashDeskUnitsPerHours = 0;
    //    public double TotalTargetedBracketsPerHours = 0;

    //    public double TotalCashDeskRegisterPerDay = 0;
    //    public double TotalCashDeskRegisterPerHour = 0;

    //    public double Value = 35;

        
    //    public void AssignCashDeskInfo(CashDeskPlanningInfo cashdeskinfo, DateTime date)
    //    {
    //        _CashDeskInfo = cashdeskinfo;
    //        if (_CashDeskInfo != null)
    //        {
    //            Value = _CashDeskInfo.CashDeskAmount;
    //            DateCashDeskPeoplePerHour datecashdesk = cashdeskinfo.GetDayCashDeskData(date);
    //            if (datecashdesk != null)
    //            {
    //                for (int i = 0; i < 24; i++)
    //                {
    //                    TargetedCashDeskUnits[i] = datecashdesk.GetPeopleUnits(i);
    //                    TargetedCashRegister[i] = datecashdesk.GetReceipt(i);
    //                }
    //            }
    //            else
    //            {
    //                for (int i = 0; i < 24; i++)
    //                {
    //                    TargetedCashDeskUnits[i] = 0;
    //                    TargetedCashRegister[i] = 0;
    //                }

    //            }

    //            CalculateCashDeskInfo();
    //        }
    //    }

    //    private void CalculateCashDeskInfo()
    //    {
    //        int countNotZeroCashReceipt = 0;
    //        int countNotZeroTargetedHours = 0;

    //        TotalCashDeskRegisterPerDay = 0;
    //        TotalTargetedCashDeskUnitsPerDay = 0;
    //        TotalTargetedBracketsPerDay = 0;
    //        ///////////////////////////////////////////
    //        // Targeted Units and Register calculation
    //        for (int i = 0; i < 24; i++)
    //        {
    //            TargetedBrackets[i] = Math.Round (TargetedCashRegister[i] / Value, 2);

    //            if (TargetedCashRegister[i] != 0)
    //                countNotZeroCashReceipt++;

    //            if (TargetedCashDeskUnits[i] != 0)
    //                countNotZeroTargetedHours++;

    //            TotalTargetedCashDeskUnitsPerDay += TargetedCashDeskUnits[i];
    //            TotalTargetedBracketsPerDay += TargetedBrackets[i];


    //            TotalCashDeskRegisterPerDay += TargetedCashRegister[i];
    //        }

    //        if (countNotZeroTargetedHours != 0)
    //        {
    //            TotalTargetedCashDeskUnitsPerHours = Math.Round ((double)TotalTargetedCashDeskUnitsPerDay / countNotZeroTargetedHours,2);
    //            TotalTargetedBracketsPerHours = Math.Round (TotalTargetedBracketsPerDay / countNotZeroTargetedHours,2);
    //        }
    //        else
    //        {
    //            TotalTargetedCashDeskUnitsPerHours = 0;
    //            TotalTargetedBracketsPerHours = 0;
    //        }
    //        if (countNotZeroCashReceipt != 0)
    //            TotalCashDeskRegisterPerHour = Math.Round (TotalCashDeskRegisterPerDay / countNotZeroCashReceipt,2);
    //        else
    //            TotalCashDeskRegisterPerHour = 0;

    //    }

    //    public void AssignPlannedInfo(int[] unitsPerHour)
    //    {
    //        if (unitsPerHour != null && unitsPerHour.Length == 24)
    //        {
    //            for (int i = 0; i < 24; i++)
    //            {
    //                PlannedCashDeskUnits[i] = unitsPerHour[i];
    //            }
    //        }
    //        if (PlannedCashDeskUnits != null)
    //            Calculate();
    //    }
    //    public void AssignTargetedInfo(int[] unitsPerHour)
    //    {
    //        if (unitsPerHour != null && unitsPerHour.Length == 24)
    //        {
    //            for (int i = 0; i < 24; i++)
    //            {
    //                TargetedCashDeskUnits[i] = unitsPerHour[i];
    //            }
    //        }
    //        if (TargetedCashDeskUnits != null)
    //            CalculateCashDeskInfo();
    //    }
    //    public void Calculate()
    //    {
    //        int countNotZeroPlannedHours = 0;
    //        CountPlannedUnitsPerDay = 0;
    //        ///////////////////////////////////////
    //        // PLanned calculation
    //        for (int i = 0; i < 24; i++)
    //        {
    //            CountPlannedUnitsPerDay += PlannedCashDeskUnits[i];
    //            if (PlannedCashDeskUnits[i] != 0)
    //                countNotZeroPlannedHours++;
    //        }
    //        if (countNotZeroPlannedHours != 0)
    //            CountPlannedUnitsPerHour = Math.Round(CountPlannedUnitsPerDay / (double)countNotZeroPlannedHours, 2);
    //        else
    //            CountPlannedUnitsPerHour = 0;


    //        ///////////////////////////////////////////////////////////

    //        TotalDifferenceTargetedPlanned = 0;
    //        AbsTotalDifferenceTargetedPlanned = 0;
    //        TotalDifferenceTargetedPlannedBrackets = 0;
    //        AbsTotalDifferenceTargetedPlannedBrackets = 0;

    //        TotalDifferenceTargetedPlannedPercent = 0;
    //        AbsTotalDifferenceTargetedPlannedPercent = 0;
    //        TotalDifferenceTargetedPlannedBracketsPercent = 0;
    //        AbsTotalDifferenceTargetedPlannedBracketsPercent = 0;

    //        int iNotZero = 0;
    //        for (int i = 0; i < 24; i++)
    //        {
    //            DifferenceTargetedPlanned[i] = PlannedCashDeskUnits[i] - TargetedCashDeskUnits[i];
    //            DifferenceTargetedPlannedBrackets[i] = PlannedCashDeskUnits[i] - TargetedBrackets[i];

    //            if (TargetedCashDeskUnits[i] != 0)
    //                DifferenceTargetedPlannedPercent[i] = Math.Round((double)(((100 / TargetedCashDeskUnits[i]) * PlannedCashDeskUnits[i]) - 100));
    //            else
    //                DifferenceTargetedPlannedPercent[i] = 0;
    //            if (TargetedBrackets[i] != 0)

    //                DifferenceTargetedPlannedBracketsPercent[i] = Math.Round(((100 / TargetedBrackets[i]) * PlannedCashDeskUnits[i]) - 100);
    //            else
    //                TargetedBrackets[i] = 0;
    //            //Currently planned Cash Desk People Units per day
    //            //CountPlannedUnitsPerDay += PlannedCashDeskUnits[i];



    //            // difference per day
    //            TotalDifferenceTargetedPlanned += DifferenceTargetedPlanned[i];
    //            AbsTotalDifferenceTargetedPlanned += Math.Abs(DifferenceTargetedPlanned[i]);

    //            TotalDifferenceTargetedPlannedBrackets += DifferenceTargetedPlannedBrackets[i];
    //            AbsTotalDifferenceTargetedPlannedBrackets += Math.Abs(DifferenceTargetedPlannedBrackets[i]);
    //            /////////////////////


    //            // percent difference per day
    //            if (DifferenceTargetedPlannedPercent[i]!=0) iNotZero++;

    //            TotalDifferenceTargetedPlannedPercent += DifferenceTargetedPlannedPercent[i];
    //            AbsTotalDifferenceTargetedPlannedPercent += Math.Abs(DifferenceTargetedPlannedPercent[i]);
    //            TotalDifferenceTargetedPlannedBracketsPercent += DifferenceTargetedPlannedBracketsPercent[i];
    //            AbsTotalDifferenceTargetedPlannedBracketsPercent += Math.Abs(DifferenceTargetedPlannedBracketsPercent[i]);

    //        }

    //        if (iNotZero != 0)
    //        {
    //            TotalDifferenceTargetedPlannedPercent /= iNotZero;
    //            AbsTotalDifferenceTargetedPlannedPercent /= iNotZero;
    //            TotalDifferenceTargetedPlannedBracketsPercent /= iNotZero;
    //            AbsTotalDifferenceTargetedPlannedBracketsPercent /= iNotZero;
    //        }
    //    }
    //}


    public class CashDeskDailyPlanningCalculator2
    {
        //  Currently planned Cash desk people units
        public DblArray PlannedCashDeskUnits = new DblArray(24);
        public DblArray TargetedCashDeskUnits = new DblArray(24);
        public DblArray DifferenceTargetedPlannedPercent = new DblArray0(24);
        private CashDeskPlanningInfo _CashDeskInfo = null;

        public CashDeskPlanningInfo CashDeskInfo
        {
            get { return _CashDeskInfo; }
        }

        

        public double AvgCashDeskAmount = 0;
        public int MinPercent = 0;
        public int MaxPercent = 0;

        public void AssignCashDeskInfo(CashDeskPlanningInfo cashdeskinfo, DateTime date)
        {
            _CashDeskInfo = cashdeskinfo;
            
            TargetedCashDeskUnits.Clear();

            if (CashDeskInfo != null)
            {
                AvgCashDeskAmount = CashDeskInfo.CashDeskAmount;
                MinPercent = CashDeskInfo.MinimumPresence;
                MaxPercent = CashDeskInfo.MaximumPresence;

                DateCashDeskPeoplePerHour datecashdesk = CashDeskInfo.GetDayCashDeskData(date);
                TargetedCashDeskUnits = new DblArray50MinMax(24, MinPercent, MaxPercent);
                if (datecashdesk != null)
                {
                    //Random n = new Random(5000);

                    for (int i = 0; i < 24; i++)
                    {
                        if (AvgCashDeskAmount != 0)
                        {
                            //TargetedCashDeskUnits.Elements[i] = n.NextDouble () / AvgCashDeskAmount;
                            TargetedCashDeskUnits.Elements[i] = datecashdesk.GetReceipt(i) / AvgCashDeskAmount;

                            // _GetPeoplePerHour(datecashdesk.GetReceipt(i), AvgCashDeskAmount);
                        }
                        else
                        {
                            TargetedCashDeskUnits.Elements[i] = 0;
                        }
                    }
                }

                TargetedCashDeskUnits.Calculate();
            }
        }

        public void AssignPlannedInfo(int[] unitsPerHour)
        {
            PlannedCashDeskUnits.Clear();
            double m = 60;

            if (unitsPerHour != null && unitsPerHour.Length == 24)
            {
                for (int i = 0; i < 24; i++)
                {
                    PlannedCashDeskUnits.Elements[i] = Math.Round(unitsPerHour[i] / m, 2); 
                }
            }
            PlannedCashDeskUnits.Calculate();
            Calculate();
        }

        public void AssignTargetedInfo(int[] unitsPerHour)
        {
            TargetedCashDeskUnits.Clear();
            double m = 60;
            if (unitsPerHour != null && unitsPerHour.Length == 24)
            {
                for (int i = 0; i < 24; i++)
                {
                    TargetedCashDeskUnits.Elements[i] = Math.Round(unitsPerHour[i] / m, 2); 
                }
            }
            TargetedCashDeskUnits.Calculate();
            Calculate();
        }

        public void Calculate()
        {
            DifferenceTargetedPlannedPercent.DiffInPercent(TargetedCashDeskUnits, PlannedCashDeskUnits);
        }

    }


    //public class CashDeskWeeklyPlanningCalculator
    //{
    //    const int COUNTITEM = 7;
    //    //  Currently planned Cash desk people units
    //    public IntArray PlannedUnits = new IntArray(7);

    //    public IntArray DiffTargetPlanned = new IntArray(7);
    //    public DblArray DiffTargetPlannedBracket = new DblArray(7);

    //    public DblArray DiffTargetPlannedPercent = new DblArray(7);
    //    public DblArray DiffTargetPlannedPercentBracket = new DblArray(7);

    //    CashDeskPlanningInfo _CashDeskInfo = null;

    //    // Targted values
    //    public IntArray TargetUnits = new IntArray(7);
    //    public IntArray TargetCashRegister = new IntArray(7);
    //    public DblArray TargetBrackets = new DblArray(7);

    //    public double AvgCashDeskAmount = 35;

    //    public int MinPercent = 0;
    //    public int MaxPercent = 0;
    //    public void AssignCashDeskInfo(CashDeskPlanningInfo cashdeskinfo, DateTime weekMondayDate)
    //    {
    //        _CashDeskInfo = cashdeskinfo;
    //        if (_CashDeskInfo != null)
    //        {
    //            AvgCashDeskAmount = _CashDeskInfo.CashDeskAmount;
    //            MinPercent = _CashDeskInfo.MinimumPresence;
    //            MaxPercent = _CashDeskInfo.MaximumPresence;

    //            DateTime weekSundayDate = DateTimeHelper.GetSunday(weekMondayDate);
    //            DateTime beginDate = DateTimeHelper.GetMonday(weekMondayDate);

    //            while (beginDate <= weekSundayDate)
    //            {
    //                DateCashDeskPeoplePerHour datecashdesk = cashdeskinfo.GetDayCashDeskData(beginDate);
    //                if (datecashdesk != null)
    //                {
    //                    datecashdesk.Calculate();
    //                    TargetUnits.Elements[(int)datecashdesk.Date.DayOfWeek] = datecashdesk.TotalPerDay;
    //                    TargetCashRegister.Elements[(int)datecashdesk.Date.DayOfWeek] = datecashdesk.TotalReceiptPerDay; 
    //                }
    //                else
    //                {
    //                    TargetUnits.Elements[(int)beginDate.DayOfWeek] = 0;
    //                    TargetCashRegister.Elements[(int)beginDate.DayOfWeek] = 0; 
    //                }

    //                beginDate = beginDate.AddDays(1);
    //            }
    //            CalculateCashDeskInfo();
    //        }
    //        else
    //        {
    //            Clear();
    //            //TargetUnits.Clear();
    //            //TargetCashRegister.Clear();
    //            //TargetBrackets.Clear();
    //        }
    //    }

    //    private void CalculateCashDeskInfo()
    //    {

    //        for (int i = 0; i < COUNTITEM; i++)
    //        {
    //            if (AvgCashDeskAmount != 0)
    //                TargetBrackets.Elements[i] = _GetPeoplePerHour(TargetCashRegister.Elements[i], AvgCashDeskAmount);
    //            else
    //                TargetBrackets.Elements[i] = 0;
    //        }

    //        TargetUnits.Calculate();
    //        TargetCashRegister.Calculate();
    //        TargetBrackets.Calculate();

    //    }

    //    private double _GetPeoplePerHour(double receipts, double avg_cash_desk_amount)
    //    {
    //        double peopleperhour = Math.Round(receipts / avg_cash_desk_amount, 2);

    //        if (peopleperhour > MaxPercent)
    //            peopleperhour = MaxPercent;
    //        else if (peopleperhour < MinPercent)
    //            peopleperhour = MinPercent;

    //        return peopleperhour;

    //    }

    //    public void AssignPlannedInfo(int[] unitsPerDay)
    //    {
    //        if (unitsPerDay != null && unitsPerDay.Length == 7)
    //        {
    //            PlannedUnits.Assign(unitsPerDay);
    //        }
    //        else
    //        {
    //            PlannedUnits.Clear();
    //        }
    //        Calculate();
    //    }
    //    public void AssignTargetedInfo(int[] unitsPerDay)
    //    {
    //        if (unitsPerDay != null && unitsPerDay.Length == 7)
    //        {
    //            TargetUnits.Assign(unitsPerDay);
    //        }
    //        else
    //        {
    //            PlannedUnits.Clear();
    //        }
    //        Calculate();
    //    }
    //    public void Calculate()
    //    {

    //        PlannedUnits.Calculate();

    //        PlannedUnits.Sub(TargetUnits , DiffTargetPlanned);
    //        PlannedUnits.Sub(TargetBrackets, DiffTargetPlannedBracket);

    //        for (int i = 0; i < COUNTITEM; i++)
    //        {

    //            if (TargetUnits.Elements[i] != 0)
    //                DiffTargetPlannedPercent.Elements[i] = Math.Round((double)(((100 / TargetUnits.Elements[i]) * PlannedUnits.Elements[i]) - 100));
    //            else
    //                DiffTargetPlannedPercent.Elements[i] = 0;


    //            if (TargetBrackets.Elements [i] != 0)

    //                DiffTargetPlannedPercentBracket.Elements[i] = Math.Round(((100 /TargetBrackets.Elements [i]) * PlannedUnits.Elements[i]) - 100);
    //            else
    //                DiffTargetPlannedPercentBracket.Elements[i] = 0;

    //        }
    //        DiffTargetPlannedPercent.Calculate();
    //        DiffTargetPlannedPercentBracket.Calculate();
    //    }


    //    public void Clear()
    //    {
    //        PlannedUnits.Clear();
    //        DiffTargetPlanned.Clear();
    //        DiffTargetPlannedBracket.Clear();
    //        DiffTargetPlannedPercent.Clear();
    //        DiffTargetPlannedPercentBracket.Clear();
    //        TargetUnits.Clear();
    //        TargetCashRegister.Clear();
    //        TargetBrackets.Clear();
    //    }
    //}



    public class CashDeskWeeklyPlanningCalculator2
    {
        const int COUNTITEM = 7;
        //  Currently planned Cash desk people units
        public DblArray PlannedUnits = new DblArray(COUNTITEM);

        public DblArray DiffTargetPlannedPercent = new DblArray0(COUNTITEM);

        // Targted values
        public DblArray TargetUnits = new DblArray(COUNTITEM);
        //public double AvgCashDeskAmount = 35;


        public bool UseMinMaxRound = true;

        public CashDeskWeeklyPlanningCalculator2():this(true)
        {

        }
        public CashDeskWeeklyPlanningCalculator2(bool use_min_max)
        {
            UseMinMaxRound = false;
        }
        public void AssignCashDeskInfo(CashDeskPlanningInfo cashdeskinfo, DateTime weekMondayDate)
        {
            CashDeskPlanningInfo CashDeskInfo = cashdeskinfo;
            if (CashDeskInfo != null)
            {
                DateTime sunday = DateTimeHelper.GetSunday(weekMondayDate);
                DateTime index_date = DateTimeHelper.GetMonday(weekMondayDate);
                int index = 0;
                while (index_date <= sunday)
                {
                    index = (int)index_date.DayOfWeek;
                    DateCashDeskPeoplePerHour datecashdesk = cashdeskinfo.GetDayCashDeskData(index_date);
                    if (datecashdesk != null)
                    {
                        TargetUnits[index] = datecashdesk.Calculate2(CashDeskInfo.CashDeskAmount, CashDeskInfo.MinimumPresence, CashDeskInfo.MaximumPresence);
                    }
                    else
                    {
                        TargetUnits[index] = 0;
                    }

                    index_date = index_date.AddDays(1);
                }
                TargetUnits.Calculate();
            }
            else
            {
                Clear();
            }
        }


        public void AssignActualInfo(int[] timePerDay)
        {
            AssignPlannedInfo(timePerDay);
        }
        public void AssignPlannedInfo(int[] timePerDay)
        {
            if (timePerDay != null && timePerDay.Length >= COUNTITEM)
            {
                double m = 60;
                for (int i = 0; i < COUNTITEM; i++)
                {
                    PlannedUnits[i] = Math.Round(timePerDay[i] / m, 2);
                }
            }
            else
            {
                PlannedUnits.Clear();
            }
            Calculate();
        }

        public void AssignTargetedInfo(int[] timePerDay)
        {
            if (timePerDay != null && timePerDay.Length >= COUNTITEM)
            {
                double m = 60;
                for (int i = 0; i < COUNTITEM; i++)
                {
                    TargetUnits[i] = Math.Round(timePerDay[i] / m, 2);
                }
            }
            else
            {
                TargetUnits.Clear();
            }
            //TODO: I think need remove - becouse Targeted method calls one time - as init
            //Calculate();
        }

        public void Calculate()
        {
            PlannedUnits.Calculate();
            TargetUnits.Calculate();

            DiffTargetPlannedPercent.DiffInPercent(TargetUnits, PlannedUnits);
        }

        public void Clear()
        {
            PlannedUnits.Clear();
            DiffTargetPlannedPercent.Clear();
            TargetUnits.Clear();
        }
    }

    public class CashDeskWeeklyPlanningCalculator3
    {
        const int COUNTITEM = 7;
        //  Currently planned Cash desk people units
        public DblArray PlannedUnits = new DblArray(COUNTITEM);

        public DblArray DiffTargetPlannedPercent = new DblArray0(COUNTITEM);

        // Targted values
        public DblArray TargetUnits = new DblArray(COUNTITEM);
        //public double AvgCashDeskAmount = 35;


        public bool UseMinMaxRound = true;

        public CashDeskDailyPlanningCalculator2[] days_calculators = new CashDeskDailyPlanningCalculator2[7];

        public CashDeskWeeklyPlanningCalculator3()
            : this(true)
        {

        }
        public CashDeskWeeklyPlanningCalculator3(bool use_min_max)
        {
            UseMinMaxRound = false;
        }
        public void AssignCashDeskInfo(CashDeskPlanningInfo cashdeskinfo, DateTime weekMondayDate)
        {
            CashDeskPlanningInfo CashDeskInfo = cashdeskinfo;
            if (CashDeskInfo != null)
            {
                DateTime sunday = DateTimeHelper.GetSunday(weekMondayDate);
                DateTime index_date = DateTimeHelper.GetMonday(weekMondayDate);
                int index = 0;
                while (index_date <= sunday)
                {
                    index = (int)index_date.DayOfWeek;
                    DateCashDeskPeoplePerHour datecashdesk = cashdeskinfo.GetDayCashDeskData(index_date);
                    days_calculators[index] = new CashDeskDailyPlanningCalculator2();
                    days_calculators[index].AssignCashDeskInfo(cashdeskinfo, index_date);

                    if (datecashdesk != null)
                    {
                        TargetUnits[index] = datecashdesk.Calculate2(CashDeskInfo.CashDeskAmount, CashDeskInfo.MinimumPresence, CashDeskInfo.MaximumPresence);
                    }
                    else
                    {
                        TargetUnits[index] = 0;
                    }

                    index_date = index_date.AddDays(1);
                }
                TargetUnits.Calculate();
            }
            else
            {
                Clear();
            }
        }


        public void AssignActualInfo(int[] timePerDay, int[][] timeperhours)
        {
            AssignPlannedInfo(timePerDay, timeperhours);
        }
        public void AssignPlannedInfo(SummariesByWorld summary)
        {
            if (summary != null && summary.DaysSum != null && summary.CashDeskUnitsPerHour != null)
            {
                double m = 60;
                for (int i = 0; i < COUNTITEM; i++)
                {
                    PlannedUnits[i] = Math.Round(summary.DaysSum[i] / m, 2);
                    if (days_calculators[i] == null)
                        days_calculators[i] = new CashDeskDailyPlanningCalculator2();
                    days_calculators[i].AssignPlannedInfo(summary.CashDeskUnitsPerHour[i]);
                }
            }
            else
            {
                PlannedUnits.Clear();
            }
            Calculate();
        }
        public void AssignPlannedInfo(int[] timePerDay, int[][] timeperhours)
        {
            if (timePerDay != null && timePerDay.Length >= COUNTITEM)
            {
                double m = 60;
                for (int i = 0; i < COUNTITEM; i++)
                {
                    PlannedUnits[i] = Math.Round(timePerDay[i] / m, 2);
                    if (days_calculators[i] == null)
                        days_calculators[i] = new CashDeskDailyPlanningCalculator2();
                    days_calculators [i].AssignPlannedInfo(timeperhours [i]);
                }
            }
            else
            {
                PlannedUnits.Clear();
            }
            Calculate();
        }

        public void AssignTargetedInfo(int[] timePerDay, int[][] timeperhours)
        {
            if (timePerDay != null && timePerDay.Length >= COUNTITEM)
            {
                double m = 60;
                for (int i = 0; i < COUNTITEM; i++)
                {
                    TargetUnits[i] = Math.Round(timePerDay[i] / m, 2);
                    if (days_calculators[i] == null)
                        days_calculators[i] = new CashDeskDailyPlanningCalculator2();

                    days_calculators [i].AssignTargetedInfo (timeperhours [i]);
                    //days_calculators[i].Calculate();
                }

            }
            else
            {
                TargetUnits.Clear();
            }
            //TODO: I think need remove - becouse Targeted method calls one time - as init
            //Calculate();
        }

        public void Calculate()
        {
            PlannedUnits.Calculate();
            TargetUnits.Calculate();

            for (int i = 0; i < COUNTITEM; i++)
            {
                days_calculators[i].Calculate();
                DiffTargetPlannedPercent[i] = days_calculators[i].DifferenceTargetedPlannedPercent.AbsAverage;
            }
            DiffTargetPlannedPercent.Calculate();// DiffInPercent(TargetUnits, PlannedUnits);
        }

        public void Clear()
        {
            PlannedUnits.Clear();
            DiffTargetPlannedPercent.Clear();
            TargetUnits.Clear();
        }
    }
}
