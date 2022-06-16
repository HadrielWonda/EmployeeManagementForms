using System;
using System.Collections;

namespace Baumax.Domain
{
	#region CountryName

	/// <summary>
	/// CountryName object for NHibernate mapped table 'CountryName'.
	/// </summary>
	[Serializable]
    public class CountryName : BaseEntity
		{
		#region Member Variables

        protected long _languageID;
		protected string _name;
		protected Country _country;

		#endregion

		#region Constructors

		public CountryName() { }

        public CountryName(long languageID, string name, Country country)
		{
			this._languageID = languageID;
			this._name = name;
			this._country = country;
		}

		#endregion

		#region Public Properties

        public virtual long LanguageID
		{
			get { return _languageID; }
			set { _languageID = value; }
		}

		public virtual string Name
		{
			get { return _name; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		public virtual Country Country
		{
			get { return _country; }
			set { _country = value; }
		}
		#endregion
	}

	#endregion
}
