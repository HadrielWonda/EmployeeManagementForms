using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country.UIColoring
{
    public partial class ColoringListControl : UCBaseEntity
    {
        private CountryColourList _bindingList = null;
        bool isUserWriteRight = UCCountryEdit.isUserWriteRight();

        public ColoringListControl()
        {
            InitializeComponent();
        }

        
        [DefaultValue (null)]
        public Domain.Country Country
        {
            get { return (Domain.Country)Entity; }
            set 
            {
                if (Entity != value)
                {
                    Entity = value;
                }
            }
        }
        protected override void EntityChanged()
        {
            InitControl();

        }
        public void InitControl()
        {
            if (Country == null)
            {
                _bindingList = null;
            }
            else
            {
                _bindingList = new CountryColourList(Country);
                _bindingList.Refresh();
                _bindingList.CheckAndCreateColorList();
            }
            gridControl.DataSource = _bindingList;
        }

        #region Grid methods

        Domain.Colouring GetEntityByRowHandle(int rowHandle)
        {
            return (gridViewColor.IsDataRow(rowHandle)) ? (Domain.Colouring)gridViewColor.GetRow(rowHandle) : null;
        }

        public Domain.Colouring FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewColor.FocusedRowHandle);
            }
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            GridHitInfo info = gridViewColor.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewColor.IsDataRow(info.RowHandle))
            {
                Domain.Colouring color = GetEntityByRowHandle(info.RowHandle);
                if (color != null) FireEditEntity(color);
            }
        }
        #endregion

        public void FireEditEntity(Domain.Colouring color)
        {
            Domain.Colouring c = color;
            if (c == null) c = FocusedEntity;
            if (c == null) return;

            FormColour form = new FormColour();
            form.Entity = c;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _bindingList.ResetItemById(c.ID);
            }

        }
        
    }
}

