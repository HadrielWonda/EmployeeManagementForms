using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects
{
    class CacheListEmployeeRelations:DictionListEmployeeRelations
    {
        public EmployeeRelationService Service
        {
            get { return ServerEnvironment.EmployeeRelationService as EmployeeRelationService; }
        }
        public CacheListEmployeeRelations()
            : base(null)
        {

        }

        public CacheListEmployeeRelations LoadByStore(long storeid)
        {
            BuildDiction(Service.RelationDao.GetEmployeeRelationsByStore (storeid, null,null));
            return this;
        }
        public CacheListEmployeeRelations LoadByStore(long storeid, DateTime begin,DateTime end)
        {
            BuildDiction(Service.RelationDao.GetEmployeeRelationsByStore(storeid, begin, end));
            return this;
        }
        public CacheListEmployeeRelations LoadByCountry(long countryid)
        {
            BuildDiction(Service.RelationDao.GetEmployeeRelationByCountryId (countryid));
            return this;
        }

        public CacheListEmployeeRelations LoadByEmployees(long[] emplids)
        {
            BuildDiction(Service.RelationDao.GetEmployeeRelationsByEmployeeIds (emplids));
            return this;
        }

        public CacheListEmployeeRelations LoadAll()
        {
            BuildDiction(Service.RelationDao.LoadAllSorted ());

            return this;
        }

        
    }




}
