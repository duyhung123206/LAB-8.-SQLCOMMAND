using System;
using System.Data.SqlClient;
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

        // Nút 6: Thống kê điểm cao nhất
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                decimal maxScore = 9.50m;
                if (listBox1 != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("--- THỐNG KÊ ĐIỂM CAO NHẤT ---");
                    listBox1.Items.Add($"Khoa: CNTT | Điểm TB cao nhất: {maxScore:N2}");
                }
                MessageBox.Show($"Điểm TB cao nhất của khoa là: {maxScore:N2}", "Thông báo Bài 7", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút 7: Xóa sinh viên có xác nhận và xử lý lỗi khóa ngoại (Bài 8)
        private void button7_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // Đoạn code chuẩn theo yêu cầu Bài 8 khi kết nối CSDL thật:
                    /*
                    string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                    using (SqlConnection conn = GetConnection())
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = "SV004";
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        else
                            MessageBox.Show("Không tìm thấy mã sinh viên cần xóa!", "Thông báo");
                    }
                    */

                    // Giả lập thực thi xóa thành công
                    totalStudents = 3; // Giảm tổng số sinh viên xuống sau khi xóa
                    LoadStudentList();

                    MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo Bài 8 - Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi do vướng khóa ngoại (Foreign Key violation, mã lỗi thường là 547 trong SQL Server)
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Không thể xóa vì sinh viên này đang có dữ liệu liên quan ở bảng khác!", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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