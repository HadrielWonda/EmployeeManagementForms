using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Services;
using Belikov.GenuineChannels.BroadcastEngine;
using Belikov.GenuineChannels.DotNetRemotingLayer;

public class EntityChangeFilter<T> : IMulticastFilter
    where T : BaseEntity, new()
{
    private BaseService<T> _svc;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityChangeFilter&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="service">The service.</param>
    public EntityChangeFilter(BaseService<T> service)
    {
        _svc = service;
    }

    /// <summary>
    /// Returns receivers that should be called.
    /// </summary>
    /// <param name="cachedReceiverList">All registered receivers (read-only cached array).</param>
    /// <param name="iMessage">The call.</param>
    /// <returns>Receivers that will be called.</returns>
    public object[] GetReceivers(object[] cachedReceiverList,
                                 IMessage iMessage)
    {
        // get string immediately from the call
        IMethodCallMessage iMethodCallMessage =
            (IMethodCallMessage) iMessage;
        IEnumerable<long> ids = iMethodCallMessage.Args[0] as IEnumerable<long>;
        if (ids == null)
        {
            return (new List<object>(cachedReceiverList)).ToArray();
        }

        // construct result list that will contain filtered receivers
        object[] resultList = new object[cachedReceiverList.Length];
        int resultListPosition = 0;

        AuthorizationService authSvc = (AuthorizationService) ServerEnvironment.AuthorizationService;

        // go though all the receivers
        for (int i = 0; i < cachedReceiverList.Length; i++)
        {
            // get the next receiver
            ReceiverInfo receiverInfo = cachedReceiverList[i] as ReceiverInfo;
            if (receiverInfo == null)
            {
                continue;
            }

            // obtain its session
            ISessionSupport session = (ISessionSupport) receiverInfo.Tag;
            User u = authSvc.GetUser(session["id"] as SessionId);
            if ((u == null) || (!u.UserRoleID.HasValue))
            {
                continue;
            }

            if (!((UserRoleId) (u.UserRoleID.Value) == UserRoleId.GlobalAdmin) && !_svc.Dao.IsPermittedAll(u, true))
            {
                List<string> pNames = new List<string>();
                List<object> pValues = new List<object>();
                string idList = QueryUtils.GenIDList(ids, pNames, pValues);
                int idCount = pValues.Count;
                IList list =
                    _svc.Dao.FindByNamedParam(new string[] {"entity.ID"}, null, string.Format("entity.ID IN ({0})", idList),
                                          null, pNames.ToArray(), pValues.ToArray(), true, u);
                if ((list == null) || (list.Count == 0))
                {
                    continue;
                }

                if (idCount != list.Count)
                {
                    List<long> newIds = new List<long>(list.Count);
                    foreach (long id in list)
                    {
                        newIds.Add(id);
                    }
                    iMethodCallMessage.Args[0] = newIds;
                }
            }

            resultList[resultListPosition++] = receiverInfo;
        }

        return resultList;
    }
}