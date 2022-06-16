using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionSaldoOnCertainWeeks:ConditionBase 
    {
        List<byte> _weeks = new List<byte>();
        public ConditionSaldoOnCertainWeeks()
            : base(ConditionTypes.SaldoOnCertainWeeks)
        {

        }
        public int Compare = 0;

        public int Value = 0;


        public override void ParseValue(string value)
        {
            ParseString1(value);
        }

        public List<byte> Weeks
        {
            get { return _weeks; }
        }

        private void ParseString1(string str)
        {

            _weeks.Clear ();
            Compare = 0;
            Value = 0;

            string[] ar = str.Split(';');

            if (ar == null || ar.Length != 3) return;

            Compare = Convert.ToInt32(ar[0]);
            Value = Convert.ToInt32(ar[1]);

            ParseString2(ar[2]);

        }
        private void ParseString2(string str)
        {
            string[] strs = str.Split(',');
            List<byte> lst = new List<byte>();
            if (strs != null && strs.Length > 0)
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!String.IsNullOrEmpty(strs[i]))
                    {
                        byte b = Convert.ToByte(strs[i]);
                        if (b > 0 && b < 54)
                            lst.Add(b);
                    }
                }
                lst.Sort();
            }
            _weeks = lst;
        }

        private bool CheckingDate(DateTime date)
        {
            byte weeknumber = DateTimeHelper.GetWeekNumber(date);

            return Weeks.BinarySearch(weeknumber) >= 0;
        }

        private bool CheckSaldo(int saldo)
        {
            int minutes = Value * 60;

            if (Compare == 0)
            {
                return saldo < minutes;
            }
            if (Compare == 1)
            {
                return minutes != saldo;
            }
            if (Compare == 2)
            {
                return saldo > minutes;
            }
            
            return false;
        }
        public override bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return CheckingDate(planningWeek.BeginDate) && CheckSaldo(planningWeek.Saldo);
        }
        public override bool Validate()
        {
            return ValidateWeek(Wrapper.EmployeeWeek, Wrapper.EmployeeWeek.BeginDate);
        }


        public override bool ValidateNew()
        {

            return ValidateWeekNew(Owner.EmployeeWeek, Owner.EmployeeWeek.BeginDate);
            

        }
        public override bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            return CheckingDate(planningWeek.BeginDate) && CheckSaldo(planningWeek.Saldo);
            
        }
    }
}
