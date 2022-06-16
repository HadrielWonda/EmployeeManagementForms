using System;
using System.Collections;

namespace Baumax.Domain
{
	#region EmployeeLongTimeAbsence

	/// <summary>
	/// EmployeeLongTimeAbsence object for NHibernate mapped table 'Employee_LongTimeAbsence'.
	/// </summary>
	[Serializable]
	public class EmployeeLongTimeAbsence : BaseEntity
		{
		#region Member Variables
		
		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected long _employeeID;
		protected long _longTimeAbsenceID;

        protected string _employeeFullName = String.Empty;
        protected string _longTimeAbsenceName = String.Empty;

        [NonSerialized]
        protected bool _Modified = false;
        [NonSerialized]
        protected LongTimeAbsence _absence = null;
		#endregion

		#region Constructors

		public EmployeeLongTimeAbsence() 
        {
            this.BeginTime = DateTime.Now;
            this.EndTime = Baumax.Contract.DateTimeSql.SmallDatetimeMax;
        }

		public EmployeeLongTimeAbsence( DateTime beginTime, DateTime endTime, long employeeID, long longTimeAbsenceID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			this._employeeID = employeeID;
			this._longTimeAbsenceID = longTimeAbsenceID;
		}

		#endregion

		#region Public Properties


		public virtual DateTime BeginTime
		{
			get { return _beginTime; }
			set { _beginTime = value; }
		}

		public virtual DateTime EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}

		public virtual long LongTimeAbsenceID
		{
			get { return _longTimeAbsenceID; }
			set { _longTimeAbsenceID = value; }
		}

        public virtual string EmployeeFullName
        {
            get { return _employeeFullName; }
            set { _employeeFullName = value; }
        }
        public virtual string LongTimeAbsenceName
        {
            get { return _longTimeAbsenceName; }
            set { _longTimeAbsenceName = value; }
        }
        #endregion

        public virtual bool IsContainDate(DateTime date)
        {
            return (BeginTime <= date && date <= EndTime);
        }
        public virtual bool Modified
        {
            get { return _Modified ;}

            set {_Modified = value; }
        }
        public virtual LongTimeAbsence Absence
        {
            get { return _absence; }

            set { _absence = value; }
        }
    }

	#endregion
}
