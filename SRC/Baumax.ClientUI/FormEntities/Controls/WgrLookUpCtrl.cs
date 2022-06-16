using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraEditors;
namespace Baumax.ClientUI.FormEntities.Controls
{
    public partial class WgrLookUpCtrl : LookUpEdit
    {
        public WgrLookUpCtrl():base()
        {
            
        }

        
        private void InitControl()
        {
            if (Properties.Columns.Count != 1)
            {
                Properties.Columns.Clear();
                Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Wgr", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
                Properties.DisplayMember = "Name";
                Properties.NullText = "";
                Properties.ShowFooter = false;
                Properties.ValueMember = "ID";
            }
        }

        private List<Domain.WGR> m_EntityList = null;

        public List<Domain.WGR> EntityList
        {
            get
            {
                return m_EntityList;
            }
            set
            {
                if (m_EntityList != value)
                {
                    InitControl();
                    m_EntityList = value;
                    Properties.DataSource = m_EntityList;

                    if (m_EntityList != null && m_EntityList.Count > 0)
                    {
                        CurrentId = m_EntityList[0].ID;
                    }
                }
            }
        }
        public Domain.WGR CurrentEntity
        {
            get
            {
                long lid = CurrentId;

                if (lid != 0)
                {
                    for (int i = 0; i < EntityList.Count; i++)
                        if (EntityList[i].ID == lid) return EntityList[i];
                }

                return null;
            }

            set
            {
                if (value != null)
                    CurrentId = value.ID;
                else CurrentId = 0;
            }
        }
        public long CurrentId
        {
            get
            {
                if (EditValue != null && EntityList != null)
                    return Convert.ToInt64(EditValue);
                else return 0;
            }
            set
            {
                if (EntityList != null)
                {
                    EditValue = value;
                }
            }
        }
    }
}
