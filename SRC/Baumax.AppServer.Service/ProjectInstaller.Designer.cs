namespace Baumax.AppServer.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller_BaumaxAppServerService = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller_BaumaxAppServerService = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller_BaumaxAppServerService
            // 
            this.serviceProcessInstaller_BaumaxAppServerService.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller_BaumaxAppServerService.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstaller_BaumaxAppServerService});
            this.serviceProcessInstaller_BaumaxAppServerService.Password = null;
            this.serviceProcessInstaller_BaumaxAppServerService.Username = null;
            // 
            // serviceInstaller_BaumaxAppServerService
            // 
            this.serviceInstaller_BaumaxAppServerService.ServiceName = "Baumax.AppServer.Service";
            this.serviceInstaller_BaumaxAppServerService.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller_BaumaxAppServerService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller_BaumaxAppServerService;
        private System.ServiceProcess.ServiceInstaller serviceInstaller_BaumaxAppServerService;
    }
}