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

namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop
{
    public partial class qllSuaLop : Form
    {
        string g_maLop = "";
        
        public qllSuaLop(string maLop)
        {
            InitializeComponent();
            qlltxtMaLop.Enabled = false;
            g_maLop = maLop;
            LoadData_Thongtin();
        }

        private void LoadData_Thongtin()
        {
            try
            {
                string query = "Select MaLopHoc, TenLopHoc from LOPHOC where MaLopHoc = @MaLopHoc";
                DataTable result = DatabaseHelper.ExecuteQuery(query,
                    new SqlParameter("@MaLopHoc", g_maLop));

                if (result.Rows.Count > 0)
                {
                    qlltxtMaLop.Text = result.Rows[0]["MaLopHoc"].ToString();
                    qlltxtTenLop.Text = result.Rows[0]["TenLopHoc"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void qllbtnSuaHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void qllbtnSuaDong_Click(object sender, EventArgs e)
        {
            string tenLop = qlltxtTenLop.Text.Trim();
            DateTime updateAt = DateTime.Now;

            if (string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!");
                return;
            }

            try
            {
                string query = @"Update LOPHOC 
                               set TenLopHoc = @TenLopHoc, 
                                   UpdateAt = @UpdateAt 
                               where MaLopHoc = @MaLopHoc";

                int rowAffected = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@TenLopHoc", tenLop),
                    new SqlParameter("@UpdateAt", updateAt),
                    new SqlParameter("@MaLopHoc", g_maLop));

                if (rowAffected > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
