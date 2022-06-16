using NHibernate.Id;
using Baumax.Dao;
using Spring.Context;
using Spring.Context.Support;

namespace Baumax.AppServer
{
    public class PKGen : IIdentifierGenerator
    {
        private IHibernatePKGenEntityDao _pkGenDao;
        
        protected IHibernatePKGenEntityDao PKGenDao
        {
            get
            {
                if(_pkGenDao == null)
                {
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    _pkGenDao = (IHibernatePKGenEntityDao)ctx.GetObject("PKGenDao");
                }
                return _pkGenDao;
            }
        }
        
        #region IIdentifierGenerator Members
        public object Generate(NHibernate.Engine.ISessionImplementor session, object obj)
        {
            // can operate more handy with "obj", when all entities will be inherited from
            // common base class
            // todo: ?implement somewhere const for "Entities" string?
            return PKGenDao.GetNextPK("Entities");
        }
        #endregion
    }
}