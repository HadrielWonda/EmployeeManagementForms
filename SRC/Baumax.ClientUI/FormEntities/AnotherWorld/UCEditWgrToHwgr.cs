using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCEditWgrToHwgr : UCBaseEntity 
    {
        public UCEditWgrToHwgr()
        {
            InitializeComponent();
            
        }

        private StoreStructureContext m_context;

        public StoreStructureContext Context
        {
            get { return m_context; }
            set { m_context = value; }
        }
	

        public HwgrToWgr EntityHwgrToWgr
        {
            get
            {
                return (HwgrToWgr)Entity;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && BeginTime != DateTime.Now)
                BeginTime = DateTime.Now;
        }
        
        private void InitMinMax()
        {
            deBeginTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
            deBeginTime.Properties.MinValue = DateTime.Today;//Contract.DateTimeSql.SmallDatetimeMin;

            deEndTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
            deEndTime.Properties.MinValue = DateTime.Today;//Contract.DateTimeSql.SmallDatetimeMin;
        }

        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                InitMinMax();
                hwgrLookUpCtrl.EntityList = m_context.TakeStoreStructure.Hwgrs;
                wgrLookUpCtrl.EntityList = m_context.TakeStoreStructure.Wgrs;

                deBeginTime.Properties.Buttons[1].ToolTip = GetLocalized("SetDefaultValue");
                deEndTime.Properties.Buttons[1].ToolTip = GetLocalized("SetDefaultValue");

                if (EntityHwgrToWgr.IsNew)
                {
                    lblCaption.Text = GetLocalized("NewAssignWgrToHwgr");
                    BeginTime = EntityHwgrToWgr.BeginTime;
                    EndTime = EntityHwgrToWgr.EndTime;

                    if (EntityHwgrToWgr.HWGR_ID > 0)
                        HwgrId = EntityHwgrToWgr.HWGR_ID;
                    if (EntityHwgrToWgr.WGR_ID > 0)
                        WgrId = EntityHwgrToWgr.WGR_ID;
                }
                else
                {
                    lblCaption.Text = GetLocalized("EditAssignWgrToHwgr");
                    btnHistory.ToolTip = string.Format(GetLocalized("ViewHistory") + " ({0})", "WGR");
                    WgrId = EntityHwgrToWgr.WGR_ID;
                    HwgrId = EntityHwgrToWgr.HWGR_ID;
                    BeginTime = EntityHwgrToWgr.BeginTime;
                    EndTime = EntityHwgrToWgr.EndTime;
                }

                ApplyRules();
            }
        }

        private void ApplyRules()
        {
            if (Entity != null)
            {
                if (EntityHwgrToWgr.IsNew)
                {
                    wgrLookUpCtrl.Enabled = true;
                    hwgrLookUpCtrl.Enabled = true;
                    deBeginTime.Enabled = true;
                    deEndTime.Enabled = true;
                }
                else
                {
                    wgrLookUpCtrl.Enabled = false;
                    hwgrLookUpCtrl.Enabled = false;
                    deBeginTime.Enabled = BeginTime > DateTime.Today;
                    deEndTime.Enabled = EndTime > DateTime.Today;
                }
            }
        }


        public DateTime BeginTime
        {
            get { return deBeginTime.DateTime; }
            set { deBeginTime.DateTime = value; }
        }

        public DateTime EndTime
        {
            get { return deEndTime.DateTime; }
            set { deEndTime.DateTime = value; }
        }

        public long WgrId
        {
            get { return wgrLookUpCtrl.CurrentId ; }
            set { wgrLookUpCtrl.CurrentId = value; }
        }

        public long HwgrId
        {
            get { return hwgrLookUpCtrl.CurrentId; }
            set { hwgrLookUpCtrl.CurrentId = value; }
        }



        public bool IsModified()
        {
            if (Entity == null || m_context.TakeStoreStructure.IsExistingWgr(HwgrId, BeginTime, EndTime))
                return false;
            if (EntityHwgrToWgr.IsNew) return true;

            return (WgrId != EntityHwgrToWgr.WGR_ID) ||
                (HwgrId != EntityHwgrToWgr.HWGR_ID) ||
                (BeginTime != EntityHwgrToWgr.BeginTime) ||
                (EndTime != EntityHwgrToWgr.EndTime);
        }


        public override bool IsValid()
        {
            bool isvalid = true;
            if (WgrId == 0)
            {
                wgrLookUpCtrl.ErrorText = GetLocalized("ErrorSelectWgr");
                isvalid = false;
            }
            else wgrLookUpCtrl.ErrorText = String.Empty;

            if (HwgrId == 0)
            {
                hwgrLookUpCtrl.ErrorText = GetLocalized("InvalidValue");
                isvalid = false;
            }
            else hwgrLookUpCtrl.ErrorText = String.Empty;

            if (BeginTime > EndTime)
            {
                deBeginTime.ErrorText = GetLocalized("InvalidDateRange");
                isvalid = false;
            }
            else deBeginTime.ErrorText = String.Empty;

            /*string errorText = string.Empty;
            List<HwgrToWgr> history = m_context.TakeStoreStructure.GetWgrHistoty();
            foreach (HwgrToWgr var in history)
                if (DateTimeHelper.IsIntersectExc(var.BeginTime.Value, var.EndTime.Value, BeginTime, EndTime))
                {
                    isvalid = false;
                    errorText = GetLocalized("IntervalIntersect");
                }
            deBeginTime.ErrorText = errorText;*/

            return (isvalid) ? base.IsValid() : false;
        }

        private void CopyEntity(HwgrToWgr source, HwgrToWgr dest)
        {
            dest.ID = source.ID;
            dest.HWGR_ID = source.HWGR_ID;
            dest.WgrName = source.WgrName;
            dest.Import = source.Import;
            dest.StoreID = source.StoreID;
            dest.WGR_ID = source.WGR_ID;
            dest.BeginTime = source.BeginTime;
            dest.EndTime = source.EndTime;

        }

        public override bool Commit()
        {
            if (IsValid())
            {
                if (IsModified())
                {
                    HwgrToWgr entity = new HwgrToWgr();
                    CopyEntity(EntityHwgrToWgr, entity);
                    
                    entity.WGR_ID = WgrId;
                    entity.HWGR_ID = HwgrId;
                    entity.BeginTime = BeginTime;
                    entity.EndTime = EndTime;
                    
                    try
                    {
                        List<HwgrToWgr> lst =  ClientEnvironment.HwgrToWgrService.InsertRelation (entity);
                        
                        Context.TakeStoreStructure.MergeHwgrToWgr(lst);

                        CopyEntity(entity, EntityHwgrToWgr);
                        EntityHwgrToWgr.WgrName = wgrLookUpCtrl.Text;
                        Modified = true;

                        return base.Commit();
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("ErrorDateRangeIntersect"));
                        return false;
                    }
                }
                else return base.Commit();

            }
            return false;
        }

        private void wgrLookUpCtrl_EditValueChanged(object sender, EventArgs e)
        {
            m_context.TakeStoreStructure.WgrHistory = wgrLookUpCtrl.CurrentEntity;
        }

        
        private void btnHistory_Click(object sender, EventArgs e)
        {
            using (FormViewHistory form = new FormViewHistory())
            {
                form.Entity = m_context;
                wgrLookUpCtrl_EditValueChanged(this, null);
                form.ShowDialog();
            }
        }

        private void Time_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind != ButtonPredefines.Combo)
            {
                if (deEndTime == sender as DateEdit)
                    deEndTime.DateTime = DateTimeSql.SmallDatetimeMax;
                else if (deBeginTime == sender as DateEdit)
                    deBeginTime.DateTime = DateTimeHelper.GetNextMonday(DateTime.Today); ;
            }
        }

        private void deBeginTime_EditValueChanged (object sender, EventArgs e)
        {
            if (EndTime == null || BeginTime == null || Entity == null)
                return;
            if (deBeginTime.DateTime.DayOfWeek != DayOfWeek.Monday)
            {
                if (DateTimeHelper.IsDayInCurrentWeek(deBeginTime.DateTime) && DateTime.Now.DayOfWeek != DayOfWeek.Monday)
                    deBeginTime.DateTime = DateTimeHelper.GetNextMonday(deBeginTime.DateTime);
                else
                    deBeginTime.DateTime = DateTimeHelper.GetMonday(deBeginTime.DateTime);
            }
        }

        private void deEndTime_EditValueChanged (object sender, EventArgs e)
        {
            if (EndTime == null || BeginTime == null || Entity == null)
                return;
             DateTime dt = EndTime;
                if (BeginTime <= DateTimeHelper.GetSunday(dt))
                    dt = DateTimeHelper.GetSunday(dt);
                else
                    dt = DateTimeHelper.GetNextSunday(dt);
                EndTime = dt;
        }
    }
}
