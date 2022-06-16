using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities.World;
namespace Baumax.ClientUI.FormEntities
{
    public partial class UCStoreTree : DevExpress.XtraEditors.XtraUserControl
    {
        StoreManagerContext m_context = null;


        //StoreStructureItems m_ListNodes = null;

        public UCStoreTree()
        {
            InitializeComponent();
        }

        public void SetStoreContext(StoreManagerContext context)
        {
            m_context = context;
        }

        public void RefreshList()
        {
        }
    }
}
