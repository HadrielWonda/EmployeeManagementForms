using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Belikov.GenuineChannels.Security;

using Common.Logging;

namespace Baumax.TestClient
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        
        static void Main(string[] args)
        {
            try
            {
                DefaultDiction.BuildDefaultResource();
                ClientEnvironment.IsRuntimeMode = true;
                RemotingConfiguration.Configure("Baumax.TestClient.exe.config", false);
                GenuineGlobalEventProvider.GenuineChannelsGlobalEvent += GenuineGlobalEventProvider_GenuineChannelsGlobalEvent;

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

                DoLogin();
                FullTest test = new FullTest();
                for (; ; )
                {
                    test.Run();
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
                Console.In.ReadLine();
            }
        }

        

        private static void DoLogin()
        {
            ClientEnvironment.DoLogin("admin", "1");
            // Login successful
            DoInitServices();
        }

        private static void DoInitServices()
        {
            ClientEnvironment.InitServices();
        }

        private static void GenuineGlobalEventProvider_GenuineChannelsGlobalEvent(object sender, GenuineEventArgs e)
        {
            switch (e.EventType)
            {
                case GenuineEventType.GeneralConnectionClosed:
                    log.Error(string.Format("{0} - The GTCP server channel has released all resources associated with client connection and will not be able to accept a reconnection from it.", e.HostInformation.Url));
                    // what does this mean? we are still able to reconnect
                    break;
                case GenuineEventType.GeneralConnectionReestablishing:
                    log.Error(string.Format("{0} - Connection is broken but will attempt to reconnect to the server automatically.", e.HostInformation.Url));
                    break;
                case GenuineEventType.GeneralServerRestartDetected:
                    log.Error(string.Format("{0} - Server restart detected. Have to relogin and to resubscribe to events.", e.HostInformation.Url));
                    DoLogin();
                    break;
                default:
                    log.Debug(string.Format("{0} - GenuineChannelsGlobalEvent: {1}", e.HostInformation.Url, e.EventType));
                    break;
            }
        }
    }
}
