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
using Quản_lý_bán_hàng_siêu_thị.DataAccess;

namespace Quản_lý_bán_hàng_siêu_thị
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }
        DataTable QuanLyBanHang;
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
           // btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            
        }
        private void ResetValues()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDVT.Text = "";
            txtMaNSX.Text = "";
            txtMaLoai.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                int index = 0;
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            if (QuanLyBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaHang.Text = dtg_QLBH.CurrentRow.Cells["MaHang"].Value.ToString();
            txtTenHang.Text = dtg_QLBH.CurrentRow.Cells["TenHang"].Value.ToString();
            txtDVT.Text = dtg_QLBH.CurrentRow.Cells["DVT"].Value.ToString();
            txtMaNSX.Text = dtg_QLBH.CurrentRow.Cells["MaNhaSX"].Value.ToString();
            txtMaLoai.Text = dtg_QLBH.CurrentRow.Cells["MaLoai"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
           // btnHuy.Enabled = true;
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            DataAccess.Connection.Connect(); //Mở kết nối
            //txtMaHang.Enabled = false;
           // btnLuu.Enabled = false;
            //btnHuy.Enabled = false;
            LoadDataGridView();
        
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaHang,TenHang,DVT,MaNhaSX,MaLoai From DanhMucHang";
            QuanLyBanHang = Connection.GetDataToTable(sql); //lấy dữ liệu
            dtg_QLBH.DataSource = QuanLyBanHang;

            dtg_QLBH.Columns[0].HeaderText = "Mã hàng hóa";
            dtg_QLBH.Columns[1].HeaderText = "Tên hàng";
            dtg_QLBH.Columns[2].HeaderText = "DVT";
            dtg_QLBH.Columns[3].HeaderText = "Mã NSX";
            dtg_QLBH.Columns[4].HeaderText = "Mã loại";

            dtg_QLBH.Columns[0].Width = 150;
            dtg_QLBH.Columns[1].Width = 200;
            dtg_QLBH.Columns[2].Width = 200;
            dtg_QLBH.Columns[3].Width = 200;
            dtg_QLBH.Columns[4].Width = 150;

            dtg_QLBH.AllowUserToAddRows = false;
            dtg_QLBH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }
            if (txtDVT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
                return;
            }
            if (txtMaNSX.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNSX.Focus();
                return;
            }
            if (txtMaLoai.Text == "  ")
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }



            sql = "SELECT MaHang FROM DanhMucHang WHERE MaHang=N'" + txtMaHang.Text.Trim() + "'";
            
            if (Connection.CheckKey(sql))
            {
                MessageBox.Show("Mã  hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                txtMaHang.Text = "";
                return;
            }
            sql = "INSERT INTO DanhMucHang(MaHang,TenHang, DVT,MaNhaSX,MaLoai) VALUES (N'" + txtMaHang.Text.Trim() + "',N'" + txtTenHang.Text.Trim() + "',N'" + txtDVT.Text.Trim() + "',N'" + txtMaNSX.Text + "',N'" + txtMaLoai.Text.Trim()+"')";
            //sql1 = "insert into NhaSanXuat(MaNhaSX,TenNhaSX) Values (N'"+null + "',N'" + txtTenNSX.Text.Trim() +"') ";
            //sql2 = "insert into LoaiHang(MaLoai,TenLoai) Values (N'" + null + "',N'" + txtTenLoai.Text.Trim() + "') ";
            Connection.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            //btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (QuanLyBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên  hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }
            if (txtDVT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đon vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
                return;
            }
            if (txtMaNSX.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNSX.Focus();
                return;
            }
            if (txtMaLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }



            sql = "UPDATE DanhMucHang SET  TenHang=N'" + txtTenHang.Text.Trim().ToString() +
                    "',DVT=N'" + txtDVT.Text.Trim().ToString() +
                    "',MaNhaSX='" + txtMaNSX.Text.ToString() +
                    "',MaLoai=N'" + txtMaLoai.Text.Trim().ToString() +
                    "' WHERE MaHang=N'" + txtMaHang.Text + "'";
            Connection.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            //btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtDVT.Enabled = false;
            txtMaLoai.Enabled = false;
            txtTenHang.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            txtMaNSX.Enabled = false;
            string sql;
            if (QuanLyBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE DanhMucHang WHERE MaHang=N'" + txtMaHang.Text + "'";
                Connection.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Đề Nghị Bạn Nhập Từ Khóa Càn Tìm!", "Thông Báo!");
                return;
            }
            else
            {
                if (cbxTimKiemTheo.Text == "Mã hàng")
                {
                    dtg_QLBH.DataSource = Connection.GetDataToTable("select * from DanhMucHang where MaHang like '%" + txtTimKiem.Text.Trim() + "%'");
                }
                if (cbxTimKiemTheo.Text == "Tên hàng")
                {
                    dtg_QLBH.DataSource = Connection.GetDataToTable("select * from DanhMucHang where TenHang like '%" + txtTimKiem.Text.Trim() + "%'");
                }

            }
            //cbxTimKiemTheo.Items.AddRange(new string[] { "a", "b", "c" });
            //cbxTimKiemTheo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void cbxTimKiemTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxTimKiemTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //cbxTimKiemTheo.SelectedIndex = cbxTimKiemTheo.Items.IndexOf("test1");
            //cbxTimKiemTheo.SelectedIndex = cbxTimKiemTheo.Items.IndexOf("test2");
        }
        //public static void SelectItemByValue(this ComboBox cbo, string value)
        //{
        //    for (int i = 0; i < cbo.Items.Count; i++)
        //    {
        //        var prop = cbo.Items[i].GetType().GetProperty(cbo.ValueMember);
        //        if (prop != null && prop.GetValue(cbo.Items[i], null).ToString() == value)
        //        {
        //            cbo.SelectedIndex = i;
        //            break;
        //        }
        //    }
        //}

        private void cbxTimKiemTheo_SelectedValueChanged(object sender, EventArgs e)
        {
            //cbxTimKiemTheo.SelectedIndex = cbxTimKiemTheo.Items.IndexOf("test2");
        }

        private void cbxTimKiemTheo_Click(object sender, EventArgs e)
        {
            cbxTimKiemTheo.DisplayMember = "Text";
            cbxTimKiemTheo.ValueMember = "Value";

            cbxTimKiemTheo.Items.Add(new { Text = "Mã hàng", Value = "Mã hàng" });
            cbxTimKiemTheo.Items.Add(new { Text = "Tên hàng", Value = "Tên hàng" });
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult hoi;
            hoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //private void buttonClear_Click(object sender, EventArgs e)
        //{
        //    cbxTimKiemTheo.SelectedIndex = -1; //removes item from "textBox" of comboBox, items are still there
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    cbxTimKiemTheo.Items.Clear(); //completely clears items from comboBox, list it empty!
        //}

    }
}
