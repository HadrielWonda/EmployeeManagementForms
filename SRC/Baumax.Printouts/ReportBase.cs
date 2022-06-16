using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Drawing;

namespace Baumax.Printouts
{
	public class ReportBase : XtraReport
	{
		public ReportBase()
		{
			InitializeComponent();

			HideButtonsAndMargins();
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() { }

		private void HideButtonsAndMargins()
		{
			//ShowPreviewMarginLines = false;
			PrintingSystem.PreviewFormEx.PrintBarManager.AllowCustomization = false;
			PrintingSystem.PreviewFormEx.PrintBarManager.AllowQuickCustomization = false;
			PrintingSystem.PreviewFormEx.PrintBarManager.MainMenu.Visible = false;
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.PrintDirect, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Find, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Scale, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.FillBackground, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.PageLayout, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.PaperSize, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Customize, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.PageSetup, CommandVisibility.None);
			PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendFile, CommandVisibility.None);
		}
	}


}