using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Net4
{
    public partial class BTNHOME : UserControl
    {
        public BTNHOME()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(LoadMenu);
            Thread thread= new Thread(ts);
            thread.Start();
            
        }
        void LoadMenu()
        {
            GameMenu gameMenu = new GameMenu();
            gameMenu.ShowDialog();
        }
    }
}
