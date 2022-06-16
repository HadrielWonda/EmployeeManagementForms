namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormAssign
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
            this.uc = new Baumax.ClientUI.FormEntities.AnotherWorld.UCAssign();
            this.lbl_AssignEntity = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_AssignEntity);
            this.panelTop.Size = new System.Drawing.Size(265, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.uc);
            this.panelClient.Size = new System.Drawing.Size(265, 184);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-6869, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 218);
            this.panelBottom.Size = new System.Drawing.Size(265, 40);
            // 
            // uc
            // 
            this.uc.Assigned = null;
            this.uc.AssignEnum = Baumax.ClientUI.FormEntities.AnotherWorld.AssignEnum.ThisHwgrToWgr;
            this.uc.BeginTime = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.uc.DropItemsHwgr = null;
            this.uc.DropItemsWgr = null;
            this.uc.DropItemsWorld = null;
            this.uc.EndTime = new System.DateTime(1900, 1, 7, 0, 0, 0, 0);
            this.uc.Entity = null;
            this.uc.Location = new System.Drawing.Point(0, 0);
            this.uc.LookAndFeel.SkinName = "iMaginary";
            this.uc.Modified = true;
            this.uc.Name = "uc";
            this.uc.OneItem = ((long)(0));
            this.uc.Size = new System.Drawing.Size(306, 270);
            this.uc.TabIndex = 0;
            // 
            // lbl_AssignEntity
            // 
            this.lbl_AssignEntity.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_AssignEntity.Appearance.Options.UseFont = true;
            this.lbl_AssignEntity.Appearance.Options.UseTextOptions = true;
            this.lbl_AssignEntity.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_AssignEntity.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_AssignEntity.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_AssignEntity.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_AssignEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_AssignEntity.Location = new System.Drawing.Point(2, 2);
            this.lbl_AssignEntity.Name = "lbl_AssignEntity";
            this.lbl_AssignEntity.Size = new System.Drawing.Size(261, 30);
            this.lbl_AssignEntity.TabIndex = 1;
            this.lbl_AssignEntity.Text = "Assign entity";
            // 
            // FormAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 258);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssign";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCAssign uc;
        private DevExpress.XtraEditors.LabelControl lbl_AssignEntity;



    }
}