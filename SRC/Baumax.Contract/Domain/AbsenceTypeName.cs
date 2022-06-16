using System;
using System.Collections;

namespace Baumax.Domain
{
	#region AbsenceTypeName

	/// <summary>
	/// AbsenceTypeName object for NHibernate mapped table 'AbsenceTypeName'.
	/// </summary>
	[Serializable]
    public class AbsenceTypeName : BaseEntity, System.IComparable
		{
		#region Member Variables
		
		protected long _languageID;
		protected string _name;
		protected AbsenceType _absenceType;
		protected static String _sortExpression = "ID";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public AbsenceTypeName() { }

		public AbsenceTypeName( long languageID, string name, AbsenceType absenceType )
		{
			this._languageID = languageID;
			this._name = name;
			this._absenceType = absenceType;
		}

		#endregion

		#region Public Properties

		public long LanguageID
		{
			get { return _languageID; }
			set { _languageID = value; }
		}

		public string Name
		{
			get { return _name; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		public AbsenceType AbsenceType
		{
			get { return _absenceType; }
			set { _absenceType = value; }
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
			if (!(obj is AbsenceTypeName))
				throw new InvalidCastException("This object is not of type AbsenceTypeName");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "ID":
					relativeValue = this.ID.CompareTo(((AbsenceTypeName)obj).ID);
					break;
				case "LanguageID":
					relativeValue = this.LanguageID.CompareTo(((AbsenceTypeName)obj).LanguageID);
					break;
				case "Name":
					relativeValue = (this.Name != null) ? this.Name.CompareTo(((AbsenceTypeName)obj).Name) : -1;
					break;
                default:
                    goto case "ID";
			}
            if (AbsenceTypeName.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
