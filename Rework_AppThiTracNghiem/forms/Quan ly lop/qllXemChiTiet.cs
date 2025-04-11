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
using Rework_AppThiTracNghiem.DataAccess;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop.Thanh_vien_lop;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class qllXemChiTiet : Form
    {
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
            try
            {
                string query = "Select MaSinhVien, HoTen, GioiTinh, NgaySinh from SINHVIEN where MaLopHoc = @MaLopHoc";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new SqlParameter("@MaLopHoc", g_maLop));
                dataThanhVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void dataThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataThanhVien.Rows[e.RowIndex];
                g_maThanhVien = row.Cells["MaSinhVien"].Value.ToString();
                g_tenThanhVien = row.Cells["HoTen"].Value.ToString();
            }
        }

        private void qllbtnSuaThanhVien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maThanhVien))
            {
                MessageBox.Show("Vui lòng chọn một thành viên để sửa!");
                return;
            }
            qllSuaThanhVien suathanhvien = new qllSuaThanhVien(g_maThanhVien, g_maLop);
            suathanhvien.Show();
        }

        private void qllbtnXoaThanhVien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maThanhVien))
            {
                MessageBox.Show("Vui lòng chọn một thành viên để xoá!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xoá " + g_tenThanhVien + " ?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                string query = "Delete SINHVIEN where MaSinhVien = @MaSinhVien";
                int rowAffected = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaSinhVien", g_maThanhVien));

                if (rowAffected > 0)
                {
                    MessageBox.Show("Xoá thành công!");
                    LoadData_ThanhVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
