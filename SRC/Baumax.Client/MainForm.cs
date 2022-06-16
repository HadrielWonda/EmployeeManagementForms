using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.ClientUI.Admin;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.FormEntities.AnotherWorld;
using Baumax.ClientUI.FormEntities.TimePlanning;
using Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning;
using Baumax.ClientUI.Import;
using Baumax.ClientUI.ManageEntityControls;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Environment.Interfaces;
using Baumax.Localization;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Localizer=Baumax.Localization.Localizer;

namespace Baumax.Client
{
    public partial class MainForm : XtraForm, IRemoteRequestVisualizer
    {
        private UCBaseEntity _currentUC;
        private NotifyChangedLanguage onChangedLanguage = null;

        private BarEditItem _marqueeBarItem;
        private bool _visualizingRequest;
        private bool isUserStoreAdministrator = false;
        private bool isUserRegionAdministrator = false;
        private bool isUserCentralGlobalAdministration = false;
        private bool isUserControlling = false;
        private bool isUserAustriaStoreAdministrator = false;
        private bool isUserCountryAdministrator = false;

        private Cursor _ServerRequestCursor;

        public MainForm()
        {
            InitializeComponent();
            LoadCursor();
            SkinManager.Default.RegisterAssembly(typeof (BonusSkins).Assembly);
            SkinManager.Default.RegisterAssembly(typeof (OfficeSkins).Assembly);
            SkinManager.EnableFormSkins();
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            ApplyUserRights();

            Subscribe();

            CreateRequestVisualizationUI();
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            onChangedLanguage = new NotifyChangedLanguage(NotificationService_ChangedLanguage);
            NotificationService.ChangedLanguage += onChangedLanguage;

            Disposed += new EventHandler(MainForm_Disposed);
        }

        private void UnSubscribe()
        {
            NotificationService.ChangedLanguage -= onChangedLanguage;
        }

        #region IRemoteRequestVisualizer Members

        public bool Visualizing
        {
            get { return _visualizingRequest; }
            set
            {
                _visualizingRequest = value;
                SetServerRequestCursor(value);
            }
        }

        private delegate void SetServerRequestCursorDelegate(bool state);

