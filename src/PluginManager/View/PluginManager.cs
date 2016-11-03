using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

using PluginManager.Model;
using PluginManager.Controller;

namespace Citrus.Forms.PluginManager.View
{
    public partial class PluginManager : Form
    {
        /// <summary>
        /// Represents the different types of status messages
        /// </summary>
        public enum StatusMessageType
        {
            None,
            Error,
            Busy,
            Info,
            Warning
        }

        /// <summary>
        /// Sets the status text message
        /// </summary>
        /// <param name="message">The status text message</param>
        private void SetSatusText(string message)
        {
            SetSatusText(message, StatusMessageType.None);
        }

        /// <summary>
        /// Sets the status text message
        /// </summary>
        /// <param name="message">The status text message</param>
        /// <param name="type">The status type</param>
        private void SetSatusText(string message, StatusMessageType type)
        {
            BusyLabel.Visible = false;
            ErrorLabel.Visible = false;
            InfoLabel.Visible = false;
            WarningLabel.Visible = false;

            switch (type)
            {
                case StatusMessageType.None:
                    break;
                case StatusMessageType.Info:
                    InfoLabel.Visible = true;
                    break;
                case StatusMessageType.Error:
                    WarningLabel.Visible = true;
                    break;
                case StatusMessageType.Warning:
                    ErrorLabel.Visible = true;
                    break;
                case StatusMessageType.Busy:
                    BusyLabel.Visible = true;
                    break;
                default:
                    break;
            }

            StatusLabel.Text = message;
            statusStrip.Refresh();
        }

        PluginStoreRefreshDialog refresher = new PluginStoreRefreshDialog();
        PluginStore pluginStore = null;        

        public PluginManager()
        {
            InitializeComponent();
            pluginStore = PluginStoreManager.LoadPuginStore();
            LoadPluginsList();
        }

        private void RefreshPluginsButton_Click(object sender, EventArgs e)
        {
            SetSatusText("Refreshing...", StatusMessageType.Busy);
            PluginTabs.UnloadPlugins();
            pluginStore = refresher.RefreshPluginStore(this);
            LoadPluginsList();
        }

        private void LoadPluginsList()
        {
            PluginList.Clear();
            if (null == pluginStore || pluginStore.Plugins.Count == 0)
            {
                SetSatusText("No plugins found", StatusMessageType.Warning);
            }
            else
            {
                foreach (PluginInfo plugin in pluginStore.Plugins)
                {
                    PluginList.Add(plugin);
                }
                SetSatusText("Loaded " + pluginStore.Plugins.Count + " plugins", StatusMessageType.Info);
            }
        }

        /// <summary>
        /// Identify the plugin and load it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PluginInfo plugin = PluginList.SelectedItem;
            if (ThreadPool.QueueUserWorkItem(new WaitCallback(DoPluginLoad), plugin))
            {
                SetSatusText("Loading " + plugin.Name + " ...", StatusMessageType.Busy);
            }
            else
            {
                DoPluginLoad(plugin);
            }
        }

        public delegate void PluginAction(object plugin);

        /// <summary>
        /// Loads the specified plugin
        /// </summary>
        /// <param name="plugin"></param>
        public void DoPluginLoad(object plugin)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new PluginAction(DoPluginLoad), new object[] { plugin });
            }
            else
            {
                Cursor = Cursors.AppStarting;
                PluginInfo p = (PluginInfo)plugin;
                try
                {

                    Control pluginControl = (Control)Activator.CreateInstance(
                        Assembly.LoadFile(EnvironmentSettings.GetFullPath(p.AssemblyFile)).GetType(p.Type)
                    );

                    
                    PluginTabs.LoadPlugin(p, pluginControl);                    
                    UpdateCurrentPluginInUse(p);
                }
                catch (Exception e)
                {
                    DisplayPluginLoadError(p, e);
                }

                Cursor = Cursors.Default;
            }
        }

        private void DisplayPluginLoadError(PluginInfo p, Exception e)
        {
            string message = string.Empty;
            if (null != e.InnerException)
                message = e.InnerException.Message;
            else
                message = e.Message;

            MessageBox.Show(this, message, "Plumed!", MessageBoxButtons.OK);
            SetSatusText(p.Name + " could not be loaded.", StatusMessageType.Error);
        }

        /// <summary>
        /// Display the description of the selected plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PluginTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PluginTabs.SelectedIndex >= 0)
                UpdateCurrentPluginInUse(PluginTabs.SelectedTab.Info);
        }

        private void UpdateCurrentPluginInUse(PluginInfo pluginInfo)
        {
            Text = pluginInfo.Name + " - PluginManager";
            SetSatusText(pluginInfo.Description, StatusMessageType.Info);
            Icon = IconSet.GetIcon(pluginInfo.Icon);
        }

        private void UpdateNoPluginsInUse()
        {
            Text = "PluginManager";
            SetSatusText("Ready");
            Icon = IconSet.Default;
        }
    }
}
