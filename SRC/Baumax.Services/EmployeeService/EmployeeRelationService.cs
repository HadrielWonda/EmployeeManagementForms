using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Util;
using Baumax.Contract.TimePlanning;
using Baumax.AppServer.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.Services
{
	[ServiceID("8EAA3C3F-7BFA-419e-88F4-547FFD04E4D3")]
	public class EmployeeRelationService : BaseService<EmployeeRelation>, IEmployeeRelationService
	{
		private IEmployeeDao _employeeDao = null;

		public IEmployeeRelationDao RelationDao
		{
			get { return (IEmployeeRelationDao)Dao; }
		}

		[AccessType(AccessType.Read)]
        public List<EmployeeRelation> GetEmployeeRelations(long emplid)
		{
            return RelationDao.GetEmployeeRelations(emplid);
		}

		[AccessType(AccessType.Read | AccessType.Write)]
        public List<EmployeeRelation> InsertDeligationToStore(EmployeeRelation entity)
		{
            DoValidateRelationWithContract(entity);
			Employee employee = _employeeDao.GetEmployeeByID(entity.EmployeeID, DateTime.Today);
            EmployeeRelationManager manager = new EmployeeRelationManager(employee, RelationDao, _employeeDao, ServerEnvironment.EmployeeContractService);
			manager.InsertDeligationToStore(entity);
			manager.Commit();

			return GetEmployeeRelations(entity.EmployeeID);
		}

		[AccessType(AccessType.Read | AccessType.Write)]
        public List<EmployeeRelation> InsertRelation(EmployeeRelation entity)
		{
            DoValidateRelationWithContract(entity);
			Employee employee = _employeeDao.GetEmployeeByID(entity.EmployeeID, DateTime.Today);
            EmployeeRelationManager manager = new EmployeeRelationManager(employee, RelationDao, _employeeDao, ServerEnvironment.EmployeeContractService);
			manager.InsertWorldAssignment(entity);
			manager.Commit();

			return GetEmployeeRelations(entity.EmployeeID);
		}

        public void DoValidateRelationWithContract(EmployeeRelation entity)
        {

            ListEmployeeContracts contracts = new ListEmployeeContracts(ServerEnvironment.EmployeeContractService, entity.EmployeeID);
            UnbreakContract validator = contracts.GetUnbreakContracts();

            if (!validator.CheckRelation(entity))
                throw new ValidationException("ErrorRelationOutsideContractTime", null);

        }

		protected override bool Validate(EmployeeRelation entity)
		{

			return base.Validate(entity);
		}

		[AccessType(AccessType.Read)]
		public List<EmployeeRelation> GetEmployeeRelationsByStore(long storeid, DateTime? aBegin, DateTime? aEnd)
		{
			return RelationDao.GetEmployeeRelationsByStore(storeid, aBegin, aEnd);
		}
        [AccessType(AccessType.Read)]
        public List<EmployeeRelation> GetEmployeeRelationsByStoreAndWorld(long storeid, long worldid, DateTime? aBegin, DateTime? aEnd)
        {
            return RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, worldid, aBegin, aEnd);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeRelation> GetEmployeeRelationsByEmployeeIds(long[] emplIds, DateTime aBegin, DateTime aEnd)
        {
            return RelationDao.GetEmployeeRelationsByEmployeeIds(emplIds, aBegin, aEnd);
        }

        public List<EmployeeRelation> GetEmployeeRelationsByCountryId(long countryid)
        {
            return RelationDao.GetEmployeeRelationByCountryId(countryid);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeRelation> GetEmployeeRelations(long emplid, DateTime aBegin, DateTime aEnd)
        {
            return RelationDao.GetEmployeeRelationsByEmployeeId(emplid, aBegin, aEnd);
        }

        [AccessType(AccessType.Read)]
        public List<EmployeeRelation> LoadAllSorted()
        {
            return RelationDao.LoadAllSorted();
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeRelation> GetEmployeeRelationByMainStore(long storeid, DateTime begin, DateTime end)
        {
            return RelationDao.GetEmployeeRelationByMainStore(storeid, begin, end);
        }
        [Conditional ("DEBUG")]
        public void TestedMethods()
        {//1229 - 509 AUT store

            long countryid = 1003;
            long storeid = 1234;
            long empl1 = 76491;
            long empl2 = 76733;
            DateTime date1 = new DateTime(2007, 12, 31);
            DateTime date2 = new DateTime(2008, 12, 31);

            RelationDao.GetEmployeeRelations(empl1);
            RelationDao.GetEmployeeRelations(storeid, date1, date2);

            RelationDao.GetEmployeeRelationsByStore(storeid, null, null);
            RelationDao.GetEmployeeRelationsByStore(storeid, date1, null);
            RelationDao.GetEmployeeRelationsByStore(storeid, date1, date2);


            RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, 102, null, null);
            RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, 0, null, null);
            RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, 102, date1, null);
            RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, 102, date1, date2);
            RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, 0, date1, null);
            RelationDao.GetEmployeeRelationsByStoreAndWorld(storeid, 0, date1, date2);

            RelationDao.GetEmployeeRelationByMainStore(storeid, date1, date2);

            RelationDao.GetEmployeeRelationsByEmployeeIds(new long[] { empl1, empl2 }, date1, date2);
            RelationDao.GetEmployeeRelationsByEmployeeIds(new long[] { empl1, empl2 });
            RelationDao.GetEmployeeRelationsByEmployeeId(empl1, date1, date1);
            RelationDao.GetEmployeeRelationByCountryId(countryid);


            RelationDao.LoadAllSorted();

        }

	}

    
}