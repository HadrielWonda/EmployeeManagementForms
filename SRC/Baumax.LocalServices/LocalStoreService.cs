using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Contract.Import;
using Baumax.Contract.PlanningAndRecording;

namespace Baumax.LocalServices
{
    public class LocalStoreService : LocalBaseCachingService<Store>, IStoreService
    {
        #region Events and Helpers

        private event OperationCompleteDelegate _BVCopyFromStoreComplete;

        private event OperationCompleteDelegate _ImportBusinessVolumeComplete;

        private event OperationCompleteDelegate _EstimateWorkingHoursComplete;

        private event OperationCompleteDelegate _EstimateCashDeskPeopleComplete;

        private event MessageInfoDelegate _ImportBusinessVolumeMessageInfo;

        private readonly IOperationCompleteReceiver _BVCopyFromStoreCompleteRcv = new OperationCompleteReceiver();

        public event OperationCompleteDelegate BVCopyFromStoreComplete
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_BVCopyFromStoreComplete);
                _BVCopyFromStoreComplete += value;
                if (needSubscribe)
                {
                    RemoteService.SubscribeBVCopyFromStoreComplete(_BVCopyFromStoreCompleteRcv);
                    _BVCopyFromStoreCompleteRcv.OperationComplete +=
                        new OperationCompleteDelegate(OnBVCopyFromStoreComplete);
                }
            }
            remove
            {
                _BVCopyFromStoreComplete -= value;
                if (!Utils.IsDelegateSubscribers(_BVCopyFromStoreComplete))
                {
                    RemoteService.UnsubscribeBVCopyFromStoreComplete(_BVCopyFromStoreCompleteRcv);
                    _BVCopyFromStoreCompleteRcv.OperationComplete -=
                        new OperationCompleteDelegate(OnBVCopyFromStoreComplete);
                }
            }
        }

        private void OnBVCopyFromStoreComplete(object sender, OperationCompleteEventArgs e)
        {
            if (_BVCopyFromStoreComplete != null)
            {
                lock (_BVCopyFromStoreComplete)
                {
                    if (_BVCopyFromStoreComplete != null)
                    {
                        _BVCopyFromStoreComplete(sender, e);
                    }
                }
            }
        }


        private readonly IOperationCompleteReceiver _ImportBusinessVolumeCompleteRcv = new OperationCompleteReceiver();

        public event OperationCompleteDelegate ImportBusinessVolumeComplete
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_ImportBusinessVolumeComplete);
                _ImportBusinessVolumeComplete += value;
                if (needSubscribe)
                {
                    RemoteService.SubscribeImportBusinessVolumeComplete(_ImportBusinessVolumeCompleteRcv);
                    _ImportBusinessVolumeCompleteRcv.OperationComplete +=
                        new OperationCompleteDelegate(OnImportBusinessVolumeComplete);
                }
            }
            remove
            {
                _ImportBusinessVolumeComplete -= value;
                if (!Utils.IsDelegateSubscribers(_ImportBusinessVolumeComplete))
                {
                    RemoteService.UnsubscribeImportBusinessVolumeComplete(_ImportBusinessVolumeCompleteRcv);
                    _ImportBusinessVolumeCompleteRcv.OperationComplete -=
                        new OperationCompleteDelegate(OnImportBusinessVolumeComplete);
                }
            }
        }

        private void OnImportBusinessVolumeComplete(object sender, OperationCompleteEventArgs e)
        {
            if (_ImportBusinessVolumeComplete != null)
            {
                lock (_ImportBusinessVolumeComplete)
                {
                    if (_ImportBusinessVolumeComplete != null)
                    {
                        _ImportBusinessVolumeComplete(sender, e);
                    }
                }
            }
        }

        private readonly IOperationCompleteReceiver _EstimateWorkingHoursCompleteRcv = new OperationCompleteReceiver();

        public event OperationCompleteDelegate EstimateWorkingHoursComplete
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_EstimateWorkingHoursComplete);
                _EstimateWorkingHoursComplete += value;
                if (needSubscribe)
                {
                    RemoteService.SubscribeEstimateWorkingHoursComplete(_EstimateWorkingHoursCompleteRcv);
                    _EstimateWorkingHoursCompleteRcv.OperationComplete +=
                        new OperationCompleteDelegate(OnEstimateWorkingHoursComplete);
                }
            }
            remove
            {
                _EstimateWorkingHoursComplete -= value;
                if (!Utils.IsDelegateSubscribers(_EstimateWorkingHoursComplete))
                {
                    RemoteService.UnsubscribeEstimateWorkingHoursComplete(_EstimateWorkingHoursCompleteRcv);
                    _EstimateWorkingHoursCompleteRcv.OperationComplete -=
                        new OperationCompleteDelegate(OnEstimateWorkingHoursComplete);
                }
            }
        }

        private void OnEstimateWorkingHoursComplete(object sender, OperationCompleteEventArgs e)
        {
            if (_EstimateWorkingHoursComplete != null)
            {
                lock (_EstimateWorkingHoursComplete)
                {
                    if (_EstimateWorkingHoursComplete != null)
                    {
                        _EstimateWorkingHoursComplete(sender, e);
                    }
                }
            }
        }

        private readonly IOperationCompleteReceiver _EstimateCashDeskPeopleCompleteRcv = new OperationCompleteReceiver();

        public event OperationCompleteDelegate EstimateCashDeskPeopleComplete
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_EstimateCashDeskPeopleComplete);
                _EstimateCashDeskPeopleComplete += value;
                if (needSubscribe)
                {
                    RemoteService.SubscribeEstimateCashDeskPeopleComplete(_EstimateCashDeskPeopleCompleteRcv);
                    _EstimateCashDeskPeopleCompleteRcv.OperationComplete +=
                        new OperationCompleteDelegate(OnEstimateCashDeskPeopleComplete);
                }
            }
            remove
            {
                _EstimateCashDeskPeopleComplete -= value;
                if (!Utils.IsDelegateSubscribers(_EstimateCashDeskPeopleComplete))
                {
                    RemoteService.UnsubscribeEstimateCashDeskPeopleComplete(_EstimateCashDeskPeopleCompleteRcv);
                    _EstimateCashDeskPeopleCompleteRcv.OperationComplete -=
                        new OperationCompleteDelegate(OnEstimateCashDeskPeopleComplete);
                }
            }
        }

        private void OnEstimateCashDeskPeopleComplete(object sender, OperationCompleteEventArgs e)
        {
            if (_EstimateCashDeskPeopleComplete != null)
            {
                lock (_EstimateCashDeskPeopleComplete)
                {
                    if (_EstimateCashDeskPeopleComplete != null)
                    {
                        _EstimateCashDeskPeopleComplete(sender, e);
                    }
                }
            }
        }

        private readonly IMessageInfoReceiver _ImportBusinessVolumeMessageInfoRcv = new MessageInfoReceiver();

        public event MessageInfoDelegate ImportBusinessVolumeMessageInfo
        {
            add
            {
                bool needSubscribe = !Utils.IsDelegateSubscribers(_ImportBusinessVolumeMessageInfo);
                _ImportBusinessVolumeMessageInfo += value;
                if (needSubscribe)
                {
                    RemoteService.SubscribeImportBusinessVolumeMessageInfo(_ImportBusinessVolumeMessageInfoRcv);
                    _ImportBusinessVolumeMessageInfoRcv.Message +=
                        new MessageInfoDelegate(OnImportBusinessVolumeMessageInfo);
                }
            }
            remove
            {
                _ImportBusinessVolumeMessageInfo -= value;
                if (!Utils.IsDelegateSubscribers(_ImportBusinessVolumeMessageInfo))
                {
                    RemoteService.UnsubscribeImportBusinessVolumeMessageInfo(_ImportBusinessVolumeMessageInfoRcv);
                    _ImportBusinessVolumeMessageInfoRcv.Message -=
                        new MessageInfoDelegate(OnImportBusinessVolumeMessageInfo);
                }
            }
        }

        private void OnImportBusinessVolumeMessageInfo(object sender, MessageInfoEventArgs e)
        {
            if (_ImportBusinessVolumeMessageInfo != null)
            {
                lock (_ImportBusinessVolumeMessageInfo)
                {
                    if (_ImportBusinessVolumeMessageInfo != null)
                    {
                        _ImportBusinessVolumeMessageInfo(sender, e);
                    }
                }
            }
        }

        #endregion

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

        #region IStoreService Members

        public IList GetStoreStructure(long storeID)
        {
            return RemoteService.GetStoreStructure(storeID);
        }

        public IList<Store> GetUserStores(long userId)
        {
            return RemoteService.GetUserStores(userId);
        }

    	public Store[] GetStoresByCountryId(long countryid)
    	{
    		return RemoteService.GetStoresByCountryId(countryid);
    	}

    	public short[] GetCalculatedYears()
        {
            return RemoteService.GetCalculatedYears();
        }

        public long GetCountryByStoreId(long storeid)
        {
            return RemoteService.GetCountryByStoreId(storeid);
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
            get { return _StoreToWorldService; }
        }

        public IWorldToHwgrService WorldToHWGRService
        {
            get { return _WorldToHwgrService; }
        }

        public IHwgrToWgrService HwgrToWgrService
        {
            get { return _HwgrToWgrService; }
        }

        public IStoreWorkingTimeService StoreWorkingTimeService
        {
            get { return _storeWorkingTimeService; }
        }

        public IBufferHoursService BufferHoursService
        {
            get { return _bufferHoursService; }
        }

        public IBufferHourAvailableService BufferHourAvailableService
        {
            get { return _bufferHourAvailableService; }
        }

        public IBenchmarkService BenchmarkService
        {
            get { return _benchmarkService; }
        }

        public ITrendCorrectionService TrendCorrectionService
        {
            get { return _trendCorrectionService; }
        }

        public IPersonMinMaxService PersonMinMaxService
        {
            get { return _personMinMaxService; }
        }

        public IStoreAdditionalHourService StoreAdditionalHourService
        {
            get { return _storeAdditionalHourService; }
        }

        public void ImportBusinessVolume(BusinessVolumeType importType)
        {
            RemoteService.ImportBusinessVolume(importType);
        }

        public ServerImportFoldersInfo GetServerImportFoldersInfo()
        {
            return RemoteService.GetServerImportFoldersInfo();
        }

        public long[] GetStoreEmptyOpenCloseTimeList(long userID)
        {
            return RemoteService.GetStoreEmptyOpenCloseTimeList(userID);
        }

        public bool CanEstimateWorkingHours(int year)
        {
            return RemoteService.CanEstimateWorkingHours(year);
        }

        public bool CanEstimateCashDeskPeople(int year)
        {
            return RemoteService.CanEstimateCashDeskPeople(year);
        }

        public IList CanEstimateWorkingHoursInfo(int year)
        {
            return RemoteService.CanEstimateWorkingHoursInfo (year);
        }

        public IList CanEstimateWorkingHoursInfo(long storeID, int year)
        {
            return RemoteService.CanEstimateWorkingHoursInfo(storeID, year);
        
        }
        
        public IList CanEstimateCashDeskPeopleInfo(int year)
        {
            return RemoteService.CanEstimateCashDeskPeopleInfo(year);
        }

        public IList CanEstimateCashDeskPeopleInfo(long storeID, int year)
        {
            return RemoteService.CanEstimateCashDeskPeopleInfo(storeID, year);
        }

        public void EstimateWorkingHours(long storeID, int year)
        {
            RemoteService.EstimateWorkingHours(storeID, year);
        }

        public void EstimateWorkingHours(int year)
        {
            RemoteService.EstimateWorkingHours(year);
        }

        public void EstimateCashDeskPeople(long storeID, int year)
        {
            RemoteService.EstimateCashDeskPeople(storeID, year);
        }

        public void EstimateCashDeskPeople(int year)
        {
            RemoteService.EstimateCashDeskPeople(year);
        }

        public bool CalculateAdditionalHoursForAllTime()
        {
            return RemoteService.CalculateAdditionalHoursForAllTime();
        }

        public bool CalculateStoreAdditionalHours(int year, long storeID)
        {
            return RemoteService.CalculateStoreAdditionalHours(year, storeID);
        }

        public bool CalculateCountryAdditionalHours(int year, long countryID)
        {
            return RemoteService.CalculateCountryAdditionalHours(year, countryID);
        }

        public bool DeleteCalculatedCountryAdditionalHours(int year, long countryID, byte dayOfWeek)
        {
            return RemoteService.DeleteCalculatedCountryAdditionalHours(year, countryID, dayOfWeek);
        }

        public bool DeleteCalculatedCountryAdditionalHours(int year, long storeID)
        {
            return RemoteService.DeleteCalculatedCountryAdditionalHours(year, storeID);
        }

        public List<short> GetYearsWithCountryAdditinalHourByStoreID(long storeID, int fromYear, int toYear)
        {
            return RemoteService.GetYearsWithCountryAdditinalHourByStoreID(storeID, fromYear, toYear);
        }

        public bool EstimationWorkingHoursExists(long storeID, int year)
        {
            return RemoteService.EstimationWorkingHoursExists(storeID, year);
        }

        public bool EstimationWorkingHoursExists(int year)
        {
            return RemoteService.EstimationWorkingHoursExists(year);
        }

        public BVcopyFromStoreResult BVCopyFromStore(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID)
        {
            return RemoteService.BVCopyFromStore(bvType, yearBegin, yearEnd, sourceStoreID, destStoreID);
        }

        public void BVCopyFromStoreAsync(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID)
        {
            RemoteService.BVCopyFromStoreAsync(bvType, yearBegin, yearEnd, sourceStoreID, destStoreID);
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeBVCopyFromStoreComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }
        
        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeBVCopyFromStoreComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeImportBusinessVolumeComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeImportBusinessVolumeComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeEstimateWorkingHoursComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeEstimateWorkingHoursComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeEstimateCashDeskPeopleComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeEstimateCashDeskPeopleComplete(IOperationCompleteReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeImportBusinessVolumeMessageInfo(IMessageInfoReceiver infoReceiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeImportBusinessVolumeMessageInfo(IMessageInfoReceiver infoReceiver)
        {
            throw new ApplicationException("Remote using only method");
        }
        public StoreTimeEnvironment GetStoreTimeEnvironment(long storeID)
        {
            return RemoteService.GetStoreTimeEnvironment(storeID);
        }
        public List<StoreShort> GetStoreShortList()
        {
            return RemoteService.GetStoreShortList();
        }

        public IList BVActualByYearInfoGet(short beforeYear)
        {
            return RemoteService.BVActualByYearInfoGet(beforeYear);
        }

        public IList BVActualByYearInfoGet(short beforeYear, long storeID)
        {
            return RemoteService.BVActualByYearInfoGet(beforeYear, storeID);
        }

        public IList BVTargetByYearInfoGet(short beforeYear)
        {
            return RemoteService.BVTargetByYearInfoGet(beforeYear);        
        }

        public IList BVTargetByYearInfoGet(short beforeYear, long storeID)
        {
            return RemoteService.BVTargetByYearInfoGet(beforeYear, storeID);
        }

        public IList BVCcrYearInfoGet(short beforeYear)
        {
            return RemoteService.BVCcrYearInfoGet(beforeYear);
        }

        public IList BVCcrYearInfoGet(short beforeYear, long storeID)
        {
            return RemoteService.BVCcrYearInfoGet(beforeYear, storeID);
        }

        public bool CopyStructureForEmptyStores()
        {
            return RemoteService.CopyStructureForEmptyStores();
        }

        //public IList EmlpoyeeHolidaysSumInfoGet(long mainStoreID, DateTime beginDate, DateTime endDate, DateTime currDate)
        //{
        //    return RemoteService.EmlpoyeeHolidaysSumInfoGet(mainStoreID, beginDate, endDate, currDate);
        //}

        //public IList EmlpoyeeHolidaysSumInfoByEmployeeIDGet(long employeeID, DateTime beginDate, DateTime endDate, DateTime currDate)
        //{
        //    return RemoteService.EmlpoyeeHolidaysSumInfoByEmployeeIDGet(employeeID,beginDate,endDate,currDate);
        //}

        public DateTime? LastEmployeeWeekTimeRecordingGet(long storeID)
        {
            return RemoteService.LastEmployeeWeekTimeRecordingGet(storeID);
        }
        
        public bool LastEmployeeWeekTimeRecordingUpdate(long storeID, DateTime date)
        {
            return RemoteService.LastEmployeeWeekTimeRecordingUpdate(storeID, date);
        }

        public DateTime? LastEmployeeWeekTimePlanningGet(long storeID)
        {
            return RemoteService.LastEmployeeWeekTimePlanningGet(storeID);
        }

        public bool LastEmployeeWeekTimePlanningUpdate(long storeID, DateTime date)
        {
            return RemoteService.LastEmployeeWeekTimePlanningUpdate(storeID, date);
        }

        public IList GetStoresWithEmployeeWeekTimeRecordingDelay()
        {
            return RemoteService.GetStoresWithEmployeeWeekTimeRecordingDelay();
        }
        public object ExecuteTestMethods(string param)
        {
            return RemoteService.ExecuteTestMethods(param);
        }
        #endregion

        private IStoreService RemoteService
        {
            get { return (IStoreService) _remoteService; }
        }

        public StoreDaysList GetStoreDays(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return RemoteService.GetStoreDays(storeid, aBegin, aEnd);
        }
    }
}
