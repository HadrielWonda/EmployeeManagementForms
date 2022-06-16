using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Belikov.GenuineChannels.Security;

namespace Baumax.Import.Test
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
			RemotingConfiguration.Configure("Baumax.Import.Test.exe.config");
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
            Application.Run(new FrmMain());
		}
	}
}