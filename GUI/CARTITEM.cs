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
    public delegate void RemoveCartItem(object sender);
    public delegate void EnableOrderButton(object sender);
    public partial class CARTITEM : UserControl
    {
        public event RemoveCartItem rci = null;
        public event EnableOrderButton eob = null;
        public CARTITEM()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int SL = Convert.ToInt32(txbSoLuong.Text);
            SL++;
            txbSoLuong.Text = SL.ToString();
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            if (txbSoLuong.Text == "1")
            {

            }
            else
            {
                int SL = Convert.ToInt32(txbSoLuong.Text);
                SL--;
                txbSoLuong.Text = SL.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rci != null)
            {
                rci(this);
            }
            this.Dispose();
        }
    }
}

