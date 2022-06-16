using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars ;
using DevExpress.XtraTab;
using DevExpress.Utils.Controls;

using DevExpress.XtraLayout;

namespace Baumax.ClientUI
{
    using Baumax.Localization;
    using Baumax.ClientUI.FormEntities;

    public class ControlLocalizer
    {
        UILocalizer _ui = null;
        Control _control = null;

        public ControlLocalizer(UILocalizer localizer, Control control)
        {
            Debug.Assert(localizer != null);
            Debug.Assert(control != null);

            _ui = localizer;
            _control = control;

            BeginLocalization();
        }

        bool IsContaintUnderscore(string controlname)
        {
            Debug.Assert(!String.IsNullOrEmpty(controlname));

            return controlname.Contains("_");
        }

        string GetCodeWord(string controlname)
        {

            if (controlname != null)
            {

                int pos = controlname.IndexOf('_');

                if (pos > 0)
                {
                    return controlname.Substring(pos + 1).ToLower();
                }
            }
            return null;
        }

        string GetLocalizeWord(string controlname)
        {
            string label = GetCodeWord(controlname);

            if (label != null)
                return _ui[label.ToLower ()];

            return null;
        }
        string GetLocalizeWordDirect(string controlname)
        {
            return _ui[controlname.ToLower ()];
        }

        void BeginLocalization()
        {
            LocalizeImpl(_control);
        }

        void LocalizeImpl(Control control)
        {

            if (control is BaseControl)
            {
                if (control is LookUpEdit)
                {
                    // DevEx LookUpEdit
                    LookUpEdit lookUpEdit = (LookUpEdit)control;
                    foreach (LookUpColumnInfo info in lookUpEdit.Properties.Columns)
                    {
                        string caption =_ui[info.Caption];
                        if (caption != null)
                            info.Caption = caption;
                    }
                }
                else if (control is GridLookUpEdit)
                {
                    GridLookUpEdit look = (control as GridLookUpEdit);
                    ColumnView cview = look.Properties.View as ColumnView;
                    if (cview != null)
                    {
                        if (cview != null)
                        {
                            foreach (GridColumn column in cview.Columns)
                            {
                                string caption = GetLocalizeWord(column.Name);
                                if (caption != null)
                                    column.Caption = caption;

                                string tip = GetLocalizeWord(column.Name + "_Tip");
                                if (tip != null)
                                    column.ToolTip = tip;
                            }
                        }
                    }
                }
                else
                {
                    // Other controls
                    string label = GetLocalizeWord(control.Name); //GetCodeWord(control.Name);
                    if (label != null)
                    {
                        control.Text = label;
                    }
                }
                //
                /*string tool_tip = GetCodeWord (control.Name);
                
                    if (tool_tip != null)
                    {
                        tool_tip = _ui[tool_tip + ".ToolTip"];
                        if (tool_tip != null)
                        {
                            ((BaseControl)control).ToolTip = tool_tip;
                        }
                    }*/
            }
            else if (control is PanelBase)
            {
                string label = GetLocalizeWord(control.Name); //GetCodeWord(control.Name);
                if (label != null)
                {
                    control.Text = label;
                }
            }
            
            else if (control is GridControl)
            {
                // DevEx GridControl
                GridControl gridControl = (GridControl)control;
                //
                //gridControl.ViewCollection
                for (int i = 0; i < gridControl.ViewCollection.Count; ++i)
                {
                    BaseView view = gridControl.ViewCollection[i];
                    // columns
                    ColumnView cview = view as ColumnView;
                    if (cview != null)
                    {
                        string caption = null;
                        foreach (GridColumn column in cview.Columns)
                        {
                            caption = GetLocalizeWord(column.Name);
                            if (caption != null)
                                column.Caption = caption;

                            string tip = GetLocalizeWord(column.Name + "_Tip");
                            if (tip != null)
                                column.ToolTip = tip;
                            else if (caption != null)
                                column.ToolTip = caption;
                        }

                        BandedGridView bview = cview as BandedGridView;

                        if (bview != null)
                        {
                            foreach (GridBand band in bview.Bands)
                            {
                                caption = GetLocalizeWord(band.Name);
                                if (caption != null)
                                {
                                    band.Caption = caption;
                                }
                            }
                        }
                    }
                    /*else
                    {
                        // bands
                        BandedGridView bview = view as BandedGridView;
                        if (bview != null)
                        {
                            string caption = null;
                            foreach (GridBand band in bview.Bands)
                            {
                                caption = GetLocalizeWord(band.Name);
                                //resourceGroup.GetResourceStringNoThrow(string.Format("{0}.{1}.Bands.{2}", control.Name, bview.Name, band.Name));
                                if (caption != null)
                                {
                                    band.Caption = caption;
                                }
                            }
                        }

                    }*/
                    GridView gview = view as GridView;
                    if (gview != null)
                    {
                        string local_grouptext = GetLocalizeWord("GroupPanelText");
                        if (local_grouptext != null)
                        {
                            gview.GroupPanelText = local_grouptext;
                        }
                    }

                }
            }
            else if (control is XtraTabControl)
            {
                XtraTabControl tabControl = (XtraTabControl)control;
                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    XtraTabPage page = tabControl.TabPages[i];
                    string label = GetLocalizeWord(page.Name);
                    if (label != null)
                    {
                        page.Text = label;
                    }
                    for (int j = 0; j < page.Controls.Count; ++j)
                    {
                        this.LocalizeImpl(page.Controls[j]);
                    }
                }
            }
            else if (control is NavBarControl)
            {
                NavBarLocalize((control as NavBarControl));
            }
            else if (control is LayoutControl)
            {
                LayoutControlLocalize((control as LayoutControl));
            }
            if (control.Controls.Count > 0)
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    if ((control.Controls [i] as UCBaseEntity)==null)
                        LocalizeImpl(control.Controls[i]);
                }
            }
        }

        public void LayoutControlLocalize(LayoutControl control)
        {
            
            foreach (BaseLayoutItem item in control.Items)
            {
                string label = GetLocalizeWord(item.Name);
                if (label != null)
                {
                    item.Text = label;
                }
            }
        }
        public void NavBarLocalize(NavBarControl nav)
        {
            foreach (NavBarGroup item in nav.Groups )
            {
                string label = GetLocalizeWord(item.Name);
                if (label != null)
                {
                    item.Caption = label;
                }
            }

            foreach (NavBarItem item in nav.Items)
            {
                string label = GetLocalizeWord(item.Name);
                if (label != null)
                {
                    item.Caption = label;
                }
            }
        }

        public void ComponentsLocalize(IContainer components)
        {
            if (components != null)
            {
                foreach (Component component in components.Components)
                {
                    if (component is ContextMenuStrip)
                    {
                        ContextMenuStrip menu = (ContextMenuStrip)component;
                        for (int i = 0; i < menu.Items.Count ; i++)
                        {
                            ToolStripMenuItem item = (menu.Items[i] as ToolStripMenuItem);
                            if (item != null)
                            {
                                string label = GetLocalizeWord(item.Name);
                                if (label != null)
                                    item.Text = label;
                            }
                        }
                    }
                    if (component is BarManager)
                    {
                        BarManager bm = (component as BarManager);
                        foreach (BarItem item in bm.Items)
                        {
                            string label = GetLocalizeWord(item.Name);
                            if (label != null)
                                item.Caption= label;
                        }
                    }
                }
            }

        }
    }
}
