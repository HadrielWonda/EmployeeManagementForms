using System;
using System.Collections;

namespace Baumax.Domain
{

    #region EmployeePlanningWorkingModel

    /// <summary>
    /// EmployeePlanningWorkingModel object for NHibernate mapped table 'EmployeePlanningWorkingModel'.
    /// </summary>
    [Serializable]
    public class EmployeePlanningWorkingModel : BaseEntity
    {
        #region Member Variables

        protected int _hours;
        protected bool _additionalCharge;
        protected DateTime _date;
        protected long _employeeID;
        protected long _workingModelID;

        #endregion

        #region Constructors

        public EmployeePlanningWorkingModel()
        {
        }

        public EmployeePlanningWorkingModel(int hours, bool additionalCharge, DateTime date, long employeeID,
                                            long workingModelID)
        {
            this._hours = hours;
            this._additionalCharge = additionalCharge;
            this._date = date;
            this._employeeID = employeeID;
            this._workingModelID = workingModelID;
        }

        #endregion

        #region Public Properties

        public virtual int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public virtual bool AdditionalCharge
        {
            get { return _additionalCharge; }
            set { _additionalCharge = value; }
        }

        public virtual DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public virtual long EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public virtual long WorkingModelID
        {
            get { return _workingModelID; }
            set { _workingModelID = value; }
        }

        #endregion
    }

    #endregion
}