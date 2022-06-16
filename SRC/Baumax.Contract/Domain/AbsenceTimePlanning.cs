using System;
using System.Collections;

namespace Baumax.Domain
{
	#region AbsenceTime

	/// <summary>
	/// AbsenceTime object for NHibernate mapped table 'AbsenceTime'.
	/// </summary>
	[Serializable]
    public class AbsenceTimePlanning : BaseEntity, Baumax.Contract.IEmployeeTimeRange
		{
		#region Member Variables

        protected DateTime _date;
        protected short _begin;
		protected short _end;
		protected short _time;
		protected long _absenceID;
		protected long _employeeID;
        [NonSerialized]
        protected int _color = 0;
        [NonSerialized ]
        protected Absence _absence = null;
	
		#endregion

		#region Constructors

		public AbsenceTimePlanning() { }

		public AbsenceTimePlanning( short begin, short end, short time, long absenceID, long employeeID )
		{
			this._begin = begin;
			this._end = end;
			this._time = time;
			this._absenceID = absenceID;
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

		public virtual long AbsenceID
		{
			get { return _absenceID; }
			set { _absenceID = value; }
		}

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}
		#endregion
        public virtual Absence Absence
        {
            get { return _absence; }
            set { _absence = value; }
        }

        public virtual decimal Days
        {
            get  { return Utills.ToDays(_time);  }
        }

        //public virtual void ApplyTime (decimal contractHours, decimal weekDays)
        //{
        //    _time = Utills.GetEntityTime(_begin, _end, contractHours, weekDays);
        //}
        public virtual void ApplyTime(double contractHours, double weekDays)
        {
            _time = Utills.GetEntityTime(_absence, _begin, _end, contractHours, weekDays);
        }
        //public virtual void ApplyTime (decimal coeficient)
        //{
        //    _time = Utills.GetEntityTime(_begin, _end, coeficient);
        //}
    }

	#endregion
}
