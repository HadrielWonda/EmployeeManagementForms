namespace Baumax.ClientUI.FormEntities.Country
{
    partial class EstimatePreconditionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimatePreconditionsForm));
            this.grp_EstimatePreconditions = new DevExpress.XtraEditors.GroupControl();
            this.imageListBox = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btn_EstimateButton = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_EstimateMuchTime = new DevExpress.XtraEditors.LabelControl();
            this.spin_Year = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_Year = new DevExpress.XtraEditors.LabelControl();
            this.btn_Validate = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CopyBH = new DevExpress.XtraEditors.SimpleButton();
            this.lbCountry = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grp_EstimatePreconditions)).BeginInit();
            this.grp_EstimatePreconditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_Year.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_EstimatePreconditions
            // 
            this.grp_EstimatePreconditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_EstimatePreconditions.Controls.Add(this.imageListBox);
            this.grp_EstimatePreconditions.Location = new System.Drawing.Point(12, 38);
            this.grp_EstimatePreconditions.Name = "grp_EstimatePreconditions";
            this.grp_EstimatePreconditions.Size = new System.Drawing.Size(962, 221);
            this.grp_EstimatePreconditions.TabIndex = 0;
            this.grp_EstimatePreconditions.Text = "Conditions";
            // 
            // imageListBox
            // 
            this.imageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBox.HorizontalScrollbar = true;
            this.imageListBox.HotTrackItems = true;
            this.imageListBox.ImageList = this.imageCollection;
            this.imageListBox.Location = new System.Drawing.Point(2, 20);
            this.imageListBox.Name = "imageListBox";
            this.imageListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.imageListBox.Size = new System.Drawing.Size(958, 199);
            this.imageListBox.TabIndex = 0;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // btn_EstimateButton
            // 
            this.btn_EstimateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_EstimateButton.Location = new System.Drawing.Point(12, 298);
            this.btn_EstimateButton.Name = "btn_EstimateButton";
            this.btn_EstimateButton.Size = new System.Drawing.Size(162, 23);
            this.btn_EstimateButton.TabIndex = 1;
            this.btn_EstimateButton.Text = "Start Estimation";
            this.btn_EstimateButton.Click += new System.EventHandler(this.btn_EstimateButton_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_Cancel.Location = new System.Drawing.Point(812, 298);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(162, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            // 
            // lbl_EstimateMuchTime
            // 
            this.lbl_EstimateMuchTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_EstimateMuchTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_EstimateMuchTime.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_EstimateMuchTime.Appearance.Options.UseFont = true;
            this.lbl_EstimateMuchTime.Appearance.Options.UseForeColor = true;
            this.lbl_EstimateMuchTime.Appearance.Options.UseTextOptions = true;
            this.lbl_EstimateMuchTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_EstimateMuchTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_EstimateMuchTime.Location = new System.Drawing.Point(12, 257);
            this.lbl_EstimateMuchTime.Name = "lbl_EstimateMuchTime";
            this.lbl_EstimateMuchTime.Size = new System.Drawing.Size(962, 26);
            this.lbl_EstimateMuchTime.TabIndex = 2;
            this.lbl_EstimateMuchTime.Text = "Warning!";
            // 
            // spin_Year
            // 
            this.spin_Year.EditValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spin_Year.Location = new System.Drawing.Point(161, 12);
            this.spin_Year.Name = "spin_Year";
            this.spin_Year.Properties.AllowFocused = false;
            this.spin_Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_Year.Properties.IsFloatValue = false;
            this.spin_Year.Properties.Mask.EditMask = "f0";
            this.spin_Year.Properties.MaxLength = 4;
            this.spin_Year.Properties.MaxValue = new decimal(new int[] {
            2078,
            0,
            0,
            0});
            this.spin_Year.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spin_Year.Size = new System.Drawing.Size(100, 20);
            this.spin_Year.TabIndex = 3;
            this.spin_Year.EditValueChanged += new System.EventHandler(this.spin_Year_EditValueChanged);
            // 
            // lbl_Year
            // 
            this.lbl_Year.Appearance.Options.UseTextOptions = true;
            this.lbl_Year.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbl_Year.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Year.Location = new System.Drawing.Point(14, 13);
            this.lbl_Year.Name = "lbl_Year";
            this.lbl_Year.Size = new System.Drawing.Size(141, 17);
            this.lbl_Year.TabIndex = 4;
            this.lbl_Year.Text = "Year";
            // 
            // btn_Validate
            // 
            this.btn_Validate.Location = new System.Drawing.Point(279, 9);
            this.btn_Validate.Name = "btn_Validate";
            this.btn_Validate.Size = new System.Drawing.Size(200, 23);
            this.btn_Validate.TabIndex = 5;
            this.btn_Validate.Text = "Validate";
            this.btn_Validate.Click += new System.EventHandler(this.btn_Validate_Click);
            // 
            // btn_CopyBH
            // 
            this.btn_CopyBH.Location = new System.Drawing.Point(857, 9);
            this.btn_CopyBH.Name = "btn_CopyBH";
            this.btn_CopyBH.Size = new System.Drawing.Size(115, 23);
            this.btn_CopyBH.TabIndex = 6;
            this.btn_CopyBH.Text = "Copy Buffer Hours";
            this.btn_CopyBH.Visible = false;
            this.btn_CopyBH.Click += new System.EventHandler(this.btn_CopyBH_Click);
            // 
            // lbCountry
            // 
            this.lbCountry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbCountry.Appearance.Options.UseFont = true;
            this.lbCountry.Location = new System.Drawing.Point(502, 15);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(75, 13);
            this.lbCountry.TabIndex = 7;
            this.lbCountry.Text = "labelControl1";
            this.lbCountry.Visible = false;
            // 
            // EstimatePreconditionsForm
            // 
            this.AcceptButton = this.btn_EstimateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(985, 333);
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.btn_CopyBH);
            this.Controls.Add(this.btn_Validate);
            this.Controls.Add(this.lbl_Year);
            this.Controls.Add(this.spin_Year);
            this.Controls.Add(this.lbl_EstimateMuchTime);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_EstimateButton);
            this.Controls.Add(this.grp_EstimatePreconditions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimatePreconditionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estimation preconditions";
            ((System.ComponentModel.ISupportInitialize)(this.grp_EstimatePreconditions)).EndInit();
            this.grp_EstimatePreconditions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_Year.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grp_EstimatePreconditions;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btn_EstimateButton;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.LabelControl lbl_EstimateMuchTime;
        private DevExpress.XtraEditors.SpinEdit spin_Year;
        private DevExpress.XtraEditors.LabelControl lbl_Year;
        private DevExpress.XtraEditors.SimpleButton btn_Validate;
        protected DevExpress.XtraEditors.ImageListBoxControl imageListBox;
        protected DevExpress.XtraEditors.SimpleButton btn_CopyBH;
        protected DevExpress.XtraEditors.LabelControl lbCountry;

    }
}