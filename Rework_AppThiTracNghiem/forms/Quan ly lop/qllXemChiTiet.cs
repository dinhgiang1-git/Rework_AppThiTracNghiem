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

namespace Rework_AppThiTracNghiem.forms
{
    public partial class qllXemChiTiet : Form
    {
        string strConn = "Server=DINHDUCGIANG;Database=Rework_AppThiTracNghiem;Integrated Security=True;TrustServerCertificate=true;";
        string g_maLop = "";
        public qllXemChiTiet(string maLop)
        {
            InitializeComponent();
            g_maLop = maLop;
            qllgroupbox.Text = "Chi tiết lớp " + g_maLop;
        }

        private void LoadData_ThanhVien()
        {
            using(SqlConnection conn = new SqlConnection(strConn))
            {

            }
        }
    }
}
