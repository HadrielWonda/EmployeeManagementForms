using System;
using System.Collections;

namespace Baumax.Domain
{
	#region ServiceList

	/// <summary>
	/// ServiceList object for NHibernate mapped table 'ServiceList'.
	/// </summary>
	[Serializable]
	public class ServiceList : BaseEntity
		{
		#region Member Variables
		
		protected Guid _serviceID;
		protected string _seviceName;
		protected UserRoleServiceList _userRoleServiceList;

		#endregion

		#region Constructors

		public ServiceList() { }

		public ServiceList( Guid serviceID, string seviceName )
		{
			this._serviceID = serviceID;
			this._seviceName = seviceName;
		}

		#endregion

		#region Public Properties

		public virtual Guid ServiceID
		{
			get { return _serviceID; }
			set { _serviceID = value; }
		}

		public virtual string SeviceName
		{
			get { return _seviceName; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for SeviceName", value, value.ToString());
				_seviceName = value;
			}
		}

		public virtual UserRoleServiceList UserRoleServiceList
		{
			get { return _userRoleServiceList; }
			set { _userRoleServiceList = value; }
		}
		#endregion
	}

	#endregion
}
/*
<one-to-one name="UserRoleServiceList" class="Baumax.Domain.UserRoleServiceList, Baumax.Dao">
			<column name="ServiceListID" sql-type="bigint" not-null="true"/>
		</one-to-one>
*/