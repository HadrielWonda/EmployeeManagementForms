using System;

namespace Baumax.Domain
{
    #region YearlyClosedDays

    /// <summary>
    /// YearlyClosedDays object for NHibernate mapped table 'YearlyClosedDays'.
    /// </summary>
    [Serializable]
    public class YearlyClosedDays : BaseEntity
    {
		#region Member Variables
		
		protected DateTime _closedDay;
		protected long? _countryID;

		#endregion

		#region Constructors

		public YearlyClosedDays() { }

        public YearlyClosedDays(DateTime closedDay, long? countryID)
		{
			_closedDay = closedDay;
			_countryID = countryID;
		}

		#endregion

		#region Public Properties


		public DateTime ClosedDay
		{
			get { return _closedDay; }
			set { _closedDay = value; }
		}

		public long? CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

		#endregion
	}

	#endregion
}

        
    