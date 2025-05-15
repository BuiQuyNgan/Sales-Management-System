using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace nhom8
{
    public partial class frmSuaNV : Form
    {
        private string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private string maNV;

        // Delegate và Event để thông báo khi dữ liệu được sửa thành công
        public delegate void DataUpdatedHandler();
        public event DataUpdatedHandler DataUpdated;

        public frmSuaNV(string maNV, string tenNV, string viTri, string sdt, string mk)
        {
            InitializeComponent();

            // Gán giá trị cho các control
            this.maNV = maNV;

            tbMaNV.Text = maNV;
            tbTen.Text = tenNV;
            cbViTri.SelectedItem = viTri;
            tbSDT.Text = sdt;
            tbMK.Text = mk;
        }

        private void btSua_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SuaNV", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào lệnh gọi thủ tục
                cmd.Parameters.AddWithValue("@manv", maNV);
                cmd.Parameters.AddWithValue("@tennv", tenNV);
                cmd.Parameters.AddWithValue("@sdt_nv", soDienThoai);
                cmd.Parameters.AddWithValue("@vitri", vitri);
                cmd.Parameters.AddWithValue("@matkhau", matkhau);

                // Thêm tham số OUTPUT để nhận thông báo
                SqlParameter returnMessage = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(returnMessage);

                // Thực thi stored procedure
                cmd.ExecuteNonQuery();

                // Hiển thị thông báo từ stored procedure
                string message = returnMessage.Value.ToString();
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kích hoạt sự kiện DataUpdated để thông báo cho các form khác
                DataUpdated?.Invoke();

                this.Close(); // Đóng form sau khi sửa thành công
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