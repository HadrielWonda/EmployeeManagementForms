namespace Baumax.ClientUI.FormEntities.Language
{
    partial class FormLanguage
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
            this.labelCode = new DevExpress.XtraEditors.LabelControl();
            this.textEditCode = new DevExpress.XtraEditors.TextEdit();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(463, 1);
            this.panelTop.TabIndex = 10;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.groupControlMain);
            this.panelClient.Location = new System.Drawing.Point(0, 1);
            this.panelClient.Size = new System.Drawing.Size(463, 130);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.button_OK.Location = new System.Drawing.Point(5, 6);
            this.button_OK.Size = new System.Drawing.Size(104, 23);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(35, 5);
            this.button_Cancel.Size = new System.Drawing.Size(90, 23);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 131);
            this.panelBottom.Size = new System.Drawing.Size(463, 34);
            this.panelBottom.TabIndex = 8;
            // 
            // groupControlMain
            // 
            this.groupControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlMain.Controls.Add(this.labelCode);
            this.groupControlMain.Controls.Add(this.textEditCode);
            this.groupControlMain.Controls.Add(this.labelName);
            this.groupControlMain.Controls.Add(this.textEditName);
            this.groupControlMain.Location = new System.Drawing.Point(5, 5);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(453, 119);
            this.groupControlMain.TabIndex = 1;
            this.groupControlMain.Text = "Language";
            // 
            // labelCode
            // 
            this.labelCode.Location = new System.Drawing.Point(7, 71);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(25, 13);
            this.labelCode.TabIndex = 7;
            this.labelCode.Text = "Code";
            // 
            // textEditCode
            // 
            this.textEditCode.Location = new System.Drawing.Point(7, 90);
            this.textEditCode.Name = "textEditCode";
            this.textEditCode.Properties.Mask.EditMask = "[a-z]{2}-[A-Z]{2}";
            this.textEditCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditCode.Properties.MaxLength = 5;
            this.textEditCode.Size = new System.Drawing.Size(62, 20);
            this.textEditCode.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(7, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(27, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name";
            // 
            // textEditName
            // 
            this.textEditName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditName.Location = new System.Drawing.Point(7, 42);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 50;
            this.textEditName.Size = new System.Drawing.Size(439, 20);
            this.textEditName.TabIndex = 2;
            // 
            // FormLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 165);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormLanguage";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            this.groupControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.LabelControl labelCode;
        private DevExpress.XtraEditors.TextEdit textEditCode;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.TextEdit textEditName;
    }
}