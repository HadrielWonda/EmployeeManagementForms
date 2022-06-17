using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateWorkingModelDao : HibernateDao<WorkingModel>, IWorkingModelDao
    {
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (WorkingModel).Name);

            PermittedIDsResult result;
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
            switch (role)
            {
                case UserRoleId.GlobalAdmin:
                    result = PermittedIDsResult.All;
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
                    sFrom.AppendFormat(", {0} internal_dao_uc",
                                       typeof (UserCountry).Name);
                    sWhere.Append(
                        @"internal_dao_uc.User.ID = :internal_dao_userID
                      AND internal_dao_uc.CountryID = filtered.CountryID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.RegionAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sFrom.AppendFormat(", {0} internal_dao_r, {1} internal_dao_ur",
                                           typeof (Region).Name, typeof (UserRegion).Name);
                        sWhere.AppendFormat(
                            @"internal_dao_ur.User.ID = :internal_dao_userID
                      AND internal_dao_ur.RegionID = internal_dao_r.ID
                      AND internal_dao_r.CountryID = filtered.CountryID");
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        result = PermittedIDsResult.None;
                    }
                    break;
                case UserRoleId.StoreAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sFrom.AppendFormat(", {0} internal_dao_s, {1} internal_dao_r, {2} internal_dao_us",
                                           typeof (Store).Name, typeof (Region).Name, typeof (UserStore).Name);
                        sWhere.AppendFormat(
                            @"internal_dao_us.User.ID = :internal_dao_userID
                      AND internal_dao_us.StoreID = internal_dao_s.ID
                      AND internal_dao_s.RegionID = internal_dao_r.ID
                      AND internal_dao_r.CountryID = filtered.CountryID");
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        result = PermittedIDsResult.None;
                    }
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

        #region IWorkingModelDao Members

        public IList GetCountryWorkingModel(long countryID)
        {
            return GetCountryModel(countryID,WorkingModelType.WorkingModel);
        }

        public IList GetCountryLunchModel(long countryID)
        {
            return GetCountryModel(countryID, WorkingModelType.LunchModel);
        }

        public IList GetCountryLunchModel(long countryID, DateTime aBegin, DateTime aEnd)
        {
            IList list =  GetCountryLunchModel(countryID);
            return SetFilter(list, aBegin, aEnd);
        }

        public IList GetCountryWorkingModel(long countryID, DateTime aBegin,DateTime aEnd)
        {
            IList list = GetCountryWorkingModel(countryID);
            return SetFilter(list, aBegin, aEnd);
        }

        private IList GetCountryModel(long countryID, WorkingModelType workingModelType)
        {
            string where = GetWhere(workingModelType);
            IList list = FindByNamedParam(null, where, null, "countryID", countryID);
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        private IList SetFilter(IList list, DateTime aBegin, DateTime aEnd)
        {
            if (list == null) return null;
                
            IList resultList = new ArrayList();

            // TODO: WHY is this filtering implemented programmaticaly?
            // IMHO this should be part of query. shorj.
            foreach (WorkingModel var in list)
            {
                if (!((aBegin > var.EndTime) || (aEnd < var.BeginTime)))
                {
                    resultList.Add(var);
                }
            }
            return resultList;
        }

        private string GetWhere(WorkingModelType workingModelType)
        {
            return string.Format("entity.CountryID = :countryID and entity.WorkingModelType = {0}", (byte)workingModelType);
        }

        #endregion
    }
}