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

namespace Rework_AppThiTracNghiem
{

    public partial class login : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        public login()
        {
            InitializeComponent();

            //khởi tạo ban đầu
            logincbChonVaiTro.SelectedIndex = 0;

            //
        }
        private void fCheckLogin()
        {
            //Lấy dữ liệu
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

            //Login
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string queryGV = "Select count(*) from GIANGVIEN where MaGiangVien = @MaGiangVien and MatKhau = @MatKhau";
                    SqlCommand cmd = new SqlCommand(queryGV, conn);
                    cmd.Parameters.AddWithValue("@MaGiangVien", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                    int count = (int)cmd.ExecuteScalar();
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
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void loginbtnLogin_Click(object sender, EventArgs e)
        {
            fCheckLogin();
        }
    }
}
