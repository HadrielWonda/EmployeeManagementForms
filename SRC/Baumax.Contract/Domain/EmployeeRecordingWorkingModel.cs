using System;
using System.Collections;

namespace Baumax.Domain
{
	#region EmployeeRecordingWorkingModel

	/// <summary>
	/// EmployeeRecordingWorkingModel object for NHibernate mapped table 'EmployeeRecordingWorkingModel'.
	/// </summary>
	[Serializable]
	public class EmployeeRecordingWorkingModel : BaseEntity
		{
		#region Member Variables
		
		protected int _hours;
		protected bool _additionalCharge;
		protected DateTime _date;
		protected long _workingModelID;
		protected long _employeeID;

		#endregion

		#region Constructors

		public EmployeeRecordingWorkingModel() { }

		public EmployeeRecordingWorkingModel( int hours, bool additionalCharge, DateTime date, long workingModelID, long employeeID )
		{
			this._hours = hours;
			this._additionalCharge = additionalCharge;
			this._date = date;
			this._workingModelID = workingModelID;
			this._employeeID = employeeID;
		}

		#endregion

		#region Public Properties

		public virtual int Hours
		{
			get { return _hours; }
			set { _hours = value; }
		}

		public virtual bool AdditionalCharge
		{
			get { return _additionalCharge; }
			set { _additionalCharge = value; }
		}

		public virtual DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		public virtual long WorkingModelID
		{
			get { return _workingModelID; }
			set { _workingModelID = value; }
		}

		public virtual long EmployeeID
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}

		#endregion
		
	}

	#endregion
}
