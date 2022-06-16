using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Baumax.ClientUI.Import;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using System.ComponentModel;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class UCEmployeeList : UCBaseEntity
    {
        private StoreViewList _listStores = null;
        private StoreShortList _listStoreShorts = null;
        private StoreWorldController _swController = null;
        private EmployeeContext _employeeContext = null;

        // acpro 118790
        private bool _EnabledEdit = true;

        public UCEmployeeList()
        {
            InitializeComponent();
            if (!IsDesignMode)
            {
                lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
                gridColumn_Country.GroupIndex = 0;
                gridColumn_Region.GroupIndex = 1;

                //
                AsOfDate = DateTime.Today;
                de_AsForDate.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
                de_AsForDate.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;

                gridColumn_ContractBeginTime.DisplayFormat.Format = new DateToStringFormatProvider();
                gridColumn_ContractEndTime.DisplayFormat.Format = new DateToStringFormatProvider();
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (!IsDesignMode)
            {
            }
        }

        public EmployeeContext Context
        {
            get { return _employeeContext; }
        }


        public bool EnabledEdit
        {
            get { return _EnabledEdit; }
            
        }

        public StoreViewList ListStores
        {
            get { return _listStores; }
            set { _listStores = value; }
        }

        public Store EntityStore
        {
            get { return (Store) Entity; }
            set { Entity = value; }
        }

        [Browsable(false)]
        public DateTime AsOfDate
        {
            get { return de_AsForDate.DateTime.Date; }
            set { de_AsForDate.DateTime = value; }
        }

        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                GenerateEmployeeList();
                // ACPRO #121486 - show Peronal ID or Personal Number, depending of store's country
                Domain.Country storeCountry = ListStores.GetCountry(ListStores.GetById(EntityStore.ID).CountryID);
                gridColumn_PersonID.Visible = (storeCountry.PersShowMode == PersShowModeType.PersonalID ||
                                               storeCountry.PersShowMode == PersShowModeType.All);
                gridColumn_PersNumber.Visible = (storeCountry.PersShowMode == PersShowModeType.PersonalNumber ||
                                                 storeCountry.PersShowMode == PersShowModeType.All);
            }
            base.EntityChanged();
        }

        private void InitStoreList()
        {
            _swController = new StoreWorldController();

            ListStores = new StoreViewList();
            ListStores.Init();
            ListStores.LoadAll();

            _listStoreShorts = new StoreShortList().ReInit();

            lookUpEditStores.Properties.DataSource = ListStores;

            lookUpEditStores.Properties.View.ExpandAllGroups();
            if ((ListStores != null) && (ListStores.Count == 1))
            {
                lookUpEditStores.EditValue = ListStores[0].ID;
            }

            List<Domain.World> lstWorlds = ClientEnvironment.WorldService.FindAll();
            repositoryItemLookUpWorlds.DataSource = lstWorlds;
            repositoryItemLookUpStores.DataSource = _listStoreShorts;
        }

        private void LoadStoreWorldList()
        {
            /*if (EntityStore != null)
            {
                if (!_swController.IsExistsStoreWorld(EntityStore.ID))
                {
                    _swController.LoadByRegionId(EntityStore.RegionID);
                }

                List<StoreToWorld> lst = _swController.GetListByStoreId(EntityStore.ID);
                repositoryItemLookUpWorlds.DataSource = lst;
            }*/
        }

        private void GenerateEmployeeList()
        {
            if (Context == null)
            {
                _employeeContext = new EmployeeContext();
            }

            bandedGridViewEmployees.BeginDataUpdate();
            try
            {
                _employeeContext.SetCriteria(EntityStore, AsOfDate);

                LoadStoreWorldList();

                if (gridControlEmployee.DataSource != Context.EmployeeList)
                {
                    gridControlEmployee.DataSource = Context.EmployeeList;
                }
            }
            finally
            {
                bandedGridViewEmployees.EndDataUpdate();
            }

            FireChangeEmployeeList();
        }

        public void Init()
        {
            InitStoreList();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsDesignMode)
            {
                lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
                if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                    (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                     (long) UserRoleId.Controlling))
                {
                    gridColumn_NewHolidays.OptionsColumn.AllowEdit =
                        gridColumn_OldHolidays.OptionsColumn.AllowEdit =
                        gridColumn_EmployeeBalanceHours.OptionsColumn.AllowEdit = false;
                    gridColumn_NewHolidays.OptionsColumn.ReadOnly =
                        gridColumn_OldHolidays.OptionsColumn.ReadOnly =
                        gridColumn_EmployeeBalanceHours.OptionsColumn.ReadOnly = true;
                    gc_AllIn.OptionsColumn.ReadOnly = true;
                    gc_AllIn.OptionsColumn.AllowEdit = false;
                }

                ri_LookupHwgr.DataSource = ClientEnvironment.HWGRService.FindAll();
            }
        }

        private void UCEmployeeList_Resize(object sender, EventArgs e)
        {
            lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
        }

        private void lookUpEditStores_Popup(object sender, EventArgs e)
        {
            lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
        }

        private void lookUpEditStores_EditValueChanged(object sender, EventArgs e)
        {
            Store store = null;
            if (lookUpEditStores.EditValue != null)
            {
                long storeid = Convert.ToInt64(lookUpEditStores.EditValue);

                StoreView sw = ListStores.GetById(storeid);

                if (sw != null)
                {
                    store = sw.Entity;
                    //Domain.Country country = _listStores.GetCountry(sw.CountryID);

                    if (sw.CountryID == ClientEnvironment.CountryService.AustriaCountryID)
                    {
                        _EnabledEdit = false;
                    }
                    else
                    {
                        _EnabledEdit = true;
                    }
                    //if (sw.Co
                }
            }

            EntityStore = store;
        }

        public void NewExternalEmployee()
        {
            if (EntityStore != null)
            {
                using (FormExternalEmployee formEmployee = new FormExternalEmployee())
                {
                    Domain.Employee newEmployee = ClientEnvironment.EmployeeService.CreateEntity();
                    newEmployee.ContractBegin = DateTime.Today;
                    newEmployee.ContractEnd = DateTimeSql.SmallDatetimeMax;

                    newEmployee.MainStoreID = EntityStore.ID;

                    formEmployee.Entity = newEmployee;

                    formEmployee.FilterDate = Context.CurrentAsOfDate;

                    if (formEmployee.ShowDialog() == DialogResult.OK)
                    {
                        Context.EmployeeList.Add((Domain.Employee) formEmployee.Entity);
                        bandedGridViewEmployees.RefreshData();
                        FireChangeEmployeeList();
                    }
                }
            }
        }

        public void EditExternalEmployee()
        {
            if (EntityStore != null && FocusedEntity != null && !FocusedEntity.Import)
            {
                Domain.Employee empl = FocusedEntity;

                using (FormExternalEmployee formEmployee = new FormExternalEmployee())
                {
                    formEmployee.FilterDate = Context.CurrentAsOfDate;
                    formEmployee.Entity = empl;

                    if (formEmployee.ShowDialog() == DialogResult.OK)
                    {
                        Context.EmployeeList.ResetItemById(empl.ID);
                    }
                }
            }
        }

        public void DeleteExternalEmployee()
        {
            if (EntityStore != null && FocusedEntity != null && !FocusedEntity.Import)
            {
                Domain.Employee empl = FocusedEntity;

                if (QuestionMessageYes(GetLocalized("QuestionDeleteExtEmployee")))
                {
                    try
                    {
                        ClientEnvironment.EmployeeService.DeleteByID(empl.ID);
                        Context.EmployeeList.RemoveEntityById(empl.ID);
                        FireChangeEmployeeList();
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("ErrorCantDeleteExtEmployee"));
                        return;
                    }
                }
            }
        }
        public void AssignEmployeeToHWGR()
        {
            if (FocusedEntity != null)
            {
                using (FormAssignEmployeeToHwgr form = new FormAssignEmployeeToHwgr())
                {
                    form.Entity = FocusedEntity;

                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        Context.EmployeeList.ResetItemById(FocusedEntity.ID);
                        //RefreshGrid();
                    }
                }
            }
        }
        public void AssignExtEmployeeToEmployee()
        {
            // acpro item: 119084(11)
            FormMergeTwoEmployees mergeForm = null;
            int nmbrMerged = 0;
            try
            {
                DateTime today = DateTime.Today;
                Dictionary<string, EmployeeListToMerge> dict = new Dictionary<string, EmployeeListToMerge>();
                // add external employees
                foreach (Domain.Employee empl in Context.EmployeeList)
                {
                    string s = String.Format("{0} {1}", empl.FirstName.ToUpper(), empl.LastName.ToUpper());
                    // acpro item: 119084(13,14)
                    if ((!empl.Import) && (empl.ContractBegin <= today) && (empl.ContractEnd >= today))
                    {
                        if (!dict.ContainsKey(s))
                        {
                            dict[s] = new EmployeeListToMerge();
                        }
                        dict[s].ExtList.Add(empl);
                    }
                }
                // add internal if needed
                foreach (Domain.Employee empl in Context.EmployeeList)
                {
                    string s = String.Format("{0} {1}", empl.FirstName.ToUpper(), empl.LastName.ToUpper());
                    // acpro item: 119084(13,14)
                    if (dict.ContainsKey(s) && empl.Import && (empl.ContractBegin <= today) && (empl.ContractEnd >= today))
                    {
                        dict[s].IntList.Add(empl);
                    }
                }

                if (dict.Count != 0)
                {
                    foreach (KeyValuePair<string, EmployeeListToMerge> pair in dict)
                    {
                        if ((pair.Value.IntList != null) &&
                            (pair.Value.ExtList != null) &&
                            (pair.Value.IntList.Count > 0) &&
                            (pair.Value.ExtList.Count > 0)
                            )
                        {
                            if (mergeForm == null)
                            {
                                mergeForm = new FormMergeTwoEmployees();
                            }
                            mergeForm.InternalEmployeeList = pair.Value.IntList;
                            mergeForm.ExternalEmployeeList = pair.Value.ExtList;

                            if (mergeForm.ShowDialog() == DialogResult.OK)
                            {
                                nmbrMerged++;
                                Domain.Employee extEmp = mergeForm.CurExternalEmployee;
                                Domain.Employee intEmp = mergeForm.CurInternalEmployee;
                                if (extEmp != null)
                                {
                                    Context.EmployeeList.RemoveEntityById(extEmp.ID);
                                }
                                if (intEmp != null)
                                {
                                    Context.EmployeeList.ResetItemById(intEmp.ID);
                                }
                            }
                            mergeForm.ResetBind();
                        }
                    }
                }
            }
            finally
            {
                if (mergeForm != null)
                {
                    mergeForm.Dispose();
                }
            }
            if (nmbrMerged > 0)
            {
                _employeeContext = null;
                GenerateEmployeeList();
            }
        }

        public void DelegateToStore()
        {
            if (EntityStore != null && FocusedEntity != null)
            {
                using (FormAssignEmployeeToStore form = new FormAssignEmployeeToStore())
                {
                    form.Entity = FocusedEntity;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Domain.Employee empl =
                            ClientEnvironment.EmployeeService.GetEmployeeByID(FocusedEntity.ID, DateTime.Today);
                        if (empl != null)
                        {
                            Context.EmployeeList.SetEntity(empl);
                        }
                    }
                }
            }
        }

        public void ImportEmployees()
        {
            if (ImportUI.ImportEmployees())
            {
                GenerateEmployeeList();
            }
        }

        public void EnterLongTimeAbsence()
        {
            if (EntityStore != null && FocusedEntity != null)
            {
                EmployeeLongTimeAbsence newAbsence = ClientEnvironment.EmployeeLongTimeAbsenceService.CreateEntity();
                long focusedEmployeeID = FocusedEntity.ID;
                newAbsence.EmployeeID = focusedEmployeeID;
                newAbsence.EmployeeFullName = FocusedEntity.FullName;

                Context.EmployeeAbsence = newAbsence;

                using (FormEmployeeLongTimeAbsence form = new FormEmployeeLongTimeAbsence())
                {
                    form.Entity = Context;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Context.EmployeeList.ResetItemById(focusedEmployeeID);
                    }
                }
                /*
                using (Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning.FormEmployeeLongTime form = new Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning.FormEmployeeLongTime())
                {
                    form.Bind(Context.EmployeeList, ClientEnvironment.LongTimeAbsenceService.FindAllByCountry(Context.CurrentCountryID), true);
                    form.Entity = newAbsence;
                    if (form.ShowDialog() == DialogResult.OK)
                        Context.EmployeeList.ResetItemById(focusedEmployeeID);
                }*/
            }
        }

        public List<StoreToWorld> GetStoreWorldList(long storeid)
        {
            List<StoreToWorld> lst = _swController.GetListByStoreId(storeid);

            if (lst.Count == 0)
            {
                lst = ClientEnvironment.StoreToWorldService.FindAllForStore(storeid);
                _swController.AddList(lst);
            }
            return lst;
        }

        public void AssignToWorld()
        {
            if (EntityStore != null && FocusedEntity != null)
            {
                List<StoreToWorld> lst = GetStoreWorldList(EntityStore.ID);


                using (FormAssignEmployeeToWorld assignform = new FormAssignEmployeeToWorld())
                {
                    Domain.Employee empl = FocusedEntity;

                    Context.CurrentEmployee = empl;

                    EmployeeRelation relation = new EmployeeRelation();

                    relation.EmployeeID = empl.ID;
                    relation.EmployeeName = empl.FullName;
                    relation.StoreID = Context.CurrentStore.ID;
                    relation.WorldID = empl.WorldID;
                    relation.BeginTime = DateTime.Today;
                    relation.EndTime = empl.ContractEnd;

                    if (IsDeligatedEmployee && empl.EndTime.HasValue)
                    {
                        relation.EndTime = empl.EndTime.Value;
                    }

                    Context.CurrentRelation = relation;

                    assignform.SetWorldList(_swController.GetListByStoreId(EntityStore.ID));

                    assignform.Entity = Context;

                    if (assignform.ShowDialog() == DialogResult.OK)
                    {
                        Domain.Employee employee =
                            ClientEnvironment.EmployeeService.GetEmployeeByID(empl.ID, DateTime.Today);
                        if (employee != null)
                        {
                            Context.EmployeeList.SetEntity(employee);
                        }
                    }
                }
            }
        }

        public void ImportEmployee()
        {
            if (ImportUI.ImportEmployees())
            {
                bandedGridViewEmployees.BeginDataUpdate();
                try
                {
                    GenerateEmployeeList();
                }
                finally
                {
                    bandedGridViewEmployees.EndDataUpdate();
                }
            }
        }

        public void RefreshGrid()
        {
            GenerateEmployeeList();
        }

        #region State of list and employee

        private Domain.Employee GetEntityByRowHandle(int rowHandle)
        {
            Domain.Employee entity = null;
            if (bandedGridViewEmployees.IsDataRow(rowHandle))
            {
                entity = (Domain.Employee) bandedGridViewEmployees.GetRow(rowHandle);
            }
            return entity;
        }

        public Domain.Employee FocusedEntity
        {
            get { return GetEntityByRowHandle(bandedGridViewEmployees.FocusedRowHandle); }
        }

        public bool IsNormalEmployee
        {
            get
            {
                Domain.Employee empl = FocusedEntity;
                bool result = true;
                if (empl != null)
                {
                    result = empl.Import;
                }
                return result;
            }
        }

        public bool IsDeligatedEmployee
        {
            get
            {
                Domain.Employee employee = FocusedEntity;
                return
                    (employee != null && employee.MainStoreID != employee.StoreID &&
                     employee.MainStoreID != Context.CurrentStore.ID);
            }
        }

        public bool IsFocusedEmployeeContractExpired
        {
            get { return IsContractExpired(FocusedEntity, DateTime.Today); }
        }

        public bool IsContractExpired(Domain.Employee employee, DateTime asForDate)
        {
            if (employee != null)
            {
                return !DateTimeHelper.Between(asForDate, employee.ContractBegin, employee.ContractEnd);
            }
            return true;
            //return (employee != null && employee.ContractEnd.Date < asForDate.Date);
        }

        public override bool EditEnabled
        {
            get
            {
                if (EntityStore == null || FocusedEntity == null)
                {
                    return false;
                }
                if (FocusedEntity != null)
                {
                    return !IsNormalEmployee;
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool AddEnabled
        {
            get
            {
                if (EntityStore != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool DeleteEnabled
        {
            get
            {
                if (EntityStore == null || FocusedEntity == null)
                {
                    return false;
                }

                return !IsNormalEmployee;
            }
        }

        public delegate void ChangeEmployeeListState();

        public event ChangeEmployeeListState OnChangeListState = null;

        private void FireChangeEmployeeList()
        {
            if (Context != null)
            {
                Context.CurrentEmployee = FocusedEntity;
            }
            if (OnChangeListState != null)
            {
                OnChangeListState();
            }
        }

        #endregion

        private void gridViewEmployee_RowStyle(object sender, RowStyleEventArgs e)
        {
            Domain.Employee empl = GetEntityByRowHandle(e.RowHandle);

            if (empl != null)
            {
                if (!empl.Import) //external employee
                {
                    e.Appearance.BackColor = Color.Aqua;
                }
                if (IsContractExpired(empl, AsOfDate))
                {
                    e.Appearance.BackColor = Color.Gray;
                }
                else if (empl.StoreID != empl.MainStoreID)
                {
                    if (empl.StoreID == Context.CurrentStore.ID) // employee from another store
                    {
                        e.Appearance.BackColor = Color.Coral;
                    }
                    else if (empl.MainStoreID == Context.CurrentStore.ID) // employee work on another store
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
                else if (empl.LongTimeAbsenceExist)
                {
                    e.Appearance.BackColor = Color.Goldenrod;
                }
            }
        }

        private void gridViewEmployee_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            FireChangeEmployeeList();
        }

        private void gridViewEmployee_RowCountChanged(object sender, EventArgs e)
        {
            FireChangeEmployeeList();
        }

        private void gridViewEmployee_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!EnabledEdit) return;

            if (e.Column == gridColumn_NewHolidays ||
                e.Column == gridColumn_OldHolidays ||
                e.Column == gridColumn_EmployeeBalanceHours ||
                e.Column == gc_AllIn)
            {
                Domain.Employee empl = GetEntityByRowHandle(e.RowHandle);

                if (empl != null)
                {
                    if (e.Column == gridColumn_NewHolidays || e.Column == gridColumn_OldHolidays)
                    {
                        //ClientEnvironment.EmployeeService.SaveEmployeeHolidays(empl.ID, empl.OldHolidays,
                        //                                                       empl.NewHolidays, null, null, null);

                        EmployeeHolidaysInfo new_info = new EmployeeHolidaysInfo(empl.ID, (short)DateTimeHelper.GetYearByDate(AsOfDate));
                        new_info.FillFromEmployee(empl);
                        

                        new_info = ClientEnvironment.EmployeeService.SaveEmployeeHolidays(new_info);// SaveEmployeeHolidays(empl.ID, empl.OldHolidays,
                                                       //empl.NewHolidays, null, null, null);

                        if (new_info != null)
                        {
                            new_info.FillEmployee(empl);
                            //empl.AvailableHolidays = empl.OldHolidays + empl.NewHolidays;

                            Context.EmployeeList.ResetItemById(empl.ID);
                        }
                    }
                    else if (e.Column == gridColumn_EmployeeBalanceHours)
                    {
                        ClientEnvironment.EmployeeService.SaveEmployeeSaldo(empl.ID, empl.BalanceHours*60);
                    }
                    else if (e.Column == gc_AllIn)
                    {
                        if (Context.CurrentAsOfDate < DateTime.Today)
                        {
                            ErrorMessage(GetLocalized("ErrorChangingAllInInPast"));
                            empl.AllIn = !empl.AllIn;
                            Context.EmployeeList.ResetItemById(empl.ID);
                            return;
                        }

                        if (QuestionMessageYes(GetLocalized("QuestionChangeAllIn")))
                        {
                            ClientEnvironment.EmployeeAllInService.InsertAllIn(empl.ID, Context.CurrentAsOfDate,
                                                                               empl.AllIn);
                        }
                        else
                        {
                            empl.AllIn = !empl.AllIn;
                            Context.EmployeeList.ResetItemById(empl.ID);
                        }
                    }

                    //ClientEnvironment.EmployeeService.SaveOrUpdate(empl);
                }
            }
        }

        private void de_AsForDate_EditValueChanged(object sender, EventArgs e)
        {
            if (_employeeContext != null && AsOfDate != _employeeContext.CurrentAsOfDate)
            {
                GenerateEmployeeList();
            }
        }

        #region test format providers
        private class DateToStringFormatProvider : ICustomFormatter, IFormatProvider
        {
            public object GetFormat(Type type)
            {
                if (type == typeof(ICustomFormatter))
                {
                    return this;
                }
                return null;
            }

            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                DateTime value = Convert.ToDateTime(arg);

                if (value.ToBinary() == (long)0)
                    return String.Empty;
                else
                    return value.ToShortDateString();
            }
        }
        //private class IntToTimeFormatProvider : ICustomFormatter, IFormatProvider
        //{
        //    public object GetFormat(Type type)
        //    {
        //        if (type == typeof (ICustomFormatter))
        //        {
        //            return this;
        //        }
        //        return null;
        //    }

        //    public string Format(string format, object arg, IFormatProvider formatProvider)
        //    {
        //        int value = Convert.ToInt32(arg);

        //        int hour = value/60;
        //        int minute = value%60;

        //        return String.Format("{0:D2}:{1:D2}", hour, minute);
        //    }
        //}

        //private class IntToDblFormatProvider : ICustomFormatter, IFormatProvider
        //{
        //    public object GetFormat(Type type)
        //    {
        //        if (type == typeof (ICustomFormatter))
        //        {
        //            return this;
        //        }
        //        return null;
        //    }

        //    public string Format(string format, object arg, IFormatProvider formatProvider)
        //    {
        //        int value = Convert.ToInt32(arg);

        //        double hour = 60;

        //        return String.Format("{0:F2}", Math.Round(value / hour, 2));
        //    }
        //}
        #endregion
        private void repositoryItemSpinEditBalanceHours_FormatEditValue(object sender,
                                                                        DevExpress.XtraEditors.Controls.
                                                                            ConvertEditValueEventArgs e)
        {
            int value = Convert.ToInt32(e.Value);
            double hour = 60;
            double d_value = Math.Round(value/hour, 2);

            e.Value = d_value;
            e.Handled = true;
        }

        private void bandedGridViewEmployees_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !EnabledEdit;
        }

        private void gridControlEmployee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //// #acpro 121090 
            //if (Context != null)
            //{
            //    if (Context.CurrentAsOfDate < DateTime.Today) return; // it's not possible change in past
            //    // for austria personal not possible change value only by import
            //    if (Context.CurrentCountryID == ClientEnvironment.CountryService.AustriaCountryID) return;
            //    // controlling - only read only
            //    long? userrole = ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID;
            //    if (userrole.HasValue && (userrole.Value == (long)UserRoleId.Controlling)) return;

            //    BandedGridHitInfo info = bandedGridViewEmployees.CalcHitInfo(e.Location);
            //    if (info.InRowCell && info.Column != null && info.Column == gc_AllIn)
            //    {
            //        Domain.Employee employee = GetEntityByRowHandle(info.RowHandle);

            //        if (employee == null) return;


            //        ClientEnvironment.EmployeeAllInService.InsertAllIn(employee.ID, Context.CurrentAsOfDate, !employee.AllIn);

            //        employee.AllIn = !employee.AllIn;

            //        Context.EmployeeList.ResetItemById(employee.ID);
            //    }
            //}
        }

        private void bandedGridViewEmployees_ValidatingEditor(object sender,
                                                              DevExpress.XtraEditors.Controls.
                                                                  BaseContainerValidateEditorEventArgs e)
        {
            //// #acpro 121090 
            //if (bandedGridViewEmployees.FocusedColumn == gc_AllIn)
            //{

            //    if (QuestionMessageYes(GetLocalized("QuestionChangeAllIn")))
            //        e.Valid = true;
            //    else
            //    {
            //        e.Valid = true;
            //    }

            //}
        }
    }


    // acpro item: 119084(11)
    internal class EmployeeListToMerge
    {
        private List<Domain.Employee> intList;
        private List<Domain.Employee> extList;

        public List<Domain.Employee> IntList
        {
            get
            {
                if (intList == null)
                {
                    intList = new List<Domain.Employee>();
                }
                return intList;
            }
            set { intList = value; }
        }

        public List<Domain.Employee> ExtList
        {
            get
            {
                if (extList == null)
                {
                    extList = new List<Domain.Employee>();
                }
                return extList;
            }
            set { extList = value; }
        }
    }
}