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

namespace Rework_AppThiTracNghiem.forms.ThiSinh
{

    public partial class BaiKiemTra : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maSinhVien = "";
        string g_maDeThi = "";
        string g_maNganHang = "";
        string g_tenDeThi = "";
        int g_soCauDe = 0;
        int g_soCauTrungBinh = 0;
        int g_soCauKho = 0;
        int g_tongSoCau = 0;
        int g_khoiTao = 0; //Làm sau //Done        
        DateTime g_thoigianbatdau = DateTime.Now;
        private System.Windows.Forms.Timer examTimer; // Sử dụng Windows.Forms.Timer
        private TimeSpan remainingTime;

        public BaiKiemTra(string maSinhVien, string maDeThi)
        {
            InitializeComponent();
            DateTime thoiGianBatDau;
            g_maSinhVien = maSinhVien;
            g_maDeThi = maDeThi;
            LoadThongTin_DeThi();
            if (g_khoiTao == 0)
            {
                TaoCauHoi();
            }

            LoadThongTin_CauHoi();

            listviewDanhSachCauHoi.View = View.Tile;
            listviewDanhSachCauHoi.TileSize = new Size(100, 60);
        }
        private void LoadThongTin_DeThi()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from SINHVIEN where MaSinhVien = @MaSinhVien";
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
                    string query = "Select * from DETHI where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string tendethi = reader["TenDeThi"].ToString();
                        string thoigianconlai = reader["ThoiGianLamBai"].ToString();
                        string socaude = reader["SoCauDe"].ToString();
                        string socautrungbinh = reader["SoCauTrungBinh"].ToString();
                        string socaukho = reader["SoCauKho"].ToString();
                        string manganhang = reader["MaNganHang"].ToString();
                        string tongsocau = reader["TongSoCau"].ToString();

                        g_maNganHang = manganhang;
                        g_soCauDe = int.Parse(socaude);
                        g_soCauTrungBinh = int.Parse(socautrungbinh);
                        g_soCauKho = int.Parse(socaukho);
                        g_tongSoCau = int.Parse(tongsocau);
                        g_tenDeThi = tendethi;

                        labelTenBaiThi.Text = "Bài thi: " + tendethi;
                        int soPhut = int.Parse(thoigianconlai);
                        remainingTime = TimeSpan.FromMinutes(soPhut);
                        txtThoiGianConLai.Text = remainingTime.ToString(@"hh\:mm\:ss");

