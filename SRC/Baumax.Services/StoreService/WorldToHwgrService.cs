using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Dao;
using Baumax.Contract.QueryResult;

namespace Baumax.Services
{
    [ServiceID("26724DF1-D6BF-443f-841E-BA0141C2ADE4")]
    public class WorldToHwgrService : BaseService<WorldToHwgr>, IWorldToHwgrService
    {
        IWorldToHwgrDao WorldHwgrDao
        {
            get { return (IWorldToHwgrDao) Dao; }
        }

        [AccessType(AccessType.Read)]
        public List<WorldToHwgr> GetWorldToHwgrFiltered(DateTime dateon)
        {
            try
            {
                return GetTypedListFromIList(((IWorldToHwgrDao) Dao).GetWorldToHwgrFiltered(dateon));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<WorldToHwgr> GetWorldToHwgrFiltered(long storeID)
        {
            try
            {
                return GetTypedListFromIList(((IWorldToHwgrDao) Dao).GetWorldToHwgrFiltered(storeID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<WorldToHwgr> GetWorldToHwgrFiltered(long storeID, long worldID, long hwgrID)
        {
            try
            {
                return GetTypedListFromIList(((IWorldToHwgrDao) Dao).GetWorldToHwgrFiltered(storeID, worldID, hwgrID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read | AccessType.Write)]
        public List<WorldToHwgr> InsertRelation(WorldToHwgr entity)
        {
         /*   HwgrDateRangeManager manager = new HwgrDateRangeManager((IWorldToHwgrDao) Dao, entity);
            manager.Execute();
            return GetTypedListFromIList(manager.LoadEntities());*/

            List<WorldToHwgr> findedWorlds = FindByNamedParam(" entity.StoreID=:storeid and entity.HWGR_ID=:hwgrid ",
                                            new string[] { "storeid", "hwgrid" },
                                            new object[] { entity.StoreID, entity.HWGR_ID });

            return DepartmentInserter.Insert<WorldToHwgr>(this, findedWorlds, entity);
        }

        protected override bool Validate(WorldToHwgr entity)
        {
//            string s = @"entity.StoreID=:storeid and entity.HWGR_ID = :hwgrid and entity.ID <> :entityid and
//                        not (:begindate > entity.EndTime or :enddate < entity.BeginTime)";

//            string[] param = new string[] { "storeid", "hwgrid", "entityid","begindate","enddate"};
//            object[] values = new object[] {entity.StoreID, entity.HWGR_ID, entity.ID, entity.BeginTime, entity.EndTime  };

//            IList lst = WorldHwgrDao.FindByNamedParam(s, param, values);

//            if (lst != null && lst.Count > 0) return false;

            return base.Validate(entity);
        }

        [AccessType(AccessType.Import)]
        public List<World_HWGR_SysValues> Get_World_HWGR_SysValues()
        {
            try
            {
                return ((IWorldToHwgrDao) Dao).Get_World_HWGR_SysValues();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
    }


    public class HwgrDateRangeManager
    {
        IWorldToHwgrDao _dao = null;
        WorldToHwgr _entity = null;
        IList _originList = null;
        List<_HwgrToWorld> _list = new List<_HwgrToWorld>();


        public HwgrDateRangeManager(IWorldToHwgrDao dao)
        {
            _dao = dao;
        }

        public HwgrDateRangeManager(IWorldToHwgrDao dao, WorldToHwgr newentity)
            : this(dao)
        {
            _entity = newentity;
        }

        public IList LoadEntities()
        {
            _originList =
                _dao.FindByNamedParam(null, "entity.StoreID=:storeID and entity.HWGR_ID=:hwgrID",
                                      "order by entity.BeginTime", new string[] {"storeID", "hwgrID"},
                                      new object[] {_entity.StoreID, _entity.HWGR_ID});
            FillInnerList();
            return _originList;
        }

        void FillInnerList()
        {
            _list.Clear();
            if (_originList != null)
            {
                foreach (WorldToHwgr h in _originList)
                {
                    _list.Add(new _HwgrToWorld(h));
                }
            }
        }


        public void Execute()
        {
            LoadEntities();

            if (_list.Count > 0)
            {
                _list.Sort(new TimeRangeComparer());
                _HwgrToWorld newItem = new _HwgrToWorld(_entity);
                _HwgrToWorld currentItem = null;
                for (int i = 0; i < _list.Count; i++)
                {
                    currentItem = _list[i];
                    if (currentItem.IsIntersectRanges(newItem))
                    {
                        if (currentItem.IsIncludeRange(newItem))
                        {
                            _HwgrToWorld n = currentItem.CreateCopy();

                            currentItem.EndTime = newItem.BeginTime.AddDays(-1);
                            n.BeginTime = newItem.EndTime.AddDays(1);

                            if (!currentItem.IsValid)
                            {
                                currentItem.Delete();
                            }

                            _list.Add(newItem);
                            if (n.IsValid)
                            {
                                _list.Add(n);
                            }

                            break;
                        }
                        else
                        {
                            currentItem.EndTime = newItem.BeginTime.AddDays(-1);

                            if (currentItem.IsValid)
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


                _HwgrToWorld first = null, second = null;

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
        }

        void InsertOrUpdateOrDelete()
        {
            foreach (_HwgrToWorld htw in _list)
            {
                if (htw.IsDeleted && !htw.Entity.IsNew)
                {
                    _dao.DeleteByID(htw.Entity.ID);
                }
            }

            foreach (_HwgrToWorld htw in _list)
            {
                if ((htw.IsModified || htw.IsCreated) && (!htw.IsDeleted ))
                {
                    _dao.SaveOrUpdate(htw.Entity);
                }
            }
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

        class _HwgrToWorld
        {
            WorldToHwgr _entity = null;
            RecordState _state = RecordState.Created;

            public _HwgrToWorld(WorldToHwgr entity)
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

            public WorldToHwgr Entity
            {
                get { return _entity; }
            }

            public long StoreID
            {
                get { return _entity.StoreID; }
            }

            public long WorldID
            {
                get { return _entity.WorldID; }
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

            public bool IsIntersectRanges(_HwgrToWorld newitem)
            {
                return !((EndTime < newitem.BeginTime) || (newitem.EndTime < BeginTime));
            }

            public bool IsIncludeRange(_HwgrToWorld newitem)
            {
                return (BeginTime <= newitem.BeginTime) && (newitem.EndTime <= EndTime);
            }

            public bool IsIncludeDate(DateTime date)
            {
                DateTime d = date.Date;
                return (BeginTime <= d) && (d <= EndTime);
            }

            public bool IsEqualByData(_HwgrToWorld a)
            {
                return a.StoreID == StoreID &&
                       a.WorldID == WorldID &&
                       a.HwgrID == HwgrID;
            }

            public bool IsValid
            {
                get { return (BeginTime <= EndTime); }
            }

            public void Delete()
            {
                _state = RecordState.Deleted;
            }

            public _HwgrToWorld CreateCopy()
            {
                WorldToHwgr wth = new WorldToHwgr();
                BaseEntity.CopyTo(_entity, wth);
                wth.ID = 0;
                return new _HwgrToWorld(wth);
            }
        }

        class TimeRangeComparer : IComparer<_HwgrToWorld>
        {
            public int Compare(_HwgrToWorld a, _HwgrToWorld b)
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