//#define DEBUGGING

using System;
using System.Text;
using System.Windows.Forms;

namespace Baumax.Server.Configurator
{
    public partial class FormMain : Form
    {
        #region Constants

        private const string _configFileName = "Baumax.AppServer.Console.exe.config";

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
        }
        
        #endregion

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}