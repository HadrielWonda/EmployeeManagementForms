using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;

namespace Baumax.ClientUI.FormEntities
{
    using Baumax.Domain;
    using Baumax.Environment;
    using Baumax.Contract.QueryResult;
    using Baumax.Templates;
    using Baumax.Contract;

    public enum ChangedEntityType :int
    {
        New,
        Edit,
        Delete,
        Validation
    }

    public class EntityChangedArgs : EventArgs
    {
        protected BaseEntity _entity = null;
        protected ChangedEntityType _changedType = ChangedEntityType.New;

        public EntityChangedArgs(BaseEntity aEntity, ChangedEntityType aChangedType)
        {
            _changedType = aChangedType;
            _entity = aEntity;
        }

        public BaseEntity Entity
        {
            get { return _entity; }
        }

        public ChangedEntityType ChangedType
        {
            get { return _changedType; }
        }
    }

    public class OpenCloseValidateArgs : EntityChangedArgs
    {
        private bool _IsValid = true;

        public OpenCloseValidateArgs(BaseEntity aEntity, ChangedEntityType aChangedType)
            : base(aEntity, aChangedType)
        {
            _changedType = aChangedType;
            _entity = aEntity;
        }

        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }
    }

    public enum StoreListMode
    {
        ShowAll,
        ShowByRegion
    }

    public static class StoreToWorldHelper
    {
        public static void PrepareStoreWorld(List<StoreToWorld> lst)
        {
        }
    }

    public sealed class StoreView
    {
        #region fields

        private Domain.Store _store;
        private string _storename;
        private string _countryname;
        private long _countryid;
        private string _regionname;
        private long _regionid;
        private string _postcode;
        private string _city;
        private string _address;
        private int _area;
        private int _internalid;
        private bool _editmode = false;

        #endregion

        #region properties

        public bool EditMode
        {
            get { return _editmode; }
        }

        public bool IsNew
        {
            get { return Entity.IsNew; }
        }

        public Domain.Store Entity
        {
            get { return _store; }
            //set { _store = value; }
        }

        public long ID
        {
            get { return Entity.ID; }
        }

        public string StoreName
        {
            get { return (EditMode) ? _storename : Entity.Name; }
            set
            {
                if (StoreName != value)
                {
                    if (EditMode)
                    {
                        _storename = value;
                    }
                    else
                    {
                        Entity.Name = value;
                    }
                }
            }
        }


        public string CountryName
        {
            get { return _countryname; }
            set { _countryname = value; }
        }


        public long CountryID
        {
            get { return _countryid; }
            set { _countryid = value; }
        }


        public string RegionName
        {
            get { return _regionname; }
            set { _regionname = value; }
        }


        public long RegionID
        {
            get
            {
                if (EditMode)
                {
                    return _regionid;
                }
                else
                {
                    return Entity.RegionID;
                }
            }
            set
            {
                if (value != RegionID)
                {
                    if (EditMode)
                    {
                        _regionid = value;
                    }
                    else
                    {
                        Entity.RegionID = value;
                    }
                }
            }
        }

        public string PostCode
        {
            get
            {
                if (EditMode)
                {
                    return _postcode;
                }
                else
                {
                    return Entity.Number;
                }
            }
            set
            {
                if (PostCode != value)
                {
                    if (EditMode)
                    {
                        _postcode = value;
                    }
                    else
                    {
                        Entity.Number = value;
                    }
                }
            }
        }

        public int Area
        {
            get
            {
                if (EditMode)
                {
                    return _area;
                }
                else
                {
                    return Entity.Area;
                }
            }
            set
            {
                if (Area != value)
                {
                    if (EditMode)
                    {
                        _area = value;
                    }
                    else
                    {
                        Entity.Area = value;
                    }
                }
            }
        }

        public string City
        {
            get
            {
                if (EditMode)
                {
                    return _city;
                }
                else
                {
                    return Entity.City;
                }
            }
            set
            {
                if (City != value)
                {
                    if (EditMode)
                    {
                        _city = value;
                    }
                    else
                    {
                        Entity.City = value;
                    }
                }
            }
        }


        public string Address
        {
            get { return (EditMode) ? _address : Entity.Address; }
            set
            {
                if (Address != value)
                {
                    if (EditMode)
                    {
                        _address = value;
                    }
                    else
                    {
                        Entity.Address = value;
                    }
                }
            }
        }

        public int InternalID
        {
            get { return (EditMode) ? _internalid : Entity.SystemID; }
            set
            {
                if (InternalID != value)
                {
                    if (EditMode)
                    {
                        _internalid = value;
                    }
                    else
                    {
                        Entity.SystemID = value;
                    }
                }
            }
        }

        #endregion

        public StoreView(Domain.Store store)
        {
            _store = store;
        }

        public void Edit()
        {
            _regionid = Entity.RegionID;
            _city = Entity.City;
            _address = Entity.Address;
            _postcode = Entity.Number;
            _storename = Entity.Name;
            _area = Entity.Area;
            _editmode = true;
        }

        public bool IsModified()
        {
            bool b = (_regionid == Entity.RegionID)
                     && (_city == Entity.City)
                     && (_address == Entity.Address)
                     && (_postcode == Entity.Number)
                     && (_storename == Entity.Name)
                     && (_area == Entity.Area);
            return !b;
        }

        public bool Validate()
        {
            return true;
        }

        public void Commit()
        {
            if (EditMode && IsModified())
            {
                Entity.RegionID = _regionid;
                Entity.City = _city;
                Entity.Address = _address;
                Entity.Number = _postcode;
                Entity.Name = _storename;
                Entity.Area = _area;
            }
            _editmode = false;
        }

        public void CancelEdit()
        {
            _editmode = false;
        }
    }

    // TO-DO: recode: assign to it class interface ICountryService - it do work as server or client
    public class CountryDictionary : Dictionary<long, Domain.Country>
    {
        public void AssignCountries(List<Domain.Country> clst)
        {
            if (clst != null)
            {
                foreach (Domain.Country country in clst)
                {
                    this[country.ID] = country;
                }
            }
        }

        public void Refresh()
        {
            Clear();
            List<Domain.Country> lstCountry = ClientEnvironment.CountryService.FindAll();
            AssignCountries(lstCountry);
        }
    }

    // TO-DO: recode: assign to it class interface IRegionService - it do work as server or client
    public class RegionDictionary : Dictionary<long, Domain.Region>
    {
        public void AssignRegions(List<Domain.Region> clst)
        {
            if (clst != null)
            {
                foreach (Domain.Region region in clst)
                {
                    this[region.ID] = region;
                }
            }
        }

        public void Refresh()
        {
            Clear();
            List<Domain.Region> lstRegions = ClientEnvironment.RegionService.FindAll();
            AssignRegions(lstRegions);
        }

        public List<Domain.Region> GetRegionByCountry(long countryid)
        {
            List<Domain.Region> resultList = new List<Baumax.Domain.Region>();
            foreach (Domain.Region reg in this.Values)
            {
                if (reg.CountryID == countryid)
                {
                    resultList.Add(reg);
                }
            }
            return resultList;
        }
    }

    // TO-DO: recode: assign to it class interface IStoreService - it do work as server or client
    public class StoreDictionary : Dictionary<long, Domain.Store>
    {
        public void AssignStores(List<Domain.Store> clst)
        {
            if (clst != null)
            {
                foreach (Domain.Store store in clst)
                {
                    this[store.ID] = store;
                }
            }
        }

        public void Refresh()
        {
            Clear();
            List<Domain.Store> lstStores = ClientEnvironment.StoreService.FindAll();
            AssignStores(lstStores);
        }

        public List<Domain.Store> GetStoreByRegion(long regionid)
        {
            List<Domain.Store> resultList = new List<Baumax.Domain.Store>();
            foreach (Domain.Store store in this.Values)
            {
                if (store.RegionID == regionid)
                {
                    resultList.Add(store);
                }
            }
            return resultList;
        }

        public string GetStoreName(long id)
        {
            string s = String.Empty;
            Domain.Store st = null;
            if (TryGetValue(id, out st))
            {
                s = st.Name;
            }
            return s;
        }

        public void FillEmployeeRelation(IList lstRelations)
        {
            if (lstRelations != null)
            {
                foreach (EmployeeRelation relation in lstRelations)
                {
                    relation.StoreName = GetStoreName(relation.StoreID);
                }
            }
        }
    }


    public class StoreViewList : BindingList<StoreView>
    {
        private RegionDictionary _regionDiction = null;
        private CountryDictionary _countryDiction = null;

        public Domain.Region GetRegion(long id)
        {
            if (_regionDiction == null)
            {
                _regionDiction = new RegionDictionary();
                _regionDiction.Refresh();
            }

            Domain.Region reg = null;
            _regionDiction.TryGetValue(id, out reg);
            return reg;
        }

        public Domain.Country GetCountry(long id)
        {
            if (_countryDiction == null)
            {
                _countryDiction = new CountryDictionary();
                _countryDiction.Refresh();
            }

            Domain.Country c = null;
            _countryDiction.TryGetValue(id, out c);
            return c;
        }


        public void Init()
        {
            GetRegion(-1);
            GetCountry(-1);
        }

        public void AssignStores(ICollection cols)
        {
            if (cols != null)
            {
                foreach (Domain.Store store in cols)
                {
                    StoreView view = new StoreView(store);

                    AddStoreView(view);
                }
            }
        }

        public void AddStoreView(StoreView view)
        {
            Domain.Region region = GetRegion(view.RegionID);
            if (region != null)
            {
                view.RegionName = region.Name;

                Domain.Country country = GetCountry(region.CountryID);

                if (country != null)
                {
                    view.CountryID = country.ID;
                    view.CountryName = country.Name;
                }
            }

            Add(view);
        }

        public void UpdateStoreView(Store store)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].ID == store.ID)
                {
                    StoreView view = new StoreView(store);
                    Domain.Region region = GetRegion(view.RegionID);
                    if (region != null)
                    {
                        view.RegionName = region.Name;

                        Domain.Country country = GetCountry(region.CountryID);

                        if (country != null)
                        {
                            view.CountryID = country.ID;
                            view.CountryName = country.Name;
                        }
                    }
                    this[i] = view;
                    return;
                }
            }
        }

        private int _lastsearchindex = -1;

        public int LastSearchIndex
        {
            get { return _lastsearchindex; }
            set { _lastsearchindex = value; }
        }

        public StoreView GetById(long id)
        {
            LastSearchIndex = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].ID == id)
                {
                    LastSearchIndex = i;
                    return this[i];
                }
            }

            return null;
        }

        #region  Fill data from local service

        public void LoadAll()
        {
            this.Clear();
            List<Domain.Store> lst = ClientEnvironment.StoreService.FindAll();
            AssignStores(lst);
        }

        public void RemoveAustriaStores()
        {
            long id = ClientEnvironment.CountryService.AustriaCountryID;
            for (int i = this.Count-1; i >= 0; i--)
            {
                if (this[i].CountryID == id)
                    RemoveAt(i);
            }

        }
        public void LoadByCountry(long countryid)
        {
            LoadAll();

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i].CountryID != countryid)
                {
                    this.RemoveAt(i);
                }
            }
        }

        public void LoadByRegion(long regionid)
        {
            LoadAll();

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i].RegionID != regionid)
                {
                    this.RemoveAt(i);
                }
            }
        }

        #endregion
    }

    public class StoreManagerContext
    {
        private StoreViewList _storesViewList = null;
        private StoreView _currentView = null;
        private List<StoreStructure> m_StoreStructure = null;
        private OpenCloseTimesList m_opencloseTimes = null;

        public void Init()
        {
            _storesViewList = new StoreViewList();
            _storesViewList.Init();
            _storesViewList.LoadAll();

            if (_storesViewList.Count > 0)
            {
                _currentView = _storesViewList[0];
            }
        }

        public List<StoreStructure> ListStoreStructure
        {
            get { return m_StoreStructure; }
        }

        public StoreViewList ListOfStoresView
        {
            get { return _storesViewList; }
        }

        public StoreView CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    ChangedStore();
                }
            }
        }

        public Domain.Store CurrentStore
        {
            get
            {
                if (CurrentView != null)
                {
                    return CurrentView.Entity;
                }
                return null;
            }
        }

        private void ChangedStore()
        {
            if (m_StoreStructure != null)
            {
                m_StoreStructure.Clear();
                m_StoreStructure = null;
            }
            if (m_opencloseTimes != null)
            {
                m_opencloseTimes.Clear();
                m_opencloseTimes = null;
            }
        }

        public void LoadStoreStructure()
        {
            if (CurrentStore != null)
            {
                m_StoreStructure =
                    (List<StoreStructure>) ClientEnvironment.StoreService.GetStoreStructure(CurrentStore.ID);
                PrepareStoreStructure();
            }
        }

        private void PrepareStoreStructure()
        {
            if (ListStoreStructure != null)
            {
                List<Domain.HWGR> _lstHwgr = ClientEnvironment.HWGRService.FindAll();
                List<Domain.WGR> _lstWgr = ClientEnvironment.WGRService.FindAll();
                List<Domain.World> _lstWorld = ClientEnvironment.WorldService.FindAll();

                Dictionary<long, string> _diction = new Dictionary<long, string>();

                if (_lstHwgr != null)
                {
                    foreach (Domain.HWGR hwgr in _lstHwgr)
                    {
                        _diction[hwgr.ID] = hwgr.Name;
                    }
                }
                if (_lstWgr != null)
                {
                    foreach (Domain.WGR wgr in _lstWgr)
                    {
                        _diction[wgr.ID] = wgr.Name;
                    }
                }

                if (_lstWorld != null)
                {
                    foreach (Domain.World world in _lstWorld)
                    {
                        _diction[world.ID] = world.Name;
                    }
                }
                string worldname = String.Empty;
                string hwgrname = String.Empty;
                string wgrname = String.Empty;
                foreach (StoreStructure str in ListStoreStructure)
                {
                    worldname = String.Empty;
                    hwgrname = String.Empty;
                    wgrname = String.Empty;
                    _diction.TryGetValue(str.WorldID, out worldname);
                    if (str.HWGR_ID.HasValue)
                    {
                        _diction.TryGetValue(str.HWGR_ID.Value, out hwgrname);
                    }
                    if (str.WGR_ID.HasValue)
                    {
                        _diction.TryGetValue(str.WGR_ID.Value, out wgrname);
                    }

                    str.WorldName = worldname;
                    str.HWGR_Name = hwgrname;
                    str.WGR_Name = wgrname;
                }
            }
        }

        public List<StoreStructure> GetStoreStructureByWorld(long worldid)
        {
            List<StoreStructure> lst = null;
            if (ListStoreStructure != null)
            {
                lst = new List<StoreStructure>();

                foreach (StoreStructure str in ListStoreStructure)
                {
                    if (str.Store_WorldID == worldid)
                    {
                        lst.Add(str);
                    }
                }
                if (lst.Count == 0)
                {
                    lst = null;
                }
            }
            return lst;
        }


        public void LoadOpenCloseTimes()
        {
            if (CurrentStore != null)
            {
                m_opencloseTimes = new OpenCloseTimesList(CurrentStore.ID);
                m_opencloseTimes.LoadOpenCloseTimes();
            }
            else
            {
                m_opencloseTimes = null;
            }
        }

        public OpenCloseTimesList OpenCloseTimes
        {
            get { return m_opencloseTimes; }
        }
    }


    public class OpenCloseTimesList : BindingTemplate<StoreWorkingTime>
    {
        private long m_storeid = 0;

        public OpenCloseTimesList(long storeid)
        {
            m_storeid = storeid;
        }

        public long StoreId
        {
            get { return m_storeid; }
        }

        public void LoadOpenCloseTimes()
        {
            this.Clear();
            if (StoreId > 0)
            {
                List<Domain.StoreWorkingTime> lst =
                    ClientEnvironment.StoreService.StoreWorkingTimeService.GetWorkingTimeFiltered(StoreId, null);
                CopyList(lst);
            }
        }

        public StoreWorkingTime FindNext(StoreWorkingTime workingTime)
        {
            if (workingTime == null)
            {
                throw new ArgumentNullException("workingTime");
            }
            StoreWorkingTime result = null;
            foreach (StoreWorkingTime itWorkingTime in this)
            {
                if (itWorkingTime.BeginTime > workingTime.EndTime &&
                    (result == null || result.BeginTime > itWorkingTime.BeginTime))
                {
                    result = itWorkingTime;
                }
            }

            return result;
        }

        public StoreWorkingTime FindPrevious(StoreWorkingTime workingTime)
        {
            if (workingTime == null)
            {
                throw new ArgumentNullException("workingTime");
            }
            StoreWorkingTime result = null;
            foreach (StoreWorkingTime itWorkingTime in this)
            {
                if (itWorkingTime.EndTime < workingTime.BeginTime &&
                    (result == null || result.EndTime < itWorkingTime.EndTime))
                {
                    result = itWorkingTime;
                }
            }

            return result;
        }

        public DateTime? GetNextDateTime()
        {
            DateTime? dt = DateTimeHelper.ResetTime(DateTime.Today);

            foreach (StoreWorkingTime swt in this)
            {
                if (DateTimeHelper.ResetTime(swt.EndTime) > dt)
                {
                    dt = swt.EndTime;
                }
            }
            dt = dt.Value.AddDays(1);

            if (dt >= DateTimeSql.SmallDatetimeMax)
            {
                dt = null;
            }

            return dt;
        }

        public StoreWorkingTime BuildNewEntity()
        {
            DateTime? dt = GetNextDateTime();

            if (dt == null)
            {
                return null;
            }

            StoreWorkingTime swt = ClientEnvironment.StoreWorkingTimeService.CreateEntity();

            swt.StoreID = 0;
            swt.BeginTime = dt.Value;
            swt.EndTime = DateTimeSql.SmallDatetimeMax;

            return swt;
        }


        public bool IsIntersect(long id, DateTime beginDate, DateTime endDate)
        {
            foreach (StoreWorkingTime swt in this)
            {
                if (id != swt.ID)
                {
                    if (DateTimeHelper.IsIntersectExc(beginDate, endDate, swt.BeginTime, swt.EndTime))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class StoreShortList : BindingList<StoreShort>
    {
        public StoreShortList ReInit()
        {
            List<StoreShort> list = ClientEnvironment.StoreService.GetStoreShortList();
            if ((list != null) && (list.Count > 0))
            {
                foreach (StoreShort s in list)
                {
                    Add(s);
                }
            }
            return this;
        }

        public StoreShort GetById(long id)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].ID == id)
                {
                    return this[i];
                }
            }
            return null;
        }
    }
}