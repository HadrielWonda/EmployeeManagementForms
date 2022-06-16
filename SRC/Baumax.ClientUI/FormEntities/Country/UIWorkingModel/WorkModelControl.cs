using System;
using System.ComponentModel;
using System.Drawing;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.WorkingModelConditions;


namespace Baumax.ClientUI.FormEntities.Country.UIWorkingModel
{
    public partial class WorkModelControl : UCBaseEntity
    {
        public WorkModelControl()
        {
            InitializeComponent();
        }
        WMItemList wnlist = null;
        DaysList _daysList = null;



        void BuildList()
        {

            wnlist = new WMItemList();
            wnlist.OnChangeState += new WMItemCheckedChanged(wnlist_OnChangeState);
            gridControl.DataSource = wnlist;
            BuildDaysList();
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                radioGroup1.Properties.Items[0].Description = GetLocalized("LessThan");
                radioGroup1.Properties.Items[1].Description = GetLocalized("GreaterThan");
            }
        }

        void wnlist_OnChangeState(BaseWMItemView item)
        {

            ConditionTypes cts = wnlist.State;
            editWorkingTimeFactor.Enabled = spinEditFixedAmount.Enabled = checkEdit_ApplyAdditionalCharge.Enabled = !ConditionHelper.IsOnlyMessageCondition(cts);

        }

        #region Working Model Entity Properties

        internal string WorkingModelName
        {
            get
            {
                return editModelName.Text.Trim();
            }
            set
            {
                editModelName.Text = value;
            }
        }

        internal string WorkingModelMessage
        {
            get
            {
                return editMessage.Text.Trim();
            }
            set
            {
                editMessage.Text = value;
            }
        }

        internal double MultiplyFactor
        {
            get
            {
                return Convert.ToDouble(editWorkingTimeFactor.EditValue);
            }
            set
            {
                editWorkingTimeFactor.EditValue = value;
            }
        }

        internal double FixedAmount
        {
            get
            {
                return Convert.ToDouble(spinEditFixedAmount.EditValue);
            }
            set
            {
                spinEditFixedAmount.EditValue = value;
            }
        }
        internal bool IsAdditionalCharge
        {
            get
            {
                return checkEdit_ApplyAdditionalCharge.Checked ;
            }
            set
            {
                checkEdit_ApplyAdditionalCharge.Checked = value;
            }
        }

        internal DateTime BeginDate
        {
            get
            {
                return deBeginDate.DateTime;
            }
            set
            {
                deBeginDate.DateTime = value;
            }
        }

        internal DateTime EndDate
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

        #endregion



        #region Popup control helper methods and properties

