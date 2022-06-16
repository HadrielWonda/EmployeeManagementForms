namespace Baumax.ClientUI.FormEntities.Language
{
    partial class UCLanguageEntity
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
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.label_LanguageName = new DevExpress.XtraEditors.LabelControl();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlMain
            // 
            this.groupControlMain.Controls.Add(this.label_LanguageName);
            this.groupControlMain.Controls.Add(this.textEditName);
            this.groupControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMain.Location = new System.Drawing.Point(0, 0);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.ShowCaption = false;
            this.groupControlMain.Size = new System.Drawing.Size(291, 66);
            this.groupControlMain.TabIndex = 0;
            this.groupControlMain.Text = "Language";
            // 
            // label_LanguageName
            // 
            this.label_LanguageName.Location = new System.Drawing.Point(7, 5);
            this.label_LanguageName.Name = "label_LanguageName";
            this.label_LanguageName.Size = new System.Drawing.Size(27, 13);
            this.label_LanguageName.TabIndex = 6;
            this.label_LanguageName.Text = "Name";
            // 
            // textEditName
            // 
            this.textEditName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditName.Location = new System.Drawing.Point(7, 24);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 50;
            this.textEditName.Size = new System.Drawing.Size(277, 20);
            this.textEditName.TabIndex = 0;
            // 
            // UCLanguageEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlMain);
            this.Name = "UCLanguageEntity";
            this.Size = new System.Drawing.Size(291, 66);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            this.groupControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.LabelControl label_LanguageName;
        private DevExpress.XtraEditors.TextEdit textEditName;
    }
}
