//#define DEBUGGING

using System;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace Baumax.Server.Service.Configurator
{
    public partial class FormMain : Form
    {
        #region Constants

        private const string _configFileName = "Baumax.AppServer.Service.exe.config";

        #endregion

        #region Private fields

        private System.Windows.Forms.Timer _timer;
        private ServiceController _svcController;

        #endregion

        #region Constructors

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(string TargetDir)
        {
            InitializeComponent();

#if DEBUGGING
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }
            else
            {
                System.Diagnostics.Debugger.Launch();
            }
#endif
            Init(TargetDir);
        }

        private void Init(string TargetDir)
        {
            ConfigSettings.Init(TargetDir, _configFileName);

            _timer = new Timer();
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Interval = 500;
            _timer.Start();

            _svcController = new ServiceController("Baumax.AppServer.Service", ".");
            RefreshState();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // just in case
                _timer.Enabled = false;
                
                RefreshState();
            }
            finally
            {
                _timer.Enabled = true;
            }
        }
        
        private void RefreshState()
        {
            try
            {
                _svcController.Refresh();
                ServiceControllerStatus status = _svcController.Status;
                textBoxServiceState.Text = status.ToString();
                switch (status)
                {
                    case ServiceControllerStatus.Stopped:
                        buttonStartService.Enabled = true;
                        buttonStopService.Enabled = false;
                        break;
                    case ServiceControllerStatus.Running:
                        buttonStartService.Enabled = false;
                        buttonStopService.Enabled = true;
                        break;
                    default:
                        buttonStartService.Enabled = false;
                        buttonStopService.Enabled = false;
                        break;
                }
            }
            catch(Exception ex)
            {
                textBoxServiceState.Text = ex.Message;
                buttonStartService.Enabled = false;
                buttonStopService.Enabled = false;
            }
        }

        #endregion

        private void buttonStartService_Click(object sender, EventArgs e)
        {
            try
            {
                buttonStartService.Enabled = false;
                _svcController.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStopService_Click(object sender, EventArgs e)
        {
            try
            {
                buttonStopService.Enabled = false;
                _svcController.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}