        private WeeksDayMask GetStateMonths()
        {
            WeeksDayMask wd = WeeksDayMask.Empty;
            for (int i = 0; i < _daysList.Count; i++)
            {
                if (checkedListBoxControl1.GetItemChecked (i))
                {
                    DaysHelper.AddDay (ref wd,_daysList[i].DayMask);
                }
            }
            return wd;
        }
        private void SetStateMonths(WeeksDayMask wd)
        {
            for (int i = 0; i < _daysList.Count; i++)
            {
                checkedListBoxControl1.SetItemChecked(i, DaysHelper.CheckDay(wd, _daysList[i].DayMask));
                //checkedListBoxControl1.Items[i].CheckState = DaysHelper.CheckDay(wd, _daysList[i].DayMask) ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void SetDoubleControlState(LGDoubleWMItemView item)
        {
            Debug.Assert(item != null);

            DoubleValue = item.Count;
            LessThan = item.LessThan;
        }
        private void GetDoubleControlState(LGDoubleWMItemView item)
        {
            Debug.Assert(item != null);

            item.Count = DoubleValue;
            item.LessThan = LessThan ;
        }

        internal double DoubleValue
        {
            get
            {
                return Convert.ToDouble(spinEditValue.EditValue);
            }
            set
            {
                spinEditValue.EditValue = value;
            }
        }

        internal bool LessThan
        {
            get
            {
                return Convert.ToBoolean(radioGroup1.EditValue); 
            }
            set
            {
                radioGroup1.EditValue = value;
            }
        }


        #endregion

        public WorkingModel WModel
        {
            get
            {
                return (WorkingModel)Entity;
            }
            set
            {
                Entity = value;
                
            }
        }

        protected override void EntityChanged()
        {
            Bind();
        }

        void InitControl()
        {
            if (wnlist == null)
                BuildList();

            if (WModel == null)
                wnlist.State = ConditionTypes.Empty;
            else
            {
                wnlist.State = (ConditionTypes)WModel.ConditionType;
                wnlist.ValuesFromString(WModel.Data);
            }

            deBeginDate.Properties.MinValue = Contract.DateTimeSql.SmallDatetimeMin;
            deEndDate.Properties.MinValue = Contract.DateTimeSql.SmallDatetimeMin;

            deBeginDate.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;
            deEndDate.Properties.MaxValue = Contract.DateTimeSql.SmallDatetimeMax;

        }

        public override bool IsValid()
        {
            if (WorkingModelName.Length == 0)
            {

                ErrorMessage(GetLocalized("err_enter_model_name"));
                editModelName.Focus();
                return false;
            }

            ValidateDateRange();

            if (BeginDate > EndDate)
            {
                ErrorMessage(GetLocalized ("ErrorDateRange"));
                deEndDate.Focus();
                return false;
            }


            int cts = (int)wnlist.State;
            if (cts == 0)
            {
                ErrorMessage(GetLocalized("err_select_conditions"));
                gridControl.Focus();
                return false;
            }


            return base.IsValid();
        }

        private void ValidateDateRange()
        {
            if (BeginDate < Contract.DateTimeSql.SmallDatetimeMin)
                BeginDate = Contract.DateTimeSql.SmallDatetimeMin ;

            if (EndDate > Contract.DateTimeSql.SmallDatetimeMax)
                EndDate = Contract.DateTimeSql.SmallDatetimeMax;

        }
        public override void Bind()
        {
            base.Bind();

            InitControl();

            WorkingModelName = WModel.Name;
            WorkingModelMessage = WModel.Message;
            FixedAmount = WModel.AddValue;
            MultiplyFactor = WModel.MultiplyValue;
            IsAdditionalCharge = WModel.AddCharges;
            BeginDate = WModel.BeginTime;
            EndDate = WModel.EndTime;
            chk_UseInRecording.Checked = WModel.UseInRecording; 
            if (WModel.IsNew)
            {
                BeginDate = DateTime.Today;
                EndDate = Contract.DateTimeSql.SmallDatetimeMax;
            }
            ValidateDateRange();

            if (!WModel.IsNew)
            {
                gridView.OptionsBehavior.Editable = false;
                deBeginDate.Properties.ReadOnly = true;
                editWorkingTimeFactor.Properties.ReadOnly = true;
                spinEditFixedAmount.Properties.ReadOnly = true;
                checkEdit_ApplyAdditionalCharge.Properties.ReadOnly = true;
                chk_UseInRecording.Properties.ReadOnly = true;
            }


        }

        public bool IsModified()
        {
            Debug.Assert(WModel != null);

            if (WModel.IsNew) return true;

            return (WModel.Message != WorkingModelMessage) ||
                (WModel.MultiplyValue != MultiplyFactor) ||
                (WModel.AddValue != FixedAmount) ||
                (WModel.AddCharges != IsAdditionalCharge) ||
                (WModel.Name != WorkingModelName) ||
                (WModel.BeginTime != BeginDate) ||
                (WModel.EndTime != EndDate) ||
                (WModel.ConditionType != (int)wnlist.State ) ||
                (WModel.Data != wnlist.ValuesToString ()||
                (WModel.UseInRecording != chk_UseInRecording.Checked));
        }
        public override bool Commit()
        {
            Debug.Assert(WModel != null);

            if (IsValid())
            {
                if (IsModified())
                {
                    WModel.ConditionType = (int)wnlist.State;
                    WModel.Data = wnlist.ValuesToString();
                    WModel.Name = WorkingModelName;
                    WModel.Message = WorkingModelMessage;
                    WModel.AddValue = FixedAmount;
                    WModel.MultiplyValue = MultiplyFactor;
                    WModel.AddCharges = IsAdditionalCharge;
                    WModel.BeginTime = BeginDate;
                    WModel.EndTime = EndDate;
                    WModel.LanguageID = Baumax.Contract.SharedConsts.NeutralLangId;
                    WModel.UseInRecording = chk_UseInRecording.Checked;
                    try
                    {
                        if (WModel.IsNew)
                        {
                            WorkingModel wm = ClientEnvironment.WorkingModelService.Save(WModel);
                            WModel.ID = wm.ID;
                        }
                        else
                            ClientEnvironment.WorkingModelService.SaveOrUpdate(WModel);

                        Modified = true;
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("CantSaveWorkingModel"));
                        return false;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return false;
                    }
                }

                return base.Commit();
            }
            else return false;
        }
        void BuildDaysList()
        {
            _daysList = new DaysList();

            checkedListBoxControl1.DataSource = _daysList;
        }
        
        private void gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView.FocusedColumn == gridColumn_WMConditionValue)
            {

                BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);
                if (item == null)
                {
                    e.Cancel = true;
                    return;
                }

