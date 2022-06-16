using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.ClientUI.Admin;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Environment.Interfaces;
using Baumax.Localization;
using Baumax.Printouts;
using Belikov.GenuineChannels.DotNetRemotingLayer;
using Belikov.GenuineChannels.GenuineTcp;
using Belikov.GenuineChannels.Security;
using Common.Logging;
using Baumax.ClientUI.FormEntities;

namespace Baumax.Client
{
    internal static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (Program));
        private static IOnIdleService onIdleService;

        private static IRemoteRequestNotificationService RequestNotificationService
        {
            get
            {
                return
                    (IRemoteRequestNotificationService) ClientEnvironment.AppCtx.GetObject("requestNotificationService");
            }
        }

        private static IOnIdleService OnIdleService
        {
            get
            {
                if (onIdleService == null)
                {
                    onIdleService = (IOnIdleService) ClientEnvironment.AppCtx.GetObject("IOnIdleService");
                }

                return onIdleService;
            }
        }

        private static MainForm mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;

            ClientEnvironment.IsRuntimeMode = true;
            UCBaseEntity.IsDesignMode = false;
            DefaultDiction.BuildDefaultResource();

            RemotingConfiguration.Configure("Baumax.Client.exe.config", false);

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

            if (!DoLogin())
            {
                return;
            }

            try
            {
                mainForm = new MainForm();
                mainForm.Text +=
                    String.Format(" - '{0}'", ClientEnvironment.AuthorizationService.GetCurrentUser().LoginName);
                ClientEnvironment.MainForm = mainForm;

                RequestNotificationService.Attach(mainForm);

                GenuineGlobalEventProvider.GenuineChannelsGlobalEvent +=
                    GenuineGlobalEventProvider_GenuineChannelsGlobalEvent;

                ReportLocalizer.InitDevExPreviewLocalizer();
            	DevExLocalizer.InitDevExLocalizer();
				DevExGridLocalizer.InitDevExGridLocalizer();

                Application.Run(mainForm);

                ClientEnvironment.DoLogout();
            }
            catch (EntityException ex)
            {
                log.Error("Unhandled", ex);
                // 2think: how to localize?
                using (FrmEntityExceptionDetails frm = new FrmEntityExceptionDetails(ex))
                {
                    frm.Text = "Unhandled exception";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("Unhandled", ex);
                MessageBox.Show(ex.ToString(), "Unhandled exception");
            }
        }

        private delegate bool LoginDelegate();

        private static bool DoLogin()
        {
            if (LoginFrm.IsDialogVisible)
                return false;
            
            if ((mainForm != null) && (mainForm.InvokeRequired))
            {
                return (bool) mainForm.Invoke(new LoginDelegate(DoLogin));
            }
            else
            {
                FormWait.HideWaitForm();

                if (LoginFrm.ShowLogin(mainForm) != DialogResult.OK)
                {
                    Application.Exit();
                    return false;
                }
                
                FormWait.ShowWaitForm();
                
                DoInitServices();
                OnIdleService.AddTask(new OnIdleOneRunTask(NotificationService.RunDataCheck));
            }
            return true;
        }

        private static void DoInitServices()
        {
            if ((mainForm != null) && (mainForm.InvokeRequired))
            {
                mainForm.Invoke(new MethodInvoker(DoInitServices));
                return;
            }
            ClientEnvironment.InitServices();
        }

        private static void GenuineGlobalEventProvider_GenuineChannelsGlobalEvent(object sender, GenuineEventArgs e)
        {
            switch (e.EventType)
            {
                case GenuineEventType.HostResourcesReleased:
                    if (!DoLogin())
                    {
                        return;
                    }
                    FormWait.HideWaitForm();
                    break;
                default:
                    log.Debug(string.Format("{0} - GenuineChannelsGlobalEvent: {1}", e.HostInformation.Url, e.EventType));
                    break;
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            log.Error("Unhandled", e.Exception);
            if (e.Exception is EntityException)
            {
                // 2think: how to localize?
                using (FrmEntityExceptionDetails frm = new FrmEntityExceptionDetails(e.Exception as EntityException))
                {
                    frm.Text = "Unhandled exception";
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(e.Exception.ToString(), "Unhandled exception");
            }
        }
    }
}