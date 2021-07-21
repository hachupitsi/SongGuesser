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
        ParamsForm pf = new ParamsForm();
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonParams_Click(object sender, EventArgs e)
        {
            pf.ShowDialog();
        }
    }
}
