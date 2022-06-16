using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using System.Diagnostics;


namespace Baumax.Contract.WorkingModelConditions
{
    public class WorkingModelWrapper
    {
        private WorkingModel _workingmodel = null;
        private List<ConditionBase> _Conditions;


        //private StoreDaysList _storedays = null;
        private EmployeePlanningWeek _employeeweek = null;
        private DateTime _currentDate = DateTime.Today;
        private int _addsubhoursasminutes = 0;
        /*public StoreDaysList StoreDays
        {
            get { return _storedays; }
        }
        */
        public EmployeePlanningWeek EmployeeWeek
        {
            get { return _employeeweek; }
        }
        public DateTime CurrentDate
        {
            get { return _currentDate; }
        }

        public void ResetContext()
        {
            //_storedays = null;
            _employeeweek = null;
            Hours = -1;
        }
        public WorkingModel Model
        {
            get { return _workingmodel; }
        }
        // add 20.12.2007 
        public int ModelAddSubHoursAsMinute
        {
            get
            {
                return _addsubhoursasminutes;
            }
        }
        // add 20.12.2007
        public int GetMultiplyValue()
        {
            Debug.Assert(Model != null);

            return DateTimeHelper.RoundToQuoter((int)(Hours * Model.MultiplyValue - Hours));
        }
        public int GetModelValue
        {
            get
            {
                int resultHours = 0;
                if (Model.AddValue != 0)
                {
                    resultHours += ModelAddSubHoursAsMinute;
                }
                if (Model.MultiplyValue != 0)
                {
                    resultHours += GetMultiplyValue();
                }
                return resultHours;
            }
        }
        public WorkingModelWrapper(WorkingModel model)
        {
            _workingmodel = model;
            BuildConditions ();
        }

        private int _Hours = -1;

        public int Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }




        public List<ConditionBase> Conditions
        {
            get { return _Conditions; }
        }

        private void BuildConditions()
        {
            if (Model.AddValue != 0)
                _addsubhoursasminutes = DateTimeHelper.RoundToQuoter((int)(60 * Model.AddValue));

            if (String.IsNullOrEmpty(Model.Data)) return;
            string[] typeValues = Model.Data.Split('#');
            try
            {
                ConditionBase condition = null;
                foreach (string param in typeValues)
                {
                    string[] typeAndValue = param.Split('=');
                    ConditionTypes ct = (ConditionTypes)Convert.ToInt32(typeAndValue[0]);
                    condition = CreateConditionByType(ct);
                    if (condition != null)
                    {
                        condition.ParseValue(typeAndValue[1]);

                        if (Conditions == null) _Conditions = new List<ConditionBase>();
                        Conditions.Add(condition);
                    }

                }
            }
            finally
            {
            }


        }

