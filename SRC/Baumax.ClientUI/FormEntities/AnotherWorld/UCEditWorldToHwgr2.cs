using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCEditWorldToHwgr2 : UCBaseEntity
    {
        private StoreStructureContext m_context;
        
        public UCEditWorldToHwgr2()
        {
            InitializeComponent();
        }

        public StoreStructureContext Context
        {
            get { return m_context; }
            set { m_context = value; }
        }
    }
}
