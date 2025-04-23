using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace Rework_AppThiTracNghiem.forms.QuanLyDeThi
{
    public partial class XemChiTietDeThi : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maDeThi = "";
        string g_maGiangVien = "";
        int g_maNganHang = 0;


        public XemChiTietDeThi(string maDeThi)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            dateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            dateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
            Load_ThongTin();
            LoadComboBox_NganHangCauHoi();
            LoadData_DeThi();
            LoadData_NganHang();

        }

        private void Load_ThongTin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select DETHI.TenDeThi, NGANHANGCAUHOI.TenNganHang, DETHI.TongSoCau, LOPHOC.TenLopHoc, DETHI.NgayBatDau, DETHI.NgayKetThuc, DETHI.ThoiGianLamBai, DETHI.MaGiangVien from DETHI join NGANHANGCAUHOI on NGANHANGCAUHOI.MaNganHang = DETHI.MaNganHang join LOPHOC on LOPHOC.MaLopHoc = DETHI.MaLop where DETHI.MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTenDeThi.Text = reader["TenDeThi"].ToString();

                        txtSoLuongCauHoi.Text = reader["TongSoCau"].ToString();

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
                        g_maGiangVien = reader["MaGiangVien"].ToString();
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

                    cbNganHangCauHoi.SelectedIndexChanged -= cbNganHangCauHoi_SelectedIndexChanged; // tránh lặp sự kiện

                    cbNganHangCauHoi.DataSource = dt;
                    cbNganHangCauHoi.DisplayMember = "TenNganHang";
                    cbNganHangCauHoi.ValueMember = "MaNganHang";

                    cbNganHangCauHoi.SelectedIndexChanged += cbNganHangCauHoi_SelectedIndexChanged;


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                    g_maNganHang = (int)cbNganHangCauHoi.SelectedValue;
                }
            }
        }

        private void LoadData_NganHang()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaCauHoi, NoiDungCauHoi, DangCauHoi from CAUHOI where MaNganHang = @MaNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataNganHang.DataSource = dt;
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
        private void LoadData_DeThi()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select CAUHOI.MaCauHoi, NoiDungCauHoi, DangCauHoi from CAUHOI join CT_DETHI on CT_DETHI.MaCauHoi = CAUHOI.MaCauHoi where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataDeThi.DataSource = dt;
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

        private void cbNganHangCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_maNganHang = (int)cbNganHangCauHoi.SelectedValue;
            LoadData_NganHang();
        }

        string g_maCauHoi_dataDeThi = "";
        private void dataDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataDeThi.Rows[e.RowIndex];
                g_maCauHoi_dataDeThi = row.Cells["MaCauHoi"].Value.ToString();
            }
        }
        string g_maCauHoi_dataNganHang = "";
        private void dataNganHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataNganHang.Rows[e.RowIndex];
                g_maCauHoi_dataNganHang = row.Cells["MaCauHoi"].Value.ToString();
            }
        }

        private bool checkDuplicateMaCauHoi(string strMakhoa)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select count(*) from CT_DETHI where MaCauHoi = @MaCauHoi and MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCauHoi", strMakhoa);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("DataBase Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void updateTongSoCau()
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select count(*) from CT_DETHI where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    count = (int)cmd.ExecuteScalar();
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
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Update DETHI set TongSoCau = @TongSoCau where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TongSoCau", count);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.ExecuteNonQuery();
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

        private void ctdtbtnChen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maCauHoi_dataNganHang))
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi từ Ngân Hàng để chuyển vào đề thi trước!");
                return;
            }
            if (checkDuplicateMaCauHoi(g_maCauHoi_dataNganHang))
            {
                MessageBox.Show("Câu hỏi này đã có trong đề thi!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into CT_DETHI (MaDeThi, MaCauHoi) values (@MaDeThi, @MaCauHoi)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.Parameters.AddWithValue("@MaCauHoi", g_maCauHoi_dataNganHang);
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        LoadData_DeThi();
                        updateTongSoCau();
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

        private void ctdtbtnXoa_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(g_maCauHoi_dataDeThi))
            {
                MessageBox.Show("Vui lòng chòn một câu hỏi muốn xoá khỏi đề thi trước!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete CT_DETHI where MaCauHoi = @MaCauHoi and MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCauHoi", g_maCauHoi_dataDeThi);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0) 
                    {
                        LoadData_DeThi();
                        updateTongSoCau();
                    }
                }
                catch (Exception ex) 
                {
                    throw new Exception ("Error " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
