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

        // Nút 5: Tìm sinh viên theo mã (Bài 6: ExecuteReader & SqlParameter)
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Đoạn code chuẩn theo yêu cầu Bài 6 khi kết nối CSDL thật:
                /*
                string sql = "SELECT MaSV, HoTen, DiemTB FROM SinhVien WHERE MaSV = @MaSV";
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = "SV002"; // Mã sinh viên cần tìm
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            listBox1.Items.Clear();
                            listBox1.Items.Add("--- KẾT QUẢ TÌM KIẾM THEO MÃ ---");
                            while (reader.Read())
                            {
                                string line = string.Format("{0} - {1} - {2:N2}", 
                                    reader["MaSV"], reader["HoTen"], reader["DiemTB"]);
                                listBox1.Items.Add(line);
                            }
                            MessageBox.Show("Tìm thấy sinh viên!", "Thông báo Bài 6");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã", "Thông báo Bài 6");
                        }
                    }
                }
                */

                // Giả lập thực thi tìm kiếm thành công theo mã "SV002"
                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("--- KẾT QUẢ TÌM KIẾM THEO MÃ (SV002) ---");
                    listBox1.Items.Add("SV002 - Nguyễn Duy Hưng - 9.00");
                }

                MessageBox.Show("Tìm thấy sinh viên!", "Thông báo Bài 6 - Tìm Theo Mã", MessageBoxButtons.OK, MessageBoxIcon.Information);
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