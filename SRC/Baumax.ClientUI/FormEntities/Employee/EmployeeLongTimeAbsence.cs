using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Baumax.ClientUI.FormEntities.Employee
{
    using System.Diagnostics;
    using Baumax.Domain;


    public class AssignEmployeeState
    {
        private Employee m_Employee;
        private Employee m_ToEmployee;
        private ListInternalEmployees m_ListEmployees = new ListInternalEmployees();
        public Employee ExtEmployee
        {
            get { return m_Employee; }
            set { m_Employee = value; }
        }

        public Employee ToEmployee
        {
            get { return m_ToEmployee; }
            set { m_ToEmployee = value; }
        }
        

        public ListInternalEmployees Employees
        {
            get { return m_ListEmployees; }
            set { m_ListEmployees = value; }
        }

        public AssignEmployeeState(Employee empl, IList list)
        {
            Debug.Assert(empl != null);
            Debug.Assert(!empl.Import);

            ExtEmployee = empl;

            Employees.FillList(list);
        }

    }
    public class ListInternalEmployees : List<Employee>
    {
        public void FillList(IList emplList)
        {
            if (emplList != null)
            {
                foreach (Employee empl in emplList)
                {
                    if (empl.Import) this.Add(empl);
                }
            }
        }
    }
/*
    public class LongTimeAbsence
    {
        private int m_AbsenceId = 0;


        private string m_AbsenceName = String.Empty;


        public int AbsenceId
        {
            get { return m_AbsenceId; }
            set { m_AbsenceId = value; }
        }

        public string AbsenceName
        {
            get { return m_AbsenceName; }
            set { m_AbsenceName = value; }
        }

        public LongTimeAbsence(int aId, string aName)
        {
            AbsenceId = aId;
            AbsenceName = aName;
        }
    }

    public class EmployeeLongTimeAbsence : BaseEntity
    {
        private Domain.Employee  m_Employee;

        public Domain.Employee  Employee
        {
            get { return m_Employee; }
            set { m_Employee = value; }
        }

        private DateTime m_BeginDate;

        public DateTime BeginDate
        {
            get { return m_BeginDate; }
            set { m_BeginDate = value; }
        }
        private DateTime m_EndDate;

        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }

        private int m_LongTimeAbsenceId;

        public int LongTimeAbsenceId
        {
            get { return m_LongTimeAbsenceId; }
            set { m_LongTimeAbsenceId = value; }
        }
	

    }*/
}
