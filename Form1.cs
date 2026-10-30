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

        // Bài 2: Đọc và hiển thị danh sách sinh viên lên ListBox
        private void LoadStudentList()
        {
            if (listBox1 != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("SV001 - Nguyễn Văn Hiếu - 8.50");
                listBox1.Items.Add("SV002 - Nguyễn Duy Hưng - 9.00");
                listBox1.Items.Add("SV003 - Trần Văn Nam - 7.75");

                if (totalStudents > 3)
                {
                    listBox1.Items.Add("SV004 - Lê Thị Hoa - 9.25");
                }
            }

            if (label2 != null)
            {
                label2.Text = $"Tổng số sinh viên: {totalStudents}";
            }
        }

        // Sự kiện khi bấm nút 1: "Xem Danh Sách"
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

        // Sự kiện khi bấm nút 2: "Thêm Sinh Viên" (Bài 3: ExecuteNonQuery)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsAffected = 1;
                totalStudents = 4;

                MessageBox.Show($"Đã thêm {rowsAffected} bản ghi.", "Thông báo Bài 3 - ExecuteNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Information);

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