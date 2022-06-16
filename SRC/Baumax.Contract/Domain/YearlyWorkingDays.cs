using System;
using System.Collections;

namespace Baumax.Domain
{
	#region YearlyWorkingDay

	/// <summary>
	/// YearlyWorkingDay object for NHibernate mapped table 'YearlyWorkingDays'.
	/// </summary>
	[Serializable]
	public class YearlyWorkingDay : BaseEntity
		{
		#region Member Variables
		
		protected DateTime _workingDay;
		protected long? _countryID;

		#endregion

		#region Constructors

		public YearlyWorkingDay() { }

		public YearlyWorkingDay( DateTime workingDay, long? countryID )
		{
			this._workingDay = workingDay;
			this._countryID = countryID;
		}

		#endregion

		#region Public Properties


		public virtual DateTime WorkingDay
		{
			get { return _workingDay; }
			set { _workingDay = value; }
		}

		public virtual long? CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}
		#endregion
	}

	#endregion
}
