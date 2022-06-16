using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Baumax.Contract
{
    [Serializable]
    public class IntArray
    {
        public int[] Elements = null;
        public int Sum = 0;
        public double Average = 0;
        public int AbsSum = 0;
        public double AbsAverage = 0;
        public int CountNotZeroItems = 0;
        public void CreateArray(int size)
        {
            Elements = new int[size];
            Sum = 0;
            Average = 0;
            AbsSum = 0;
            AbsAverage = 0;
            CountNotZeroItems = 0;
        }

        public IntArray(int size)
        {
            CreateArray(size);
        }

        public void Assign(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            Elements = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                Elements[i] = arr[i];
            }
            Calculate();
        }
        public void Calculate()
        {
            if (Elements == null)
                throw new ArgumentNullException();
            CountNotZeroItems = 0;
            Sum = 0;
            Average = 0;
            for (int i = 0; i < Elements.Length; i++)
            {
                if (Elements[i] != 0)
                {
                    CountNotZeroItems++;
                    Sum += Elements[i];
                    AbsSum += Math.Abs(Elements[i]);
                }
            }
            if (CountNotZeroItems > 0)
            {
                Average = Sum / (double)CountNotZeroItems;
                AbsAverage = AbsSum / (double)CountNotZeroItems;
            }
        }
        public void Clear()
        {
            Sum = 0;
            Average = 0;
            AbsSum = 0;
            AbsAverage = 0;
            CountNotZeroItems = 0;
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = 0;
            }
        }


        public IntArray Sub(IntArray arr, IntArray res)
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                res.Elements[i] = Elements[i] - arr.Elements[i];
            }
            res.Calculate();
            return res;
        }
        public DblArray Sub(DblArray arr, DblArray res)
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                res.Elements[i] = Elements[i] - arr.Elements[i];
            }
            res.Calculate();
            return res;
        }

    }

    [Serializable]
    public class IntArrayTP
    {
        #region fields

        private int[] _Elements = null;
        [NonSerialized]
        private int _Sum = 0;
        [NonSerialized]
        private double _Average = 0;
        [NonSerialized]
        private int _AbsSum = 0;
        [NonSerialized]
        private double _AbsAverage = 0;
        [NonSerialized]
        private int _PosSum = 0;
        [NonSerialized]
        private int _NegSum = 0;
        [NonSerialized]
        private int _CountNotZeroItems = 0;
        [NonSerialized]
        private int _CountPosNotZeroItems = 0;
        [NonSerialized]
        private int _CountNegNotZeroItems = 0;

        #endregion

        #region properties

        public int Count
        {
            get
            {
                if (_Elements != null)
                    return _Elements.Length;
                return 0;
            }
            set
            {
                if (Count != value)
                {
                    CreateArray(value);
                }
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return _Elements[index];
                }
#if DEBUG
                throw new IndexOutOfRangeException("IntArrayTimePlanning out of index");
#else
                return 0;
#endif
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    _Elements[index] = value;
                }
                else
                {
#if DEBUG
                    throw new IndexOutOfRangeException("IntArrayTimePlanning out of index");
#endif
                }

            }
        }

        public int TotalSum
        {
            get { return _Sum; }
            protected set { _Sum = value; }
        }
        public int AbsTotalSum
        {
            get { return _AbsSum; }
            protected set { _AbsSum = value; }
        }
        public int PosTotalSum
        {
            get { return _PosSum; }
            protected set { _PosSum = value; }
        }
        public int NegTotalSum
        {
            get { return _NegSum; }
            protected set { _NegSum = value; }
        }

        public double AverageTotalSum
        {
            get { return _Average; }
            protected set { _Average = value; }
        }
        
        public double AbsAverageTotalSum
        {
            get { return _AbsAverage; }
            protected set { _AbsAverage = value; }
        }

        public int CountNotZeroNumber
        {
            get { return _CountNotZeroItems; }
            protected set { _CountNotZeroItems = value; }
        }
        public int CountPositiveNotZeroNumber
        {
            get { return _CountPosNotZeroItems; }
            protected set { _CountPosNotZeroItems = value; }
        }
        public int CountNegativeNotZeroNumber
        {
            get { return _CountNegNotZeroItems; }
            protected set { _CountNegNotZeroItems = value; }
        }

        #endregion

        protected virtual void CreateArray(int size)
        {
            _Elements = new int[size];
            Clear();
        }

        public IntArrayTP(int size)
        {
            Count = size;
        }

        public virtual void Assign(int[] arr)
        {
            if (arr == null)
                return ;

            Count = arr.Length;

            if (Count > 0)
            {
                arr.CopyTo(_Elements, 0);
            }
            Calculate();
        }
        public virtual void Calculate()
        {
            ClearSum();

            if (Count == 0)
                return;

            

            for (int i = 0; i < Count; i++)
            {
                ProcessNumber(this[i]);
            }

            AfterCalculation();
        }
        protected virtual void AfterCalculation()
        {
            if (CountNotZeroNumber > 0)
            {
                double c = CountNotZeroNumber;
                AverageTotalSum = TotalSum / c;
                AbsAverageTotalSum = AbsTotalSum / c;
            }
        }
        protected virtual void ProcessNumber(int value)
        {
            if (value != 0)
            {
                CountNotZeroNumber++;
                if (value >= 0)
                {
                    CountPositiveNotZeroNumber++;
                    PosTotalSum += value;
                }
                else
                {
                    CountNegativeNotZeroNumber++;
                    NegTotalSum += value;
                }

                TotalSum += value;
                AbsTotalSum += Math.Abs(value);
            }
        }
        protected virtual void ClearSum()
        {
            TotalSum = 0;
            AbsTotalSum = 0;
            PosTotalSum = 0;
            NegTotalSum = 0;
            AverageTotalSum = 0;
            AbsAverageTotalSum = 0;
            CountNotZeroNumber = 0;
            CountPositiveNotZeroNumber = 0;
            CountNegativeNotZeroNumber = 0;
        }
        public virtual void Clear()
        {
            ClearSum();
            for (int i = 0; i < Count; i++)
            {
                this[i] = 0;
            }
        }

        public virtual string Dump()
        {
            StringBuilder sb = new StringBuilder(200);
            for (int i = 0; i < Count; i++)
            {
                if (sb.Length > 0)
                    sb.Append(";");
                sb.Append(this[i].ToString());
            }
            sb.AppendLine();

            sb.AppendFormat(@"Sum={0}; AbsSum={1}; PositiveSum={2}; NegativeSum={3}; \n
                              AverageSum = {4}; AverageAbsSum = {5}", 
                            new object[] {TotalSum, AbsTotalSum, PosTotalSum, NegTotalSum, 
                                            AverageTotalSum, AbsAverageTotalSum});

            return sb.ToString();

        }
    }
    [Serializable]
    public class PercentArray
    {
        #region fields

        private double[] _Elements = null;
        
        private double _Sum = 0;
        private double _Average = 0;

        private double _AbsSum = 0;
        private double _AbsAverage = 0;

        private double _PosSum = 0;
        private double _AvgPosSum = 0;
        
        private double _NegSum = 0;
        private double _AvgNegSum = 0;

        private int _CountNotZeroItems = 0;
        private int _CountPosNotZeroItems = 0;
        private int _CountNegNotZeroItems = 0;

        #endregion

        #region properties

        public int Count
        {
            get
            {
                if (_Elements != null)
                    return _Elements.Length;
                return 0;
            }
            set
            {
                if (Count != value)
                {
                    CreateArray(value);
                }
            }
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return _Elements[index];
                }
#if DEBUG
                throw new IndexOutOfRangeException("PercentArray out of index");
#else
                return 0;
#endif
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    _Elements[index] = value;
                }
                else
                {
#if DEBUG
                    throw new IndexOutOfRangeException("PercentArray out of index");
#endif
                }

            }
        }

        public double TotalSum
        {
            get { return _Sum; }
            protected set { _Sum = value; }
        }
        public double AbsTotalSum
        {
            get { return _AbsSum; }
            protected set { _AbsSum = value; }
        }
        public double PosTotalSum
        {
            get { return _PosSum; }
            protected set { _PosSum = value; }
        }
        public double NegTotalSum
        {
            get { return _NegSum; }
            protected set { _NegSum = value; }
        }

        public double AverageTotalSum
        {
            get { return _Average; }
            protected set { _Average = value; }
        }

        public double AbsAverageTotalSum
        {
            get { return _AbsAverage; }
            protected set { _AbsAverage = value; }
        }

        public int CountNotZeroNumber
        {
            get { return _CountNotZeroItems; }
            protected set { _CountNotZeroItems = value; }
        }
        public int CountPositiveNotZeroNumber
        {
            get { return _CountPosNotZeroItems; }
            protected set { _CountPosNotZeroItems = value; }
        }
        public int CountNegativeNotZeroNumber
        {
            get { return _CountNegNotZeroItems; }
            protected set { _CountNegNotZeroItems = value; }
        }
        public double AvgNegTotalSum
        {
            get { return _AvgNegSum; }
            protected set { _AvgNegSum = value; }
        }
        public double AvgPosTotalSum
        {
            get { return _AvgPosSum; }
            protected set { _AvgPosSum = value; }
        }
        #endregion

        protected virtual void CreateArray(int size)
        {
            _Elements = new double[size];
            Clear();
        }

        public PercentArray(int size)
        {
            Count = size;
        }

        public virtual void Assign(double[] arr)
        {
            if (arr == null)
                return ;

            Count = arr.Length;

            if (Count > 0)
            {
                arr.CopyTo(_Elements, 0);
            }
            CalculateTotalSums();
        }
        public virtual void CalculateTotalSums()
        {
            if (Count == 0)
                return;

            ClearSum();

            for (int i = 0; i < Count; i++)
            {
                ProcessNumber(this[i]);
            }

            AfterCalculationTotalSums();
        }
        protected virtual void AfterCalculationTotalSums()
        {
            if (CountNotZeroNumber > 0)
            {
                double c = CountNotZeroNumber;
                AverageTotalSum = Round(TotalSum / c);
                AbsAverageTotalSum = Round(AbsTotalSum / c);
            }

            if (CountPositiveNotZeroNumber > 0)
            {
                double c = CountPositiveNotZeroNumber;
                AvgPosTotalSum = Round(PosTotalSum / c);
            }
            if (CountNegativeNotZeroNumber > 0)
            {
                double c = CountNegativeNotZeroNumber;
                AvgNegTotalSum = Round(NegTotalSum / c);
            }
        }
        protected virtual void ProcessNumber(double value)
        {
            if (value != 0)
            {
                CountNotZeroNumber++;
                if (value >= 0)
                {
                    CountPositiveNotZeroNumber++;
                    PosTotalSum += value;
                }
                else
                {
                    CountNegativeNotZeroNumber++;
                    NegTotalSum += value;
                }

                TotalSum += value;
                AbsTotalSum += Math.Abs(value);
            }
        }
        protected virtual void ClearSum()
        {
            TotalSum = 0;
            AbsTotalSum = 0;
            PosTotalSum = 0;
            NegTotalSum = 0;

            AverageTotalSum = 100.0;
            AbsAverageTotalSum = 100.0;
            AvgNegTotalSum = 0;
            AvgPosTotalSum = 0;

            CountNotZeroNumber = 0;
            CountPositiveNotZeroNumber = 0;
            CountNegativeNotZeroNumber = 0;
        }
        public virtual void Clear()
        {
            ClearSum();
            for (int i = 0; i < Count; i++)
            {
                this[i] = 0;
            }
        }

        public void BuildPercent(IntArrayTP top, IntArrayTP bottom)
        {
            Clear();

            if (top == null || bottom == null) return;
            if (top.Count != bottom.Count) return;

            Count = top.Count;

            int top_number = 0;
            int bottom_number = 0;
            int diff_number = 0;
            double diff_percent = 0;
            for (int i = 0; i < Count; i++)
            {
                top_number = top[i];
                bottom_number = bottom[i];
                diff_number = bottom_number - top_number;

                diff_percent = 0.0;
                if (top_number != 0)
                    diff_percent = Round((100.0 / top_number) * diff_number);

                this[i] = diff_percent;
            }

            CalculateTotalSums();
        }

        protected virtual double Round(double value)
        {
            return Math.Round(value, 1);
        }

        public virtual string Dump()
        {
            StringBuilder sb = new StringBuilder(200);
            for (int i = 0; i < Count; i++)
            {
                if (sb.Length > 0)
                    sb.Append(";");
                sb.Append(this[i].ToString());
            }
            sb.AppendLine();

            sb.AppendFormat(@"Sum={0}; AbsSum={1}; PositiveSum={2}; NegativeSum={3}; \n
                              AverageSum = {4}; AverageAbsSum = {5}; AvgNegSum = {6} AvgPosSum = {7}",
                            new object[] {TotalSum, AbsTotalSum, PosTotalSum, NegTotalSum, 
                                            AverageTotalSum, AbsAverageTotalSum, AvgNegTotalSum, AvgPosTotalSum});

            return sb.ToString();

        }
    }

    [Serializable]
    public class DblArray
    {
        public double[] Elements = null;
        public double Sum = 0;
        public double Average = 0;
        public double AbsSum = 0;
        public double AbsAverage = 0;
        public int CountNotZeroItems = 0;

        public void CreateArray(int size)
        {
            Elements = new double[size];
            Sum = 0;
            Average = 0;
            AbsSum = 0;
            AbsAverage = 0;
        }

        public DblArray(int size)
        {
            CreateArray(size);
        }
        public double this[int i]
        {
            get { return Elements[i]; }
            set { Elements[i] = value; }
        }
        public void Assign(double[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            Elements = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Elements[i] = arr[i];
            }
            Calculate();
        }

        public virtual void Calculate()
        {
            CountNotZeroItems = 0;
            Sum = 0;
            Average = 0;
            AbsSum = 0;
            AbsAverage = 0;
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = Round(Elements[i]); 
                if (Elements[i] != 0)
                {
                    CountNotZeroItems++;
                    Sum += Elements[i];
                    AbsSum += Math.Abs(Elements[i]);
                }
            }
            if (CountNotZeroItems > 0)
            {
                Average = Round(Sum / CountNotZeroItems);
                AbsAverage = Round(AbsSum / CountNotZeroItems);
            }
        }

        public void Clear()
        {
            Sum = 0;
            Average = 0;
            AbsAverage = 0;
            AbsSum = 0;
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = 0;
            }
        }

        public virtual double Round(double value)
        {
            return Math.Round(value,2);
        }
        public virtual void DiffInPercent(DblArray targeted, DblArray planned)
        {

            Debug.Assert(targeted.Elements != null);
            Debug.Assert(planned.Elements != null);
            Debug.Assert(targeted.Elements.Length == planned.Elements.Length);

            Clear();

            if (Elements == null || Elements.Length != targeted.Elements.Length)
                CreateArray(targeted.Elements.Length);
            int count_not_zero_item = 0;
            for (int i = 0; i < targeted.Elements.Length; i++)
            {
                Elements[i] = 0;
                if (targeted.Elements[i] != 0)
                {
                    Elements[i] = Round((double)(((100 / targeted.Elements[i]) * planned.Elements[i]) - 100));
                    count_not_zero_item++;
                    Sum += Elements[i];
                    AbsSum += Math.Abs(Elements[i]);
                }
            }
            if (count_not_zero_item > 0)
            {
                Average = Round(Sum / count_not_zero_item);
                AbsAverage = Round(AbsSum / count_not_zero_item);
            }
//            Sum = Math.Round(Sum);
//            AbsSum = Math.Round(AbsSum);
//            Average = Math.Round(Average);
//            AbsAverage = Math.Round(AbsAverage);

        }
    }

    [Serializable]
    public class DblArray50 : DblArray 
    {
        public DblArray50(int size) : base(size) { }
        public override double Round(double value)
        {
            double d = Math.Round(value, 2);

            double right = d - Math.Truncate(d);

            if (right != 0)
            {
                if (right < 0.5)
                    right = 0.5;
                else
                    right = 1;
            }
            d = Math.Truncate(d) + right;

            return d;
        }
        //public override double Round(double value)
        //{
        //    value = Math.Round(value, 2);
        //    int integer_value = 0;
        //    double part_of_value = 0;
        //    bool bSign = false;

        //    bSign = (value < 0);

        //    value = Math.Abs(value);

        //    integer_value = (int)value;

        //    part_of_value = value - integer_value;

        //    if (part_of_value != 0)
        //    {
        //        int d = (int)(part_of_value * 100);
        //        int module = d % 50;

        //        if (module != 0)
        //        {
        //            if (module < 25)
        //                d = d - module;
        //            else
        //                d += (50 - module);
        //        }
        //        part_of_value = d / (double)100;
        //        value = integer_value + part_of_value;

        //    }
        //    return (bSign) ? -value : value;
        //}
    }

    [Serializable]
    public class DblArray25 : DblArray
    {
        public DblArray25(int size):base(size){}
        public override double Round(double value)
        {
            value = Math.Round(value, 2);
            int integer_value = 0;
            double part_of_value = 0;
            bool bSign = false;

            bSign = (value < 0);

            value = Math.Abs(value);

            integer_value = (int)value;

            part_of_value = value - integer_value;

            if (part_of_value != 0)
            {
                int d = (int)(part_of_value * 100);
                int module = d % 25;

                if (module != 0)
                {
                    if (module < 13)
                        d = d - module;
                    else
                        d += (25 - module);
                }
                part_of_value = d / (double)100;
                value = integer_value + part_of_value;

            }
            return (bSign) ? -value : value;
        }
    }
    [Serializable]
    public class DblArray0 : DblArray
    {
        public DblArray0(int size):base(size){}
        public override double Round(double value)
        {
            return Math.Round(value, 0);
        }
    }
    // for targeted hours need that Min<=Value<=Max and round to half hour
    public class DblArray50MinMax : DblArray50
    {
        private int _min = 0;
        private int _max = 0;
        public DblArray50MinMax(int size, int min,int max) : base(size)
        {
            _min = min;
            _max = max;
        }
        public override double Round(double value)
        {
            if (value == 0) 
                return 0;
            
            if (value > _max)
                value = _max;
            else if (value < _min)
                value = _min;

            return base.Round(value);
            
        }
    }
}
