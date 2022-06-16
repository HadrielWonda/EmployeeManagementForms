namespace Baumax.ClientUI.FormEntities.Country.LunchBrakes
{
    partial class FormLunchModel
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
            this.ecLunchModel1 = new Baumax.ClientUI.FormEntities.Country.LunchBrakes.ECLunchModel();
            this.lb_lunchModel = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lb_lunchModel);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ecLunchModel1);
            this.panelClient.Size = new System.Drawing.Size(355, 253);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 287);
            // 
            // ecLunchModel1
            // 
            this.ecLunchModel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecLunchModel1.Entity = null;
            this.ecLunchModel1.Location = new System.Drawing.Point(2, 2);
            this.ecLunchModel1.LookAndFeel.SkinName = "iMaginary";
            this.ecLunchModel1.LunchModelEntity = null;
            this.ecLunchModel1.Name = "ecLunchModel1";
            this.ecLunchModel1.Size = new System.Drawing.Size(351, 249);
            this.ecLunchModel1.TabIndex = 0;
            // 
            // lb_lunchModel
            // 
            this.lb_lunchModel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_lunchModel.Appearance.Options.UseFont = true;
            this.lb_lunchModel.Appearance.Options.UseTextOptions = true;
            this.lb_lunchModel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lb_lunchModel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lb_lunchModel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_lunchModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_lunchModel.Location = new System.Drawing.Point(2, 2);
            this.lb_lunchModel.Name = "lb_lunchModel";
            this.lb_lunchModel.Size = new System.Drawing.Size(622, 30);
            this.lb_lunchModel.TabIndex = 0;
            this.lb_lunchModel.Text = "Lunch Model";
            // 
            // FormLunchModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 327);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormLunchModel";
            this.Text = "FormLunchModel";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ECLunchModel ecLunchModel1;
        public DevExpress.XtraEditors.LabelControl lb_lunchModel;
    }
}