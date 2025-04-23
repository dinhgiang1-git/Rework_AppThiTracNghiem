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
            // Lấy dữ liệu
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

            string maLop = tdtcbLop.SelectedValue.ToString();
            DateTime createAt = DateTime.Now;

            // Validate
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

            // Kiểm tra tổng số lượng câu hỏi nhập vào
            if (soluongcauhoide + soluongcauhoitrungbinh + soluongcauhoikho > soluongcauhoi)
            {
                MessageBox.Show("Tổng số lượng câu dễ, trung bình, khó không được vượt quá tổng số lượng câu hỏi của đề!");
                return;
            }


            int maDeThi;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO DETHI (TenDeThi, MaNganHang, MaGiangVien, MaLop, TongSoCau, ThoiGianLamBai, NgayBatDau, NgayKetThuc, CreateAt)
                        OUTPUT INSERTED.MaDeThi
                        VALUES (@TenDeThi, @MaNganHang, @MaGiangVien, @MaLop, @TongSoCau, @ThoiGianLamBai, @NgayBatDau, @NgayKetThuc, @CreateAt)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDeThi", tendethi);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    cmd.Parameters.AddWithValue("@MaGiangVien", g_maGiangVien);
                    cmd.Parameters.AddWithValue("@MaLop", g_maLop);
                    cmd.Parameters.AddWithValue("@TongSoCau", soluongcauhoi);              
                    cmd.Parameters.AddWithValue("@ThoiGianLamBai", thoigianlambai);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngaybatdau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ngayketthuc);
                    cmd.Parameters.AddWithValue("@CreateAt", createAt);

                    maDeThi = (int)cmd.ExecuteScalar();

                    // Gọi TaoCauHoi để random câu hỏi và lưu vào CT_DETHI
                    TaoCauHoi(maDeThi, soluongcauhoi, soluongcauhoide, soluongcauhoitrungbinh, soluongcauhoikho);

                    MessageBox.Show("Thêm đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm đề thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TaoCauHoi(int maDeThi, int tongSoCau, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            List<int> danhSachCauHoi = new List<int>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    if (soCauDe == 0 && soCauTrungBinh == 0 && soCauKho == 0)
                    {
                        // Nếu cả 3 đều bằng 0, random toàn bộ số câu hỏi
                        LayCauHoiNgauNhien(conn, danhSachCauHoi, tongSoCau);
                    }
                    else
                    {
                        // Tạo câu hỏi DỄ
                        LayCauHoiTheoMucDo(conn, soCauDe, "Dễ", danhSachCauHoi);

                        // Tạo câu hỏi TRUNG BÌNH
                        LayCauHoiTheoMucDo(conn, soCauTrungBinh, "Trung bình", danhSachCauHoi);

                        // Tạo câu hỏi KHÓ
                        LayCauHoiTheoMucDo(conn, soCauKho, "Khó", danhSachCauHoi);

                        // Nếu tổng số câu hỏi chưa đủ, random thêm từ ngân hàng
                        int conLai = tongSoCau - (soCauDe + soCauTrungBinh + soCauKho);
                        if (conLai > 0)
                        {
                            LayCauHoiNgauNhien(conn, danhSachCauHoi, conLai);
                        }
                    }

                    // Insert vào CT_DETHI
                    foreach (int maCauHoi in danhSachCauHoi)
                    {
                        SqlCommand insertCmd = new SqlCommand(
                            "INSERT INTO CT_DETHI (MaDeThi, MaCauHoi) VALUES (@MaDeThi, @MaCauHoi)",
                            conn
                        );
                        insertCmd.Parameters.AddWithValue("@MaDeThi", maDeThi);
                        insertCmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
        private void LayCauHoiTheoMucDo(SqlConnection conn, int soLuong, string mucDo, List<int> danhSach)
        {
            if (soLuong <= 0) return;

            string query = $"SELECT TOP {soLuong} MaCauHoi FROM CAUHOI WHERE MaNganHang = @MaNganHang AND DangCauHoi = N'{mucDo}' ORDER BY NEWID()";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int maCauHoi = reader.GetInt32(0);
                        if (!danhSach.Contains(maCauHoi)) // Kiểm tra trùng lặp
                        {
                            danhSach.Add(maCauHoi);
                        }
                    }
                }
            }
        }

        private void LayCauHoiNgauNhien(SqlConnection conn, List<int> danhSach, int soLuong)
        {
            if (soLuong <= 0) return;

            string query = $"SELECT TOP {soLuong} MaCauHoi FROM CAUHOI WHERE MaNganHang = @MaNganHang ORDER BY NEWID()";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int maCauHoi = reader.GetInt32(0);
                        if (!danhSach.Contains(maCauHoi)) // Kiểm tra trùng lặp
                        {
                            danhSach.Add(maCauHoi);
                        }
                    }
                }
            }
        }

        private void tdtbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
