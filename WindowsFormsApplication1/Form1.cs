using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}