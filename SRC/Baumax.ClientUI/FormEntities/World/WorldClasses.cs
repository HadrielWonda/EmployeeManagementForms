using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.World
{
    #region nnnnnnnn
    public enum WorldDetailType:int
    {
        AvailableWorkTimeHoursPerHour,
        AvailableBufferHours,
        BusinessVolumeHours,
        TargetedBusinessVolumeOfWorld,
        NetBusinessVolumePerHour,
        NetBusinessVolumePerHourWithoutBufferHours,
        BenchmarkPerformance
    }

    public class WorldDetailItem
    {
        private WorldDetailType  _detailtype;

        public WorldDetailType  DetailType
        {
            get { return _detailtype; }
            set { _detailtype = value; }
        }
        private string _detailname;

        public string DetailName
        {
            get { return _detailname; }
            set { _detailname = value; }
        }
        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

    }
    #endregion


   /* public class StoreStructureItem
    {
        private long m_Id;
        private long m_ParentId;
        private long m_RelationId;
        private string m_ItemName;
        private DateTime? m_BeginTime;
        private DateTime? m_EndTime;
        public long Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
       

        public long ParentId
        {
            get { return m_ParentId; }
            set { m_ParentId = value; }
        }

        

        public long RelationId
        {
            get { return m_RelationId; }
            set { m_RelationId = value; }
        }
        

        public string ItemName
        {
            get { return m_ItemName; }
            set { m_ItemName = value; }
        }

        

        public DateTime? BeginTime
        {
            get { return m_BeginTime; }
            set { m_BeginTime = value; }
        }
        

        public DateTime? EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }


        public StoreStructureItem(long id, long pid, long rid, string name, DateTime? bt, DateTime? et)
        {
            Id = id;
            ParentId = pid;
            RelationId = rid;
            ItemName = name;
            BeginTime = bt;
            EndTime = et;
        }


    }*/
/*
    public class WorldHwgrManager
    {
        List<WorldToHwgr> m_ListWorldHwgr = null;
        private long m_StoreWorldId;

        public long StoreWorldId
        {
            get { return m_StoreWorldId; }
            set { m_StoreWorldId = value; }
        }

        public void Load()
        {
            m_ListWorldHwgr = ClientEnvironment.WorldToHWGRService.FindByNamedParam("from WorldToHwgr t where t.StoreWorld_ID = :p", "p", StoreWorldId); 
        }
    }*/

  /*  public class HWgrItem
    {
        private long m_id;

        public long Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

    }
    public class StoreStructureItems : BindingList<StoreStructureItem>
    {
        Dictionary<long, StoreStructureItem> _worlds = new Dictionary<long, StoreStructureItem>();
        Dictionary<long, StoreStructureItem> _hwgrs = new Dictionary<long, StoreStructureItem>();
        Dictionary<long, StoreStructureItem> _wgrs = new Dictionary<long, StoreStructureItem>();

        public void ProcessStoreStructure(IList lst)
        {
            
            if (lst != null)
            {
                long worldid = 0;
                long hwgrid = 0;
                long wgr = 0;
                foreach (StoreStructure str in lst)
                {
                    worldid = str.Store_WorldID;

                    if (!_worlds.ContainsKey(worldid))
                    {
                        StoreStructureItem it = new StoreStructureItem(worldid, 0, str.WorldID, str.WorldName, null, null);
                        _worlds.Add(worldid, it);
                        this.Add(it);
                    }
                    hwgrid = str.World_HWGR_ID;

                    if (hwgrid > 0)
                    {
                        if (!_hwgrs.ContainsKey(hwgrid))
                        {
                            StoreStructureItem it = new StoreStructureItem(hwgrid, worldid, str.HWGR_ID, str.HWGR_Name, str.HWGR_BeginTime, str.HWGR_EndTime);
                            _hwgrs.Add(hwgrid, it);
                            this.Add(it);
                        }

                        wgr = str.HWGR_WGR_ID;
                        if (wgr > 0)
                        {
                            if (!_wgrs.ContainsKey(wgr))
                            {
                                StoreStructureItem it = new StoreStructureItem(wgr, hwgrid, str.WGR_ID, str.WGR_Name, str.WGR_BeginTime, str.WGR_EndTime);
                                _wgrs.Add(wgr, it);
                                this.Add(it);
                            }
                        }
                    }

                }
                _worlds.Clear();
                _hwgrs.Clear();
                _wgrs.Clear();

            }
        }
        // only data of single world
        public void ProcessStoreStructure2(List<StoreStructure> lst)
        {
            _hwgrs.Clear();
            long nextid = 1;
            if (lst != null)
            {
                long hwgrid = 0;
                long wgr = 0;
                foreach (StoreStructure str in lst)
                {
                    hwgrid = str.World_HWGR_ID;

                    if (hwgrid > 0)
                    {
                        if (!_hwgrs.ContainsKey(hwgrid))
                        {
                            StoreStructureItem it = new StoreStructureItem(nextid++, 0, str.HWGR_ID, str.HWGR_Name, str.HWGR_BeginTime, str.HWGR_EndTime);
                            _hwgrs.Add(hwgrid, it);
                            this.Add(it);
                        }

                        wgr = str.HWGR_WGR_ID;
                        if (wgr > 0)
                        {
                            if (((str.HWGR_BeginTime <= str.WGR_BeginTime) && (str.WGR_BeginTime <= str.HWGR_EndTime)) ||
                                (((str.HWGR_BeginTime <= str.WGR_EndTime) && (str.WGR_EndTime <= str.HWGR_EndTime))))
                            {
                                if (!_wgrs.ContainsKey(wgr))
                                {
                                    StoreStructureItem it = new StoreStructureItem(nextid++, hwgrid, str.WGR_ID, str.WGR_Name, str.WGR_BeginTime, str.WGR_EndTime);
                                    _wgrs.Add(wgr, it);
                                    this.Add(it);
                                }
                            }
                        }
                    }

                }
                _worlds.Clear();
                _hwgrs.Clear();
                _wgrs.Clear();

            }
        }
    }*/

}
