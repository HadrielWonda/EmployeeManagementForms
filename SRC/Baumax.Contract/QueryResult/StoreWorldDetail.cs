using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Baumax.Domain;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
	public class StoreWorldDetail:ISerializable 
    {
        #region  Fields

        protected long _storeid;
        protected long _storeworldid;
        protected short _year;
        protected decimal? _available_work_time_hours;
        protected double? _available_buffer_hours;
        protected decimal? _business_volume_hours;
        protected decimal? _targetedbusinessvolume;
        protected decimal? _netbusinessvolume1;
        protected decimal? _netbusinessvolume2;
        protected double? _benchmark_perfomance;
        
        [NonSerialized]
        protected string _worldName;
        [NonSerialized]
        protected WorldType _worldTypeID;
        #endregion


        #region Properties

        public long StoreId
        {
            get { return _storeid; }
            set { _storeid = value; }
        }

        public long StoreWorldId
        {
            get { return _storeworldid; }
            set { _storeworldid = value; }
        }

        public short Year
        {
            get { return _year; }
            set { _year = value; }
        }

        /*
         * Available work-time-hours per world 
         * (See import-use-case of how to do this calculation).
         */
        public decimal? AvailableWorkTimeHours
        {
            get { return _available_work_time_hours; }
            set { _available_work_time_hours = value; }
        }
        
        /*
         * Available buffer-hours: 
         * This is the available buffer-hours of this 
         * current year that has been defined at “Define buffer-hours for worlds” use-case. 
         */
        public double? AvailableBufferHours
        {
            get { return _available_buffer_hours; }
            set { _available_buffer_hours = value; }
        }

        /*
         *	Business Volume hours (Umsatzstunden): 
         * This is simply calculated by 
         * (Available work-time-hours per world) – (Currently available buffer-hours)
         */
        public decimal? BusinessVolumeHours
        {
            get { return _business_volume_hours; }
            set { _business_volume_hours = value; }
        }

        /*
         * Targeted business volume of this world 
         * (See import-use-case of how to do this calculation).
         */
        public decimal? TargetedBusinessVolume
        {
            get { return _targetedbusinessvolume; }
            set { _targetedbusinessvolume = value; }
        }

        /*
         * Net-business volume per hour (Netto-Stundenleistung): 
         * This is calculated by dividing the targeted business volume per world 
         * through the available work-time-hours per world  
         * (See import-use-case of how to do this calculation.)
         */
        public decimal? NetBusinessVolume1
        {
            get { return _netbusinessvolume1; }
            set { _netbusinessvolume1 = value; }
        }

        /*
         * 	Net-business volume per hour without Buffer-hours (Nettostundenleistung ohne Bufferstunden)
         * (used to find the targeted hours per world for planning): 
         * This is calculated by = 
         *   (Targeted business volume per world) / ((Available work-time-hours per world) – (buffer-hours)). 
         */
        public decimal? NetBusinessVolume2
        {
            get { return _netbusinessvolume2; }
            set { _netbusinessvolume2 = value; }
        }

        /*
         * Benchmark performance: 
         * This has been defined under “Define benchmarks for worlds” use-case
         */
        public double? BenchmarkPerfomance
        {
            get { return _benchmark_perfomance; }
            set { _benchmark_perfomance = value; }
        }

        public string WorldName
        {
            get { return _worldName; }
            set { _worldName = value; }
        }

        #endregion

        #region ISerializable Members

		//
        protected StoreWorldDetail(SerializationInfo info, StreamingContext context)
            
		{
            _storeid = info.GetInt64("sid");
            _storeworldid = info.GetInt64 ("swid");
            _year = info.GetInt16("y");
            _available_work_time_hours = (decimal?)info.GetValue("_1", typeof(decimal?));
            _available_buffer_hours = (double?)info.GetValue("_2", typeof(double?));
            _business_volume_hours = (decimal?)info.GetValue("_3", typeof(decimal?));
            _targetedbusinessvolume = (decimal?)info.GetValue("_4", typeof(decimal?));
            _netbusinessvolume1 = (decimal?)info.GetValue("_5", typeof(decimal?));
            _netbusinessvolume2 = (decimal?)info.GetValue("_6", typeof(decimal?));
			_benchmark_perfomance = (double?)info.GetValue("_7", typeof(double?)); 
		}

		//
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            info.AddValue("sid", _storeid);
            info.AddValue("swid", _storeworldid);
            info.AddValue("y", _year);
            info.AddValue("_1", _available_work_time_hours);
            info.AddValue("_2", _available_buffer_hours);
            info.AddValue("_3", _business_volume_hours);
            info.AddValue("_4", _targetedbusinessvolume);
            info.AddValue("_5", _netbusinessvolume1);
            info.AddValue("_6", _netbusinessvolume2);
            info.AddValue("_7", _benchmark_perfomance);
		}

		#endregion

        public virtual WorldType WorldTypeID
        {
            get { return _worldTypeID; }
            set { _worldTypeID = value; }
        }

        public StoreWorldDetail() { }

        public StoreWorldDetail(long storeid, long storeworldid, short year)
        {
            _storeid = storeid;
            _storeworldid = storeworldid;
            _year = year;
        }
    }
}
