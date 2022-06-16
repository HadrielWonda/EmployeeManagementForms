using System;
using System.Collections;

namespace Baumax.Domain
{
	#region UserRole

	/// <summary>
	/// UserRole object for NHibernate mapped table 'UserRole'.
	/// </summary>
	[Serializable]
    public class UserRole : BaseEntity
		{
		#region Member Variables

		protected string _name;
		protected long _languageID;
		protected IList _userRoleServiceList;
		protected IList _userRoleNames;

		#endregion

		#region Constructors

		public UserRole() { }

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

		public virtual IList UserRoleServiceList
		{
			get
			{
				if (_userRoleServiceList==null)
					{
					_userRoleServiceList = new ArrayList();
				}
				return _userRoleServiceList;
			}
			set { _userRoleServiceList = value; }
		}

	    #endregion
	}

	#endregion
}
