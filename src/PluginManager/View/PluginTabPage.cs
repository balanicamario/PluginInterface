using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginManager.Model;

namespace Citrus.Forms.PluginManager.View
{
    public partial class PluginTabPage : TabPage
    {
        public PluginInfo Info { get; private set; }
        public Control Plugin { get; private set; }
        public PluginTabPage FromTab { get; private set; }

        public PluginTabPage(PluginInfo pluginInfo, Control plugin, PluginTabPage parentTab)
            : base(pluginInfo.Name)
        {
            plugin.SuspendLayout();
            plugin.Dock = DockStyle.Fill;

            Info = pluginInfo;
            Plugin = plugin;
            FromTab = parentTab;

            Controls.Add(plugin);
            this.Name = pluginInfo.Name;
            plugin.ResumeLayout();
        }

        public PluginTabPage(PluginInfo pluginInfo, Control plugin)
            : this(pluginInfo, plugin, null) { }
    }
}
