using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_WavEditor_v02
{
    class MyFuncs
    {


        public int CompareDoubles(double d1, double d2)
        {
            if (Math.Abs(d1 - d2) < 0.0001)
            {
                return 0;
            }
            else if (d1 > d2)
            {
                return 1;
            }
            else return -1;
        }

        public bool DoublesEqual(double d1, double d2)
        {
            if (Math.Abs(d1 - d2) < 0.0001)
            {
                return true;
            }
            return false;
        }

        public static string GetStereoStr(int channelsIn, bool caps = false)
        {
            string result;
            if (channelsIn == 1)
                result = caps ? "Mono" : "mono";
            else
                result = caps ? "Stereo" : "stereo";
            return result;
        }



        private const int a = 1;

        public static double GetDbFrom8bit(sbyte value)
        {

            double result = (20.0 * Math.Log10(32767.0 / value));
            int db = (int)(Math.Round(20.0 * Math.Log10(32767.0 / value)));
            //Voltage ratio : Level L(dB) = 20 × log(value 2 / value 1)   That are field quantities

            return result;
        }

        public static double GetDbFrom16bit(short value)
        {
            double result = (20.0 * Math.Log10(32767.0 / value));
            int db = (int)(Math.Round(20.0 * Math.Log10(32767.0 / value)));
            //Voltage ratio : Level L(dB) = 20 × log(value 2 / value 1)   That are field quantities

            return result;
        }

        public static double GetDbFrom24bit(int value)
        {
            double result = (20.0 * Math.Log10(32767.0 / value));
            int db = (int)(Math.Round(20.0 * Math.Log10(32767.0 / value)));
            //Voltage ratio : Level L(dB) = 20 × log(value 2 / value 1)   That are field quantities

            return result;
        }

        public static int GetDbFrom32bit(int value)
        {
            return 0;
        }

        public static int GetDb(int bitsIn, int value)
        {
            return 0;
        }


        public static string ConvertLengthToTime(int length, int sampleRate)
        {
            string output = "";

            //1h 35m 10s 200 ms.... 
            //1h = 44100*60*60 = 158,760,000	44100*60*60*1		360k
            //35m = 92,610,000					44100*60*35			210k
            //10s = 441000						44100*10			10k
            //200ms = 8820						44100*0.2			0.2k
            //251819820												= 580.2k

            int rem = 0;
            int timeH = (length / (sampleRate * (60 * 60)));
            rem = (length % (sampleRate * (60 * 60)));          //93059820

            int timeM = (rem / (sampleRate * (60)));
            rem = (rem % (sampleRate * (60)));                  //449820

            int timeS = (rem / sampleRate);
            rem = (rem % sampleRate);

            int timeMS = ((rem * 1000) / sampleRate);

            if (timeM < 1)
            {               //display secs and ms

                output += timeS + "s ";
                output += timeMS + "ms ";

            }

            else
            {                           //display hours, mins and secs

            }

            return output;
        }

    }
}
