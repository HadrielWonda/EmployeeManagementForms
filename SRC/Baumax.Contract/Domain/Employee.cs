using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Employee

	/// <summary>
	/// Employee object for NHibernate mapped table 'Employee'.
	/// </summary>
	[Serializable]
    public class Employee : BaseEntity
		{
		#region Member Variables

        protected int? _PersNumber;
        protected DateTime? _beginTime;
        protected DateTime? _endTime;
        protected DateTime _contractBegin;
        protected DateTime _contractEnd;
        bool _LongTimeAbsenceExist;
        bool _AllIn;
        long? _worldID;
        long? _hwgrID;
        long _storeID;
        long _EmployeeContractID;
        long _EmployeeRelationsID;
        decimal _availableHolidays;
		decimal _usedHolidays;
		decimal _spareHolidaysExc;
		decimal _spareHolidaysInc;
		protected bool _import;
		protected string _persID;
		protected string _lastName;
		protected string _firstName;
		protected long _mainStoreID;
		protected decimal _contractWorkingHours;
		protected decimal _oldHolidays;
		protected decimal _newHolidays;
		protected decimal _balanceHours;
		protected DateTime? _createDate;
        protected long? _OrderHwgrID;
        protected WeekStateType _WeekState;
        protected bool _isAustria = false;
		#endregion

		#region Constructors

		public Employee() { }

		public Employee( string persID, string lastName, string firstName, long mainStoreID )
		{
			this._persID = persID;
			this._lastName = lastName;
			this._firstName = firstName;
			this._mainStoreID = mainStoreID;
		}

		#endregion

		#region Public Properties

        #region Mapped

        public virtual long? OrderHwgrID
        {
            get { return _OrderHwgrID; }
            set { _OrderHwgrID = value; }
        }

        public virtual WeekStateType WeekState
        {
            get { return _WeekState; }
            set { _WeekState = value; }
        }

        public virtual int? PersNumber
        {
            get { return _PersNumber; }
            set { _PersNumber = value; }
        }

        public virtual decimal OldHolidays
		{
			get { return _oldHolidays; }
			set { _oldHolidays = value; }
		}

		public virtual decimal NewHolidays
		{
			get { return _newHolidays; }
			set { _newHolidays = value; }
		}

		public virtual decimal BalanceHours
		{
			get { return _balanceHours; }
			set { _balanceHours = value; }
		}

		public virtual DateTime? CreateDate
		{
			get { return _createDate; }
			set { _createDate = value; }
		}

		public virtual string PersID
		{
			get { return _persID; }
			set
			{
				if (value != null && value.Length > 25)
					throw new ArgumentOutOfRangeException("Invalid value for PersID", value, value.ToString());
				_persID = value;
			}
		}

		public virtual bool Import
		{
			get { return _import; }
			set { _import = value; }
		}

		public virtual string LastName
		{
			get { return _lastName; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
				_lastName = value;
			}
		}

		public virtual string FirstName
		{
			get { return _firstName; }
			set
			{
				if ( value != null && value.Length > 50)
					throw new ArgumentOutOfRangeException("Invalid value for FirstName", value, value.ToString());
				_firstName = value;
			}
		}

		public virtual long MainStoreID
		{
			get { return _mainStoreID; }
			set { _mainStoreID = value; }
		}

        public virtual decimal AvailableHolidays
        {
            get 
            {
                if (IsAustria)
                    return 0;
                return _availableHolidays; 
            }
            set { _availableHolidays = value; }
        }
        #endregion

        #region Not Mapped

        public virtual bool IsAustria
        {
            get { return _isAustria ; }
            set { _isAustria = value; }
        }

        public virtual bool AllIn
        {
            get { return _AllIn; }
            set { _AllIn = value; }
        }

        public virtual bool LongTimeAbsenceExist
        {
            get { return _LongTimeAbsenceExist; }
            set { _LongTimeAbsenceExist = value; }
        }

        public virtual long EmployeeRelationsID
        {
            get { return _EmployeeRelationsID; }
            set { _EmployeeRelationsID = value; }
        }

        public virtual long EmployeeContractID
		{
			get { return _EmployeeContractID; }
			set { _EmployeeContractID = value; }
		}
		
		public virtual decimal ContractWorkingHours
		{
			get { return _contractWorkingHours; }
			set { _contractWorkingHours = value; }
		}

		public virtual DateTime ContractBegin
		{
			get { return _contractBegin; }
			set { _contractBegin = value; }
		}

		public virtual DateTime ContractEnd
		{
			get { return _contractEnd; }
			set { _contractEnd = value; }
		}
        public virtual DateTime? BeginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }

        public virtual DateTime? EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        public virtual long StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }

		public virtual long? HWGR_ID
		{
			get { return _hwgrID; }
			set { _hwgrID = value; }
		}

		public virtual long? WorldID
		{
			get { return _worldID; }
			set { _worldID = value; }
		}

		public virtual decimal SpareHolidaysInc
		{
			get { return _spareHolidaysInc; }
			set { _spareHolidaysInc = value; }
		}

		public virtual decimal SpareHolidaysExc
		{
			get 
            {
                if (IsAustria)
                    return _availableHolidays;

                return _spareHolidaysExc; 
            }
			set { _spareHolidaysExc = value; }
		}

		public virtual decimal UsedHolidays
		{
			get { return _usedHolidays; }
			set { _usedHolidays = value; }
        }
        #endregion

		#endregion

        public virtual string FullName
        {
            get
            {
                return String.Format("{1} {0}", FirstName , LastName );
            }
        }
	}

	#endregion
}
