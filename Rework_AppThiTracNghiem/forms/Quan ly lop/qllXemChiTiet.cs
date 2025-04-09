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
using Rework_AppThiTracNghiem.forms.Quan_ly_lop;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop.Thanh_vien_lop;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class qllXemChiTiet : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maLop = "";
        string g_maThanhVien = "";
        string g_tenThanhVien = "";
        public qllXemChiTiet(string maLop)
        {
            InitializeComponent();
            g_maLop = maLop;
            qllgroupbox.Text = "Chi tiết lớp " + g_maLop;
            LoadData_ThanhVien();
        }

        private void LoadData_ThanhVien()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaSinhVien, HoTen, GioiTinh, NgaySinh from SINHVIEN where MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataThanhVien.DataSource = dt;
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
        private void qllbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData_ThanhVien();
        }

        private void qllbtnThemThanhVien_Click(object sender, EventArgs e)
        {
            qllThemThanhVien themthanhvien = new qllThemThanhVien(g_maLop);
            themthanhvien.Show();
        }

        private void qllbtnSuaThanhVien_Click(object sender, EventArgs e)
        {
            qllSuaThanhVien suathanhvien = new qllSuaThanhVien(g_maThanhVien, g_maLop);
            suathanhvien.Show();
        }
        private void dataThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataThanhVien.Rows[e.RowIndex];
                g_maThanhVien = row.Cells["MaSinhVien"].Value.ToString();
                g_tenThanhVien = row.Cells["HoTen"].Value.ToString();
            }
        }

        private void qllbtnXoaThanhVien_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(g_maThanhVien))
            {
                MessageBox.Show("Vui lòng chọn một thành viên để xoá!");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá " + g_tenThanhVien + " ?.", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            //Xoá
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete SINHVIEN where MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maThanhVien);
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Xoá " + g_tenThanhVien + " thành công!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
