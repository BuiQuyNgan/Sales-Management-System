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
    public partial class frmTaoSP : Form
    {
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Tạo static event để thông báo khi dữ liệu đã được thêm
        public static event Action DataUpdated;
        public frmTaoSP()
        {
            InitializeComponent();
        }

        private void frmTaoSP_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "SELECT dbo.TaoMa('SanPham')";

                SqlCommand cmd = new SqlCommand(sQuery, con);
                object result = cmd.ExecuteScalar();

                tbMaSP.Text = result?.ToString();
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
            // Lấy dữ liệu từ các TextBox và ComboBox trên form
            string tensp = tbTen.Text.Trim();
            string donvi = cbDonVi.SelectedItem?.ToString();
            string loaihang = cbLoaiHang.SelectedItem?.ToString();
            string hsd = tbHSD.Text.Trim();

            // Kiểm tra các trường hợp nếu có trường dữ liệu chưa nhập
            if (string.IsNullOrWhiteSpace(tensp) || string.IsNullOrWhiteSpace(donvi) ||
                string.IsNullOrWhiteSpace(loaihang) || string.IsNullOrWhiteSpace(hsd))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh gọi thủ tục ThemSP
            using (SqlConnection con = new SqlConnection(sCon))
            {
                try
                {
                    con.Open();

                    // Tạo Command để gọi thủ tục
                    SqlCommand cmd = new SqlCommand("ThemSP", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào thủ tục
                    cmd.Parameters.AddWithValue("@tensp", tensp);
                    cmd.Parameters.AddWithValue("@donvi", donvi);
                    cmd.Parameters.AddWithValue("@loaihang", loaihang);
                    cmd.Parameters.AddWithValue("@hsd", hsd);
                    cmd.Parameters.AddWithValue("@slht", 0);  // Số lượng tồn kho mặc định là 0

                    // Thêm tham số output để nhận thông báo từ thủ tục
                    SqlParameter messageParam = new SqlParameter("@message", SqlDbType.NVarChar, 100)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    // Thực thi thủ tục
                    cmd.ExecuteNonQuery();

                    // Lấy thông báo từ thủ tục
                    string message = messageParam.Value.ToString();

                    // Hiển thị thông báo từ thủ tục
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nếu thủ tục thành công, có thể cập nhật dữ liệu trong form hoặc thực hiện hành động khác.
                    DataUpdated?.Invoke(); // Kích hoạt sự kiện nếu cần thiết.

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gọi thủ tục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
