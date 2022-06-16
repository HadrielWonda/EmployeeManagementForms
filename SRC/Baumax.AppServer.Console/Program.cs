using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using Baumax.Contract.Interfaces;
using Baumax.Services;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Belikov.GenuineChannels.Security;
using Common.Logging;
using Spring.Context.Support;
using System.Collections;
using Spring.Context;
using Baumax.Scheduler;

namespace Baumax.AppServer.Console
{
    class Program
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 
        static void Main(string[] args)
        {
            log.Info("Starting...");
            try
            {
                ServerStateService svcState = new ServerStateService();
                RemotingServices.Marshal(svcState, "rServerStateService");
                svcState.AfterPropertiesSet();

                // Force Spring to load configuration
                IApplicationContext ctx = ContextRegistry.GetContext();

				// Define channel security
            	IEnumerator channelEnum = ChannelServices.RegisteredChannels.GetEnumerator();
				while (channelEnum.MoveNext())
				{
					BasicChannelWithSecurity channel = channelEnum.Current as BasicChannelWithSecurity;
					if (channel != null)
					{
						channel.ITransportContext.IKeyStore.SetKey("/BAUMAX/SES", new KeyProvider_SelfEstablishingSymmetric());
					}
				}

                Baumax.AppServer.Environment.ServerEnvironment.Configure();

                Scheduler.Scheduler sch = new Scheduler.Scheduler();
                sch.AfterPropertiesSet();

                svcState.ServerReady = true;
                
                log.Info("Server listening...");
            }
            catch (Exception e)
            {
                log.Fatal(e);
            }
            finally
            {
                System.Console.Out.WriteLine("--- Press <return> to quit ---");
                System.Console.ReadLine();
            }
        }
    }
}
