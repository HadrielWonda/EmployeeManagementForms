namespace Baumax.ClientUI.Printout
{
    partial class FormPrintAbsencePlanning
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.rgMode = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rdo_AllWorlds = new DevExpress.XtraEditors.CheckEdit();
            this.rdo_World = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.rdo_Yearly = new DevExpress.XtraEditors.CheckEdit();
            this.edStore = new DevExpress.XtraEditors.TextEdit();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.rdo_Monthly = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lc_store = new DevExpress.XtraLayout.LayoutControlItem();
            this.gr_World = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gr_View = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_AllWorlds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_World.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_Yearly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_Monthly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.rgMode);
            this.layoutControl.Controls.Add(this.labelControl1);
            this.layoutControl.Controls.Add(this.rdo_AllWorlds);
            this.layoutControl.Controls.Add(this.rdo_World);
            this.layoutControl.Controls.Add(this.btn_Print);
            this.layoutControl.Controls.Add(this.rdo_Yearly);
            this.layoutControl.Controls.Add(this.edStore);
            this.layoutControl.Controls.Add(this.btn_Cancel);
            this.layoutControl.Controls.Add(this.rdo_Monthly);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(420, 157);
            this.layoutControl.TabIndex = 0;
            // 
            // rgMode
            // 
            this.rgMode.EditValue = true;
            this.rgMode.Enabled = false;
            this.rgMode.Location = new System.Drawing.Point(114, 85);
            this.rgMode.MaximumSize = new System.Drawing.Size(95, 22);
            this.rgMode.Name = "rgMode";
            this.rgMode.Properties.Columns = 2;
            this.rgMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "A3"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "A4")});
            this.rgMode.Size = new System.Drawing.Size(93, 22);
            this.rgMode.StyleController = this.layoutControl;
            this.rgMode.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(183, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.StyleController = this.layoutControl;
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "(A3)";
            // 
            // rdo_AllWorlds
            // 
            this.rdo_AllWorlds.Location = new System.Drawing.Point(221, 58);
            this.rdo_AllWorlds.Name = "rdo_AllWorlds";
            this.rdo_AllWorlds.Properties.Caption = "All w";
            this.rdo_AllWorlds.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_AllWorlds.Properties.RadioGroupIndex = 2;
            this.rdo_AllWorlds.Size = new System.Drawing.Size(191, 19);
            this.rdo_AllWorlds.StyleController = this.layoutControl;
            this.rdo_AllWorlds.TabIndex = 8;
            this.rdo_AllWorlds.TabStop = false;
            this.rdo_AllWorlds.CheckedChanged += new System.EventHandler(this.rdoWorldChecked);
            // 
            // rdo_World
            // 
            this.rdo_World.EditValue = true;
            this.rdo_World.Location = new System.Drawing.Point(221, 88);
            this.rdo_World.Name = "rdo_World";
            this.rdo_World.Properties.Caption = "World:";
            this.rdo_World.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_World.Properties.RadioGroupIndex = 2;
            this.rdo_World.Size = new System.Drawing.Size(191, 19);
            this.rdo_World.StyleController = this.layoutControl;
            this.rdo_World.TabIndex = 9;
            this.rdo_World.CheckedChanged += new System.EventHandler(this.rdoWorldChecked);
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(267, 121);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(69, 22);
            this.btn_Print.StyleController = this.layoutControl;
            this.btn_Print.TabIndex = 7;
            this.btn_Print.Text = "Print";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // rdo_Yearly
            // 
            this.rdo_Yearly.EditValue = true;
            this.rdo_Yearly.Location = new System.Drawing.Point(9, 58);
            this.rdo_Yearly.Name = "rdo_Yearly";
            this.rdo_Yearly.Properties.Caption = "Yearly";
            this.rdo_Yearly.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_Yearly.Properties.RadioGroupIndex = 1;
            this.rdo_Yearly.Size = new System.Drawing.Size(163, 19);
            this.rdo_Yearly.StyleController = this.layoutControl;
            this.rdo_Yearly.TabIndex = 7;
            this.rdo_Yearly.CheckedChanged += new System.EventHandler(this.rdoCheckedChanged);
            // 
            // edStore
            // 
            this.edStore.Enabled = false;
            this.edStore.Location = new System.Drawing.Point(37, 6);
            this.edStore.Name = "edStore";
            this.edStore.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edStore.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edStore.Size = new System.Drawing.Size(378, 20);
            this.edStore.StyleController = this.layoutControl;
            this.edStore.TabIndex = 4;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(347, 121);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(68, 22);
            this.btn_Cancel.StyleController = this.layoutControl;
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            // 
            // rdo_Monthly
            // 
            this.rdo_Monthly.Location = new System.Drawing.Point(9, 88);
            this.rdo_Monthly.Name = "rdo_Monthly";
            this.rdo_Monthly.Properties.Caption = "Monthly";
            this.rdo_Monthly.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdo_Monthly.Properties.RadioGroupIndex = 1;
            this.rdo_Monthly.Size = new System.Drawing.Size(97, 19);
            this.rdo_Monthly.StyleController = this.layoutControl;
            this.rdo_Monthly.TabIndex = 6;
            this.rdo_Monthly.TabStop = false;
            this.rdo_Monthly.CheckedChanged += new System.EventHandler(this.rdoCheckedChanged);
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.CustomizationFormText = "layoutControlGroup";
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem6,
            this.lc_store,
            this.gr_World,
            this.gr_View,
            this.emptySpaceItem1});
            this.layoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup.Size = new System.Drawing.Size(420, 157);
            this.layoutControlGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup.Text = "layoutControlGroup";
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_Print;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(261, 115);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.Size = new System.Drawing.Size(80, 42);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_Cancel;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(341, 115);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Size = new System.Drawing.Size(79, 42);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // lc_store
            // 
            this.lc_store.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.lc_store.AppearanceItemCaption.Options.UseForeColor = true;
            this.lc_store.Control = this.edStore;
            this.lc_store.CustomizationFormText = "Store";
            this.lc_store.Location = new System.Drawing.Point(0, 0);
            this.lc_store.Name = "lc_store";
            this.lc_store.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lc_store.Size = new System.Drawing.Size(420, 31);
            this.lc_store.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lc_store.Text = "Store";
            this.lc_store.TextSize = new System.Drawing.Size(26, 20);
            // 
            // gr_World
            // 
            this.gr_World.CustomizationFormText = "World";
            this.gr_World.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.gr_World.Location = new System.Drawing.Point(212, 31);
            this.gr_World.Name = "gr_World";
            this.gr_World.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.gr_World.Size = new System.Drawing.Size(208, 84);
            this.gr_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.gr_World.Text = "World";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rdo_AllWorlds;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(202, 30);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.rdo_World;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(202, 30);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // gr_View
            // 
            this.gr_View.CustomizationFormText = "View";
            this.gr_View.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem8});
            this.gr_View.Location = new System.Drawing.Point(0, 31);
            this.gr_View.Name = "gr_View";
            this.gr_View.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.gr_View.Size = new System.Drawing.Size(212, 84);
            this.gr_View.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.gr_View.Text = "View";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rdo_Monthly;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Size = new System.Drawing.Size(108, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.rdo_Yearly;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(174, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(174, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(32, 30);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.rgMode;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(108, 30);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem8.Size = new System.Drawing.Size(98, 30);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 115);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(261, 42);
            this.emptySpaceItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormPrintAbsencePlanning
            // 
            this.AcceptButton = this.btn_Print;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(420, 157);
            this.Controls.Add(this.layoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintAbsencePlanning";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print absence time planning";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_AllWorlds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_World.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_Yearly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_Monthly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lc_store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gr_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.TextEdit edStore;
        private DevExpress.XtraLayout.LayoutControlItem lc_store;
		private DevExpress.XtraEditors.CheckEdit rdo_Yearly;
		private DevExpress.XtraEditors.CheckEdit rdo_Monthly;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraEditors.CheckEdit rdo_AllWorlds;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraEditors.CheckEdit rdo_World;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraEditors.SimpleButton btn_Print;
		private DevExpress.XtraEditors.SimpleButton btn_Cancel;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup gr_World;
        private DevExpress.XtraLayout.LayoutControlGroup gr_View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.RadioGroup rgMode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}