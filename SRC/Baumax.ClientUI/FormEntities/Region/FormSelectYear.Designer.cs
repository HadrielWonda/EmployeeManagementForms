namespace Baumax.ClientUI.FormEntities.Region
{
    partial class FormSelectYear
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
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_DefineBufferHours = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.seBufferHours = new DevExpress.XtraEditors.SpinEdit();
            this.seYear = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpWorlds = new DevExpress.XtraEditors.LookUpEdit();
            this.teStore = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItem_Store = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItem_World = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItem_Year = new DevExpress.XtraLayout.LayoutControlItem();
            this.li_BufferHours = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seBufferHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWorlds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_World)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BufferHours)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_DefineBufferHours);
            this.panelTop.Size = new System.Drawing.Size(380, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Size = new System.Drawing.Size(380, 176);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(11, -7);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(42, -7);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 210);
            this.panelBottom.Size = new System.Drawing.Size(380, 10);
            this.panelBottom.Visible = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btn_OK);
            this.panelControl3.Controls.Add(this.btn_Cancel);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 172);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(380, 38);
            this.panelControl3.TabIndex = 2;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 10);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "Save";
            this.btn_OK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(297, 10);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_DefineBufferHours
            // 
            this.lbl_DefineBufferHours.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_DefineBufferHours.Appearance.Options.UseFont = true;
            this.lbl_DefineBufferHours.Appearance.Options.UseTextOptions = true;
            this.lbl_DefineBufferHours.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_DefineBufferHours.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_DefineBufferHours.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_DefineBufferHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DefineBufferHours.Location = new System.Drawing.Point(2, 2);
            this.lbl_DefineBufferHours.Name = "lbl_DefineBufferHours";
            this.lbl_DefineBufferHours.Size = new System.Drawing.Size(376, 30);
            this.lbl_DefineBufferHours.TabIndex = 1;
            this.lbl_DefineBufferHours.Text = "Buffer-hours";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.seBufferHours);
            this.layoutControl1.Controls.Add(this.seYear);
            this.layoutControl1.Controls.Add(this.lookUpWorlds);
            this.layoutControl1.Controls.Add(this.teStore);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 34);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.DrawItemBorders = true;
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(380, 138);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // seBufferHours
            // 
            this.seBufferHours.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seBufferHours.Location = new System.Drawing.Point(196, 94);
            this.seBufferHours.Name = "seBufferHours";
            this.seBufferHours.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seBufferHours.Properties.Mask.EditMask = "f1";
            this.seBufferHours.Properties.MaxValue = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.seBufferHours.Size = new System.Drawing.Size(178, 20);
            this.seBufferHours.StyleController = this.layoutControl1;
            this.seBufferHours.TabIndex = 8;
            // 
            // seYear
            // 
            this.seYear.EditValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seYear.Location = new System.Drawing.Point(7, 94);
            this.seYear.Name = "seYear";
            this.seYear.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.seYear.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.seYear.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.seYear.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.seYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seYear.Properties.Mask.EditMask = "0000";
            this.seYear.Properties.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.seYear.Properties.MinValue = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.seYear.Size = new System.Drawing.Size(178, 20);
            this.seYear.StyleController = this.layoutControl1;
            this.seYear.TabIndex = 6;
            // 
            // lookUpWorlds
            // 
            this.lookUpWorlds.Location = new System.Drawing.Point(70, 38);
            this.lookUpWorlds.Name = "lookUpWorlds";
            this.lookUpWorlds.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lookUpWorlds.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lookUpWorlds.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.lookUpWorlds.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.lookUpWorlds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpWorlds.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorldName", "WorldName", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpWorlds.Properties.DisplayMember = "WorldName";
            this.lookUpWorlds.Properties.NullText = "";
            this.lookUpWorlds.Properties.ValueMember = "ID";
            this.lookUpWorlds.Size = new System.Drawing.Size(304, 20);
            this.lookUpWorlds.StyleController = this.layoutControl1;
            this.lookUpWorlds.TabIndex = 5;
            // 
            // teStore
            // 
            this.teStore.Enabled = false;
            this.teStore.Location = new System.Drawing.Point(70, 7);
            this.teStore.Name = "teStore";
            this.teStore.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.teStore.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.teStore.Properties.AppearanceDisabled.Options.UseFont = true;
            this.teStore.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.teStore.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.teStore.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black;
            this.teStore.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.teStore.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.teStore.Properties.ReadOnly = true;
            this.teStore.Size = new System.Drawing.Size(304, 20);
            this.teStore.StyleController = this.layoutControl1;
            this.teStore.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowHide = false;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItem_Store,
            this.layoutItem_World,
            this.layoutItem_Year,
            this.li_BufferHours});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(380, 138);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutItem_Store
            // 
            this.layoutItem_Store.Control = this.teStore;
            this.layoutItem_Store.CustomizationFormText = "Store";
            this.layoutItem_Store.Location = new System.Drawing.Point(0, 0);
            this.layoutItem_Store.Name = "layoutItem_Store";
            this.layoutItem_Store.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_Store.Size = new System.Drawing.Size(378, 31);
            this.layoutItem_Store.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutItem_Store.Text = "Store";
            this.layoutItem_Store.TextSize = new System.Drawing.Size(58, 20);
            // 
            // layoutItem_World
            // 
            this.layoutItem_World.Control = this.lookUpWorlds;
            this.layoutItem_World.CustomizationFormText = "World";
            this.layoutItem_World.Location = new System.Drawing.Point(0, 31);
            this.layoutItem_World.Name = "layoutItem_World";
            this.layoutItem_World.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_World.Size = new System.Drawing.Size(378, 31);
            this.layoutItem_World.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutItem_World.Text = "World";
            this.layoutItem_World.TextSize = new System.Drawing.Size(58, 20);
            // 
            // layoutItem_Year
            // 
            this.layoutItem_Year.Control = this.seYear;
            this.layoutItem_Year.CustomizationFormText = "Year";
            this.layoutItem_Year.Location = new System.Drawing.Point(0, 62);
            this.layoutItem_Year.Name = "layoutItem_Year";
            this.layoutItem_Year.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutItem_Year.Size = new System.Drawing.Size(189, 74);
            this.layoutItem_Year.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutItem_Year.Text = "Year";
            this.layoutItem_Year.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutItem_Year.TextSize = new System.Drawing.Size(58, 20);
            // 
            // li_BufferHours
            // 
            this.li_BufferHours.Control = this.seBufferHours;
            this.li_BufferHours.CustomizationFormText = "BufferHours";
            this.li_BufferHours.Location = new System.Drawing.Point(189, 62);
            this.li_BufferHours.Name = "li_BufferHours";
            this.li_BufferHours.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.li_BufferHours.Size = new System.Drawing.Size(189, 74);
            this.li_BufferHours.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.li_BufferHours.Text = "BufferHours";
            this.li_BufferHours.TextLocation = DevExpress.Utils.Locations.Top;
            this.li_BufferHours.TextSize = new System.Drawing.Size(58, 20);
            // 
            // FormSelectYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 220);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl3);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormSelectYear";
            this.Text = "    ";
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.Controls.SetChildIndex(this.panelTop, 0);
            this.Controls.SetChildIndex(this.panelClient, 0);
            this.Controls.SetChildIndex(this.panelControl3, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seBufferHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpWorlds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_World)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItem_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.li_BufferHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.LabelControl lbl_DefineBufferHours;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SpinEdit seBufferHours;
        private DevExpress.XtraEditors.SpinEdit seYear;
        private DevExpress.XtraEditors.LookUpEdit lookUpWorlds;
        private DevExpress.XtraEditors.TextEdit teStore;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutItem_Store;
        private DevExpress.XtraLayout.LayoutControlItem layoutItem_World;
        private DevExpress.XtraLayout.LayoutControlItem layoutItem_Year;
        private DevExpress.XtraLayout.LayoutControlItem li_BufferHours;
    }
}