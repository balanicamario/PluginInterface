using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PluginLoader;

namespace Plugin.StickyNote
{
    /// <summary>
    /// A *very simple* example to show how to create a sticky notes plugin    
    /// </summary>
    [Plugin("Sticky Note", "A sticky notes plugin sample")]
    public partial class StickyNote : UserControl
    {
        readonly string NotesFile = AppDomain.CurrentDomain.BaseDirectory + "/plugins/Plugin.StickyNote/Note.txt";

        public StickyNote()
        {
            InitializeComponent();
            LoadNotes();
        }

        /// <summary>
        /// Saves the current text to the notes file
        /// </summary>
        private void SaveNotes()
        {
            noteSaver.Enabled = false;
            using (StreamWriter w = new StreamWriter(NotesFile))
            {
                w.AutoFlush = true;
                w.Write(noteEntry.Text);
                w.Close();
            }
            noteSaver.Enabled = true;
        }

        /// <summary>
        /// Loads the notes file
        /// </summary>
        private void LoadNotes()
        {
            CheckNotesFile();
            using (StreamReader r = new StreamReader(NotesFile))
            {
                noteEntry.Text = r.ReadToEnd();
                r.Close();
            }
        }

        /// <summary>
        /// Checks the notes file (creates one if not found)
        /// Loads the contents to screen
        /// </summary>
        private void CheckNotesFile()
        {
            if (!File.Exists(NotesFile))
            {
                File.CreateText(NotesFile).Close();
            }
        }


        /// <summary>
        /// Tick hanlder to save the note every now and then
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noteSaver_Tick(object sender, EventArgs e)
        {
            SaveNotes();
        }


        /// <summary>
        /// Initialize extra event handlers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StickyNote_Load(object sender, EventArgs e)
        {
            // Ensure the notes get saved in various events
            // Currently, we bother about only when 
            //     * the main form is closed
            //     * the tab that contains this plugin is removed
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
            ((TabControl)this.Parent.Parent).ControlRemoved += new ControlEventHandler(StickyNote_ControlRemoved);
        }


        void StickyNote_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control == this.Parent)
                SaveNotes();
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNotes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void noteEntry_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
