using System;
using System.Collections;

namespace Baumax.Domain
{
	#region EmployeeRelation

	/// <summary>
	/// EmployeeRelation object for NHibernate mapped table 'Employee_Relations'.
	/// </summary>
	[Serializable]
	public class EmployeeRelation : BaseEntity, IComparable <EmployeeRelation>
		{
		#region Member Variables
		
		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected long? _hwgr_ID;
		protected long _storeID;
		protected long _employeeID;
		protected long? _worldID;
        [NonSerialized ]
        protected string _storeName;
        [NonSerialized]
        protected string _worldName;

        [NonSerialized]
        protected string _employeeName;

		#endregion

		#region Constructors

		public EmployeeRelation() { }

		public EmployeeRelation( DateTime beginTime, DateTime endTime, long worldHWGR_ID, long storeID, long employeeID, long storeWorldID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			this._hwgr_ID = worldHWGR_ID;
			this._storeID = storeID;
			this._employeeID = employeeID;
			this._worldID = storeWorldID;
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

		public virtual long? HWGR_ID
		{
			get { return _hwgr_ID; }
			set { _hwgr_ID = value; }
		}

		public virtual long StoreID
		{
			get { return _storeID; }
			set { _storeID = value; }
		}

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}

		public virtual long? WorldID
		{
			get { return _worldID; }
			set { _worldID = value; }
		}
        public virtual string StoreName
        {
            get { return _storeName; }
            set { _storeName = value; }
        }

        public virtual string WorldName
        {
            get { return _worldName; }
            set { _worldName = value; }
        }
        public virtual string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }
		#endregion

        public virtual bool IsContainDate(DateTime date)
        {
            return (BeginTime <= date && date <= EndTime);
        }

        public virtual bool IsValidRelation()
        {
            return BeginTime <= EndTime;
        }

        public virtual EmployeeRelation GetCopy()
        {
            return (EmployeeRelation)MemberwiseClone();
        }

        public virtual int CompareTo(EmployeeRelation entity)
        {
            if (entity == null) return -1;

            int i = EmployeeID.CompareTo(entity.EmployeeID);
            if (i == 0)
            {
                i = BeginTime.CompareTo(entity.BeginTime);
            }

            return i;
        }
	}

	#endregion
}
