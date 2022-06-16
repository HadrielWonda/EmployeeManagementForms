namespace Baumax.ClientUI.FormEntities.Country.UIColoring
{
    partial class FormColour
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
            this.colorEntityControl1 = new Baumax.ClientUI.FormEntities.Country.UIColoring.ColorEntityControl();
            this.lbl_ModifyCountryColor = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_ModifyCountryColor);
            this.panelTop.Size = new System.Drawing.Size(455, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.colorEntityControl1);
            this.panelClient.Size = new System.Drawing.Size(455, 355);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(12, 8);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(598, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 389);
            this.panelBottom.Size = new System.Drawing.Size(455, 40);
            // 
            // colorEntityControl1
            // 
            this.colorEntityControl1.CountryColor = null;
            this.colorEntityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorEntityControl1.Entity = null;
            this.colorEntityControl1.HighValue = 0;
            this.colorEntityControl1.Location = new System.Drawing.Point(2, 2);
            this.colorEntityControl1.LowValue = 0;
            this.colorEntityControl1.Name = "colorEntityControl1";
            this.colorEntityControl1.Size = new System.Drawing.Size(451, 351);
            this.colorEntityControl1.TabIndex = 0;
            this.colorEntityControl1.XValue = 0;
            this.colorEntityControl1.YValue = 0;
            // 
            // lbl_ModifyCountryColor
            // 
            this.lbl_ModifyCountryColor.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_ModifyCountryColor.Appearance.Options.UseFont = true;
            this.lbl_ModifyCountryColor.Appearance.Options.UseTextOptions = true;
            this.lbl_ModifyCountryColor.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_ModifyCountryColor.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_ModifyCountryColor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_ModifyCountryColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ModifyCountryColor.Location = new System.Drawing.Point(2, 2);
            this.lbl_ModifyCountryColor.Name = "lbl_ModifyCountryColor";
            this.lbl_ModifyCountryColor.Size = new System.Drawing.Size(451, 30);
            this.lbl_ModifyCountryColor.TabIndex = 0;
            this.lbl_ModifyCountryColor.Text = "Edit color";
            // 
            // FormColour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(455, 429);
            this.Name = "FormColour";
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

        private ColorEntityControl colorEntityControl1;
        private DevExpress.XtraEditors.LabelControl lbl_ModifyCountryColor;
    }
}
