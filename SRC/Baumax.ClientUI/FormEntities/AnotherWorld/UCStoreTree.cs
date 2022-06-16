using System;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCStoreTree : UCBaseEntity
    {
        private StoreStructureContext m_context = null;
        private bool isUserControlling = false;
        private bool isUserStoreAdministrator = false;

        public void ReloadTree()
        {
            if (m_context != null)
            {
                BindingTemplate<BaseTreeItem> list = m_context.TakeStoreStructure.GetStructure();
                treeList.DataSource = list;
                treeList.ExpandAll();
            }
        }

        public UCStoreTree()
        {
            InitializeComponent();
            Disposed += new EventHandler(UCStoreTree_Disposed);

            if (!IsDesignMode)
            {
                if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.Controlling))
                {
                    treeList.ContextMenuStrip = null;
                    isUserControlling = true;
                }
                else
                    if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                        (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.StoreAdmin))
                        isUserStoreAdministrator = true; 
            }
            
        }

        private void UCStoreTree_Disposed(object sender, EventArgs e)
        {
            if (m_context != null)
            {
                m_context.WorldChanged -= context_WorldChanged;
                m_context.TakeStoreStructure.FilterDateChanged -= FilterDateChanged;
                m_context.StoreChanged -= m_context_StoreChanged;
            }
        }
        
        protected override void  EntityChanged()
        {
 	        base.EntityChanged();
            if (m_context != Entity as StoreStructureContext)
            {
                m_context = Entity as StoreStructureContext;
                m_context.WorldChanged += context_WorldChanged;
                m_context.StoreChanged += m_context_StoreChanged;
                m_context_StoreChanged(this, null);
            }
            ReloadTree();
        }

        void m_context_StoreChanged(object sender, EventArgs e)
        {
            m_context.TakeStoreStructure.FilterDateChanged += FilterDateChanged;
        }

        void FilterDateChanged(object sender, EventArgs e)
        {
            ReloadTree();
        }
        
        void context_WorldChanged(object sender, EventArgs e)
        {
            ReloadTree();
        }
        
        private void cms_Opening(object sender, CancelEventArgs e)
        {
            StoreToWorld entity = m_context.TakeStoreWorld.GetWorld(m_context.StoreToWorldID);
            e.Cancel = false;
            if (entity == null || entity.WorldTypeID != WorldType.World)
                e.Cancel = true;
             if (isUserStoreAdministrator)
                 ts_AssignHwgr.Visible = false;
            e.Cancel = e.Cancel || ! m_context.TakeStoreStructure.IsAnyWgr;
        }

        private void ts_AssignThisHwgrToWorld_Click(object sender, EventArgs e)
        {
            NewAssignHwgrToWorld();
        }

        private void ts_AssignWgrToThisHwgr_Click(object sender, EventArgs e)
        {
            NewAssignWgrToHwgr();
        }

        public void NewAssignWgrToHwgr()
        {
            WgrTreeItem item = null;

            if (IsWgrFocused) item = FocusedEntity as WgrTreeItem;

            HwgrToWgr newitem = new HwgrToWgr ();
            newitem.StoreID = m_context.Store.ID;
            if (item != null)
            {
                newitem.HWGR_ID = item.Wgr.HWGR_ID;
                newitem.WGR_ID = item.Wgr.WGR_ID;
                newitem.BeginTime = DateTimeHelper.GetNextMonday (DateTime.Today);
                newitem.EndTime = DateTimeSql.SmallDatetimeMax;
            }
            else
            {
                newitem.BeginTime = DateTime.Today;
                newitem.EndTime = DateTimeSql.SmallDatetimeMax;
            }

            using (FormAssignWgrToHwgr form = new FormAssignWgrToHwgr())
            {
                form.Context = m_context;
                form.Entity = newitem;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    treeList.BeginUpdate();
                    m_context.TakeStoreStructure.ReBuildByWgr(newitem, (treeList.DataSource as BindingTemplate<BaseTreeItem>));
                    EntityChanged();
                    treeList.EndUpdate();
                }
            }


        }
        public void NewAssignHwgrToWorld()
        {
            HwgrTreeItem item = null;

            if (IsHwgrFocused) item = FocusedEntity as HwgrTreeItem;

            WorldToHwgr newitem = new WorldToHwgr();
            newitem.StoreID = m_context.Store.ID;
            if (item != null)
            {
                newitem.HWGR_ID = item.Hwgr.HWGR_ID;
                newitem.WorldID = item.Hwgr.WorldID;
                newitem.BeginTime = DateTimeHelper.GetNextMonday(DateTime.Today);
                newitem.EndTime = DateTimeSql.SmallDatetimeMax;
            }
            else
            {
                newitem.BeginTime = DateTime.Today;
                newitem.EndTime = DateTimeSql.SmallDatetimeMax;
                newitem.HWGR_ID = m_context.WorldToHwgr.HWGR_ID;
                newitem.WorldID = m_context.WorldToHwgr.WorldID;
            }

            using (FormAssignHwgrToWorld form = new FormAssignHwgrToWorld())
            {
                form.Context = m_context;
                form.Entity = newitem;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    treeList.BeginUpdate();
                    m_context.TakeStoreStructure.ReBuildByHwgr (newitem.HWGR_ID, (treeList.DataSource as BindingTemplate<BaseTreeItem>));
                    EntityChanged();
                    treeList.EndUpdate();
                }
            }
        }
        
        protected void ChangeTimeInterval(TreeListNode node)
        {

            if (IsHwgrFocused && !isUserStoreAdministrator)
            {
                NewAssignHwgrToWorld();
            }
            else
                if (IsWgrFocused)
                {
                    NewAssignWgrToHwgr();
                }
        }

        public bool IsHaveContent()
        { 
            return treeList.DataSource != null && (treeList.DataSource as BindingTemplate<BaseTreeItem>).Count > 0;
        }

        private void treeList_DoubleClick(object sender, EventArgs e)
        {
            if (!isUserControlling)
            ChangeTimeInterval(treeList.FocusedNode);
        }

        private void FireChangedFocusedTreeNode()
        {
                BaseTreeItem item = treeList.GetDataRecordByNode(treeList.FocusedNode) as BaseTreeItem;
                if (item != null)
                {
                    HwgrTreeItem hw = item as HwgrTreeItem;
                    if (hw != null)
                        m_context.WorldToHwgr = hw.Hwgr;
                    else 
                    {
                        WgrTreeItem w = item as WgrTreeItem;
                        if (w != null)
                        {
                            foreach (BaseTreeItem parent in treeList.DataSource as BindingTemplate<BaseTreeItem>)
                                if (parent.ID == w.ParentID)
                                {
                                    m_context.WorldToHwgr = (parent as HwgrTreeItem).Hwgr;
                                    break;
                                }
                            m_context.HwgrToWgr = w.Wgr;
                        }
                    }
                }
            
        }

        private TreeListNode GetNodeByEntity(BaseTreeItem entity)
        { 
            TreeListNode ret_node = null;
            foreach(TreeListNode node in treeList.Nodes)
                if (entity == GetEntityByNode(node))
                {
                    ret_node = node;
                    break;
                }
            return ret_node;
        }
        private BaseTreeItem GetEntityByNode(TreeListNode node)
        {
            return treeList.GetDataRecordByNode(node) as BaseTreeItem;
        }

        private bool IsContain(BaseEntity entity)
        {
            bool contain = false;
            foreach (BaseTreeItem bti in treeList.DataSource as BindingTemplate<BaseTreeItem>)
                if (bti.GetRelationID() == entity.ID)
                {
                    contain = true;
                    break;
                }
            return contain;
        }


        public BaseTreeItem FocusedEntity
        {
            get
            {
                return GetEntityByNode(treeList.FocusedNode);
            }
        }
        public bool IsHwgrFocused
        {
            get
            {
                BaseTreeItem item = FocusedEntity;
                return (item != null) && (item is HwgrTreeItem);
            }
        }
        public bool IsWgrFocused
        {
            get
            {
                BaseTreeItem item = FocusedEntity;
                return (item != null) && (item is WgrTreeItem);
            }
        }

        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FireChangedFocusedTreeNode();
        }


        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(components);
                tc_Name.Caption = GetLocalized("Name");
                tc_StartDate.Caption = GetLocalized("BeginDate");
                tc_EndDate.Caption = GetLocalized("EndDate");
            }
        }
    }
}
