using System;
using System.Collections.Generic;
using System.Collections;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Spring.Transaction.Interceptor;

namespace Baumax.Services
{
    [ServiceID("58F50F16-3E32-48b1-A963-EE419608512E")]
    public class EmployeeLongTimeAbsenceService : BaseService<EmployeeLongTimeAbsence>, IEmployeeLongTimeAbsenceService
    {
        IEmployeeService _employeeService;


        public EmployeeService EmployeeService
        {
            get { return (_employeeService as EmployeeService); }
        }
        private IEmployeeLongTimeAbsenceDao tcDao
        {
            get { return (IEmployeeLongTimeAbsenceDao) Dao; }
        }

        protected override bool Validate(EmployeeLongTimeAbsence entity)
        {
            string s =
                @" entity.ID <> :EntityID AND entity.EmployeeID = :EmployeeID AND 
                        ( (:from_date BETWEEN entity.BeginTime AND entity.EndTime) OR
                        (:to_date BETWEEN entity.BeginTime AND entity.EndTime) OR 
                        (entity.BeginTime BETWEEN :from_date AND :to_date) OR
                        (entity.EndTime BETWEEN :from_date AND :to_date))";
            IList list =
                tcDao.FindByNamedParam(s,
                                       new string[] {"EntityID", "EmployeeID", "from_date", "to_date"},
                                       new object[] {entity.ID, entity.EmployeeID, entity.BeginTime, entity.EndTime});
            if ((list != null) && (list.Count > 0))
            {
                if (entity.IsNew)
                {
                    return false;
                }
                else
                {
                    foreach (EmployeeLongTimeAbsence e in list)
                    {
                        if (e.ID != entity.ID)
                        {
                            return false;
                        }
                    }
                }
            }
            return base.Validate(entity);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return tcDao.GetEmployeesHasLongTimeAbsence(storeid, aBegin, aEnd);
        }
        [AccessType(AccessType.Read)]
        public Dictionary<long, EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsenceAsDiction(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return tcDao.GetEmployeesHasLongTimeAbsenceAsDiction(storeid, aBegin, aEnd);
        }

        [AccessType(AccessType.Read)]
        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long[] emplids, DateTime aBegin, DateTime aEnd)
        {
            return tcDao.GetEmployeesHasLongTimeAbsence(emplids, aBegin, aEnd);
        }
        public List<EmployeeLongTimeAbsence> GetEntitiesByEmployee(long emplid)
        {
            return tcDao.GetEmployeesHasLongTimeAbsence(new long[] { emplid }, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax);
        }
        public List<EmployeeLongTimeAbsence> LoadAll(DateTime fromDate)
        {
            return null;
            //return tcDao.FindByNamedParam ("", string[]{""},
        }


    }
}