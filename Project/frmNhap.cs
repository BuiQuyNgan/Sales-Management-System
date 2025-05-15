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
    public partial class frmNhap : Form
    {
        private string viTri;
        private string tenNV;
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frmNhap(string viTri, string tenNV)
        {
            InitializeComponent();
            this.viTri = viTri;
            this.tenNV = tenNV;

            // Gán giá trị vào các TextBox hoặc Label nếu cần thiết
            txtChucVu.Text = viTri;
            txtTen.Text = tenNV;
        }

        private void frmNhap_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm để tải dữ liệu ban đầu
            SetPlaceholder();
        }
        private void LoadData()
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "select * from Nhap"; // Giữ nguyên hoặc thay đổi truy vấn nếu cần
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Nhap");

                dataGridView1.DataSource = ds.Tables["Nhap"];
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

        // Hàm đặt placeholder cho ô tìm kiếm
        private void SetPlaceholder()
        {
            tbTimKiem.Text = "Nhập mã hoá đơn nhập cần tìm";
            tbTimKiem.ForeColor = System.Drawing.Color.Gray;

            tbTimKiem.Enter += RemovePlaceholder;
            tbTimKiem.Leave += AddPlaceholder;
        }

        // Khi ô tìm kiếm được focus, xóa placeholder
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Nhập mã hoá đơn nhập cần tìm")
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
                tbTimKiem.Text = "Nhập mã hoá đơn nhập cần tìm";
                tbTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void frmNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tạm biệt! Hẹn gặp lại lần sau", "Thông báo");
            Environment.Exit(0);
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();

            // Kiểm tra nếu không có từ khóa tìm kiếm
            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập mã hoá đơn nhập cần tìm")
            {
                MessageBox.Show("Vui lòng nhập mã hoá đơn nhập cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "select * from Nhap"; // Giữ nguyên truy vấn hoặc thay đổi nếu cần

                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Nhap");

                // Lọc dữ liệu theo mã dự nợ
                DataTable dt = ds.Tables["Nhap"];
                DataView dv = new DataView(dt);

                // Điều kiện tìm kiếm theo Mã Dự Nợ (MaDNo)
                dv.RowFilter = string.Format("MaHDN LIKE '%{0}%'", keyword);

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
