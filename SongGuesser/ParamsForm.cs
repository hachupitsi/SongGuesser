using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SongGuesser
{
    public partial class ParamsForm : Form
    {
        public ParamsForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Challenge.gameDuration = Convert.ToInt32(cbGameDuration.Text);
            Challenge.songDuration = Convert.ToInt32(cbSongDuration.Text);
            Challenge.randomStart = cbRandomStart.Checked;
            Challenge.allDir = cbSelectAllDir.Checked;
            Challenge.WriteParams();
            this.Hide();
        }

        private void SetParams()
        {
            cbGameDuration.Text = Challenge.gameDuration.ToString();
            cbSongDuration.Text = Challenge.songDuration.ToString();
            cbRandomStart.Checked = Challenge.randomStart;
            cbSelectAllDir.Checked = Challenge.allDir;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            SetParams();
            this.Hide();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                listBoxSongs.Items.AddRange(Directory.GetFiles(fbd.SelectedPath, "*.wav", cbSelectAllDir.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
                Challenge.songs.Clear();
                Challenge.songs.AddRange(Directory.GetFiles(fbd.SelectedPath, "*.wav", cbSelectAllDir.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
                Challenge.savedFolder = fbd.SelectedPath;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxSongs.Items.Clear();
        }

        private void ParamsForm_Load(object sender, EventArgs e)
        {
            SetParams();
            listBoxSongs.Items.AddRange(Challenge.songs.ToArray());
        }
    }
}
