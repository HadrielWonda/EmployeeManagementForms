using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class FormEnterAbsenceTime : FormBaseEntity 
    {
        public FormEnterAbsenceTime()
        {
            InitializeComponent();
        }
        private int m_begintime = 6*60;
        private int m_endtime = 18*60;

        public int BeginTime
        {
            get { return m_begintime; }
            set { m_begintime = value; }
        }
        public int EndTime
        {
            get { return m_endtime; }
            set { m_endtime = value; }
        }


        private int m_round = 15;

        public int RoundTime
        {
            get { return m_round; }
            set { m_round = value; }
        }
        public override bool Modified
        {
            get
            {
                return true;
            }
        }
        private int StrToTime(string str)
        {
            string[] values = str.Split(new string[] { ":" }, StringSplitOptions.None);

            int iHour = Convert.ToInt32(values[0]);
            int iMinutes = Convert.ToInt32(values[1]);

            iMinutes += iHour * 60;
            if (RoundTime > 0)
            {
                if (iMinutes % RoundTime != 0)
                {
                    int p = iMinutes / RoundTime;
                    iMinutes = p * (RoundTime + 1);
                }
            }

            return iMinutes;
        }

        private string TimeToStr(int time)
        {
            int iHour = time / 60;
            int iMinutes = time % 60;

            return String.Format("{0}:{1}", iHour.ToString("00"), iMinutes.ToString("00"));
        }
        protected override void OnLoad(EventArgs e)
        {
             base.OnLoad(e);
             if (!DesignMode)
             {
                 teBegin.Text = TimeToStr(BeginTime);
                 teEnd.Text = TimeToStr(EndTime);
             }
        }
        protected override bool ValidateEntity()
        {
            int bt = StrToTime(teBegin.Text);
            int et = StrToTime(teEnd.Text);
            if (bt >= et)
                return false;

            BeginTime = bt;
            EndTime = et;
            return true;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}