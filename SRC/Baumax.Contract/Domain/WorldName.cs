using System;
using System.Collections;

namespace Baumax.Domain
{
	#region WorldName

	/// <summary>
	/// WorldName object for NHibernate mapped table 'WorldName'.
	/// </summary>
	[Serializable]
    public class WorldName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected World _world;

		#endregion

		#region Constructors

		public WorldName() { }

		public WorldName( long languageID, string name, World world )
		{
			this._languageID = languageID;
			this._name = name;
			this._world = world;
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

		public virtual World World
		{
			get { return _world; }
			set { _world = value; }
		}
		#endregion
	}

	#endregion
}
