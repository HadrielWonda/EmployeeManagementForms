namespace Baumax.Client.Configurator
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
            this.groupBoxHostSettings = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxHostSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxHostSettings
            // 
            this.groupBoxHostSettings.Controls.Add(this.textBoxPort);
            this.groupBoxHostSettings.Controls.Add(this.label2);
            this.groupBoxHostSettings.Controls.Add(this.textBoxURL);
            this.groupBoxHostSettings.Controls.Add(this.labelURL);
            resources.ApplyResources(this.groupBoxHostSettings, "groupBoxHostSettings");
            this.groupBoxHostSettings.Name = "groupBoxHostSettings";
            this.groupBoxHostSettings.TabStop = false;
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelURL
            // 
            resources.ApplyResources(this.labelURL, "labelURL");
            this.labelURL.Name = "labelURL";
            // 
            // textBoxURL
            // 
            resources.ApplyResources(this.textBoxURL, "textBoxURL");
            this.textBoxURL.Name = "textBoxURL";
            // 
            // textBoxPort
            // 
            resources.ApplyResources(this.textBoxPort, "textBoxPort");
            this.textBoxPort.Name = "textBoxPort";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxHostSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.groupBoxHostSettings.ResumeLayout(false);
            this.groupBoxHostSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHostSettings;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelURL;
    }
}

