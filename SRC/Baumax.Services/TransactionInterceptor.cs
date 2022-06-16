using System;
using AopAlliance.Intercept;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Common.Logging;

namespace Baumax.Services
{
    public class TransactionInterceptor : Spring.Transaction.Interceptor.TransactionInterceptor, IMethodInterceptor
    {
        /// <summary>
        /// AOP Alliance invoke call that handles all transaction plumbing. 
        /// </summary>
        /// <param name="invocation">
        /// The method that is to execute in the context of a transaction.
        /// </param>
        /// <returns>The return value from the method invocation.</returns>
        public new object Invoke(IMethodInvocation invocation)
        {
            // Work out the target class: may be <code>null</code>.
            // The TransactionAttributeSource should be passed the target class
            // as well as the method, which may be from an interface.
            Type targetType = (invocation.This != null) ? invocation.This.GetType() : null;

            // If the transaction attribute is null, the method is non-transactional.
            TransactionInfo txnInfo = CreateTransactionIfNecessary(invocation.Method, targetType);
            object returnValue = null;

            try
            {
                // This is an around advice.
                // Invoke the next interceptor in the chain.
                // This will normally result in a target object being invoked.
                returnValue = invocation.Proceed();
            }
            catch (Exception ex)
            {
                // target invocation exception
                CompleteTransactionAfterThrowing(txnInfo, ex);
                if (ex is EntityException)
                {
                    throw;
                }
                else
                {
                    ThrowEntityException(invocation, ex);
                }
            }
            finally
            {
                CleanupTransactionInfo(txnInfo);
            }

            // COMMIT
            try
            {
                CommitTransactionAfterReturning(txnInfo);
            }
            catch (EntityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                ThrowEntityException(invocation, ex);
            }
            return returnValue;
        }

        private void ThrowEntityException(IMethodInvocation invocation, Exception ex)
        {
            // just in case
            if (ex is EntityException)
            {
                throw ex;
            }

            RemoteService.CheckForDBValidationException(null, ex);

            object[] attrs =
                invocation.Method.GetCustomAttributes(typeof (AccessTypeAttribute), true);
            if (attrs == null || attrs.Length == 0)
            {
                log.Error(string.Format("Can't get AccessTypeAttribute for {0}", invocation.Method.Name));
                throw new EntityException(ex);
            }
            AccessType accessType = ((AccessTypeAttribute) attrs[0]).AccessType;
            switch (accessType)
            {
                case AccessType.FreeAccess:
                case AccessType.None:
                    throw new EntityException(ex);
                case AccessType.Read:
                case AccessType.Import:
                    throw new LoadException(ex);
                case AccessType.Write:
                    throw new SaveOrUpdateException(ex);
                default:
                    log.Error(
                        string.Format("Unknown AccessTypeAttribute for {0} ({1})", invocation.Method.Name,
                                      accessType.ToString()));
                    throw new EntityException(ex);
            }
        }
    }
}