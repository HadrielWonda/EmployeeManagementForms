namespace Baumax.ClientUI.General
{
    partial class EstimationWaitForm
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
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_EstimationInProgress = new DevExpress.XtraEditors.LabelControl();
            this.progressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(197, 67);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            // 
            // lbl_EstimationInProgress
            // 
            this.lbl_EstimationInProgress.Location = new System.Drawing.Point(12, 12);
            this.lbl_EstimationInProgress.Name = "lbl_EstimationInProgress";
            this.lbl_EstimationInProgress.Size = new System.Drawing.Size(185, 13);
            this.lbl_EstimationInProgress.TabIndex = 2;
            this.lbl_EstimationInProgress.Text = "Wait please. Estimation is in progress. ";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 32);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(443, 18);
            this.progressBar.TabIndex = 3;
            // 
            // EstimationWaitForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 102);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_EstimationInProgress);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EstimationWaitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estimating";
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.LabelControl lbl_EstimationInProgress;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBar;
    }
}