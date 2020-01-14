using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs_WavEditor_v02
{
    class Draw
    {

        private const int MAP_OFFS_X = 0;
        private const int MAP_OFFS_Y = 0;

        int waveformAreaHeight = 400;
        public int waveformAreaWidth { get; set; } = 900;

        public int horizZoom = 1;
        public int scrollX = 0;

        public int samplesPerPixel
        {
            get; set;
        } = 0;

        public int pixelsPerSample
        {
            get; set;
        } = 0;




        public int DrawStuff(PaintEventArgs e, AudioFile audioIn)
        {
            return DrawStuff(e, audioIn, 400, 900);
        }


        public int DrawStuff(PaintEventArgs e, AudioFile audioIn, int widthIn, int heightIn)
        {


            if (audioIn == null) return 0;

            waveformAreaWidth = widthIn;
            waveformAreaHeight = heightIn / 2;

            e.Graphics.Clear(Color.White);






            Graphics z = e.Graphics;

            Bitmap bmp = new Bitmap(widthIn, heightIn, z);
            //PaintEventArgs  pnt = bmp. 
            Graphics gr = Graphics.FromImage(bmp);





            //Pen pen = new Pen(Brushes.DeepSkyBlue);

            Pen pen = new Pen(Color.FromArgb(100, 255, 0, 0));
            gr.DrawLine(pen, MAP_OFFS_X + 0, MAP_OFFS_Y + 0, MAP_OFFS_X + 200, MAP_OFFS_Y + 100);

            int yAxis = waveformAreaHeight / 2;
            Pen BlackPen = new Pen(Color.Black);

            gr.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + yAxis, MAP_OFFS_X + waveformAreaWidth, MAP_OFFS_Y + yAxis);        // ---------
            gr.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + 0, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight);           //|	

            Pen GreyPen = new Pen(Color.FromArgb(255, 192, 192, 192));
            gr.DrawLine(GreyPen, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight, MAP_OFFS_X + waveformAreaWidth, MAP_OFFS_Y + waveformAreaHeight);

            //Draw second grid
            gr.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight + yAxis, MAP_OFFS_X + waveformAreaWidth, MAP_OFFS_Y + waveformAreaHeight + yAxis);      // ---------
            gr.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight + waveformAreaHeight);			//|	





            Pen greenPen = new Pen(Color.Green);
            Pen redPen = new Pen(Color.Red);





            int bitsPerSample = audioIn.bitsPerSample;
            int length = audioIn.length;
            int numChannels = audioIn.channels;
            int sampleRate = audioIn.sampleRate;

            byte[] audioBuffer8 = audioIn.audioBuffer8;
            short[] audioBuffer16 = audioIn.audioBuffer16;
            int[] audioBuffer32 = audioIn.audioBuffer32;






            int samplesToDraw = 16 << horizZoom;
            pixelsPerSample = waveformAreaWidth / samplesToDraw;

            samplesPerPixel = 0;		//we use either pixelsPerSample or samplesPerPixel depending on zoom


            if (pixelsPerSample == 0)
            {
                //eg... samples to draw   = 16 << 7 = 2048
                //      pixels per sample = 1066 / 2048
                //						  = 0

                //work out how many samples per pixel to represent

                samplesPerPixel = samplesToDraw / waveformAreaWidth;
                int pixelCounter = 0;
                int sampleCounter = (scrollX * numChannels);
                int average = 0;

                bool needToBreak = false;

                for (int pix = 0; pix < waveformAreaWidth; pix++)
                {

                    int q = (scrollX + pix) * samplesPerPixel * numChannels;

                    if (bitsPerSample == 8)
                    {
                        for (int j = 0; j < numChannels; j++)
                        {
                            int samplesPerPixelF = samplesPerPixel;

                            if ((scrollX + pix + 1) * 1 * samplesPerPixel > length)           //+1 because it uses the next samplesPerPixel number of samples for averaging
                            {
                                samplesPerPixelF = length - ((scrollX + pix) * 1 * samplesPerPixel);
                                needToBreak = true;
                            }


                            //new approach... using min/max value instead. overwrite average value
                            byte min = 127;                                                                    //8bit change
                            byte max = 127;                                                                     //8bit change
                            for (int s = 0; s < samplesPerPixelF; s++)
                            {
                                int n = q + (s * numChannels) + j;
                                if (audioBuffer8[n] > max) max = audioBuffer8[n];                               //8bit change
                                if (audioBuffer8[n] < min) min = audioBuffer8[n];                               //8bit change
                            }

                            //8bit change - convert to signed so we can follow pattern 16 bit does
                            int maxS = max - 128;
                            int minS = min - 128;
                            average = Math.Abs(maxS) > Math.Abs(minS) ? maxS : minS;



                            int x1 = pix;
                            int y1 = yAxis - (Math.Abs(average) * (waveformAreaHeight / 2)) / 128;              //8bit change

                            int x2 = pix;
                            int y2 = yAxis + (Math.Abs(average) * (waveformAreaHeight / 2)) / 128;              //8bit change

                            if (j == 0)
                                gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);
                            else
                                gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                        }

                        if (needToBreak)
                        {
                            break;
                        }
                    }
                    else if (bitsPerSample == 16)
                    {

                        for (int j = 0; j < numChannels; j++)
                        {
                            int samplesPerPixelF = samplesPerPixel;

                            if ((scrollX + pix + 1) * 1 * samplesPerPixel > length)           //+1 because it uses the next samplesPerPixel number of samples for averaging
                            {
                                samplesPerPixelF = length - ((scrollX + pix) * 1 * samplesPerPixel);
                                needToBreak = true;
                            }


                            //new approach... using min/max value instead. overwrite average value
                            short min = 0;
                            short max = 0;
                            for (int s = 0; s < samplesPerPixelF; s++)
                            {
                                int n = q + (s * numChannels) + j;
                                if (audioBuffer16[n] > max) max = audioBuffer16[n];
                                if (audioBuffer16[n] < min) min = audioBuffer16[n];
                            }
                            average = Math.Abs(max) > Math.Abs(min) ? max : min;



                            int x1 = pix;
                            int y1 = yAxis - (Math.Abs(average) * (waveformAreaHeight / 2)) / 32768;

                            int x2 = pix;
                            int y2 = yAxis + (Math.Abs(average) * (waveformAreaHeight / 2)) / 32768;

                            if (j == 0)
                                gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);
                            else
                                gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                        }

                        if (needToBreak)
                        {
                            break;
                        }

                    }
                    else if (bitsPerSample == 24)
                    {

                        for (int j = 0; j < numChannels; j++)
                        {

                            if ((pix + 1) * samplesPerPixel > length)           //+1 because it uses the next samplesPerPixel number of samples for averaging
                            {
                                samplesPerPixel = length - (pix * samplesPerPixel);
                                needToBreak = true;
                            }

                            average = 0;
                            for (int s = 0; s < samplesPerPixel; s++)
                            {

                                //before v09
                                //average += audioBuffer32[p + (s*numChannels) + j];		

                                //new for v09 - check incase we have gone past the last sample in the array
                                int n = q + (s * numChannels) + j;
                                if (n > length * numChannels)
                                {
                                    average += 0;                               //gone past last sample			
                                }
                                else
                                {
                                    average += audioBuffer32[n];
                                }
                                //////////////////////////////////////////////

                            }

                            average = average / samplesPerPixel;


                            int x1 = pix;
                            int y1 = yAxis - (Math.Abs(average) * (waveformAreaHeight / 2)) / 8388608;       //different value

                            int x2 = pix;
                            int y2 = yAxis + (Math.Abs(average) * (waveformAreaHeight / 2)) / 8388608;       //different value

                            if (j == 0)
                                gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);
                            else
                                gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                        }

                        if (needToBreak)
                        {
                            break;
                        }

                    }







                }


            }












            else
            {

                if (bitsPerSample == 8 && length > 0)
                {

                    //(audioBuffer16[i] * (waveformAreaHeight/2) ) / 32767

                    int prevX = 0, prevY = 0;
                    int prevX_2 = 0, prevY_2 = 0;           //stereo

                    int iI;
                    samplesToDraw = waveformAreaWidth;

                    for (int i = 0; i < samplesToDraw; i++)
                    {

                        iI = i * numChannels;       //if stereo, we must skip every other sample

                        iI += (scrollX * numChannels);      //just added!!! may need to remove

                        if ((iI / numChannels) > length) break;

                        int x1 = pixelsPerSample * i;
                        int y1 = yAxis - 5 - ((audioBuffer8[iI] - 128) * (waveformAreaHeight / 2)) / 128;

                        int x2 = pixelsPerSample * i;
                        int y2 = yAxis + 5 - ((audioBuffer8[iI] - 128) * (waveformAreaHeight / 2)) / 128;

                        gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);

                        if (i > 0)
                        {
                            gr.DrawLine(greenPen, MAP_OFFS_X + prevX, MAP_OFFS_Y + prevY, MAP_OFFS_X + x2, MAP_OFFS_Y + y1 + 5);
                        }

                        prevX = pixelsPerSample * i;
                        prevY = yAxis + 0 - ((audioBuffer8[iI] - 128) * (waveformAreaHeight / 2)) / 128;

                        if (numChannels == 2)
                        {

                            iI = (i * numChannels) + 1;

                            iI += (scrollX * numChannels);      //just added!!! may need to remove

                            x1 = pixelsPerSample * i;
                            y1 = yAxis - 5 - ((audioBuffer8[iI] - 128) * (waveformAreaHeight / 2)) / 128;

                            x2 = pixelsPerSample * i;
                            y2 = yAxis + 5 - ((audioBuffer8[iI] - 128) * (waveformAreaHeight / 2)) / 128;

                            gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                            if (i > 0)
                            {
                                gr.DrawLine(greenPen, MAP_OFFS_X + prevX_2, MAP_OFFS_Y + waveformAreaHeight + prevY_2, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y1 + 5);
                            }

                            prevX_2 = pixelsPerSample * i;
                            prevY_2 = yAxis + 0 - ((audioBuffer8[iI] - 128) * (waveformAreaHeight / 2)) / 128;


                        }

                    }
                }

                else if (bitsPerSample == 16 && length > 0)
                {

                    //(audioBuffer16[i] * (waveformAreaHeight/2) ) / 32767

                    int prevX = 0, prevY = 0;
                    int prevX_2 = 0, prevY_2 = 0;           //stereo

                    int iI;
                    samplesToDraw = waveformAreaWidth;

                    for (int i = 0; i < samplesToDraw; i++)
                    {

                        iI = i * numChannels;       //if stereo, we must skip every other sample

                        iI += (scrollX * numChannels);      //just added!!! may need to remove

                        if ((iI / numChannels) > length) break;

                        int x1 = pixelsPerSample * i;
                        int y1 = yAxis - 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                        int x2 = pixelsPerSample * i;
                        int y2 = yAxis + 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                        gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);

                        if (i > 0)
                        {
                            gr.DrawLine(greenPen, MAP_OFFS_X + prevX, MAP_OFFS_Y + prevY, MAP_OFFS_X + x2, MAP_OFFS_Y + y1 + 5);
                        }

                        prevX = pixelsPerSample * i;
                        prevY = yAxis + 0 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                        if (numChannels == 2)
                        {

                            iI = (i * numChannels) + 1;

                            iI += (scrollX * numChannels);      //just added!!! may need to remove

                            x1 = pixelsPerSample * i;
                            y1 = yAxis - 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                            x2 = pixelsPerSample * i;
                            y2 = yAxis + 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                            gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                            if (i > 0)
                            {
                                gr.DrawLine(greenPen, MAP_OFFS_X + prevX_2, MAP_OFFS_Y + waveformAreaHeight + prevY_2, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y1 + 5);
                            }

                            prevX_2 = pixelsPerSample * i;
                            prevY_2 = yAxis + 0 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;


                        }

                    }
                }

                else if (bitsPerSample == 24 && length > 0)
                {

                    //(audioBuffer16[i] * (waveformAreaHeight/2) ) / 32767

                    int prevX = 0, prevY = 0;
                    int prevX_2 = 0, prevY_2 = 0;           //stereo

                    int iI;

                    samplesToDraw = waveformAreaWidth;

                    for (int i = 0; i < samplesToDraw; i++)
                    {

                        iI = i * numChannels;       //if stereo, we must skip every other sample

                        iI += (scrollX * numChannels);      //just added!!! may need to remove

                        if ((iI / numChannels) > length) break;

                        int x1 = pixelsPerSample * i;
                        int y1 = yAxis - 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                        int x2 = pixelsPerSample * i;
                        int y2 = yAxis + 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                        gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);

                        if (i > 0)
                        {
                            gr.DrawLine(greenPen, MAP_OFFS_X + prevX, MAP_OFFS_Y + prevY, MAP_OFFS_X + x2, MAP_OFFS_Y + y1 + 5);
                        }

                        prevX = pixelsPerSample * i;
                        prevY = yAxis + 0 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;       //changed from 32768 and different buffer

                        if (numChannels == 2)
                        {

                            iI = (i * numChannels) + 1;

                            iI += (scrollX * numChannels);      //just added!!! may need to remove

                            x1 = pixelsPerSample * i;
                            y1 = yAxis - 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                            x2 = pixelsPerSample * i;
                            y2 = yAxis + 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                            gr.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                            if (i > 0)
                            {
                                gr.DrawLine(greenPen, MAP_OFFS_X + prevX_2, MAP_OFFS_Y + waveformAreaHeight + prevY_2, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y1 + 5);
                            }

                            prevX_2 = pixelsPerSample * i;
                            prevY_2 = yAxis + 0 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;     //changed from 32768 and different buffer


                        }

                    }
                }

            }



            int X1, w;
            int Y1, h;

            X1 = (audioIn.selectionStart - scrollX);
            if (X1 < 0) X1 = 0;
            Y1 = 0;

            w = ((audioIn.selectionEnd - scrollX) - X1);
            if (w < 0) w = 0;
            h = waveformAreaHeight * 2;

            if (pixelsPerSample > 0)
            {
                X1 = X1 * pixelsPerSample;
                w = w * pixelsPerSample;
            }
            else
            {
                if (samplesPerPixel > 0)
                {
                    X1 = X1 / samplesPerPixel;
                    w = w / samplesPerPixel;
                }
            }






            //Draw end line
            long xx = audioIn.length;

            if (pixelsPerSample > 0)
            {
                xx = (long)audioIn.length * pixelsPerSample;
                if (xx < waveformAreaWidth)
                    gr.DrawLine(greenPen, xx, 0, xx, heightIn);
            }
            else
            {
                if (samplesPerPixel > 0)
                    xx = audioIn.length / samplesPerPixel;
                else xx = 0;

                gr.DrawLine(greenPen, xx, 0, xx, heightIn);
            }



            //Draw position marker for playback
            xx = audioIn.marker;

            if (pixelsPerSample > 0)
            {
                xx = audioIn.marker * pixelsPerSample;

            }
            else
            {
                if (samplesPerPixel > 0)
                    xx = audioIn.marker / samplesPerPixel;
                else xx = 0;
            }

            gr.DrawLine(redPen, xx, 0, xx, heightIn);






            SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 200));
            e.Graphics.FillRectangle(highlightBrush, MAP_OFFS_X + X1, MAP_OFFS_Y + Y1,
                w, h);
            highlightBrush.Dispose();




            greenPen.Dispose();
            redPen.Dispose();

            GreyPen.Dispose();
            BlackPen.Dispose();
            pen.Dispose();

            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();

            return 1;
        }

        public int DrawStuffPrev(PaintEventArgs e, AudioFile audioIn, int widthIn, int heightIn)
        {
            if (audioIn == null) return 0;

            waveformAreaWidth = widthIn;
            waveformAreaHeight = heightIn / 2;

            e.Graphics.Clear(Color.White);

            //Pen pen = new Pen(Brushes.DeepSkyBlue);

            Pen pen = new Pen(Color.FromArgb(100, 255, 0, 0));
            e.Graphics.DrawLine(pen, MAP_OFFS_X + 0, MAP_OFFS_Y + 0, MAP_OFFS_X + 200, MAP_OFFS_Y + 100);

            int yAxis = waveformAreaHeight / 2;
            Pen BlackPen = new Pen(Color.Black);

            e.Graphics.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + yAxis, MAP_OFFS_X + waveformAreaWidth, MAP_OFFS_Y + yAxis);        // ---------
            e.Graphics.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + 0, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight);           //|	

            Pen GreyPen = new Pen(Color.FromArgb(255, 192, 192, 192));
            e.Graphics.DrawLine(GreyPen, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight, MAP_OFFS_X + waveformAreaWidth, MAP_OFFS_Y + waveformAreaHeight);

            //Draw second grid
            e.Graphics.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight + yAxis, MAP_OFFS_X + waveformAreaWidth, MAP_OFFS_Y + waveformAreaHeight + yAxis);      // ---------
            e.Graphics.DrawLine(BlackPen, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight, MAP_OFFS_X + 0, MAP_OFFS_Y + waveformAreaHeight + waveformAreaHeight);			//|	





            Pen greenPen = new Pen(Color.Green);
            Pen redPen = new Pen(Color.Red);





            int bitsPerSample = audioIn.bitsPerSample;
            int length = audioIn.length;
            int numChannels = audioIn.channels;
            int sampleRate = audioIn.sampleRate;

            short[] audioBuffer16 = audioIn.audioBuffer16;
            int[] audioBuffer32 = audioIn.audioBuffer32;






            int samplesToDraw = 16 << horizZoom;
            pixelsPerSample = waveformAreaWidth / samplesToDraw;

            samplesPerPixel = 0;		//we use either pixelsPerSample or samplesPerPixel depending on zoom


            if (pixelsPerSample == 0)
            {
                //eg... samples to draw   = 16 << 7 = 2048
                //      pixels per sample = 1066 / 2048
                //						  = 0

                //work out how many samples per pixel to represent

                samplesPerPixel = samplesToDraw / waveformAreaWidth;
                int pixelCounter = 0;
                int sampleCounter = (scrollX * numChannels);
                int average = 0;

                bool needToBreak = false;

                for (int i = 0; i < waveformAreaWidth; i++)
                {

                    int q = (scrollX + i * samplesPerPixel) * numChannels;


                    if (bitsPerSample == 16)
                    {

                        for (int j = 0; j < numChannels; j++)
                        {
                            int samplesPerPixelF = samplesPerPixel;

                            if ((scrollX + i + 1) * samplesPerPixel > length)           //+1 because it uses the next samplesPerPixel number of samples for averaging
                            {
                                samplesPerPixelF = ((scrollX + i) * samplesPerPixel) - length;
                                needToBreak = true;
                            }

                            /*
                            average = 0;
                            for (int s = 0; s < samplesPerPixel; s++)
                            {
                                int n = q + (s * numChannels) + j;
                                average += audioBuffer16[n];
                            }

                            average = (samplesPerPixel > 0) ? average / samplesPerPixel : 0;        //to ensure we dont divide by zero!
                            */                                                                      //average = average / samplesPerPixel;


                            //new approach... using min/max value instead. overwrite average value
                            short min = 0;
                            short max = 0;
                            for (int s = 0; s < samplesPerPixelF; s++)
                            {
                                int n = q + (s * numChannels) + j;
                                if (audioBuffer16[n] > max) max = audioBuffer16[n];
                                if (audioBuffer16[n] < min) min = audioBuffer16[n];
                            }
                            average = Math.Abs(max) > Math.Abs(min) ? max : min;



                            int x1 = i;
                            int y1 = yAxis - (Math.Abs(average) * (waveformAreaHeight / 2)) / 32768;

                            int x2 = i;
                            int y2 = yAxis + (Math.Abs(average) * (waveformAreaHeight / 2)) / 32768;

                            if (j == 0)
                                e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);
                            else
                                e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                        }

                        if (needToBreak)
                        {
                            break;
                        }

                    }
                    else if (bitsPerSample == 24)
                    {

                        for (int j = 0; j < numChannels; j++)
                        {

                            if ((i + 1) * samplesPerPixel > length)           //+1 because it uses the next samplesPerPixel number of samples for averaging
                            {
                                samplesPerPixel = (i * samplesPerPixel) - length;
                                needToBreak = true;
                            }

                            average = 0;
                            for (int s = 0; s < samplesPerPixel; s++)
                            {

                                //before v09
                                //average += audioBuffer32[p + (s*numChannels) + j];		

                                //new for v09 - check incase we have gone past the last sample in the array
                                int n = q + (s * numChannels) + j;
                                if (n > length * numChannels)
                                {
                                    average += 0;                               //gone past last sample			
                                }
                                else
                                {
                                    average += audioBuffer32[n];
                                }
                                //////////////////////////////////////////////

                            }

                            average = average / samplesPerPixel;


                            int x1 = i;
                            int y1 = yAxis - (Math.Abs(average) * (waveformAreaHeight / 2)) / 8388608;       //different value

                            int x2 = i;
                            int y2 = yAxis + (Math.Abs(average) * (waveformAreaHeight / 2)) / 8388608;       //different value

                            if (j == 0)
                                e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);
                            else
                                e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                        }

                        if (needToBreak)
                        {
                            break;
                        }

                    }







                }

                /*
                while (pixelCounter < waveformAreaWidth) {

                    average = 0;
                    int j = 3;
                    while (j != 0) {
                        average += 1;
                    }

                }
                */


                for (int i = 0; i < samplesToDraw; i++)
                {

                    /*
                    for (int j = 0; j < samplesPerPixel; j++) {

                        int iI = i * numChannels;		//if stereo, we must skip every other sample
                        iI += (scrollX * numChannels);		//just added!!! may need to remove
                        iI += j;
                    }
                    */



                    //[iI]




                    /*
                    int iI = i * numChannels;		//if stereo, we must skip every other sample
                    iI += (scrollX * numChannels);		//just added!!! may need to remove

                    //if ((iI / numChannels) > length) break;

                    int x1 = pixelsPerSample * i;
                    int y1 = yAxis - 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                    int x2 = pixelsPerSample * i;
                    int y2 = yAxis + 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;
                    */
                }

            }












            else
            {

                if (bitsPerSample == 16 && length > 0)
                {

                    //(audioBuffer16[i] * (waveformAreaHeight/2) ) / 32767

                    int prevX = 0, prevY = 0;
                    int prevX_2 = 0, prevY_2 = 0;           //stereo

                    int iI;

                    for (int i = 0; i < samplesToDraw; i++)
                    {

                        iI = i * numChannels;       //if stereo, we must skip every other sample

                        iI += (scrollX * numChannels);      //just added!!! may need to remove

                        if ((iI / numChannels) > length) break;

                        int x1 = pixelsPerSample * i;
                        int y1 = yAxis - 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                        int x2 = pixelsPerSample * i;
                        int y2 = yAxis + 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                        e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);

                        if (i > 0)
                        {
                            e.Graphics.DrawLine(greenPen, MAP_OFFS_X + prevX, MAP_OFFS_Y + prevY, MAP_OFFS_X + x2, MAP_OFFS_Y + y1 + 5);
                        }

                        prevX = pixelsPerSample * i;
                        prevY = yAxis + 0 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                        if (numChannels == 2)
                        {

                            iI = (i * numChannels) + 1;

                            iI += (scrollX * numChannels);      //just added!!! may need to remove

                            x1 = pixelsPerSample * i;
                            y1 = yAxis - 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                            x2 = pixelsPerSample * i;
                            y2 = yAxis + 5 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;

                            e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                            if (i > 0)
                            {
                                e.Graphics.DrawLine(greenPen, MAP_OFFS_X + prevX_2, MAP_OFFS_Y + waveformAreaHeight + prevY_2, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y1 + 5);
                            }

                            prevX_2 = pixelsPerSample * i;
                            prevY_2 = yAxis + 0 - (audioBuffer16[iI] * (waveformAreaHeight / 2)) / 32768;


                        }

                    }
                }

                else if (bitsPerSample == 24 && length > 0)
                {

                    //(audioBuffer16[i] * (waveformAreaHeight/2) ) / 32767

                    int prevX = 0, prevY = 0;
                    int prevX_2 = 0, prevY_2 = 0;           //stereo

                    int iI;

                    for (int i = 0; i < samplesToDraw; i++)
                    {

                        iI = i * numChannels;       //if stereo, we must skip every other sample

                        iI += (scrollX * numChannels);      //just added!!! may need to remove

                        if ((iI / numChannels) > length) break;

                        int x1 = pixelsPerSample * i;
                        int y1 = yAxis - 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                        int x2 = pixelsPerSample * i;
                        int y2 = yAxis + 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                        e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + 0 + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + 0 + y2);

                        if (i > 0)
                        {
                            e.Graphics.DrawLine(greenPen, MAP_OFFS_X + prevX, MAP_OFFS_Y + prevY, MAP_OFFS_X + x2, MAP_OFFS_Y + y1 + 5);
                        }

                        prevX = pixelsPerSample * i;
                        prevY = yAxis + 0 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;       //changed from 32768 and different buffer

                        if (numChannels == 2)
                        {

                            iI = (i * numChannels) + 1;

                            iI += (scrollX * numChannels);      //just added!!! may need to remove

                            x1 = pixelsPerSample * i;
                            y1 = yAxis - 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                            x2 = pixelsPerSample * i;
                            y2 = yAxis + 5 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;      //changed from 32768 and different buffer

                            e.Graphics.DrawLine(redPen, MAP_OFFS_X + x1, MAP_OFFS_Y + waveformAreaHeight + y1, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y2);

                            if (i > 0)
                            {
                                e.Graphics.DrawLine(greenPen, MAP_OFFS_X + prevX_2, MAP_OFFS_Y + waveformAreaHeight + prevY_2, MAP_OFFS_X + x2, MAP_OFFS_Y + waveformAreaHeight + y1 + 5);
                            }

                            prevX_2 = pixelsPerSample * i;
                            prevY_2 = yAxis + 0 - (audioBuffer32[iI] * (waveformAreaHeight / 2)) / 8388608;     //changed from 32768 and different buffer


                        }

                    }
                }

            }



            int X1, w;
            int Y1, h;

            X1 = (audioIn.selectionStart - scrollX);
            if (X1 < 0) X1 = 0;
            Y1 = 0;

            w = ((audioIn.selectionEnd - scrollX) - X1);
            if (w < 0) w = 0;
            h = waveformAreaHeight * 2;

            if (pixelsPerSample > 0)
            {
                X1 = X1 * pixelsPerSample;
                w = w * pixelsPerSample;
            }
            else
            {
                if (samplesPerPixel > 0)
                {
                    X1 = X1 / samplesPerPixel;
                    w = w / samplesPerPixel;
                }
            }





            //Draw end line
            int xx = audioIn.length;

            if (pixelsPerSample > 0)
            {
                xx = audioIn.length * pixelsPerSample;
            }
            else
            {
                if (samplesPerPixel > 0)
                    xx = audioIn.length / samplesPerPixel;
                else xx = 0;
            }

            e.Graphics.DrawLine(greenPen, xx, 0, xx, heightIn);



            //Draw position marker for playback
            xx = audioIn.marker;

            if (pixelsPerSample > 0)
            {
                xx = audioIn.marker * pixelsPerSample;

            }
            else
            {
                if (samplesPerPixel > 0)
                    xx = audioIn.marker / samplesPerPixel;
                else xx = 0;
            }

            e.Graphics.DrawLine(redPen, xx, 0, xx, heightIn);






            SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 200));
            e.Graphics.FillRectangle(highlightBrush, MAP_OFFS_X + X1, MAP_OFFS_Y + Y1,
                w, h);
            highlightBrush.Dispose();




            greenPen.Dispose();
            redPen.Dispose();

            GreyPen.Dispose();
            BlackPen.Dispose();
            pen.Dispose();

            return 1;
        }


    }





}
