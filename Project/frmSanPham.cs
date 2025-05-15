using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace nhom8
{
    public partial class frmSanPham : Form
    {
        private string viTri;
        private string tenNV;

        public frmSanPham(string viTri, string tenNV)
        {
            InitializeComponent();
            this.viTri = viTri;
            this.tenNV = tenNV;

            frmTaoSP.DataUpdated += LoadData;
        }

        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private Dictionary<string, string> loaiHangMapping = new Dictionary<string, string>
        {
            { "Ăn vặt", "AV" },
            { "Sữa", "Sữa" },
            { "Đồ đóng hộp", "ĐH" },
            { "Lương thực", "LT" },
            { "Gia vị", "GV" }
        };

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            // Gán thông tin vị trí và tên nhân viên
            txtChucVu.Text = viTri;
            txtTen.Text = tenNV;

            // Tải toàn bộ dữ liệu ban đầu
            LoadData();

            // Đặt placeholder cho ô tìm kiếm
            SetPlaceholder();

            // Thêm danh sách loại hàng vào ComboBox
            foreach (var loai in loaiHangMapping.Keys)
            {
                cbLoaiHang.Items.Add(loai);
            }

            cbLoaiHang.SelectedIndexChanged += cbLoaiHang_SelectedIndexChanged;
        }

        private void LoadData()
        {
            string query = @"
                SELECT DISTINCT SanPham.MaSP, TenSP, DonVi, LoaiHang, HSD, SLHT
                FROM SanPham
                JOIN Chua ON SanPham.MaSP = Chua.MaSP
                JOIN Kho ON Chua.MaLH = Kho.MaLH";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "SanPham");

                    dataGridView1.DataSource = ds.Tables["SanPham"];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetPlaceholder()
        {
            tbTimKiem.Text = "Nhập mã sản phẩm hoặc tên sản phẩm cần tìm";
            tbTimKiem.ForeColor = Color.Gray;

            tbTimKiem.Enter += RemovePlaceholder;
            tbTimKiem.Leave += AddPlaceholder;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Nhập mã sản phẩm hoặc tên sản phẩm cần tìm")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTimKiem.Text))
            {
                tbTimKiem.Text = "Nhập mã sản phẩm hoặc tên sản phẩm cần tìm";
                tbTimKiem.ForeColor = Color.Gray;
            }
        }

        private void cbLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiHang.SelectedItem == null) return;

            string selectedLoaiHang = cbLoaiHang.SelectedItem.ToString();

            if (loaiHangMapping.TryGetValue(selectedLoaiHang, out string maLoaiHang))
            {
                FilterDataByLoaiHang(maLoaiHang);
            }
        }

        private void FilterDataByLoaiHang(string maLoaiHang)
        {
            string query = @"
                SELECT DISTINCT SanPham.MaSP, TenSP, DonVi, LoaiHang, HSD, SLHT
                FROM SanPham
                JOIN Chua ON SanPham.MaSP = Chua.MaSP
                JOIN Kho ON Chua.MaLH = Kho.MaLH
                WHERE LoaiHang = @LoaiHang";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@LoaiHang", maLoaiHang);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "SanPham");

                    dataGridView1.DataSource = ds.Tables["SanPham"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm tìm kiếm sản phẩm theo mã hoặc tên
        private void btTim_Click(object sender, EventArgs e)
        {
            string searchQuery = tbTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchQuery) || searchQuery == "Nhập mã sản phẩm hoặc tên sản phẩm cần tìm")
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên sản phẩm để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                SELECT DISTINCT SanPham.MaSP, TenSP, DonVi, LoaiHang, HSD, SLHT
                FROM SanPham
                JOIN Chua ON SanPham.MaSP = Chua.MaSP
                JOIN Kho ON Chua.MaLH = Kho.MaLH
                WHERE SanPham.MaSP LIKE @SearchQuery OR SanPham.TenSP LIKE @SearchQuery";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "SanPham");

                    dataGridView1.DataSource = ds.Tables["SanPham"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tạm biệt! Hẹn gặp lại lần sau", "Thông báo");
            Environment.Exit(0);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            frmTaoSP taomoi = new frmTaoSP();
            taomoi.ShowDialog(); // Hiển thị form tạo nhà phân phối
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu dòng được chọn là hợp lệ
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột
                string maSP = row.Cells["MaSP"].Value.ToString();
                string tenSP = row.Cells["TenSP"].Value.ToString();
                string donVi = row.Cells["DonVi"].Value.ToString();
                string loaiHang = row.Cells["LoaiHang"].Value.ToString();
                string hsd = row.Cells["HSD"].Value.ToString();

                // Mở form sửa sản phẩm và truyền dữ liệu
                frmSuaSP suaSP = new frmSuaSP(maSP, tenSP, donVi, loaiHang, hsd);

                // Đăng ký sự kiện DataUpdated để tải lại dữ liệu sau khi sửa
                suaSP.DataUpdated += LoadData;

                suaSP.ShowDialog();
            }
        }
        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }
        private void NhaPhanPhoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNPP frmNPP = new frmNPP(viTri,tenNV);
            frmNPP.ShowDialog();
        }

        private void HoaDonNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHDNo frmHDNo = new frmHDNo(viTri, tenNV);
            frmHDNo.ShowDialog();
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
    }
}
