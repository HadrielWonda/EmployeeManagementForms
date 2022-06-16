using System;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI
{
    public partial class FrmEntityExceptionDetails : DevExpress.XtraEditors.XtraForm
    {
        private EntityException _ex;
        
        public FrmEntityExceptionDetails()
        {
            InitializeComponent();
        }
        
        public FrmEntityExceptionDetails(EntityException ex) : this()
        {
            _ex = ex;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_ex != null)
            {
                EditType.Text = string.Format("{0} - ({1})", _ex.GetType().FullName, _ex.Data[EntityExceptionDataKey.InnerTypeName] as string);
                EditSource.Text = _ex.Data[EntityExceptionDataKey.InnerSource] as string;
                EditMessage.Text = _ex.Data[EntityExceptionDataKey.InnerMessage] as string;
                EditStackTrace.Text = _ex.Data[EntityExceptionDataKey.InnerStackTrace] as string;
            }
        }

        private void btn_CopyToClipboard_Click(object sender, EventArgs e)
        {
            if(_ex != null)
            {
                Clipboard.SetText(_ex.Data[EntityExceptionDataKey.InnerString] as string);
            }
        }
    }
}