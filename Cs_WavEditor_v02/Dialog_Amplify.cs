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
    public partial class Dialog_Amplify : Form
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

        public Dialog_Amplify()
        {
            InitializeComponent();
        }

        private void textBoxDecimalScaler_TextChanged(object sender, EventArgs e)
        {
            if (trigger == false && !String.IsNullOrEmpty(textBoxDecimalScaler.Text))
            {
                trigger = true;
                valueScaler = double.Parse(textBoxDecimalScaler.Text);
                valueDb = 10.0 * Math.Log10(valueScaler);
                textBoxDbIncrease.Text = valueDb.ToString();
                trigger = false;

            }
        }

        private void textBoxDbIncrease_TextChanged(object sender, EventArgs e)
        {
            if (trigger == false && !String.IsNullOrEmpty(textBoxDbIncrease.Text))
            {
                trigger = true;
                valueDb = double.Parse(textBoxDbIncrease.Text);
                valueScaler = Math.Pow(10, (valueDb / 10.0));
                textBoxDecimalScaler.Text = valueScaler.ToString();
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


        public double GetAmplification()
        {
            return valueScaler;
        }

        //20log(2) = 
    }
}
