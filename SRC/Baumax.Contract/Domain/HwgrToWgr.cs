using System;
using System.Collections;

namespace Baumax.Domain
{
	#region HwgrToWgr

	/// <summary>
	/// HwgrToWgr object for NHibernate mapped table 'HwgrToWgr'.
	/// </summary>
	[Serializable]
	public class HwgrToWgr : BaseEntity, IDepartment
	{
		#region Member Variables

        private long _storeID;
        private long _hwgrID;
        protected bool _import;
		protected DateTime _beginTime;
		protected DateTime _endTime;
		//protected long _worldHWGR_ID;
		protected long _wgr_ID;
        [NonSerialized]
        protected string _wgrName;


	

		#endregion

		#region Constructors

		public HwgrToWgr() { }

		public HwgrToWgr( DateTime beginTime, DateTime endTime, long wgr_ID )
		{
			this._beginTime = beginTime;
			this._endTime = endTime;
			//this._worldHWGR_ID = worldHWGR_ID;
			this._wgr_ID = wgr_ID;
		}

		#endregion

		#region Public Properties

        public virtual long StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }

        public virtual long HWGR_ID
        {
            get { return _hwgrID; }
            set { _hwgrID = value; }
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

        //public virtual long WorldHWGR_ID
        //{
        //    get { return _worldHWGR_ID; }
        //    set { _worldHWGR_ID = value; }
        //}

		public virtual long WGR_ID
		{
			get { return _wgr_ID; }
			set { _wgr_ID = value; }
		}

        public virtual string WgrName
        {
            get { return _wgrName; }
            set { _wgrName = value; }
        }
		#endregion

        public override string ToString()
        {
            return string.Format("id:{0} hwgrID:{1} wgrID:{2} begin:{3} end:{4}",_ID, _hwgrID, _wgr_ID,_beginTime,_endTime);
        }

        #region IDepartment Members


        public long ParentID
        {
            get { return _hwgrID; }
            set { _hwgrID = value; }
        }

        public long SectorID
        {
            get { return _wgr_ID; }
            set { _wgr_ID = value; }
        }

        #endregion
    }

	#endregion
}
