namespace Baumax.Client
{
    partial class FormWait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWait));
            this.lbl_WaitPlease = new DevExpress.XtraEditors.LabelControl();
            this.marqueeProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_WaitPlease
            // 
            this.lbl_WaitPlease.Appearance.Font = new System.Drawing.Font("Lucida Sans Unicode", 10F);
            this.lbl_WaitPlease.Appearance.Options.UseFont = true;
            this.lbl_WaitPlease.Location = new System.Drawing.Point(13, 96);
            this.lbl_WaitPlease.Name = "lbl_WaitPlease";
            this.lbl_WaitPlease.Size = new System.Drawing.Size(83, 16);
            this.lbl_WaitPlease.TabIndex = 1;
            this.lbl_WaitPlease.Text = "Wait please...";
            this.lbl_WaitPlease.UseWaitCursor = true;
            // 
            // marqueeProgressBar
            // 
            this.marqueeProgressBar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.marqueeProgressBar.EditValue = 0;
            this.marqueeProgressBar.Location = new System.Drawing.Point(13, 118);
            this.marqueeProgressBar.Name = "marqueeProgressBar";
            this.marqueeProgressBar.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.marqueeProgressBar.Properties.Appearance.Options.UseBackColor = true;
            this.marqueeProgressBar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.marqueeProgressBar.Properties.EndColor = System.Drawing.Color.DarkOrange;
            this.marqueeProgressBar.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.marqueeProgressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.marqueeProgressBar.Properties.StartColor = System.Drawing.Color.Yellow;
            this.marqueeProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.marqueeProgressBar.ShowToolTips = false;
            this.marqueeProgressBar.Size = new System.Drawing.Size(302, 18);
            this.marqueeProgressBar.TabIndex = 2;
            this.marqueeProgressBar.UseWaitCursor = true;
            // 
            // FormWait
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Baumax.Client.Properties.Resources.storage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.ClientSize = new System.Drawing.Size(476, 148);
            this.ControlBox = false;
            this.Controls.Add(this.marqueeProgressBar);
            this.Controls.Add(this.lbl_WaitPlease);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWait";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_WaitPlease;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBar;
    }
}