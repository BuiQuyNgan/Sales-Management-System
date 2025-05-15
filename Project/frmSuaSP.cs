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
    public partial class frmSuaSP : Form
    {
        public frmSuaSP(string maSP, string tenSP, string donVi, string loaiHang, string hsd)
        {
            InitializeComponent();

            // Gán dữ liệu từ frmSanPham vào các control trong form này
            tbMaSP.Text = maSP;
            tbTen.Text = tenSP;

            cbDonVi.SelectedItem = donVi;

            cbLoaiHang.SelectedItem = loaiHang;

            // Gán giá trị hạn sử dụng
            tbHSD.Text = hsd;
        }

        // Khai báo delegate và event
        public delegate void DataUpdatedHandler();
        public event DataUpdatedHandler DataUpdated;

        private void btSua_Click(object sender, EventArgs e)
        {
            string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // Lấy giá trị từ các control
            string maSP = tbMaSP.Text.Trim();
            string tenSP = tbTen.Text.Trim();
            string donVi = cbDonVi.SelectedItem?.ToString();
            string loaiHang = cbLoaiHang.SelectedItem?.ToString();
            string hsd = tbHSD.Text.Trim();

            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    // Kiểm tra nếu tên sản phẩm đã tồn tại nhưng không phải của sản phẩm hiện tại
                    string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE TenSP = @TenSP AND MaSP != @MaSP";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@TenSP", tenSP);
                        checkCmd.Parameters.AddWithValue("@MaSP", maSP);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Sản phẩm này đã có trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Thực hiện cập nhật dữ liệu
                    string updateQuery = @"
                                            UPDATE SanPham
                                            SET TenSP = @TenSP, DonVi = @DonVi, LoaiHang = @LoaiHang
                                            WHERE MaSP = @MaSP;

                                            UPDATE Kho
                                            SET HSD = @HSD
                                            WHERE MaLH IN (
                                                SELECT Chua.MaLH
                                                FROM Chua
                                                WHERE Chua.MaSP = @MaSP
                                            );";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@TenSP", tenSP);
                        updateCmd.Parameters.AddWithValue("@DonVi", donVi);
                        updateCmd.Parameters.AddWithValue("@LoaiHang", loaiHang);
                        updateCmd.Parameters.AddWithValue("@HSD", hsd);
                        updateCmd.Parameters.AddWithValue("@MaSP", maSP);

                        updateCmd.ExecuteNonQuery();

                        // Gọi sự kiện sau khi cập nhật thành công
                        DataUpdated?.Invoke();

                        MessageBox.Show("Sản phẩm đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form sau khi sửa thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
