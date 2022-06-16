using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common.Logging;

namespace Baumax.HQLTest
{
    static class Program
    {
        static private readonly ILog log = LogManager.GetLogger(typeof(Program));
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new MainForm());
            }
            catch(Exception ex)
            {
                log.Error("Unhandled", ex);
                MessageBox.Show(ex.ToString(), "Unhandled exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            log.Error("Unhandled", e.Exception);
            MessageBox.Show(e.Exception.ToString(), "Unhandled exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}