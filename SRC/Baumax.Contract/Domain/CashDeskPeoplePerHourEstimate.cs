using System;
using System.Collections;

namespace Baumax.Domain
{
	#region CashDeskPeoplePerHourEstimate

	/// <summary>
	/// CashDeskPeoplePerHourEstimate object for NHibernate mapped table 'CashDeskPeoplePerHourEstimate'.
	/// </summary>
	[Serializable]
	public class CashDeskPeoplePerHourEstimate : BaseEntity
		{
		#region Member Variables
		
		protected int _estimateYear;
		protected DateTime _date;
		protected long _storeID;
		protected byte _week;
		protected byte _weekDay;
		protected byte _month;
		protected byte _hour;
		protected short _peoplePerHour;
        protected decimal _targReceiptsPerHour;

		#endregion

		#region Constructors

		public CashDeskPeoplePerHourEstimate() { }

        public CashDeskPeoplePerHourEstimate(int estimateYear, DateTime date, long storeID, byte week, byte weekDay, byte month, byte hour, short peoplePerHour, decimal targReceiptsPerHour)
		{
			this._estimateYear = estimateYear;
			this._date = date;
			this._storeID = storeID;
			this._week = week;
			this._weekDay = weekDay;
			this._month = month;
			this._hour = hour;
			this._peoplePerHour = peoplePerHour;
            this._targReceiptsPerHour = targReceiptsPerHour;
		}

		#endregion

		#region Public Properties

		public virtual int EstimateYear
		{
			get { return _estimateYear; }
			set { _estimateYear = value; }
		}

		public virtual DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public virtual long StoreID
		{
			get { return _storeID; }
			set { _storeID = value; }
		}

		public virtual byte Week
		{
			get { return _week; }
			set { _week = value; }
		}

		public virtual byte WeekDay
		{
			get { return _weekDay; }
			set { _weekDay = value; }
		}

		public virtual byte Month
		{
			get { return _month; }
			set { _month = value; }
		}

		public virtual byte Hour
		{
			get { return _hour; }
			set { _hour = value; }
		}

		public virtual short PeoplePerHour
		{
			get { return _peoplePerHour; }
			set { _peoplePerHour = value; }
		}

        public virtual decimal TargReceiptsPerHour
        {
            get { return _targReceiptsPerHour; }
            set { _targReceiptsPerHour = value; }
        }


		#endregion
		
	}

	#endregion
}
