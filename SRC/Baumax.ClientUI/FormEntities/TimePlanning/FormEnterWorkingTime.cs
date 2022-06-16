using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class FormEnterWorkingTime : FormBaseEntity 
    {
        public FormEnterWorkingTime()
        {
            InitializeComponent();
        }


        private int m_begintime;
        private int m_endtime;

        public int BeginTime
        {
            get { return StrToTime(teBegin.Text); }
            set { teBegin.Text = TimeToStr(value); }
        }
        public int EndTime
        {
            get { return StrToTime(teEnd.Text); }
            set { teEnd.Text = TimeToStr(value); }
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
            iMinutes = DateTimeHelper.RoundToQuoter(iMinutes);
            //if (RoundTime > 0)
            //{
            //    if (iMinutes % RoundTime != 0)
            //    {
            //        int p = iMinutes % RoundTime;
            //        iMinutes = p*(RoundTime+1);
            //    }
            //}

            return iMinutes;
        }

        private string TimeToStr(int time)
        {

            //TextParser.TimeToString (time);
            //int iHour = time / 60;
            //int iMinutes = time % 60;

            return TextParser.TimeToString(time); ;// String.Format("{0}:{1}", iHour.ToString("00"), iMinutes.ToString("00"));
        }

        protected override bool ValidateEntity()
        {
            //int bt = StrToTime(teBegin.Text);
            //int et = StrToTime(teEnd.Text);
            if (BeginTime >= EndTime)
                return false;

            //BeginTime = bt;
            //EndTime = et;
            return true;
        }
    }
}