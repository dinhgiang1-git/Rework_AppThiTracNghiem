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

namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop.Thanh_vien_lop
{
    public partial class qllSuaThanhVien : Form
    {
        string g_maThanhVien = "";
        string g_maLop = "";
        
        public qllSuaThanhVien(string maThanhVien, string maLop)
        {
            InitializeComponent();
            thanhvientxtMaLop.Enabled = false;
            thanhvientxtMaThanhVien.Enabled = false;
            thanhvientxtMaLop.Text = maLop;
            thanhvientxtMaThanhVien.Text = maThanhVien;
            g_maThanhVien = maThanhVien;
            g_maLop = maLop;
            Load_ThongTin();
        }

        private void thanhvienbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_ThongTin()
        {
            try
            {
                string query = "Select HoTen, GioiTinh, NgaySinh, QueQuan from SINHVIEN where MaSinhVien = @MaSinhVien";
                DataTable result = DatabaseHelper.ExecuteQuery(query,
                    new SqlParameter("@MaSinhVien", g_maThanhVien));

                if (result.Rows.Count > 0)
                {
                    thanhvientxtHoTen.Text = result.Rows[0]["HoTen"].ToString();
                    thanhviencbGioiTinh.SelectedItem = result.Rows[0]["GioiTinh"].ToString();
                    if (!result.Rows[0].IsNull("NgaySinh"))
                    {
                        thanhviendateNgaySinh.Value = Convert.ToDateTime(result.Rows[0]["NgaySinh"]);
                    }
                    thanhvientxtQueQuan.Text = result.Rows[0]["QueQuan"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void thanhvienbtnSuaDong_Click(object sender, EventArgs e)
        {
            string tenThanhVien = thanhvientxtHoTen.Text;
            string gioiTinh = thanhviencbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = thanhviendateNgaySinh.Value;
            string queQuan = thanhvientxtQueQuan.Text;
            DateTime updateAt = DateTime.Now;

            if (string.IsNullOrEmpty(tenThanhVien))
            {
                MessageBox.Show("Vui lòng điền tên thành viên!");
                return;
            }

            try
            {
                string query = @"Update SINHVIEN 
                               set HoTen = @HoTen, 
                                   GioiTinh = @GioiTinh, 
                                   NgaySinh = @NgaySinh, 
                                   QueQuan = @QueQuan, 
                                   UpdateAt = @UpdateAt 
                               where MaSinhVien = @MaSinhVien";

                int rowAffected = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@HoTen", tenThanhVien),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@QueQuan", queQuan),
                    new SqlParameter("@UpdateAt", updateAt),
                    new SqlParameter("@MaSinhVien", g_maThanhVien));

                if (rowAffected > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
