using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quản_lý_bán_hàng_siêu_thị
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanHang bh = new BanHang();
            bh.Show();
            this.Hide();
        }

        private void quảnLýKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BangKhachHang KH = new BangKhachHang();
            KH.ShowDialog();
            DataTable dt = new DataTable();
        }
    }
}
