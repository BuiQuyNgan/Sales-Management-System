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

namespace QuenMk
{
    public partial class frmDangNhap : Form
    {
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pnĐN_Resize(object sender, EventArgs e)
        {
            pnĐN.Left = (this.ClientSize.Width - pnĐN.Width) / 2;
            pnĐN.Top = (this.ClientSize.Height - pnĐN.Height) / 2;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                txtTDN.Text = "Nhập tên đăng nhập";
                txtTDN.ForeColor = Color.Gray;
                txtMK.Text = "Nhập mật khẩu";
                txtMK.ForeColor = Color.Gray;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối");
            }
            
        }

        private void txtTDN_Enter(object sender, EventArgs e)
        {
            if (txtTDN.Text == "Nhập tên đăng nhập") // Placeholder
            {
                txtTDN.Text = ""; // Xóa placeholder
                txtTDN.ForeColor = Color.Black; // Đặt màu chữ thành đen
                txtTDN.Font = new Font(txtTDN.Font, FontStyle.Regular); // Đặt kiểu chữ là Regular
            }
        }

        private void txtTDN_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTDN.Text)) // TextBox trống
            {
                txtTDN.Text = "Nhập tên đăng nhập"; // Hiển thị lại placeholder
                txtTDN.ForeColor = Color.Gray; // Đặt màu chữ là xám
                txtTDN.Font = new Font(txtTDN.Font, FontStyle.Italic); // Đặt placeholder là kiểu chữ Italic (tùy chọn)
            }
        }

        private void txtMK_Enter(object sender, EventArgs e)
        {
            if (txtMK.Text == "Nhập mật khẩu") // Placeholder
            {
                txtMK.Text = ""; // Xóa placeholder
                txtMK.ForeColor = Color.Black; // Đặt màu chữ thành đen
                txtMK.Font = new Font(txtMK.Font, FontStyle.Regular); // Đặt kiểu chữ là Regular
            }
            txtMK.PasswordChar = '*';
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text)) // TextBox trống
            {
                txtMK.Text = "Nhập mật khẩu"; // Hiển thị lại placeholder
                txtMK.ForeColor = Color.Gray; // Đặt màu chữ là xám
                txtMK.Font = new Font(txtMK.Font, FontStyle.Italic); // Đặt placeholder là kiểu chữ Italic (tùy chọn)
            }
        }



        private void btĐN_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTDN.Text;
            string matKhau = txtMK.Text;

            if(string.IsNullOrEmpty(tenDangNhap) || tenDangNhap == "Nhập tên đăng nhập" ||
        string.IsNullOrEmpty(matKhau) || matKhau == "Nhập mật khẩu")
    {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sCon))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spDangNhap", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu vào
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        // Thêm tham số đầu ra
                        SqlParameter returnMessage = new SqlParameter("@ReturnMessage", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(returnMessage);

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();

                        // Lấy giá trị từ tham số đầu ra
                        string result = returnMessage.Value.ToString();

                        // Kiểm tra kết quả
                        if (result.Contains("Đăng nhập thành công"))
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Chuyển sang form khác
                            this.Hide();
                            
                        }
                        else
                        {
                            MessageBox.Show(result, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lbQMK_Click(object sender, EventArgs e)
        {

            this.Hide();
            // Mở form Quên mật khẩu
            frmQuenMatKhau forgotPasswordForm = new frmQuenMatKhau();
            forgotPasswordForm.Show();
        }
    }
}
