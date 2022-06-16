using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.TimePlanning
{
    public class WeeklyDaysSum
    {
        int[] _sums = new int[8];

        int _TotalContractWorkingHours = 0;
        int _TotalPlannedHours = 0;
        int _TotalAdditionalCharges = 0;
        int _TotalPlusMinusHours = 0;
        int _TotalSaldo = 0;

        public int this[DayOfWeek dayofweek]
        {
            get { return _sums[(int)dayofweek]; }
            set { _sums[(int)dayofweek] = value; }
        }

        public void BuildTotals()
        {
            _sums[7] = 0;
            for (int i = 0; i < 7; i++)
            {
                _sums[7] += _sums[i];
            }
        }
        public void Clear()
        {
            for (int i = 0; i < 8; i++)
            {
                _sums[i] = 0;
            }
            _sums[7] = Int32.MinValue;
            _TotalContractWorkingHours = 0;
            _TotalPlannedHours = 0;
            _TotalAdditionalCharges = 0;
            _TotalPlusMinusHours = 0;
            _TotalSaldo = 0;
        }

        public int TotalSum
        {
            get
            {
                if (_sums[7] == Int32.MinValue)
                    BuildTotals();
                return _sums[7];
            }
        }

        public int[] GetSums()
        {
            int[] sums = new int[8];
            _sums.CopyTo(sums, 0);
            return sums;
        }

        public int TotalPlannedHours
        {
            get { return _TotalPlannedHours; }
            set { _TotalPlannedHours = value; }
        }
        public int TotalContractWorkingHours
        {
            get { return _TotalContractWorkingHours; }
            set { _TotalContractWorkingHours = value; }
        }

        public int TotalAdditionalCharges
        {
            get { return _TotalAdditionalCharges; }
            set { _TotalAdditionalCharges = value; }
        }


        public int TotalPlusMinusHours
        {
            get { return _TotalPlusMinusHours; }
            set { _TotalPlusMinusHours = value; }
        }


        public int TotalSaldo
        {
            get { return _TotalSaldo; }
            set { _TotalSaldo = value; }
        }

    }

    public class WeeklyDaysUnitSum
    {
        int[] _sums = new int[7];

        public int this[DayOfWeek dayofweek]
        {
            get { return _sums[(int)dayofweek]; }
            set { _sums[(int)dayofweek] = value; }
        }

        public int[] GetSums()
        {
            int[] ar = new int[7];
            _sums.CopyTo(ar, 0);
            return ar;
        }
        public void Clear()
        {
            for (int i = 0; i < 7; i++)
            {
                _sums[i] = 0;
            }
        }
    }
}
