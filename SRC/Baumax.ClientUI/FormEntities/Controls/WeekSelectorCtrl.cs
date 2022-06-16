using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Baumax.ClientUI.FormEntities.Controls
{
    public class WeekSelectorCtrl : PopupContainerEdit
    {
        private UCWeekSelector weekSelector;

        public int Year
        {
            get { return weekSelector.CurrentYear; }
            set {
                if (weekSelector.CurrentYear != value)
                {
                    weekSelector.CurrentYear = value;
                    OnDateChanged();
                }
            }
        }
        public DateTime MondayDate
        {
            get { return weekSelector.MondayDate; }
        }
        public DateTime SundayDate
        {
            get { return weekSelector.SundayDate; }
        }
        
        public int Week
        {
            get { return weekSelector.CurrentWeek; }
            set 
            {
                OnDateChanged();
                weekSelector.CurrentWeek = value; 
            }
        }
        
        public DateTime Date
        {
            set 
            { 
                weekSelector.Date = value;
                ChangeTextBox();
            }
        }

        private void ChangeTextBox()
        {
            AddButton();
            Properties.Buttons[Properties.Buttons.Count-1].Caption = " " + weekSelector.CurrentWeek.ToString() + " ";
            EditValue = string.Format("    {0} - {1}", 
                weekSelector.MondayDate.ToString("dd.MM.yyyy"), 
                weekSelector.SundayDate.ToString("dd.MM.yyyy"));
        }

        public event EventHandler DateChanged = null;

        public WeekSelectorCtrl()
        {
            PopupContainerControl popupControl = new PopupContainerControl();
            weekSelector = new UCWeekSelector();
            popupControl.Controls.Add(weekSelector);
            
            Properties.PopupControl = popupControl;
            Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            
            popupControl.Width = this.Width;
            popupControl.Height = 320;
            weekSelector.Dock = System.Windows.Forms.DockStyle.Fill;

                SizeChanged += new EventHandler(
                    delegate(object s, EventArgs e)
                    { 
                        popupControl.Width = Width;
                    });
                weekSelector.DateChanged += new EventHandler(
                    delegate(object o, EventArgs e)
                    {
                        OnDateChanged();
                    });
                Date = DateTime.Today;
                this.Popup += new EventHandler(
                    delegate(object s, EventArgs e)
                    {
                        weekSelector.MakeRowVisible();
                    });
            AddButton();
        }

        protected void OnDateChanged()
        {
            ChangeTextBox();
            if (DateChanged != null)
                DateChanged(this, null);
        }

        private void AddButton()
        {
            if (Properties.Buttons.Count == 1)
            {
                Properties.Buttons.Clear();
                DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
                serializableAppearanceObject1.ForeColor = System.Drawing.Color.FromArgb(45,45,45);
                serializableAppearanceObject1.Options.UseForeColor = true;
                serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                serializableAppearanceObject1.Options.UseFont = true;
                
                Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, false, true, true, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
             
            }
        }
    }
}
