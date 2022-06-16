using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Services
{
    public static class DepartmentInserter
    {
        public static List<T> Insert<T>(BaseService<T> service, List<T> source, T newEntity) 
                                        where T : BaseEntity, IDepartment, new()
        {
            List<T> result = new List<T>();
            List<Department> departList = new List<Department>();

            foreach (T item in source)
                departList.Add(new Department(item));
            
            List<Department> processed = Insert(departList, new Department(newEntity));

            foreach (Department department in processed)
                switch (department.State)
                {
                    case DepartState.Insert:
                        result.Add (service.Save (department.FillEntity (service.CreateEntity())));
                        break;

                    case DepartState.Update:
                        result.Add(service.Update(department.Cast<T>()));
                        break;

                    case DepartState.Delete:
                        service.DeleteByID(department.ID);
                        break;

                    case DepartState.None:
                        result.Add(department.Cast<T>());
                        break;
                }
            return result;
        }

        private static List<Department> Insert(List<Department> list, Department department)
        {
            List<Department> added = new List<Department>();
            department.State = DepartState.Insert;

            foreach (Department current in list)

                if (current.IsEnter (department))
                    current.State = DepartState.Delete;
                else
                    if (current.ParentID == department.ParentID)
                    {
                        if (current.IsCover(department))
                        {
                            department.State = DepartState.None;
                            break;
                        }
                        else if (current.IsLeftIntersect(department))
                        {
                            department.Begin = current.Begin;
                            current.State = DepartState.Delete;
                        }
                        else if (current.IsRightIntersect(department))
                        {
                            department.End = current.End;
                            current.State = DepartState.Delete;
                        }
                    }
                    else
                    {
                        if (current.IsCover(department))
                        {
                            added.Add(new Department(department.End.AddDays(1d), current.End, current.SectorID, current.ParentID, current.StoreID));
                            current.End = department.Begin.AddDays(-1);
                            current.State = DepartState.Update;
                            break;
                        }
                        else if (current.IsLeftIntersect(department))
                        {
                            current.End = department.Begin.AddDays(-1d);
                            current.State = DepartState.Update;
                        }
                        else if (current.IsRightIntersect(department))
                        {
                            current.Begin = department.End.AddDays(1d);
                            current.State = DepartState.Update;
                        }
                    }
            
            list.AddRange(added);
            list.RemoveAll(delegate(Department rem)
            {
                if (rem.Begin >= rem.End)
                {
                    if (rem.ID <= 0)
                        return true;
                    rem.State = DepartState.Delete;
                }
                return false;
            });

            if (department.State == DepartState.Insert)
                list.Add(department);
            return list;
        }
    }

    public class Department
    {
        #region fields
        private DepartState _state;
        private IDepartment _entity;
        private long _storeID;
        private DateTime _end;
        private DateTime _begin;
        private long _parentID;
        private long _sectorID;
        private long _id;
        #endregion

        #region properties
        public long StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }
        public DateTime Begin
        {
            get { return _begin; }
            set { _begin = value; }
        }
	
        public long ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }
	
        public long SectorID
        {
            get { return _sectorID; }
            set { _sectorID = value; }
        }
        public DepartState State
        {
            get { return _state; }
            set { _state = value; }
        }
        #endregion
        
        public bool IsEnter(Department other)
        {
            return _begin >= other.Begin && _end <= other.End;
        }

        public bool IsCover(Department other)
        {
            return _begin <= other.Begin && _end >= other.End;
        }

        public bool IsLeftIntersect(Department other)
        {
            return _end.AddDays(1d) >= other.Begin && _begin < other.Begin;
        }

        public bool IsRightIntersect(Department other)
        {
            return _begin.AddDays(-1d) <= other.End && _end > other.Begin;
        }

        public T FillEntity<T>(T entity) where T : IDepartment
        {
            entity.BeginTime = _begin;
            entity.EndTime = _end;
            entity.ParentID = _parentID;
            entity.SectorID = _sectorID;
            entity.StoreID = _storeID;
            return entity;
        }

        public T Cast<T>() where T : BaseEntity, IDepartment, new()
        {
            return FillEntity(_entity as T);
        }

        public Department(DateTime begin, DateTime end, long sectorID, long parentID, long storeID)
        {
            _begin = begin;
            _end = end;
            _parentID = parentID;
            _sectorID = sectorID;
            _storeID = storeID;
            _state = DepartState.Insert;
            _id = 0;
        }

        public Department(IDepartment entity)
        {
            _entity = entity;
            _id = entity.ID;
            _state = DepartState.None;
            _begin = entity.BeginTime;
            _end = entity.EndTime;
            _sectorID = entity.SectorID;
            _parentID = entity.ParentID;
            _storeID = entity.StoreID;
        }
    }

    public enum DepartState
    { 
        Insert,
        Update,
        Delete,
        None
    }
}
