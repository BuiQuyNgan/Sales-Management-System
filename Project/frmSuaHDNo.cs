using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace nhom8
{
    public partial class frmSuaHDNo : Form
    {
        private string maDNo;

        public frmSuaHDNo(string maDNo, string hgd, string sttt, string ttgd)
        {
            InitializeComponent();

            this.maDNo = maDNo;

            // Gán dữ liệu từ frmHDNo vào các control trong form này
            tbMaHDNo.Text = maDNo;
            dateTimePicker1.Value = DateTime.Parse(hgd);
            tbSTTT.Text = sttt;
            tbTTGD.Text = ttgd;
        }

        // Sửa hóa đơn nợ
        private void btSuaHDNo_Click(object sender, EventArgs e)
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    con.Open();

                    // Lấy giá trị từ các control
                    string hgd = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Đảm bảo định dạng "yyyy-MM-dd" cho cột HGD kiểu date
                    float sttt;
                    bool isValidSTTT = float.TryParse(tbSTTT.Text.Trim(), out sttt); // Kiểm tra và chuyển giá trị STTT sang kiểu float

                    // Nếu STTT không hợp lệ, thông báo lỗi
                    if (!isValidSTTT)
                    {
                        MessageBox.Show("Số tiền chưa hoàn tất (STTT) phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy giá trị TongTienNH từ bảng Nhap
                    float tongTienNH = 0;
                    string queryTongTien = "SELECT TongTienNH FROM Nhap WHERE MaDNo = @MaDNo";
                    using (SqlCommand cmdTongTien = new SqlCommand(queryTongTien, con))
                    {
                        cmdTongTien.Parameters.AddWithValue("@MaDNo", maDNo);
                        object result = cmdTongTien.ExecuteScalar();
                        if (result != null)
                        {
                            tongTienNH = Convert.ToSingle(result);
                        }
                    }

                    // Kiểm tra điều kiện STTT phải bé hơn TongTienNH
                    if (sttt >= tongTienNH)
                    {
                        MessageBox.Show("Số tiền chưa hoàn tất (STTT) phải nhỏ hơn tổng tiền nhập (TongTienNH).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cập nhật hóa đơn nợ
                    string queryUpdate = "UPDATE HDNoNPP SET HGD = @HGD, STTT = @STTT WHERE MaDNo = @MaDNo";

                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con))
                    {
                        // Gán tham số cho câu lệnh update
                        cmdUpdate.Parameters.AddWithValue("@HGD", hgd); // Gán giá trị cho HGD
                        cmdUpdate.Parameters.AddWithValue("@STTT", sttt); // Gán STTT dưới dạng float
                        cmdUpdate.Parameters.AddWithValue("@MaDNo", maDNo); // Gán MaDNo cho điều kiện update

                        // Thực thi câu lệnh
                        int rowsAffected = cmdUpdate.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật hóa đơn nợ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi cập nhật thành công
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hoàn thành hóa đơn nợ
        private void btHoanThanh_Click(object sender, EventArgs e)
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    con.Open();

                    // Cập nhật trạng thái TTGD thành "Hoàn thành"
                    string query = "UPDATE HDNoNPP SET TTGD = @TTGD WHERE MaDNo = @MaDNo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Gán tham số
                        cmd.Parameters.AddWithValue("@TTGD", "Hoàn thành");
                        cmd.Parameters.AddWithValue("@MaDNo", maDNo);

                        // Thực thi câu lệnh
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hóa đơn nợ đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi hoàn thành
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hoàn thành hóa đơn nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
