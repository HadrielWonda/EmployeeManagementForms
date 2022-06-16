using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.FormEntities.EntityStore;
using Baumax.ClientUI.Import;
using Baumax.Contract;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.ManageEntityControls
{
    public partial class StoreManagerControl : UCBaseEntity
    {
        UCStoreList _storeList = null;
        UCOpenCloseHoursList _opencloseList = null;
        UCGetValueFromStore _getvaluefromstore = null;
        UCStoreStructure _storeStructure = null;

        StoreManagerContext _context = new StoreManagerContext();

        public StoreManagerControl()
        {
            InitializeComponent();
            InitContext();
            ViewStoreListControl();
            if (!isCurentuserRoleCentralGlobalAdministration())
            {
                nb_ImportStore.Visible = false;
                nb_Estimate.Visible = false;
            }
            //bi_GetValue.Visible = false; // need delete after compleate.
//#if DEBUG
            if (isCurentuserRoleCentralGlobalAdministration()) bi_CopyBValue.Visible = true;
//#endif
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            UpdateState();
        }
        
        private bool isCurentuserRoleCentralGlobalAdministration()
        {
            if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
             (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.GlobalAdmin))
                return true;
            else return false;
        }
        
        public void InitContext()
        {
            Context.Init();
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode )
            {
                LocalizerControl.NavBarLocalize(navBarStore);
            }
        }

        private void ReleaseStoreList()
        {
            if (_storeList != null)
            {
                _storeList.Hide();
                _storeList.Dispose();
                _storeList = null;
            }
        }

        private void ReleaseGetValueWorkingTime()
        {
            if (_getvaluefromstore != null)
            {
                _getvaluefromstore.Hide();
                _getvaluefromstore.Dispose();
                _getvaluefromstore = null;
            }

        }

        private void ReleaseOpenCloseHoursControl()
        {
            if (_opencloseList != null)
            {
                _opencloseList.Hide();
                _opencloseList.Dispose();
                _opencloseList = null;
            }

        }

        private void ReleaseStoreStructure()
        {
            if (_storeStructure != null)
            {
                _storeStructure.Hide();
                _storeStructure.Dispose();
                _storeStructure = null;
            }

        }

        private void ViewStoreStructureControl()
        {
            if (_storeStructure == null)
            {
                ReleaseStoreList();
                ReleaseOpenCloseHoursControl();
                ReleaseGetValueWorkingTime();


                _storeStructure = new UCStoreStructure();
                _storeStructure.Dock = DockStyle.Fill;
                _storeStructure.Parent = pcClient;
                _storeStructure.Show();
                _storeStructure.SetStoreContext(Context);
            }
        }

        private void ViewStoreListControl()
        {
            if (_storeList == null)
            {
                ReleaseGetValueWorkingTime();
                ReleaseOpenCloseHoursControl();
                ReleaseStoreStructure();
                


                _storeList = new UCStoreList();
                _storeList.Dock = DockStyle.Fill;
                _storeList.Parent = pcClient;
                _storeList.Show();
                _storeList.SetStoreContext(Context);
                _storeList.OnNotifyChangeCountry += new UCStoreList.NotifyEntityChanged(_storeList_OnNotifyChangeCountry);                       //+= new UCStoreList.NotifyEntityChanged(_storeList.OnNotifyChangeCountry);
            }
        }

        private void _storeList_OnNotifyChangeCountry(Domain.BaseEntity entity)
        {
            UpdateState();
        }
        
        private void UpdateState()
        {
            bi_RunWorkingTimeEstimate.Enabled =
                bi_RunCashDeskEstimate.Enabled =
                bi_ViewEstimateData.Enabled = (_storeList.FocusedEntity != null);
        }

        private void ViewOpenCloseHoursControl()
        {
            if (_opencloseList == null)
            {
                ReleaseStoreList();
                ReleaseStoreStructure();
                ReleaseGetValueWorkingTime();


                _opencloseList = new UCOpenCloseHoursList();
                _opencloseList.Dock = DockStyle.Fill;
                _opencloseList.Parent = pcClient;
                _opencloseList.Show();
                _opencloseList.SetStoreContext(Context); ;
                //_opencloseList.LoadControlData ();
            }
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            ViewOpenCloseHoursControl();
        }

        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ViewStoreListControl();
        }

        private void nb_NewStore_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            
            if (ImportUI.ImportStores())
            {
                if (_storeList != null)
                {
                    _storeList.ReloadData();
                }
                else
                {
                    Context.ListOfStoresView.LoadAll();
                }
            }
        }

        private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ViewStoreStructureControl();
        }


        public StoreManagerContext Context
        {
            get
            {
                return _context;
            }
        }

        public StoreViewList ListOfStores
        {
            get
            {
                if (Context != null) return Context.ListOfStoresView;
                return null;
            }
        }

        private void bi_RunWorkingTimeEstimate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (isCurentuserRoleCentralGlobalAdministration() && Context.CurrentStore != null)
            {
                using (StoreEstimatioPreconditionForm frm = new StoreEstimatioPreconditionForm())
                {
                   frm.Init(Context.CurrentStore.ID, Context.CurrentStore.Name, false);
                }
            }
        }

        private void bi_RunCashDeskEstimate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (isCurentuserRoleCentralGlobalAdministration() && Context.CurrentStore != null)
            {
                using (StoreEstimatioPreconditionForm frm = new StoreEstimatioPreconditionForm())
                {
                    frm.Init(Context.CurrentStore.ID, Context.CurrentStore.Name, true);
                }
            }
        }

        private void navBarItem1_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            if (Context != null && Context.CurrentStore != null)
            {
                using (FormViewEstimateData form = new FormViewEstimateData())
                {
                    form.Init(Context.CurrentStore.ID, Context.CurrentStore.Name);
                }
            }
        }

        private void ViewGetValueWorkingTime()
        {
            if (_getvaluefromstore == null)
            {
                ReleaseStoreList();
                ReleaseOpenCloseHoursControl();
                ReleaseStoreStructure();


                _getvaluefromstore = new UCGetValueFromStore();
                _getvaluefromstore.Dock = DockStyle.Fill;
                _getvaluefromstore.Parent = pcClient;
                _getvaluefromstore.Show();
                _getvaluefromstore.SetStoreContext(Context);
               
            }
        }

        private void bi_GetValue_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
         ViewGetValueWorkingTime();
        }
    }
}
