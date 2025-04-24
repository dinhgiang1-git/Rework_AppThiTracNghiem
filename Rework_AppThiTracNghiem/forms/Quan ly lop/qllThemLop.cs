using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class qllThemLop : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maGiangVien = "";
        public qllThemLop(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
        }

        private void qllbtnThemHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkTrungMaLop(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select count(*) from LOPHOC where MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", maLop);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
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
        private void add()
        {
            //lấy dữ liệu
            string maLop = qlltxtMaLop.Text.Trim().ToUpper();
            string tenLop = qlltxtTenLop.Text.Trim();
            DateTime createAt = DateTime.Now;

            //Validate
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!");
                return;
            }
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!");
                return;
            }
            if (checkTrungMaLop(maLop))
            {
                MessageBox.Show("Mã lớp đã bị trùng!. Vui lòng nhập mã khác!");
                return;
            }

            //Thêm
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into LOPHOC(MaLopHoc, TenLopHoc, CreateAt, MaGiangVien) values (@MaLopHoc, @TenLopHoc, @CreateAt, @MaGiangVien)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", maLop);
                    cmd.Parameters.AddWithValue("@TenLopHoc", tenLop);
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
        private void qllbtnThem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void qllbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
            this.Close();
        }
    }
}
