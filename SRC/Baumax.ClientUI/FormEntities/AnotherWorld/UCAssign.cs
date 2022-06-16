using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCAssign : UCBaseEntity
    {
        private DateTime m_endTime = new DateTime(2014, 4, 4);
        private TimeSpan m_oneSecond = new TimeSpan(0, 0, 1);
        private AssignEnum m_assignEnum = AssignEnum.ThisHwgrToWgr;
        private long m_OneItem ;
        private List<Domain.WGR> m_DropItemsWgr = null;
        private BaseTreeItem m_assigned = null;

        public BaseTreeItem Assigned
        {
            get { return m_assigned; }
            set { m_assigned = value; }
        }
	
        public List<Domain.WGR> DropItemsWgr
        {
            get { return m_DropItemsWgr; }
            set { m_DropItemsWgr = value; }
        }
        private List<Domain.HWGR> m_DropItemsHwgr = null;

        public List<Domain.HWGR> DropItemsHwgr
        {
            get { return m_DropItemsHwgr; }
            set { m_DropItemsHwgr = value; }
        }
        private List<Domain.World> m_DropItemsWorld = null;

        public List<Domain.World> DropItemsWorld
        {
            get { return m_DropItemsWorld; }
            set { m_DropItemsWorld = value; }
        }
        private long m_storeID;

        [Browsable(false)]
        public long OneItem
        {
          get { return m_OneItem; }
          set 
          { 
              m_OneItem = value;
          }
        }

        [Browsable(false)]
        public AssignEnum AssignEnum
        {
            get { return m_assignEnum; }
            set 
            { 
                m_assignEnum = value;
            }
        }
        [Browsable(false)]
        public DateTime BeginTime
        {
            get { return timeRange.BeginTime; }
            set { timeRange.BeginTime = value; }
        }
        [Browsable(false)]
        public DateTime EndTime
        {
            get { return timeRange.EndTime; }
            set { timeRange.EndTime = value; }
        }

        public UCAssign()
        {
            InitializeComponent();
        }

        public void Bind (AssignEnum _type, long storeID)
        {
            AssignEnum = _type;
            m_storeID = storeID;

            switch (_type)
            {
                case AssignEnum.WorldHwgrDisable:
                    edParent.Properties.ReadOnly = true;

                    edParent.EditValue = (Entity as WorldToHwgr).WorldID;
                    goto case AssignEnum.ThisHwgrToWorld;
                case AssignEnum.ThisHwgrToWorld:
                    lbChild.Text = "HWGR";
                    lbParent.Text = "World";
                    
                        edChild.Properties.DataSource = DropItemsHwgr;
                        edChild.EditValue = m_OneItem;
                        edChild.Properties.ReadOnly = true;
                    if (m_DropItemsWorld != null)
                        edParent.Properties.DataSource = m_DropItemsWorld;
                    break;
                case AssignEnum.HwgrWgrDisable:
                    edParent.Properties.ReadOnly = true;
                    edParent.EditValue = (Entity as HwgrToWgr).HWGR_ID;
                    goto case AssignEnum.ThisWgrToHWGR;
                case AssignEnum.ThisWgrToHWGR:
                    lbChild.Text = "WGR";
                    lbParent.Text = "HWGR";
                        edChild.Properties.DataSource = DropItemsWgr;
                        edChild.EditValue = m_OneItem;
                        edChild.Properties.ReadOnly = true;
                    if (m_DropItemsHwgr != null)
                        edParent.Properties.DataSource = m_DropItemsHwgr;
                    break;
                
                case AssignEnum.ThisHwgrToWgr:
                    lbChild.Text = "WGR";
                    lbParent.Text = "HWGR";
                        edParent.Properties.DataSource = DropItemsHwgr;
                        edParent.EditValue = m_OneItem;
                        edParent.Properties.ReadOnly = true;
                    if (m_DropItemsWgr != null)
                        edChild.Properties.DataSource = m_DropItemsWgr;
                    break;
            }
        }

        public override bool IsValid()
        {
            bool noParent = edParent.EditValue == null, 
                 noChild  = edChild.EditValue == null,
                 noDate = timeRange.BeginTime > timeRange.EndTime;

            if (noParent)
                dxErrorProvider.SetError(edParent, GetLocalized("SelectHWGR"));
            else dxErrorProvider.SetErrorType(edParent, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            if (noChild)
                dxErrorProvider.SetError(edChild, GetLocalized("SelectWGR"));
            else dxErrorProvider.SetErrorType(edChild, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);


            if (noDate)
                timeRange.SetErrorBeginTime(true);
            else timeRange.SetErrorBeginTime(false);


            return !(noParent || noChild || noDate);
        }

        public override bool Commit ()
        {
            try
            {
                DateTime begin = BeginTime, end = EndTime;
                Utility.AssignWeek (ref begin, ref end);
                BeginTime = begin;
                EndTime = end; 
                switch (m_assignEnum)
                { 
                    case AssignEnum.ThisHwgrToWgr :
                    case AssignEnum.ThisWgrToHWGR :
                        HwgrToWgr assign = ClientEnvironment.HwgrToWgrService.CreateEntity();
                        assign.BeginTime = BeginTime;
                        assign.EndTime = EndTime;
                        assign.HWGR_ID = (long)edParent.EditValue;
                        assign.Import = false;
                        assign.StoreID = m_storeID;
                        assign.WGR_ID = (long)edChild.EditValue;
                        ClientEnvironment.HwgrToWgrService.Save (assign);
                        m_assigned = new WgrTreeItem(assign, assign.HWGR_ID);
                        break;

                    case AssignEnum.ThisHwgrToWorld :
                        WorldToHwgr assign2 = ClientEnvironment.WorldToHWGRService.CreateEntity();
                        assign2.BeginTime = BeginTime;
                        assign2.EndTime = EndTime;
                        assign2.HWGR_ID = (long)edChild.EditValue;
                        assign2.Import = false;
                        assign2.StoreID = m_storeID;
                        assign2.WorldID = (Entity as WorldToHwgr).WorldID;
                        ClientEnvironment.WorldToHWGRService.Save(assign2);
                        m_assigned = new HwgrTreeItem(assign2, 0);
                        break;

                    case AssignEnum.WorldHwgrDisable:
                            DateTime t1 = timeRange.BeginTime,
                                     t2 = timeRange.EndTime;
                            Utility.AssignWeek(ref begin, ref end);
                            timeRange.BeginTime = t1;
                            timeRange.EndTime = t2;

                               WorldToHwgr vice = Entity as WorldToHwgr;
                             WorldToHwgr first = ClientEnvironment.WorldToHWGRService.FindById(vice.ID);
                                    first.BeginTime = timeRange.BeginTime;
                                    first.EndTime = timeRange.EndTime;

                                    ClientEnvironment.WorldToHWGRService.Update(first);
                        break;
                    case AssignEnum.HwgrWgrDisable:
                        HwgrToWgr vice2 = Entity as HwgrToWgr;
                        Domain.HwgrToWgr first2 = ClientEnvironment.HwgrToWgrService.FindById(vice2.ID);
                         first2.EndTime = timeRange.EndTime;
                            first2.BeginTime = timeRange.BeginTime;
                        
                        ClientEnvironment.HwgrToWgrService.Update(first2);
                        break;
                } 
            }
            catch(ValidationException)
            {
                XtraMessageBox.Show(Baumax.Localization.Localizer.GetLocalized("InvalidTimeRange"));
                return false;
            }/*
            catch (Exception ex)
            {
                XtraMessageBox.Show (ex.Message);
                return false;
            }*/
            return true;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }

        public override bool Modified
        {
            get { return true;}
            set { base.Modified = value; }
        }

    
    }
}
