using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Baumax.Domain
{
	#region EmployeeHolidaysInfo

	/// <summary>
	/// EmployeeHolidaysInfo object for NHibernate mapped table 'EmployeeHolidaysInfo'.
	/// </summary>
	[Serializable]
    public class EmployeeHolidaysInfo : BaseEntity
		{
		#region Member Variables
		
		protected short _year;
		protected decimal _oldHolidays;
		protected decimal _newHolidays;
		protected decimal _usedHolidays;
        protected decimal _takenHolidays;
        protected decimal _plannedHolidays;
        protected decimal _spareHolidaysExc;
        protected decimal _spareHolidaysInc;

		protected long _employeeID;

		#endregion

		#region Constructors

		public EmployeeHolidaysInfo() { }
        public EmployeeHolidaysInfo(long employeeID, short year) 
        {
            _employeeID = employeeID;
            _year = year;
        }

		public EmployeeHolidaysInfo( short year, decimal spareHolidays, decimal newHolidays, decimal usedHolidays, long employeeID )
		{
			this._year = year;
			this._oldHolidays = spareHolidays;
			this._newHolidays = newHolidays;
			this._usedHolidays = usedHolidays;
			this._employeeID = employeeID;
		}

		#endregion

		#region Public Properties

		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
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

		public virtual decimal UsedHolidays
		{
			get { return _usedHolidays; }
			set { _usedHolidays = value; }
		}
        public virtual decimal TakenHolidays
        {
            get { return _takenHolidays; }
            set { _takenHolidays = value; }
        }
        public virtual decimal PlannedHolidays
        {
            get { return _plannedHolidays; }
            set { _plannedHolidays = value; }
        }

        public virtual decimal SpareHolidaysExc
        {
            get { return _spareHolidaysExc; }
            set { _spareHolidaysExc = value; }
        }
        public virtual decimal SpareHolidaysInc
        {
            get { return _spareHolidaysInc; }
            set { _spareHolidaysInc = value; }
        }

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}

		#endregion

        public virtual bool CalculateSpareHolidays()
        {
            decimal spare_exc = SpareHolidaysExc;
            decimal spare_inc = SpareHolidaysInc;
            decimal used = UsedHolidays;

            UsedHolidays = TakenHolidays + PlannedHolidays;

            SpareHolidaysExc = OldHolidays + NewHolidays - TakenHolidays;
            SpareHolidaysInc = SpareHolidaysExc - PlannedHolidays;

            return (spare_exc != SpareHolidaysInc) || (spare_inc != SpareHolidaysInc) || (used != UsedHolidays);

        }

        public virtual bool CalculateSpareHolidays_Austria()
        {
            decimal spare_inc = SpareHolidaysInc;
            decimal used = UsedHolidays;

            UsedHolidays = TakenHolidays + PlannedHolidays;

            SpareHolidaysInc = SpareHolidaysExc - PlannedHolidays;

            return (spare_inc != SpareHolidaysInc) || (used != UsedHolidays);

        }

        public virtual void FillEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException();

            employee.NewHolidays = NewHolidays;
            employee.OldHolidays = OldHolidays;
            employee.AvailableHolidays = NewHolidays + OldHolidays;
            employee.UsedHolidays = UsedHolidays;
            employee.SpareHolidaysExc = SpareHolidaysExc;
            employee.SpareHolidaysInc = SpareHolidaysInc;

            Debug.Assert(UsedHolidays == TakenHolidays + PlannedHolidays);
        }

        public virtual void FillFromEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException();

            NewHolidays = employee.NewHolidays;
            OldHolidays = employee.OldHolidays;
            SpareHolidaysExc = employee.SpareHolidaysExc;
            SpareHolidaysInc = employee.SpareHolidaysInc;

            EmployeeID = employee.ID;
        }

        public override string ToString()
        {
            return String.Format("ID={0}; EmplID={1}; New={2:F2};Old={3:F2};Used={4:F2};Taken={5:F2};Plan={6:F2};SpareExc={7:F2};SpareInc={8:F2};", 
                new object[] {ID,EmployeeID, NewHolidays,OldHolidays,UsedHolidays, TakenHolidays,PlannedHolidays, SpareHolidaysExc,SpareHolidaysInc});
        }

        public static Dictionary<long, EmployeeHolidaysInfo> BuildDiction(List<EmployeeHolidaysInfo> list)
        {
            Dictionary<long, EmployeeHolidaysInfo> diction = new Dictionary<long, EmployeeHolidaysInfo>();

            if (list != null)
            {
                foreach (EmployeeHolidaysInfo item in list)
                    diction[item.EmployeeID] = item;
            }
            return diction;
        }

        public virtual bool IsEqualByData(EmployeeHolidaysInfo entity)
        {
            if (entity == null) return false;

            return this.PlannedHolidays == entity.PlannedHolidays &&
                   this.TakenHolidays == entity.TakenHolidays &&
                   this.SpareHolidaysExc == entity.SpareHolidaysExc &&
                   this.SpareHolidaysInc == entity.SpareHolidaysInc &&
                   this.EmployeeID == entity.EmployeeID &&
                   this.OldHolidays == entity.OldHolidays &&
                   this.NewHolidays == entity.NewHolidays &&
                   this.Year == entity.Year &&
                   this.UsedHolidays == entity.UsedHolidays;
        }
	}

	#endregion
}
