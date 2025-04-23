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

namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    public partial class XemLaiBaiKiemTra : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maDeThi = "";
        string g_maSinhVien = "";
        public XemLaiBaiKiemTra(string maDeThi, string maSinhVien)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            g_maSinhVien = maSinhVien;

            LoadThongTin();
            LoadCauHoi();
        }
        private void LoadThongTin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM SINHVIEN WHERE MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string masinhvien = reader["MaSinhVien"].ToString();
                        string hoten = reader["HoTen"].ToString();

                        labelHoTen.Text = "Họ tên: " + hoten;
                        labelMaSinhVien.Text = "Mã: " + masinhvien;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM DETHI WHERE MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string tendethi = reader["TenDeThi"].ToString();
                        labelTenBaiThi.Text = "Bài thi: " + tendethi;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin bài thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCauHoi()
        {
            flowCauHoi.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT CAUHOI.MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, BAITHI.DapAnChon
                        FROM CAUHOI 
                        JOIN BAITHI ON BAITHI.MaCauHoi = CAUHOI.MaCauHoi 
                        WHERE BAITHI.MaSinhVien = @MaSinhVien AND BAITHI.MaDeThi = @MaDeThi";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    if (!int.TryParse(g_maDeThi, out int maDeThi))
                    {
                        throw new Exception("Mã đề thi không hợp lệ!");
                    }
                    cmd.Parameters.AddWithValue("@MaDeThi", maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int index = 0;
                    while (reader.Read())
                    {
                        string macauhoi = reader["MaCauHoi"].ToString();
                        string noidungcauhoi = reader["NoiDungCauHoi"].ToString();
                        string noidungdapanA = reader["DapAnA"].ToString();
                        string noidungdapanB = reader["DapAnB"].ToString();
                        string noidungdapanC = reader["DapAnC"].ToString();
                        string noidungdapanD = reader["DapAnD"].ToString();
                        string dapAnChon = reader["DapAnChon"]?.ToString();
                        string dapAnDung = reader["DapAnDung"].ToString();

                        index++;
                        ucCauHoi cauHoi = new ucCauHoi
                        {
                            MaCauHoi = macauhoi,
                            NoiDungCauHoi = noidungcauhoi,
                            NoiDungDapAnA = noidungdapanA,
                            NoiDungDapAnB = noidungdapanB,
                            NoiDungDapAnC = noidungdapanC,
                            NoiDungDapAnD = noidungdapanD,
                            DapAnChonDaChon = dapAnChon,
                            DapAnDung = dapAnDung,
                            Index = "Câu: " + index,
                            Dock = DockStyle.Top
                        };

                        bool isCorrect = !string.IsNullOrEmpty(dapAnChon) && dapAnChon == dapAnDung;
                        cauHoi.SetAnswerColor(dapAnChon, isCorrect, dapAnDung);

                        //cauHoi.DisableRadioButtons();

                        flowCauHoi.Controls.Add(cauHoi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
