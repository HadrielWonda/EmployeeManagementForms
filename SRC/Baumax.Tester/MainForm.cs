using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spring.Context;
using Spring.Context.Support;
using Common.Logging;
using System.IO;
using Baumax.Contract.Interfaces;
using Baumax.Environment;

namespace Baumax.Tester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


        }
        private void login()
        {
            
            ClientEnvironment.DoLogin("admin", "2");
            ClientEnvironment.InitServices();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientEnvironment.StoreService.ExecuteTestMethods(null);
        }
    }
}