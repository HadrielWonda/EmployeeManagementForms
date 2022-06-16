using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Country

	/// <summary>
	/// Country object for NHibernate mapped table 'Country'.
	/// </summary>
	[Serializable]
	public class Country : BaseEntity
		{
        [NonSerialized]
        private string _languagename = String.Empty;
		#region Member Variables

		protected byte _warningDays;
		protected byte _maxDays;
		protected byte _systemID1;
		protected string _systemID2;
		protected bool _import;
		protected long _languageID;

        protected PersShowModeType _PersShowMode;
		protected long _CountryLanguage;
		protected string _name;


		#endregion

		#region Constructors

		public Country() { }

		public Country(byte systemID1, string systemID2, long countryLanguage, long languageID, string name)
		{
			this._systemID1 = systemID1;
			this._systemID2 = systemID2;
			this._languageID = languageID;
			this._name = name;
			this._CountryLanguage = countryLanguage;
		}

		#endregion

		#region Public Properties

        public virtual PersShowModeType PersShowMode
        {
            get { return _PersShowMode; }
            set { _PersShowMode = value; }
        }

		public virtual byte WarningDays
		{
			get { return _warningDays; }
			set { _warningDays = value; }
		}

		public virtual byte MaxDays
		{
			get { return _maxDays; }
			set { _maxDays = value; }
		}

		public virtual byte SystemID1
		{
			get { return _systemID1; }
			set { _systemID1 = value; }
		}

		public virtual string SystemID2
		{
			get { return _systemID2; }
			set
			{
				if (value != null && value.Length > 2)
					throw new ArgumentOutOfRangeException("Invalid value for SystemID2", value, value.ToString());
				_systemID2 = value;
			}
		}

		public virtual bool Import
		{
			get { return _import; }
			set { _import = value; }
		}

		public virtual long CountryLanguage
		{
			get { return _CountryLanguage; }
			set { _CountryLanguage = value; }
		}


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
				if (value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}
	    
        public virtual string LanguageName
        {
            get { return _languagename; }
            set { _languagename = value; }
        }
        #endregion
    }

	#endregion
}
