using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Net4.DTO;
using Net4.DAL;
using Net4.BLL;

namespace Net4
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
            
        }
        string s = "All";
        DataTable dataTable;
        MemoryStream ms;
        Boolean down = false, enter = false;
        int X, Y, MX, MY;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor= Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor= Color.Gainsboro;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Gainsboro;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Gainsboro;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Gainsboro;
        }

        private void GameMenu_Load(object sender, EventArgs e)
        {
                dataTable = GAME_BLL.Instance.getAllGAME();

                foreach (DataRow row in dataTable.Rows)
                {
                    GAMES game = new GAMES();
                    game.button1.Text = row["game_name"].ToString();
                    game.label1.Text = row["path"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    game.pictureBox1.Image = Image.FromStream(ms);
                    game.button1.Click += Button1_Click;
                    flowLayoutPanel1.Controls.Add(game);
                }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GAMES game = new GAMES();
            game = (GAMES)btn.Parent;
            if (game.label1.Text != "")
            {
                System.Diagnostics.Process.Start(game.label1.Text);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
                dataTable = GAME_BLL.Instance.getAllGAME();
                s = "All";
                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    GAMES game = new GAMES();
                    game.button1.Text = row["game_name"].ToString();
                    game.label1.Text = row["path"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    game.pictureBox1.Image = Image.FromStream(ms);
                    game.button1.Click += Button1_Click;
                    flowLayoutPanel1.Controls.Add(game);
                }
        }

        private void label3_Click(object sender, EventArgs e)
        {
                dataTable = GAME_BLL.Instance.getGameByID(1);
                s = "Offline";
                flowLayoutPanel1.Controls.Clear();
                
                foreach (DataRow row in dataTable.Rows)
                {
                    GAMES game = new GAMES();
                    game.button1.Text = row["game_name"].ToString();
                    game.label1.Text = row["path"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    game.pictureBox1.Image = Image.FromStream(ms);
                    game.button1.Click += Button1_Click;
                    flowLayoutPanel1.Controls.Add(game);
                }
        }

        private void label4_Click(object sender, EventArgs e)
        {
                dataTable = GAME_BLL.Instance.getGameByID(2);
                s = "Online";
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    GAMES game = new GAMES();
                    game.button1.Text = row["game_name"].ToString();
                    game.label1.Text = row["path"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    game.pictureBox1.Image = Image.FromStream(ms);
                    game.button1.Click += Button1_Click;
                    flowLayoutPanel1.Controls.Add(game);
                }
        }

        private void label5_Click(object sender, EventArgs e)
        {
                dataTable = GAME_BLL.Instance.getGameByID(3);
                s = "Tools";
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    GAMES game = new GAMES();
                    //bTDRINK.Size = new System.Drawing.Size(183, 217);
                    game.button1.Text = row["game_name"].ToString();
                    game.label1.Text = row["path"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    game.pictureBox1.Image = Image.FromStream(ms);
                    game.button1.Click += Button1_Click;
                    flowLayoutPanel1.Controls.Add(game);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                flowLayoutPanel1.Controls.Clear();

                if (s == "All")
                    dataTable = GAME_BLL.Instance.getAllGameByNAME(textBox1.Text);
                else if (s == "Online")
                    dataTable = GAME_BLL.Instance.getGameByNAME(2,textBox1.Text);
                else if (s == "Offline")
                    dataTable = GAME_BLL.Instance.getGameByNAME(1, textBox1.Text);
                else if (s == "Tools")
                    dataTable = GAME_BLL.Instance.getGameByNAME(3, textBox1.Text);
                
                foreach (DataRow row in dataTable.Rows)
                {
                    GAMES game = new GAMES();
                    game.button1.Text = row["game_name"].ToString();
                    game.label1.Text = row["path"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    game.pictureBox1.Image = Image.FromStream(ms);
                    game.button1.Click += Button1_Click;
                    flowLayoutPanel1.Controls.Add(game);
                }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            down = true;
            MX = e.X;
            MY = e.Y;
            X = this.Location.X;
            Y = this.Location.Y;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            enter = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (enter && down)
            {
                this.Location = new Point(X + (e.X - MX), Y + (e.Y - MY));
                this.BringToFront();
            }
        }
    }
}
