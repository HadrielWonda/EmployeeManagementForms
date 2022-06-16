using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.Import;
using Baumax.Contract.PlanningAndRecording;
using Baumax.Contract.QueryResult;

namespace Baumax.Contract.Interfaces
{
    public interface IStoreService : IBaseService<Store>
    {
        IWorldService WorldService { get; }
        IHWGRService HWGRService { get; }
        IWGRService WGRService { get; }
        IStoreToWorldService StoreToWorldService { get; }
        IWorldToHwgrService WorldToHWGRService { get; }
        IHwgrToWgrService HwgrToWgrService { get; }
        IStoreWorkingTimeService StoreWorkingTimeService { get; }
        IBufferHoursService BufferHoursService { get; }
        IBufferHourAvailableService BufferHourAvailableService { get; }
        IBenchmarkService BenchmarkService { get; }
        ITrendCorrectionService TrendCorrectionService { get; }
        IPersonMinMaxService PersonMinMaxService { get; }
        IStoreAdditionalHourService StoreAdditionalHourService { get; }
        
		IList GetStoreStructure(long storeID);
        short[] GetCalculatedYears();
        IList<Store> GetUserStores(long userId);
        void SubscribeImportBusinessVolumeComplete(IOperationCompleteReceiver receiver);
        void UnsubscribeImportBusinessVolumeComplete(IOperationCompleteReceiver receiver);
        void SubscribeImportBusinessVolumeMessageInfo(IMessageInfoReceiver infoReceiver);
        void UnsubscribeImportBusinessVolumeMessageInfo(IMessageInfoReceiver infoReceiver);
        StoreDaysList GetStoreDays(long storeid, DateTime aBegin, DateTime aEnd);
        void ImportBusinessVolume(BusinessVolumeType importType);
        ServerImportFoldersInfo GetServerImportFoldersInfo();
        long[] GetStoreEmptyOpenCloseTimeList(long userID);
        bool CanEstimateWorkingHours(int year);
        bool CanEstimateCashDeskPeople(int year);
        void SubscribeEstimateWorkingHoursComplete(IOperationCompleteReceiver receiver);
        void UnsubscribeEstimateWorkingHoursComplete(IOperationCompleteReceiver receiver);
        void SubscribeEstimateCashDeskPeopleComplete(IOperationCompleteReceiver receiver);
        void UnsubscribeEstimateCashDeskPeopleComplete(IOperationCompleteReceiver receiver);
        long GetCountryByStoreId(long storeid);
        bool CalculateAdditionalHoursForAllTime();
        bool CalculateStoreAdditionalHours(int year, long storeId);
        bool CalculateCountryAdditionalHours(int year, long countryID);
        bool DeleteCalculatedCountryAdditionalHours(int year, long countryID, byte dayOfWeek);
        bool DeleteCalculatedCountryAdditionalHours(int year, long storeID);
        List<short> GetYearsWithCountryAdditinalHourByStoreID(long storeID, int fromYear, int toYear);

		Store[] GetStoresByCountryId(long countryid);
        StoreTimeEnvironment GetStoreTimeEnvironment(long storeID);

        void EstimateCashDeskPeople(long storeID, int year);
        void EstimateCashDeskPeople(int year);
        void EstimateWorkingHours(long storeID, int year);
        void EstimateWorkingHours(int year);
        bool EstimationWorkingHoursExists(long storeID, int year);
        bool EstimationWorkingHoursExists(int year);
        IList CanEstimateWorkingHoursInfo(int year);
        IList CanEstimateWorkingHoursInfo(long storeID, int year);
        IList CanEstimateCashDeskPeopleInfo(int year);
        IList CanEstimateCashDeskPeopleInfo(long storeID, int year);

        event MessageInfoDelegate ImportBusinessVolumeMessageInfo;
        event OperationCompleteDelegate ImportBusinessVolumeComplete;
        event OperationCompleteDelegate EstimateWorkingHoursComplete;
        event OperationCompleteDelegate EstimateCashDeskPeopleComplete;

        List<StoreShort> GetStoreShortList();

        IList BVActualByYearInfoGet(short beforeYear);
        IList BVActualByYearInfoGet(short beforeYear, long storeID);
        IList BVTargetByYearInfoGet(short beforeYear);
        IList BVTargetByYearInfoGet(short beforeYear, long storeID);
        IList BVCcrYearInfoGet(short beforeYear);
        IList BVCcrYearInfoGet(short beforeYear, long storeID);

        BVcopyFromStoreResult BVCopyFromStore(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID);

        void BVCopyFromStoreAsync(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID);
        event OperationCompleteDelegate BVCopyFromStoreComplete;
        void SubscribeBVCopyFromStoreComplete(IOperationCompleteReceiver receiver);
        void UnsubscribeBVCopyFromStoreComplete(IOperationCompleteReceiver receiverr);

        bool CopyStructureForEmptyStores();
        //List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoGet(long mainStoreID, DateTime beginDate, DateTime endDate, DateTime currDate);
        //EmlpoyeeHolidaysSumDays EmlpoyeeHolidaysSumInfoByEmployeeIDGet(long employeeID, DateTime beginDate, DateTime endDate, DateTime currDate);

        DateTime? LastEmployeeWeekTimeRecordingGet(long storeID);
        bool LastEmployeeWeekTimeRecordingUpdate(long storeID, DateTime date);
        IList GetStoresWithEmployeeWeekTimeRecordingDelay();
        DateTime? LastEmployeeWeekTimePlanningGet(long storeID);
        bool LastEmployeeWeekTimePlanningUpdate(long storeID, DateTime date);

        object ExecuteTestMethods(string param);

    }

    //public interface IStoreServiceHelper
    //{
    //    long GetCountryByStoreId(long storeid);
    //}
}
