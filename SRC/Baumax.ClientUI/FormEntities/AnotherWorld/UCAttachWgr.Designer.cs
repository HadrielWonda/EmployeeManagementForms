namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCAttachWgr
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
            this.lbl_WGR = new DevExpress.XtraEditors.LabelControl();
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCTimeRange();
            this.edWGR = new DevExpress.XtraEditors.LookUpEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edWGR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_WGR
            // 
            this.lbl_WGR.Location = new System.Drawing.Point(14, 12);
            this.lbl_WGR.Name = "lbl_WGR";
            this.lbl_WGR.Size = new System.Drawing.Size(24, 13);
            this.lbl_WGR.TabIndex = 0;
            this.lbl_WGR.Text = "WGR";
            // 
            // uc
            // 
            this.uc.BeginTime = new System.DateTime(2007, 7, 31, 12, 18, 58, 861);
            this.uc.EndTime = new System.DateTime(((long)(0)));
            this.uc.Location = new System.Drawing.Point(3, 45);
            this.uc.Name = "uc";
            this.uc.Size = new System.Drawing.Size(290, 118);
            this.uc.TabIndex = 2;
            // 
            // edWGR
            // 
            this.edWGR.Location = new System.Drawing.Point(14, 32);
            this.edWGR.Name = "edWGR";
            this.edWGR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edWGR.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edWGR.Properties.DisplayMember = "Name";
            this.edWGR.Properties.NullText = "";
            this.edWGR.Properties.ShowFooter = false;
            this.edWGR.Properties.ShowHeader = false;
            this.edWGR.Properties.ValueMember = "ID";
            this.edWGR.Size = new System.Drawing.Size(279, 20);
            this.edWGR.TabIndex = 3;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // UCAttachWgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edWGR);
            this.Controls.Add(this.lbl_WGR);
            this.Controls.Add(this.uc);
            this.Name = "UCAttachWgr";
            this.Size = new System.Drawing.Size(303, 173);
            ((System.ComponentModel.ISupportInitialize)(this.edWGR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_WGR;
        private UCTimeRange uc;
        private DevExpress.XtraEditors.LookUpEdit edWGR;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;

    }
}
