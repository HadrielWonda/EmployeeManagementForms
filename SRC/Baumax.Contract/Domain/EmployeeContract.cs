using System;
using System.Collections;

namespace Baumax.Domain
{
	#region EmployeeContract

	/// <summary>
	/// EmployeeContract object for NHibernate mapped table 'EmployeeContract'.
	/// </summary>
	[Serializable]
    public class EmployeeContract : BaseEntity, IComparable<EmployeeContract>
		{
        public static int InvalidContractHours = Int32.MinValue;

		#region Member Variables
		
		protected DateTime _contractBegin;
		protected DateTime _contractEnd;
		protected decimal _contractWorkingHours;
		protected long _employeeID;

		#endregion

		#region Constructors

		public EmployeeContract() { }

		public EmployeeContract( DateTime contractBegin, DateTime contractEnd, decimal contractWorkingHours, long employeeID )
		{
			this._contractBegin = contractBegin;
			this._contractEnd = contractEnd;
			this._contractWorkingHours = contractWorkingHours;
			this._employeeID = employeeID;
		}

		#endregion

		#region Public Properties

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

		public virtual decimal ContractWorkingHours
		{
			get { return _contractWorkingHours; }
			set { _contractWorkingHours = value; }
		}

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}
		#endregion

        public virtual bool IsContainDate(DateTime date)
        {
            return (ContractBegin <= date && date <= ContractEnd);
        }

        public virtual int ContractWeekTime
        {
            get { return Convert.ToInt32(Math.Round (ContractWorkingHours * 60)); }

            //set
            //{
            //    ContractWorkingHours = Convert.ToDecimal(value / 60);
            //}
        }

        public virtual bool IsEqualEntity(EmployeeContract contract)
        {
            if (contract == null) return false;

            return this.EmployeeID == contract.EmployeeID &&
                   this.ContractBegin == contract.ContractBegin &&
                   this.ContractEnd == contract.ContractEnd &&
                   this.ContractWeekTime == contract.ContractWeekTime;

        }
        public virtual int CompareTo(EmployeeContract entity)
        {
            if (entity == null) return -1;

            int i = EmployeeID.CompareTo(entity.EmployeeID);
            if (i == 0)
            {

                i = ContractBegin.CompareTo(entity.ContractBegin);
            }

            return i;
        }
	}

	#endregion
}
