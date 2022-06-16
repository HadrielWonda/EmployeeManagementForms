using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public partial class UCHwgrEntity : UCBaseEntity
    {
        public Domain.HWGR HWGR 
        {
            get { return (Domain.HWGR)Entity; }
            set { 
                if (Entity != value)
                    Entity = value;
            }
        }

        public UCHwgrEntity()
        {
            InitializeComponent();
        }

        public override void Bind()
        {
            base.Bind();
            if (HWGR == null) return;

            if (HWGR.Import)
            {
                edName.Properties.ReadOnly  = true;
            }

            edName.Text = HWGR.Name;
        }

        public override bool IsValid()
        {
            bool noName = string.IsNullOrEmpty (edName.Text);
            if (noName)
                dxErrorProvider.SetError(edName, "Name should be not empty.");
            else dxErrorProvider.SetErrorType(edName, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);

            return !noName;
        }

        public override bool Commit()
        {
            if (HWGR == null) return true;

            if (edName.Text != HWGR.Name)
                Modified = true;

            HWGR.Name = edName.Text;
            HWGR.LanguageID = Baumax.Contract.SharedConsts.NeutralLangId;

            ClientEnvironment.HWGRService.SaveOrUpdate(HWGR);
            return true;
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
                LocalizerControl.ComponentsLocalize(this.components);
        }
    }
}
