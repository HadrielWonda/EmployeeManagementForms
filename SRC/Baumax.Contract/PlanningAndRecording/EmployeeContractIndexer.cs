using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using System.Diagnostics;

namespace Baumax.Contract.TimePlanning
{
    public class DictionListEmployeesContract
    {
        protected Dictionary<long, ListEmployeeContracts> _diction = new Dictionary<long, ListEmployeeContracts>();
        protected ListEmployeeContracts _lstUsing = null;
        protected long _lastId = 0;

        public DictionListEmployeesContract() {}

        public DictionListEmployeesContract(List<EmployeeContract> lst)
        {
            BuildDiction(lst);
        }


        public void BuildDiction(List<EmployeeContract> lst)
        {
            _diction.Clear();
            _lastId = 0;
            _lstUsing = null;

            if (lst == null) return;

            
            foreach (EmployeeContract rel in lst)
            {
                GetById(rel.EmployeeID,true).Add(rel);
            }
        }

        protected virtual ListEmployeeContracts CreateDictionItem(long emplid)
        {
            return new ListEmployeeContracts(emplid);
        }
        protected ListEmployeeContracts GetById(long emplid)
        {
            if (_lstUsing != null && _lastId == emplid) return _lstUsing;

            ListEmployeeContracts list = null;

            if (_diction.TryGetValue(emplid, out list))
            {
                _lstUsing = list;
                _lastId = emplid;
            }
            return list;
        }

        protected virtual ListEmployeeContracts GetById(long emplid, bool bCreate)
        {
            ListEmployeeContracts list = GetById(emplid);

            if ((list == null) && bCreate )
            {
                list = CreateDictionItem(emplid);
                _lstUsing = list;
                _lastId = emplid;
                _diction[emplid] = list;
            }

            return list;
        }

        public int Count
        {
            get { return _diction.Count; }
        }

        public ListEmployeeContracts this[long emplid]
        {
            get { return GetById(emplid); }
        }

        public virtual EmployeeContract IsContain(long emplid, DateTime date)
        {
            ListEmployeeContracts lst = GetById(emplid);

            if (lst == null) return null;

            return lst.GetContract(date);
        }

        public int GetContractHours(long emplid, DateTime date)
        {
            EmployeeContract contract = IsContain(emplid, date);

            int result = EmployeeContract.InvalidContractHours;

            if (contract != null)
                result = Convert.ToInt32(contract.ContractWorkingHours * 60);

            return result;
        }

        public int GetContractHours(long emplid, DateTime date,DateTime date1)
        {
            
            ListEmployeeContracts lst = GetById(emplid);

            if (lst == null) return 0;

            return lst.GetContractHoursByWeekRange(date, date1);

           
        }

        public bool FillEmployeeWeek(EmployeeWeek week)
        {
            if (week == null) return false;
            bool bExistsContract = false;
            int contracthours = EmployeeContract.InvalidContractHours;

            foreach (EmployeeDay d in week.DaysList)
            {
                contracthours = GetContractHours(d.EmployeeId, d.Date);

                if (contracthours != EmployeeContract.InvalidContractHours)
                {
                    d.HasContract = true;
                    if (week.ContractHoursPerWeek == 0)
                        week.ContractHoursPerWeek = contracthours;
                }
                bExistsContract |= d.HasContract;
            }
            
            
            return bExistsContract;
        }
        public void FillEmployeeWeeks(List<EmployeeWeek> weeks)
        {
            if (weeks == null || weeks.Count == 0) return;

            foreach (EmployeeWeek w in weeks)
                FillEmployeeWeek(w);
        }

        public void LoadContracts(IEmployeeContractService service)
        {
            BuildDiction(service.LoadAllSorted ());
        }
    }


    public class ListEmployeeContracts:List<EmployeeContract>
    {
        private IEmployeeContractService _contractservice = null;
        private long _employeeid = 0;

        public long Employeeid
        {
            get { return _employeeid; }
        }

        public ListEmployeeContracts(long emplid)
            : base()
        {
            _employeeid = emplid;
        }

        public ListEmployeeContracts(IEmployeeContractService contractservice)
        {
            _contractservice = contractservice;
        }

        public ListEmployeeContracts(IEmployeeContractService contractservice, long emplid)
        {
            _contractservice = contractservice;
            LoadContracts(emplid);
        }

        public EmployeeContract GetContract(DateTime date)
        {

            int iCount = this.Count;
            if (iCount > 0)
            {
                EmployeeContract contract = this[0];

                if (iCount == 1 && contract.IsContainDate(date))
                    return contract;

                for (int i = 0; i < iCount; i++)
                {
                    contract = this[i];
                    if (contract.IsContainDate(date))
                        return contract;
                }
            }
            return null;
        }

