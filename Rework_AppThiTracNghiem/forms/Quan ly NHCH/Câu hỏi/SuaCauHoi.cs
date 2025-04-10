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

    public partial class SuaCauHoi : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maNganHang = "";
        string g_tenNganHang = "";
        string g_maCauHoi = "";
        public SuaCauHoi(string maNganHang, string tenNganHang, string maCauHoi)
        {
            InitializeComponent();
            g_maNganHang = maNganHang;
            g_tenNganHang = tenNganHang;
            g_maCauHoi = maCauHoi;

            schtxtMaNganHang.Text = maNganHang;
            schtxtMaNganHang.Enabled = false;
            schtxtTenNganHang.Text = tenNganHang;
            schtxtTenNganHang.Enabled = false;
            LoadThongTin();
        }
        private void LoadThongTin()
        {

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung from CAUHOI where MaCauHoi = @MaCauHoi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCauHoi", g_maCauHoi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        schtxtNoiDungCauHoi.Text = reader["NoiDungCauHoi"].ToString();
                        schtxtNoiDungA.Text = reader["DapAnA"].ToString();
                        schtxtNoiDungB.Text = reader["DapAnA"].ToString();
                        schtxtNoiDungC.Text = reader["DapAnA"].ToString();
                        schtxtNoiDungD.Text = reader["DapAnA"].ToString();
                        string dapAnDung = reader["DapAnDung"].ToString();
                        if (dapAnDung == "A")
                        {
                            radioA.Checked = true;
                        }
                        else if (dapAnDung == "B")
                        {
                            radioB.Checked = true;
                        }
                        else if (dapAnDung == "C")
                        {
                            radioC.Checked = true;
                        }
                        else if (dapAnDung == "D")
                        {
                            radioD.Checked = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error :" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void Edit()
        {
            //Lấy dữ liệu
            string noiDungCauHoi = schtxtNoiDungCauHoi.Text;
            string noiDungA = schtxtNoiDungA.Text;
            string noiDungB = schtxtNoiDungB.Text;
            string noiDungC = schtxtNoiDungC.Text;
            string noiDungD = schtxtNoiDungD.Text;
            string dapAnDung = "";
            DateTime updateAt = DateTime.Now;
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
                    string query = "Update CAUHOI set NoiDungCauHoi = @NoiDungCauHoi, DapAnA = @DapAnA, DapAnB = @DapAnB, DapAnC = @DapAnC, DapAnD = @DapAnD, DapAnDung = @DapAnDung, UpdateAt = @UpDateAt where MaCauHoi = @MaCauHoi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NoiDungCauHoi", noiDungCauHoi);
                    cmd.Parameters.AddWithValue("@DapAnA", noiDungA);
                    cmd.Parameters.AddWithValue("@DapAnB", noiDungB);
                    cmd.Parameters.AddWithValue("@DapAnC", noiDungC);
                    cmd.Parameters.AddWithValue("@DapAnD", noiDungD);
                    cmd.Parameters.AddWithValue("@DapAnDung", dapAnDung);
                    cmd.Parameters.AddWithValue("@UpdateAt", updateAt);
                    cmd.Parameters.AddWithValue("@MaCauHoi", g_maCauHoi);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Sửa câu hỏi thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa câu hỏi thất bại");
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

        private void nhchbtnThem_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void nhchbtnThemDong_Click(object sender, EventArgs e)
        {
            Edit();
            this.Close();
        }
        private void nhchbtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
