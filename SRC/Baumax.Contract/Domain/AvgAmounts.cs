using System;
using System.Collections;

namespace Baumax.Domain
{
	#region AvgAmount

	/// <summary>
	/// AvgAmount object for NHibernate mapped table 'AvgAmounts'.
	/// </summary>
	[Serializable]
	public class AvgAmount : BaseEntity
		{
		#region Member Variables

        protected short _AvgRestingTime;
        protected short _year;
		protected byte _avgWeeks;
		protected short _avgContractTime;
		protected short _cashDeskAmount;
		protected long _countryID;

		#endregion

		#region Constructors

		public AvgAmount() { }

		public AvgAmount( short year, byte avgWeeks, short avgContractTime, short cashDeskAmount, long countryID )
		{
			this._year = year;
			this._avgWeeks = avgWeeks;
			this._avgContractTime = avgContractTime;
			this._cashDeskAmount = cashDeskAmount;
			this._countryID = countryID;
		}

		#endregion

		#region Public Properties


		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
		}

		public virtual byte AvgWeeks
		{
			get { return _avgWeeks; }
			set { _avgWeeks = value; }
		}

		public virtual short AvgContractTime
		{
			get { return _avgContractTime; }
			set { _avgContractTime = value; }
		}

		public virtual short CashDeskAmount
		{
			get { return _cashDeskAmount; }
			set { _cashDeskAmount = value; }
		}

        public virtual short AvgRestingTime
        {
            get { return _AvgRestingTime; }
            set { _AvgRestingTime = value; }
        }


		public virtual long CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}
		#endregion
	}

	#endregion
}
