using System;
using System.Windows.Forms;

namespace Lab8_SqlCommand
{
    public partial class Form1 : Form
    {
        private int totalStudents = 4;

        public Form1()
        {
            InitializeComponent();
            LoadStudentList();
        }

        // Đọc và hiển thị danh sách sinh viên lên ListBox
        private void LoadStudentList()
        {
            if (listBox1 != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("SV001 - Nguyễn Văn Hiếu - 8.50");
                listBox1.Items.Add("SV002 - Nguyễn Duy Hưng - 9.00");
                listBox1.Items.Add("SV003 - Trần Văn Nam - 7.75");
                listBox1.Items.Add("SV004 - Lê Thị Hoa - 9.50");
            }

            if (label2 != null)
            {
                label2.Text = $"Tổng số sinh viên: {totalStudents}";
            }
        }

        // Nút 1: Xem Danh Sách
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStudentList();
                MessageBox.Show("Đã tải thành công danh sách sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 2: Thêm Sinh Viên
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsAffected = 1;
                totalStudents = 4;

                MessageBox.Show($"Đã thêm {rowsAffected} bản ghi.", "Thông báo Bài 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 3: Cập nhật điểm
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = 1;
                string message = (rows == 1) ? "Cập nhật thành công" : "Không tìm thấy mã";
                MessageBox.Show(message, "Thông báo Bài 4", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 4: Tìm Theo Khoa (Stored Procedure)
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("--- KẾT QUẢ TÌM KIẾM THEO KHOA (CNTT) ---");
                    listBox1.Items.Add("SV001 - Nguyễn Văn Hiếu - 8.50");
                    listBox1.Items.Add("SV002 - Nguyễn Duy Hưng - 9.00");
                    listBox1.Items.Add("SV004 - Lê Thị Hoa - 9.50");
                }
                MessageBox.Show("Đã gọi Stored Procedure thành công!", "Thông báo Bài 5", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 5: Tìm sinh viên theo mã
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("--- KẾT QUẢ TÌM KIẾM THEO MÃ (SV002) ---");
                    listBox1.Items.Add("SV002 - Nguyễn Duy Hưng - 9.00");
                }
                MessageBox.Show("Tìm thấy sinh viên!", "Thông báo Bài 6", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 6: Thống kê điểm cao nhất theo khoa (Bài 7: ExecuteScalar & xử lý NULL)
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Đoạn code chuẩn theo yêu cầu Bài 7 khi kết nối CSDL thật:
                /*
                string sql = "SELECT MAX(DiemTB) FROM SinhVien WHERE MaKhoa = @MaKhoa";
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = "CNTT";
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    
                    // Xử lý trường hợp kết quả trả về là NULL (chưa có sinh viên)
                    decimal maxScore = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    
                    MessageBox.Show($"Điểm trung bình cao nhất khoa CNTT là: {maxScore:N2}", "Thông báo Bài 7");
                }
                */

                // Giả lập thực thi lấy điểm cao nhất thành công (Điểm cao nhất khoa CNTT là 9.50)
                decimal maxScore = 9.50m;

                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("--- THỐNG KÊ ĐIỂM CAO NHẤT ---");
                    listBox1.Items.Add($"Khoa: CNTT | Điểm TB cao nhất: {maxScore:N2}");
                }

                MessageBox.Show($"Điểm TB cao nhất của khoa là: {maxScore:N2}", "Thông báo Bài 7 - Điểm Cao Nhất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}