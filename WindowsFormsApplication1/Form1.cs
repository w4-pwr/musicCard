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

       

        private void button4_Click(object sender, EventArgs e)
        {
            //directX clicked


            DirectSound.Device Device = new DirectSound.Device();
            Device.SetCooperativeLevel(this.Handle, DirectSound.CooperativeLevel.Priority);
            DirectSound.Buffer AudioBuffer = new DirectSound.Buffer("C:\\v.wav", Device);
            AudioBuffer.Play(0, BufferPlayFlags.Default);
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
        private void button5_Click(object sender, EventArgs e)
        {
           //// waveIn
           // int sampleRate = 22000;
           // int channels = 1;
           // waveIn = new WaveIn();
           // waveIn.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, channels);
           // waveIn.DeviceNumber = 0;
           // waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(
           //     waveIn_DataAvailable);
           // writerr = new WaveFileWriter("nagranie1", waveIn.WaveFormat);
           // waveIn.StartRecording();

           // waveIn = new WaveIn();
           // waveIn.StartRecording();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //waveIn.StopRecording();
            //waveIn.Save
        }

     
    }
}