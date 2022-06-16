using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.ClientUI.Admin;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Localization;
using Belikov.GenuineChannels.Security;
using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace Baumax.Client
{
    public partial class LoginFrm : XtraForm
    {
        private delegate void SetStateDelegate(ServerState state);

        private bool _ShouldClose = true;
        private readonly ManualResetEvent _FinishChecking = new ManualResetEvent(false);

        private static bool _IsDialogVisible = false;
        private readonly Thread _CheckThread;
        //private const string _DefaultPassword = "init";
        private bool? _UserHasPassword = null;
        private ServerState _State = ServerState.Unavailable;
        
        private LoginFrm()
        {
            InitializeComponent();
            //GenuineGlobalEventProvider.GenuineChannelsGlobalEvent += new GenuineChannelsGlobalEventHandler(GenuineGlobalEventProvider_GenuineChannelsGlobalEvent);
            SkinManager.EnableFormSkins();

            btn_Login.Enabled = false;
            btn_Login.Text = Localizer.GetLocalized("Login");
            btn_Exit.Text = Localizer.GetLocalized("Exit");
            lbl_LoginName.Text = Localizer.GetLocalized("LoginName");
            lbl_Password.Text = Localizer.GetLocalized("Password");

            txtState.Text = Localizer.GetLocalized("CheckingServerPresence");

            _CheckThread = new Thread(CheckState);
            _CheckThread.IsBackground = true;
            _CheckThread.Start();

            teLogin.Text = System.Environment.UserName;
            EnableLoginField(false);

#if DEBUG
            EnableLoginField(true);
            teLogin.Text = "admin";
            tePassword.Text = "1";
#endif
        }

        public static bool IsDialogVisible
        {
            get { return _IsDialogVisible; }
        }

        public static DialogResult ShowLogin(IWin32Window wnd)
        {
            _IsDialogVisible = true;

            using (LoginFrm frm = new LoginFrm())
            {
                DialogResult res = frm.ShowDialog(wnd);
                _IsDialogVisible = false;
                return res;
            }
        }

        private void CheckState()
        {
            try
            {
                SecuritySessionParameters parameters = new SecuritySessionParameters(
                    SecuritySessionServices.DefaultContext.Name,
                    SecuritySessionAttributes.None, TimeSpan.FromSeconds(5));
                using (new SecurityContextKeeper(parameters))
                {
                    while (true)
                    {
                        try
                        {
                            if (ClientEnvironment.ServerStateService.CanInteract)
                            {
                                if (ClientEnvironment.ServerStateService.ServerReady)
                                    SetState(ServerState.Ready);
                                else
                                    SetState(ServerState.Starting);
                            }
                            else
                                SetState(ServerState.Starting);
                        }
                        catch (ThreadAbortException)
                        {
                            return;
                        }
                        catch(Exception ex)
                        {
                            SetState(ServerState.Unavailable);
                        }
                        if (_FinishChecking.WaitOne(1000, false))
                            return;
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
        }

        private void SetState(ServerState state)
        {
            if (InvokeRequired)
                BeginInvoke(new SetStateDelegate(SetState), state);
            else
            {
                _State = state;
                switch (state)
                {
                    case ServerState.Ready:
                        if (!_UserHasPassword.HasValue)
                        {
                            _UserHasPassword = ClientEnvironment.AuthorizationService.IsUserHasPassword(teLogin.Text);
                            if (!_UserHasPassword.Value)
                            {
                                _ShouldClose = Login();
                                DialogResult = DialogResult.OK;
                                if (!_ShouldClose)
                                    EnableLoginField(true);

                                Close();
                            }
                        }
                        txtState.Text = Localizer.GetLocalized("ServerReady");
                        btn_Login.Enabled = true;
                        break;

                    case ServerState.Starting:
                        _UserHasPassword = null;
                        txtState.Text = Localizer.GetLocalized("ServerStarting");
                        btn_Login.Enabled = false;
                        break;

                    case ServerState.Unavailable:
                        _UserHasPassword = null;
                        txtState.Text = Localizer.GetLocalized("ServerIsUnavailable");
                        btn_Login.Enabled = false;
                        break;
                }

                txtState.Refresh();
            }
        }

        private bool Login()
        {
            try
            {
                if (ClientEnvironment.ServerStateService.CanInteract)
                {
                    if (ClientEnvironment.ServerStateService.ServerReady)
                    {
                        LoginResult result = ClientEnvironment.DoLogin(teLogin.Text, tePassword.Text);
                        switch (result)
                        {
                            case LoginResult.Successful:
                                if (ClientEnvironment.AuthorizationService.GetCurrentUser().ShouldChangePassword)
                                {
                                    using (ChangePasswordForm cpf = new ChangePasswordForm())
                                    {
                                        cpf.SetCaption(Localizer.GetLocalized("ShouldChangePassword"));
                                        cpf.ShowDialog();
                                    }
                                }
                                return true;

                            case LoginResult.WrongLogin:
                            case LoginResult.WrongPassword:
                                XtraMessageBox.Show(this, Localizer.GetLocalized("WrongLoginOrPassword"), string.Empty,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                                break;

                            case LoginResult.UserIsInactive:
                                XtraMessageBox.Show(this, Localizer.GetLocalized("UserIsInactive"),
                                                    string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                // 2think: how to localize?
                using (FrmEntityExceptionDetails frm = new FrmEntityExceptionDetails(ex))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                if (ex is SocketException || ex.InnerException is SocketException)
                {
                    XtraMessageBox.Show(this, Localizer.GetLocalized("ServerIsUnavailable"), string.Empty,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show(this, ex.Message, string.Empty, MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
            return false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = !_ShouldClose;
            if (_ShouldClose)
            {
                _FinishChecking.Set();
                if (_CheckThread.ThreadState != ThreadState.Unstarted)
                    while (!_CheckThread.Join(100))
                    {
                        Application.DoEvents();
                    }
            }
        }

        private void EnableLoginField(bool enabled)
        {
            teLogin.Enabled = enabled;
            teLogin.Properties.Enabled = enabled;
            teLogin.Properties.ReadOnly = !enabled;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _ShouldClose = Login();    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _ShouldClose = true;
        }

        private enum ServerState
        {
            Unavailable,
            Starting,
            Ready
        }
    }
}