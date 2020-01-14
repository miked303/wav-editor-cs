using NAudio.Wave;
using SharpDX;
using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs_WavEditor_v02
{
    public partial class MdiChildForm : Form
    {


        public int id { get; set; }
        public AudioFile audio { get; set; }
        public string filename { get; set; }
        public bool fileChanged { get; set; } = false;

        //View
        int vertZoom;

        Draw d = new Draw();

        Point dragCoords = new Point();


        public MdiChildForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public void UpdateFileChanged(bool updated = true)
        {
            if (updated)
            {
                if (!fileChanged)
                {
                    fileChanged = true;
                    if (filename != null)
                        this.Text += "*";
                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);
            d.DrawStuff(e, audio, DisplayRectangle.Width, DisplayRectangle.Height - hScrollBar1.Height);

        }




        protected override void OnResize(System.EventArgs e)
        {

            /*
            Control control = (Control)sender;

          
            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }
            */
            base.OnResize(e);

            this.Invalidate();  // request a delayed Repaint by the normal MessageLoop system    
                                //this.Update();      // forces Repaint of invalidated area 
                                // this.Refresh();     // Combines Invalidate() and Update()


        }


        public void ZoomIn()
        {
            if (d.horizZoom > 0) d.horizZoom--;
            this.Invalidate();
            labelZoomStatus.Text = "horizZoom: " + d.horizZoom;
            labelSamplesPerP.Text = "Samples Per Pix: " + d.samplesPerPixel;
            labelPixPerSam.Text = "Pixels Per Sample: " + d.pixelsPerSample;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int x = hScrollBar1.Value;
            label1.Text = "ScrollBar Value:(OnScroll Event) " + x.ToString();
            d.scrollX = (audio.length * x) / 100;
            this.Invalidate();
        }

        private void MdiChildForm_Load(object sender, EventArgs e)
        {

        }



        private DialogResult SaveStuff()
        {

            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = "*.*";

            fd.Title = "Save Wav File";
            fd.Filter = "WAV files|*.wav";
            return fd.ShowDialog();

            return new SaveFileDialog().ShowDialog();

        }




        private void MdiChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!fileChanged)
                return;

            DialogResult dg = MessageBox.Show("Do you want to save changes?", "Closing", MessageBoxButtons.YesNoCancel);

            if (dg == DialogResult.Yes)
            {
                if (this.filename == null)
                //if (this.Text.Equals("Untitled") == true)     //if file isnt a new one, bring up new Save As
                {
                    //here
                    if (this.filename == null)
                    //if (this.Text.Equals("Untitled") == true)     //if file isnt a new one, bring up new Save As
                    {

                        // Create a new OpenFileDialog and display it.
                        SaveFileDialog fd = new SaveFileDialog();
                        fd.DefaultExt = "*.*";

                        fd.Title = "Save Wav File";
                        fd.Filter = "WAV files|*.wav";
                        //fd.InitialDirectory = @"C:\";

                        DialogResult r = fd.ShowDialog();

                        if (r == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else if (fd.FileName != "")
                        {
                            this.audio.SaveWav(fd.FileName);
                        }
                        else e.Cancel = true;
                    }


                }
                else
                {
                    this.audio.SaveWav(this.filename);            //otherwise just save to existing filename
                }

            }
            else if (dg == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }




        private void MdiChildForm_FormClosing2(object sender, FormClosingEventArgs e)
        {

            if (!fileChanged)
                return;

            DialogResult dg = MessageBox.Show("Do you want to save changes?", "Closing", MessageBoxButtons.YesNoCancel);

            if (dg == DialogResult.Yes)
            {
                if (this.filename == null)
                //if (this.Text.Equals("Untitled") == true)     //if file isnt a new one, bring up new Save As
                {
                    if (SaveStuff() == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }

                }
                else
                {
                    this.audio.SaveWav(this.filename);            //otherwise just save to existing filename
                }

            }
            else if (dg == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        public void ZoomOut()
        {
            d.horizZoom++;
            this.Invalidate();
            labelZoomStatus.Text = "horizZoom: " + d.horizZoom;
            labelSamplesPerP.Text = "Samples Per Pix: " + d.samplesPerPixel;
            labelPixPerSam.Text = "Pixels Per Sample: " + d.pixelsPerSample;
        }


        //Get sample number based on point on screen
        int GetSampleNumber(Point p)
        {
            int samplesToDraw = 16 << d.horizZoom;
            int pixelsPerSample = d.waveformAreaWidth / samplesToDraw;

            int x1 = 0;
            if (pixelsPerSample > 0)
            {


                x1 = p.X / pixelsPerSample + d.scrollX;
                label3.Text = "d.horizZoom: " + d.horizZoom + ", samplesToDraw: " + samplesToDraw + ", pixelsPerSample: " + pixelsPerSample + ", d.scrollX: " + d.scrollX + ", Areawidth: " + d.waveformAreaWidth;
            }
            else
            {
                int samplesPerPixel = samplesToDraw / d.waveformAreaWidth;

                x1 = p.X * samplesPerPixel;
                //what about scroll? one of these ?...
                //x1 += d.scrollX; ??
                //x1 += d.scrollX*samplesPerPixel;

                label3.Text = "d.horizZoom: " + d.horizZoom + ", samplesToDraw: " + samplesToDraw + ", samplesPerPixel: " + samplesPerPixel + ", d.scrollX: " + d.scrollX + ", Areawidth: " + d.waveformAreaWidth;
            }

            return x1;
        }


        private void MdiChildForm_MouseDown(object sender, EventArgs e)
        {

            labelMouseDown.Text = string.Format("Mouse Down X: {0} Y: {1}", MousePosition.X, MousePosition.Y);

            var relativePoint = this.PointToClient(MousePosition);
            dragCoords = relativePoint;


            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var sampleNo = GetSampleNumber(relativePoint);
                if (sampleNo < audio.length)
                {
                    //label1.Text = "Sample #" + sampleNo + "=";
                    //label1.Text += audio.GetSample(sampleNo);
                    Form1 frm = this.MdiParent as Form1;
                    frm.DisplayCurrentSampleAndValue(sampleNo, audio.GetSample(sampleNo));

                }

            }
            else if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                label1.Text += "yallallala";
            }


        }

        private void MdiChildForm_MouseUp(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));
            labelMouseUp.Text = string.Format("Mouse Up X: {0} Y: {1}", MousePosition.X, MousePosition.Y);
        }

        private void MdiChildForm_MouseMove(object sender, EventArgs e)
        {

            var relativePoint = this.PointToClient(MousePosition);
            labelMouseMove.Text = string.Format("Mouse Move X: {0} Y: {1}", MousePosition.X, MousePosition.Y);

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                label2.Text = "Left move"; ;
            }
            else if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                label2.Text = "right move";

                if (relativePoint.X > dragCoords.X)
                {
                    //dragging right >>>
                    Form1 frm = this.MdiParent as Form1;
                    if (frm != null)
                    {
                        frm.numericUpDownSelStart_UpdateFromChild(GetSampleNumber(dragCoords));
                        frm.numericUpDownSelEnd_UpdateFromChild(GetSampleNumber(relativePoint));
                    }

                }
                else if (relativePoint.X < dragCoords.X)
                {
                    //dragging left <<<
                    Form1 frm = this.MdiParent as Form1;
                    if (frm != null)
                    {
                        frm.numericUpDownSelStart_UpdateFromChild(GetSampleNumber(relativePoint));
                        frm.numericUpDownSelEnd_UpdateFromChild(GetSampleNumber(dragCoords));
                    }
                }

            }
            else
            {
                label2.Text = "no button move";
            }


        }


        public void PlayThisWorks()
        {
            var sampleRate = 16000;
            var frequency = 500;
            var amplitude = 0.2;
            var seconds = 5;

            var raw = new byte[sampleRate * seconds * 2];

            var multiple = 2.0 * frequency / sampleRate;
            for (int n = 0; n < sampleRate * seconds; n++)
            {
                var sampleSaw = ((n * multiple) % 2) - 1;
                var sampleValue = sampleSaw > 0 ? amplitude : -amplitude;
                var sample = (short)(sampleValue * Int16.MaxValue);
                var bytes = BitConverter.GetBytes(sample);
                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }


            var ms = new MemoryStream(raw);
            var rs = new RawSourceWaveStream(ms, new NAudio.Wave.WaveFormat(sampleRate, 16, 1));

            var wo = new WaveOutEvent();
            wo.Init(rs);
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(500);
            }
            wo.Dispose();
        }



        public void Play()
        {
            var sampleRate = audio.sampleRate;
            /*
            var frequency = 500;
            var amplitude = 0.2;
            var seconds = 5;

            var raw = new byte[sampleRate * seconds * 2];

            var multiple = 2.0 * frequency / sampleRate;
            for (int n = 0; n < sampleRate * seconds; n++)
            {
                var sampleSaw = ((n * multiple) % 2) - 1;
                var sampleValue = sampleSaw > 0 ? amplitude : -amplitude;
                var sample = (short)(sampleValue * Int16.MaxValue);
                var bytes = BitConverter.GetBytes(sample);
                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }

             var ms = new MemoryStream(raw);
            */


            MemoryStream ms;
            switch (audio.bitsPerSample)
            {
                case 8:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer8.Length];
                        Buffer.BlockCopy(audio.audioBuffer8, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;

                case 16:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer16.Length * 2];
                        Buffer.BlockCopy(audio.audioBuffer16, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;

                case 24:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer32.Length * 4];
                        Buffer.BlockCopy(audio.audioBuffer32, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;

                default:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer32.Length * 4];
                        Buffer.BlockCopy(audio.audioBuffer32, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;
            }

            int bps = (audio.bitsPerSample == 24) ? 32 : audio.bitsPerSample;
            //24bit being stored in a 32 bit buffer

            var rs = new RawSourceWaveStream(ms, new NAudio.Wave.WaveFormat(sampleRate, bps, audio.channels));

            var wo = new WaveOutEvent();
            wo.Init(rs);
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
            wo.Dispose();
        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }

        public void Play3()
        {
            var xaudio2 = new XAudio2();
            var v = xaudio2.GetDeviceDetails(0);
            var masteringVoice = new MasteringVoice(xaudio2);

            //var stream = new SoundStream(File.OpenRead(fileName));
            //var waveFormat = stream.Format;
            var dataStream = DataStream.Create(audio.audioBuffer16, true, true);

            var stream = new SoundStream(dataStream);

            var buffer = new AudioBuffer
            {
                //Stream = stream.ToDataStream(),
                Stream = stream,
                AudioBytes = (int)audio.length,
                Flags = BufferFlags.EndOfStream
            };

            var waveFormat = new SharpDX.Multimedia.WaveFormat();


            var sourceVoice = new SourceVoice(xaudio2, waveFormat, true);
            // Adds a sample callback to check that they are working on source voices
            sourceVoice.BufferEnd += (context) => Console.WriteLine(" => event received: end of buffer");
            sourceVoice.SubmitSourceBuffer(buffer, stream.DecodedPacketsInfo);
            sourceVoice.Start();





            masteringVoice.Dispose();
            xaudio2.Dispose();
        }

        public void Play2()
        {

            //var myBufferOfSamples = new short[44100 * 1 * 2];

            // Create a DataStream with pinned managed buffer
            //var dataStream = DataStream.Create(myBufferOfSamples, true, true);
            var dataStream = DataStream.Create(audio.audioBuffer16, true, true);


            var buffer = new AudioBuffer
            {
                Stream = dataStream,
                AudioBytes = (int)dataStream.Length,
                Flags = BufferFlags.EndOfStream
            };

            //...
            // Fill myBufferOfSamples
            //...

            // PCM 44.1Khz stereo 16 bit format
            var waveFormat = new SharpDX.Multimedia.WaveFormat();

            XAudio2 xaudio = new XAudio2();
            //MasteringVoice masteringVoice = new MasteringVoice(xaudio);
            MasteringVoice masteringVoice = new MasteringVoice(xaudio, 2, 44100, 0);
            var sourceVoice = new SourceVoice(xaudio, waveFormat, true);

            // Submit the buffer
            sourceVoice.SubmitSourceBuffer(buffer, null);

            // Start playing
            sourceVoice.Start();


            //no control over mono/stereo/bits/etc
            /*

            using (MemoryStream ms = new MemoryStream(audio.audioBuffer16))
            {
                // Construct the sound player
                SoundPlayer player = new SoundPlayer(ms);
                player.Play();
            }
            */


        }


        public void Paste(int bufferIn)
        {

        }

        public int Paste16(AudioFile clipboardAudio, int position)
        {

            int newLength = clipboardAudio.length + audio.length;
            short[] tempBuffer = new short[newLength * audio.channels];

            for (int i = 0; i < position; i++)
            {

                int iI = i * audio.channels;
                tempBuffer[iI] = audio.audioBuffer16[iI];
                if (audio.channels == 2)
                    tempBuffer[iI + 1] = audio.audioBuffer16[iI + 1];

            }

            for (int i = 0; i < clipboardAudio.length; i++)
            {

                int iI = i * audio.channels;
                tempBuffer[iI + (position * audio.channels)] = clipboardAudio.audioBuffer16[iI];
                if (audio.channels == 2)
                    tempBuffer[iI + 1 + (position * audio.channels)] = clipboardAudio.audioBuffer16[iI + 1];

            }

            for (int i = 0; i < (audio.length - position); i++)
            {

                int iI = i * audio.channels;
                tempBuffer[iI + ((position + clipboardAudio.length) * audio.channels)] = audio.audioBuffer16[iI + position * audio.channels];
                if (audio.channels == 2)
                    tempBuffer[iI + 1 + ((position + clipboardAudio.length) * audio.channels)] = audio.audioBuffer16[iI + 1 + position * audio.channels];

            }


            audio.audioBuffer16 = tempBuffer;

            audio.length = newLength;
            return 1;

        }

        //better to pass a paste object in -> it would contain details of its bitrate, samplerate, stereo status, etc
        public int Paste(AudioFile clipboardAudio, int position)
        {

            if (this.audio.sampleRate != clipboardAudio.sampleRate)
            {
                MessageBox.Show("Sample rate mismatch", "Error");
                return 0;
            }

            if (this.audio.bitsPerSample != clipboardAudio.bitsPerSample)
            {
                MessageBox.Show("Bitdepth mismatch", "Error");
                return 0;
            }


            //sample rate mismatch = disallow ?
            //mono -> stereo = copy twice
            //stereo -> mono = mix average
            //bitDepth mismatch = disallow ?

            switch (this.audio.bitsPerSample)
            {
                case 8:
                    {
                        //activeChild.Paste(clipboardBuffer8);
                        return 0;
                    }
                    break;
                case 16:
                    {
                        return this.Paste16(clipboardAudio, 0);
                    }
                    break;
                case 24:
                    {
                        //activeChild.Paste(clipboardBuffer32);
                        return 0;
                    }
                    break;
                default:
                    {
                        return 0;
                        //activeChild.Paste(clipboardBuffer32);
                    }
                    break;
            }

        }


        public int PasteMix(AudioFile clipboardAudio, int position)
        {

            if (this.audio.sampleRate != clipboardAudio.sampleRate)
            {
                MessageBox.Show("Sample rate mismatch", "Error");
                return 0;
            }

            if (this.audio.bitsPerSample != clipboardAudio.bitsPerSample)
            {
                MessageBox.Show("Bitdepth mismatch", "Error");
                return 0;
            }


            //sample rate mismatch = disallow ?
            //mono -> stereo = copy twice
            //stereo -> mono = mix average
            //bitDepth mismatch = disallow ?

            switch (this.audio.bitsPerSample)
            {
                case 8:
                    {
                        //activeChild.Paste(clipboardBuffer8);
                        return 0;
                    }
                    break;
                case 16:
                    {
                        //return this.Paste16(clipboardAudio, 0);
                    }
                    break;
                case 24:
                    {
                        //activeChild.Paste(clipboardBuffer32);
                        return 0;
                    }
                    break;
                default:
                    {
                        return 0;
                        //activeChild.Paste(clipboardBuffer32);
                    }
                    break;
            }

            return 0;
        }

        public void Paste(sbyte bufferIn)
        {

        }

        //new 2019 paste function. this one will paste into right hand channel only. ideally i want just one paste function that combines
        //on 2nd thoughts maybe not... this is more of a mix function then insert
        public int PasteInto2ndChannel(AudioFile clipboardAudio, int position)
        {

            if (this.audio.sampleRate != clipboardAudio.sampleRate)
            {
                MessageBox.Show("Sample rate mismatch", "Error");
                return 0;
            }

            if (this.audio.bitsPerSample != clipboardAudio.bitsPerSample)
            {
                MessageBox.Show("Bitdepth mismatch", "Error");
                return 0;
            }


            //sample rate mismatch = disallow ?
            //mono -> stereo = copy twice
            //stereo -> mono = mix average
            //bitDepth mismatch = disallow ?

            switch (this.audio.bitsPerSample)
            {
                case 8:
                    {
                        //activeChild.Paste(clipboardBuffer8);
                        return 0;
                    }
                    break;
                case 16:
                    {
                        //return this.Paste16(clipboardAudio, 0);
                        //return this.Paste16(clipboardAudio, 0);

                        int newLength = audio.length;           //keep length the same [different from other paste function]
                        short[] tempBuffer = new short[newLength * audio.channels];

                        for (int i = 0; i < audio.length; i++)          //v different
                        {

                            int iI = i * audio.channels;
                            tempBuffer[iI] = audio.audioBuffer16[iI];
                            //if (audio.channels == 2)
                            //    tempBuffer[iI + 1] = audio.audioBuffer16[iI + 1];

                            tempBuffer[iI + 1] = clipboardAudio.audioBuffer16[i];
                        }

                        audio.audioBuffer16 = tempBuffer;

                        audio.length = newLength;
                        return 1;
                    }
                    break;
                case 24:
                    {
                        //activeChild.Paste(clipboardBuffer32);
                        return 0;
                    }
                    break;
                default:
                    {
                        return 0;
                        //activeChild.Paste(clipboardBuffer32);
                    }
                    break;
            }

        }

        public int Delete()
        {

            int removeLength = audio.selectionEnd - audio.selectionStart;
            if (removeLength == 0)
                return 0;

            int newLength = audio.length - removeLength;

            switch (audio.bitsPerSample)
            {
                case 16:
                    {

                        short[] tempBuffer = new short[newLength * audio.channels];

                        for (int i = 0; i < audio.selectionStart; i++)
                        {
                            int iI = i * audio.channels;
                            tempBuffer[iI] = audio.audioBuffer16[iI];
                            if (audio.channels == 2)
                                tempBuffer[iI + 1] = audio.audioBuffer16[iI + 1];
                        }

                        for (int i = audio.selectionEnd; i < audio.length; i++)
                        {
                            int iI = i * audio.channels;
                            tempBuffer[(i - removeLength) * audio.channels] = audio.audioBuffer16[i * audio.channels];
                            if (audio.channels == 2)
                                tempBuffer[(i - removeLength) * audio.channels + 1] = audio.audioBuffer16[i * audio.channels + 1];
                        }

                        audio.audioBuffer16 = tempBuffer;
                        audio.length = newLength;

                        Invalidate();

                        return 1;
                    }

                case 24:
                    {

                        int[] tempBuffer = new int[newLength * audio.channels];     //16->24

                        for (int i = 0; i < audio.selectionStart; i++)
                        {
                            int iI = i * audio.channels;
                            tempBuffer[iI] = audio.audioBuffer32[iI];           //16->24
                            if (audio.channels == 2)
                                tempBuffer[iI + 1] = audio.audioBuffer32[iI + 1];       //16->24
                        }

                        for (int i = audio.selectionEnd; i < audio.length; i++)
                        {
                            int iI = i * audio.channels;
                            tempBuffer[(i - removeLength) * audio.channels] = audio.audioBuffer32[i * audio.channels];          //16->24
                            if (audio.channels == 2)
                                tempBuffer[(i - removeLength) * audio.channels + 1] = audio.audioBuffer32[i * audio.channels + 1];      //16->24
                        }

                        audio.audioBuffer32 = tempBuffer;                   //16->24
                        audio.length = newLength;

                        Invalidate();

                        return 1;
                    }

                default:
                    {
                        return 0;
                    }

            }

            return 0;
        }

        public int Crop()
        {
            switch (audio.bitsPerSample)
            {
                case 16:
                    {
                        int newLength = audio.selectionEnd - audio.selectionStart;
                        if (newLength == 0)
                            return 0;

                        short[] tempBuffer = new short[newLength * audio.channels];

                        for (int i = 0; i < newLength; i++)
                        {

                            int iI = i * audio.channels;
                            tempBuffer[iI] = audio.audioBuffer16[(audio.selectionStart * audio.channels) + iI];
                            if (audio.channels == 2)
                                tempBuffer[iI + 1] = audio.audioBuffer16[(audio.selectionStart * audio.channels) + iI + 1];

                        }

                        audio.audioBuffer16 = tempBuffer;
                        audio.length = newLength;

                        return 1;
                    }

                default:
                    {
                        return 0;
                    }

            }

            return 0;
        }

        public int Silence()
        {

            int selection = audio.selectionEnd - audio.selectionStart;
            if (selection == 0)
                return 0;

            switch (audio.bitsPerSample)
            {
                case 16:
                    {
                        for (int i = audio.selectionStart; i < audio.selectionEnd; i++)
                        {
                            audio.audioBuffer16[i * audio.channels] = 0;
                            if (audio.channels == 2)
                                audio.audioBuffer16[i * audio.channels + 1] = 0;
                        }
                        return 1;
                    }

                case 24:
                    {
                        for (int i = audio.selectionStart; i < audio.selectionEnd; i++)
                        {
                            audio.audioBuffer32[i * audio.channels] = 0;
                            if (audio.channels == 2)
                                audio.audioBuffer32[i * audio.channels + 1] = 0;
                        }
                        return 1;
                    }

                default:
                    {
                        return 0;
                    }

            }
        }



        public void ConvertToStereo(bool secondChannelEmpty = false)
        {
            audio = AudioProcessing.ConvertToStereoNew(audio, secondChannelEmpty);
        }

        public void ConvertToMono(int mode)
        {
            audio = AudioProcessing.ConvertToMono(audio, mode);
        }

        public bool Amplify(double scalerIn)
        {

            switch (audio.bitsPerSample)
            {
                case 16:
                    {
                        for (int i = audio.selectionStart; i < audio.selectionEnd; i++)
                        {
                            audio.audioBuffer16[i * audio.channels] = (short)(audio.audioBuffer16[i * audio.channels] * scalerIn);

                            if (audio.audioBuffer16[i * audio.channels] > short.MaxValue)
                                audio.audioBuffer16[i * audio.channels] = short.MaxValue;

                            if (audio.audioBuffer16[i * audio.channels] < short.MinValue)
                                audio.audioBuffer16[i * audio.channels] = short.MinValue;

                            if (audio.channels == 2)
                            {
                                audio.audioBuffer16[i * audio.channels + 1] = (short)(audio.audioBuffer16[i * audio.channels + 1] * scalerIn);

                                if (audio.audioBuffer16[i * audio.channels + 1] > short.MaxValue)
                                    audio.audioBuffer16[i * audio.channels + 1] = short.MaxValue;

                                if (audio.audioBuffer16[i * audio.channels + 1] < short.MinValue)
                                    audio.audioBuffer16[i * audio.channels + 1] = short.MinValue;
                            }

                        }
                        return true;
                    }

                case 24:
                    {
                        for (int i = audio.selectionStart; i < audio.selectionEnd; i++)
                        {
                            audio.audioBuffer32[i * audio.channels] = 0;
                            if (audio.channels == 2)
                                audio.audioBuffer32[i * audio.channels + 1] = 0;
                        }
                        return true;
                    }

                default:
                    {
                        return false;
                    }

            }

            return true;
        }

        public void Resample(int targetSampleRate)
        {
            audio = AudioProcessing.Resample(audio, targetSampleRate);
        }

        public void SelectAll()
        {
            audio.selectionEnd = audio.length;
            audio.selectionStart = 0;

            Form1 frm = this.MdiParent as Form1;
            if (frm != null)
            {
                frm.numericUpDownSelStart_UpdateFromChild(0);
                frm.numericUpDownSelEnd_UpdateFromChild(audio.length);
            }

            Invalidate();
        }

        public void UpdatePosition(int pos)
        {
            //unable to... im trying to update main ui thread from a different thread
            //label2.Text = "pos: " + pos;
        }

        public void UpdateCurrentPosition(int pos)
        {
            label2.Text = "pos: " + pos;
        }

        public int FindLastNonZeroValue()
        {

            return 1;
        }

        public int SetBitDepth(int targetBitDepth)
        {
            if (audio.bitsPerSample == targetBitDepth) return 0;

            //truncate
            if (targetBitDepth == 8)                //signed to unsigned
            {

                audio.audioBuffer8 = new byte[audio.length * audio.channels];

                if (audio.bitsPerSample == 16)
                {
                    for (int i = 0; i < audio.length; i++)
                    {
                        audio.audioBuffer8[i * audio.channels] = (byte)((audio.audioBuffer16[i * audio.channels] >> 8) + 128);
                        if (audio.channels == 2)
                            audio.audioBuffer8[i * audio.channels + 1] = (byte)((audio.audioBuffer16[i * audio.channels + 1] >> 8) + 128);
                    }
                    audio.bitsPerSample = 8;
                }
                else if (audio.bitsPerSample == 24)
                {
                    for (int i = 0; i < audio.length; i++)
                    {
                        audio.audioBuffer8[i * audio.channels] = (byte)((audio.audioBuffer32[i * audio.channels] >> 16) + 128);
                        if (audio.channels == 2)
                            audio.audioBuffer8[i * audio.channels + 1] = (byte)((audio.audioBuffer32[i * audio.channels + 1] >> 16) + 128);
                    }
                    audio.bitsPerSample = 8;
                }
            }


            else if (targetBitDepth == 16)
            {
                audio.audioBuffer16 = new short[audio.length * audio.channels];

                if (audio.bitsPerSample == 8)
                {
                    for (int i = 0; i < audio.length * audio.channels; i++)
                    {
                        audio.audioBuffer16[i] = (short)((audio.audioBuffer8[i] - 128) << 8);
                    }
                    audio.bitsPerSample = 16;
                }

                else if (audio.bitsPerSample == 24)
                {
                    for (int i = 0; i < audio.length; i++)
                    {
                        audio.audioBuffer16[i * audio.channels] = (short)(audio.audioBuffer32[i * audio.channels] >> 8);
                        if (audio.channels == 2)
                            audio.audioBuffer16[i * audio.channels + 1] = (short)(audio.audioBuffer32[i * audio.channels + 1] >> 8);
                    }
                    //need to delete 24 bit buffer too
                    audio.bitsPerSample = 16;
                }
            }


            else if (targetBitDepth == 24)
            {
                audio.audioBuffer32 = new int[audio.length * audio.channels];

                if (audio.bitsPerSample == 8)
                {
                    for (int i = 0; i < audio.length; i++)
                    {
                        //pause this.... 8 bit is unsigned!
                        /*
                        audio.audioBuffer32[i * audio.channels] = audio.audioBuffer8[i * audio.channels];
                        if (audio.channels == 2)
                            audio.audioBuffer32[i * audio.channels + 1] = audio.audioBuffer8[i * audio.channels + 1];
                            */
                    }
                }
                else if (audio.bitsPerSample == 16)
                {
                    for (int i = 0; i < audio.length; i++)
                    {
                        audio.audioBuffer32[i * audio.channels] = audio.audioBuffer16[i * audio.channels] * 256;
                        if (audio.channels == 2)
                            audio.audioBuffer32[i * audio.channels + 1] = audio.audioBuffer16[i * audio.channels + 1] * 256;
                    }
                }
                //need to delete 16 bit buffer too
                audio.bitsPerSample = 24;
            }

            return 1;
        }

    }
}
