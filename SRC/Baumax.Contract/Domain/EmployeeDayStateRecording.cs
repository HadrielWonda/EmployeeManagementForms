using System;
using System.Collections;
using Baumax.Contract;

namespace Baumax.Domain
{

    #region EmployeeDayStateRecording

    /// <summary>
    /// EmployeeDayStateRecording object for NHibernate mapped table 'EmployeeDayStateRecording'.
    /// </summary>
    [Serializable]
    public class EmployeeDayStateRecording : BaseEntity, IEmployeeDay
    {
        #region Member Variables

        protected int _workingHours;
        protected DateTime _date;
        protected int _allreadyPlannedHours;
        protected int _sumOfAddHours;
        protected int _plusMinusHours;
        protected int _emplBalanceHours;
        protected long _employeeID;
        protected long _storeworldid;

        #endregion

        #region Constructors

        public EmployeeDayStateRecording()
        {
        }

        public EmployeeDayStateRecording(DateTime date, int allreadyPlannedHours, int sumOfAddHours, int plusMinusHours,
                                         int emplBalanceHours, long employeeID, int workingHours, long storeworldid)
        {
            this._date = date;
            this._allreadyPlannedHours = allreadyPlannedHours;
            this._sumOfAddHours = sumOfAddHours;
            this._plusMinusHours = plusMinusHours;
            this._emplBalanceHours = emplBalanceHours;
            this._employeeID = employeeID;
            this._workingHours = workingHours;
            this._storeworldid = storeworldid;
        }

        #endregion

        #region Public Properties

        public virtual int WorkingHours
        {
            get { return _workingHours; }
            set { _workingHours = value; }
        }

        public virtual DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public virtual int AllreadyPlannedHours
        {
            get { return _allreadyPlannedHours; }
            set { _allreadyPlannedHours = value; }
        }

        public virtual int SumOfAddHours
        {
            get { return _sumOfAddHours; }
            set { _sumOfAddHours = value; }
        }

        public virtual int PlusMinusHours
        {
            get { return _plusMinusHours; }
            set { _plusMinusHours = value; }
        }

        public virtual int EmplBalanceHours
        {
            get { return _emplBalanceHours; }
            set { _emplBalanceHours = value; }
        }

        public virtual long EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        public virtual long StoreWorldId
        {
            get { return _storeworldid; }
            set { _storeworldid = value; }
        }
        #endregion
    }

    #endregion
}