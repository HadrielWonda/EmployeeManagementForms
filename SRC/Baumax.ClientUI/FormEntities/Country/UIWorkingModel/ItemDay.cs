using System;
using System.ComponentModel;
using System.Text;
using Baumax.Domain;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.Country
{
    public class ItemDay
    {
        private DaysList _parent = null;
        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            set 
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (_parent != null && !_parent.InitState)
                        _parent.ChangeState(this);
                }
            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private WeeksDayMask _day;

        public WeeksDayMask DayMask
        {
            get { return _day; }
            set { _day = value; }
        }

        public void UpdateName()
        {
            Name = DaysHelper.GetDayName(DayMask);
        }

        public ItemDay(WeeksDayMask aDayMask, DaysList parent)
        {
            _checked = false;
            _name = String.Empty;
            _day = aDayMask;
            _parent = parent;
        }
    }

    public delegate void DaysStateChanged(int state);

    public class DaysList : BindingList<ItemDay>
    {
        public DaysList()
            : base()
        {
            BuildList();
        }
        private bool _initState = false;

        public bool InitState
        {
            get { return _initState; }
            set { _initState = value; }
        }
	
        private void BuildList()
        {
            InitState = true;
            int i = 1;
            for (int j = 0; j < 7; j++)
            {
                this.Add(new ItemDay((WeeksDayMask)i,this)); i *= 2;
            }
            InitState = false;
            AssignLanguage();
        }

        public int CheckedState
        {
            get
            {
                WeeksDayMask wd = WeeksDayMask.Empty;
                foreach (ItemDay item in this)
                {
                    if (item.Checked) wd |= item.DayMask;
                }
                return (int)wd;
            }
            set
            {
                InitState = true;
                WeeksDayMask wd = (WeeksDayMask)value;
                foreach (ItemDay item in this)
                {
                    item.Checked = ((item.DayMask & wd) != WeeksDayMask.Empty);
                }
                InitState = false;
                this.ResetBindings();
            }
        }
        public event DaysStateChanged OnStateChanged = null;
        internal void ChangeState(ItemDay item)
        {
            if (OnStateChanged != null) OnStateChanged(CheckedState);
        }
        public void AssignLanguage()
        {

            foreach (ItemDay item in this)
            {
                item.UpdateName();
            }
        }
    }

    public class DaysWrapper
    {
        private WeeksDayMask  _days;

        public WeeksDayMask  DayMasks
        {
            get { return _days; }
            set { _days = value; }
        }

        public DaysWrapper(WeeksDayMask wd)
        {
            _days = wd;
        }

        void SetState(bool state, WeeksDayMask dayMask)
        {
            if (state)
            {
                DaysHelper.AddDay(ref _days, WeeksDayMask.Monday);
            }
            else
            {
                DaysHelper.RemoveDay(ref _days, WeeksDayMask.Monday);
            }
        }

        public bool Monday
        {
            get { return DaysHelper.CheckDay (_days, WeeksDayMask.Monday) ; }
            set { SetState(value, WeeksDayMask.Monday); }
        }
        public bool Tuesday
        {
            get { return DaysHelper.CheckDay(_days, WeeksDayMask.Tuesday); }
            set { SetState(value, WeeksDayMask.Tuesday); }
        }
        public bool Wednesday
        {
            get { return DaysHelper.CheckDay(_days, WeeksDayMask.Wednesday); }
            set { SetState(value, WeeksDayMask.Wednesday); }
        }
        public bool Thursday
        {
            get { return DaysHelper.CheckDay(_days, WeeksDayMask.Thursday); }
            set { SetState(value, WeeksDayMask.Thursday); }
        }
        public bool Friday
        {
            get { return DaysHelper.CheckDay(_days, WeeksDayMask.Friday); }
            set { SetState(value, WeeksDayMask.Friday); }
        }
        public bool Saturday
        {
            get { return DaysHelper.CheckDay(_days, WeeksDayMask.Saturday); }
            set { SetState(value, WeeksDayMask.Saturday); }
        }
        public bool Sunday
        {
            get { return DaysHelper.CheckDay(_days, WeeksDayMask.Sunday); }
            set { SetState(value, WeeksDayMask.Sunday); }
        }
    }

    public class DaysHelper
    {
        public static string DaysToString(WeeksDayMask dayMasks)
        {
            int j = 1;
            StringBuilder sb = new StringBuilder (100);
            for (int i = 0; i < 7; i++)
            {
                if (CheckDay(dayMasks, (WeeksDayMask)j))
                {
                    if (sb.Length > 0) sb.Append(",");
                    sb.Append(GetDayName((WeeksDayMask)j));
                }
                j*=2;
            }
            return sb.ToString();
        }

        public static string GetDayName(WeeksDayMask dayMask)
        {
            switch (dayMask)
            {
                case WeeksDayMask.Monday: return UILocalizer.Current["Monday"] ; 
                case WeeksDayMask.Tuesday: return UILocalizer.Current["Tuesday"]; 
                case WeeksDayMask.Wednesday: return UILocalizer.Current["Wednesday"]; 
                case WeeksDayMask.Thursday: return UILocalizer.Current["Thursday"]; 
                case WeeksDayMask.Friday: return UILocalizer.Current["Friday"]; 
                case WeeksDayMask.Saturday: return UILocalizer.Current["Saturday"]; 
                case WeeksDayMask.Sunday: return UILocalizer.Current["Sunday"]; 
            }
            return String.Empty;
        }

        public static void RemoveDay(ref WeeksDayMask dayMasks, WeeksDayMask dayMask)
        {
            dayMasks &= (~dayMask);
        }

        public static void AddDay(ref WeeksDayMask dayMasks, WeeksDayMask dayMask)
        {
            dayMasks |= dayMask;
        }
        public static bool CheckDay(WeeksDayMask dayMasks, WeeksDayMask dayMask)
        {
            return (dayMasks & dayMask) == dayMask;
        }


    }


}
