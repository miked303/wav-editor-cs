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
    public partial class Form_NewWav : Form
    {

        int bitDepth;
        int sampleRate;
        int Channels;

        public Form_NewWav()
        {
            InitializeComponent();

            bitDepth = 16;
            sampleRate = 44100;
            Channels = 2;
        }

        RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }





        public int GetChannels()
        {
            if (String.Equals(GetCheckedRadio(groupBox1).Text, "Mono"))
                return 1;
            return 2;
        }

        public int GetSampleRate()
        {
            return int.Parse(GetCheckedRadio(groupBox2).Text);
        }

        public int GetBitDepth()
        {
            if (String.Equals(GetCheckedRadio(groupBox3).Text, "8 bit"))
                return 8;
            else if (String.Equals(GetCheckedRadio(groupBox3).Text, "16 bit"))
                return 16;
            else if (String.Equals(GetCheckedRadio(groupBox3).Text, "24 bit"))
                return 24;
            return int.Parse(GetCheckedRadio(groupBox3).Text);
        }


    }
}
