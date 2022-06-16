namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormWorldMinMax
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
            this.lbl_MinMaxPersons = new DevExpress.XtraEditors.LabelControl();
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldMinMax();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Controls.Add(this.lbl_MinMaxPersons);
            this.panelTop.Size = new System.Drawing.Size(451, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClient.Controls.Add(this.uc);
            this.panelClient.Size = new System.Drawing.Size(451, 355);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(9, 8);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-960, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Location = new System.Drawing.Point(0, 389);
            this.panelBottom.Size = new System.Drawing.Size(451, 40);
            // 
            // lbl_MinMaxPersons
            // 
            this.lbl_MinMaxPersons.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MinMaxPersons.Appearance.Options.UseFont = true;
            this.lbl_MinMaxPersons.Appearance.Options.UseTextOptions = true;
            this.lbl_MinMaxPersons.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_MinMaxPersons.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_MinMaxPersons.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_MinMaxPersons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_MinMaxPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MinMaxPersons.Location = new System.Drawing.Point(0, 0);
            this.lbl_MinMaxPersons.Name = "lbl_MinMaxPersons";
            this.lbl_MinMaxPersons.Size = new System.Drawing.Size(451, 34);
            this.lbl_MinMaxPersons.TabIndex = 3;
            this.lbl_MinMaxPersons.Text = "Minimum and maximum of persons";
            // 
            // uc
            // 
            this.uc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc.Entity = null;
            this.uc.Location = new System.Drawing.Point(0, 0);
            this.uc.LookAndFeel.SkinName = "iMaginary";
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(451, 355);
            this.uc.TabIndex = 0;
            // 
            // FormWorldMinMax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 429);
            this.EntityControl = this.uc;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormWorldMinMax";
            this.Text = "  ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWorldMinMax_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_MinMaxPersons;
        private UCWorldMinMax uc;
    }
}