        private ConditionBase CreateConditionByType(ConditionTypes ct)
        {
            ConditionBase c = null;
            switch(ct)
            {
                case ConditionTypes.DurationOfWorkingDay: c = new ConditionDurationOfWorkingDaysInRow(); break;
                case ConditionTypes.DurationOfWorkingTime: c = new ConditionDurationOfWorkingTime(); break;
                case ConditionTypes.DurationOfWorkingTimeByMonth: c = new ConditionDurationOfWorkingTimeOnMonth(); break;
                case ConditionTypes.DurationOfWorkingTimeByWeek: c = new ConditionDurationOfWorkingTimeOnWeek(); break;
                case ConditionTypes.DurationOfWorkingTimeSingleDay: c = new ConditionDurationOfWorkingTimeOnSingleDay(); break;
                case ConditionTypes.TimeBetweenPreviousDayWorkingTime: c = new ConditionTimeBetweenPreviousDayWorkingTime(); break;
                case ConditionTypes.WorkingOnFeast: c = new ConditionWorkingOnFeast(); break;
                case ConditionTypes.WorkingOnSpecialWeekdays: c = new ConditionWorkingOnSpecialWeekdays(); break;
                case ConditionTypes.WorkingOverEmployeeContractTime: c = new ConditionWorkingOverEmployeeContractTime (); break;
                case ConditionTypes.WorkingOverEmployeeCurrentBalanceHours: c = new ConditionWorkingOverEmployeeCurrentBalanceHours(); break;
                case ConditionTypes.WorkingTimeBetweenSeveralHours: c = new ConditionWorkingTimeBetweenSeveralHours(); break;
                case ConditionTypes.WorkingTimeOutOfOpeningTimeOfStore: c = new ConditionWorkingTimeOutOfOpeningStore(); break;
                case ConditionTypes.BalanceHoursReachesCertainAmount: c = new ConditionBalanceHoursReachesCertainAmount(); break;
                case ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear: c = new ConditionBalanceHoursMustBeZeroEveryWeekMonthYear(); break;
                case ConditionTypes.WorkingOnSunday: c = new ConditionWorkingOnSunday(); break;
                case ConditionTypes.WorkingOnSaturdayOrSunday: c = new ConditionWorkingOnSundayOrSaturday(); break;
                case ConditionTypes.SaldoOnCertainWeeks: c = new ConditionSaldoOnCertainWeeks(); break;
            }
            if (c != null)
                c.Wrapper = this;
            return c;
        }

        public bool IsWeekModel
        {
            get
            {
                ConditionTypes types = ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear |
                    ConditionTypes.DurationOfWorkingDay |
                    ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                    ConditionTypes.BalanceHoursReachesCertainAmount |
                    ConditionTypes.WorkingOverEmployeeContractTime |
                    ConditionTypes.DurationOfWorkingTimeByWeek |
                    ConditionTypes.DurationOfWorkingTimeByMonth |
                    ConditionTypes.WorkingOnSunday |
                    ConditionTypes.WorkingOnSaturdayOrSunday |
                    ConditionTypes.SaldoOnCertainWeeks ;

                return (((ConditionTypes)Model.ConditionType) & types) != ConditionTypes.Empty;

            }
        }

        public bool IsWeekMessageModel
        {
            get
            {
                ConditionTypes types = ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear |
                    ConditionTypes.DurationOfWorkingDay |
                    ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                    ConditionTypes.BalanceHoursReachesCertainAmount | 
                    ConditionTypes.WorkingOnSunday |
                    ConditionTypes.WorkingOnSaturdayOrSunday |
                    ConditionTypes.SaldoOnCertainWeeks;
                return (((ConditionTypes)Model.ConditionType) & types) != ConditionTypes.Empty;

            }
        }
        public bool IsMessageModel { get { return IsOnlyMessageCondition((ConditionTypes)Model.ConditionType); } }
        public bool IsContainMessage()
        {
            return (Model.Message != null) && (!String.IsNullOrEmpty(Model.Message));
        }

        public static bool IsOnlyMessageCondition(ConditionTypes conds)
        {
            ConditionTypes messageCondidtions =
                            ConditionTypes.DurationOfWorkingDay |
                            ConditionTypes.TimeBetweenPreviousDayWorkingTime |
                            ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                            ConditionTypes.BalanceHoursReachesCertainAmount |
                            ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear | 
                            ConditionTypes.WorkingOnSunday |
                            ConditionTypes.WorkingOnSaturdayOrSunday |
                            ConditionTypes.SaldoOnCertainWeeks;

            return ((messageCondidtions & conds) != ConditionTypes.Empty);
        }



        public bool Validate(EmployeePlanningWeek planningWeek, DateTime date)
        {
            _employeeweek = planningWeek;
            _currentDate = date;
            _Hours = -1;
            return Validate();
        }

