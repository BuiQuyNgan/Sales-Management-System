using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace nhom8
{
    public partial class frmTaoNPP : Form
    {
        // Chuỗi kết nối đến database
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Tạo static event để thông báo khi dữ liệu đã được thêm
        public static event Action DataUpdated;

        public frmTaoNPP()
        {
            InitializeComponent();
        }

        private void frmTaoNPP_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "SELECT dbo.TaoMa('NhaPhanPhoi')";

                SqlCommand cmd = new SqlCommand(sQuery, con);
                object result = cmd.ExecuteScalar();

                tbMaNPP.Text = result?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btTao_Click(object sender, EventArgs e)
        {
            string tenNPP = tbTen.Text.Trim();
            string diaChi = tbDC.Text.Trim();
            string soDienThoai = tbSDT.Text.Trim();

            // Kiểm tra nếu các TextBox rỗng
            if (string.IsNullOrEmpty(tenNPP) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập đúng 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ThemNPP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào lệnh gọi thủ tục
                cmd.Parameters.AddWithValue("@tennpp", tenNPP);
                cmd.Parameters.AddWithValue("@sdt_npp", soDienThoai);
                cmd.Parameters.AddWithValue("@dc_npp", diaChi);

                // Lấy thông báo từ thủ tục
                SqlParameter returnMessage = new SqlParameter("@Message", SqlDbType.NVarChar, 200);
                returnMessage.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(returnMessage);

                // Thực thi stored procedure
                cmd.ExecuteNonQuery();

                // Hiển thị thông báo từ thủ tục
                string message = returnMessage.Value.ToString();
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kích hoạt sự kiện DataUpdated để thông báo cho các form khác
                DataUpdated?.Invoke();

                this.Close(); // Đóng form sau khi thêm thành công
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}