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

namespace Rework_AppThiTracNghiem.forms.BangDiem
{
    public partial class bdXemChiTiet : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maDeThi = "";
        string g_maLop = "";
        public bdXemChiTiet(string maDeThi)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            LoadThongTin_Groupbox();
            LoadThongTin_ComboboxLop();
            LoadData_BangDiem();
        }

        private void LoadThongTin_Groupbox()
        {
            //Lấy thông tin cho groubbox
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select MaLopHoc, TenLopHoc from LOPHOC join DETHI on DETHI.MaLop = LOPHOC.MaLopHoc where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bdgroupbox.Text = "Bảng điểm chi tiết lớp: " + reader["TenLopHoc"].ToString();
                        g_maLop = reader["MaLopHoc"].ToString();
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
        private void LoadThongTin_ComboboxLop()
        {
            //Lấy thông tin cho comboboxLop
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select MaDeThi, TenDeThi from DETHI where MaLop = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    bdcbDeThi.DataSource = dt;
                    bdcbDeThi.DisplayMember = "TenDeThi";
                    bdcbDeThi.ValueMember = "MaDeThi";
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
        private void LoadData_BangDiem()
        {
            //Lấy dữ liệu cho datagridviewBangDiem
            //COALESCE(BAITHI_KETQUA.Diem, 0) AS Diem, ORDERBY
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        SINHVIEN.MaSinhVien,
                        SINHVIEN.HoTen,
                        DETHI.TenDeThi,
                        Diem,
                        BAITHI_KETQUA.ThoiGianNop          
                    FROM 
                        SINHVIEN
                        LEFT JOIN BAITHI_KETQUA ON SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien 
                            AND BAITHI_KETQUA.MaDeThi = @MaDeThi
                        LEFT JOIN DETHI ON BAITHI_KETQUA.MaDeThi = DETHI.MaDeThi
                    WHERE 
                        SINHVIEN.MaLopHoc = @MaLopHoc
                        AND (DETHI.MaDeThi = @MaDeThi OR DETHI.MaDeThi IS NULL)
                    ORDER BY 
                        SINHVIEN.HoTen ASC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.Parameters.AddWithValue("@MALopHoc", g_maLop);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataBangDiem.DataSource = dt;

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
    }
}
