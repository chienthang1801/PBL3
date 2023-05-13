using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using Net4;
using System.Reflection.Emit;
using System.Collections;
using System.Security.Policy;
using Net4.DTO;
using Net4.BLL;
using Net4.DAL;

namespace Net4
{

    public partial class Home : Form
    {
        public string user_name;
        public string role_name;
        public System.Windows.Forms.Label reflb = new System.Windows.Forms.Label();
        bool cancel = false;
        public event EnableOrderButton eob = null;
        Modify modify = new Modify();
        DataTable dataTable;
        Boolean down = false, enter = false;
        int X, Y, MX, MY;

        public Home(string user_name, string role_name)
        {
                InitializeComponent();
                btnHome.Visible = false;
                listdrink1.Visible = false;
                addcart1.Visible = false;
                addcart1.btnThanhToan.Click += BtnThanhToan_Click;
                feedback1.Visible = false;
                entertains1.Visible = false;
                manage1.Visible = false;
                news1.Visible = false;
                this.user_name = user_name;
                this.role_name = role_name;
                dataTable = NEWS_BLL.Instance.GetAllNEWS();
                foreach (DataRow row in dataTable.Rows)
                {
                    PUBLICNEWS pn = new PUBLICNEWS();
                    pn.Size = new System.Drawing.Size(726, 300);
                    pn.labelDate.Text = ((DateTime)row["create_date"]).ToShortDateString();
                    pn.labelType.Text = row["type"].ToString();
                    pn.labelTitle.Text = row["title"].ToString();
                    pn.labelContent.Text = row["content"].ToString();
                    ms = new MemoryStream((byte[])row["image_url"]);
                    pn.pictureBox1.Image = Image.FromStream(ms);
                    news1.flowLayoutPanel1.Controls.Add(pn);
                }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Số tiền thanh toán của bạn là " + addcart1.lbMoney.Text + " đồng\n Bạn có chắc muốn thanh toán ?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                foreach(CARTITEM ci in addcart1.flowLayoutPanel1.Controls)
                {
                    PRIVATENEWS pn = new PRIVATENEWS();
                    pn.label1.Text = "Đơn hàng " + ci.label1.Text + " (x" + ci.txbSoLuong.Text + ") đang được xử lý";
                    pn.panel1.BackColor = ci.panel1.BackColor;
                    pn.pictureBox1.Image = ci.pictureBox1.Image;
                    pn.label2.Text = "Đặt hàng";
                    news1.flowLayoutPanel2.Controls.Add(pn);
                }
                addcart1.flowLayoutPanel1.Controls.Clear();
                MessageBox.Show("Thanh toán thành công!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.BackColor = Color.Firebrick;
            panel3.BackColor = Color.Firebrick;
            panel4.Show();
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;
            panel4.BackColor = Color.Firebrick;
            button7.BackColor = Color.Firebrick;
            button8.BackColor = Color.Firebrick;
            button9.BackColor = Color.Firebrick;
            btnHome.Visible = true;
            news1.Visible = false;
            listdrink1.Visible = false;
            addcart1.Visible = false;
            feedback1.Visible = false;
            entertains1.Visible = false;
            manage1.Visible = false;
            btnHome.BringToFront();
            this.BackgroundImage = null;
            label1.Text = "Home";
            label2.Text = "Main Menu";
        }
        MemoryStream ms;

        private void button2_Click(object sender, EventArgs e)
        {
                panel3.Visible = true;
                panel2.BackColor = Color.DarkOrange;
                panel3.BackColor = Color.DarkOrange;
                panel4.Show();
                panel4.Height = button2.Height;
                panel4.Top = button2.Top;
                panel4.BringToFront();
                panel4.BackColor = Color.DarkOrange;
                button7.BackColor = Color.DarkOrange;
                button8.BackColor = Color.DarkOrange;
                button9.BackColor = Color.DarkOrange;
                news1.Visible = false;
                btnHome.Visible = false;
                feedback1.Visible = false;
                entertains1.Visible = false;
                manage1.Visible = false;
                listdrink1.Visible = true;
                listdrink1.lbTitle.Text = "List Drink";
                listdrink1.flowLayoutPanel1.Controls.Clear();
                dataTable = PRODUCT_BLL.Instance.getProductByID(1);

                
                foreach (DataRow row in dataTable.Rows)
                {
                    BTDRINK bTDRINK = new BTDRINK();
                    bTDRINK.Size = new System.Drawing.Size(183, 217);
                    bTDRINK.label1.Text = row["prices"].ToString() + "đ";
                    bTDRINK.label2.Text = row["product_name"].ToString();
                    bTDRINK.button1.BackColor = Color.DarkOrange;
                    bTDRINK.button1.Click += Button1_Click;
                    ms = new MemoryStream((byte[])row["image_url"]);
                    bTDRINK.pictureBox1.Image = Image.FromStream(ms);
                    listdrink1.flowLayoutPanel1.Controls.Add(bTDRINK);
                }
                addcart1.Visible = true;
                listdrink1.BringToFront();
                this.BackgroundImage = null;
                label1.Text = "Drink";
                label2.Text = "Drink Menu";
        }

        private void button3_Click(object sender, EventArgs e)
        {
                panel3.Visible = true;
                panel2.BackColor = Color.Gold;
                panel3.BackColor = Color.Gold;
                panel4.Height = button3.Height;
                panel4.Show();
                panel4.Top = button3.Top;
                panel4.BringToFront();
                panel4.BackColor = Color.Gold;
                button7.BackColor = Color.Gold;
                button8.BackColor = Color.Gold;
                button9.BackColor = Color.Gold;
                listdrink1.lbTitle.Text = "List Food";
                listdrink1.flowLayoutPanel1.Controls.Clear();
                dataTable = PRODUCT_BLL.Instance.getProductByID(2);
                foreach (DataRow row in dataTable.Rows)
                {
                    BTDRINK bTDRINK = new BTDRINK();
                    bTDRINK.Size = new System.Drawing.Size(183, 217);
                    bTDRINK.label1.Text = row["prices"].ToString() + "đ";
                    bTDRINK.label2.Text = row["product_name"].ToString();
                    bTDRINK.button1.BackColor = Color.Gold;
                    bTDRINK.button1.Click += Button1_Click;
                    ms = new MemoryStream((byte[])row["image_url"]);
                    bTDRINK.pictureBox1.Image = Image.FromStream(ms);
                    listdrink1.flowLayoutPanel1.Controls.Add(bTDRINK);
                }
                news1.Visible = false;
                addcart1.Visible = true;
                btnHome.Visible = false;
                feedback1.Visible = false;
                listdrink1.Visible = true;
                entertains1.Visible = false;
                manage1.Visible = false;
                listdrink1.lbTitle.Text = "List Food";
                this.BackgroundImage = null;
                label1.Text = "Food";
                label2.Text = "Food Menu";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cancel = false;
            Button btn = sender as Button;
            BTDRINK btd = new BTDRINK();
            btd = (BTDRINK)btn.Parent.Parent;
            if (btd.label2.Text == "Nạp tự chọn")
            {
                
                reflb.Text = "0";
                OptRecharge optrecharges1 = new OptRecharge();
                optrecharges1.moneyAcception += new MoneyAcception(Optrecharges1_moneyAcception);
                optrecharges1.exit += new Exit(Optrecharges1_exit);
                optrecharges1.ShowDialog();
                btd.label1.Text = reflb.Text + "đ";
            }
            if (!cancel)
            {
                CARTITEM cARTITEM = new CARTITEM();
                cARTITEM.Size = new System.Drawing.Size(266, 122);
                cARTITEM.label1.Text = btd.label2.Text;
                cARTITEM.lbPrice.Text = btd.label1.Text;
                cARTITEM.panel1.BackColor = btd.button1.BackColor;
                cARTITEM.pictureBox1.Image = btd.pictureBox1.Image;
                cARTITEM.btnExit.Click += BtnExit_Click;
                cARTITEM.txbSoLuong.TextChanged += TxbSoLuong_TextChanged;
                addcart1.flowLayoutPanel1.Controls.Add(cARTITEM);
            }
        }

        private void Optrecharges1_exit()
        {
            cancel = true;
            return;
        }

        private void Optrecharges1_moneyAcception(Naptien nt)
        {
            reflb.Text = nt.money;
        }


        private void TxbSoLuong_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            foreach (CARTITEM ci in addcart1.flowLayoutPanel1.Controls)
            {
                s += (Convert.ToInt32(ci.lbPrice.Text.TrimEnd('đ')) * Convert.ToInt32(ci.txbSoLuong.Text));
            }
            ADDCART ac = new ADDCART();
            ac = (ADDCART)addcart1.flowLayoutPanel1.Parent;
            ac.lbMoney.Text = s.ToString() + "đ";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CARTITEM ci = new CARTITEM();
            ci = (CARTITEM)btn.Parent.Parent;
            addcart1.flowLayoutPanel1.Controls.Remove(ci);
        }

