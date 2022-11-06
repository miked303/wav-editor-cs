using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_WavEditor_v02
{
    public class AudioFile
    {

        const int maxBufferSizeBytes = 512000000;		//512mb roughly

        //TCHAR filename[256];
        char[] filename = new char[256];
        int fileChanged;

        public int sampleRate { get; set; }
        public int bitsPerSample { get; set; }
        public int channels { get; set; }
        public int length { get; set; }         //frames
        public int lengthTotal { get; set; }    //samples (frames * channels)
        public int size { get; set; }

        //
        public int byteRate { get; set; }
        public int blockAlign { get; set; }
        public int audioFormat { get; set; }

        public int marker { get; set; }
        public int selectionStart { get; set; }
        public int selectionEnd { get; set; }
        int xZoom { get; set; }
        int yZoom { get; set; }

        //int16_t* audioBuffer16;
        //int32_t* audioBuffer32;

        public byte[] audioBuffer8 { get; set; }        //byte = 8 bit unsigned in c#
        public short[] audioBuffer16 { get; set; }      //short = 16 bit signed in c#
        public int[] audioBuffer32 { get; set; }         //int = 32 bit signed in c#

        //IDirectSoundBuffer8** dBuffer;      //v07 - changed to double pointer
        int bufferKey;              //new v07 - instead of the above pointer

        bool fullyLoaded;           //new v09 - for handling huge files
        int framesLoaded;           //new v09 - for handling huge files
        private AudioFile aIn;

        public AudioFile(AudioFile aIn)         //creates an AudioFile with the same audio specs
        {
            sampleRate = aIn.sampleRate;
            length = aIn.length;
            channels = aIn.channels;
            bitsPerSample = aIn.bitsPerSample;
            byteRate = aIn.byteRate;
            blockAlign = aIn.blockAlign;
        }

        public void SetFormatBasedOn(AudioFile aIn)
        {
            sampleRate = aIn.sampleRate;
            length = aIn.length;
            channels = aIn.channels;
            bitsPerSample = aIn.bitsPerSample;
            byteRate = aIn.byteRate;
            blockAlign = aIn.blockAlign;
        }

        public AudioFile()
        {
        }

        public AudioFile(int sampleRateIn, int bitsPerSampleIn, int channelsIn)
        {
            sampleRate = sampleRateIn;
            bitsPerSample = bitsPerSampleIn;
            channels = channelsIn;

            byteRate = sampleRate * (bitsPerSample / 8) * channels;
            blockAlign = bitsPerSample / 8 * channels;
        }

        public void SetDefaultAudioSettings()
        {
            sampleRate = 44100;
            length = 0;
            channels = 2;
            bitsPerSample = 16;
            //byteRate = aIn.byteRate;
            //blockAlign = aIn.blockAlign;
        }

        public int OpenWav(string filename)
        {

            FileInfo fInfo = new FileInfo(filename);
            long sizeFile = fInfo.Length;

            //      ifstream audiofile;
            //      audiofile.open(filename, ios::in | ios::binary);
            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {

                //char[] chunkId = new char[4];
                //chunkId = reader.ReadChars(4);
                String chunkId = new String(reader.ReadChars(4));


                //This is the size of the rest of the chunk following this number. Little endian format
                byte[] chunkSize = new byte[4];
                chunkSize = reader.ReadBytes(4);
                int chunkSizeBytes = ((int)chunkSize[0] & 0xff) + (((int)chunkSize[1] & 0xff) << 8) + (((int)chunkSize[2] & 0xff) << 16) + (((int)chunkSize[3] & 0xff) << 24);

                String waveDef = new String(reader.ReadChars(4));
                //String waveDef = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));





                //We now hav 2 subchunks: "fmt " and "data" 

                int subChunkSizeBytes;
                string subchunk1ID = new string(reader.ReadChars(4));
                string subchunk1SizeTemp;

                //while (!(subchunk1ID[0] == 'f' && subchunk1ID[1] == 'm' && subchunk1ID[2] == 't' && subchunk1ID[3] == ' '))
                while (!subchunk1ID.Equals("fmt "))
                {

                    //char subchunk1SizeTemp[4];
                    //audiofile.read(subchunk1SizeTemp, 4);
                    subchunk1SizeTemp = new string(reader.ReadChars(4));

                    subChunkSizeBytes = ((int)subchunk1SizeTemp[0] & 0xff) + (((int)subchunk1SizeTemp[1] & 0xff) << 8) + (((int)subchunk1SizeTemp[2] & 0xff) << 16) + (((int)subchunk1SizeTemp[3] & 0xff) << 24);

                    //read the stuff
                    for (int i = 0; i < subChunkSizeBytes; i++)
                    {

                        byte s;
                        s = reader.ReadByte();


                    }

                    //audiofile.read(subchunk1ID, 4);
                    subchunk1ID = (reader.ReadChars(4)).ToString();

                }

                subchunk1SizeTemp = new String(reader.ReadChars(4));
                subChunkSizeBytes = ((int)subchunk1SizeTemp[0] & 0xff) + (((int)subchunk1SizeTemp[1] & 0xff) << 8) + (((int)subchunk1SizeTemp[2] & 0xff) << 16) + (((int)subchunk1SizeTemp[3] & 0xff) << 24);
                //size is 16 which means PCM 

                /*
                  0x0001	WAVE_FORMAT_PCM				PCM
                  0x0003	WAVE_FORMAT_IEEE_FLOAT		IEEE float
                  0x0006	WAVE_FORMAT_ALAW			8 - bit ITU - T G.711 A - law
                  0x0007	WAVE_FORMAT_MULAW			8 - bit ITU - T G.711 µ - law
                  0xFFFE	WAVE_FORMAT_EXTENSIBLE		Determined by SubFormat
                  */


                /*
                char audioFormatTemp[2];        //waveshop - fffe		
                audiofile.read(audioFormatTemp, 2);
                int audioFormat = (int)audioFormatTemp[0] + ((int)audioFormatTemp[1] << 8);
                */

                /*
                int audioFormat = reader.ReadUInt16();
                int numChannels = reader.ReadUInt16();
                int sampleRate = reader.ReadInt32();
                int byteRate = reader.ReadInt32();
                int blockAlign = reader.ReadUInt16();
                int bitsPerSample = reader.ReadUInt16();
                */

                audioFormat = reader.ReadUInt16();
                channels = reader.ReadUInt16();
                sampleRate = reader.ReadInt32();
                byteRate = reader.ReadInt32();
                blockAlign = reader.ReadUInt16();
                bitsPerSample = reader.ReadUInt16();

                //sometimes subChunkSizeBytes is 18 (or possibly something else?) - so read additional bytes; usually these can be ignored
                if (subChunkSizeBytes > 16)
                {
                    char[] crap = new char[256];
                    //audiofile.read(crap, subChunkSizeBytes - 16);
                    reader.ReadChars(subChunkSizeBytes - 16);
                }








                /////////////////////////////////////////////////////////////////////
                // Read second subchunk. Could be data, could be "acid", "pad ","smpl", etc
                ///////////////////////////////////////////////////////////////////// 

                string subchunk2ID = new string(reader.ReadChars(4));
                int subChunk2Size = reader.ReadInt32();

                //If its data.... NumSamples * NumChannels * BitsPerSample/8
                //Raw file size : 26,456 bytes, which is this value!!!
                // other is 88,200

                while (!subchunk2ID.Equals("data"))
                {

                    //Keep searching until we find "data"; not bothered about other crap

                    for (int i = 0; i < subChunk2Size; i++)
                    {
                        char crap = reader.ReadChar();
                    }

                    subchunk2ID = new string(reader.ReadChars(4));
                    subChunk2Size = reader.ReadInt32();

                }


                int dataSize = subChunk2Size;
                //frames (regardless of channels)
                int frames = 0;

                if (bitsPerSample == 8)
                {
                    frames = dataSize;
                }
                else if (bitsPerSample == 16)
                {
                    frames = dataSize / 2;
                }
                else if (bitsPerSample == 24)
                {
                    frames = dataSize / 3;
                }

                if (channels == 2)
                {
                    frames = frames / 2;
                }

                length = frames;


                int bufferSize;        //the data size we can actually load. We may not have enough memory to load it all

                bufferSize = 1;             //temporarily... remove later

                if (bitsPerSample == 8)
                {
                    if (dataSize > maxBufferSizeBytes)
                    {
                        int n = maxBufferSizeBytes / (1 * channels);
                        bufferSize = n * 1 * channels;
                    }
                    else
                    {
                        bufferSize = dataSize;
                    }


                    int samplesToLoad = bufferSize / 1;
                    audioBuffer8 = new byte[samplesToLoad];

                    for (int i = 0; i < samplesToLoad; i++)
                    {
                        audioBuffer8[i] = reader.ReadByte();
                    }
                }
                else if (bitsPerSample == 16)
                {

                    if (audioBuffer16 != null)
                    {
                        //delete[] audioBuffer16;			
                        //because im using audioBuffer16 elsewhere as  a pointer when switching between child windows!
                        //audioBuffer16 = NULL;
                    }


                    //new v10
                    if (dataSize > maxBufferSizeBytes)
                    {
                        int n = maxBufferSizeBytes / (2 * channels);
                        bufferSize = n * 2 * channels;
                    }
                    else
                    {
                        bufferSize = dataSize;
                    }


                    int samplesToLoad = bufferSize / 2;
                    audioBuffer16 = new short[samplesToLoad];

                    for (int i = 0; i < samplesToLoad; i++)
                    {
                        audioBuffer16[i] = reader.ReadInt16();
                    }

                    /*
                    char tempC[1];
                    char c[1];
                    for (int i = 0; i < bufferSize; i++)
                    {           //v10 bug fix... was incorrectly doing "i<bufferSize/2" meaning only half the wave was being loaded!

                        audiofile.read(c, 1);
                        //audiofileOut.write (c, 1);

                        if (i % 2 == 1)
                        {
                            audioBuffer16[i / 2] = (int16_t)((c[0] << 8) | (tempC[0] & 0xff));
                            //myfile2 <<  "\na: " << dec << a;
                        }
                        else
                        {
                            tempC[0] = c[0];
                        }
                    }
                    */


                }

                else if (bitsPerSample == 24)
                {

                    //debug 
                    var offset = reader.BaseStream.Position;

                    if (dataSize > maxBufferSizeBytes)
                    {
                        int n = maxBufferSizeBytes / (3 * channels);
                        bufferSize = n * 3 * channels;
                    }
                    else
                    {
                        bufferSize = dataSize;
                    }


                    int samplesToLoad = bufferSize / 3;
                    audioBuffer32 = new int[samplesToLoad];
                    byte[] tempStore = new byte[3];
                    sbyte[] c = new sbyte[3];

                    for (int i = 0; i < samplesToLoad; i++)
                    {
                        //tempStore = reader.ReadBytes(3);
                        //audioBuffer32[i] = ((tempStore[2] << 16) | ((tempStore[1] & 0xff) << 8) | (tempStore[0] & 0xff));

                        c[0] = reader.ReadSByte();
                        c[1] = reader.ReadSByte();
                        c[2] = reader.ReadSByte();
                        audioBuffer32[i] = ((c[2] << 16) | ((c[1] & 0xff) << 8) | (c[0] & 0xff));


                        //audioBuffer32[i] = reader.ReadInt16();
                    }

                }
















                return 1;




            }//usiong ibnary reader




        }//openwav







        public int SaveWav(string filenameIn)
        {
            //few missing bytes at end ?! maybe im reading it in slightly incorrectly


            using (BinaryWriter writer = new BinaryWriter(File.Open(filenameIn, FileMode.Create)))
            {

                // writer.Write("RIFF");
                writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));

                //This is the size of the rest of the chunk following 
                //this number.This is the size of the entire file 
                //in bytes minus 8 bytes for the two fields not included 
                //in this count: ChunkID and ChunkSize.

                //Little endian format
                //int chunkSizeBytes = ((int)chunkSize[0] & 0xff) + (((int)chunkSize[1] & 0xff) << 8) + (((int)chunkSize[2] & 0xff) << 16) + (((int)chunkSize[3] & 0xff) << 24);
                int chunkSizeBytes = 0;         //4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)

                chunkSizeBytes += 4;

                chunkSizeBytes += 8;
                chunkSizeBytes += 16;           //subchunk 1 size

                chunkSizeBytes += 8;
                chunkSizeBytes += length * channels * bitsPerSample / 8; // data (subchunk 2 size)

                writer.Write(chunkSizeBytes);

                writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));

                ///////////////////////////////////////////////
                //We now hav 2 subchunks: "fmt " and "data" 

                writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt "));

                int subChunkSizeBytes = 16;                 //Forcing 16=PCM (sometimes its 18 or other values)
                writer.Write(subChunkSizeBytes);


                short audioFormat = 1;        //PCM = 1. Other values indicate some form of compression.
                writer.Write((short)audioFormat);
                writer.Write((short)channels);





                writer.Write(sampleRate);


                int byteRate = sampleRate * channels * bitsPerSample / 8;
                writer.Write(byteRate);


                short blockAlign = (short)(channels * bitsPerSample / 8);
                writer.Write(blockAlign);

                writer.Write((short)bitsPerSample);


                //second subchunk (can be data, or other)
                writer.Write(System.Text.Encoding.ASCII.GetBytes("data"));



                int subChunk2Size = length * channels * bitsPerSample / 8;           //fix
                writer.Write(subChunk2Size);

                if (bitsPerSample == 8)
                {

                    for (int i = 0; i < length; i++)
                    {

                        int iI = i * channels;

                        byte[] buffer = new byte[1];
                        buffer[0] = (byte)(audioBuffer8[iI]);
                        writer.Write(buffer);

                        if (channels == 2)
                        {
                            buffer[0] = (byte)(audioBuffer8[iI + 1]);
                            writer.Write(buffer);
                        }

                    }
                }
                else if (bitsPerSample == 16)
                {

                    for (int i = 0; i < length; i++)
                    {

                        int iI = i * channels;

                        byte[] buffer = new byte[2];
                        buffer[0] = (byte)(audioBuffer16[iI] & 0xff);
                        buffer[1] = (byte)((audioBuffer16[iI] >> 8) & 0xff);
                        writer.Write(buffer);

                        if (channels == 2)
                        {
                            buffer[0] = (byte)(audioBuffer16[iI + 1] & 0xff);
                            buffer[1] = (byte)((audioBuffer16[iI + 1] >> 8) & 0xff);
                            writer.Write(buffer);
                        }

                    }
                }

                else if (bitsPerSample == 24)
                {

                    for (int i = 0; i < length; i++)
                    {

                        int iI = i * channels;

                        byte[] buffer = new byte[3];
                        buffer[0] = (byte)(audioBuffer32[iI] & 0xff);
                        buffer[1] = (byte)((audioBuffer32[iI] >> 8) & 0xff);
                        buffer[2] = (byte)((audioBuffer32[iI] >> 16) & 0xff);
                        writer.Write(buffer);

                        if (channels == 2)
                        {
                            buffer[0] = (byte)(audioBuffer32[iI + 1] & 0xff);
                            buffer[1] = (byte)((audioBuffer32[iI + 1] >> 8) & 0xff);
                            buffer[2] = (byte)((audioBuffer32[iI + 1] >> 16) & 0xff);
                            writer.Write(buffer);
                        }

                    }
                }



                writer.Close();







                return 1;
            }
        }

        public int SaveRaw(string filenameIn)
        {

            using (BinaryWriter writer = new BinaryWriter(File.Open(filenameIn, FileMode.Create)))
            {

                if (bitsPerSample == 16)
                {

                    for (int i = 0; i < length; i++)
                    {

                        int iI = i * channels;

                        byte[] buffer = new byte[2];
                        buffer[0] = (byte)(audioBuffer16[iI] & 0xff);
                        buffer[1] = (byte)((audioBuffer16[iI] >> 8) & 0xff);
                        writer.Write(buffer);

                        if (channels == 2)
                        {
                            buffer[0] = (byte)(audioBuffer16[iI + 1] & 0xff);
                            buffer[1] = (byte)((audioBuffer16[iI + 1] >> 8) & 0xff);
                            writer.Write(buffer);
                        }

                    }
                }

                else if (bitsPerSample == 24)
                {

                    for (int i = 0; i < length; i++)
                    {

                        int iI = i * channels;

                        byte[] buffer = new byte[3];
                        buffer[0] = (byte)(audioBuffer32[iI] & 0xff);
                        buffer[1] = (byte)((audioBuffer32[iI] >> 8) & 0xff);
                        buffer[2] = (byte)((audioBuffer32[iI] >> 16) & 0xff);
                        writer.Write(buffer);

                        if (channels == 2)
                        {
                            buffer[0] = (byte)(audioBuffer32[iI + 1] & 0xff);
                            buffer[1] = (byte)((audioBuffer32[iI + 1] >> 8) & 0xff);
                            buffer[2] = (byte)((audioBuffer32[iI + 1] >> 16) & 0xff);
                            writer.Write(buffer);
                        }

                    }
                }

                writer.Close();

                return 1;
            }
        }


        double poly_blep(double t, double mPhaseIncrement, double twoPI)
        {
            double dt = mPhaseIncrement / twoPI;
            // 0 <= t < 1                               //his comment; i dont understand this line
            if (t < dt)                                 //if first sample in period
            {
                t /= dt;
                return t + t - t * t - 1.0;             //value returned is bigger the closer t is to 0
            }
            // -1 < t < 0                               //his comment; i dont understand this line
            else if (t > 1.0 - dt)                      //if last sample in period
            {
                t = (t - 1.0) / dt;                     
                return t * t + t + t + 1.0;             //value returned is bigger the closer t is to 1
            }
            // 0 otherwise
            else return 0.0;
        }


        double poly_blep_orig(double t, double dt)
        {
            // 0 <= t < 1
            if (t < dt)
            {
                t /= dt;
                return t + t - t * t - 1.0;
            }
            // -1 < t < 0
            else if (t > 1.0 - dt)
            {
                t = (t - 1.0) / dt;
                return t * t + t + t + 1.0;
            }
            // 0 otherwise
            else return 0.0;
        }

        public int GenerateNewWavDeluxe(int channelsIn, int sampleRateIn, int bitsPerSamplesIn, int lengthIn, Waveform waveformIn, double freqIn, bool usePolyBleps)
        {

            audioFormat = 0x00;         //just guessed?!
            channels = channelsIn;
            sampleRate = sampleRateIn;
            bitsPerSample = bitsPerSamplesIn;

            byteRate = sampleRate * (bitsPerSample / 8) * channels;
            blockAlign = bitsPerSample / 8 * channels;

            int newLength = sampleRate;      //1 second i hope

            uint freq = (uint)freqIn;
            uint value = 0;

            uint inc = (uint)((4294967295 / sampleRate) * freq);

            /*
            Phase Increment = 	Phase Acc Size 		*	 (Desired frequency / Sample rate freq)
eg			2^32	* 	(440hz / 156250) 	= 12094627.91

Output Freq =		(Phase Increment * Sample rate frequency) / Phase Acc Size

            */

            short[] tempBuffer = new short[newLength * this.channels];
            short v;

            for (int i = 0; i < newLength; i++)
            {

                value += inc;

                switch (waveformIn)
                {
                    case Waveform.Ramp:
                        {

                            if (usePolyBleps)
                            {

                                uint valueTemp = value;

                                //buffer[i] = 1.0 - (2.0 * mPhase / twoPI);
                                //-1.0 to +1.0 range over 2PI

                                //2.0 => 2^32
                                //TWOPI = 2^32

                                double twoPI = 4294967295;
                                double mPhaseIncrement = inc;

                                double t = value / 4294967295.0;
                                double dt = mPhaseIncrement / twoPI;
                                double z = poly_blep_orig(t, dt);

                                uint zUINT = (uint)z;

                                valueTemp -= zUINT;






                                uint v1 = valueTemp >> 16;
                                int valueOut = (int)v1 - 32767;

                                if (valueOut < -32767)
                                    valueOut = -32767;
                                if (valueOut > 32767)
                                    valueOut = 32767;

                                v = (short)valueOut;
                            }
                            else
                            {
                                uint v1 = value >> 16;
                                int valueOut = (int)v1 - 32767;

                                if (valueOut < -32767)
                                    valueOut = -32767;
                                if (valueOut > 32767)
                                    valueOut = 32767;

                                v = (short)valueOut;
                            }


                        }
                        break;

                    case Waveform.Saw:
                        {
                            uint v1 = 65535 - (value >> 16);
                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;

                    case Waveform.Square:
                        {
                            uint v1 = (value >> 16);
                            if (v1 > 32767)
                                v = +32767;
                            else
                            {
                                v = -32767;
                            }

                        }
                        break;

                    default:
                        {
                            uint v1 = value >> 16;
                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;
                }



                int iI = i * this.channels;

                tempBuffer[iI] = v;
                /*
                if (this.channels == 2)
                    tempBuffer[iI + 1] = this.audioBuffer16[(0 * this.channels) + iI + 1];
                    */
            }

            this.audioBuffer16 = tempBuffer;
            this.length = newLength;

            return 1;

        }//generatenewwavedeluxe

        public int GenerateNewWav3(int channelsIn, int sampleRateIn, int bitsPerSamplesIn, int lengthIn, Waveform waveformIn, double freqIn, bool usePolyBlep, int banding)
        {

            const double PI2 = 3.14159 * 2.0;

            audioFormat = 0x00;         //just guessed?!
            channels = channelsIn;
            sampleRate = sampleRateIn;
            bitsPerSample = bitsPerSamplesIn;

            byteRate = sampleRate * (bitsPerSample / 8) * channels;
            blockAlign = bitsPerSample / 8 * channels;

            int newLength = sampleRate* lengthIn;      //1 second i hope

            uint freq = (uint)freqIn;
            uint value = 0;

            const uint MAX_VALUE = 4294967295;


            uint inc = (uint)((MAX_VALUE / sampleRate) * freq);

            double mPhaseIncrement = (((PI2 * (double)freq) / sampleRate) );
            double mPhase = 0f;
            double twoPI = PI2;


            /*
            Phase Increment = 	Phase Acc Size 		*	 (Desired frequency / Sample rate freq)
eg			2^32	* 	(440hz / 156250) 	= 12094627.91

Output Freq =		(Phase Increment * Sample rate frequency) / Phase Acc Size

            */

            short[] tempBuffer;
            int[] tempBufferInts;

            if (bitsPerSample == 16)
            {
                tempBuffer = new short[newLength * this.channels];
                tempBufferInts = new int[1 * this.channels];
            }
            else if (bitsPerSample == 24)
            {
                tempBuffer = new short[1 * this.channels];
                tempBufferInts = new int[newLength * this.channels];
            }
            else
            {
                tempBuffer = new short[1 * this.channels];
                tempBufferInts = new int[1 * this.channels];
            }



            short v = 0;
            int vInt = 0;


            for (int i = 0; i < newLength; i++)
            {

                /*
                value += inc;



                mPhase += mPhaseIncrement;
                while (mPhase >= twoPI)
                {
                    mPhase -= twoPI;
                }
                */



                switch (waveformIn)
                {
                    case Waveform.Ramp:
                        {
                            uint v1 = value >> 16;

                            if (usePolyBlep)
                            {
                                v1 = v1 & 0xf000;
                            }


                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;

                    case Waveform.Saw:
                        {


                            double t = 0f;      //param in
                            double retValue = 0f;
                            uint intRetValue = 0;

                            //double twoPI = MAX_VALUE;

                            //Polyblep routine to reduce aliasing
                            //It works by targeting the transients: the part of the saw/ramp wave that is the big jump up/down. 
                            //The rest of the wav which is a slope is left unaffected.
                            //We adjust the first and last sample of a period: before and after the jump.
                            //We do this by adding/subtract an amount to the standard raw wav. For the unaffected parts, zero is added.
                            //The value added or subtracted is greater the closer we are to zero or one. eg. it is rounded/smoothed more

                            //This is only applicable for a ramp wave; a square wave has two transients per sample


                            //poly_blep(double t)
                            if (usePolyBlep)
                            {
                                /*
                                To go from 2^32 to 2PI range
                                we do intAcc = piAcc / 2PI * 255 
                                and piAcc = intAcc / 255 * 2PI
                                
                                */

                                //t = mPhase / twoPI;
                                t = value / (double)MAX_VALUE;

                                //double dt = mPhaseIncrement / twoPI;
                                double dt = inc / (double)MAX_VALUE;

                                // 0 <= t < 1
                                if (t < dt)
                                {
                                    t /= dt;
                                    retValue = t + t - t * t - 1.0;
                                }
                                // -1 < t < 0
                                else if (t > 1.0 - dt)
                                {
                                    t = (t - 1.0) / dt;
                                    retValue = t * t + t + t + 1.0;
                                }
                                // 0 otherwise
                                else
                                    retValue = 0.0f;

                                intRetValue = (uint)((retValue / PI2) * (double)MAX_VALUE);










                                t = mPhase / twoPI;
                                retValue = poly_blep(t, mPhaseIncrement, twoPI);
                            }


                            double doubleValueTemp = mPhase;
                            doubleValueTemp -= retValue;


                            double scaler = 0.75;

                            //convert to short

                            uint valueTemp = (uint)((doubleValueTemp / twoPI) * MAX_VALUE);

                            /*
                            uint valueTemp = (uint)((mPhase / twoPI) * MAX_VALUE);
                            valueTemp -= intRetValue;
                            */

                            uint v1 = 65535 - (valueTemp >> 16);

                            int valueOut = (int)v1 - 32767;

                            //bad way of doing that...
                            double doubleValueOut = ((((doubleValueTemp*2.0)/twoPI))-1.0) * scaler;
                            valueOut = (int)(doubleValueOut * 32767.0);



                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            if (banding > 0)
                            {

                                int mask = 0xffff;
                                for(int x=0; x<banding; x++)
                                {
                                    mask &= ~(1 << x);
                                }
                                valueOut = (valueOut & mask);

                            }

                            v = (short)valueOut;

                           



                            //convert to int
                            valueTemp = (uint)((doubleValueTemp / twoPI) * MAX_VALUE);

                            const int TWO_POW_24_SUB_1 = 16777216 - 1;

                            v1 = TWO_POW_24_SUB_1 - (valueTemp >> 8);

                            valueOut = (int)v1 - (TWO_POW_24_SUB_1 >> 1);


                            //bad way of doing that...    
                            int TWO_POW_23_SUB_1 = 8388607;
                          doubleValueOut = ((((2.0*doubleValueTemp) / twoPI)) - 1.0) * scaler;
                            valueOut = (int)(doubleValueOut * TWO_POW_23_SUB_1);

                            //scaler = 0.6;

                            //valueOut = (int)(scaler * valueOut);

                            if (valueOut < -TWO_POW_23_SUB_1)
                                valueOut = -TWO_POW_23_SUB_1;
                            if (valueOut > (TWO_POW_23_SUB_1))
                                valueOut = (TWO_POW_23_SUB_1);

                            vInt = (int)valueOut;






                if (bitsPerSample == 16)
                    tempBuffer[iI] = v;
                else if (bitsPerSample == 24)
                    tempBufferInts[iI] = vInt;
                /*
                if (this.channels == 2)
                    tempBuffer[iI + 1] = this.audioBuffer16[(0 * this.channels) + iI + 1];
                    */


                value += inc;



                mPhase += mPhaseIncrement;
                while (mPhase >= twoPI)
                {
                    mPhase -= twoPI;
                }

            }

            if (bitsPerSample == 16)
                this.audioBuffer16 = tempBuffer;
            else if (bitsPerSample == 24)
                this.audioBuffer32 = tempBufferInts;

            this.length = newLength;

            return 1;

        }//openwav



        public int GenerateNewWav2(int channelsIn, int sampleRateIn, int bitsPerSamplesIn, int lengthIn, Waveform waveformIn, double freqIn, bool usePolyBlep)
        {

            const double PI2 = 3.14159 * 2.0;

            audioFormat = 0x00;         //just guessed?!
            channels = channelsIn;
            sampleRate = sampleRateIn;
            bitsPerSample = bitsPerSamplesIn;

            byteRate = sampleRate * (bitsPerSample / 8) * channels;
            blockAlign = bitsPerSample / 8 * channels;

            int newLength = sampleRate;      //1 second i hope

            uint freq = (uint)freqIn;
            uint value = 0;

            const uint MAX_VALUE = 4294967295;


            uint inc = (uint)((MAX_VALUE / sampleRate) * freq);

            double mPhaseIncrement = (((PI2 * (double)freq) / (double)sampleRate));
            double mPhase = 0f;
            double twoPI = PI2;


            /*
            Phase Increment = 	Phase Acc Size 		*	 (Desired frequency / Sample rate freq)
eg			2^32	* 	(440hz / 156250) 	= 12094627.91

Output Freq =		(Phase Increment * Sample rate frequency) / Phase Acc Size

            */

            short[] tempBuffer;
            int[] tempBufferInts;

            if (bitsPerSample == 16)
            {
                tempBuffer = new short[newLength * this.channels];
                tempBufferInts = new int[1 * this.channels];
            }
            else if (bitsPerSample == 24)
            {
                tempBuffer = new short[1 * this.channels];
                tempBufferInts = new int[newLength * this.channels];
            }
            else
            {
                tempBuffer = new short[1 * this.channels];
                tempBufferInts = new int[1 * this.channels];
            }
                
        

            short v = 0;
            int vInt = 0;


            for (int i = 0; i < newLength; i++)
            {

                value += inc;



                mPhase += mPhaseIncrement;
                while (mPhase >= twoPI)
                {
                    mPhase -= twoPI;
                }



                switch (waveformIn)
                {
                    case Waveform.Ramp:
                        {
                            uint v1 = value >> 16;

                            if (usePolyBlep)
                            {
                                v1 = v1 & 0xf000;
                            }


                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;

                    case Waveform.Saw:
                        {
                  

                            double t = 0f;      //param in
                            double retValue = 0f;
                            uint intRetValue = 0;

                            //double twoPI = MAX_VALUE;

                            //Polyblep routine to reduce aliasing
                            //It works by targeting the transients: the part of the saw/ramp wave that is the big jump up/down. 
                            //The rest of the wav which is a slope is left unaffected.
                            //We adjust the first and last sample of a period: before and after the jump.
                            //We do this by adding/subtract an amount to the standard raw wav. For the unaffected parts, zero is added.
                            //The value added or subtracted is greater the closer we are to zero or one. eg. it is rounded/smoothed more

                            //This is only applicable for a ramp wave; a square wave has two transients per sample


                            //poly_blep(double t)
                            if (usePolyBlep)
                            {
                                /*
                                To go from 2^32 to 2PI range
                                we do intAcc = piAcc / 2PI * 255 
                                and piAcc = intAcc / 255 * 2PI
                                
                                */

                                //t = mPhase / twoPI;
                                t = value / (double)MAX_VALUE;

                                //double dt = mPhaseIncrement / twoPI;
                                double dt = inc / (double)MAX_VALUE;

                                // 0 <= t < 1
                                if (t < dt)
                                {
                                    t /= dt;
                                    retValue = t + t - t * t - 1.0;
                                }
                                // -1 < t < 0
                                else if (t > 1.0 - dt)
                                {
                                    t = (t - 1.0) / dt;
                                    retValue = t * t + t + t + 1.0;
                                }
                                // 0 otherwise
                                else
                                    retValue = 0.0f;

                                intRetValue = (uint)((retValue / PI2) * (double)MAX_VALUE);










                               t = mPhase / twoPI;
                                retValue = poly_blep(t, mPhaseIncrement, twoPI);
                            }


                            double doubleValueTemp = mPhase;
                            doubleValueTemp -= retValue;


                            double scaler = 0.6;

                            //convert to short

                            uint valueTemp = (uint)((doubleValueTemp / twoPI) * MAX_VALUE);

                            /*
                            uint valueTemp = (uint)((mPhase / twoPI) * MAX_VALUE);
                            valueTemp -= intRetValue;
                            */

                            uint v1 = 65535 - (valueTemp >> 16);

                            int valueOut = (int)v1 - 32767;
                            scaler = 0.6;

                            valueOut = (int)(scaler * valueOut);

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;




                            //convert to int
                            valueTemp = (uint)((doubleValueTemp / twoPI) * MAX_VALUE);

                            const int TWO_POW_24_SUB_1 = 16777216-1;

                            v1 = TWO_POW_24_SUB_1 - (valueTemp >> 8);

                            valueOut = (int)v1 - (TWO_POW_24_SUB_1>>1);
                            scaler = 0.6;

                            valueOut = (int)(scaler * valueOut);

                            if (valueOut < -(TWO_POW_24_SUB_1 >> 1))
                                valueOut = -(TWO_POW_24_SUB_1 >> 1);
                            if (valueOut > (TWO_POW_24_SUB_1 >> 1))
                                valueOut = (TWO_POW_24_SUB_1 >> 1);

                            vInt = (int)valueOut;



                        }
                        break;

                    case Waveform.Square:
                        {
                            uint v1 = (value >> 16);
                            if (v1 > 32767)
                                v = +32767;
                            else
                            {
                                v = -32767;
                            }

                        }
                        break;

                    default:
                        {
                            uint v1 = value >> 16;
                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;
                }



                int iI = i * this.channels;

                tempBuffer[iI] = v;
                /*
                if (this.channels == 2)
                    tempBuffer[iI + 1] = this.audioBuffer16[(0 * this.channels) + iI + 1];
                    */
            }

            this.audioBuffer16 = tempBuffer;
            this.length = newLength;

            return 1;

        }//openwav


                int iI = i * this.channels;

                if (bitsPerSample == 16)
                    tempBuffer[iI] = v;
                else if (bitsPerSample == 24)
                    tempBufferInts[iI] = vInt;
                /*
                if (this.channels == 2)
                    tempBuffer[iI + 1] = this.audioBuffer16[(0 * this.channels) + iI + 1];
                    */
            }

            if(bitsPerSample==16)
                this.audioBuffer16 = tempBuffer;
            else if (bitsPerSample == 24)
                this.audioBuffer32 = tempBufferInts;

            this.length = newLength;

            return 1;

        }//openwav


        public int GenerateNewWav(int channelsIn, int sampleRateIn, int bitsPerSamplesIn, int lengthIn, Waveform waveformIn, double freqIn)
        {

            audioFormat = 0x00;         //just guessed?!
            channels = channelsIn;
            sampleRate = sampleRateIn;
            bitsPerSample = bitsPerSamplesIn;

            byteRate = sampleRate * (bitsPerSample / 8) * channels;
            blockAlign = bitsPerSample / 8 * channels;

            int newLength = sampleRate;      //1 second i hope

            uint freq = (uint)freqIn;
            uint value = 0;

            const uint MAX_VALUE = 4294967295;


            uint inc = (uint)((MAX_VALUE / sampleRate) * freq);

            /*
            Phase Increment = 	Phase Acc Size 		*	 (Desired frequency / Sample rate freq)
eg			2^32	* 	(440hz / 156250) 	= 12094627.91

Output Freq =		(Phase Increment * Sample rate frequency) / Phase Acc Size

            */

            short[] tempBuffer = new short[newLength * this.channels];
            short v;

            for (int i = 0; i < newLength; i++)
            {

                value += inc;

                switch (waveformIn)
                {
                    case Waveform.Ramp:
                        {
                            uint v1 = value >> 16;
                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;

                    case Waveform.Saw:
                        {

                            bool usePolyBlep = true;
                            const double PI2 = 3.14159 * 2.0;

                            double t = 0f;      //param in
                            double retValue = 0f;
                            uint intRetValue = 0;

                            //double twoPI = MAX_VALUE;


                            //poly_blep(double t)
                            if (!usePolyBlep)
                            {
                                /*
                                To go from 2^32 to 2PI range
                                we do intAcc = piAcc / 2PI * 255 
                                and piAcc = intAcc / 255 * 2PI
                                
                                */

                                //t = mPhase / twoPI;
                                t = value / (double)MAX_VALUE;

                                //double dt = mPhaseIncrement / twoPI;
                                double dt = inc / (double)MAX_VALUE;

                                // 0 <= t < 1
                                if (t < dt)
                                {
                                    t /= dt;
                                    retValue = t + t - t * t - 1.0;
                                }
                                // -1 < t < 0
                                else if (t > 1.0 - dt)
                                {
                                    t = (t - 1.0) / dt;
                                    retValue = t * t + t + t + 1.0;
                                }
                                // 0 otherwise
                                else
                                    retValue = 0.0f;

                                intRetValue = (uint)((retValue / PI2) * (double)MAX_VALUE);
                            }



                            uint valueTemp = value;
                            valueTemp -= intRetValue;




                            uint v1 = 65535-(valueTemp >> 16);
                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;

                    case Waveform.Square:
                        {
                            uint v1 = (value >> 16);         
                            if (v1 > 32767)
                                v = +32767;
                            else
                            {
                                v = -32767;
                            }
                           
                        }
                        break;

                    default:
                        {
                            uint v1 = value >> 16;
                            int valueOut = (int)v1 - 32767;

                            if (valueOut < -32767)
                                valueOut = -32767;
                            if (valueOut > 32767)
                                valueOut = 32767;

                            v = (short)valueOut;
                        }
                        break;
                }

        
             
                int iI = i * this.channels;

                tempBuffer[iI] = v;
                /*
                if (this.channels == 2)
                    tempBuffer[iI + 1] = this.audioBuffer16[(0 * this.channels) + iI + 1];
                    */
            }

            this.audioBuffer16 = tempBuffer;
            this.length = newLength;

            return 1;

        }//openwav




        public int AdjustLength(int newLength)
        {

            switch (this.bitsPerSample)
            {
                case 16:
                    {

                        if (newLength == 0)
                            return 0;

                        short[] tempBuffer = new short[newLength * this.channels];

                        for (int i = 0; i < newLength; i++)
                        {

                            int iI = i * this.channels;

                            if (i < this.length)
                            {
                                tempBuffer[iI] = this.audioBuffer16[(0 * this.channels) + iI];
                                if (this.channels == 2)
                                    tempBuffer[iI + 1] = this.audioBuffer16[(0 * this.channels) + iI + 1];
                            }
                            else
                            {
                                tempBuffer[iI] = 0;
                                if (this.channels == 2)
                                    tempBuffer[iI + 1] = 0;
                            }


                        }

                        this.audioBuffer16 = tempBuffer;
                        this.length = newLength;

                        return 1;
                    }

                default:
                    {
                        return 0;
                    }

            }
        }




        //note - only worked on 16 bit not 24 bit yet!!!
        public int ExportTextNew2(string filenameIn, TextExportOptions textOptions)
        {

            bool decimalFormat = false;

            if (textOptions.numberFormat == 0) decimalFormat = true;
            else decimalFormat = false;

            int fileCount = 0;
            string outputFile = filenameIn;

            if (textOptions.splitBigFile)
            {
                string dir = Path.GetDirectoryName(filenameIn) + Path.DirectorySeparatorChar;
                string fn = Path.GetFileName(filenameIn);
                fn = Path.GetFileNameWithoutExtension(filenameIn);
                fn += ("_" + fileCount);
                string fe = Path.GetExtension(filenameIn);
                outputFile = dir + fn + fe;
            }

            StreamWriter writer = new StreamWriter(outputFile);

            if (textOptions.splitBigFile)
            {
                if (length > textOptions.splitBigFileSizeLimit)
                {
                    //StreamWriter writers = new StreamWriter(filenameIn);

                    /*
                    writer.Close();

                    string dir = Path.GetDirectoryName(filenameIn);
                    string fn = Path.GetFileName(filenameIn);
                    fn = Path.GetFileNameWithoutExtension(filenameIn);
                    string fe = Path.GetExtension(filenameIn);


                    writer = new StreamWriter(filenameIn);
                    */
                }
            }

            if (bitsPerSample == 16)
            {

                int counter = 0;
                char[] c = new char[2];         //or unsigned ?!

                for (int i = 0; i < length * channels; i++)

                {


                    if (textOptions.splitBigFile)
                    {
                        if (i >= textOptions.splitBigFileSizeLimit)
                        {

                            if (i / textOptions.splitBigFileSizeLimit > fileCount)
                            {
                                fileCount++;

                                //StreamWriter writers = new StreamWriter(filenameIn);
                                writer.Close();

                                string dir = Path.GetDirectoryName(filenameIn) + Path.DirectorySeparatorChar;
                                string fn = Path.GetFileName(filenameIn);
                                fn = Path.GetFileNameWithoutExtension(filenameIn);
                                fn += ("_" + fileCount);
                                string fe = Path.GetExtension(filenameIn);
                                outputFile = dir + fn + fe;

                                writer = new StreamWriter(outputFile);
                            }


                        }
                    }//if splitting







                    //int littleEndian = 1;				//default for wav... value 16 is stored as 


                    if (decimalFormat)
                    {
                        writer.Write(audioBuffer16[i]);

                        if (i % (textOptions.valuesPerLine) == (textOptions.valuesPerLine))
                            writer.Write(Environment.NewLine);
                        else
                            writer.Write(", ");

                    }
                    else
                    {
                        if (!textOptions.littleEndian)
                        {
                            //c[0] = ((audioBuffer16[i] >> 8) & 0xff);
                            //c[1] = (audioBuffer16[i] & 0xff);
                            writer.Write("0x");
                            writer.Write(((audioBuffer16[i] >> 8) & 0xff).ToString("X2"));
                            writer.Write(", 0x");
                            writer.Write((audioBuffer16[i] & 0xff).ToString("X2"));

                        }
                        else
                        {
                            //c[0] = (audioBuffer16[i] & 0xff);           //default for wav... value 16 is stored as 0x1000 not 0x0010
                            //c[1] = ((audioBuffer16[i] >> 8) & 0xff);

                            writer.Write("0x");
                            writer.Write((audioBuffer16[i] & 0xff).ToString("X2"));
                            writer.Write(", 0x");
                            writer.Write(((audioBuffer16[i] >> 8) & 0xff).ToString("X2"));

                        }

                        if (i % (textOptions.valuesPerLine) == (textOptions.valuesPerLine - 1))
                            writer.Write("," + Environment.NewLine);
                        else
                            writer.Write(", ");
                    }



                }

            }


            else if (bitsPerSample == 24)
            {

                int counter = 0;
                char[] c = new char[3];

                for (int i = 0; i < length * channels; i++)
                {


                    //int littleEndian = 1;				//default for wav... value 16 is stored as 


                    if (!textOptions.littleEndian)
                    {
                        /*
                        c[0] = ((audioBuffer32[i] >> 16) & 0xff);
                        c[1] = ((audioBuffer32[i] >> 8) & 0xff);
                        c[2] = (audioBuffer32[i] & 0xff);
                        */
                        writer.Write("0x");
                        writer.Write((audioBuffer32[i] >> 16) & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 8) & 0xff);
                        writer.Write(", 0x");
                        writer.Write(audioBuffer32[i] & 0xff);

                    }
                    else
                    {
                        /*
                        c[0] = (audioBuffer32[i] & 0xff);           //default for wav... value 16 is stored as 0x1000 not 0x0010
                        c[1] = ((audioBuffer32[i] >> 8) & 0xff);
                        c[2] = ((audioBuffer32[i] >> 16) & 0xff);
                        */
                        writer.Write("0x");
                        writer.Write(audioBuffer32[i] & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 8) & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 16) & 0xff);

                    }

                    /*
                    myFile << hex << "0x";
                    if (c[0] < 0x10)
                        myFile << "0";
                    myFile << (c[0] & 0xff) << ", ";

                    myFile << hex << "0x";
                    if (c[1] < 0x10)
                        myFile << "0";
                    myFile << (c[1] & 0xff) << ", ";

                    myFile << hex << "0x";
                    if (c[2] < 0x10)
                        myFile << "0";
                    myFile << (c[2] & 0xff) << ", ";
                    */
                    if (i % 8 == 7)
                        writer.Write("\n");
                }
            }

            writer.Close();
            return 1;
        }



        public int ExportTextNew(string filenameIn, int numberFormat, int valuesPerLine, bool littleEndian, bool groupSingleItemsIfStereo)
        {

            bool decimalFormat = false;

            if (numberFormat == 0) decimalFormat = true;
            else decimalFormat = false;


            StreamWriter writer = new StreamWriter(filenameIn);

            if (bitsPerSample == 16)
            {

                int counter = 0;
                char[] c = new char[2];         //or unsigned ?!

                for (int i = 0; i < length * channels; i++)

                {


                    //int littleEndian = 1;				//default for wav... value 16 is stored as 


                    if (decimalFormat)
                    {
                        writer.Write(audioBuffer16[i]);

                        if (i % (valuesPerLine) == (valuesPerLine))
                            writer.Write(Environment.NewLine);
                        else
                            writer.Write(", ");

                    }
                    else
                    {
                        if (!littleEndian)
                        {
                            //c[0] = ((audioBuffer16[i] >> 8) & 0xff);
                            //c[1] = (audioBuffer16[i] & 0xff);
                            writer.Write("0x");
                            writer.Write(((audioBuffer16[i] >> 8) & 0xff).ToString("X2"));
                            writer.Write(", 0x");
                            writer.Write((audioBuffer16[i] & 0xff).ToString("X2"));

                        }
                        else
                        {
                            //c[0] = (audioBuffer16[i] & 0xff);           //default for wav... value 16 is stored as 0x1000 not 0x0010
                            //c[1] = ((audioBuffer16[i] >> 8) & 0xff);

                            writer.Write("0x");
                            writer.Write((audioBuffer16[i] & 0xff).ToString("X2"));
                            writer.Write(", 0x");
                            writer.Write(((audioBuffer16[i] >> 8) & 0xff).ToString("X2"));

                        }

                        if (i % (valuesPerLine) == (valuesPerLine - 1))
                            writer.Write("," + Environment.NewLine);
                        else
                            writer.Write(", ");
                    }

                }

            }


            else if (bitsPerSample == 24)
            {

                int counter = 0;
                char[] c = new char[3];

                for (int i = 0; i < length * channels; i++)
                {


                    //int littleEndian = 1;				//default for wav... value 16 is stored as 


                    if (!littleEndian)
                    {
                        /*
                        c[0] = ((audioBuffer32[i] >> 16) & 0xff);
                        c[1] = ((audioBuffer32[i] >> 8) & 0xff);
                        c[2] = (audioBuffer32[i] & 0xff);
                        */
                        writer.Write("0x");
                        writer.Write((audioBuffer32[i] >> 16) & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 8) & 0xff);
                        writer.Write(", 0x");
                        writer.Write(audioBuffer32[i] & 0xff);

                    }
                    else
                    {
                        /*
                        c[0] = (audioBuffer32[i] & 0xff);           //default for wav... value 16 is stored as 0x1000 not 0x0010
                        c[1] = ((audioBuffer32[i] >> 8) & 0xff);
                        c[2] = ((audioBuffer32[i] >> 16) & 0xff);
                        */
                        writer.Write("0x");
                        writer.Write(audioBuffer32[i] & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 8) & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 16) & 0xff);

                    }

                    /*
                    myFile << hex << "0x";
                    if (c[0] < 0x10)
                        myFile << "0";
                    myFile << (c[0] & 0xff) << ", ";

                    myFile << hex << "0x";
                    if (c[1] < 0x10)
                        myFile << "0";
                    myFile << (c[1] & 0xff) << ", ";

                    myFile << hex << "0x";
                    if (c[2] < 0x10)
                        myFile << "0";
                    myFile << (c[2] & 0xff) << ", ";
                    */
                    if (i % 8 == 7)
                        writer.Write("\n");
                }
            }

            writer.Close();
            return 1;
        }





        public int ExportText(string filenameIn, bool littleEndian = true)
        {

            bool decimalFormat = false;

            StreamWriter writer = new StreamWriter(filenameIn);

            if (bitsPerSample == 16)
            {

                int counter = 0;
                char[] c = new char[2];         //or unsigned ?!

                for (int i = 0; i < length * channels; i++)

                {


                    //int littleEndian = 1;				//default for wav... value 16 is stored as 


                    if (decimalFormat)
                    {
                        writer.Write(audioBuffer16[i]);
                        writer.Write(Environment.NewLine);

                    }
                    else
                    {
                        if (!littleEndian)
                        {
                            //c[0] = ((audioBuffer16[i] >> 8) & 0xff);
                            //c[1] = (audioBuffer16[i] & 0xff);
                            writer.Write("0x");
                            writer.Write(((audioBuffer16[i] >> 8) & 0xff).ToString("X2"));
                            writer.Write(", 0x");
                            writer.Write((audioBuffer16[i] & 0xff).ToString("X2"));

                        }
                        else
                        {
                            //c[0] = (audioBuffer16[i] & 0xff);           //default for wav... value 16 is stored as 0x1000 not 0x0010
                            //c[1] = ((audioBuffer16[i] >> 8) & 0xff);

                            writer.Write("0x");
                            writer.Write((audioBuffer16[i] & 0xff).ToString("X2"));
                            writer.Write(", 0x");
                            writer.Write(((audioBuffer16[i] >> 8) & 0xff).ToString("X2"));

                        }

                        if (i % 8 == 7)
                            writer.Write(Environment.NewLine);
                        else
                            writer.Write(", ");
                    }

                }

            }


            else if (bitsPerSample == 24)
            {

                int counter = 0;
                char[] c = new char[3];

                for (int i = 0; i < length * channels; i++)
                {


                    //int littleEndian = 1;				//default for wav... value 16 is stored as 


                    if (!littleEndian)
                    {
                        /*
                        c[0] = ((audioBuffer32[i] >> 16) & 0xff);
                        c[1] = ((audioBuffer32[i] >> 8) & 0xff);
                        c[2] = (audioBuffer32[i] & 0xff);
                        */
                        writer.Write("0x");
                        writer.Write((audioBuffer32[i] >> 16) & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 8) & 0xff);
                        writer.Write(", 0x");
                        writer.Write(audioBuffer32[i] & 0xff);

                    }
                    else
                    {
                        /*
                        c[0] = (audioBuffer32[i] & 0xff);           //default for wav... value 16 is stored as 0x1000 not 0x0010
                        c[1] = ((audioBuffer32[i] >> 8) & 0xff);
                        c[2] = ((audioBuffer32[i] >> 16) & 0xff);
                        */
                        writer.Write("0x");
                        writer.Write(audioBuffer32[i] & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 8) & 0xff);
                        writer.Write(", 0x");
                        writer.Write((audioBuffer32[i] >> 16) & 0xff);

                    }

                    /*
                    myFile << hex << "0x";
                    if (c[0] < 0x10)
                        myFile << "0";
                    myFile << (c[0] & 0xff) << ", ";

                    myFile << hex << "0x";
                    if (c[1] < 0x10)
                        myFile << "0";
                    myFile << (c[1] & 0xff) << ", ";

                    myFile << hex << "0x";
                    if (c[2] < 0x10)
                        myFile << "0";
                    myFile << (c[2] & 0xff) << ", ";
                    */
                    if (i % 8 == 7)
                        writer.Write("\n");
                }
            }

            writer.Close();
            return 1;
        }















        public string GetSample(int sampleNo)
        {
            switch (bitsPerSample)
            {
                case 16:
                    {
                        if (channels == 1)
                            return "" + audioBuffer16[sampleNo];
                        return "" + audioBuffer16[sampleNo << 1] + "," + audioBuffer16[(sampleNo << 1) + 1];            //<< has lower precedence than i realised!
                    }
                case 24:
                    {
                        if (channels == 1)
                            return "" + audioBuffer32[sampleNo];
                        return "" + audioBuffer32[sampleNo * 2] + "," + audioBuffer32[sampleNo * 2 + 1];
                    }
                default:
                    {
                        return "";
                    }
                    break;
            }
        }












    }
}
