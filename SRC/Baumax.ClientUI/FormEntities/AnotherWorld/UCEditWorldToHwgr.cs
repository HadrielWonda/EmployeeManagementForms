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
    public partial class UCEditWorldToHwgr : UCBaseEntity 
    {
        private StoreStructureContext m_context;

        public UCEditWorldToHwgr()
        {
            InitializeComponent();
        }
        public StoreStructureContext Context
        {
            get { return m_context; }
            set { m_context = value; }
        }

        public WorldToHwgr EntityWorldToHwgr
        {
            get
            {
                return (WorldToHwgr)Entity;
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
            deBeginTime.Properties.MinValue = DateTime.Today;// Contract.DateTimeSql.SmallDatetimeMin;

            deEndTime.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
            deEndTime.Properties.MinValue = DateTime.Today; //Contract.DateTimeSql.SmallDatetimeMin;
        }
        
        private List<StoreToWorld> RemoveAdminAndCashDeskFromList(List<StoreToWorld> listWorlds)
        {
            if (listWorlds == null)
                return listWorlds;
            List<StoreToWorld> outList = new List<StoreToWorld>();
            foreach (StoreToWorld world in listWorlds)
            {
                if (!world.IsAdministration && !world.IsCashDesk)
                    outList.Add(world);
                    
            }
            return outList;
        }
        
        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                InitMinMax();

                List<StoreToWorld> list = new List<StoreToWorld>();
                list.AddRange(m_context.TakeStoreWorld.GetStoreWorldList());
                storeWorldLookUpCtrl.EntityList = RemoveAdminAndCashDeskFromList(list);
                hwgrLookUpCtrl.EntityList = m_context.TakeStoreStructure.Hwgrs;

                deBeginTime.Properties.Buttons[1].ToolTip = GetLocalized("SetDefaultValue");
                deEndTime.Properties.Buttons[1].ToolTip = GetLocalized("SetDefaultValue");

                if (EntityWorldToHwgr.IsNew)
                {
                    lblAssignHwgrToWorld.Text = GetLocalized ("NewAssignHwgrToWorld");

                    BeginTime = EntityWorldToHwgr.BeginTime;
                    EndTime = EntityWorldToHwgr.EndTime;

                    if (EntityWorldToHwgr.HWGR_ID > 0)
                        HwgrId = EntityWorldToHwgr.HWGR_ID;
                    if (EntityWorldToHwgr.WorldID > 0)
                        WorldId = EntityWorldToHwgr.WorldID;
                }
                else
                {
                    lblAssignHwgrToWorld.Text = GetLocalized ("EditAssignHwgrToWorld");
                    WorldId = EntityWorldToHwgr.WorldID;
                    HwgrId = EntityWorldToHwgr.HWGR_ID;
                    BeginTime = EntityWorldToHwgr.BeginTime;
                    EndTime = EntityWorldToHwgr.EndTime;
                }

                ApplyRules();
                btnHistory.ToolTip = string.Format (GetLocalized("ViewHistory") + " ({0})", "HWGR");
            }
        }

        private void ApplyRules()
        {
            if (Entity != null)
            {
                if (EntityWorldToHwgr.IsNew)
                {
                    storeWorldLookUpCtrl.Enabled = true;
                    hwgrLookUpCtrl.Enabled = true;
                    deBeginTime.Enabled = true;
                    deEndTime.Enabled = true;
                }
                else
                {
                    storeWorldLookUpCtrl.Enabled = false;
                    hwgrLookUpCtrl.Enabled = false;
                    deBeginTime.Enabled = BeginTime > DateTime.Today;
                    deEndTime.Enabled = EndTime > DateTime.Today;
                }
            }
        }


        public DateTime BeginTime
        {
            get { return deBeginTime.DateTime ; }
            set { deBeginTime.DateTime = value; }
        }

        public DateTime EndTime
        {
            get { return deEndTime.DateTime; }
            set { deEndTime.DateTime = value; }
        }

        public long WorldId
        {
            get { return storeWorldLookUpCtrl.WorldId; }
            set { storeWorldLookUpCtrl.WorldId = value; }
        }

        public long HwgrId
        {
            get { return hwgrLookUpCtrl.CurrentId; }
            set { hwgrLookUpCtrl.CurrentId = value; }
        }



        public bool IsModified()
        {
            if (Entity == null || m_context.TakeStoreStructure.IsExistingHwgr (WorldId, BeginTime, EndTime)) 
                return false;
            if (EntityWorldToHwgr.IsNew) return true;

            return (WorldId != EntityWorldToHwgr.WorldID ) ||
                (HwgrId != EntityWorldToHwgr.HWGR_ID) ||
                (BeginTime != EntityWorldToHwgr.BeginTime) ||
                (EndTime != EntityWorldToHwgr.EndTime);
        }

        public override bool IsValid()
        {
            bool isvalid = true;
            if (WorldId == 0) 
            {
                storeWorldLookUpCtrl.ErrorText = GetLocalized ("ErrorSelectWorld");
                isvalid = false;
            }
            else storeWorldLookUpCtrl.ErrorText = String.Empty;

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

            if (m_context.TakeStoreStructure.IsExistingHwgr(WorldId, BeginTime, EndTime))
            {
                storeWorldLookUpCtrl.ErrorText = GetLocalized("IntervalIntersect");
                isvalid = false;
            }
            else storeWorldLookUpCtrl.ErrorText = string.Empty;

            /*string errorText = string.Empty;
            List<WorldToHwgr> history = m_context.TakeStoreStructure.GetHwgrHistory();
            foreach (WorldToHwgr var in history)
                if (DateTimeHelper.IsIntersectExc(var.BeginTime.Value, var.EndTime.Value, BeginTime, EndTime))
                {
                    isvalid = false;
                    errorText = GetLocalized("IntervalIntersect");
                }
            deBeginTime.ErrorText = errorText;*/
            if (!isvalid) return false;

            return base.IsValid();
        }

       /* private void CopyEntity(WorldToHwgr source, WorldToHwgr dest)
        {
            
            dest.ID = source.ID;
            dest.HWGR_ID = source.HWGR_ID;
            dest.HwgrName = source.HwgrName;
            dest.Import = source.Import;
            dest.StoreID = source.StoreID;
            dest.WorldID = source.WorldID;
            dest.BeginTime = source.BeginTime;
            dest.EndTime = source.EndTime;
            
        }
        */
        public override bool Commit()
        {
            if (IsValid())
            {
                if (IsModified())
                {
                    WorldToHwgr entity = new WorldToHwgr();
                    WorldToHwgr.CopyTo(EntityWorldToHwgr, entity);
                    //CopyEntity(EntityWorldToHwgr, entity);
                    entity.ID = 0;
                    entity.WorldID = WorldId;
                    entity.HWGR_ID = HwgrId;
                    entity.BeginTime = BeginTime;
                    entity.EndTime = EndTime;
                    try
                    {
                        List<WorldToHwgr> lst = ClientEnvironment.WorldToHWGRService.InsertRelation (entity);
                        if (lst != null)
                            Context.TakeStoreStructure.MergeWorldToHwgr(lst);

                        //CopyEntity(entity, EntityWorldToHwgr);
                        WorldToHwgr.CopyTo(entity, EntityWorldToHwgr);
                        EntityWorldToHwgr.HwgrName = hwgrLookUpCtrl.Text;
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

        private void deEndTime_DateTimeChanged(object sender, EventArgs e)
        {
            if (EndTime == null || BeginTime == null || Entity == null)
                return;
           
                if (EntityWorldToHwgr.Import && (EntityWorldToHwgr.EndTime == EndTime )) return;
                if (EndTime == null || BeginTime == null)
                    return;
                DateTime dt = EndTime;
                if (BeginTime <= DateTimeHelper.GetSunday(dt))
                    dt = DateTimeHelper.GetSunday(dt);
                else
                    dt = DateTimeHelper.GetNextSunday(dt);
                EndTime = dt;
        }

        private void deBeginTime_DateTimeChanged(object sender, EventArgs e)
        {
            if (EndTime == null || BeginTime == null || Entity == null)
                return;
            
                if (EntityWorldToHwgr.Import && (EntityWorldToHwgr.BeginTime == BeginTime)) return;
                if (deBeginTime.DateTime.DayOfWeek != DayOfWeek.Monday)
                {
                    if (DateTimeHelper.IsDayInCurrentWeek(deBeginTime.DateTime) && DateTime.Now.DayOfWeek != DayOfWeek.Monday)
                        deBeginTime.DateTime = DateTimeHelper.GetNextMonday(deBeginTime.DateTime);
                    else
                        deBeginTime.DateTime = DateTimeHelper.GetMonday(deBeginTime.DateTime);
                }
        }
        private void hwgrLookUpCtrl_EditValueChanged(object sender, EventArgs e)
        {
            m_context.TakeStoreStructure.HwgrHistory = hwgrLookUpCtrl.CurrentEntity;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            using(FormViewHistory form = new FormViewHistory())
            {
                form.Entity = m_context;
                hwgrLookUpCtrl_EditValueChanged(this, null);
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
                    deBeginTime.DateTime = DateTime.Today;
            }
        }
    }
}
