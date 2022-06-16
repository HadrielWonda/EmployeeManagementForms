using System;
using System.Collections;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using Baumax.Dao;
using System.Diagnostics;
using Baumax.Contract.Exceptions;

namespace Baumax.Services
{
    [ServiceID("0CFBEEBA-EB71-4b87-AF2F-E98CBAF7F9E5")]
    public class HwgrToWgrService : BaseService<HwgrToWgr>, IHwgrToWgrService
    {
        private static bool _IsRunningWgrImport = false;
        private static Object _SyncIsRunningWgrImport = new Object();

        private static bool IsRunningWgrImport
        {
            get { return _IsRunningWgrImport; }
            set 
            {
                lock (_SyncIsRunningWgrImport)
                {
                    if (_IsRunningWgrImport != value)
                    {
                        _IsRunningWgrImport = value;
                    }
                }
            }
        }

        [AccessType(AccessType.Read)]
        public List<HwgrToWgr> GetHwgrToWgrFiltered(DateTime dateon)
        {
            try
            {
                return GetTypedListFromIList(((IHwgrWgrDao) Dao).GetHwgrToWgrFiltered(dateon));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<HwgrToWgr> GetHwgrToWgrFiltered(long storeID)
        {
            try
            {
                return GetTypedListFromIList(((IHwgrWgrDao) Dao).GetHwgrToWgrFiltered(storeID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Import)]
        public List<HWGR_WGR_SysValues> Get_HWGR_WGR_SysValues()
        {
            try
            {
                return ((IHwgrWgrDao) Dao).Get_HWGR_WGR_SysValues();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Import)]
        public SaveDataResult Save_HWGR_WGR_Values(List<HWGR_WGR_SysValuesShort> list)
        {
            if (IsRunningWgrImport)
                throw new AnotherImportRunning();
            IsRunningWgrImport = true;
            try
            {
                return ((IHwgrWgrDao)Dao).Save_HWGR_WGR_Values(list);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
            finally
            {
                IsRunningWgrImport = false;
            }
        }

        [AccessType(AccessType.Write)]
        public List<HwgrToWgr> InsertRelation(HwgrToWgr entity)
        {
         /* WgrDateRangeManager manager = new WgrDateRangeManager((IHwgrWgrDao) Dao, entity);
            manager.Execute();
            return GetTypedListFromIList(manager.LoadEntities());
            */
            List<HwgrToWgr> finded = FindByNamedParam(" entity.StoreID=:storeid and entity.WGR_ID=:wgrid ", 
                    new string[] {"storeid", "wgrid" }, 
                    new object[] { entity.StoreID, entity.WGR_ID });
            return DepartmentInserter.Insert<HwgrToWgr> (this, finded, entity);
        }

        protected override bool Validate(HwgrToWgr entity)
        {
            /*IList list = FindByNamedParam(
                @" entity.ID <> :entity_id 
                AND entity.StoreID = :store_id
                AND entity.HWGR_ID = :hwgr_id
                AND entity.WGR_ID = :wgr_id
                AND ( (:from_date BETWEEN entity.BeginTime AND entity.EndTime) OR
                      (:to_date BETWEEN entity.BeginTime AND entity.EndTime) OR 
                      (entity.BeginTime BETWEEN :from_date AND :to_date) OR
                      (entity.EndTime BETWEEN :from_date AND :to_date) )",
                new string[] {"entity_id", "store_id", "hwgr_id", "wgr_id", "from_date", "to_date"},
                new object[]
                    {entity.ID, entity.StoreID, entity.HWGR_ID, entity.WGR_ID, entity.BeginTime, entity.EndTime}
                );
            if ((list != null) && (list.Count > 0))
            {
                if (entity.IsNew)
                {
                    return false;
                }
                else
                {
                    foreach (HwgrToWgr e in list)
                    {
                        if (e.ID != entity.ID)
                        {
                            return false;
                        }
                    }
                }
            }*/
            return base.Validate(entity);
        }
    }

    public class WgrDateRangeManager
    {
        IHwgrWgrDao _dao = null;
        HwgrToWgr _entity = null;
        IList _originList = null;
        List<_HwgrToWgr> _list = new List<_HwgrToWgr>();


        public WgrDateRangeManager(IHwgrWgrDao dao)
        {
            _dao = dao;
        }

        public WgrDateRangeManager(IHwgrWgrDao dao, HwgrToWgr newentity)
            : this(dao)
        {
            _entity = newentity;
        }

        public IList LoadEntities()
        {
            _originList =
                _dao.FindByNamedParam(null, "entity.StoreID=:storeID and entity.WGR_ID=:wgr_id",
                                      "order by entity.BeginTime", new string[] {"storeID", "wgr_id"},
                                      new object[] {_entity.StoreID, _entity.WGR_ID});
            FillInnerList();
            return _originList;
        }

        void FillInnerList()
        {
            _list.Clear();
            if (_originList != null)
            {
                foreach (HwgrToWgr h in _originList)
                {
                    _list.Add(new _HwgrToWgr(h));
                }
            }
        }


        public void Execute()
        {
            LoadEntities();

            if (_list.Count > 0)
            {
                _list.Sort(new TimeRangeComparer());
                _HwgrToWgr newItem = new _HwgrToWgr(_entity);
                _HwgrToWgr currentItem = null;
                for (int i = 0; i < _list.Count; i++)
                {
                    currentItem = _list[i];
                    if (currentItem.IsIntersectRanges(newItem))
                    {
                        if (currentItem.IsIncludeRange(newItem))
                        {
                            _HwgrToWgr n = currentItem.CreateCopy();

                            currentItem.EndTime = newItem.BeginTime.AddDays(-1);
                            n.BeginTime = newItem.EndTime.AddDays(1);

                            if (!currentItem.IsValid )
                            {
                                currentItem.Delete();
                            }

                            _list.Add(newItem);
                            if (n.IsValid )
                            {
                                _list.Add(n);
                            }

                            break;
                        }
                        else
                        {
                            currentItem.EndTime = newItem.BeginTime.AddDays(-1);

                            if (currentItem.IsValid )
                            {
                                currentItem.Delete();
                            }

                            for (int j = i + 1; j < _list.Count; j++)
                            {
                                currentItem = _list[j];
                                if (currentItem.IsIncludeDate(newItem.EndTime))
                                {
                                    currentItem.BeginTime = newItem.EndTime.AddDays(1);
                                    if (currentItem.IsValid)
                                    {
                                        currentItem.Delete();
                                    }
                                }
                                else
                                {
                                    currentItem.Delete();
                                }
                            }
                            _list.Add(newItem);
                            break;
                        }
                    }
                }


                FindEqualsByData();


                InsertOrUpdateOrDelete();
            }
        }

        void FindEqualsByData()
        {
            if (_list != null)
            {
                _list.Sort(new TimeRangeComparer());


                _HwgrToWgr first = null, second = null;

                for (int i = 0; i < _list.Count; i++)
                {
                    if (_list[i].IsDeleted)
                    {
                        continue;
                    }

                    if (first == null)
                    {
                        first = _list[i];
                        continue;
                    }
                    if (second == null)
                    {
                        second = _list[i];
                        if (first.IsEqualByData(second))
                        {
                            second.BeginTime = first.BeginTime;
                            first.Delete();
                        }

                        first = second;
                        second = null;
                    }
                }
            }

            foreach (_HwgrToWgr var in _list)
                if (var.BeginTime >= var.EndTime)
                    var.Delete();
            
            _list.Sort(new Comparison<_HwgrToWgr>(delegate(_HwgrToWgr a, _HwgrToWgr b) 
            {
                return (a.EndTime > b.EndTime) ? 1 : 0;
            }));
            if (_list[0].IsDeleted && _list[0].Entity.Import)
                _list[0].UnDelete();

            _list.Sort(new Comparison<_HwgrToWgr>(delegate(_HwgrToWgr a, _HwgrToWgr b)
            {
                return a.BeginTime < b.BeginTime ? 1 : 0;
            }));
            if (_list[0].IsDeleted && _list[0].Entity.Import)
                _list[0].UnDelete();

            _list.Sort(new Comparison<_HwgrToWgr>(delegate(_HwgrToWgr a, _HwgrToWgr b)
            {
                return (a.HwgrID == b.HwgrID) 
                    ? (a.BeginTime < b.BeginTime ? 1: 0) 
                    : (a.HwgrID >= b.HwgrID ? 1 : 0);
            }));
            /*
            if (_list.Count > 1)
                for (int i=1; i < _list.Count; i++)
                    if (_list[i - 1].HwgrID == _list[i].HwgrID
                        && (_list[i - 1].EndTime.AddDays(1) == _list[i].BeginTime
                            || _list[i-1].BeginTime == _list[i].BeginTime)
                        )
                    {
                        if ((_list[i - 1].IsCreated || !_list[i - 1].IsDeleted) && !_list[i].IsDeleted)
                        {
                            if (_list[i - 1].EndTime < _list[i].EndTime)
                                _list[i - 1].EndTime = _list[i].EndTime;
                            _list[i].Delete();
                        }
                        else if ((_list[i].IsCreated || !_list[i].IsDeleted) && !_list[i - 1].IsDeleted)
                        {
                            if (_list[i].EndTime < _list[i - 1].EndTime)
                                _list[i].EndTime = _list[i-1].EndTime;
                            _list[i-1].Delete();                            
                        }
                    }*/
            _list.Sort(new Comparison<_HwgrToWgr>(delegate(_HwgrToWgr a, _HwgrToWgr b)
            {
                return a.BeginTime < b.BeginTime ? 1 : 0;
            }));

            if (_list.Count > 1)
                for (int i = 1; i < _list.Count; i++)
                    if (_list[i].IsDeleted && _list[i-1].EndTime.AddDays(1) == _list[i].BeginTime)
                        _list[i].UnDelete();
            /*
            foreach (_HwgrToWgr var in _list)
                if (var.IsCreated && var.IsDeleted)
                    _list.Remove(var);
             */
        }

        void InsertOrUpdateOrDelete()
        {
            foreach (_HwgrToWgr htw in _list)
                if (htw.IsDeleted && !htw.IsCreated)
                    _dao.DeleteByID(htw.Entity.ID);
            foreach (_HwgrToWgr htw in _list)
                if (htw.IsModified || (htw.IsCreated && !htw.IsDeleted))
                    _dao.SaveOrUpdate(htw.Entity);
        }


        void Refresh()
        {
            LoadEntities();
            ParanoikCheck();
        }

        [Conditional("DEBUG")]
        public void ParanoikCheck()
        {
            if (_list != null)
            {
                _list.Sort(new TimeRangeComparer());

                for (int i = 1; i < _list.Count; i++)
                {
                    if (_list[i - 1].EndTime.Date != _list[i].BeginTime.Date.AddDays(-1))
                    {
                        throw new Exception("Invalide date range(exists whole)!!!");
                    }
                }
            }
        }

        enum RecordState
        {
            UnModified,
            Created,
            Modified,
            Deleted
        }

        class _HwgrToWgr
        {
            HwgrToWgr _entity = null;
            RecordState _state = RecordState.Created;

            public _HwgrToWgr(HwgrToWgr entity)
            {
                _entity = entity;
                if (!_entity.IsNew)
                {
                    _state = RecordState.UnModified;
                }
            }

            public RecordState State
            {
                get { return _state; }
            }

            public bool IsDeleted
            {
                get { return _state == RecordState.Deleted; }
            }

            public bool IsModified
            {
                get { return _state == RecordState.Modified; }
            }

            public bool IsCreated
            {
                get { return _entity.IsNew; }
            }

            public HwgrToWgr Entity
            {
                get { return _entity; }
            }

            public long StoreID
            {
                get { return _entity.StoreID; }
            }

            public long WgrID
            {
                get { return _entity.WGR_ID; }
            }

            public long HwgrID
            {
                get { return _entity.HWGR_ID; }
            }

            public DateTime BeginTime
            {
                get { return _entity.BeginTime.Date; }
                set
                {
                    if (BeginTime != value.Date)
                    {
                        _entity.BeginTime = value.Date;
                        if (_state != RecordState.Created)
                        {
                            _state = RecordState.Modified;
                        }
                    }
                }
            }

            public DateTime EndTime
            {
                get { return _entity.EndTime.Date; }
                set
                {
                    if (EndTime != value.Date)
                    {
                        _entity.EndTime = value.Date;
                        if (_state != RecordState.Created)
                        {
                            _state = RecordState.Modified;
                        }
                    }
                }
            }

            public bool IsIntersectRanges(_HwgrToWgr newitem)
            {
                return !((EndTime < newitem.BeginTime) || (newitem.EndTime < BeginTime));
            }

            public bool IsIncludeRange(_HwgrToWgr newitem)
            {
                return (BeginTime <= newitem.BeginTime) && (newitem.EndTime <= EndTime);
            }

            public bool IsIncludeDate(DateTime date)
            {
                DateTime d = date.Date;
                return (BeginTime <= d) && (d <= EndTime);
            }

            public bool IsEqualByData(_HwgrToWgr a)
            {
                return a.StoreID == StoreID &&
                       a.HwgrID == HwgrID &&
                       a.WgrID == WgrID;
            }

            public bool IsValid
            {
                get { return (BeginTime <= EndTime); }
            }

            public void Delete()
            {
                _state = RecordState.Deleted;
            }

            public void UnDelete()
            {
                _state = RecordState.Modified;
            }

            public _HwgrToWgr CreateCopy()
            {
                HwgrToWgr wth = new HwgrToWgr();
                BaseEntity.CopyTo(_entity, wth);
                wth.ID = 0;
                return new _HwgrToWgr(wth);
            }
        }

        class TimeRangeComparer : IComparer<_HwgrToWgr>
        {
            public int Compare(_HwgrToWgr a, _HwgrToWgr b)
            {
                if (a.IsDeleted && b.IsDeleted)
                {
                    return 0;
                }

                if (a.IsDeleted)
                {
                    return -1;
                }
                if (b.IsDeleted)
                {
                    return 1;
                }

                if (a.BeginTime == b.BeginTime && a.EndTime == b.EndTime)
                {
                    return 0;
                }

                if (a.EndTime < b.BeginTime)
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}