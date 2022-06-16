using System;
using System.Collections;

namespace Baumax.Domain
{
	#region AbsenceName

	/// <summary>
	/// AbsenceName object for NHibernate mapped table 'AbsenceName'.
	/// </summary>
	[Serializable]
    public class AbsenceName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected Absence _absence;

		#endregion

		#region Constructors

		public AbsenceName() { }

		public AbsenceName( long languageID, string name, Absence absence )
		{
			this._languageID = languageID;
			this._name = name;
			this._absence = absence;
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

		public virtual Absence Absence
		{
			get { return _absence; }
			set { _absence = value; }
		}
		#endregion
	}

	#endregion
}
