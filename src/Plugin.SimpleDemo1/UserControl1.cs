using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginLoader;
using PluginManager;

namespace Plugin.SimpleDemo1
{

    [Plugin("Plugin.SimpleDemo1", "A simple plugin for Nyeeeeezz")]
    public partial class UserControl1 : UserControl
    {
       

        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
