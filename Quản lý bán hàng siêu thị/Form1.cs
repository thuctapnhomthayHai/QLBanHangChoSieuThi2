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
using System.Data;


namespace Quản_lý_bán_hàng_siêu_thị
{
    public partial class frmdn : Form
    {
        public frmdn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndn_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-76IRRSL\SQLEXPRESS;Initial Catalog=PMBanHangSieuThi;Integrated Security=True");

            

            try
            {
                conn.Open();
                string tk = txttk.Text;
                string mk = txtmk.Text;
                string sql = "select * from NhanVien where TenNV='" + tk + "' and MaNV = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    FrmMain frmMain = new FrmMain();
                    frmMain.ShowDialog();
                }
                else MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có thoát hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (tb == DialogResult.OK)
                Application.Exit();
        }
    }
}
