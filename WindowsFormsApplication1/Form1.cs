using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.DirectSound;
using DirectSound = Microsoft.DirectX.DirectSound;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Boolean isPlaying = false;
        private string file = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //play Button
            file = textBox1.Text;
            axWindowsMediaPlayer1.URL = file;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            isPlaying = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {//stopButton
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {//Pause Button

            if (isPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                isPlaying = false;
                button3.Text = "Wznów";
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                isPlaying = true;
                button3.Text = "Pauza";
            }
        }


        private Device dSound;
        private void button4_Click(object sender, EventArgs e)
        {
            //directX clicked
            dSound = new Device();
            dSound.SetCooperativeLevel(this, CooperativeLevel.Priority);
            SecondaryBuffer sound;
            BufferDescription d = new BufferDescription();

            // Set descriptor’s flags
            d.ControlPan = true;
            d.ControlVolume = true;
            d.ControlFrequency = true;
            d.ControlEffects = true;

            sound = new SecondaryBuffer("C:\\Users\\Rafal\\Documents\\Visual Studio 2015\\Projects\\WindowsFormsApplication1\\v.wav", d, dSound);
            sound.Play(0, BufferPlayFlags.Default);


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //waveOut

            var reader = new WaveFileReader("v.wav");
            var waveOut = new WaveOut(); // or WaveOutEvent()
            waveOut.Init(reader);
            waveOut.Play();

        }
        WaveIn waveIn;
        WaveFileWriter writer;
        string output = "C:\\Users\\Rafal\\Documents\\Visual Studio 2015\\Projects\\WindowsFormsApplication1\\nagranie1.wav";
        private BufferedWaveProvider bufferedWaveProvider;

        private void button5_Click(object sender, EventArgs e)
        {   //startRecording
            waveIn = new WaveIn();
            writer = new WaveFileWriter(output, waveIn.WaveFormat);

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(new_dataAvailable);

            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true;
            waveIn.StartRecording();
        }

        void new_dataAvailable(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                short sample = (short)((e.Buffer[i + 1] << 8) | e.Buffer[i + 0]);
                float sample32 = sample / 32768f;

                writer.WriteByte(e.Buffer[i + 0]);
                writer.WriteByte(e.Buffer[i + 1]);

            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            //stop Recording
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn = null;
            writer.Close();
            writer = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("v.wav", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            String info = "";

            info += ("riff id:" + br.ReadBytes(4).ToString() + "\n");
            UInt32 size = br.ReadUInt32();
            info += ("size: " + size + "\n");
            info += ("wavId: " + br.ReadBytes(4).ToString() + "\n");
            info += ("fmtid" + br.ReadBytes(4).ToString() + "\n");
            info += ("fmtSize:" + br.ReadUInt32() + "\n");
            info += ("format:" + br.ReadUInt16() + "\n");
            info += ("channels:" + br.ReadUInt16() + "\n");
            info += ("sampleRate:" + br.ReadUInt32() + "\n");
            info += ("bytePerSize: " + br.ReadUInt32() + "\n");
            info += ("blockSize:" + br.ReadUInt16() + "\n");
            info += ("bit: " + br.ReadUInt16() + "\n");
            info += ("dataId: " + br.ReadBytes(4).ToString() + "\n");
            info += ("dataSize: " + br.ReadUInt32() + "\n");




            MessageBox.Show(info);

        }


  




    }

}
