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
    public partial class frmTaoNV : Form
    {
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Tạo static event để thông báo khi dữ liệu đã được thêm
        public static event Action DataUpdated;
        public frmTaoNV()
        {
            InitializeComponent();
        }

        private void frmTaoNV_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "SELECT dbo.TaoMa('NhanVien')";

                SqlCommand cmd = new SqlCommand(sQuery, con);
                object result = cmd.ExecuteScalar();

                tbMaNV.Text = result?.ToString(); // Gán mã nhà phân phối vào TextBox
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
            string tenNV = tbTen.Text.Trim();
            string vitri = cbViTri.SelectedItem?.ToString();
            string matkhau = tbMK.Text.Trim();
            string soDienThoai = tbSDT.Text.Trim();

            // Kiểm tra nếu các TextBox rỗng
            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(matkhau) || string.IsNullOrEmpty(soDienThoai))
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
                SqlCommand cmd = new SqlCommand("ThemNV", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào lệnh gọi thủ tục
                cmd.Parameters.AddWithValue("@tennv", tenNV);
                cmd.Parameters.AddWithValue("@sdt_nv", soDienThoai);
                cmd.Parameters.AddWithValue("@vitri", vitri);
                cmd.Parameters.AddWithValue("@matkhau", matkhau);

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
