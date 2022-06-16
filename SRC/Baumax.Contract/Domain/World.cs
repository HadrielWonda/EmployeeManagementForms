using System;
using System.Collections;

namespace Baumax.Domain
{
	#region World

	/// <summary>
	/// World object for NHibernate mapped table 'World'.
	/// </summary>
	[Serializable]
    public class World : BaseEntity
		{
		#region Member Variables
		
		protected int _exSystemID;
		
		protected long _languageID;
		protected string _name;
		protected bool _import;

		protected WorldType _worldTypeID;

		#endregion

		#region Constructors

		public World() { }

		public World(int exSystemID, WorldType worldTypeID, long languageID, string name)
		{
			this._languageID = languageID;
			this._name = name;
			this._exSystemID = exSystemID;
			this._worldTypeID = worldTypeID;
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

		public virtual bool Import
		{
			get { return _import; }
			set { _import = value; }
		}

		public virtual int ExSystemID
		{
			get { return _exSystemID; }
			set { _exSystemID = value; }
		}

		public virtual WorldType WorldTypeID
		{
			get { return _worldTypeID; }
			set { _worldTypeID = value; }
		}
		#endregion
	}

	#endregion
}
