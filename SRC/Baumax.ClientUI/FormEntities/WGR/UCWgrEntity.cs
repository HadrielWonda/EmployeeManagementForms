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
    public partial class UCWgrEntity : UCBaseEntity
    {
        public Domain.WGR WGR 
        {
            get { return (Domain.WGR)Entity; }
            set { 
                if (Entity != value)
                    Entity = value;
            }
        }

        public UCWgrEntity()
        {
            InitializeComponent();
        }

        public override void Bind()
        {
            base.Bind();
            if (WGR != null)
            {
                edName.Properties.ReadOnly = WGR.Import;
                edName.Text = WGR.Name;
            }
        }

        public override bool IsValid()
        {
            bool noName = string.IsNullOrEmpty (edName.Text);
            if (noName)
                dxErrorProvider.SetError(edName, GetLocalized("NameShouldBeNotEmpty"));
            else 
                dxErrorProvider.SetErrorType(edName, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);

            return !noName;
        }

        public override bool Commit()
        {
            if (WGR != null)
            {
                if (string.Compare(edName.Text, WGR.Name, true) != 0)
                    Modified = true;

                WGR.Name = edName.Text;
                WGR.LanguageID = Baumax.Contract.SharedConsts.NeutralLangId;

                ClientEnvironment.WGRService.SaveOrUpdate(WGR);
            }
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
