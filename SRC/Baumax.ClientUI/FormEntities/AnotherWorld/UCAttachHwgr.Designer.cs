namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCAttachHwgr
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
            this.lbl_HWGR = new System.Windows.Forms.Label();
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCTimeRange();
            this.EditHwgr = new DevExpress.XtraEditors.LookUpEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.edWorld = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl_World = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditHwgr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_HWGR
            // 
            this.lbl_HWGR.AutoSize = true;
            this.lbl_HWGR.Location = new System.Drawing.Point(12, 59);
            this.lbl_HWGR.Name = "lbl_HWGR";
            this.lbl_HWGR.Size = new System.Drawing.Size(38, 13);
            this.lbl_HWGR.TabIndex = 0;
            this.lbl_HWGR.Text = "HWGR";
            // 
            // uc
            // 
            this.uc.BeginTime = new System.DateTime(((long)(0)));
            this.uc.EndTime = new System.DateTime(((long)(0)));
            this.uc.Location = new System.Drawing.Point(3, 92);
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(222, 118);
            this.uc.TabIndex = 2;
            // 
            // EditHwgr
            // 
            this.EditHwgr.Location = new System.Drawing.Point(15, 76);
            this.EditHwgr.Name = "EditHwgr";
            this.EditHwgr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EditHwgr.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.EditHwgr.Properties.DisplayMember = "Name";
            this.EditHwgr.Properties.NullText = "";
            this.EditHwgr.Properties.ShowFooter = false;
            this.EditHwgr.Properties.ShowHeader = false;
            this.EditHwgr.Properties.ValidateOnEnterKey = true;
            this.EditHwgr.Properties.ValueMember = "ID";
            this.EditHwgr.Size = new System.Drawing.Size(254, 20);
            this.EditHwgr.TabIndex = 3;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // edWorld
            // 
            this.edWorld.Location = new System.Drawing.Point(15, 25);
            this.edWorld.Name = "edWorld";
            this.edWorld.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edWorld.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edWorld.Properties.DisplayMember = "Name";
            this.edWorld.Properties.NullText = "";
            this.edWorld.Properties.ShowFooter = false;
            this.edWorld.Properties.ShowHeader = false;
            this.edWorld.Properties.ValidateOnEnterKey = true;
            this.edWorld.Properties.ValueMember = "ID";
            this.edWorld.Size = new System.Drawing.Size(254, 20);
            this.edWorld.TabIndex = 5;
            // 
            // lbl_World
            // 
            this.lbl_World.AutoSize = true;
            this.lbl_World.Location = new System.Drawing.Point(12, 9);
            this.lbl_World.Name = "lbl_World";
            this.lbl_World.Size = new System.Drawing.Size(35, 13);
            this.lbl_World.TabIndex = 4;
            this.lbl_World.Text = "World";
            // 
            // UCAttachHwgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edWorld);
            this.Controls.Add(this.lbl_World);
            this.Controls.Add(this.EditHwgr);
            this.Controls.Add(this.lbl_HWGR);
            this.Controls.Add(this.uc);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCAttachHwgr";
            this.Size = new System.Drawing.Size(284, 222);
            ((System.ComponentModel.ISupportInitialize)(this.EditHwgr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edWorld.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_HWGR;
        private UCTimeRange uc;
        private DevExpress.XtraEditors.LookUpEdit EditHwgr;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.LookUpEdit edWorld;
        private System.Windows.Forms.Label lbl_World;
    }
}
