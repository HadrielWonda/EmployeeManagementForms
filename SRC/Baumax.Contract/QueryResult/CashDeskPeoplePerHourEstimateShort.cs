using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Estimate;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class CashDeskPeoplePerHourEstimateShort
    {
        public DateTime Date;
        public byte Hour;
        public short PeoplePerHour;
        public decimal TargReceiptsPerHour;
    }

    [Serializable]
    public sealed class DateCashDeskPeoplePerHour
    {
        private DateTime _date;
        private short[] _values = new short[24];
        private int[] _receipt = new int[24];
        [NonSerialized]
        private int _TotalPerDay = 0;
        [NonSerialized]
        private double _TotalPerHour = 0;
        [NonSerialized]
        private int _TotalReceiptPerDay = 0;
        [NonSerialized]
        private double _TotalReceiptPerHour = 0;



        public int TotalPerDay
        {
            get { return _TotalPerDay; }
            set { _TotalPerDay = value; }
        }
        public double TotalPerHour
        {
            get { return _TotalPerHour; }
            set { _TotalPerHour = value; }
        }

        public int TotalReceiptPerDay
        {
            get { return _TotalReceiptPerDay; }
            set { _TotalReceiptPerDay = value; }
        }
        public double TotalReceiptPerHour
        {
            get { return _TotalReceiptPerHour; }
            set { _TotalReceiptPerHour = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public short[] GetPeopleUnits()
        {
            short[] array = new short[24];
            _values.CopyTo(array, 0);
            return array;
        }

        public int[] GetReceipts()
        {
            int[] array = new int[24];
            _receipt.CopyTo(array, 0);
            return array;
        }

        public short GetPeopleUnits(int hour)
        {
            if (hour >= 0 && hour < 24)
                return _values[hour];

            throw new ArgumentOutOfRangeException();
        }
        public int GetReceipt(int hour)
        {
            if (hour >= 0 && hour < 24)
                return _receipt[hour];

            throw new ArgumentOutOfRangeException();
        }
        public DateCashDeskPeoplePerHour(DateTime date)
        {
            Date = date;
            for (int i = 0; i < 24; i++)
            {
                _values[i] = 0;
                _receipt[i] = 0;
            }
        }
        public void AddCashDeskPeoplePerHour(CashDeskPeoplePerHourEstimateShort entity)
        {
            if (entity.Date == Date)
            {
                if (entity.Hour >= 0 && entity.Hour < 24)
                {
                    _values[(int)entity.Hour] = entity.PeoplePerHour;
                    _receipt[(int)entity.Hour] = Convert.ToInt32(entity.TargReceiptsPerHour);
                }
            }
        }
        public void AddBusinessVolume(BusinessVolumeCRRSum entity)
        {
            if (entity.Date == Date)
            {
                if (entity.Hour >= 0 && entity.Hour < 24)
                {
                    _values[(int)entity.Hour] = 0;
                    _receipt[(int)entity.Hour] = entity.Number;
                }
            }
        }
        public void Calculate()
        {
            int countNotZeroHours = 0;
            
            _TotalPerDay = 0;
            _TotalPerHour = 0;
            _TotalReceiptPerDay = 0;
            _TotalReceiptPerHour = 0;
            for (int i = 0; i < 24; i++)
            {
                if (_values[i] != 0)
                    countNotZeroHours++;
                _TotalPerDay += _values[i];
                _TotalReceiptPerDay += _receipt[i];
            }

            if (countNotZeroHours > 0)
            {
                _TotalPerHour = _TotalPerDay / (double)countNotZeroHours;
                _TotalReceiptPerHour = _TotalReceiptPerDay / (double)countNotZeroHours;
            }

        }


        public double Calculate2(double avg_cash_desk_amount, int min, int max)
        {
            if (avg_cash_desk_amount == 0) 
                return 0;


            DblArray array = new DblArray50MinMax(24, min, max);
            for (int i = 0; i < 24; i++)
            {
                array[i] = _receipt[i] / avg_cash_desk_amount;
            }

            array.Calculate();

            return array.Sum;
        }




    }
    [Serializable]
    public sealed class DateCashDeskRegisterReceiptPerHour
    {
        private DateTime _date;
        private short[] _values = new short[24];
        private int _TotalPerDay = 0;
        private double _TotalPerHour = 0;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public DateCashDeskRegisterReceiptPerHour(DateTime date)
        {
            Date = date;
            for (int i = 0; i < 24; i++)
            {
                _values[i] = 0;
            }
        }
        public void AddCashDeskPeoplePerHour(CashDeskPeoplePerHourEstimateShort entity)
        {
            if (entity.Date == Date)
            {
                _values[(int)entity.Hour] = entity.PeoplePerHour;
            }
        }

        public void Calculate()
        {
            int countNotZeroHours = 0;
            _TotalPerDay = 0;
            _TotalPerHour = 0;
            for (int i = 0; i < 24; i++)
            {
                if (_values[i] > 0)
                    countNotZeroHours++;
                _TotalPerDay += _values[i];
            }

            if (countNotZeroHours > 0)
                _TotalPerHour = _TotalPerDay / (double)countNotZeroHours;

        }
    }
}
