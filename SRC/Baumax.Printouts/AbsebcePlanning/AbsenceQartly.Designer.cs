using DevExpress.XtraReports.UI;
namespace Baumax.Printouts.AbsebcePlanning
{
    partial class AbsenceQartly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbsenceQartly));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.tbDetail = new DevExpress.XtraReports.UI.XRTable();
            this.xrDetailRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.gc_Employee = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_OldHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_NewHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_AvailableHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_january = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_february = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_march = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_april = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_may = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_june = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_july = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_august = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_september = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_october = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_november = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_december = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_UsedHolidays = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_SpareHolidaysExc = new DevExpress.XtraReports.UI.XRTableCell();
            this.gc_SpareHolidaysInc = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tbHead = new DevExpress.XtraReports.UI.XRTable();
            this.xrRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xr_Employee = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_Old = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_New2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_Avail = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_january = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_february = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_march = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_april = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_may = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_june = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_july = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_august = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_september = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_october = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_november = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_december = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_Used = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_Excl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xr_Incl = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbDetail});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.Height = 24;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tbDetail
            // 
            this.tbDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbDetail.Dock = DevExpress.XtraReports.UI.XRDockStyle.Fill;
            resources.ApplyResources(this.tbDetail, "tbDetail");
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.ParentStyleUsing.UseBorders = false;
            this.tbDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrDetailRow});
            // 
            // xrDetailRow
            // 
            this.xrDetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.gc_Employee,
            this.gc_OldHolidays,
            this.gc_NewHolidays,
            this.gc_AvailableHolidays,
            this.gc_january,
            this.gc_february,
            this.gc_march,
            this.gc_april,
            this.gc_may,
            this.gc_june,
            this.gc_july,
            this.gc_august,
            this.gc_september,
            this.gc_october,
            this.gc_november,
            this.gc_december,
            this.gc_UsedHolidays,
            this.gc_SpareHolidaysExc,
            this.gc_SpareHolidaysInc});
            this.xrDetailRow.Name = "xrDetailRow";
            resources.ApplyResources(this.xrDetailRow, "xrDetailRow");
            // 
            // gc_Employee
            // 
            this.gc_Employee.KeepTogether = true;
            resources.ApplyResources(this.gc_Employee, "gc_Employee");
            this.gc_Employee.Multiline = true;
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_Employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // gc_OldHolidays
            // 
            resources.ApplyResources(this.gc_OldHolidays, "gc_OldHolidays");
            this.gc_OldHolidays.KeepTogether = true;
            this.gc_OldHolidays.Multiline = true;
            this.gc_OldHolidays.Name = "gc_OldHolidays";
            this.gc_OldHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.gc_OldHolidays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_NewHolidays
            // 
            resources.ApplyResources(this.gc_NewHolidays, "gc_NewHolidays");
            this.gc_NewHolidays.KeepTogether = true;
            this.gc_NewHolidays.Multiline = true;
            this.gc_NewHolidays.Name = "gc_NewHolidays";
            this.gc_NewHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.gc_NewHolidays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_AvailableHolidays
            // 
            resources.ApplyResources(this.gc_AvailableHolidays, "gc_AvailableHolidays");
            this.gc_AvailableHolidays.KeepTogether = true;
            this.gc_AvailableHolidays.Multiline = true;
            this.gc_AvailableHolidays.Name = "gc_AvailableHolidays";
            this.gc_AvailableHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.gc_AvailableHolidays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_january
            // 
            this.gc_january.KeepTogether = true;
            resources.ApplyResources(this.gc_january, "gc_january");
            this.gc_january.Multiline = true;
            this.gc_january.Name = "gc_january";
            this.gc_january.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_january.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_february
            // 
            this.gc_february.KeepTogether = true;
            resources.ApplyResources(this.gc_february, "gc_february");
            this.gc_february.Multiline = true;
            this.gc_february.Name = "gc_february";
            this.gc_february.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_february.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_march
            // 
            this.gc_march.KeepTogether = true;
            resources.ApplyResources(this.gc_march, "gc_march");
            this.gc_march.Multiline = true;
            this.gc_march.Name = "gc_march";
            this.gc_march.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_march.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_april
            // 
            this.gc_april.KeepTogether = true;
            resources.ApplyResources(this.gc_april, "gc_april");
            this.gc_april.Multiline = true;
            this.gc_april.Name = "gc_april";
            this.gc_april.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_april.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_may
            // 
            this.gc_may.KeepTogether = true;
            resources.ApplyResources(this.gc_may, "gc_may");
            this.gc_may.Multiline = true;
            this.gc_may.Name = "gc_may";
            this.gc_may.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_may.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_june
            // 
            this.gc_june.KeepTogether = true;
            resources.ApplyResources(this.gc_june, "gc_june");
            this.gc_june.Multiline = true;
            this.gc_june.Name = "gc_june";
            this.gc_june.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_june.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_july
            // 
            this.gc_july.KeepTogether = true;
            resources.ApplyResources(this.gc_july, "gc_july");
            this.gc_july.Multiline = true;
            this.gc_july.Name = "gc_july";
            this.gc_july.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_july.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_august
            // 
            this.gc_august.KeepTogether = true;
            resources.ApplyResources(this.gc_august, "gc_august");
            this.gc_august.Multiline = true;
            this.gc_august.Name = "gc_august";
            this.gc_august.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_august.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_september
            // 
            this.gc_september.KeepTogether = true;
            resources.ApplyResources(this.gc_september, "gc_september");
            this.gc_september.Multiline = true;
            this.gc_september.Name = "gc_september";
            this.gc_september.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_september.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_october
            // 
            this.gc_october.KeepTogether = true;
            resources.ApplyResources(this.gc_october, "gc_october");
            this.gc_october.Multiline = true;
            this.gc_october.Name = "gc_october";
            this.gc_october.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_october.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_november
            // 
            this.gc_november.KeepTogether = true;
            resources.ApplyResources(this.gc_november, "gc_november");
            this.gc_november.Multiline = true;
            this.gc_november.Name = "gc_november";
            this.gc_november.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_november.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_december
            // 
            this.gc_december.KeepTogether = true;
            resources.ApplyResources(this.gc_december, "gc_december");
            this.gc_december.Multiline = true;
            this.gc_december.Name = "gc_december";
            this.gc_december.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gc_december.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_UsedHolidays
            // 
            resources.ApplyResources(this.gc_UsedHolidays, "gc_UsedHolidays");
            this.gc_UsedHolidays.KeepTogether = true;
            this.gc_UsedHolidays.Multiline = true;
            this.gc_UsedHolidays.Name = "gc_UsedHolidays";
            this.gc_UsedHolidays.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.gc_UsedHolidays.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_SpareHolidaysExc
            // 
            resources.ApplyResources(this.gc_SpareHolidaysExc, "gc_SpareHolidaysExc");
            this.gc_SpareHolidaysExc.KeepTogether = true;
            this.gc_SpareHolidaysExc.Multiline = true;
            this.gc_SpareHolidaysExc.Name = "gc_SpareHolidaysExc";
            this.gc_SpareHolidaysExc.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.gc_SpareHolidaysExc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // gc_SpareHolidaysInc
            // 
            resources.ApplyResources(this.gc_SpareHolidaysInc, "gc_SpareHolidaysInc");
            this.gc_SpareHolidaysInc.KeepTogether = true;
            this.gc_SpareHolidaysInc.Multiline = true;
            this.gc_SpareHolidaysInc.Name = "gc_SpareHolidaysInc";
            this.gc_SpareHolidaysInc.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.gc_SpareHolidaysInc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbHead});
            this.PageHeader.Height = 29;
            this.PageHeader.Name = "PageHeader";
            // 
            // tbHead
            // 
            resources.ApplyResources(this.tbHead, "tbHead");
            this.tbHead.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tbHead.Dock = DevExpress.XtraReports.UI.XRDockStyle.Fill;
            this.tbHead.Name = "tbHead";
            this.tbHead.ParentStyleUsing.UseBackColor = false;
            this.tbHead.ParentStyleUsing.UseBorders = false;
            this.tbHead.ParentStyleUsing.UseFont = false;
            this.tbHead.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrRow1});
            this.tbHead.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrRow1
            // 
            this.xrRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xr_Employee,
            this.xr_Old,
            this.xr_New2,
            this.xr_Avail,
            this.xr_january,
            this.xr_february,
            this.xr_march,
            this.xr_april,
            this.xr_may,
            this.xr_june,
            this.xr_july,
            this.xr_august,
            this.xr_september,
            this.xr_october,
            this.xr_november,
            this.xr_december,
            this.xr_Used,
            this.xr_Excl,
            this.xr_Incl});
            this.xrRow1.Name = "xrRow1";
            resources.ApplyResources(this.xrRow1, "xrRow1");
            // 
            // xr_Employee
            // 
            resources.ApplyResources(this.xr_Employee, "xr_Employee");
            this.xr_Employee.Name = "xr_Employee";
            this.xr_Employee.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_Employee.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xr_Old
            // 
            resources.ApplyResources(this.xr_Old, "xr_Old");
            this.xr_Old.Name = "xr_Old";
            this.xr_Old.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.xr_Old.ParentStyleUsing.UseFont = false;
            this.xr_Old.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_New2
            // 
            resources.ApplyResources(this.xr_New2, "xr_New2");
            this.xr_New2.Name = "xr_New2";
            this.xr_New2.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.xr_New2.ParentStyleUsing.UseFont = false;
            this.xr_New2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_Avail
            // 
            resources.ApplyResources(this.xr_Avail, "xr_Avail");
            this.xr_Avail.Name = "xr_Avail";
            this.xr_Avail.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.xr_Avail.ParentStyleUsing.UseFont = false;
            this.xr_Avail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_january
            // 
            resources.ApplyResources(this.xr_january, "xr_january");
            this.xr_january.Name = "xr_january";
            this.xr_january.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_january.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_february
            // 
            resources.ApplyResources(this.xr_february, "xr_february");
            this.xr_february.Name = "xr_february";
            this.xr_february.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_february.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_march
            // 
            resources.ApplyResources(this.xr_march, "xr_march");
            this.xr_march.Name = "xr_march";
            this.xr_march.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_march.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_april
            // 
            resources.ApplyResources(this.xr_april, "xr_april");
            this.xr_april.Name = "xr_april";
            this.xr_april.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_april.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_may
            // 
            resources.ApplyResources(this.xr_may, "xr_may");
            this.xr_may.Name = "xr_may";
            this.xr_may.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_may.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_june
            // 
            resources.ApplyResources(this.xr_june, "xr_june");
            this.xr_june.Name = "xr_june";
            this.xr_june.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_june.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_july
            // 
            resources.ApplyResources(this.xr_july, "xr_july");
            this.xr_july.Name = "xr_july";
            this.xr_july.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_july.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_august
            // 
            resources.ApplyResources(this.xr_august, "xr_august");
            this.xr_august.Name = "xr_august";
            this.xr_august.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_august.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_september
            // 
            resources.ApplyResources(this.xr_september, "xr_september");
            this.xr_september.Name = "xr_september";
            this.xr_september.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_september.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_october
            // 
            resources.ApplyResources(this.xr_october, "xr_october");
            this.xr_october.Name = "xr_october";
            this.xr_october.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_october.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_november
            // 
            resources.ApplyResources(this.xr_november, "xr_november");
            this.xr_november.Name = "xr_november";
            this.xr_november.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_november.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_december
            // 
            resources.ApplyResources(this.xr_december, "xr_december");
            this.xr_december.Name = "xr_december";
            this.xr_december.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xr_december.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_Used
            // 
            resources.ApplyResources(this.xr_Used, "xr_Used");
            this.xr_Used.Name = "xr_Used";
            this.xr_Used.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.xr_Used.ParentStyleUsing.UseFont = false;
            this.xr_Used.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_Excl
            // 
            resources.ApplyResources(this.xr_Excl, "xr_Excl");
            this.xr_Excl.Name = "xr_Excl";
            this.xr_Excl.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.xr_Excl.ParentStyleUsing.UseFont = false;
            this.xr_Excl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xr_Incl
            // 
            resources.ApplyResources(this.xr_Incl, "xr_Incl");
            this.xr_Incl.Name = "xr_Incl";
            this.xr_Incl.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 1, 0, 0, 100F);
            this.xr_Incl.ParentStyleUsing.UseFont = false;
            this.xr_Incl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.Name = "xrControlStyle1";
            // 
            // AbsenceQartly
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(118, 59, 79, 78);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            ((System.ComponentModel.ISupportInitialize)(this.tbDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        public DevExpress.XtraReports.UI.XRTable tbHead;
        public DevExpress.XtraReports.UI.XRTable tbDetail;
        public XRTableRow xrDetailRow;
        public XRTableRow xrRow1;
        public XRTableCell xr_january;
        public XRTableCell xr_august;
        public XRTableCell xr_Incl;
        public XRTableCell xr_Employee;
        public XRTableCell xr_Old;
        public XRTableCell xr_New2;
        public XRTableCell xr_Avail;
        public XRTableCell xr_february;
        public XRTableCell xr_march;
        public XRTableCell xr_april;
        public XRTableCell xr_may;
        public XRTableCell xr_june;
        public XRTableCell xr_july;
        public XRTableCell xr_september;
        public XRTableCell xr_october;
        public XRTableCell xr_november;
        public XRTableCell xr_december;
        public XRTableCell xr_Used;
        public XRTableCell xr_Excl;
        public XRTableCell gc_Employee;
        public XRTableCell gc_OldHolidays;
        public XRTableCell gc_NewHolidays;
        public XRTableCell gc_AvailableHolidays;
        public XRTableCell gc_january;
        public XRTableCell gc_february;
        public XRTableCell gc_march;
        public XRTableCell gc_april;
        public XRTableCell gc_may;
        public XRTableCell gc_june;
        public XRTableCell gc_july;
        public XRTableCell gc_august;
        public XRTableCell gc_september;
        public XRTableCell gc_october;
        public XRTableCell gc_november;
        public XRTableCell gc_december;
        public XRTableCell gc_UsedHolidays;
        public XRTableCell gc_SpareHolidaysExc;
        public XRTableCell gc_SpareHolidaysInc;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private XRControlStyle xrControlStyle1;

    }
}
