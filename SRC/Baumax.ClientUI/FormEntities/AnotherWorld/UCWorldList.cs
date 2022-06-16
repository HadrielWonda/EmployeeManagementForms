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
    public partial class UCWorldList : UCBaseEntity
    {
        private DateTime m_filterDate = DateTime.Now;

        Dictionary<long, ViceWGR> m_wgrs = new Dictionary<long, ViceWGR>();
        Dictionary<long, ViceHWGR> m_hwgrs = new Dictionary<long, ViceHWGR>();
        Dictionary<long, ViceWorld> m_worlds = new Dictionary<long, ViceWorld>();

        public UCWorldList()
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

            long selected = (long)edStore.EditValue;

            if (selected != null)
            {
                System.Collections.IList storeStruct = ClientEnvironment.StoreService
                    .GetStoreStructure(selected);

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
                _worldGrid.Bind(selected);
            }
            EnableBarButtons();
        }

        private void EnableBarButtons()
        {
            nbi_AttachHWGR.Enabled = true;
            nbi_ChangeTimeRange.Enabled = true;
            nbi_AttachWGR.Enabled = true;
            nbi_StopWorkingNow.Enabled = true;

            _worldGrid.Enabled = true;
            worldDetail.Enabled = true;
            if (edStore.EditValue != null && edWorld.EditValue != null)
            {
                System.Collections.IList detail = ClientEnvironment.StoreToWorldService.GetStoreWorldDetail(
                    (short)m_filterDate.Year,
                    (long)edStore.EditValue,
                    ((ViceWorld)edWorld.EditValue).ID);
                if (detail != null)
                    worldDetail.DisplayWorldData(detail[0] as Dao.QueryResult.StoreWorldDetail);
            }
        }
        private void FilterChanged(object sender, EventArgs e)
        {
            m_filterDate = edBeginDate.DateTime;
        }

        private void gridelectEntity(object sender, EventArgs e)
        {
            if (sender is ViceHWGR)
            {
                nbi_AttachHWGR.Enabled = true;
            }
            else 
            {
                nbi_AttachHWGR.Enabled = false;
            }
        }

        private void AttachHwgrClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.PleaseAttachHWGR();
        }

        private void StopWorkingNowClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.PleaseStopWorkingNow();
        }

        private void AttachWgrClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.PleaseAttachWGR();
        }

        private void ChangeTimeRangeClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _worldGrid.PleaseChangeTimeRangeNow();
        }

        private void ImportClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (Baumax.ClientUI.Import.ImportUI.ImportWorlds())
            {
                Storeselected(this, new EventArgs());
            }
        }
    }
}