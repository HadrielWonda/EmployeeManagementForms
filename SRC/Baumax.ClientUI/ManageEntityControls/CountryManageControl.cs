using System;
using System.Collections.Generic;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.FormEntities.Country;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.ManageEntityControls
{
    public partial class CountryManageControl : UCBaseEntity
    {
        public CountryManageControl()
        {
            InitializeComponent();
            if (!isCurentuserRoleCentralGlobalAdministration())
            {
                navBarItem_ImportCountry.Visible = false;
                navBarGroup1.Visible = false;
            }
        }

        private bool isCurentuserRoleCentralGlobalAdministration()
        {
            if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
            (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.GlobalAdmin))
                return true;
            else return false;
        }

        void UpdateButtonState()
        {
            Country c = ucCountryList21.FocusedEntity;

            navBarItem_CountryDetails.Enabled = c != null;
            navBarItem_EditCountry.Enabled = c != null;
            navBarItem_ImportCountry.Enabled = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<Country> lst = ClientEnvironment.CountryService.FindAll();

            ucCountryList21.CountryList = lst;
        }

        private void navBarItem_NewCountry_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ucCountryList21.FireNewEntity();
        }

        private void navBarItem_EditCountry_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ucCountryList21.FireEditEntity(null);
        }

        private void navBarItem_DeleteCountry_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //ucCountryList21.FireDeleteEntity(null);
            if (ucCountryList21.FocusedEntity != null)
            {
                ucCountryList21.ShowCountryDetail();
            }
        }

        private void ucCountryList21_OnChangeFocusedEntity(BaseEntity entity)
        {
            UpdateButtonState();

            /*if (entity != null)
            {
                countryDetailControl1.Country = (Country)entity;
            }
            else countryDetailControl1.Country = null;*/
        }

        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.NavBarLocalize(navBarControlCountries);
            }
        }

        private void bi_RunCashDeskEstimate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (isCurentuserRoleCentralGlobalAdministration())
            {
                using(EstimatePreconditionsForm frm = new EstimatePreconditionsForm())
                {
                    frm.IsCashDesk = true;
                    frm.ShowDialog();
                }
            }
        }

        private void bi_RunStoreWorkingTimeEstimate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (isCurentuserRoleCentralGlobalAdministration())
            {
                using (EstimatePreconditionsForm frm = new EstimatePreconditionsForm())
                {
                    frm.IsCashDesk = false;
                    frm.ShowDialog();
                }
            }
        }
    }
}

