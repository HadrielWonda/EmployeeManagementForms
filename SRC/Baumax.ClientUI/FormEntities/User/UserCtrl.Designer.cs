namespace Baumax.ClientUI.FormEntities.User
{
    partial class UserCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCtrl));
            this.groupControlMain_User = new DevExpress.XtraEditors.GroupControl();
            this.lookupRole = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupLanguage = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl_Role = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit_ChangePasswordAtNextLogin = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit_Active = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl_Language = new DevExpress.XtraEditors.LabelControl();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.label_Password = new DevExpress.XtraEditors.LabelControl();
            this.teLoginName = new DevExpress.XtraEditors.TextEdit();
            this.label_LoginName = new DevExpress.XtraEditors.LabelControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPage_Countries = new DevExpress.XtraTab.XtraTabPage();
            this.btnDelCountry = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddCountry = new DevExpress.XtraEditors.SimpleButton();
            this.lbCountries = new DevExpress.XtraEditors.ListBoxControl();
            this.tabPage_Regions = new DevExpress.XtraTab.XtraTabPage();
            this.btnDelRegion = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddRegion = new DevExpress.XtraEditors.SimpleButton();
            this.lbRegions = new DevExpress.XtraEditors.ListBoxControl();
            this.tabPage_Stores = new DevExpress.XtraTab.XtraTabPage();
            this.btnDelStore = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddStore = new DevExpress.XtraEditors.SimpleButton();
            this.lbStores = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain_User)).BeginInit();
            this.groupControlMain_User.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ChangePasswordAtNextLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Active.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabPage_Countries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountries)).BeginInit();
            this.tabPage_Regions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbRegions)).BeginInit();
            this.tabPage_Stores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbStores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlMain_User
            // 
            this.groupControlMain_User.Controls.Add(this.lookupRole);
            this.groupControlMain_User.Controls.Add(this.lookupLanguage);
            this.groupControlMain_User.Controls.Add(this.labelControl_Role);
            this.groupControlMain_User.Controls.Add(this.checkEdit_ChangePasswordAtNextLogin);
            this.groupControlMain_User.Controls.Add(this.checkEdit_Active);
            this.groupControlMain_User.Controls.Add(this.labelControl_Language);
            this.groupControlMain_User.Controls.Add(this.tePassword);
            this.groupControlMain_User.Controls.Add(this.label_Password);
            this.groupControlMain_User.Controls.Add(this.teLoginName);
            this.groupControlMain_User.Controls.Add(this.label_LoginName);
            this.groupControlMain_User.Location = new System.Drawing.Point(3, 3);
            this.groupControlMain_User.Name = "groupControlMain_User";
            this.groupControlMain_User.Size = new System.Drawing.Size(342, 292);
            this.groupControlMain_User.TabIndex = 5;
            this.groupControlMain_User.Text = "User";
            // 
            // lookupRole
            // 
            this.lookupRole.Location = new System.Drawing.Point(5, 180);
            this.lookupRole.Name = "lookupRole";
            this.lookupRole.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookupRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupRole.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookupRole.Properties.DisplayMember = "Name";
            this.lookupRole.Properties.NullText = "";
            this.lookupRole.Properties.ValueMember = "ID";
            this.lookupRole.Size = new System.Drawing.Size(332, 20);
            this.lookupRole.TabIndex = 3;
            this.lookupRole.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookupRole_ButtonClick);
            this.lookupRole.EditValueChanged += new System.EventHandler(this.lookupRole_EditValueChanged);
            // 
            // lookupLanguage
            // 
            this.lookupLanguage.Location = new System.Drawing.Point(5, 132);
            this.lookupLanguage.Name = "lookupLanguage";
            this.lookupLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Delete), "Delete language binding")});
            this.lookupLanguage.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookupLanguage.Properties.DisplayMember = "Name";
            this.lookupLanguage.Properties.NullText = "";
            this.lookupLanguage.Properties.ValueMember = "ID";
            this.lookupLanguage.Size = new System.Drawing.Size(332, 20);
            this.lookupLanguage.TabIndex = 2;
            this.lookupLanguage.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookupLanguage_ButtonClick);
            // 
            // labelControl_Role
            // 
            this.labelControl_Role.Location = new System.Drawing.Point(7, 161);
            this.labelControl_Role.Name = "labelControl_Role";
            this.labelControl_Role.Size = new System.Drawing.Size(21, 13);
            this.labelControl_Role.TabIndex = 9;
            this.labelControl_Role.Text = "Role";
            // 
            // checkEdit_ChangePasswordAtNextLogin
            // 
            this.checkEdit_ChangePasswordAtNextLogin.Location = new System.Drawing.Point(5, 252);
            this.checkEdit_ChangePasswordAtNextLogin.Name = "checkEdit_ChangePasswordAtNextLogin";
            this.checkEdit_ChangePasswordAtNextLogin.Properties.Caption = "Change Password at next login";
            this.checkEdit_ChangePasswordAtNextLogin.Size = new System.Drawing.Size(332, 19);
            this.checkEdit_ChangePasswordAtNextLogin.TabIndex = 5;
            // 
            // checkEdit_Active
            // 
            this.checkEdit_Active.Location = new System.Drawing.Point(5, 216);
            this.checkEdit_Active.Name = "checkEdit_Active";
            this.checkEdit_Active.Properties.Caption = "Active";
            this.checkEdit_Active.Size = new System.Drawing.Size(332, 19);
            this.checkEdit_Active.TabIndex = 4;
            // 
            // labelControl_Language
            // 
            this.labelControl_Language.Location = new System.Drawing.Point(7, 113);
            this.labelControl_Language.Name = "labelControl_Language";
            this.labelControl_Language.Size = new System.Drawing.Size(47, 13);
            this.labelControl_Language.TabIndex = 4;
            this.labelControl_Language.Text = "Language";
            // 
            // tePassword
            // 
            this.tePassword.EditValue = "";
            this.tePassword.Location = new System.Drawing.Point(5, 87);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.MaxLength = 20;
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(332, 20);
            this.tePassword.TabIndex = 1;
            this.tePassword.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // label_Password
            // 
            this.label_Password.Location = new System.Drawing.Point(5, 68);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(46, 13);
            this.label_Password.TabIndex = 2;
            this.label_Password.Text = "Password";
            // 
            // teLoginName
            // 
            this.teLoginName.Location = new System.Drawing.Point(5, 42);
            this.teLoginName.Name = "teLoginName";
            this.teLoginName.Properties.MaxLength = 50;
            this.teLoginName.Size = new System.Drawing.Size(332, 20);
            this.teLoginName.TabIndex = 0;
            // 
            // label_LoginName
            // 
            this.label_LoginName.Location = new System.Drawing.Point(5, 23);
            this.label_LoginName.Name = "label_LoginName";
            this.label_LoginName.Size = new System.Drawing.Size(55, 13);
            this.label_LoginName.TabIndex = 0;
            this.label_LoginName.Text = "Login Name";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "delete.png");
            this.imageList.Images.SetKeyName(1, "add.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(351, 6);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabPage_Countries;
            this.xtraTabControl1.Size = new System.Drawing.Size(384, 292);
            this.xtraTabControl1.TabIndex = 7;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPage_Countries,
            this.tabPage_Regions,
            this.tabPage_Stores});
            this.xtraTabControl1.Text = "tabCtrl";
            // 
            // tabPage_Countries
            // 
            this.tabPage_Countries.Controls.Add(this.btnDelCountry);
            this.tabPage_Countries.Controls.Add(this.btnAddCountry);
            this.tabPage_Countries.Controls.Add(this.lbCountries);
            this.tabPage_Countries.Name = "tabPage_Countries";
            this.tabPage_Countries.Size = new System.Drawing.Size(375, 261);
            this.tabPage_Countries.Text = "Countries";
            // 
            // btnDelCountry
            // 
            this.btnDelCountry.ImageIndex = 0;
            this.btnDelCountry.ImageList = this.imageList;
            this.btnDelCountry.Location = new System.Drawing.Point(31, 1);
            this.btnDelCountry.Name = "btnDelCountry";
            this.btnDelCountry.Size = new System.Drawing.Size(26, 23);
            this.btnDelCountry.TabIndex = 1;
            this.btnDelCountry.Click += new System.EventHandler(this.btnDelCountry_Click);
            // 
            // btnAddCountry
            // 
            this.btnAddCountry.ImageIndex = 1;
            this.btnAddCountry.ImageList = this.imageList;
            this.btnAddCountry.Location = new System.Drawing.Point(1, 1);
            this.btnAddCountry.Name = "btnAddCountry";
            this.btnAddCountry.Size = new System.Drawing.Size(26, 23);
            this.btnAddCountry.TabIndex = 1;
            this.btnAddCountry.Click += new System.EventHandler(this.btnAddCountry_Click);
            // 
            // lbCountries
            // 
            this.lbCountries.DisplayMember = "Name";
            this.lbCountries.Location = new System.Drawing.Point(0, 30);
            this.lbCountries.Name = "lbCountries";
            this.lbCountries.Size = new System.Drawing.Size(372, 231);
            this.lbCountries.TabIndex = 0;
            this.lbCountries.ValueMember = "ID";
            // 
            // tabPage_Regions
            // 
            this.tabPage_Regions.Controls.Add(this.btnDelRegion);
            this.tabPage_Regions.Controls.Add(this.btnAddRegion);
            this.tabPage_Regions.Controls.Add(this.lbRegions);
            this.tabPage_Regions.Name = "tabPage_Regions";
            this.tabPage_Regions.Size = new System.Drawing.Size(375, 261);
            this.tabPage_Regions.Text = "Regions";
            // 
            // btnDelRegion
            // 
            this.btnDelRegion.ImageIndex = 0;
            this.btnDelRegion.ImageList = this.imageList;
            this.btnDelRegion.Location = new System.Drawing.Point(31, 1);
            this.btnDelRegion.Name = "btnDelRegion";
            this.btnDelRegion.Size = new System.Drawing.Size(26, 23);
            this.btnDelRegion.TabIndex = 3;
            this.btnDelRegion.Click += new System.EventHandler(this.btnDelRegion_Click);
            // 
            // btnAddRegion
            // 
            this.btnAddRegion.ImageIndex = 1;
            this.btnAddRegion.ImageList = this.imageList;
            this.btnAddRegion.Location = new System.Drawing.Point(1, 1);
            this.btnAddRegion.Name = "btnAddRegion";
            this.btnAddRegion.Size = new System.Drawing.Size(26, 23);
            this.btnAddRegion.TabIndex = 4;
            this.btnAddRegion.Click += new System.EventHandler(this.btnAddRegion_Click);
            // 
            // lbRegions
            // 
            this.lbRegions.DisplayMember = "Name";
            this.lbRegions.Location = new System.Drawing.Point(0, 30);
            this.lbRegions.Name = "lbRegions";
            this.lbRegions.Size = new System.Drawing.Size(372, 231);
            this.lbRegions.TabIndex = 2;
            this.lbRegions.ValueMember = "ID";
            // 
            // tabPage_Stores
            // 
            this.tabPage_Stores.Controls.Add(this.btnDelStore);
            this.tabPage_Stores.Controls.Add(this.btnAddStore);
            this.tabPage_Stores.Controls.Add(this.lbStores);
            this.tabPage_Stores.Name = "tabPage_Stores";
            this.tabPage_Stores.Size = new System.Drawing.Size(375, 261);
            this.tabPage_Stores.Text = "Stores";
            // 
            // btnDelStore
            // 
            this.btnDelStore.ImageIndex = 0;
            this.btnDelStore.ImageList = this.imageList;
            this.btnDelStore.Location = new System.Drawing.Point(31, 1);
            this.btnDelStore.Name = "btnDelStore";
            this.btnDelStore.Size = new System.Drawing.Size(26, 23);
            this.btnDelStore.TabIndex = 3;
            this.btnDelStore.Click += new System.EventHandler(this.btnDelStore_Click);
            // 
            // btnAddStore
            // 
            this.btnAddStore.ImageIndex = 1;
            this.btnAddStore.ImageList = this.imageList;
            this.btnAddStore.Location = new System.Drawing.Point(1, 1);
            this.btnAddStore.Name = "btnAddStore";
            this.btnAddStore.Size = new System.Drawing.Size(26, 23);
            this.btnAddStore.TabIndex = 4;
            this.btnAddStore.Click += new System.EventHandler(this.btnAddStore_Click);
            // 
            // lbStores
            // 
            this.lbStores.DisplayMember = "Name";
            this.lbStores.Location = new System.Drawing.Point(0, 30);
            this.lbStores.Name = "lbStores";
            this.lbStores.Size = new System.Drawing.Size(372, 231);
            this.lbStores.TabIndex = 2;
            this.lbStores.ValueMember = "ID";
            // 
            // UserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.groupControlMain_User);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UserCtrl";
            this.Size = new System.Drawing.Size(738, 298);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain_User)).EndInit();
            this.groupControlMain_User.ResumeLayout(false);
            this.groupControlMain_User.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ChangePasswordAtNextLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Active.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabPage_Countries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbCountries)).EndInit();
            this.tabPage_Regions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbRegions)).EndInit();
            this.tabPage_Stores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbStores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMain_User;
        private DevExpress.XtraEditors.LabelControl labelControl_Role;
        private DevExpress.XtraEditors.CheckEdit checkEdit_Active;
        private DevExpress.XtraEditors.LabelControl labelControl_Language;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.LabelControl label_Password;
        private DevExpress.XtraEditors.TextEdit teLoginName;
        private DevExpress.XtraEditors.LabelControl label_LoginName;
        private DevExpress.XtraEditors.LookUpEdit lookupLanguage;
        private DevExpress.XtraEditors.LookUpEdit lookupRole;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPage_Countries;
        private DevExpress.XtraTab.XtraTabPage tabPage_Regions;
        private DevExpress.XtraTab.XtraTabPage tabPage_Stores;
        private DevExpress.XtraEditors.ListBoxControl lbCountries;
        private DevExpress.XtraEditors.SimpleButton btnDelCountry;
        private DevExpress.XtraEditors.SimpleButton btnAddCountry;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraEditors.SimpleButton btnDelRegion;
        private DevExpress.XtraEditors.SimpleButton btnAddRegion;
        private DevExpress.XtraEditors.ListBoxControl lbRegions;
        private DevExpress.XtraEditors.SimpleButton btnDelStore;
        private DevExpress.XtraEditors.SimpleButton btnAddStore;
        private DevExpress.XtraEditors.ListBoxControl lbStores;
        private DevExpress.XtraEditors.CheckEdit checkEdit_ChangePasswordAtNextLogin;
    }
}