        public bool IsExistsContract(DateTime date)
        {
            return GetContract (date) != null;
        }

        public int GetContractHours(DateTime date)
        {
            EmployeeContract contract = GetContract(date);
            return (contract != null) ? contract.ContractWeekTime : EmployeeContract.InvalidContractHours;
        }

        public int GetContractHoursByWeekRange(DateTime monday, DateTime sunday)
        {
            int iCount = this.Count;
            if (iCount > 0)
            {
                EmployeeContract contract = this[0];

                if (iCount == 1 && DateTimeHelper.IsIntersectExc(monday, sunday, contract.ContractBegin, contract.ContractEnd))
                    return contract.ContractWeekTime;

                for (int i = 0; i < iCount; i++)
                {
                    contract = this[i];
                    if (DateTimeHelper.IsIntersectExc(monday, sunday, contract.ContractBegin, contract.ContractEnd))
                        return contract.ContractWeekTime;
                }
            }
            return 0;
        }


        public void LoadContracts(long emplid, DateTime beginDate, DateTime endDate)
        {
            if (_contractservice == null)
                throw new ArgumentNullException();

            _employeeid = emplid;

            this.Clear();

            List<EmployeeContract> lst = _contractservice.GetEmployeeContracts(emplid, beginDate, endDate);

            if (lst != null)
                AddRange(lst);


        }

        public void LoadContracts(long emplid)
        {
            if (_contractservice == null)
                throw new ArgumentNullException();

            _employeeid = emplid;

            Clear();

            List<EmployeeContract> lst = _contractservice.GetEmployeeContracts(emplid);

            if (lst != null)
                AddRange(lst);


        }
        
        //private void CheckContracts()
        //{
        //    if (Count <= 1) return;

        //    DateTime date = this[0].ContractEnd.Date;

        //    for (int i = 1; i < Count-1; i++)
        //    {
        //        if (date.AddDays(1) != this[i].ContractBegin.Date)
        //            throw new ArgumentException();

        //        date = this[i].ContractEnd.Date;
        //    }
        //}


        //public bool IsValidRelation(EmployeeRelation relation)
        //{
        //    if (relation == null)
        //        throw new ArgumentNullException();

        //    if (_employeeid <= 0)
        //        throw new ArgumentNullException();

        //    bool bValid = false;
        //    if (relation.EmployeeID == _employeeid)
        //    {
        //        bValid = GetContract(relation.BeginTime) != null;
        //        bValid &= GetContract(relation.EndTime) != null;
        //    }
        //    return bValid;
        //}

        public DateTime GetFirstContractDate()
        {
            if (Count > 0)
                return this[0].ContractBegin;
            else
                return DateTimeSql.SmallDatetimeMin;
        }

        public DateTime GetLastContractDate()
        {
            if (Count > 0)
                return this[Count - 1].ContractEnd;
            else 
                return DateTimeSql.SmallDatetimeMin;
        }

        //public bool CorrectRelation(EmployeeRelation relation)
        //{
        //    if (relation == null)
        //        throw new ArgumentNullException();
        //    if (_employeeid <= 0)
        //        throw new ArgumentNullException();

        //    if (IsValidRelation(relation)) 
        //        return false;

        //    DateTime firstDate = GetFirstContractDate();
        //    DateTime lastDate = GetLastContractDate();
        //    bool bModified = false;
        //    if (relation.BeginTime < firstDate)
        //    {
        //        bModified = true;
        //        relation.BeginTime = firstDate;
        //    }

        //    if (relation.EndTime > lastDate)
        //    {
        //        bModified = true;
        //        relation.EndTime = lastDate;
        //    }

        //    return bModified;
        //}

        public EmployeeContract GetById(long contractid)
        {

            for (int i = 0; i < Count - 1; i++)
            {
                if ( this[i].ID == contractid ) return this[i];
            }
            return null;
        }

        public UnbreakContract GetUnbreakContracts()
        {
            return new UnbreakContract(this);
        }
    }

    public class UnbreakContract
    {
        private DateTime _BeginDate;
        private DateTime _EndDate;
        private UnbreakContract _NextContract;
        private List<EmployeeContract> _Contracts = new List<EmployeeContract>();
        private List<EmployeeRelation> _Relations = new List<EmployeeRelation>();

        public DateTime BeginDate
        {
            get { return _BeginDate; }
            set { _BeginDate = value; }
        }
        

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        

        public UnbreakContract NextContract
        {
            get { return _NextContract; }
            set { _NextContract = value; }
        }
        public List<EmployeeContract> Contracts { get { return _Contracts; } }
        public List<EmployeeRelation> Relations { get { return _Relations; } }

