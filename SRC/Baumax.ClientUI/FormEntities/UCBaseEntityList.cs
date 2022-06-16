using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities
{
    public partial class UCBaseEntityList : UCBaseEntity
    {
        public UCBaseEntityList()
        {
            InitializeComponent();
        }

        public UCBaseEntityList(Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = (GridHitInfo) gridControl.FocusedView.CalcHitInfo(e.Location);
            if ((hitInfo.InRow && hitInfo.RowHandle != GridControl.InvalidRowHandle) && (EditEnabled))
            {
                Edit();
            }
        }

        protected void AddGridColumns(string[] fieldNames, string[] captions)
        {
            if( (fieldNames == null) || (captions == null) || (fieldNames.Length != captions.Length))
            {
                // todo? inherit exception class?
                Exception ex = new ApplicationException("AddGridColumns: invalid parameters");
                ex.Data.Add("fieldNames", fieldNames);
                ex.Data.Add("captions", captions);
                throw ex;
            }
            if(fieldNames.Length == 0)
            {
                return; // or should throw exception instead?
            }

            GridColumn[] columns = new GridColumn[fieldNames.Length];
            for(int i=0; i<fieldNames.Length; i++)
            {
                columns[i] = new GridColumn();
            }
            
            this.SuspendLayout();
            this.mainGridView.Columns.AddRange(columns);
            // is it allowable to implement the following logic in previous cycle immediately?
            for(int i=0; i<fieldNames.Length; i++)
            {
                columns[i].Caption = captions[i];
                columns[i].FieldName = fieldNames[i];
                columns[i].Name = "gridColumn" + fieldNames[i];
                columns[i].Visible = true;
                // suppose that ALL columns for the grid are being added here
                // otherwise last existing visible index's value should be added to 'i'
                columns[i].VisibleIndex = i;
            }
            this.ResumeLayout(false);
        }

        public override void RefreshData()
        {
            base.RefreshData();
            gridControl.ForceInitialize();
            mainGridView.RefreshData();
        }
    }
}