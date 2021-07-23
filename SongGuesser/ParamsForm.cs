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
            Challenge.WriteParams();
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxSongs.Items.Clear();
        }
    }
}
