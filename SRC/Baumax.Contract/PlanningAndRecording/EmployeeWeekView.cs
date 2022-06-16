using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Baumax.Contract.TimePlanning
{
    public class EmployeeWeekView
    {
        private EmployeeWeek _planningWeek = null;
        private EmployeeWeek _actualWeek = null;
        private string _EmplFullName = String.Empty;
        private IPlanningContext _context = null;
        private long _OrderHWGR;

        public EmployeeWeekView(IPlanningContext context)
        {
            _context = context;
        }

        public EmployeeWeekView(IPlanningContext context, EmployeeWeek planweek, EmployeeWeek actualweek, long orderHWGR):
            this(context)
        {
            _planningWeek = planweek;
            _actualWeek = actualweek;
            _OrderHWGR = orderHWGR;
            if (_planningWeek != null)
            {
                _EmplFullName = _planningWeek.FullName;
            }
        }

        public IPlanningContext Context
        {
            get { return _context; }
            set 
            { 
                _context = value; 
            }
        }

        public EmployeeWeek PlanningWeek
        {
            get { return _planningWeek; }
            set 
            { 
                _planningWeek = value;
                if (_planningWeek != null)
                    _EmplFullName = _planningWeek.FullName;
            }
        }

        public EmployeeWeek ActualWeek
        {
            get { return _actualWeek; }
            set 
            { 
                _actualWeek = value;
                if (_actualWeek != null)
                    _EmplFullName = _actualWeek.FullName;

            }
        }

        public long EmployeeId
        {
            get
            {
                if (_planningWeek != null) return _planningWeek.EmployeeId;
                if (_actualWeek != null) return _actualWeek.EmployeeId;
                return 0;
            }
        }

        public string FullName
        {
            get { return _EmplFullName; }
        }

        public IList GetPlanningDayContent(DayOfWeek dayofweek)
        {
            return null;
        }

        public IList GetActualDayContent(DayOfWeek dayofweek)
        {
            return null;
        }

        #region properties for display

        public string ContractHoursPerWeek
        {
            get 
            {
                if (_planningWeek != null && _planningWeek.IsValidWeek)
                    return TextParser.TimeToString(_planningWeek.ContractHoursPerWeek);
                return "--:--"; 
            }
        }

        public string PlannedWorkingHours
        {
            get
            {
                if (_planningWeek != null && _planningWeek.IsValidWeek)
                    return TextParser.TimeToString(_planningWeek.CountWeeklyPlanningWorkingHours);
                return "--:--";
            }
        }

        public string AdditionalHours
        {
            get
            {
                if (_planningWeek != null && !_planningWeek.AllIn && _planningWeek.IsValidWeek )
                    return TextParser.TimeToString(_planningWeek.CountWeeklyAdditionalCharges);
                return "--:--";
            }
        }

        public string PlusMinusHours
        {
            get
            {
                if (_planningWeek != null && _planningWeek.IsValidWeek)
                    return TextParser.TimeToString(_planningWeek.CountWeeklyPlusMinusHours);
                return "--:--";
            }
        }
        public string Saldo
        {
            get
            {
                if (_planningWeek != null && !_planningWeek.AllIn)
                    return TextParser.TimeToString(_planningWeek.Saldo);
                return "--:--";
            }
        }
        ///////////////////////////////////
        public string ActualPlannedWorkingHours
        {
            get
            {
                if (_actualWeek != null && _actualWeek.IsValidWeek)
                    return TextParser.TimeToString(_actualWeek.CountWeeklyPlanningWorkingHours);
                return "--:--";
            }
        }

        public string ActualAdditionalHours
        {
            get
            {
                if (_actualWeek != null && !_actualWeek.AllIn)
                    return TextParser.TimeToString(_actualWeek.CountWeeklyAdditionalCharges);
                return "--:--";
            }
        }

        public string ActualPlusMinusHours
        {
            get
            {
                if (_actualWeek != null && _actualWeek.IsValidWeek)
                    return TextParser.TimeToString(_actualWeek.CountWeeklyPlusMinusHours);
                return "--:--";
            }
        }
        public string ActualSaldo
        {
            get
            {
                if (_actualWeek != null && !_actualWeek.AllIn && _actualWeek.IsValidWeek)
                    return TextParser.TimeToString(_actualWeek.Saldo);
                return "--:--";
            }
        }

        public long OrderHWGR
        {
            get { return _OrderHWGR; }
            set { _OrderHWGR = value; }
        }

        #endregion


        public bool CopyFromPlannedToActual(DateTime minDate, DateTime maxDate)
        {
            if (PlanningWeek == null || ActualWeek == null) return false;
            EmployeeDay actualDay = null;
            bool bModified = false;
            foreach (EmployeeDay emplday in PlanningWeek.DaysList)
            {
                if (emplday.Date <= minDate) continue;
                if (emplday.Date >= maxDate) continue;


                actualDay = ActualWeek.GetDay(emplday.Date);

                if (actualDay == null)
                    throw new ArgumentException();


                if (!EmployeeTimeRangeHelper.CompareTwoList(actualDay.TimeList, emplday.TimeList))
                {
                    actualDay.TimeList = new List<EmployeeTimeRange>();

                    if (emplday.TimeList != null)
                    {
                        //EmployeeTimeRange newrange = null;
                        foreach (EmployeeTimeRange range in emplday.TimeList)
                        {
                            actualDay.TimeList.Add(new EmployeeTimeRange(range));
                        }
                    }
                    actualDay.Modified = true;
                    bModified = true;
                }
            }

            return bModified;
        }
    }
}
