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

namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.Câu_hỏi
{
    public partial class ThemCauHoi : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maNganHang = "";
        string g_tenNganHang = "";
        public ThemCauHoi(string maNganHang, string tenNganHang)
        {
            InitializeComponent();
            tchtxtMaNganHang.Text = maNganHang;
            tchtxtTenNganHang.Text = tenNganHang;
            tchtxtMaNganHang.Enabled = false;
            tchtxtTenNganHang.Enabled = false;

            g_maNganHang = maNganHang;
            g_tenNganHang = tenNganHang;
        }

        public void addCauHoi()
        {
            //Lấy dữ liệu
            string noiDungCauHoi = tchtxtNoiDungCauHoi.Text;
            string noiDungA = tchtxtNoiDungDapAnA.Text;
            string noiDungB = tchtxtNoiDungDapAnB.Text;
            string noiDungC = tchtxtNoiDungDapAnC.Text;
            string noiDungD = tchtxtNoiDungDapAnD.Text;
            string dapAnDung = "";
            DateTime createAt = DateTime.Now;
            if (radioA.Checked)
            {
                dapAnDung = "A";
            }
            else if (radioB.Checked)
            {
                dapAnDung = "B";
            }
            else if (radioC.Checked)
            {
                dapAnDung = "C";
            }
            else if (radioD.Checked)
            {
                dapAnDung = "D";
            }

            //Validate
            if (string.IsNullOrEmpty(noiDungCauHoi))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi.!");
                return;
            }
            if (string.IsNullOrEmpty(noiDungA) && string.IsNullOrEmpty(noiDungB) && string.IsNullOrEmpty(noiDungC) && string.IsNullOrEmpty(noiDungD))
            {
                MessageBox.Show("Vui lòng điền ít nhất 1 câu trả lời!");
                return;
            }
            if (string.IsNullOrEmpty(dapAnDung))
            {
                MessageBox.Show("Vui lòng chọn câu trả lời");
                return;
            }

            //add
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Insert into CAUHOI(NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, MaNganHang, CreateAt) values(@NoiDungCauHoi, @DapAnA, @DapAnB, @DapAnC, @DapAnD, @DapAnDung, @MaNganHang, @CreateAt)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NoiDungCauHoi", noiDungCauHoi);
                    cmd.Parameters.AddWithValue("@DapAnA", noiDungA);
                    cmd.Parameters.AddWithValue("@DapAnB", noiDungB);
                    cmd.Parameters.AddWithValue("@DapAnC", noiDungC);
                    cmd.Parameters.AddWithValue("@DapAnD", noiDungD);
                    cmd.Parameters.AddWithValue("@DapAnDung", dapAnDung);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    cmd.Parameters.AddWithValue("@CreateAt", createAt);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Thêm câu hỏi thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm câu hỏi thất bại");
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
        private void clearThongTin()
        {
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
            tchtxtNoiDungCauHoi.Text = string.Empty;
            tchtxtNoiDungDapAnA.Clear();
            tchtxtNoiDungDapAnB.Clear();
            tchtxtNoiDungDapAnC.Clear();
            tchtxtNoiDungDapAnD.Clear();
        }

        private void tchbtnThem_Click(object sender, EventArgs e)
        {
            addCauHoi();
        }

        private void tchbtnThemDong_Click(object sender, EventArgs e)
        {
            addCauHoi();
            this.Close();
        }

        private void tchbtnClear_Click(object sender, EventArgs e)
        {
            clearThongTin();
        }

        private void tchbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
