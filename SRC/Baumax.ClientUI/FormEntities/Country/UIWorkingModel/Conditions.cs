using System;
using System.ComponentModel;
using System.Text;
using Baumax.Domain;
using Baumax.Localization;
using Baumax.Contract.WorkingModelConditions;
using System.Globalization;
using System.Collections.Generic;

namespace Baumax.ClientUI.FormEntities.Country.UIWorkingModel
{
    
    public delegate void WMItemCheckedChanged(BaseWMItemView item);

    public class BaseWMItemView
    {
        #region fields

        private bool _checked;
        private ConditionTypes _type;
        private string _conditionname;
        private object _value;
        private WMItemList _parent = null;
        #endregion


        #region Properties

        public bool Checked
        {
            get { return _checked; }
            set 
            { 
                if (_checked != value)
                {
                    _checked = value;
                    if (_parent != null)
                        _parent.ChangeState(this);
                }
            }
        }
        

        public ConditionTypes Type
        {
            get { return _type; }
            set { _type = value; }
        }
        

        public string ConditionName
        {
            get { return _conditionname; }
            set { _conditionname = value; }
        }
        

        public object Value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                InitValue();
            }
        }


        
        #endregion


        #region  virtual functions and properties

        protected virtual void InitValue(){}

        public virtual string StringValue
        {
            get
            {
                return String.Format("{0}={1}", (int)Type, 0);
            }
            set
            {
                Value = value;
            }
        }

        public virtual string DisplayString
        {
            get {return String.Empty ;}
        }

        #endregion

        public BaseWMItemView(ConditionTypes type, object value, WMItemList parent)
        {
            Type = type;
            Value = value;
            _parent = parent;
            InitValue();
            UpdateName();
        }

        public void UpdateName()
        {
            ConditionName = ConditionHelper.GetConditionName(Type);
        }
    }

    public class SpecialDayWMItemView : BaseWMItemView
    {

        public SpecialDayWMItemView(ConditionTypes type, object value, WMItemList parent):base(type,value,parent)
        {
        }

        private WeeksDayMask _days;

        public WeeksDayMask DayMasks
        {
            get { return _days; }
            set { _days = value; }
        }

        public override string DisplayString
        {
            get
            {
                return DaysHelper.DaysToString(_days);
            }
        }
        protected override void InitValue()
        {
            _days = (WeeksDayMask)Convert.ToInt32(Value);
        }
       

        public override string StringValue
        {
            get
            {
                return String.Format("{0}={1}", (int)Type, (int)DayMasks); ;
            }
            set
            {
                DayMasks = (WeeksDayMask)Convert.ToInt32(value);
            }
        }
    }

    public class EveryItemWMItemView : BaseWMItemView
    {
        public EveryItemWMItemView(ConditionTypes type, object value, WMItemList parent)
            : base(type, value, parent)
        {
        }
        private EveryItemEnum m_enumItems = EveryItemEnum.Empty ;

        private int m_CountWeek = 0;

        public int CountWeek
        {
            get { return m_CountWeek; }
            set { m_CountWeek = value; }
        }
        private int m_CountMonth = 0;

        public int CountMonth
        {
            get { return m_CountMonth; }
            set { m_CountMonth = value; }
        }


        public EveryItemEnum EveryItems
        {
            get { return m_enumItems; }
            set { m_enumItems = value; }
        }
        public override string DisplayString
        {
            get
            {
                return ConditionHelper.EveryItemToString(EveryItems, CountWeek,CountMonth);
            }
        }
        protected override void InitValue()
        {
            m_enumItems = (EveryItemEnum)Convert.ToInt32(Value);
        }


        public override string StringValue
        {
            get
            {
                return String.Format("{0}={1},{2},{3}", (int)Type, (int)EveryItems, CountWeek,CountMonth); ;
            }
            set
            {
                string[] vals = value.Split (',');

                if (vals.Length == 3)
                {
                    EveryItems = (EveryItemEnum)Convert.ToInt32(vals[0]);
                    CountWeek = Convert.ToInt32(vals[1]);
                    CountMonth = Convert.ToInt32(vals[2]);
                }
            }
        }
    }

    public class TimesWMItemView : BaseWMItemView
    {
        public TimesWMItemView(ConditionTypes type, object value, WMItemList parent):base(type,value,parent)
        {
        }

        private string _times;

        public string Times
        {
            get { return _times; }
            set { _times = value; }
        }
        public override string DisplayString
        {
            get
            {
                return _times;
            }
        }
        protected override void InitValue()
        {
            _times = Convert.ToString(Value);
        }
        
        public override string StringValue
        {
            get
            {
                return String.Format("{0}={1}", (int)Type, Times); ;
            }
            set
            {
                Times = Convert.ToString(value);
            }
        }
    }

    public class IntegerWMItemView : BaseWMItemView
    {
        public IntegerWMItemView(ConditionTypes type, object value, WMItemList parent):base(type,value,parent)
        {
        }
        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public override string DisplayString
        {
            get
            {
                return (Checked )? Convert.ToString(Count):String.Empty ;
            }
        }
        protected override void InitValue()
        {
            _count = Convert.ToInt32(Value);
        }
       
        
        public override string StringValue
        {
            get
            {
                return String.Format("{0}={1}", (int)Type, Count);
            }
            set
            {
                Count = Convert.ToInt32(value);
            }
        }
    }

    public class DoubleWMItemView : BaseWMItemView
    {
        public DoubleWMItemView(ConditionTypes type, object value, WMItemList parent):base(type,value,parent)
        {
        }
        private double _count;

        public double Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public override string DisplayString
        {
            get
            {
                if (Checked)
                    //return Count.ToString("#.#", NumberFormatInfo.InvariantInfo );
                    return String.Format(NumberFormatInfo.InvariantInfo ,"{0:F1}", Count);
                else return String.Empty;
            }
        }
        protected override void InitValue()
        {
            _count = Convert.ToDouble(Value, NumberFormatInfo.InvariantInfo);
        }
        
        public override string StringValue
        {
            get
            {
                //return String.Format("{0}={1:F1}", (int)Type, Count);
                return String.Format(NumberFormatInfo.InvariantInfo,"{0}={1:F1}", (int)Type, Count);
            }
            set
            {
                Count = Convert.ToDouble(value, NumberFormatInfo.InvariantInfo);
            }
        }
    }

    public class LGDoubleWMItemView : BaseWMItemView
    {
        public LGDoubleWMItemView(ConditionTypes type, object value, WMItemList parent)
            : base(type, value, parent)
        {
        }
        private double _count;

        public double Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private bool _LessThan = true;

        public bool LessThan
        {
            get { return _LessThan; }
            set { _LessThan = value; }
        }

        public override string DisplayString
        {
            get
            {
                if (Checked)
                {
                    if (LessThan) return String.Format(NumberFormatInfo.InvariantInfo,"<{0:F1}", Count);
                    else return String.Format(NumberFormatInfo.InvariantInfo,">{0:F1}", Count);
                }
                else return String.Empty;
            }
        }
        protected override void InitValue()
        {
            _count = Convert.ToDouble(Value, NumberFormatInfo.InvariantInfo);
        }

        public override string StringValue
        {
            get
            {
                return String.Format(NumberFormatInfo.InvariantInfo,"{0}={1:F1};{2}", (int)Type, Count, (LessThan) ?0:1);
            }
            set
            {
                string[] arr = value.Split(';');

                Count = Convert.ToDouble(arr[0], NumberFormatInfo.InvariantInfo);
                LessThan = (Convert.ToInt32(arr[1]) == 0) ? true : false;
            }
        }
    }


    public class SaldoZeroOnCertainWeekWMItemView : BaseWMItemView
    {

        byte[] _weeknumbers = null;

        public int Compare = 0;

        public int Hours = 0;

        public SaldoZeroOnCertainWeekWMItemView(ConditionTypes type, object value, WMItemList parent)
            : base(type, value, parent)
        {
        }
        public override string DisplayString
        {
            get
            {
                return (Checked)? BuildDisplayString() : String.Empty;
            }
        }

        private string BuildDisplayString()
        {
            char c = '<';
            if (Compare == 1)
                c = '=';
            else if (Compare == 2)
                c = '>';

            return c + Hours.ToString () + " - " + ArrayToString ();
        }
        public  string ArrayToString()
        {
            string str = String.Empty;
            if (_weeknumbers != null && _weeknumbers.Length > 0)
            {
                StringBuilder sb = new StringBuilder(50);
                for (int i = 0; i < _weeknumbers .Length ; i++)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(_weeknumbers[i]);
                }
                str = sb.ToString();
            }
            return str;
        }

        public void AssignWeekNumbers(string val)
        {
            string[] strs = val.Split(',');
            List<byte> lst = new List<byte>();
            if (strs != null && strs.Length > 0)
            {
                for (int i = 0; i < strs.Length; i++)
			    {
                    if (!String.IsNullOrEmpty(strs[i]))
                    {
                        byte b = Convert.ToByte(strs[i]);
                        if (b>0 && b< 54)
                            lst.Add(b);
                    }
			    }
                lst.Sort();
            }
            _weeknumbers = lst.ToArray();
        }
        private void ParseString(string str)
        {

            _weeknumbers = null;
            Compare = 0;
            Hours = 0;

            string[] ar = str.Split (';');

            if (ar == null || ar.Length != 3) return;

            Compare = Convert.ToInt32(ar[0]);
            Hours= Convert.ToInt32(ar[1]);

            AssignWeekNumbers(ar[2]);
            
        }

        public override string StringValue
        {
            get
            {
                return String.Format("{0}={1};{2};{3}", new object[] {(int)Type, Compare, Hours, ArrayToString()});
            }
            set
            {
                ParseString(value);
            }
        }

        protected override void InitValue()
        {
            ParseString(Value.ToString ());
        }
    }


    public class WMItemList : BindingList<BaseWMItemView>
    {
        public WMItemList()
        {
            BuildList();
        }
        void BuildList()
        {
            //ConditionTypes cond = ConditionTypes.Empty;
            Array values = Enum.GetValues(typeof(ConditionTypes));
            //for (int i = 0; i < values.Length ; i++)
            foreach (ConditionTypes cond in values)
            {
                //cond = (ConditionTypes)values.[i];

                if (ConditionHelper.IsEmptyCondition(cond))
                    this.Add(new BaseWMItemView(cond, null, this));
                else if (ConditionHelper.IsSpecialDaysCondition(cond))
                    this.Add(new SpecialDayWMItemView(cond, 0, this));
                else if (ConditionHelper.IsDoubleCondition(cond))
                    this.Add(new DoubleWMItemView(cond, 0, this));
                else if (ConditionHelper.IsLGDoubleCondition(cond))
                    this.Add(new LGDoubleWMItemView(cond, 0, this));
                else if (ConditionHelper.IsIntegerCondition(cond))
                    this.Add(new IntegerWMItemView(cond, 0, this));
                else if (ConditionHelper.IsInteger2Condition(cond))
                    this.Add(new IntegerWMItemView(cond, 0, this));
                else if (ConditionHelper.IsTimesCondition(cond))

                    this.Add(new TimesWMItemView(cond, String.Empty, this));
                else if (ConditionHelper.IsEveryItemCondition(cond))
                    this.Add(new EveryItemWMItemView(cond, 0, this));
                else if (cond == ConditionTypes.WorkingOnSunday)
                    this.Add(new IntegerWMItemView(cond, 1, this));
                else if (cond == ConditionTypes.WorkingOnSaturdayOrSunday)
                    this.Add(new IntegerWMItemView(cond, 1, this));
                else if (cond == ConditionTypes.SaldoOnCertainWeeks)
                    this.Add(new SaldoZeroOnCertainWeekWMItemView(cond, "", this));

            }
        }

        public event WMItemCheckedChanged OnChangeState = null;

        private bool _initstate;

        public bool InitState
        {
            get { return _initstate; }
            set { _initstate = value; }
        }

        public void ChangeState(BaseWMItemView item)
        {

            if (OnChangeState != null && !InitState) OnChangeState(item);
        }

        public ConditionTypes State
        {
            get
            {
                ConditionTypes ct = ConditionTypes.Empty;
                foreach (BaseWMItemView item in this)
                {
                    if (item.Checked) ct |= item.Type;
                }
                return ct;
            }
            set
            {
                InitState = true;
                ConditionTypes ct = value;
                foreach (BaseWMItemView item in this)
                {
                    item.Checked = ConditionHelper.CheckCondition(ct, item.Type);
                }
                InitState = false;
                ResetBindings();

            }
        }


        public BaseWMItemView GetItemByType(ConditionTypes type)
        {
            foreach (BaseWMItemView bi in this)
            {
                if (bi.Type == type) return bi;
            }
            throw new Exception("Not found  " + type.ToString());
        }

        public void ValuesFromString(string values)
        {
            if (String.IsNullOrEmpty(values)) return;
            string[] typeValues = values.Split('#');
            InitState = true;
            try
            {

                foreach (string param in typeValues)
                {
                    string[] typeAndValue = param.Split('=');
                    ConditionTypes ct = (ConditionTypes)Convert.ToInt32(typeAndValue[0]);

                    GetItemByType(ct).StringValue = typeAndValue[1];
                }
            }
            finally
            {
                InitState = false;
            }

        }
        public string ValuesToString()
        {
            StringBuilder sb = new StringBuilder (100);
            foreach (BaseWMItemView bi in this)
            {
                if (bi.Checked)
                {
                    if (sb.Length > 0) sb.Append("#");
                    sb.Append(bi.StringValue);
                }
            }
            return sb.ToString();
        }
    }



    public class ConditionHelper
    {
        public static string ConditionsToString(ConditionTypes conds)
        {
            StringBuilder sb = new StringBuilder(400);
            foreach(ConditionTypes cts in Enum.GetValues(typeof(ConditionTypes)))
            {
                if (CheckCondition(conds, cts))
                {
                    if (sb.Length > 0) sb.Append(",");
                    sb.Append(GetConditionName(cts));
                }
            }

            return sb.ToString();
        }

        public static string GetConditionName(ConditionTypes cond)
        {
            return Localizer.GetLocalized (cond.ToString().ToLower ());
        }

        public static bool IsEmptyCondition(ConditionTypes conds)
        {
            ConditionTypes emptyCondidtions =
                            ConditionTypes.WorkingTimeOutOfOpeningTimeOfStore |
                            ConditionTypes.WorkingOverEmployeeContractTime |
                            ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                            ConditionTypes.WorkingOnFeast ;
            return ((emptyCondidtions & conds) != ConditionTypes.Empty);

        }

        public static bool IsOnlyMessageCondition(ConditionTypes conds)
        {
            ConditionTypes messageCondidtions =
                            ConditionTypes.DurationOfWorkingDay |
                            ConditionTypes.TimeBetweenPreviousDayWorkingTime |
                            ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                            ConditionTypes.BalanceHoursReachesCertainAmount |
                            ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear |
                            ConditionTypes.WorkingOnSaturdayOrSunday |
                            ConditionTypes.WorkingOnSunday |
                            ConditionTypes.SaldoOnCertainWeeks ;

            return ((messageCondidtions & conds) != ConditionTypes.Empty);
        }

        public static bool IsSpecialDaysCondition(ConditionTypes conds)
        {
            return (ConditionTypes.WorkingOnSpecialWeekdays & conds) != ConditionTypes.Empty;
        }

        public static bool IsTimesCondition(ConditionTypes conds)
        {
            return (ConditionTypes.WorkingTimeBetweenSeveralHours & conds) != ConditionTypes.Empty;
        }
        public static bool IsIntegerCondition(ConditionTypes conds)
        {
            ConditionTypes intConditions = ConditionTypes.TimeBetweenPreviousDayWorkingTime |
                ConditionTypes.DurationOfWorkingDay;
            return (intConditions & conds) != ConditionTypes.Empty;
        }
        public static bool IsInteger2Condition(ConditionTypes conds)
        {
            return (ConditionTypes.BalanceHoursReachesCertainAmount &conds) != ConditionTypes.Empty;
        }

        public static bool IsDoubleCondition(ConditionTypes cond)
        {
            return false;
            //ConditionTypes doubleConditions = ConditionTypes.TimeBetweenPreviousDayWorkingTime;
            //return (cond & doubleConditions) != ConditionTypes.Empty;
        }

        public static bool IsLGDoubleCondition(ConditionTypes cond)
        {
            ConditionTypes doubleConditions = ConditionTypes.DurationOfWorkingTime |
                                    ConditionTypes.DurationOfWorkingTimeSingleDay |
                                    ConditionTypes.DurationOfWorkingTimeByMonth |
                                    ConditionTypes.DurationOfWorkingTimeByWeek;
                                    
            return (cond & doubleConditions) != ConditionTypes.Empty;
        }

        public static bool IsEveryItemCondition(ConditionTypes cond)
        {
            ConditionTypes doubleConditions = ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear ;

            return (cond & doubleConditions) != ConditionTypes.Empty;
        }
        public static void RemoveCondition(ref ConditionTypes conds, ConditionTypes cond)
        {
            conds &= (~cond);
        }

        public static void AddCondition(ref ConditionTypes conds, ConditionTypes cond)
        {
            conds |= cond;
        }
        public static bool CheckCondition(ConditionTypes conds, ConditionTypes cond)
        {
            return (conds & cond) == cond;
        }



        public static string EveryItemToString(EveryItemEnum EveryItems, int week, int month)
        {
            StringBuilder sb = new StringBuilder(100);

            if ((EveryItems & EveryItemEnum.EveryWeek) != EveryItemEnum.Empty)
            {
                string val = Localizer.GetLocalized("EveryWeek");
                if (String.IsNullOrEmpty(val)) val = "Every week";

                if (week > 1) val = String.Format("{0}({1})", val, week);
                sb.Append(val);
            }
            if ((EveryItems & EveryItemEnum.EveryMonth) != EveryItemEnum.Empty)
            {
                string val = Localizer.GetLocalized("EveryMonth");
                if (String.IsNullOrEmpty(val)) val = "Every month";
                if (sb.Length > 0) sb.Append(", ");
                if (week > 1) val = String.Format("{0}({1})", val, month);
                sb.Append(val);
            }
            if ((EveryItems & EveryItemEnum.EveryYear) != EveryItemEnum.Empty)
            {
                string val = Localizer.GetLocalized("EveryYear");
                if (String.IsNullOrEmpty(val)) val = "Every year";
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(val);
            }
            return sb.ToString();

        }
    }

}
