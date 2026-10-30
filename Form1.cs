using System;
using System.Windows.Forms;

namespace Lab8_SqlCommand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Giả lập hàm đếm số sinh viên (Bài 1)
        private int CountStudents()
        {
            return 3;
        }

        // Giả lập hàm đọc danh sách sinh viên đổ vào ListBox (Bài 2)
        private void LoadStudentList()
        {
            if (listBox1 != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("SV001 - Nguyễn Văn Hiếu - 8.50");
                listBox1.Items.Add("SV002 - Nguyễn Duy Hưng - 9.00");
                listBox1.Items.Add("SV003 - Trần Văn Nam - 7.75");
            }
        }

        // Sự kiện khi bấm vào nút
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int total = CountStudents();

                // Sử dụng label1 để khớp hoàn toàn với giao diện thiết kế hiện tại
                if (label2 != null)
                {
                    label2.Text = $"Tổng số sinh viên: {total}";
                }

                // Đọc và đổ danh sách vào ListBox
                LoadStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}