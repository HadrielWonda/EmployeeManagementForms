using System;
using System.Drawing;

namespace Baumax.Printouts
{
    public partial class AbsenceQuartlyAustria : Baumax.Printouts.AbsebcePlanning.AbsenceQartly
    {
        public AbsenceQuartlyAustria()
        {
            ReaddRange();
            //InitializeComponent();
            int[] sizes = new int[] { 192, 97, 98, 97, 98, 97, 98, 97, 98, 97, 98, 97, 98, 37, 37 };
            RecalculateBlock(xrRow1, sizes);
            RecalculateBlock(xrDetailRow, sizes);
            gc_SpareHolidaysExc.Font = gc_SpareHolidaysInc.Font = gc_UsedHolidays.Font = new Font("Arial", 8f, FontStyle.Regular);
        }
    }
}

