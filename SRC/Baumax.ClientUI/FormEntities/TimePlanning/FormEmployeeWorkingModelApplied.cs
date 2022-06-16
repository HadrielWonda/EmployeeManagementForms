using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Contract;
using Baumax.Contract.WorkingModelConditions;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class FormEmployeeWorkingModelApplied : FormBaseEntity 
    {

        List<EmployeeWTItem> _listItems = new List<EmployeeWTItem>();
        public FormEmployeeWorkingModelApplied()
        {
            InitializeComponent();

            gridControl.DataSource = _listItems;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            // :-)
            if (!UCBaseEntity.IsDesignMode)
            {
                button_Cancel.Text = GetLocalized("Close");
            }
        }

        private static bool _AllowShow = true;
        private static FormEmployeeWorkingModelApplied _instance = null;
        public static bool AllowShow
        {
            get { return _AllowShow; }
            set 
            { 
                _AllowShow = value;
                if (!AllowShow && _instance != null)
                    _instance.Hide();
            }
        }

        public void ShowOrHide()
        {
            if (AllowShow)
            {
                if (_listItems.Count > 0)
                {
                    if (!Visible) Show(ClientEnvironment.MainForm);
                    //BringToFront();
                }
                else
                {
                    Hide();
                }
            }
            else
            {
                Hide();
            }
        }
        public static bool IsVisible
        {
            get
            {
                if (_instance != null) return _instance.Visible;
                else return false;
            }
        }
        public static void HideForm()
        {
            if (_instance != null)
                _instance.Hide();
        }

        public static void PlayEmployeeWeeks(IPlanningContext context, List<EmployeePlanningWeek> listEmployee)
        {
            if (_instance == null)
                _instance = new FormEmployeeWorkingModelApplied();
            _instance.PlayWorkingModel(context, listEmployee);
            _instance.ShowOrHide();
        }

        public static void PlayEmployeeWeeks(IPlanningContext context, List<EmployeeWeek> listEmployee)
        {
            if (_instance == null)
                _instance = new FormEmployeeWorkingModelApplied();
            _instance.PlayWorkingModel(context, listEmployee);
            _instance.ShowOrHide();
        }

        public void PlayWorkingModel(IPlanningContext context, List<EmployeePlanningWeek> listEmployee)
        {


            _listItems.Clear();
            gridControl.DataSource = null;
            if (listEmployee != null && listEmployee.Count > 0)
            {
                WorkingModelManager wmmanager = context.WorkingModels as WorkingModelManager;
                WorkingModelWrapper wrapper = null;
                foreach (EmployeePlanningWeek week in listEmployee)
                {
                    foreach (EmployeePlanningDay day in week.Days.Values)
                    {
                        if (day.WorkingModels != null)
                        {
                            foreach (EmployeePlanningWorkingModel model in day.WorkingModels)
                            {
                                wrapper = wmmanager[model.WorkingModelID];
                                if (wrapper != null && wrapper.IsContainMessage())
                                {
                                    _listItems.Add (new EmployeeWTItem (
                                                                        week.EmployeeId, 
                                                                        week.FullName, 
                                                                        day.Date, 
                                                                        wrapper.Model.Name,
                                                                        wrapper.Model.Message 
                                                                        ));
                                }
                            }
                        }
                    }
                }

            }

            gridControl.DataSource = _listItems;
        }

        public void PlayWorkingModel(IPlanningContext context, List<EmployeeWeek> listEmployee)
        {


            _listItems.Clear();
            gridControl.DataSource = null;
            if (context != null && listEmployee != null && listEmployee.Count > 0)
            {
                WorkingModelManagerNew wmmanager = context.WorkingModels as WorkingModelManagerNew;
                WorkingModelWrapperNew wrapper = null;
                foreach (EmployeeWeek week in listEmployee)
                {
                    foreach (EmployeeDay day in week.DaysList)
                    {
                        if (day.WorkingModels != null)
                        {
                            foreach (EmployeeWorkingModel model in day.WorkingModels)
                            {
                                wrapper = wmmanager[model.WorkingModelID];
                                if (wrapper != null && wrapper.IsContainMessage())
                                {
                                    _listItems.Add(new EmployeeWTItem(
                                                                        week.EmployeeId,
                                                                        week.FullName,
                                                                        day.Date,
                                                                        wrapper.Model.Name,
                                                                        wrapper.Model.Message
                                                                        ));
                                }
                            }
                        }
                    }
                }

            }

            gridControl.DataSource = _listItems;
        }



        class EmployeeWTItem
        {
            private long _EmployeeId;

            public long EmployeeId
            {
                get { return _EmployeeId; }
                set { _EmployeeId = value; }
            }
            private string _EmployeeName;

            public string EmployeeName
            {
                get { return _EmployeeName; }
                set { _EmployeeName = value; }
            }
            private string _Date;

            public string Date
            {
                get { return _Date; }
                set { _Date = value; }
            }
            private string _WorkingModelName;

            public string WorkingModelName
            {
                get { return _WorkingModelName; }
                set { _WorkingModelName = value; }
            }
            private string _Message;

            public string Message
            {
                get { return _Message; }
                set { _Message = value; }
            }


            public EmployeeWTItem(long emplid, string emplname, DateTime date, string modelname, string message)
            {
                EmployeeId = emplid;
                EmployeeName = emplname;
                Date = date.ToString("dd.MM.yyyy");
                WorkingModelName = modelname;
                Message = message;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            AllowShow = false;
            Hide();
        }
    }
}