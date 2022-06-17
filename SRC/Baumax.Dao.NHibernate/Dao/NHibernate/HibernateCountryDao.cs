using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using NHibernate;
using Baumax.Contract;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateCountryDao : HibernateDao<Country>, ICountryDao
    {
        #region Private Fields

        private IColouringDao _colouringDao;
        private ICountryAdditionalHourDao _countryAdditionalHourDao;

        #endregion

        #region Private Methods

        private List<long> CheckOrCreateColourings(long countryID)
        {
            if (countryID <= 0)
            {
                return null;
            }

            IList list = _colouringDao.GetCountryColouring(countryID);
            List<long> changedIDs = new List<long>();
            foreach (byte value in Enum.GetValues(typeof (CountryColorValueType)))
            {
                bool bExists = false;
                if (list != null)
                {
                    foreach (Colouring c in list)
                    {
                        if (c.ColourType == value)
                        {
                            bExists = true;
                            break;
                        }
                    }
                }
                if (!bExists)
                {
                    Colouring c = new Colouring();
                    c.CountryID = countryID;
                    c.ColourType = value;
                    c.L = 0;
                    c.Y = 10;
                    c.X = 20;
                    c.H = 30;

                    c.LCColour = Color.Black.ToArgb();
                    c.LColour = c.NColour = c.HColour = c.HCColour = Color.Black.ToArgb();

                    _colouringDao.Save(c);
                }
            }

            if (changedIDs.Count == 0)
            {
                return null;
            }
            return changedIDs;
        }

        #endregion

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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (Country).Name);
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
                    sFrom.AppendFormat(", {0} internal_dao_uc", typeof (UserCountry).Name);
                    sWhere.Append(
                        @"internal_dao_uc.User.ID = :internal_dao_userID 
                      AND internal_dao_uc.CountryID = filtered.ID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.RegionAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sFrom.AppendFormat(", {0} internal_dao_ur, {1} internal_dao_r", typeof (UserRegion).Name,
                                           typeof (Domain.Region).Name);
                        sWhere.Append(
                            @"internal_dao_ur.User.ID = :internal_dao_userID 
                      AND internal_dao_ur.RegionID = internal_dao_r.ID 
                      AND internal_dao_r.CountryID = filtered.ID");
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
                        sFrom.AppendFormat(", {0} internal_dao_us, {1} internal_dao_s, {2} internal_dao_r",
                                           typeof (UserStore).Name, typeof (Store).Name,
                                           typeof (Domain.Region).Name);
                        sWhere.Append(
                            @"internal_dao_us.User.ID = :internal_dao_userID 
                      AND internal_dao_us.StoreID = internal_dao_s.ID 
                      AND internal_dao_s.RegionID = internal_dao_r.ID 
                      AND internal_dao_r.CountryID = filtered.ID");
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

        #region Public Methods

        public override Country Save(Country daoObj)
        {
            base.Save(daoObj);
            List<long> changedColourings = CheckOrCreateColourings(daoObj.ID);

            if ((changedColourings != null) && (changedColourings.Count > 0))
            {
                _colouringDao.OnDaoEntitiesChanged(changedColourings);
            }
            OnDaoEntitiesChanged(daoObj.ID);
            return daoObj;
        }

        // not very efficient but reliable for now
        // TODO: rewrite saving entities silently, collect all countries' and colourings' ids 
        // and then fire only one event for each list
        public override void SaveList(IList list)
        {
            foreach (Country entity in list)
            {
                Save(entity);
            }
        }

        public override Country SaveOrUpdate(Country daoObj)
        {
            base.SaveOrUpdate(daoObj);
            List<long> changedColourings = CheckOrCreateColourings(daoObj.ID);

            if ((changedColourings != null) && (changedColourings.Count > 0))
            {
                _colouringDao.OnDaoEntitiesChanged(changedColourings);
            }
            OnDaoEntitiesChanged(daoObj.ID);
            return daoObj;
        }

        // not very efficient but reliable for now
        // TODO: rewrite saving entities silently, collect all countries' and colourings' ids 
        // and then fire only one event for each list
        public override void SaveOrUpdateList(IList list)
        {
            foreach (Country entity in list)
            {
                SaveOrUpdate(entity);
            }
        }

        public IList GetUserCountries(long userId)
        {
            return
                FindByNamedParam("UserCountry uc", "uc.User.ID = :userID and entity.ID = uc.CountryID", null, "userID",
                                 userId);
        }

        public long GetAustriaCountryID()
        {
            return (long) getDataScalar("select isnull(dbo.getAustriaCountryID(), 0)");
        }

        public long[] GetCountryNoWorkingFeastDaysIDList()
        {
            List<long> result = new List<long>();

            HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        string query =
                            @"select CountryID from Country c
                                        where 
                                            not exists (select * from dbo.YearlyWorkingDays w where c.CountryID = w.CountryID)
	                                        and not exists (select * from dbo.Feasts f where c.CountryID = f.CountryID)";

                        session.CreateSQLQuery(query)
                            .AddScalar("CountryID", NHibernateUtil.Int64)
                            .List(result);
                        return null;
                    }
                );

            return result.ToArray();

        }

        public long[] GetInUseIDList(InUseEntity inUseEntity,  long countryID)
        {
            string spName;
            switch (inUseEntity)
            {
                case InUseEntity.Absence:
                    spName = "spAbsenceUsingIDList";
                    break;
                case InUseEntity.AvgWorkingDaysInWeek:
                    spName = "spAvgWorkingDaysInWeekUsingIDList";
                    break;
                case InUseEntity.WorkingModel:
                    spName = "spWorkingModelUsingIDList";
                    break;
                default:
                    goto case InUseEntity.Absence;
            }
            string query = string.Format("exec {0} {1}", spName, countryID);
            List<long> result = new List<long>();

            HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        session.CreateSQLQuery(query)
                            .AddScalar("ID", NHibernateUtil.Int64)
                            .List(result);
                        return null;
                    }
                );
            return result.ToArray();
        }

        #endregion
    }
}