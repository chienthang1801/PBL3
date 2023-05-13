using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net4
{
    public partial class GAMES : UserControl
    {
        public GAMES()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
            pictureBox1.BackColor = Color.LightGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
            pictureBox1.BackColor = Color.LightGray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void GAME_Load(object sender, EventArgs e)
        {

        }
    }
}
