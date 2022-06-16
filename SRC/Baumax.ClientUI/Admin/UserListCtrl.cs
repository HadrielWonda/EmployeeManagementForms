using System;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.Admin
{
    public partial class UserListCtrl : UCBaseEntity
    {
        private UserGridCtrl _usergrids = null;
        public UserListCtrl()
        {
            InitializeComponent();
            InitGridUsers();
        }

        public UserListCtrl(Form frm)
            : base(frm)
        {
            InitializeComponent();

            InitGridUsers();
        }
        private void InitGridUsers()
        {
            _usergrids = new UserGridCtrl();
            _usergrids.Parent = splitContainer.Panel2;
            _usergrids.Dock = DockStyle.Fill;

            _usergrids.OnNotifyChangeUser += new UserGridCtrl.NotifyEntityChanged(_usergrids_OnNotifyChangeUser);
        }

        void _usergrids_OnNotifyChangeUser(BaseEntity entity)
        {
            UpdateState();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                Bind();
            }
        }

        private void nbNew_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            _usergrids.Add();
        }

        private void nbEdit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            _usergrids.FixEdit();
        }

        private void nbDelete_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            _usergrids.Delete();
        }

        public void UpdateState()
        {
            bool canWrite = (ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.UserService) &
                           AccessType.Write) != 0;
            nbNew_newuser.Enabled = canWrite;
            nbEdit_edituser.Enabled = (_usergrids.FocusedEntity != null) && canWrite;
            nbDelete_deleteuser.Enabled = (_usergrids.FocusedEntity != null) && canWrite;
        }

        /// <summary>
        /// Binds data to controls. Should be implemented in descendants of UCBaseEntity
        /// </summary>
        public override void Bind()
        {
            _usergrids.Bind();
        }
    }
}
