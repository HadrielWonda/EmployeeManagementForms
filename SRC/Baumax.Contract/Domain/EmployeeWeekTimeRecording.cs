using System;
using System.Collections;
using Baumax.Contract;

namespace Baumax.Domain
{

    #region EmployeeWeekTimeRecording

    /// <summary>
    /// EmployeeWeekTimeRecording object for NHibernate mapped table 'EmployeeWeekTimeRecording'.
    /// </summary>
    [Serializable]
    public class EmployeeWeekTimeRecording : BaseEntity, IEmployeeWeek, IComparable <EmployeeWeekTimeRecording>
    {
        #region Member Variables

        protected int _workingHours;
        protected byte _weekNumber;
        protected DateTime _weekBegin;
        protected DateTime _weekEnd;
        protected int _plusMinusHours;
        protected int _saldo;
        protected int _plannedHours;
        protected int _contractHours;
        protected int _additionalCharge;
        protected long _employeeID;
        protected bool _customEdit;
        protected bool _AllIn;
        protected long _orderHWGR;

        #endregion

        #region Constructors

        public EmployeeWeekTimeRecording()
        {
        }

        public EmployeeWeekTimeRecording(byte weekNumber, DateTime weekBegin, DateTime weekEnd, int plusMinusHours,
                                         int saldo, int plannedHours, int contractHours, int additionalCharge,
                                         long employeeID, int workingHours,
                                         bool customEdit, long orderHWGR)
        {
            this._weekNumber = weekNumber;
            this._weekBegin = weekBegin;
            this._weekEnd = weekEnd;
            this._plusMinusHours = plusMinusHours;
            this._saldo = saldo;
            this._plannedHours = plannedHours;
            this._contractHours = contractHours;
            this._additionalCharge = additionalCharge;
            this._employeeID = employeeID;
            this._workingHours = workingHours;
            this._customEdit = customEdit;
            this._orderHWGR = orderHWGR;
        }

        #endregion

        #region Public Properties

        public virtual bool AllIn
        {
            get { return _AllIn; }
            set { _AllIn = value; }
        }

        public virtual int WorkingHours
        {
            get { return _workingHours; }
            set { _workingHours = value; }
        }

        public virtual byte WeekNumber
        {
            get { return _weekNumber; }
            set { _weekNumber = value; }
        }

        public virtual DateTime WeekBegin
        {
            get { return _weekBegin; }
            set { _weekBegin = value; }
        }

        public virtual DateTime WeekEnd
        {
            get { return _weekEnd; }
            set { _weekEnd = value; }
        }

        public virtual int PlusMinusHours
        {
            get { return _plusMinusHours; }
            set { _plusMinusHours = value; }
        }

        public virtual int Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public virtual int PlannedHours
        {
            get { return _plannedHours; }
            set { _plannedHours = value; }
        }

        public virtual int ContractHours
        {
            get { return _contractHours; }
            set { _contractHours = value; }
        }

        public virtual int AdditionalCharge
        {
            get { return _additionalCharge; }
            set { _additionalCharge = value; }
        }

        public virtual long EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public virtual bool CustomEdit
        {
            get { return _customEdit; }
            set { _customEdit = value; }
        }

        public virtual long OrderHWGR
        {
            get { return _orderHWGR; }
            set { _orderHWGR = value; }
        }

        #endregion

        #region Calculate saldo

        public virtual bool CalculateSaldo(int prevSaldo)
        {
            bool bChanged = false;
            if (!CustomEdit)
            {
                int saldo = 0;
                saldo = prevSaldo - ContractHours;

                if (AllIn)
                {
                    saldo += PlannedHours;

                }
                else
                {
                    saldo += AdditionalCharge + PlannedHours;
                }

                bChanged = saldo != Saldo;

                Saldo = saldo;
            }
            return bChanged;
        }

        public virtual int GetPrevSaldo()
        {
            if (CustomEdit) return 0;
            int prevSaldo = 0;
            if (AllIn)
            {
                prevSaldo = Saldo - PlannedHours;
            }
            else
            {
                prevSaldo = Saldo - PlannedHours - AdditionalCharge;
            }

            prevSaldo += ContractHours;

            return prevSaldo;
        }
        #endregion

        public virtual bool IsPlannedWeek
        {
            get { return false; }
        }
        public virtual int CompareTo(EmployeeWeekTimeRecording week)
        {

            int i = EmployeeID.CompareTo (week.EmployeeID);
            if (i == 0)
            {
                i = week.WeekBegin.CompareTo (week.WeekBegin);
            }
            return i;
        }
        public virtual string Dump()
        {
            return String.Format(@" ID={0} Week={1} From={2} To={3}\n 
                                   PlannedHours={4} AddCharges={5} WorkingHours={6} ContractHours={7}\n
                                    Saldo={8} AllIn={9} CustomEdit={10}, OrderHWGR={11}", new object[] { EmployeeID, WeekNumber, WeekBegin.ToShortDateString(),
                WeekEnd.ToShortDateString(), PlannedHours, AdditionalCharge, WorkingHours, ContractHours, Saldo, AllIn, CustomEdit, OrderHWGR});
        }
    }



    
    #endregion
}