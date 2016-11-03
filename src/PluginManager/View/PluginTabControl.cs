using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginManager.Model;

namespace Citrus.Forms.PluginManager.View
{
    public partial class PluginTabControl : TabControl
    {
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public event LastTabRemovedEventHandler LastTabRemoved;

        public virtual void OnLastTabRemoved()
        {
            if (null != LastTabRemoved)
                LastTabRemoved();
        }

        public void LoadPlugin(PluginInfo pluginInfo, Control pluginToLoad)
        {
            if (!TabPages.ContainsKey(pluginInfo.Name))
            {
                if (SelectedIndex >= 0)
                    TabPages.Insert(SelectedIndex + 1, new PluginTabPage(pluginInfo, pluginToLoad));
                else
                    TabPages.Add(new PluginTabPage(pluginInfo, pluginToLoad));
            }
            SelectTab(pluginInfo.Name);
        }

        public PluginTabControl()
            : base()
        {
            InitializeComponent();
        }

        public new PluginTabPage SelectedTab
        {
            get
            {
                return (PluginTabPage)base.SelectedTab;
            }
        }

        /// <summary>
        /// Unloads all loaded plugins
        /// </summary>
        public void UnloadPlugins()
        {
            RemoveAll();
        }

        /// <summary>
        /// Double clicking on a tab closes it
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (this.GetTabRect(SelectedIndex).Contains(e.X, e.Y))
            {
                RemoveTab(SelectedIndex);
                SelectTabAfterRemove(SelectedIndex);
            }
        }

        /// <summary>
        /// Middle mouse button click on a tab closes it
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (e.Button == MouseButtons.Middle && this.GetTabRect(i).Contains(e.X, e.Y))
                {
                    RemoveTab(i);
                    SelectTabAfterRemove(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Removes the tab specified by the index        
        /// </summary>
        /// <param name="index"></param>
        private void RemoveTab(int index)
        {
            PluginTabPage tabToRemove = TabPages[index] as PluginTabPage;
            TabPages.RemoveAt(index);

            if (TabPages.Count == 0)
                OnLastTabRemoved();
        }

        private void SelectTabAfterRemove(int index)
        {
            if (TabPages.Count == 0)
                return;

            if (index >= TabPages.Count) // last tab removed
                SelectTab(TabPages.Count - 1);
            else if (index > 0)
                SelectTab(index - 1);
            else
                SelectTab(0);
        }
    }

    public delegate void LastTabRemovedEventHandler();
}
