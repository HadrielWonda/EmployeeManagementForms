using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Dao.TimePlanning
{
    public class StoreWorldPlanningInfo
    {
        private long _StoreWorldId;
        [NonSerialized]
        private int[] _TargetedHours = new int[7];
        [NonSerialized]
        private int _SumTargetedHours = 0;

        private byte _MinimumPresence;
        private byte _MaximumPresence;


        private int _AvailableWorldBufferHours = 0;

        private int _Benchmark = 0;
        private int _TargetedNetPerformancePerHour = 0;

	    public byte MinimumPresence
	    {
		    get { return _MinimumPresence;}
		    set { _MinimumPresence = value;}
	    }

        public byte MaximumPresence
	    {
		    get { return _MaximumPresence;}
		    set { _MaximumPresence = value;}
	    }

        public long StoreWorldId
        {
            get { return _StoreWorldId; }
            set { _StoreWorldId = value; }
        }

        public long SumTargetedHours
        {
            get { return _SumTargetedHours; }
            set { _SumTargetedHours = value; }
        }

        public int AvailableWorldBufferHours
        {
            get { return _AvailableWorldBufferHours; }
            set { _AvailableWorldBufferHours = value; }
        }

        public int Benchmark
        {
            get { return _Benchmark; }
            set { _Benchmark = value; }
        }

        public int TargetedNetPerformancePerHour
        {
            get { return _TargetedNetPerformancePerHour; }
            set { _TargetedNetPerformancePerHour = value; }
        }

        public int this[DayOfWeek weekday]
        {
            get { return _targetedHours[(int)weekday]; }
        }
    }
}
