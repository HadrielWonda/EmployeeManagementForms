using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Absence

	/// <summary>
	/// Absence object for NHibernate mapped table 'Absence'.
	/// </summary>
	[Serializable]
    public class Absence : BaseEntity
		{
		#region Member Variables

        protected bool _import;
        protected int? _systemID;
        protected bool _withoutFixedTime;
		protected long _languageID;
		protected string _name;
		protected int _color;
		protected string _charID;
		protected bool _useInCalck;
		protected bool _isFixed;
        protected bool _CountAsOneDay = false;
		protected double _value;
        protected AbsenceType _absenceTypeID = AbsenceType.Absence ;
		protected long _countryID;
        protected IsShowAbsence _IsShow = IsShowAbsence.PlanningRecording;
		#endregion

		#region Constructors

		public Absence() { }

        public Absence(int color, string charID, AbsenceType absenceTypeID, long countryID, bool useInCalck, bool isFixed, double value, long languageID, string name)
		{
			this._languageID = languageID;
			this._name = name;
			this._color = color;
			this._charID = charID;
			this._useInCalck = useInCalck;
			this._isFixed = isFixed;
			this._value = value;
			this._absenceTypeID = absenceTypeID;
			this._countryID = countryID;
		}

		#endregion

		#region Public Properties

        public virtual int? SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }
        
        public virtual bool Import
        {
            get { return _import; }
            set { _import = value; }
        } 

		public virtual bool WithoutFixedTime
		{
			get { return _withoutFixedTime; }
			set { _withoutFixedTime = value; }
		}

		public virtual long LanguageID
		{
			get { return _languageID; }
			set { _languageID = value; }
		}

		public virtual string Name
		{
			get { return _name; }
			set
			{
				if (value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_name = value;
			}
		}

		public virtual bool UseInCalck
		{
			get { return _useInCalck; }
			set { _useInCalck = value; }
		}

		public virtual bool IsFixed
		{
			get { return _isFixed; }
			set { _isFixed = value; }
		}

		public virtual double Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public virtual int Color
		{
			get { return _color; }
			set { _color = value; }
		}

		public virtual string CharID
		{
			get { return _charID; }
			set
			{
				if ( value != null && value.Length > 6)
					throw new ArgumentOutOfRangeException("Invalid value for CharID", value, value.ToString());
				_charID = value;
			}
		}

        public virtual AbsenceType AbsenceTypeID
		{
			get { return _absenceTypeID; }
			set { _absenceTypeID = value; }
		}

		public virtual long CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

        public virtual IsShowAbsence IsShow
        {
            get { return _IsShow; }
            set { _IsShow = value; }
        }
        public virtual bool CountAsOneDay
        {
            get { return _CountAsOneDay; }
            set { _CountAsOneDay = value; }
        }
        public virtual bool CanShowInPlanning
        {
            get 
            {
                return (IsShow == IsShowAbsence.Planning) || (IsShow == IsShowAbsence.PlanningRecording);
            }
        }
        public virtual bool CanShowInRecording
        {
            get
            {
                return (IsShow == IsShowAbsence.Recording) || (IsShow == IsShowAbsence.PlanningRecording);
            }
        }

        #endregion
	}

	#endregion
}
