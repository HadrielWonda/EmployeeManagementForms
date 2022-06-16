namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCWgrEntity
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
            this.lbl_WGRName = new DevExpress.XtraEditors.LabelControl();
            this.edName = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_WGRName
            // 
            this.lbl_WGRName.Location = new System.Drawing.Point(3, 3);
            this.lbl_WGRName.Name = "lbl_WGRName";
            this.lbl_WGRName.Size = new System.Drawing.Size(27, 13);
            this.lbl_WGRName.TabIndex = 0;
            this.lbl_WGRName.Text = "Name";
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(3, 22);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(274, 20);
            this.edName.TabIndex = 1;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // UCWgrEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edName);
            this.Controls.Add(this.lbl_WGRName);
            this.Name = "UCWgrEntity";
            this.Size = new System.Drawing.Size(280, 55);
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_WGRName;
        private DevExpress.XtraEditors.TextEdit edName;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}
