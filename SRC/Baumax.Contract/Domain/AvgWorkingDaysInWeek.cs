using System;
using System.Collections;

namespace Baumax.Domain
{
	#region AvgWorkingDaysInWeek

	/// <summary>
	/// AvgWorkingDaysInWeek object for NHibernate mapped table 'AvgWorkingDaysInWeek'.
	/// </summary>
	[Serializable]
    public class AvgWorkingDaysInWeek : BaseEntity
	{
		#region Member Variables
		
		protected short _year;
		protected decimal _daysCount;
		protected long _countryID;

		#endregion

		#region Constructors

		public AvgWorkingDaysInWeek() { }

		public AvgWorkingDaysInWeek( short year, decimal daysCount, long countryID )
		{
			this._year = year;
			this._daysCount = daysCount;
			this._countryID = countryID;
		}

		#endregion

		#region Public Properties

		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
		}

		public virtual decimal DaysCount
		{
			get { return _daysCount; }
			set { _daysCount = value; }
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
