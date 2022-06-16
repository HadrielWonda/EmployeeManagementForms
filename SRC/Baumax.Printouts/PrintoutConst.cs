using System.Collections.Generic;
namespace Baumax.Printouts
{
	class PrintoutConst
	{
		public const string ContractWorkingHours = "ContractWorkingHours";
		public const string AvailableHolidays = "AvailableHolidays";
		public const string PlannedWorkingHours = "PlannedWorkingHours";
		public const string AdditionalWorkingHours = "AdditionalWorkingHours";
		public const string PlusMinusHours = "PlusMinusHours";
		public const string BalanceHours = "BalanceHours";
        public const string UsedHolidays = "UsedHolidays";

        public const string EmployeeName = "EmployeeName";
        public const string OldHoliday = "OldHolidays";
        public const string NewHoliday = "NewHolidays";
        public const string SpareExc = "SpareExc";
        public const string SpareInc = "SpareInc";
        public const string Text = "Text";
        public const string Tag = "Tag";
        public const string World = "WorldName";

        public static List<string> Months = new List<string>(
            new string[] 
            {   "january","february","march",
                "april","may","june",
                "july","august","september",
                "october","november","december" });

        /// <summary></summary>
        public const float CellEmployeeWidth= 0.1f;
        public const float CellUsedWidth    = 0.022f;
        public const float CellMonthWidth   = 0.064f;

        public static string DynName(int factor)
        {
            return string.Concat("dcDyn", factor);
        }
    }
}