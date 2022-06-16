using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Belikov.GenuineChannels;
using Belikov.GenuineChannels.BroadcastEngine;
using Spring.Transaction.Interceptor;
using Baumax.Contract.Exceptions;
using Baumax.Contract.PlanningAndRecording;
using Baumax.AppServer.Environment;
using System.Diagnostics;
using Baumax.Services._HelperObjects;
using Baumax.Services._HelperObjects.ServerEntitiesList;

namespace Baumax.Services
{
    [ServiceID("3CDC01E1-ADC1-4efe-84F2-92D47A4AEA29")]
    public class StoreService : BaseService<Store>, IStoreService//, IStoreServiceHelper
    {
        public event OperationCompleteDelegate BVCopyFromStoreComplete;

        public event OperationCompleteDelegate ImportBusinessVolumeComplete;

        public event OperationCompleteDelegate EstimateWorkingHoursComplete;

        public event OperationCompleteDelegate EstimateCashDeskPeopleComplete;

        public event MessageInfoDelegate ImportBusinessVolumeMessageInfo;

        #region Fields

        private readonly Dispatcher _BVCopyFromStoreDispatcher =
            new Dispatcher(typeof (IOperationCompleteReceiver));

        private readonly IOperationCompleteReceiver _BVCopyFromStoreCaller;


        private readonly Dispatcher _ImportBusinessVolumeDispatcher =
            new Dispatcher(typeof (IOperationCompleteReceiver));

        private readonly IOperationCompleteReceiver _ImportBusinessVolumeCaller;

        private readonly Dispatcher _EstimateWorkingHoursDispatcher =
            new Dispatcher(typeof (IOperationCompleteReceiver));

        private readonly IOperationCompleteReceiver _EstimateWorkingHoursCaller;

        private readonly Dispatcher _EstimateCashDeskPeopleDispatcher =
            new Dispatcher(typeof (IOperationCompleteReceiver));

        private readonly IOperationCompleteReceiver _EstimateCashDeskPeopleCaller;

        private readonly Dispatcher _ImportBusinessVolumeMessageInfoDispatcher =
            new Dispatcher(typeof (IMessageInfoReceiver));

        private readonly IMessageInfoReceiver _ImportBusinessVolumeMessageInfoCaller;

        private IWorldService _worldService;
        private IHWGRService _HWGRService;
        private IWGRService _WGRService;
        private IStoreToWorldService _StoreToWorldService;
        private IWorldToHwgrService _WorldToHwgrService;
        private IHwgrToWgrService _HwgrToWgrService;
        private IStoreWorkingTimeService _storeWorkingTimeService;
        private IBufferHoursService _bufferHoursService;
        private IBenchmarkService _benchmarkService;
        private ITrendCorrectionService _trendCorrectionService;
        private IPersonMinMaxService _personMinMaxService;
        private IStoreAdditionalHourService _storeAdditionalHourService;
        private IBufferHourAvailableService _bufferHourAvailableService;

        // for internal use
        private ICountryService _countryService;

        private static bool _IsRunningCashDeskEstimate = false;
        private static bool _IsRunningWorkingHoursEstimate = false;
        
        private static bool _IsRunningBusinessVolumeActual = false;
        private static bool _IsRunningBusinessVolumeTarget = false;
        private static bool _IsRunningBusinessVolumeCRR = false;

        private static Object _SyncIsRunningBusinessVolumeActual = new Object();
        private static Object _SyncIsRunningBusinessVolumeTarget = new Object();
        private static Object _SyncIsRunningBusinessVolumeCRR = new Object();


        private static bool IsRunningBusinessVolumeActual
        {
            get { return _IsRunningBusinessVolumeActual; }
            set 
            {
                lock (_SyncIsRunningBusinessVolumeActual)
                {
                    _IsRunningBusinessVolumeActual = value;
                }
            }
        }

        private static bool IsRunningBusinessVolumeTarget
        {
            get { return _IsRunningBusinessVolumeTarget; }
            set
            {
                lock (_SyncIsRunningBusinessVolumeTarget)
                {
                    _IsRunningBusinessVolumeTarget = value;
                }
            }
        }

        private static bool IsRunningBusinessVolumeCRR
        {
            get { return _IsRunningBusinessVolumeCRR; }
            set
            {
                lock (_SyncIsRunningBusinessVolumeCRR)
                {
                    _IsRunningBusinessVolumeCRR = value;
                }
            }
        }


        public ICountryService CountryService
        {
            get { return _countryService; }
        }
        #endregion

        public StoreService()
        {
            _BVCopyFromStoreDispatcher.BroadcastCallFinishedHandler += BroadcastCallFinishedHandler;
            _BVCopyFromStoreDispatcher.CallIsAsync = true;
            _BVCopyFromStoreCaller = (IOperationCompleteReceiver) _BVCopyFromStoreDispatcher.TransparentProxy;


            _ImportBusinessVolumeDispatcher.BroadcastCallFinishedHandler += BroadcastCallFinishedHandler;
            _ImportBusinessVolumeDispatcher.CallIsAsync = true;
            _ImportBusinessVolumeCaller = (IOperationCompleteReceiver) _ImportBusinessVolumeDispatcher.TransparentProxy;

            _EstimateWorkingHoursDispatcher.BroadcastCallFinishedHandler += BroadcastCallFinishedHandler;
            _EstimateWorkingHoursDispatcher.CallIsAsync = true;
            _EstimateWorkingHoursCaller = (IOperationCompleteReceiver) _EstimateWorkingHoursDispatcher.TransparentProxy;

            _EstimateCashDeskPeopleDispatcher.BroadcastCallFinishedHandler += BroadcastCallFinishedHandler;
            _EstimateCashDeskPeopleDispatcher.CallIsAsync = true;
            _EstimateCashDeskPeopleCaller =
                (IOperationCompleteReceiver) _EstimateCashDeskPeopleDispatcher.TransparentProxy;

            _ImportBusinessVolumeMessageInfoDispatcher.BroadcastCallFinishedHandler += BroadcastCallFinishedHandler;
            _ImportBusinessVolumeMessageInfoDispatcher.CallIsAsync = true;
            _ImportBusinessVolumeMessageInfoCaller =
                (IMessageInfoReceiver) _ImportBusinessVolumeMessageInfoDispatcher.TransparentProxy;
        }

