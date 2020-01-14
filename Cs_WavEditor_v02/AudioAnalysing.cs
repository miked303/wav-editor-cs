using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs_WavEditor_v02
{
    class AudioAnalysing
    {


        public static int AnalyseStereo(AudioFile aIn)
        {

            if (aIn.bitsPerSample == 16)
            {

                int averageDifference = 0;
                int counter = 0;
                int maxDifference = 0;


                if (aIn.channels == 1) return 0;

                for (int i = 0; i < aIn.length; i += 2)
                {

                    int difference = aIn.audioBuffer16[i] - aIn.audioBuffer16[i + 1];
                    averageDifference = (averageDifference + difference) / (i / 2 + 1);
                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                    }

                }

                string output = "Average difference: ";
                output += averageDifference;

                output += ", Max Diff:";
                output += maxDifference;

                MessageBox.Show(output, "Stereo Analysis");

            }

            else if (aIn.bitsPerSample == 24)
            {

                int averageDifference = 0;
                int counter = 0;
                int maxDifference = 0;


                if (aIn.channels == 1) return 0;

                for (int i = 0; i < aIn.length; i += 2)
                {

                    int difference = aIn.audioBuffer32[i] - aIn.audioBuffer32[i + 1];
                    averageDifference = (averageDifference + difference) / (i / 2 + 1);
                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                    }

                }

                string output = "Average difference: ";
                output += averageDifference;

                output += ", Max Diff:";
                output += maxDifference;

                MessageBox.Show(output, "Stereo Analysis");


            }



            return 0;
        }


        public static int GetPeakLevel(AudioFile aIn)
        {

            if (aIn.bitsPerSample == 16)
            {

                int maxDifference = 0;
                int maxPosition = 0;



                for (int i = 0; i < (aIn.length * aIn.channels); i += 1)
                {

                    if (Math.Abs(aIn.audioBuffer16[i]) > maxDifference)
                    {
                        maxDifference = Math.Abs(aIn.audioBuffer16[i]);
                        maxPosition = i;
                    }

                }

                if (aIn.channels == 2) maxPosition = maxPosition / 2;        //actual position
                double dooo = 0;
                dooo = (20.0 * Math.Log10(32767.0 / maxDifference));
                int db = (int)Math.Round(20.0 * Math.Log10(32767.0 / maxDifference));
                //Voltage ratio : Level L(dB) = 20 × log(value 2 / value 1)   That are field quantities

                string output = "Pos: ";
                output += maxPosition;

                output += ", Max Diff:";
                output += maxDifference;

                output += ", dB: ";
                output += db;

                MessageBox.Show(output, "Peak Level");
            }


            else if (aIn.bitsPerSample == 24)
            {

                int maxDifference = 0;
                int maxPosition = 0;



                for (int i = 0; i < (aIn.length * aIn.channels); i += 1)
                {

                    if (Math.Abs(aIn.audioBuffer32[i]) > maxDifference)
                    {
                        maxDifference = Math.Abs(aIn.audioBuffer32[i]);
                        maxPosition = i;
                    }

                }

                if (aIn.channels == 2) maxPosition = maxPosition / 2;        //actual position
                double dooo = 0;
                dooo = (20.0 * Math.Log10(8388607.0 / maxDifference));
                int db = (int)Math.Round(20.0 * Math.Log10(8388607.0 / maxDifference));
                //Voltage ratio : Level L(dB) = 20 × log(value 2 / value 1)   That are field quantities

                string output = "Pos: ";
                output += maxPosition;

                output += ", Max Diff:";
                output += maxDifference;

                output += ", dB: ";
                output += db;

                MessageBox.Show(output, "Peak Level");
            }

            return 1;
        }










        public static int FindLastNonZeroValue(AudioFile aIn)
        {

            if (aIn.bitsPerSample == 16)
            {

                if (aIn.audioBuffer16[aIn.length * aIn.channels - 1] == 0)
                {
                    //First we check that the final value is actually non-zero; no point progressing otherwise

                    for (int i = aIn.length * aIn.channels - 1; i > 0; i -= 1)
                    {

                        if (aIn.audioBuffer16[i] != 0)
                        {

                            int pos;
                            if (aIn.channels == 2) pos = i / 2;
                            else pos = i;
                            MessageBox.Show("The final zero value was at " + pos);
                            return 1;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Audio doesnt end with zero value");
                    return 1;
                }
            }

            return 1;
        }


    }
}



