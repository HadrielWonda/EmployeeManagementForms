using System;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.FormEntities
{
    public partial class RegionListCtrl : UCBaseEntity
    {
        UCRegionList _regionGridCtrl = null;
        public RegionListCtrl()
        {
            InitializeComponent();

            _regionGridCtrl = new UCRegionList();
            _regionGridCtrl.Parent = splitContainer.Panel2;
            _regionGridCtrl.Dock = DockStyle.Fill;
            _regionGridCtrl.OnNotifyFocusedChanged += new NotifyFocusedEntityChanged(_regionGridCtrl_OnNotifyFocusedChanged);
        }

        void _regionGridCtrl_OnNotifyFocusedChanged(BaseEntity entity)
        {
            UpdateState(); 
        }

        private bool isCurentuserRoleCentralGlobalAdministration()
        {
            if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
             (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.GlobalAdmin))
                return true;
            else return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                _regionGridCtrl.Init();
                //ctrlRegionGrid.RegionList = ClientEnvironment.RegionService.FindAll();
                //
                if (!isCurentuserRoleCentralGlobalAdministration())
                    bi_ImportRegion.Visible = false;
            }
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            LocalizerControl.NavBarLocalize(ctrlNavBar);
        }
        private void nbNew_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            _regionGridCtrl.Add();
        }

        private void nbEdit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Domain.Region region = _regionGridCtrl.FocusedRegion;
            if (region != null)
            {
                _regionGridCtrl.ShowRegionStores();
            }
        }

        private void UpdateState()
        {
            Domain.Region region = _regionGridCtrl.FocusedRegion;

            bi_ImportRegion.Enabled = true;
            bi_RegionDetails.Enabled = region != null;
            bi_EditRegion.Enabled = region != null;
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (_regionGridCtrl.FocusedRegion != null)
            {
                _regionGridCtrl.EditRegion();
            }
        }
    }
}
