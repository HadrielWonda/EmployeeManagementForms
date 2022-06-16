using System;
using System.Collections;

namespace Baumax.Domain
{
	#region Benchmark

	/// <summary>
	/// Benchmark object for NHibernate mapped table 'Benchmark'.
	/// </summary>
	[Serializable]
	public class Benchmark : BaseEntity
		{
		#region Member Variables

		[NonSerialized]
		string _worldName;
		protected short _year;
		protected double _value;
		protected long _storeWorldID;

		#endregion

		#region Constructors

		public Benchmark() { }

		public Benchmark( short year, double value, long storeWorldID )
		{
			this._year = year;
			this._value = value;
			this._storeWorldID = storeWorldID;
		}

		#endregion

		#region Public Properties
		
		public virtual string WorldName
		{
			get { return _worldName; }
			set { _worldName = value; }
		}

		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
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
