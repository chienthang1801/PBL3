using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Net4.DTO;
using Net4.DAL;
using Net4.BLL;

namespace Net4
{
    public partial class Menu : Form
    {
        public string user_name;
        public string role_name;
        public string[] arr;
        int Hour, Minute, Second;
        public LockScreen ls;
        public Boolean activate = false;
        public Menu()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(LoadHome);
            Thread thread= new Thread(ts);
            thread.Start();
        }

        void LoadHome()
        {
            Home home = new Home(user_name, role_name);
            home.ShowDialog();
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            LockScreen lockScreen = new LockScreen();
            lockScreen.FireEventLoginSuccess += LockScreen_FireEventLoginSuccess;
            lockScreen.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hour == 0 && Minute == 0 && Second == 0)
            {
                timer1.Stop();
                if (activate) { ls.lg.Dispose(); ls.Dispose(); activate = false; }
                button3_Click(sender, e);
            }
            else
            {
                if (Minute == 0 && Second == 0)
                {
                    Hour--;
                    Minute = 59;
                    Second = 59;
                    textBox4.Text = (Convert.ToInt32(textBox4.Text) - 100).ToString();
                }
                else if (Minute != 0 && Second == 0)
                {
                    Minute--;
                    Second = 59;
                    textBox4.Text = (Convert.ToInt32(textBox4.Text) - 100).ToString();
                }
                else if (Second != 0)
                {
                    Second--;
                }
                textBox5.Text = Hour.ToString() + ":" + Minute.ToString() + ":" +Second.ToString();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ls = new LockScreen(1);
            activate = true;
            ls.user_name= this.user_name;
            ls.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();

            int id = ACCOUNT_BLL.Instance.getAccountID(this.user_name);
            ACCOUNT_BLL.Instance.updateReminingtime(id, Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString());
            Menu_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RESETPASS rp = new RESETPASS(this.user_name);
            rp.Show();
        }

        private void LockScreen_FireEventLoginSuccess(string user_name, string role_name, string remaining_time)
        {
            this.user_name= user_name;
            this.role_name= role_name;
            textBox1.Text = user_name;
            arr = remaining_time.Split(':');
            
            Hour = Convert.ToInt32(arr[0]);
            Minute = Convert.ToInt32(arr[1]);
            Second = Convert.ToInt32(arr[2]);
            textBox2.Text = Hour.ToString() + ":" + Minute.ToString();
            textBox5.Text = Hour.ToString() + ":" + Minute.ToString();
            textBox3.Text = ((Hour * 60 + Minute) * 100).ToString();
            textBox4.Text = textBox3.Text;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                timer1.Stop();
                
                int id = ACCOUNT_BLL.Instance.getAccountID(this.user_name);
                ACCOUNT_BLL.Instance.updateReminingtime(id, Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString());
                Menu_Load(sender, e);
        }
    }
}
