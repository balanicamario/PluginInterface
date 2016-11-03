using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using PluginManager.Model;
using PluginManager.Controller;

namespace Citrus.Forms.PluginManager.View
{
    public partial class PluginStoreRefreshDialog : Form
    {
        public PluginStoreRefreshDialog()
        {
            InitializeComponent();
            PluginStoreManager.OnPluginStoreRefreshStarting += new PluginStoreRefreshOnStartHandler(PluginStoreManager_OnPluginStoreRefreshStarting);
            PluginStoreManager.OnPluginStoreRefreshProgress += new PluginStoreRefreshHandler(PluginStoreManager_OnPluginStoreRefreshProgress);
            PluginStoreManager.OnPluginStoreRefreshCompleted += new PluginStoreRefreshOnCompleteHandler(PluginStoreManager_OnPluginStoreRefreshCompleted);
        }

        public delegate void Action();
        public delegate void PluginStoreUpdateAction(PluginStoreRefreshProgressEventArgs e);

        public void Update(PluginStoreRefreshProgressEventArgs e)
        {
            if (Visible)
            {
                progressBar.Maximum = e.Total;
                progressBar.Value = e.Current;                
            }
        }

        void PluginStoreManager_OnPluginStoreRefreshCompleted()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.Close));
            }
            else
            {
                this.Hide();
            }
        }

        void PluginStoreManager_OnPluginStoreRefreshProgress(PluginStoreRefreshProgressEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new PluginStoreUpdateAction(this.Update), new object[] { e });
            else
                this.Update(e);
        }

        void PluginStoreManager_OnPluginStoreRefreshStarting()
        {
        }

        public PluginStore RefreshPluginStore(IWin32Window parent)
        {
            this.Show(parent);            
            return PluginStoreManager.RefreshPuginStore();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            PluginStoreManager.OnPluginStoreRefreshStarting -= new PluginStoreRefreshOnStartHandler(PluginStoreManager_OnPluginStoreRefreshStarting);
            PluginStoreManager.OnPluginStoreRefreshProgress -= new PluginStoreRefreshHandler(PluginStoreManager_OnPluginStoreRefreshProgress);
            PluginStoreManager.OnPluginStoreRefreshCompleted -= new PluginStoreRefreshOnCompleteHandler(PluginStoreManager_OnPluginStoreRefreshCompleted);
            base.OnClosing(e);
        }
    }
}
