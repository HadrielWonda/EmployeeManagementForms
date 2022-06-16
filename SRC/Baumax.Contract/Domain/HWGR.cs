using System;
using System.Collections;

namespace Baumax.Domain
{
	#region HWGR

	/// <summary>
	/// HWGR object for NHibernate mapped table 'HWGR'.
	/// </summary>
	[Serializable]
    public class HWGR : BaseEntity
		{
		#region Member Variables

		protected long _languageID;
		protected string _name;
		protected int _systemID;
		protected bool _import;

		#endregion

		#region Constructors

		public HWGR() { }

		public HWGR(int systemID, long languageID, string name)
		{
			this._languageID = languageID;
			this._name = name;
			this._systemID = systemID;
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

		public virtual int SystemID
		{
			get { return _systemID; }
			set { _systemID = value; }
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
