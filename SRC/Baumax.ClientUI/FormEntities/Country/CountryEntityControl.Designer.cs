namespace Baumax.ClientUI.FormEntities.Country
{
    partial class CountryEntityControl
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.languageLookUpList = new Baumax.ClientUI.UIControls.LanguageLookUpList();
            this.lbl_Language = new DevExpress.XtraEditors.LabelControl();
            this.lbl_CountryName = new DevExpress.XtraEditors.LabelControl();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.languageLookUpList);
            this.groupControl1.Controls.Add(this.lbl_Language);
            this.groupControl1.Controls.Add(this.lbl_CountryName);
            this.groupControl1.Controls.Add(this.textEditName);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(332, 132);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // languageLookUpList
            // 
            this.languageLookUpList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.languageLookUpList.LanguageID = ((long)(-1));
            this.languageLookUpList.Location = new System.Drawing.Point(18, 88);
            this.languageLookUpList.Name = "languageLookUpList";
            this.languageLookUpList.Size = new System.Drawing.Size(295, 21);
            this.languageLookUpList.TabIndex = 1;
            // 
            // lbl_Language
            // 
            this.lbl_Language.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Language.Location = new System.Drawing.Point(18, 59);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(295, 13);
            this.lbl_Language.TabIndex = 7;
            this.lbl_Language.Text = "Language";
            // 
            // lbl_CountryName
            // 
            this.lbl_CountryName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_CountryName.Location = new System.Drawing.Point(18, 14);
            this.lbl_CountryName.Name = "lbl_CountryName";
            this.lbl_CountryName.Size = new System.Drawing.Size(295, 13);
            this.lbl_CountryName.TabIndex = 5;
            this.lbl_CountryName.Text = "Name";
            // 
            // textEditName
            // 
            this.textEditName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditName.Location = new System.Drawing.Point(16, 33);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 50;
            this.textEditName.Size = new System.Drawing.Size(297, 20);
            this.textEditName.TabIndex = 0;
            // 
            // CountryEntityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "CountryEntityControl";
            this.Size = new System.Drawing.Size(332, 132);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Language;
        private DevExpress.XtraEditors.LabelControl lbl_CountryName;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private Baumax.ClientUI.UIControls.LanguageLookUpList languageLookUpList;
    }
}
