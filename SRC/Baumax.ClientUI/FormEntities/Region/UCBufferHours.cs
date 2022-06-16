using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Region
{
    using Baumax.Environment;

    public partial class UCBufferHours : UCBaseEntity 
    {
        List<Domain.BufferHours> _listItems = new List<Domain.BufferHours>();
        List<Domain.BufferHours> _originalItems = new List<Domain.BufferHours>();

        public UCBufferHours()
        {
            InitializeComponent();
        }

        public Domain.Store RegionStore
        {
            get
            {
                return (Domain.Store)Entity;
            }
            set
            {
                if (Entity != value)
                    Entity = value;
            }
        }

        protected override void EntityChanged()
        {
            base.EntityChanged();
        }

        public override void Bind()
        {
            base.Bind();
        }

        public void AssignWorlds(List<Domain.BufferHours> lst)
        {
            _originalItems = lst;
            gridControl1.DataSource = null;

            _listItems.Clear();


            foreach (Domain.BufferHours bh in _originalItems)
            {
                Domain.BufferHours copyObject = new Baumax.Domain.BufferHours();

                copyObject.ID = bh.ID;
                copyObject.StoreWorldID = bh.StoreWorldID;
                copyObject.Year = bh.Year;
                copyObject.Value = bh.Value;

                _listItems.Add(copyObject);
            }

            gridControl1.DataSource = _listItems;

        }

        public bool IsModified()
        {
            foreach (Domain.BufferHours origBuffer in _originalItems)
            {
                foreach (Domain.BufferHours curBuffer in _listItems)
                {
                    if (origBuffer.ID == curBuffer.ID && origBuffer.Value != curBuffer.Value) return true;
                }
            }
            return false;
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }


        public override bool Commit()
        {
            if (IsModified())
            {
                foreach (Domain.BufferHours bh in _listItems)
                {
                    //ClientEnvironment.StoreService.SaveOrUpdate(_listItems);

                    foreach (Domain.BufferHours origBuffer in _originalItems)
                    {
                        foreach (Domain.BufferHours curBuffer in _listItems)
                        {
                            if (origBuffer.StoreWorldID == curBuffer.StoreWorldID)
                            {
                                origBuffer.ID = curBuffer.ID;
                                origBuffer.StoreWorldID = curBuffer.StoreWorldID;
                                origBuffer.Year = curBuffer.Year;
                                origBuffer.Value = curBuffer.Value;
                            }
                        }
                    }
                }

                Modified = true;
            }
            return base.Commit();
        }
    }
}
