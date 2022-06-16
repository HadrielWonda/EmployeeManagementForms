using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Region

	/// <summary>
	/// Region object for NHibernate mapped table 'Region'.
	/// </summary>
	[Serializable]
    public class Region : BaseEntity
		{
		#region Member Variables

		protected long _languageID;
		protected string _name;
		protected bool _import;
		protected string _regionSysID;

		protected long _countryID;

		#endregion

		#region Constructors

		public Region() { }

		public Region( long countryID,long languageID, string name )
		{
			this._languageID = languageID;
			this._name = name;
			this._countryID = countryID;
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
				if (value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		public virtual string RegionSysID
		{
			get { return _regionSysID; }
			set
			{
				if (value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for RegionSysID", value, value.ToString());
				_regionSysID = value;
			}
		}

		public virtual long CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

		public virtual bool Import
		{
			get { return _import; }
			set { _import = value; }
		}
		#endregion
	}

	#endregion
}
