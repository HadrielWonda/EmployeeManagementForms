using System;
using System.Collections;

namespace Baumax.Domain
{
	#region WorkingModel

	/// <summary>
	/// WorkingModel object for NHibernate mapped table 'WorkingModel'.
	/// </summary>
	[Serializable]
    public class WorkingModel : BaseEntity
		{
		#region Member Variables

		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected bool _addCharges;
		protected long _languageID;
		protected string _name;
		protected string _message;
		protected long? _countryID;
		protected string _data;
		protected int _conditionType;
		protected double _multiplyValue;
		protected double _addValue;
        protected bool _UseInRecording;
        protected WorkingModelType _WorkingModelType = WorkingModelType.WorkingModel;

		#endregion

		#region Constructors

		public WorkingModel() { }

		public WorkingModel(long? countryID, string data, int conditionType, double multiplyValue, double addValue)
		{
			this._countryID = countryID;
			this._data = data;
			this._conditionType = conditionType;
			this._multiplyValue = multiplyValue;
			this._addValue = addValue;
		}

		#endregion

		#region Public Properties

        public virtual WorkingModelType WorkingModelType
        {
            get { return _WorkingModelType; }
            set { _WorkingModelType = value; }
        }

        public virtual bool UseInRecording
        {
            get { return _UseInRecording; }
            set { _UseInRecording = value; }
        }

		public virtual DateTime BeginTime
		{
			get { return _beginTime; }
			set { _beginTime = value; }
		}

		public virtual DateTime EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		public virtual bool AddCharges
		{
			get { return _addCharges; }
			set { _addCharges = value; }
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

		public virtual string Message
		{
			get { return _message; }
			set
			{
				if (value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Message", value, value.ToString());
				_message = value;
			}
		}

		public virtual long? CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

		public virtual string Data
		{
			get { return _data; }
			set
			{
				if (value != null && value.Length > 200)
					throw new ArgumentOutOfRangeException("Invalid value for Data", value, value.ToString());
				_data = value;
			}
		}
		public virtual int ConditionType
		{
			get { return _conditionType; }
			set { _conditionType = value; }
		}

		public virtual double MultiplyValue
		{
			get { return _multiplyValue; }
			set { _multiplyValue = value; }
		}

		public virtual double AddValue
		{
			get { return _addValue; }
			set { _addValue = value; }
		}

        public virtual double ConditionTime
	    {
            get { return _addValue; }
            set { _addValue = value; } 
	    }

        public virtual double HoursLunch
        {
            get { return _multiplyValue; }
            set { _multiplyValue = value; }
        }

        public virtual bool IsDurationTime
        {
            get { return _addCharges; }
            set { _addCharges = value; }
        }
        
		#endregion
	}

	#endregion
}
