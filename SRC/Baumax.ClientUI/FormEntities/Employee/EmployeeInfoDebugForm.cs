using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract.PlanningAndRecording;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Environment;
using Baumax.Domain;


namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class EmployeeInfoDebugForm : DevExpress.XtraEditors.XtraForm
    {
        public EmployeeInfoDebugForm()
        {
            InitializeComponent();
            gridColumn17.DisplayFormat.Format = 
            gridColumn18.DisplayFormat.Format = 
                gridColumn19.DisplayFormat.Format = 
                gridColumn20.DisplayFormat.Format = 
                gridColumn21.DisplayFormat.Format =
                gridColumn22.DisplayFormat.Format = new IntToTimeFormatProvider();

            gridColumn27.DisplayFormat.Format =
            gridColumn28.DisplayFormat.Format =
                gridColumn29.DisplayFormat.Format =
                gridColumn30.DisplayFormat.Format =
                gridColumn31.DisplayFormat.Format =
                gridColumn32.DisplayFormat.Format = new IntToTimeFormatProvider();



        }
        EmployeeDebugInfo _debuginfo = null;
        public void ShowInfo(long emplid)
        {
            LoadByEmployee(emplid);
            ShowDialog();
        }
        private void LoadByEmployee(long emplid)
        {
            _debuginfo = ClientEnvironment.EmployeeService.GetEmployeeDebugInfo(emplid);


            if (_debuginfo._relations != null)
            {
                foreach (EmployeeRelation rel in _debuginfo._relations)
                {
                    if (rel.WorldID.HasValue)
                        rel.WorldName = ClientEnvironment.WorldService.FindById(rel.WorldID.Value).Name;

                    rel.StoreName = ClientEnvironment.StoreService.FindById(rel.StoreID).Name;
                }
            }

            gridControlRelations.DataSource = _debuginfo._relations;
            gridControlContracts.DataSource = _debuginfo._contracts;
            gridControlAllIn.DataSource = _debuginfo._allins;
            gridControlAbsences.DataSource = _debuginfo._absences;
            gridControlPlanning.DataSource = _debuginfo._planningweeks ;
            gridControlRecording.DataSource = _debuginfo._recordingweeks;

            teFirstName.Text = _debuginfo.employee.FirstName;
            teLastName.Text = _debuginfo.employee.LastName;
            teID.Text = _debuginfo.employee.ID.ToString();
            teSaldo.Text = TextParser.TimeToString((int)Math.Round(_debuginfo.employee.BalanceHours));
            if (_debuginfo.employee.PersNumber.HasValue )
                teNumber.Text = _debuginfo.employee.PersNumber.Value.ToString ();
            tePersID.Text = _debuginfo.employee.PersID;

        }


        private class IntToTimeFormatProvider : ICustomFormatter, IFormatProvider
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
                int value = Convert.ToInt32(arg);

                return TextParser.TimeToString(value);
            }
        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }
    }
}