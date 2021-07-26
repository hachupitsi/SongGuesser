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
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            playRandomSong();
        }

        private void PlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            wmp.Ctlcontrols.stop();
        }
    }
}
