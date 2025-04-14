using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.Class;
using Rework_AppThiTracNghiem.DataAccess;
using Rework_AppThiTracNghiem.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class LamDeThi : Form
    {
        private List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private string g_maDeThi = "";
        private string g_maSinhVien = "";
        private int thoigianlam = 0;
        private Timer timer;
        private int remainingSeconds;
        private Dictionary<int, Button> buttonCauHoi = new Dictionary<int, Button>();
        public LamDeThi(string maDeThi, string maSinhVien, int duration)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            g_maSinhVien = maSinhVien;
            thoigianlam = duration;
            Console.WriteLine(g_maDeThi + " + " + g_maSinhVien + "+"+thoigianlam);
            load_danh_sach_cau_hoi(g_maDeThi);
            BindData();
            StartTimer();
        }
    
        private void StartTimer()
        {
            remainingSeconds = thoigianlam * 60;
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateTimeDisplay();
        }
    
        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            if (remainingSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Hết thời gian làm bài!");
                NopBai(true);
            }
            UpdateTimeDisplay();
        }
    
        private void UpdateTimeDisplay()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            lblTimer.Text = $"{minutes:00}:{seconds:00}";
        }
    
        private void btnNopBai_Click(object sender, EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Chưa hết giờ, bạn có muốn nộp bài?",
                    "Xác nhận nộp bài",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
    
                if (result == DialogResult.Yes)
                {
                    NopBai(false);
                }
            }
            else
            {
                NopBai(true);
            }
        }
    
        private void NopBai(bool isTimeout)
        {
            timer.Stop();
            double diem = TinhDiem();
    
            try
            {
                string query = @"INSERT INTO KETQUA (MaDeThi, MaSinhVien, Diem, NgayThi) 
                        VALUES (@MaDeThi, @MaSinhVien, @Diem, @NgayThi)";
    
                DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaDeThi", g_maDeThi),
                    new SqlParameter("@MaSinhVien", g_maSinhVien),
                    new SqlParameter("@Diem", diem),
                    new SqlParameter("@NgayThi", DateTime.Now));
    
                string message = isTimeout ? 
                    $"Hết giờ làm bài!\nĐiểm của bạn: {diem:F2}" : 
                    $"Điểm của bạn: {diem:F2}";
                    
                MessageBox.Show(message, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu kết quả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private double TinhDiem()
        {
            int soCauDung = 0;
            int tongSoCau = danhSachCauHoi.Count;
    
            foreach (Control control in FlowCauHoi.Controls)
            {
                if (control is itemCauHoi itemCH)
                {
                    if (itemCH.CheckDapAn())
                    {
                        soCauDung++;
                    }
                }
            }
    
            return Math.Round((soCauDung * 10.0) / tongSoCau, 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void itemCauHoi4_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BindData()
        {
            // Create buttons
            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                Button btn = new Button
                {
                    Text = (i + 1).ToString(),
                    Width = 30,
                    Height = 30,
                    Margin = new Padding(5),
                    BackColor = Color.White,
                    Tag = i
                };
                btn.Click += (s, e) => 
                {
                    int index = (int)((Button)s).Tag;
                    FlowCauHoi.ScrollControlIntoView(FlowCauHoi.Controls[index]);
                };
                buttonCauHoi.Add(i, btn);
                pnlDanhSachCau.Controls.Add(btn);
            }
    
            // Create question items
            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                var itemCauHoi = new itemCauHoi();
                int currentIndex = i;  // Capture the current index
                
                // Randomize answers before binding
                CauHoi cauHoiRandom = RandomizeAnswers(danhSachCauHoi[i]);
                itemCauHoi.BindData(cauHoiRandom, currentIndex);
                
                itemCauHoi.DapAnChanged += (s, index) => 
                {
                    if (buttonCauHoi.ContainsKey(currentIndex))
                    {
                        buttonCauHoi[currentIndex].BackColor = Color.LightGreen;
                    }
                };
                FlowCauHoi.Controls.Add(itemCauHoi);
            }
        }

        private CauHoi RandomizeAnswers(CauHoi cauHoi)
        {
            // Lấy đáp án đúng
            string correctAnswerContent = cauHoi.DapAnDung;
    
            // Lấy danh sách đáp án 
            var answers = new List<string>
            {
                ( cauHoi.DapAnA),
                ( cauHoi.DapAnB),
                ( cauHoi.DapAnC),
                ( cauHoi.DapAnD)
            };
    
            // Tráo thứ tự đáp án
            Random rng = new Random();
            int n = answers.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var temp = answers[k];
                answers[k] = answers[n];
                answers[n] = temp;
            }
    
            // Trả về object CauHoi
            var randomizedCauHoi = new CauHoi
            {
                MaCauHoi = cauHoi.MaCauHoi,
                NoiDungCauHoi = cauHoi.NoiDungCauHoi,
                DapAnA = answers[0],
                DapAnB = answers[1],
                DapAnC = answers[2],
                DapAnD = answers[3],
                DapAnDung = correctAnswerContent, // Store the actual answer content instead of letter
                DangCauHoi = cauHoi.DangCauHoi,
                MaNganHang = cauHoi.MaNganHang,
                CreateAt = cauHoi.CreateAt,
                UpdateAt = cauHoi.UpdateAt
            };
    
            return randomizedCauHoi;
        }

        private void load_danh_sach_cau_hoi(string maDeThi)
        {
            string strConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //sử dụng SQLDataReader
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    SqlCommand command = new SqlCommand("GetCauHoi_DeThi", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@madethi", maDeThi);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("fetch thanh cong");
                        danhSachCauHoi.Add(new CauHoi
                        {
                            MaCauHoi = reader.GetInt32(0),
                            NoiDungCauHoi = reader.GetString(1),
                            DapAnA = reader.GetString(2),
                            DapAnB = reader.GetString(3),
                            DapAnC = reader.GetString(4),
                            DapAnD = reader.GetString(5),
                            DapAnDung = reader.GetString(6),
                            DangCauHoi = reader.GetString(7),
                            MaNganHang = reader.GetInt32(8),
                            CreateAt = reader.GetDateTime(9),
                            UpdateAt = reader.GetDateTime(10)
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

        }
    }
}
