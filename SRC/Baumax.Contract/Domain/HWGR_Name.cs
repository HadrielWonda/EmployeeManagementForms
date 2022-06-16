using System;
using System.Collections;

namespace Baumax.Domain
{
	#region HWGRName

	/// <summary>
	/// HWGRName object for NHibernate mapped table 'HWGR_Name'.
	/// </summary>
	[Serializable]
    public class HWGRName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected HWGR _hWGR;

		#endregion

		#region Constructors

		public HWGRName() { }

		public HWGRName( long languageID, string name, HWGR hWGR )
		{
			this._languageID = languageID;
			this._name = name;
			this._hWGR = hWGR;
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

		public virtual HWGR HWGR
		{
			get { return _hWGR; }
			set { _hWGR = value; }
		}
		#endregion
	}

	#endregion
}
