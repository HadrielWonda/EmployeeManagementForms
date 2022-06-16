using System;
using System.Collections;

namespace Baumax.Domain
{
	#region StoreAdditionalHour

	/// <summary>
	/// StoreAdditionalHour object for NHibernate mapped table 'StoreAdditionalHours'.
	/// </summary>
	[Serializable]
	public class StoreAdditionalHour : BaseEntity
		{
		#region Member Variables
		
		protected DateTime _beginDate;
		protected DateTime _endDate;
		protected byte _weekDay;
		protected decimal _additionalHours;
		protected long _storeID;

		#endregion

		#region Constructors

		public StoreAdditionalHour() { }

		public StoreAdditionalHour( DateTime beginDate, DateTime endDate, byte weekDay, decimal additionalHours, long storeID )
		{
			this._beginDate = beginDate;
			this._endDate = endDate;
			this._weekDay = weekDay;
			this._additionalHours = additionalHours;
			this._storeID = storeID;
		}

		#endregion

		#region Public Properties

		public virtual DateTime BeginDate
		{
			get { return _beginDate; }
			set { _beginDate = value; }
		}

		public virtual DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		public virtual byte WeekDay
		{
			get { return _weekDay; }
			set { _weekDay = value; }
		}

		public virtual decimal AdditionalHours
		{
			get { return _additionalHours; }
			set { _additionalHours = value; }
		}

		public virtual long StoreID
		{
			get { return _storeID; }
			set { _storeID = value; }
		}

		#endregion
		
	}

	#endregion
}
