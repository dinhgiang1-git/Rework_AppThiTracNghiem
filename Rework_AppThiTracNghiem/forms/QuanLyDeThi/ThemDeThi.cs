using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Rework_AppThiTracNghiem.forms.QuanLyDeThi
{
    public partial class ThemDeThi : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maGiangVien = "";
        int g_maNganHang;
        string g_maLop = "";
        public ThemDeThi(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
            LoadComboBox_NganHangCauHoi();
            LoadComboBox_Lop();

            tdtdateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            tdtdateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
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

                    tdtcbNganHangCauHoi.DataSource = dt;
                    tdtcbNganHangCauHoi.DisplayMember = "TenNganHang";
                    tdtcbNganHangCauHoi.ValueMember = "MaNganHang";

                    if (tdtcbNganHangCauHoi.Items.Count > 0)
                    {
                        tdtcbNganHangCauHoi.SelectedIndex = 0; // Gán lại index để đảm bảo SelectedValue đúng
                        tdtcbNganHangCauHoi_SelectedIndexChanged(null, null); // Gọi thủ công
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

                    tdtcbLop.DataSource = dt.Copy();
                    tdtcbLop.DisplayMember = "TenLopHoc";
                    tdtcbLop.ValueMember = "MaLopHoc";
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

        private void add()
        {
            //lấy dữ liệu          
            string tendethi = tdttxtTenDeThi.Text;
            int manganhang = int.Parse(tdtcbNganHangCauHoi.SelectedValue.ToString());
            int soluongcauhoi = 0;
            int thoigianlambai = 0;
            DateTime ngaybatdau = tdtdateNgayBatDau.Value;
            DateTime ngayketthuc = tdtdateNgayKetThuc.Value;
            if (!string.IsNullOrWhiteSpace(tdttxtThoiGianLamBai.Text))
            {
                thoigianlambai = int.Parse(tdttxtThoiGianLamBai.Text);
            }
            if (!string.IsNullOrWhiteSpace(tdttxtSoLuongCauHoi.Text))
            {
                soluongcauhoi = int.Parse(tdttxtSoLuongCauHoi.Text);
            }

            int soluongcauhoide = 0;
            if (!string.IsNullOrWhiteSpace(tdttxtSoLuongCauHoiDe.Text))
            {
                soluongcauhoide = int.Parse(tdttxtSoLuongCauHoiDe.Text);
            }
            int soluongcauhoitrungbinh = 0;
            if (!string.IsNullOrWhiteSpace(tdttxtSoLuongCauHoiTrungBinh.Text))
            {
                soluongcauhoitrungbinh = int.Parse(tdttxtSoLuongCauHoiTrungBinh.Text);
            }
            int soluongcauhoikho = 0;
            if (!string.IsNullOrWhiteSpace(tdttxtSoLuongCauHoiKho.Text))
            {
                soluongcauhoikho = int.Parse(tdttxtSoLuongCauHoiKho.Text);
            }
            if(thoigianlambai == 0) { }
            string maLop = tdtcbLop.SelectedValue.ToString();
            DateTime createAt = DateTime.Now;

            //Validate           
            if (string.IsNullOrEmpty(tendethi))
            {
                MessageBox.Show("Vui lòng nhập TÊN ĐỀ THI!");
                return;
            }
            if (string.IsNullOrEmpty(tdttxtSoLuongCauHoi.Text))
            {
                MessageBox.Show("Vui lòng nhập SỐ LƯỢNG CÂU HỎI CỦA ĐỀ!");
                return;
            }
            if (thoigianlambai == 0) 
            {
                MessageBox.Show("Vui lòng nhập THỜI GIAN LÀM BÀI!");
                return;
            }

            //Thêm
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into DETHI(TenDeThi, MaNganHang, MaGiangVien, MaLop, TongSoCau, SoCauDe, SoCauTrungBinh, SoCauKho, ThoiGianLamBai, NgayBatDau, NgayKetThuc, CreateAt) values (@TenDeThi, @MaNganHang, @MaGiangVien, @MaLop, @TongSoCau, @SoCauDe, @SoCauTrungBinh, @SoCauKho, @ThoiGianLamBai, @NgayBatDau, @NgayKetThuc, @CreateAt)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDeThi", tendethi);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    cmd.Parameters.AddWithValue("@MaLop", g_maLop);
                    cmd.Parameters.AddWithValue("@TongSoCau", soluongcauhoi);
                    cmd.Parameters.AddWithValue("@SoCauDe", soluongcauhoide);
                    cmd.Parameters.AddWithValue("@SoCauTrungBinh", soluongcauhoitrungbinh);
                    cmd.Parameters.AddWithValue("@SoCauKho", soluongcauhoikho);
                    cmd.Parameters.AddWithValue("@ThoiGianLamBai", thoigianlambai);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngaybatdau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ngayketthuc);
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

        private void tdtbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tdtcbNganHangCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string maNganHang = tdtcbNganHangCauHoi.SelectedValue.ToString();

            int maNganHang;
            if (!int.TryParse(tdtcbNganHangCauHoi.SelectedValue.ToString(), out maNganHang))
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
                    iiii.Text = "(" + soLuong + " câu)";
                    iiii.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void tdtbtnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tdtbtnThem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void tdtbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
            this.Close();
        }

        private void tdtcbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_maLop = tdtcbLop.SelectedValue.ToString();
        }
    }
}
