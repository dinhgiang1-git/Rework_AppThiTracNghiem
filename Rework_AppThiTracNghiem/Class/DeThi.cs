using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.DataAccess;
using Rework_AppThiTracNghiem.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rework_AppThiTracNghiem.Class
{
    public class DeThi
    {
        public string MaDeThi { get; set; }
        public string TenDeThi { get; set; }
        public DateTime NgayMo { get; set; }
        public DateTime NgayDong { get; set; }
        public int ThoiGianLam { get; set; }
        public static DeThi GetDethi(string maDeThi){
            try
            {
                string query = @"SELECT 
                                D.TenDeThi,
                                D.ThoiGianLam,
                                D.NgayMo,
                                D.NgayDong,
                               FROM DETHI D
                               WHERE D.MaDeThi = @MaDeThi"
                ;

                using (SqlDataReader reader = DatabaseHelper.ExecuteReader(query,
                    new SqlParameter("@MaDeThi", maDeThi)))
                {
                    if (reader.Read())
                    {
                        return new DeThi
                        {
                            MaDeThi = maDeThi,
                            TenDeThi = reader["TenDeThi"].ToString(),
                            ThoiGianLam = Convert.ToInt32(reader["ThoiGianLam"]),
                            NgayMo = Convert.ToDateTime(reader["NgayMo"]),
                            NgayDong = Convert.ToDateTime(reader["NgayDong"])
                        };
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
