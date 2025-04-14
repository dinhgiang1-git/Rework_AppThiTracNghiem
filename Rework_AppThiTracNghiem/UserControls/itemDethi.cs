using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.Class;
using Rework_AppThiTracNghiem.DataAccess;
using Rework_AppThiTracNghiem.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Rework_AppThiTracNghiem.UserControls
{
    public partial class itemDethi : UserControl
    {
        private string g_maDeThi = "";
        private string g_masinhvien = "";

        System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
        DateTime ngayDong = new DateTime();
        int duration = 0;
        public itemDethi()
        {
            InitializeComponent();

        }

        private void poisonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void dateNgaymo_Click(object sender, EventArgs e)
        {

        }

        public void BindData(DeThi dethi,string masinhvien)
        {
            g_maDeThi = dethi.MaDeThi;
            g_masinhvien = masinhvien;
            duration = (int)dethi.ThoiGianLam;
            tenDeThi.Text = dethi.TenDeThi;
            dateNgaymo.Text = dethi.NgayMo.ToString("dd/MM/yyyy");
            dateNgaydong.Text = dethi.NgayDong.ToString("dd/MM/yyyy");
            ngayDong = dethi.NgayDong;
            thoiGianLam.Text = dethi.ThoiGianLam + " phút";


        }
        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: Implement thi function
            if (DateTime.Now > ngayDong) { MessageBox.Show("Quá hạn làm bài"); }

            else
            {
                MessageBox.Show("Bắt đầu làm bài thi: " + g_maDeThi);
                LamDeThi lamdethi = new LamDeThi(g_maDeThi, g_masinhvien, duration);
                lamdethi.Show();
                
            }
        }
    }
}
