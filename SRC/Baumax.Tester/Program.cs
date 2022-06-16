using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Belikov.GenuineChannels.Security;
namespace Baumax.Tester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Baumax.Localization.DefaultDiction.BuildDefaultResource();
            RemotingConfiguration.Configure("Baumax.Tester.exe.config");
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
            SecuritySessionServices.SetCurrentSecurityContext(SecuritySessionServices.DefaultContext);
            Application.Run(new MainForm());
        }
    }
}