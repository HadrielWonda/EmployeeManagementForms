using System;
using System.Windows.Forms;

namespace Baumax.Server.Configurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FormMain formMain = new FormMain(args.Length > 0 ? args[0] : null);
                Application.Run(formMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Application is finished with error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return 1;
            }
            return 0;
        }
    }
}