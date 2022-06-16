namespace Baumax.Server.Service.Configurator
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ConfigSettings = new Baumax.Setup.UI.UCConfigSettings();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxServiceState = new System.Windows.Forms.TextBox();
            this.labelServiceState = new System.Windows.Forms.Label();
            this.buttonStopService = new System.Windows.Forms.Button();
            this.buttonStartService = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigSettings
            // 
            resources.ApplyResources(this.ConfigSettings, "ConfigSettings");
            this.ConfigSettings.Name = "ConfigSettings";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.textBoxServiceState);
            this.groupBox1.Controls.Add(this.labelServiceState);
            this.groupBox1.Controls.Add(this.buttonStopService);
            this.groupBox1.Controls.Add(this.buttonStartService);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBoxServiceState
            // 
            resources.ApplyResources(this.textBoxServiceState, "textBoxServiceState");
            this.textBoxServiceState.Name = "textBoxServiceState";
            this.textBoxServiceState.ReadOnly = true;
            // 
            // labelServiceState
            // 
            resources.ApplyResources(this.labelServiceState, "labelServiceState");
            this.labelServiceState.Name = "labelServiceState";
            // 
            // buttonStopService
            // 
            resources.ApplyResources(this.buttonStopService, "buttonStopService");
            this.buttonStopService.Name = "buttonStopService";
            this.buttonStopService.UseVisualStyleBackColor = true;
            this.buttonStopService.Click += new System.EventHandler(this.buttonStopService_Click);
            // 
            // buttonStartService
            // 
            resources.ApplyResources(this.buttonStartService, "buttonStartService");
            this.buttonStartService.Name = "buttonStartService";
            this.buttonStartService.UseVisualStyleBackColor = true;
            this.buttonStartService.Click += new System.EventHandler(this.buttonStartService_Click);
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConfigSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Baumax.Setup.UI.UCConfigSettings ConfigSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelServiceState;
        private System.Windows.Forms.Button buttonStopService;
        private System.Windows.Forms.Button buttonStartService;
        private System.Windows.Forms.TextBox textBoxServiceState;
        private System.Windows.Forms.Button buttonClose;
    }
}

