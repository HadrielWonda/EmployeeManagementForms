using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Baumax.Domain;
using Baumax.Printouts.AbsebcePlanning;
using Baumax.Contract.Absences;
using Baumax.Environment;
using System.Drawing.Printing;

namespace Baumax.Printouts.AbsebcePlanning
{
    public partial class AbsencePlanningPrintoutA4 : AbsencePlanningPrintout
    {
        public AbsencePlanningPrintoutA4()
		{
			InitializeComponent();
		}
    }
}

