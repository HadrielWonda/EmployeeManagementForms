namespace Baumax.Printouts.ManpowerTimePlanning
{
	partial class TimePlanningDaily
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
            this.fieldCell_0000 = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldCell_PlannedWorkingHours = new DevExpress.XtraReports.UI.XRTableCell();
            this.tbl_DailyCaption = new DevExpress.XtraReports.UI.XRTable();
            this.row_DailyCaption = new DevExpress.XtraReports.UI.XRTableRow();
            this.lbCell_Employee = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_0000 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_AllreadyPlannedWorkingHours = new DevExpress.XtraReports.UI.XRTableCell();
            this.TextGeneral = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TextFeast = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TextClosedDay = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TextAnotherWorld = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TextCell = new DevExpress.XtraReports.UI.XRControlStyle();
            this.CellClosedTime = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbl_DailyData});
            this.Detail.Height = 25;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.PrintOnEmptyDataSource = false;
            // 
            // tbl_DailyData
            // 
            this.tbl_DailyData.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbl_DailyData.Dock = DevExpress.XtraReports.UI.XRDockStyle.Top;
            this.tbl_DailyData.Location = new System.Drawing.Point(0, 0);
            this.tbl_DailyData.Name = "tbl_DailyData";
            this.tbl_DailyData.ParentStyleUsing.UseBorders = false;
            this.tbl_DailyData.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.row_DailyData});
            this.tbl_DailyData.Size = new System.Drawing.Size(990, 25);
            // 
            // row_DailyData
            // 
            this.row_DailyData.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.fieldCell_EmployeeName,
            this.fieldCell_0000,
            this.fieldCell_PlannedWorkingHours});
            this.row_DailyData.Name = "row_DailyData";
            this.row_DailyData.Size = new System.Drawing.Size(990, 25);
            // 
            // fieldCell_EmployeeName
            // 
            this.fieldCell_EmployeeName.Location = new System.Drawing.Point(0, 0);
            this.fieldCell_EmployeeName.Name = "fieldCell_EmployeeName";
            this.fieldCell_EmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_EmployeeName.Size = new System.Drawing.Size(90, 25);
            // 
            // fieldCell_0000
            // 
            this.fieldCell_0000.Location = new System.Drawing.Point(90, 0);
            this.fieldCell_0000.Name = "fieldCell_0000";
            this.fieldCell_0000.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_0000.Size = new System.Drawing.Size(835, 25);
            this.fieldCell_0000.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PrintTimeCell);
            // 
            // fieldCell_PlannedWorkingHours
            // 
            this.fieldCell_PlannedWorkingHours.Location = new System.Drawing.Point(925, 0);
            this.fieldCell_PlannedWorkingHours.Name = "fieldCell_PlannedWorkingHours";
            this.fieldCell_PlannedWorkingHours.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_PlannedWorkingHours.Size = new System.Drawing.Size(65, 25);
            this.fieldCell_PlannedWorkingHours.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PrintSummaryColumn);
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
            this.lbCell_0000.Size = new System.Drawing.Size(835, 50);
            this.lbCell_0000.Text = "00:00";
            this.lbCell_0000.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_0000.WordWrap = false;
            // 
            // lbCell_AllreadyPlannedWorkingHours
            // 
            this.lbCell_AllreadyPlannedWorkingHours.Location = new System.Drawing.Point(925, 0);
            this.lbCell_AllreadyPlannedWorkingHours.Name = "lbCell_AllreadyPlannedWorkingHours";
            this.lbCell_AllreadyPlannedWorkingHours.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_AllreadyPlannedWorkingHours.Size = new System.Drawing.Size(65, 50);
            this.lbCell_AllreadyPlannedWorkingHours.Text = "lbCell_AllreadyPlannedWorkingHours";
            this.lbCell_AllreadyPlannedWorkingHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TextGeneral
            // 
            this.TextGeneral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextGeneral.Name = "TextGeneral";
            // 
            // TextFeast
            // 
            this.TextFeast.BackColor = System.Drawing.Color.LightGreen;
            this.TextFeast.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TextFeast.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextFeast.Name = "TextFeast";
            // 
            // TextClosedDay
            // 
            this.TextClosedDay.BackColor = System.Drawing.Color.LightGray;
            this.TextClosedDay.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TextClosedDay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextClosedDay.Name = "TextClosedDay";
            // 
            // TextAnotherWorld
            // 
            this.TextAnotherWorld.BackColor = System.Drawing.Color.Gray;
            this.TextAnotherWorld.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TextAnotherWorld.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextAnotherWorld.Name = "TextAnotherWorld";
            // 
            // TextCell
            // 
            this.TextCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.TextCell.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextCell.Name = "TextCell";
            // 
            // CellClosedTime
            // 
            this.CellClosedTime.BackColor = System.Drawing.Color.LightGray;
            this.CellClosedTime.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.CellClosedTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CellClosedTime.Name = "CellClosedTime";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbl_DailyCaption});
            this.PageHeader.Height = 50;
            this.PageHeader.Name = "PageHeader";
            // 
            // TimePlanningDaily
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(118, 59, 79, 79);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.TextGeneral,
            this.TextFeast,
            this.TextClosedDay,
            this.TextAnotherWorld,
            this.TextCell,
            this.CellClosedTime});
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DailyCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRTable tbl_DailyCaption;
		private DevExpress.XtraReports.UI.XRTableRow row_DailyCaption;
		private DevExpress.XtraReports.UI.XRTableCell lbCell_Employee;
		private DevExpress.XtraReports.UI.XRTableCell lbCell_0000;
		private DevExpress.XtraReports.UI.XRTable tbl_DailyData;
		private DevExpress.XtraReports.UI.XRTableRow row_DailyData;
		private DevExpress.XtraReports.UI.XRTableCell fieldCell_EmployeeName;
		private DevExpress.XtraReports.UI.XRTableCell fieldCell_0000;
		private DevExpress.XtraReports.UI.XRControlStyle TextGeneral;
		private DevExpress.XtraReports.UI.XRControlStyle TextFeast;
		private DevExpress.XtraReports.UI.XRControlStyle TextClosedDay;
		private DevExpress.XtraReports.UI.XRControlStyle TextAnotherWorld;
		private DevExpress.XtraReports.UI.XRControlStyle TextCell;
        private DevExpress.XtraReports.UI.XRControlStyle CellClosedTime;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_AllreadyPlannedWorkingHours;
        private DevExpress.XtraReports.UI.XRTableCell fieldCell_PlannedWorkingHours;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
	}
}
