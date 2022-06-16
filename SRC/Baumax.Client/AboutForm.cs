using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Windows.Forms;
using Baumax.Environment;
using Baumax.Localization;
using Baumax.ServerState;
using DevExpress.XtraEditors;

namespace Baumax.Client
{
    public partial class AboutForm : XtraForm
    {
        private ServerStateData serStat = new  ServerStateData();
        
        public AboutForm()
        {
            InitializeComponent();
                    }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                Text = Localizer.GetLocalized("About") + " " + Localizer.GetLocalized("MainWindowCaption");
                lb_mess.Text = Localizer.GetLocalized("MainWindowCaption");
                lb_InstalledComponent.Text = Localizer.GetLocalized("InstalledComponent");
                fillVerText();
            }
        }
        
        private static string GetUrl(string url)
        {
            if (url != null)
            {
                int pos = url.LastIndexOf('/');
                if (pos > 0)
                    return url.Remove(pos);
            }
            return "";
        }
        
        private void fillVerText()
        {
            serStat = ClientEnvironment.ServerStateService.GetState();
            string uri = GetUrl(RemotingServices.GetObjectUri((MarshalByRefObject)ClientEnvironment.ServerStateService));

            lb_ver.Items.Add(Localizer.GetLocalized("ClientVer") + " " + ClientEnvironment.ClientVerision);
            lb_ver.Items.Add(Localizer.GetLocalized("AppserVer") + " " + serStat.ServerVersion);
            lb_ver.Items.Add(Localizer.GetLocalized("DBVer") + " " + serStat.DbVersion);
            lb_ver.Items.Add(Localizer.GetLocalized("HostURL") + " " + uri); 
        }

        private void btnOK_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
