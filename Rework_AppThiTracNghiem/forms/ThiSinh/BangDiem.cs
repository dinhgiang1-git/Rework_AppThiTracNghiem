using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    public partial class BangDiem : UserControl
    {
        string g_maSinhVien = "";
        public BangDiem(string maSinhVien)
        {
            InitializeComponent();
            dateThoiGianNopBai.CustomFormat = "MM/dd/yyyy HH:mm";
            this.Paint += ucDeThi_Paint; // Đăng ký sự kiện vẽ
            this.Margin = new Padding(left: 30, top: 10, right: 30, bottom: 8);
            g_maSinhVien = maSinhVien;

        }
        private void ucDeThi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trái
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trên
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Phải
                Color.DimGray, 2, ButtonBorderStyle.Solid); // Dưới
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            XemLaiBaiKiemTra xemlaibaikiemtra = new XemLaiBaiKiemTra(this.MaDeThi, g_maSinhVien);
            xemlaibaikiemtra.Show();
        }

        public string TenBaiThi
        {
            get => labelTenBaiThi.Text;
            set => labelTenBaiThi.Text = value;
        }
        public string Diem
        {
            get => labelDiem.Text;
            set => labelDiem.Text = value;
        }
        public DateTime ThoiGianNopBai
        {
            get => dateThoiGianNopBai.Value;
            set => dateThoiGianNopBai.Value = value;
        }
        public string MaDeThi
        {
            get => labelMaDeThi.Text;
            set => labelMaDeThi.Text= value;
        }
    }
}
