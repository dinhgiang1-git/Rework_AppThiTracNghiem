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

namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop
{
    public partial class qllThemThanhVien : Form
    {
        string g_maLop = "";
        
        public qllThemThanhVien(string maLop)
        {
            InitializeComponent();
            g_maLop = maLop;
            thanhviencbGioiTinh.SelectedIndex = 0;
            thanhvientxtMaLop.Enabled = false;
            thanhvientxtMaLop.Text = maLop;
        }

        private void thanhvienbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkTrungMaThanhVien(string maSinhVien)
        {
            try
            {
                string query = "Select count(*) from SINHVIEN where MaSinhVien = @MaSinhVien";
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                    new SqlParameter("@MaSinhVien", maSinhVien)));
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void add()
        {
            string maThanhVien = thanhvientxtMaThanhVien.Text.Trim().ToUpper();
            string hoTen = thanhvientxtHoTen.Text;
            string gioiTinh = thanhviencbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = thanhviendateNgaySinh.Value;
            string queQuan = thanhvientxtQueQuan.Text;
            DateTime createAt = DateTime.Now;

            //Validate           
            if (string.IsNullOrEmpty(maThanhVien))
            {
                MessageBox.Show("Vui lòng nhập mã tên thành viên!");
                return;
            }
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập tên thành viên!");
                return;
            }
            if (checkTrungMaThanhVien(maThanhVien))
            {
                MessageBox.Show("Mã thành viên đã bị trùng!. Vui lòng nhập mã khác!");
                return;
            }

            try
            {
                string query = @"Insert into SINHVIEN
                               (MaSinhVien, HoTen, GioiTinh, NgaySinh, QueQuan, MatKhau, MaLopHoc, CreateAt) 
                               values 
                               (@MaSinhVien, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @MatKhau, @MaLopHoc, @CreateAt)";

                int rowAffected = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaSinhVien", maThanhVien),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@NgaySinh", ngaySinh),
                    new SqlParameter("@QueQuan", queQuan),
                    new SqlParameter("@MatKhau", "123"),
                    new SqlParameter("@MaLopHoc", g_maLop),
                    new SqlParameter("@CreateAt", createAt));

                if (rowAffected > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void thanhvienbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
        }

        private void thanhvienbtnThem_Click(object sender, EventArgs e)
        {
            add();
            thanhvientxtMaThanhVien.Text = "";
            thanhvientxtHoTen.Text = "";
            thanhviencbGioiTinh.SelectedIndex = 0;
            thanhviendateNgaySinh.Value = DateTime.Now;
            thanhvientxtQueQuan.Text = "";
            Close();
        }
    }
}
