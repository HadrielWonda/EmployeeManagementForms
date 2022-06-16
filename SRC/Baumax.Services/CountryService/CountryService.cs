using System;
using System.Collections;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using System.Collections.Generic;
using Baumax.Import.Scheduler;
using Baumax.Import;
using Baumax.AppServer.Environment;
using System.Threading;

namespace Baumax.Services
{
    [ServiceID("5F6D8376-3313-4500-835B-72ABFCE87D65")]
    public class CountryService : BaseService<Country>, ICountryService
    {
        #region Fields

        private IFeastService _feastService;
        private IAbsenceService _absenceService;
        private IAvgAmountService _avgAmountService;
        private IWorkingModelService _workingModelService;
        private IColouringService _colouringService;
        private IYearlyWorkingDayService _yearlyWorkingDayService;
        private IAvgWorkingDaysInWeekService _avgWorkingDaysInWeekService;
        private ICountryAdditionalHourService _countryAdditionalHourService;

        #endregion

        #region Properties

        private ICountryDao CountryDao
        {
            get { return (ICountryDao) Dao; }
        }

        #endregion

        #region ICountryService Members

        public IAvgWorkingDaysInWeekService AvgWorkingDaysInWeekService
        {
            get { return _avgWorkingDaysInWeekService; }
        }

        public IFeastService FeastService
        {
            get { return _feastService; }
        }

        public IAbsenceService AbsenceService
        {
            get { return _absenceService; }
        }

        public IAvgAmountService AvgAmountService
        {
            get { return _avgAmountService; }
        }

        public IWorkingModelService WorkingModelService
        {
            get { return _workingModelService; }
        }

        public IColouringService ColouringService
        {
            get { return _colouringService; }
        }

        public IYearlyWorkingDayService YearlyWorkingDayService
        {
            get { return _yearlyWorkingDayService; }
        }

        public ICountryAdditionalHourService CountryAdditionalHourService
        {
            get { return _countryAdditionalHourService; }
        }

        public long AustriaCountryID
        {
            [AccessType(AccessType.Read)]
            get
            {
                try
                {
                    return CountryDao.GetAustriaCountryID();
                }
                catch (Exception ex)
                {
                    throw new LoadException(ex);
                }
            }
        }

        //2think: whether it should be implemented in C#? this is DB-constraints level logic.
        //!is it already implemented in DB. INDEX [UniqueRec] ON [dbo].[CountryName] 
        [AccessType(AccessType.Read)]
        public bool IsCountryExist(long c_id, string c_name)
        {
            try
            {
                List<string> pNames = new List<string>();
                List<object> pValues = new List<object>();
                StringBuilder sb = new StringBuilder("entity.Name = :name");
                pNames.Add("name");
                pValues.Add(c_name);
                if (c_id > 0)
                {
                    sb.Append(" AND entity.ID <> :id");
                    pNames.Add("id");
                    pValues.Add(c_id);
                }
                IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
                if ((list != null) && (list.Count > 0))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex);
            }
        }

        public IList<Country> GetUserCountries(long userId)
        {
            try
            {
                return GetTypedListFromIList(CountryDao.GetUserCountries(userId));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public long[] GetCountryNoWorkingFeastDaysIDList()
        {
            try
            {
                return CountryDao.GetCountryNoWorkingFeastDaysIDList();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public long[] GetInUseIDList(InUseEntity inUseEntity, long countryID)
        {
            try
            {
                return CountryDao.GetInUseIDList(inUseEntity, countryID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Import)]
        public void TestImportServerSide()
        {
            InheritedContextAsyncStarter.Run(testImportServerSide);
        }

        private void testImportServerSide()
        {
            Log.Info("testImportServerSide started.");
            ImportFileManager.Instance.DeleteFilesOutOfDate(); 
/*
            ImportDataManager importDataManager = ImportDataManager.Instance;
            try
            {
                Log.Info("ImportType.World started.");
                importDataManager.Import(ImportType.World);
                Log.Info("ImportType.World completed successfully.");
            }
            catch (Exception ex)
            {
                Log.Info("ImportType.World completed with error(s).", ex);
            }

            try
            {
                Log.Info("ImportType.Absences started.");
                importDataManager.Import(ImportType.Absence);
                Log.Info("ImportType.Absences completed successfully.");
            }
            catch (Exception ex)
            {
                Log.Info("ImportType.Absences completed with error(s).", ex);
            }

            try
            {
                Log.Info("ImportType.TimeRecording started.");
                importDataManager.Import(ImportType.TimeRecording);
                Log.Info("ImportType.TimeRecording completed successfully.");
            }
            catch (Exception ex)
            {
                Log.Info("ImportType.TimeRecording completed with error(s).", ex);
            }

            try
            {
                Log.Info("ImportType.TimePlanning started.");
                importDataManager.Import(ImportType.TimePlanning);
                Log.Info("ImportType.TimePlanning completed successfully.");
            }
            catch (Exception ex)
            {
                Log.Info("ImportType.TimePlanning completed with error(s).", ex);
            }
*/
            Log.Info("testImportServerSide completed");
        }

        #endregion

        [AccessType(AccessType.Write)]
        public override void Delete(Country entity)
        {
            throw new ValidationException("Cannot delete the countries", null);
        }

        [AccessType(AccessType.Write)]
        public override void DeleteList(List<Country> entities)
        {
            throw new ValidationException("Cannot delete the countries", null);
        }

        [AccessType(AccessType.Write)]
        public override void DeleteByID(long id)
        {
            throw new ValidationException("Cannot delete the countries", null);
        }

        [AccessType(AccessType.Write)]
        public override void DeleteListByID(List<long> ids)
        {
            throw new ValidationException("Cannot delete the countries", null);
        }
    }
}