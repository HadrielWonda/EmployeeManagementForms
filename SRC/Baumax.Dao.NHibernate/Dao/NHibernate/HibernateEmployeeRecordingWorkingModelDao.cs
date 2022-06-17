using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using NHibernate;
using NHibernate.Expression;
using System;
using System.Diagnostics;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeRecordingWorkingModelDao : HibernateDao<EmployeeRecordingWorkingModel>, IEmployeeRecordingWorkingModelDao
    {
        #region IEmployeeRecordingWorkingModelDao Members


        public List<EmployeeRecordingWorkingModel> GetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);
            List<EmployeeRecordingWorkingModel> res = new List<EmployeeRecordingWorkingModel>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeeRecordingWorkingModel))
                                                  .Add(Expression.Eq("EmployeeID", employeeId))
                                                  .Add(Expression.Between ("Date", beginDate, endDate))
                                                  .AddOrder(Order.Asc("Date"))
                                                  .AddOrder(Order.Asc("WorkingModelID"))
                                                  .List(res);
                                              return null;
                                          }
                );

            return res; 
        }

        public List<EmployeeRecordingWorkingModel> GetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);
            List<EmployeeRecordingWorkingModel> res = new List<EmployeeRecordingWorkingModel>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeeRecordingWorkingModel))
                                                  .Add(Expression.In("EmployeeID", employeeIds))
                                                  .Add(Expression.Between("Date", beginDate, endDate))
                                                  .AddOrder(Order.Asc("EmployeeID"))
                                                  .AddOrder(Order.Asc("Date"))
                                                  .AddOrder(Order.Asc("WorkingModelID"))
                                                  .List(res);
                                              return null;
                                          }
                );

            return res; 
        }


        public void SetWorkingModelByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate, List<EmployeeRecordingWorkingModel> lstModels)
        {
            IList lstOldList = GetWorkingModelByEmployeeId(employeeId, beginDate, endDate);
            List<EmployeeRecordingWorkingModel> oldValues = new List<EmployeeRecordingWorkingModel>();

            if (lstOldList != null)
            {
                foreach (EmployeeRecordingWorkingModel models in lstOldList)
                    oldValues.Add(models);
            }
            UpdateTwoList(oldValues, lstModels);
        }

        public void SetWorkingModelByEmployeeIds(long[] employeeIds, DateTime beginDate, DateTime endDate, List<EmployeeRecordingWorkingModel> lstModels)
        {
            IList lstOldList = GetWorkingModelByEmployeeIds(employeeIds, beginDate, endDate);
            List<EmployeeRecordingWorkingModel> oldValues = new List<EmployeeRecordingWorkingModel>();

            if (lstOldList != null)
            {
                foreach (EmployeeRecordingWorkingModel models in lstOldList)
                    oldValues.Add(models);
            }
            UpdateTwoList(oldValues, lstModels);
        }

        private void UpdateTwoList(List<EmployeeRecordingWorkingModel> lstOld, List<EmployeeRecordingWorkingModel> lstNew)
        {
            EmployeeRecordingWorkingModel newModel = null;
            EmployeeRecordingWorkingModel oldModel = null;
            List<EmployeeRecordingWorkingModel> newList = lstNew;
            List<EmployeeRecordingWorkingModel> oldList = lstOld;

            if (newList == null) newList = new List<EmployeeRecordingWorkingModel>();
            if (oldList == null) oldList = new List<EmployeeRecordingWorkingModel>();
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

        #endregion
    }
}