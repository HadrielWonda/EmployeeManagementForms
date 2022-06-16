namespace Baumax.ClientUI.FormEntities.Region
{
    partial class RegionCtrl
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
            this.grpRegion = new DevExpress.XtraEditors.GroupControl();
            this.lookUpCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.ceImported = new DevExpress.XtraEditors.CheckEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpRegion)).BeginInit();
            this.grpRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceImported.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRegion
            // 
            this.grpRegion.Controls.Add(this.lookUpCountry);
            this.grpRegion.Controls.Add(this.ceImported);
            this.grpRegion.Controls.Add(this.teName);
            this.grpRegion.Controls.Add(this.labelControl1);
            this.grpRegion.Controls.Add(this.lblName);
            this.grpRegion.Location = new System.Drawing.Point(3, 3);
            this.grpRegion.Name = "grpRegion";
            this.grpRegion.Size = new System.Drawing.Size(228, 151);
            this.grpRegion.TabIndex = 0;
            this.grpRegion.Text = "Region";
            // 
            // lookUpCountry
            // 
            this.lookUpCountry.Location = new System.Drawing.Point(6, 90);
            this.lookUpCountry.Name = "lookUpCountry";
            this.lookUpCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCountry.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpCountry.Properties.DisplayMember = "Name";
            this.lookUpCountry.Properties.NullText = "";
            this.lookUpCountry.Properties.ValueMember = "ID";
            this.lookUpCountry.Size = new System.Drawing.Size(214, 20);
            this.lookUpCountry.TabIndex = 3;
            // 
            // ceImported
            // 
            this.ceImported.Enabled = false;
            this.ceImported.Location = new System.Drawing.Point(5, 126);
            this.ceImported.Name = "ceImported";
            this.ceImported.Properties.Caption = "Imported";
            this.ceImported.Size = new System.Drawing.Size(75, 19);
            this.ceImported.TabIndex = 2;
            this.ceImported.ToolTip = "Imported ite, can not be edited.";
            this.ceImported.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(6, 44);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(214, 20);
            this.teName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Country";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(6, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(27, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // RegionCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRegion);
            this.Name = "RegionCtrl";
            this.Size = new System.Drawing.Size(236, 160);
            ((System.ComponentModel.ISupportInitialize)(this.grpRegion)).EndInit();
            this.grpRegion.ResumeLayout(false);
            this.grpRegion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceImported.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpRegion;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.CheckEdit ceImported;
        private DevExpress.XtraEditors.LookUpEdit lookUpCountry;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
