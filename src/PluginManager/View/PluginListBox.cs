using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginManager.Model;
using PluginManager.Controller;

namespace Citrus.Forms.PluginManager.View
{
    public partial class PluginListBox : ListBox
    {
        public PluginListBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;

        }

        public new PluginInfo SelectedItem
        {
            get { return (PluginInfo)base.SelectedItem; }
        }

        public void Add(PluginInfo pluginInfo)
        {
            Items.Add(pluginInfo);
        }

        public void Clear()
        {
            Items.Clear();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count > 0) // Handle design time issues
                DrawItemEx(e);

            // base.OnDrawItem(e);
        }

        private void DrawItemEx(DrawItemEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            Pen bgPen = new Pen(BackColor);

            PluginInfo pluginInfo = (PluginInfo)Items[e.Index];

            // Draw a custom icon if present
            Bitmap bitmap = IconSet.GetIcon(pluginInfo.Icon).ToBitmap();

            e.Graphics.DrawImage(bitmap, 2, e.Bounds.Y, 22, 22);

            e.Graphics.FillRectangle(
                bgPen.Brush,
                new RectangleF(24, e.Bounds.Y + 1, e.Bounds.Width - 16, 15)
            );

            e.Graphics.DrawString(
                     pluginInfo.Name,
                     Font,
                     blackPen.Brush,
                     new RectangleF(26, e.Bounds.Y + 5, e.Bounds.Width - 20, 15),
                     new StringFormat(StringFormatFlags.NoWrap)
                 );

            blackPen.Dispose();
            bgPen.Dispose();
        }
    }
}
