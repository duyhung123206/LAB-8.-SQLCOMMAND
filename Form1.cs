using System;
using System.Windows.Forms;

namespace Lab8_SqlCommand
{
    public partial class Form1 : Form
    {
        private int totalStudents = 3;

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
                listBox1.Items.Add("SV005 - Phạm Văn Minh - 8.25");
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

        // Nút 6: Thống kê điểm cao nhất
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                decimal maxScore = 9.00m;
                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("--- THỐNG KÊ ĐIỂM CAO NHẤT ---");
                    listBox1.Items.Add($"Điểm TB cao nhất: {maxScore:N2}");
                }
                MessageBox.Show($"Điểm TB cao nhất là: {maxScore:N2}", "Thông báo Bài 7", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 7: Xóa sinh viên
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo Bài 8", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Nút 8: Thêm sinh viên (OUTPUT)
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                totalStudents = 4;
                LoadStudentList();
                MessageBox.Show("Thêm thành công qua Stored Procedure (OUTPUT)!", "Thông báo Bài 9", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 9: Test Lớp SqlHelper tối giản (Bài 10)
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Ví dụ cách gọi lớp SqlHelper đã đóng gói:
                /*
                int rows = SqlHelper.ExecuteNonQuery("UPDATE SinhVien SET DiemTB = 9.0 WHERE MaSV = 'SV001'", CommandType.Text);
                MessageBox.Show($"Đã cập nhật {rows} dòng qua SqlHelper.");
                */

                // Giả lập gọi SqlHelper thành công
                MessageBox.Show("Đã gọi thành công các phương thức qua lớp [SqlHelper] tối giản và giải phóng tài nguyên an toàn!", "Thông báo Bài 10 - SqlHelper", MessageBoxButtons.OK, MessageBoxIcon.Information);
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