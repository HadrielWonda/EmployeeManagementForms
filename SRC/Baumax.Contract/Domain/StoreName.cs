using System;
using System.Collections;

namespace Baumax.Domain
{
	#region StoreName

	/// <summary>
	/// StoreName object for NHibernate mapped table 'StoreName'.
	/// </summary>
	[Serializable]
    public class StoreName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected Store _store;

		#endregion

		#region Constructors

		public StoreName() { }

		public StoreName( long languageID, string name, Store store )
		{
			this._languageID = languageID;
			this._name = name;
			this._store = store;
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

		public virtual Store Store
		{
			get { return _store; }
			set { _store = value; }
		}
		#endregion
	}

	#endregion
}
