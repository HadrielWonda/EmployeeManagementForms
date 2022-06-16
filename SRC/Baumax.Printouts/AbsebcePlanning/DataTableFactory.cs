using System;
using System.Collections.Generic;
using System.Data;
using Baumax.Contract.Absences;
using DevExpress.XtraReports.UI;
using Baumax.Contract;
using PC = Baumax.Printouts.PrintoutConst;
using System.Drawing;
using Baumax.Environment;
using Baumax.Domain;

namespace Baumax.Printouts.AbsebcePlanning
{
    public abstract class DataTableFactory
    {
        protected DataTable   m_Table = null;
        protected YearWrapper m_Wrapper = null;
        protected Dictionary<string, double> m_Sums = new Dictionary<string,double>();
        protected bool m_HolidaysOnly;
        protected bool m_CalcSummary;
        protected readonly string m_Format = "{0:0.0}";

        protected abstract void BuildDynamicColumns();
        protected abstract void ApplyDynamicValues(BzEmployeeHoliday entity, DataRow row);

        public Dictionary<string, double> Sums
        {
            get { return m_Sums; }
            set { m_Sums = value; }
        }
        public YearWrapper Wrapper
        {
            get { return m_Wrapper; }
            set { m_Wrapper = value; }
        }
        public DataTable Table  
        { 
            get { return m_Table; } 
        }

        public DataTableFactory (bool onlyHolidays, bool calcSummary)
        {
            m_CalcSummary = calcSummary;
            m_HolidaysOnly = onlyHolidays;
        }

        public void BindStaticCells(XRTableCell gcEmployee, XRTableCell gcOldHolidays, XRTableCell gcNewHolidays,
                                    XRTableCell gcSpareExc, XRTableCell gcSpareInc, XRTableCell gcAvailable, XRTableCell gcUsed)
        {
            gcEmployee.DataBindings.Add(new XRBinding(PC.Text, m_Table,PC.EmployeeName));
            gcOldHolidays.DataBindings.Add(new XRBinding(PC.Text, m_Table, PC.OldHoliday, m_Format));
            gcNewHolidays.DataBindings.Add(new XRBinding(PC.Text, m_Table, PC.NewHoliday, m_Format));
            gcSpareExc.DataBindings.Add (new XRBinding(PC.Text, m_Table, PC.SpareExc, m_Format));
            gcSpareInc.DataBindings.Add(new XRBinding(PC.Text, m_Table, PC.SpareInc, m_Format));
            gcAvailable.DataBindings.Add(new XRBinding(PC.Text, m_Table, PC.AvailableHolidays, m_Format));
            gcUsed.DataBindings.Add(new XRBinding(PC.Text, m_Table, PC.UsedHolidays, m_Format));
        }

        public virtual void BindDynamicCell (XRTableCell cell, int factor)
        {
            cell.DataBindings.Add(new XRBinding(PC.Tag, m_Table, PC.DynName(factor)));
        }

        protected virtual void BuildStaticColumns()
        {
            m_Table.Columns.Add(PC.EmployeeName, typeof(string));
            m_Table.Columns.Add(PC.OldHoliday, typeof(double));
            m_Table.Columns.Add(PC.NewHoliday, typeof(double));
            m_Table.Columns.Add(PC.AvailableHolidays, typeof(double));
            m_Table.Columns.Add(PC.SpareExc, typeof(double));
            m_Table.Columns.Add(PC.SpareInc, typeof(double));
            m_Table.Columns.Add(PC.UsedHolidays, typeof(double));
            m_Table.Columns.Add(PC.World, typeof(string));
        }

        private List<StoreToWorld> GetWorlds(bool showAll, long worldID, long storeID)
        {
            if (showAll)
                return ClientEnvironment.StoreToWorldService.FindAllForStore(storeID);
            List<StoreToWorld> worlds = new List<StoreToWorld>();
            worlds.Add(ClientEnvironment.StoreToWorldService.FindById(worldID));
            return worlds;
        }

        protected virtual void ApplyStaticEmployeeValues(BzEmployeeHoliday entity, DataRow row)
        {
            row[PC.EmployeeName] = entity.EmployeeName;
            row[PC.OldHoliday]   = entity.OldHolidays;
            row[PC.NewHoliday] = entity.NewHolidays;
            row[PC.AvailableHolidays]   = entity.AvailableHolidays;
            row[PC.SpareExc]     = entity.SpareHolidaysExc;
            row[PC.SpareInc] = entity.SpareHolidaysInc;
            row[PC.UsedHolidays] = entity.UsedHolidays;
            row[PC.World] = entity.WorldName;
        }

        protected void Init(IList<BzEmployeeHoliday> content, int year)
        {
            m_Wrapper = new YearWrapper(year);
            m_Table = new DataTable();
            BuildStaticColumns();
            BuildDynamicColumns();
            BuildSumsDiction();
            foreach (BzEmployeeHoliday holiday in content)
            {
                DataRow row = m_Table.NewRow();
                ApplyStaticEmployeeValues(holiday, row);
                ApplyDynamicValues(holiday, row);
                ApplySums(holiday);
                m_Table.Rows.Add(row);
            }
        }

        protected virtual void BuildSumsDiction()
        {
            m_Sums[PC.AvailableHolidays] = 0d;
            m_Sums[PC.NewHoliday] = 0d;
            m_Sums[PC.OldHoliday] = 0d;
            m_Sums[PC.SpareExc] = 0d;
            m_Sums[PC.SpareInc] = 0d;
            m_Sums[PC.UsedHolidays] = 0d;
        }

        protected virtual void ApplySums(BzEmployeeHoliday holiday)
        {
                m_Sums[PC.AvailableHolidays] += holiday.AvailableHolidays;
                m_Sums[PC.NewHoliday]  += holiday.NewHolidays;
                m_Sums[PC.OldHoliday] += holiday.OldHolidays;
                m_Sums[PC.SpareExc] += holiday.SpareHolidaysExc;
                m_Sums[PC.SpareInc] += holiday.SpareHolidaysInc;
                m_Sums[PC.UsedHolidays] += holiday.UsedHolidays;
        }

        protected virtual string InfoToString(IHolidayInfo info)
        {
            return (m_HolidaysOnly && !info.IsHoliday()) 
                ? "|-1"
                : string.Format("{0}|{1}", info.Value, info.GetColor());
        }

        public void ParseTag(object tag, out string text, out Color color)
        {
            string[] binds = ((string)tag).Split('|');
            int argb = int.Parse(binds[1]);
            text = binds[0];
            color = argb == 0 ? Color.SlateGray : Color.FromArgb(argb);
        }
    }
}
