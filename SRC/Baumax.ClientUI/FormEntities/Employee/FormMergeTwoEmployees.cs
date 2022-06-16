using System;
using System.Collections.Generic;
using System.Diagnostics;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class FormMergeTwoEmployees : FormBaseEntity
    {
        public FormMergeTwoEmployees()
        {
            InitializeComponent();
        }

        // acpro item: 119084(11)
        private List<Domain.Employee> _InternalEmployeeList = null;
        private List<Domain.Employee> _ExternalEmployeeList = null;
        private int _CurInternalEmployeeIndex = -1;
        private int _CurExternalEmployeeIndex = -1;
        private bool m_bModified = false;

        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                for (int i = 0; i < vGridControl1.Rows.Count; i++)
                {
                    string label = GetLocalized(GetCodeWord(vGridControl1.Rows[i].Name));
                    if (label != null)
                    {
                        vGridControl1.Rows[i].Properties.Caption = label;
                    }
                }
            }
        }

        private string GetCodeWord(string controlname)
        {
            if (controlname != null)
            {
                int pos = controlname.IndexOf('_');

                if (pos > 0)
                {
                    return controlname.Substring(pos + 1).ToLower();
                }
            }
            return null;
        }

        public override object Entity
        {
            get { return CurInternalEmployee; }
            set { }
        }

        public Domain.Employee CurInternalEmployee
        {
            get
            {
                if ((_InternalEmployeeList != null) &&
                    (_InternalEmployeeList.Count > 0) &&
                    (_CurInternalEmployeeIndex >= 0) &&
                    (_CurInternalEmployeeIndex < _InternalEmployeeList.Count)
                    )
                {
                    return _InternalEmployeeList[_CurInternalEmployeeIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public Domain.Employee CurExternalEmployee
        {
            get
            {
                if ((_ExternalEmployeeList != null) &&
                    (_ExternalEmployeeList.Count > 0) &&
                    (_CurExternalEmployeeIndex >= 0) &&
                    (_CurExternalEmployeeIndex < _ExternalEmployeeList.Count)
                    )
                {
                    return _ExternalEmployeeList[_CurExternalEmployeeIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Domain.Employee> InternalEmployeeList
        {
            get { return _InternalEmployeeList; }
            set
            {
                _InternalEmployeeList = value;
                _CurInternalEmployeeIndex = -1;
                SelectNextInternalEmployee();
            }
        }

        public List<Domain.Employee> ExternalEmployeeList
        {
            get { return _ExternalEmployeeList; }
            set
            {
                _ExternalEmployeeList = value;
                _CurExternalEmployeeIndex = -1;
                SelectNextExternalEmployee();
            }
        }

        protected void SelectNextInternalEmployee()
        {
            if ((_InternalEmployeeList != null) && (_InternalEmployeeList.Count > 0))
            {
                if (++_CurInternalEmployeeIndex >= _InternalEmployeeList.Count)
                {
                    _CurInternalEmployeeIndex = 0;
                }
            }
            BindEmployees();
        }

        protected void SelectNextExternalEmployee()
        {
            if ((_ExternalEmployeeList != null) && (_ExternalEmployeeList.Count > 0))
            {
                if (++_CurExternalEmployeeIndex >= _ExternalEmployeeList.Count)
                {
                    _CurExternalEmployeeIndex = 0;
                }
            }
            BindEmployees();
        }

        public void ResetBind()
        {
            _CurExternalEmployeeIndex = -1;
            _CurInternalEmployeeIndex = -1;
            BindEmployees();
            vGridControl1.DataSource = null;
        }

        protected void BindEmployees()
        {
            if (CurInternalEmployee != null && CurExternalEmployee != null)
            {
                List<Domain.Employee> lst = new List<Domain.Employee>(2);
                lst.Add(CurInternalEmployee);
                lst.Add(CurExternalEmployee);

                vGridControl1.DataSource = lst;
            }
            else
            {
                vGridControl1.DataSource = null;
            }
            button_NextInt.Enabled = ((_InternalEmployeeList != null) && (_InternalEmployeeList.Count > 1));
            button_NextExt.Enabled = ((_ExternalEmployeeList != null) && (_ExternalEmployeeList.Count > 1));
        }

        public override bool Modified
        {
            get { return m_bModified; }
        }

        protected override bool ValidateEntity()
        {
            Debug.Assert(CurInternalEmployee != null);
            Debug.Assert(CurExternalEmployee != null);

            if (CurInternalEmployee != null && CurExternalEmployee != null)
            {
                return String.Compare(CurInternalEmployee.FullName, CurExternalEmployee.FullName, true) == 0;
            }
            return false;
        }

        protected override bool SaveEntity()
        {
            Debug.Assert(CurInternalEmployee != null);
            Debug.Assert(CurExternalEmployee != null);

            if (CurInternalEmployee != null && CurExternalEmployee != null)
            {
                if (QuestionMessageYes(GetLocalized("QuestionAssignExternalEmployee")))
                {
                    try
                    {
                        ClientEnvironment.EmployeeService.Merge(CurInternalEmployee.ID, CurExternalEmployee.ID);
                        m_bModified = true;
                        return true;
                    }
                    catch (EmployeeMergeException ex)
                    {
                        if (ex.EmployeeMergeError == EmployeeMergeError.CantMerge)
                        {
                            ErrorMessage(GetLocalized("ErrorCantMergeEmployees"));
                        }
                        else
                        {
                            ProcessEntityException(ex);
                        }
                    }
                }
            }
            return false;
        }

        private void button_NextInt_Click(object sender, EventArgs e)
        {
            SelectNextInternalEmployee();
        }

        private void button_NextExt_Click(object sender, EventArgs e)
        {
            SelectNextExternalEmployee();
        }
    }
}