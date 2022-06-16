namespace Baumax.ClientUI.FormEntities.WGR
{
    partial class UCHwgrEntity
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
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.edName = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Name = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(12, 22);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(260, 20);
            this.edName.TabIndex = 0;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(12, 3);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(27, 13);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "Name";
            // 
            // UCHwgrEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.edName);
            this.Name = "UCHwgrEntity";
            this.Size = new System.Drawing.Size(275, 123);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit edName;
        private DevExpress.XtraEditors.LabelControl lbl_Name;
    }
}
