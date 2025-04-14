using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.Class;
using Rework_AppThiTracNghiem.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rework_AppThiTracNghiem
{
    public partial class ThiSinh : Form
    {
        private List<DeThi> danhSachDeThi = new List<DeThi>();
        private List<KetQua> danhSachKetQua = new List<KetQua>();

        string g_masinhvien = "";
        public ThiSinh(string masv)
        {
            InitializeComponent();
            g_masinhvien = masv;
            load_Danh_sach_de_thi(g_masinhvien);
            LoadData();
        }
        //Load danh sách đề thi
        private void LoadData() //aka BindData
        {
            Console.WriteLine(danhSachDeThi);
            // 2. Cấu hình TableLayoutPanel
            tblDethi.ColumnCount = 1; // 1 cột
            tblDethi.RowCount = danhSachDeThi.Count;
            tblDethi.AutoScroll = true;
            tblKetQuaThi.ColumnCount = 1; // 1 cột
            tblKetQuaThi.RowCount = danhSachDeThi.Count;
            tblKetQuaThi.AutoScroll = true;

            // 3. Tạo và thêm các UserControl vào TableLayoutPanel
            for (int i = 0; i < danhSachDeThi.Count; i++)
            {
                // Tạo UserControl mới
                var itemdethi = new itemDethi();
                itemdethi.BindData(danhSachDeThi[i], g_masinhvien);

                // Thêm vào TableLayoutPanel
                tblDethi.Controls.Add(itemdethi, 0, i);

                // Cấu hình row style nếu cần
                tblDethi.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            for (int i = 0; i < danhSachKetQua.Count; ++i)
            {
                var itemdiemthi = new itemDiemThi();
                itemdiemthi.BindData(danhSachKetQua[i]);
                tblKetQuaThi.Controls.Add(itemdiemthi, 0, i);
                tblKetQuaThi.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

        }
        //Nạp danh sách đề thi 
        private void load_Danh_sach_de_thi(string masinhvien)
        {

            string strConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //sử dụng SQLDataReader
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    SqlCommand command = new SqlCommand("getBaiThi_SinhVien", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@masinhvien", masinhvien);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("fetch thanh cong");
                        danhSachDeThi.Add(new DeThi
                        {
                            MaDeThi = reader.GetInt32(0).ToString(),
                            TenDeThi = reader.GetString(1),
                            NgayMo = reader.GetDateTime(2),
                            NgayDong = reader.GetDateTime(3),
                            ThoiGianLam = reader.GetInt32(4),
                        });

                    }
                    reader.Close();
                    command.CommandText = "getKetQua_SinhVien";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("fetch thanh cong");
                        danhSachKetQua.Add(new KetQua
                        {
                            MaKetQua = reader.GetInt32(0),
                            MaDeThi = reader.GetInt32(1),
                            MaSinhVien = reader.GetString(2),
                            Diem = reader.GetDouble(3),
                            NgayThi = reader.GetDateTime(4),
                            TenDeThi = reader.GetString(5)
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

        }

        private void btnRF_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("!!!!");
            danhSachKetQua.Clear(); danhSachDeThi.Clear();
            tblDethi.Controls.Clear(); tblKetQuaThi.Controls.Clear();
            load_Danh_sach_de_thi(g_masinhvien);
            LoadData();
        }

        private void poisonButton18_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < danhSachDeThi.Count; i++)
            {
                {
                    if (inputSearch.Text == danhSachDeThi[i].TenDeThi || inputSearch.Text == danhSachDeThi[i].MaDeThi)
                    {
                        tblDethi.ScrollControlIntoView(tblDethi.Controls[i]);
                    }
                }
            }
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < danhSachKetQua.Count; i++)
            {
                {
                    if (inputSearch2.Text == danhSachKetQua[i].TenDeThi || inputSearch2.Text == danhSachKetQua[i].MaDeThi.ToString())
                    {
                        tblDethi.ScrollControlIntoView(tblDethi.Controls[i]);
                    }
                }
            }
        }
    }
}
