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
    public partial class XemChiTietDeThi : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maDeThi = "";

        public XemChiTietDeThi(string maDeThi)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            dateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            dateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
            Load_ThongTin();
        }

        private void Load_ThongTin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select DETHI.TenDeThi, NGANHANGCAUHOI.TenNganHang, DETHI.TongSoCau, DETHI.SoCauDe, DETHI.SoCauTrungBinh, DETHI.SoCauKho, LOPHOC.TenLopHoc, DETHI.NgayBatDau, DETHI.NgayKetThuc, DETHI.ThoiGianLamBai from DETHI join NGANHANGCAUHOI on NGANHANGCAUHOI.MaNganHang = DETHI.MaNganHang join LOPHOC on LOPHOC.MaLopHoc = DETHI.MaLop where DETHI.MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTenDeThi.Text = reader["TenDeThi"].ToString();              
                        txtNganHangCauHoi.Text = reader["TenNganHang"].ToString();
                        txtSoLuongCauHoi.Text = reader["TongSoCau"].ToString();
                        txtSoLuongCauDe.Text = reader["SoCauDe"].ToString();
                        txtSoLuongCauTrungBinh.Text = reader["SoCauTrungBinh"].ToString();
                        txtSoLuongCauKho.Text = reader["SoCauKho"].ToString();
                        txtLop.Text = reader["TenLopHoc"].ToString();
                        // Xử lý ngày 
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayBatDau")))
                        {
                            dateNgayBatDau.Value = Convert.ToDateTime(reader["NgayBatDau"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayKetThuc")))
                        {
                            dateNgayKetThuc.Value = Convert.ToDateTime(reader["NgayKetThuc"]);
                        }
                        txtThoiGianLamBai.Text = reader["ThoiGianLamBai"].ToString();                        
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
    }
}
