namespace Baumax.ClientUI.FormEntities.Colouring
{
    public partial class FormColouring : FormBaseEntity
    {
        private Domain.Colouring _colouring;

        public Domain.Colouring Colouring
        {
            get
            {
                /* table was changed
                if (colorEditAddChargesEmplSum != null)
                {
                    _colouring.AddChargesEmplSum = colorEditAddChargesEmplSum.Color.ToArgb();
                }
                if (colorEditOtherColoursaddlater != null)
                {
                    _colouring.OtherColoursaddlater = colorEditOtherColoursaddlater.Color.ToArgb();
                }
                */
                return _colouring;
            }
            set
            {
                _colouring = value;
                /* table was changed
                colorEditAddChargesEmplSum.Color = Color.FromArgb(_colouring.AddChargesEmplSum);
                colorEditOtherColoursaddlater.Color = Color.FromArgb(_colouring.OtherColoursaddlater);
                */
                BindControls();
            }
        }

        public FormColouring()
        {
            InitializeComponent();
        }

        private void BindControls()
        {
            // can't bind int fields to Color .{
            // implementing binding-like behavior in property
        }
    }
}