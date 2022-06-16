namespace Baumax.Setup.UI
{
    partial class UCConfigSettings
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
            this.groupBoxConfigSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxImportSettings = new System.Windows.Forms.GroupBox();
            this.ellipsisImportLogsFolder = new System.Windows.Forms.Button();
            this.textBoxImportLogsFolder = new System.Windows.Forms.TextBox();
            this.labelImportLogsFolder = new System.Windows.Forms.Label();
            this.ellipsisImportErrorsFolder = new System.Windows.Forms.Button();
            this.textBoxImportErrorsFolder = new System.Windows.Forms.TextBox();
            this.labelImportErrorsFolder = new System.Windows.Forms.Label();
            this.ellipsisImportImportedFolder = new System.Windows.Forms.Button();
            this.ellipsisImportSourceFolder = new System.Windows.Forms.Button();
            this.textBoxImportImportedFolder = new System.Windows.Forms.TextBox();
            this.labelImportImportedFolder = new System.Windows.Forms.Label();
            this.textBoxImportSourceFolder = new System.Windows.Forms.TextBox();
            this.labelImportSourceFolder = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxRemotingSettings = new System.Windows.Forms.GroupBox();
            this.textBoxTCPPort = new System.Windows.Forms.MaskedTextBox();
            this.labelTCPPort = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkDBConnectionButton = new System.Windows.Forms.Button();
            this.groupBoxAuthentication = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.labelUserID = new System.Windows.Forms.Label();
            this.radioButtonSQLAuthentification = new System.Windows.Forms.RadioButton();
            this.radioButtonIntegratedSecurity = new System.Windows.Forms.RadioButton();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.textBoxDataSource = new System.Windows.Forms.TextBox();
            this.labelDataSource = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.numericUpDownDaysFilesOutOfDate = new System.Windows.Forms.NumericUpDown();
            this.labelDaysFilesOutOfDate = new System.Windows.Forms.Label();
            this.groupBoxConfigSettings.SuspendLayout();
            this.groupBoxImportSettings.SuspendLayout();
            this.groupBoxRemotingSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxAuthentication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysFilesOutOfDate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxConfigSettings
            // 
            this.groupBoxConfigSettings.Controls.Add(this.groupBoxImportSettings);
            this.groupBoxConfigSettings.Controls.Add(this.buttonSave);
            this.groupBoxConfigSettings.Controls.Add(this.groupBoxRemotingSettings);
            this.groupBoxConfigSettings.Controls.Add(this.groupBox1);
            this.groupBoxConfigSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxConfigSettings.Name = "groupBoxConfigSettings";
            this.groupBoxConfigSettings.Size = new System.Drawing.Size(782, 320);
            this.groupBoxConfigSettings.TabIndex = 13;
            this.groupBoxConfigSettings.TabStop = false;
            this.groupBoxConfigSettings.Text = " Config settings ";
            // 
            // groupBoxImportSettings
            // 
            this.groupBoxImportSettings.Controls.Add(this.labelDaysFilesOutOfDate);
            this.groupBoxImportSettings.Controls.Add(this.numericUpDownDaysFilesOutOfDate);
            this.groupBoxImportSettings.Controls.Add(this.ellipsisImportLogsFolder);
            this.groupBoxImportSettings.Controls.Add(this.textBoxImportLogsFolder);
            this.groupBoxImportSettings.Controls.Add(this.labelImportLogsFolder);
            this.groupBoxImportSettings.Controls.Add(this.ellipsisImportErrorsFolder);
            this.groupBoxImportSettings.Controls.Add(this.textBoxImportErrorsFolder);
            this.groupBoxImportSettings.Controls.Add(this.labelImportErrorsFolder);
            this.groupBoxImportSettings.Controls.Add(this.ellipsisImportImportedFolder);
            this.groupBoxImportSettings.Controls.Add(this.ellipsisImportSourceFolder);
            this.groupBoxImportSettings.Controls.Add(this.textBoxImportImportedFolder);
            this.groupBoxImportSettings.Controls.Add(this.labelImportImportedFolder);
            this.groupBoxImportSettings.Controls.Add(this.textBoxImportSourceFolder);
            this.groupBoxImportSettings.Controls.Add(this.labelImportSourceFolder);
            this.groupBoxImportSettings.Location = new System.Drawing.Point(399, 64);
            this.groupBoxImportSettings.Name = "groupBoxImportSettings";
            this.groupBoxImportSettings.Size = new System.Drawing.Size(382, 221);
            this.groupBoxImportSettings.TabIndex = 16;
            this.groupBoxImportSettings.TabStop = false;
            this.groupBoxImportSettings.Text = " Import settings ";
            // 
            // ellipsisImportLogsFolder
            // 
            this.ellipsisImportLogsFolder.Location = new System.Drawing.Point(348, 154);
            this.ellipsisImportLogsFolder.Name = "ellipsisImportLogsFolder";
            this.ellipsisImportLogsFolder.Size = new System.Drawing.Size(28, 22);
            this.ellipsisImportLogsFolder.TabIndex = 11;
            this.ellipsisImportLogsFolder.Text = "...";
            this.ellipsisImportLogsFolder.UseVisualStyleBackColor = true;
            this.ellipsisImportLogsFolder.Click += new System.EventHandler(this.ellipsisImportLogsFolder_Click);
            // 
            // textBoxImportLogsFolder
            // 
            this.textBoxImportLogsFolder.Location = new System.Drawing.Point(6, 155);
            this.textBoxImportLogsFolder.Name = "textBoxImportLogsFolder";
            this.textBoxImportLogsFolder.Size = new System.Drawing.Size(343, 20);
            this.textBoxImportLogsFolder.TabIndex = 10;
            // 
            // labelImportLogsFolder
            // 
            this.labelImportLogsFolder.AutoSize = true;
            this.labelImportLogsFolder.Location = new System.Drawing.Point(6, 138);
            this.labelImportLogsFolder.Name = "labelImportLogsFolder";
            this.labelImportLogsFolder.Size = new System.Drawing.Size(87, 13);
            this.labelImportLogsFolder.TabIndex = 9;
            this.labelImportLogsFolder.Text = "Import logs folder";
            // 
            // ellipsisImportErrorsFolder
            // 
            this.ellipsisImportErrorsFolder.Location = new System.Drawing.Point(348, 114);
            this.ellipsisImportErrorsFolder.Name = "ellipsisImportErrorsFolder";
            this.ellipsisImportErrorsFolder.Size = new System.Drawing.Size(28, 22);
            this.ellipsisImportErrorsFolder.TabIndex = 8;
            this.ellipsisImportErrorsFolder.Text = "...";
            this.ellipsisImportErrorsFolder.UseVisualStyleBackColor = true;
            this.ellipsisImportErrorsFolder.Click += new System.EventHandler(this.ellipsisImportErrorsFolder_Click);
            // 
            // textBoxImportErrorsFolder
            // 
            this.textBoxImportErrorsFolder.Location = new System.Drawing.Point(6, 115);
            this.textBoxImportErrorsFolder.Name = "textBoxImportErrorsFolder";
            this.textBoxImportErrorsFolder.Size = new System.Drawing.Size(343, 20);
            this.textBoxImportErrorsFolder.TabIndex = 7;
            // 
            // labelImportErrorsFolder
            // 
            this.labelImportErrorsFolder.AutoSize = true;
            this.labelImportErrorsFolder.Location = new System.Drawing.Point(6, 98);
            this.labelImportErrorsFolder.Name = "labelImportErrorsFolder";
            this.labelImportErrorsFolder.Size = new System.Drawing.Size(94, 13);
            this.labelImportErrorsFolder.TabIndex = 6;
            this.labelImportErrorsFolder.Text = "Import errors folder";
            // 
            // ellipsisImportImportedFolder
            // 
            this.ellipsisImportImportedFolder.Location = new System.Drawing.Point(348, 71);
            this.ellipsisImportImportedFolder.Name = "ellipsisImportImportedFolder";
            this.ellipsisImportImportedFolder.Size = new System.Drawing.Size(28, 22);
            this.ellipsisImportImportedFolder.TabIndex = 5;
            this.ellipsisImportImportedFolder.Text = "...";
            this.ellipsisImportImportedFolder.UseVisualStyleBackColor = true;
            this.ellipsisImportImportedFolder.Click += new System.EventHandler(this.ellipsisImportImportedFolder_Click);
            // 
            // ellipsisImportSourceFolder
            // 
            this.ellipsisImportSourceFolder.Location = new System.Drawing.Point(348, 31);
            this.ellipsisImportSourceFolder.Name = "ellipsisImportSourceFolder";
            this.ellipsisImportSourceFolder.Size = new System.Drawing.Size(28, 22);
            this.ellipsisImportSourceFolder.TabIndex = 4;
            this.ellipsisImportSourceFolder.Text = "...";
            this.ellipsisImportSourceFolder.UseVisualStyleBackColor = true;
            this.ellipsisImportSourceFolder.Click += new System.EventHandler(this.ellipsisImportSourceFolder_Click);
            // 
            // textBoxImportImportedFolder
            // 
            this.textBoxImportImportedFolder.Location = new System.Drawing.Point(6, 72);
            this.textBoxImportImportedFolder.Name = "textBoxImportImportedFolder";
            this.textBoxImportImportedFolder.Size = new System.Drawing.Size(343, 20);
            this.textBoxImportImportedFolder.TabIndex = 3;
            // 
            // labelImportImportedFolder
            // 
            this.labelImportImportedFolder.AutoSize = true;
            this.labelImportImportedFolder.Location = new System.Drawing.Point(6, 55);
            this.labelImportImportedFolder.Name = "labelImportImportedFolder";
            this.labelImportImportedFolder.Size = new System.Drawing.Size(98, 13);
            this.labelImportImportedFolder.TabIndex = 2;
            this.labelImportImportedFolder.Text = "Imported files folder";
            // 
            // textBoxImportSourceFolder
            // 
            this.textBoxImportSourceFolder.Location = new System.Drawing.Point(6, 32);
            this.textBoxImportSourceFolder.Name = "textBoxImportSourceFolder";
            this.textBoxImportSourceFolder.Size = new System.Drawing.Size(343, 20);
            this.textBoxImportSourceFolder.TabIndex = 1;
            // 
            // labelImportSourceFolder
            // 
            this.labelImportSourceFolder.AutoSize = true;
            this.labelImportSourceFolder.Location = new System.Drawing.Point(6, 16);
            this.labelImportSourceFolder.Name = "labelImportSourceFolder";
            this.labelImportSourceFolder.Size = new System.Drawing.Size(91, 13);
            this.labelImportSourceFolder.TabIndex = 0;
            this.labelImportSourceFolder.Text = "Source files folder";
            // 
            // buttonSave
            // 
            this.buttonSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSave.Location = new System.Drawing.Point(329, 291);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(128, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "&Save settings";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxRemotingSettings
            // 
            this.groupBoxRemotingSettings.Controls.Add(this.textBoxTCPPort);
            this.groupBoxRemotingSettings.Controls.Add(this.labelTCPPort);
            this.groupBoxRemotingSettings.Location = new System.Drawing.Point(399, 19);
            this.groupBoxRemotingSettings.Name = "groupBoxRemotingSettings";
            this.groupBoxRemotingSettings.Size = new System.Drawing.Size(382, 39);
            this.groupBoxRemotingSettings.TabIndex = 14;
            this.groupBoxRemotingSettings.TabStop = false;
            this.groupBoxRemotingSettings.Text = " Remoting settings ";
            // 
            // textBoxTCPPort
            // 
            this.textBoxTCPPort.Culture = new System.Globalization.CultureInfo("");
            this.textBoxTCPPort.Location = new System.Drawing.Point(64, 15);
            this.textBoxTCPPort.Name = "textBoxTCPPort";
            this.textBoxTCPPort.Size = new System.Drawing.Size(71, 20);
            this.textBoxTCPPort.TabIndex = 10;
            // 
            // labelTCPPort
            // 
            this.labelTCPPort.AutoSize = true;
            this.labelTCPPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTCPPort.Location = new System.Drawing.Point(8, 18);
            this.labelTCPPort.Name = "labelTCPPort";
            this.labelTCPPort.Size = new System.Drawing.Size(50, 13);
            this.labelTCPPort.TabIndex = 8;
            this.labelTCPPort.Text = "TCP Port";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkDBConnectionButton);
            this.groupBox1.Controls.Add(this.groupBoxAuthentication);
            this.groupBox1.Controls.Add(this.textBoxDatabase);
            this.groupBox1.Controls.Add(this.labelDatabase);
            this.groupBox1.Controls.Add(this.textBoxDataSource);
            this.groupBox1.Controls.Add(this.labelDataSource);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 266);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Database settings ";
            // 
            // checkDBConnectionButton
            // 
            this.checkDBConnectionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkDBConnectionButton.Location = new System.Drawing.Point(62, 240);
            this.checkDBConnectionButton.Name = "checkDBConnectionButton";
            this.checkDBConnectionButton.Size = new System.Drawing.Size(242, 23);
            this.checkDBConnectionButton.TabIndex = 10;
            this.checkDBConnectionButton.Text = "Check &DB Connection";
            this.checkDBConnectionButton.UseVisualStyleBackColor = true;
            this.checkDBConnectionButton.Click += new System.EventHandler(this.checkDBConnectionButton_Click);
            // 
            // groupBoxAuthentication
            // 
            this.groupBoxAuthentication.Controls.Add(this.textBoxPassword);
            this.groupBoxAuthentication.Controls.Add(this.labelPassword);
            this.groupBoxAuthentication.Controls.Add(this.textBoxUserID);
            this.groupBoxAuthentication.Controls.Add(this.labelUserID);
            this.groupBoxAuthentication.Controls.Add(this.radioButtonSQLAuthentification);
            this.groupBoxAuthentication.Controls.Add(this.radioButtonIntegratedSecurity);
            this.groupBoxAuthentication.Location = new System.Drawing.Point(12, 71);
            this.groupBoxAuthentication.Name = "groupBoxAuthentication";
            this.groupBoxAuthentication.Size = new System.Drawing.Size(366, 120);
            this.groupBoxAuthentication.TabIndex = 9;
            this.groupBoxAuthentication.TabStop = false;
            this.groupBoxAuthentication.Text = " Authentication ";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(70, 91);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(290, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Enabled = false;
            this.labelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPassword.Location = new System.Drawing.Point(3, 94);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Enabled = false;
            this.textBoxUserID.Location = new System.Drawing.Point(70, 65);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(290, 20);
            this.textBoxUserID.TabIndex = 3;
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Enabled = false;
            this.labelUserID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelUserID.Location = new System.Drawing.Point(3, 68);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(43, 13);
            this.labelUserID.TabIndex = 2;
            this.labelUserID.Text = "User ID";
            // 
            // radioButtonSQLAuthentification
            // 
            this.radioButtonSQLAuthentification.AutoSize = true;
            this.radioButtonSQLAuthentification.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonSQLAuthentification.Location = new System.Drawing.Point(6, 42);
            this.radioButtonSQLAuthentification.Name = "radioButtonSQLAuthentification";
            this.radioButtonSQLAuthentification.Size = new System.Drawing.Size(150, 17);
            this.radioButtonSQLAuthentification.TabIndex = 1;
            this.radioButtonSQLAuthentification.Text = "SQL Server authentication";
            this.radioButtonSQLAuthentification.UseVisualStyleBackColor = true;
            // 
            // radioButtonIntegratedSecurity
            // 
            this.radioButtonIntegratedSecurity.AutoSize = true;
            this.radioButtonIntegratedSecurity.Checked = true;
            this.radioButtonIntegratedSecurity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonIntegratedSecurity.Location = new System.Drawing.Point(6, 19);
            this.radioButtonIntegratedSecurity.Name = "radioButtonIntegratedSecurity";
            this.radioButtonIntegratedSecurity.Size = new System.Drawing.Size(114, 17);
            this.radioButtonIntegratedSecurity.TabIndex = 0;
            this.radioButtonIntegratedSecurity.TabStop = true;
            this.radioButtonIntegratedSecurity.Text = "Integrated Security";
            this.radioButtonIntegratedSecurity.UseVisualStyleBackColor = true;
            this.radioButtonIntegratedSecurity.CheckedChanged += new System.EventHandler(this.radioButtonIntegratedSecurity_CheckedChanged);
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(82, 45);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(290, 20);
            this.textBoxDatabase.TabIndex = 8;
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDatabase.Location = new System.Drawing.Point(9, 49);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(53, 13);
            this.labelDatabase.TabIndex = 7;
            this.labelDatabase.Text = "Database";
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(82, 19);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(290, 20);
            this.textBoxDataSource.TabIndex = 6;
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDataSource.Location = new System.Drawing.Point(9, 22);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(67, 13);
            this.labelDataSource.TabIndex = 5;
            this.labelDataSource.Text = "Data Source";
            // 
            // numericUpDownDaysFilesOutOfDate
            // 
            this.numericUpDownDaysFilesOutOfDate.Location = new System.Drawing.Point(6, 195);
            this.numericUpDownDaysFilesOutOfDate.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownDaysFilesOutOfDate.Name = "numericUpDownDaysFilesOutOfDate";
            this.numericUpDownDaysFilesOutOfDate.Size = new System.Drawing.Size(370, 20);
            this.numericUpDownDaysFilesOutOfDate.TabIndex = 14;
            // 
            // labelDaysFilesOutOfDate
            // 
            this.labelDaysFilesOutOfDate.AutoSize = true;
            this.labelDaysFilesOutOfDate.Location = new System.Drawing.Point(6, 179);
            this.labelDaysFilesOutOfDate.Name = "labelDaysFilesOutOfDate";
            this.labelDaysFilesOutOfDate.Size = new System.Drawing.Size(311, 13);
            this.labelDaysFilesOutOfDate.TabIndex = 15;
            this.labelDaysFilesOutOfDate.Text = "Number of days after which the imported files should be removed";
            // 
            // UCConfigSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxConfigSettings);
            this.Name = "UCConfigSettings";
            this.Size = new System.Drawing.Size(788, 324);
            this.groupBoxConfigSettings.ResumeLayout(false);
            this.groupBoxImportSettings.ResumeLayout(false);
            this.groupBoxImportSettings.PerformLayout();
            this.groupBoxRemotingSettings.ResumeLayout(false);
            this.groupBoxRemotingSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAuthentication.ResumeLayout(false);
            this.groupBoxAuthentication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysFilesOutOfDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConfigSettings;
        private System.Windows.Forms.GroupBox groupBoxRemotingSettings;
        private System.Windows.Forms.MaskedTextBox textBoxTCPPort;
        private System.Windows.Forms.Label labelTCPPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button checkDBConnectionButton;
        private System.Windows.Forms.GroupBox groupBoxAuthentication;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.RadioButton radioButtonSQLAuthentification;
        private System.Windows.Forms.RadioButton radioButtonIntegratedSecurity;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.TextBox textBoxDataSource;
        private System.Windows.Forms.Label labelDataSource;
        public System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxImportSettings;
        private System.Windows.Forms.Label labelImportSourceFolder;
        private System.Windows.Forms.TextBox textBoxImportSourceFolder;
        private System.Windows.Forms.TextBox textBoxImportImportedFolder;
        private System.Windows.Forms.Label labelImportImportedFolder;
        private System.Windows.Forms.Button ellipsisImportImportedFolder;
        private System.Windows.Forms.Button ellipsisImportSourceFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button ellipsisImportErrorsFolder;
        private System.Windows.Forms.TextBox textBoxImportErrorsFolder;
        private System.Windows.Forms.Label labelImportErrorsFolder;
        private System.Windows.Forms.Button ellipsisImportLogsFolder;
        private System.Windows.Forms.TextBox textBoxImportLogsFolder;
        private System.Windows.Forms.Label labelImportLogsFolder;
        private System.Windows.Forms.Label labelDaysFilesOutOfDate;
        private System.Windows.Forms.NumericUpDown numericUpDownDaysFilesOutOfDate;

    }
}
