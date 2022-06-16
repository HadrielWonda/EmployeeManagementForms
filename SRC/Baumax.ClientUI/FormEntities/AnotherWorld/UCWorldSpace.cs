using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Environment;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class UCWorldSpace : UCBaseEntity
    {
        public void DisplayWorldData(Baumax.Dao.QueryResult.StoreWorldDetail detail)
        {
            lbAvailableWorkTime.Text = detail.AvailableWorkTimeHours.ToString();
            lbBenchmarkBusinessVolume.Text = detail.BenchmarkPerfomance.ToString();
            lbBenchmarkHours.Text = detail.BusinessVolumeHours.ToString(); /////////////no
            lbBussinessVolumeHours.Text = detail.BusinessVolumeHours.ToString();
            lbCurrentlyAvailableBuffer.Text = detail.AvailableBufferHours.ToString();
            
            lbEstimatedBusinessVolume.Text = detail.TargetedBusinessVolume.ToString();
            lbNetBusinessVolume.Text = detail.NetBusinessVolume1.ToString();
            lbNetBusinessVolumeWithout.Text = detail.NetBussinessVolume2.ToString();
            lbWorld.Text = ClientEnvironment.StoreToWorldService.FindById(detail.StoreWorldId).WorldName;
        }
	
        public UCWorldSpace()
        {
            InitializeComponent();
        }

    }
}