        private bool Validate()
        {
            foreach (ConditionBase cond in _Conditions)
            {
                if (!cond.Validate()) return false;
            }
            if (Hours == -1) Hours = 0;
            return true;
        }
    }



    public class WorkingModelWrapperNew
    {
        private WorkingModel _workingmodel = null;
        private List<ConditionBase> _Conditions;


        //private IStoreDaysList _storedays = null;
        private IBaumaxEmployeeWeek _employeeweek = null;
        private DateTime _currentDate = DateTime.Today;
        private int _addsubhoursasminutes = 0;
        //public IStoreDaysList StoreDays
        //{
        //    get { return _storedays; }
        //}

        public IBaumaxEmployeeWeek EmployeeWeek
        {
            get { return _employeeweek; }
        }
        public DateTime CurrentDate
        {
            get { return _currentDate; }
        }

        public void ResetContext()
        {
           // _storedays = null;
            _employeeweek = null;
            Hours = -1;
        }
        public WorkingModel Model
        {
            get { return _workingmodel; }
        }
        // add 20.12.2007 
        public int ModelAddSubHoursAsMinute
        {
            get
            {
                return _addsubhoursasminutes;
            }
        }
        // add 20.12.2007
        public int GetMultiplyValue()
        {
            Debug.Assert(Model != null);

            return DateTimeHelper.RoundToQuoter((int)(Hours * Model.MultiplyValue - Hours));
        }

        public int GetModelValue
        {
            get
            {
                int resultHours = 0;
                if (Model.AddValue != 0)
                {
                    resultHours += ModelAddSubHoursAsMinute;
                }
                if (Model.MultiplyValue != 0)
                {
                    resultHours += GetMultiplyValue();
                }
                return resultHours;
            }
        }

        public WorkingModelWrapperNew(WorkingModel model)
        {
            _workingmodel = model;
            BuildConditions();
        }

        private int _Hours = -1;

        public int Hours
        {
            get { return _Hours; }
            set 
            { 
                if (_Hours > value || _Hours == -1)
                    _Hours = value; 
            }
        }

        public List<ConditionBase> Conditions
        {
            get { return _Conditions; }
        }

        private void BuildConditions()
        {
            if (Model.AddValue != 0)
                _addsubhoursasminutes = DateTimeHelper.RoundToQuoter((int)(60 * Model.AddValue));
            if (String.IsNullOrEmpty(Model.Data)) return;
            string[] typeValues = Model.Data.Split('#');
            try
            {
                ConditionBase condition = null;
                foreach (string param in typeValues)
                {
                    string[] typeAndValue = param.Split('=');
                    ConditionTypes ct = (ConditionTypes)Convert.ToInt32(typeAndValue[0]);
                    condition = CreateConditionByType(ct);
                    if (condition != null)
                    {
                        condition.ParseValue(typeAndValue[1]);

                        if (Conditions == null) _Conditions = new List<ConditionBase>();
                        Conditions.Add(condition);
                    }

                }
            }
            finally
            {
            }


        }

        private ConditionBase CreateConditionByType(ConditionTypes ct)
        {
            ConditionBase c = null;
            switch (ct)
            {
                case ConditionTypes.DurationOfWorkingDay: c = new ConditionDurationOfWorkingDaysInRow(); break;
                case ConditionTypes.DurationOfWorkingTime: c = new ConditionDurationOfWorkingTime(); break;
                case ConditionTypes.DurationOfWorkingTimeByMonth: c = new ConditionDurationOfWorkingTimeOnMonth(); break;
                case ConditionTypes.DurationOfWorkingTimeByWeek: c = new ConditionDurationOfWorkingTimeOnWeek(); break;
                case ConditionTypes.DurationOfWorkingTimeSingleDay: c = new ConditionDurationOfWorkingTimeOnSingleDay(); break;
                case ConditionTypes.TimeBetweenPreviousDayWorkingTime: c = new ConditionTimeBetweenPreviousDayWorkingTime(); break;
                case ConditionTypes.WorkingOnFeast: c = new ConditionWorkingOnFeast(); break;
                case ConditionTypes.WorkingOnSpecialWeekdays: c = new ConditionWorkingOnSpecialWeekdays(); break;
                case ConditionTypes.WorkingOverEmployeeContractTime: c = new ConditionWorkingOverEmployeeContractTime(); break;
                case ConditionTypes.WorkingOverEmployeeCurrentBalanceHours: c = new ConditionWorkingOverEmployeeCurrentBalanceHours(); break;
                case ConditionTypes.WorkingTimeBetweenSeveralHours: c = new ConditionWorkingTimeBetweenSeveralHours(); break;
                case ConditionTypes.WorkingTimeOutOfOpeningTimeOfStore: c = new ConditionWorkingTimeOutOfOpeningStore(); break;
                case ConditionTypes.BalanceHoursReachesCertainAmount: c = new ConditionBalanceHoursReachesCertainAmount(); break;
                case ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear: c = new ConditionBalanceHoursMustBeZeroEveryWeekMonthYear(); break;
                case ConditionTypes.WorkingOnSunday: c = new ConditionWorkingOnSunday(); break;
                case ConditionTypes.WorkingOnSaturdayOrSunday: c = new ConditionWorkingOnSundayOrSaturday(); break;
                case ConditionTypes.SaldoOnCertainWeeks: c = new ConditionSaldoOnCertainWeeks(); break;

            }
            if (c != null)
                c.Owner = this;
            return c;
        }

        public bool IsWeekModel
        {
            get
            {
                ConditionTypes types = ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear |
                    ConditionTypes.DurationOfWorkingDay |
                    ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                    ConditionTypes.BalanceHoursReachesCertainAmount |
                    ConditionTypes.WorkingOverEmployeeContractTime |
                    ConditionTypes.DurationOfWorkingTimeByWeek |
                    ConditionTypes.WorkingOnSunday |
                    ConditionTypes.WorkingOnSaturdayOrSunday |
                    ConditionTypes.SaldoOnCertainWeeks;

                return (((ConditionTypes)Model.ConditionType) & types) != ConditionTypes.Empty;

            }
        }

        public bool IsWeekMessageModel
        {
            get
            {
                ConditionTypes types = ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear |
                    ConditionTypes.DurationOfWorkingDay |
                    ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                    ConditionTypes.BalanceHoursReachesCertainAmount |
                    ConditionTypes.WorkingOnSunday |
                    ConditionTypes.WorkingOnSaturdayOrSunday |
                    ConditionTypes.SaldoOnCertainWeeks;
                return (((ConditionTypes)Model.ConditionType) & types) != ConditionTypes.Empty;

            }
        }
        public bool IsMessageModel { get { return IsOnlyMessageCondition((ConditionTypes)Model.ConditionType); } }


        public static bool IsOnlyMessageCondition(ConditionTypes conds)
        {
            ConditionTypes messageCondidtions =
                            ConditionTypes.DurationOfWorkingDay |
                            ConditionTypes.TimeBetweenPreviousDayWorkingTime |
                            ConditionTypes.WorkingOverEmployeeCurrentBalanceHours |
                            ConditionTypes.BalanceHoursReachesCertainAmount |
                            ConditionTypes.BalanceHoursMustBeZeroEveryWeekMonthYear |
                            ConditionTypes.WorkingOnSunday |
                    ConditionTypes.WorkingOnSaturdayOrSunday |
                    ConditionTypes.SaldoOnCertainWeeks;

            return ((messageCondidtions & conds) != ConditionTypes.Empty);
        }


        public bool IsContainMessage()
        {
            return (Model.Message != null) && (!String.IsNullOrEmpty(Model.Message));
        }
        public bool Validate(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            _employeeweek = planningWeek;
            _currentDate = date;
            _Hours = -1;
            return Validate();
        }

        private bool Validate()
        {
            foreach (ConditionBase cond in _Conditions)
            {
                if (!cond.ValidateNew()) return false;
            }
            if (Hours == -1) Hours = 0;
            return true;
        }
    }
}
