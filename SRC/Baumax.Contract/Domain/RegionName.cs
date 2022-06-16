using System;
using System.Collections;

namespace Baumax.Domain
{
	#region RegionName

	/// <summary>
	/// RegionName object for NHibernate mapped table 'RegionName'.
	/// </summary>
	[Serializable]
    public class RegionName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected Region _region;

		#endregion

		#region Constructors

		public RegionName() { }

		public RegionName( long languageID, string name, Region region )
		{
			this._languageID = languageID;
			this._name = name;
			this._region = region;
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

		public virtual Region Region
		{
			get { return _region; }
			set { _region = value; }
		}
		#endregion
	}

	#endregion
}
