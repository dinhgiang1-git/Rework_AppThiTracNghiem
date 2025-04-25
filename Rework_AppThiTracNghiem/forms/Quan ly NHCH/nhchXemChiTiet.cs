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
using ExcelDataReader;
using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.Câu_hỏi;

namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH
{
    public partial class nhchXemChiTiet : Form
    {
        string strConn = DBHelpercs.strConn;
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
                    string query = "Select MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, DangCauHoi from CAUHOI where MaNganHang = @MaNganHang";
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


        private void dataCAUHOI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataCAUHOI.Rows[e.RowIndex];
                g_maCauHoi = row.Cells["MaCauHoi"].Value.ToString();
                g_noiDungCauHoi = row.Cells["NoiDungCauHoi"].Value.ToString();
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            LoadData_CauHoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemCauHoi themcauhoithucong = new ThemCauHoi(g_maNganHang, g_tenNganHang);
            themcauhoithucong.Show();
        }

        private void sdtbtnHuy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maCauHoi))
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi để sửa!");
                return;
            }
            SuaCauHoi suacauhoi = new SuaCauHoi(g_maNganHang, g_tenNganHang, g_maCauHoi);
            suacauhoi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    }
                    else
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
        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet();
                            var table = result.Tables[0];

                            // Tạo từ điển ánh xạ level
                            var levelMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                                {
                                    {"dễ", "Dễ"},
                                    {"trung bình", "Trung bình"},
                                    {"trungbinh", "Trung bình"},
                                    {"trung binh", "Trung bình"},
                                    {"khó", "Khó"},
                                    {"kho", "Khó"}
                                };

                            for (int i = 1; i < table.Rows.Count; i++)
                            {
                                string noiDung = table.Rows[i][0]?.ToString()?.Trim() ?? "";
                                string dapAnA = table.Rows[i][1]?.ToString()?.Trim() ?? "";
                                string dapAnB = table.Rows[i][2]?.ToString()?.Trim() ?? "";
                                string dapAnC = table.Rows[i][3]?.ToString()?.Trim() ?? "";
                                string dapAnD = table.Rows[i][4]?.ToString()?.Trim() ?? "";
                                string dapAnDung = table.Rows[i][5]?.ToString()?.Trim()?.ToUpper() ?? "";
                                string level = table.Rows[i][6]?.ToString()?.Trim() ?? "";

                                // Kiểm tra dữ liệu bắt buộc
                                if (string.IsNullOrEmpty(noiDung) || string.IsNullOrEmpty(dapAnA) ||
                                    string.IsNullOrEmpty(dapAnB) || string.IsNullOrEmpty(dapAnC) ||
                                    string.IsNullOrEmpty(dapAnD) || string.IsNullOrEmpty(dapAnDung))
                                {
                                    continue;
                                }

                                // Kiểm tra đáp án đúng
                                if (!new[] { "A", "B", "C", "D" }.Contains(dapAnDung))
                                {
                                    MessageBox.Show($"Dòng {i + 1}: Đáp án đúng không hợp lệ (phải là A, B, C hoặc D)");
                                    continue;
                                }

                                // Chuẩn hóa level
                                string normalizedLevel = levelMapping.TryGetValue(level, out var mappedLevel)
                                    ? mappedLevel
                                    : "Không";

                                using (SqlConnection conn = new SqlConnection(strConn))
                                {
                                    conn.Open();
                                    string query = @"INSERT INTO CAUHOI 
                                           (NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, 
                                            DapAnDung, DangCauHoi, MaNganHang) 
                                           VALUES 
                                           (@NoiDung, @A, @B, @C, @D, @Dung, @DangCauHoi, @MaNganHang)";

                                    SqlCommand cmd = new SqlCommand(query, conn);
                                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                                    cmd.Parameters.AddWithValue("@A", dapAnA);
                                    cmd.Parameters.AddWithValue("@B", dapAnB);
                                    cmd.Parameters.AddWithValue("@C", dapAnC);
                                    cmd.Parameters.AddWithValue("@D", dapAnD);
                                    cmd.Parameters.AddWithValue("@Dung", dapAnDung);
                                    cmd.Parameters.AddWithValue("@DangCauHoi", normalizedLevel);
                                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show($"Đã import thành công {table.Rows.Count - 1} câu hỏi!");
                            LoadData_CauHoi();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi import file: " + ex.Message);
                }
            }
        }    
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataCAUHOI);
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
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DanhSachCauHoi.xlsx" })
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
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"Select MaCauHoi, NoiDungCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, DangCauHoi 
                    from CAUHOI 
                    where MaNganHang = @MaNganHang
                    and (@NoiDungCauHoi is null or NoiDungCauHoi like '%'+@NoiDungCauHoi+'%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNganHang", g_maNganHang);
                    if(string.IsNullOrEmpty(txtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@NoiDungCauHoi",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NoiDungCauHoi", txtTimKiem.Text);
                    }
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
    }
}
