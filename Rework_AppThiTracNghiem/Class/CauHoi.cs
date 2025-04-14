using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.DataAccess;
using System;
using System.Collections.Generic;

namespace Rework_AppThiTracNghiem.Class
{
    public class CauHoi
    {
        public int MaCauHoi { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string DapAnA { get; set; }
        public string DapAnB { get; set; }
        public string DapAnC { get; set; }
        public string DapAnD { get; set; }
        public string DapAnDung { get; set; }

        public string DangCauHoi { get; set; }
        public int MaNganHang { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        // Lấy danh sách câu hỏi chưa được thêm vào đề thi
        public static List<CauHoi> GetCauHoiChuaChon(string maDeThi)
        {
            string query = @"SELECT CH.* 
                           FROM CAUHOI CH
                           WHERE CH.MaCauHoi NOT IN 
                           (SELECT MaCauHoi FROM CAUHOIDETHI WHERE MaDeThi = @MaDeThi)";

            List<CauHoi> dsCauHoi = new List<CauHoi>();
            using (SqlDataReader reader = DatabaseHelper.ExecuteReader(query,
                new SqlParameter("@MaDeThi", maDeThi)))
            {
                while (reader.Read())
                {
                    dsCauHoi.Add(new CauHoi
                    {
                        MaCauHoi = Convert.ToInt32(reader["MaCauHoi"]),
                        NoiDungCauHoi = reader["NoiDungCauHoi"].ToString(),
                        DapAnA = reader["DapAnA"].ToString(),
                        DapAnB = reader["DapAnB"].ToString(),
                        DapAnC = reader["DapAnC"].ToString(),
                        DapAnD = reader["DapAnD"].ToString(),
                        DapAnDung = reader["DapAnDung"].ToString(),
                        MaNganHang = Convert.ToInt32(reader["MaNganHang"]),
                        CreateAt = Convert.ToDateTime(reader["CreateAt"])
                    });
                }
            }
            return dsCauHoi;
        }

        // Lấy danh sách câu hỏi của một đề thi
        public static List<CauHoi> GetCauHoiCuaDeThi(string maDeThi)
        {
            string query = @"SELECT CH.*, CHD.ThuTu 
                           FROM CAUHOI CH
                           INNER JOIN CAUHOIDETHI CHD ON CH.MaCauHoi = CHD.MaCauHoi
                           WHERE CHD.MaDeThi = @MaDeThi
                           ORDER BY CHD.ThuTu";

            List<CauHoi> dsCauHoi = new List<CauHoi>();
            using (SqlDataReader reader = DatabaseHelper.ExecuteReader(query,
                new SqlParameter("@MaDeThi", maDeThi)))
            {
                while (reader.Read())
                {
                    dsCauHoi.Add(new CauHoi
                    {
                        MaCauHoi = Convert.ToInt32(reader["MaCauHoi"]),
                        NoiDungCauHoi = reader["NoiDungCauHoi"].ToString(),
                        DapAnA = reader["DapAnA"].ToString(),
                        DapAnB = reader["DapAnB"].ToString(),
                        DapAnC = reader["DapAnC"].ToString(),
                        DapAnD = reader["DapAnD"].ToString(),
                        DapAnDung = reader["DapAnDung"].ToString(),
                        MaNganHang = Convert.ToInt32(reader["MaNganHang"]),
                        CreateAt = Convert.ToDateTime(reader["CreateAt"])
                    });
                }
            }
            return dsCauHoi;
        }

        // Thêm câu hỏi vào đề thi
        public static bool ThemVaoDeThi(string maDeThi, int maCauHoi, int thuTu)
        {
            string query = @"INSERT INTO CAUHOIDETHI (MaDeThi, MaCauHoi, ThuTu) 
                           VALUES (@MaDeThi, @MaCauHoi, @ThuTu)";

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query,
                    new SqlParameter("@MaDeThi", maDeThi),
                    new SqlParameter("@MaCauHoi", maCauHoi),
                    new SqlParameter("@ThuTu", thuTu));
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static CauHoi GetCauHoi(string maDeThi)
        {
            try
            {
                string query = @"SELECT 
                                D.TenDeThi,
                                D.ThoiGianLamBai,
                                D.NgayMo,
                                D.NgayDong,
                                L.TenLopHoc,
                                (SELECT COUNT(*) FROM CAUHOIDETHI WHERE MaDeThi = @MaDeThi) as SoLuongCauHoi
                               FROM CauHoi C
                               INNER JOIN LOPHOC L ON D.MaLopHoc = L.MaLopHoc
                               WHERE D.MaDeThi = @MaDeThi"
                ;

                using (SqlDataReader reader = DatabaseHelper.ExecuteReader(query,
                    new SqlParameter("@MaDeThi", maDeThi)))
                {
                    if (reader.Read())
                    {
                        //return new CauHoi
                        //{
                        //    MaDeThi = maDeThi,
                        //    TenDeThi = reader["TenDeThi"].ToString(),
                        //    ThoiGianLamBai = Convert.ToInt32(reader["ThoiGianLamBai"]),
                        //    NgayMo = Convert.ToDateTime(reader["NgayMo"]),
                        //    NgayDong = Convert.ToDateTime(reader["NgayDong"]),
                        //    TenLopHoc = reader["TenLopHoc"].ToString(),
                        //    SoLuongCauHoi = Convert.ToInt32(reader["SoLuongCauHoi"])
                        //};
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }
    }
}