                if (ConditionHelper.IsEmptyCondition(item.Type) || !item.Checked)
                {
                    e.Cancel = true;
                    return;
                }
            }

        }

        private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(e.RowHandle);
            if (item == null) return;
            
            if (e.Column == gridColumn_WMConditionValue)
            {
                if ((item.Type & ConditionTypes.TimeBetweenPreviousDayWorkingTime) != ConditionTypes.Empty)
                {
                    e.RepositoryItem = repositoryItemSpinEditBetweenDay;
                    return;
                }
                if ((item.Type & ConditionTypes.DurationOfWorkingDay) != ConditionTypes.Empty)
                {
                    e.RepositoryItem = repositoryItemSpinEditDurationOfWorkingDays;
                    return;
                }


                if (ConditionHelper.IsSpecialDaysCondition(item.Type)) e.RepositoryItem = repositoryItemPopupContainerEdit1;
                else if (ConditionHelper.IsTimesCondition(item.Type)) e.RepositoryItem = repositoryItemTextEdit1;
                else if (ConditionHelper.IsEveryItemCondition(item.Type)) e.RepositoryItem = repositoryItemPopupContainerEditEveryItem;
                else if (ConditionHelper.IsEmptyCondition(item.Type)) e.RepositoryItem = null;
                else if (ConditionHelper.IsLGDoubleCondition(item.Type)) e.RepositoryItem = repositoryItemPopupContainerEdit2;
                else if (ConditionHelper.IsIntegerCondition(item.Type)) e.RepositoryItem = repositoryItemSpinEdit1;
                else if (ConditionHelper.IsInteger2Condition(item.Type)) e.RepositoryItem = repositoryItemSpinEditSaldo;
                else if (item.Type == ConditionTypes.WorkingOnSaturdayOrSunday) e.RepositoryItem = repositoryItemCountSaturdayOrSunday;
                else if (item.Type == ConditionTypes.WorkingOnSunday) e.RepositoryItem = repositoryItemCountSunday;
                else if (item.Type == ConditionTypes.SaldoOnCertainWeeks) e.RepositoryItem = repositoryItemPopupContainerEditSaldoEqualValueonCertainWeeks;//repositoryItemTextEditSalsoZeroOnCertainWeeks;
                else e.RepositoryItem = repositoryItemSpinEditBetweenDay;
            }
        }

        private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(e.RowHandle);
            if (item == null) return;
            if (e.IsGetData)
            {
                e.Value = item.DisplayString;
            }
            else
            {
                item.Value = e.Value;
            }

        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(e.RowHandle);
            if (item == null) return;

            if (item.Checked)
            {
                e.Appearance.BackColor = Color.GreenYellow;
            }
            
        }

        private void repositoryItemPopupContainerEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);

            if (item != null && (item is SpecialDayWMItemView))
            {
                SpecialDayWMItemView itemDays = (item as SpecialDayWMItemView);
                SetStateMonths(itemDays.DayMasks);
            }
        }

        private void repositoryItemPopupContainerEdit1_CloseUp(object sender, CloseUpEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);

            if (item != null && (item is SpecialDayWMItemView))
            {
                SpecialDayWMItemView itemDays = (item as SpecialDayWMItemView);
                itemDays.DayMasks = GetStateMonths();
            }
        }

        private void repositoryItemPopupContainerEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);

            if (item != null && (item is LGDoubleWMItemView))
            {
                LGDoubleWMItemView itemWm = (item as LGDoubleWMItemView);
                SetDoubleControlState(itemWm);
            }
        }

        private void repositoryItemPopupContainerEdit2_CloseUp(object sender, CloseUpEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);

            if (item != null && (item is LGDoubleWMItemView))
            {
                LGDoubleWMItemView itemWm = (item as LGDoubleWMItemView);
                GetDoubleControlState(itemWm);
                gridView.RefreshData();
            }
        }

        private void deBeginDate_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void repositoryItemPopupContainerEditEveryItem_QueryPopUp(object sender, CancelEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);

            if (item != null && (item is EveryItemWMItemView))
            {
                EveryItemWMItemView itemWm = (item as EveryItemWMItemView);
                SetEveryItemControlState(itemWm);
            }
        }

        private void SetEveryItemControlState(EveryItemWMItemView itemWm)
        {
            checkEditEveryWeek.Checked = (itemWm.EveryItems & EveryItemEnum.EveryWeek) != EveryItemEnum.Empty;
            if (checkEditEveryWeek.Checked)
            {
                seCountWeek.Value = itemWm.CountWeek;
            }
            checkEditEveryMonth.Checked = (itemWm.EveryItems & EveryItemEnum.EveryMonth) != EveryItemEnum.Empty;

            if (checkEditEveryWeek.Checked)
            {
                seCountMonth.Value = itemWm.CountMonth;
            }

            checkEditEveryYear.Checked = (itemWm.EveryItems & EveryItemEnum.EveryYear) != EveryItemEnum.Empty;

        }
        private void GetEveryItemControlState(EveryItemWMItemView itemWm)
        {
            itemWm.EveryItems = EveryItemEnum.Empty;
            if (checkEditEveryWeek.Checked)
            {
                itemWm.EveryItems |= EveryItemEnum.EveryWeek;
                itemWm.CountWeek = Convert.ToInt32(seCountWeek.Value );
            }
            if (checkEditEveryMonth.Checked)
            {
                itemWm.EveryItems |= EveryItemEnum.EveryMonth;
                itemWm.CountMonth = Convert.ToInt32(seCountMonth.Value);
            }
            if (checkEditEveryYear.Checked)
                itemWm.EveryItems |= EveryItemEnum.EveryYear;

        }

        

        private void repositoryItemPopupContainerEditEveryItem_CloseUp(object sender, CloseUpEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);

            if (item != null && (item is EveryItemWMItemView))
            {
                EveryItemWMItemView itemWm = (item as EveryItemWMItemView);
                GetEveryItemControlState(itemWm);
                gridView.RefreshData();
            }
        }

        private void repositoryItemTextEdit1_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"(0?\d|1\d|2[0-3])\:[0-5]\d-(0?\d|1\d|2[0-3])\:[0-5]\d");
            TextEdit te = (sender as TextEdit );
            string s = te.Text;
            if (!String.IsNullOrEmpty(s))
            {
                if (reg.IsMatch(s))
                {
                    short[] result = Baumax.ClientUI.FormEntities.EntityStore.BaumaxTimeHelper.GetTimeRangeFromString(s);
                    if (result[1] <= result[0])
                    {
                        te.ErrorText = GetLocalized("ErrorBeginTimeEndTime");// "¬рем€ окончание работы магазина меньше времени начала работы магазина";
                        e.Cancel = true;
                    }
                }
                else
                {
                    te.ErrorText = GetLocalized("InvalidValue");// "Ќекорректное значение времени";
                    e.Cancel = true;
                }

                if (!e.Cancel)
                {
                    te.ErrorText = String.Empty;
                }
            }
        }

        private void checkEditEveryWeek_CheckedChanged(object sender, EventArgs e)
        {
            seCountWeek.Enabled = checkEditEveryWeek.Checked;
        }

        private void checkEditEveryMonth_CheckedChanged(object sender, EventArgs e)
        {
            seCountMonth.Enabled = checkEditEveryMonth.Checked;
        }

        private void spinEditValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                //repositoryItemPopupContainerEdit2.
            }
        }

        private void deEndDate_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
        }

        private void deEndDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (deEndDate.DateTime == DateTime.MinValue)
                deEndDate.DateTime = Contract.DateTimeSql.SmallDatetimeMax;
            if (WModel != null && WModel.IsNew)
            {
                if (deEndDate.DateTime < DateTime.Today)
                    deEndDate.DateTime = DateTime.Today;
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);
            if (item != null)
                item.Checked = (bool)gridView.EditingValue;
        }

        private void deBeginDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (WModel != null && WModel.IsNew)
            {
                if (deBeginDate.DateTime < DateTime.Today)
                    deBeginDate.DateTime = DateTime.Today;
            }
        }

        void SetWeeksData(BaseWMItemView item)
        {
            SaldoZeroOnCertainWeekWMItemView condition = item as SaldoZeroOnCertainWeekWMItemView;

            if (condition != null)
            {
                radioGroupOperatorWeeks.SelectedIndex = condition.Compare;
                spinEditHours.Value = condition.Hours;
                textEditWeeks.Text = condition.ArrayToString();
            }
            else
            {
                spinEditHours.Value = 0m;
                textEditWeeks.Text = String.Empty;
            }
        }

        public void UpdateWeekData()
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);
            SaldoZeroOnCertainWeekWMItemView condition = item as SaldoZeroOnCertainWeekWMItemView;
            if (condition != null)
            {
                condition.Compare = radioGroupOperatorWeeks.SelectedIndex;
                condition.Hours = Convert.ToInt32(spinEditHours.Value);
                condition.AssignWeekNumbers(textEditWeeks.Text);
            }
        }

        private void repositoryItemPopupContainerEditSaldoEqualValueonCertainWeeks_QueryPopUp(object sender, CancelEventArgs e)
        {
            BaseWMItemView item = (BaseWMItemView)gridView.GetRow(gridView.FocusedRowHandle);
           
            if (item != null)
            {
                SetWeeksData(item);
               
            }
        }

        private void repositoryItemPopupContainerEditSaldoEqualValueonCertainWeeks_CloseUp(object sender, CloseUpEventArgs e)
        {
            UpdateWeekData();
        }

    }
}

