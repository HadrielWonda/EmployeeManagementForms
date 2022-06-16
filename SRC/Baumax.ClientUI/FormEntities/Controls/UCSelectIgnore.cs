using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract;
using DevExpress.XtraEditors.Controls;
using System.Text;

namespace Baumax.ClientUI.FormEntities.TimePlanning.AbsencePlanning
{
    public partial class UCSelectIgnore : UCBaseEntity
    {
        public event EventHandler IgnoreSelected = null;

        public UCSelectIgnore()
        {
            InitializeComponent();
        }

        public IEnumerable<BaumaxDayOfWeek> GetIgnoreDays()
        {
            for (int i = 0; i < listBox.Items.Count; i++)
                if (listBox.Items[i].CheckState == CheckState.Checked)
                    yield return (BaumaxDayOfWeek)(i + 1);
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            listBox.Items.Clear();

            for (BaumaxDayOfWeek day = BaumaxDayOfWeek.Monday; day <= BaumaxDayOfWeek.Sunday; day++)
            {
                listBox.Items.Add(GetLocalized(day.ToString()), false);
            }
        }

        public bool IgnoreFeast 
        {
            get  { return ed_IgnoreFeasts.Checked; }
        }

        public bool IgnoreClosedDay
        {
            get
            {    return ed_IgnoreClosedDays.Checked;   }
        }

        protected void OnIgnoreSelected()
        {
            if (IgnoreSelected != null)
                IgnoreSelected (null, null);
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            OnIgnoreSelected();
        }

        private void listBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            OnIgnoreSelected();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (IgnoreClosedDay)
                builder.Append(GetLocalized("ClosedDays"));

            if (IgnoreFeast)
            {
                if (builder.Length > 0)
                    builder.Append(", ");
                builder.Append(GetLocalized("Feasts"));
            }

            foreach (BaumaxDayOfWeek day in GetIgnoreDays())
            {
                if (builder.Length > 0)
                    builder.Append (", ");
                builder.Append (GetLocalized(day.ToString()));
            }

            if (builder.Length == 0)
                builder.Append(GetLocalized("None"));

            return builder.ToString();
        }

    }
}