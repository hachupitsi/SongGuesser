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
        int songDuration;

        public PlayForm()
        {
            InitializeComponent();
        }

        private void endGame()
        {
            timer1.Stop();
            wmp.Ctlcontrols.stop();
        }

        private void playRandomSong()
        {
            if (Challenge.songs.Count == 0)
                endGame();
            else
            {
                songDuration = Challenge.songDuration;
                n = rand.Next(0, Challenge.songs.Count);
                wmp.URL = Challenge.songs[n];
                Challenge.songs.RemoveAt(n);
                labelSongCounter.Text = Challenge.songs.Count.ToString();
            }
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            labelSongCounter.Text = Challenge.songs.Count.ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Challenge.gameDuration;
            progressBar1.Value = 0;
            songDuration = Challenge.songDuration;
            labelSongDuration.Text = songDuration.ToString();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            playRandomSong();
            timer1.Start();
        }

        private void PlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            endGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            songDuration--;
            labelSongDuration.Text = songDuration.ToString();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                endGame();
                return;
            }
            if (songDuration == 0)
                playRandomSong();
        }

        private void gamePause()
        {
            timer1.Stop();
            wmp.Ctlcontrols.pause();
        }

        private void gameStart()
        {
            timer1.Start();
            wmp.Ctlcontrols.play();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            gamePause();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            gameStart();
        }

        private void PlayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                gamePause();
                if (MessageBox.Show("Правильный ответ?", "Игрок 1", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    labelPlayer1.Text = (Convert.ToInt32(labelPlayer1.Text) + 1).ToString();
                    playRandomSong();
                }
                gameStart();
            }
            else if (e.KeyData == Keys.L)
            {
                gamePause();
                if (MessageBox.Show("Правильный ответ?", "Игрок 2", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    labelPlayer2.Text = (Convert.ToInt32(labelPlayer2.Text) + 1).ToString();
                    playRandomSong();
                }
                gameStart();
            }
        }
    }
}
