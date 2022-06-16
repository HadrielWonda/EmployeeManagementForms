namespace Baumax.ClientUI.FormEntities.WorkingModel
{
    partial class FormWorkingModel
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
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.labelCountry = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditCountry = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(305, 0);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.groupControlMain);
            this.panelClient.Location = new System.Drawing.Point(0, 0);
            this.panelClient.Size = new System.Drawing.Size(305, 126);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(61, 5);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-157, 5);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 126);
            this.panelBottom.Size = new System.Drawing.Size(305, 34);
            // 
            // groupControlMain
            // 
            this.groupControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlMain.Controls.Add(this.labelCountry);
            this.groupControlMain.Controls.Add(this.comboBoxEditCountry);
            this.groupControlMain.Controls.Add(this.textEditName);
            this.groupControlMain.Controls.Add(this.labelName);
            this.groupControlMain.Location = new System.Drawing.Point(5, 6);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(295, 114);
            this.groupControlMain.TabIndex = 1;
            this.groupControlMain.Text = "Working Model";
            // 
            // labelCountry
            // 
            this.labelCountry.Location = new System.Drawing.Point(5, 68);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(39, 13);
            this.labelCountry.TabIndex = 16;
            this.labelCountry.Text = "Country";
            // 
            // comboBoxEditCountry
            // 
            this.comboBoxEditCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEditCountry.Location = new System.Drawing.Point(5, 87);
            this.comboBoxEditCountry.Name = "comboBoxEditCountry";
            this.comboBoxEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditCountry.Size = new System.Drawing.Size(283, 20);
            this.comboBoxEditCountry.TabIndex = 15;
            // 
            // textEditName
            // 
            this.textEditName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditName.Location = new System.Drawing.Point(5, 42);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 50;
            this.textEditName.Size = new System.Drawing.Size(283, 20);
            this.textEditName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(5, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(27, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // FormWorkingModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 160);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormWorkingModel";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            this.groupControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.LabelControl labelCountry;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditCountry;
    }
}