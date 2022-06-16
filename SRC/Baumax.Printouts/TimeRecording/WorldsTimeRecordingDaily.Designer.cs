namespace Baumax.Printouts.TimeRecording
{
	partial class WorldsTimeRecordingDaily
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.tbl_DailyData = new DevExpress.XtraReports.UI.XRTable();
            this.row_DailyData = new DevExpress.XtraReports.UI.XRTableRow();
            this.fieldCell_EmployeeName = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldCell_0000Planned = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldCell_PlannedWorkingHoursPlanned = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.fieldCell_Employee1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldCell_0000 = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldCell_PlannedHours = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tbl_DailyCaption = new DevExpress.XtraReports.UI.XRTable();
            this.row_DailyCaption = new DevExpress.XtraReports.UI.XRTableRow();
            this.lbCell_Employee = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_0000 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_AllreadyPlannedWorkingHours = new DevExpress.XtraReports.UI.XRTableCell();
            this.styleFont = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbl_DailyData});
            this.Detail.Height = 50;
            this.Detail.Name = "Detail";
            // 
            // tbl_DailyData
            // 
            this.tbl_DailyData.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbl_DailyData.Dock = DevExpress.XtraReports.UI.XRDockStyle.Top;
            this.tbl_DailyData.KeepTogether = true;
            this.tbl_DailyData.Location = new System.Drawing.Point(0, 0);
            this.tbl_DailyData.Name = "tbl_DailyData";
            this.tbl_DailyData.ParentStyleUsing.UseBorders = false;
            this.tbl_DailyData.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.row_DailyData,
            this.xrTableRow1});
            this.tbl_DailyData.Size = new System.Drawing.Size(990, 50);
            this.tbl_DailyData.StyleName = "styleFont";
            this.tbl_DailyData.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BeforePrintRecordingTable);
            // 
            // row_DailyData
            // 
            this.row_DailyData.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.fieldCell_EmployeeName,
            this.fieldCell_0000Planned,
            this.fieldCell_PlannedWorkingHoursPlanned});
            this.row_DailyData.Name = "row_DailyData";
            this.row_DailyData.Size = new System.Drawing.Size(990, 25);
            // 
            // fieldCell_EmployeeName
            // 
            this.fieldCell_EmployeeName.KeepTogether = true;
            this.fieldCell_EmployeeName.Location = new System.Drawing.Point(0, 0);
            this.fieldCell_EmployeeName.Name = "fieldCell_EmployeeName";
            this.fieldCell_EmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_EmployeeName.Size = new System.Drawing.Size(90, 25);
            // 
            // fieldCell_0000Planned
            // 
            this.fieldCell_0000Planned.KeepTogether = true;
            this.fieldCell_0000Planned.Location = new System.Drawing.Point(90, 0);
            this.fieldCell_0000Planned.Name = "fieldCell_0000Planned";
            this.fieldCell_0000Planned.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_0000Planned.Size = new System.Drawing.Size(827, 25);
            this.fieldCell_0000Planned.Text = "fieldCell_0000Planned";
            this.fieldCell_0000Planned.SizeChanged += new DevExpress.XtraReports.UI.ChangeEventHandler(this.CellSizeChanged);
            // 
            // fieldCell_PlannedWorkingHoursPlanned
            // 
            this.fieldCell_PlannedWorkingHoursPlanned.KeepTogether = true;
            this.fieldCell_PlannedWorkingHoursPlanned.Location = new System.Drawing.Point(917, 0);
            this.fieldCell_PlannedWorkingHoursPlanned.Name = "fieldCell_PlannedWorkingHoursPlanned";
            this.fieldCell_PlannedWorkingHoursPlanned.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_PlannedWorkingHoursPlanned.Size = new System.Drawing.Size(73, 25);
            this.fieldCell_PlannedWorkingHoursPlanned.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PrintPlannedHours);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.fieldCell_Employee1,
            this.fieldCell_0000,
            this.fieldCell_PlannedHours});
            this.xrTableRow1.KeepTogether = false;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(990, 25);
            // 
            // fieldCell_Employee1
            // 
            this.fieldCell_Employee1.KeepTogether = true;
            this.fieldCell_Employee1.Location = new System.Drawing.Point(0, 0);
            this.fieldCell_Employee1.Name = "fieldCell_Employee1";
            this.fieldCell_Employee1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_Employee1.Size = new System.Drawing.Size(90, 25);
            // 
            // fieldCell_0000
            // 
            this.fieldCell_0000.KeepTogether = true;
            this.fieldCell_0000.Location = new System.Drawing.Point(90, 0);
            this.fieldCell_0000.Name = "fieldCell_0000";
            this.fieldCell_0000.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_0000.Size = new System.Drawing.Size(827, 25);
            this.fieldCell_0000.Text = "fieldCell_0000";
            this.fieldCell_0000.SizeChanged += new DevExpress.XtraReports.UI.ChangeEventHandler(this.CellSizeChanged);
            // 
            // fieldCell_PlannedHours
            // 
            this.fieldCell_PlannedHours.KeepTogether = true;
            this.fieldCell_PlannedHours.Location = new System.Drawing.Point(917, 0);
            this.fieldCell_PlannedHours.Name = "fieldCell_PlannedHours";
            this.fieldCell_PlannedHours.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_PlannedHours.Size = new System.Drawing.Size(73, 25);
            this.fieldCell_PlannedHours.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PrintActualHours);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbl_DailyCaption});
            this.PageHeader.Height = 50;
            this.PageHeader.Name = "PageHeader";
            // 
            // tbl_DailyCaption
            // 
            this.tbl_DailyCaption.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbl_DailyCaption.Location = new System.Drawing.Point(0, 0);
            this.tbl_DailyCaption.Name = "tbl_DailyCaption";
            this.tbl_DailyCaption.ParentStyleUsing.UseBorders = false;
            this.tbl_DailyCaption.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.row_DailyCaption});
            this.tbl_DailyCaption.Size = new System.Drawing.Size(990, 50);
            this.tbl_DailyCaption.StyleName = "styleFont";
            // 
            // row_DailyCaption
            // 
            this.row_DailyCaption.BackColor = System.Drawing.Color.Silver;
            this.row_DailyCaption.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lbCell_Employee,
            this.lbCell_0000,
            this.lbCell_AllreadyPlannedWorkingHours});
            this.row_DailyCaption.Name = "row_DailyCaption";
            this.row_DailyCaption.ParentStyleUsing.UseBackColor = false;
            this.row_DailyCaption.Size = new System.Drawing.Size(990, 50);
            // 
            // lbCell_Employee
            // 
            this.lbCell_Employee.Location = new System.Drawing.Point(0, 0);
            this.lbCell_Employee.Name = "lbCell_Employee";
            this.lbCell_Employee.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Employee.Size = new System.Drawing.Size(90, 50);
            this.lbCell_Employee.Text = "lbCell_Employee";
            this.lbCell_Employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbCell_0000
            // 
            this.lbCell_0000.Angle = 90F;
            this.lbCell_0000.Location = new System.Drawing.Point(90, 0);
            this.lbCell_0000.Name = "lbCell_0000";
            this.lbCell_0000.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_0000.Size = new System.Drawing.Size(827, 50);
            this.lbCell_0000.Text = "00:00";
            this.lbCell_0000.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_0000.WordWrap = false;
            // 
            // lbCell_AllreadyPlannedWorkingHours
            // 
            this.lbCell_AllreadyPlannedWorkingHours.Location = new System.Drawing.Point(917, 0);
            this.lbCell_AllreadyPlannedWorkingHours.Name = "lbCell_AllreadyPlannedWorkingHours";
            this.lbCell_AllreadyPlannedWorkingHours.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_AllreadyPlannedWorkingHours.Size = new System.Drawing.Size(73, 50);
            this.lbCell_AllreadyPlannedWorkingHours.Text = "lbCell_AllreadyPlannedWorkingHours";
            this.lbCell_AllreadyPlannedWorkingHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // styleFont
            // 
            this.styleFont.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.styleFont.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.styleFont.Name = "styleFont";
            // 
            // WorldsTimeRecordingDaily
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(118, 59, 79, 79);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.styleFont});
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRTable tbl_DailyCaption;
		private DevExpress.XtraReports.UI.XRTableRow row_DailyCaption;
		private DevExpress.XtraReports.UI.XRTableCell lbCell_Employee;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_0000;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_AllreadyPlannedWorkingHours;
		private DevExpress.XtraReports.UI.XRTable tbl_DailyData;
		private DevExpress.XtraReports.UI.XRTableRow row_DailyData;
		private DevExpress.XtraReports.UI.XRTableCell fieldCell_EmployeeName;
        private DevExpress.XtraReports.UI.XRTableCell fieldCell_0000Planned;
        private DevExpress.XtraReports.UI.XRTableCell fieldCell_PlannedWorkingHoursPlanned;
		private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
		private DevExpress.XtraReports.UI.XRTableCell fieldCell_Employee1;
		private DevExpress.XtraReports.UI.XRTableCell fieldCell_0000;
        private DevExpress.XtraReports.UI.XRTableCell fieldCell_PlannedHours;
        private DevExpress.XtraReports.UI.XRControlStyle styleFont;
	}
}