        private void SetServerRequestCursor(bool state)
        {
            if (InvokeRequired)
            {
                Invoke(new SetServerRequestCursorDelegate(SetServerRequestCursor), state);
            }
            else
            {
                if (state)
                {
                    Cursor = _ServerRequestCursor;
                }
                else
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        public void UpdateProgress()
        {
            /*if (_visualizingRequest && Visible)
            {
                statusBar.Invalidate();
            }*/
        }

        private void CreateRequestVisualizationUI()
        {
            /*_marqueeBarItem = new BarEditItem();
			_marqueeBarItem.Width = 200;
			RepositoryItemMarqueeProgressBar marquee = new RepositoryItemMarqueeProgressBar();
			marquee.Stopped = false;
			marquee.ProgressAnimationMode = ProgressAnimationMode.PingPong;
			marquee.MarqueeAnimationSpeed = 50;
			marquee.ProgressViewStyle = ProgressViewStyle.Solid;
			marquee.ShowTitle = true;
			marquee.NullText = "Processing server request";
			_marqueeBarItem.Edit = marquee;
			mainBarManager.Items.Add(_marqueeBarItem);
			statusBar.LinksPersistInfo.Add(new LinkPersistInfo(_marqueeBarItem));
			_marqueeBarItem.Visibility = BarItemVisibility.Never;*/
        }

        #endregion

        #region Pressed Button Members

        private void ClearPressedButtons()
        {
            buttonItem_LanguageManager.Border =
                buttonItem_CountryManager.Border =
                btn_UserManager.Border =
                btn_EmployeeManager.Border =
                barButton_RegionManager.Border =
                barButton_StoreManager.Border =
                barButton_TimePlanning.Border =
                barBtn_StructureManager.Border =
                br_AbsencePlanning.Border =
                bar_TimeRecording.Border =
                //barLargeButtonItem1.Border =
                BorderStyles.NoBorder;
        }

        private void PressedButtonTrue(BarLargeButtonItem _button)
        {
            ClearPressedButtons();
            _button.Border = BorderStyles.Simple;
        }

        private bool isButtonPressed(BarLargeButtonItem _button)
        {
            if (_button.Border == BorderStyles.Simple)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        public string GetLocalized(string key)
        {
            return Localizer.GetLocalized(key);
        }

        public string GetLocalized(int key)
        {
            return Localizer.GetLocalized(key);
        }

        protected UCBaseEntity CurrentUC
        {
            get { return _currentUC; }
            set
            {
                if (_currentUC != null)
                {
                    _currentUC.SomethingDoBeforeDispose();
                    _currentUC.Dispose();
                    panelControl.Controls.Clear();
                }
                _currentUC = value;
                // acpro item #124036
                // simply closing current UC and clearing out client part of main form 
                // when the one of import routines is called
                // therefore we need possibility to set CurrentUC = null;
                if (value != null)
                {
                    _currentUC.Dock = DockStyle.Fill;
                    panelControl.Controls.Add(_currentUC);
                }
                SetCommands();
            }
        }

        private void SetCommands()
        {
            barButtonNew.Enabled = ((_currentUC != null) && (_currentUC.AddEnabled));
            barButtonNew.Visibility = barButtonNew.Enabled
                                          ? BarItemVisibility.Always
                                          : BarItemVisibility.OnlyInCustomizing;
            barButtonEdit.Enabled = ((_currentUC != null) && (_currentUC.EditEnabled));
            barButtonEdit.Visibility = barButtonEdit.Enabled
                                           ? BarItemVisibility.Always
                                           : BarItemVisibility.OnlyInCustomizing;
            barButtonDelete.Enabled = ((_currentUC != null) && (_currentUC.DeleteEnabled));
            barButtonDelete.Visibility = barButtonDelete.Enabled
                                             ? BarItemVisibility.Always
                                             : BarItemVisibility.OnlyInCustomizing;
            // enabled always when UC present.
            barButtonRefresh.Enabled = (_currentUC != null);
            barButtonRefresh.Visibility = barButtonRefresh.Enabled
                                              ? BarItemVisibility.Always
                                              : BarItemVisibility.OnlyInCustomizing;
        }

        protected virtual void AssignLanguage()
        {
            if (!DesignMode)
            {
                ControlLocalizer localizer = new ControlLocalizer(UILocalizer.Current, this);

                localizer.ComponentsLocalize(components);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                AssignLanguage();
                LoadLanguages();
                Text =
                    string.Format("{0} - '{1}'", GetLocalized("MainWindowCaption"),
                                  ClientEnvironment.AuthorizationService.GetCurrentUser().LoginName);
                FormWait.HideWaitForm();
            }
        }

        [DllImport("user32.dll", EntryPoint = "LoadCursorFromFileW", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadCursorFromFile(String str);

        private void LoadCursor()
        {
            IntPtr hCursor;

            string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "request.ani");
            hCursor = LoadCursorFromFile(fileName);
            if (!IntPtr.Zero.Equals(hCursor))
            {
                _ServerRequestCursor = new Cursor(hCursor);
            }
            else
            {
                //int err = Marshal.GetLastWin32Error();
                _ServerRequestCursor = Cursors.WaitCursor;
            }
        }

        private void DefineUserRole()
        {
            if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                 (long) UserRoleId.Controlling))
            {
                isUserControlling = true;
            }
            else if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                     (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                      (long) UserRoleId.GlobalAdmin))
            {
                isUserCentralGlobalAdministration = true;
            }
            else if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                     (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                      (long) UserRoleId.RegionAdmin))
            {
                isUserRegionAdministrator = true;
            }
            else if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                     (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                      (long) UserRoleId.StoreAdmin))
            {
                isUserStoreAdministrator = true;
                long userID = ClientEnvironment.AuthorizationService.GetCurrentUser().ID;
                isUserAustriaStoreAdministrator =
                    IsUserAustriaStoreAdminByStore(ClientEnvironment.UserService.GetUserStores(userID));
            }
            else if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                     (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                      (long) UserRoleId.CountryAdmin))
            {
                isUserCountryAdministrator = true;
            }
        }

        private bool IsUserAustriaStoreAdminByStore(IList<Store> listStore)
        {
            long countryID;
            if ((listStore != null) && (listStore.Count > 0))
            {
                foreach (Store store in listStore)
                {
                    countryID = ClientEnvironment.StoreService.GetCountryByStoreId(store.ID);
                    if (countryID == 1003) //countryID of Austria       
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private void ApplyUserRights()
        {
            IAuthorizationService auth = ClientEnvironment.AuthorizationService;
            AccessType country = auth.GetAccess(ClientEnvironment.CountryService);
            AccessType user = auth.GetAccess(ClientEnvironment.UserService);
            AccessType lng = auth.GetAccess(ClientEnvironment.LanguageService);
            AccessType employee = auth.GetAccess(ClientEnvironment.EmployeeService);
            AccessType region = auth.GetAccess(ClientEnvironment.RegionService);
            AccessType store = auth.GetAccess(ClientEnvironment.StoreService);
            AccessType world = auth.GetAccess(ClientEnvironment.WorldService);

            DefineUserRole();

            menu_LanguageManager.Visibility =
                buttonItem_LanguageManager.Visibility =
                (lng != AccessType.None && !isUserRegionAdministrator && !isUserStoreAdministrator && !isUserControlling &&
                 !isUserCountryAdministrator)
                    ? BarItemVisibility.Always
                    : BarItemVisibility.Never;
            menu_countryManager.Visibility =
                buttonItem_CountryManager.Visibility =
                (country != AccessType.None && !isUserRegionAdministrator && !isUserStoreAdministrator &&
                 !isUserControlling)
                    ? BarItemVisibility.Always
                    : BarItemVisibility.Never;
            menu_UserManager.Visibility =
                btn_UserManager.Visibility =
                (user != AccessType.None && !isUserRegionAdministrator && !isUserStoreAdministrator &&
                 !isUserControlling)
                    ? BarItemVisibility.Always
                    : BarItemVisibility.Never;
            menu_EmployeeManager.Visibility =
                btn_EmployeeManager.Visibility =
                (employee != AccessType.None) ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_RegionManager.Visibility =
                barButton_RegionManager.Visibility =
                (region != AccessType.None && !isUserStoreAdministrator)
                    ? BarItemVisibility.Always
                    : BarItemVisibility.Never;
            menu_StoreManager.Visibility =
                barButton_StoreManager.Visibility =
                (store != AccessType.None) ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_structureManager.Visibility =
                barBtn_StructureManager.Visibility = (world != AccessType.None) &&
                                                     ((country & AccessType.Read) != 0)
                                                     && ((store & AccessType.Read) != 0)
                                                     && ((region & AccessType.Read) != 0)
                                                         ? BarItemVisibility.Always
                                                         : BarItemVisibility.Never;
            menu_TimeRecording.Visibility =
                bar_TimeRecording.Visibility =
                (!isUserAustriaStoreAdministrator) ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (!isUserCentralGlobalAdministration)
            {
                menu_Import.Visibility =
                    bi_Import.Visibility = BarItemVisibility.Never;
            }


            menu_importcountry.Visibility =
                bi_ImportCountry.Visibility =
                (country & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportRegion.Visibility =
                bi_ImportRegion.Visibility =
                (region & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportStore.Visibility =
                bi_ImportStore.Visibility =
                (store & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportWorld.Visibility =
                bi_ImportWorld.Visibility =
                (world & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportHWGR.Visibility =
                bi_ImportHWGR.Visibility =
                (world & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportWGR.Visibility =
                bi_ImportWGR.Visibility =
                (world & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportEmployee.Visibility =
                bi_ImportEmployee.Visibility =
                (employee & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            menu_ImportCashRegisterReceipt.Visibility =
                menu_ImportTargetBusinessVolume.Visibility =
                menu_ImportBusinessVolume.Visibility =
                bi_ImportCashRegisterReceipt.Visibility =
                bi_ImportTargetBusinessVolume.Visibility =
                bi_ImportBusinessVolume.Visibility =
                (store & AccessType.Import) != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
            //************ hide unused buttons
            bi_ImportLongTimeAbsence.Visibility = BarItemVisibility.Never;
            bi_ImportFeast.Visibility = BarItemVisibility.Never;
            bi_ImportClosedDay.Visibility = BarItemVisibility.Never;
            bi_ImportTimePlanning.Visibility = BarItemVisibility.Never;
            bi_ImportTimeRecording.Visibility = BarItemVisibility.Never;


            menu_system.Visibility =
                bi_system.Visibility = BarItemVisibility.Always;

            //User user1 = ClientEnvironment.AuthorizationService.GetCurrentUser();
        }

        private void barButtonNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((_currentUC != null) && (_currentUC.AddEnabled))
            {
                _currentUC.Add();
            }
        }

        private void barButtonEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((_currentUC != null) && (_currentUC.EditEnabled))
            {
                _currentUC.Edit();
            }
        }

        private void barButtonDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((_currentUC != null) && (_currentUC.DeleteEnabled))
            {
                if (
                    XtraMessageBox.Show(this, GetLocalized("Are you sure you want to delete selected items"),
                                        GetLocalized("Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                    DialogResult.Yes)
                {
                    return;
                }
                _currentUC.Delete();
            }
        }

        private void barButtonRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentUC != null)
            {
                _currentUC.RefreshData();
            }
        }

        private void buttonItem_LanguageManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(buttonItem_LanguageManager))
            {
                CurrentUC = new LanguageManageControl(this);
                PressedButtonTrue(buttonItem_LanguageManager);
            }
        }

        private void buttonItem_UserManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(btn_UserManager))
            {
                CurrentUC = new UserListCtrl(this);
                PressedButtonTrue(btn_UserManager);
            }
        }

        private void buttonItem_CountryManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(buttonItem_CountryManager))
            {
                CurrentUC = new CountryManageControl();
                PressedButtonTrue(buttonItem_CountryManager);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //CurrentUC = new Baumax.ClientUI.Admin.EmployeeListCtrl(this);
            if (!isButtonPressed(btn_EmployeeManager))
            {
                CurrentUC = new UCEmployeeManagerControl();
                PressedButtonTrue(btn_EmployeeManager);
            }
        }

        private void btnRegionManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(barButton_RegionManager))
            {
                CurrentUC = new RegionListCtrl();
                PressedButtonTrue(barButton_RegionManager);
            }
        }

        private void barButton_StoreManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentUC = new StoreManagerControl();
            PressedButtonTrue(barButton_StoreManager);
        }


        private void SkinChangedClick(object sender, EventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SkinName = (sender as SimpleButton).LookAndFeel.SkinName;
        }

        #region Language methods

        private bool bfreezChangeLanguageUI = false;

        public long CurrentLanguageId
        {
            get
            {
                long id = 0;
                if (barEditItemLanguages.EditValue != null)
                {
                    id = (long) barEditItemLanguages.EditValue;
                }
                return id;
            }
            set { barEditItemLanguages.EditValue = value; }
        }

        private void NotificationService_ChangedLanguage(Language entity)
        {
            List<Language> lst = ClientEnvironment.LanguageService.FindAll();

            bfreezChangeLanguageUI = true;
            long id = (long) barEditItemLanguages.EditValue;
            repositoryItemLookUpEdit1.DataSource = lst;
            barEditItemLanguages.EditValue = id;
            bfreezChangeLanguageUI = false;
        }

        private void barEditItemLanguages_EditValueChanged(object sender, EventArgs e)
        {
            if (!bfreezChangeLanguageUI)
            {
                LoadNewLanguage();
                NotificationService.OnChangedLanguageUI();
            }
        }

        private void LoadLanguages()
        {
            if (!DesignMode)
            {
                List<Language> lst = ClientEnvironment.LanguageService.FindAll();

                repositoryItemLookUpEdit1.DataSource = lst;

                barEditItemLanguages.EditValue = ClientEnvironment.UserLanguageId;
            }
        }

        private void LoadNewLanguage()
        {
            long id = CurrentLanguageId;

            if (id > 0)
            {
                DbUIProvider uiprovider = new DbUIProvider(id);
                UILocalizer.Current.UIProvider = uiprovider;
                AssignLanguage();
            }
        }

        #endregion

        private void barBtn_WgrManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*if (!isButtonPressed(btnStructure))
            {
               CurrentUC = new UCWorldList2();
               PressedButtonTrue(btnStructure);
            }
             * */
            if (!isButtonPressed(barBtn_StructureManager))
            {
                CurrentUC = new UCWorldList2();
                PressedButtonTrue(barBtn_StructureManager);
            }
        }

        private void bi_ImportCountry_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearPressedButtons();
            // acpro item #124036
            // simply closing current UC and clearing out client part of main form 
            // when the one of import routines is called
            CurrentUC = null;
            if (e.Item == bi_ImportCountry)
            {
                ImportUI.ImportCountries();
            }
            else if (e.Item == bi_ImportRegion)
            {
                ImportUI.ImportRegions();
            }
            else if (e.Item == bi_ImportStore)
            {
                ImportUI.ImportStores();
            }
            else if (e.Item == bi_ImportWorld)
            {
                ImportUI.ImportWorlds();
            }
            else if (e.Item == bi_ImportHWGR)
            {
                ImportUI.ImportHwgrs();
            }
            else if (e.Item == bi_ImportWGR)
            {
                ImportUI.ImportWgrs();
            }
            else if (e.Item == bi_ImportEmployee)
            {
                ImportUI.ImportEmployees();
            }
            else if (e.Item == bi_ImportLongTimeAbsence)
            {
                ImportUI.ImportLongTimeAbsences();
            }
            else if (e.Item == bi_ImportFeast)
            {
                ImportUI.ImportFeasts();
            }
            else if (e.Item == bi_ImportClosedDay)
            {
                ImportUI.ImportWorkingDays();
            }
            else if (e.Item == bi_ImportCashRegisterReceipt)
            {
                ImportUI.ImportCashRegisterReceipt();
            }
            else if (e.Item == bi_ImportTargetBusinessVolume)
            {
                ImportUI.ImportTargetBusinessVolume();
            }
            else if (e.Item == bi_ImportBusinessVolume)
            {
                ImportUI.ImportBusinessVolume();
            }
            else if (e.Item == bi_ImportTimePlanning)
            {
                ImportUI.ImportTimePlanning();
            }
            else if (e.Item == bi_ImportTimeRecording)
            {
                ImportUI.ImportTimeRecording();
            }
        }

        private void barButton_TimePlanning_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(barButton_TimePlanning))
            {
                CurrentUC = new UCTimePlanning();
                PressedButtonTrue(barButton_TimePlanning);
            }
        }

        private void br_AbsencePlanning_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(br_AbsencePlanning))
            {
                CurrentUC = new Baumax.ClientUI.FormEntities.AbsencePlanning.UCAbsencePlanning();// new UCAbsencePlanning();
                PressedButtonTrue(br_AbsencePlanning);
            }
        }

        private void bar_TimeRecording_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(bar_TimeRecording))
            {
                CurrentUC = new UCTimeRecording();
                PressedButtonTrue(bar_TimeRecording);
            }
        }

        private void bi_system_itemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == bisystem_about)
            {
                using (AboutForm aboutFrm = new AboutForm())
                {
                    aboutFrm.ShowDialog();
                }
            }
        }

        private void menu_langMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(buttonItem_LanguageManager))
            {
                CurrentUC = new LanguageManageControl(this);
                PressedButtonTrue(buttonItem_LanguageManager);
            }
        }

        private void menu_UserMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(btn_UserManager))
            {
                CurrentUC = new UserListCtrl(this);
                PressedButtonTrue(btn_UserManager);
            }
        }

        private void menu_countryMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(buttonItem_CountryManager))
            {
                CurrentUC = new CountryManageControl();
                PressedButtonTrue(buttonItem_CountryManager);
            }
        }

        private void menu_regionMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(barButton_RegionManager))
            {
                CurrentUC = new RegionListCtrl();
                PressedButtonTrue(barButton_RegionManager);
            }
        }

        private void menu_storemanager_itemclick(object sender, ItemClickEventArgs e)
        {
            CurrentUC = new StoreManagerControl();
            PressedButtonTrue(barButton_StoreManager);
        }

        private void menu_structureMan_itemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(barBtn_StructureManager))
            {
                CurrentUC = new UCWorldList2();
                PressedButtonTrue(barBtn_StructureManager);
            }
        }

        private void menu_employeeMan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(btn_EmployeeManager))
            {
                CurrentUC = new UCEmployeeManagerControl();
                PressedButtonTrue(btn_EmployeeManager);
            }
        }

        private void menu_absencePlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(br_AbsencePlanning))
            {
                CurrentUC = new Baumax.ClientUI.FormEntities.AbsencePlanning.UCAbsencePlanning();//new UCAbsencePlanning();
                PressedButtonTrue(br_AbsencePlanning);
            }
        }

        private void menu_timePlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(barButton_TimePlanning))
            {
                CurrentUC = new UCTimePlanning();
                PressedButtonTrue(barButton_TimePlanning);
            }
        }

        private void menu_timeRecording_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isButtonPressed(bar_TimeRecording))
            {
                CurrentUC = new UCTimeRecording();
                PressedButtonTrue(bar_TimeRecording);
            }
        }

        private void menu_importcountry_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportCountries();
        }

        private void menu_importRegion_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportRegions();
        }

        private void menu_importStore_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportStores();
        }

        private void menu_importWorld_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportWorlds();
        }

        private void menu_importHWGR_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportHwgrs();
        }

        private void menu_importWGR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportWgrs();
        }

        private void mennu_importEmployee_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportEmployees();
        }

        private void menu_importCash_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportCashRegisterReceipt();
        }

        private void menu_importTarget_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportTargetBusinessVolume();
        }

        private void menu_importBuissness_itemClick(object sender, ItemClickEventArgs e)
        {
            ImportUI.ImportBusinessVolume();
        }

        private void menu_About_itemClick(object sender, ItemClickEventArgs e)
        {
            using (AboutForm aboutFrm = new AboutForm())
            {
                aboutFrm.ShowDialog();
            }
        }

        //private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (!isButtonPressed(barLargeButtonItem1))
        //    {
        //        CurrentUC = new Baumax.ClientUI.FormEntities.AbsencePlanning.UCAbsencePlanning();
        //        PressedButtonTrue(barLargeButtonItem1);
        //    }
        //}
    }
}