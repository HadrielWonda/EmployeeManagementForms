using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.Dao
{
    public interface IStoreDao : IDao<Store>
    {
		IList GetStoreStructure(long storeID);
        IList GetUserStores(long userId);
        short[] GetCalculatedYears();
        long GetCountryByStoreId(long storeid);
        Store[] GetStoresByCountryId(long countryid);

        event MessageInfoDelegate ImportBusinessVolumeMessageInfo;
        ImportBusinessValuesResult ImportBusinessVolume(BusinessVolumeType importType);
        ServerImportFoldersInfo GetServerImportFoldersInfo();
        long[] GetStoreEmptyOpenCloseTimeList(long userID);
        bool CanEstimateWorkingHours(int year);
        bool CanEstimateCashDeskPeople(int year);
        bool EstimateWorkingHours(long storeID, int year);
        bool EstimateWorkingHours(int year);
        bool EstimateCashDeskPeople(long storeID, int year);
        bool EstimateCashDeskPeople(int year);
        bool EstimationWorkingHoursExists(long storeID, int year);
        bool EstimationWorkingHoursExists(int year);
        IList CanEstimateWorkingHoursInfo(int year);
        IList CanEstimateWorkingHoursInfo(long storeID, int year);
        IList CanEstimateCashDeskPeopleInfo(int year);
        IList CanEstimateCashDeskPeopleInfo(long storeID, int year);
        IList BVByYearInfoGet(BusinessVolumeType bvType, short beforeYear, long storeID);
        BVcopyFromStoreResult BVCopyFromStore(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID);
        List<StoreShort> GetStoreShortList();
        bool CopyStructureForEmptyStores();
        List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoGet(long mainStoreID, DateTime beginDate, DateTime endDate, DateTime currDate);
        List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoByEmployeeIDGet(long employeeID, DateTime beginDate, DateTime endDate, DateTime currDate);
        List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoByCountryIDGet(long countryID, DateTime beginDate, DateTime endDate, DateTime currDate);
        
        DateTime? LastEmployeeWeekTimeRecordingGet(long storeID);
        bool LastEmployeeWeekTimeRecordingUpdate(long storeID, DateTime date);
        IList GetStoresWithEmployeeWeekTimeRecordingDelay();

        IList BVActualByYearInfoGet(short beforeYear, long storeID);
        DateTime? LastEmployeeWeekTimePlanningGet(long storeID);
        bool LastEmployeeWeekTimePlanningUpdate(long storeID, DateTime date);

        List<Store> LoadAll();
    }
}
