using System;
using Baumax.Domain;

namespace Baumax.Domain
{
    [Serializable]
    public class UserRegion : BaseEntity
	{

		#region Private Members

		private User _user; 
		private long _regionid; 		
		#endregion

		#region Constructor

		public UserRegion()
		{
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		#region Public Properties
			
		public virtual User User
		{
			get
			{ 
				return _user;
			}
			set
			{
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for User", value, "null");

				_user = value;
			}

		}
			
		public virtual long RegionID
		{
			get
			{ 
				return _regionid;
			}
			set
			{
				_regionid = value;
			}

		}
				
		#endregion 
	}
}
