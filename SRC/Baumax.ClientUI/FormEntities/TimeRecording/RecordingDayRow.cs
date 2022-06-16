using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public class RecordingDayRow
    {

        EmployeeWeek _plannedWeek = null;
        EmployeeWeek _actualWeek = null;

        EmployeeDay _plannedDay = null;
        EmployeeDay _actualDay = null;

        RecordingDayView _plannedDayView = null;
        RecordingDayView _actualDayView = null;

        private string _fullname;
        private long _OrderHWGR;

        public RecordingDayRow(EmployeeWeek week, RecordingDayView dayview,
            EmployeeWeek actualweek, RecordingDayView actualdayview, long orderHwgr)
        {
            _plannedWeek = week;
            _plannedDayView = dayview;

            _actualWeek = actualweek;
            _actualDayView = actualdayview;

            if (_plannedDayView != null)
                _plannedDay = _plannedDayView.RecordingDay;

            if (_actualDayView != null)
                _actualDay = _actualDayView.RecordingDay;

            if (_plannedWeek.FullName != null)
                _fullname = _plannedWeek.FullName;

            _OrderHWGR = orderHwgr;
        }

        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        public long OrderHWGR
        {
            get { return _OrderHWGR; }
            set { _OrderHWGR = value; }
        }

        public RecordingDayView PlannedView
        {
            get { return _plannedDayView; } 
        }

        public RecordingDayView ActualView
        {
            get { return _actualDayView; }
        }

        public EmployeeWeek PlannedWeek
        {
            get { return _plannedWeek; }
        }

        public EmployeeWeek ActualWeek
        {
            get { return _actualWeek; }
        }

        public EmployeeDay PlannedDay
        {
            get { return _plannedDay; }
        }

        public EmployeeDay ActualDay
        {
            get { return _actualDay; }
        }

        #region properties for display

        public string ContractHoursPerWeek
        {
            get
            {
                if (_plannedWeek != null)
                    return TextParser.TimeToString(_plannedWeek.ContractHoursPerWeek);
                return "00:00";
            }
        }

        public string PlannedWorkingHours
        {
            get
            {
                if (_plannedDay != null)
                    return TextParser.TimeToString(_plannedDay.CountDailyPlannedWorkingHours);
                return "00:00";
            }
        }

        public string AdditionalHours
        {
            get
            {
                if (_plannedDay != null)
                    return TextParser.TimeToString(_plannedDay.CountDailyAdditionalCharges );
                return "00:00";
            }
        }

        public string PlusMinusHours
        {
            get
            {
                if (_plannedWeek != null)
                    return TextParser.TimeToString(_plannedWeek.CountWeeklyPlusMinusHours);
                return "00:00";
            }
        }
        public string Saldo
        {
            get
            {
                if (_plannedWeek != null)
                    return TextParser.TimeToString(_plannedWeek.Saldo);
                return "00:00";
            }
        }
        ///////////////////////////////////
        public string ActualPlannedWorkingHours
        {
            get
            {
                if (_actualDay != null)
                    return TextParser.TimeToString(_actualDay.CountDailyPlannedWorkingHours );
                return "00:00";
            }
        }

        public string ActualAdditionalHours
        {
            get
            {
                if (_actualDay != null)
                    return TextParser.TimeToString(_actualDay.CountDailyAdditionalCharges );
                return "00:00";
            }
        }

        public string ActualPlusMinusHours
        {
            get
            {
                if (_actualWeek != null)
                    return TextParser.TimeToString(_actualWeek.CountWeeklyPlusMinusHours);
                return "00:00";
            }
        }
        public string ActualSaldo
        {
            get
            {
                if (_actualWeek != null)
                    return TextParser.TimeToString(_actualWeek.Saldo);
                return "00:00";
            }
        }
        #endregion

    }
}
