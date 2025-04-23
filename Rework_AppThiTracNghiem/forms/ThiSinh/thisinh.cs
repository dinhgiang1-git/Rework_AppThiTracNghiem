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
using Rework_AppThiTracNghiem.forms.QuanLyDeThi;
using Rework_AppThiTracNghiem.forms.ThiSinh;

namespace Rework_AppThiTracNghiem
{
    public partial class ThiSinh : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maSinhVien = "";
        string g_maBaiThi = "";
        ucBaiThi selectedBaiThi = null;
        public ThiSinh(string tenDangNhap)
        {
            InitializeComponent();
            g_maSinhVien = tenDangNhap;
            LoadThongTin();
            LoadBangDiem();
        }

        private void ThiSinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            login ln = new login();
            ln.Show();
        }

        private void LoadThongTin()
        {
            flowBaiThi.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select MaDeThi, TenDeThi, NgayBatDau, NgayKetThuc, ThoiGianLamBai, TongSoCau  from DETHI join SINHVIEN on SINHVIEN.MaLopHoc = DETHI.MaLop where SINHVIEN.MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string madethi = reader["MaDeThi"].ToString();
                        string tendethi = reader["TenDeThi"].ToString();
                        DateTime NgayBatDau = DateTime.Now;
                        DateTime NgayKetThuc = DateTime.Now;
                        // Xử lý ngày 
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayBatDau")))
                        {
                            NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayKetThuc")))
                        {
                            NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                        }
                        string thoigianlambai = reader["ThoiGianLamBai"].ToString();
                        string tongsocau = reader["TongSoCau"].ToString();

                        ucBaiThi baithi = new ucBaiThi(g_maSinhVien);
                        baithi.Dock = DockStyle.Top;
                        baithi.MaBaiThi = madethi;
                        baithi.TenBaiThi = tendethi;
                        baithi.NgayBatDau = NgayBatDau;
                        baithi.NgayKetThuc = NgayKetThuc;
                        baithi.SoCau = "Số lượng câu hỏi: "+tongsocau + "(câu)";
                        baithi.ThoiLuong = thoigianlambai + " (phút)";

                        baithi.onDeThi_Click += ucDeThi_Click;

                        flowBaiThi.Controls.Add(baithi);
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
        private void ucDeThi_Click(object sender, EventArgs e)
        {
            ucBaiThi bt = sender as ucBaiThi; 
            if (bt == null) return;

            if (selectedBaiThi != null)
            {
                selectedBaiThi.BackColor = SystemColors.Control;
            }

            selectedBaiThi = bt;
            selectedBaiThi.BackColor = Color.LightBlue;
            g_maBaiThi = bt.MaBaiThi;
        }
        private void LoadBangDiem()
        {
            flowBangDiem.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select MaSinhVien, BAITHI_KETQUA.MaDeThi, DETHI.TenDeThi, Diem, ThoiGianNop from BAITHI_KETQUA  join DETHI on DETHI.MaDeThi = BAITHI_KETQUA.MaDeThi where MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    {
                        string madethi = reader["MaDeThi"].ToString();
                        string tendethi = reader["TenDeThi"].ToString();
                        string diem = reader["Diem"].ToString();
                        DateTime thoigiannop = DateTime.Now;

                        // Xử lý ngày 
                        if (!reader.IsDBNull(reader.GetOrdinal("ThoiGianNop")))
                        {
                            thoigiannop = Convert.ToDateTime(reader["ThoiGianNop"]);
                        }
                        BangDiem bangdiem = new BangDiem(g_maSinhVien);
                        bangdiem.Dock = DockStyle.Top;
                        bangdiem.TenBaiThi = tendethi;
                        bangdiem.Diem = "Điểm: " + diem;
                        bangdiem.ThoiGianNopBai = thoigiannop;
                        bangdiem.MaDeThi = madethi;

                        flowBangDiem.Controls.Add(bangdiem);
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
    }
}
