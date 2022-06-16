using System;
using System.Collections;

namespace Baumax.Domain
{
	#region PersonMinMax

	/// <summary>
	/// PersonMinMax object for NHibernate mapped table 'PersonMinMax'.
	/// </summary>
	[Serializable]
    public class PersonMinMax : BaseEntity
		{
		#region Member Variables
		
		protected short _year;
		protected short _min;
		protected short _max;
		protected long _Store_WorldID;
			
#endregion

		#region Constructors

		public PersonMinMax() { }

		public PersonMinMax( short year, short min, short max, long store_WorldID )
		{
			this._year = year;
			this._min = min;
			this._max = max;
			this._Store_WorldID = store_WorldID;
		}

		#endregion

		#region Public Properties

		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
		}

		public virtual short Min
		{
			get { return _min; }
			set { _min = value; }
		}

		public virtual short Max
		{
			get { return _max; }
			set { _max = value; }
		}

		public virtual long Store_WorldID
		{
			get { return _Store_WorldID; }
			set { _Store_WorldID = value; }
		}
		#endregion

        #region Helper methods

        public static bool IsIntersectByYearAndWorld(PersonMinMax a, PersonMinMax b)
        {
            if (a == null || b == null) throw new NullReferenceException();
            bool isintersect = false;

            if (a.ID != b.ID)// don't compare with self
            {
                if (a.Year == b.Year && a.Store_WorldID == b.Store_WorldID)
                {
                    isintersect = true;
                }
            }

            return isintersect;
        }
        #endregion
    }

	#endregion
}
