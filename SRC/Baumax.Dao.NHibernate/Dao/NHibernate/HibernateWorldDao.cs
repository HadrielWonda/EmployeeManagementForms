using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using NHibernate.Type;

namespace Baumax.Dao.NHibernate
{
    public class HibernateWorldDao : HibernateDao<World>, IWorldDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (World).Name);
            long? languageID = getCurrentLanguageID();
            if (languageID.HasValue)
            {
                sWhere.Append(" WHERE filtered.LanguageID = :internal_dao_languageid ");
                pNames.Add("internal_dao_languageid");
                pValues.Add(languageID.Value);
            }

            // TODO: add filtering by user/role
            if (sWhere.Length == 0)
            {
                filterHQL = null;
            }
            else
            {
                filterHQL = sFrom.Append(sWhere).ToString();
            }
            return PermittedIDsResult.Restricted;
            // suppose, we should never call base
            //return base.CreatePermittedIDFilter();
        }

        #region IWorldDao Members

        public IList GetStoreWorlds(long storeID)
        {
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();

            StringBuilder sb = new StringBuilder(50);
            sb.Append("entity.ID=sw.WorldID AND sw.StoreID=:storeID ");
            pNames.Add("storeID");
            pValues.Add(storeID);

            IList list = FindByNamedParam("StoreToWorld sw", sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        public World GetByStoreToWorldID(long storeToWorldID)
        {
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();

            StringBuilder sb = new StringBuilder(50);
            sb.Append(
                "entity.ID=sw.WorldID AND sw.ID=:storeToWorldID ");
            pNames.Add("storeToWorldID");
            pValues.Add(storeToWorldID);

            IList list = FindByNamedParam("StoreToWorld sw", sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list == null) || (list.Count == 0))
            {
                return null;
            }
            Debug.Assert(list.Count == 1, "Found more than 1 World by ID of StoreToWorld");
            return (World) (list[0]);
        }

        public Dictionary<long, World> GetDictionaryByStoreToWorldIDList(IEnumerable<long> idList)
        {
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();

            StringBuilder sb = new StringBuilder(50);
            sb.Append("entity.ID=sw.WorldID AND sw.ID IN (");
            sb.Append(QueryUtils.GenIDList(idList, pNames, pValues));
            sb.Append(")");

            IList list =
                FindByNamedParam(new string[] {"sw.ID", "entity"}, "StoreToWorld sw", sb.ToString(), "",
                                 pNames.ToArray(), pValues.ToArray(), true);

            if ((list == null) || (list.Count == 0))
            {
                return null;
            }

            Dictionary<long, World> result = new Dictionary<long, World>(list.Count);
            foreach(object[] array in list)
            {
                result.Add((long)array[0], (World)array[1]);
            }
            return result;
        }

        #endregion
    }
}