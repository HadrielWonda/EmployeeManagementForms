using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using System;
using Baumax.Contract;
using System.Text;
using Baumax.Contract.QueryResult;
using Baumax.Services._HelperObjects.ExEntity;
using Baumax.AppServer.Environment;

namespace Baumax.Services
{
    [ServiceID("16EE5443-DC27-4c55-A0A8-7D6A1FF2C5E7")]
    public class EmployeeHolidaysInfoService : BaseService<EmployeeHolidaysInfo>, IEmployeeHolidaysInfoService
    {
        private IEmployeeService _employeeService;

        public  IEmployeeHolidaysInfoDao EmployeeHolidaysInfoDao
        {
            get { return (IEmployeeHolidaysInfoDao) Dao; }
        }
        [AccessType(AccessType.Read)]
        public EmployeeHolidaysInfo GetEntity(long emplid, int year)
        {
            return EmployeeHolidaysInfoDao.GetEntity(emplid, year);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeHolidaysInfo> GetEntities(long emplid)
        {
            return EmployeeHolidaysInfoDao.GetEntities(emplid);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeHolidaysInfo> GetEntities(long[] emplids, int year)
        {
            return EmployeeHolidaysInfoDao.GetEntities(emplids, year);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeHolidaysInfo> GetEntitiesByStore(long storeid, int year)
        {
            return EmployeeHolidaysInfoDao.GetEntitiesByStore(storeid, year);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeHolidaysInfo> GetEntitiesByCountry(long countryid, int year)
        {
            return EmployeeHolidaysInfoDao.GetEntitiesByCountry(countryid, year);
        }
        [AccessType(AccessType.Write)]
        public List<EmployeeHolidaysInfo> MoveSpareHolidaysToYear(long storeid, int year)
        {
            if (Log.IsInfoEnabled)
            {
                try
                {
                    Store store = ServerEnvironment.StoreService.FindById(storeid); 
                    Log.Info(String.Format("{0} take spare holidays for store({2}) from previous year(current year={1}).",
                        new object[] { ServerEnvironment.LogUserPrefix, year, (store != null ? store.Name : "Unknown") }));
                }
                catch{}
            }
            return ExEmployeeHolidays.BuildOldHolidaysFromPreviousYear(storeid, year);
        }
    }
}