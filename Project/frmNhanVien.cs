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
    public partial class frmNhanVien : Form
    {
        private string viTri;
        private string tenNV;
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public frmNhanVien(string viTri, string tenNV)
        {
            InitializeComponent();
            this.viTri = viTri;
            this.tenNV = tenNV;

            // Gán giá trị vào các TextBox hoặc Label nếu cần thiết
            txtChucVu.Text = viTri;
            txtTen.Text = tenNV;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
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
                string sQuery = "exec GiaiMaNhanVien";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "NhanVien");

                dataGridView1.DataSource = ds.Tables["NhanVien"];
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
                string sQuery = "exec GiaiMaNhanVien"; // Gọi thủ tục để lấy dữ liệu đã giải mã
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "NhanVien");

                // Lọc dữ liệu sau khi đã giải mã
                DataTable dt = ds.Tables["NhanVien"];
                DataView dv = new DataView(dt);

                // Điều kiện tìm kiếm theo TenNPP hoặc SDT_NPP (đã giải mã)
                dv.RowFilter = string.Format("TenNV LIKE '%{0}%' OR SDT_NV LIKE '%{0}%'", keyword);

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

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tạm biệt! Hẹn gặp lại lần sau", "Thông báo");
            Environment.Exit(0);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            frmTaoNV taomoi = new frmTaoNV();
            frmTaoNV.DataUpdated += LoadData;
            taomoi.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu dòng được chọn là hợp lệ
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột
                string maNV = row.Cells["MaNV"].Value.ToString();
                string tenNV = row.Cells["TenNV"].Value.ToString();
                string viTri = row.Cells["ViTri"].Value.ToString();
                string sdt = row.Cells["SDT_NV"].Value.ToString();
                string mk = row.Cells["MatKhau"].Value.ToString();

                // Mở form sửa sản phẩm và truyền dữ liệu
                frmSuaNV suaNV = new frmSuaNV(maNV, tenNV, viTri, sdt, mk);

                // Đăng ký sự kiện DataUpdated để tải lại dữ liệu sau khi sửa
                suaNV.DataUpdated += LoadData;

                suaNV.ShowDialog();
            }
        }

        private void SanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSanPham frm = new frmSanPham(viTri, tenNV);
            frm.ShowDialog();
        }

        private void KhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKhachHang frmKH = new frmKhachHang(viTri, tenNV);
            frmKH.ShowDialog();
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

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
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
    }
}
