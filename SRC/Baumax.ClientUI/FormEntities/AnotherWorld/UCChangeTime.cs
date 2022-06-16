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

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCChangeTime : UCBaseEntity
    {
        private BaseTreeItem m_vice = null;
        private long m_storeID;
        private DateTime m_endTime = new DateTime(2014, 4, 4);
        private TimeSpan m_oneSecond = new TimeSpan(0, 0, 1);

        public UCChangeTime()
        {
            InitializeComponent();
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

        public void Bind(BaseTreeItem entity, long storeID)
        {
            m_vice = entity;
            m_storeID = storeID;

            edParent.Properties.DataSource = new BaseTreeItem[] { entity};
            edParent.EditValue = entity;
        }

        public override bool Commit()
        {
            try
            {
                DateTime begin = timeRange.BeginTime, 
                         end = timeRange.EndTime;
                Utility.AssignWeek(ref begin, ref end);
                timeRange.BeginTime = begin; 
                timeRange.EndTime = end;
                

                if (m_vice is HwgrTreeItem)
                {
                    HwgrTreeItem vice = m_vice as HwgrTreeItem;

                    List<WorldToHwgr> saveList = new List<WorldToHwgr>();
                    WorldToHwgr first = ClientEnvironment.WorldToHWGRService.FindById(vice.Hwgr.ID);

                    saveList.Add(first);

                    if (first.Import)
                    {
                        first.EndTime = DateTime.Now;
                        WorldToHwgr second = ClientEnvironment.WorldToHWGRService.CreateEntity();
                        second.Import = false;
                        second.BeginTime = timeRange.BeginTime;
                        second.EndTime = timeRange.EndTime;
                        second.HWGR_ID = vice.Hwgr.HWGR_ID;
                        second.WorldID = vice.Hwgr.WorldID;
                        second.StoreID = m_storeID;
                        saveList.Add(second);

                        if (vice.EndTime > timeRange.EndTime)
                        {
                            WorldToHwgr third = ClientEnvironment.WorldToHWGRService.CreateEntity();
                            third.Import = true;
                            third.BeginTime = timeRange.EndTime + m_oneSecond;
                            third.EndTime = m_endTime;
                            third.HWGR_ID = vice.Hwgr.HWGR_ID;
                            third.WorldID = vice.Hwgr.WorldID;
                            third.StoreID = m_storeID;
                            saveList.Add(third);
                        }
                    }
                    else
                    {
                        first.BeginTime = timeRange.BeginTime;
                        first.EndTime = timeRange.EndTime;
                    }
                    ClientEnvironment.WorldToHWGRService.SaveOrUpdateList(saveList);
                }
                else
                {
                    WgrTreeItem vice = m_vice as WgrTreeItem;

                    List<Domain.HwgrToWgr> saveList = new List<HwgrToWgr>();
                    Domain.HwgrToWgr first = ClientEnvironment.HwgrToWgrService.FindById(vice.Wgr.ID);

                    saveList.Add(first);

                    if (first.Import)
                    {
                        first.EndTime = DateTime.Now;
                        Domain.HwgrToWgr second = ClientEnvironment.HwgrToWgrService.CreateEntity();
                        second.Import = false;
                        second.BeginTime = timeRange.BeginTime;
                        second.EndTime = timeRange.EndTime;
                        second.WGR_ID = vice.Wgr.WGR_ID;
                        second.HWGR_ID = vice.Wgr.HWGR_ID;
                        second.StoreID = m_storeID;
                        saveList.Add(second);

                        if (vice.EndTime > timeRange.EndTime)
                        {
                            Domain.HwgrToWgr third = ClientEnvironment.HwgrToWgrService.CreateEntity();
                            third.Import = true;
                            third.BeginTime = timeRange.EndTime + m_oneSecond;
                            third.EndTime = m_endTime;
                            third.WGR_ID = vice.Wgr.WGR_ID;
                            third.HWGR_ID = vice.Wgr.HWGR_ID;
                            third.StoreID = m_storeID;
                            saveList.Add(third);
                        }
                    }
                    else
                    {
                        first.EndTime = timeRange.EndTime;
                        first.BeginTime = timeRange.BeginTime;
                    }
                    ClientEnvironment.HwgrToWgrService.SaveOrUpdateList(saveList);
                }
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public override bool IsValid()
        {
            bool noDate = timeRange.BeginTime > timeRange.EndTime;
            if (noDate)
                timeRange.SetErrorBeginTime(true);
            else
                timeRange.SetErrorBeginTime(false);
            

            return !( noDate);
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
                
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }

        private void timeRange_Load(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_Properties_Click(object sender, EventArgs e)
        {

        }

        private void btnShowHistory_EditValueChanged(object sender, EventArgs e)
        {
            ucDropHwgrHistory.Entity = Entity;
            popupControl.Show();
        }
    }
}
