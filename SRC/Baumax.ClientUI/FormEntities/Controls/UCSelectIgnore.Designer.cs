namespace Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning
{
    partial class UCSelectIgnore
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
            this.ed_IgnoreFeasts = new DevExpress.XtraEditors.CheckEdit();
            this.ed_IgnoreClosedDays = new DevExpress.XtraEditors.CheckEdit();
            this.listBox = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.grp_IgnoredDays = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ed_IgnoreFeasts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ed_IgnoreClosedDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_IgnoredDays)).BeginInit();
            this.grp_IgnoredDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // ed_IgnoreFeasts
            // 
            this.ed_IgnoreFeasts.Location = new System.Drawing.Point(3, 3);
            this.ed_IgnoreFeasts.Name = "ed_IgnoreFeasts";
            this.ed_IgnoreFeasts.Properties.Caption = "Ignore fest";
            this.ed_IgnoreFeasts.Size = new System.Drawing.Size(239, 19);
            this.ed_IgnoreFeasts.TabIndex = 0;
            this.ed_IgnoreFeasts.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ed_IgnoreClosedDays
            // 
            this.ed_IgnoreClosedDays.EditValue = true;
            this.ed_IgnoreClosedDays.Location = new System.Drawing.Point(3, 28);
            this.ed_IgnoreClosedDays.Name = "ed_IgnoreClosedDays";
            this.ed_IgnoreClosedDays.Properties.Caption = "Ignore closed days";
            this.ed_IgnoreClosedDays.Size = new System.Drawing.Size(239, 19);
            this.ed_IgnoreClosedDays.TabIndex = 1;
            this.ed_IgnoreClosedDays.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // listBox
            // 
            this.listBox.Appearance.BackColor = System.Drawing.Color.White;
            this.listBox.Appearance.Options.UseBackColor = true;
            this.listBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.listBox.CheckOnClick = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Monday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Tuesday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Wednesday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Thursday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Friday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Saturday"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Sunday")});
            this.listBox.Location = new System.Drawing.Point(2, 20);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(235, 123);
            this.listBox.TabIndex = 2;
            this.listBox.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.listBox_ItemCheck);
            // 
            // grp_IgnoredDays
            // 
            this.grp_IgnoredDays.Controls.Add(this.listBox);
            this.grp_IgnoredDays.Location = new System.Drawing.Point(5, 53);
            this.grp_IgnoredDays.Name = "grp_IgnoredDays";
            this.grp_IgnoredDays.Size = new System.Drawing.Size(239, 145);
            this.grp_IgnoredDays.TabIndex = 3;
            this.grp_IgnoredDays.Text = "Ignored days";
            // 
            // UCSelectIgnore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_IgnoredDays);
            this.Controls.Add(this.ed_IgnoreClosedDays);
            this.Controls.Add(this.ed_IgnoreFeasts);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCSelectIgnore";
            this.Size = new System.Drawing.Size(249, 204);
            ((System.ComponentModel.ISupportInitialize)(this.ed_IgnoreFeasts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ed_IgnoreClosedDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_IgnoredDays)).EndInit();
            this.grp_IgnoredDays.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ed_IgnoreFeasts;
        private DevExpress.XtraEditors.CheckEdit ed_IgnoreClosedDays;
        private DevExpress.XtraEditors.CheckedListBoxControl listBox;
        private DevExpress.XtraEditors.GroupControl grp_IgnoredDays;
    }
}
