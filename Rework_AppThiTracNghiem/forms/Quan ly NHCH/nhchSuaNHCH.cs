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

namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH
{
    public partial class nhchSuaNHCH : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maNganHang = "";
        public nhchSuaNHCH(string maNganHang)
        {
            InitializeComponent();
            g_maNganHang = maNganHang;
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select TenNganHang from NGANHANGCAUHOI where MaNganHang = @MaNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        nhchtxtTenNganHang.Text = reader["TenNganHang"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void nhchbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Edit()
        {
            //Lấy dữ liệu
            string tenNganHang = nhchtxtTenNganHang.Text;
            DateTime updateAt = DateTime.Now;

            //Validate
            if (string.IsNullOrEmpty(tenNganHang))
            {
                MessageBox.Show("Vui lòng nhập tên ngân hàng mới!");
                return;
            }

            //Edit
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Update NGANHANGCAUHOI set TenNganHang = @TenNganHang where MaNganHang = @MaNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenNganHang", tenNganHang);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void nhchbtnSua_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void nhchbtnSuaDong_Click(object sender, EventArgs e)
        {
            Edit();
            this.Close();
        }
    }
}
