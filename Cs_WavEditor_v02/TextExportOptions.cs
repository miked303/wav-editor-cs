using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_WavEditor_v02
{
    public class TextExportOptions
    {
        public int numberFormat = 1;       //decimal = 0
        public bool littleEndian = true;
        public int valuesPerLine = 8;
        public bool groupSingleValuesIfStereo = false;
        public bool printSampleNumber = false;
        public bool splitBigFile = false;
        public int splitBigFileSizeLimit = 8192;
    }
}
