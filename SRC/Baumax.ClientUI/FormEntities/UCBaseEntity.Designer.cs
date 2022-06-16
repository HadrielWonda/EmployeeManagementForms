namespace Baumax.ClientUI.FormEntities
{
    partial class UCBaseEntity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBaseEntity));
            this.toolTip = new DevExpress.Utils.ToolTipController(this.components);
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.Rounded = true;
            this.toolTip.ShowBeak = true;
            this.toolTip.ToolTipType = DevExpress.Utils.ToolTipType.Standard;
            // 
            // UCBaseEntity
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCBaseEntity";
            this.toolTip.SetSuperTip(this, null);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTip;
    }
}
