using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Store

	/// <summary>
	/// Store object for NHibernate mapped table 'Store'.
	/// </summary>
	[Serializable]
    public class Store : BaseEntity
		{
		#region Member Variables

		protected bool _import;
		protected long _languageID;
		protected string _name;
		protected int _systemID;
		protected string _number;
		protected string _city;
		protected string _address;
		protected int _area;
		protected long _regionID;
        protected long _countryID;

		#endregion

		#region Constructors

		public Store() { }

		public Store( int systemID, string number, string location, long regionID, bool import )
		{
			this._systemID = systemID;
			this._number = number;
			this._regionID = regionID;
			this._import = import;
		}

		#endregion

		#region Public Properties

		public virtual bool Import
		{
			get { return _import; }
			set { _import = value; }
		}

		public virtual int SystemID
		{
			get { return _systemID; }
			set { _systemID = value; }
		}

		public virtual string Number
		{
			get { return _number; }
			set 
			{
				if (value != null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Number", value, value.ToString());
				_number = value; 
			}
		}

		public virtual string City
		{
			get { return _city; }
			set
			{
				if (value != null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				_city = value;
			}
		}

		public virtual string Address
		{
			get { return _address; }
			set
			{
				if (value != null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for Address", value, value.ToString());
				_address = value;
			}
		}

		public virtual int Area
		{
			get { return _area; }
			set { _area = value; }
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

		public virtual long RegionID
		{
			get { return _regionID; }
			set { _regionID = value; }
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
