using System;
using System.Collections;

namespace Baumax.Domain
{
	#region WorldToHwgr

	/// <summary>
	/// WorldToHwgr object for NHibernate mapped table 'WorldToHwgr'.
	/// </summary>
	[Serializable]
	public class WorldToHwgr : BaseEntity, IDepartment
		{
		#region Member Variables

        private long _storeID;
        private long _worldID;
        protected bool _import;
		protected DateTime _beginTime;
		protected DateTime _endTime;
		//protected long _storeWorld_ID;
		protected long _hwgr_ID;
        [NonSerialized]
        protected string _hwgrName = string.Empty;

		#endregion

		#region Constructors

		public WorldToHwgr() { }

		public WorldToHwgr( DateTime beginTime, DateTime endTime, long hwgr_ID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			//this._storeWorld_ID = storeWorld_ID;
			this._hwgr_ID = hwgr_ID;
		}

		#endregion

		#region Public Properties

        public virtual long StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }

        public virtual long WorldID
        {
            get { return _worldID; }
            set { _worldID = value; }
        }
        
        public virtual bool Import
		{
			get { return _import; }
			set { _import = value; }
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

        //public virtual long StoreWorld_ID
        //{
        //    get { return _storeWorld_ID; }
        //    set { _storeWorld_ID = value; }
        //}

		public virtual long HWGR_ID
		{
			get { return _hwgr_ID; }
			set { _hwgr_ID = value; }
		}

        public virtual string HwgrName
        {
            get { return _hwgrName; }
            set { _hwgrName = value; }
        }
		#endregion

        #region IDepartment Members

        public long ParentID
        {
            get { return _worldID; }
            set { _worldID = value; }
        }

        public long SectorID
        {
            get { return _hwgr_ID; }
            set { _hwgr_ID = value; }
        }

        #endregion
    }

	#endregion
}
