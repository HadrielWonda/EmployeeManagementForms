using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country.LunchBrakes
{
    public partial class FormLunchModel : FormBaseEntity
    {
        private bool _isNew = false;
        
        public FormLunchModel()
        {
            InitializeComponent();
            if (ClientEnvironment.IsRuntimeMode)
              EntityControl = ecLunchModel1;
        }
        
        public bool isNew
        {
           get
            {
                return _isNew;
            }
            set
            {
                _isNew = value;
            }  
        }

        public FormLunchModel(object entity)
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                 InitializeComponent();
                 EntityControl = ecLunchModel1;
                 Entity = entity;
            }
        }

       protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            Text = " ";
            if (isNew)
                lb_lunchModel.Text = GetLocalized("NewLunch");
            else
                lb_lunchModel.Text = GetLocalized("editLunch");
        }
        
        public void setReadOnlyTypeLunch(bool isDurationTime)
        {
           if (ClientEnvironment.IsRuntimeMode)
             ecLunchModel1.isTypeLunchReadOnly(isDurationTime);
        }
    }
}