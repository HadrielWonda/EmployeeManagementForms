using System;
using System.Collections.Generic;
using System.Reflection;
using AopAlliance.Intercept;
using Baumax.Contract.Exceptions;
using Baumax.Contract.Interfaces;
using Common.Logging;
using Spring.Aop;

namespace Baumax.Services
{
    public class SecurityBeforeAdvice : IMethodInterceptor
	{
        private RuntimeMethodHandle _LoginMethod;
        private RuntimeMethodHandle _LoginVersionCheckMethod;
        private RuntimeMethodHandle _IsUserHasPasswordMethod;
        private IAuthorizationService _AuthSvc;
        private Type _ServiceIdType = typeof(ServiceIDAttribute);
        
        static ILog log = LogManager.GetLogger("Security"); 
        
        public SecurityBeforeAdvice()
        {
            _LoginMethod = typeof(AuthorizationService).GetMethod("Login").MethodHandle;
            _LoginVersionCheckMethod = typeof(AuthorizationService).GetMethod("LoginVersionCheck").MethodHandle;
            _IsUserHasPasswordMethod = typeof(AuthorizationService).GetMethod("IsUserHasPassword").MethodHandle;
        }

        #region IMethodInterceptor Members

        public object Invoke(IMethodInvocation invocation)
        {
            object res;
            DateTime start;
            try
            {
                if (log.IsDebugEnabled)
                    log.Debug(string.Format("Client call: {0}.{1}", invocation.Target, invocation.Method.Name));

                if (invocation.Method.MethodHandle != _LoginMethod && invocation.Method.MethodHandle != _LoginVersionCheckMethod && invocation.Method.MethodHandle != _IsUserHasPasswordMethod)
                {
                    IService svc = invocation.Target as IService;
                    if (svc == null)
                    {
                        object[] attrs = invocation.Method.ReflectedType.GetCustomAttributes(_ServiceIdType, false);
                        if (attrs == null || attrs.Length == 0)
                            throw new AccessDeniedException();

                        Guid id = new Guid(((ServiceIDAttribute)attrs[0]).ID);
                        if (!_AuthSvc.CanExecute(invocation.Method.MethodHandle, id))
                            throw new AccessDeniedException();

                    }
                    else
                    {
                        if (!_AuthSvc.CanExecute(invocation.Method.MethodHandle, svc.ServiceId))
                            throw new AccessDeniedException();
                    }
                }

                start = DateTime.Now;
                res = invocation.Proceed();
                if (log.IsDebugEnabled)
                    log.Debug(string.Format("Execution time: {0}", DateTime.Now - start));
            }
            catch (Exception ex)
            {
                if (log.IsWarnEnabled)
                {
                    log.Warn(string.Format("Exception thrown from {0}.{1}\n  Exception Message = {2}:{3}", invocation.Target, invocation.Method.Name, ex.GetType(), ex.Message));
                }
                throw;
            }
            return res;
        }

        #endregion
        
        public IAuthorizationService AuthSvc
        {
            get { return _AuthSvc; }
            set { _AuthSvc = value; }
        }
    }
}