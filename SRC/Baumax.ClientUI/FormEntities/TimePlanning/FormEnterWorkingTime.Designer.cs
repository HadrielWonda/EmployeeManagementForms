namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class FormEnterWorkingTime
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
            this.teBegin = new DevExpress.XtraEditors.TextEdit();
            this.teEnd = new DevExpress.XtraEditors.TextEdit();
            this.lbl_From = new DevExpress.XtraEditors.LabelControl();
            this.lbl_To = new DevExpress.XtraEditors.LabelControl();
            this.lbl_EnterWorkingTime = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_EnterWorkingTime);
            this.panelTop.Size = new System.Drawing.Size(295, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.lbl_To);
            this.panelClient.Controls.Add(this.lbl_From);
            this.panelClient.Controls.Add(this.teEnd);
            this.panelClient.Controls.Add(this.teBegin);
            this.panelClient.Size = new System.Drawing.Size(295, 39);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1463, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 73);
            this.panelBottom.Size = new System.Drawing.Size(295, 40);
            // 
            // teBegin
            // 
            this.teBegin.EditValue = "06:00";
            this.teBegin.Location = new System.Drawing.Point(53, 6);
            this.teBegin.Name = "teBegin";
            this.teBegin.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:[0-5]\\d";
            this.teBegin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teBegin.Size = new System.Drawing.Size(77, 20);
            this.teBegin.TabIndex = 0;
            // 
            // teEnd
            // 
            this.teEnd.EditValue = "18:00";
            this.teEnd.Location = new System.Drawing.Point(185, 6);
            this.teEnd.Name = "teEnd";
            this.teEnd.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:[0-5]\\d";
            this.teEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teEnd.Size = new System.Drawing.Size(79, 20);
            this.teEnd.TabIndex = 1;
            // 
            // lbl_From
            // 
            this.lbl_From.Location = new System.Drawing.Point(5, 9);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(24, 13);
            this.lbl_From.TabIndex = 2;
            this.lbl_From.Text = "From";
            // 
            // lbl_To
            // 
            this.lbl_To.Location = new System.Drawing.Point(151, 9);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(12, 13);
            this.lbl_To.TabIndex = 3;
            this.lbl_To.Text = "To";
            // 
            // lbl_EnterWorkingTime
            // 
            this.lbl_EnterWorkingTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_EnterWorkingTime.Appearance.Options.UseFont = true;
            this.lbl_EnterWorkingTime.Appearance.Options.UseTextOptions = true;
            this.lbl_EnterWorkingTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_EnterWorkingTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_EnterWorkingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_EnterWorkingTime.Location = new System.Drawing.Point(2, 2);
            this.lbl_EnterWorkingTime.Name = "lbl_EnterWorkingTime";
            this.lbl_EnterWorkingTime.Size = new System.Drawing.Size(291, 30);
            this.lbl_EnterWorkingTime.TabIndex = 0;
            this.lbl_EnterWorkingTime.Text = "Enter working time";
            // 
            // FormEnterWorkingTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 113);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormEnterWorkingTime";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit teEnd;
        private DevExpress.XtraEditors.TextEdit teBegin;
        private DevExpress.XtraEditors.LabelControl lbl_From;
        private DevExpress.XtraEditors.LabelControl lbl_EnterWorkingTime;
        private DevExpress.XtraEditors.LabelControl lbl_To;
    }
}