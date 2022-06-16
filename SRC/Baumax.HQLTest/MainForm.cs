using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Baumax.Dao.NHibernate;
using Spring.Context;
using Spring.Context.Support;
using Common.Logging;

namespace Baumax.HQLTest
{
    public partial class MainForm : Form
    {
        static private readonly ILog log = LogManager.GetLogger(typeof (MainForm));
        private IApplicationContext _ctx = ContextRegistry.GetContext();
        private StringWriter _consoleCatcher = new StringWriter();
        private HibernateBaseEntityDao _dao;
        private System.Windows.Forms.Timer _timer;

        public MainForm()
        {
            InitializeComponent();

            _dao = (HibernateBaseEntityDao) _ctx.GetObject("BaseEntityDao", typeof (HibernateBaseEntityDao));
            Console.SetOut(_consoleCatcher);
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 500;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;

            string s;
            lock (_consoleCatcher)
            {
                s = _consoleCatcher.ToString();
                if ((s != null) && (s.Length > 0))
                {
                    _consoleCatcher.GetStringBuilder().Length = 0;
                }
            }
            if ((s != null) && (s.Length > 0))
            {
                textBoxOut.Text += s;
                textBoxOut.Select(textBoxOut.Text.Length - 1, 0);
                textBoxOut.ScrollToCaret();
            }

            _timer.Enabled = true;
        }

        private void ClearGrid()
        {
            gridViewMain.Columns.Clear();
            gridControlMain.DataSource = null;
            gridControlMain.DataBindings.Clear();
        }

        private void DoExecuteQuery()
        {
            ClearGrid();
            try
            {
                IList list = _dao.HibernateTemplate.Find(textBoxIn.Text);
                if ((list != null) && (list.Count > 0))
                {
                    gridControlMain.DataSource = list;
                    gridViewMain.PopulateColumns(list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.ToString(), "Query execution error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DoExecuteQuery();
        }

        private void textBoxIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ctrl-e
            if (((ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyChar == 5))
            {
                DoExecuteQuery();
            }

            // ctrl-a
            if (((ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyChar == 1))
            {
                textBoxIn.SelectAll();
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            textBoxOut.Text = string.Empty;
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }
    }
}