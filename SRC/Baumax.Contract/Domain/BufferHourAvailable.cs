using System;
using System.Collections;

namespace Baumax.Domain
{
	#region BufferHourAvailable

	/// <summary>
	/// BufferHourAvailable object for NHibernate mapped table 'BufferHourAvailable'.
	/// </summary>
	[Serializable]
	public class BufferHourAvailable : BaseEntity
		{
		#region Member Variables
		
		protected short _year;
		protected DateTime _weekBegin;
        protected DateTime _weekEnd;
		protected byte _weekNumber;
		protected double _availableBufferHour;
		protected long _storeWorldID;
        protected double? _SumFromPlanning;
        protected double? _SumFromRecording;
        protected double? _SumActualBVEstimated;
		#endregion

		#region Constructors

		public BufferHourAvailable() { }

		public BufferHourAvailable( short year, DateTime weekBegin, DateTime weekEnd, byte weekNumber, double availableBufferHour, long storeWorldID ,double? sumFromPlanning, double? sumFromRecording)
		{
			this._year = year;
			this._weekBegin = weekBegin;
			this._weekEnd = weekEnd;
			this._weekNumber = weekNumber;
			this._availableBufferHour = availableBufferHour;
			this._storeWorldID = storeWorldID;
            this._SumFromPlanning = sumFromPlanning;
            this._SumFromRecording = sumFromRecording;
		}

		#endregion

		#region Public Properties

		public virtual short Year
		{
			get { return _year; }
			set { _year = value; }
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

        public virtual byte WeekNumber
		{
			get { return _weekNumber; }
			set { _weekNumber = value; }
		}

		public virtual double AvailableBufferHour
		{
			get { return _availableBufferHour; }
			set { _availableBufferHour = value; }
		}

        public virtual double? SumFromPlanning
        {
            get { return _SumFromPlanning; }
            set { _SumFromPlanning = value; }
        }

        public virtual double? SumFromRecording
        {
            get { return _SumFromRecording; }
            set { _SumFromRecording = value; }
        }

        public virtual double? SumActualBVEstimated
        {
            get { return _SumActualBVEstimated; }
            set { _SumActualBVEstimated = value; }
        }

		public virtual long StoreWorldID
		{
			get { return _storeWorldID; }
			set { _storeWorldID = value; }
		}
		#endregion

        public virtual bool IsExistsPlanning
        {
            get { return _SumFromPlanning.HasValue; }
        }
        public virtual bool IsExistsRecording
        {
            get { return _SumFromRecording.HasValue; }
        }
        public virtual bool IsExistsEstimate
        {
            get { return _SumActualBVEstimated.HasValue; }
        }

        public virtual bool Update(double prevBufferHours, int step)
        {
            double estimateValue = (SumActualBVEstimated.HasValue) ? SumActualBVEstimated.Value : 0;

            double WorldValue = (SumFromPlanning.HasValue) ? SumFromPlanning.Value : 0;

            if (SumFromRecording.HasValue)
            {
                WorldValue = SumFromRecording.Value;
            }

            double value = prevBufferHours + step + (estimateValue - WorldValue);

            bool bChanges = AvailableBufferHour != value;
            if (bChanges)
            {
                AvailableBufferHour = value;
            }
            return bChanges;
        }
	}

	#endregion
}
