namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    partial class UCCashDeskWeeklyInfo
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
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lblAvailableWorldBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.lblMaximumPresence = new DevExpress.XtraEditors.LabelControl();
            this.lblMinimumPresence = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.lblAvailableWorldBufferHours);
            this.panelControl4.Controls.Add(this.lblMaximumPresence);
            this.panelControl4.Controls.Add(this.lblMinimumPresence);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(582, 25);
            this.panelControl4.TabIndex = 5;
            // 
            // lblAvailableWorldBufferHours
            // 
            this.lblAvailableWorldBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAvailableWorldBufferHours.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAvailableWorldBufferHours.Location = new System.Drawing.Point(310, 2);
            this.lblAvailableWorldBufferHours.Name = "lblAvailableWorldBufferHours";
            this.lblAvailableWorldBufferHours.Size = new System.Drawing.Size(208, 15);
            this.lblAvailableWorldBufferHours.TabIndex = 13;
            this.lblAvailableWorldBufferHours.Text = "Available world buffer hours :";
            // 
            // lblMaximumPresence
            // 
            this.lblMaximumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMaximumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMaximumPresence.Location = new System.Drawing.Point(149, 2);
            this.lblMaximumPresence.Name = "lblMaximumPresence";
            this.lblMaximumPresence.Size = new System.Drawing.Size(136, 15);
            this.lblMaximumPresence.TabIndex = 12;
            this.lblMaximumPresence.Text = "Maximum presence:";
            // 
            // lblMinimumPresence
            // 
            this.lblMinimumPresence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMinimumPresence.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMinimumPresence.Location = new System.Drawing.Point(5, 2);
            this.lblMinimumPresence.Name = "lblMinimumPresence";
            this.lblMinimumPresence.Size = new System.Drawing.Size(136, 15);
            this.lblMinimumPresence.TabIndex = 11;
            this.lblMinimumPresence.Text = "Minimum presence:";
            // 
            // UCCashDeskWeeklyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl4);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCCashDeskWeeklyInfo";
            this.Size = new System.Drawing.Size(582, 25);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl lblAvailableWorldBufferHours;
        private DevExpress.XtraEditors.LabelControl lblMaximumPresence;
        private DevExpress.XtraEditors.LabelControl lblMinimumPresence;
    }
}
