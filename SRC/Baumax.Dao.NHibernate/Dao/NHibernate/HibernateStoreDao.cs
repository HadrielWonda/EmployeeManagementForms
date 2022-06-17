using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Import.Util;
using NHibernate;
using Rsdn.Framework.Data.Mapping;
using Baumax.Cache.QueryCacheClasses;

namespace Baumax.Dao.NHibernate
{
    public class HibernateStoreDao : HibernateDao<Store>, IStoreDao
    {
        const long NoData = -1;
        QueryCacheBVActualByYearInfo _QueryCacheBVActualByYearInfo;
        protected override PermittedIDsResult CreatePermittedIDFilter(List<string> pNames, List<object> pValues,
                                                                      bool bForReading, out string filterHQL, User user)
        {
            Debug.Assert((pNames != null) && (pValues != null),
                         "CreatePermittedIDFilter: impossible to store parameters");

            User u = user;
            Debug.Assert(u != null, "CreatePermittedIDFilter: user is null");
            if (!u.UserRoleID.HasValue)
            {
                filterHQL = null;
                return PermittedIDsResult.None;
            }

            StringBuilder sFrom = new StringBuilder();
            StringBuilder sWhere = new StringBuilder();
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (Store).Name);
            long? languageID = getCurrentLanguageID();
            if (languageID.HasValue)
            {
                sWhere.Append(" WHERE filtered.LanguageID = :internal_dao_languageid ");
                pNames.Add("internal_dao_languageid");
                pValues.Add(languageID.Value);
            }

            PermittedIDsResult result;
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
            switch (role)
            {
                case UserRoleId.GlobalAdmin:
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.Controlling:
                    if (bForReading)
                    {
                        goto case UserRoleId.CountryAdmin;
                    }
                    else
                    {
                        result = PermittedIDsResult.None;
                    }
                    break;
                case UserRoleId.CountryAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(", {0} internal_dao_uc, {1} internal_dao_c, {2} internal_dao_r",
                                       typeof (UserCountry).Name, typeof (Country).Name, typeof (Region).Name);
                    sWhere.Append(
                        @"internal_dao_uc.User.ID = :internal_dao_userID
                      AND internal_dao_uc.CountryID = internal_dao_c.ID
                      AND internal_dao_c.ID = internal_dao_r.CountryID
                      AND internal_dao_r.ID = filtered.RegionID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.RegionAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(", {0} internal_dao_ur, {1} internal_dao_r", typeof (UserRegion).Name,
                                       typeof (Region).Name);
                    sWhere.Append(
                        @"internal_dao_ur.User.ID = :internal_dao_userID
                      AND internal_dao_ur.RegionID = internal_dao_r.ID
                      AND internal_dao_r.ID = filtered.RegionID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.StoreAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(", {0} internal_dao_us", typeof (UserStore).Name);
                    sWhere.Append(
                        @"internal_dao_us.User.ID = :internal_dao_userID
                      AND internal_dao_us.StoreID = filtered.ID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                default:
                    throw new Exception(string.Format("unknown user role : {0}", role.ToString()));
            }

            if (sWhere.Length == 0)
            {
                filterHQL = null;
            }
            else
            {
                filterHQL = sFrom.Append(sWhere).ToString();
            }
            return result;
            // suppose, we should never call base
            //return base.CreatePermittedIDFilter();
        }

        public IList GetStoreStructure(long storeID)
        {
            List<StoreStructure> storeStructureList = new List<StoreStructure>();
            string query = "exec spStoreStructureGet :storeId, :date";

            HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        session.CreateSQLQuery(query)
                            .AddEntity(typeof (StoreStructure))
                            .SetParameter("storeId", storeID)
                            .SetParameter("date", DateTime.Now.ToString("yyyMMdd"))
                            .List(storeStructureList);
                        return null;
                    }
                );

            return storeStructureList;
        }

