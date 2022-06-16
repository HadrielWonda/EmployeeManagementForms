using System;
using Baumax.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.UI;

namespace Baumax.Printouts
{
	// Localization of reports & preview window
	public class ReportLocalizer : PreviewLocalizer
	{
		private const string StrPreviewStringId = "PreviewStringId.";

		private static ReportLocalizer _instance; 

		public static void InitDevExPreviewLocalizer()
		{
			Active = GetInstance();
		}

		private ReportLocalizer(){}

		private static ReportLocalizer GetInstance()
		{
			if (_instance == null)
			{
				_instance = new ReportLocalizer();
			}
			return _instance;
		}

		private static string GetCodeWord(string controlName)
		{

			if (!String.IsNullOrEmpty(controlName))
			{

				int pos = controlName.IndexOf('_');

				return (pos > 0) ? controlName.Substring(pos + 1).ToLower() : controlName.ToLower();
			}
			return null;
		}

		private static string GetLocalizeWord(string controlname)
		{
			string label = GetCodeWord(controlname);

            if (label != null)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(label);
#endif
                return Localizer.GetLocalized(label.ToLower());
            }

		    return null;
		}

		public static void Localize(XRControl control)
		{
			if (control == null)
			{
				return;
			}

			if (!String.IsNullOrEmpty(control.Name))
			{
				control.Text = GetLocalizeWord(control.Name);
			}
			//
			if (control is XRTable)
			{
				XRTable table = control as XRTable;
				for (int rowIdx = 0; rowIdx < table.Rows.Count; rowIdx++)
				{
					foreach (XRTableCell cell in table.Rows[rowIdx].Cells)
					{
						cell.Text = GetLocalizeWord(cell.Name);
					}
				}
			}
			else if (control is Subreport)
			{
				Localize(control);
			}
			else
			{
				for (int i = 0; i < control.Controls.Count; ++i)
					Localize(control.Controls[i]);
			}
		}

        public static string GetMonthName(int number)
        {
            return Localizer.GetLocalized(39 + number) ?? "january";
        }

		public override string GetLocalizedString(PreviewStringId id)
		{
			switch (id)
			{
				case PreviewStringId.Button_Cancel:
					return Localizer.GetLocalized("cancel");
				case PreviewStringId.Button_Apply:
					return Localizer.GetLocalized("Apply");
				case PreviewStringId.RibbonPreview_Print_Caption:
				case PreviewStringId.TB_TTip_Print:
					return Localizer.GetLocalized("Print");
				default:
					string result = Localizer.GetLocalized(StrPreviewStringId + id);
					return (String.IsNullOrEmpty(result)) ? id.ToString() : result;
			}
		}

    }
}