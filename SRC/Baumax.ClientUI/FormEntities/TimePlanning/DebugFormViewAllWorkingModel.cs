using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Contract.WorkingModelConditions;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class DebugFormViewAllWorkingModel : DevExpress.XtraEditors.XtraForm
    {
        public DebugFormViewAllWorkingModel()
        {
            InitializeComponent();
        }
        List<EmployeeWTItem> _listItems = new List<EmployeeWTItem>();

        public void FillGrid(IPlanningContext context, List<EmployeePlanningWeek> listEmployee)
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
                                if (wrapper != null)
                                {
                                    _listItems.Add(new EmployeeWTItem(
                                                                        week.EmployeeId,
                                                                        week.FullName,
                                                                        day.Date,
                                                                        wrapper.Model.Name,
                                                                        wrapper.Model.Message,
                                                                        model.AdditionalCharge,
                                                                        model.Hours
                                                                        ));
                                }
                            }
                        }
                    }
                }

            }

            gridControl.DataSource = _listItems;
        }


        public void FillGrid(IPlanningContext context, List<EmployeeWeek> listEmployee)
        {
            _listItems.Clear();
            gridControl.DataSource = null;

            if (listEmployee != null && listEmployee.Count > 0)
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
                                if (wrapper != null)
                                {
                                    _listItems.Add(new EmployeeWTItem(
                                                                        week.EmployeeId,
                                                                        week.FullName,
                                                                        day.Date,
                                                                        wrapper.Model.Name,
                                                                        wrapper.Model.Message,
                                                                        model.AdditionalCharge,
                                                                        model.Hours
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
            private bool _additionalcharges;

            public bool AdditionalCharges
            {
                get { return _additionalcharges; }
                set { _additionalcharges = value; }
            }
            private string _hours;

            public string Hours
            {
                get { return _hours; }
                set { _hours = value; }
            }


            public EmployeeWTItem(long emplid, string emplname, DateTime date, string modelname, string message, bool asaddhours, int hours)
            {
                EmployeeId = emplid;
                EmployeeName = emplname;
                Date = date.ToString("dd.MM.yyyy");
                WorkingModelName = modelname;
                Message = message;
                AdditionalCharges = asaddhours;
                Hours = TextParser.TimeToString(hours);
            }
        }
    }
}