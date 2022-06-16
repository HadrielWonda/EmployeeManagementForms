using System;
using System.Collections;

namespace Baumax.Domain
{
	#region WorldEmployee

	/// <summary>
	/// WorldEmployee object for NHibernate mapped table 'World_Employee'.
	/// </summary>
	[Serializable]
    public class WorldEmployee : BaseEntity, System.IComparable
		{
		#region Member Variables
		
		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected World _world;
		protected Employee _employee;
		protected static String _sortExpression = "ID";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public WorldEmployee() { }

		public WorldEmployee( DateTime beginTime, DateTime endTime, World world, Employee employee )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			this._world = world;
			this._employee = employee;
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

		public World World
		{
			get { return _world; }
			set { _world = value; }
		}

		public Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
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
			if (!(obj is WorldEmployee))
				throw new InvalidCastException("This object is not of type WorldEmployee");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "ID":
					relativeValue = this.ID.CompareTo(((WorldEmployee)obj).ID);
					break;
				case "BeginTime":
					relativeValue = this.BeginTime.CompareTo(((WorldEmployee)obj).BeginTime);
					break;
				case "EndTime":
					relativeValue = this.EndTime.CompareTo(((WorldEmployee)obj).EndTime);
					break;
                default:
                    goto case "ID";
			}
            if (WorldEmployee.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
