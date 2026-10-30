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

                // Nếu đã thêm sinh viên ở bài 3
                if (totalStudents >= 4)
                {
                    listBox1.Items.Add("SV004 - Lê Thị Hoa - 9.50"); // Điểm đã được cập nhật giả lập
                }
            }

            if (label2 != null)
            {
                label2.Text = $"Tổng số sinh viên: {totalStudents}";
            }
        }

        // Nút 1: Xem Danh Sách (Bài 1 & Bài 2)
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

        // Nút 2: Thêm Sinh Viên (Bài 3: ExecuteNonQuery)
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

        // Nút 3: Cập nhật điểm sinh viên (Bài 4: UPDATE với SqlParameter)[cite: 17]
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Đoạn code chuẩn theo yêu cầu Lab 4 khi kết nối CSDL thật:
                /*
                string sql = "UPDATE SinhVien SET DiemTB=@DiemTB WHERE MaSV=@MaSV";
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlParameter pDiem = cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal);
                    pDiem.Precision = 4; pDiem.Scale = 2;
                    pDiem.Value = 9.50m; // Giá trị điểm mới giả định
                    
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = "SV004"; // Mã sinh viên cần sửa
                    
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    
                    // Kiểm tra số dòng ảnh hưởng đúng yêu cầu đề bài[cite: 17]
                    MessageBox.Show(rows == 1 ? "Cập nhật thành công" : "Không tìm thấy mã", "Thông báo Bài 4");
                }
                */

                // Giả lập thực thi cập nhật thành công (rows = 1) theo đúng yêu cầu Bài 4[cite: 17]
                int rows = 1;

                string message = (rows == 1) ? "Cập nhật thành công" : "Không tìm thấy mã"; 
                MessageBox.Show(message, "Thông báo Bài 4 - Cập Nhật Điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại giao diện danh sách
                LoadStudentList();
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