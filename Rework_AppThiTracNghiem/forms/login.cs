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

namespace Rework_AppThiTracNghiem
{

    public partial class login : Form
    {
        // Remove strConn
        public login()
        {
            InitializeComponent();
            logincbChonVaiTro.SelectedIndex = 0;
        }

        private void fCheckLogin()
        {
            string tenDangNhap = logintxtTenDangNhap.Text.Trim();
            string matKhau = logintxtMatKhau.Text.Trim();

            //Validate
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng điền tên đăng nhập");
                return;
            }
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng điền mật khẩu!");
                return;
            }
            if (logincbChonVaiTro.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                return;
            }

            try
            {
                string queryGV = "Select count(*) from GIANGVIEN where MaGiangVien = @MaGiangVien and MatKhau = @MatKhau";
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryGV,
                    new SqlParameter("@MaGiangVien", tenDangNhap),
                    new SqlParameter("@MatKhau", matKhau)));

                if (count > 0)
                {
                    admin ad = new admin(tenDangNhap);
                    ad.Show();
                    this.Hide();
                }
                else
                {
                    

                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! Vui lòng thử lại");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                throw new Exception("Error: " + ex.Message);
            }
        }

        private void bigLabel3_Click(object sender, EventArgs e)
        {

        }

        private void loginbtnLogin_Click(object sender, EventArgs e)
        {
            fCheckLogin();
        }
    }
}
