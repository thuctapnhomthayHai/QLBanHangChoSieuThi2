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
    public partial class ThongKe : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SNTR6UK;Initial Catalog=PMBanHangSieuThi;Integrated Security=True");
        public ThongKe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                con.Open();
                string sql = "SELECT *FROM HangTrongKho";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            if (radioButton2.Checked == true)
            {
                con.Open();
                string sql = "SELECT *FROM HoaDonNhap";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            if (radioButton3.Checked == true)
            {
                con.Open();
                string sql = "SELECT *FROM HoaDonXuat";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
    }
}
