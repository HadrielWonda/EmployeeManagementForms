using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class FormTrendCorrection : FormBaseEntity 
    {
        Store _store = null;
        TrendCorrection _entity = null;
        bool _modified = false;

        public FormTrendCorrection()
        {
            InitializeComponent();

            if (ClientEnvironment.IsRuntimeMode)
            {
                StartDate = DateTime.Today ;
                EndDate = DateTime.Today.AddDays (1) ;

                deStartDate.Properties.MinValue = DateTimeSql.DatetimeMin ;
                deStartDate.Properties.MaxValue = DateTimeSql.DatetimeMax ;

                deEndDate.Properties.MinValue = DateTimeSql.DatetimeMin ;
                deEndDate.Properties.MaxValue = DateTimeSql.DatetimeMax ;
            }
        }

        public override object Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                if (_entity != value)
                {
                    _entity = (TrendCorrection )value;
                    EntityChanged();
                }
            }
        }
        public override bool Modified
        {
            get
            {
                return _modified;
            }
        }
        public Store EntityStore
        {
            set
            {
                _store = value;

                if (_store != null)
                {
                    teStore.Text = _store.Name;
                }
            }
        }
        public TrendCorrection  EntityTrend
        {
            get { return (TrendCorrection)Entity; }
            set { Entity = value; }
        }


        private void EntityChanged()
        {

            if (Entity != null)
            {
                StoreWorldId = EntityTrend.StoreWorldID;
				TrendCorrectionName = EntityTrend.Name;
                StartDate = EntityTrend.BeginTime;
                EndDate = EntityTrend.EndTime;
                Value = EntityTrend.Value;

                if (EntityTrend.IsNew)
                    lbl_DefineTrendCorrection.Text = GetLocalized("DefineTrendCorrection");
                else lbl_DefineTrendCorrection.Text = GetLocalized("EditTrendCorrection");
            }
            else
            {
                StartDate = DateTime.Today;
                EndDate = DateTime.Today.AddDays(1);
            }

        }

        bool IsModified()
        {
            if (Entity == null) return true;

            if (EntityTrend.IsNew) return true;


            return (StoreWorldId != EntityTrend.StoreWorldID)||
				(TrendCorrectionName != EntityTrend.Name) ||
                (StartDate != EntityTrend.BeginTime)||
                (EndDate != EntityTrend.EndTime) ||
                (Value != EntityTrend.Value);
        }
        public void SetReadOnly()
        {
            lookUpWorlds.Properties.ReadOnly = true;
            lookUpWorlds.Enabled = false;
        }
        public void SetStoreWorlds(List<StoreToWorld> lst)
        {
            lookUpWorlds.Properties.DataSource = lst;

            if (lst != null && lst.Count > 0)
            {
                lookUpWorlds.EditValue = lst[0].ID;
            }
        }

        TrendCorrection CreateEntity()
        {
            TrendCorrection trend = ClientEnvironment.StoreService.TrendCorrectionService.CreateEntity();

            trend.StoreWorldID = StoreWorldId;
            trend.BeginTime = StartDate;
            trend.EndTime = EndDate;
        	trend.Name = TrendCorrectionName;
            trend.Value = Value;

            if (EntityTrend != null) trend.ID = EntityTrend.ID;
            return trend;

        }

        void CopyEntity(TrendCorrection source, TrendCorrection dest)
        {
			dest.StoreWorldID = source.StoreWorldID;
        	dest.Name = source.Name;
            dest.BeginTime = source.BeginTime;
            dest.EndTime = source.EndTime;
            dest.Value = source.Value;
            dest.ID = source.ID;
        }
        protected override bool ValidateEntity()
        {
            if (StoreWorldId == -1)
            {
                ErrorMessage(GetLocalized ("ErrorSelectWorld"));
                lookUpWorlds.Focus();
                return false;
            }

            if (StartDate > EndDate)
            {
                ErrorMessage(GetLocalized("ErrorInvalidDateRange"));
                deEndDate.Focus();
                return false;
            }

            if (EndDate > new DateTime(2079, 1, 1))
            {
                EndDate = new DateTime(2079, 1, 1);
                deEndDate.Focus();
                deEndDate.BackColor = System.Drawing.Color.Red;
                return false;
            }

            if (StartDate < new DateTime(1900, 1, 1))
            {
                StartDate = new DateTime(1900, 1, 1);
                deStartDate.BackColor = System.Drawing.Color.Red;
                deStartDate.Focus();
                return false;
            }

            if (EndDate < new DateTime(1900, 1, 1))
            {
                deEndDate.BackColor = System.Drawing.Color.Red;
                EndDate = DateTime.Now.Date;
                deEndDate.Focus();
                return false;
            }
            
            if (deStartDate.BackColor == System.Drawing.Color.Red)
            {
                deStartDate.BackColor = System.Drawing.Color.Empty;
            }

            if (deEndDate.BackColor == System.Drawing.Color.Red)
            {
                deEndDate.BackColor = System.Drawing.Color.Empty;
            }
            
            return base.ValidateEntity();
        }

        protected override bool SaveEntity()
        {
            if (IsModified())
            {
                if (EntityTrend == null || EntityTrend.IsNew)
                {
                    if (!InsertTrend()) return false;
                }
                else if (!UpdateTrend()) return false;
            }
            return base.SaveEntity();
        }

        bool InsertTrend()
        {
            if (ValidateEntity())
            {
                TrendCorrection trend = CreateEntity();

                try
                {
                    trend = ClientEnvironment.StoreService.TrendCorrectionService.Save(trend);

                    StoreToWorld sw = (StoreToWorld)lookUpWorlds.Properties.GetDataSourceRowByKeyValue(StoreWorldId);

                    if (sw != null) trend.WorldName = sw.WorldName;

                    _entity = trend;
                    _modified = true;
                    return true;
                }
                catch(ValidationException)
                {
                    ErrorMessage(GetLocalized("ErrorTrendCorrectionRangeIntersect"), GetLocalized("Attention"));
                }
            }

            return false;
        }

        bool UpdateTrend()
        {
            if (ValidateEntity())
            {
                TrendCorrection trend = CreateEntity();

                try
                {
                    trend = ClientEnvironment.StoreService.TrendCorrectionService.SaveOrUpdate(trend);

                    CopyEntity(trend, EntityTrend);
                    _modified = true;
                    return true;
                }
                catch(ValidationException)
                {
                    ErrorMessage(GetLocalized("ErrorTrendCorrectionRangeIntersect"), GetLocalized("Attention"));
                }
            }
            return false;
        }

        public long StoreWorldId
        {
            get
            {
                if (lookUpWorlds.EditValue == null) return -1;
                return Convert.ToInt64(lookUpWorlds.EditValue);
            }
            set
            {
                lookUpWorlds.EditValue = value;
            }
        }

    	public string TrendCorrectionName
    	{
    		get
    		{
    			return teName.Text;
    		}
			set
			{
				teName.Text = value;
			}
    	}

        public DateTime StartDate
        {
            get
            {
                return deStartDate.DateTime ;
            }
            set
            {
                deStartDate.DateTime = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return deEndDate.DateTime;
            }
            set
            {
                deEndDate.DateTime = value;
            }
        }
        public double Value
        {
            get
            {
                return Convert.ToDouble(ceValue.Value);
            }
            set
            {
                ceValue.Value = Convert.ToDecimal(value);
            }
        }

        private void deEndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (EndDate < StartDate) EndDate = StartDate;
        }

		private void ceValue_EditValueChanging(object sender, ChangingEventArgs e)
		{
			e.Cancel = 0 > Convert.ToDouble(e.NewValue);
		}

    }
}