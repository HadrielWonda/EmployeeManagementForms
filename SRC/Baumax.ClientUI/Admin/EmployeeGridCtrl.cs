using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.FormEntities.Employee;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.Admin
{
    public partial class EmployeeGridCtrl : UCBaseEntityList
    {
        private IList<Employee> _EmployeeList;

        public EmployeeGridCtrl()
        {
            InitializeComponent();
            string[] names = new string[2];
            names[0] = GetLocalized("FirstName");
            names[1] = GetLocalized("LastName");
            AddGridColumns(new string[] {"FirstName", "LastName"}, names);
        }

        public override void Bind()
        {
            base.Bind();
            _EmployeeList = ClientEnvironment.EmployeeService.FindAll();
            gridControl.DataSource = EmployeeList;
        }

        /// <summary>
        /// Add new item
        /// </summary>
        public override void Add()
        {
            Employee emp = new Employee();
            using (EmployeeFrm frm = new EmployeeFrm())
            {
                frm.Entity = emp;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (emp.ID == 0)
                    {
                        try
                        {
                            ClientEnvironment.EmployeeService.Save(emp);
                        }
                        catch (EntityException ex)
                        {
                            // 2think: what details should we show?
                            // 2think: how to localize?
                            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                            {
                                form.Text = GetLocalized("CannotSaveEmployee");
                                form.ShowDialog(this);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            ClientEnvironment.EmployeeService.SaveOrUpdate(emp);
                        }
                        catch (EntityException ex)
                        {
                            // 2think: what details should we show?
                            // 2think: how to localize?
                            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                            {
                                form.Text = GetLocalized("CannotSaveEmployee");
                                form.ShowDialog(this);
                            }
                        }
                    }
                    RefreshData();
                }
            }
        }

        /// <summary>
        /// Edit current item
        /// </summary>
        public override void Edit()
        {
            Employee emp = (Employee) mainGridView.GetRow(mainGridView.FocusedRowHandle);
            if (emp != null)
            {
                using (EmployeeFrm frm = new EmployeeFrm())
                {
                    frm.Entity = emp;
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (emp.ID == 0)
                        {
                            try
                            {
                                ClientEnvironment.EmployeeService.Save(emp);
                            }
                            catch (EntityException ex)
                            {
                                // 2think: what details should we show?
                                // 2think: how to localize?
                                using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                                {
                                    form.Text = GetLocalized("CannotSaveEmployee");
                                    form.ShowDialog(this);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                ClientEnvironment.EmployeeService.SaveOrUpdate(emp);
                            }
                            catch (EntityException ex)
                            {
                                // 2think: what details should we show?
                                // 2think: how to localize?
                                using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                                {
                                    form.Text = GetLocalized("CannotSaveEmployee");
                                    form.ShowDialog(this);
                                }
                            }
                        }
                        RefreshData();
                    }
                }
            }
        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        public override void Delete()
        {
            List<long> ids = new List<long>();
            foreach (int rowHandle in mainGridView.GetSelectedRows())
            {
                Employee entity = (Employee) mainGridView.GetRow(rowHandle);
                ids.Add(entity.ID);
            }
            if (!QuestionMessageYes(GetLocalized("QuestionDeleteEmployee")))
            {
                return;
            }
            if (ids.Count == 1)
            {
                try
                {
                    ClientEnvironment.EmployeeService.DeleteByID(ids[0]);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotDeleteEmployee");
                        form.ShowDialog(this);
                    }
                }
            }
            else
            {
                try
                {
                    ClientEnvironment.EmployeeService.DeleteListByID(ids);
                }
                catch (EntityException)
                {
                    // can't obtain more details while deleting list
                    ErrorMessage(GetLocalized("SomeEmployeesNotDeleted"));
                }
            }

            RefreshData();
        }

        [Browsable(false)]
        public IList<Employee> EmployeeList
        {
            get { return _EmployeeList; }
            set
            {
                _EmployeeList = value;
                RefreshData();
            }
        }
    }
}