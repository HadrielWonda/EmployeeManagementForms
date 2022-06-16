using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;
using Baumax.Dao.QueryResult ;
using Baumax.Environment;
using Baumax.Domain;
using Baumax.Templates;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public static class Utility
    {
        public static void AssignWeek (ref DateTime begin, ref DateTime end)
        {
            DayOfWeek monday = begin.DayOfWeek;
            DayOfWeek sunday = end.DayOfWeek;
            /* Sunday = 0, вос
               Monday = 1, понs
               Tuesday = 2, вт
               Wednesday = 3, ср
               Thursday = 4, чт
               Friday = 5, пт
               Saturday = 6, сб*/

            if (sunday != DayOfWeek.Sunday)
                end += new TimeSpan(7 - (int)sunday, 0, 0, 0);
            if (monday != DayOfWeek.Monday)
                begin -= new TimeSpan((int)monday - 1, 0, 0, 0);
        }
        public static void GetSunday(ref DateTime end)
        {
            DayOfWeek sunday = end.DayOfWeek;
            if (sunday != DayOfWeek.Sunday)
                end += new TimeSpan(7 - (int)sunday, 0, 0, 0);
        }
        public static void GetMonday(ref DateTime begin)
        {
            DayOfWeek monday = begin.DayOfWeek;
            if (monday != DayOfWeek.Monday)
                begin -= new TimeSpan((int)monday - 1, 0, 0, 0);
        }
    }




    public enum AssignEnum 
    { 
        ThisHwgrToWorld,
        ThisHwgrToWgr,
        ThisWgrToHWGR,
        WorldHwgrDisable,
        HwgrWgrDisable
    } 

    public interface ITreeNode
    {
        long ID            { get;set;}
        string Name        { get;set;}
        DateTime BeginTime { get;set;}
        DateTime EndTime   { get;set;}
        long EntityID      { get;set;}
    }

    public class ViceWGR : ITreeNode
    {
        private DateTime _endTime;
        private string _name;
        private DateTime _beginTime;
        private long _id;

        private long _entityID;

        public long EntityID
        {
            get { return _entityID; }
            set { _entityID = value; }
        }
	

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime BeginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public ViceWGR(string name, long iD, DateTime begin, DateTime end , long entityID)
        {
            _name = name;
            _id = iD;
            _beginTime = begin;
            _endTime = end;
            _entityID = entityID;
        }


    }

    public class ViceHWGR : ITreeNode
    {
        private DateTime _endTime;
        private string _name;
        private DateTime _beginTime;
        private BindingList<ViceWGR> _wgrs = new BindingList<ViceWGR>();
        private long _id;


        private long _entityID;

        public long EntityID
        {
            get { return _entityID; }
            set { _entityID = value; }
        }
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public BindingList<ViceWGR> WGRs
        {
            get { return _wgrs; }
            set { _wgrs = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime BeginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public ViceHWGR(string name, long iD, DateTime begin, DateTime end, long entityID)
        {
            _name = name;
            _id = iD;
            _beginTime = begin;
            _endTime = end;
            _entityID = entityID;
        }
    }

    public class ViceWorld : ITreeNode
    {
        private string _name;
        private BindingList<ViceHWGR> _hwgrs = new BindingList<ViceHWGR>();
        private long _id;


        private long _entityID;

        public long EntityID
        {
            get { return _entityID; }
            set { _entityID = value; }
        }
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public BindingList<ViceHWGR> HWGRs
        {
            get { return _hwgrs; }
            set { _hwgrs = value; }
        }
        public string Name
        {
          get { return _name; }
          set { _name = value; }
        }

        public ViceWorld (string name,long iD,  long entityID)
        {
            _name = name;
            _id = iD;
            _entityID = entityID;
        }

        #region ITreeNode Members



        #endregion

        #region ITreeNode Members


        public DateTime BeginTime
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
            }
        }

        public DateTime EndTime
        {
            get
            {
               return DateTime.Now;
            }
            set
            {
            }
        }

        #endregion
    }



    public class StoreStructureItem
    {
        private int m_imageIndex;

        public int ImageIndex
        {
            get { return m_imageIndex; }
            set { m_imageIndex = value; }
        }
	

        private long m_Id;

        public long Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        private long m_ParentId;

        public long ParentId
        {
            get { return m_ParentId; }
            set { m_ParentId = value; }
        }

        private long m_RelationId;

        public long RelationId
        {
            get { return m_RelationId; }
            set { m_RelationId = value; }
        }
        private string m_ItemName;

        public string ItemName
        {
            get { return m_ItemName; }
            set { m_ItemName = value; }
        }

        private DateTime? m_BeginTime;

        public DateTime? BeginTime
        {
            get { return m_BeginTime; }
            set { m_BeginTime = value; }
        }
        private DateTime? m_EndTime;

        public DateTime? EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }


        public StoreStructureItem(long id, long pid, long rid, string name, DateTime? bt, DateTime? et, int image)
        {
            Id = id;
            ParentId = pid;
            RelationId = rid;
            ItemName = name;
            BeginTime = bt;
            EndTime = et;
            m_imageIndex = image;
        }
    }

    public class TreeSourceItems : Dictionary<long, BindingTemplate<BaseTreeItem>>
    {
        private long currentWorldID;



        public BindingTemplate<BaseTreeItem> GetByWorldID(long id, DateTime? date)
        {
            if (date != null)
            {
                BindingTemplate<BaseTreeItem> view = new BindingTemplate<BaseTreeItem>();
                foreach (BaseTreeItem var in this[id])
                    if (var.BeginTime < date && var.EndTime > date)
                        view.Add(var);
                return view;
            }
            else return this[id];
        }

        private void AddItem(BaseTreeItem item)
        {
            if (!this.ContainsKey(currentWorldID))
                this.Add(currentWorldID, new BindingTemplate<BaseTreeItem>());

            if (!this[currentWorldID].Contains(item))
                this[currentWorldID].Add(item);
        }

        public void Bind(long storeID)
        {
            /*List<Domain.WGR> wgrList = ClientEnvironment.WGRService.FindAll();
            List<Domain.HWGR> hwgrList = ClientEnvironment.HWGRService.FindAll();
            Dictionary<long, string> capsule = new Dictionary<long, string>();

            List<StoreToWorld> worldList = ClientEnvironment.StoreToWorldService.FindAllForStore(storeID);
        List<WorldToHwgr> hwgrList = ClientEnvironment.WorldToHWGRService.GetWorldToHwgrFiltered(storeID);
        List<HwgrToWgr> wgrList = ClientEnvironment.HwgrToWgrService.GetHwgrToWgrFiltered(storeID);
             
            if (wgrList != null)
                foreach (Domain.WGR var in wgrList)
                    capsule.Add(var.ID, var.Name);
            if (hwgrList != null)
                foreach (Domain.HWGR var in hwgrList)
                    capsule.Add(var.ID, var.Name);

            

            if (worldList != null)
                foreach (StoreToWorld currentWorld in worldList)
                {
                    currentWorldID = currentWorld.ID;
                    if (hwgrList != null)
                        foreach (WorldToHwgr var in hwgrList)
                        { 

                            string name = string.Empty;
                            if (capsule.TryGetValue(var.HWGR_ID, out name))
                                var.HwgrName = name;
                            HwgrTreeItem item = new HwgrTreeItem(var, currentWorldID);
                            AddItem (item);
                        }
                    //if ()
            }*/
        }
    }

    public class StoreStructureItems : Dictionary<long, BindingList<StoreStructureItem>>
    {
        Dictionary<long, StoreStructureItem> _hwgrs  = new Dictionary<long, StoreStructureItem>();
        Dictionary<long, StoreStructureItem> _wgrs   = new Dictionary<long, StoreStructureItem>();

        public void ProcessStoreStructure(IList lst)
        {
            if (lst != null)
            {
                List<Domain.WGR> wgrList = ClientEnvironment.WGRService.FindAll();
                List<Domain.HWGR> hwgrList = ClientEnvironment.HWGRService.FindAll();
                Dictionary<long, string> capsule = new Dictionary<long,string>();

                if (wgrList != null)
                    foreach (Domain.WGR var in wgrList)
                        capsule.Add(var.ID, var.Name);
                if (hwgrList != null)
                    foreach (Domain.HWGR var in hwgrList)
                        capsule.Add(var.ID, var.Name);

                long worldid = 0;
                long hwgrid = 0;
                long wgr = 0;
                BindingList<StoreStructureItem> currentWorld = new BindingList<StoreStructureItem>();

                _hwgrs.Clear();
                _wgrs.Clear();

                foreach (StoreStructure str in lst)
                {
                    worldid = str.Store_WorldID;
                    hwgrid = str.World_HWGR_ID;
                    wgr = str.HWGR_WGR_ID;

                    if (!this.ContainsKey(worldid))
                    {
                        currentWorld = new BindingList<StoreStructureItem>();
                        this.Add(worldid, currentWorld);
                    }
                    
                    if (hwgrid > 0 && worldid > 0)
                    {
                        if (!_hwgrs.ContainsKey(hwgrid))
                        {
                            string name = string.Empty;
                            capsule.TryGetValue(str.HWGR_ID, out name);
                            StoreStructureItem it = new StoreStructureItem(hwgrid, 0, str.HWGR_ID,name, str.HWGR_BeginTime, str.HWGR_EndTime, 1);
                            _hwgrs.Add(hwgrid, it);
                            currentWorld.Add(it);
                        }

                        
                        if (wgr > 0)
                        {
                            if (!_wgrs.ContainsKey(wgr) )
                            {
                                string name = string.Empty;
                                capsule.TryGetValue(str.WGR_ID, out name);
                                StoreStructureItem it = new StoreStructureItem(wgr, hwgrid, str.WGR_ID,name, str.WGR_BeginTime, str.WGR_EndTime, 0);
                                _wgrs.Add(wgr, it);
                                currentWorld.Add(it);
                            }
                        }
                    }


                }
            }
        }
    }
}
