using System.Data;
using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.forms;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop;
using Rework_AppThiTracNghiem.forms.Quan_ly_NHCH;
using Rework_AppThiTracNghiem.forms.QuanLyDeThi;
namespace Rework_AppThiTracNghiem
{
    public partial class admin : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maGiangVien = "";
        string g_MaNganHangCauHoi = "";
        string g_TenNganHangCauHoi = "";
        string g_maLop = "";
        string g_maDeThi = "";
        string g_tenDeThi = "";
        public admin(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
            LoadThongTin();
            LoadData_Lop();
            LoadData_NHCH();
            LoadData_DETHI();
        }
        private void LoadThongTin()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from GIANGVIEN where MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string hoten = reader["HoTen"].ToString();
                        Console.WriteLine(g_maGiangVien);

                        adminlabelHoTen.Text = hoten;
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
        private void LoadData_Lop()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                LOPHOC.MaLopHoc,
                                LOPHOC.TenLopHoc,
                                COUNT(SINHVIEN.MaSinhVien) AS SoLuongSinhVien
                            FROM 
                                LOPHOC
                            LEFT JOIN 
                                SINHVIEN ON SINHVIEN.MaLopHoc = LOPHOC.MaLopHoc
                            WHERE 
                                LOPHOC.MaGiangVien = @MaGiangVien
                            GROUP BY 
                                LOPHOC.MaLopHoc, LOPHOC.TenLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataLop.DataSource = dt;
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
        private void LoadData_NHCH()
        {

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                        N.MaNganHang,
                        N.TenNganHang,
                        COUNT(C.MaCauHoi) AS SoLuongCauHoi
                    FROM 
                        NGANHANGCAUHOI N
                    LEFT JOIN 
                        CAUHOI C ON C.MaNganHang = N.MaNganHang
                    WHERE 
                        N.MaGiangVien = @MaGiangVien
                    GROUP BY 
                        N.MaNganHang, N.TenNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataNHCH.DataSource = dt;
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

        private void LoadData_DETHI()
        {

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select DETHI.MaDeThi, DETHI.TenDeThi, NGANHANGCAUHOI.TenNganHang, DETHI.NgayBatDau, DETHI.NgayKetThuc from DETHI join NGANHANGCAUHOI on NGANHANGCAUHOI.MaNganHang = DETHI.MaNganHang where DETHI.MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
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

        private void adminqllbtnThemLop_Click(object sender, EventArgs e)
        {
            qllThemLop themLop = new qllThemLop(g_maGiangVien);
            themLop.Show();
        }

        private void adminqllbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData_Lop();
        }

        private void adminqllbtnSuaLop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maLop))
            {
                MessageBox.Show("Vui lòng chọn một lớp để sửa!");
                return;
            }
            qllSuaLop sualop = new qllSuaLop(g_maLop);
            sualop.Show();
        }

        private void dataLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataLop.Rows[e.RowIndex];
                g_maLop = row.Cells["MaLopHoc"].Value.ToString();

            }
        }
        private void adminXoaThanhVien()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete SINHVIEN where MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
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
        private void adminqllbtnXoaLop_Click(object sender, EventArgs e)
        {
            //Validate
            if (string.IsNullOrEmpty(g_maLop))
            {
                MessageBox.Show("Vui lòng chọn một lớp để xoá");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá " + g_maLop + " ?. Nếu có sẽ xoá cả thành viên của lớp này.", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            //Xoá
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete LOPHOC where MaLopHoc = @MaLophoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    adminXoaThanhVien();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Xoá lớp " + g_maLop + " thành công!");
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
        private void adminqllbtnXemChiTiet_Click(object sender, EventArgs e)
        {
            qllXemChiTiet xemchitiet = new qllXemChiTiet(g_maLop);
            xemchitiet.Show();
        }

        private void nhchbtnThemNHCH_Click(object sender, EventArgs e)
        {
            nhchThemNHCH nhch = new nhchThemNHCH(g_maGiangVien);
            nhch.Show();
        }

        private void nhchbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData_NHCH();
        }

        private void nhchbtnXemChiTiet_Click(object sender, EventArgs e)
        {
            nhchXemChiTiet xemchitiet = new nhchXemChiTiet(g_MaNganHangCauHoi, g_TenNganHangCauHoi);
            xemchitiet.Show();
        }

        private void dataNHCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataNHCH.Rows[e.RowIndex];
                g_MaNganHangCauHoi = row.Cells["MaNganHang"].Value.ToString();
                g_TenNganHangCauHoi = row.Cells["TenNganHang"].Value.ToString();

            }
        }

        private void nhchbtnSuaNHCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_MaNganHangCauHoi))
            {
                MessageBox.Show("Vui lòng chọn một Ngân hàng câu hỏi để sửa!");
                return;
            }
            nhchSuaNHCH suanhch = new nhchSuaNHCH(g_MaNganHangCauHoi);
            suanhch.Show();
        }

        private void adminbtnThemDeThi_Click(object sender, EventArgs e)
        {
            ThemDeThi themdethi = new ThemDeThi(g_maGiangVien);
            themdethi.Show();
        }

        private void adminbtnSuaDeThi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(g_maDeThi))
            {
                MessageBox.Show("Vui lòng chọn một đề thi để sửa");
                return;
            }
            SuaDeThi suadethi = new SuaDeThi(g_maDeThi, g_maGiangVien);
            suadethi.Show();
        }

        private void dataDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataDeThi.Rows[e.RowIndex];
                g_maDeThi = row.Cells["MaDeThi"].Value.ToString();
                g_tenDeThi = row.Cells["TenDeThi"].Value.ToString();

            }
        }

        private void adminbtnLamMoiDeThi_Click(object sender, EventArgs e)
        {
            LoadData_DETHI();
        }

        private void adminbtnXoaDeThi_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(g_maDeThi))
            {
                MessageBox.Show("Vui lòng chọn một đề thi để xoá");
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá " + g_tenDeThi + " ?.", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            //Xoá
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete DETHI where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    adminXoaThanhVien();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Xoá " + g_tenDeThi + " thành công!");
                        LoadData_DETHI();
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
    }
}
