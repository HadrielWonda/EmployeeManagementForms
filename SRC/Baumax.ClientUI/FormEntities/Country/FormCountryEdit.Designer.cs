namespace Baumax.ClientUI.FormEntities.Country
{
    partial class FormCountryEdit
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
            this.ucCountryEdit1 = new Baumax.ClientUI.FormEntities.Country.UCCountryEdit();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Country = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCaption);
            this.panelTop.Size = new System.Drawing.Size(1012, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucCountryEdit1);
            this.panelClient.Controls.Add(this.panelControl2);
            this.panelClient.Size = new System.Drawing.Size(1012, 523);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(11, 14);
            this.button_OK.Visible = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(5851, 14);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 557);
            this.panelBottom.Size = new System.Drawing.Size(1012, 53);
            // 
            // ucCountryEdit1
            // 
            this.ucCountryEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCountryEdit1.Entity = null;
            this.ucCountryEdit1.EntityCountry = null;
            this.ucCountryEdit1.Location = new System.Drawing.Point(2, 32);
            this.ucCountryEdit1.LookAndFeel.SkinName = "iMaginary";
            this.ucCountryEdit1.Name = "ucCountryEdit1";
            this.ucCountryEdit1.Size = new System.Drawing.Size(1008, 489);
            this.ucCountryEdit1.TabIndex = 1;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(1008, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Edit country";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.textEdit1);
            this.panelControl2.Controls.Add(this.lbl_Country);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1008, 30);
            this.panelControl2.TabIndex = 2;
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(111, 5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(642, 21);
            this.textEdit1.TabIndex = 2;
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Country.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Country.Location = new System.Drawing.Point(2, 2);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(103, 26);
            this.lbl_Country.TabIndex = 0;
            this.lbl_Country.Text = "Country:";
            // 
            // FormCountryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 610);
            this.ControlBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1020, 640);
            this.Name = "FormCountryEdit";
            this.ShowIcon = false;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UCCountryEdit ucCountryEdit1;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl lbl_Country;
    }
}