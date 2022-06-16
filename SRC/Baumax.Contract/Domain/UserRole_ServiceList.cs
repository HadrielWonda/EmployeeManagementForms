using System;
using System.Collections;

namespace Baumax.Domain
{
	#region UserRoleServiceList

	/// <summary>
	/// UserRoleServiceList object for NHibernate mapped table 'UserRole_ServiceList'.
	/// </summary>
	[Serializable]
	public class UserRoleServiceList 
		{
		#region Member Variables

		int _operation;
		//protected ServiceList _serviceList;
		protected long _userRoleID;
		private long _serviceListID;
        private ServiceList _Service;

		#endregion

		#region Constructors

		public UserRoleServiceList() { }

		public UserRoleServiceList(int operation, long serviceListID, long userRoleID)
		{
			this._userRoleID = userRoleID;
			this._operation = operation;
			this._serviceListID = serviceListID;
		}

		#endregion

		#region Public Properties

		public virtual long ServiceListID
		{
			get { return _serviceListID; }
			set { _serviceListID = value; }
		}

		public virtual int Operation
		{
			get { return _operation; }
			set { _operation = value; }
		}
		
		public virtual long UserRoleID
		{
			get { return _userRoleID; }
			set { _userRoleID = value; }
		}

	    public virtual ServiceList Service
	    {
	        get { return _Service; }
	        set { _Service = value; }
	    }

		#endregion
		public override bool Equals(object obj)
		{
			UserRoleServiceList ursl = obj as UserRoleServiceList;
			if (ursl == null)
				return false;

			return ursl.ServiceListID == _serviceListID && ursl.UserRoleID == _userRoleID;
		}
		public override int GetHashCode()
		{
			return (int)_serviceListID * (int)_userRoleID;
		}

	}

	#endregion
}
