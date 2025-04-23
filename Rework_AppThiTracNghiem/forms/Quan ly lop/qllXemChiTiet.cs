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
using Rework_AppThiTracNghiem.forms.Quan_ly_lop;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop.Thanh_vien_lop;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class qllXemChiTiet : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maLop = "";
        string g_maThanhVien = "";
        string g_tenThanhVien = "";
        public qllXemChiTiet(string maLop)
        {
            InitializeComponent();
            g_maLop = maLop;
            qllgroupbox.Text = "Chi tiết lớp " + g_maLop;
            LoadData_ThanhVien();
        }

        private void LoadData_ThanhVien()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Select MaSinhVien, HoTen, GioiTinh, NgaySinh from SINHVIEN where MaLopHoc = @MaLopHoc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataThanhVien.DataSource = dt;
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
        private void qllbtnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void qllbtnSuaThanhVien_Click(object sender, EventArgs e)
        {

        }
        private void dataThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataThanhVien.Rows[e.RowIndex];
                g_maThanhVien = row.Cells["MaSinhVien"].Value.ToString();
                g_tenThanhVien = row.Cells["HoTen"].Value.ToString();
            }
        }

        private void qllbtnXoaThanhVien_Click(object sender, EventArgs e)
        {

        }
        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            // Mở dialog để chọn file Excel
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string maLopHoc = g_maLop;

                if (string.IsNullOrEmpty(maLopHoc))
                {
                    MessageBox.Show("Vui lòng nhập mã lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ImportSinhVienTuExcel(ofd.FileName, maLopHoc);
            }
        }

        private void ImportSinhVienTuExcel(string filePath, string maLopHoc)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var table = result.Tables[0];

                        // Kiểm tra định dạng file Excel
                        if (table.Rows[0][0].ToString() != "MaSV" ||
                            table.Rows[0][1].ToString() != "HOTEN" ||
                            table.Rows[0][2].ToString() != "GIOITINH" ||
                            table.Rows[0][3].ToString() != "NgaySinh" ||
                            table.Rows[0][4].ToString() != "QUEQUAN")
                        {
                            throw new Exception("File Excel không đúng định dạng! Vui lòng kiểm tra tiêu đề cột.");
                        }

                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();

                            // Bắt đầu từ hàng thứ 2 (hàng 1 là tiêu đề)
                            for (int i = 1; i < table.Rows.Count; i++)
                            {
                                string maSinhVien = table.Rows[i][0]?.ToString()?.Trim() ?? "";
                                string hoTen = table.Rows[i][1]?.ToString()?.Trim() ?? "";
                                string gioiTinh = table.Rows[i][2]?.ToString()?.Trim() ?? "";
                                string ngaySinhStr = table.Rows[i][3]?.ToString()?.Trim() ?? "";
                                string queQuan = table.Rows[i][4]?.ToString()?.Trim() ?? "";

                                // Kiểm tra dữ liệu bắt buộc
                                if (string.IsNullOrEmpty(maSinhVien) || string.IsNullOrEmpty(hoTen))
                                {
                                    continue; // Bỏ qua hàng nếu thiếu thông tin quan trọng
                                }

                                // Chuyển đổi ngày sinh
                                if (!DateTime.TryParse(ngaySinhStr, out DateTime ngaySinh))
                                {
                                    MessageBox.Show($"Dòng {i + 1}: Ngày sinh không hợp lệ: {ngaySinhStr}");
                                    continue;
                                }

                                // Kiểm tra giới tính hợp lệ
                                if (!new[] { "Nam", "Nữ", "Nu" }.Contains(gioiTinh, StringComparer.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show($"Dòng {i + 1}: Giới tính không hợp lệ (phải là Nam hoặc Nữ)");
                                    continue;
                                }
                                // Chuẩn hóa giới tính
                                gioiTinh = gioiTinh.Equals("Nu", StringComparison.OrdinalIgnoreCase) ? "Nữ" : gioiTinh;

                                // Mật khẩu mặc định là "1"
                                string matKhau = "1";

                                // Kiểm tra xem sinh viên đã tồn tại chưa
                                string checkQuery = "SELECT COUNT(*) FROM SINHVIEN WHERE MaSinhVien = @MaSinhVien";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                                checkCmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                                int count = (int)checkCmd.ExecuteScalar();

                                if (count > 0)
                                {
                                    // Cập nhật thông tin nếu sinh viên đã tồn tại
                                    string updateQuery = @"
                                UPDATE SINHVIEN 
                                SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, 
                                    QueQuan = @QueQuan, MaLopHoc = @MaLopHoc, UpdateAt = @UpdateAt
                                WHERE MaSinhVien = @MaSinhVien";
                                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                                    updateCmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                                    updateCmd.Parameters.AddWithValue("@HoTen", hoTen);
                                    updateCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                    updateCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                    updateCmd.Parameters.AddWithValue("@QueQuan", queQuan);
                                    updateCmd.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                                    updateCmd.Parameters.AddWithValue("@UpdateAt", DateTime.Now);
                                    updateCmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    // Thêm sinh viên mới
                                    string insertQuery = @"
                                INSERT INTO SINHVIEN (MaSinhVien, HoTen, GioiTinh, NgaySinh, QueQuan, MatKhau, MaLopHoc, CreateAt, UpdateAt)
                                VALUES (@MaSinhVien, @HoTen, @GioiTinh, @NgaySinh, @QueQuan, @MatKhau, @MaLopHoc, @CreateAt, @UpdateAt)";
                                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                                    insertCmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                                    insertCmd.Parameters.AddWithValue("@HoTen", hoTen);
                                    insertCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                    insertCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                    insertCmd.Parameters.AddWithValue("@QueQuan", queQuan);
                                    insertCmd.Parameters.AddWithValue("@MatKhau", matKhau);
                                    insertCmd.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                                    insertCmd.Parameters.AddWithValue("@CreateAt", DateTime.Now);
                                    insertCmd.Parameters.AddWithValue("@UpdateAt", DateTime.Now);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show($"Đã import thành công {table.Rows.Count - 1} sinh viên!");
                            // Gọi hàm để tải lại dữ liệu nếu cần (tương tự LoadData_CauHoi trong ví dụ nhập câu hỏi)
                            // LoadData_SinhVien();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi import file: " + ex.Message);
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(dataThanhVien);
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

        private void sdtbtnThemDong_Click(object sender, EventArgs e)
        {
            qllThemThanhVien themthanhvien = new qllThemThanhVien(g_maLop);
            themthanhvien.Show();
        }

        private void sdtbtnHuy_Click(object sender, EventArgs e)
        {
            qllSuaThanhVien suathanhvien = new qllSuaThanhVien(g_maThanhVien, g_maLop);
            suathanhvien.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(g_maThanhVien))
            {
                MessageBox.Show("Vui lòng chọn một thành viên để xoá!");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn xoá " + g_tenThanhVien + " ?.", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            //Xoá
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = "Delete SINHVIEN where MaSinhVien = @MaSinhVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSinhVien", g_maThanhVien);
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Xoá " + g_tenThanhVien + " thành công!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadData_ThanhVien();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    string query = @"Select MaSinhVien, HoTen, GioiTinh, NgaySinh 
                    from SINHVIEN 
                    where MaLopHoc = @MaLopHoc
                    and (@HoTen is null or HoTen like '%'+@HoTen+'%')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLopHoc", g_maLop);
                    if(string.IsNullOrEmpty(txtTimKiem.Text))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txtTimKiem.Text);
                    }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataThanhVien.DataSource = dt;
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
