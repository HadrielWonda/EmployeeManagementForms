using System;
using System.Collections;

namespace Baumax.Domain
{
	#region UserRoleName

	/// <summary>
	/// UserRoleName object for NHibernate mapped table 'UserRoleName'.
	/// </summary>
	[Serializable]
    public class UserRoleName : BaseEntity
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected UserRole _userRole;

		#endregion

		#region Constructors

		public UserRoleName() { }

		public UserRoleName( long languageID, string name, UserRole userRole )
		{
			this._languageID = languageID;
			this._name = name;
			this._userRole = userRole;
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
				if ( value != null && value.Length > 25)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		public virtual UserRole UserRole
		{
			get { return _userRole; }
			set { _userRole = value; }
		}
		#endregion
	}

	#endregion
}
