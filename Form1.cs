using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab8_SqlCommand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hàm tạo kết nối tới SQL Server với tên server chính xác của bạn
        private SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=LAPTOP-B7GDBO46;Initial Catalog=QLSinhVien;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        // Hàm đếm số sinh viên sử dụng ExecuteScalar
        private int CountStudents()
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SinhVien", conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // Sự kiện khi bấm vào button1
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int total = CountStudents();
                label1.Text = $"Tổng số sinh viên: {total}";

                // Hiển thị hộp thoại thông báo thành công
                MessageBox.Show($"Đếm thành công! Tổng số sinh viên là: {total}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}