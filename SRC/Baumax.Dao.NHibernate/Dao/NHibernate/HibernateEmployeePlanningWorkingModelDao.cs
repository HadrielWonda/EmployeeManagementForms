using Baumax.Domain;
using System.Collections;
using System;
using NHibernate;
using NHibernate.Expression;
using System.Collections.Generic;
using System.Diagnostics;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeePlanningWorkingModelDao : HibernateDao<EmployeePlanningWorkingModel>, IEmployeePlanningWorkingModelDao
    {
        public IList LoadByEmployeesAndDateRange(long[] emplids, DateTime begin, DateTime end)
        {
            return (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                         {
                                                             return session.CreateCriteria(
                                                                 typeof (EmployeePlanningWorkingModel))
                                                                 .Add(Expression.In("EmployeeID", emplids))
                                                                 .Add(Expression.Between("Date", begin, end))
                                                                 .AddOrder (Order.Asc ("EmployeeID"))
                                                                 .AddOrder(Order.Asc("Date"))
                                                                 .AddOrder(Order.Asc("WorkingModelID"))
                                                                 .List();
                                                         }
                               );
        }

        public List<EmployeePlanningWorkingModel> GetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);
            
            List<EmployeePlanningWorkingModel> res = new List<EmployeePlanningWorkingModel>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeePlanningWorkingModel))
                                                  .Add(Expression.Eq("EmployeeID", employeeId))
                                                  .Add(Expression.Between("Date", beginDate, endDate))
                                                  .AddOrder(Order.Asc("Date"))
                                                  .AddOrder(Order.Asc("WorkingModelID"))
                                                  .List(res);
                                              return null;
                                          }
                );

            return res;
        }

        public List<EmployeePlanningWorkingModel> GetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);
            
            List<EmployeePlanningWorkingModel> res = new List<EmployeePlanningWorkingModel>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeePlanningWorkingModel))
                                                  .Add(Expression.In("EmployeeID", employeeIds))
                                                  .Add(Expression.Between("Date", beginDate, endDate))
                                                  .AddOrder(Order.Asc("EmployeeID"))
                                                  .AddOrder(Order.Asc("Date"))
                                                  .AddOrder(Order.Asc("WorkingModelID"))
                                                  .List(res);
                                              return null;
                                          }
                );

            return GetTypedListFromIList(res);
        }

        public void SetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate, List<EmployeePlanningWorkingModel> lstModels)
        {
            IList lstOldList = GetWorkingModelByEmployeeId(employeeId, beginDate, endDate);
            List<EmployeePlanningWorkingModel> oldValues = new List<EmployeePlanningWorkingModel>();

            if (lstOldList != null)
            {
                foreach (EmployeePlanningWorkingModel models in lstOldList)
                    oldValues.Add(models);
            }
            UpdateTwoList(oldValues, lstModels);
        }

        public void SetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate, List<EmployeePlanningWorkingModel> lstModels)
        {
            IList lstOldList = GetWorkingModelByEmployeeIds(employeeIds, beginDate, endDate);
            List<EmployeePlanningWorkingModel> oldValues = new List<EmployeePlanningWorkingModel>();

            if (lstOldList != null)
            {
                foreach (EmployeePlanningWorkingModel models in lstOldList)
                    oldValues.Add(models);
            }
            UpdateTwoList(oldValues, lstModels);
        }

        private void UpdateTwoList(List<EmployeePlanningWorkingModel> lstOld, List<EmployeePlanningWorkingModel> lstNew)
        {
            EmployeePlanningWorkingModel newModel = null;
            EmployeePlanningWorkingModel oldModel = null;
            List<EmployeePlanningWorkingModel> newList = lstNew;
            List<EmployeePlanningWorkingModel> oldList = lstOld;

            if (newList == null) newList = new List<EmployeePlanningWorkingModel>();
            if (oldList == null) oldList = new List<EmployeePlanningWorkingModel>();
            int index = Math.Max(newList.Count, oldList.Count);

            for (int i = 0; i < index; i++)
            {
                if (i < newList.Count)
                {
                    newModel = newList[i];
                }
                if (i < oldList.Count)
                {
                    oldModel = oldList[i];
                }


                if (oldModel == null)
                {
                    newModel.ID = 0;
                    SaveOrUpdate(newModel);
                }
                else if (newModel == null)
                {
                    DeleteByID(oldModel.ID);
                }
                else
                {
                    newModel.ID = oldModel.ID;
                    SaveOrUpdate(newModel);
                }

            }
        }

    }
}