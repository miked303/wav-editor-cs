using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_WavEditor_v02
{
    class AudioProcessing
    {

        //How will i process files? pass reference in? return new file back

        /*
        public static int ConvertToMono(int monoMode, AudioFile aIn)
        {

            if (aIn.channels == 1) return 0;     //error, already mono

            if (aIn.bitsPerSample == 8)
            {

            }

            else if (aIn.bitsPerSample == 16)
            {

                int16_t* audioBuffer16_temp;
                audioBuffer16_temp = new int16_t[length];

                switch (monoMode)
                {
                    case MONO_USE_L:
                        {

                            for (int i = 0; i < aIn.length; i++)
                            {
                                //mono to stereo...
                                //[i * 2] = audioBuffer16[i];
                                //audioBuffer16_temp[i * 2 + 1] = audioBuffer16[i];
                                audioBuffer16_temp[i] = audioBuffer16[i * 2 + 0];

                            }

                        }
                        break;

                    case MONO_USE_R:
                        {

                            for (int i = 0; i < aIn.length; i++)
                            {
                                audioBuffer16_temp[i] = audioBuffer16[i * 2 + 1];
                            }

                        }
                        break;

                    case MONO_MIX:
                        {

                            for (int i = 0; i < aIn.length; i++)
                            {
                                audioBuffer16_temp[i] = (audioBuffer16[i * 2 + 0] / 2);
                                audioBuffer16_temp[i] += (audioBuffer16[i * 2 + 1] / 2);
                            }

                        }
                        break;
                }   //switch monoMode

                delete[] audioBuffer16;
                audioBuffer16 = audioBuffer16_temp;

                numChannels = 2;
                return 1;


            }
            else if (aIn.bitsPerSample == 24)
            {

                int32_t* audioBuffer32_temp;
                audioBuffer32_temp = new int32_t[length * 2];

                switch (monoMode)
                {
                    case MONO_USE_L:
                        {

                            for (int i = 0; i < length; i++)
                            {
                                audioBuffer32_temp[i] = audioBuffer32[i * 2 + 0];
                            }

                        }
                        break;

                    case MONO_USE_R:
                        {

                            for (int i = 0; i < length; i++)
                            {
                                audioBuffer32_temp[i] = audioBuffer32[i * 2 + 1];
                            }

                        }
                        break;

                    case MONO_MIX:
                        {

                            for (int i = 0; i < length; i++)
                            {
                                audioBuffer32_temp[i] = (audioBuffer32[i * 2 + 0] / 2);
                                audioBuffer32_temp[i] += (audioBuffer32[i * 2 + 1] / 2);
                            }

                        }
                        break;
                }   //switch monoMode


                delete[] audioBuffer32;
                audioBuffer32 = audioBuffer32_temp;

                numChannels = 1;
                return 1;

            }



            return 1;
        }


        public static int ConvertToStereo(AudioFile aIn)
        {

            if (aIn.channels == 1)
            {

                if (aIn.bitsPerSample == 8)
                {

                }

                else if (aIn.bitsPerSample == 16)
                {

                    int16_t* audioBuffer16_temp;
                    audioBuffer16_temp = new int16_t[length * 2];

                    for (int i = 0; i < length; i++)
                    {
                        audioBuffer16_temp[i * 2] = audioBuffer16[i];
                        audioBuffer16_temp[i * 2 + 1] = audioBuffer16[i];
                    }

                    delete[] audioBuffer16;
                    audioBuffer16 = audioBuffer16_temp;

                    numChannels = 2;
                    return 1;


                }
                else if (aIn.bitsPerSample == 24)
                {

                    int32_t* audioBuffer32_temp;
                    audioBuffer32_temp = new int32_t[length * 2];

                    for (int i = 0; i < length; i++)
                    {
                        audioBuffer32_temp[i * 2] = audioBuffer32[i];
                        audioBuffer32_temp[i * 2 + 1] = audioBuffer32[i];
                    }

                    delete[] audioBuffer32;
                    audioBuffer32 = audioBuffer32_temp;

                    numChannels = 2;
                    return 1;

                }


            }

            return 0;
        }
        */


        public static AudioFile ConvertToMono(AudioFile aIn, int mode)
        {

            if (aIn.channels == 1) return aIn;          //already mono

            AudioFile monoAudio = new AudioFile(aIn);



            if (aIn.bitsPerSample == 8)
            {
                monoAudio.audioBuffer8 = new byte[aIn.length];

                for (int i = 0; i < aIn.length; i++)
                {

                    if (mode == 0)          //left
                    {
                        monoAudio.audioBuffer8[i] = aIn.audioBuffer8[i * 2];
                    }
                    if (mode == 1)          //left
                    {
                        monoAudio.audioBuffer8[i] = aIn.audioBuffer8[i * 2 + 1];
                    }
                    else                    //stereo
                    {
                        monoAudio.audioBuffer8[i] = (byte)(aIn.audioBuffer8[i * 2] * 0.5f);
                        monoAudio.audioBuffer8[i] += (byte)(aIn.audioBuffer8[i * 2 + 1] * 0.5f);
                    }
                }

                monoAudio.channels = 1;
                return monoAudio;
            }

            else if (aIn.bitsPerSample == 16)
            {

                monoAudio.audioBuffer16 = new short[aIn.length];

                for (int i = 0; i < aIn.length; i++)
                {
                    if (mode == 0)          //left
                    {
                        monoAudio.audioBuffer16[i] = aIn.audioBuffer16[i * 2];
                    }
                    if (mode == 1)          //left
                    {
                        monoAudio.audioBuffer16[i] = aIn.audioBuffer16[i * 2 + 1];
                    }
                    else                    //stereo
                    {
                        monoAudio.audioBuffer16[i] = (short)(aIn.audioBuffer16[i * 2] * 0.5f);
                        monoAudio.audioBuffer16[i] += (short)(aIn.audioBuffer16[i * 2 + 1] * 0.5f);
                    }
                }

                monoAudio.channels = 1;
                return monoAudio;

            }

            else if (aIn.bitsPerSample == 24)
            {

                monoAudio.audioBuffer32 = new int[aIn.length];

                for (int i = 0; i < aIn.length; i++)
                {
                    if (mode == 0)          //left
                    {
                        monoAudio.audioBuffer32[i] = aIn.audioBuffer32[i * 2];
                    }
                    if (mode == 1)          //left
                    {
                        monoAudio.audioBuffer32[i] = aIn.audioBuffer32[i * 2 + 1];
                    }
                    else                    //stereo
                    {
                        monoAudio.audioBuffer32[i] = (short)(aIn.audioBuffer32[i * 2] * 0.5f);
                        monoAudio.audioBuffer32[i] += (short)(aIn.audioBuffer32[i * 2 + 1] * 0.5f);
                    }
                }

                monoAudio.channels = 1;
                return monoAudio;

            }

            return aIn;



            return aIn;
        }


        public static AudioFile ConvertToStereoNew(AudioFile aIn, bool leave2ndChannelEmpty)
        {

            if (aIn.channels == 2)
                return null;


            AudioFile stereoAudio = new AudioFile(aIn);

            if (aIn.bitsPerSample == 8)
            {
                stereoAudio.audioBuffer8 = new byte[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer8[i * 2] = aIn.audioBuffer8[i];
                    if (leave2ndChannelEmpty)
                        stereoAudio.audioBuffer8[i * 2 + 1] = 0;
                    else
                        stereoAudio.audioBuffer8[i * 2 + 1] = aIn.audioBuffer8[i];
                }

            }
            else if (aIn.bitsPerSample == 16)
            {

                stereoAudio.audioBuffer16 = new short[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer16[i * 2] = aIn.audioBuffer16[i];
                    if (leave2ndChannelEmpty) stereoAudio.audioBuffer16[i * 2 + 1] = 0;
                    else stereoAudio.audioBuffer16[i * 2 + 1] = aIn.audioBuffer16[i];
                }
            }
            else if (aIn.bitsPerSample == 24)
            {

                stereoAudio.audioBuffer32 = new int[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer32[i * 2] = aIn.audioBuffer32[i];
                    if (leave2ndChannelEmpty)
                        stereoAudio.audioBuffer32[i * 2 + 1] = 0;
                    else
                        stereoAudio.audioBuffer32[i * 2 + 1] = aIn.audioBuffer32[i];
                }
            }

            stereoAudio.channels = 2;
            return stereoAudio;

        }



        public static AudioFile ConvertToStereo(AudioFile aIn)
        {

            if (aIn.channels == 2)
                return null;


            AudioFile stereoAudio = new AudioFile(aIn);

            if (aIn.bitsPerSample == 8)
            {
                stereoAudio.audioBuffer8 = new byte[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer8[i * 2] = aIn.audioBuffer8[i];
                    stereoAudio.audioBuffer8[i * 2 + 1] = aIn.audioBuffer8[i];
                }

            }
            else if (aIn.bitsPerSample == 16)
            {

                stereoAudio.audioBuffer16 = new short[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer16[i * 2] = aIn.audioBuffer16[i];
                    stereoAudio.audioBuffer16[i * 2 + 1] = aIn.audioBuffer16[i];
                }
            }
            else if (aIn.bitsPerSample == 24)
            {

                stereoAudio.audioBuffer32 = new int[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer32[i * 2] = aIn.audioBuffer32[i];
                    stereoAudio.audioBuffer32[i * 2 + 1] = aIn.audioBuffer32[i];
                }
            }

            stereoAudio.channels = 2;
            return stereoAudio;

        }






        public static AudioFile Resample(AudioFile aIn, int targetSampleRate)
        {

            if (aIn.sampleRate == targetSampleRate)
                return aIn;

            double resampleFactor = targetSampleRate / aIn.sampleRate;


            AudioFile newAudio = new AudioFile(aIn);

            if (aIn.bitsPerSample == 8)
            {
                return aIn;
                /*
                stereoAudio.audioBuffer8 = new byte[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    stereoAudio.audioBuffer8[i * 2] = aIn.audioBuffer8[i];
                    stereoAudio.audioBuffer8[i * 2 + 1] = aIn.audioBuffer8[i];
                }
                */

            }
            else if (aIn.bitsPerSample == 16)
            {

                //48000->44100 - 
                //44100 -> 22050 = lengthx0.5
                //
                int newLength = (int)(aIn.length * resampleFactor);
                newAudio.length = newLength;
                newAudio.lengthTotal = newLength * aIn.channels;
                newAudio.audioBuffer16 = new short[newAudio.lengthTotal];

                for (int i = 0; i < aIn.length; i++)
                {
                    newAudio.audioBuffer16[i * 2] = aIn.audioBuffer16[i];
                    newAudio.audioBuffer16[i * 2 + 1] = aIn.audioBuffer16[i];
                }

                return aIn;
            }
            else if (aIn.bitsPerSample == 24)
            {

                return aIn;
                /*
                newAudio.audioBuffer32 = new int[aIn.length * 2];

                for (int i = 0; i < aIn.length; i++)
                {
                    newAudio.audioBuffer32[i * 2] = aIn.audioBuffer32[i];
                    newAudio.audioBuffer32[i * 2 + 1] = aIn.audioBuffer32[i];
                }
                */
            }


            return aIn;

        }



    } // class

} // namespace
