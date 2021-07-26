using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongGuesser
{
    public partial class PlayForm : Form
    {
        Random rand = new Random();
        int n;

        public PlayForm()
        {
            InitializeComponent();
        }

        private void playRandomSong()
        {
            n = rand.Next(0, Challenge.songs.Count);
            wmp.URL = Challenge.songs[n];
            Challenge.songs.RemoveAt(n);
            labelSongCounter.Text = Challenge.songs.Count.ToString();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            labelSongCounter.Text = Challenge.songs.Count.ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Challenge.gameDuration;
            progressBar1.Value = 0;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            playRandomSong();
            timer1.Start();
        }

        private void PlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            wmp.Ctlcontrols.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                wmp.Ctlcontrols.stop();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            wmp.Ctlcontrols.pause();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            timer1.Start();
            wmp.Ctlcontrols.play();
        }
    }
}
