using System;

namespace Baumax.Printouts
{
    public partial class AbsenceQuartlyAustriaA4 : Baumax.Printouts.AbsenceQuartlyA4
    {
        public AbsenceQuartlyAustriaA4()
        {
            ReaddRange();
            //InitializeComponent();
            int[] sizes = new int[] { 142, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 31, 31 };
            RecalculateBlock(xrRow1, sizes);
            RecalculateBlock(xrDetailRow, sizes);
        }
    }
}