        public long[] GetStoreEmptyOpenCloseTimeList(long userID)
        {
            string query =
                @"exec spStoreIDListEmptyOpenCloseTime :userID";
            List<long> result = new List<long>();

            HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        session.CreateSQLQuery(query)
                            .AddScalar("StoreID", NHibernateUtil.Int64)
                            .SetParameter("userID", userID)
                            .List(result);
                        return null;
                    }
                );

            return result.ToArray();
        }

        public IList GetUserStores(long userId)
        {
            return FindByNamedParam("UserStore us", "us.User.ID = :userID and entity.ID = us.StoreID", null, "userID",
                                    userId);
        }

        public short[] GetCalculatedYears()
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = "select [Year] from [CalculatedYear] order by [Year]";
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    List<short> list = new List<short>();
                    while (reader.Read())
                    {
                        list.Add(reader.GetInt16(0));
                    }
                    return list.ToArray();
                }
            }
        }

        public long GetCountryByStoreId(long storeid)
        {
            string query =
                @"SELECT entityregion.CountryID FROM Region entityregion,Store entitystore WHERE entitystore.ID={0} AND entitystore.RegionID=entityregion.ID ";
            query = String.Format(query, storeid);
            IList lst = HibernateTemplate.FindByNamedParam(query, new string[0], new object[0]);
            //IList lst = Session.CreateSQLQuery(query).//List();

            if (lst == null || lst.Count > 1)
            {
                throw new Exception("Country for store not found or return grater than one");
            }

            return (long) lst[0];
        }

        public Store[] GetStoresByCountryId(long countryid)
        {
            string query =
                @"SELECT entitystore FROM Region entityregion, Store entitystore WHERE entityregion.CountryID={0} AND entityregion.ID=entitystore.RegionID";
            query = String.Format(query, countryid);
            IList lst = HibernateTemplate.FindByNamedParam(query, new string[0], new object[0]);
            //IList lst = Session.CreateSQLQuery(query).//List();
            Store[] result = null;
            if (lst != null && lst.Count > 0)
            {
                result = new Store[lst.Count];
				lst.CopyTo(result, 0);
            }
            
            return result;
        }

        public event MessageInfoDelegate ImportBusinessVolumeMessageInfo;
