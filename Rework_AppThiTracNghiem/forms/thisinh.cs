using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.Class;
using Rework_AppThiTracNghiem.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rework_AppThiTracNghiem
{
    public partial class ThiSinh : Form
    {
        private List<DeThi> danhSachDeThi = new List<DeThi>();
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

            // 3. Tạo và thêm các UserControl vào TableLayoutPanel
            for (int i = 0; i < danhSachDeThi.Count; i++)
            {
                // Tạo UserControl mới
                var itemdethi = new itemDethi();
                itemdethi.BindData(danhSachDeThi[i],g_masinhvien);

                // Thêm vào TableLayoutPanel
                tblDethi.Controls.Add(itemdethi, 0, i);

                // Cấu hình row style nếu cần
                tblDethi.RowStyles.Add(new RowStyle(SizeType.AutoSize));
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
                    SqlCommand command = new SqlCommand("GetDeThi_SinhVien", connection);
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

        }
    }
}
