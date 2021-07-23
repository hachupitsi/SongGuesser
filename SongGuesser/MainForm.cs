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
    public partial class MainForm : Form
    {
        PlayForm playf = new PlayForm();
        ParamsForm paramsf = new ParamsForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            playf.ShowDialog();
        }

        private void buttonParams_Click(object sender, EventArgs e)
        {
            paramsf.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