        private void button4_Click(object sender, EventArgs e)
        {
                panel3.Visible = true;
                panel2.BackColor = Color.ForestGreen;
                panel3.BackColor = Color.ForestGreen;
                panel4.Show();
                panel4.Height = button4.Height;
                panel4.Top = button4.Top;
                panel4.BringToFront();
                panel4.BackColor = Color.ForestGreen;
                button7.BackColor = Color.ForestGreen;
                button8.BackColor = Color.ForestGreen;
                button9.BackColor = Color.ForestGreen;
                addcart1.Visible = true;
                news1.Visible = false;
                btnHome.Visible = false;
                feedback1.Visible = false;
                listdrink1.Visible = true;
                entertains1.Visible = false;
                manage1.Visible = false;
                listdrink1.lbTitle.Text = "List Recharge";
                listdrink1.flowLayoutPanel1.Controls.Clear();
                dataTable = PRODUCT_BLL.Instance.getProductByID(3);
                foreach (DataRow row in dataTable.Rows)
                {
                    BTDRINK bTDRINK = new BTDRINK();
                    bTDRINK.Size = new System.Drawing.Size(183, 217);
                    bTDRINK.label1.Text = row["prices"].ToString() + "đ";
                    bTDRINK.label2.Text = row["product_name"].ToString();
                    bTDRINK.button1.BackColor = Color.ForestGreen;
                    bTDRINK.button1.Click += Button1_Click;
                    ms = new MemoryStream((byte[])row["image_url"]);
                    bTDRINK.pictureBox1.Image = Image.FromStream(ms);
                    listdrink1.flowLayoutPanel1.Controls.Add(bTDRINK);
                }
                this.BackgroundImage = null;
                label1.Text = "Recharge";
                label2.Text = "Recharge Account";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.BackColor = Color.DeepSkyBlue;
            panel3.BackColor = Color.DeepSkyBlue;
            panel4.Show();
            panel4.Height = button5.Height;
            panel4.Top = button5.Top;
            panel4.BringToFront();
            panel4.BackColor = Color.DeepSkyBlue;
            button7.BackColor = Color.DeepSkyBlue;
            button8.BackColor = Color.DeepSkyBlue;
            button9.BackColor = Color.DeepSkyBlue;
            news1.Visible = false;
            addcart1.Visible = false;
            btnHome.Visible = false;
            entertains1.Visible = false;
            listdrink1.Visible = false;
            feedback1.Visible = false;
            manage1.Visible = false;
            this.BackgroundImage = null;
            label1.Text = "Communication";
            label2.Text = "Chat Box";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.BackColor = Color.DarkViolet;
            panel3.BackColor = Color.DarkViolet;
            panel4.Show();
            panel4.Height = button6.Height;
            panel4.Top = button6.Top;
            panel4.BringToFront();
            panel4.BackColor = Color.DarkViolet;
            button7.BackColor = Color.DarkViolet;
            button8.BackColor = Color.DarkViolet;
            button9.BackColor = Color.DarkViolet;
            feedback1.Visible = true;
            feedback1.BringToFront();
            news1.Visible = false;
            addcart1.Visible = false;
            btnHome.Visible = false;
            entertains1.Visible = false;
            listdrink1.Visible = false;
            manage1.Visible = false;
            this.BackgroundImage = null;
            label1.Text = "Feedback";
            label2.Text = "User Feedback";
        }

