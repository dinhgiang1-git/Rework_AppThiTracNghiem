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

namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop.Thanh_vien_lop
{
    public partial class qllSuaThanhVien : Form
    {
        string g_maThanhVien = "";
        string g_maLop = "";
        string strConn = DBHelpercs.strConn;
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
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select HoTen, GioiTinh, NgaySinh, QueQuan from SINHVIEN where MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maThanhVien);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        thanhvientxtHoTen.Text = reader["HoTen"].ToString();
                        thanhviencbGioiTinh.SelectedItem = reader["GioiTinh"].ToString();
                        // Xử lý ngày sinh
                        if (!reader.IsDBNull(reader.GetOrdinal("NgaySinh")))
                        {
                            thanhviendateNgaySinh.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        }
                        thanhvientxtQueQuan.Text = reader["QueQuan"].ToString();
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

        private void thanhvienbtnSuaDong_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu
            string tenThanhVien = thanhvientxtHoTen.Text;
            string gioiTinh = thanhviencbGioiTinh.SelectedItem.ToString();
            DateTime ngaySinh = thanhviendateNgaySinh.Value;
            string queQuan = thanhvientxtQueQuan.Text;
            DateTime updateAt = DateTime.Now;

            //Validate
            if (string.IsNullOrEmpty(tenThanhVien))
            {
                MessageBox.Show("Vui lòng điền tên thành viên!");
                return;
            }

            //Sửa
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Update SINHVIEN set HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, QueQuan = @QueQuan, UpdateAt = @UpdateAt where MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", tenThanhVien);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@UpdateAt", updateAt);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maThanhVien);

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
