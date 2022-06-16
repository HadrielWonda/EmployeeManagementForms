using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Contract;
using Spring.Context;
using Baumax.Services._HelperObjects;
using Spring.Transaction.Interceptor;
using Baumax.Contract.Exceptions.EntityExceptions;
using System.Diagnostics;

namespace Baumax.Services
{
    [ServiceID("8287B74B-1B8C-4e07-A0D7-93E791559DBA")]
    public class EmployeeAllInService: BaseService<EmployeeAllIn>, IEmployeeAllInService
    {
        IEmployeeService _employeeService = null;

        //private EmployeeService EmployeeService
        //{
        //    get
        //    {
        //        IApplicationContext ctx = Spring.Context.Support.ContextRegistry.GetContext();

        //        return ctx["employeeService"] as EmployeeService;
        //    }
        //}
        public IEmployeeAllInDao AllInDao
        {
            get { return (IEmployeeAllInDao)_dao; }
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeAllIn> GetEntitiesByEmployee(long emplid, DateTime? aBegin, DateTime? aEnd)
        {
            return AllInDao.GetEntitiesByEmployee(emplid, aBegin, aEnd);
        }

        public List<EmployeeAllIn> GetEntitiesByEmployees(long[] emplids, DateTime? aBegin, DateTime? aEnd)
        {
            return AllInDao.GetEntitiesByEmployees(emplids, aBegin, aEnd);
        }

        [AccessType(AccessType.Read)]
        public List<EmployeeAllIn> GetEntitiesByStoreAndRelation(long storeid, DateTime? aBegin, DateTime? aEnd)
        {
            return AllInDao.GetEntitiesByStoreAndRelation(storeid, aBegin, aEnd);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeAllIn> GetEntitiesByStore(long storeid, DateTime? aBegin, DateTime? aEnd)
        {
            return AllInDao.GetEntitiesByStore(storeid, aBegin, aEnd);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeAllIn> GetEntitiesByCountry(long countryid, DateTime? aBegin, DateTime? aEnd)
        {
            return AllInDao.GetEntitiesByCountry(countryid, aBegin, aEnd);
        }
        [AccessType(AccessType.Write)]
        [Transaction]
        public void InsertAllIn(long emplid, DateTime date, bool bAllIn)
        {

            // align date to monday. Main rule: monday must be in future or Today => date >= Today
            if (date < DateTime.Today)
                throw new ValidationException("ErrorChangingAllInInPast", null);

            DateTime fromDate = date;
            if (fromDate.DayOfWeek != DayOfWeek.Monday)
                fromDate = DateTimeHelper.GetMonday(fromDate);

            if (fromDate < DateTime.Today)
                fromDate = fromDate.AddDays(7);

            Debug.Assert(fromDate.DayOfWeek == DayOfWeek.Monday);

            Employee empl = _employeeService.FindById(emplid);
            if (empl == null)
                return;

            Debug.WriteLine("Begin insert/update allin flag from - " + fromDate.ToShortDateString ());

            ListEmployeeAllIn manager = new ListEmployeeAllIn(emplid);

            if (manager.Insert(fromDate, bAllIn))
            {
                EmployeeBusinessObject bzEmployee = new EmployeeBusinessObject(empl, fromDate);
                bzEmployee.UpdateAllInFlag(fromDate);
            }
        }

        [Conditional ("DEBUG")]
        public void TestedMethods()
        {
            List<EmployeeAllIn> empls = AllInDao.GetEntitiesByEmployee(20100, null, null);
            Debug.Write(empls.Count.ToString());
            AllInDao.GetAllEntitiesSorted();
            AllInDao.GetEntitiesByCountry(1003, null, null);
            AllInDao.GetEntitiesByCountry(1003, new DateTime(2007,1,1), null);
            AllInDao.GetEntitiesByCountry(1003, new DateTime(2007, 1, 1), new DateTime(2008, 1, 1));

            AllInDao.GetEntitiesByStore(1229, null, null);
            AllInDao.GetEntitiesByStore(1229, new DateTime(2007, 1, 1), null);
            AllInDao.GetEntitiesByStore(1229, new DateTime(2007, 1, 1), new DateTime(2008, 1, 1));

            AllInDao.GetEntitiesByStoreAndRelation(1229, null, null);
            AllInDao.GetEntitiesByStoreAndRelation(1229, new DateTime(2007, 1, 1), null);
            AllInDao.GetEntitiesByStoreAndRelation(1229, new DateTime(2007, 1, 1), new DateTime(2008, 1, 1));
        }
    }
}
