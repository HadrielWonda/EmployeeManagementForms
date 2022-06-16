using System;
using System.Collections;
using System.Runtime.Remoting;
using System.ServiceProcess;
using System.Runtime.Remoting.Channels;
using Baumax.Services;
using Common.Logging;
using Spring.Context.Support;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Belikov.GenuineChannels.Security;

namespace Baumax.AppServer.Service
{
    public partial class BaumaxAppServerService : ServiceBase
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaumaxAppServerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log.Info("Starting...");
            try
            {
                //Set current directory to assembly folder
                System.Environment.CurrentDirectory =
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                ServerStateService svcState = new ServerStateService();
                RemotingServices.Marshal(svcState, "rServerStateService");
                svcState.AfterPropertiesSet();
                
                // Force Spring to load configuration
                ContextRegistry.GetContext();

                // Define channel security
                IEnumerator channelEnum = ChannelServices.RegisteredChannels.GetEnumerator();
                while (channelEnum.MoveNext())
                {
                    BasicChannelWithSecurity channel = channelEnum.Current as BasicChannelWithSecurity;
                    if (channel != null)
                    {
                        channel.ITransportContext.IKeyStore.SetKey("/BAUMAX/SES",
                                                                   new KeyProvider_SelfEstablishingSymmetric());
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
                // how to (should we) inform starter about failure during startup?
                // currently starting from service explorer causes just message 
                // that service was started and then ended right after that
                throw;
            }
        }

        protected override void OnStop()
        {
        }
    }
}