                        // Khởi tạo và cấu hình Timer
                        examTimer = new System.Windows.Forms.Timer();
                        examTimer.Interval = 1000; // 1 giây
                        examTimer.Tick += ExamTimer_Tick;
                        examTimer.Start();
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
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select count(*) from CT_BAITHI where MaDeThi = @MaDeThi and KhoiTao = '1'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        g_khoiTao = 1;
                    }
                    else
                    {
                        g_khoiTao = 0;
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
        private void LoadThongTin_CauHoi()
        {
            flowCauHoi.Controls.Clear();
            listviewDanhSachCauHoi.Items.Clear();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                int index = 0;
                try
                {
                    conn.Open();
                    string query = "select CAUHOI.MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD from CAUHOI join CT_BAITHI on CT_BAITHI.MaCauHoi = CAUHOI.MaCauHoi where CT_BAITHI.MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string macauhoi = reader["MaCauHoi"].ToString();
                        string noidungcauhoi = reader["NoiDungCauHoi"].ToString();
                        string noidungdapanA = reader["DapAnA"].ToString();
                        string noidungdapanB = reader["DapAnB"].ToString();
                        string noidungdapanC = reader["DapAnC"].ToString();
                        string noidungdapanD = reader["DapAnD"].ToString();

                        ucCauHoi cauhoi = new ucCauHoi();
                        cauhoi.Dock = DockStyle.Top;
                        cauhoi.MaCauHoi = macauhoi;
                        cauhoi.NoiDungCauHoi = noidungcauhoi;
                        cauhoi.NoiDungDapAnA = noidungdapanA;
                        cauhoi.NoiDungDapAnB = noidungdapanB;
                        cauhoi.NoiDungDapAnC = noidungdapanC;
                        cauhoi.NoiDungDapAnD = noidungdapanD;
                        index++;
                        string strIndex = "Câu: " + index.ToString();
                        cauhoi.Index = strIndex;

                        // Thêm vào ListView
                        ListViewItem item = new ListViewItem(strIndex);
                        item.Tag = cauhoi; // Lưu reference đến UserControl
                        listviewDanhSachCauHoi.Items.Add(item);

                        flowCauHoi.Controls.Add(cauhoi);
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
        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime.TotalSeconds > 0)
            {
                remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                txtThoiGianConLai.Text = remainingTime.ToString(@"hh\:mm\:ss");
            }
            else
            {
                examTimer.Stop();
                MessageBox.Show("Hết giờ làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Hoặc gọi hàm nộp bài
            }
        }

        private void BaiKiemTra_FormClosing(object sender, FormClosingEventArgs e)
        {
            examTimer?.Stop();
            examTimer?.Dispose();
        }

        //Very impotant!!! TaoCauHoi();
        private void TaoCauHoi()
        {
            List<int> danhSachCauHoi = new List<int>();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    if (g_soCauDe == 0 && g_soCauTrungBinh == 0 && g_soCauKho == 0)
                    {
                        // Nếu cả 3 đều bằng 0, random toàn bộ số câu hỏi
                        LayCauHoiNgauNhien(conn, danhSachCauHoi);
                    }
                    else
                    {
                        // Tạo câu hỏi DỄ
                        LayCauHoiTheoMucDo(conn, g_soCauDe, "Dễ", danhSachCauHoi);

                        // Tạo câu hỏi TRUNG BÌNH
                        LayCauHoiTheoMucDo(conn, g_soCauTrungBinh, "Trung bình", danhSachCauHoi);

                        // Tạo câu hỏi KHÓ
                        LayCauHoiTheoMucDo(conn, g_soCauKho, "Khó", danhSachCauHoi);
                    }

                    // Insert vào CT_BAITHI
                    foreach (int maCauHoi in danhSachCauHoi)
                    {
                        SqlCommand insertCmd = new SqlCommand("INSERT INTO CT_BAITHI (MaSinhVien, MaDeThi, MaCauHoi, KhoiTao) VALUES (@MaSinhVien, @MaDeThi, @MaCauHoi, @KhoiTao)", conn);
                        insertCmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                        insertCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                        insertCmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                        insertCmd.Parameters.AddWithValue("@KhoiTao", 1);
                        insertCmd.ExecuteNonQuery();
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
        private void LayCauHoiTheoMucDo(SqlConnection conn, int soLuong, string mucDo, List<int> danhSach)
        {
            string query = $"SELECT TOP {soLuong} MaCauHoi FROM CAUHOI WHERE MaNganHang = @MaNganHang AND DangCauHoi = N'{mucDo}' ORDER BY NEWID()";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
            }
        }
        private void LayCauHoiNgauNhien(SqlConnection conn, List<int> danhSach)
        {
            // Số lượng câu hỏi có thể xác định tùy vào đề thi            

            string query = $"SELECT TOP {g_tongSoCau} MaCauHoi FROM CAUHOI WHERE MaNganHang = @MaNganHang ORDER BY NEWID()";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
            }
        }

        private void listviewDanhSachCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listviewDanhSachCauHoi.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listviewDanhSachCauHoi.SelectedItems[0];
                ucCauHoi selectedQuestion = selectedItem.Tag as ucCauHoi;

                // Cuộn đến câu hỏi được chọn
                flowCauHoi.ScrollControlIntoView(selectedQuestion);
            }
        }
        public void UpdateQuestionStatus(int questionNumber, bool isAnswered)
        {
            if (questionNumber > 0 && questionNumber <= listviewDanhSachCauHoi.Items.Count)
            {
                ListViewItem item = listviewDanhSachCauHoi.Items[questionNumber - 1];

                if (isAnswered)
                {
                    item.BackColor = Color.LightGreen;
                    if (!item.Text.StartsWith("✓ ")) // nếu chưa có thì mới thêm
                    {
                        item.Text = "✓ " + item.Text;
                    }
                }
                else
                {
                    item.BackColor = SystemColors.Window;
                    if (item.Text.StartsWith("✓ ")) // nếu có thì mới xóa
                    {
                        item.Text = item.Text.Substring(2);
                    }
                }
            }
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            if(!checkboxnopbai.Checked)
            {
                MessageBox.Show("Vui lòng tích vào 'Tôi muốn nộp bài!'");
                return;
            }         
            examTimer.Stop();

            int soCauDung = 0;
            double diemMoiCau = 10.0 / g_tongSoCau;
            double diem = 0;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    foreach (ucCauHoi cauHoi in flowCauHoi.Controls.OfType<ucCauHoi>())
                    {
                        // Lấy đáp án đã chọn
                        string dapAnChon = cauHoi.DapAnChon; 
                        string maCauHoi = cauHoi.MaCauHoi;

                        if (!string.IsNullOrEmpty(dapAnChon))
                        {
                            // Cập nhật chỉ cột DapAnChon vào bảng CT_BAITHI
                            string updateQuery = @"
                                UPDATE CT_BAITHI 
                                SET DapAnChon = @DapAnChon
                                WHERE MaSinhVien = @MaSinhVien AND MaDeThi = @MaDeThi AND MaCauHoi = @MaCauHoi";

                            SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                            updateCmd.Parameters.AddWithValue("@DapAnChon", dapAnChon);
                            updateCmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                            updateCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                            updateCmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                            updateCmd.ExecuteNonQuery();
                        }
                    }


                    // Query to count correct answers
                    string query = @"
                        SELECT COUNT(*) 
                        FROM CT_BAITHI ct
                        JOIN CAUHOI ch ON ct.MaCauHoi = ch.MaCauHoi
                        WHERE ct.MaSinhVien = @MaSinhVien 
                        AND ct.MaDeThi = @MaDeThi 
                        AND ct.DapAnChon = ch.DapAnDung
                        AND ct.DapAnChon IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    soCauDung = Convert.ToInt32(cmd.ExecuteScalar());

                    diem = soCauDung * diemMoiCau;

                    string insertQuery = @"
                        INSERT INTO BAITHI_KETQUA 
                        (MaSinhVien, MaDeThi, Diem, ThoiGianBatDau, ThoiGianNop, SoCauDung, TongSoCau, CreateAt)
                        VALUES (@MaSinhVien, @MaDeThi, @Diem, @ThoiGianBatDau, @ThoiGianNop, @SoCauDung, @TongSoCau, @CreateAt)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    insertCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    insertCmd.Parameters.AddWithValue("@Diem", diem);
                    insertCmd.Parameters.AddWithValue("@ThoiGianBatDau", g_thoigianbatdau); 
                    insertCmd.Parameters.AddWithValue("@ThoiGianNop", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@SoCauDung", soCauDung);
                    insertCmd.Parameters.AddWithValue("@TongSoCau", g_tongSoCau);
                    insertCmd.Parameters.AddWithValue("@CreateAt", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    flowCauHoi.Controls.Clear();

                    ucKetQua ucketqua = new ucKetQua();
                    ucketqua.Dock = DockStyle.Top;
                    ucketqua.TenBaiThi = g_tenDeThi;
                    ucketqua.SoCauTraLoiDung = "Bạn đã làm đúng " +soCauDung+ "/" +g_tongSoCau;
                    ucketqua.DiemSo = "Số điểm của bạn " +diem+ "đ";

                    flowCauHoi.Controls.Add(ucketqua);
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
