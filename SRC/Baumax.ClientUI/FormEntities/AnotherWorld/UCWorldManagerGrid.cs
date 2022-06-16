using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldManagerGrid : UCBaseEntity
    {
        protected BindingList<ViceHWGR> hwgrs;
        protected ViceWGR dragWgr;
        protected ViceHWGR dragHWGR;
        protected GridHitInfo hitInfo = null;
        protected GridHitInfo hitInfoHwgr = null;
        protected ViceWorld m_world = null;




        public event EventHandler SelectEntity;


        public UCWorldManagerGrid()
        {
            InitializeComponent    ();
            gridHWGR.BestFitColumns();
            gridWGR.BestFitColumns ();
            this.SelectEntity += new EventHandler(UCWorldManagerGrid_SelectEntity);
        }

        void UCWorldManagerGrid_SelectEntity(object sender, EventArgs e)
        {
            if (hitInfo != null)
            {
                // gridWGR
                ts_AttachHwgrTo.Enabled = false;
            }
            else if (hitInfoHwgr == null) return;
            else
            {
                // gridHWGR
                ts_AttachHwgrTo.Enabled = true;
            }
        }

        public void Bind (ViceWorld data)
        {
            m_world = data;
            hwgrs = data.HWGRs;
            gridControl1.DataSource = hwgrs;
        }

        private void gridHWGR_GetChild(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs e)
        {
            e.DefaultView = gridWGR;
        }

        private void DragDrop(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {
            
        }

        private void wgrDragStart(object sender, DevExpress.XtraGrid.Views.Base.DragObjectStartEventArgs e)
        {
            dragWgr = e.DragObject as ViceWGR;
        }

        private void wgrDragProcess(object sender, DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs e)
        {
            
        }

        private void wgrDragDopEnd(object sender, DevExpress.XtraGrid.Views.Base.DragObjectDropEventArgs e)
        {
            int i = e.DropInfo.Index;
        }

        private void GridWGR_MouseDown(object sender, MouseEventArgs e)
        {   
            DevExpress.XtraGrid.Views.Grid.GridView active = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (active != null)
            {
                hitInfo = active.CalcHitInfo(e.X, e.Y);
                dragWgr = (ViceWGR)active.GetRow(hitInfo.RowHandle);
                SelectEntity (dragWgr, null);
            }
        }
        private void GridHWGR_MouseDown(object sender, MouseEventArgs e)
        {
            hitInfoHwgr = gridHWGR.CalcHitInfo (e.X, e.Y);
            dragHWGR = (ViceHWGR)gridHWGR.GetRow(hitInfoHwgr.RowHandle);
            hitInfo = null;
            SelectEntity (dragHWGR, null);
        }

        private void GridWGR_MouseMove(object sender, MouseEventArgs e)
        {
            if (hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            Rectangle dragRect = new Rectangle(new Point(
                hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)))
            {
                if (hitInfo.InRowCell)
                    gridControl1.DoDragDrop(gridWGR.GetRow(hitInfo.RowHandle), DragDropEffects.Copy);
                if (hitInfo.HitTest == GridHitTest.RowIndicator)
                {
                    ViceWGR data = (ViceWGR)gridWGR.GetRow(hitInfo.RowHandle);
                    gridControl1.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

        private void ChangeTimeRangeClick(object sender, EventArgs e)
        {
            PleaseChangeTimeRangeNow();
        }

        #region public methods
        public void MutableWgrManager (ViceHWGR _hwgr)
        {
            gridControl1.MainView = gridWGR;
            dragHWGR = _hwgr;
            gridControl1.DataSource = _hwgr.WGRs;
        }

        protected void ChangeTimeRangeHwgr()
        { /*
            FormChangeTime form = new FormChangeTime();
            form.UC.Bind(dragHWGR, m_world);
            try
            {
                if (form.ShowDialog() == DialogResult.OK && dragHWGR != null)
                {
                    dragHWGR.BeginTime = form.UC.BeginTime;
                    dragHWGR.EndTime = form.UC.EndTime;
                }
            }
            catch (EntityException ex)
            {
                XtraMessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        protected void ChangeTimeRangeWgr()
        {/*
            FormChangeTime form = new FormChangeTime();
            form.Bind(dragWgr, dragHWGR);
            try
            {
                if (form.ShowDialog() == DialogResult.OK && dragHWGR != null)
                {
                    dragWgr.BeginTime = form.BeginTime;
                    dragWgr.EndTime = form.EndTime;
                }
            }
            catch (EntityException ex)
            {
                XtraMessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        protected void StopWorkingWgr()
        {
            try
            {
                dragWgr.EndTime = DateTime.Now;
                HwgrToWgr first = ClientEnvironment.HwgrToWgrService.FindById(dragWgr.ID);
                first.EndTime = DateTime.Now;
                ClientEnvironment.HwgrToWgrService.SaveOrUpdate(first);
            }
            catch (EntityException ex)
            {
                XtraMessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void StopWorkingHwgr()
        {
            dragHWGR.EndTime = DateTime.Now;

            try
            {
                WorldToHwgr first = ClientEnvironment.WorldToHWGRService.FindById(dragHWGR.ID);
                if (first != null)
                {
                    first.EndTime = DateTime.Now;
                    ClientEnvironment.WorldToHWGRService.SaveOrUpdate(first);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PleaseAttachHWGR()
        {
            FormAttachHwgr form = new FormAttachHwgr();
            form.Bind(m_world);

            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                    hwgrs.Add (new ViceHWGR (form.EntityName,
                        form.Attached.ID,
                        (DateTime)form.Attached.BeginTime,
                        (DateTime)form.Attached.EndTime,
                        form.Attached.HWGR_ID));
            }        
            catch (EntityException ex)
            {
                XtraMessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PleaseAttachWGR()
        {
            FormAttachWgr form = new FormAttachWgr();
            form.Bind(dragHWGR);
            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                    dragHWGR.WGRs.Add(new ViceWGR(form.EntityName,
                        form.Attached.ID,
                        (DateTime)form.Attached.BeginTime,
                        (DateTime)form.Attached.EndTime,
                        form.Attached.WGR_ID));
            }
            catch (EntityException ex)
            {
                XtraMessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void StopWorkingNowClick(object sender, EventArgs e)
        {
            PleaseStopWorkingNow();
        }

        private void AttachWgrClick(object sender, EventArgs e)
        {
            PleaseAttachWGR();
        }

        private void AttachHwgrClick(object sender, EventArgs e)
        {
            PleaseAttachHWGR();
        }

        public void PleaseStopWorkingNow()
        {
            if (hitInfo == null)
                StopWorkingHwgr();
            else StopWorkingWgr();
        }

        public void PleaseChangeTimeRangeNow()
        {
            if (hitInfo == null)
                ChangeTimeRangeHwgr();
            else ChangeTimeRangeWgr();
        }


    }
}
