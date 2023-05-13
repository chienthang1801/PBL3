using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4.DTO;

namespace Net4
{
    public delegate void Exit();
    public partial class OptRecharge : Form
    {
        public OptRecharge()
        {
            InitializeComponent();
        }
        public event MoneyAcception moneyAcception = null;
        public event Exit exit = null;
        public string s;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiền cần nạp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                s = textBox1.Text;
                
                /*for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] < '0' || s[i] > '9') MessageBox.Show("Số tiền không thể chứa kí tự khác ngoài số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    break;
                }*/
                    if (moneyAcception != null)
                    {
                        moneyAcception(new Naptien { money = textBox1.Text });
                    }
                    this.Dispose();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (exit != null)
            {
                exit();
            }
            this.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (exit != null)
            {
                exit();
            }
            this.Dispose();
        }
    }
}
