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
    public partial class qllThemThanhVien : Form
    {
        string strConn = DBHelpercs.strConn;
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
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select count(*) from SINHVIEN where MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
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

            //Thêm
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into SINHVIEN(MaSinhVien, HoTen, GioiTinh, NgaySinh, QueQuan, MatKhau, MaLopHoc, CreateAt) values (@MaSinhVien, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @MatKhau, @MaLopHoc, @CreateAt)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", maThanhVien);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@QueQuan", queQuan);
                    cmd.Parameters.AddWithValue("@MatKhau", 1);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    cmd.Parameters.AddWithValue("@CreateAt", createAt);

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
        private void thanhvienbtnThem_Click(object sender, EventArgs e)
        {
            add();
        }
        private void thanhvienbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
            add();
            Close();
        }
    }
}
