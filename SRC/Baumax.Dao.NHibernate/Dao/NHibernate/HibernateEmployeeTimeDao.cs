using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using System.Data.SqlClient;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using System.Globalization;
using NHibernate;
using Rsdn.Framework.Data;
using Rsdn.Framework.Data.Mapping;

using Spring.Data.NHibernate.Support;
using Baumax.Contract.Interfaces;
using NHibernate.Expression;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeTimeDao : HibernateDaoSupport, IEmployeeTimeDao
    {
        const int _RowsInBatch = 200;

        #region Private Fields
        private IAbsenceTimePlanningDao _AbsenceTimePlanningDao;
        private IAbsenceTimeRecordingDao _AbsenceTimeRecordingDao;
        private IWorkingTimePlanningDao _WorkingTimePlanningDao;
        private IWorkingTimeRecordingDao _WorkingTimeRecordingDao;
        private IAuthorizationService _AuthorizationService;
        private IEmployeeDayStatePlanningDao _EmployeeDayStatePlanningDao;
        private IEmployeeDayStateRecordingDao _EmployeeDayStateRecordingDao;
        private IEmployeeWeekTimePlanningDao _EmployeeWeekTimePlanningDao;
        private IEmployeeWeekTimeRecordingDao _EmployeeWeekTimeRecordingDao;
        private IEmployeePlanningWorkingModelDao _EmployeePlanningWorkingModelDao;
        private IEmployeeDao _EmployeeDao;
        private IEmployeeRecordingWorkingModelDao _EmployeeRecordingWorkingModelDao;
        private IEmployeeHolidaysInfoDao _EmployeeHolidaysInfoDao;
        #endregion

        #region Private Functions
        private string[] createQueriesForInsert(List<ImportTimeData> list)
        {
            int listsCount = list.Count / _RowsInBatch;
            int partLastCount = list.Count - listsCount * _RowsInBatch;
            if (partLastCount > 0)
                listsCount++;
            string[] result = new string[listsCount];
            for (int i = 0; i < listsCount; i++)
            {
                int count = _RowsInBatch;
                if (i == (listsCount - 1))
                    count = partLastCount;
                result[i]= createQueryForInsert(list.GetRange(i * _RowsInBatch, count).ToArray());
            }
            return result;
        }
        private string createQueryForInsert(ImportTimeData[] data)
        {
            string query = "select N'{0}','{1}',N'{2}',{3},{4} {5}";
            StringBuilder result = new StringBuilder("insert into #tp4insert ([PersID], [Date], [CharID], [Begin], [End]) ", (query.Length + 50 )* _RowsInBatch);
            if (data.Length > 0)
            {
                for (int i = 0; i < data.Length - 1; i++)
                {
                    result.AppendFormat(query,
                        data[i].PersID,
                        data[i].Date.ToString("yyyyMMdd"),
                        data[i].CharID,
                        data[i].Begin,
                        data[i].End,
                        "union all ");
                }
                result.AppendFormat(query,
                    data[data.Length - 1].PersID,
                    data[data.Length - 1].Date.ToString("yyyyMMdd"),
                    data[data.Length - 1].CharID,
                    data[data.Length - 1].Begin,
                    data[data.Length - 1].End,
                    "");
                return result.ToString();
            }
            return "";
        }
        #endregion

        #region IEmployeeTimeDao
        public SaveDataResult ImportTime(List<ImportTimeData> list, ImportTimeType importTimeType)
        {
            SaveDataResult result = new SaveDataResult();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
@" create table #tp4insert
(
    [PersID] nvarchar (25), 
    [Date] smalldatetime,
    [CharID] nvarchar (10), 
    [Begin] smallint,
    [End] smallint
)
";
                using (IDbCommand command = Session.Connection.CreateCommand())
                {
                    Session.Transaction.Enlist(command);
                    command.CommandText = query;
                    command.CommandTimeout = 60 * 6;
                    command.ExecuteNonQuery();
                    string[] queries = createQueriesForInsert(list);
                    for (int i = 0; i < queries.Length; i++)
                    {
                        command.CommandText = queries[i];
                        command.ExecuteNonQuery();
                    }
                    if (importTimeType == ImportTimeType.Planning)
                        command.CommandText = "spEmployeeTimePlanning_ImportData";
                    else
                        command.CommandText = "spEmployeeTimeRecording_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
					SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
					importResult.Direction = ParameterDirection.Output;
					command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        //list = Map.ToList<ImportTimeData>(reader);
                        result.Data = GetResultFromTimeImport(reader);
                        reader.NextResult();
                        result.Success = ((int)importResult.Value > 0);
                    }
                }
                if (importTimeType == ImportTimeType.Planning)
                {
                    _AbsenceTimePlanningDao.OnDaoInvalidateWholeCache();
                    _WorkingTimePlanningDao.OnDaoInvalidateWholeCache();
                }
                else
                {
                    _AbsenceTimeRecordingDao.OnDaoInvalidateWholeCache();
                    _WorkingTimeRecordingDao.OnDaoInvalidateWholeCache();
                }
            }
            return result;
        }

        IList GetResultFromTimeImport(IDataReader reader)
        {
            const int valuesCount = 2;
            DateTime?[,] result = new DateTime?[1, valuesCount];
            if (reader.Read())
            {
                for (int i = 0; i < valuesCount; i++)
                    if (reader.IsDBNull(i))
                        result[0, i] = null;
                    else
                        result[0, i] = reader.GetDateTime(i);
            }
            return result;
        }

        public int? GetEmployeeLastVerifiedSaldo(long employeeid, DateTime currentMonday)
        {
            EmployeeWeekTimeRecording entity = (EmployeeWeekTimeRecording)HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        return session.CreateCriteria(typeof (EmployeeWeekTimeRecording))
                            .Add(Expression.Eq("EmployeeID", employeeid))
                            .Add(Expression.Lt("WeekBegin", currentMonday))
                            .AddOrder(Order.Desc("WeekBegin"))
                            .SetMaxResults(1)
                            .UniqueResult<EmployeeWeekTimeRecording>();
                    }
                );

            EmployeeWeekTimePlanning entity2 = (EmployeeWeekTimePlanning)HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        return session.CreateCriteria(typeof (EmployeeWeekTimePlanning))
                            .Add(Expression.Eq("EmployeeID", employeeid))
                            .Add(Expression.Lt("WeekBegin", currentMonday))
                            .AddOrder(Order.Desc("WeekBegin"))
                            .SetMaxResults(1)
                            .UniqueResult<EmployeeWeekTimePlanning>();
                    }
                );
            

            if (entity == null && entity2 == null) 
                return null;
            else
            {
                if (entity == null) 
                    return entity2.Saldo;

                if (entity2 == null) 
                    return entity.Saldo;

                if (entity.WeekBegin < entity2.WeekBegin)
                    return entity2.Saldo;
                else 
                    return entity.Saldo;
            }

        }

        public long[][] EmployeeTimeSaldoGet(long[] employeeIDList, EmployeeTimeSaldoType employeeTimeSaldoType, DateTime date)
        {
            long[][] result;
            if (employeeIDList != null && employeeIDList.Length > 0)
            {
                using (IDbCommand command = Session.Connection.CreateCommand())
                {
                    Session.Transaction.Enlist(command);
                    command.CommandTimeout = 0;
                    command.CommandText = "spEmployeeTimeSaldo";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter typeParam = new SqlParameter("@type", SqlDbType.Int, 4);
                    typeParam.Value = employeeTimeSaldoType;
                    command.Parameters.Add(typeParam);

                    SqlParameter xmlDocument = new SqlParameter("@xmlDocument", SqlDbType.NText);
                    xmlDocument.Value = Utils.GetParamsInXml(employeeIDList, "Employee", "EmployeeID");
                    command.Parameters.Add(xmlDocument);

                    SqlParameter dateParam = new SqlParameter("@Date", SqlDbType.SmallDateTime, 4);
                    dateParam.Value = date;
                    command.Parameters.Add(dateParam);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        List<EmployeeSaldo> list = Map.ToList<EmployeeSaldo>(reader);
                        result = new long[list.Count][];
                        for (int i = 0; i < list.Count; i++)
                        {
                            result[i] = new long[2];
                            result[i][0] = list[i].EmployeeID;
                            result[i][1] = list[i].Saldo;
                        }
                    }

                }
            }
            else
                result = new long[0][];
            return result;
        }

        public class EmployeeSaldo
        {
            public long EmployeeID;
            public long Saldo;
        }

        public List<long> GetStoresWhereWorkedEmployee(long employeeid, DateTime begin, DateTime end)
        {
            string hql = @"select distinct st.id 
                                from 
                            Store st, 
                            EmployeeDayStatePlanning days, 
                            StoreToWorld sw 
                                where
                            sw.StoreID= st.id AND 
                            days.StoreWorldId=sw.id and 
                            (days.Date BETWEEN '{1}' AND '{2}') and 
                            days.EmployeeID={0}";
            string hql2 = @"select distinct st.id 
                                from 
                            Store st, 
                            EmployeeDayStateRecording days, 
                            StoreToWorld sw 
                                where
                            sw.StoreID= st.id AND 
                            days.StoreWorldId=sw.id and 
                            (days.Date BETWEEN '{1}' AND '{2}') and 
                            days.EmployeeID={0}";

            string query = String.Format(hql, employeeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));


            IList objects = HibernateTemplate.FindByNamedParam(query, new string[] { }, new object[] { });

            string query2 = String.Format(hql2, employeeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));

            IList objects2 = HibernateTemplate.FindByNamedParam(query2, new string[] { }, new object[] { });
            Dictionary<long, object> diction = new Dictionary<long, object>();

            if (objects != null)
            {
                foreach (long id in objects)
                    diction[id] = null;
            }
            if (objects2 != null)
            {
                foreach (long id in objects2)
                    diction[id] = null;
            }

            if (diction.Count == 0)
                return null;

            List<long> ids = new List<long>(diction.Keys);

            return ids;

        }

        public long[] EmployeeListContractEndOutsideChangedGet()
        {
            List<long> result = new List<long>();
            string query = "exec spEmployeeList_ContractEndOutsideChangedGet";

            HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    session.CreateSQLQuery(query)
                        .AddScalar("EmployeeID", NHibernateUtil.Int64)
                        .List(result);
                    return null;
                }
                );
            return result.ToArray();
        }

        public DateTime GetMaxDateOfPlanningOrRecording(long emplid)
        {
            string hql1 = @"select max(entity.Date) from EmployeeDayStatePlanning entity 
                            where entity.EmployeeID={0}";
            string hql2 = @"select max(entity.Date) from EmployeeDayStateRecording entity 
                            where entity.EmployeeID={0}";

            string hql3 = @"select max(entity.Date) from AbsenceTimePlanning entity 
                            where entity.EmployeeID={0}";

            DateTime date = DateTimeSql.SmallDatetimeMin ;
            DateTime query_date;
            IList list = HibernateTemplate.Find(string.Format(hql1, emplid));
            if (list != null && list.Count == 1 && list[0] != null)
            {
                query_date = (DateTime)list[0];
                if (date < query_date)
                    date = query_date;
            }
            list = HibernateTemplate.Find(string.Format(hql2, emplid));
            if (list != null && list.Count == 1 && list[0] != null)
            {
                query_date = (DateTime)list[0];
                if (date < query_date)
                    date = query_date;
            }
            list = HibernateTemplate.Find(string.Format(hql3, emplid));
            if (list != null && list.Count == 1 && list[0] != null)
            {
                query_date = (DateTime)list[0];
                if (date < query_date)
                    date = query_date;
            }
            //HibernateTemplate.Execute(delegate(ISession session)
            //    {
            //        IList <DateTime> list = 
            //            session.CreateQuery(string.Format(hql1, emplid)).List<DateTime>();

            //        if (list != null && list.Count == 1)
            //        {
            //            if (date < list[0])
            //                date = list[0];
            //        }
            //        list =
            //            session.CreateQuery(string.Format(hql2, emplid)).List<DateTime>();
            //        if (list != null && list.Count == 1)
            //        {
            //            if (date < list[0])
            //                date = list[0];
            //        }
            //        list =
            //            session.CreateQuery(string.Format(hql3, emplid)).List<DateTime>();
            //        if (list != null && list.Count == 1)
            //        {
            //            if (date < list[0])
            //                date = list[0];
            //        }
            //        return null;
            //    }
            //);
            return date;

        }
        #endregion
    }
}
