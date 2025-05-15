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

namespace nhom8
{
    public partial class frmKhachHang : Form
    {
        private string viTri;
        private string tenNV;
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frmKhachHang(string viTri, string tenNV)
        {
            InitializeComponent();
            this.viTri = viTri;
            this.tenNV = tenNV;

            // Gán giá trị vào các TextBox hoặc Label nếu cần thiết
            txtChucVu.Text = viTri;
            txtTen.Text = tenNV;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm để tải dữ liệu ban đầu
            SetPlaceholder(); // Đặt placeholder cho ô tìm kiếm
        }
        private void LoadData()
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "exec GiaiMaKhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "KhachHang");

                dataGridView1.DataSource = ds.Tables["KhachHang"];
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        // Hàm thiết lập placeholder cho ô tìm kiếm
        private void SetPlaceholder()
        {
            tbTimKiem.Text = "Nhập thông tin cần tìm";
            tbTimKiem.ForeColor = System.Drawing.Color.Gray;

            tbTimKiem.Enter += RemovePlaceholder;
            tbTimKiem.Leave += AddPlaceholder;
        }

        // Khi ô tìm kiếm được focus, xóa placeholder
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Nhập thông tin cần tìm")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        // Khi ô tìm kiếm mất focus, nếu rỗng thì đặt lại placeholder
        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTimKiem.Text))
            {
                tbTimKiem.Text = "Nhập thông tin cần tìm";
                tbTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();

            // Kiểm tra nếu không có từ khóa tìm kiếm
            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập thông tin cần tìm")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                // Tìm kiếm theo tên hoặc số điện thoại đã giải mã (SDT_NPP)
                string sQuery = "exec GiaiMaKhachHang"; // Gọi thủ tục để lấy dữ liệu đã giải mã
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "KhachHang");

                // Lọc dữ liệu sau khi đã giải mã
                DataTable dt = ds.Tables["KhachHang"];
                DataView dv = new DataView(dt);

                // Điều kiện tìm kiếm theo TenNPP hoặc SDT_NPP (đã giải mã)
                dv.RowFilter = string.Format("TenKH LIKE '%{0}%' OR SDT_KH LIKE '%{0}%'", keyword);

                // Hiển thị kết quả tìm kiếm trong DataGridView
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tạm biệt! Hẹn gặp lại lần sau", "Thông báo");
            Environment.Exit(0);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            frmTaoKH taomoi = new frmTaoKH();
            frmTaoKH.DataUpdated += LoadData;
            taomoi.ShowDialog(); // Hiển thị form tạo nhà phân phối
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string maKH = row.Cells["MaKH"].Value.ToString();
                string ten = row.Cells["TenKH"].Value.ToString();
                string diaChi = row.Cells["DC_KH"].Value.ToString();
                string sdt = row.Cells["SDT_KH"].Value.ToString();

                frmSuaKH frmSua = new frmSuaKH(maKH, ten, diaChi, sdt);
                frmSua.DataUpdated += LoadData;
                frmSua.ShowDialog();
            }
        }

        private void SanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSanPham frm = new frmSanPham(viTri, tenNV);
            frm.ShowDialog();
        }

        private void NhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien frmNV = new frmNhanVien(viTri, tenNV);
            frmNV.ShowDialog();
        }

        private void NhaPhanPhoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNPP frmNPP = new frmNPP(viTri, tenNV);
            frmNPP.ShowDialog();
        }

        private void HoaDonNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhap frm = new frmNhap(viTri, tenNV);
            frm.ShowDialog();
        }

        private void HoaDonXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmXuat frm = new frmXuat(viTri, tenNV);
            frm.ShowDialog();
        }

        private void HoaDonNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHDNo frmHDNo = new frmHDNo(viTri, tenNV);
            frmHDNo.ShowDialog();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }
    }
}
