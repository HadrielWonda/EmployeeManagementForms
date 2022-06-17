using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using Baumax.Domain;
using NHibernate;
using NHibernate.Expression;

namespace Baumax.Dao.NHibernate
{
    public class HibernateAvgWorkingDaysInWeekDao : HibernateDao<AvgWorkingDaysInWeek>, IAvgWorkingDaysInWeekDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (AvgWorkingDaysInWeek).Name);

            PermittedIDsResult result;
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
            switch (role)
            {
                case UserRoleId.GlobalAdmin:
                    filterHQL = null;
                    return PermittedIDsResult.All;
                case UserRoleId.Controlling:
                    filterHQL = null;
                    if (bForReading)
                    {
                        goto case UserRoleId.CountryAdmin;
                    }
                    else
                    {
                        return PermittedIDsResult.None;
                    }
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

        #region IAvgWorkingDaysInWeekDao Members

        public IList GetAvgWorkingDaysInWeekFiltered(long countryID, short? yearFrom, short? yearTo)
        {
            StringBuilder hql = new StringBuilder("entity.CountryID=:countryID");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("countryID");
            pValues.Add(countryID);

            if (yearFrom.HasValue)
            {
                hql.Append(" AND entity.Year >= :year_from ");
                pNames.Add("year_from");
                pValues.Add(yearFrom.Value);
            }

            if (yearTo.HasValue)
            {
                hql.Append(" AND entity.Year <= :year_to ");
                pNames.Add("year_to");
                pValues.Add(yearTo.Value);
            }

            IList list = FindByNamedParam(hql.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }
        public double GetAvgWorkingDaysInWeek(long countryID, int year)
        {
            double  result = 0;
            AvgWorkingDaysInWeek entity = (AvgWorkingDaysInWeek)HibernateTemplate.Execute(delegate(ISession session)
                {
                    ICriteria criteria = session.CreateCriteria(typeof(AvgWorkingDaysInWeek));
                    return criteria.Add(Expression.Eq("CountryID", countryID))
                    .Add(Expression.Eq("Year", (short)year))
                    .UniqueResult<AvgWorkingDaysInWeek>();
                }
            );

            if (entity != null)
            {
                result = Convert.ToDouble(entity.DaysCount);
            }
            return result;
            
        }

        public List<AvgWorkingDaysInWeek> GetAllAvgWorkingDaysInWeekByCountry(long countryid)
        {
            
            IList lst = (IList)HibernateTemplate.Execute(delegate(ISession session)
                {
                    ICriteria criteria = session.CreateCriteria(typeof(AvgWorkingDaysInWeek));
                    return criteria.Add(Expression.Eq("CountryID", countryid)).List();
                }
            );

            return GetTypedListFromIList (lst);
        }

        public List<AvgWorkingDaysInWeek> GetAllAvgWorkingDaysInWeek()
        {
            IList lst = (IList)HibernateTemplate.Execute(delegate(ISession session)
               {
                   ICriteria criteria = session.CreateCriteria(typeof(AvgWorkingDaysInWeek));
                   return criteria.List();
               }
           );

            return GetTypedListFromIList(lst);
        }
        #endregion
    }
}