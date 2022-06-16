using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Dao;
using Baumax.Contract.Interfaces;
using Baumax.AppServer.Environment;
using System.Diagnostics;

namespace Baumax.Services
{
    [ServiceID("E8D0B971-2D2A-40a7-B97D-DFE1388C7A99")]
    public class AvgWorkingDaysInWeekService : BaseService<AvgWorkingDaysInWeek>, IAvgWorkingDaysInWeekService
    {

        public IAvgWorkingDaysInWeekDao ServiceDao
        {
            get { return ((IAvgWorkingDaysInWeekDao) Dao);}
        }

        #region IAvgWorkingDaysInWeekService Members

        [AccessType(AccessType.Read)]
        public List<AvgWorkingDaysInWeek> GetAvgWorkingDaysInWeekFiltered(long countryID, short? yearFrom, short? yearTo)
        {
            try
            {
                return
                    GetTypedListFromIList(
                        ServiceDao.GetAvgWorkingDaysInWeekFiltered(countryID, yearFrom, yearTo));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType (AccessType.Read )]
        public double GetAvgWorkingDaysInWeek(long countryID, int year)
        {
            return ServiceDao.GetAvgWorkingDaysInWeek(countryID, year);
        }
        [AccessType(AccessType.Read)]
        public double GetAvgWorkingDaysInWeekByStore(long storeid, int year)
        {
            long countryid = ServerEnvironment.StoreService.GetCountryByStoreId(storeid);
            return ServiceDao.GetAvgWorkingDaysInWeek(countryid, year);
        }
        #endregion
    }


    public class AvgWorkingDaysInWeekManager
    {
        private IAvgWorkingDaysInWeekDao _dao = null;
        private Dictionary<long, List<AvgWorkingDaysInWeek>> _dictionByCounrties = new Dictionary<long, List<AvgWorkingDaysInWeek>>();
        
        private List<AvgWorkingDaysInWeek> last_access_entry = null;
        private long last_access_countryid = 0;

        public AvgWorkingDaysInWeekManager()
        {
            _dao = (ServerEnvironment.AvgWorkingDaysInWeekService as AvgWorkingDaysInWeekService).ServiceDao;

            Debug.Assert(_dao != null);

            LoadAll(-1);
        }
        public AvgWorkingDaysInWeekManager(long countryid)
        {
            _dao = (ServerEnvironment.AvgWorkingDaysInWeekService as AvgWorkingDaysInWeekService).ServiceDao;

            Debug.Assert(_dao != null);

            LoadAll(countryid);
        }

        private void LoadAll(long countryid)
        {

            List<AvgWorkingDaysInWeek> lst = null;
            if (countryid <= 0)
                lst = _dao.GetAllAvgWorkingDaysInWeek();
            else
                lst = _dao.GetAllAvgWorkingDaysInWeekByCountry(countryid);

            _dictionByCounrties.Clear();
            if (lst != null)
            {
                List<AvgWorkingDaysInWeek> entry = null;
                foreach (AvgWorkingDaysInWeek entity in lst)
                {
                    if (!_dictionByCounrties.TryGetValue(entity.CountryID, out entry))
                    {
                        entry = new List<AvgWorkingDaysInWeek> ();
                        _dictionByCounrties[entity.CountryID] = entry;
                    }
                    entry.Add(entity);
                }
            }

        }


        public AvgWorkingDaysInWeek GetEntity(long countryid, int year)
        {
            Debug.Assert(countryid > 0);
            Debug.Assert((1900 <= year) && (year <= 2079));

            List<AvgWorkingDaysInWeek> entry = null;
            AvgWorkingDaysInWeek entity = null;
            if (last_access_entry != null && last_access_countryid == countryid)
            {
                entry = last_access_entry;
            }
            else
            {
                if (_dictionByCounrties.TryGetValue(countryid, out entry))
                {
                    last_access_entry = entry;
                    last_access_countryid = countryid;
                }
            }

            if (entry != null)
            {
                foreach (AvgWorkingDaysInWeek item in entry)
                {
                    if (item.Year == year)
                    {
                        entity = item;
                        break;
                    }
                }
            }
            return entity;

        }

        public double GetEntityValue(long countryid, int year)
        {
            AvgWorkingDaysInWeek entity = GetEntity(countryid, year);

            double resultValue = 0;
            if (entity != null)
                resultValue = Convert.ToDouble(entity.DaysCount);

            return resultValue;
        }

        public List<AvgWorkingDaysInWeek> GetList(long countryid)
        {
            List<AvgWorkingDaysInWeek> entry = null;
            _dictionByCounrties.TryGetValue(countryid, out entry);
            return entry;
        }
    }
}