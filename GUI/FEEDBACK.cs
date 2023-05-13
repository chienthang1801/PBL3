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
    public partial class FEEDBACK : UserControl
    {
        public FEEDBACK()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phản hồi của bạn đã được ghi nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
