namespace Baumax.ClientUI
{
    
    public enum Action
    {
        New,
        Edit,
        Delete,
        None
    }

    enum EntityEnum
    {
        Language,
        User,
        Country
    }



    public class UIActionState
    {
        private bool _canNew = false;
        private bool _canEdit = false;
        private bool _canDelete = false;

        public bool CanNew
        {
            get
            {
                return _canNew ;
            }
            set
            {
                _canNew = value;
            }
        }
        public bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                _canEdit = value;
            }
        }
        public bool CanDelete
        {
            get
            {
                return _canDelete;
            }
            set
            {
                _canDelete = value;
            }
        }

        public UIActionState(bool bNew, bool bEdit, bool bDelete)
        {
            CanNew = bNew;
            CanEdit = bEdit;
            CanDelete = bDelete;
        }
    }


}
