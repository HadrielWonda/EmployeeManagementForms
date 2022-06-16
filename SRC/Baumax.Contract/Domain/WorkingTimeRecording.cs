using System;
using System.Collections;
using Baumax.Contract;

namespace Baumax.Domain
{
	#region TimeRecording

	/// <summary>
	/// TimeRecording object for NHibernate mapped table 'TimeRecording'.
	/// </summary>
	[Serializable]
    public class WorkingTimeRecording : BaseEntity, IEmployeeTimeRange
		{
		#region Member Variables
		
		protected DateTime _date;
		protected short _begin;
		protected short _end;
		protected short _time;
		protected long _employeeID;

		#endregion

		#region Constructors

		public WorkingTimeRecording() { }

		public WorkingTimeRecording( DateTime date, short begin, short end, short time, long employeeID )
		{
			this._date = date;
			this._begin = begin;
			this._end = end;
			this._time = time;
			this._employeeID = employeeID;
		}

		#endregion

		#region Public Properties

		public virtual DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public virtual short Begin
		{
			get { return _begin; }
			set { _begin = value; }
		}

		public virtual short End
		{
			get { return _end; }
			set { _end = value; }
		}

		public virtual short Time
		{
			get { return _time; }
			set { _time = value; }
		}

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}
        public virtual long AbsenceID
        {
            get { return 0; }
            set { }
        }

        public virtual Absence Absence
        {
            get { return null; }
            set { }
        }

        public virtual decimal Days 
        {
            get { return 0; }
        }
		#endregion

	}

	#endregion
}
