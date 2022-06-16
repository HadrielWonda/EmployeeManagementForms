namespace Baumax.Printouts
{
    partial class AbsenceWeekly
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tbl_DetailsCaption = new DevExpress.XtraReports.UI.XRTable();
            this.row_DetailsHeader = new DevExpress.XtraReports.UI.XRTableRow();
            this.lbCell_Employee = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_OldHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_NewHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_AvailableHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Monday = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Tuesday = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Wednesday = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Thursday = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Friday = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Saturday = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_Sunday = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_UsedHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_SpareHolidaysExc = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_SpareHolidaysInc = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DetailsCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbl_DetailsCaption});
            this.PageHeader.Height = 44;
            this.PageHeader.Name = "PageHeader";
            // 
            // tbl_DetailsCaption
            // 
            this.tbl_DetailsCaption.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbl_DetailsCaption.Location = new System.Drawing.Point(0, 0);
            this.tbl_DetailsCaption.Name = "tbl_DetailsCaption";
            this.tbl_DetailsCaption.ParentStyleUsing.UseBorders = false;
            this.tbl_DetailsCaption.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.row_DetailsHeader});
            this.tbl_DetailsCaption.Size = new System.Drawing.Size(991, 42);
            // 
            // row_DetailsHeader
            // 
            this.row_DetailsHeader.BackColor = System.Drawing.Color.Silver;
            this.row_DetailsHeader.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lbCell_Employee,
            this.xr_OldHolidays,
            this.xr_NewHolidays,
            this.xr_AvailableHolidays,
            this.lbCell_Monday,
            this.lbCell_Tuesday,
            this.lbCell_Wednesday,
            this.lbCell_Thursday,
            this.lbCell_Friday,
            this.lbCell_Saturday,
            this.lbCell_Sunday,
            this.gc_UsedHolidays,
            this.xr_SpareHolidaysExc,
            this.xr_SpareHolidaysInc});
            this.row_DetailsHeader.Name = "row_DetailsHeader";
            this.row_DetailsHeader.ParentStyleUsing.UseBackColor = false;
            this.row_DetailsHeader.Size = new System.Drawing.Size(991, 42);
            // 
            // lbCell_Employee
            // 
            this.lbCell_Employee.Location = new System.Drawing.Point(0, 0);
            this.lbCell_Employee.Multiline = true;
            this.lbCell_Employee.Name = "lbCell_Employee";
            this.lbCell_Employee.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Employee.Size = new System.Drawing.Size(160, 42);
            this.lbCell_Employee.Text = "Employee";
            this.lbCell_Employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Employee.WordWrap = false;
            // 
            // xr_OldHolidays
            // 
            this.xr_OldHolidays.Location = new System.Drawing.Point(160, 0);
            this.xr_OldHolidays.Name = "xr_OldHolidays";
            this.xr_OldHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_OldHolidays.Size = new System.Drawing.Size(40, 42);
            this.xr_OldHolidays.Text = "Old Holidays";
            // 
            // xr_NewHolidays
            // 
            this.xr_NewHolidays.Location = new System.Drawing.Point(200, 0);
            this.xr_NewHolidays.Name = "xr_NewHolidays";
            this.xr_NewHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_NewHolidays.Size = new System.Drawing.Size(40, 42);
            this.xr_NewHolidays.Text = "New Holidays";
            // 
            // xr_AvailableHolidays
            // 
            this.xr_AvailableHolidays.Location = new System.Drawing.Point(240, 0);
            this.xr_AvailableHolidays.Name = "xr_AvailableHolidays";
            this.xr_AvailableHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_AvailableHolidays.Size = new System.Drawing.Size(40, 42);
            this.xr_AvailableHolidays.Text = "Available Holidays";
            // 
            // lbCell_Monday
            // 
            this.lbCell_Monday.Location = new System.Drawing.Point(280, 0);
            this.lbCell_Monday.Multiline = true;
            this.lbCell_Monday.Name = "lbCell_Monday";
            this.lbCell_Monday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Monday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Monday.Text = "Monday";
            this.lbCell_Monday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Monday.WordWrap = false;
            // 
            // lbCell_Tuesday
            // 
            this.lbCell_Tuesday.Location = new System.Drawing.Point(364, 0);
            this.lbCell_Tuesday.Multiline = true;
            this.lbCell_Tuesday.Name = "lbCell_Tuesday";
            this.lbCell_Tuesday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Tuesday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Tuesday.Text = "Tuesday";
            this.lbCell_Tuesday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Tuesday.WordWrap = false;
            // 
            // lbCell_Wednesday
            // 
            this.lbCell_Wednesday.Location = new System.Drawing.Point(448, 0);
            this.lbCell_Wednesday.Multiline = true;
            this.lbCell_Wednesday.Name = "lbCell_Wednesday";
            this.lbCell_Wednesday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Wednesday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Wednesday.Text = "Wednesday";
            this.lbCell_Wednesday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Wednesday.WordWrap = false;
            // 
            // lbCell_Thursday
            // 
            this.lbCell_Thursday.Location = new System.Drawing.Point(532, 0);
            this.lbCell_Thursday.Multiline = true;
            this.lbCell_Thursday.Name = "lbCell_Thursday";
            this.lbCell_Thursday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Thursday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Thursday.Text = "Thursday";
            this.lbCell_Thursday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Thursday.WordWrap = false;
            // 
            // lbCell_Friday
            // 
            this.lbCell_Friday.Location = new System.Drawing.Point(616, 0);
            this.lbCell_Friday.Multiline = true;
            this.lbCell_Friday.Name = "lbCell_Friday";
            this.lbCell_Friday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Friday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Friday.Text = "Friday";
            this.lbCell_Friday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Friday.WordWrap = false;
            // 
            // lbCell_Saturday
            // 
            this.lbCell_Saturday.Location = new System.Drawing.Point(700, 0);
            this.lbCell_Saturday.Multiline = true;
            this.lbCell_Saturday.Name = "lbCell_Saturday";
            this.lbCell_Saturday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Saturday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Saturday.Text = "Saturday";
            this.lbCell_Saturday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Saturday.WordWrap = false;
            // 
            // lbCell_Sunday
            // 
            this.lbCell_Sunday.Location = new System.Drawing.Point(784, 0);
            this.lbCell_Sunday.Multiline = true;
            this.lbCell_Sunday.Name = "lbCell_Sunday";
            this.lbCell_Sunday.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Sunday.Size = new System.Drawing.Size(84, 42);
            this.lbCell_Sunday.Text = "Sunday";
            this.lbCell_Sunday.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lbCell_Sunday.WordWrap = false;
            // 
            // gc_UsedHolidays
            // 
            this.gc_UsedHolidays.Location = new System.Drawing.Point(868, 0);
            this.gc_UsedHolidays.Name = "gc_UsedHolidays";
            this.gc_UsedHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_UsedHolidays.Size = new System.Drawing.Size(40, 42);
            this.gc_UsedHolidays.Text = "Used Holidays";
            // 
            // xr_SpareHolidaysExc
            // 
            this.xr_SpareHolidaysExc.Location = new System.Drawing.Point(908, 0);
            this.xr_SpareHolidaysExc.Name = "xr_SpareHolidaysExc";
            this.xr_SpareHolidaysExc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_SpareHolidaysExc.Size = new System.Drawing.Size(40, 42);
            this.xr_SpareHolidaysExc.Text = "Spare Holidays Exc";
            // 
            // xr_SpareHolidaysInc
            // 
            this.xr_SpareHolidaysInc.Location = new System.Drawing.Point(948, 0);
            this.xr_SpareHolidaysInc.Name = "xr_SpareHolidaysInc";
            this.xr_SpareHolidaysInc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_SpareHolidaysInc.Size = new System.Drawing.Size(43, 42);
            this.xr_SpareHolidaysInc.Text = "Spare Holidays Inc";
            // 
            // Detail
            // 
            this.Detail.Name = "Detail";
            // 
            // AbsenceWeekly
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.PageHeader,
            this.Detail});
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.PageHeight = 1654;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            ((System.ComponentModel.ISupportInitialize)(this.tbl_DetailsCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable tbl_DetailsCaption;
        private DevExpress.XtraReports.UI.XRTableRow row_DetailsHeader;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Employee;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Monday;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Tuesday;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Wednesday;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Thursday;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Friday;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Saturday;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_Sunday;
        private DevExpress.XtraReports.UI.XRTableCell xr_OldHolidays;
        private DevExpress.XtraReports.UI.XRTableCell xr_NewHolidays;
        private DevExpress.XtraReports.UI.XRTableCell xr_AvailableHolidays;
        private DevExpress.XtraReports.UI.XRTableCell gc_UsedHolidays;
        private DevExpress.XtraReports.UI.XRTableCell xr_SpareHolidaysExc;
        private DevExpress.XtraReports.UI.XRTableCell xr_SpareHolidaysInc;
    }
}