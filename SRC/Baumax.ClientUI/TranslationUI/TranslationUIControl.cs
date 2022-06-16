using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Baumax.ClientUI;
using Baumax.ClientUI.FormEntities;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Base;
using Baumax.Localization;

namespace Baumax.ClientUI.TranslationUI
{
    public partial class TranslationUIControl : UCBaseEntity
    {

        private long _fromLanguageId = -1;
        private long _toLanguageId = -1;

        Dictionary<int, UIResource> _fromUIResources = new Dictionary<int,UIResource> ();
        Dictionary<int, UIResource> _toUIResources = new Dictionary<int,UIResource> ();


        List<UIResource> _delta = null;

        BindingTemplate<Language> _bindingLanguageList = new BindingTemplate<Language>();


        public TranslationUIControl()
        {
            InitializeComponent();
        }

        class TranslationItem
        {
            private bool _modifiedFrom ;
            private bool _modifiedTo;
            private int _resourceID;
            private string _nameFrom;
            private string _nameTo;

            public TranslationItem(int resid, string fromname)
            {
                _resourceID = resid;
                _nameFrom = fromname;
                _nameTo = String.Empty;
                _modifiedTo = false;
                _modifiedFrom = false;
            }

            public bool ModifiedFrom
            {
                get { return _modifiedFrom; }
                set { _modifiedFrom = value; }
            }
            

            public bool ModifiedTo
            {
                get { return _modifiedTo; }
                set { _modifiedTo = value; }
            }


            

            public int ResourceID
            {
                get { return _resourceID; }
                set { _resourceID = value; }
            }
            

            

            public string NameFrom
            {
                get { return _nameFrom; }
                set 
                {
                    if (_nameFrom != value)
                    {

                        _nameFrom = value;
                        _modifiedFrom = true;
                    }
                }
            }


            public string NameTo
            {
                get { return _nameTo; }
                set 
                {
                    if (_nameTo != value)
                    {
                        _nameTo = value;
                        _modifiedTo = true;
                    }
                }
            }


        }

        BindingList<TranslationItem> _list = new BindingList<TranslationItem>();


        public new bool Modified
        {
            get
            {
                foreach (TranslationItem ti in _list)
                    if (ti.ModifiedFrom || ti.ModifiedTo) return true;

                return false;
            }
        }

        public void ResetModifyFlag()
        {
            foreach (TranslationItem ti in _list)
                ti.ModifiedFrom = ti.ModifiedTo = false;
        }

        void BuildDefaultList()
        {
            foreach (ItemResource ir in DefaultDiction.ListResource)
            {
                _list.Add(new TranslationItem(ir.Key , ir.Value));
            }

            gridControlUI.DataSource = _list;
        }


        void LoadLanguageFromList(List<UIResource> list, bool bFrom)
        {

            if (bFrom)
            {
                _fromUIResources.Clear();
            }
            else
            {
                _toUIResources.Clear();
            }
            if (list != null)
            {
                foreach (UIResource res in list)
                {
                    if (bFrom) _fromUIResources[res.ResourceID] = res;
                    else _toUIResources[res.ResourceID] = res;
                }
            }



            foreach (TranslationItem ti in _list)
            {
                if (bFrom)
                {
                    if (_fromUIResources.ContainsKey(ti.ResourceID))
                        ti.NameFrom = _fromUIResources[ti.ResourceID].Resource ;
                    else ti.NameFrom = DefaultDiction.Item(ti.ResourceID);

                    ti.ModifiedFrom = false;
                }
                else
                {
                    if (_toUIResources.ContainsKey(ti.ResourceID))
                        ti.NameTo = _toUIResources[ti.ResourceID].Resource;
                    else ti.NameTo = DefaultDiction.Item(ti.ResourceID);
                    ti.ModifiedTo = false;
                }
            }
            _list.ResetBindings();
        }


        void BuildDelta()
        {
            if (_delta == null) _delta = new List<UIResource>();
            UIResource resource = null;
            foreach (TranslationItem ti in _list)
            {
                resource = null;
                if (ti.ModifiedFrom && _fromLanguageId != -1)
                {
                    _fromUIResources.TryGetValue(ti.ResourceID, out resource);

                    if (resource == null)
                    {
                        resource = new UIResource();
                        resource.ResourceID = ti.ResourceID;
                        resource.LanguageID = _fromLanguageId;
                    }
                    resource.Resource = ti.NameFrom;
                    _delta.Add(resource);
                }
                resource = null;
                if (ti.ModifiedTo && _toLanguageId != -1)
                {
                    _toUIResources.TryGetValue(ti.ResourceID, out resource);
                    
                    if (resource == null)
                    {
                        resource = new UIResource();
                        resource.ResourceID = ti.ResourceID;
                        resource.LanguageID = _toLanguageId;
                    }

                    resource.Resource = ti.NameTo;
                    _delta.Add(resource);
                }
            }

            ResetModifyFlag();
        }

        private void lookUpEditTo_EditValueChanged(object sender, EventArgs e)
        {
            if (sender == lookUpEditFrom)
            {

                long _fromId = Convert.ToInt64(lookUpEditFrom.EditValue);

                if (_fromLanguageId != -1 && _fromId != _fromLanguageId)
                {
                    ChangedLanguage();




                }
                _fromLanguageId = _fromId;
                LoadLanguage(_fromLanguageId, true);


            }

            if (sender == lookUpEditTo)
            {
                long _toId = Convert.ToInt64(lookUpEditTo.EditValue);
                if (_toLanguageId != -1 && _toId != _toLanguageId)
                {

                    ChangedLanguage();




                }
                _toLanguageId = _toId;
                LoadLanguage(_toLanguageId, false);

            }

        }

        public void ChangedLanguage()
        {
            BuildDelta();

            UpdateTranslationDelta();
        }


        void LoadLanguage(long lang_id, bool bFrom)
        {
            List<UIResource> lst = null;
            if (lang_id > 0)
                lst = ClientEnvironment.LanguageService.GetResources(lang_id);
            else lst = new List<UIResource>();

            LoadLanguageFromList(lst, bFrom);
            
        }

        void UpdateTranslationDelta()
        {
            if (_delta != null && _delta.Count > 0)
            {
                ///
                ClientEnvironment.LanguageService.UpdateResources(_delta);

                _delta = null;
            }
        }

        void InitLanguageLookUp()
        {
            IList _langList = ClientEnvironment.LanguageService.FindAll();

            _bindingLanguageList.CopyList(_langList);

            lookUpEditFrom.Properties.DataSource =
                lookUpEditTo.Properties.DataSource = _bindingLanguageList;

            lookUpEditFrom.EditValue = _fromLanguageId;
            lookUpEditTo.EditValue = _toLanguageId;
        }

        public override void Bind()
        {
            base.Bind();

            InitLanguageLookUp();
            BuildDefaultList();
        }

        public delegate void ChangeContent();
        public event ChangeContent OnChangeContent = null;

        private void gridViewUI_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (OnChangeContent != null) OnChangeContent();
        }

        private void gridViewUI_ShowingEditor(object sender, CancelEventArgs e)
        {
            TranslationItem ti = (TranslationItem)gridViewUI.GetRow(gridViewUI.FocusedRowHandle);
            if (ti != null)
            {
                if (gridViewUI.FocusedColumn == gridColumnFrom)
                {
                    if (_fromLanguageId <= 0)
                        e.Cancel = true;
                }
                else
                {
                    if (gridViewUI.FocusedColumn == gridColumnTo)
                        if (_toLanguageId <= 0)
                            e.Cancel = true;

                }
            }
        }
    }
}