        protected DateTime NextDay
        {
            get { return EndDate.AddDays(1); }
        }
        protected DateTime PrevDay
        {
            get { return BeginDate.AddDays(-1); }
        }
        public UnbreakContract(EmployeeContract contract)
        {
            BeginDate = contract.ContractBegin;
            EndDate = contract.ContractEnd;
            _Contracts.Add(contract);
            NextContract = null;
        }
        public UnbreakContract(List<EmployeeContract> contracts)
        {

            if (contracts == null) return;

            bool init = false;

            foreach (EmployeeContract c in contracts)
            {
                if (!init)
                {
                    BeginDate = c.ContractBegin;
                    EndDate = c.ContractEnd;
                    NextContract = null;
                }
                else AddContract(c);
                
            }
        }
        public void AddContract(EmployeeContract contract)
        {
            if (EndDate < contract.ContractBegin)
            {
                if (NextDay == contract.ContractBegin)
                {
                    EndDate = contract.ContractBegin;
                    _Contracts.Add(contract);
                }
                else
                {
                    if (NextContract == null)
                    {
                        NextContract = new UnbreakContract(contract);
                    }
                    else
                    {
                        NextContract.AddContract(contract);
                    }
                }
            }
            
        }

        public bool Include(EmployeeRelation relation)
        {
            if (relation == null) return false;
            return DateTimeHelper.Include(relation.BeginTime, relation.EndTime, BeginDate, EndDate);
        }

        public bool CheckIfOutside(EmployeeRelation relation)
        {
            if (NextContract == null) return true;

            DateTime nextBeginDate = NextContract.BeginDate.AddDays (-1);

            if (DateTimeHelper.Include(relation.BeginTime, relation.EndTime, NextDay, nextBeginDate))
                return false;

            return NextContract.CheckIfOutside(relation);

        }
        public bool CheckRelation(EmployeeRelation relation)
        {
            if (relation == null) return false;

            if (Include(relation))  return true;

            if (NextContract != null)
                return NextContract.CheckRelation(relation);

            
            return false;
        }
        protected void TryResizeIfNeed(IEmployeeRelationService service)
        {
            EmployeeRelation firstRange = null;
            EmployeeRelation lastRange = null;
            if (_Relations != null && _Relations.Count > 0)
            {
                _Relations.Sort();
                firstRange = _Relations[0];

                if (firstRange.BeginTime != BeginDate)
                {
                    firstRange.BeginTime = BeginDate;
                }
                lastRange = _Relations[_Relations.Count - 1];
                if (firstRange.EndTime != EndDate)
                {
                    firstRange.EndTime = EndDate;
                }

                if (_Relations.Count == 1)
                    service.SaveOrUpdate (firstRange );
                else
                {
                    service.SaveOrUpdate (firstRange );
                    service.SaveOrUpdate (lastRange);
                }

            }
            if (NextContract != null)
                NextContract.TryResizeIfNeed(service);
        }
        public void CheckAndModifyRelations(List<EmployeeRelation> relations ,IEmployeeRelationService service)
        {
            if (relations == null || relations.Count == 0) return;
            if (service == null) return;

            foreach (EmployeeRelation relation in relations)
                CheckAndModify(relation, service);

            TryResizeIfNeed(service);
        }

        public void CheckAndModify(EmployeeRelation relation, IEmployeeRelationService service)
        {
            if (CheckIfOutside(relation))
            {
                //relation.EndTime = relation.BeginTime.AddDays(-1);
                service.Delete(relation);
                return ;
            }


            if (Include(relation))
            {
                Relations.Add(relation);
                return ;
            }
            else if (DateTimeHelper.IsIntersectExc(relation.BeginTime, relation.EndTime, BeginDate, EndDate))
            {
                if (DateTimeHelper.Between(relation.BeginTime, BeginDate, EndDate))
                {
                    EmployeeRelation newrelation = relation.GetCopy ();
                    newrelation.ID = 0;
                    newrelation.BeginTime = NextDay;

                    relation.EndTime = EndDate;
                    Debug.Assert(relation.IsValidRelation());
                    Relations.Add(relation);
                    service.SaveOrUpdate(relation);
                    relation = newrelation;
                }
                else if (DateTimeHelper.Between(relation.EndTime, BeginDate, EndDate))
                {
                    EmployeeRelation newrelation = relation.GetCopy();
                    newrelation.ID = 0;
                    newrelation.EndTime = PrevDay;

                    relation.BeginTime = BeginDate;
                    Debug.Assert(relation.IsValidRelation());

                    Relations.Add(relation);
                    service.SaveOrUpdate(relation);
                    relation = newrelation;

                }
                if (NextContract != null)
                    NextContract.CheckAndModify(relation, service);
            }
            else if (NextContract != null)
                NextContract.CheckAndModify(relation, service);
            return ;
        }
    }
}
