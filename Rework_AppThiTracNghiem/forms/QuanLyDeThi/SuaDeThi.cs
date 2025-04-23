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

namespace Rework_AppThiTracNghiem.forms.QuanLyDeThi
{
    public partial class SuaDeThi : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maDeThi = "";
        string g_maGiangVien = "";
        int g_maNganHang;
        string g_maLop = "";
        public SuaDeThi(string maDeThi, string maGiangVien)
        {
            InitializeComponent();
            sdtdateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            sdtdateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
            g_maDeThi = maDeThi;
            g_maGiangVien = maGiangVien;
            LoadComboBox_NganHangCauHoi();
            LoadComboBox_Lop();
            Load_ThongTin();
        }

        private void Load_ThongTin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from DETHI where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        sdttxtTenDeThi.Text = reader["TenDeThi"].ToString();
                        // Gán sau khi combo đã có datasource
                        var maNganHang = reader["MaNganHang"].ToString();
                        var maLop = reader["MaLop"].ToString();

                        // Gán tạm vào biến global
                        g_maNganHang = Convert.ToInt32(maNganHang);

                        sdttxtSoLuongCauHoi.Text = reader["TongSoCau"].ToString();                       
                        sdttxtThoiGianLamBai.Text = reader["ThoiGianLambai"].ToString();
                        sdtdateNgayBatDau.Value = Convert.ToDateTime(reader["NgayBatDau"]);
                        sdtdateNgayKetThuc.Value = Convert.ToDateTime(reader["NgayKetThuc"]);

                        // Lưu lại mã ngân hàng và lớp để gán sau khi combo load xong
                        sdtcbNganHangCauHoi.SelectedValue = g_maNganHang;
                        sdtcbLop.SelectedValue = maLop;

                        // Gọi lại thủ công
                        sdtcbNganHangCauHoi_SelectedIndexChanged(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void sdtcbNganHangCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maNganHang;
            if (!int.TryParse(sdtcbNganHangCauHoi.SelectedValue.ToString(), out maNganHang))
                return;
            g_maNganHang = maNganHang;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM CAUHOI WHERE MaNganHang = @MaNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNganHang", maNganHang);

                    int soLuong = (int)cmd.ExecuteScalar();
                    iiii1.Text = "(" + soLuong + " câu)";
                    iiii1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadComboBox_NganHangCauHoi()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaNganHang, TenNganHang from NGANHANGCAUHOI where MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    sdtcbNganHangCauHoi.DataSource = dt;
                    sdtcbNganHangCauHoi.DisplayMember = "TenNganHang";
                    sdtcbNganHangCauHoi.ValueMember = "MaNganHang";

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
        private void LoadComboBox_Lop()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaLopHoc, TenLopHoc from LOPHOC where MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    sdtcbLop.DataSource = dt.Copy();
                    sdtcbLop.DisplayMember = "TenLopHoc";
                    sdtcbLop.ValueMember = "MaLopHoc";

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

        private void sdtbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void edit()
        {
            //lấy dữ liệu          
            string tendethi = sdttxtTenDeThi.Text;
            int manganhang = int.Parse(sdtcbNganHangCauHoi.SelectedValue.ToString());
            int soluongcauhoi = 0;
            int thoigianlambai = 0;
            DateTime ngaybatdau = sdtdateNgayBatDau.Value;
            DateTime ngayketthuc = sdtdateNgayKetThuc.Value;
            if (!string.IsNullOrWhiteSpace(sdttxtThoiGianLamBai.Text))
            {
                thoigianlambai = int.Parse(sdttxtThoiGianLamBai.Text);
            }
            if (!string.IsNullOrWhiteSpace(sdttxtSoLuongCauHoi.Text))
            {
                soluongcauhoi = int.Parse(sdttxtSoLuongCauHoi.Text);
            }            
            string maLop = sdtcbLop.SelectedValue.ToString();
            DateTime updateat = DateTime.Now;

            //Validate           
            if (string.IsNullOrEmpty(tendethi))
            {
                MessageBox.Show("Vui lòng nhập TÊN ĐỀ THI!");
                return;
            }
            if (string.IsNullOrEmpty(sdttxtSoLuongCauHoi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thành viên!");
                return;
            }

            //Thêm
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Update DETHI set TenDeThi = @TenDeThi, MaNganHang = @MaNganHang, MaLop = @MaLop, TongSoCau = @TongSoCau, ThoiGianLamBai = @ThoiGianLamBai, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, UpdateAt = @UpdateAt where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDeThi", tendethi);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    cmd.Parameters.AddWithValue("@MaLop", g_maLop);
                    cmd.Parameters.AddWithValue("@TongSoCau", soluongcauhoi);        
                    cmd.Parameters.AddWithValue("@ThoiGianLamBai", thoigianlambai);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngaybatdau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ngayketthuc);
                    cmd.Parameters.AddWithValue("@UpdateAt", updateat);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);

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

        private void sdtcbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_maLop = sdtcbLop.SelectedValue.ToString();
        }

        private void sdtbtnThem_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void sdtbtnThemDong_Click(object sender, EventArgs e)
        {
            edit();
            Close();
        }

        private void sdtbtnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
