namespace Baumax.ClientUI.FormEntities.Country
{
    partial class ClosedDaysForm
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
            this.lbl_NewClosedDays = new DevExpress.XtraEditors.LabelControl();
            this.closedDayEntityControl1 = new Baumax.ClientUI.FormEntities.Country.ClosedDayEntityControl();
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
            this.panelTop.Controls.Add(this.lbl_NewClosedDays);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.None;
            this.panelTop.Size = new System.Drawing.Size(463, 30);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.closedDayEntityControl1);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.None;
            this.panelClient.Location = new System.Drawing.Point(0, 27);
            this.panelClient.Size = new System.Drawing.Size(463, 209);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-5246, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 234);
            this.panelBottom.Size = new System.Drawing.Size(462, 40);
            // 
            // lbl_NewClosedDays
            // 
            this.lbl_NewClosedDays.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_NewClosedDays.Appearance.Options.UseFont = true;
            this.lbl_NewClosedDays.Appearance.Options.UseTextOptions = true;
            this.lbl_NewClosedDays.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_NewClosedDays.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_NewClosedDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_NewClosedDays.Location = new System.Drawing.Point(2, 2);
            this.lbl_NewClosedDays.Name = "lbl_NewClosedDays";
            this.lbl_NewClosedDays.Size = new System.Drawing.Size(459, 26);
            this.lbl_NewClosedDays.TabIndex = 0;
            this.lbl_NewClosedDays.Text = "New Closed DayMasks";
            // 
            // closedDayEntityControl1
            // 
            this.closedDayEntityControl1.Country = null;
            this.closedDayEntityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closedDayEntityControl1.Entity = null;
            this.closedDayEntityControl1.Location = new System.Drawing.Point(2, 2);
            this.closedDayEntityControl1.LookAndFeel.SkinName = "iMaginary";
            this.closedDayEntityControl1.Name = "closedDayEntityControl1";
            this.closedDayEntityControl1.Size = new System.Drawing.Size(459, 205);
            this.closedDayEntityControl1.TabIndex = 0;
            // 
            // ClosedDaysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 274);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "ClosedDaysForm";
            this.Text = "    ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClosedDaysForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_WorkingDays;
        private DevExpress.XtraEditors.LabelControl lbl_NewClosedDays;
        private ClosedDayEntityControl closedDayEntityControl1;
        
    }
}