using System;
using System.Collections;

namespace Baumax.Domain
{
	#region LongTimeAbsence

	/// <summary>
	/// LongTimeAbsence object for NHibernate mapped table 'LongTimeAbsence'.
	/// </summary>
	[Serializable]
	public class LongTimeAbsence : BaseEntity
		{
		#region Member Variables

        protected string _charID;
        protected long? countryID;
        protected short? _code;
		protected string _codeName;
        protected bool _import;
        protected int _color;

		#endregion

		#region Constructors

		public LongTimeAbsence() { }

		public LongTimeAbsence( short code, string codeName)
		{
			this._code = code;
			this._codeName = codeName;
		}

		#endregion

		#region Public Properties

        public virtual string CharID
        {
            get { return _charID; }
            set
            {
                if (value != null && value.Length > 6)
                    throw new ArgumentOutOfRangeException("Invalid value for CharID", value, value.ToString());
                _charID = value;
            }
        }

        public virtual int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public virtual long? CountryID
        {
            get { return countryID; }
            set { countryID = value; }
        }

        public virtual bool Import
        {
            get { return _import; }
            set { _import = value; }
        }

		public virtual short? Code
		{
			get { return _code; }
			set { _code = value; }
		}

		public virtual string CodeName
		{
			get { return _codeName; }
			set
			{
				if ( value != null && value.Length > 30)
					throw new ArgumentOutOfRangeException("Invalid value for CodeName", value, value.ToString());
				_codeName = value;
			}
		}
		#endregion
	}

	#endregion
}
