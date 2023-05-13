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
using Net4;

namespace Net4
{
    public partial class LISTDRINK : UserControl
    {
        public LISTDRINK()
        {
            InitializeComponent();
        }

        private void txbSearch_Enter(object sender, EventArgs e)
        {
            if (txbSearch.Text == "Tìm Kiếm")
            {
                txbSearch.Text = "";
                txbSearch.ForeColor = Color.White;
            }
        }

        private void txbSearch_Leave(object sender, EventArgs e)
        {
            if (txbSearch.Text == "")
            {
                txbSearch.ForeColor = Color.Gray;
                txbSearch.Text = "Tìm Kiếm";
            }
        }
        
        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
