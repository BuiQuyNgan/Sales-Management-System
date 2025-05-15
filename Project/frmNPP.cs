using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace nhom8
{
    public partial class frmNPP : Form
    {
        private string viTri;
        private string tenNV;
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frmNPP(string viTri, string tenNV)
        {
            InitializeComponent();
            this.viTri = viTri;
            this.tenNV = tenNV;

            // Gán giá trị vào các TextBox hoặc Label nếu cần thiết
            tbChucVu.Text = viTri;
            tbTenNV.Text = tenNV;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm để tải dữ liệu ban đầu
            SetPlaceholder(); // Đặt placeholder cho ô tìm kiếm
        }

        // Hàm tải dữ liệu ban đầu
        private void LoadData()
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "exec GiaiMaNhaPhanPhoi";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "NhaPhanPhoi");

                dataGridView1.DataSource = ds.Tables["NhaPhanPhoi"];
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

        // Sự kiện Click vào nút tìm kiếm
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
                string sQuery = "exec GiaiMaNhaPhanPhoi"; // Gọi thủ tục để lấy dữ liệu đã giải mã
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "NhaPhanPhoi");

                // Lọc dữ liệu sau khi đã giải mã
                DataTable dt = ds.Tables["NhaPhanPhoi"];
                DataView dv = new DataView(dt);

                // Điều kiện tìm kiếm theo TenNPP hoặc SDT_NPP (đã giải mã)
                dv.RowFilter = string.Format("TenNPP LIKE '%{0}%' OR SDT_NPP LIKE '%{0}%'", keyword);

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

        // Sự kiện khi nhấp vào các mục trong menu
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Xử lý sự kiện nếu cần thiết
        }

        // Sự kiện tạo mới nhà phân phối
        private void btnTaoNPP_Click_1(object sender, EventArgs e)
        {
            frmTaoNPP taomoi = new frmTaoNPP();
            frmTaoNPP.DataUpdated += LoadData;
            taomoi.ShowDialog(); // Hiển thị form tạo nhà phân phối
        }

        // Sự kiện khi form đang đóng
        private void frmNPP_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tạm biệt! Hẹn gặp lại lần sau", "Thông báo");
            Environment.Exit(0 );
        }

        // Sự kiện khi nhấp vào một dòng trong DataGridView để sửa
        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string maNPP = row.Cells["MaNPP"].Value.ToString();
                string ten = row.Cells["TenNPP"].Value.ToString();
                string diaChi = row.Cells["DC_NPP"].Value.ToString();
                string sdt = row.Cells["SDT_NPP"].Value.ToString();

                frmSuaNPP frmSua = new frmSuaNPP(maNPP, ten, diaChi, sdt);
                frmSua.DataUpdated += LoadData;
                frmSua.ShowDialog();
            }
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
