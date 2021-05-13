using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs_WavEditor_v02
{

    public enum Waveform { Saw, Ramp, Sine, Square, Triangle, Noise };

    public partial class Dialog_GenerateSound : Form
    {

  
        /*
        a 3 dB increase in power is a double in volume:
        10 * log10 (2) = 3.01 dB, where 2 is the double in power (volume)

        note Nobody in his/her right mind would characterize a doubling of power 
        as a doubling of volume (assuming what is meant by volume is the 
        relative loudness of the program material). It's a noticeable increase, 
        but nowhere near twice as loud. Volume levels are somewhat subjective. 
        There is some grounding to be able to say a 6 dB increase is a doubling of volume, 
        but as often as not I hear people refer to 10 dB doubling volume.
        */

        double valueDb = 3.0, valueScaler = 2.0;
        bool trigger = false;
        private Waveform currentWaveform = Waveform.Sine;

        public Dialog_GenerateSound()
        {
            InitializeComponent();
            comboBoxWaves.SelectedIndex = 0;
        }

        public double GetFreq()
        {
            double f = double.Parse(textBoxFreqInHz.Text);
            return f;
        }

        public int GetTime()
        {
            int t = Int32.Parse(textBoxFreqInHz.Text);
            return t;
        }

        public bool UsePolyBleps()
        {
            return checkBoxUseBLEP.Checked;
        }

        public int GetBitDepth()
        {
            if(checkBoxBitz.Checked)
                return 24;
            return 16;
        }

        public int GetBandlimiting()
        {
            return Int32.Parse(textBoxBandLimiting.Text);
        }

        public int GetLength()
        {
            return Int32.Parse(textBoxTime.Text);
        }


        public Waveform GetWaveform()
        {
            //return currentWaveform;
            return (Waveform)comboBoxWaves.SelectedIndex;
        }

        private void textBoxDecimalScaler_TextChanged(object sender, EventArgs e)
        {
            if (trigger == false && !String.IsNullOrEmpty(textBoxTimeInFrames.Text))
            {
                trigger = true;
                valueScaler = double.Parse(textBoxTimeInFrames.Text);
                valueDb = 10.0 * Math.Log10(valueScaler);
                textBoxTime.Text = valueDb.ToString();
                trigger = false;

            }
        }

        private void textBoxDbIncrease_TextChanged(object sender, EventArgs e)
        {
            if (trigger == false && !String.IsNullOrEmpty(textBoxTime.Text))
            {
                trigger = true;
                valueDb = double.Parse(textBoxTime.Text);
                valueScaler = Math.Pow(10, (valueDb / 10.0));
                textBoxTimeInFrames.Text = valueScaler.ToString();
                trigger = false;

            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void comboBoxWaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentWaveform = (Waveform)comboBoxWaves.SelectedIndex;
        }

        public double GetAmplification()
        {
            return valueScaler;
        }

        //20log(2) = 
    }
}
