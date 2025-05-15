using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace nhom8
{
    public partial class frmThongKe : Form
    {
        string sCon = "Data Source=DESKTOP-I9JHVVR\\SQLEXPRESS;Initial Catalog=QLQTKD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm để tải dữ liệu ban đầu
        }

        // Hàm tải dữ liệu ban đầu
        private void LoadData()
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
                string sQuery = "exec InHDNo"; // Giữ nguyên hoặc thay đổi truy vấn nếu cần
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "ThongKeHD");

                dataGridView1.DataSource = ds.Tables["ThongKeHD"];
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
    }
}
