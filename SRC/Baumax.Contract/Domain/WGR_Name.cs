using System;
using System.Collections;

namespace Baumax.Domain
{
	#region WGRName

	/// <summary>
	/// WGRName object for NHibernate mapped table 'WGR_Name'.
	/// </summary>
	[Serializable]
    public class WGRName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected WGR _wRG;

		#endregion

		#region Constructors

		public WGRName() { }

		public WGRName( long languageID, string name, WGR wRG )
		{
			this._languageID = languageID;
			this._name = name;
			this._wRG = wRG;
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

		public virtual WGR WRG_
		{
			get { return _wRG; }
			set { _wRG = value; }
		}
		#endregion
	}

	#endregion
}
