using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace nhom8
{
    public partial class frmHDNo : Form
    {
        private string viTri;
        private string tenNV;
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frmHDNo(string viTri, string tenNV)
        {
            InitializeComponent();
            this.viTri = viTri;
            this.tenNV = tenNV;

            // Gán giá trị vào các TextBox hoặc Label nếu cần thiết
            txtChucVu.Text = viTri;
            tbTenNV.Text = tenNV;
        }

        private void frmHDNo_Load(object sender, EventArgs e)
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
                string sQuery = "select * from HDNoNPP"; // Giữ nguyên hoặc thay đổi truy vấn nếu cần
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "HoaDonNo");

                dataGridView1.DataSource = ds.Tables["HoaDonNo"];
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
            tbTimKiem.Text = "Nhập mã đơn nợ cần tìm";
            tbTimKiem.ForeColor = System.Drawing.Color.Gray;

            tbTimKiem.Enter += RemovePlaceholder;
            tbTimKiem.Leave += AddPlaceholder;
        }

        // Khi ô tìm kiếm được focus, xóa placeholder
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Nhập mã đơn nợ cần tìm")
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
                tbTimKiem.Text = "Nhập mã đơn nợ cần tìm";
                tbTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // Sự kiện Click vào nút tìm kiếm
        private void btTim_Click(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();

            // Kiểm tra nếu không có từ khóa tìm kiếm
            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập mã đơn nợ cần tìm")
            {
                MessageBox.Show("Vui lòng nhập mã đơn nợ cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "select * from HDNoNPP"; // Giữ nguyên truy vấn hoặc thay đổi nếu cần

                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "HoaDonNo");

                // Lọc dữ liệu theo mã dự nợ
                DataTable dt = ds.Tables["HoaDonNo"];
                DataView dv = new DataView(dt);

                // Điều kiện tìm kiếm theo Mã Dự Nợ (MaDNo)
                dv.RowFilter = string.Format("MaDNo LIKE '%{0}%'", keyword);

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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe ThongKe = new frmThongKe();
            ThongKe.ShowDialog();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string maDNo = row.Cells["MaDNo"].Value.ToString();
                string hgd = row.Cells["HGD"].Value.ToString();
                string sttt = row.Cells["STTT"].Value.ToString();
                string ttgd = row.Cells["TTGD"].Value.ToString();

                if (ttgd == "Hoàn thành")
                {
                    MessageBox.Show("Hóa đơn nợ này đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Truyền dữ liệu sang form frmSuaHDNo qua constructor
                    frmSuaHDNo frmSua = new frmSuaHDNo(maDNo, hgd, sttt, ttgd);
                    frmSua.ShowDialog();

                    // Sau khi form frmSuaHDNo đóng, gọi lại LoadData để làm mới DataGridView
                    LoadData();
                }
            }
        }
        private void frmHDNo_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Tạm biệt! Hẹn gặp lại lần sau", "Thông báo");
            Environment.Exit(0);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void NhaPhanPhoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNPP frmNPP = new frmNPP(viTri, tenNV);
            frmNPP.ShowDialog();
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
