using System;
using System.Collections;

namespace Baumax.Domain
{
	#region HWGREmployee

	/// <summary>
	/// HWGREmployee object for NHibernate mapped table 'HWGR_Employee'.
	/// </summary>
	[Serializable]
	public class HWGREmployee : BaseEntity, System.IComparable
		{
		#region Member Variables
		
		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected long _employeeID;
		protected long _hWGR_ID;
		protected static String _sortExpression = "ID";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public HWGREmployee() { }

		public HWGREmployee( DateTime beginTime, DateTime endTime, long employeeID, long hWGR_ID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			this._employeeID = employeeID;
			this._hWGR_ID = hWGR_ID;
		}

		#endregion

		#region Public Properties

		public DateTime BeginTime
		{
			get { return _beginTime; }
			set { _beginTime = value; }
		}

		public DateTime EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		public long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}

		public long HWGR_ID
		{
			get { return _hWGR_ID; }
			set { _hWGR_ID = value; }
		}

        public static String SortExpression
        {
            get { return _sortExpression; }
            set { _sortExpression = value; }
        }

        public static SortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }
		#endregion
		
        #region IComparable Methods
        public int CompareTo(object obj)
        {
			if (!(obj is HWGREmployee))
				throw new InvalidCastException("This object is not of type HWGREmployee");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "ID":
					relativeValue = this.ID.CompareTo(((HWGREmployee)obj).ID);
					break;
				case "BeginTime":
					relativeValue = (this.BeginTime != null) ? this.BeginTime.CompareTo(((HWGREmployee)obj).BeginTime) : -1;
					break;
				case "EndTime":
					relativeValue = (this.EndTime != null) ? this.EndTime.CompareTo(((HWGREmployee)obj).EndTime) : -1;
					break;
                default:
                    goto case "ID";
			}
            if (HWGREmployee.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
