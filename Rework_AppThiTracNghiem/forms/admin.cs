using System.Data;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.forms;
using Rework_AppThiTracNghiem.forms.BangDiem;
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
        string g_maLopHoc = "";
        string g_maDeThi = "";
        string g_tenDeThi = "";
        string g_matKhau = "";
        ucLop selectedLop = null;
        ucNganHang selectedNHCH = null;
        ucDeThi selectedDeThi = null;
        ucbdDETHI selectedBANGDIEM = null;
        public admin(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
            LoadThongTin();
            //LoadData_Lop();
            LoadDanhSachLop();
            LoadData_NHCH();
            LoadData_DETHI();
            LoadCB_Lop();
            LoadThongTinTaiKhoan();
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

        //Lớp
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
            selectedLop.BackColor = System.Drawing.Color.LightBlue; // hoặc màu bạn thích

            // Cập nhật mã lớp cho các chức năng sửa/xoá
            g_maLop = fl.MaLop;
        }
        private void qllbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachLop();
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
        private void qllbtnXoa_Click(object sender, EventArgs e)
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
        private void qllbtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maLop))
            {
                MessageBox.Show("Vui lòng chọn một lớp để sửa!");
                return;
            }
            qllSuaLop sualop = new qllSuaLop(g_maLop);
            sualop.Show();
        }
        private void adminqllbtnThemLop_Click(object sender, EventArgs e)
        {
            qllThemLop themLop = new qllThemLop(g_maGiangVien);
            themLop.Show();
        }
        private void qllbtnTimKiem_Click(object sender, EventArgs e)
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
                    AND (@TenLopHoc is null or LOPHOC.TenLopHoc like '%' +@TenLopHoc+ '%')
                    GROUP BY LOPHOC.MaLopHoc, LOPHOC.TenLopHoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                if (string.IsNullOrEmpty(qlltxtTimKiem.Text))
                {
                    cmd.Parameters.AddWithValue("@TenLopHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TenLopHoc", qlltxtTimKiem.Text);
                }

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

        //Ngân hàng câu hỏi
        private void FlowNHCH_Click(object sender, ucNganHang nh)
        {
            // Bỏ chọn cái cũ (nếu có)
            if (selectedNHCH != null)
            {
                selectedNHCH.BackColor = SystemColors.Control;
            }

            // Tô màu cái mới
            selectedNHCH = nh;
            selectedNHCH.BackColor = System.Drawing.Color.LightBlue; // hoặc màu bạn thích

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
        private void btnLamMoiNHCH_Click(object sender, EventArgs e)
        {
            LoadData_NHCH();
        }
        private void btnThemNganHangCauHoi_Click(object sender, EventArgs e)
        {
            nhchThemNHCH nhch = new nhchThemNHCH(g_maGiangVien);
            nhch.Show();
        }
        private void btnSuaNHCH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_MaNganHangCauHoi))
            {
                MessageBox.Show("Vui lòng chọn một Ngân hàng câu hỏi để sửa!");
                return;
            }
            nhchSuaNHCH suanhch = new nhchSuaNHCH(g_MaNganHangCauHoi);
            suanhch.Show();
        }
        private void btnXoaNHCH_Click(object sender, EventArgs e)
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
        private void nhchbtnTimKiem_Click(object sender, EventArgs e)
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
                        FROM NGANHANGCAUHOI N
                        LEFT JOIN CAUHOI C ON C.MaNganHang = N.MaNganHang
                        WHERE N.MaGiangVien = @MaGiangVien
                        AND (@TenNganHang is null or N.TenNganHang like '%'+@TenNganHang+'%')
                        GROUP BY N.MaNganHang, N.TenNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    if (string.IsNullOrEmpty(nhchtxtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TenNganHang", nhchtxtTimKiem.Text);
                    }
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
                        uc.Tag = manganhang;

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

        //Đề thi
        private void ucDeThi_Click(object sender, ucDeThi dt)
        {
            // Bỏ chọn cái cũ (nếu có)
            if (selectedDeThi != null)
            {
                selectedDeThi.BackColor = SystemColors.Control;
            }

            // Tô màu cái mới
            selectedDeThi = dt;
            selectedDeThi.BackColor = System.Drawing.Color.LightBlue; // hoặc màu bạn thích

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
        private void dtbtnLamMoi_Click(object sender, EventArgs e)
        {
            g_maDeThi = "";
            LoadData_DETHI();
        }
        private void adminbtnThemDeThi_Click(object sender, EventArgs e)
        {
            ThemDeThi themdethi = new ThemDeThi(g_maGiangVien);
            themdethi.Show();
        }
        private void dtbtnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(g_maDeThi))
            {
                MessageBox.Show("Vui lòng chọn một đề thi để sửa");
                return;
            }
            SuaDeThi suadethi = new SuaDeThi(g_maDeThi, g_maGiangVien);
            suadethi.Show();
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
        private void dtbtnTimKiem_Click(object sender, EventArgs e)
        {
            flowDeThi.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select DETHI.MaDeThi, DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc from DETHI where DETHI.MaGiangVien = @MaGiangVien and (@TenDeThi is null or DETHI.TenDeThi like '%' +@TenDeThi+ '%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    if (string.IsNullOrEmpty(dttxtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@TenDeThi", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TenDeThi", dttxtTimKiem.Text);
                    }
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

        //Bảng Điểm
        private void LoadCB_Lop()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaLopHoc, TenLopHoc from LOPHOC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    bdcbLop.DataSource = dt;
                    bdcbLop.DisplayMember = "TenLopHoc";
                    bdcbLop.ValueMember = "MaLopHoc";
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
        private void LoadData_BangDiem(string maLop)
        {
            flowBangDiem.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"select DETHI.MaDeThi, DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc, count(BAITHI_KETQUA.MaSinhVien) as SoLuongSVLamBai 
                    from DETHI join LOPHOC on DETHI.MaLop = LOPHOC.MaLopHoc 
                    left join BAITHI_KETQUA on DETHI.MaDeThi = BAITHI_KETQUA.MaDeThi
                    where LOPHOC.MaLopHoc = @MaLopHoc         
                    group by DETHI.MaDeThi, DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", maLop);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string madethi = reader["MaDeThi"].ToString();
                        string tendethi = reader["TenDeThi"].ToString();
                        DateTime NgayBatDau = DateTime.Now;
                        DateTime NgayKetThuc = DateTime.Now;
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayBatDau")))
                        {
                            NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayKetThuc")))
                        {
                            NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                        }
                        string soluongsinhvien = reader["SoLuongSVLamBai"].ToString();
                        ucbdDETHI DETHI = new ucbdDETHI();
                        DETHI.Dock = DockStyle.Top;
                        DETHI.MaBaiThi = madethi;
                        DETHI.TenBaiThi = tendethi;
                        DETHI.NgayBatDau = NgayBatDau;
                        DETHI.NgayKetThuc = NgayKetThuc;
                        DETHI.Status = "Còn hạn";
                        DETHI.Soluongsinhviendalam = soluongsinhvien + " SV đã làm.";
                        DETHI.onBANGDIEM_Click += FlowBANGDIEM_Click;
                        flowBangDiem.Controls.Add(DETHI);
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
        private void FlowBANGDIEM_Click(object sender, ucbdDETHI BD)
        {
            // Bỏ chọn cái cũ (nếu có)
            if (selectedBANGDIEM != null)
            {
                selectedBANGDIEM.BackColor = SystemColors.Control;
            }

            // Tô màu cái mới
            selectedBANGDIEM = BD;
            selectedBANGDIEM.BackColor = System.Drawing.Color.LightBlue; // hoặc màu bạn thích

        }
        private void bdcbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData_BangDiem(bdcbLop.SelectedValue.ToString());
            g_maLopHoc = bdcbLop.SelectedValue.ToString();
        }        
        private void bdbtnTimKiem_Click(object sender, EventArgs e)
        {
            flowBangDiem.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"select DETHI.MaDeThi, DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc, count(BAITHI_KETQUA.MaSinhVien) as SoLuongSVLamBai 
                    from DETHI join LOPHOC on DETHI.MaLop = LOPHOC.MaLopHoc 
                    left join BAITHI_KETQUA on DETHI.MaDeThi = BAITHI_KETQUA.MaDeThi
                    where LOPHOC.MaLopHoc = @MaLopHoc 
                    and (@TenDeThi is null or DETHI.TenDeThi like '%'+@TenDeThi+'%')
                    group by DETHI.MaDeThi, DETHI.TenDeThi, DETHI.NgayBatDau, DETHI.NgayKetThuc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLopHoc);
                    if (string.IsNullOrEmpty(bdtxtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@TenDeThi", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TenDeThi", bdtxtTimKiem.Text);
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string madethi = reader["MaDeThi"].ToString();
                        string tendethi = reader["TenDeThi"].ToString();
                        DateTime NgayBatDau = DateTime.Now;
                        DateTime NgayKetThuc = DateTime.Now;
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayBatDau")))
                        {
                            NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("NgayKetThuc")))
                        {
                            NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]);
                        }
                        string soluongsinhvien = reader["SoLuongSVLamBai"].ToString();
                        ucbdDETHI DETHI = new ucbdDETHI();
                        DETHI.Dock = DockStyle.Top;
                        DETHI.MaBaiThi = madethi;
                        DETHI.TenBaiThi = tendethi;
                        DETHI.NgayBatDau = NgayBatDau;
                        DETHI.NgayKetThuc = NgayKetThuc;
                        DETHI.Status = "Còn hạn";
                        DETHI.Soluongsinhviendalam = soluongsinhvien + " SV đã làm.";
                        DETHI.onBANGDIEM_Click += FlowBANGDIEM_Click;
                        flowBangDiem.Controls.Add(DETHI);
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
        private void bdbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData_BangDiem(g_maLopHoc);
        }

        //Thông tin tài khoản
        private void LoadThongTinTaiKhoan()
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
                        tttklabelMaGiangVien.Text = reader["MaGiangVien"].ToString();
                        tttklabelHoTen.Text = reader["HoTen"].ToString();
                        tttklabelGioiTinh.Text = reader["GioiTinh"].ToString();
                        tttklabelQueQuan.Text = reader["QueQuan"].ToString();
                        g_matKhau = reader["MatKhau"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    tttktxtMaGiangVien.Enabled = false;
                    tttktxtMaGiangVien.Text = tttklabelMaGiangVien.Text;
                    tttktxtHoTen.Text = tttklabelHoTen.Text;
                    tttkcbGioiTinh.SelectedItem = tttklabelGioiTinh.Text;
                    tttktxtQueQuan.Text = tttklabelQueQuan.Text;
                }
            }
        }
        private void tttkbtnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            //Lấy thông tin
            string hoTen = tttktxtHoTen.Text;
            string gioiTinh = tttkcbGioiTinh.SelectedItem.ToString();
            string queQuan = tttktxtQueQuan.Text;

            //Validate
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng điền đẩy đủ họ tên để cập nhật!");
                return;
            }
            if (string.IsNullOrWhiteSpace(queQuan))
            {
                MessageBox.Show("Vui lòng điền quê quán để cập nhật!");
                return;
            }

            //Edit
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Update GIANGVIEN set HoTen = @HoTen, GioiTinh = @GioiTinh, QueQuan = @QueQuan where MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@QueQuan", queQuan);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        LoadThongTinTaiKhoan();
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
        private void tttkbtnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            //Lấy thông tin
            string oldPass = tttktxtMatKhauOld.Text;
            string newPass = tttktxtMatKhauNew.Text;
            string newPassR = tttktxtMatKhauNewR.Text;

            //Validate
            if (string.IsNullOrWhiteSpace(oldPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!");
                return;
            }
            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                return;
            }
            if (string.IsNullOrWhiteSpace(newPassR))
            {
                MessageBox.Show("Vui lòng điền lại mật khẩu mới!");
                return;
            }

            if (g_matKhau != oldPass)
            {
                MessageBox.Show("Mật khẩu không đúng!");
                return;
            }
            if (newPassR != newPass)
            {
                MessageBox.Show("Mật khẩu mới được nhập lại không khớp!");
                return;
            }

            //Edit
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Update GIANGVIEN set MatKhau = @MatKhau where MaGiangVien = @MaGiangVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MatKhau", newPass);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công!");
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
    }
}
