using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using System.Collections;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract;

namespace Baumax.Services._HelperObjects
{
    // load employee relation be demand
//    public class EmployeesRelationIndexer : DictionListEmployeeRelations
//    {
//        private EmployeeRelationService _service = null;

//        private DateTime _begindate;

//        public DateTime BeginDate
//        {
//            get { return _begindate; }
//            set { _begindate = value; }
//        }

//        public virtual DateTime EndDate
//        {
//            get { return DateTimeSql.SmallDatetimeMax; }
//        }

//        public EmployeesRelationIndexer(IEmployeeRelationService service, DateTime date):base(null)
//        {
//            if (service == null)
//                throw new ArgumentNullException();

//            _service = service as EmployeeRelationService;

//            if (_service == null)
//                throw new InvalidCastException();

//            _begindate = date;
//        }

//        protected override ListEmployeeRelations GetById(long emplid, bool bCreate)
//        {
//            ListEmployeeRelations lstResult = base.GetById(emplid, bCreate);


//            if (lstResult == null && _service != null)
//            {
//                List<EmployeeRelation> lst = _service.GetEmployeeRelations(emplid, BeginDate, EndDate);

//                lstResult = new ListEmployeeRelations();
//                if (lst != null)
//                {
//                    lstResult.AddRange(lst);
//                }

//#if DEBUG
//                if (_diction.ContainsKey(emplid))
//                    throw new ArgumentException();
//#endif

//                _diction[emplid] = lstResult;
//            }

//            return lstResult;
//        }

//        public void LoadByEmployees(long[] employeesids)
//        {
//            List<EmployeeRelation> lst = _service.GetEmployeeRelationsByEmployeeIds(employeesids, BeginDate, EndDate);
//            if (lst != null && lst.Count > 0)
//            {
//                foreach (EmployeeRelation relation in lst)
//                {
//                    GetById(relation.EmployeeID, true).Add(relation);
//                }
//            }
//        }

//    }
}
