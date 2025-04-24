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
    public partial class nhchThemNHCH : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maGiangVien = "";
        public nhchThemNHCH(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
        }

        private void nhchbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add()
        {
            //lấy dữ liệu
            string tenNHCH = "Ngân hàng câu hỏi " + nhchtxtTenNganHang.Text;
            DateTime createAt = DateTime.Now;

            //Validate
            if (string.IsNullOrEmpty(tenNHCH))
            {
                MessageBox.Show("Vui lòng nhập tên ngân hàng câu hỏi!");
                return;
            }

            //Thêm
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into NGANHANGCAUHOI(TenNganHang, CreateAt, MaGiangVien) values (@TenNganHang, @CreateAt, @MaGiangVien)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenNganHang", tenNHCH);
                    cmd.Parameters.AddWithValue("@CreateAt", createAt);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);

                    int rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!");
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
        private void nhchbtnThem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void nhchbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
            this.Close();
        }

        private void nhchtxtTenNganHang_TextChanged(object sender, EventArgs e)
        {
            idk.Text = "Ngân hàng câu hỏi môn " + nhchtxtTenNganHang.Text;
        }
    }
}
