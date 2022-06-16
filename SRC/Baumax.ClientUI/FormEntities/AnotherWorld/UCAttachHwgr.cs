using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCAttachHwgr : UCBaseEntity
    {
        private ViceWorld m_world = null;
        private WorldToHwgr m_attached;
        private string m_entityName;
        private AssignEnum m_assign = AssignEnum.ThisHwgrToWorld;

        [Browsable(false)]
        public AssignEnum AssignEnum
        {
            get { return m_assign; }
            set { m_assign = value; }
        }
        [Browsable(false)]
        public string EntityName
        {
            get { return m_entityName; }
            set { m_entityName = value; }
        }
        [Browsable(false)]
        public WorldToHwgr Attached
        {
            get { return m_attached; }
            set { m_attached = value; }
        }
        [Browsable(false)]
        public LookUpEdit EditWorld
        {
            get { return  edWorld; }
            set { edWorld = value; }
        }
        [Browsable(false)]
        public DateTime BeginTime
        {
            get { return uc.BeginTime; }
            set { uc.BeginTime = value; }
        }
        [Browsable(false)]
        public DateTime EndTime
        {
            get { return uc.EndTime; }
            set { uc.EndTime = value; }
        }
        [Browsable(false)]
        public LookUpEdit EditHWGR
        {
            get { return EditHwgr; }
            set { EditHwgr = value; }
        }

        public UCAttachHwgr()
        {
            InitializeComponent();
        }

        public override bool IsValid()
        {
            bool noName = EditHwgr.EditValue == null;
            if (noName)
                dxErrorProvider.SetError(EditHwgr, GetLocalized("SelectHWGR"));
            else dxErrorProvider.SetErrorType(EditHwgr, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            bool noDate = BeginTime > EndTime;
            if (noDate)
                dxErrorProvider.SetError(uc, GetLocalized("ErrorDateRange"));
            else dxErrorProvider.SetErrorType(uc, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            
            
            return ! (noName || noDate);
        }

        public override bool Commit()
        {
            long worldID = (long)edWorld.EditValue;
            WorldToHwgr attach   = ClientEnvironment.WorldToHWGRService.CreateEntity();
            attach.BeginTime     = uc.BeginTime;
            attach.EndTime       = uc.EndTime;
            attach.HWGR_ID       = (long)EditHWGR.EditValue;
            attach.Import        = false;
            attach.StoreID = worldID;
            m_entityName         = EditHWGR.Text;
            m_attached = attach  = ClientEnvironment.WorldToHWGRService.Save(attach);

            return true;
        }
        [Browsable(false)]
        public override bool Modified
        {
            get { return true; }
            set { }
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }

        public void Bind (ViceWorld world)
        {
            EditHWGR.Properties.DataSource = ClientEnvironment.HWGRService.FindAll();

            edWorld.EditValue = world;
            edWorld.Enabled = false;

            m_assign = AssignEnum.ThisHwgrToWorld;
            m_world = world;
        }
        public void Bind (ViceHWGR hwgr, BindingList<ViceWorld> worlds)
        {
            edWorld.Properties.DataSource = worlds;

            EditHwgr.EditValue = hwgr;
            EditHwgr.Enabled = false;

            m_assign = AssignEnum.ThisHwgrToWgr;
        }
    }
}
