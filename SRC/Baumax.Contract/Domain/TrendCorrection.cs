using System;
using System.Collections;

namespace Baumax.Domain
{
	#region TrendCorrection

	/// <summary>
	/// TrendCorrection object for NHibernate mapped table 'TrendCorrection'.
	/// </summary>
	[Serializable]
	public class TrendCorrection : BaseEntity
		{
		#region Member Variables

		[NonSerialized]
		string _worldName;
        string _Name;
		protected DateTime _beginTime;
		protected DateTime _endTime;
		protected double _value;
		protected long _storeWorldID;

		#endregion

		#region Constructors

		public TrendCorrection() { }

		public TrendCorrection( DateTime beginTime, DateTime endTime, double value, long storeWorldID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			this._value = value;
			this._storeWorldID = storeWorldID;
		}

		#endregion

		#region Public Properties

        public virtual string Name
        {
            get { return _Name; }
            set 
            {
                if (value != null && value.Length > 256)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());
                _Name = value; 
            }
        }

		public virtual string WorldName
		{
			get { return _worldName; }
			set { _worldName = value; }
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

		public virtual double Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public virtual long StoreWorldID
		{
			get { return _storeWorldID; }
			set { _storeWorldID = value; }
		}
		#endregion
	}

	#endregion
}
