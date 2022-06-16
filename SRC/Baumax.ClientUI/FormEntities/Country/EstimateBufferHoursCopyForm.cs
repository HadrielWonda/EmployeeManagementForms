using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class EstimateBufferHoursCopyForm : XtraForm
    {

        StoreWorldController _StoreWorldList = null;//new StoreWorldController();
        BindingTemplate<BufferHours> _listBufferHours = new BindingTemplate<BufferHours>();
        
        public EstimateBufferHoursCopyForm()
        {
            InitializeComponent();
        }

        public int EstimationYear
        {
            get { return (int)spin_Year.Value; }
            set { spin_Year.Value = value; }
        }
        
        
    }
}