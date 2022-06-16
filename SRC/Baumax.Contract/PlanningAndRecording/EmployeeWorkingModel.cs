using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.TimePlanning
{
    public sealed class EmployeeWorkingModel:BaseEntity
    {
        #region Member Variables

        int _hours;
        bool _additionalCharge = false;
        DateTime _date;
        long _employeeID;
        long _workingModelID;

        #endregion

        #region Constructors

        public EmployeeWorkingModel()
        {
        }

        public EmployeeWorkingModel(EmployeePlanningWorkingModel plwm)
        {
            ID = plwm.ID;
            Hours = plwm.Hours;
            WorkingModelID = plwm.WorkingModelID;
            EmployeeID = plwm.EmployeeID;
            AdditionalCharge = plwm.AdditionalCharge;
            Date = plwm.Date;
        }
        public EmployeeWorkingModel(EmployeeRecordingWorkingModel plwm)
        {
            ID = plwm.ID;
            Hours = plwm.Hours;
            WorkingModelID = plwm.WorkingModelID;
            EmployeeID = plwm.EmployeeID;
            AdditionalCharge = plwm.AdditionalCharge;
            Date = plwm.Date;
        }
        public void AssignTo(EmployeeRecordingWorkingModel plwm)
        {
            plwm.ID = ID;
            plwm.Hours = Hours ;
            plwm.WorkingModelID = WorkingModelID;
            plwm.EmployeeID = EmployeeID;
            plwm.AdditionalCharge = AdditionalCharge;
            plwm.Date = Date;
        }
        public void AssignTo(EmployeePlanningWorkingModel plwm)
        {
            plwm.ID = ID;
            plwm.Hours = Hours;
            plwm.WorkingModelID = WorkingModelID;
            plwm.EmployeeID = EmployeeID;
            plwm.AdditionalCharge = AdditionalCharge;
            plwm.Date = Date;
        }

        #endregion

        #region Public Properties

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public bool AdditionalCharge
        {
            get { return _additionalCharge; }
            set { _additionalCharge = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public  long EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public  long WorkingModelID
        {
            get { return _workingModelID; }
            set { _workingModelID = value; }
        }

        #endregion
    }
}
