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
    public partial class UCWorldEntity : UCBaseEntity
    {
        private Dictionary<long, string> stores = new Dictionary<long,string>();
        private Dictionary<Baumax.Domain.WorldType, string> types 
            = new Dictionary<Baumax.Domain.WorldType,string>();

        public Domain.World World 
        {
            get { return (Domain.World)Entity; }
            set { 
                if (Entity != value)
                    Entity = value;
            }
        }

        public UCWorldEntity()
        {
            InitializeComponent();
            foreach (Domain.Store var in ClientEnvironment.StoreService.FindAll())
                stores.Add (var.ID, var.Name);
            types.Add(Baumax.Domain.WorldType.Administration, "Administration");
            types.Add(Baumax.Domain.WorldType.CashDesk, "CashDesk");
            types.Add(Baumax.Domain.WorldType.World, "World");
            edType.SelectedIndex = 2;
        }

        public override void Bind()
        {
            base.Bind();
            if (World == null) return;

            if (World.Import)
            {
                edName.Properties.ReadOnly  = true;
                edStore.Properties.ReadOnly = true;
                edType.Properties.ReadOnly = true;
            }
            edStore.Properties.Items.Clear();
            edStore.Properties.Items.AddRange(stores.Values);
            edType.Properties.Items.Clear();
            edType.Properties.Items.AddRange (types.Keys);
            edName.Text = World.Name;
        }

        public override bool IsValid()
        {
            bool name = !string.IsNullOrEmpty (edName.Text);
            if (!name)
                dxErrorProvider.SetError(edName, "Name should be not empty.");
            else dxErrorProvider.SetErrorType(edName, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);

            return name;
        }

        public override bool Commit()
        {
            if (World == null) return true;

            if (edName.Text != World.Name 
                || edType.Text != types[World.WorldTypeID])
                Modified = true;

            World.Name = edName.Text;

            ClientEnvironment.WorldService.SaveOrUpdate (World);
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
