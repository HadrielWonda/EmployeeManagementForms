using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Colouring
{
    public partial class UCColouringList : UCBaseEntityList
    {
        private IList _colouringList;

        public UCColouringList()
        {
            InitializeComponent();

            Init();
        }

        public UCColouringList(Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            AddGridColumns(new string[] {"ColouringID"},
                           new string[] {"ID"});
        }

        public override void Bind()
        {
            base.Bind();
            _colouringList = ClientEnvironment.ColouringService.FindAll();

            gridControl.DataSource = _colouringList;
        }

        public override void Add()
        {
            FormColouring f = new FormColouring();
            f.Text = GetLocalized("New Colouring");
            f.Colouring = new Domain.Colouring();
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                try
                {
                    ClientEnvironment.ColouringService.SaveOrUpdate(f.Colouring);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotSaveColouring");
                        form.ShowDialog(this);
                    }
                }
            }

            RefreshData();
        }

        public override void Edit()
        {
            Domain.Colouring l = (Domain.Colouring)mainGridView.GetRow(mainGridView.FocusedRowHandle);
            if (l == null)
            {
                return;
            }
            FormColouring f = new FormColouring();
            f.Text = GetLocalized("Edit Colouring");
            f.Colouring = l;
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                try
                {
                    ClientEnvironment.ColouringService.SaveOrUpdate(f.Colouring);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotSaveColouring");
                        form.ShowDialog(this);
                    }
                }
            }

            RefreshData();
        }

        public override void Delete()
        {
            //XtraMessageBox.Show(this, "Delete", this.Name, MessageBoxButtons.OK);
            List<long> ids = new List<long>();
            foreach (int rowHandle in mainGridView.GetSelectedRows())
            {
                Domain.Colouring col = (Domain.Colouring)mainGridView.GetRow(rowHandle);
                ids.Add(col.ID);
            }
            if (ids.Count == 1)
            {
                try
                {
                    ClientEnvironment.ColouringService.DeleteByID(ids[0]);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotDeleteColouring");
                        form.ShowDialog(this);
                    }
                }
            }
            else
            {
                try
                {
                    ClientEnvironment.ColouringService.DeleteListByID(ids);
                }
                catch (EntityException)
                {
                    // can't obtain more details while deleting list
                    ErrorMessage(GetLocalized("SomeColouringsNotDeleted"));
                }
            }

            RefreshData();
        }
    }
}