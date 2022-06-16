namespace Baumax.ClientUI.FormEntities.AbsenceType
{
    public partial class FormAbsenceType : FormBaseEntity
    {
        private UCAbsenceTypeList.AbsenceTypeWrapper _absenceType;

        public UCAbsenceTypeList.AbsenceTypeWrapper AbsenceType
        {
            get { return _absenceType; }
            set
            {
                _absenceType = value;
                BindControls();
            }
        }
        
        public FormAbsenceType()
        {
            InitializeComponent();
        }

        private void BindControls()
        {
            textEditName.DataBindings.Clear();
            textEditName.DataBindings.Add("EditValue", _absenceType, "Name");
        }
    }
}