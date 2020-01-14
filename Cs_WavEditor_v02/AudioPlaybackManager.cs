using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cs_WavEditor_v02
{
    class AudioPlaybackManager
    {

        RawSourceWaveStream rs;
        WaveOutEvent wo;

        System.Timers.Timer timer;
        MdiChildForm windowForm;

        public enum PlayState { Stopped, Playing, Paused };

        public PlayState currentPlayState
        {
            get; set;
        } = PlayState.Stopped;

        public int PrepareAudio(AudioFile audio, MdiChildForm formIn)
        {

            windowForm = formIn;

            var sampleRate = audio.sampleRate;

            MemoryStream ms;
            switch (audio.bitsPerSample)
            {

                case 8:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer8.Length];
                        Buffer.BlockCopy(audio.audioBuffer8, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;

                case 16:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer16.Length * 2];
                        Buffer.BlockCopy(audio.audioBuffer16, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;

                case 24:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer32.Length * 4];
                        Buffer.BlockCopy(audio.audioBuffer32, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;

                default:
                    {
                        byte[] byteArray = new byte[audio.audioBuffer32.Length * 4];
                        Buffer.BlockCopy(audio.audioBuffer32, 0, byteArray, 0, byteArray.Length);
                        ms = new MemoryStream(byteArray);
                    }
                    break;
            }

            int bps = (audio.bitsPerSample == 24) ? 32 : audio.bitsPerSample;
            //24bit being stored in a 32 bit buffer

            rs = new RawSourceWaveStream(ms, new NAudio.Wave.WaveFormat(sampleRate, bps, audio.channels));

            wo = new WaveOutEvent();
            wo.Init(rs);

            return 1;
        }


        void Play2()
        {
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
            wo.Dispose();
        }

        void Resume()
        {

        }

        public PlayState PlayPause()
        {
            switch (currentPlayState)
            {

                case PlayState.Stopped:
                    {
                        Play();
                    }
                    break;

                case PlayState.Playing:
                    {
                        Pause();
                    }
                    break;

                case PlayState.Paused:
                    {
                        Resume();
                    }
                    break;
            }



            return currentPlayState;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            windowForm.UpdatePosition(rs.CurrentTime.Milliseconds);

        }


        private void audioOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
             timer.Enabled = false;

            currentPlayState = PlayState.Stopped;

            if (wo != null)
            {
                wo.Dispose();
                wo = null;
            }

            if (wo != null)
            {
                wo.Dispose();
                wo = null;
            }

        }


        public int Play()
        {


            /*
            Task.Factory.StartNew(() => Play2());
            */
            wo.PlaybackStopped += new EventHandler<StoppedEventArgs>(audioOutput_PlaybackStopped);

            currentPlayState = PlayState.Playing;
            wo.Play();


            timer = new System.Timers.Timer();
            timer.Interval = 200;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            /*
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
            wo.Dispose();
            */

            return 1;
        }



        public int Pause()
        {
            currentPlayState = PlayState.Paused;
            wo.Stop();

            return 1;
        }

        public int Stop()
        {
            return 1;
        }

        public int GetPositionMs()
        {
            return rs.CurrentTime.Milliseconds;
            //return 0;
        }

        public int GetPositionS()
        {
            return rs.CurrentTime.Seconds;
            //return 0;
        }

        public long GetPositionInFrames()
        {
            return rs.Position / rs.BlockAlign;
        }

        public long GetPositionInBytes()
        {
            return rs.Position;
        }

        public int SeekPosition(int pos)
        {
            return 1;
        }
    }
}
