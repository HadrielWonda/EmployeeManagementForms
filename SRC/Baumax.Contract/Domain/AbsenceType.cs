using System;
using System.Collections;

namespace Baumax.Domain
{
	#region AbsenceType

	/// <summary>
	/// AbsenceType object for NHibernate mapped table 'AbsenceType'.
	/// </summary>
	[Serializable]
    public class AbsenceType : BaseEntity, System.IComparable
		{
		#region Member Variables
		
		protected IList _absences;
		protected IList _absenceTypeNames;
		protected static String _sortExpression = "ID";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public AbsenceType() { }

		#endregion

		#region Public Properties

		public IList Absences
		{
			get
			{
				if (_absences==null)
				{
					_absences = new ArrayList();
				}
				return _absences;
			}
			set { _absences = value; }
		}

		public IList AbsenceTypeNames
		{
			get
			{
				if (_absenceTypeNames==null)
				{
					_absenceTypeNames = new ArrayList();
				}
				return _absenceTypeNames;
			}
			set { _absenceTypeNames = value; }
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
			if (!(obj is AbsenceType))
				throw new InvalidCastException("This object is not of type AbsenceType");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "ID":
					relativeValue = this.ID.CompareTo(((AbsenceType)obj).ID);
					break;
                default:
                    goto case "ID";
			}
            if (AbsenceType.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
