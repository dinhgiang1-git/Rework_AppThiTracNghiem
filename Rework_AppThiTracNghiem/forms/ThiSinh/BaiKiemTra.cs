using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            LoadThongTin_CauHoi();
            listviewDanhSachCauHoi.View = View.Tile;
            listviewDanhSachCauHoi.TileSize = new Size(100, 60);
        }
        //Xem lại bài kiểm tra      
        private void LoadThongTin_DeThi()
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
                    throw new Exception("Error: " + ex.Message);
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
                        string thoigianconlai = reader["ThoiGianLamBai"].ToString();
                        string manganhang = reader["MaNganHang"].ToString();
                        string tongsocau = reader["TongSoCau"].ToString();

                        g_maNganHang = manganhang;
                        g_tongSoCau = int.Parse(tongsocau);

                        labelTenBaiThi.Text = "Bài thi: " + tendethi;
                        int soPhut = int.Parse(thoigianconlai);
                        remainingTime = TimeSpan.FromMinutes(soPhut);
                        txtThoiGianConLai.Text = remainingTime.ToString(@"hh\:mm\:ss");

                        examTimer = new System.Windows.Forms.Timer();
                        examTimer.Interval = 1000;
                        examTimer.Tick += ExamTimer_Tick;
                        examTimer.Start();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }

            // Tạo bản ghi trong BAITHI cho sinh viên
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra xem sinh viên đã có bản ghi trong BAITHI chưa
                    string checkQuery = "SELECT COUNT(*) FROM BAITHI WHERE MaDeThi = @MaDeThi AND MaSinhVien = @MaSinhVien";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    checkCmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // Lấy danh sách câu hỏi từ CT_DETHI
                        string selectQuery = "SELECT MaCauHoi FROM CT_DETHI WHERE MaDeThi = @MaDeThi";
                        SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                        selectCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                        SqlDataReader reader = selectCmd.ExecuteReader();

                        List<int> danhSachCauHoi = new List<int>();
                        while (reader.Read())
                        {
                            danhSachCauHoi.Add((int)reader["MaCauHoi"]);
                        }
                        reader.Close();

                        // Xáo trộn danh sách câu hỏi (nếu muốn thứ tự ngẫu nhiên)
                        Random rng = new Random();
                        int n = danhSachCauHoi.Count;
                        for (int i = 0; i < n; i++)
                        {
                            int k = rng.Next(i, n);
                            int temp = danhSachCauHoi[i];
                            danhSachCauHoi[i] = danhSachCauHoi[k];
                            danhSachCauHoi[k] = temp;
                        }

                        // Thêm bản ghi vào BAITHI
                        for (int i = 0; i < danhSachCauHoi.Count; i++)
                        {
                            string insertQuery = @"
                                                INSERT INTO BAITHI (MaDeThi, MaCauHoi, MaSinhVien, DapAnChon)
                                                VALUES (@MaDeThi, @MaCauHoi, @MaSinhVien, NULL)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                            insertCmd.Parameters.AddWithValue("@MaCauHoi", danhSachCauHoi[i]);
                            insertCmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);               
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
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
                    string query = @"
                        SELECT CAUHOI.MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, BAITHI.DapAnChon 
                        FROM CAUHOI 
                        JOIN BAITHI ON BAITHI.MaCauHoi = CAUHOI.MaCauHoi 
                        WHERE BAITHI.MaSinhVien = @MaSinhVien AND BAITHI.MaDeThi = @MaDeThi";
          
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string macauhoi = reader["MaCauHoi"].ToString();
                        string noidungcauhoi = reader["NoiDungCauHoi"].ToString();
                        string noidungdapanA = reader["DapAnA"].ToString();
                        string noidungdapanB = reader["DapAnB"].ToString();
                        string noidungdapanC = reader["DapAnC"].ToString();
                        string noidungdapanD = reader["DapAnD"].ToString();
                        string dapAnChon = reader["DapAnChon"]?.ToString();


                        ucCauHoi cauhoi = new ucCauHoi
                        {
                            Dock = DockStyle.Top,
                            MaCauHoi = macauhoi,
                            NoiDungCauHoi = noidungcauhoi,
                            NoiDungDapAnA = noidungdapanA,
                            NoiDungDapAnB = noidungdapanB,
                            NoiDungDapAnC = noidungdapanC,
                            NoiDungDapAnD = noidungdapanD
                        };

                        //if (!string.IsNullOrEmpty(dapAnChon))
                        //{
                        //    if (dapAnChon == "A") cauhoi.DapAnA = true;
                        //    else if (dapAnChon == "B") cauhoi.DapAnB = true;
                        //    else if (dapAnChon == "C") cauhoi.DapAnC = true;
                        //    else if (dapAnChon == "D") cauhoi.DapAnD = true;
                        //}

                        index++;
                        string strIndex = "Câu: " + index.ToString();
                        cauhoi.Index = strIndex;

                        ListViewItem item = new ListViewItem(strIndex);
                        item.Tag = cauhoi;
                        listviewDanhSachCauHoi.Items.Add(item);

                        flowCauHoi.Controls.Add(cauhoi);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
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
            if (!checkboxnopbai.Checked)
            {
                MessageBox.Show("Vui lòng tích vào 'Tôi muốn nộp bài!'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dừng đồng hồ
            examTimer.Stop();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();

                    // Duyệt qua các control ucCauHoi trong FlowLayoutPanel
                    foreach (ucCauHoi cauHoi in flowCauHoi.Controls.OfType<ucCauHoi>())
                    {
                        string dapAnChon = cauHoi.DapAnChon;
                        string maCauHoi = cauHoi.MaCauHoi;

                        if (!string.IsNullOrEmpty(dapAnChon))
                        {
                            // Cập nhật DapAnChon vào bảng CT_DETHI
                            string updateQuery = @"
                                UPDATE BAITHI 
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

                    // Tính điểm
                    int soCauDung = 0;
                    double diemMoiCau = 10.0 / g_tongSoCau;
                    double diem = 0;

                    // Đếm số câu đúng
                    string query = @"
                        SELECT COUNT(*) 
                        FROM BAITHI bt
                        JOIN CAUHOI ch ON bt.MaCauHoi = ch.MaCauHoi
                        WHERE bt.MaSinhVien = @MaSinhVien 
                        AND bt.MaDeThi = @MaDeThi 
                        AND bt.DapAnChon = ch.DapAnDung
                        AND bt.DapAnChon IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    soCauDung = Convert.ToInt32(cmd.ExecuteScalar());

                    diem = soCauDung * diemMoiCau;

                    // Lưu kết quả vào BAITHI_KETQUA
                    string insertQuery = @"
                        INSERT INTO BAITHI_KETQUA 
                        (MaSinhVien, MaDeThi, Diem, ThoiGianBatDau, ThoiGianNop, SoCauDung, TongSoCau, CreateAt)
                        VALUES (@MaSinhVien, @MaDeThi, @Diem, @ThoiGianBatDau, @ThoiGianNop, @SoCauDung, @TongSoCau, @CreateAt)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@MaSinhVien", g_maSinhVien);
                    insertCmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    insertCmd.Parameters.AddWithValue("@Diem", diem);
                    insertCmd.Parameters.AddWithValue("@ThoiGianBatDau", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@ThoiGianNop", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@SoCauDung", soCauDung);
                    insertCmd.Parameters.AddWithValue("@TongSoCau", g_tongSoCau);
                    insertCmd.Parameters.AddWithValue("@CreateAt", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    flowCauHoi.Controls.Clear();

                    ucKetQua ucketqua = new ucKetQua(g_maDeThi, g_maSinhVien);
                    ucketqua.Dock = DockStyle.Top;
                    ucketqua.TenBaiThi = g_tenDeThi;
                    ucketqua.SoCauTraLoiDung = "Bạn đã làm đúng " + soCauDung + "/" + g_tongSoCau;
                    ucketqua.DiemSo = "Số điểm của bạn " + diem + "đ";

                    flowCauHoi.Controls.Add(ucketqua);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nộp bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        
    }
}
