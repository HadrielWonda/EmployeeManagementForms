using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Feast

	/// <summary>
	/// Feast object for NHibernate mapped table 'Feasts'.
	/// </summary>
	[Serializable]
    public class Feast : BaseEntity
		{
		#region Member Variables
		
		protected DateTime _feastDate;
		protected long _countryID;
		#endregion

		#region Constructors

		public Feast() { }

		public Feast(DateTime feastDate, long countryID)
		{
			this._feastDate = feastDate;
			this._countryID = countryID;
		}

		#endregion

		#region Public Properties

		public virtual DateTime FeastDate
		{
			get { return _feastDate; }
			set { _feastDate = value; }
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
