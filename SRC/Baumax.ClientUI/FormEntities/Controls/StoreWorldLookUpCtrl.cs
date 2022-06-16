using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;

namespace Baumax.ClientUI.FormEntities.Controls
{
    class StoreWorldLookUpCtrl : LookUpEdit
    {
        private bool _bInitFirstValue = true;
        public StoreWorldLookUpCtrl()
            : base()
        {
        }
        
        private void InitControl()
        {
            if (Properties.Columns.Count != 1)
            {
                Properties.Columns.Clear();
                Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorldName", "World", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
                Properties.DisplayMember = "WorldName";
                Properties.NullText = "";
                Properties.ShowFooter = false;
                Properties.ValueMember = "ID";
            }
        }


        private List<Domain.StoreToWorld> m_EntityList = null;
        public bool InitFirstValue
        {
            get { return _bInitFirstValue; }
            set { _bInitFirstValue = value; }
        }

        public List<Domain.StoreToWorld> EntityList
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
                    EditValue = null;
                    Properties.DataSource = m_EntityList;

                    if (m_EntityList != null && m_EntityList.Count > 0 && InitFirstValue)
                    {
                        CurrentId = m_EntityList[0].ID;
                    }
                }
            }
        }

        public Domain.StoreToWorld CurrentEntity
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

        public long WorldId
        {
            get 
            {
                Domain.StoreToWorld sw = CurrentEntity;
                if (sw != null)
                {
                    return sw.WorldID;
                }
                return 0;
            }
            set 
            {
                if (EntityList != null)
                {
                    for (int i = 0; i < EntityList.Count; i++)
                    {
                        if (EntityList[i].WorldID == value)
                        {
                            CurrentId = EntityList[i].ID;
                            return;
                        }
                    }

                    CurrentId = 0;
                }
            }
        }

    }
}
