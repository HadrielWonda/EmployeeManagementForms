using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
// todo: probably, wrapper should be implemented at server side to minimize network traffic
// 2think: what if we just add fake wrapper fields/properties into entity itself? 
// then server-side services should implement some logic to wrap after loading and
// unwrap before saving entity (or even properties can do this by themselves 
// inside of getters/setters). 
// such implementation also doesn't require creation of new classes.
//
// intend to implement such logic for Country service

namespace Baumax.ClientUI.FormEntities.AbsenceType
{
    public partial class UCAbsenceTypeList : UCBaseEntityList
    {
        public class AbsenceTypeWrapper
        {
            private Domain.AbsenceType _absenceType;
            private string _name;
            
            public AbsenceTypeWrapper(Domain.AbsenceType absenceType, string name)
            {
                this._absenceType = absenceType;
                this._name = name;
            }
            
            public long Id
            {
                get { return _absenceType.ID; }
            }
            
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            internal Domain.AbsenceType AbsenceType
            {
                get { return _absenceType; }
            }

            /// <summary>
            /// put _name into the proper position of AbsenceTypeNames list
            /// </summary>
            public void DecomposeName(long langId)
            {
                // no need to check. lazy init is implemented in property
                /*
                if(_absenceType.AbsenceTypeNames == null)
                {
                    _absenceType.AbsenceTypeNames = new ArrayList();
                }*/
                AbsenceTypeName properATN = null;
                foreach(AbsenceTypeName atn in _absenceType.AbsenceTypeNames)
                {
                    if(atn.LanguageID == langId)
                    {
                        properATN = atn;
                        break;
                    }
                }
                if (properATN == null)
                {
                    _absenceType.AbsenceTypeNames.Add(new AbsenceTypeName(langId, _name, _absenceType));
                }
                else
                {
                    // LanguageID is already filled
                    //properATN.LanguageID = langId;
                    properATN.Name = _name;
                    properATN.AbsenceType = _absenceType;
                }
            }
        }

        private List<AbsenceTypeWrapper> _absTypeWList;
        
        public UCAbsenceTypeList()
        {
            InitializeComponent();

            Init();
        }

        public UCAbsenceTypeList(Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            AddGridColumns(new string[] { "Name" },
                           new string[] { "Name" });

        }

        public override void Bind()
        {
            IList absTypeList = ClientEnvironment.AbsenceTypeService.FindAll();
            _absTypeWList = new List<AbsenceTypeWrapper>();
            foreach(Domain.AbsenceType at in absTypeList)
            {
                bool found = false;
                AbsenceTypeName neuLangATN = null;
                AbsenceTypeName anyLandATN = null;
                foreach (AbsenceTypeName atn in at.AbsenceTypeNames)
                {
                    if (atn.LanguageID == ClientEnvironment.LanguageId)
                    {
                        found = true;
                        _absTypeWList.Add(new AbsenceTypeWrapper(at, atn.Name));
                        break;
                    }
                    if(atn.LanguageID == SharedConsts.NeutralLangId)
                    {
                        neuLangATN = atn;
                    }
                    if(anyLandATN == null)
                    {
                        anyLandATN = atn;
                    }
                }
                if(!found)
                {
                    if(neuLangATN == null)
                    {
                        if(anyLandATN == null)
                        {
                            _absTypeWList.Add(new AbsenceTypeWrapper(at, "???"));
                        }
                        else
                        {
                            _absTypeWList.Add(new AbsenceTypeWrapper(at, anyLandATN.Name));
                        }
                    }
                    else
                    {
                        _absTypeWList.Add(new AbsenceTypeWrapper(at, neuLangATN.Name));
                    }
                }
            }

            gridControl.DataSource = _absTypeWList;
        }

        public override void Add()
        {
            FormAbsenceType f = new FormAbsenceType();
            f.Text = GetLocalized("New Absence Type");
            f.AbsenceType = new AbsenceTypeWrapper(new Domain.AbsenceType(), "");
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                f.AbsenceType.DecomposeName(ClientEnvironment.LanguageId);
                try
                {
                    ClientEnvironment.AbsenceTypeService.SaveOrUpdate(f.AbsenceType.AbsenceType);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotSaveAbsenceType");
                        form.ShowDialog(this);
                    }
                }
            }

            RefreshData();
        }

        public override void Edit()
        {
            AbsenceTypeWrapper e = (AbsenceTypeWrapper)mainGridView.GetRow(mainGridView.FocusedRowHandle);
            if (e == null)
            {
                return;
            }
            FormAbsenceType f = new FormAbsenceType();
            f.Text = GetLocalized("Edit Absence Type");
            f.AbsenceType = e;
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                f.AbsenceType.DecomposeName(ClientEnvironment.LanguageId);
                try
                {
                    ClientEnvironment.AbsenceTypeService.SaveOrUpdate(f.AbsenceType.AbsenceType);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotSaveAbsenceType");
                        form.ShowDialog(this);
                    }
                }
            }

            RefreshData();
        }

        public override void Delete()
        {
            List<long> ids = new List<long>();
            foreach (int rowHandle in mainGridView.GetSelectedRows())
            {
                AbsenceTypeWrapper atw = (AbsenceTypeWrapper)mainGridView.GetRow(rowHandle);
                ids.Add(atw.AbsenceType.ID);
            }
            if (ids.Count == 1)
            {
                try
                {
                    ClientEnvironment.AbsenceTypeService.DeleteByID(ids[0]);
                }
                catch (EntityException ex)
                {
                    // 2think: what details should we show?
                    // 2think: how to localize?
                    using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                    {
                        form.Text = GetLocalized("CannotDeleteAbsenceType");
                        form.ShowDialog(this);
                    }
                }
            }
            else
            {
                try
                {
                    ClientEnvironment.AbsenceTypeService.DeleteListByID(ids);
                }
                catch (EntityException)
                {
                    // can't obtain more details while deleting list
                    ErrorMessage(GetLocalized("SomeAbsenceTypesNotDeleted"));
                }
            }

            RefreshData();
        }
    }
}