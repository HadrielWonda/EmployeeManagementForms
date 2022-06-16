using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCHwgrList : UCBaseEntity
    {
        private bool i_am_wgr = false;
        private DateTime m_filterDate = DateTime.Now;
        private ViceWorld m_currentWorld = null;
        Dictionary<long, ViceWGR> m_wgrs = new Dictionary<long, ViceWGR>();
        Dictionary<long, ViceHWGR> m_hwgrs = new Dictionary<long, ViceHWGR>();
        Dictionary<long, ViceWorld> m_worlds = new Dictionary<long, ViceWorld>();

        public UCHwgrList()
        {
            InitializeComponent();
            edBeginDate.DateTime = DateTime.Now;
            edStore.Properties.DataSource = ClientEnvironment.StoreService.FindAll();
        }


        private void Storeselected(object sender, EventArgs e)
        {
            ViceWorld viceWorld = null;
            ViceHWGR viceHwgr = null;
            ViceWGR viceWgr = null;

            m_wgrs.Clear();
            m_hwgrs.Clear();
            m_worlds.Clear();

            Dictionary<long, string> nameCapsule = new Dictionary<long, string>();
            List<Domain.WGR> wgrs = ClientEnvironment.WGRService.FindAll();
            List<Domain.HWGR> hwgrs = ClientEnvironment.HWGRService.FindAll();
            List<Domain.World> worlds = ClientEnvironment.WorldService.FindAll();
            
            List<long> dWgr = ClientEnvironment.HwgrToWgrService.GetHwgrToWgrFiltered(edBeginDate.DateTime)
                .ConvertAll<long>(new Converter<HwgrToWgr, long>(delegate(HwgrToWgr w)
                {
                    return w.ID;
                }));
            List<long> dHwgr = ClientEnvironment.WorldToHWGRService.GetWorldToHwgrFiltered(edBeginDate.DateTime)
                .ConvertAll<long>(new Converter<WorldToHwgr, long>(delegate(WorldToHwgr w)
                {
                    return w.ID;
                }));

            if (wgrs != null)
                foreach (Domain.WGR var in wgrs)
                    nameCapsule.Add(var.ID, var.Name);
            if (hwgrs != null)
                foreach (Domain.HWGR var in hwgrs)
                    nameCapsule.Add(var.ID, var.Name);
            if (worlds != null)
                foreach (Domain.World var in worlds)
                    nameCapsule.Add(var.ID, var.Name);
            string name = string.Empty;

            Domain.Store selected = edStore.EditValue as Domain.Store;

            if (selected != null)
            {
                System.Collections.IList storeStruct = ClientEnvironment.StoreService
                    .GetStoreStructure(selected.ID);

                if (storeStruct != null)
                {
                    foreach (Dao.QueryResult.StoreStructure str in storeStruct)
                    {
                        string s = String.Empty;
                        nameCapsule.TryGetValue(str.WorldID, out s);
                        str.WorldName = s;
                        s = String.Empty;
                        nameCapsule.TryGetValue(str.HWGR_ID, out s);
                        str.HWGR_Name = s;
                        s = String.Empty;
                        nameCapsule.TryGetValue(str.WGR_ID, out s);
                        str.WGR_Name = s;

                    }
                }
                StoreStructureItems items = new StoreStructureItems();
                items.ProcessStoreStructure(storeStruct);

                if (storeStruct != null)
                    foreach (Dao.QueryResult.StoreStructure str in storeStruct)
                    {
                        if (!m_worlds.ContainsKey(str.Store_WorldID))
                        {
                            nameCapsule.TryGetValue(str.WorldID, out name);
                            viceWorld = new ViceWorld(name,
                                str.Store_WorldID,
                                str.WorldID);
                            m_worlds.Add(str.Store_WorldID, viceWorld);
                        }
                        if (!m_hwgrs.ContainsKey(str.World_HWGR_ID)
                            && dHwgr.Contains(str.World_HWGR_ID)
                            && viceWorld != null)
                        {
                            nameCapsule.TryGetValue(str.HWGR_ID, out name);
                            viceHwgr = new ViceHWGR(name,
                                str.World_HWGR_ID,
                                str.HWGR_BeginTime,
                                str.HWGR_EndTime,
                                str.HWGR_ID);
                            viceWorld.HWGRs.Add(viceHwgr);
                        }
                        nameCapsule.TryGetValue(str.WGR_ID, out name);
                        viceWgr = new ViceWGR(name,
                            str.HWGR_WGR_ID,
                            str.WGR_BeginTime,
                            str.WGR_EndTime,
                            str.WGR_ID);
                        if (!m_wgrs.ContainsKey(str.HWGR_WGR_ID)
                            && dWgr.Contains(str.HWGR_WGR_ID)
                            && viceHwgr != null)
                        {
                            m_wgrs.Add(str.HWGR_WGR_ID, viceWgr);
                            viceHwgr.WGRs.Add(viceWgr);
                        }
                    }
                List<ViceWorld> t = new List<ViceWorld>();
                t.AddRange(m_worlds.Values);
                edWorld.Properties.DataSource = t;
                edWorld.Visible = true;
            }
        }
        private void WorldSelect(object sender, EventArgs e)
        {
            ViceWorld selected = (ViceWorld)edWorld.EditValue;
            if (selected != null)
            {
                edHwgr.Properties.DataSource = selected.HWGRs;
            }
        }

        private void EnableBarButtons()
        {
            nbi_AttachWGR.Enabled = true;
            nbi_ChangeTimeRange.Enabled = true;
            nbi_StopWorkingNow.Enabled = true;
            _hwgrGrid.Enabled = true;
        }
        private void FilterChanged(object sender, EventArgs e)
        {
            m_filterDate = edBeginDate.DateTime;
            Storeselected(edStore, new EventArgs());
        }

        private void AttachHwgrClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.PleaseAttachHWGR();
        }

        private void StopWorkingNowClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.PleaseStopWorkingNow();
        }

        private void AttachWgrClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.PleaseAttachWGR();
        }

        private void ChangeTimeRangeClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _hwgrGrid.PleaseChangeTimeRangeNow();
        }

        private void HwgrSelect(object sender, EventArgs e)
        {
            ViceHWGR selected = edHwgr.EditValue as ViceHWGR;
            if (selected != null)
            {
                EnableBarButtons();
                _hwgrGrid.MutableWgrManager(selected);
            }
        }

        protected void MutableToWgrList()
        {
            nbi_ImportHWGR.LargeImageIndex += 1;
            nbi_ImportHWGR.Caption = "Import WGRs";
            nb_HWGRManager.Caption = "WGR manager";
            i_am_wgr = true;
        }

        private void ImportClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (i_am_wgr )
                if(Baumax.ClientUI.Import.ImportUI.ImportWgrs())
                    Storeselected(this, new EventArgs());
            else 
                if (Baumax.ClientUI.Import.ImportUI.ImportHwgrs())
                    Storeselected(this, new EventArgs());
        }
    }
}
