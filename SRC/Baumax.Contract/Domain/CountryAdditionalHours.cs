using System;
using System.Collections;

namespace Baumax.Domain
{
	#region CountryAdditionalHour

	/// <summary>
	/// CountryAdditionalHour object for NHibernate mapped table 'CountryAdditionalHours'.
	/// </summary>
	[Serializable]
	public class CountryAdditionalHour : BaseEntity
		{
		#region Member Variables
		
		protected short _year;
		protected byte _weekDay;
		protected short _beginTime;
		protected short _endTime;
        protected decimal _factorEarly;
        protected decimal _factorLate;
        protected long _countryID;

		#endregion

		#region Constructors

		public CountryAdditionalHour() { }

        public CountryAdditionalHour(short year, byte weekDay, short beginTime, short endTime, decimal factorEarly, decimal factorLate, long countryID)
		{
			this._year = year;
			this._weekDay = weekDay;
			this._beginTime = beginTime;
			this._endTime = endTime;
            this._factorEarly = factorEarly;
            this._factorLate = factorLate;
            this._countryID = countryID;
		}

		#endregion

		#region Public Properties

		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
		}

		public virtual byte WeekDay
		{
			get { return _weekDay; }
			set { _weekDay = value; }
		}

		public virtual short BeginTime
		{
			get { return _beginTime; }
			set { _beginTime = value; }
		}

		public virtual short EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

        public virtual decimal FactorEarly
        {
            get { return _factorEarly; }
            set { _factorEarly = value; }
        }

        public virtual decimal FactorLate
        {
            get { return _factorLate; }
            set { _factorLate = value; }
        }

		public virtual long CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

		#endregion
		
       
	}

	#endregion
}
