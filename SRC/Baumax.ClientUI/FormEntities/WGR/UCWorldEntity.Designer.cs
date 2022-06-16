namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCWorldEntity
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
            this.lbl_Name = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.edName = new DevExpress.XtraEditors.TextEdit();
            this.lb_Type = new DevExpress.XtraEditors.LabelControl();
            this.edType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lb_Store = new DevExpress.XtraEditors.LabelControl();
            this.edStore = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(20, 14);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(27, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(20, 33);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(289, 20);
            this.edName.TabIndex = 1;
            // 
            // lb_Type
            // 
            this.lb_Type.Location = new System.Drawing.Point(20, 70);
            this.lb_Type.Name = "lb_Type";
            this.lb_Type.Size = new System.Drawing.Size(24, 13);
            this.lb_Type.TabIndex = 2;
            this.lb_Type.Text = "Type";
            // 
            // edType
            // 
            this.edType.Location = new System.Drawing.Point(20, 90);
            this.edType.Name = "edType";
            this.edType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edType.Properties.Items.AddRange(new object[] {
            "one ",
            "two",
            "three"});
            this.edType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edType.Size = new System.Drawing.Size(289, 20);
            this.edType.TabIndex = 3;
            // 
            // lb_Store
            // 
            this.lb_Store.Location = new System.Drawing.Point(20, 128);
            this.lb_Store.Name = "lb_Store";
            this.lb_Store.Size = new System.Drawing.Size(26, 13);
            this.lb_Store.TabIndex = 4;
            this.lb_Store.Text = "Store";
            // 
            // edStore
            // 
            this.edStore.Location = new System.Drawing.Point(20, 148);
            this.edStore.Name = "edStore";
            this.edStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStore.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edStore.Size = new System.Drawing.Size(289, 20);
            this.edStore.TabIndex = 5;
            // 
            // UCWorldEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edStore);
            this.Controls.Add(this.lb_Store);
            this.Controls.Add(this.edType);
            this.Controls.Add(this.lb_Type);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.lbl_Name);
            this.Name = "UCWorldEntity";
            this.Size = new System.Drawing.Size(418, 224);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_Name;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.LabelControl lb_Type;
        private DevExpress.XtraEditors.TextEdit edName;
        private DevExpress.XtraEditors.ComboBoxEdit edType;
        private DevExpress.XtraEditors.LabelControl lb_Store;
        private DevExpress.XtraEditors.ComboBoxEdit edStore;
    }
}
