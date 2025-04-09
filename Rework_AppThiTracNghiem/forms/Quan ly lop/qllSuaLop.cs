using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop
{
    public partial class qllSuaLop : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maLop = "";
        public qllSuaLop(string maLop)
        {
            InitializeComponent();
            qlltxtMaLop.Enabled = false;
            g_maLop = maLop;
            LoadData_Thongtin();
        }

        private void LoadData_Thongtin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaLopHoc, TenLopHoc from LOPHOC where MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string malop = reader["MaLopHoc"].ToString();
                        string tenlop = reader["TenLopHoc"].ToString();

                        qlltxtMaLop.Text = malop;
                        qlltxtTenLop.Text = tenlop;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error :" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void qllbtnSuaHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void qllbtnSuaDong_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu
            string tenLop = qlltxtTenLop.Text;
            DateTime updateAt = DateTime.Now;
            
            //Validate
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng điền tên lớp!");
                return;
            }

            //Sửa
            using (SqlConnection conn = new SqlConnection(strConn)) 
            {
                try
                {
                    conn.Open();
                    string query = "Update LOPHOC set TenLopHoc = @TenLopHoc, UpdateAt = @UpdateAt where MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenLopHoc", tenLop);
                    cmd.Parameters.AddWithValue("@UpdateAt", updateAt);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0) 
                    {
                        MessageBox.Show("Sửa thành công!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    this.Close();
                }
            }
        }
    }
}
