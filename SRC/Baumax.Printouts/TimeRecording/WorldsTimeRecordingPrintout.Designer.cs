namespace Baumax.Printouts.TimeRecording
{
	partial class WorldsTimeRecordingPrintout
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
            this.subreportDetails = new DevExpress.XtraReports.UI.XRSubreport();
            this.field_WorldName = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tlb_StoreCaption = new DevExpress.XtraReports.UI.XRTable();
            this.row_StoreCaption = new DevExpress.XtraReports.UI.XRTableRow();
            this.lbCell_Store = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldCell_Store = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCell_TimeRange = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_TimeRecording = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageInfo_PageNr = new DevExpress.XtraReports.UI.XRPageInfo();
            this.pageInfo_Date = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.tlb_StoreCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subreportDetails,
            this.field_WorldName});
            this.Detail.Height = 56;
            this.Detail.Name = "Detail";
            // 
            // subreportDetails
            // 
            this.subreportDetails.Location = new System.Drawing.Point(0, 31);
            this.subreportDetails.Name = "subreportDetails";
            this.subreportDetails.Size = new System.Drawing.Size(100, 25);
            this.subreportDetails.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.subreportDetails_BeforePrint);
            // 
            // field_WorldName
            // 
            this.field_WorldName.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.field_WorldName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.field_WorldName.Location = new System.Drawing.Point(0, 15);
            this.field_WorldName.Name = "field_WorldName";
            this.field_WorldName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.field_WorldName.ParentStyleUsing.UseBackColor = false;
            this.field_WorldName.ParentStyleUsing.UseFont = false;
            this.field_WorldName.Size = new System.Drawing.Size(992, 17);
            this.field_WorldName.Text = "field_WorldName";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tlb_StoreCaption,
            this.lbl_TimeRecording});
            this.PageHeader.Height = 58;
            this.PageHeader.KeepTogether = true;
            this.PageHeader.Name = "PageHeader";
            // 
            // tlb_StoreCaption
            // 
            this.tlb_StoreCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlb_StoreCaption.Location = new System.Drawing.Point(0, 33);
            this.tlb_StoreCaption.Name = "tlb_StoreCaption";
            this.tlb_StoreCaption.ParentStyleUsing.UseFont = false;
            this.tlb_StoreCaption.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.row_StoreCaption});
            this.tlb_StoreCaption.Size = new System.Drawing.Size(992, 25);
            // 
            // row_StoreCaption
            // 
            this.row_StoreCaption.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lbCell_Store,
            this.fieldCell_Store,
            this.lbCell_TimeRange});
            this.row_StoreCaption.Name = "row_StoreCaption";
            this.row_StoreCaption.Size = new System.Drawing.Size(992, 25);
            this.row_StoreCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCell_Store
            // 
            this.lbCell_Store.Location = new System.Drawing.Point(0, 0);
            this.lbCell_Store.Name = "lbCell_Store";
            this.lbCell_Store.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCell_Store.Size = new System.Drawing.Size(117, 25);
            this.lbCell_Store.Text = "Store";
            this.lbCell_Store.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fieldCell_Store
            // 
            this.fieldCell_Store.Location = new System.Drawing.Point(117, 0);
            this.fieldCell_Store.Name = "fieldCell_Store";
            this.fieldCell_Store.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldCell_Store.Size = new System.Drawing.Size(488, 25);
            this.fieldCell_Store.Text = "fieldCell_Store";
            this.fieldCell_Store.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCell_TimeRange
            // 
            this.lbCell_TimeRange.Location = new System.Drawing.Point(605, 0);
            this.lbCell_TimeRange.Name = "lbCell_TimeRange";
            this.lbCell_TimeRange.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 7, 0, 0, 100F);
            this.lbCell_TimeRange.Size = new System.Drawing.Size(387, 25);
            this.lbCell_TimeRange.Text = "lbCell_TimeRange";
            this.lbCell_TimeRange.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lbl_TimeRecording
            // 
            this.lbl_TimeRecording.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_TimeRecording.Location = new System.Drawing.Point(0, 0);
            this.lbl_TimeRecording.Name = "lbl_TimeRecording";
            this.lbl_TimeRecording.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_TimeRecording.ParentStyleUsing.UseFont = false;
            this.lbl_TimeRecording.Size = new System.Drawing.Size(992, 33);
            this.lbl_TimeRecording.Text = "Time recording";
            this.lbl_TimeRecording.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo_PageNr,
            this.pageInfo_Date});
            this.BottomMargin.Height = 79;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // pageInfo_PageNr
            // 
            this.pageInfo_PageNr.Location = new System.Drawing.Point(525, 0);
            this.pageInfo_PageNr.Name = "pageInfo_PageNr";
            this.pageInfo_PageNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageInfo_PageNr.Size = new System.Drawing.Size(467, 25);
            this.pageInfo_PageNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // pageInfo_Date
            // 
            this.pageInfo_Date.Location = new System.Drawing.Point(0, 0);
            this.pageInfo_Date.Name = "pageInfo_Date";
            this.pageInfo_Date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageInfo_Date.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo_Date.Size = new System.Drawing.Size(500, 25);
            // 
            // WorldsTimeRecordingPrintout
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.BottomMargin});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(118, 59, 79, 79);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.tlb_StoreCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel lbl_TimeRecording;
		private DevExpress.XtraReports.UI.XRTable tlb_StoreCaption;
		private DevExpress.XtraReports.UI.XRTableRow row_StoreCaption;
		private DevExpress.XtraReports.UI.XRTableCell lbCell_Store;
        private DevExpress.XtraReports.UI.XRTableCell fieldCell_Store;
		private DevExpress.XtraReports.UI.XRLabel field_WorldName;
		private DevExpress.XtraReports.UI.XRSubreport subreportDetails;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.XRPageInfo pageInfo_PageNr;
		private DevExpress.XtraReports.UI.XRPageInfo pageInfo_Date;
        private DevExpress.XtraReports.UI.XRTableCell lbCell_TimeRange;
	}
}
