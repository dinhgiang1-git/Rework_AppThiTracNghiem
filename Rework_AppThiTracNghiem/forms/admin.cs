﻿using System.Data;
using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.forms;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop.flowLayout;
using Rework_AppThiTracNghiem.forms.Quan_ly_NHCH;
using Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.flowLayout;
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
        ucLop selectedLop = null;
        ucNganHang selectedNHCH = null;
        ucDeThi selectedDeThi = null;
        public admin(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
            LoadThongTin();
            //LoadData_Lop();
            LoadDanhSachLop();
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
        //private void LoadData_Lop()
        //{
        //    using (SqlConnection conn = new SqlConnection(strConn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = @"SELECT 
        //                        LOPHOC.MaLopHoc,
        //                        LOPHOC.TenLopHoc,
        //                        COUNT(SINHVIEN.MaSinhVien) AS SoLuongSinhVien
        //                    FROM 
        //                        LOPHOC
        //                    LEFT JOIN 
        //                        SINHVIEN ON SINHVIEN.MaLopHoc = LOPHOC.MaLopHoc
        //                    WHERE 
        //                        LOPHOC.MaGiangVien = @MaGiangVien
        //                    GROUP BY 
        //                        LOPHOC.MaLopHoc, LOPHOC.TenLopHoc";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            adapter.Fill(dt);

        //            dataLop.DataSource = dt;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        private void LoadDanhSachLop()
        {
            flowLop.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string query = @"
            SELECT LOPHOC.MaLopHoc, LOPHOC.TenLopHoc, COUNT(SINHVIEN.MaSinhVien) AS SoLuongSinhVien
            FROM LOPHOC
            LEFT JOIN SINHVIEN ON SINHVIEN.MaLopHoc = LOPHOC.MaLopHoc
            WHERE LOPHOC.MaGiangVien = @MaGiangVien
            GROUP BY LOPHOC.MaLopHoc, LOPHOC.TenLopHoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenLop = reader["TenLopHoc"].ToString();
                    string maLop = reader["MaLopHoc"].ToString();
                    int soLuongSV = Convert.ToInt32(reader["SoLuongSinhVien"]);

                    // Tạo 1 thẻ UserControl cho mỗi lớp
                    ucLop fl = new ucLop();
                    fl.Dock = DockStyle.Top; // hoặc none nếu muốn flow dạng khối
                    fl.MaLop = maLop;
                    fl.TenLop = tenLop;
                    fl.SiSo = "Sĩ số: " + soLuongSV;
                    fl.Tag = maLop; // để bạn lấy mã khi click

                    fl.OnFlowLopClick += FlowLop_Click;


                    // Thêm vào danh sách
                    flowLop.Controls.Add(fl);
                }
            }
        }
        private void FlowLop_Click(object sender, ucLop fl)
        {
            // Bỏ chọn cái cũ (nếu có)
            if (selectedLop != null)
            {
                selectedLop.BackColor = SystemColors.Control;
            }

            // Tô màu cái mới
            selectedLop = fl;
            selectedLop.BackColor = Color.LightBlue; // hoặc màu bạn thích

            // Cập nhật mã lớp cho các chức năng sửa/xoá
            g_maLop = fl.MaLop;
        }

        private void FlowNHCH_Click(object sender, ucNganHang nh)
        {
            // Bỏ chọn cái cũ (nếu có)
            if (selectedNHCH != null)
            {
                selectedNHCH.BackColor = SystemColors.Control;
            }

            // Tô màu cái mới
            selectedNHCH = nh;
            selectedNHCH.BackColor = Color.LightBlue; // hoặc màu bạn thích

            // Cập nhật mã lớp cho các chức năng sửa/xoá
            g_MaNganHangCauHoi = nh.MaNganHang;
        }

        private void LoadData_NHCH()
        {
            flowNHCH.Controls.Clear();

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
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string manganhang = reader["MaNganHang"].ToString();
                        string tennganhang = reader["TenNganHang"].ToString();
                        string soluongcauhoi = reader["SoLuongCauHoi"].ToString();


                        ucNganHang uc = new ucNganHang();
                        uc.Dock = DockStyle.Top;
                        uc.TenNganHang = tennganhang;
                        uc.MaNganHang = manganhang;
                        uc.SoLuongCauHoi = "Số lượng câu hỏi: " + soluongcauhoi;
                        uc.Tag = manganhang; // để bạn lấy mã khi click

                        uc.OnFlowNHCHClick += FlowNHCH_Click;

                        flowNHCH.Controls.Add(uc);

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

        private void ucDeThi_Click(object sender, ucDeThi dt)
        {
            // Bỏ chọn cái cũ (nếu có)
            if (selectedDeThi != null)
            {
                selectedDeThi.BackColor = SystemColors.Control;
            }

            // Tô màu cái mới
            selectedDeThi = dt;
            selectedDeThi.BackColor = Color.LightBlue; // hoặc màu bạn thích

            // Cập nhật mã lớp cho các chức năng sửa/xoá
            g_maDeThi = dt.MaDeThi;
        }

        private void LoadData_DETHI()
        {
            flowDeThi.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select DETHI.MaDeThi, DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc from DETHI where DETHI.MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
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

                        ucDeThi dethi = new ucDeThi();
                        dethi.Dock = DockStyle.Top;
                        dethi.MaDeThi = madethi;
                        dethi.TenDeThi = tendethi;
                        dethi.NgayBatDau = NgayBatDau;
                        dethi.NgayKetThuc = NgayKetThuc;

                        dethi.onDeThi_Click += ucDeThi_Click;

                        flowDeThi.Controls.Add(dethi);
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

        private void adminqllbtnThemLop_Click(object sender, EventArgs e)
        {
            qllThemLop themLop = new qllThemLop(g_maGiangVien);
            themLop.Show();
        }

        private void adminqllbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachLop();
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

        private void adminbtnLamMoiDeThi_Click(object sender, EventArgs e)
        {
            g_maDeThi = "";
            LoadData_DETHI();
        }

        private void adminbtnXoaDeThi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(g_maDeThi))
            {
                MessageBox.Show("Vui lòng chọn một đề thi để xoá");
                return;
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

        private void nhchbtnXoaNHCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(g_MaNganHangCauHoi))
            {
                MessageBox.Show("Vui lòng chọn một đề thi để xoá");
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá " + g_TenNganHangCauHoi + " ?.", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    string query = "Delete NGANHANGCAUHOI where MaNganHang = @MaNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_MaNganHangCauHoi);
                    adminXoaThanhVien();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Xoá " + g_TenNganHangCauHoi + " thành công!");
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

        private void adminbtnThemDeThi_Click(object sender, EventArgs e)
        {
            ThemDeThi themdethi = new ThemDeThi(g_maGiangVien);
            themdethi.Show();
        }
    }
}
