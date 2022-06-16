namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormWorldMinMaxEdit
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
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCWorldMinMaxEntity();
            this.lbAddRecord = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbAddRecord);
            this.panelTop.Size = new System.Drawing.Size(407, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClient.Controls.Add(this.uc);
            this.panelClient.Size = new System.Drawing.Size(407, 124);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(9, 8);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1505, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Location = new System.Drawing.Point(0, 158);
            this.panelBottom.Size = new System.Drawing.Size(407, 40);
            // 
            // uc
            // 
            this.uc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc.Entity = null;
            this.uc.Location = new System.Drawing.Point(0, 0);
            this.uc.LookAndFeel.SkinName = "iMaginary";
            this.uc.Modified = true;
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(407, 124);
            this.uc.TabIndex = 0;
            // 
            // lbAddRecord
            // 
            this.lbAddRecord.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbAddRecord.Appearance.Options.UseFont = true;
            this.lbAddRecord.Appearance.Options.UseTextOptions = true;
            this.lbAddRecord.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbAddRecord.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbAddRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAddRecord.Location = new System.Drawing.Point(0, 0);
            this.lbAddRecord.Name = "lbAddRecord";
            this.lbAddRecord.Size = new System.Drawing.Size(407, 34);
            this.lbAddRecord.TabIndex = 0;
            // 
            // FormWorldMinMaxEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 198);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormWorldMinMaxEdit";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCWorldMinMaxEntity uc;
        private DevExpress.XtraEditors.LabelControl lbAddRecord;
    }
}