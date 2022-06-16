using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Baumax.Domain
{
    /// <summary>
    /// EmployeeContract object for NHibernate mapped table 'EmployeeAllIn'.
    /// </summary>
    [Serializable]
    public class EmployeeAllIn: BaseEntity ,IComparable <EmployeeAllIn>
    {
        #region Member Variables

        private DateTime _BeginTime;
        protected DateTime _EndTime;
        protected bool _AllIn;
        protected long _employeeID;

        #endregion

        #region Constructors
        public EmployeeAllIn()
        { }

        public EmployeeAllIn(long employeeID, DateTime beginTime, DateTime endTime, bool allIn)
        {
            _employeeID = employeeID;
            _BeginTime = beginTime;
            _EndTime = endTime;
            _AllIn = allIn;
        }

        #endregion

        #region Public Properties
        public virtual DateTime BeginTime
        {
            get { return _BeginTime; }
            set { _BeginTime = value; }
        }

        public virtual DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        public virtual bool AllIn
        {
            get { return _AllIn; }
            set { _AllIn = value; }
        }

        public virtual long EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        #endregion

        public virtual bool IsContainDate(DateTime date)
        {
            return (BeginTime <= date && date <= EndTime);
        }

        public virtual bool IsValid()
        {
            return BeginTime <= EndTime;
        }
        private byte _entitystate = 0;
        // 0- normal
        // 1- modified
        // 2 - deleted
        public virtual byte EntityState
        {
            get { return _entitystate; }
            set { _entitystate = value; }
        }


        public int CompareTo(EmployeeAllIn entity)
        {
            Debug.Assert(entity != null);
            int i = EmployeeID.CompareTo(entity.EmployeeID);

            if (i == 0)
            {
                i = DateTime.Compare(BeginTime, entity.BeginTime);
            }

            return i;
        }

    }


    //public class ComparerAllIn : IComparer<EmployeeAllIn>
    //{
    //    public int Compare(EmployeeAllIn left, EmployeeAllIn right)
    //    {
    //        Debug.Assert(left != null);
    //        Debug.Assert(right != null);

    //        int i = left.EmployeeID.CompareTo(right.EmployeeID);

    //        if (i == 0)
    //        {
    //            i = DateTime.Compare(left.BeginTime, right.BeginTime);
    //        }

    //        return i;
    //    }
    //}
}
