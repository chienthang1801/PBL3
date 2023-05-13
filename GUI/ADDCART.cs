using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4;

namespace Net4
{
    public partial class ADDCART : UserControl
    {
        public ADDCART()
        {
            InitializeComponent();
        }

        private void txbMGG_Enter(object sender, EventArgs e)
        {
            if (txbMGG.Text == "Nhập mã giảm giá")
            {
                txbMGG.Text = "";
                txbMGG.ForeColor = Color.White;
            }
        }

        private void txbMGG_Leave(object sender, EventArgs e)
        {
            if (txbMGG.Text == "")
            {
                txbMGG.ForeColor = Color.Gray;
                txbMGG.Text = "Nhập mã giảm giá";
            }
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            int s = 0;
            foreach (CARTITEM ci in flowLayoutPanel1.Controls)
            {
                s += (Convert.ToInt32(ci.lbPrice.Text.TrimEnd('đ')) * Convert.ToInt32(ci.txbSoLuong.Text));
            }
            ADDCART ac = new ADDCART();
            ac = (ADDCART)flowLayoutPanel1.Parent;
            ac.lbMoney.Text = s.ToString() + "đ";
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            int s = 0;
            foreach (CARTITEM ci in flowLayoutPanel1.Controls)
            {
                s += (Convert.ToInt32(ci.lbPrice.Text.TrimEnd('đ')) * Convert.ToInt32(ci.txbSoLuong.Text));
            }
            ADDCART ac = new ADDCART();
            ac = (ADDCART)flowLayoutPanel1.Parent;
            ac.lbMoney.Text = s.ToString() + "đ";
        }

        private void lbMoney_TextChanged(object sender, EventArgs e)
        {
            if (lbMoney.Text == "0đ")
            {
                btnThanhToan.Enabled = false;
            }
            else btnThanhToan.Enabled = true;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
        }
    }
}
