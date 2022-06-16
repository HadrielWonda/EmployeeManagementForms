using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.FormEntities.User;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.Admin
{
    public partial class UserGridCtrl : UCBaseEntity
    {
        private BindingTemplate<UserInfo> _UserList = new BindingTemplate<UserInfo>();

        public delegate void NotifyEntityChanged(BaseEntity entity);
        public event NotifyEntityChanged OnNotifyChangeUser = null;
        private bool canWrite = false;
        private int focusedRow = -1; 
        private bool isRowNotFixed = false; 
        private UserInfo focusedUser = null; 
        private const byte OK = 0;
        private byte fixedTimes = OK;
        private bool _groupByRole = true;

        public UserGridCtrl()
        {
            InitializeComponent();
            ClientEnvironment.UserService.EntitiesChanged += new EntitiesChangedDelegate(UserService_EntitiesChanged);
            ClientEnvironment.UserService.InvalidateWholeCache +=
                new InvalidateWholeCacheDelegate(UserService_InvalidateWholeCache);
            Disposed += new EventHandler(UserGridCtrl_Disposed);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            canWrite = (ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.UserService) &
                           AccessType.Write) != 0;
            if (!canWrite)
            {
               gridControl.ContextMenuStrip = null;  
            }
            gridColumn_Role.GroupIndex = 0;
            
        }
        void UserGridCtrl_Disposed(object sender, EventArgs e)
        {
            ClientEnvironment.UserService.EntitiesChanged -= new EntitiesChangedDelegate(UserService_EntitiesChanged);
            ClientEnvironment.UserService.InvalidateWholeCache -=
                new InvalidateWholeCacheDelegate(UserService_InvalidateWholeCache);
        }

        void UserService_EntitiesChanged(IEnumerable<long> ids)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EntitiesChangedDelegate(UserService_EntitiesChanged), ids);
                return;
            }

            Bind();
        }

        void UserService_InvalidateWholeCache()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new InvalidateWholeCacheDelegate(UserService_InvalidateWholeCache));
                return;
            }

            Bind();
        }

        public override void Bind()
        {
            IList<User> users = ClientEnvironment.UserService.GetUserList();
            List<UserInfo> info = new List<UserInfo>(users.Count);
            foreach (User user in users)
            {
                info.Add(new UserInfo(user));
            }
            SetUserList(info);
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode )
                LocalizerControl.ComponentsLocalize(components);
        }
        [Browsable(false)]
        public BindingTemplate<UserInfo> UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }

        public void SetUserList(IList<UserInfo> users)
        {
            gridControl.BeginInit();
            try
            {
                UserList.Clear();

                if (users != null)
                {
                    UserList.CopyList(users);
                }
                if (gridControl.DataSource == null)
                {
                    gridControl.DataSource = UserList;
                   // gridColumn_Role.GroupIndex = 0;
                }
            }
            finally
            {
                gridControl.EndInit();
            }
        }

        [DefaultValue(true)]
        public bool GroupByRole
        {
            get { return _groupByRole; }
            set
            {
                if (value != _groupByRole)
                {
                    _groupByRole = value;
                    if (GroupByRole)
                    {
                        gridColumn_Role.GroupIndex = 0;
                    }
                    else
                    {
                        gridColumn_Role.GroupIndex = -1;
                    }
                }
            }
        }

        private UserInfo GetEntityByRowHandle(int rowHandle)
        {
            UserInfo entity = null;
            if (gridViewUser.IsDataRow(rowHandle))
            {
                entity = (UserInfo) gridViewUser.GetRow(rowHandle);
            }
            return entity;
        }

        public UserInfo FocusedEntity
        {
            get { return GetEntityByRowHandle(gridViewUser.FocusedRowHandle); }
        }

        /// <summary>
        /// Add new item
        /// </summary>
        public override void Add()
        {
            User usr = ClientEnvironment.UserService.CreateEntity();
            using (FormUser frm = new FormUser())
            {
                frm.Entity = usr;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (usr.IsNew)
                    {
                        try
                        {
                            usr = ClientEnvironment.UserService.Save(usr);
                            UserList.Add(new UserInfo(usr));
                            for (int row = 0 ; row < UserList.Count; row++)
                            {
                                if ( UserList[row].User.ID == usr.ID)
                                {
                                    focusedRow = row;
                                    break;
                                }
                            }
                            focusedUser = new UserInfo(usr);
                            isRowNotFixed = true;
                            fixedTimes = 3;
                            fixFocusedEntity();
                        }
                        catch (EntityException ex)
                        {
                            // 2think: what details should we show?
                            // 2think: how to localize?
                            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                            {
                                form.Text = GetLocalized("CannotSaveUser");
                                form.ShowDialog(this);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            usr = ClientEnvironment.UserService.SaveOrUpdate(usr);
                            UserList.ResetItemById(usr.ID);
                        }
                        catch (EntityException ex)
                        {
                            // 2think: what details should we show?
                            // 2think: how to localize?
                            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                            {
                                form.Text = GetLocalized("CannotSaveUser");
                                form.ShowDialog(this);
                            }
                        }
                    }
                }
            }
         //   RefreshData(); //******************!!!!!!!!!
        }
        
        public void FixEdit()
        {
            setFocusedRow();
            Edit();
            isRowNotFixed = true;
            fixFocusedEntity();   
        }

        /// <summary>
        /// Edit current item
        /// </summary>
        /// 
        public override void Edit()
        {
            UserInfo info = FocusedEntity;
            if (info != null)
            {
                using (FormUser frm = new FormUser())
                {
                    frm.Entity = info.User;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (info.User.IsNew)
                        {
                            try
                            {
                                User usr = ClientEnvironment.UserService.Save(info.User);
                                UserList.Add(new UserInfo(usr));
                            }
                            catch (EntityException ex)
                            {
                                // 2think: what details should we show?
                                // 2think: how to localize?
                                using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                                {
                                    form.Text = GetLocalized("CannotSaveUser");
                                    form.ShowDialog(this);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                User usr = ClientEnvironment.UserService.SaveOrUpdate(info.User);
                                UserList.ResetItemById(usr.ID);
                            }
                            catch (EntityException ex)
                            {
                                // 2think: what details should we show?
                                // 2think: how to localize?
                                using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                                {
                                    form.Text = GetLocalized("CannotSaveUser");
                                    form.ShowDialog(this);
                                }
                            }
                        }
                    }
                }

                UserList.ResetItemById(info.User.ID); 
            }
            RefreshData();
        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        public override void Delete()
        {
            if (QuestionMessageYes(GetLocalized("questiondeleteuser"),
                                   GetLocalized("confirm")))
            {
                List<long> ids = new List<long>();

                foreach (int rowHandle in gridViewUser.GetSelectedRows())
                {
                    UserInfo info = GetEntityByRowHandle(rowHandle);
                    if (info != null)
                    {
                        ids.Add(info.User.ID);
                        UserList.Remove(info);
                    }
                }

                if (ids.Count == 1)
                {
                    try
                    {
                        ClientEnvironment.UserService.DeleteByID(ids[0]);
                    }
                    catch (EntityException ex)
                    {
                        // 2think: what details should we show?
                        // 2think: how to localize?
                        using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                        {
                            form.Text = GetLocalized("CannotDeleteUser");
                            form.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    try
                    {
                        ClientEnvironment.UserService.DeleteListByID(ids);
                    }
                    catch (EntityException)
                    {
                        // can't obtain more details while deleting list
                        ErrorMessage(GetLocalized("SomeUsersNotDeleted"));
                    }
                }
            }
            RefreshData();
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (canWrite)
            {
                   GridHitInfo info = gridViewUser.CalcHitInfo(e.X, e.Y);

                if (info.InRowCell && gridViewUser.IsDataRow(info.RowHandle))
                {
                   setFocusedRow();
                   Edit();
                   isRowNotFixed = true;
                   fixFocusedEntity();
                } 
            }
        }

        private void gridViewUser_FocusedRowChanged(object sender,
                                                    FocusedRowChangedEventArgs e)
        {
            if (OnNotifyChangeUser != null)
            {
                if (FocusedEntity != null)
                    OnNotifyChangeUser(FocusedEntity.User);
                else
                {
                    OnNotifyChangeUser(null);  
                    fixFocusedEntity();
                }
            }
        }

        private void toolStripMenuItem_newUser_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void toolStripMenuItem_editUser_Click(object sender, EventArgs e)
        {
            setFocusedRow();
            Edit();
            isRowNotFixed = true;
            fixFocusedEntity();
        }

        private void toolStripMenuItem_deleteUser_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void contextMenuUsers_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItem_newUser.Enabled = true;
            menuItem_GroupByRole.Checked = GroupByRole;
            toolStripMenuItem_editUser.Enabled = FocusedEntity != null;
            toolStripMenuItem_deleteUser.Enabled = FocusedEntity != null;
            menuItem_CollapseAll.Visible = menuItem_ExpandedAll.Visible = GroupByRole;
        }

        private void setFocusedRow()
        {
            focusedRow = gridViewUser.FocusedRowHandle;
            focusedUser = FocusedEntity;
            isRowNotFixed = true;
            fixedTimes = 3;
        }
        
        private void fixFocusedEntity()
        {
           if (isRowNotFixed)
            {
                gridViewUser.FocusedRowHandle = focusedRow;
                
                if (FocusedEntity == null || focusedUser.User.ID != FocusedEntity.User.ID)
                {
                    for (int row = 0; row < gridViewUser.RowCount; row ++)
                    {
                        if (GetEntityByRowHandle(row) != null)
                        {
                           if (focusedUser.Login == GetEntityByRowHandle(row).Login)
                            {
                              gridViewUser.FocusedRowHandle = row;
                                    if (fixedTimes == OK)
                                    {
                                        isRowNotFixed = false;
                                        return;
                                    }
                                    fixedTimes--;      
                              return;
                            } 
                        }
                    }
                }
                 else
                    {
                        if (fixedTimes == OK)
                        {
                            isRowNotFixed = false;
                            return;
                        }
                        fixedTimes--;      
                    }
            }
        }

        private void menuItem_CollapseAll_Click(object sender, EventArgs e)
        {
            if (gridViewUser != null && gridViewUser.RowCount != 0)
                gridViewUser.CollapseAllGroups();
        }

        private void menuItem_ExpandedAll_Click(object sender, EventArgs e)
        {
            if (gridViewUser != null && gridViewUser.RowCount != 0)
                gridViewUser.ExpandAllGroups();
        }

        private void menuItem_GroupByRole_Click(object sender, EventArgs e)
        {
            GroupByRole = !GroupByRole;
        }
    }

    public class UserInfo : BaseEntity
    {
        private User _User;
        private UserRole _Role;

        public UserInfo(User user)
        {
            User = user;
            
        }

        public string Login
        {
            get { return _User.LoginName; }
        }

        public bool Active
        {
            get { return _User.Active; }
        }

        public string RoleName
        {
            get
            {
                if (_Role != null)
                    return _Role.Name;
                else
                    return null;
            }
        }

        public User User
        {
            get { return _User; }
            set
            {
                _User = value;
                if (_User.UserRoleID.HasValue)
                    _Role = ClientEnvironment.RoleService.FindById(User.UserRoleID.Value);
            }
        }

        public UserRole Role
        {
            get { return _Role; }
        }
    }
}
    