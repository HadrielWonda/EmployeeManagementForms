using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI.Admin;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Baumax.ClientUI.FormEntities.User
{
    public partial class UserCtrl : UCBaseEntity
    {
        private RelationBindingList<Domain.Country> _CountryBindList;
        private bool _CountriesModified;

        private RelationBindingList<Domain.Region> _RegionBindList;
        private bool _RegionsModified;

        private RelationBindingList<Store> _StoreBindList;
        private bool _StoresModified;


        public UserCtrl()
        {
            InitializeComponent();
        }

        public override void Bind()
        {
            if (UserEntity != null)
            {
                checkEdit_Active.Checked = UserEntity.Active;
                checkEdit_ChangePasswordAtNextLogin.Checked = UserEntity.ShouldChangePassword;

                teLoginName.Text = UserEntity.LoginName;
                teLoginName.Properties.ReadOnly = !UserEntity.IsNew;
                teLoginName.Enabled = UserEntity.IsNew;

                IList<UserRole> roles = ClientEnvironment.UserService.GetRoles();
                LocalizeRoles(roles);

                lookupRole.Properties.DataSource = roles;
                if (UserEntity.IsNew)
                {
                    UserEntity.UserRoleID = (long)UserRoleId.GlobalAdmin;
                    tePassword.Text = "";
                    checkEdit_ChangePasswordAtNextLogin.Checked = false;
                }
                else
                    tePassword.Text = UserEntity.Password;

                lookupRole.EditValue = UserEntity.UserRoleID;

                IList languages = ClientEnvironment.LanguageService.FindAll();
                lookupLanguage.Properties.DataSource = languages;
                lookupLanguage.EditValue = UserEntity.LanguageID;

                BindCountries();
                BindRegions();
                BindStores();
                if (UserEntity.UserRoleID.HasValue)
                {
                    ApplyRoleView(ClientEnvironment.RoleService.FindById(UserEntity.UserRoleID.Value));
                }
                else
                {
                    ApplyRoleView(null);
                }
            }
            else
            {
                checkEdit_Active.Checked = false;
                teLoginName.Text = null;
                tePassword.Text = "";
                ApplyRoleView(null);
            }
        }

        private void BindCountries()
        {
            if (UserEntity != null)
            {
                if (!UserEntity.IsNew)
                {
                    _CountryBindList = new RelationBindingList<Domain.Country>();
                    IList<Domain.Country> lst = ClientEnvironment.UserService.GetUserCountries(UserEntity.ID);
                    if ((lst != null) && (lst.Count > 0))
                    {
                        foreach (Domain.Country country in lst)
                        {
                            _CountryBindList.Add(country);
                        }
                    }
                }
                else
                {
                    _CountryBindList = new RelationBindingList<Domain.Country>();
                }

                lbCountries.DataSource = _CountryBindList;
            }
        }

        private void BindRegions()
        {
            if (UserEntity != null)
            {
                _RegionBindList = new RelationBindingList<Domain.Region>();
                if (!UserEntity.IsNew)
                {
                    IList<Domain.Region> lst = ClientEnvironment.UserService.GetUserRegions(UserEntity.ID);
                    if ((lst != null) && (lst.Count > 0))
                    {
                        foreach (Domain.Region region in lst)
                        {
                            _RegionBindList.Add(region);
                        }
                    }
                }
                lbRegions.DataSource = _RegionBindList;
            }
        }

        private void BindStores()
        {
            if (UserEntity != null)
            {
                _StoreBindList = new RelationBindingList<Store>();
                if (!UserEntity.IsNew)
                {
                    IList<Store> lst = ClientEnvironment.UserService.GetUserStores(UserEntity.ID);
                    if ((lst != null) && (lst.Count > 0))
                    {
                        foreach (Store store in lst)
                        {
                            _StoreBindList.Add(store);
                        }
                    }
                }
                lbStores.DataSource = _StoreBindList;
            }
        }

        public override bool Commit()
        {
            if (!IsValid())
            {
                return false;
            }

            if (UserEntity.Active != checkEdit_Active.Checked)
            {
                UserEntity.Active = checkEdit_Active.Checked;
                Modified = true;
            }

            if (UserEntity.ShouldChangePassword != checkEdit_ChangePasswordAtNextLogin.Checked)
            {
                UserEntity.ShouldChangePassword = checkEdit_ChangePasswordAtNextLogin.Checked;
                Modified = true;
            }

            if (UserEntity.LoginName != teLoginName.Text)
            {
                UserEntity.LoginName = teLoginName.Text;
                Modified = true;
            }

            if (UserEntity.Password != tePassword.Text)
            {
                if (!string.IsNullOrEmpty(tePassword.Text))
                    UserEntity.Password = '#' + tePassword.Text;
                else
                    UserEntity.Password = "";
                Modified = true;
            }

            if (UserEntity.UserRoleID != (long?) lookupRole.EditValue)
            {
                UserEntity.UserRoleID = (long?) lookupRole.EditValue;
                Modified = true;
            }

            if (UserEntity.LanguageID != (long?) lookupLanguage.EditValue)
            {
                UserEntity.LanguageID = (long?) lookupLanguage.EditValue;
                Modified = true;
            }

            UserRole role = CurrentRole;

            if (role == null)
            {
                UserEntity.UserCountryList.Clear();
                UserEntity.UserRegionList.Clear();
                UserEntity.UserStoreList.Clear();
            }
            else if (role.ID == (long) UserRoleId.CountryAdmin)
            {
                UserEntity.UserRegionList.Clear();
                UserEntity.UserStoreList.Clear();
                CommitCountries();
            }
            else if (role.ID == (long)UserRoleId.Controlling)
            {
                UserEntity.UserRegionList.Clear();
                UserEntity.UserStoreList.Clear();
                CommitCountries();
            }
            else if (role.ID == (long)UserRoleId.RegionAdmin)
            {
                UserEntity.UserCountryList.Clear();
                UserEntity.UserStoreList.Clear();
                CommitRegions();
            }
            else if (role.ID == (long) UserRoleId.StoreAdmin)
            {
                UserEntity.UserCountryList.Clear();
                UserEntity.UserRegionList.Clear();
                CommitStores();
            }
            else
            {
                UserEntity.UserCountryList.Clear();
                UserEntity.UserRegionList.Clear();
                UserEntity.UserStoreList.Clear();
            }

            return true;
        }

        public override bool IsValid()
        {
            bool loginValid = !string.IsNullOrEmpty(teLoginName.Text);
            if (loginValid && UserEntity.IsNew)
            {
                loginValid = loginValid && teLoginName.Text.Length > 3 && teLoginName.Text.Length <= 50;
            }

            if (!loginValid)
            {
                dxErrorProvider.SetError(teLoginName, GetLocalized("InvalidLogin"));
            }
            else
            {
                if (UserEntity.IsNew && ClientEnvironment.UserService.UserExist(teLoginName.Text))
                {
                    dxErrorProvider.SetError(teLoginName, GetLocalized("UserExist"));
                    loginValid = false;
                }
                else
                {
                    dxErrorProvider.SetError(teLoginName, "", ErrorType.None);
                }
            }

            /*bool passwordValid = true;
            if (UserEntity.IsNew || (!UserEntity.IsNew && tePassword.Text.Length > 0))
            {
                passwordValid = !string.IsNullOrEmpty(tePassword.Text) && tePassword.Text.Length > 4;
                if (!passwordValid)
                {
                    dxErrorProvider.SetError(tePassword, GetLocalized("InvalidPassword"));
                }
                else
                {
                    dxErrorProvider.SetError(tePassword, "", ErrorType.None);
                }
            }*/

            return loginValid/* & passwordValid*/;
        }

        private void CommitCountries()
        {
            if (_CountriesModified)
            {
                List<Domain.Country> removed = _CountryBindList.GetRemoveList();
                foreach (Domain.Country rc in removed)
                {
                    IList ucs = UserEntity.UserCountryList;
                    foreach (UserCountry uc in ucs)
                    {
                        if (uc.CountryID == rc.ID)
                        {
                            ucs.Remove(uc);
                            break;
                        }
                    }
                }

                List<Domain.Country> newc = _CountryBindList.GetNewItemList();
                foreach (Domain.Country nc in newc)
                {
                    bool found = false;
                    IList ucs = UserEntity.UserCountryList;
                    for (int i = 0; i < ucs.Count; i++)
                    {
                        UserCountry uc = (UserCountry) ucs[i];
                        if (uc.CountryID == nc.ID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        UserCountry uc = new UserCountry();
                        uc.User = UserEntity;
                        uc.CountryID = nc.ID;
                        UserEntity.UserCountryList.Add(uc);
                    }
                }
            }
        }

        private void CommitRegions()
        {
            if (_RegionsModified)
            {
                List<Domain.Region> removed = _RegionBindList.GetRemoveList();
                foreach (Domain.Region rc in removed)
                {
                    IList ucs = UserEntity.UserRegionList;
                    foreach (UserRegion uc in ucs)
                    {
                        if (uc.RegionID == rc.ID)
                        {
                            ucs.Remove(uc);
                            break;
                        }
                    }
                }

                List<Domain.Region> newc = _RegionBindList.GetNewItemList();
                foreach (Domain.Region nc in newc)
                {
                    bool found = false;
                    IList ucs = UserEntity.UserRegionList;
                    for (int i = 0; i < ucs.Count; i++)
                    {
                        UserRegion uc = (UserRegion) ucs[i];
                        if (uc.RegionID == nc.ID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        UserRegion uc = new UserRegion();
                        uc.User = UserEntity;
                        uc.RegionID = nc.ID;
                        UserEntity.UserRegionList.Add(uc);
                    }
                }
            }
        }

        private void CommitStores()
        {
            if (_StoresModified)
            {
                List<Store> removed = _StoreBindList.GetRemoveList();
                foreach (Store rc in removed)
                {
                    IList ucs = UserEntity.UserStoreList;
                    foreach (UserStore uc in ucs)
                    {
                        if (uc.StoreID == rc.ID)
                        {
                            ucs.Remove(uc);
                            break;
                        }
                    }
                }

                List<Store> newc = _StoreBindList.GetNewItemList();
                foreach (Store nc in newc)
                {
                    bool found = false;
                    IList ucs = UserEntity.UserStoreList;
                    for (int i = 0; i < ucs.Count; i++)
                    {
                        UserStore uc = (UserStore) ucs[i];
                        if (uc.StoreID == nc.ID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        UserStore uc = new UserStore();
                        uc.User = UserEntity;
                        uc.StoreID = nc.ID;
                        UserEntity.UserStoreList.Add(uc);
                    }
                }
            }
        }

        private void ApplyRoleView(UserRole role)
        {
            tabPage_Countries.PageEnabled = false;
            tabPage_Regions.PageEnabled = false;
            tabPage_Stores.PageEnabled = false;
            if (role != null)
            {
                //IAuthorizationService auth = ClientEnvironment.AuthorizationService;
                if (role.ID == (long) UserRoleId.CountryAdmin)
                {
                    tabPage_Countries.PageEnabled = true;
                }
                if (role.ID == (long)UserRoleId.Controlling)
                {
                    tabPage_Countries.PageEnabled = true;
                }
                else if (role.ID == (long)UserRoleId.RegionAdmin)
                {
                    tabPage_Regions.PageEnabled = true;
                }
                else if (role.ID == (long) UserRoleId.StoreAdmin)
                {
                    tabPage_Stores.PageEnabled = true;
                }
            }
        }

        private void LocalizeRoles(IList<UserRole> roles)
        {
            foreach (UserRole role in roles)
            {
                switch((UserRoleId)role.ID)
                {
                    case UserRoleId.GlobalAdmin:
                        role.Name = GetLocalized("GlobalAdmin");
                        break;

                    case UserRoleId.Controlling:
                        role.Name = GetLocalized("Controlling");
                        break;

                    case UserRoleId.CountryAdmin:
                        role.Name = GetLocalized("CountryAdmin");
                        break;

                    case UserRoleId.RegionAdmin:
                        role.Name = GetLocalized("RegionAdmin");
                        break;

                    case UserRoleId.StoreAdmin:
                        role.Name = GetLocalized("StoreAdmin");
                        break;
                }
            }
        }

        private Domain.User UserEntity
        {
            get { return (Domain.User) Entity; }
        }

        private UserRole CurrentRole
        {
            get
            {
                long? roleId = (long?) lookupRole.EditValue;
                if (roleId.HasValue)
                {
                    object o = lookupRole.Properties.GetDataSourceRowByKeyValue(roleId.Value);
                    return (UserRole) o;
                }
                return null;
            }
        }

        private void lookupLanguage_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                lookupLanguage.EditValue = null;
            }
        }

        private void lookupRole_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                lookupRole.EditValue = null;
            }
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            using (CountrySelectFrm frm = new CountrySelectFrm())
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    foreach (Domain.Country country in frm.SelectedCountries)
                    {
                        if (_CountryBindList.GetItemByID(country.ID) == null)
                        {
                            _CountryBindList.Add(country);
                            Modified = true;
                            _CountriesModified = true;
                        }
                    }
                }
            }
        }

        private void btnDelCountry_Click(object sender, EventArgs e)
        {
            if (lbCountries.SelectedItem != null)
            {
                if (QuestionMessage(GetLocalized("questionDeleteCountry"), GetLocalized("Confirm")) == DialogResult.Yes)
                {
                    Domain.Country country = (Domain.Country) lbCountries.SelectedItem;
                    _CountryBindList.Remove(country);
                    Modified = true;
                    _CountriesModified = true;
                }
            }
        }

        private void btnAddRegion_Click(object sender, EventArgs e)
        {
            using (RegionSelectForm frm = new RegionSelectForm())
            {
                frm.ExcludeIds(_RegionBindList.GetIds());

                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    List<Domain.Region> regions = frm.SelectedRegions;
                    if (regions != null)
                    {
                        foreach (Domain.Region region in regions)
                        {
                            object exist = _RegionBindList.GetItemByID(region.ID);

                            if (null == exist)
                            {
                                _RegionBindList.Add(region);
                                Modified = true;
                                _RegionsModified = true;
                            }
                        }
                    }
                }
            }
        }

        private void btnDelRegion_Click(object sender, EventArgs e)
        {
            if (lbRegions.SelectedItem != null)
            {
                if (QuestionMessage(GetLocalized("questionDeleteRegion"), GetLocalized("Confirm")) == DialogResult.Yes)
                {
                    Domain.Region r = (Domain.Region) lbRegions.SelectedItem;
                    _RegionBindList.Remove(r);
                    Modified = true;
                    _RegionsModified = true;
                }
            }
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            using (StoreSelectFrm frm = new StoreSelectFrm())
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    List<Store> stores = frm.SelectedStores;
                    foreach (Store store in stores)
                    {
                        if (_StoreBindList.GetItemByID(store.ID) == null)
                        {
                            _StoreBindList.Add(store);
                            Modified = true;
                            _StoresModified = true;
                        }
                    }
                }
            }
        }

        private void btnDelStore_Click(object sender, EventArgs e)
        {
            if (lbStores.SelectedItem != null)
            {
                if (QuestionMessage(GetLocalized("questionDeleteStore"), GetLocalized("Confirm")) == DialogResult.Yes)
                {
                    Store r = (Store) lbStores.SelectedItem;
                    _StoreBindList.Remove(r);
                    Modified = true;
                    _StoresModified = true;
                }
            }
        }

        private void lookupRole_EditValueChanged(object sender, EventArgs e)
        {
            ApplyRoleView(CurrentRole);
        }
    }
}