namespace Baumax.ClientUI.FormEntities.Country.UIWorkingModel
{
    public partial class WorkingModelForm : FormBaseEntity
    {
        public WorkingModelForm()
        {
            InitializeComponent();
            EntityControl = workModelControl1;
        }

        public WorkingModelForm(object entity)
        {
            InitializeComponent();
            EntityControl = workModelControl1;
            Entity = entity;
        }

    }
}

