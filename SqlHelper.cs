using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab8_SqlCommand
{
    public static class SqlHelper
    {
        // Chuỗi kết nối mẫu (khi dùng CSDL thật)
        private static string connectionString = @"Data Source=LAPTOP-B7GDBO46;Initial Catalog=QuanLySinhVien;Integrated Security=True";

        // Lấy đối tượng kết nối
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // 1. Đóng gói ExecuteNonQuery (Dùng cho INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 2. Đóng gói ExecuteScalar (Dùng cho các hàm tính toán trả về 1 giá trị đơn như COUNT, MAX)
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // Lưu ý: Đối với ExecuteReader, do cần đọc dữ liệu sau khi đóng kết nối hoặc đọc tuần tự, 
        // thường trả thẳng command hoặc dùng trực tiếp trong using tại Form để tránh lỗi đóng kết nối sớm.
    }
}