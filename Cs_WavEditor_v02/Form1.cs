using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Cs_WavEditor_v02
{
    public partial class Form1 : Form
    {
        string winDir = System.Environment.GetEnvironmentVariable("windir");



        AudioFile audioClipboard = new AudioFile();
        List<string> recent_filenames = new List<string>();

        AudioPlaybackManager playbackManager = new AudioPlaybackManager();
        System.Timers.Timer updateScreenTimer;

        bool programmerMode = true;


        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);

                string filename = file;
                //string[] filelines = File.ReadAllLines(filename);
                //textBox1.Text += filelines[0];

                a = new AudioFile();

                a.OpenWav(filename);

                AddToRecentFiles(filename);
                RebuildRecentFiles();

                UpdateAudioInfo(a);


                MdiChildForm newMDIChild = new MdiChildForm();
                // Set the Parent Form of the Child window.  
                newMDIChild.MdiParent = this;

                newMDIChild.audio = a;
                newMDIChild.Text = newMDIChild.filename = filename;

                numericUpDownSelStart.Maximum = a.length;
                numericUpDownSelEnd.Maximum = a.length;

                // Display the new form.  
                newMDIChild.Show();

            }
        }


        public Form1()
        {

            InitializeComponent();
            this.MdiChildActivate += new EventHandler(Form1_MdiChildActivate);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(scroll_MouseWheel);
            this.Text = "Cs Wav Editor v01";

            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            LoadSettings();
        }

        void RebuildRecentFiles()
        {

            openRecentToolStripMenuItem.DropDownItems.Clear();

            foreach (var filename in recent_filenames)
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = filename;
                    openRecentToolStripMenuItem.DropDownItems.Add(item);
                    item.Click += new EventHandler((sender, e) => OpenRecentFile(sender, e, item.Text));
                }
            }
        }

        void LoadSettings()
        {
            recent_filenames.Insert(0, Properties.Settings.Default.recentFile0);
            recent_filenames.Insert(1, Properties.Settings.Default.recentFile1);
            recent_filenames.Insert(2, Properties.Settings.Default.recentFile2);
            recent_filenames.Insert(3, Properties.Settings.Default.recentFile3);
            recent_filenames.Insert(4, Properties.Settings.Default.recentFile4);
            recent_filenames.Insert(5, Properties.Settings.Default.recentFile5);
            recent_filenames.Insert(6, Properties.Settings.Default.recentFile6);
            recent_filenames.Insert(7, Properties.Settings.Default.recentFile7);
            recent_filenames.Insert(8, Properties.Settings.Default.recentFile8);
            recent_filenames.Insert(9, Properties.Settings.Default.recentFile9);

            foreach (var filename in recent_filenames)
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = filename;
                    openRecentToolStripMenuItem.DropDownItems.Add(item);
                    item.Click += new EventHandler((sender, e) => OpenRecentFile(sender, e, item.Text));
                }
            }

        }

        void SaveRecentFileList()
        {
            Properties.Settings.Default.recentFile0 = recent_filenames.ElementAt(0);
            Properties.Settings.Default.recentFile1 = recent_filenames.ElementAt(1);
            Properties.Settings.Default.recentFile2 = recent_filenames.ElementAt(2);
            Properties.Settings.Default.recentFile3 = recent_filenames.ElementAt(3);
            Properties.Settings.Default.recentFile4 = recent_filenames.ElementAt(4);
            Properties.Settings.Default.recentFile5 = recent_filenames.ElementAt(5);
            Properties.Settings.Default.recentFile6 = recent_filenames.ElementAt(6);
            Properties.Settings.Default.recentFile7 = recent_filenames.ElementAt(7);
            Properties.Settings.Default.recentFile8 = recent_filenames.ElementAt(8);
            Properties.Settings.Default.recentFile9 = recent_filenames.ElementAt(9);

            Properties.Settings.Default.Save();
        }


        void AddToRecentFiles(string filenameIn)
        {

            string stringTemp = filenameIn;
            int alreadyThere = -1;

            for (int i = 0; i < recent_filenames.Count; i++)
            {

                var it = recent_filenames.ElementAt(i);

                if (it.Equals(stringTemp) == true)
                {                   //match

                    alreadyThere = i;       //get index

                }
            }

            if (alreadyThere != -1)
            {
                recent_filenames.RemoveAt(alreadyThere);
            }

            recent_filenames.Insert(0, stringTemp);

            if (recent_filenames.Count > 10)
            {
                recent_filenames.RemoveAt(10);
            }

            //update recent files
            SaveRecentFileList();



        }






        private void button1_Click(object sender, System.EventArgs e)
        {



        }



        private void button3_Click(object sender, System.EventArgs e)
        {

        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            //Demonstrates how to obtain a list of disk drives.
            this.listBox1.Items.Clear();
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                addListItem(drive);
            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            //How to get a list of folders (example uses Windows folder). 
            this.listBox1.Items.Clear();
            string[] dirs = Directory.GetDirectories(winDir);
            foreach (string dir in dirs)
            {
                addListItem(dir);
            }
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            //How to obtain list of files (example uses Windows folder).
            this.listBox1.Items.Clear();
            string[] files = Directory.GetFiles(winDir);
            foreach (string i in files)
            {
                addListItem(i);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void Delete()
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            activeChild.Delete();
            UpdateAudioInfo(activeChild.audio);

        }

        private void Cut()
        {
            //copy selection area to clipboard
            //delete

            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            //activeChild.audio.Copy(selectionStart, selectionEnd);
            if (activeChild.audio.bitsPerSample == 16)
            {

                audioClipboard.SetFormatBasedOn(activeChild.audio);
                int clipboardLengthS = audioClipboard.channels * (activeChild.audio.selectionEnd - activeChild.audio.selectionStart);
                audioClipboard.lengthTotal = clipboardLengthS;
                audioClipboard.length = clipboardLengthS / audioClipboard.channels;
                audioClipboard.audioBuffer16 = new short[clipboardLengthS];
                Array.Copy(activeChild.audio.audioBuffer16, activeChild.audio.selectionStart, audioClipboard.audioBuffer16, 0, clipboardLengthS);        //length is number of elements, not bytes
                                                                                                                                                         //Array.Copy(activeChild.audio.audioBuffer16, activeChild.audio.selectionStart, clipboardBuffer, 0, length);      //will this work?
                activeChild.Delete();

                toolStripStatusLabel1.Text = "Copy only for now " + (clipboardLengthS / audioClipboard.channels) + " " + MyFuncs.GetStereoStr(audioClipboard.channels) + " samples";
            }
            else if (activeChild.audio.bitsPerSample == 24)
            {

                audioClipboard.SetFormatBasedOn(activeChild.audio);
                int clipboardLengthS = audioClipboard.channels * (activeChild.audio.selectionEnd - activeChild.audio.selectionStart);
                audioClipboard.lengthTotal = clipboardLengthS;
                audioClipboard.length = clipboardLengthS / audioClipboard.channels;

                //above unchanged from 16 bit
                audioClipboard.audioBuffer32 = new int[clipboardLengthS];
                Array.Copy(activeChild.audio.audioBuffer32, activeChild.audio.selectionStart, audioClipboard.audioBuffer32, 0, clipboardLengthS);        //length is number of elements, not bytes

                //Array.Copy(activeChild.audio.audioBuffer16, activeChild.audio.selectionStart, clipboardBuffer, 0, length);      //will this work?

                //below also unchanged
                activeChild.Delete();
                toolStripStatusLabel1.Text = "Copy only for now " + (clipboardLengthS / audioClipboard.channels) + " " + MyFuncs.GetStereoStr(audioClipboard.channels) + " samples";
            }


        }

        private void Copy()
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;

            //activeChild.audio.Copy(selectionStart, selectionEnd);
            if (activeChild.audio.bitsPerSample == 16)
            {

                audioClipboard.SetFormatBasedOn(activeChild.audio);
                int clipboardLengthS = audioClipboard.channels * (activeChild.audio.selectionEnd - activeChild.audio.selectionStart);
                audioClipboard.lengthTotal = clipboardLengthS;
                audioClipboard.length = clipboardLengthS / audioClipboard.channels;
                audioClipboard.audioBuffer16 = new short[clipboardLengthS];
                Array.Copy(activeChild.audio.audioBuffer16, activeChild.audio.selectionStart, audioClipboard.audioBuffer16, 0, clipboardLengthS);        //length is number of elements, not bytes
                                                                                                                                                         //Array.Copy(activeChild.audio.audioBuffer16, activeChild.audio.selectionStart, clipboardBuffer, 0, length);      //will this work?
                toolStripStatusLabel1.Text = "Copied " + (clipboardLengthS / audioClipboard.channels) + " " + MyFuncs.GetStereoStr(audioClipboard.channels) + " samples";
            }
        }

        private void Paste()
        {

            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (activeChild.Paste(audioClipboard, 0) == 1)
            {
                UpdateAudioInfo(activeChild.audio);
                toolStripStatusLabel1.Text = "Pasted " + (audioClipboard.length) + " " + MyFuncs.GetStereoStr(audioClipboard.channels) + " samples";
                activeChild.UpdateFileChanged();
                activeChild.Invalidate();
            }

        }




        public void UpdateAudioInfo(AudioFile a)
        {
            this.listBox1.Items.Clear();
            addListItem("channels:" + a.channels);
            addListItem("sampleRate:" + a.sampleRate);
            addListItem("size:" + a.size);
            addListItem("length:" + a.length);
            addListItem("bitsPerSample:" + a.bitsPerSample);

            string time = MyFuncs.ConvertLengthToTime(a.length, a.sampleRate);
            addListItem("time:" + time);


        }

        private void scroll_MouseWheel(object sender, MouseEventArgs e)
        {

            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (e.Delta > 0)
            {
                activeChild.ZoomOut();
            }
            else if (e.Delta < 0)
            {
                activeChild.ZoomIn();
            }
        }


        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (playbackManager.currentPlayState == AudioPlaybackManager.PlayState.Playing)
            {
                MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
                //activeChild.UpdateCurrentPosition(playbackManager.GetPositionMs());
                toolStripStatusLabel1.Text = "pos:" +
                    playbackManager.GetPositionS() + ":" +
                    playbackManager.GetPositionMs();

                //activeChild.audio.selectionEnd = (int)playbackManager.GetPositionInFrames();
                activeChild.audio.marker = (int)(playbackManager.GetPositionInBytes() / activeChild.audio.blockAlign);
                activeChild.audio.marker = (int)(playbackManager.GetPositionInFrames());

                activeChild.Invalidate();

                toolStripStatusLabel3.Text = "pos in frames: " + playbackManager.GetPositionInFrames();


            }
            else if (playbackManager.currentPlayState == AudioPlaybackManager.PlayState.Stopped)
            {
                updateScreenTimer.Enabled = false;
            }

        }


        void NewFile()
        {

            Form_NewWav diag = new Form_NewWav();
            if (diag.ShowDialog() == DialogResult.OK)
            {

                int smp = diag.GetSampleRate();
                int bitDepth = diag.GetBitDepth();
                int channels = diag.GetChannels();


                MdiChildForm newMDIChild = new MdiChildForm();
                newMDIChild.MdiParent = this;
                newMDIChild.Text = "Untitled";
                newMDIChild.audio = new AudioFile(smp, bitDepth, channels);
                newMDIChild.Show();

                diag.Close();
            }
            else if (diag.ShowDialog() == DialogResult.Cancel)
            {
                diag.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;

            if (keyData == Keys.Delete)
            {
                activeChild.Delete();
            }

            if (keyData == Keys.OemMinus)
            {
                activeChild.ZoomOut();
            }
            if (keyData == Keys.Oemplus)
            {
                activeChild.ZoomIn();
            }

            if (keyData == Keys.Space)
            {
                if (activeChild != null)
                {
                    playbackManager.PrepareAudio(activeChild.audio, activeChild);
                    if (playbackManager.PlayPause() == AudioPlaybackManager.PlayState.Playing)
                    {

                        updateScreenTimer = new System.Timers.Timer();
                        updateScreenTimer.Interval = 200;
                        updateScreenTimer.Elapsed += Timer_Elapsed;
                        updateScreenTimer.Start();

                    }
                 


                }
            }

            if (keyData == (Keys.Control | Keys.N))
            {
                NewFile();
            }

            if (keyData == (Keys.Control | Keys.A))
            {
                activeChild.SelectAll();
            }

            if (keyData == (Keys.Control | Keys.C))
            {
                Copy();
            }
            if (keyData == (Keys.Control | Keys.X))
            {
                Cut();
            }
            if (keyData == (Keys.Control | Keys.V))
            {
                Paste();
            }


            if (keyData == (Keys.Control | Keys.O))
            {
                // Create a new OpenFileDialog and display it.
                OpenFileDialog fd = new OpenFileDialog();


                fd.Title = "Open Wav File";
                fd.Filter = "WAV files|*.wav";
                //fd.InitialDirectory = @"C:\";


                if (fd.ShowDialog() == DialogResult.OK)
                {

                    string filename = fd.FileName;
                    //string[] filelines = File.ReadAllLines(filename);
                    //textBox1.Text += filelines[0];

                    a = new AudioFile();

                    a.OpenWav(filename);

                    AddToRecentFiles(filename);
                    RebuildRecentFiles();

                    UpdateAudioInfo(a);


                    MdiChildForm newMDIChild = new MdiChildForm();
                    // Set the Parent Form of the Child window.  
                    newMDIChild.MdiParent = this;

                    newMDIChild.audio = a;
                    newMDIChild.Text = newMDIChild.filename = filename;

                    numericUpDownSelStart.Maximum = a.length;
                    numericUpDownSelEnd.Maximum = a.length;

                    // Display the new form.  
                    newMDIChild.Show();


                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void OpenRecentFile(Object sender, EventArgs e, string filename)
        {



            a = new AudioFile();

            a.OpenWav(filename);
            UpdateAudioInfo(a);


            MdiChildForm newMDIChild = new MdiChildForm();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;

            newMDIChild.audio = a;
            newMDIChild.Text = newMDIChild.filename = filename;

            numericUpDownSelStart.Maximum = a.length;
            numericUpDownSelEnd.Maximum = a.length;

            AddToRecentFiles(filename);
            RebuildRecentFiles();

            // Display the new form.  
            newMDIChild.Show();

        }

        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // Create a new OpenFileDialog and display it.
            OpenFileDialog fd = new OpenFileDialog();


            fd.Title = "Open Wav File";
            fd.Filter = "WAV files|*.wav";
            //fd.InitialDirectory = @"C:\";


            if (fd.ShowDialog() == DialogResult.OK)
            {

                string filename = fd.FileName;
                //string[] filelines = File.ReadAllLines(filename);
                //textBox1.Text += filelines[0];

                a = new AudioFile();

                a.OpenWav(filename);

                this.listBox1.Items.Clear();
                UpdateAudioInfo(a);

                AddToRecentFiles(filename);
                RebuildRecentFiles();


                MdiChildForm newMDIChild = new MdiChildForm();
                // Set the Parent Form of the Child window.  
                newMDIChild.MdiParent = this;

                newMDIChild.audio = a;
                newMDIChild.Text = newMDIChild.filename = filename;

                numericUpDownSelStart.Maximum = a.length;
                numericUpDownSelEnd.Maximum = a.length;

                // Display the new form.  
                newMDIChild.Show();


            }



        }



        private void buttonZ1_Click(object sender, System.EventArgs e)
        {
            //How to obtain list of files (example uses Windows folder).
            this.listBox1.Items.Clear();
            string[] files = Directory.GetFiles(winDir);
            foreach (string i in files)
            {

                addListItem(i);
            }

            textBox1.Text += "Initial text contents of the TextBox.";

        }

        private void buttonZ2_Click(object sender, System.EventArgs e)
        {

            textBox1.Text += ("currentDir: " + Directory.GetCurrentDirectory());
        }

        public void butttons(object sender, System.EventArgs e)
        {
            int button = 0;
            switch (button)
            {
                case 0:
                    {
                        //How to obtain list of files (example uses Windows folder).
                        this.listBox1.Items.Clear();
                        string[] files = Directory.GetFiles(winDir);
                        foreach (string i in files)
                        {

                            addListItem(i);
                        }

                        textBox1.Text += "Initial text contents of the TextBox.";
                    }
                    break;

                case 1:
                    {
                        textBox1.Text += ("currentDir: " + Directory.GetCurrentDirectory());
                    }
                    break;

                case 2:
                    {
                        //Reads text file line by line...
                        int lineCounter = 0;

                        //How to read a text file.
                        //try...catch is to deal with a 0 byte file.
                        this.listBox1.Items.Clear();
                        StreamReader reader = new StreamReader(winDir + "\\system.ini");
                        try
                        {
                            do
                            {
                                String line = reader.ReadLine();
                                addListItem(line);

                                //for first line, split up into words (seperated by ' ')
                                if (lineCounter == 0)
                                {

                                    string[] words = line.Split(' ');

                                    foreach (var word in words)
                                    {
                                        //System.Console.WriteLine($"<{word}>");
                                        addListItem("+" + word);

                                        if (word.StartsWith("16", StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            addListItem("... what i was searching for!");
                                        }


                                    }

                                }

                                lineCounter++;
                            }
                            while (reader.Peek() != -1);
                        }
                        catch
                        {
                            addListItem("File is empty");
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                    break;

                case 3:
                    {

                    }
                    break;
            }
        }


        AudioFile a;
        private Image picture;
        private Point pictureLocation;
        Draw d = new Draw();
        protected override void OnPaint(PaintEventArgs e)
        {



            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);
            d.DrawStuff(e, a);
            if (this.picture != null && this.pictureLocation != Point.Empty)
            {
                e.Graphics.DrawImage(this.picture, this.pictureLocation);



            }
        }







        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void addListItem(string value)
        {
            this.listBox1.Items.Add(value);
        }

        private void bloopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form.  
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control, which  
            // in this example should be a RichTextBox.  
            if (activeChild != null)
            {
                try
                {
                    RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Put the selected text on the Clipboard.  
                        Clipboard.SetDataObject(theBox.SelectedText);

                        MessageBox.Show("the text is:" + theBox.Text);

                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a RichTextBox.");
                }
            }
        }

        private void zoopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form.  
            //Form activeChild = this.ParentForm.ActiveMdiChild;

            // Determine the active child form.  
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control, which  
            // in this example should be a RichTextBox.  
            if (activeChild != null)
            {
                try
                {
                    RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Create a new instance of the DataObject interface.  
                        IDataObject data = Clipboard.GetDataObject();
                        // If the data is text, then set the text of the   
                        // RichTextBox to the text in the clipboard.  
                        if (data.GetDataPresent(DataFormats.Text))
                        {
                            theBox.SelectedText = data.GetData(DataFormats.Text).ToString();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a RichTextBox.");
                }
            }
        }








        private void Form1_MdiChildActivate(Object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                UpdateAudioInfo(activeChild.audio);
            }
            //mdi event chamge
            //MessageBox.Show("You are in the Form.MdiChildActivate event.");
        }

        private void goopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form.  
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control, which  
            // in this example should be a RichTextBox.  
            if (activeChild != null)
            {
                ((MdiChildForm)activeChild).ZoomIn();
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form activeChild = this.ActiveMdiChild;

            if (activeChild != null)
            {
                ((MdiChildForm)activeChild).ZoomOut();
            }
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        public void numericUpDownSelStart_UpdateFromChild(int valueIn)
        {
            if (valueIn > -1 && valueIn < numericUpDownSelStart.Maximum)
                numericUpDownSelStart.Value = valueIn;
        }
        public void numericUpDownSelEnd_UpdateFromChild(int valueIn)
        {
            if (valueIn > numericUpDownSelStart.Maximum)
                numericUpDownSelEnd.Value = numericUpDownSelStart.Maximum;
            else
                numericUpDownSelEnd.Value = valueIn;
        }

        private void numericUpDownSelStart_ValueChanged(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild == null)
                return;

            ((MdiChildForm)activeChild).audio.selectionStart = (int)numericUpDownSelStart.Value;
            activeChild.Invalidate();

        }

        private void numericUpDownSelEnd_ValueChanged(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild == null)
                return;

            ((MdiChildForm)activeChild).audio.selectionEnd = (int)numericUpDownSelEnd.Value;
            activeChild.Invalidate();
        }

        private void findPeakLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void getPeakLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findPeakLevelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                AudioAnalysing.GetPeakLevel(((MdiChildForm)activeChild).audio);
            }
        }

        private void analyseStereoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                AudioAnalysing.AnalyseStereo(((MdiChildForm)activeChild).audio);
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                //activeChild.Play();
                MessageBox.Show("Use spacebar instead");
            }
        }

        private void convertToStereoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                activeChild.ConvertToStereo();

                activeChild.Invalidate();
                UpdateAudioInfo(activeChild.audio);
                activeChild.UpdateFileChanged();

            }

        }

        private void convertToMonoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {

                // Create a new OpenFileDialog and display it.
                SaveFileDialog fd = new SaveFileDialog();
                fd.DefaultExt = "*.*";

                fd.Title = "Save Wav File";
                fd.Filter = "WAV files|*.wav";
                //fd.InitialDirectory = @"C:\";

                if (!String.IsNullOrEmpty(activeChild.filename))
                {
                    fd.InitialDirectory = Path.GetDirectoryName(activeChild.filename);
                    fd.FileName = Path.GetFileName(activeChild.filename);
                }

                fd.ShowDialog();

                if (fd.FileName != "")
                {
                    string filename = fd.FileName;

                    activeChild.audio.SaveWav(fd.FileName);

                    activeChild.Text = activeChild.filename = filename;
                    AddToRecentFiles(filename);
                    RebuildRecentFiles();

                    toolStripStatusLabel1.Text = "Saved File";
                    activeChild.fileChanged = false;

                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            //from tileeditor
            /*
            if (String.IsNullOrEmpty(activeChild.filename))
                {

                }
                else
                {
                    string filename = activeChild.filename;
                    TiledFileIO.SaveFile(filename, activeChild.level);

                    AddToRecentFiles(filename);
                    RebuildRecentFiles();

                    toolStripStatusLabel1.Text = "Saved File";
                    activeChild.Text = activeChild.filename = filename;
                    activeChild.fileChanged = false;
                }
            */

            if (String.IsNullOrEmpty(activeChild.filename))
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.DefaultExt = "*.*";

                fd.Title = "Save Wav File";
                fd.Filter = "WAV files|*.wav";
                //fd.InitialDirectory = @"C:\";

                fd.ShowDialog();

                if (fd.FileName != "")
                {
                    activeChild.audio.SaveWav(fd.FileName);
                    toolStripStatusLabel1.Text = "Saved File";
                }
            }
            else
            {
                string filename = activeChild.filename;
                activeChild.audio.SaveWav(filename);
                activeChild.fileChanged = false;
                activeChild.Text = activeChild.filename = filename;
                toolStripStatusLabel1.Text = "Saved File";

            }

        }

        private void exportRAWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                // Create a new OpenFileDialog and display it.
                SaveFileDialog fd = new SaveFileDialog();
                fd.DefaultExt = "*.*";

                fd.Title = "Save RAW File";
                fd.Filter = "RAW files|*.raw";
                //fd.InitialDirectory = @"C:\";

                fd.ShowDialog();

                if (fd.FileName != "")
                {
                    activeChild.audio.SaveRaw(fd.FileName);
                    toolStripStatusLabel1.Text = "Saved File";
                }
            }

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                Paste();
            }
        }

        private void exportTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {

                bool NEW_WAY = true;
                if (NEW_WAY)
                {
                    Dialog_ExportText diag = new Dialog_ExportText();
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        /*
                        int valuesPerLine = diag.valuesPerLine;
                        bool groupSingleValuesIfStereo = diag.groupSingleValuesIfStereo;
                        bool littleEndian = diag.littleEndian;
                        int numberFormat = diag.numberFormat;
                        bool printLineNumber = diag.printSampleNumber;
                        */

                        TextExportOptions textOptions = diag.textExport;

                        diag.Close();

                        // Create a new OpenFileDialog and display it.
                        SaveFileDialog fd = new SaveFileDialog();
                        fd.DefaultExt = "*.*";

                        fd.Title = "Save TXT File";
                        fd.Filter = "TXT files|*.txt";
                        //fd.InitialDirectory = @"C:\";
                        if (!String.IsNullOrEmpty(activeChild.filename))
                        {
                            fd.InitialDirectory = Path.GetDirectoryName(activeChild.filename);
                            fd.FileName = Path.GetFileName(activeChild.filename);
                        }

                        fd.ShowDialog();

                        if (fd.FileName != "")
                        {
                            //activeChild.audio.ExportTextNew(fd.FileName, numberFormat, valuesPerLine, littleEndian, groupSingleValuesIfStereo);
                            activeChild.audio.ExportTextNew2(fd.FileName, textOptions);
                            toolStripStatusLabel1.Text = "Saved File";
                        }
                    }
                    else if (diag.ShowDialog() == DialogResult.Cancel)
                    {
                        diag.Close();
                    }

                }
                else
                {
                    // Create a new OpenFileDialog and display it.
                    SaveFileDialog fd = new SaveFileDialog();
                    fd.DefaultExt = "*.*";

                    fd.Title = "Save TXT File";
                    fd.Filter = "TXT files|*.txt";
                    //fd.InitialDirectory = @"C:\";
                    if (!String.IsNullOrEmpty(activeChild.filename))
                    {
                        fd.InitialDirectory = Path.GetDirectoryName(activeChild.filename);
                        fd.FileName = Path.GetFileName(activeChild.filename);
                    }

                    fd.ShowDialog();

                    if (fd.FileName != "")
                    {
                        activeChild.audio.ExportText(fd.FileName);
                        toolStripStatusLabel1.Text = "Saved File";
                    }
                } //else OLD_WAY

            }
        }

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                if (activeChild.Crop() == 1)
                {
                    UpdateAudioInfo(activeChild.audio);
                    toolStripStatusLabel1.Text = "Audio cropped";
                    activeChild.Invalidate();
                    activeChild.UpdateFileChanged();
                }
            }
        }

        private void silenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                if (activeChild.Silence() == 1)
                {
                    toolStripStatusLabel1.Text = "Selection silenced";
                    activeChild.Invalidate();
                }
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            activeChild.SelectAll();
        }



        public void DisplayCurrentSampleAndValue(int sampleNo, string value1)
        {
            toolStripStatusLabel2.Text = "Sample #" + sampleNo + "=";
            toolStripStatusLabel2.Text += value1;
        }

        private void programmerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.Equals(programmerModeToolStripMenuItem.Text, "Programmer Mode"))
            {
                toolStripSplitButton1.Text = "Programmer Mode";
                programmerMode = true;
            }

        }

        private void audioModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton1.Text = "Audio Mode";
            programmerMode = false;
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void useLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                activeChild.ConvertToMono(0);

                activeChild.Invalidate();
                UpdateAudioInfo(activeChild.audio);
            }
        }

        private void useRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                activeChild.ConvertToMono(1);

                activeChild.Invalidate();
                UpdateAudioInfo(activeChild.audio);
            }
        }

        private void mixLRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild != null)
            {
                activeChild.ConvertToMono(2);

                activeChild.Invalidate();
                UpdateAudioInfo(activeChild.audio);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void amplifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            Dialog_Amplify diag = new Dialog_Amplify();
            if (diag.ShowDialog() == DialogResult.OK)
            {

                //int smp = diag.GetSampleRate();
                //int bitDepth = diag.GetBitDepth();
                //int channels = diag.GetChannels();
                double scaler = diag.GetAmplification();
                if (activeChild.Amplify(scaler))
                {
                    toolStripStatusLabel1.Text = "Selection amplified";
                    UpdateAudioInfo(activeChild.audio);
                    activeChild.Invalidate();
                }



                diag.Close();
            }
            else if (diag.ShowDialog() == DialogResult.Cancel)
            {
                diag.Close();
            }


        }

        private void normaliseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            Dialog_Normalise diag = new Dialog_Normalise();
            if (diag.ShowDialog() == DialogResult.OK)
            {

                double newPeak = diag.GetAmplification();
                int currentPeak = AudioAnalysing.GetPeakLevel(activeChild.audio);       //wont work. this function jsut returns 1/0
                double doubleCurrentPeak = 0;
                if (activeChild.audio.bitsPerSample == 16) doubleCurrentPeak = (currentPeak / 32767.0);
                double amplification = newPeak / doubleCurrentPeak;

                if (activeChild.Amplify(amplification))
                {
                    toolStripStatusLabel1.Text = "Selection normalised";
                    UpdateAudioInfo(activeChild.audio);
                    activeChild.Invalidate();
                }

                diag.Close();
            }
            else if (diag.ShowDialog() == DialogResult.Cancel)
            {
                diag.Close();
            }
        }

        private void resampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            Dialog_Resample diag = new Dialog_Resample();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                int newSampleRate = diag.GetNewSampleRate();

                activeChild.Resample(newSampleRate);
                toolStripStatusLabel1.Text = "File resampled";
                UpdateAudioInfo(activeChild.audio);
                activeChild.Invalidate();




                diag.Close();
            }
            else if (diag.ShowDialog() == DialogResult.Cancel)
            {
                diag.Close();
            }
        }

        private void generateSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Dialog_GenerateSound diag = new Dialog_GenerateSound();
            if (diag.ShowDialog() == DialogResult.OK)
            {

                a = new AudioFile();
                a.GenerateNewWav(1, 44100, 16, 999);

                this.listBox1.Items.Clear();
                UpdateAudioInfo(a);
                MdiChildForm newMDIChild = new MdiChildForm();
                // Set the Parent Form of the Child window.  
                newMDIChild.MdiParent = this;

                newMDIChild.audio = a;
                newMDIChild.Text = newMDIChild.filename = "New wave";

                numericUpDownSelStart.Maximum = a.length;
                numericUpDownSelEnd.Maximum = a.length;

                // Display the new form.  
                newMDIChild.Show();

                diag.Close();
            }
            else if (diag.ShowDialog() == DialogResult.Cancel)
            {
                diag.Close();
            }
        }

        private void shrinkExtendWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            Dialog_Prog_ShrinkExtend diag = new Dialog_Prog_ShrinkExtend(activeChild.audio.length);
            if (diag.ShowDialog() == DialogResult.OK)
            {
                if (activeChild.audio.AdjustLength(diag.newLength) == 1)
                {
                    activeChild.Invalidate();
                    activeChild.UpdateFileChanged();
                    UpdateAudioInfo(activeChild.audio);
                }

                diag.Close();
            }
            else if (diag.ShowDialog() == DialogResult.Cancel)
            {
                diag.Close();
            }
        }

        private void compareWavsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findLastNonzeroFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            AudioAnalysing.FindLastNonZeroValue(((MdiChildForm)activeChild).audio);

        }

        private void pasteIntoOppositeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (activeChild != null)
            {
                //if this stereo, tell user to convert to mono first
                //if clipboard empty, dont proceed
                //if sample rate different, bitdepth different, dont proceed

                if (activeChild.audio.channels == 2)
                {
                    MessageBox.Show("Error: Ensure active wav is mono format");
                    return;
                }
                activeChild.ConvertToStereo(true);

                if (activeChild.PasteInto2ndChannel(audioClipboard, 0) == 1)
                {

                }

                UpdateAudioInfo(activeChild.audio);
                activeChild.UpdateFileChanged();
                activeChild.Invalidate();


            }
        }

        private void pasteMixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (activeChild.PasteMix(audioClipboard, 0) == 1)         //this function not yet complete
            {
                UpdateAudioInfo(activeChild.audio);
                toolStripStatusLabel1.Text = "Pasted " + (audioClipboard.length) + " " + MyFuncs.GetStereoStr(audioClipboard.channels) + " samples";
                activeChild.UpdateFileChanged();
                activeChild.Invalidate();
            }
        }

        private void bit8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (activeChild.SetBitDepth(8) == 1)
            {
                UpdateAudioInfo(activeChild.audio);
                toolStripStatusLabel1.Text = "Adjusted bit depth ";
                activeChild.UpdateFileChanged();
                activeChild.Invalidate();
            }
        }

        private void bit16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (activeChild.SetBitDepth(16) == 1)
            {
                UpdateAudioInfo(activeChild.audio);
                toolStripStatusLabel1.Text = "Adjusted bit depth ";
                activeChild.UpdateFileChanged();
                activeChild.Invalidate();
            }
        }

        private void bit24ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MdiChildForm activeChild = (MdiChildForm)this.ActiveMdiChild;
            if (activeChild == null) return;

            if (activeChild.SetBitDepth(24) == 1)
            {
                UpdateAudioInfo(activeChild.audio);
                toolStripStatusLabel1.Text = "Adjusted bit depth ";
                activeChild.UpdateFileChanged();
                activeChild.Invalidate();
            }
        }
    } // class
}
