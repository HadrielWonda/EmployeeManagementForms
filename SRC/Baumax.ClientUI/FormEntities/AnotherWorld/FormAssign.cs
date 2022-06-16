using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormAssign : FormBaseEntity
    {
        [Browsable(false)]
        public UCAssign UC
        {
            get { return uc; }
            set { uc = value; }
        }
        
        
        public FormAssign()
        {
            InitializeComponent();
            EntityControl = uc;
        }


        public  void Bind(AssignEnum assignEnum, long m_storeID)
        {
            UC.Bind(assignEnum, m_storeID);
            switch (assignEnum)
            { 
                case AssignEnum.ThisHwgrToWgr:
                case AssignEnum.ThisWgrToHWGR:
                    lbl_AssignEntity.Text = Localizer.GetLocalized("ThisWgrToHWGR");
                    break;
                case AssignEnum.ThisHwgrToWorld:
                    lbl_AssignEntity.Text = Localizer.GetLocalized("ThisHwgrToWorld");
                    break;
                case AssignEnum.HwgrWgrDisable:
                    lbl_AssignEntity.Text = Localizer.GetLocalized("HwgrWgrDisable");
                    break;
                case AssignEnum.WorldHwgrDisable:
                    lbl_AssignEntity.Text = Localizer.GetLocalized("WorldHwgrDisable");
                    break;
            }
        }
    }
}