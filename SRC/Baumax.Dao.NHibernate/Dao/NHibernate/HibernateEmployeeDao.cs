using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Data;
using Baumax.AppServer.Environment;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using System.Data.SqlClient;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using System.Globalization;
using Baumax.Util;
using Rsdn.Framework.Data.Mapping;
using NHibernate;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeDao : HibernateDao<Employee>, IEmployeeDao
    {
        #region Private Fields

        private IEmployeeContractDao _EmployeeContractDao;
        private IEmployeeRelationDao _EmployeeRelationDao;
        private IEmployeeLongTimeAbsenceDao _EmployeeLongTimeAbsenceDao;
        private IEmployeeHolidaysInfoDao _EmployeeHolidaysInfoDao;
        private IEmployeeAllInDao _EmployeeAllInDao;

        #endregion

        #region Private Methods

        private long insertEmployeeContract(Employee employee)
        {
            EmployeeContract ec = new EmployeeContract();
            ec.EmployeeID = employee.ID;
            ec.ContractBegin = employee.ContractBegin;
            ec.ContractEnd = employee.ContractEnd;
            ec.ContractWorkingHours = employee.ContractWorkingHours;
            _EmployeeContractDao.Save(ec);
            return ec.ID;
        }

        private long insertEmployeeRelations(Employee employee)
        {
            long id =
                insertEmployeeRelations(employee.ID, employee.MainStoreID, employee.WorldID, null,
                                        employee.ContractBegin, employee.ContractEnd);
            getEmployeeLastAssignRelations(employee);
            return id;
        }

        private long insertEmployeeRelations(long employeeID, long storeID, long? worldID, long? hwgr_ID,
                                             DateTime beginTime, DateTime endDate)
        {
            if (CheckEmployeeTimeRange(employeeID, beginTime, endDate))
            {
                EmployeeRelation er = new EmployeeRelation();
                er.EmployeeID = employeeID;
                er.StoreID = storeID;
                er.WorldID = worldID;
                er.HWGR_ID = hwgr_ID;
                er.BeginTime = beginTime;
                er.EndTime = endDate;
                _EmployeeRelationDao.Save(er);
                return er.ID;
            }
            else
            {
                throw new ValidationException();
            }
        }

        private bool CheckEmployeeTimeRange(long employeeid, DateTime beginTime, DateTime endTime)
        {
            string hql =
                @"entity.EmployeeID=:emplid AND 
                        ( (:from_date BETWEEN entity.BeginTime AND entity.EndTime) OR
                        (:to_date BETWEEN entity.BeginTime AND entity.EndTime) OR 
                        (entity.BeginTime BETWEEN :from_date AND :to_date) OR
                        (entity.EndTime BETWEEN :from_date AND :to_date))";
            string[] fields = new string[] {"emplid", "from_date", "to_date"};
            object[] values = new object[] {employeeid, beginTime, endTime};
            IList lst = _EmployeeRelationDao.FindByNamedParam(hql, fields, values);

            if (lst != null && lst.Count > 0)
            {
                return false;
            }
            return true;
        }

        private void updateEmployeeContract(Employee employee)
        {
            EmployeeContract ec = _EmployeeContractDao.FindById(employee.EmployeeContractID);
            if (ec == null)
            {
                ec = new EmployeeContract();
            }
            ec.EmployeeID = employee.ID;
            ec.ContractBegin = employee.ContractBegin;
            ec.ContractEnd = employee.ContractEnd;
            ec.ContractWorkingHours = employee.ContractWorkingHours;
            if (!ec.IsNew)
            {
                _EmployeeContractDao.Update(ec);
            }
            else
            {
                _EmployeeContractDao.Save(ec);
            }
        }

        private void updateEmployeeRelations(Employee employee, Employee prevEmployee, DateTime previousContractBegin,
                                             DateTime previousContractEnd, EmployeeRelationManager relationManager)
        {
            // Contract begin
            if (previousContractBegin < employee.ContractBegin)
            {
                relationManager.DeleteForPeriod(previousContractBegin, employee.ContractBegin.AddDays(-1));

                // acpro #122269
                EmployeeRelation newRelation = new EmployeeRelation();
                newRelation.EmployeeID = employee.ID;
                newRelation.StoreID = employee.MainStoreID;
                newRelation.WorldID = employee.WorldID;
                newRelation.HWGR_ID = null;
                newRelation.BeginTime = employee.ContractBegin;
                newRelation.EndTime = employee.ContractEnd;

                relationManager.UpdateAssignment(newRelation);
            }
            else if (previousContractBegin > employee.ContractBegin)
            {
                /*
                EmployeeRelation newRelation = new EmployeeRelation();
                newRelation.EmployeeID = employee.ID;
                newRelation.StoreID = employee.MainStoreID;
                newRelation.WorldID = employee.WorldID;
                newRelation.HWGR_ID = null;
                newRelation.BeginTime = employee.ContractBegin;
                newRelation.EndTime = previousContractBegin.AddDays(-1);

                relationManager.InsertWorldAssignment(newRelation);
                 * */

                // acpro #122269
                EmployeeRelation newRelation = new EmployeeRelation();
                newRelation.EmployeeID = employee.ID;
                newRelation.StoreID = employee.MainStoreID;
                newRelation.WorldID = employee.WorldID;
                newRelation.HWGR_ID = null;
                newRelation.BeginTime = employee.ContractBegin;
                newRelation.EndTime = employee.ContractEnd;

                relationManager.UpdateAssignment(newRelation);
            }
            // Contract end
            if (previousContractEnd > employee.ContractEnd)
            {
                relationManager.DeleteForPeriod(employee.ContractEnd.AddDays(1), previousContractEnd);

                // acpro #122269
                EmployeeRelation newRelation = new EmployeeRelation();
                newRelation.EmployeeID = employee.ID;
                newRelation.StoreID = employee.MainStoreID;
                newRelation.WorldID = employee.WorldID;
                newRelation.HWGR_ID = null;
                newRelation.BeginTime = employee.ContractBegin;
                newRelation.EndTime = employee.ContractEnd;

                relationManager.UpdateAssignment(newRelation);
            }
            else if (previousContractEnd < employee.ContractEnd)
            {
                /*
                EmployeeRelation newRelation = new EmployeeRelation();
                newRelation.EmployeeID = employee.ID;
                newRelation.StoreID = employee.MainStoreID;
                newRelation.WorldID = employee.WorldID;
                newRelation.HWGR_ID = null;
                newRelation.BeginTime = previousContractEnd.AddDays(1);
                newRelation.EndTime = employee.ContractEnd;

                relationManager.InsertWorldAssignment(newRelation);
                 * */

                // acpro #122269
                EmployeeRelation newRelation = new EmployeeRelation();
                newRelation.EmployeeID = employee.ID;
                newRelation.StoreID = employee.MainStoreID;
                newRelation.WorldID = employee.WorldID;
                newRelation.HWGR_ID = null;
                newRelation.BeginTime = employee.ContractBegin;
                newRelation.EndTime = employee.ContractEnd;

                relationManager.UpdateAssignment(newRelation);
            }

            // acpro #122269
            if ((previousContractBegin == employee.ContractBegin) && (previousContractEnd == employee.ContractEnd))
            {
                // acpro #119084 comment 9 item (6)
                // don't try to save if nothing was changed in the relations
                if (
                    (employee.MainStoreID != prevEmployee.MainStoreID)
                    || (employee.WorldID != prevEmployee.WorldID)
                    || (employee.HWGR_ID != prevEmployee.HWGR_ID)
                    || (employee.BeginTime != prevEmployee.BeginTime)
                    || (employee.EndTime != prevEmployee.EndTime)
                    )
                {
                    EmployeeRelation newRelation = new EmployeeRelation();
                    newRelation.EmployeeID = employee.ID;
                    newRelation.StoreID = employee.MainStoreID;
                    newRelation.WorldID = employee.WorldID;
                    newRelation.HWGR_ID = null;
                    newRelation.BeginTime = employee.ContractBegin;
                    newRelation.EndTime = employee.ContractEnd;

                    relationManager.UpdateAssignment(newRelation);
                }
            }

            relationManager.Commit();
            //
            getEmployeeLastAssignRelations(employee);
        }

        private void copyMappingData(Employee source, Employee dest)
        {
            dest.PersID = source.PersID;
            dest.PersNumber = source.PersNumber;
            dest.LastName = source.LastName;
            dest.FirstName = source.FirstName;
            dest.Import = source.Import;
            dest.MainStoreID = source.MainStoreID;
            dest.OldHolidays = source.OldHolidays;
            dest.NewHolidays = source.NewHolidays;
            dest.BalanceHours = source.BalanceHours;
            dest.CreateDate = source.CreateDate;
            dest.AvailableHolidays = dest.AvailableHolidays;
            dest.OrderHwgrID = source.OrderHwgrID;
        }

        private void copyNotMappingData(Employee source, Employee dest)
        {
            dest.LongTimeAbsenceExist = source.LongTimeAbsenceExist;
            dest.EmployeeRelationsID = source.EmployeeRelationsID;
            dest.EmployeeContractID = source.EmployeeContractID;
            dest.ContractWorkingHours = source.ContractWorkingHours;
            dest.ContractBegin = source.ContractBegin;
            dest.ContractEnd = source.ContractEnd;
            dest.StoreID = source.StoreID;
            dest.HWGR_ID = source.HWGR_ID;
            dest.WorldID = source.WorldID;
            dest.SpareHolidaysInc = source.SpareHolidaysInc;
            dest.SpareHolidaysExc = source.SpareHolidaysExc;
            dest.UsedHolidays = source.UsedHolidays;
        }

        private void setContractTime(Employee employee)
        {
            employee.ContractBegin = DateTimeSql.GetBegin(employee.ContractBegin);
            employee.ContractEnd = DateTimeSql.GetEnd(employee.ContractEnd);
        }

        #endregion

        #region Public Methods

        public EmployeeShortView[] GetEmployeesNames(long storeid)
        {
            StringBuilder hql =
                new StringBuilder(
                    @"SELECT entity.ID, entity.FirstName,entity.LastName FROM 
                            Employee entity WHERE entity.MainStoreID=:mid");
            
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("mid");
            pValues.Add(storeid);

            IList res = HibernateTemplate.FindByNamedParam(hql.ToString(), pNames.ToArray(), pValues.ToArray());

            EmployeeShortView[] resArray = null;
            if (res != null)
            {
                resArray = new EmployeeShortView[res.Count];

                for (int i = 0; i < res.Count; i++)
                {
                    object[] items = (object[]) res[i];
                    resArray[i] = new EmployeeShortView((long) items[0], items[1].ToString(), items[2].ToString());
                }
            }

            return resArray;
        }

        public ImportEmployeeResult ImportEmployee(List<ImportEmployeeData> list)
        {
            ImportEmployeeResult result = new ImportEmployeeResult();
            List<EmployeeChanged> changedEmployeeList = new List<EmployeeChanged>();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
                    @" 
create table #empl4insert
(
	Store_SystemID int,
	HWGR_SystemID int,
	World_SystemID int,
	PersNumber int,
	FirstName nvarchar (50),
	LastName nvarchar (50),
	PersID nvarchar (25),-- collate SQL_Latin1_General_CP1_CI_AS,
	ContractBegin smalldatetime,
	ContractEnd smalldatetime,
	StoreID bigint,
	WorldID bigint,
	HWGR_ID bigint,
    ContractWorkingHours decimal (5,2),
    AvailableHolidays decimal (7,2),
    BalanceHours decimal (8,2),
	[exists] bit,
	ContractChange smallint NOT NULL DEFAULT ((0)),
    EmployeeID bigint,
    Department nvarchar (50),
	AllIn bit NOT NULL DEFAULT ((0)),
	AllInChange smallint NOT NULL DEFAULT ((0)),
    BalanceHoursChange smallint NOT NULL DEFAULT ((0))  
)
";
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                    foreach (ImportEmployeeData value in list)
                    {
                        query =
                            @"insert into #empl4insert (Store_SystemID, HWGR_SystemID, World_SystemID, FirstName, LastName, PersID, ContractBegin, ContractEnd, ContractWorkingHours, AvailableHolidays, BalanceHours, PersNumber, Department, AllIn) 
									values({0},{1},{2},N'{3}',N'{4}',N'{5}','{6}','{7}',{8},{9},{10},{11},N'{12}',{13})";
                        command.CommandText = string.Format(query,
                                                            value.Store_SystemID, //0
                                                            value.HWGR_SystemID, //1
                                                            value.World_SystemID, //2
                                                            value.FirstName, //3
                                                            value.LastName, //4
                                                            value.PersID, //5 
                                                            value.ContractBegin.ToString("yyyyMMdd"),
                                                            value.ContractEnd.ToString("yyyyMMdd"),
                                                            value.ContractWorkingHours.ToString("F3",
                                                                                                CultureInfo.
                                                                                                    InvariantCulture),
                                                            value.AvailableHolidays.ToString("F3",
                                                                                             CultureInfo.
                                                                                                 InvariantCulture),
                                                            value.BalanceHours.ToString("F3",
                                                                                        CultureInfo.InvariantCulture),
                                                            value.PersNumber, value.Department, value.AllIn);
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "spEmployee_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        //get employee with errors
                        list.Clear();
                        while (reader.Read())
                        {
                            ImportEmployeeData value = new ImportEmployeeData();
                            value.PersID = reader.GetString(0);
                            value.ImportError = (EmployeeImportError) reader.GetInt32(1);
                            list.Add(value);
                        }

                        //get employee with changed contract and "all in" data
                        reader.NextResult();
                        while (reader.Read())
                        {
                            EmployeeChanged employeeChanged = new EmployeeChanged();
                            employeeChanged.EmployeeID = reader.GetInt64(0);
                            employeeChanged.Contract = (Changed)reader.GetInt16(1);
                            employeeChanged.BalanceHours = (Changed)reader.GetInt16(2);
                            employeeChanged.AllIn = (Changed)reader.GetInt16(3);
                            changedEmployeeList.Add(employeeChanged);
                        }

                        //get import result
                        reader.NextResult();
                        result.Success = ((int) importResult.Value > 0);
                    }
                    result.DataChanged = changedEmployeeList.ToArray();
                    result.DataError = list;
                }
            }
            OnDaoInvalidateWholeCache();
            return result;
        }


        /*
        public IList GetEmployeeList2(long storeID, DateTime date)
        {
            List<Employee> employeeList = new List<Employee>();
            string query = "exec spEmlpoyeeDetailGet {0}, '{1}'";
            query = string.Format(query, storeID, DateTimeSql.DateToSqlString(date));
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                        {
                            employee.PersID = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            employee.LastName = reader.GetString(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            employee.FirstName = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            employee.ContractBegin = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            employee.ContractEnd = reader.GetDateTime(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            employee.Import = reader.GetBoolean(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            employee.MainStoreID = reader.GetInt64(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            employee.ContractWorkingHours = reader.GetDecimal(8);
                        }
                        if (!reader.IsDBNull(9))
                        {
                            employee.OldHolidays = reader.GetDecimal(9);
                        }
                        if (!reader.IsDBNull(10))
                        {
                            employee.NewHolidays = reader.GetDecimal(10);
                        }
                        if (!reader.IsDBNull(11))
                        {
                            employee.BalanceHours = reader.GetDecimal(11);
                        }
                        if (!reader.IsDBNull(12))
                        {
                            employee.CreateDate = reader.GetDateTime(12);
                        }
                        if (!reader.IsDBNull(13))
                        {
                            employee.EmployeeContractID = reader.GetInt64(13);
                        }
                        if (!reader.IsDBNull(14))
                        {
                            employee.EmployeeRelationsID = reader.GetInt64(14);
                        }
                        if (!reader.IsDBNull(15))
                        {
                            employee.StoreID = reader.GetInt64(15);
                        }
                        if (!reader.IsDBNull(16))
                        {
                            employee.WorldID = reader.GetInt64(16);
                        }
                        if (!reader.IsDBNull(17))
                        {
                            employee.HWGR_ID = reader.GetInt64(17);
                        }
                        if (!reader.IsDBNull(18))
                        {
                            employee.LongTimeAbsenceExist = (1 == reader.GetInt32(18));
                        }
                        employeeList.Add(employee);
                    }
                }
            }
            return employeeList;
        }
        */
        public IList GetEmployeeList(long storeID, DateTime date)
        {
            //using (DbManager db = new DbManager()) 
            //    employeeList= db.SetSpCommand("spEmlpoyeeDetailGet", storeID, date).ExecuteList<Employee>();
            List<Employee> employeeList;
            string query =
                string.Format("exec spEmlpoyeeDetailGet {0}, '{1}'", storeID, DateTimeSql.DateToSqlString(date));
            using (IDataReader reader = getDataReader(query))
            {
                employeeList = Map.ToList<Employee>(reader);
            }
            return employeeList;
        }

        protected override void DoDeleteEntities(IEnumerable<long> idlist)
        {
            foreach (long id in idlist)
            {
                _EmployeeHolidaysInfoDao.DeleteAllForEmployee(id);
            }
            base.DoDeleteEntities(idlist);
        }

        //protected override Employee DoSaveEntity(Employee daoObj)
        //{
        //    Employee result = base.DoSaveEntity(daoObj);
        //    _EmployeeHolidaysInfoDao.SaveOrUpdateForEmployee(daoObj, DateTime.Today.Year);
        //    return result;
        //}

        //public override Employee Save(Employee daoObj)
        //{
        //    setContractTime(daoObj);
        //    Employee employee = base.Save(daoObj);
        //    copyNotMappingData(daoObj, employee);
        //    employee.EmployeeContractID = insertEmployeeContract(employee);
        //    employee.EmployeeRelationsID = insertEmployeeRelations(employee);

        //    return employee;
        //}

        //public override Employee SaveOrUpdate(Employee daoObj)
        //{
        //    if (daoObj.IsNew)
        //    {
        //        return Save(daoObj);
        //    }

        //    // acpro #119084 comment 9 item (6)
        //    Employee prevEmployee = FindById(daoObj.ID);
        //    // it MUST be not null since it's not new
        //    Debug.Assert(prevEmployee != null);

        //    setContractTime(daoObj);
        //    // FIX: When contract time is shortened, check whethere there's no time planning defined for the period with stays outside contract time
        //    // Else, update should fail
        //    EmployeeContract previousContract = _EmployeeContractDao.FindById(daoObj.EmployeeContractID);
        //    DateTime previousContractBegin = previousContract.ContractBegin,
        //             previousContractEnd = previousContract.ContractEnd;

        //    EmployeeRelationManager relationManager = new EmployeeRelationManager(daoObj, _EmployeeRelationDao, this, ServerEnvironment.EmployeeContractService);

        //    Employee employee = base.SaveOrUpdate(daoObj);
        //    copyNotMappingData(daoObj, employee);

        //    updateEmployeeContract(employee);
        //    updateEmployeeRelations(employee, prevEmployee, previousContractBegin, previousContractEnd, relationManager);

        //    return employee;
        //}

        //public override Employee Update(Employee daoObj)
        //{
        //    setContractTime(daoObj);
        //    Employee employee = FindById(daoObj.ID);
        //    copyMappingData(daoObj, employee);
        //    base.Update(employee);
        //    copyNotMappingData(daoObj, employee);
        //    updateEmployeeContract(employee);
        //    return employee;
        //}



        // obsolete
        public Employee UpdateHolidays(long employeeID, decimal OldHolidays, decimal NewHolidays)
        {
            Employee entity = FindById(employeeID);

            if (entity == null)
            {
                return null;
            }
            // for Austria - read-only
            long countryid = ServerEnvironment.StoreService.GetCountryByStoreId(entity.MainStoreID);
            if (countryid == ServerEnvironment.CountryService.AustriaCountryID) return null;
 
            entity.OldHolidays = OldHolidays;
            entity.NewHolidays = NewHolidays;
            Employee result = base.Update(entity);

            _EmployeeHolidaysInfoDao.SaveOrUpdateForEmployee(entity, DateTime.Today.Year);
            return result;
        }
        // obsolete
        public Employee UpdateSaldo(long employeeID, decimal saldo)
        {
            Employee entity = FindById(employeeID);
            if (entity == null)
            {
                return null;
            }
            entity.BalanceHours = saldo;

            Employee result = base.Update(entity);

            return result;
        }

        private Employee getEmployeeLastAssignRelations(Employee employee)
        {
            /*string query = @"
                            select top 1 Employee_RelationsID, StoreID, WorldID, HWGR_ID from dbo.Employee_Relations
                            where
                            EmployeeID = {0} and '{1}' between BeginTime and EndTime
                            order by BeginTime desc
                            ";
            */
            string query =
                @"
                            select rel.* from Employee_Relations rel
                            where
                            EmployeeID = {0} and '{1}' between BeginTime and EndTime
                            order by BeginTime desc
                            ";
            query = String.Format(query, employee.ID, DateTimeSql.DateToSqlString(DateTime.Today));

            IList lst = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                          {
                                                              return
                                                                  session.CreateSQLQuery(query)
                                                                      .AddEntity("rel", typeof (EmployeeRelation))
                                                                      .List();
                                                          }
                                    );

            if (lst != null && lst.Count > 0)
            {
                EmployeeRelation rel = (EmployeeRelation) lst[0];
                employee.EmployeeRelationsID = rel.ID;
                employee.WorldID = rel.WorldID;
                employee.StoreID = rel.StoreID;
                employee.HWGR_ID = rel.HWGR_ID;
                employee.BeginTime = rel.BeginTime;
                employee.EndTime = rel.EndTime;
            }
            
            return employee;
        }

        public Employee Assign(Employee employee, long storeID, long? worldID, long? hwgrID, DateTime beginTime,
                               DateTime endDate)
        {
            insertEmployeeRelations(employee.ID, storeID, worldID, hwgrID, beginTime, endDate);
            return getEmployeeLastAssignRelations(employee);
        }

        public void AssignHwgr(long employeeId, long? hwgrID)
        {
            Employee emp = FindById(employeeId);
            emp.OrderHwgrID = hwgrID;
            base.Update(emp);
        }

        public void Merge(long employeeIDInternal, long employeeIDExternal)
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandTimeout = 60*3;
                command.CommandText = "spEmployeeMerge";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idInternal = new SqlParameter("@employeeIDInternal", SqlDbType.BigInt, 8);
                idInternal.Value = employeeIDInternal;
                command.Parameters.Add(idInternal);

                SqlParameter idExternal = new SqlParameter("@employeeIDExternal", SqlDbType.BigInt, 8);
                idExternal.Value = employeeIDExternal;
                command.Parameters.Add(idExternal);

                SqlParameter mergeResult = new SqlParameter("@result", SqlDbType.Int, 4);
                mergeResult.Direction = ParameterDirection.Output;
                command.Parameters.Add(mergeResult);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new EmployeeMergeException(ex);
                }
                switch ((int) mergeResult.Value)
                {
                    case 1:
                        break;
                    case -1:
                        throw new EmployeeMergeException(EmployeeMergeError.CantMerge);
                    case -2:
                        throw new EmployeeMergeException(EmployeeMergeError.UnknownInternalEmployee);
                    case -3:
                        throw new EmployeeMergeException(EmployeeMergeError.UnknownExternalEmployee);
                    case -4:
                        throw new EmployeeMergeException(EmployeeMergeError.NotSameNames);
                    default:
                        throw new EmployeeMergeException(EmployeeMergeError.UnknownError);
                }
            }
            OnDaoEntitiesChanged(new long[] {employeeIDInternal, employeeIDExternal});
        }

        public Employee GetEmployeeByID(long employeeID, DateTime date)
        {
            Employee employee = null;
            //using (DbManager db = new DbManager())
            //    employee = db.SetSpCommand("spEmlpoyeeDetailGetByEmpID", employeeID, date).ExecuteObject<Employee>();
            string query =
                string.Format("exec spEmlpoyeeDetailGetByEmpID {0}, '{1}'", employeeID,
                              DateTimeSql.DateToSqlString(date));
            using (IDataReader reader = getDataReader(query))
            {
                List<Employee> list = Map.ToList<Employee>(reader);
                if (list.Count > 0)
                {
                    employee = list[0];
                }
            }
            return employee;
        }

        public IList GetPlanningEmployees(long storeid, DateTime aBegin, DateTime aEnd)
        {
            string sQuery =
                @"
                            select distinct empl.* from Employee empl, Employee_Relations rel WHERE 
                            rel.StoreID=:sid AND 
                            rel.EmployeeID = empl.EmployeeID AND 
                            NOT(rel.BeginTime>:etime OR rel.EndTime<:stime)
                            ";
            IList lst = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                          {
                                                              return session.CreateSQLQuery(sQuery)
                                                                  .AddEntity("empl", typeof (Employee))
                                                                  .SetInt64("sid", storeid)
                                                                  .SetDateTime("etime", aEnd)
                                                                  .SetDateTime("stime", aBegin)
                                                                  .List();
                                                          }
                                    );

            return lst;
        }

        public IList GetPlanningEmployeesByWorld(long storeid, long worldid, DateTime aBegin, DateTime aEnd)
        {
            string sQuery =
                @"
                            select distinct empl.* from Employee empl, Employee_Relations rel WHERE 
                            rel.StoreID=:sid AND 
                            rel.EmployeeID = empl.EmployeeID AND 
                            rel.WorldID = :wid AND
                            NOT(rel.BeginTime>:etime OR rel.EndTime<:stime)
                            ";

            if (worldid <= 0)
            {
                sQuery =
                    @"
                            select distinct empl.* from Employee empl, Employee_Relations rel WHERE 
                            rel.StoreID=:sid AND 
                            rel.EmployeeID = empl.EmployeeID AND 
                            NOT(rel.BeginTime>:etime OR rel.EndTime<:stime)
                            ";
            }

            IList lst = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                          {
                                                              ISQLQuery query =
                                                                  session.CreateSQLQuery(sQuery).AddEntity("empl",
                                                                                                           typeof (
                                                                                                               Employee));

                                                              query.SetInt64("sid", storeid);

                                                              if (worldid > 0)
                                                              {
                                                                  query.SetInt64("wid", worldid);
                                                              }

                                                              query.SetDateTime("etime", aEnd);
                                                              query.SetDateTime("stime", aBegin);

                                                              return query.List();
                                                          }
                                    );

            return lst;
        }


        /*  Algoritm
         * Select all  employee relation for this store
         * select all employee for store
         * select all empl long-time absence for this time-range
         * select external empl if exists (storeid != MainStoreID)
         * 
         */
        // obsolete
        public TimePlanningResult GetTimePlannignEmployee(long storeid, DateTime aBegin, DateTime aEnd)
        {
            // list of all employee for storeid
            IList employees = GetPlanningEmployees(storeid, aBegin, aEnd);

            if (employees == null || employees.Count == 0)
            {
                return null;
            }

            IList l = _EmployeeRelationDao.GetEmployeeRelations(storeid, aBegin, aEnd);
            List<EmployeeRelation> emplRelations = new List<EmployeeRelation>();
            if (l != null)
            {
                foreach (EmployeeRelation rel in l)
                {
                    emplRelations.Add(rel);
                }
            }


            List<EmployeeLongTimeAbsence> emplLongTimeAbsences =
                _EmployeeLongTimeAbsenceDao.GetEmployeesHasLongTimeAbsence(storeid, aBegin, aEnd);

            List<Employee> resultList = new List<Employee>(employees.Count);

            Dictionary<long, EmployeeLongTimeAbsence> diction =
                EmployeeLongTimeAbsenceProcessor.GetEmployeeHasAbsences(emplLongTimeAbsences, aBegin, aEnd);

            foreach (Employee empl in employees)
            {
                if (diction.ContainsKey(empl.ID))
                {
                    for (int i = emplRelations.Count - 1; i >= 0; i--)
                    {
                        if (emplRelations[i].EmployeeID == empl.ID)
                        {
                            emplRelations.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    resultList.Add(empl);
                }
            }

            emplLongTimeAbsences =
                EmployeeLongTimeAbsenceProcessor.GetEmployeesIntersectTimeRange(emplLongTimeAbsences, aBegin, aEnd);


            return new TimePlanningResult(resultList, emplRelations, emplLongTimeAbsences, null);
        }



        //public bool HasWorkingOrAbsenceTime2(long employeeID, DateTime beginTime, DateTime endTime)
        //{
        //    string query =
        //        string.Format("exec spEmlpoyeeHasWorkingAbsenceTime {0}, '{1}', '{2}'", employeeID,
        //                      DateTimeSql.DateToSqlString(beginTime), DateTimeSql.DateToSqlString(endTime));

        //    bool result = (bool) HibernateTemplate.Execute(delegate(ISession session)
        //                                                   {
        //                                                       return session.CreateSQLQuery(query)
        //                                                           .AddScalar("result", NHibernateUtil.Boolean)
        //                                                           .UniqueResult<bool>();
        //                                                   }
        //                             );
        //    return result;
        //}
        public bool HasWorkingOrAbsenceTime(long employeeID, DateTime beginTime, DateTime endTime)
        {
            string hql = @"select entity.id from {0} entity where entity.EmployeeID=:emplid and
                            entity.Date between :begin_date and :end_date";

            string query = string.Format(hql, "EmployeeDayStatePlanning");

            IList list = HibernateTemplate.FindByNamedParam(query, new string[] { "emplid", "begin_date", "end_date" },
                new object[] {employeeID, beginTime, endTime });

            if (list == null || list.Count == 0)
            {
                query = string.Format(hql, "EmployeeDayStateRecording");

                list = HibernateTemplate.FindByNamedParam(query, new string[] { "emplid", "begin_date", "end_date" },
                    new object[] { employeeID, beginTime, endTime });
            }

            return (list != null && list.Count > 0);

        }
        public bool HasWorkingOrAbsenceTimeEx(long employeeID, DateTime beginTime, DateTime endTime)
        {


            bool res = HasWorkingOrAbsenceTime(employeeID, beginTime, endTime);

            if (!res)
            {
                IList  list = HibernateTemplate.Find("select entity from AbsenceTimePlanning where entity.EmployeeID= ? AND entity.Date BETWEEN ? AND ? ", new object[] { employeeID, beginTime, endTime, },
                        new global::NHibernate.Type.IType[] { NHibernateUtil.Int64, NHibernateUtil.DateTime, NHibernateUtil.DateTime });

                res = (list != null && list.Count > 0);

            }

            return res;

        }
        public long[][] GetEmployeeToMergeList()
        {
            IList list = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                           {
                                                               return
                                                                   session.CreateSQLQuery(
                                                                       "exec spEmployeeToMergeList")
                                                                       .AddScalar("EmployeeID", NHibernateUtil.Int64)
                                                                       .AddScalar("MainStoreID", NHibernateUtil.Int64)
                                                                       .List();
                                                           }
                                     );

            long[][] result = new long[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                IList array = (IList) list[i];
                result[i] = new long[array.Count];
                array.CopyTo(result[i], 0);
            }
            return result;
        }

        private struct ResEmployeeToMerge
        {
            public long EmployeeID;
            public long MainStoreID;
        }



        private List<string> GetIdsAsStrings(long[] ids)
        {
            int count_size = 100;
            List<string> result = new List<string>();

            StringBuilder sb = new StringBuilder(1000);
            
            for (int i = 0; i < ids.Length; i++)
            {

                if (sb.Length != 0) sb.Append(",");
                sb.Append(ids[i]);


                if (((i+1) % count_size == 0) || (i + 1 == ids.Length))
                {
                    if (sb.Length > 0)
                    {
                        result.Add(sb.ToString());
                    }
                    sb.Length = 0;
                }
                
            }
            
            return result;
        }
        public List<Employee> GetEmployeeByIds(long[] ids)
        {
            
            if (ids == null || ids.Length == 0) return null;
            
            List<string> lstIds = GetIdsAsStrings(ids);

            string sQuery = @"SELECT {empl.*} from Employee {empl} WHERE empl.EmployeeID IN ";//({0})";


            
            
                List<Employee> lst = (List<Employee>)HibernateTemplate.Execute(delegate(ISession session)
                                                {
                                                    List<Employee> list = new List<Employee>();

                                                    foreach (string s in lstIds)
                                                    {
                                                        if (!String.IsNullOrEmpty(s))
                                                        {
                                                            //IList l = session.CreateSQLQuery(String.Format(sQuery, s))
                                                            IList l = session.CreateSQLQuery(sQuery + "(" + s + ")")
                                                                .AddEntity("empl", typeof(Employee)).List();
                                                            if (l != null)
                                                            {
                                                                foreach (Employee e in l) list.Add(e);
                                                            }
                                                        }
                                                    }
                                                    return list;
                                                }
                                            );

                
            
            
            return lst;
        }



        /*
         * Load employee which have difference contract end date and relation end date
         * 
         */
        public List<DiffContractRelation> GetDifferenceContractsAndRelations()
        {
            string query = @"
                SELECT contracts.EmployeeID,MAX([ContractEnd])  ContractEnd, MAX(EndTime)  RelationEnd
                  FROM EmployeeContract  contracts, Employee_Relations  relations 
                WHERE contracts.EmployeeID=relations.EmployeeID
                Group By contracts.EmployeeID 
                having MAX([ContractEnd]) <>MAX (EndTime)
                ORDER BY 1
            ";

            List<DiffContractRelation> list = null;
            using (IDataReader reader = GetDataReader(query))
            {

                list = Map.ToList<DiffContractRelation>(reader);
                
            }

            if (list != null)
            {
                Trace.WriteLine("objects count = " + list.Count);
            }
            return list;
        }

        public List<Employee> GetStoreEmployeesHaveContracts(long storeid, DateTime begin, DateTime end)
        {

            begin = DateTimeSql.CheckSmallMinMax(begin);
            end = DateTimeSql.CheckSmallMinMax(end);

            string hql = @"select distinct entity from 
                                              Employee entity, 
                                              EmployeeContract contract 
                                        where 
                                              entity.MainStoreID=:st_id AND
                                              entity.id=contract.EmployeeID AND  
                                              NOT(contract.ContractBegin>:etime OR contract.ContractEnd<:stime)";

            List<Employee> resultList = new List<Employee>(100);
            object o = HibernateTemplate.Execute(delegate(ISession session)
                          {
                              IQuery query = session.CreateQuery(hql);

                              query.SetInt64("st_id", storeid);
                              query.SetDateTime("stime", begin);
                              query.SetDateTime("etime", end);

                              query.List(resultList);

                              return resultList;
                          }
                    );

            return resultList;
        }
        public List<Employee> GetCountryEmployeesHaveContracts(long countryid, DateTime begin, DateTime end)
        {

            begin = DateTimeSql.CheckSmallMinMax(begin);
            end = DateTimeSql.CheckSmallMinMax(end);

            string hql = @"select distinct entity from 
                                              Employee entity, 
                                              EmployeeContract contract,
                                              Store st 
                                        where 
                                              st.CountryID=:ct_id AND
                                              entity.MainStoreID=st.id AND
                                              entity.id=contract.EmployeeID AND  
                                              NOT(contract.ContractBegin>:etime OR contract.ContractEnd<:stime)";

            List<Employee> resultList = new List<Employee>(2000);
            object o = HibernateTemplate.Execute(delegate(ISession session)
                          {
                              IQuery query = session.CreateQuery(hql);

                              query.SetInt64("ct_id", countryid);
                              query.SetDateTime("stime", begin);
                              query.SetDateTime("etime", end);

                              query.List(resultList);

                              return resultList;
                          }
                    );

            return resultList;
        }
        public List<Employee> GetCountryEmployees(long countryid)
        {

            string hql = @"select entity from 
                                              Employee entity, 
                                              Store st 
                                        where 
                                              st.CountryID=:ct_id AND
                                              entity.MainStoreID=st.id";

            List<Employee> resultList = new List<Employee>(2000);
            object o = HibernateTemplate.Execute(delegate(ISession session)
                          {
                              IQuery query = session.CreateQuery(hql);

                              query.SetInt64("ct_id", countryid);
                              query.List(resultList);

                              return resultList;
                          }
                    );

            return resultList;
        }
        #endregion

        #region Export for hungary

        private struct HungaryWTime
        {
            public string PersonalID;
            public int? StoreID;
            public DateTime? Date;
            public string AbsenceTypeID;
            public UtsMinutes? WTimeFrom;
            public UtsMinutes? WTimeTo;
            public int Break;
        }

        private struct HungaryAvailableAbsence
        {
            public int? AbsenceTypeID;
            public string AbsenceCharID;
            public string AbsenceName;
        }

        internal class CSVWriter
        {
            private char _listSeparator;
            private char _decimalPoint;

            public char ListSeparator
            {
                get { return _listSeparator; }
                set { _listSeparator = value; }
            }

            public char DecimalPoint
            {
                get { return _decimalPoint; }
                set { _decimalPoint = value; }
            }

            public CSVWriter()
            {
                _listSeparator = ';';
                _decimalPoint = '.';
            }

            public CSVWriter(char listSeparator, char decimalPoint)
            {
                _listSeparator = listSeparator;
                _decimalPoint = decimalPoint;
            }

            private static string FormatDateTime(DateTime dt)
            {
                return (dt.ToString("yyyyMMdd"));
            }

            private static string FormatUtsMinutes(UtsMinutes utsMinutes)
            {
                return string.Format("{0:D2}{1:D2}", utsMinutes.Hours, utsMinutes.Minutes);
            }

            // TODO: add more types to handle when needed
            public void Write(object[] list, string[] fieldNames, string fileName)
            {
                if ((fileName == null) || (fileName.Length == 0))
                {
                    throw new ArgumentException("filename is not valid", "fileName");
                }
                StringBuilder sb = new StringBuilder(10);
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    if (list != null)
                    {
                        for (int i = 0; i < list.Length; i++)
                        {
                            object o = list[i];
                            if (o != null)
                            {
                                sb.Length = 0;
                                if (fieldNames != null)
                                {
                                    for (int j = 0; j < fieldNames.Length; j++)
                                    {
                                        if (j > 0)
                                        {
                                            sb.Append(_listSeparator);
                                        }
                                        FieldInfo fi =
                                            o.GetType().GetField(fieldNames[j],
                                                                 BindingFlags.NonPublic | BindingFlags.Instance |
                                                                 BindingFlags.Public);
                                        if (fi != null)
                                        {
                                            Type oType = fi.FieldType;
                                            object oVal = fi.GetValue(o);
                                            if (oType == typeof(string))
                                            {
                                                sb.Append((string)oVal);
                                            }
                                            else if (oType == typeof(int))
                                            {
                                                sb.Append((int)oVal);
                                            }
                                            else if (oType == typeof(int?))
                                            {
                                                if (((int?)oVal).HasValue)
                                                {
                                                    sb.Append(((int?)oVal).Value);
                                                }
                                            }
                                            else if (oType == typeof(DateTime))
                                            {
                                                sb.Append(FormatDateTime((DateTime)oVal));
                                            }
                                            else if (oType == typeof(DateTime?))
                                            {
                                                if (((DateTime?)oVal).HasValue)
                                                {
                                                    sb.Append(FormatDateTime(((DateTime?)oVal).Value));
                                                }
                                            }
                                            else if (oType == typeof(UtsMinutes))
                                            {
                                                sb.Append(FormatUtsMinutes((UtsMinutes)oVal));
                                            }
                                            else if (oType == typeof(UtsMinutes?))
                                            {
                                                if (((UtsMinutes?)oVal).HasValue)
                                                {
                                                    sb.Append(FormatUtsMinutes(((UtsMinutes?)oVal).Value));
                                                }
                                            }
                                        }
                                    }
                                }
                                sw.WriteLine(sb.ToString());
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private struct UtsMinutes
        {
            public short SumMinutes;

            public short Hours
            {
                get { return (short) (SumMinutes/60); }
            }

            public short Minutes
            {
                get { return (short) (SumMinutes%60); }
            }

            public UtsMinutes(short sumMinutes)
            {
                SumMinutes = sumMinutes;
            }
        }

        public void ExportHungaryGetWTimes(DateTime? from, DateTime? to)
        {
            // should we intoduce new folder setting?
            DateTime now = DateTime.Now;
            string outFName = string.Format("PEP_HUNGARYworkingtime_{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.txt",
                                            now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            outFName = Path.Combine(ServerEnvironment.ImportSettings.SourceFolder, outFName);

            List<object> timeList = new List<object>();
            string dateFromStr;
            string dateToStr;
            if( (!from.HasValue) || (!to.HasValue) )
            {
                dateToStr = dateFromStr = DateTimeSql.DateToSqlString(now.Date.AddDays(-1));
            }
            else
            {
                dateFromStr = DateTimeSql.DateToSqlString(from.Value);
                dateToStr = DateTimeSql.DateToSqlString(to.Value);
            }
            string query = string.Format(
                "exec sp_rptHungaryGetWTimes @DateFrom='{0}', @DateTo='{1}', @ReportName='{2}'",
                dateFromStr, dateToStr, "HungarianMain");
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        HungaryWTime wTime = new HungaryWTime();
                        if (!reader.IsDBNull(0))
                        {
                            wTime.PersonalID = reader.GetString(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            wTime.StoreID = reader.GetInt32(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            wTime.Date = reader.GetDateTime(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            wTime.AbsenceTypeID = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            wTime.WTimeFrom = new UtsMinutes(reader.GetInt16(4));
                        }
                        if (!reader.IsDBNull(5))
                        {
                            wTime.WTimeTo = new UtsMinutes(reader.GetInt16(5));
                        }

                        short wTimeDiff = 0;
                        if ((wTime.WTimeFrom.HasValue) && (wTime.WTimeTo.HasValue))
                        {
                            wTimeDiff =
                                (short) Math.Abs(wTime.WTimeTo.Value.SumMinutes - wTime.WTimeFrom.Value.SumMinutes);
                        }
                        // fill break field
                        if ((wTime.AbsenceTypeID != null) || (wTimeDiff < 6*60))
                        {
                            wTime.Break = 0;
                        }
                        else if (wTimeDiff < 9*60)
                        {
                            wTime.Break = 30;
                        }
                        else
                        {
                            wTime.Break = 60;
                        }
                        timeList.Add(wTime);
                    }
                }
            }
            CSVWriter csvwriter = new CSVWriter(';', '.');
            csvwriter.Write(timeList.ToArray(),
                            new string[]
                                {"PersonalID", "StoreID", "Date", "AbsenceTypeID", "WTimeFrom", "WTimeTo", "Break"},
                            outFName);
        }

        public void ExportHungaryGetAvailableAbsences()
        {
            // should we intoduce new folder setting?
            DateTime now = DateTime.Now;
            string outFName = string.Format("PEP_HUNGARYavailableabsences_{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}.txt",
                                            now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            outFName = Path.Combine(ServerEnvironment.ImportSettings.SourceFolder, outFName);

            List<object> absenceList = new List<object>();
            string query = string.Format(
                "exec sp_rptHungaryGetAvailableAbsences @ReportName = '{0}'", "HungarianMain");
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    while (reader.Read())
                    {
                        HungaryAvailableAbsence absence = new HungaryAvailableAbsence();
                        if (!reader.IsDBNull(0))
                        {
                            absence.AbsenceTypeID = reader.GetInt32(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            absence.AbsenceCharID = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            absence.AbsenceName = reader.GetString(2);
                        }
                        absenceList.Add(absence);
                    }
                }
            }
            CSVWriter csvwriter = new CSVWriter(';', '.');
            csvwriter.Write(absenceList.ToArray(),
                            new string[] {"AbsenceTypeID", "AbsenceCharID", "AbsenceName"},
                            outFName);
        }

        #endregion
    }
}