using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using NHibernate;
using NHibernate.Expression;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateUserDao : HibernateDao<User>, IUserDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (User).Name);

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
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sWhere.AppendFormat(
                            @"(filtered.ID = :internal_dao_userID

                         OR EXISTS 
                            (SELECT internal_dao_r_ur.ID FROM {0} internal_dao_r_ur 
                              WHERE internal_dao_r_ur.User.ID = filtered.ID 
                                AND internal_dao_r_ur.RegionID IN 
                                    (SELECT internal_dao_rr_r.ID 
                                       FROM {1} internal_dao_rr_r, {2} internal_dao_rr_uc 
                                      WHERE internal_dao_rr_uc.CountryID = internal_dao_rr_r.CountryID 
                                        AND internal_dao_rr_uc.User.ID = :internal_dao_userID) 
                            )

                         OR EXISTS 
                            (SELECT internal_dao_s_us.ID FROM {3} internal_dao_s_us 
                              WHERE internal_dao_s_us.User.ID = filtered.ID
                                AND internal_dao_s_us.StoreID IN 
                                    (SELECT internal_dao_ss_s.ID 
                                       FROM {4} internal_dao_ss_s, {5} internal_dao_ss_r, 
                                            {6} internal_dao_ss_uc 
                                      WHERE internal_dao_ss_s.RegionID = internal_dao_ss_r.ID 
                                        AND internal_dao_ss_r.CountryID = internal_dao_ss_uc.CountryID 
                                        AND internal_dao_ss_uc.User.ID = :internal_dao_userID) 
                            )
                          )",
                            typeof (UserRegion).Name, typeof (Region).Name, typeof (UserCountry).Name,
                            typeof (UserStore).Name, typeof (Store).Name, typeof (Region).Name,
                            typeof (UserCountry).Name);
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        // cannot change global admins
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sWhere.AppendFormat(@"filtered.UserRoleID <> :internal_dao_userRoleID");
                        pNames.Add("internal_dao_userRoleID");
                        pValues.Add((long) (UserRoleId.GlobalAdmin));
                        result = PermittedIDsResult.Restricted;
                    }
                    break;
                case UserRoleId.RegionAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sWhere.AppendFormat(
                            @"(filtered.ID = :internal_dao_userID 

                         OR EXISTS 
                            (SELECT internal_dao_s_us.ID FROM {0} internal_dao_s_us 
                              WHERE internal_dao_s_us.User.ID = filtered.ID
                                AND internal_dao_s_us.StoreID IN 
                                    (SELECT internal_dao_ss_s.ID 
                                       FROM {1} internal_dao_ss_s, {2} internal_dao_ss_ur 
                                      WHERE internal_dao_ss_s.RegionID = internal_dao_ss_ur.RegionID 
                                        AND internal_dao_ss_ur.User.ID = :internal_dao_userID) 
                            )
                          )",
                            typeof (UserStore).Name, typeof (Store).Name, typeof (UserRegion).Name);
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        filterHQL = null;
                        return PermittedIDsResult.None;
                    }
                    break;
                case UserRoleId.StoreAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sWhere.AppendFormat(@"(filtered.ID = :internal_dao_userID)");
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        filterHQL = null;
                        return PermittedIDsResult.None;
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

        public User GetByLogin(string login)
        {
            object usr = HibernateTemplate.Execute(delegate(ISession session)
                                                   {
                                                       ICriteria crit = session.CreateCriteria(typeof (User))
                                                           .SetFetchMode("UserCountryList", FetchMode.Join)
                                                           .SetFetchMode("UserRegionList", FetchMode.Join)
                                                           .SetFetchMode("UserStoreList", FetchMode.Join)
                                                           .Add(Expression.Eq("LoginName", login));
                                                       HibernateTemplate.PrepareCriteria(crit);

                                                       return crit.UniqueResult();
                                                   }
                );

            return usr == null ? null : (User) usr;
        }

        public override User Save(User daoObj)
        {
            bool isNew = daoObj.IsNew;
            if (isNew)
            {
                // HibernateTemplate.Save() returns just ID. real new entity lies in the same daoObj after return.
                //daoObj = (User)HibernateTemplate.Save(daoObj);
                HibernateTemplate.Save(daoObj);
                SaveUserDependants(daoObj);
            }
            else
            {
                DeleteUserDependants(daoObj.ID);
                SaveUserDependants(daoObj);
                HibernateTemplate.SaveOrUpdateCopy(daoObj);
            }
            OnDaoEntitiesChanged(daoObj.ID);
            return daoObj;
        }

        public override User SaveOrUpdate(User daoObj)
        {
            return Save(daoObj);
        }

        public override User Update(User daoObj)
        {
            return Save(daoObj);
        }

        public override void Delete(User daoObj)
        {
            DeleteUserDependants(daoObj.ID);
            HibernateTemplate.Delete(daoObj);
            OnDaoEntitiesChanged(daoObj.ID);
        }

        public override void DeleteByID(long id)
        {
            DeleteUserDependants(id);
            base.DeleteByID(id);
        }

        // TODO: rewrite List-functions to generate single event with list of changed entites' id
        public override void SaveList(IList list)
        {
            foreach (User entity in list)
            {
                Save(entity);
            }
        }

        // TODO: rewrite List-functions to generate single event with list of changed entites' id
        public override void SaveOrUpdateList(IList list)
        {
            foreach (User entity in list)
            {
                SaveOrUpdate(entity);
            }
        }

        // TODO: rewrite List-functions to generate single event with list of changed entites' id
        public override void UpdateList(IList list)
        {
            foreach (User entity in list)
            {
                Update(entity);
            }
        }

        // TODO: rewrite List-functions to generate single event with list of changed entites' id
        public override void DeleteList(IList list)
        {
            foreach (User entity in list)
            {
                Delete(entity);
            }
        }

        // TODO: rewrite List-functions to generate single event with list of changed entites' id
        public override void DeleteListByID(IEnumerable<long> idlist)
        {
            foreach (long id in idlist)
            {
                DeleteByID(id);
            }
        }

        private void DeleteUserDependants(long userId)
        {
            HibernateTemplate.Delete("from UserCountry uc where uc.User.ID = ?", userId, NHibernateUtil.Int64);
            HibernateTemplate.Delete("from UserRegion ur where ur.User.ID = ?", userId, NHibernateUtil.Int64);
            HibernateTemplate.Delete("from UserStore us where us.User.ID = ?", userId, NHibernateUtil.Int64);
        }

        private void SaveUserDependants(User daoObj)
        {
            for (int i = 0; i < daoObj.UserCountryList.Count; i++)
            {
                UserCountry country = (UserCountry) daoObj.UserCountryList[i];
                country.User = daoObj;
                // HibernateTemplate.Save() returns just ID. real new entity lies in the same daoObj after return.
                //daoObj.UserCountryList[i] = HibernateTemplate.Save(country);
                HibernateTemplate.Save(country);
                daoObj.UserCountryList[i] = country;
            }

            for (int i = 0; i < daoObj.UserRegionList.Count; i++)
            {
                UserRegion r = (UserRegion) daoObj.UserRegionList[i];
                r.User = daoObj;
                // HibernateTemplate.Save() returns just ID. real new entity lies in the same daoObj after return.
                //daoObj.UserRegionList[i] = HibernateTemplate.Save(r);
                HibernateTemplate.Save(r);
                daoObj.UserRegionList[i] = r;
            }

            for (int i = 0; i < daoObj.UserStoreList.Count; i++)
            {
                UserStore s = (UserStore) daoObj.UserStoreList[i];
                s.User = daoObj;
                // HibernateTemplate.Save() returns just ID. real new entity lies in the same daoObj after return.
                //daoObj.UserStoreList[i] = HibernateTemplate.Save(s);
                HibernateTemplate.Save(s);
                daoObj.UserStoreList[i] = s;
            }
        }
    }
}