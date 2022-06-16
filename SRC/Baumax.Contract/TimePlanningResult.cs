using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract
{
    
    [Serializable]
    public class TimePlanningResult
    {
        List<Employee> m_employees = null;
        List<EmployeeRelation> m_relations = null;
        List<EmployeeLongTimeAbsence> m_longabsences = null;
        List<EmployeeContract> m_contracts = null;


        public TimePlanningResult(List<Employee> aEmployees,
            List<EmployeeRelation> aRelations,
            List<EmployeeLongTimeAbsence> aLongabsences,
            List<EmployeeContract> contracts
            )
        {
            m_employees = aEmployees;
            m_relations = aRelations;
            m_longabsences = aLongabsences;
            m_contracts = contracts;
        }

        public List<Employee> Employees
        {
            get
            {
                return m_employees;
            }
        }
        public List<EmployeeRelation> Relations
        {
            get
            {
                return m_relations;
            }
        }
        public List<EmployeeContract> Contracts
        {
            get
            {
                return m_contracts;
            }
        }
        public List<EmployeeLongTimeAbsence> LongAbsences
        {
            get
            {
                return m_longabsences;
            }
        }

        public List<Employee> WorldEmployee(long worldid)
        {
            if (m_employees == null) return new List<Employee>();

            List<Employee> resultList = new List<Employee>();

            foreach (Employee empl in m_employees)
            {
                if (m_relations != null)
                {
                    foreach (EmployeeRelation rel in m_relations)
                    {
                        if (rel.EmployeeID == empl.ID)
                        {
                            if (rel.WorldID == worldid)
                            {
                                resultList.Add(empl);
                                break;
                            }
                        }
                    }
                }
            }

            return resultList;

        }

    }
}
