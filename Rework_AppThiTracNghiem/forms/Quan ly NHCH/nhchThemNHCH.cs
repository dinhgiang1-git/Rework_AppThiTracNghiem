using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.DataAccess;

namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH
{
    public partial class nhchThemNHCH : Form
    {
        string g_maGiangVien = "";
        
        public nhchThemNHCH(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
        }

        private void nhchbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add()
        {
            string tenNHCH = "Ngân hàng câu hỏi " + nhchtxtTenNganHang.Text;
            DateTime createAt = DateTime.Now;

            if (string.IsNullOrEmpty(tenNHCH))
            {
                MessageBox.Show("Vui lòng nhập tên ngân hàng câu hỏi!");
                return;
            }

            try
            {
                string query = @"Insert into NGANHANGCAUHOI
                               (TenNganHang, CreateAt, MaGiangVien) 
                               values 
                               (@TenNganHang, @CreateAt, @MaGiangVien)";

                int rowAffected = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@TenNganHang", tenNHCH),
                    new SqlParameter("@CreateAt", createAt),
                    new SqlParameter("@MaGiangVien", g_maGiangVien));

                if (rowAffected > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void nhchbtnThem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void nhchbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
            this.Close();
        }

        private void nhchtxtTenNganHang_TextChanged(object sender, EventArgs e)
        {
            idk.Text = "Ngân hàng câu hỏi môn " + nhchtxtTenNganHang.Text;
        }
    }
}
