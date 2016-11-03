namespace Plugin.StickyNote
{
    partial class StickyNote
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.noteEntry = new System.Windows.Forms.TextBox();
            this.noteSaver = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noteEntry
            // 
            this.noteEntry.AcceptsReturn = true;
            this.noteEntry.AcceptsTab = true;
            this.noteEntry.AllowDrop = true;
            this.noteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noteEntry.Location = new System.Drawing.Point(4, 4);
            this.noteEntry.Multiline = true;
            this.noteEntry.Name = "noteEntry";
            this.noteEntry.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.noteEntry.Size = new System.Drawing.Size(474, 447);
            this.noteEntry.TabIndex = 0;
            this.noteEntry.TextChanged += new System.EventHandler(this.noteEntry_TextChanged);
            // 
            // noteSaver
            // 
            this.noteSaver.Enabled = true;
            this.noteSaver.Interval = 10000;
            this.noteSaver.Tick += new System.EventHandler(this.noteSaver_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StickyNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noteEntry);
            this.Name = "StickyNote";
            this.Size = new System.Drawing.Size(481, 500);
            this.Load += new System.EventHandler(this.StickyNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox noteEntry;
        private System.Windows.Forms.Timer noteSaver;
        private System.Windows.Forms.Button button1;
    }
}
