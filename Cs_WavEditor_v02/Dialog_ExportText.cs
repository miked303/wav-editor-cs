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

    public partial class Dialog_ExportText : Form
    {
        public Dialog_ExportText()
        {
            InitializeComponent();
            textExport = new TextExportOptions();

            SetDefaults();
        }

        void SetDefaults()
        {

        }

        public TextExportOptions textExport { get; set; }

        /*
        public int numberFormat = 1;       //decimal = 0
        public bool littleEndian = true;
        public int valuesPerLine = 8;
        public bool groupSingleValuesIfStereo = false;
        public bool printSampleNumber = false;
        */
        private void ShowMaxFramesExtras(bool show)
        {
            if (show)
            {
                //labelMaxFrames.
                numericMaxValuesPerDoc.Enabled = show;
            }
            else numericMaxValuesPerDoc.Enabled = show;
        }

        private void radioDecimal_CheckedChanged(object sender, EventArgs e)
        {
            //numberFormat = 0;
            textExport.numberFormat = 0;
        }

        private void radioHex_CheckedChanged(object sender, EventArgs e)
        {
            //numberFormat = 1;
            textExport.numberFormat = 1;
        }

        private void radioEndianSmall_CheckedChanged(object sender, EventArgs e)
        {
            // littleEndian = true;
            textExport.littleEndian = true;
        }

        private void radioEndianBig_CheckedChanged(object sender, EventArgs e)
        {
            //littleEndian = false;
            textExport.littleEndian = false;
        }

        private void numericValuesPerLine_ValueChanged(object sender, EventArgs e)
        {
            //valuesPerLine = (int)numericValuesPerLine.Value;
            textExport.valuesPerLine = (int)numericValuesPerLine.Value;
        }

        private void checkBoxGroupSingleValues_CheckedChanged(object sender, EventArgs e)
        {
            //groupSingleValuesIfStereo = checkBoxGroupSingleValues.Checked;
            textExport.groupSingleValuesIfStereo = checkBoxGroupSingleValues.Checked;
        }

        private void checkBoxPrintSampleNumber_CheckedChanged(object sender, EventArgs e)
        {
            //printSampleNumber = checkBoxPrintSampleNumber.Checked;
            textExport.printSampleNumber = checkBoxPrintSampleNumber.Checked;
        }

        private void checkBoxSplitLongFile_CheckedChanged(object sender, EventArgs e)
        {
            textExport.splitBigFile = checkBoxSplitLongFile.Checked;
            if (textExport.splitBigFile)
            {
                ShowMaxFramesExtras(true);
            }
            else
            {
                ShowMaxFramesExtras(false);
            }
            textExport.splitBigFile = textExport.splitBigFile;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void numericMaxValuesPerDoc_ValueChanged(object sender, EventArgs e)
        {
            textExport.splitBigFileSizeLimit = (int)numericMaxValuesPerDoc.Value;
        }
    }
}
