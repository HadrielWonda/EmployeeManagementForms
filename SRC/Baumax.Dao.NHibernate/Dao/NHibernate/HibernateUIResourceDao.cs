using Baumax.Domain;
using NHibernate;

namespace Baumax.Dao.NHibernate
{
    public class HibernateUIResourceDao : HibernateDao<UIResource>, IUIResourceDao
    {
        #region IUIResourceDao Members

        public System.Collections.IList FindForLanguage(long langID)
        {
            return HibernateTemplate.Find("select entity from UIResource entity where entity.LanguageID=?", langID, NHibernateUtil.Int64);
        }

        #endregion
    }
}