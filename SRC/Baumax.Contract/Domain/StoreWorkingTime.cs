using System;
using System.Collections;

namespace Baumax.Domain
{
	#region StoreWorkingTime

	/// <summary>
	/// StoreWorkingTime object for NHibernate mapped table 'StoreWorkingTime'.
	/// </summary>
	[Serializable]
	public class StoreWorkingTime : BaseEntity
		{
		#region Member Variables
		
		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected long _storeID;
		protected IList _storeWTWeekdays;

		#endregion

		#region Constructors

		public StoreWorkingTime() { }

		public StoreWorkingTime( DateTime beginTime, DateTime endTime, long storeID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			this._storeID = storeID;
		}

		#endregion

		#region Public Properties

		public virtual DateTime BeginTime
		{
			get { return _beginTime; }
			set { _beginTime = value; }
		}

		public virtual DateTime EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		public virtual long StoreID
		{
			get { return _storeID; }
			set { _storeID = value; }
		}

		public virtual IList StoreWTWeekdays
		{
			get
			{
				if (_storeWTWeekdays==null)
				{
					_storeWTWeekdays = new ArrayList();
				}
				return _storeWTWeekdays;
			}
			set { _storeWTWeekdays = value; }
		}
		#endregion
	}
	#endregion
}