        #region IStoreService Members

        protected IStoreDao StoreDao
        {
            get { return (IStoreDao) Dao; }
        }

        [AccessType(AccessType.Read)]
        public IList GetStoreStructure(long storeID)
        {
            try
            {
                return StoreDao.GetStoreStructure(storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList<Store> GetUserStores(long userId)
        {
            try
            {
                return GetTypedListFromIList(StoreDao.GetUserStores(userId));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }


        public IWorldService WorldService
        {
            get { return _worldService; }
        }

        public IHWGRService HWGRService
        {
            get { return _HWGRService; }
        }

        public IWGRService WGRService
        {
            get { return _WGRService; }
        }

        public IStoreToWorldService StoreToWorldService
        {
            [AccessType(AccessType.Read)]
            get { return _StoreToWorldService; }
        }

        public IWorldToHwgrService WorldToHWGRService
        {
            [AccessType(AccessType.Read)]
            get { return _WorldToHwgrService; }
        }

        public IHwgrToWgrService HwgrToWgrService
        {
            [AccessType(AccessType.Read)]
            get { return _HwgrToWgrService; }
        }

        public IStoreWorkingTimeService StoreWorkingTimeService
        {
            [AccessType(AccessType.Read)]
            get { return _storeWorkingTimeService; }
        }

        public IBufferHoursService BufferHoursService
        {
            [AccessType(AccessType.Read)]
            get { return _bufferHoursService; }
        }

        public IBufferHourAvailableService BufferHourAvailableService
        {
            [AccessType(AccessType.Read)]
            get { return _bufferHourAvailableService; }
        }

        public IBenchmarkService BenchmarkService
        {
            [AccessType(AccessType.Read)]
            get { return _benchmarkService; }
        }

        public ITrendCorrectionService TrendCorrectionService
        {
            [AccessType(AccessType.Read)]
            get { return _trendCorrectionService; }
        }

        public IPersonMinMaxService PersonMinMaxService
        {
            [AccessType(AccessType.Read)]
            get { return _personMinMaxService; }
        }

        public IStoreAdditionalHourService StoreAdditionalHourService
        {
            [AccessType(AccessType.Read)]
            get { return _storeAdditionalHourService; }
        }

        [AccessType(AccessType.FreeAccess)]
        public short[] GetCalculatedYears()
        {
            try
            {
                return StoreDao.GetCalculatedYears();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<StoreShort> GetStoreShortList()
        {
            try
            {
                return StoreDao.GetStoreShortList();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion

        #region Import Business volume

        private bool IsRunningImportBusinessVolumeCheck(BusinessVolumeType importType)
        {
            //bool isRunning;
            //switch (importType)
            //{
            //    case BusinessVolumeType.Actual:
            //        isRunning = IsRunningBusinessVolumeActual;
            //        break;
            //    case BusinessVolumeType.Target:
            //        isRunning = IsRunningBusinessVolumeTarget;
            //        break;
            //    case BusinessVolumeType.CashRegisterReceipt:
            //        isRunning = IsRunningBusinessVolumeCRR;
            //        break;
            //    default:
            //        goto case BusinessVolumeType.Actual;
            //}
            //return isRunning;
            return IsRunningBusinessVolumeActual || IsRunningBusinessVolumeTarget || IsRunningBusinessVolumeCRR;
        }

        private BusinessVolumeType WhatIsRunning ()
        {
            BusinessVolumeType businessVolumeType;
            if (IsRunningBusinessVolumeActual)
                businessVolumeType = BusinessVolumeType.Actual;
            else if (IsRunningBusinessVolumeTarget)
                businessVolumeType = BusinessVolumeType.Target;
            else
                businessVolumeType = BusinessVolumeType.CashRegisterReceipt;
            return businessVolumeType;
        }

        private void IsRunningImportBusinessVolumeSet(BusinessVolumeType importType, bool value)
        {
            switch (importType)
            {
                case BusinessVolumeType.Actual:
                    IsRunningBusinessVolumeActual = value;
                    break;
                case BusinessVolumeType.Target:
                    IsRunningBusinessVolumeTarget = value;
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    IsRunningBusinessVolumeCRR = value;
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
        }

        [AccessType(AccessType.Import)]
        public void ImportBusinessVolume(BusinessVolumeType importType)
        {
            if (IsRunningImportBusinessVolumeCheck(importType))
            {
                throw new AnotherImportRunning(string.Format(GetLocalized("bvAlreadyRunning"), WhatIsRunning().ToString()));
            }
            StoreDao.ImportBusinessVolumeMessageInfo +=
                new MessageInfoDelegate(StoreService_ImportBusinessVolumeMessageInfo);

            InheritedContextAsyncStarter.Run(importBusinessVolume, new ImportParam(importType));
        }

        private void StoreService_ImportBusinessVolumeMessageInfo(object sender, MessageInfoEventArgs e)
        {
            if (ImportBusinessVolumeMessageInfo != null)
            {
                ImportBusinessVolumeMessageInfo(null, e);
            }
            _ImportBusinessVolumeMessageInfoCaller.ReceiveMessage(null, e);
        }

        private void OnImportBusinessVolumeComplete(object sender, OperationCompleteEventArgs e)
        {
            if (ImportBusinessVolumeComplete != null)
            {
                ImportBusinessVolumeComplete(sender, e);
            }
            _ImportBusinessVolumeCaller.ReceiveOperationComplete(sender, e);
            StoreDao.ImportBusinessVolumeMessageInfo -=
                new MessageInfoDelegate(StoreService_ImportBusinessVolumeMessageInfo);
        }

        private void importBusinessVolume(object param)
        {
            OperationCompleteEventArgs operationCompleteEventArgs = new OperationCompleteEventArgs(false);
            ImportParam importParam = (ImportParam) param;
            ImportBusinessValuesResult saveDataResult;
            try
            {
                IsRunningImportBusinessVolumeSet(importParam.ImportType, true);
                saveDataResult = StoreDao.ImportBusinessVolume(importParam.ImportType);
                operationCompleteEventArgs.Success = saveDataResult.Success;
                operationCompleteEventArgs.Param = saveDataResult;
            }
            catch (Exception ex)
            {
                saveDataResult = new ImportBusinessValuesResult();
                saveDataResult.BusinessVolumeType = importParam.ImportType;
                saveDataResult.Success = false;
                saveDataResult.Data = ex;
                operationCompleteEventArgs.Param = saveDataResult;
            }
            IsRunningImportBusinessVolumeSet(importParam.ImportType, false);
            OnImportBusinessVolumeComplete(null, operationCompleteEventArgs);
        }

        [AccessType(AccessType.Import)]
        public ServerImportFoldersInfo GetServerImportFoldersInfo()
        {
            try
            {
                return StoreDao.GetServerImportFoldersInfo();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        private struct ImportParam
        {
            public readonly BusinessVolumeType ImportType;

            public ImportParam(BusinessVolumeType importType)
            {
                ImportType = importType;
            }
        }

        #endregion

        [AccessType(AccessType.Import)]
        public bool CopyStructureForEmptyStores()
        {
            try
            {
                return StoreDao.CopyStructureForEmptyStores();
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        #region Estimate working hours

        [AccessType(AccessType.Write)]
        public void EstimateWorkingHours(int year)
        {
            EstimateWorkingHours(SharedConsts.CalculateAll, year);
        }

        [AccessType(AccessType.Write)]
        public void EstimateWorkingHours(long storeID, int year)
        {
            InheritedContextAsyncStarter.Run(estimateWorkingHours, new EstimateParam(storeID, year));
        }

        private void OnEstimateWorkingHoursComplete(object sender, OperationCompleteEventArgs e)
        {
            if (EstimateWorkingHoursComplete != null)
            {
                EstimateWorkingHoursComplete(sender, e);
            }
            _EstimateWorkingHoursCaller.ReceiveOperationComplete(sender, e);
        }

        private void estimateWorkingHours(object param)
        {
            if (_IsRunningWorkingHoursEstimate)
            {
                return;
            }

            OperationCompleteEventArgs operationCompleteEventArgs = new OperationCompleteEventArgs(false);
            EstimateParam estimateParam = (EstimateParam) param;
            try
            {
                _IsRunningWorkingHoursEstimate = true;
                bool result = StoreDao.EstimateWorkingHours(estimateParam.StoreID, estimateParam.Year);
                operationCompleteEventArgs.Success = result;
            }
            catch (Exception ex)
            {
                operationCompleteEventArgs.Param = ex;
            }
            _IsRunningWorkingHoursEstimate = false;
            OnEstimateWorkingHoursComplete(null, operationCompleteEventArgs);
        }

        [AccessType(AccessType.Read)]
        public bool EstimationWorkingHoursExists(long storeID, int year)
        {
            try
            {
                return StoreDao.EstimationWorkingHoursExists(storeID, year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public bool EstimationWorkingHoursExists(int year)
        {
            try
            {
                return StoreDao.EstimationWorkingHoursExists(year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion

        #region Estimate cash desk people

        [AccessType(AccessType.Write)]
        public void EstimateCashDeskPeople(int year)
        {
            EstimateCashDeskPeople(SharedConsts.CalculateAll, year);
        }

        [AccessType(AccessType.Write)]
        public void EstimateCashDeskPeople(long storeID, int year)
        {
            InheritedContextAsyncStarter.Run(estimateCashDeskPeople, new EstimateParam(storeID, year));
        }

        private void OnestimateCashDeskPeopleComplete(object sender, OperationCompleteEventArgs e)
        {
            if (EstimateCashDeskPeopleComplete != null)
            {
                EstimateCashDeskPeopleComplete(sender, e);
            }
            _EstimateCashDeskPeopleCaller.ReceiveOperationComplete(sender, e);
        }


        private void estimateCashDeskPeople(object param)
        {
            if (_IsRunningCashDeskEstimate)
            {
                return;
            }

            OperationCompleteEventArgs operationCompleteEventArgs = new OperationCompleteEventArgs(false);
            EstimateParam estimateParam = (EstimateParam) param;
            try
            {
                _IsRunningCashDeskEstimate = true;
                bool result = ((IStoreDao) Dao).EstimateCashDeskPeople(estimateParam.StoreID, estimateParam.Year);
                operationCompleteEventArgs.Success = result;
            }
            catch (Exception ex)
            {
                operationCompleteEventArgs.Param = ex;
            }
            _IsRunningCashDeskEstimate = false;
            OnestimateCashDeskPeopleComplete(null, operationCompleteEventArgs);
        }

        #endregion

        private struct EstimateParam
        {
            public long StoreID;
            public int Year;

            public EstimateParam(long storeID, int year)
            {
                StoreID = storeID;
                Year = year;
            }

            public EstimateParam(int year)
                : this(0, year)
            {
            }
        }

        #region Calculation Store Additional Hours 

        /*
         * 
         */

        [AccessType(AccessType.Read)]
        public List<short> GetYearsWithCountryAdditinalHourByStoreID(long storeID, int fromYear, int toYear)
        {
            long countryID = GetCountryByStoreId(storeID);
            List<CountryAdditionalHour> additionalHours = new List<CountryAdditionalHour>();
            List<short> years = new List<short>();
            List<CountryAdditionalHour> list = new List<CountryAdditionalHour>();
            for (short year = (short) fromYear; year <= toYear; year ++)
            {
                list = _countryService.CountryAdditionalHourService.GetCountryAdditionalHourFiltered(countryID, year);
                if (list != null && list.Count != 0)
                {
                    additionalHours.AddRange(list);
                }
            }

            if (additionalHours != null && additionalHours.Count != 0)
            {
                bool existYear = false;
                foreach (CountryAdditionalHour additionalHour in additionalHours)
                {
                    existYear = false;
                    foreach (int year in years)
                    {
                        if (year == additionalHour.Year)
                        {
                            existYear = true;
                            break;
                        }
                    }

                    if (!existYear)
                    {
                        years.Add(additionalHour.Year);
                    }
                }
            }
            if (years != null && years.Count != 0)
            {
                return years;
            }
            else
            {
                return null;
            }
        }

        // TODO: does this function really writes data?
        [AccessType(AccessType.Write)]
        [Transaction]
        public bool CalculateAdditionalHoursForAllTime()
        {
            try
            {
                bool result = false;
                List<CountryAdditionalHour> additionalHours = _countryService.CountryAdditionalHourService.FindAll();
                //((IStoreDao)Dao).GetCountryAdditionalHourYears();
                if (additionalHours != null && additionalHours.Count != 0)
                {
                    List<int> years = new List<int>();
                    List<long> countries = new List<long>();
                    bool existYear = false;
                    bool existCountry = false;
                    foreach (CountryAdditionalHour additionalHour in additionalHours)
                    {
                        existYear = false;
                        existCountry = false;
                        foreach (int year in years)
                        {
                            if (year == additionalHour.Year)
                            {
                                existYear = true;
                                break;
                            }
                        }
                        foreach (long country in countries)
                        {
                            if (country == additionalHour.CountryID)
                            {
                                existCountry = true;
                                break;
                            }
                        }
                        if (!existYear)
                        {
                            years.Add(additionalHour.Year);
                        }
                        if (!existCountry)
                        {
                            countries.Add(additionalHour.CountryID);
                        }
                    }
                    if (years != null && countries != null && years.Count != 0 && countries.Count != 0)
                    {
                        foreach (long countryID in countries)
                        {
                            foreach (int year in years)
                            {
                                if (CalculateCountryAdditionalHours(year, countryID))
                                {
                                    result = true;
                                }
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        // TODO: does this function really writes data?
        [AccessType(AccessType.Write)]
        [Transaction]
        public bool CalculateCountryAdditionalHours(int year, long countryID)
        {
            try
            {
                bool result = false;
                Store[] stores = GetStoresByCountryId(countryID);
                if (stores == null || stores.Length == 0)
                {
                    return false;
                }

                List<CountryAdditionalHour> countryAdditionalHours =
                    _countryService.CountryAdditionalHourService.GetCountryAdditionalHourFiltered(countryID,
                                                                                                  (short?)year);
                if (countryAdditionalHours == null || countryAdditionalHours.Count == 0)
                {
                    return false;
                }

                foreach (Store store in stores)
                {
                    if (CalculateAdditionalHours(year, store.ID, countryAdditionalHours))
                    {
                        result = true;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        // TODO: does this function really writes data?
        [AccessType(AccessType.Write)]
        [Transaction]
        public bool CalculateStoreAdditionalHours(int year, long storeID)
        {
            try
            {
                long countryID = GetCountryByStoreId(storeID);
                if (countryID <= 0)
                {
                    return false;
                }

                List<CountryAdditionalHour> countryAdditionalHours =
                    _countryService.CountryAdditionalHourService.GetCountryAdditionalHourFiltered(countryID, (short?)year);
                if (countryAdditionalHours == null || countryAdditionalHours.Count == 0)
                {
                    return false;
                }

                return CalculateAdditionalHours(year, storeID, countryAdditionalHours);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        private bool CalculateAdditionalHours(int year, long storeID, List<CountryAdditionalHour> countryAdditionalHours)
        {
            decimal additionalHours = 0;

            List<StoreAdditionalHour> updatedAdditionalHours = new List<StoreAdditionalHour>();

            try
            {
                bool result = false;

                List<StoreWorkingTime> storeWorkingTime =
                    StoreWorkingTimeService.GetWorkingTimeFiltered(storeID, new DateTime(year, 1, 1),
                                                                   new DateTime(year, 12, 31));
                if (storeWorkingTime == null || storeWorkingTime.Count == 0)
                {
                    return result;
                }

                foreach (StoreWorkingTime workingTime in storeWorkingTime)
                {
                    DateTime BeginDate;
                    DateTime EndDate;

                    if (workingTime.BeginTime < new DateTime(year, 1, 1))
                    {
                        BeginDate = new DateTime(year, 1, 1);
                    }
                    else
                    {
                        BeginDate = workingTime.BeginTime;
                    }

                    if (workingTime.EndTime > new DateTime(year, 12, 31))
                    {
                        EndDate = new DateTime(year, 12, 31);
                    }
                    else
                    {
                        EndDate = workingTime.EndTime;
                    }

                    List<StoreAdditionalHour> storeAdditionalHours =
                        StoreAdditionalHourService.GetStoreAdditionalHourFiltered(storeID, BeginDate, EndDate);

                    List<StoreWTWeekday> wtWeekdays = new List<StoreWTWeekday>();

                    StoreWorkingTime wtimecopy = StoreWorkingTimeService.CreateEntity();
                    StoreWorkingTime.CopyTo(workingTime, wtimecopy);
                    foreach (StoreWTWeekday wtwd in wtimecopy.StoreWTWeekdays)
                    {
                        wtWeekdays.Add(wtwd);
                    }

                    if (wtWeekdays == null || wtWeekdays.Count == 0)
                    {
                        continue;
                    }

                    //updatedAdditionalHours = new List<StoreAdditionalHour>();
                    foreach (StoreWTWeekday wtWeekday in wtWeekdays)
                    {
                        foreach (CountryAdditionalHour additionalHour in countryAdditionalHours)
                        {
                            byte WeekDay;
                            //compare WeekDay in format of WeekDay and BaumaxWeekDay
                            if (wtWeekday.Weekday == additionalHour.WeekDay ||
                                wtWeekday.Weekday + 7 == additionalHour.WeekDay)
                            {
                                WeekDay = additionalHour.WeekDay;
                                short OpenTime = wtWeekday.Opentime;
                                short CloseTime = wtWeekday.Closetime;
                                short begintime = additionalHour.BeginTime;
                                short endtime = additionalHour.EndTime;
                                decimal factorB = additionalHour.FactorEarly;
                                decimal factorE = additionalHour.FactorLate;
                                int originaltime;
                                bool needDelete = false;
                                if (begintime == 0 && CloseTime > endtime && endtime > OpenTime)
                                {
                                    originaltime = CloseTime - endtime;
                                    additionalHours = originaltime*factorE - originaltime;
                                }

                                if (begintime == 0 && (endtime >= CloseTime || endtime <= OpenTime))
                                {
                                    needDelete = true;
                                }

                                if (endtime == 0 && begintime > OpenTime && begintime < CloseTime)
                                {
                                    originaltime = begintime - OpenTime;
                                    additionalHours = originaltime*factorB - originaltime;
                                }
                                if (endtime == 0 && (begintime >= CloseTime || begintime <= OpenTime))
                                {
                                    needDelete = true;
                                }
                                if (begintime != 0 && endtime != 0 && CloseTime > endtime && begintime > OpenTime &&
                                    endtime > OpenTime && begintime < CloseTime)
                                {
                                    originaltime = (begintime - OpenTime) + (CloseTime - endtime);
                                    additionalHours = ((begintime - OpenTime)*factorB + (CloseTime - endtime)*factorE) -
                                                      originaltime;
                                }
                                if (begintime != 0 && endtime != 0 && CloseTime > endtime && endtime > OpenTime &&
                                    (begintime >= CloseTime || begintime <= OpenTime))
                                {
                                    originaltime = CloseTime - endtime;
                                    additionalHours = originaltime*factorE - originaltime;
                                }
                                if (begintime != 0 && endtime != 0 && begintime > OpenTime && begintime < CloseTime &&
                                    (endtime >= CloseTime || endtime <= OpenTime))
                                {
                                    originaltime = begintime - OpenTime;
                                    additionalHours = originaltime*factorB - originaltime;
                                }
                                if (begintime != 0 && endtime != 0 && (endtime >= CloseTime || endtime <= OpenTime) &&
                                    (begintime >= CloseTime || begintime <= OpenTime))
                                {
                                    needDelete = true;
                                }
                                if (additionalHours <= 0)
                                {
                                    needDelete = true;
                                }
                                StoreAdditionalHour Entity = StoreAdditionalHourService.CreateEntity();
                                if (storeAdditionalHours != null && storeAdditionalHours.Count != 0)
                                {
                                    foreach (StoreAdditionalHour existSaHour in storeAdditionalHours)
                                    {
                                        if (existSaHour.WeekDay == WeekDay)
                                        {
                                            if (needDelete)
                                            {
                                                StoreAdditionalHourService.DeleteByID(existSaHour.ID);
                                            }
                                            else
                                            {
                                                Entity.ID = existSaHour.ID;
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (!needDelete)
                                {
                                    Entity.StoreID = storeID;
                                    Entity.BeginDate = BeginDate;
                                    Entity.EndDate = EndDate;
                                    Entity.WeekDay = WeekDay;
                                    Entity.AdditionalHours = additionalHours/60;
                                    result = true;
                                    updatedAdditionalHours.Add(Entity);
                                }
                            }
                        }
                    }
                }

                if (updatedAdditionalHours != null && updatedAdditionalHours.Count != 0)
                {
                    if (Log.IsDebugEnabled)
                    {
                        Log.Debug("Saving recalculated additional hours. Count = " +
                                  updatedAdditionalHours.Count.ToString());
                    }
                    StoreAdditionalHourService.SaveOrUpdateList(updatedAdditionalHours);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public bool DeleteCalculatedCountryAdditionalHours(int year, long countryID, byte dayOfWeek)
        {
            try
            {
                bool result = false;
                Store[] stores = GetStoresByCountryId(countryID);
                List<long> ListRemoveStoreAdditionalHoursID = new List<long>();
                if (stores == null || stores.Length == 0)
                {
                    return false;
                }
                foreach (Store store in stores)
                {
                    List<StoreAdditionalHour> storeAdditionalHours =
                        StoreAdditionalHourService.GetStoreAdditionalHourFiltered(store.ID, year, dayOfWeek);
                    if (storeAdditionalHours != null && storeAdditionalHours.Count != 0)
                    {
                        foreach (StoreAdditionalHour storeAddhour in storeAdditionalHours)
                        {
                            ListRemoveStoreAdditionalHoursID.Add(storeAddhour.ID);
                            result = true;
                        }
                    }
                }
                if (ListRemoveStoreAdditionalHoursID != null && ListRemoveStoreAdditionalHoursID.Count != 0)
                {
                    StoreAdditionalHourService.DeleteListByID(ListRemoveStoreAdditionalHoursID);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new DeleteException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public bool DeleteCalculatedCountryAdditionalHours(int year, long storeID)
        {
            try
            {
                bool result = false;
                List<long> ListRemoveStoreAdditionalHoursID = new List<long>();
                List<StoreAdditionalHour> storeAdditionalHours = new List<StoreAdditionalHour>();
                List<StoreAdditionalHour> list = new List<StoreAdditionalHour>();
                for (byte dayOfWeek = Convert.ToByte(BaumaxDayOfWeek.Monday);
                     dayOfWeek <= Convert.ToByte(BaumaxDayOfWeek.Sunday);
                     dayOfWeek++)
                {
                    list = StoreAdditionalHourService.GetStoreAdditionalHourFiltered(storeID, year, dayOfWeek);
                    if (list != null && list.Count != 0)
                    {
                        storeAdditionalHours.AddRange(list);
                    }
                }

                if (storeAdditionalHours != null && storeAdditionalHours.Count != 0)
                {
                    foreach (StoreAdditionalHour storeAddhour in storeAdditionalHours)
                    {
                        ListRemoveStoreAdditionalHoursID.Add(storeAddhour.ID);
                        result = true;
                    }
                }
                if (ListRemoveStoreAdditionalHoursID != null && ListRemoveStoreAdditionalHoursID.Count != 0)
                {
                    StoreAdditionalHourService.DeleteListByID(ListRemoveStoreAdditionalHoursID);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new DeleteException(ex);
            }
        }

        #endregion

        #region IStoreServiceHelper Members

        [AccessType(AccessType.Read)]
        public long GetCountryByStoreId(long storeid)
        {
            try
            {
                return StoreDao.GetCountryByStoreId(storeid);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion

        [AccessType(AccessType.Read)]
        public Store[] GetStoresByCountryId(long countryid)
        {
            try
            {
                return StoreDao.GetStoresByCountryId(countryid);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        public List<Store> LoadAll()
        {
            try
            {
                return StoreDao.LoadAll();
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        [AccessType(AccessType.Read)]
        public StoreDaysList GetStoreDays(long storeid, DateTime aBegin, DateTime aEnd)
        {
            StoreDaysList result = new StoreDaysList(storeid, aBegin, aEnd);
            long countryid = GetCountryByStoreId(storeid);

            CountryFeastListEx feasts = new CountryFeastListEx(countryid, aBegin, aEnd);

            //IList lst = _countryService.FeastService.GetFeastsFiltered(countryid, aBegin, aEnd);
//            result.ApplyFeastDays(lst);
            result.ApplyFeastDays(feasts.Values);

            CountryCloseDaysListEx closedays = new CountryCloseDaysListEx(countryid, aBegin, aEnd);
            result.ApplyClosedDays(closedays.Values);

            //lst = _countryService.YearlyWorkingDayService.GetYearlyWorkingDaysFiltered(countryid, aBegin, aEnd);
            //result.ApplyClosedDays(lst);

            IList lst = (StoreWorkingTimeService as StoreWorkingTimeService).GetWorkingTimeFiltered_Srv(storeid, aBegin, aEnd);
            result.ApplyOpenCloseTimes(lst);


            int year = DateTimeHelper.GetYearByDate(aBegin);
            result.AvgDayInWeek = _countryService.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeek(countryid, year);

            //lst =
            //    _countryService.AvgWorkingDaysInWeekService.GetAvgWorkingDaysInWeekFiltered(countryid,
            //                                                                                (short)year,
            //                                                                                (short) year);

            //if (lst != null && lst.Count > 0)
            //{
            //    AvgWorkingDaysInWeek avg = (AvgWorkingDaysInWeek) lst[0];
            //    result.AvgDayInWeek = Convert.ToDouble(avg.DaysCount);
            //}

            return result;
        }

        [AccessType(AccessType.Read)]
        public long[] GetStoreEmptyOpenCloseTimeList(long userID)
        {
            try
            {
                return StoreDao.GetStoreEmptyOpenCloseTimeList(userID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoGet(long mainStoreID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            try
            {
                return StoreDao.EmlpoyeeHolidaysSumInfoGet(mainStoreID, beginDate, endDate, currDate);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoByCountryIDGet(long countryID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            try
            {
                return StoreDao.EmlpoyeeHolidaysSumInfoByCountryIDGet(countryID, beginDate, endDate, currDate);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public EmlpoyeeHolidaysSumDays EmlpoyeeHolidaysSumInfoByEmployeeIDGet(long employeeID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            try
            {
                IList list = StoreDao.EmlpoyeeHolidaysSumInfoByEmployeeIDGet(employeeID, beginDate, endDate, currDate);

                if (list != null && list.Count == 1)
                    return (EmlpoyeeHolidaysSumDays)list[0];

                return null;
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public StoreTimeEnvironment GetStoreTimeEnvironment(long storeID)
        {
            StoreTimeEnvironment result = new StoreTimeEnvironment();

            Store store = FindById (storeID );
            Debug.Assert(store != null);
            if (store != null)
            {
                Country country = ServerEnvironment.CountryService.FindById(store.CountryID);
                
                Debug.Assert(country != null);

                result.LastRecordingDate = LastEmployeeWeekTimeRecordingGet(storeID);
                result.LastPlanningDate = LastEmployeeWeekTimePlanningGet(storeID);

                if (country != null)
                {
                    result.CriticalDays = country.MaxDays;
                    result.WarningDays = country.WarningDays;
                }
            }
            return result;
        }

        [AccessType(AccessType.Read)]
        public DateTime? LastEmployeeWeekTimeRecordingGet(long storeID)
        {
            try
            {
                return StoreDao.LastEmployeeWeekTimeRecordingGet(storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException (ex);
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public bool LastEmployeeWeekTimeRecordingUpdate(long storeID, DateTime date)
        {
            try
            {
                DateTime? oldDate = LastEmployeeWeekTimeRecordingGet(storeID);

                if (!oldDate.HasValue || oldDate.Value < date)
                    return StoreDao.LastEmployeeWeekTimeRecordingUpdate(storeID, date);

                return false;
            }
            catch (Exception ex)
            {
                throw new SaveException (ex);
            }
        }

        [AccessType(AccessType.Read)]
        public DateTime? LastEmployeeWeekTimePlanningGet(long storeID)
        {
            try
            {
                return StoreDao.LastEmployeeWeekTimePlanningGet(storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public bool LastEmployeeWeekTimePlanningUpdate(long storeID, DateTime date)
        {
            try
            {
                DateTime? oldDate = LastEmployeeWeekTimePlanningGet(storeID);

                if (!oldDate.HasValue || oldDate.Value < date)
                    return StoreDao.LastEmployeeWeekTimePlanningUpdate(storeID, date);

                return false;
            }
            catch (Exception ex)
            { 
                throw new SaveException(ex);
            }
        }

        //public void LastEmployeeRecordingWeekUpdate(long storeid, DateTime date)
        //{
        //    try
        //    {
        //        DateTime? oldDate = LastEmployeeWeekTimeRecordingGet(storeid);

        //        if (!oldDate.HasValue || oldDate.Value < date)
        //            LastEmployeeWeekTimeRecordingUpdate(storeid, date);
        //    }
        //    catch (Exception ex)
        //    { 
        //        throw new SaveException(ex);
        //    }
        //}

        [AccessType (AccessType.Read)]
        public IList GetStoresWithEmployeeWeekTimeRecordingDelay()
        {
            try
            {
                return StoreDao.GetStoresWithEmployeeWeekTimeRecordingDelay();
            }
            catch (Exception ex)
            {
                throw new LoadException (ex);
            }
        }

        #region Can estimate functions

        [AccessType(AccessType.Read)]
        public bool CanEstimateWorkingHours(int year)
        {
            try
            {
                if (_IsRunningWorkingHoursEstimate)
                {
                    return false;
                }
                return StoreDao.CanEstimateWorkingHours(year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public bool CanEstimateCashDeskPeople(int year)
        {
            try
            {
                if (_IsRunningCashDeskEstimate)
                {
                    return false;
                }
                return StoreDao.CanEstimateCashDeskPeople(year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList CanEstimateWorkingHoursInfo(int year)
        {
            return CanEstimateWorkingHoursInfo(SharedConsts.CalculateAll, year);
        }

        [AccessType(AccessType.Read)]
        public IList CanEstimateWorkingHoursInfo(long storeID, int year)
        {
            try
            {
                if (_IsRunningWorkingHoursEstimate)
                {
                    return null;
                }
                return ((IStoreDao) Dao).CanEstimateWorkingHoursInfo(storeID, year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList CanEstimateCashDeskPeopleInfo(int year)
        {
            return CanEstimateCashDeskPeopleInfo(SharedConsts.CalculateAll, year);
        }

        [AccessType(AccessType.Read)]
        public IList CanEstimateCashDeskPeopleInfo(long storeID, int year)
        {
            try
            {
                if (_IsRunningCashDeskEstimate)
                {
                    return null;
                }
                return ((IStoreDao) Dao).CanEstimateCashDeskPeopleInfo(storeID, year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }


        [AccessType(AccessType.Write)]
        [Transaction]
        public object ExecuteTestMethods(string param)
        {
            //YearlyEstimatedWorldHoursBuilder b = new YearlyEstimatedWorldHoursBuilder();
            //StoreToWorld sw = ServerEnvironment.StoreToWorldService.FindById(1350); ;
            //int year = 2008;

            //return b.TestAndCompare2(sw, year);

            StoreBufferHoursAvailableManager.UpdateWholeYear(1229, 2008);
            return null;
        }
        #endregion

        #region Copy "business volume from other store" functions

        #region Synchronous

        [AccessType(AccessType.Write)]
        public BVcopyFromStoreResult BVCopyFromStore(BusinessVolumeType bvType, short yearBegin, short yearEnd,
                                                     long sourceStoreID, long destStoreID)
        {
            try
            {
                return StoreDao.BVCopyFromStore(bvType, yearBegin, yearEnd, sourceStoreID, destStoreID);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
        }

        #endregion

        #region Async

        private void OnBVCopyFromStoreComplete(object sender, OperationCompleteEventArgs e)
        {
            if (BVCopyFromStoreComplete != null)
            {
                BVCopyFromStoreComplete(sender, e);
            }
            _BVCopyFromStoreCaller.ReceiveOperationComplete(sender, e);
        }


        [AccessType(AccessType.Write)]
        public void BVCopyFromStoreAsync(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID,
                                         long destStoreID)
        {
            InheritedContextAsyncStarter.Run(bvCopyFromStore, new BVCopyParam(bvType, yearBegin, yearEnd, sourceStoreID, destStoreID));
        }

        private void bvCopyFromStore(object param)
        {
            OperationCompleteEventArgs operationCompleteEventArgs = new OperationCompleteEventArgs(false);
            BVCopyParam bvCopyParam = (BVCopyParam) param;
            try
            {
                BVcopyFromStoreResult bvcopyFromStoreResult =
                    StoreDao.BVCopyFromStore(bvCopyParam.BvType, bvCopyParam.YearBegin, bvCopyParam.YearEnd,
                                             bvCopyParam.SourceStoreID, bvCopyParam.DestStoreID);
                operationCompleteEventArgs.Success = bvcopyFromStoreResult == BVcopyFromStoreResult.Success;
                operationCompleteEventArgs.Param = bvcopyFromStoreResult;
            }
            catch (Exception ex)
            {
                operationCompleteEventArgs.Param = ex;
            }
            OnBVCopyFromStoreComplete(null, operationCompleteEventArgs);
        }

        private struct BVCopyParam
        {
            public readonly BusinessVolumeType BvType;
            public readonly short YearBegin;
            public readonly short YearEnd;
            public readonly long SourceStoreID;
            public readonly long DestStoreID;

            public BVCopyParam(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID,
                               long destStoreID)
            {
                BvType = bvType;
                YearBegin = yearBegin;
                YearEnd = yearEnd;
                SourceStoreID = sourceStoreID;
                DestStoreID = destStoreID;
            }
        }

        #endregion

        #region Get info about business volumes per year

        [AccessType(AccessType.Read)]
        public IList BVActualByYearInfoGet(short beforeYear)
        {
            return BVActualByYearInfoGet(beforeYear, SharedConsts.CalculateAll);
        }

        [AccessType(AccessType.Read)]
        public IList BVActualByYearInfoGet(short beforeYear, long storeID)
        {
            try
            {
                //return ((IStoreDao) Dao).BVByYearInfoGet(BusinessVolumeType.Actual, beforeYear, storeID);
                return ((IStoreDao)Dao).BVActualByYearInfoGet(beforeYear, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList BVTargetByYearInfoGet(short beforeYear)
        {
            return BVTargetByYearInfoGet(beforeYear, SharedConsts.CalculateAll);
        }

        [AccessType(AccessType.Read)]
        public IList BVTargetByYearInfoGet(short beforeYear, long storeID)
        {
            try
            {
                return ((IStoreDao) Dao).BVByYearInfoGet(BusinessVolumeType.Target, beforeYear, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public IList BVCcrYearInfoGet(short beforeYear)
        {
            return BVCcrYearInfoGet(beforeYear, SharedConsts.CalculateAll);
        }

        [AccessType(AccessType.Read)]
        public IList BVCcrYearInfoGet(short beforeYear, long storeID)
        {
            try
            {
                return ((IStoreDao) Dao).BVByYearInfoGet(BusinessVolumeType.CashRegisterReceipt, beforeYear, storeID);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion

        #endregion

        #region Subscribe and unsubscribe functions for dispatchers

        private static void BroadcastCallFinishedHandler(Dispatcher dispatcher, IMessage message,
                                                         ResultCollector resultCollector)
        {
            lock (resultCollector)
            {
                foreach (DictionaryEntry entry in resultCollector.Failed)
                {
                    string mbrUri = (string) entry.Key;
                    Exception ex = null;
                    if (entry.Value is Exception)
                    {
                        ex = (Exception) entry.Value;
                    }
                    else
                    {
                        ex = ((IMethodReturnMessage) entry.Value).Exception;
                    }
                    MarshalByRefObject failedObject = dispatcher.FindObjectByUri(mbrUri);

                    Console.WriteLine("{0}: Receiver {1} has failed. Error: {2}", ex.Source, mbrUri, ex.Message);
                    // here you have failed MBR object (failedObject)
                    // and Exception (ex)
                }
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeBVCopyFromStoreComplete(IOperationCompleteReceiver receiver)
        {
            _BVCopyFromStoreDispatcher.Add((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeBVCopyFromStoreComplete(IOperationCompleteReceiver receiver)
        {
            _BVCopyFromStoreDispatcher.Remove((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeImportBusinessVolumeMessageInfo(IMessageInfoReceiver infoReceiver)
        {
            _ImportBusinessVolumeMessageInfoDispatcher.Add((MarshalByRefObject) infoReceiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeImportBusinessVolumeMessageInfo(IMessageInfoReceiver infoReceiver)
        {
            _ImportBusinessVolumeMessageInfoDispatcher.Remove((MarshalByRefObject) infoReceiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeImportBusinessVolumeComplete(IOperationCompleteReceiver receiver)
        {
            _ImportBusinessVolumeDispatcher.Add((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeImportBusinessVolumeComplete(IOperationCompleteReceiver receiver)
        {
            _ImportBusinessVolumeDispatcher.Remove((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeEstimateWorkingHoursComplete(IOperationCompleteReceiver receiver)
        {
            _EstimateWorkingHoursDispatcher.Add((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeEstimateWorkingHoursComplete(IOperationCompleteReceiver receiver)
        {
            _EstimateWorkingHoursDispatcher.Remove((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeEstimateCashDeskPeopleComplete(IOperationCompleteReceiver receiver)
        {
            _EstimateCashDeskPeopleDispatcher.Add((MarshalByRefObject) receiver);
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeEstimateCashDeskPeopleComplete(IOperationCompleteReceiver receiver)
        {
            _EstimateCashDeskPeopleDispatcher.Remove((MarshalByRefObject) receiver);
        }

        #endregion
    }
}