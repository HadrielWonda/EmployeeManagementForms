using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract;
using System.ComponentModel;
using Baumax.Environment;
using Baumax.Templates;
using System.Collections;
using Baumax.Contract.QueryResult;
using System.Data;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    /*
     *  1. Return list by world and date
     *  2. Merge new WorldToHwgr
     */

    public class HwgrManager
    {
        private Dictionary<long, HWGR> m_diction = new Dictionary<long, HWGR>(10);
        private static HwgrManager _instance = null;
        private List<HWGR> cachedEntities = null;

        public static HwgrManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HwgrManager();
                }
                return _instance;
            }
        }

        private HwgrManager()
        {
            //Refresh();
        }

        private string GetHwgrName(long hwgrid)
        {
            HWGR h = null;
            if (m_diction.TryGetValue(hwgrid, out h))
            {
                return h.Name;
            }
            else
            {
                return String.Empty;
            }
        }

        public void Refresh()
        {
            // acpro item #124036
            //if (cachedEntities == null) 
            cachedEntities = ClientEnvironment.HWGRService.FindAll();
            m_diction.Clear();
            // don't forget to check if reference-typed values are null!
            if (cachedEntities != null)
            {
                foreach (HWGR var in cachedEntities)
                {
                    m_diction[var.ID] = var;
                }
            }
        }

        public static void FillWorldToHwgr(WorldToHwgr entity)
        {
            entity.HwgrName = Instance.GetHwgrName(entity.HWGR_ID);
        }

        public static void FillWorldToHwgr(List<WorldToHwgr> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (WorldToHwgr var in lst)
                {
                    FillWorldToHwgr(var);
                }
            }
        }

        public static List<HWGR> List
        {
            get { return new List<HWGR>(Instance.m_diction.Values); }
        }

        public static HWGR GetHWGRByID(long id)
        {
            HWGR h = null;
            Instance.m_diction.TryGetValue(id, out h);
            return h;
        }

        internal static HWGR GetHwgrEntity(WorldToHwgr hwgr)
        {
            HWGR entity = GetHWGRByID(hwgr.HWGR_ID);
            if (entity == null)
            {
                foreach (HWGR var in Instance.m_diction.Values)
                {
                    if (var.ID == hwgr.HWGR_ID)
                    {
                        entity = var;
                        break;
                    }
                }
            }
            return entity;
        }
    }

    public class WgrManager
    {
        private Dictionary<long, Domain.WGR> m_diction = new Dictionary<long, Domain.WGR>(30);
        private static WgrManager _instance = null;
        private List<WGR> cachedEntities = null;

        public static WgrManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WgrManager();
                }
                return _instance;
            }
        }

        private WgrManager()
        {
            //Refresh();
        }

        private string GetWgrName(long wgrid)
        {
            WGR h = null;
            if (m_diction.TryGetValue(wgrid, out h))
            {
                return h.Name;
            }
            else
            {
                return String.Empty;
            }
        }

        public void Refresh()
        {
            // acpro item #124036
            //if (cachedEntities == null)
            cachedEntities = ClientEnvironment.WGRService.FindAll();
            m_diction.Clear();
            // don't forget to check if reference-typed values are null!
            if (cachedEntities != null)
            {
                foreach (Domain.WGR var in cachedEntities)
                {
                    m_diction[var.ID] = var;
                }
            }
        }

        public static void FillHwgrToWgr(HwgrToWgr entity)
        {
            entity.WgrName = Instance.GetWgrName(entity.WGR_ID);
        }

        public static void FillHwgrToWgr(List<HwgrToWgr> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                foreach (HwgrToWgr var in lst)
                {
                    FillHwgrToWgr(var);
                }
            }
        }

        public static List<Domain.WGR> List
        {
            get { return new List<Domain.WGR>(Instance.m_diction.Values); }
        }

        public static Domain.WGR GetWGRByID(long id)
        {
            Domain.WGR h = null;
            Instance.m_diction.TryGetValue(id, out h);
            return h;
        }

        internal static Domain.WGR GetWgrEntity(HwgrToWgr hwgr_wgr)
        {
            Domain.WGR entity = GetWGRByID(hwgr_wgr.ID);
            if (entity == null)
            {
                foreach (Domain.WGR var in Instance.m_diction.Values)
                {
                    if (var.ID == hwgr_wgr.WGR_ID)
                    {
                        return var;
                    }
                }
            }
            return entity;
        }
    }


    public class StoreWorldToHwgrController
    {
        private List<WorldToHwgr> _innerlist = new List<WorldToHwgr>();
        private long m_storeId = 0;

        public StoreWorldToHwgrController()
        {
        }

        public StoreWorldToHwgrController(long storeid, List<WorldToHwgr> lst)
        {
            AssignList(storeid, lst);
        }

        public long StoreId
        {
            get { return m_storeId; }
        }

        public List<WorldToHwgr> GetAll()
        {
            return _innerlist;
        }

        public void AssignList(long storeid, List<WorldToHwgr> list)
        {
            m_storeId = storeid;
            _innerlist.Clear();
            if (list != null)
            {
                _innerlist.AddRange(list);
            }

            //HwgrManager.FillWorldToHwgr(_innerlist);
        }

        public List<WorldToHwgr> GetAllByHwgr(long hwgrid)
        {
            List<WorldToHwgr> resultList = new List<WorldToHwgr>();
            for (int i = 0; i < _innerlist.Count; i++)
            {
                if (hwgrid == _innerlist[i].HWGR_ID)
                {
                    resultList.Add(_innerlist[i]);
                }
            }
            return resultList;
        }

        public void MergeWorldToHwgr(List<WorldToHwgr> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                long hwgrid = 0;
                long storeid = 0;

                hwgrid =  entities[0].HWGR_ID;
                storeid = entities[0].StoreID;

                if (_innerlist != null && hwgrid > 0)
                {
                    _innerlist.RemoveAll(delegate(WorldToHwgr wor) 
                    { 
                        return wor.HWGR_ID == hwgrid; 
                    });
                    _innerlist.AddRange(entities);
                }
            }
        }

        public WorldToHwgr GetEntityByHwgrAndDate(long worldid, long hwgrid, DateTime date)
        {
            WorldToHwgr wth = null;
            for (int i = 0; i < _innerlist.Count; i++)
            {
                wth = _innerlist[i];
                if (wth.WorldID == worldid && wth.HWGR_ID == hwgrid)
                {
                    if (wth.BeginTime.Date <= date && date <= wth.EndTime.Date)
                    {
                        return wth;
                    }
                }
            }
            return null;
        }

        public List<WorldToHwgr> GetHwgrByWorldAndDate(long worldid, DateTime date)
        {
            List<WorldToHwgr> resultList = new List<WorldToHwgr>(10);
            WorldToHwgr wth = null;
            for (int i = 0; i < _innerlist.Count; i++)
            {
                wth = _innerlist[i];
                if (wth.WorldID == worldid)
                {
                    if (wth.BeginTime.Date <= date && date <= wth.EndTime.Date)
                    {
                        resultList.Add(wth);
                    }
                }
            }
            return resultList;
        }
    }

    public class StoreWorldController
    {
        private long m_storeID;
        private Dictionary<long, Domain.StoreToWorld> m_entities = new Dictionary<long, Baumax.Domain.StoreToWorld>();

        public StoreWorldController()
        {
        }

        public StoreWorldController(long storeID) //, List<Domain.World> content)
        {
            StoreID = storeID;
        }

        public BindingList<StoreToWorld> GetStoreWorldList()
        {
            BindingList<StoreToWorld> returned = new BindingList<StoreToWorld>();

            foreach (StoreToWorld storeworld in m_entities.Values)
            {
                returned.Add(storeworld);
            }

            return returned;
        }

        public long StoreID
        {
            get { return m_storeID; }
            set
            {
                if (m_storeID != value)
                {
                    m_storeID = value;
                    OnChangeStore();
                }
            }
        }

        private void OnChangeStore()
        {
            m_entities.Clear();
            if (m_storeID > 0)
            {
                List<StoreToWorld> storeWorlds = ClientEnvironment.StoreToWorldService.FindAllForStore(m_storeID);
                if (storeWorlds != null)
                {
                    foreach (StoreToWorld storeworld in storeWorlds)
                    {
                        m_entities[storeworld.ID] = storeworld;
                    }
                }
            }
        }

        public Domain.StoreToWorld GetWorld(long store_worldID)
        {
            Domain.StoreToWorld var = null;
            m_entities.TryGetValue(store_worldID, out var);
            return var;
        }

        public string GetWorldName(long store_worldID)
        {
            Domain.StoreToWorld var = GetWorld(store_worldID);

            return (var != null) ? var.WorldName : String.Empty;
        }
    }

    public class PersonMinMaxController
    {
        protected List<PersonMinMax> m_persons;
        protected long m_storeID = 0;
        protected short m_year = (short) DateTime.Today.Year;
        private PersonMinMax m_personMinMax;

        public event EventHandler PersonalMinMaxChanged = null;

        public PersonMinMaxController()
        {
        }

        public PersonMinMaxController(long storeID)
        {
            StoreID = storeID;
        }

        public PersonMinMax PersonMinMax
        {
            get { return m_personMinMax; }
            set
            {
                if (m_personMinMax != value)
                {
                    m_personMinMax = value;
                    OnPersonalMinMaxChanged();
                }
            }
        }

        public short Year
        {
            get { return m_year; }
            set { m_year = value; }
        }

        public long StoreID
        {
            get { return m_storeID = 0; }
            set
            {
                if (m_storeID != value)
                {
                    m_storeID = value;
                    m_persons = ClientEnvironment.PersonMinMaxService.GetPersonMinMaxFiltered(m_storeID);
                }
            }
        }

        public PersonMinMax GetPerson(long storeWorldID)
        {
            if (m_year != 0 && m_persons != null)
            {
                PersonMinMax person = null;
                foreach (PersonMinMax var in m_persons)
                {
                    if (var.Year == m_year && var.Store_WorldID == storeWorldID)
                    {
                        person = var;
                        break;
                    }
                }
                return person;
            }
            else
            {
                return null;
            }
        }

        public BindingList<PersonMinMax> GetListByWorld(long storeWorldID)
        {
            BindingList<PersonMinMax> persons = new BindingList<PersonMinMax>();
            if (m_persons != null)
            {
                foreach (PersonMinMax var in m_persons)
                {
                    if (var.Store_WorldID == storeWorldID)
                    {
                        persons.Add(var);
                    }
                }
            }
            return persons;
        }

        public void RemovePerson(PersonMinMax value)
        {
            if (m_persons.Contains(value))
            {
                m_persons.Remove(value);
            }
        }

        internal void AddPerson(PersonMinMax person)
        {
            if (m_persons == null)
            {
                m_persons = new List<PersonMinMax>();
            }
            if (person != null)
            {
                m_persons.Add(person);
            }
        }

        internal void AddPerson()
        {
            AddPerson(m_personMinMax);
        }

        public bool IsNewYear(short year)
        {
            return (m_persons == null)
                       ? true
                       : m_persons.FindAll(new Predicate<PersonMinMax>(
                                               delegate(PersonMinMax p) { return p.Year == year; }))
                             .Count == 0;
        }

        public bool ValidateEditMinMaxPerson(long id, short year, long worldid)
        {
            bool isvalid = true;
            // temporary need recording
            PersonMinMax entity = new PersonMinMax(year, 0, 1, worldid);
            entity.ID = id;

            if (m_persons != null)
            {
                foreach (PersonMinMax person in m_persons)
                {
                    if (PersonMinMax.IsIntersectByYearAndWorld(person, entity))
                    {
                        isvalid = false;
                        break;
                    }
                }
            }
            return isvalid;
        }

        private void OnPersonalMinMaxChanged()
        {
            if (PersonalMinMaxChanged != null)
            {
                PersonalMinMaxChanged(this, null);
            }
        }

        public void CreateNewPerson(long? store_world_id)
        {
            PersonMinMax person = ClientEnvironment.PersonMinMaxService.CreateEntity();
            person.Max = 2;
            person.Min = 1;
            if (store_world_id.HasValue)
            {
                person.Store_WorldID = store_world_id.Value;
            }
            person.Year = (short) DateTime.Today.Year;

            PersonMinMax = person;
        }
    }

    public class WorldDetailController
    {
        private List<StoreWorldDetail> m_details = new List<StoreWorldDetail>();
        private short m_year = (short) DateTime.Today.Year;
        private long m_storeID = 0;
        private long m_worldID = 0;
        private WorldDetailList m_currentDetailList;

        private event EventHandler m_yearChanged = null;

        public event EventHandler YearChanged
        {
            add { m_yearChanged = value; }
            remove { m_yearChanged = value; }
        }

        protected void OnYearChanged()
        {
            if (m_yearChanged != null)
            {
                m_yearChanged(this, null);
            }
        }

        public WorldDetailController()
        {
        }

        public WorldDetailController(long storeID)
        {
            StoreID = storeID;
        }

        public long StoreToWorldID
        {
            get { return m_worldID; }
            set { m_worldID = value; }
        }

        public WorldDetailList CurrentDetailList
        {
            get { return m_currentDetailList; }
            set { m_currentDetailList = value; }
        }

        public long StoreID
        {
            get { return m_storeID; }
            set
            {
                if (m_storeID != value)
                {
                    m_storeID = value;
                    if (Year != 0)
                    {
                        AddDetailList();
                    }
                }
            }
        }

        public short Year
        {
            get { return m_year; }
            set
            {
                if (m_year != value)
                {
                    m_year = value;
                    AddDetailList();
                    OnYearChanged();
                }
            }
        }

        public List<StoreWorldDetail> GetDetailList()
        {
            if (StoreID != 0 && Year != 0)
            {
                return m_details.FindAll(new Predicate<StoreWorldDetail>(
                                             delegate(StoreWorldDetail var) { return var.StoreId == m_storeID && var.Year == m_year; }));
            }
            else
            {
                return null;
            }
        }

        private void AddDetailList()
        {
            m_details.Clear();
            IList list = ClientEnvironment.StoreToWorldService.GetStoreWorldDetail(m_year, StoreID);
            if (list != null)
            {
                foreach (StoreWorldDetail var in list)
                {
                    m_details.Add(var);
                }
            }
        }
    }

    public class StoreStructureContext
    {
        // key: StoreID
        protected PersonMinMaxController m_minmax = null;
        protected StoreStructureManager m_manager = null;
        protected WorldDetailController m_worldDetail = null;
        protected StoreWorldController m_storeWorld = null;

        protected Domain.Store m_store = new Store();
        protected long m_worldID = 0;
        protected WorldToHwgr m_hwgr = null;
        protected HwgrToWgr m_wgr = null;

        public event EventHandler StoreChanged = null;
        public event EventHandler WorldChanged = null;
        public event EventHandler HwgrChanged = null;
        public event EventHandler WgrChanged = null;

        public Store Store
        {
            get { return m_store; }
            set
            {
                if (m_store.ID != value.ID)
                {
                    m_store = value;
                    Invalidate();
                }
            }
        }

        public void Invalidate()
        {
            UnSubscribe();
            m_minmax = new PersonMinMaxController(m_store.ID);
            m_manager = new StoreStructureManager(m_store.ID);
            m_worldDetail = new WorldDetailController(m_store.ID);
            m_storeWorld = new StoreWorldController(m_store.ID);
            OnStoreChanged();
        }

        private void UnSubscribe()
        {
            if (TakeWorldDetail != null)
                TakeWorldDetail.YearChanged -= OnWorldDetailYearChanged;
            
        }

        public long StoreToWorldID
        {
            get { return m_worldID; }
            set
            {
                if (m_worldID != value)
                {
                    m_worldID = value;
                    StoreToWorld entity = TakeStoreWorld.GetWorld(m_worldID);
                    if (entity != null)
                    {
                        TakeStoreStructure.WorldID = entity.WorldID;
                    }
                    else
                    {
                        TakeStoreStructure.WorldID = 0;
                    }
                    //TakeStoreStructure.WorldID = TakeStoreWorld.GetWorld(m_worldID).ID;
                    OnWorldChanged();
                }
            }
        }

        public HwgrToWgr HwgrToWgr
        {
            get { return m_wgr; }
            set
            {
                m_wgr = value;
                OnWgrChanged();
            }
        }

        public WorldToHwgr WorldToHwgr
        {
            get { return m_hwgr; }
            set
            {
                m_hwgr = value;
                OnHwgrChanged();
            }
        }

        public StoreWorldController TakeStoreWorld
        {
            get { return m_storeWorld; }
        }

        public StoreStructureManager TakeStoreStructure
        {
            get { return m_manager; }
        }

        public PersonMinMaxController TakePersonMinMax
        {
            get { return m_minmax; }
        }

        public WorldDetailController TakeWorldDetail
        {
            get { return m_worldDetail; }
        }

        public static bool IsContainEntity(IEnumerable list, long id)
        {
            bool contain = false;
            if (list is IEnumerable<BaseTreeItem>)
            {
                foreach (BaseTreeItem var in list)
                {
                    if (var.GetRelationID() == id)
                    {
                        contain = true;
                        break;
                    }
                    else if (list is IEnumerable<BaseEntity>)
                    {
                        foreach (BaseEntity entity in list)
                        {
                            if (entity.ID == id)
                            {
                                contain = true;
                                break;
                            }
                        }
                    }
                }
            }
            return contain;
        }

        protected void OnStoreChanged()
        {
            TakeWorldDetail.YearChanged += new EventHandler(OnWorldDetailYearChanged);
            if (StoreChanged != null)
            {
                StoreChanged(this, null);
            }
        }

        private void OnWorldDetailYearChanged(object s, EventArgs e)
        {
            TakePersonMinMax.Year = TakeWorldDetail.Year;
        }

        protected void OnWorldChanged()
        {
            if (WorldChanged != null)
            {
                WorldChanged(this, null);
            }
        }

        protected void OnHwgrChanged()
        {
            if (HwgrChanged != null)
            {
                HwgrChanged(this, null);
            }
        }

        protected void OnWgrChanged()
        {
            if (WgrChanged != null)
            {
                WgrChanged(this, null);
            }
        }
    }

    public class StoreStructureManager
    {
        private List<StoreToWorld> worldList = null;
        private StoreWorldToHwgrController hwgrList = null;
        private List<HwgrToWgr> wgrList = null;
        private List<Domain.World> treeWorlds = null;
        private long _worldid;
        private long _storeid;
        private DateTime m_filterDate = DateTime.Today;
        private HWGR m_hwgrHistory;
        private Domain.WGR m_wgrHistory;

        public event EventHandler FilterDateChanged = null;
        public event EventHandler HwgrHistoryChanged = null;

        public event EventHandler WgrHistoryChanged = null;

        public StoreStructureManager()
        {
            m_filterDate = DateTimeHelper.GetMonday(DateTime.Today);
            HwgrManager.Instance.Refresh();
            WgrManager.Instance.Refresh();
        }

        public StoreStructureManager(long storeID) : this()
        {
            StoreID = storeID;
        }

        public bool IsAnyWgr
        {
            get 
            { 
                return wgrList != null && wgrList.Count > 0; 
            }
        }

        public List<HwgrToWgr> WgrSource
        {
            get { return wgrList; }
        }

        public StoreWorldToHwgrController HwgrSource
        {
            get { return hwgrList; }
        }

        public List<Domain.World> Worlds
        {
            get
            {
                if (treeWorlds == null)
                {
                    treeWorlds = ClientEnvironment.WorldService.FindAll();
                }
                return treeWorlds;
            }
        }

        public List<Domain.HWGR> Hwgrs
        {
            get { return HwgrManager.List; }
        }

        public List<Domain.WGR> Wgrs
        {
            get { return WgrManager.List; }
        }

        public long StoreID
        {
            get { return _storeid; }
            set
            {
                if (_storeid != value)
                {
                    _storeid = value;
                    ChangedStore();
                }
            }
        }

        public long WorldID
        {
            get { return _worldid; }
            set
            {
                _worldid = value;
                ChangedWorld();
            }
        }

        public DateTime FilterDate
        {
            get { return m_filterDate; }
            set
            {
                if (m_filterDate != value)
                {
                    m_filterDate = value;
                    OnFilterDateChanged();
                }
            }
        }

        public HWGR HwgrHistory
        {
            get { return m_hwgrHistory; }
            set
            {
                m_hwgrHistory = value;
                OnHwgrHistoryChanged();
            }
        }

        public Domain.WGR WgrHistory
        {
            get { return m_wgrHistory; }
            set
            {
                m_wgrHistory = value;
                OnWgrHistoryChanged();
            }
        }

        private void ChangedWorld()
        {
        }


        private void ChangedStore()
        {
            worldList = ClientEnvironment.StoreToWorldService.FindAllForStore(StoreID);
            hwgrList =
                new StoreWorldToHwgrController(StoreID,
                                               ClientEnvironment.WorldToHWGRService.GetWorldToHwgrFiltered(StoreID));
            wgrList = ClientEnvironment.HwgrToWgrService.GetHwgrToWgrFiltered(StoreID);

            _worldid = 0;

            WgrManager.FillHwgrToWgr(wgrList);
        }


        public void MergeWorldToHwgr(List<WorldToHwgr> entities)
        {
            hwgrList.MergeWorldToHwgr(entities);
        }

        public void MergeHwgrToWgr(List<HwgrToWgr> entities)
        {

            if (entities != null && entities.Count > 0)
            {
                WgrManager.FillHwgrToWgr(entities);

                long wgrid = entities[0].WGR_ID;
                List<HwgrToWgr> tempList = new List<HwgrToWgr>(wgrList.Count);

                foreach (HwgrToWgr entity in wgrList)
                {
                    if (entity.WGR_ID != wgrid)
                    {
                        tempList.Add(entity);
                    }
                }

                wgrList.Clear();
                wgrList.Capacity = tempList.Count;
                wgrList.AddRange(tempList);
                wgrList.AddRange(entities);
            }
        }

        public BindingTemplate<BaseTreeItem> GetStructure()
        {
            BindingTemplate<BaseTreeItem> resultList = new BindingTemplate<BaseTreeItem>();

            if (hwgrList != null)
            {
                List<WorldToHwgr> lst = hwgrList.GetHwgrByWorldAndDate(WorldID, m_filterDate);

                for (int i = 0; i < lst.Count; i++)
                {
                    resultList.Add(new HwgrTreeItem(lst[i], 0));
                }
            }
            List<WgrTreeItem> tempList = new List<WgrTreeItem>();
            foreach (HwgrTreeItem entity in resultList)
            {
                long hwgrid = entity.Hwgr.HWGR_ID;

                if (wgrList != null)
                {
                    foreach (HwgrToWgr wgr in wgrList)
                    {
                        if (wgr.HWGR_ID == hwgrid)
                        {
                            if (Check4DateRange(entity.Hwgr.BeginTime, entity.Hwgr.EndTime,
                                                wgr.BeginTime, wgr.EndTime))
                            {
                                if (CheckDateRange(wgr.BeginTime, wgr.EndTime, m_filterDate))
                                {
                                    tempList.Add(new WgrTreeItem(wgr, entity.ID));
                                }
                            }
                        }
                    }
                }
            }

            foreach (WgrTreeItem item in tempList)
            {
                resultList.Add(item);
            }

            return resultList;
        }


        public void ReBuildByHwgr(long hwgrid, BindingTemplate<BaseTreeItem> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                WorldToHwgr entity = hwgrList.GetEntityByHwgrAndDate(WorldID, hwgrid, m_filterDate);

                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].IsHwgr)
                    {
                        HwgrTreeItem item = (lst[i] as HwgrTreeItem);
                        if (item.Hwgr.HWGR_ID == hwgrid)
                        {
                            if (entity != null)
                            {
                                item.Hwgr = entity;
                            }
                            else
                            {
                                RemoveChilds(item.ID, lst);
                                lst.Remove(item);
                                lst.ClearRemoveList();
                            }
                            return;
                        }
                    }
                }
                // new item
                if (entity != null)
                {
                    HwgrTreeItem item = new HwgrTreeItem(entity, 0);
                    lst.Add(item);
                    foreach (HwgrToWgr htw in wgrList)
                    {
                        if (htw.HWGR_ID == hwgrid)
                        {
                            if (htw.BeginTime.Date <= m_filterDate && m_filterDate <= htw.EndTime.Date)
                            {
                                lst.Add(new WgrTreeItem(htw, item.ID));
                            }
                        }
                    }
                }
            }
        }

        private void RemoveChilds(long p, BindingTemplate<BaseTreeItem> lst)
        {
            if (lst != null)
            {
                for (int i = lst.Count - 1; i >= 0; i--)
                {
                    if (!lst[i].IsHwgr)
                    {
                        if (lst[i].ParentID == p)
                        {
                            lst.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private bool Check4DateRange(DateTime begin_a, DateTime end_a, DateTime begin_b, DateTime end_b)
        {
            return DateTimeHelper.ResetTime(begin_a) <= DateTimeHelper.ResetTime(end_b) ||
                   DateTimeHelper.ResetTime(end_a) >= DateTimeHelper.ResetTime(begin_b);
        }

        private bool CheckDateRange(DateTime begin, DateTime end, DateTime testing)
        {
            return DateTimeHelper.ResetTime(begin) <= DateTimeHelper.ResetTime(testing) &&
                   DateTimeHelper.ResetTime(end) >= DateTimeHelper.ResetTime(testing);
        }

        protected void OnFilterDateChanged()
        {
            if (FilterDateChanged != null)
            {
                FilterDateChanged(this, null);
            }
        }

        protected void OnHwgrHistoryChanged()
        {
            if (HwgrHistoryChanged != null)
            {
                HwgrHistoryChanged(this, null);
            }
        }

        protected void OnWgrHistoryChanged()
        {
            if (WgrHistoryChanged != null)
            {
                WgrHistoryChanged(this, null);
            }
        }

        public List<HwgrToWgr> GetWgrHistoty()
        {
            return wgrList.FindAll(
                delegate(HwgrToWgr var)
                {
                    return (m_wgrHistory != null)
                               ? var.WGR_ID == m_wgrHistory.ID && var.StoreID == _storeid
                               : var.WGR_ID == -1 && var.StoreID == _storeid;
                });
        }

        public List<WorldToHwgr> GetHwgrHistory()
        {
            if (m_hwgrHistory != null)
            {
                return hwgrList.GetAllByHwgr(m_hwgrHistory.ID);
            }
            else
            {
                return null;
            }
        }

        public HWGR GetHwgr(WorldToHwgr hwgr)
        {
            return HwgrManager.GetHwgrEntity(hwgr);
        }

        public HWGR GetHwgr(HwgrToWgr hwgr)
        {
            return HwgrManager.GetHWGRByID(hwgr.HWGR_ID);
        }

        public long GetWgrID(long hwgr_wgr_id)
        {
            for (int i = 0; i < wgrList.Count; i++)
            {
                if (wgrList[i].ID == hwgr_wgr_id)
                {
                    return wgrList[i].WGR_ID;
                }
            }
            return 0;
        }

        public Domain.WGR GetWgr(HwgrToWgr hwgr_wgr)
        {
            return WgrManager.GetWgrEntity(hwgr_wgr);
        }

        public Domain.World GetWorld(long stote_world_id)
        {
            for (int i = 0; i < Worlds.Count; i++)
            {
                if (treeWorlds[i].ID == stote_world_id)
                {
                    return Worlds[i];
                }
            }
            return null;
        }


        public void ReBuildByWgr(HwgrToWgr wgr, BindingTemplate<BaseTreeItem> lst)
        {
            if (lst != null)
            {
                List<BaseTreeItem> detect = new List<BaseTreeItem>();
                detect.AddRange(lst);
                foreach (BaseTreeItem item in detect)
                {
                    if (!item.IsHwgr && (item as WgrTreeItem).Wgr.WGR_ID == wgr.WGR_ID)
                    {
                        lst.Remove(item);
                    }
                }
                foreach (HwgrToWgr item in GetWgrHistoty())
                {
                    if (item.BeginTime <= m_filterDate && item.EndTime >= m_filterDate)
                    {
                        long parentid = 0;
                        foreach (BaseTreeItem var in lst)
                        {
                            if (var.IsHwgr && (var as HwgrTreeItem).Hwgr.HWGR_ID == item.HWGR_ID)
                            {
                                parentid = var.ID;
                                break;
                            }
                        }
                        lst.Add(new WgrTreeItem(item, parentid));
                    }
                }
                lst.ClearRemoveList();
            }
        }

        internal bool IsExistingWgr(long parentId, DateTime begin, DateTime end)
        {
            List<HwgrToWgr> list = GetWgrHistoty();
            if (list == null)
            {
                return false;
            }

            foreach (HwgrToWgr wgr in list)
            {
                if (wgr.HWGR_ID == parentId
                    && DateTimeHelper.IsEntryExc(begin, end, wgr.BeginTime, wgr.EndTime))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool IsExistingHwgr(long parentId, DateTime begin, DateTime end)
        {
            List<WorldToHwgr> list = GetHwgrHistory();
            if (list == null)
            {
                return false;
            }
            foreach (WorldToHwgr hwgr in list)
            {
                if (hwgr.WorldID == parentId
                    && DateTimeHelper.IsEntryExc(begin, end, hwgr.BeginTime, hwgr.EndTime))
                {
                    return true;
                }
            }
            return false;
        }
    }

    # region single-sweep classes for data sorces

    public class WorldDetailElement : Baumax.Contract.QueryResult.StoreWorldDetail
    {
        private short m_min;
        private short m_max;
        private decimal? m_netBusinessVolumeWithoutBuffer;

        public decimal? NetBusinessVolumeWithoutBuffer
        {
            get { return m_netBusinessVolumeWithoutBuffer; }
            set { m_netBusinessVolumeWithoutBuffer = value; }
        }

        public short Max
        {
            get { return m_max; }
            set { m_max = value; }
        }

        public short Min
        {
            get { return m_min; }
            set { m_min = value; }
        }

        public void UpdateMinMax(PersonMinMax person)
        {
            m_max = (person != null) ? person.Max : (short) 0;
            m_min = (person != null) ? person.Min : (short) 0;
        }

        public WorldDetailElement(Baumax.Contract.QueryResult.StoreWorldDetail parent,
                                  string worldName, PersonMinMax person)
        {
            this.AvailableBufferHours = parent.AvailableBufferHours;
            this.AvailableWorkTimeHours = parent.AvailableWorkTimeHours;
            this.BenchmarkPerfomance = parent.BenchmarkPerfomance;
            this.BusinessVolumeHours = parent.BusinessVolumeHours;
            this.NetBusinessVolume1 = parent.NetBusinessVolume1;
            this.NetBusinessVolume2 = parent.NetBusinessVolume2;
            this.StoreId = parent.StoreId;
            this.StoreWorldId = parent.StoreWorldId;
            this.TargetedBusinessVolume = parent.TargetedBusinessVolume;
            this.Year = parent.Year;
            this.m_min = (person != null) ? person.Min : (short) 0;
            this.m_max = (person != null) ? person.Max : (short) 0;
            this.WorldName = worldName;
            this.m_netBusinessVolumeWithoutBuffer = TargetedBusinessVolume/
                                                    (AvailableWorkTimeHours - (decimal?) AvailableBufferHours);
        }
    }

    public class WorldDetailList : BindingList<WorldDetailElement>
    {
        public void Update(StoreStructureContext context)
        {
            foreach (WorldDetailElement var in this)
            {
                var.UpdateMinMax(context.TakePersonMinMax.GetPerson(var.StoreWorldId));
            }
        }

        public WorldDetailList(List<StoreWorldDetail> lst, StoreStructureContext context)
        {
            if (lst != null)
            {
                foreach (StoreWorldDetail var in lst)
                {
                    this.Add(new WorldDetailElement(var,
                                                    context.TakeStoreWorld.GetWorldName(var.StoreWorldId),
                                                    context.TakePersonMinMax.GetPerson(var.StoreWorldId)));
                }
            }
        }
    }

    public class BaseTreeItem : BaseEntity
    {
        protected static int _nextID = 1;
        protected BaseEntity _entity;
        protected long _parentID;
        protected bool _ishwgr = true;

        public virtual int ImageIndex
        {
            get { return -1; }
            set { }
        }

        public virtual DateTime BeginTime
        {
            get { return DateTime.Today; }
            set { }
        }

        public virtual DateTime EndTime
        {
            get { return DateTime.Today; }
            set { }
        }

        public virtual string ItemName
        {
            get { return string.Empty; }
            set { }
        }

        public long ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        public BaseTreeItem(BaseEntity entity, long parentID)
        {
            _entity = entity;
            _parentID = parentID;
        }

        public BaseTreeItem()
        {
        }

        public long GetRelationID()
        {
            return _entity.ID;
        }

        public bool IsHwgr
        {
            get { return _ishwgr; }
        }
    }

    public class WgrTreeItem : BaseTreeItem
    {
        public HwgrToWgr Wgr
        {
            get { return _entity as HwgrToWgr; }
            set { _entity = value; }
        }

        public override DateTime BeginTime
        {
            get { return Wgr.BeginTime; }
            set { Wgr.BeginTime = value; }
        }

        public override DateTime EndTime
        {
            get { return Wgr.EndTime; }
            set { Wgr.EndTime = value; }
        }

        public override int ImageIndex
        {
            get { return 0; }
        }

        public override string ItemName
        {
            get { return Wgr.WgrName; }
            set { Wgr.WgrName = value; }
        }

        public WgrTreeItem(HwgrToWgr entity, long parentID)
            : base(entity, parentID)
        {
            ID = _nextID++;
            _ishwgr = false;
        }

        public WgrTreeItem(Domain.WGR entity, long parentID)
            : base(new BaseEntity(), parentID)
        {
            this.Wgr = new HwgrToWgr();
            this.Wgr.WGR_ID = entity.ID;
            base.ParentID = parentID;
            ID = _nextID++;
            _ishwgr = false;
        }
    }

    public class HwgrTreeItem : BaseTreeItem
    {
        public WorldToHwgr Hwgr
        {
            get { return _entity as WorldToHwgr; }
            set { _entity = value; }
        }

        public override DateTime BeginTime
        {
            get { return Hwgr.BeginTime; }
            set { Hwgr.BeginTime = value; }
        }

        public override DateTime EndTime
        {
            get { return Hwgr.EndTime; }
            set { Hwgr.EndTime = value; }
        }

        public override int ImageIndex
        {
            get { return 1; }
        }

        public override string ItemName
        {
            get { return Hwgr.HwgrName; }
            set { Hwgr.HwgrName = value; }
        }

        public HwgrTreeItem(WorldToHwgr entity, long parentID)
            : base(entity, parentID)
        {
            ID = _nextID++;
        }
    }

    public class WorldTreeItem : BaseTreeItem
    {
        public StoreToWorld World
        {
            get { return _entity as StoreToWorld; }
            set { _entity = value; }
        }

        public override int ImageIndex
        {
            get { return 2; }
        }

        public override string ItemName
        {
            get { return World.WorldName; }
            set { World.WorldName = value; }
        }

        public WorldTreeItem(StoreToWorld entity, long parentID)
            : base(entity, parentID)
        {
            Domain.World world = ClientEnvironment.WorldService.FindById(World.WorldID);
            if (world != null)
            {
                World.WorldName = world.Name;
            }
            ID = _nextID++;
        }

        public WorldTreeItem(Domain.World entity, long parentID)
        {
            this.World = new StoreToWorld();
            this.World.WorldID = entity.ID;
            this.World.WorldName = entity.Name;
            base.ParentID = parentID;
            ID = _nextID++;
        }

        public WorldTreeItem(long StoreToWorldID)
        {
            this.World = ClientEnvironment.StoreToWorldService.FindById(StoreToWorldID);
            Domain.World entity = ClientEnvironment.WorldService.FindById(World.WorldID);
            if (entity != null)
            {
                World.WorldName = entity.Name;
            }
            base.ParentID = World.StoreID;
            ID = _nextID++;
        }
    }

    # endregion
}