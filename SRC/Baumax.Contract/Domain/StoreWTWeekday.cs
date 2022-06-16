using System;
using System.Collections;

namespace Baumax.Domain
{
	#region StoreWTWeekday

	/// <summary>
	/// StoreWTWeekday object for NHibernate mapped table 'StoreWTWeekday'.
	/// </summary>
	[Serializable]
	public class StoreWTWeekday : BaseEntity
		{
		#region Member Variables
		
		protected byte _weekday;
		protected short _opentime;
		protected short _closetime;
        protected StoreWorkingTime _storeWorkingTime;

		#endregion

		#region Constructors

		public StoreWTWeekday() { }

        public StoreWTWeekday(byte weekday, short opentime, short closetime, StoreWorkingTime storeWorkingTime)
		{
			this._weekday = weekday;
			this._opentime = opentime;
			this._closetime = closetime;
            this._storeWorkingTime = storeWorkingTime;
		}

		#endregion

		#region Public Properties

		public virtual byte Weekday
		{
			get { return _weekday; }
			set { _weekday = value; }
		}

		public virtual short Opentime
		{
			get { return _opentime; }
			set { _opentime = value; }
		}

		public virtual short Closetime
		{
			get { return _closetime; }
			set { _closetime = value; }
		}

	    public virtual StoreWorkingTime StoreWorkingTime
	    {
            get { return _storeWorkingTime; }
            set { _storeWorkingTime = value; }
	    }
		#endregion
	}

	#endregion
}
