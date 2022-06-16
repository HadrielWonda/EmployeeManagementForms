namespace Baumax.ClientUI.FormEntities.EntityStore
{
    partial class CopyingWaitForm
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
            this.bt_OK = new DevExpress.XtraEditors.SimpleButton();
            this.ProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.lb_mess = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_OK
            // 
            this.bt_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_OK.Location = new System.Drawing.Point(214, 91);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 0;
            this.bt_OK.Text = "OK";
            // 
            // ProgressBar
            // 
            this.ProgressBar.EditValue = 0;
            this.ProgressBar.Location = new System.Drawing.Point(31, 57);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(437, 18);
            this.ProgressBar.TabIndex = 2;
            // 
            // lb_mess
            // 
            this.lb_mess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_mess.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_mess.Appearance.Options.UseFont = true;
            this.lb_mess.Location = new System.Drawing.Point(31, 27);
            this.lb_mess.Name = "lb_mess";
            this.lb_mess.Size = new System.Drawing.Size(51, 13);
            this.lb_mess.TabIndex = 3;
            this.lb_mess.Text = "message";
            // 
            // CopyingWaitForm
            // 
            this.AcceptButton = this.bt_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 126);
            this.ControlBox = false;
            this.Controls.Add(this.lb_mess);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.bt_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CopyingWaitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copying";
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bt_OK;
        private DevExpress.XtraEditors.MarqueeProgressBarControl ProgressBar;
        private DevExpress.XtraEditors.LabelControl lb_mess;
    }
}