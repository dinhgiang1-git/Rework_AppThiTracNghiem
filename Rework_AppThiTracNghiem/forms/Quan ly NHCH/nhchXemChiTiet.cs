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
using Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.Câu_hỏi;

namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH
{
    public partial class nhchXemChiTiet : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maNganHang = "";
        string g_tenNganHang = "";
        string g_maCauHoi = "";
        string g_noiDungCauHoi = "";
        public nhchXemChiTiet(string maNganHang, string tenNganHang)
        {
            InitializeComponent();
            g_maNganHang = maNganHang;
            g_tenNganHang = tenNganHang;

            idk.Text = tenNganHang;
            this.Text = tenNganHang;
            LoadData_CauHoi();
        }

        private void LoadData_CauHoi()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD from CAUHOI where MaNganHang = @MaNganHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataCAUHOI.DataSource = dt;
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

        private void nhchbtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData_CauHoi();
        }

        private void nhchbtnThemThuCong_Click(object sender, EventArgs e)
        {
            ThemCauHoi themcauhoithucong = new ThemCauHoi(g_maNganHang, g_tenNganHang);
            themcauhoithucong.Show();
        }

        private void nhchbtnSuaCauHoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maCauHoi))
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi để sửa!");
                return;
            }
            SuaCauHoi suacauhoi = new SuaCauHoi(g_maNganHang, g_tenNganHang, g_maCauHoi);
            suacauhoi.Show();
        }

        private void dataCAUHOI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataCAUHOI.Rows[e.RowIndex];
                g_maCauHoi = row.Cells["MaCauHoi"].Value.ToString();
                g_noiDungCauHoi = row.Cells["NoiDungCauHoi"].Value.ToString();
            }
        }

        private void nhchbtnXoaCauHoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maCauHoi)) 
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi để XOÁ!");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá " + g_noiDungCauHoi + " ?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete CAUHOI where MaCauHoi = @MaCauHoi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCauHoi", g_maCauHoi);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0) 
                    {
                        MessageBox.Show("Xoá câu hỏi " + g_noiDungCauHoi + " thành công!");
                        LoadData_CauHoi();
                    } else
                    {
                        MessageBox.Show("Xoá câu hỏi thất bại!");
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
    }
}
