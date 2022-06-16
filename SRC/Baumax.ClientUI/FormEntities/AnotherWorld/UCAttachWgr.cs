using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCAttachWgr : UCBaseEntity
    {
        private ViceHWGR m_hwgr = null;
        private HwgrToWgr m_attached;
        private string m_entityName;

        [Browsable(false)]
        public string EntityName
        {
            get { return m_entityName; }
            set { m_entityName = value; }
        }
        [Browsable(false)]
        public HwgrToWgr Attached
        {
            get { return m_attached; }
            set { m_attached = value; }
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
        public LookUpEdit EditWgr
        {
            get { return edWGR; }
            set { edWGR = value; }
        }

        public UCAttachWgr()
        {
            InitializeComponent();
        }

        public void Bind(ViceHWGR hwgr)
        {
            EditWgr.Properties.DataSource = ClientEnvironment.WGRService.FindAll();
            m_hwgr = hwgr;
        }

        public override bool IsValid()
        {
            bool noName = EditWgr.EditValue == null ;
            if (noName)
                dxErrorProvider.SetError(EditWgr, GetLocalized("SelectWGR"));
            else 
                dxErrorProvider.SetErrorType(EditWgr, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            
            bool noDate = BeginTime > EndTime;
            if (noDate)
                dxErrorProvider.SetError(uc, GetLocalized("ErrorDateRange"));
            else 
                dxErrorProvider.SetErrorType(uc, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            
            return !(noName || noDate);
        }

        public override bool Commit()
        {
            try
            {
                HwgrToWgr attach = ClientEnvironment.HwgrToWgrService.CreateEntity();
                attach.BeginTime = uc.BeginTime;
                attach.EndTime = uc.EndTime;
                attach.WGR_ID = (long)EditWgr.EditValue;
                attach.Import = false;
                attach.StoreID = m_hwgr.ID;
                m_entityName = EditWgr.Text;
                m_attached = attach = ClientEnvironment.HwgrToWgrService.SaveOrUpdate(attach);
            }
            catch(EntityException e)
            {
                ProcessEntityException(e);
                return false;
            }
            return true;
        }
        [Browsable(false)]
        public override bool Modified
        {
            get
            {
                return true;
            }
            set
            {
                base.Modified = value;
            }
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }
    }
}
