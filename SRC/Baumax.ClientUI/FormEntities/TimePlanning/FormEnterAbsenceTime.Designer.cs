namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class FormEnterAbsenceTime
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
            this.lbl_EnterAbsenceTime = new DevExpress.XtraEditors.LabelControl();
            this.lbl_To = new DevExpress.XtraEditors.LabelControl();
            this.lbl_From = new DevExpress.XtraEditors.LabelControl();
            this.teEnd = new DevExpress.XtraEditors.TextEdit();
            this.teBegin = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_EnterAbsenceTime);
            this.panelTop.Size = new System.Drawing.Size(300, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClient.Controls.Add(this.lbl_To);
            this.panelClient.Controls.Add(this.lbl_From);
            this.panelClient.Controls.Add(this.teEnd);
            this.panelClient.Controls.Add(this.teBegin);
            this.panelClient.Size = new System.Drawing.Size(300, 47);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(9, 8);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1056, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Location = new System.Drawing.Point(0, 81);
            this.panelBottom.Size = new System.Drawing.Size(300, 40);
            // 
            // lbl_EnterAbsenceTime
            // 
            this.lbl_EnterAbsenceTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_EnterAbsenceTime.Appearance.Options.UseFont = true;
            this.lbl_EnterAbsenceTime.Appearance.Options.UseTextOptions = true;
            this.lbl_EnterAbsenceTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_EnterAbsenceTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_EnterAbsenceTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_EnterAbsenceTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_EnterAbsenceTime.Location = new System.Drawing.Point(2, 2);
            this.lbl_EnterAbsenceTime.Name = "lbl_EnterAbsenceTime";
            this.lbl_EnterAbsenceTime.Size = new System.Drawing.Size(296, 30);
            this.lbl_EnterAbsenceTime.TabIndex = 1;
            this.lbl_EnterAbsenceTime.Text = "Enter absence time";
            // 
            // lbl_To
            // 
            this.lbl_To.Location = new System.Drawing.Point(158, 19);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(12, 13);
            this.lbl_To.TabIndex = 7;
            this.lbl_To.Text = "To";
            this.lbl_To.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // lbl_From
            // 
            this.lbl_From.Location = new System.Drawing.Point(12, 19);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(24, 13);
            this.lbl_From.TabIndex = 6;
            this.lbl_From.Text = "From";
            // 
            // teEnd
            // 
            this.teEnd.EditValue = "18:00";
            this.teEnd.Location = new System.Drawing.Point(187, 18);
            this.teEnd.Name = "teEnd";
            this.teEnd.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:[0-5]\\d";
            this.teEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teEnd.Size = new System.Drawing.Size(100, 20);
            this.teEnd.TabIndex = 5;
            // 
            // teBegin
            // 
            this.teBegin.EditValue = "06:00";
            this.teBegin.Location = new System.Drawing.Point(44, 18);
            this.teBegin.Name = "teBegin";
            this.teBegin.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:[0-5]\\d";
            this.teBegin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teBegin.Size = new System.Drawing.Size(100, 20);
            this.teBegin.TabIndex = 4;
            // 
            // FormEnterAbsenceTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 121);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormEnterAbsenceTime";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_EnterAbsenceTime;
        private DevExpress.XtraEditors.LabelControl lbl_To;
        private DevExpress.XtraEditors.LabelControl lbl_From;
        private DevExpress.XtraEditors.TextEdit teEnd;
        private DevExpress.XtraEditors.TextEdit teBegin;
    }
}