        private void Home_Load(object sender, EventArgs e)
        {
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
            panel9.Hide();
            panel10.Hide();
            panel11.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listdrink1_Load(object sender, EventArgs e)
        {
            listdrink1.txbSearch.TextChanged += TxbSearch_TextChanged;
        }

        string query;
        private void TxbSearch_TextChanged(object sender, EventArgs e)
        {
                if (listdrink1.txbSearch.Text != "Tìm Kiếm")
                {
                    listdrink1.flowLayoutPanel1.Controls.Clear();
                    if (listdrink1.lbTitle.Text == "List Drink") dataTable = PRODUCT_BLL.Instance.getProductByNAME(1, listdrink1.txbSearch.Text);
                    else if (listdrink1.lbTitle.Text == "List Food") dataTable = PRODUCT_BLL.Instance.getProductByNAME(2, listdrink1.txbSearch.Text);
                    else if (listdrink1.lbTitle.Text == "List Recharge") dataTable = PRODUCT_BLL.Instance.getProductByNAME(3, listdrink1.txbSearch.Text);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        BTDRINK bTDRINK = new BTDRINK();
                        bTDRINK.Size = new System.Drawing.Size(183, 217);
                        bTDRINK.label1.Text = row["prices"].ToString() + "đ";
                        bTDRINK.label2.Text = row["product_name"].ToString();
                        if (listdrink1.lbTitle.Text == "List Drink") bTDRINK.button1.BackColor = Color.DarkOrange;
                        else if (listdrink1.lbTitle.Text == "List Food") bTDRINK.button1.BackColor = Color.Gold;
                        else if (listdrink1.lbTitle.Text == "List Recharge") bTDRINK.button1.BackColor = Color.ForestGreen;
                        ms = new MemoryStream((byte[])row["image_url"]);
                        bTDRINK.pictureBox1.Image = Image.FromStream(ms);
                        listdrink1.flowLayoutPanel1.Controls.Add(bTDRINK);
                        bTDRINK.button1.Click += Button1_Click;
                    }
                }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.BackColor = Color.HotPink;
            panel3.BackColor = Color.HotPink;
            panel4.Height = button6.Height;
            panel4.Show();
            panel4.Top = button11.Top;
            panel4.BringToFront();
            panel4.BackColor = Color.HotPink;
            button7.BackColor = Color.HotPink;
            button8.BackColor = Color.HotPink;
            button9.BackColor = Color.HotPink;
            addcart1.Visible = false;
            btnHome.Visible = false;
            news1.Visible = false;
            entertains1.Visible = false;
            listdrink1.Visible = false;
            manage1.Visible = true;
            manage1.BringToFront();
            this.BackgroundImage = null;
            feedback1.Visible = false;
            label1.Text = "Management";
            label2.Text = "Edit Database";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.BackColor = Color.SaddleBrown;
            panel3.BackColor = Color.SaddleBrown;
            panel4.Show();
            panel4.Height = button6.Height;
            panel4.Top = button12.Top;
            panel4.BringToFront();
            panel4.BackColor = Color.SaddleBrown;
            button7.BackColor = Color.SaddleBrown;
            button8.BackColor = Color.SaddleBrown;
            button9.BackColor = Color.SaddleBrown;
            news1.Visible = false;
            addcart1.Visible = false;
            btnHome.Visible = false;
            listdrink1.Visible = false;
            feedback1.Visible = false;
            manage1.Visible = false;
            entertains1.Visible = true;
            entertains1.BringToFront();
            this.BackgroundImage = null;
            label1.Text = "Entertainment";
            label2.Text = "Other activities";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.RoyalBlue;
            panel3.Visible = false;
            button7.BackColor = Color.RoyalBlue;
            button8.BackColor = Color.RoyalBlue;
            button9.BackColor = Color.RoyalBlue;
            addcart1.Visible = false;
            btnHome.Visible = false;
            entertains1.Visible = false;
            listdrink1.Visible = false;
            feedback1.Visible = false;
            manage1.Visible = false;
            news1.Visible = true;
            news1.BringToFront();
            this.BackgroundImage = null;
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
