using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Common.Logging;

namespace Baumax.TestClient
{
    public class CreateDeleteTest<T> : ITest 
        where T : BaseEntity
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SaveTest<T>));
        private IBaseService<T> _Svc;
        
        public CreateDeleteTest(IBaseService<T> svc)
        {
            _Svc = svc;
        }

        public void Run()
        {
            log.Info(string.Format("Start CreateDelete for: {0}", _Svc.GetType().Name));
            try
            {
                ICollection<T> list = _Svc.FindAll();

                if ((list != null) && (list.Count > 0))
                {
                    foreach (T e in list)
                    {
                        T entity = _Svc.CreateEntity();
                        BaseEntity.CopyTo(e, entity);
                        entity.ID = -1;

                        entity = _Svc.Save(entity);
                        _Svc.Delete(entity);
                        entity = _Svc.FindById(entity.ID);
                        System.Diagnostics.Debug.Assert(entity == null);
                    }
                    log.Info(string.Format("{0} entities passed CreateDeleteTest", list.Count));
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
            }
            log.Info("end");
        }
    }
}
