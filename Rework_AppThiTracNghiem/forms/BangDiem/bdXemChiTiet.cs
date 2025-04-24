using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.Data.SqlClient;

namespace Rework_AppThiTracNghiem.forms.BangDiem
{
    public partial class bdXemChiTiet : Form
    {
        string strConn = DBHelpercs.strConn;
        string g_maDeThi = "";
        string g_maLop = "";
        public bdXemChiTiet(string maDeThi)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            LoadThongTin_Groupbox();
            LoadThongTin_ComboboxLop();
            LoadData_BangDiem();
        }

        private void LoadThongTin_Groupbox()
        {
            //Lấy thông tin cho groubbox
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select MaLopHoc, TenLopHoc from LOPHOC join DETHI on DETHI.MaLop = LOPHOC.MaLopHoc where MaDeThi = @MaDeThi";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bdgroupbox.Text = "Bảng điểm chi tiết lớp: " + reader["TenLopHoc"].ToString();
                        g_maLop = reader["MaLopHoc"].ToString();
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
        private void LoadThongTin_ComboboxLop()
        {
            //Lấy thông tin cho comboboxLop
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "select MaDeThi, TenDeThi from DETHI where MaLop = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    bdcbDeThi.DataSource = dt;
                    bdcbDeThi.DisplayMember = "TenDeThi";
                    bdcbDeThi.ValueMember = "MaDeThi";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    labelTenDeThi.Text = bdcbDeThi.GetItemText(bdcbDeThi.SelectedItem).ToUpper();
                }
            }
        }
        private void LoadData_BangDiem()
        {
            //Lấy dữ liệu cho datagridviewBangDiem
            //COALESCE(BAITHI_KETQUA.Diem, 0) AS Diem,
            //ORDERBY           
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                    SINHVIEN.MaSinhVien,
                    SINHVIEN.HoTen,             
                    Diem,
                    BAITHI_KETQUA.ThoiGianNop          
                    FROM SINHVIEN
                    LEFT JOIN BAITHI_KETQUA ON SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien 
                    AND BAITHI_KETQUA.MaDeThi = @MaDeThi
                    LEFT JOIN DETHI ON BAITHI_KETQUA.MaDeThi = DETHI.MaDeThi
                    WHERE SINHVIEN.MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataBangDiem.DataSource = dt;
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

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataBangDiem);
        }
        private void ExportDataGridViewToExcel(DataGridView dataGridView)
        {
            try
            {
                // Kiểm tra xem DataGridView có dữ liệu không
                if (dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mở dialog để người dùng chọn nơi lưu file
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachDiemSinhVien.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            // Tạo một worksheet
                            var worksheet = wb.Worksheets.Add("DanhSach");

                            // Ghi tiêu đề cột từ DataGridView
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                                worksheet.Cell(1, i + 1).Style.Font.Bold = true; // In đậm tiêu đề
                                worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray; // Đặt màu nền
                            }

                            // Ghi dữ liệu từ các hàng của DataGridView
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                if (dataGridView.Rows[i].IsNewRow) continue; // Bỏ qua hàng mới (nếu có)

                                for (int j = 0; j < dataGridView.Columns.Count; j++)
                                {
                                    var cellValue = dataGridView.Rows[i].Cells[j].Value;
                                    if (cellValue != null)
                                    {
                                        // Kiểm tra nếu cột là ngày giờ (ví dụ: ThoiGianNop)
                                        if (dataGridView.Columns[j].HeaderText == "ThoiGianNop" && DateTime.TryParse(cellValue.ToString(), out DateTime dateValue))
                                        {
                                            worksheet.Cell(i + 2, j + 1).Value = dateValue;
                                            worksheet.Cell(i + 2, j + 1).Style.DateFormat.Format = "dd/mm/yyyy hh:mm:ss";
                                        }
                                        else
                                        {
                                            worksheet.Cell(i + 2, j + 1).Value = cellValue.ToString();
                                        }
                                    }
                                    else
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = "";
                                    }
                                }
                            }

                            // Tự động điều chỉnh kích thước cột
                            worksheet.Columns().AdjustToContents();

                            // Thêm viền cho toàn bộ bảng
                            var range = worksheet.Range(1, 1, dataGridView.Rows.Count + 1, dataGridView.Columns.Count);
                            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // Lưu file
                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bdcbDeThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelTenDeThi.Text = bdcbDeThi.GetItemText(bdcbDeThi.SelectedItem).ToUpper();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            g_maDeThi = bdcbDeThi.SelectedValue.ToString();
            LoadData_BangDiem();
            resetRadiobtn();
        }

        private void resetRadiobtn()
        {
            radioSortName.Checked = false;
            radioSortDiem.Checked = false;
        }
        private void radioSortName_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                    SINHVIEN.MaSinhVien,
                    SINHVIEN.HoTen,             
                    Diem,
                    BAITHI_KETQUA.ThoiGianNop          
                    FROM SINHVIEN
                    LEFT JOIN BAITHI_KETQUA ON SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien 
                    AND BAITHI_KETQUA.MaDeThi = @MaDeThi
                    LEFT JOIN DETHI ON BAITHI_KETQUA.MaDeThi = DETHI.MaDeThi
                    WHERE SINHVIEN.MaLopHoc = @MaLopHoc
                    ORDER BY 
                    SUBSTRING(
                        SINHVIEN.HoTen, 
                        LEN(SINHVIEN.HoTen) - CHARINDEX(' ', REVERSE(SINHVIEN.HoTen)) + 2, 
                        LEN(SINHVIEN.HoTen)
                    ) ASC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataBangDiem.DataSource = dt;
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

        private void radioSortDiem_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                    TOP 1 WITH TIES
                    SINHVIEN.MaSinhVien,
                    SINHVIEN.HoTen,             
                    Diem,
                    BAITHI_KETQUA.ThoiGianNop          
                    FROM SINHVIEN
                    LEFT JOIN BAITHI_KETQUA ON SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien 
                    AND BAITHI_KETQUA.MaDeThi = @MaDeThi
                    LEFT JOIN DETHI ON BAITHI_KETQUA.MaDeThi = DETHI.MaDeThi
                    WHERE SINHVIEN.MaLopHoc = @MaLopHoc
                    ORDER BY Diem DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataBangDiem.DataSource = dt;
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

        private void bdbtnTimKiem_Click(object sender, EventArgs e)
        {           
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                    SINHVIEN.MaSinhVien,
                    SINHVIEN.HoTen,             
                    Diem,
                    BAITHI_KETQUA.ThoiGianNop          
                    FROM SINHVIEN
                    LEFT JOIN BAITHI_KETQUA ON SINHVIEN.MaSinhVien = BAITHI_KETQUA.MaSinhVien 
                    AND BAITHI_KETQUA.MaDeThi = @MaDeThi
                    LEFT JOIN DETHI ON BAITHI_KETQUA.MaDeThi = DETHI.MaDeThi
                    WHERE SINHVIEN.MaLopHoc = @MaLopHoc
                    AND (@HoTen is null or SINHVIEN.HoTen like '%'+@HoTen+'%')
                    OR (@Diem is null or Diem like @Diem)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDeThi", g_maDeThi);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    if(string.IsNullOrEmpty(bdtxtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Diem", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HoTen", bdtxtTimKiem.Text);
                        cmd.Parameters.AddWithValue("@Diem", bdtxtTimKiem.Text);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataBangDiem.DataSource = dt;
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
