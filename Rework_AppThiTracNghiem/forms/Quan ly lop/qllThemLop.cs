using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.DataAccess;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class qllThemLop : Form
    {
        string g_maGiangVien = "";
        
        public qllThemLop(string maGiangVien)
        {
            InitializeComponent();
            g_maGiangVien = maGiangVien;
        }

        private void qllbtnThemHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkTrungMaLop(string maLop)
        {
            try
            {
                string query = "Select count(*) from LOPHOC where MaLopHoc = @MaLopHoc";
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                    new SqlParameter("@MaLopHoc", maLop)));
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void add()
        {
            string maLop = qlltxtMaLop.Text.Trim().ToUpper();
            string tenLop = qlltxtTenLop.Text.Trim();
            DateTime createAt = DateTime.Now;

            //Validate
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!");
                return;
            }
            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!");
                return;
            }
            if (checkTrungMaLop(maLop))
            {
                MessageBox.Show("Mã lớp đã bị trùng! Vui lòng nhập mã khác!");
                return;
            }

            try
            {
                string query = @"Insert into LOPHOC
                               (MaLopHoc, TenLopHoc, CreateAt, MaGiangVien) 
                               values 
                               (@MaLopHoc, @TenLopHoc, @CreateAt, @MaGiangVien)";

                int rowAffected = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaLopHoc", maLop),
                    new SqlParameter("@TenLopHoc", tenLop),
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

        private void qllbtnThem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void qllbtnThemDong_Click(object sender, EventArgs e)
        {
            add();
            this.Close();
        }
    }
}
