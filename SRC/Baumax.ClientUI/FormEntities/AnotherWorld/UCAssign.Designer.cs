namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCAssign
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
            this.components = new System.ComponentModel.Container();
            this.timeRange = new Baumax.ClientUI.FormEntities.AnotherWorld.UCTimeRange();
            this.lbChild = new DevExpress.XtraEditors.LabelControl();
            this.edChild = new DevExpress.XtraEditors.LookUpEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.edParent = new DevExpress.XtraEditors.LookUpEdit();
            this.lbParent = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edChild.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edParent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timeRange
            // 
            this.timeRange.BeginTime = new System.DateTime(((long)(0)));
            this.timeRange.EndTime = new System.DateTime(1, 1, 7, 0, 0, 0, 0);
            this.timeRange.Location = new System.Drawing.Point(14, 122);
            this.timeRange.Name = "timeRange";
            this.timeRange.Size = new System.Drawing.Size(253, 74);
            this.timeRange.TabIndex = 5;
            // 
            // lbChild
            // 
            this.lbChild.Location = new System.Drawing.Point(14, 67);
            this.lbChild.Name = "lbChild";
            this.lbChild.Size = new System.Drawing.Size(23, 13);
            this.lbChild.TabIndex = 3;
            this.lbChild.Text = "Child";
            // 
            // edChild
            // 
            this.edChild.Location = new System.Drawing.Point(14, 86);
            this.edChild.Name = "edChild";
            this.edChild.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.edChild.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.edChild.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edChild.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.edChild.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edChild.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edChild.Properties.DisplayMember = "Name";
            this.edChild.Properties.NullText = "";
            this.edChild.Properties.ShowFooter = false;
            this.edChild.Properties.ShowHeader = false;
            this.edChild.Properties.ValueMember = "ID";
            this.edChild.Size = new System.Drawing.Size(241, 20);
            this.edChild.TabIndex = 1;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // edParent
            // 
            this.edParent.Location = new System.Drawing.Point(14, 31);
            this.edParent.Name = "edParent";
            this.edParent.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.edParent.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.edParent.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edParent.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.edParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edParent.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edParent.Properties.DisplayMember = "Name";
            this.edParent.Properties.NullText = "";
            this.edParent.Properties.ShowFooter = false;
            this.edParent.Properties.ShowHeader = false;
            this.edParent.Properties.ValueMember = "ID";
            this.edParent.Size = new System.Drawing.Size(241, 20);
            this.edParent.TabIndex = 0;
            // 
            // lbParent
            // 
            this.lbParent.Location = new System.Drawing.Point(14, 12);
            this.lbParent.Name = "lbParent";
            this.lbParent.Size = new System.Drawing.Size(32, 13);
            this.lbParent.TabIndex = 7;
            this.lbParent.Text = "Parent";
            // 
            // UCAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbParent);
            this.Controls.Add(this.edParent);
            this.Controls.Add(this.edChild);
            this.Controls.Add(this.lbChild);
            this.Controls.Add(this.timeRange);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCAssign";
            this.Size = new System.Drawing.Size(277, 260);
            ((System.ComponentModel.ISupportInitialize)(this.edChild.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edParent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCTimeRange timeRange;
        private DevExpress.XtraEditors.LabelControl lbChild;
        private DevExpress.XtraEditors.LookUpEdit edChild;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.LookUpEdit edParent;
        private DevExpress.XtraEditors.LabelControl lbParent;
    }
}
