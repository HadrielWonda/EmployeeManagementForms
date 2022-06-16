using DevExpress.XtraReports.UI;
namespace Baumax.Printouts.AbsebcePlanning
{
	partial class AbsencePlanningPrintout
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
            this.xrSubreport = new DevExpress.XtraReports.UI.XRSubreport();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tbHead = new DevExpress.XtraReports.UI.XRTable();
            this.rwHead = new DevExpress.XtraReports.UI.XRTableRow();
            this.fieldStore = new DevExpress.XtraReports.UI.XRTableCell();
            this.tc_World = new DevExpress.XtraReports.UI.XRTableCell();
            this.fieldWorld = new DevExpress.XtraReports.UI.XRTableCell();
            this.tc_TimeRange = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbl_AbsencePlanning = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.BottomMargin1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.headStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.tbHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport});
            this.Detail.Height = 39;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseFont = false;
            // 
            // xrSubreport
            // 
            this.xrSubreport.Location = new System.Drawing.Point(0, 0);
            this.xrSubreport.Name = "xrSubreport";
            this.xrSubreport.Size = new System.Drawing.Size(100, 25);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tbHead,
            this.lbl_AbsencePlanning});
            this.PageHeader.Height = 63;
            this.PageHeader.Name = "PageHeader";
            // 
            // tbHead
            // 
            this.tbHead.Location = new System.Drawing.Point(0, 33);
            this.tbHead.Name = "tbHead";
            this.tbHead.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.rwHead});
            this.tbHead.Size = new System.Drawing.Size(1475, 29);
            // 
            // rwHead
            // 
            this.rwHead.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.fieldStore,
            this.tc_World,
            this.fieldWorld,
            this.tc_TimeRange});
            this.rwHead.Name = "rwHead";
            this.rwHead.Size = new System.Drawing.Size(1475, 29);
            // 
            // fieldStore
            // 
            this.fieldStore.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fieldStore.Location = new System.Drawing.Point(0, 0);
            this.fieldStore.Name = "fieldStore";
            this.fieldStore.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldStore.ParentStyleUsing.UseFont = false;
            this.fieldStore.Size = new System.Drawing.Size(400, 29);
            this.fieldStore.StyleName = "headStyle";
            this.fieldStore.Text = "fieldStore";
            this.fieldStore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.fieldStore.WordWrap = false;
            // 
            // tc_World
            // 
            this.tc_World.Location = new System.Drawing.Point(400, 0);
            this.tc_World.Name = "tc_World";
            this.tc_World.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 6, 0, 0, 100F);
            this.tc_World.Size = new System.Drawing.Size(133, 29);
            this.tc_World.StyleName = "headStyle";
            this.tc_World.Text = "World";
            this.tc_World.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // fieldWorld
            // 
            this.fieldWorld.Location = new System.Drawing.Point(533, 0);
            this.fieldWorld.Name = "fieldWorld";
            this.fieldWorld.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fieldWorld.Size = new System.Drawing.Size(375, 29);
            this.fieldWorld.StyleName = "headStyle";
            this.fieldWorld.Text = "fieldWorld";
            this.fieldWorld.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tc_TimeRange
            // 
            this.tc_TimeRange.Location = new System.Drawing.Point(908, 0);
            this.tc_TimeRange.Name = "tc_TimeRange";
            this.tc_TimeRange.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 10, 0, 0, 100F);
            this.tc_TimeRange.Size = new System.Drawing.Size(567, 29);
            this.tc_TimeRange.StyleName = "headStyle";
            this.tc_TimeRange.Text = "Time range";
            this.tc_TimeRange.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tc_TimeRange.WordWrap = false;
            // 
            // lbl_AbsencePlanning
            // 
            this.lbl_AbsencePlanning.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_AbsencePlanning.Location = new System.Drawing.Point(0, 0);
            this.lbl_AbsencePlanning.Name = "lbl_AbsencePlanning";
            this.lbl_AbsencePlanning.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_AbsencePlanning.ParentStyleUsing.UseFont = false;
            this.lbl_AbsencePlanning.Size = new System.Drawing.Size(1475, 33);
            this.lbl_AbsencePlanning.Text = "Absence planning";
            this.lbl_AbsencePlanning.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // BottomMargin1
            // 
            this.BottomMargin1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin1.Height = 79;
            this.BottomMargin1.Name = "BottomMargin1";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xrPageInfo2.Location = new System.Drawing.Point(758, 0);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 7, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.Number;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(224, 25);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 0);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(450, 25);
            // 
            // headStyle
            // 
            this.headStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.headStyle.Name = "headStyle";
            this.headStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // AbsencePlanningPrintout
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.BottomMargin1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(118, 59, 79, 79);
            this.PageHeight = 1169;
            this.PageWidth = 1654;
            this.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.headStyle});
            ((System.ComponentModel.ISupportInitialize)(this.tbHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

        public DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        public DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.BottomMarginBand BottomMargin1;
        public DevExpress.XtraReports.UI.XRLabel lbl_AbsencePlanning;
        public XRTableCell tc_TimeRange;
        public XRSubreport xrSubreport;

        public DevExpress.XtraReports.UI.XRTable tbHead;
        public DevExpress.XtraReports.UI.XRTableRow rwHead;

        public DevExpress.XtraReports.UI.XRTableCell fieldStore;
        public DevExpress.XtraReports.UI.XRControlStyle headStyle;

        public DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        public DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private XRTableCell tc_World;
        private XRTableCell fieldWorld;
	}
}
