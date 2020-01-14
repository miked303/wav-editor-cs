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
    public partial class Dialog_Prog_ShrinkExtend : Form
    {
        public Dialog_Prog_ShrinkExtend()
        {
            InitializeComponent();
        }

        public Dialog_Prog_ShrinkExtend(int origLength)
        {
            InitializeComponent();
            originalLength = origLength;

            textBoxOriginalLength.Text = textBoxNewLength.Text = originalLength.ToString();
            numericSpecificValue.Value = origLength;

        }

        int originalLength = 1;
        public int newLength = 2;

        private void radioBtnExtendNearestN_CheckedChanged(object sender, EventArgs e)
        {
            int divider = (int)numericNearestValue.Value;
            if (originalLength % divider != 0)
                newLength = ((originalLength / divider) + 1) * divider;
            textBoxNewLength.Text = newLength.ToString();
        }

        private void radioBtnExtendSpecific_CheckedChanged(object sender, EventArgs e)
        {
            newLength = (int)numericSpecificValue.Value;
            textBoxNewLength.Text = newLength.ToString();
        }

        private void numericNearestValue_ValueChanged(object sender, EventArgs e)
        {
            int divider = (int)numericNearestValue.Value;
            newLength = ((originalLength / divider) + 1) * divider;
            textBoxNewLength.Text = newLength.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void numericSpecificValue_ValueChanged(object sender, EventArgs e)
        {

            newLength = (int)numericSpecificValue.Value;
            textBoxNewLength.Text = newLength.ToString();
        }
    }
}
