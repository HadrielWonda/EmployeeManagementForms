namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormChangeTime
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
            this.components = new System.ComponentModel.Container();
            this.timeRange = new Baumax.ClientUI.FormEntities.AnotherWorld.UCChangeTime();
            this.lbl_ChangeTimeRange = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_ChangeTimeRange);
            this.panelTop.Size = new System.Drawing.Size(265, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.timeRange);
            this.panelClient.Size = new System.Drawing.Size(265, 162);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 6);
            this.button_OK.Size = new System.Drawing.Size(74, 23);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1660, 6);
            this.button_Cancel.Size = new System.Drawing.Size(72, 23);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 196);
            this.panelBottom.Size = new System.Drawing.Size(265, 40);
            // 
            // timeRange
            // 
            this.timeRange.BeginTime = new System.DateTime(2007, 7, 31, 21, 33, 3, 361);
            this.timeRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeRange.EndTime = new System.DateTime(2007, 7, 31, 21, 33, 3, 361);
            this.timeRange.Entity = null;
            this.timeRange.Location = new System.Drawing.Point(2, 2);
            this.timeRange.LookAndFeel.SkinName = "iMaginary";
            this.timeRange.Modified = true;
            this.timeRange.Name = "timeRange";
            this.timeRange.Size = new System.Drawing.Size(261, 158);
            this.timeRange.TabIndex = 0;
            // 
            // lbl_ChangeTimeRange
            // 
            this.lbl_ChangeTimeRange.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_ChangeTimeRange.Appearance.Options.UseFont = true;
            this.lbl_ChangeTimeRange.Appearance.Options.UseTextOptions = true;
            this.lbl_ChangeTimeRange.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_ChangeTimeRange.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_ChangeTimeRange.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_ChangeTimeRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ChangeTimeRange.Location = new System.Drawing.Point(2, 2);
            this.lbl_ChangeTimeRange.Name = "lbl_ChangeTimeRange";
            this.lbl_ChangeTimeRange.Size = new System.Drawing.Size(261, 30);
            this.lbl_ChangeTimeRange.TabIndex = 1;
            this.lbl_ChangeTimeRange.Text = "Change time range";
            // 
            // FormChangeTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 236);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormChangeTime";
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

        private UCChangeTime timeRange;
        private DevExpress.XtraEditors.LabelControl lbl_ChangeTimeRange;


    }
}