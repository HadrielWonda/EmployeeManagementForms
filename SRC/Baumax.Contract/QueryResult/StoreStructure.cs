using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
	[Serializable]
	public class StoreStructure
	{
	    private long _Store_WorldID;
	    private long? _World_HWGR_ID;
	    private long? _HWGR_WGR_ID;
		
		//Store
	    private long _StoreID;
        [NonSerialized]
		private int _StoreSystemID;
		[NonSerialized] 
		private string _StoreName;
		
		//World
	    private long _WorldID;
		[NonSerialized] 
		private int _WorldSystemID;
		[NonSerialized] 
		private string _WorldName;

		//HWGR
	    private long? _HWGR_ID;
		[NonSerialized] 
		private int _HWGR_SystemID;
		[NonSerialized] private string _HWGR_Name;

	    private DateTime? _HWGR_BeginTime;
	    private DateTime? _HWGR_EndTime;

		//WGR
	    private long? _WGR_ID;
		[NonSerialized] 
		private int _WGR_SystemID;
		[NonSerialized] 
		private string _WGR_Name;

	    private DateTime? _WGR_BeginTime;
	    private DateTime? _WGR_EndTime;

        public virtual string WorldDisplayName
        {
            get
            {
                return _WorldName;
            }
        }
	    
        public virtual string HwgrDisplayName
        {
            get
            {
                return _HWGR_Name;
            }
        }
	    
        public virtual string WgrDisplayName
        {
            get
            {
                return _WGR_Name;
            }
        }

        public virtual long Store_WorldID
	    {
	        get { return _Store_WorldID; }
	        set { _Store_WorldID = value; }
	    }

        public virtual long? World_HWGR_ID
	    {
	        get { return _World_HWGR_ID; }
	        set { _World_HWGR_ID = value; }
	    }

        public virtual long? HWGR_WGR_ID
	    {
	        get { return _HWGR_WGR_ID; }
	        set { _HWGR_WGR_ID = value; }
	    }

        public virtual long StoreID
	    {
	        get { return _StoreID; }
	        set { _StoreID = value; }
	    }

        public virtual long WorldID
	    {
	        get { return _WorldID; }
	        set { _WorldID = value; }
	    }

        public virtual long? HWGR_ID
	    {
	        get { return _HWGR_ID; }
	        set { _HWGR_ID = value; }
	    }

        public virtual DateTime? HWGR_BeginTime
	    {
	        get { return _HWGR_BeginTime; }
	        set { _HWGR_BeginTime = value; }
	    }

        public virtual DateTime? HWGR_EndTime
	    {
	        get { return _HWGR_EndTime; }
	        set { _HWGR_EndTime = value; }
	    }

        public virtual long? WGR_ID
	    {
	        get { return _WGR_ID; }
	        set { _WGR_ID = value; }
	    }

        public virtual DateTime? WGR_BeginTime
	    {
	        get { return _WGR_BeginTime; }
	        set { _WGR_BeginTime = value; }
	    }

	    public virtual DateTime? WGR_EndTime
	    {
	        get { return _WGR_EndTime; }
	        set { _WGR_EndTime = value; }
	    }

        public virtual int StoreSystemID
	    {
	        get { return _StoreSystemID; }
	        set { _StoreSystemID = value; }
	    }

        public virtual string StoreName
	    {
	        get { return _StoreName; }
	        set { _StoreName = value; }
	    }

        public virtual int WorldSystemID
	    {
	        get { return _WorldSystemID; }
	        set { _WorldSystemID = value; }
	    }

        public virtual string WorldName
	    {
	        get { return _WorldName; }
	        set { _WorldName = value; }
	    }

        public virtual int HWGR_SystemID
	    {
	        get { return _HWGR_SystemID; }
	        set { _HWGR_SystemID = value; }
	    }

        public virtual string HWGR_Name
	    {
	        get { return _HWGR_Name; }
	        set { _HWGR_Name = value; }
	    }

        public virtual int WGR_SystemID
	    {
	        get { return _WGR_SystemID; }
	        set { _WGR_SystemID = value; }
	    }

	    public virtual string WGR_Name
	    {
	        get { return _WGR_Name; }
	        set { _WGR_Name = value; }
	    }

        public override bool Equals(object obj)
        {
            StoreStructure ursl = obj as StoreStructure;
            if (ursl == null)
                return false;

            return ursl.StoreID == StoreID && ursl.WorldID== WorldID &&
                ursl.HWGR_ID == HWGR_ID && ursl.WGR_ID == WGR_ID;
        }
        public override int GetHashCode()
        {
            return 23 * (int)StoreID + (int)WorldID + (int)HWGR_ID + (int)WGR_ID;
        }
	}
}
