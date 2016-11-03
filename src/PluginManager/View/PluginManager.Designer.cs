namespace Citrus.Forms.PluginManager.View
{
    using NJFLib.Controls;
    using System.Drawing;

    partial class PluginManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginManager));
            this.PluginsHeaderLabel = new System.Windows.Forms.Label();
            this.RefreshPluginsButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.BusyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.InfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.WarningLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PluginListPanel = new System.Windows.Forms.Panel();
            this.PluginList = new Citrus.Forms.PluginManager.View.PluginListBox();
            this.collapsibleSplitter1 = new NJFLib.Controls.CollapsibleSplitter();
            this.PluginTabsPanel = new System.Windows.Forms.Panel();
            this.PluginTabs = new Citrus.Forms.PluginManager.View.PluginTabControl();
            this.statusStrip.SuspendLayout();
            this.PluginListPanel.SuspendLayout();
            this.PluginTabsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PluginsHeaderLabel
            // 
            this.PluginsHeaderLabel.AutoSize = true;
            this.PluginsHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.PluginsHeaderLabel.Name = "PluginsHeaderLabel";
            this.PluginsHeaderLabel.Size = new System.Drawing.Size(87, 13);
            this.PluginsHeaderLabel.TabIndex = 2;
            this.PluginsHeaderLabel.Text = "Available Plugins";
            // 
            // RefreshPluginsButton
            // 
            this.RefreshPluginsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshPluginsButton.Location = new System.Drawing.Point(9, 606);
            this.RefreshPluginsButton.Name = "RefreshPluginsButton";
            this.RefreshPluginsButton.Size = new System.Drawing.Size(156, 23);
            this.RefreshPluginsButton.TabIndex = 1;
            this.RefreshPluginsButton.Text = "Refresh List";
            this.RefreshPluginsButton.UseVisualStyleBackColor = true;
            this.RefreshPluginsButton.Click += new System.EventHandler(this.RefreshPluginsButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BusyLabel,
            this.ErrorLabel,
            this.InfoLabel,
            this.WarningLabel,
            this.StatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 644);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // BusyLabel
            // 
            this.BusyLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BusyLabel.Image = ((System.Drawing.Image)(resources.GetObject("BusyLabel.Image")));
            this.BusyLabel.Name = "BusyLabel";
            this.BusyLabel.Size = new System.Drawing.Size(16, 17);
            this.BusyLabel.Text = "BusyLabel";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ErrorLabel.Image = ((System.Drawing.Image)(resources.GetObject("ErrorLabel.Image")));
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(16, 17);
            this.ErrorLabel.Text = "ErrorLabel";
            // 
            // InfoLabel
            // 
            this.InfoLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoLabel.Image = ((System.Drawing.Image)(resources.GetObject("InfoLabel.Image")));
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(16, 17);
            this.InfoLabel.Text = "InfoLabel";
            // 
            // WarningLabel
            // 
            this.WarningLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WarningLabel.Image = ((System.Drawing.Image)(resources.GetObject("WarningLabel.Image")));
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(16, 17);
            this.WarningLabel.Text = "WarningLabel";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(88, 17);
            this.StatusLabel.Text = "PluginManager";
            // 
            // PluginListPanel
            // 
            this.PluginListPanel.Controls.Add(this.RefreshPluginsButton);
            this.PluginListPanel.Controls.Add(this.PluginsHeaderLabel);
            this.PluginListPanel.Controls.Add(this.PluginList);
            this.PluginListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PluginListPanel.Location = new System.Drawing.Point(0, 0);
            this.PluginListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PluginListPanel.Name = "PluginListPanel";
            this.PluginListPanel.Size = new System.Drawing.Size(180, 644);
            this.PluginListPanel.TabIndex = 2;
            // 
            // PluginList
            // 
            this.PluginList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PluginList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.PluginList.FormattingEnabled = true;
            this.PluginList.ItemHeight = 25;
            this.PluginList.Location = new System.Drawing.Point(9, 34);
            this.PluginList.Margin = new System.Windows.Forms.Padding(0);
            this.PluginList.Name = "PluginList";
            this.PluginList.Size = new System.Drawing.Size(168, 562);
            this.PluginList.TabIndex = 0;
            this.PluginList.SelectedIndexChanged += new System.EventHandler(this.PluginList_SelectedIndexChanged);
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.collapsibleSplitter1.ControlToHide = this.PluginListPanel;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(180, 0);
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.TabIndex = 3;
            this.collapsibleSplitter1.TabStop = false;
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = NJFLib.Controls.VisualStyles.DoubleDots;
            // 
            // PluginTabsPanel
            // 
            this.PluginTabsPanel.Controls.Add(this.PluginTabs);
            this.PluginTabsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginTabsPanel.Location = new System.Drawing.Point(188, 0);
            this.PluginTabsPanel.Name = "PluginTabsPanel";
            this.PluginTabsPanel.Size = new System.Drawing.Size(604, 644);
            this.PluginTabsPanel.TabIndex = 4;
            // 
            // PluginTabs
            // 
            this.PluginTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PluginTabs.Location = new System.Drawing.Point(3, 3);
            this.PluginTabs.Multiline = true;
            this.PluginTabs.Name = "PluginTabs";
            this.PluginTabs.SelectedIndex = 0;
            this.PluginTabs.Size = new System.Drawing.Size(598, 637);
            this.PluginTabs.TabIndex = 0;
            this.PluginTabs.LastTabRemoved += new Citrus.Forms.PluginManager.View.LastTabRemovedEventHandler(this.UpdateNoPluginsInUse);
            this.PluginTabs.SelectedIndexChanged += new System.EventHandler(this.PluginTabs_SelectedIndexChanged);
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 666);
            this.Controls.Add(this.PluginTabsPanel);
            this.Controls.Add(this.collapsibleSplitter1);
            this.Controls.Add(this.PluginListPanel);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "PluginManager";
            this.Text = "PluginManager";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.PluginListPanel.ResumeLayout(false);
            this.PluginListPanel.PerformLayout();
            this.PluginTabsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.SplitContainer SplitPanelContainer;
        private System.Windows.Forms.Button RefreshPluginsButton;
        private PluginListBox PluginList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private PluginTabControl PluginTabs;
        private System.Windows.Forms.Label PluginsHeaderLabel;
        private System.Windows.Forms.Panel PluginListPanel;
        private CollapsibleSplitter collapsibleSplitter1;
        private System.Windows.Forms.Panel PluginTabsPanel;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel BusyLabel;
        private System.Windows.Forms.ToolStripStatusLabel ErrorLabel;
        private System.Windows.Forms.ToolStripStatusLabel InfoLabel;
        private System.Windows.Forms.ToolStripStatusLabel WarningLabel;
    }
}

