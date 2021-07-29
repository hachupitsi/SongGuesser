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
    public partial class AnswerForm : Form
    {
        int answerTime;

        public AnswerForm()
        {
            InitializeComponent();
        }

        private void AnswerForm_Load(object sender, EventArgs e)
        {
            answerTime = 5;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            answerTime--;
            labelTimer.Text = answerTime.ToString();
            if (answerTime == 0)
            {
                timer1.Stop();

            }
        }

        private void labelAnswer_Click(object sender, EventArgs e)
        {
            labelAnswer.Text = Challenge.answer;
        }
    }
}