/*
        public ImportBusinessValuesResult ImportBusinessVolume(BusinessVolumeType importType)
        {
            string folderName = ServerEnvironment.ImportSettings.SourceFolder;
            string[] files = ImportUtil.GetBusinessVolumeFilesList(folderName, importType);

            ImportBusinessValuesResult result = new ImportBusinessValuesResult();
            if (files.Length > 0)
            {
                if(ImportBusinessVolumeMessageInfo != null)
                {
                    ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(files));
                }
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandTimeout = 0;
                    command.CommandText = "spBusinessVolume_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);

                    SqlParameter xmlDocument = new SqlParameter("@xmlDocument", SqlDbType.NText);
                    xmlDocument.Value = ImportUtil.GetFilesListInXml(files);
                    command.Parameters.Add(xmlDocument);

                    SqlParameter formatFile = new SqlParameter("@formatFile", SqlDbType.NVarChar, 255);
                    formatFile.Value = ImportUtil.GetFormatFile(folderName, importType);
                    command.Parameters.Add(formatFile);

                    SqlParameter tableName = new SqlParameter("@tableName", SqlDbType.NVarChar, 30);
                    tableName.Value = ImportUtil.GetTableName(importType);
                    command.Parameters.Add(tableName);

                    command.ExecuteNonQuery();
                    result.Success = ((int) importResult.Value > 0);
                    if (result.Success)
                    {
                        ImportUtil.MoveFilesInImportedFolder(ServerEnvironment.ImportSettings.ImportedFolder, files);
                        command.Parameters.Clear();
                        command.CommandText = "spBusinessVolume_ConvertData";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(tableName);
                        command.ExecuteNonQuery();
                        result.Data = files.Length;
                    }
                }
            }
            else
            {
                result.Success = true;
                result.Data = 0;
            }
            return result;
        }
*/
        public ImportBusinessValuesResult ImportBusinessVolume(BusinessVolumeType importType)
        {
            int importSuccessCount = 0;
            string folderName = ServerEnvironment.ImportSettings.SourceFolder;
            string[] files = ImportUtil.GetBusinessVolumeFilesList(folderName, importType);

            ImportBusinessValuesResult result = new ImportBusinessValuesResult();
            result.BusinessVolumeType = importType;
            if (files.Length > 0)
            {
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;

                    SqlParameter importFile = new SqlParameter("@importFile", SqlDbType.NVarChar, 255);

                    SqlParameter errorFile = new SqlParameter("@errorFile", SqlDbType.NVarChar, 255);

                    SqlParameter formatFile = new SqlParameter("@formatFile", SqlDbType.NVarChar, 255);
                    formatFile.Value = ImportUtil.GetFormatFile(folderName, importType);

                    SqlParameter tableName = new SqlParameter("@tableName", SqlDbType.NVarChar, 30);
                    tableName.Value = ImportUtil.GetTableName(importType);

                    for (int i = 0; i < files.Length; i++)
                    {
                        if (ImportBusinessVolumeMessageInfo != null)
                            ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(new MessageStringInfo(importType, files[i])));

                        command.CommandText = "spBusinessVolume_ImportData";
                        command.Parameters.Clear();
                        command.Parameters.Add(importResult);
                        
                        importFile.Value = files[i];
                        command.Parameters.Add(importFile);

                        errorFile.Value = ImportUtil.GetErrorFileName(files[i]);
                        command.Parameters.Add(errorFile);

                        command.Parameters.Add(formatFile);
                        command.Parameters.Add(tableName);

                        command.ExecuteNonQuery();
                        result.Success = ((int)importResult.Value > 0);
                        if (result.Success)
                        {
                            importSuccessCount++;
                            ImportUtil.MoveFilesInFolder(ServerEnvironment.ImportSettings.ImportedFolder, new string[] { files[i] });
                            if (ImportBusinessVolumeMessageInfo != null)
                                ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(new MessageStringInfo(importType,"bvImportOK", false, true)));
                        }
                        else
                        {
                            ImportUtil.MoveFilesInFolder(ServerEnvironment.ImportSettings.ImportErrorsFolder, ImportUtil.GetFilesWithErrorsForFile(files[i]));
                            if (ImportBusinessVolumeMessageInfo != null)
                                ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(new MessageStringInfo(importType, "bvImportError", false, true)));
                        }
                    }
                    if (importSuccessCount != files.Length)
                        if (ImportBusinessVolumeMessageInfo != null)
                        {
                            MessageStringInfo messageStringInfo = new MessageStringInfo(importType, "bvAboutErrorFilesInfo");
                            messageStringInfo.LocalizeKey = true;
                            messageStringInfo.MessageParams = new string[] { ServerEnvironment.ImportSettings.ImportErrorsFolder };
                            ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(messageStringInfo));
                        }
                    if (importSuccessCount > 0)
                    {
                        if (ImportBusinessVolumeMessageInfo != null)
                        {
                            ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(new MessageStringInfo(importType, "")));
                            MessageStringInfo messageStringInfo = new MessageStringInfo(importType, "bvDataConvertStart");
                            messageStringInfo.LocalizeKey = true;
                            ImportBusinessVolumeMessageInfo(null, new MessageInfoEventArgs(messageStringInfo));
                        }
                        command.Parameters.Clear();
                        command.CommandText = "spBusinessVolume_ConvertData";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(tableName);
                        command.ExecuteNonQuery();

                        ReloadDataIntoCache(importType);
                    }

                    result.Success = importSuccessCount == files.Length;
                    if (result.Success)
                        result.FilesCount = files.Length;
                }
            }
            else
            {
                result.Success = true;
                result.FilesCount = 0;
            }
            return result;
        }

        public ServerImportFoldersInfo GetServerImportFoldersInfo()
        {
            return new ServerImportFoldersInfo(ServerEnvironment.ImportSettings.SourceFolder,
                                               ServerEnvironment.ImportSettings.ImportedFolder);
        }

        private bool Estimate(EstimateType estimateType, int year, long storeID)
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandTimeout = 0;
                command.CommandType = CommandType.StoredProcedure;
                switch (estimateType)
                {
                    case EstimateType.CashDeskPeople:
                        command.CommandText = "spBusinessVolume_EstimateCashDeskPeople";
                        break;
                    case EstimateType.WorkingHours:
                        command.CommandText = "spBusinessVolume_EstimateWorkingHours";
                        break;
                    default:
                        goto case EstimateType.CashDeskPeople;
                }
                SqlParameter paramStoreID = new SqlParameter("@StoreID", SqlDbType.BigInt, 8);
                if (storeID < 0)
                    paramStoreID.Value = DBNull.Value;
                else
                    paramStoreID.Value = storeID;
                command.Parameters.Add(paramStoreID);

                SqlParameter estimateYear = new SqlParameter("@EstimateYear", SqlDbType.SmallInt, 2);
                estimateYear.Value = year;
                command.Parameters.Add(estimateYear);

                SqlParameter result = new SqlParameter("@result", SqlDbType.Int, 4);
                result.Direction = ParameterDirection.Output;
                command.Parameters.Add(result);

                command.ExecuteNonQuery();
                return ((int)result.Value) > 0;
            }
        }

        public bool EstimateCashDeskPeople(int year)
        {
            return EstimateCashDeskPeople(SharedConsts.CalculateAll, year);
        }

        public bool EstimateCashDeskPeople(long storeID, int year)
        {
            return Estimate(EstimateType.CashDeskPeople, year, storeID);
        }

        public bool EstimateWorkingHours(long storeID, int year)
        {
            return Estimate(EstimateType.WorkingHours, year, storeID);
        }

        public bool EstimateWorkingHours(int year)
        {
            return EstimateWorkingHours(SharedConsts.CalculateAll, year);
        }

        public bool EstimationWorkingHoursExists(long storeID, int year)
        {
            //spBusinessVolume_EstimationWorkingHoursExists
            using (IDbCommand command = CreateCommand())
            {
                command.CommandTimeout = 0;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spBusinessVolume_EstimationWorkingHoursExists";
                SqlParameter paramStoreID = new SqlParameter("@StoreID", SqlDbType.BigInt, 8);
                if (storeID < 0)
                    paramStoreID.Value = DBNull.Value;
                else
                    paramStoreID.Value = storeID;
                command.Parameters.Add(paramStoreID);

                SqlParameter estimateYear = new SqlParameter("@Year", SqlDbType.SmallInt, 2);
                estimateYear.Value = year;
                command.Parameters.Add(estimateYear);

                SqlParameter result = new SqlParameter("@result", SqlDbType.Int, 4);
                result.Direction = ParameterDirection.Output;
                command.Parameters.Add(result);

                command.ExecuteNonQuery();
                return ((int)result.Value) > 0;
            }
        }

        public bool EstimationWorkingHoursExists(int year)
        {
            return EstimationWorkingHoursExists(SharedConsts.CalculateAll,year);
        }

        public IList CanEstimateWorkingHoursInfo(int year)
        {
            return CanEstimateWorkingHoursInfo(SharedConsts.CalculateAll,year);
        }

        public IList CanEstimateWorkingHoursInfo(long storeID, int year)
        {
            List<CanEstimateWorkingHoursResult> result;
            string query = string.Format("exec spBusinessVolume_CanEstimateWorkingHours {0}, {1}", year, storeID);
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<CanEstimateWorkingHoursResult>(reader);
            }
            return result;
        }

        public IList CanEstimateCashDeskPeopleInfo(int year)
        {
            return CanEstimateCashDeskPeopleInfo(SharedConsts.CalculateAll, year);
        }

        public IList CanEstimateCashDeskPeopleInfo(long storeID, int year)
        {
            List<CanEstimateCashDeskPeopleResult> result;
            string query = string.Format("exec spBusinessVolume_CanEstimateCashDeskPeople {0}, {1}", year, storeID);
            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<CanEstimateCashDeskPeopleResult>(reader);
            }
            return result;
        }

        public bool CanEstimateWorkingHours(int year)
        {
            bool result= true;
            List<CanEstimateWorkingHoursResult> list= (List<CanEstimateWorkingHoursResult>)CanEstimateWorkingHoursInfo(year);
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Result)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool CanEstimateCashDeskPeople(int year)
        {
            bool result = true;
            List<CanEstimateCashDeskPeopleResult> list = (List<CanEstimateCashDeskPeopleResult>)CanEstimateCashDeskPeopleInfo(year);
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Result)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public IList BVByYearInfoGet(BusinessVolumeType bvType, short beforeYear, long storeID)
        {
            IList result;
            string procName;
            switch (bvType)
            {
                case BusinessVolumeType.Actual:
                    procName = "spBV_ActualStoreYearGet";
                    break;
                case BusinessVolumeType.Target:
                    procName = "spBV_TargetStoreYearGet";
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    procName = "spBV_CRRStoreYearGet";
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
            string query;
            if (storeID == SharedConsts.CalculateAll)
                query = string.Format("exec {0} {1}", procName, beforeYear);
            else
                query = string.Format("exec {0} {1}, {2}", procName, beforeYear, storeID);
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                command.CommandTimeout = 0;
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    switch (bvType)
                    {
                        case BusinessVolumeType.Actual:
                            result = Map.ToList<BVActualByYearInfo>(reader);
                            break;
                        case BusinessVolumeType.Target:
                            result = Map.ToList<BVTargetByYearInfo>(reader);
                            break;
                        case BusinessVolumeType.CashRegisterReceipt:
                            result = Map.ToList<BVCcrByYearInfo>(reader);
                            break;
                        default:
                            goto case BusinessVolumeType.Actual;
                    }
                }
                return result;
            }
        }


        public IList BVActualByYearInfoGet (short beforeYear, long storeID)
        {
            IList result;
            if (storeID == SharedConsts.CalculateAll)
                result = _QueryCacheBVActualByYearInfo.GetData(beforeYear);
            else
                result= _QueryCacheBVActualByYearInfo.GetData(beforeYear,storeID);
            return result;
        }

        public BVcopyFromStoreResult BVCopyFromStore(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID)
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandTimeout = 0;
                switch (bvType)
                {
                    case BusinessVolumeType.Actual:
                        command.CommandText = "spBV_ActualAddFromStore";
                        break;
                    case BusinessVolumeType.Target:
                        command.CommandText = "spBV_TargetAddFromStore";
                        break;
                    case BusinessVolumeType.CashRegisterReceipt:
                        command.CommandText = "spBV_CRRAddFromStore";
                        break;
                    default:
                        goto case BusinessVolumeType.Actual;
                }
                command.CommandType = CommandType.StoredProcedure;
                
                SqlParameter returnParam = new SqlParameter("Return", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnParam);

                SqlParameter yearBeginParam = new SqlParameter("@YearBegin", SqlDbType.SmallInt, 4);
                yearBeginParam.Direction = ParameterDirection.Input;
                yearBeginParam.Value = yearBegin;
                command.Parameters.Add(yearBeginParam);

                SqlParameter yearEndParam = new SqlParameter("@YearEnd", SqlDbType.SmallInt, 4);
                yearEndParam.Direction = ParameterDirection.Input;
                yearEndParam.Value = yearEnd;
                command.Parameters.Add(yearEndParam);

                SqlParameter storeIDParam = new SqlParameter("@StoreID", SqlDbType.BigInt, 8);
                storeIDParam.Direction = ParameterDirection.Input;
                storeIDParam.Value = sourceStoreID;
                command.Parameters.Add(storeIDParam);

                SqlParameter newStoreIDParam = new SqlParameter("@NewStoreID", SqlDbType.BigInt);
                newStoreIDParam.Direction = ParameterDirection.Input;
                newStoreIDParam.Value = destStoreID;
                command.Parameters.Add(newStoreIDParam);

                command.ExecuteNonQuery();

                BVcopyFromStoreResult result = (BVcopyFromStoreResult)returnParam.Value;
                if (result == BVcopyFromStoreResult.Success)
                    AddDataIntoCache(bvType,yearBegin,yearEnd,sourceStoreID,destStoreID);

                return result;
            }
        }

        public List<StoreShort> GetStoreShortList()
        {
            IList list = HibernateTemplate.Find(
                @"SELECT entity.ID, entity.Name, entity.RegionID, r.CountryID
                    FROM Store entity, Region r
                   WHERE entity.RegionID = r.ID");
            if( (list == null) || (list.Count == 0) )
            {
                return null;
            }
            List<StoreShort> result = new List<StoreShort>();
            foreach (object[] item in list)
            {
                result.Add(new StoreShort((long)item[0], (string)item[1], (long)item[2], (long)item[3]));
            }
            return result;
        }
        /// <summary>
        ///  Load all store - don't apply permission filters 
        /// </summary>
        /// <returns></returns>
        public List<Store> LoadAll()
        {
            return GetTypedListFromIList(HibernateTemplate.Find(@"SELECT entity FROM Store entity"));
        }
        public bool CopyStructureForEmptyStores()
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandTimeout = 0;
                command.CommandText = "spStoreStructureCopyForEmpties";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter returnParam = new SqlParameter("Return", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnParam);

                command.ExecuteNonQuery();

                return (int)returnParam.Value == 0;
            }

        }

        public List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoGet(long mainStoreID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            return EmlpoyeeHolidaysSumInfoGet(mainStoreID, NoData, NoData, beginDate, endDate, currDate);
        }

        public List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoByEmployeeIDGet(long employeeID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            return EmlpoyeeHolidaysSumInfoGet(NoData, employeeID, NoData, beginDate, endDate, currDate);
        }

        public List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoByCountryIDGet(long countryID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            return EmlpoyeeHolidaysSumInfoGet(NoData, NoData, countryID, beginDate, endDate, currDate);
        }

        private List<EmlpoyeeHolidaysSumDays> EmlpoyeeHolidaysSumInfoGet(long mainStoreID, long employeeID, long countryID, DateTime beginDate, DateTime endDate, DateTime currDate)
        {
            List<EmlpoyeeHolidaysSumInfo> result;
            string query;

            if (employeeID == NoData)
                query = string.Format("exec spEmlpoyeeHolidaysSumInfoGet {0} , '{1}' , '{2}' , '{3}'", mainStoreID, beginDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"), currDate.ToString("yyyyMMdd"));
            else if (countryID == NoData)
                query = string.Format("exec spEmlpoyeeHolidaysSumInfoGet {0} , '{1}' , '{2}' , '{3}', {4}", "NULL", beginDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"),currDate.ToString ("yyyyMMdd"),employeeID);
            else
                query = string.Format("exec spEmlpoyeeHolidaysSumInfoGet {0} , '{1}' , '{2}' , '{3}', {4}, {5}", "NULL", beginDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"), currDate.ToString("yyyyMMdd"), "NULL", countryID);

            using (IDataReader reader = getDataReader(query))
            {
                result = Map.ToList<EmlpoyeeHolidaysSumInfo>(reader);
            }
            return result == null ? null : result.ConvertAll<EmlpoyeeHolidaysSumDays>(
                delegate (EmlpoyeeHolidaysSumInfo info)
                {
                    return new EmlpoyeeHolidaysSumDays(info);
                });
        }

        private DateTime? LastEmployeeWeekTimeRecPlanGet(EmployeeWeekTimeType employeeWeekTime, long storeID)
        {
            string spName;
            string resName;
            switch (employeeWeekTime)
            {
                case EmployeeWeekTimeType.Recording:
                    spName = "spStore_LastEmployeeWTRGet";
                    resName = "LastEmployeeWTR";
                    break;
                case EmployeeWeekTimeType.Planning:
                    spName = "spStore_LastEmployeeWTPGet";
                    resName = "LastEmployeeWTP";
                    break;
                default:
                    goto case EmployeeWeekTimeType.Recording;
            }
            
            DateTime? result;
            string query = string.Format("exec {0} :storeID",spName);
            result = (DateTime?)HibernateTemplate.Execute(
                    delegate(ISession session)
                    {
                        return session.CreateSQLQuery(query)
                            .AddScalar(resName, NHibernateUtil.DateTime)
                            .SetParameter("storeID", storeID)
                            .UniqueResult<DateTime?>();
                    }
                );
            return result;
            
        }

        private bool LastEmployeeWeekTimeRecPlanUpdate(EmployeeWeekTimeType employeeWeekTime, long storeID, DateTime date)
        {
            string spName;
            switch (employeeWeekTime)
            {
                case EmployeeWeekTimeType.Recording:
                    spName = "spStore_LastEmployeeWTRUpdate";
                    break;
                case EmployeeWeekTimeType.Planning:
                    spName = "spStore_LastEmployeeWTPUpdate";
                    break;
                default:
                    goto case EmployeeWeekTimeType.Recording;
            }

            int result;
            string query =
string.Format(
@"declare @res int
exec @res = {0} {1}, '{2}'
select @res result",spName, storeID, date.ToString("yyyyMMdd"));
            result = (int)HibernateTemplate.Execute(
                    delegate(ISession session)
                    {
                        return session.CreateSQLQuery(query)
                            .AddScalar("result", NHibernateUtil.Int32)
                            .UniqueResult<int>();
                    }
                );
            return result == 0;
        }

        public DateTime? LastEmployeeWeekTimeRecordingGet(long storeID)
        {
            return LastEmployeeWeekTimeRecPlanGet(EmployeeWeekTimeType.Recording, storeID);
        }

        public bool LastEmployeeWeekTimeRecordingUpdate (long storeID, DateTime date)
        {
            return LastEmployeeWeekTimeRecPlanUpdate(EmployeeWeekTimeType.Recording, storeID, date);
        }

        public DateTime? LastEmployeeWeekTimePlanningGet(long storeID)
        {
            return LastEmployeeWeekTimeRecPlanGet(EmployeeWeekTimeType.Planning, storeID);
        }

        public bool LastEmployeeWeekTimePlanningUpdate(long storeID, DateTime date)
        {
            return LastEmployeeWeekTimeRecPlanUpdate(EmployeeWeekTimeType.Planning, storeID, date);
        }

        public IList GetStoresWithEmployeeWeekTimeRecordingDelay()
        {
            List<StoreDelayInfo> result = new List<StoreDelayInfo>();
            string query = "exec spStore_LastEmployeeWTRWarning";

            HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    session.CreateSQLQuery(query)
                        .AddEntity(typeof(StoreDelayInfo))
                        .List(result);
                    return null;
                }
                );

            return result;
        }

        public override void AfterPropertiesSet()
        {
            base.AfterPropertiesSet();
            _QueryCacheBVActualByYearInfo = new QueryCacheBVActualByYearInfo("exec spBV_ActualStoreYearGet 2079", this);
        }

        private void AddDataIntoCache(BusinessVolumeType bvType, short yearBegin, short yearEnd, long sourceStoreID, long destStoreID)
        {
            switch (bvType)
            {
                case BusinessVolumeType.Actual:
                    _QueryCacheBVActualByYearInfo.CopyData(yearBegin, yearEnd, sourceStoreID, destStoreID);
                    break;
                case BusinessVolumeType.Target:
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
        }

        private void ReloadDataIntoCache(BusinessVolumeType bvType)
        {
            switch (bvType)
            {
                case BusinessVolumeType.Actual:
                    _QueryCacheBVActualByYearInfo.ReloadCache();
                    break;
                case BusinessVolumeType.Target:
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
        
        }

        enum EstimateType { CashDeskPeople, WorkingHours }
        enum EmployeeWeekTimeType {Recording, Planning }
    }

}
