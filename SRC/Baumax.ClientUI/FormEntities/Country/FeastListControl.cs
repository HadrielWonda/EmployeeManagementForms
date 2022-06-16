using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.Domain;
using Baumax.TestGUIClient.Templates;
namespace Baumax.TestGUIClient.UI.FormEntities.Country
{
    public partial class FeastListControl : Baumax.TestGUIClient.UI.FormEntities.UCBaseEntity
    {
        public FeastListControl()
        {
            InitializeComponent();
        }

        private bool _readonly = false;

        public bool ReadOnly
        {
            get { return _readonly; }
            set { _readonly = value; }
        }

        BindingTemplate<Feast> _bindingFeast = new BindingTemplate<Feast>();

        private Domain.Country _country;

        public Domain.Country Country
        {
            get { return _country; }
            set { _country = value; }
        }

        Feast GetFeastByRowHandle(int rowHandle)
        {
            Feast feast = null;
            if (gridViewFeast.IsDataRow(rowHandle))
                feast = (Feast)gridViewFeast.GetRow(rowHandle);
            return feast;

        }

        public Feast FocusedFeast
        {
            get
            {
                return GetFeastByRowHandle(gridViewFeast.FocusedRowHandle);
            }
        }

        void DeleteFeast(Feast feast)
        {
            if (ReadOnly) return;

            Feast f = feast;
            if (f == null) f = FocusedFeast;

            if (f == null) return;

            _bindingFeast.Remove(f);
        }

        void NewFeast()
        {
            if (ReadOnly) return;
            FormFeast ffeast = new FormFeast();
            ffeast.Country = this.Country;
            if (ffeast.ShowDialog() == DialogResult.OK)
            {
                Feast[] newFeast = ffeast.GetNewFeast();
                for (int i = 0; i < newFeast.Length; i++)
                {
                    _bindingFeast.Add(newFeast[i]);
                }
            }
        }

        private void defineNewFeastsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;

            NewFeast();
        }

        private void deleteFeastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReadOnly) return;

            DeleteFeast(null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (ReadOnly) e.Cancel = true;
        }

    }
}

