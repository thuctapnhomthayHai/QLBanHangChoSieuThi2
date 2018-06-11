using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_bán_hàng_siêu_thị
{
    public partial class NhanVien : Form
    {

        public NhanVien()
        {
            InitializeComponent();
        }
        DataView dv = new DataView();
        string strConn = @"Server=.\SQLEXPRESS;Initial Catalog=PMBanHangSieuThi;Integrated Security=True";
        SqlConnection conn;
        private void LoadData()
        {
            SqlCommand cmd = new SqlCommand("select * from NhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dv = new DataView(dt);
            dgvNV.DataSource = dv;
        }
        private void databinding()
        {
            this.txtMaNV.DataBindings.Clear();
            this.txtMaNV.DataBindings.Add("Text", dgvNV.DataSource, "MaNV", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTenNV.DataBindings.Clear();
            this.txtTenNV.DataBindings.Add("Text", dgvNV.DataSource, "TenNV", true, DataSourceUpdateMode.OnPropertyChanged);
            this.DateNS.DataBindings.Clear();
            this.DateNS.DataBindings.Add("Text", dgvNV.DataSource, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtGT.DataBindings.Clear();
            this.txtGT.DataBindings.Add("Text", dgvNV.DataSource, "GT", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtDiaChi.DataBindings.Clear();
            this.txtDiaChi.DataBindings.Add("Text", dgvNV.DataSource, "Diachi", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtSDT.DataBindings.Clear();
            this.txtSDT.DataBindings.Add("Text", dgvNV.DataSource, "SDT", true, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtEmail.DataBindings.Add("Text", dgvNV.DataSource, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            //DateTime.ParseExact("DateNS", "dd/MM/yyyy", CultureInfo.InvariantCulture);       

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConn);
            conn.Open();
            LoadData();
            databinding();
        }

        private void dgvNV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvNV.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtTimKiem.Text = Convert.ToString(dgvNV.CurrentRow.Cells["MaNV"].Value);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = @"Server=.\SQLEXPRESS;Initial Catalog=PMBanHangSieuThi;Integrated Security=True";
                SqlConnection con = new SqlConnection(strConn);
                con.Open();

                SqlCommand cmd = new SqlCommand("InsertNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaNV", txtMaNV.Text);
                cmd.Parameters.Add(p);
                SqlParameter p1 = new SqlParameter("@TenNV", txtTenNV.Text);
                cmd.Parameters.Add(p1);
                SqlParameter p3 = new SqlParameter("@NgaySinh", DateNS.Value);
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@GT", txtGT.Text);
                cmd.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@Diachi", txtDiaChi.Text);
                cmd.Parameters.Add(p5);
                SqlParameter p6 = new SqlParameter("@SDT", txtSDT.Text);
                cmd.Parameters.Add(p6);
                SqlParameter p7 = new SqlParameter("@Email", txtEmail.Text);
                cmd.Parameters.Add(p7);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Thêm mới thành công!");
                LoadData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = @"Server=.\SQLEXPRESS;Initial Catalog=PMBanHangSieuThi;Integrated Security=True";
                SqlConnection con = new SqlConnection(strConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaNV", txtMaNV.Text);
                cmd.Parameters.Add(p);
                SqlParameter p1 = new SqlParameter("@TenNV", txtTenNV.Text);
                cmd.Parameters.Add(p1);
                SqlParameter p3 = new SqlParameter("@NgaySinh", DateNS.Text);
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@GT", txtGT.Text);
                cmd.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@Diachi", txtDiaChi.Text);
                cmd.Parameters.Add(p5);
                SqlParameter p6 = new SqlParameter("@SDT", txtSDT.Text);
                cmd.Parameters.Add(p6);
                SqlParameter p7 = new SqlParameter("@Email", txtEmail.Text);
                cmd.Parameters.Add(p7);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!");
                LoadData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string strConn = @"Server=.\SQLEXPRESS;Initial Catalog=PMBanHangSieuThi;Integrated Security=True";
            SqlConnection con = new SqlConnection(strConn);
            con.Open();

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ID Phiếu xuất  ?" + txtMaNV.Text, "Thông báo", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {


                    SqlCommand cmd = new SqlCommand("DeleteNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p = new SqlParameter("@MaNV", txtMaNV.Text);
                    cmd.Parameters.Add(p);

                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Xóa thành công!");
                    LoadData();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa bản ghi hiện thời!\n" + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            databinding();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = @"Server=.\SQLEXPRESS;Initial Catalog=PMBanHangSieuThi;Integrated Security=True";
                SqlConnection con = new SqlConnection(strConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("TimKiemNV", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@Manv", txtTimKiem.Text.Trim());
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dgvNV.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }


    }
}
