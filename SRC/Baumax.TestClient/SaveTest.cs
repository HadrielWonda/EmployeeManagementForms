using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Common.Logging;

namespace Baumax.TestClient
{
    public class SaveTest<T> : ITest 
        where T : BaseEntity
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SaveTest<T>));
        private IBaseService<T> _Svc;
        
        public SaveTest(IBaseService<T> svc)
        {
            _Svc = svc;
        }
        
        public void Run()
        {
            log.Info(string.Format("Start save test for: {0}", _Svc.GetType().Name));
            try
            {
                ICollection<T> list = _Svc.FindAll();
                if ((list != null) && (list.Count > 0))
                {
                    foreach (T e in list)
                    {
                        _Svc.SaveOrUpdate(e);
                    }
                    log.Info(string.Format("{0} entities saved", list.Count));
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
