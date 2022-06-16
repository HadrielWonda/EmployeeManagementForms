using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;

namespace Baumax.Services._HelperObjects.ResetsSaldo
{
    public interface IResetSaldoCache
    {
        ResetSaldoList FilterByEmployeeID(long emplid);
        ResetSaldoList FilterByEmployeeID(long emplid, DateTime begin, DateTime end);
        ResetSaldo GetResetSaldoIfExists(long emplid, DateTime begin, DateTime end);
        ResetSaldo FindByEmployeeIDAndDate(long emplid, DateTime date);
        bool IsExistsReset(long emplid, DateTime date);
    }
    public class ResetSaldo
    {
        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private long _EmployeeID;

        public long EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

    }

    public class ResetSaldoList:List<ResetSaldo>,IResetSaldoCache
    {
        public ResetSaldoList(ICollection<ResetSaldo> colls)
        {
            AddRange(colls);
        }
        public ResetSaldoList() { }


        public ResetSaldoList FilterByEmployeeID(long emplid)
        {
            ResetSaldoList list = FilterByEmployeeID(emplid, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax);

            return list;
        }
        public ResetSaldoList FilterByEmployeeID(long emplid, DateTime begin, DateTime end)
        {
            ResetSaldoList list = new ResetSaldoList();

            foreach (ResetSaldo rs in this)
            {
                if (rs.EmployeeID == emplid && DateTimeHelper.Between(rs.Date, begin, end))
                    list.Add(rs);
            }

            return list;
        }
        public ResetSaldo GetResetSaldoIfExists(long emplid, DateTime begin, DateTime end)
        {
            ResetSaldoList list = FilterByEmployeeID(emplid, begin, end);

            if (list != null && list.Count > 0)
                return list[list.Count - 1];

            return null;
        }

        public ResetSaldo FindByEmployeeIDAndDate(long emplid, DateTime date)
        {
            foreach (ResetSaldo rs in this)
            {
                if (rs.EmployeeID == emplid && rs.Date == date)
                    return rs;
            }
            return null;
        }
        public bool IsExistsReset(long emplid, DateTime date)
        {
            return FindByEmployeeIDAndDate(emplid, date) != null;
        }
    }

    public class CacheResetSaldo : Dictionary<long, ResetSaldoList>,IResetSaldoCache
    {
        public CacheResetSaldo(ICollection <ResetSaldo> colls)
        {
            BuildDiction(colls);
        }

        private void BuildDiction(ICollection<ResetSaldo> colls)
        {
            if (colls != null)
            {
                foreach (ResetSaldo rs in colls)
                    _AddItem(rs);
            }
        }

        protected virtual void _AddItem(ResetSaldo entity)
        {
            ResetSaldoList list = null;
            if (!this.TryGetValue(entity.EmployeeID, out list))
            {
                list = new ResetSaldoList();
                this[entity.EmployeeID] = list;
            }

            list.Add(entity);
        }

        public ResetSaldoList GetByEmployeeId(long emplid)
        {
            ResetSaldoList list = null;
            
            this.TryGetValue(emplid, out list);

            return list;
        }

        public ResetSaldoList FilterByEmployeeID(long emplid)
        {
            ResetSaldoList list = FilterByEmployeeID(emplid, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax);

            return list;
        }
        public ResetSaldoList FilterByEmployeeID(long emplid, DateTime begin, DateTime end)
        {
            ResetSaldoList list = new ResetSaldoList();
            ResetSaldoList listCache = GetByEmployeeId(emplid);
            if (listCache != null)
            {
                foreach (ResetSaldo rs in listCache)
                {
                    if (rs.EmployeeID == emplid && DateTimeHelper.Between(rs.Date, begin, end))
                        list.Add(rs);
                }
            }
            return list;
        }
        public ResetSaldo GetResetSaldoIfExists(long emplid, DateTime begin, DateTime end)
        {
            ResetSaldoList list = FilterByEmployeeID(emplid, begin, end);

            if (list != null && list.Count > 0)
                return list[list.Count - 1];

            return null;
        }

        public ResetSaldo FindByEmployeeIDAndDate(long emplid, DateTime date)
        {
            ResetSaldoList listCache = GetByEmployeeId(emplid);
            if (listCache != null)
            {
                foreach (ResetSaldo rs in listCache)
                {
                    if (rs.EmployeeID == emplid && rs.Date == date)
                        return rs;
                }
            }
            return null;
        }
        public bool IsExistsReset(long emplid, DateTime date)
        {
            return FindByEmployeeIDAndDate(emplid, date) != null;
        }

    }
}
