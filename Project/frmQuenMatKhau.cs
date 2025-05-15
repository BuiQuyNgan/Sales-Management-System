using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuenMk
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void pnQMK_Resize(object sender, EventArgs e)
        {
            pnQMK.Left = (this.ClientSize.Width - pnQMK.Width) / 2;
            pnQMK.Top = (this.ClientSize.Height - pnQMK.Height) / 2;
        }

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            txtMNV.Text = "Nhập mã nhân viên";
            txtMNV.ForeColor = Color.Gray;
            txtSDT.Text = "Nhập số điện thoại";
            txtSDT.ForeColor = Color.Gray;
            txtSDT.PasswordChar = '*';
        }

        private void txtMNV_Enter(object sender, EventArgs e)
        {
            if (txtMNV.Text == "Nhập mã nhân viên") // Placeholder
            {
                txtMNV.Text = ""; // Xóa placeholder
                txtMNV.ForeColor = Color.Black; // Đặt màu chữ thành đen
                txtMNV.Font = new Font(txtMNV.Font, FontStyle.Regular); // Đặt kiểu chữ là Regular
            }
        }

        private void txtMNV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMNV.Text)) // TextBox trống
            {
                txtMNV.Text = "Nhập mã nhân viên"; // Hiển thị lại placeholder
                txtMNV.ForeColor = Color.Gray; // Đặt màu chữ là xám
                txtMNV.Font = new Font(txtMNV.Font, FontStyle.Italic); // Đặt placeholder là kiểu chữ Italic (tùy chọn)
            }
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            if (txtSDT.Text == "Nhập số điện thoại") // Placeholder
            {
                txtSDT.Text = ""; // Xóa placeholder
                txtSDT.ForeColor = Color.Black; // Đặt màu chữ thành đen
                txtSDT.Font = new Font(txtSDT.Font, FontStyle.Regular); // Đặt kiểu chữ là Regular
            }
            txtSDT.PasswordChar = '*';
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text)) // TextBox trống
            {
                txtSDT.Text = "Nhập số điện thoại"; // Hiển thị lại placeholder
                txtSDT.ForeColor = Color.Gray; // Đặt màu chữ là xám
                txtSDT.Font = new Font(txtSDT.Font, FontStyle.Italic); // Đặt placeholder là kiểu chữ Italic (tùy chọn)
            }

        }

        private void btGui_Click(object sender, EventArgs e)
        {
            // Mã hóa số điện thoại: chỉ lộ 2 số cuối
           

            // Hiển thị thông báo
            MessageBox.Show($"Mật khẩu đã được gửi về số điện thoại của bạn!");

            // Đóng form Quên mật khẩu và quay lại form Đăng nhập
            this.Hide();
            frmDangNhap LoginForm = new frmDangNhap();
            LoginForm.Show();
        }   

    }
}
