using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.flowLayout;

namespace Rework_AppThiTracNghiem.forms.BangDiem
{
    public partial class ucbdDETHI : UserControl
    {
        public event EventHandler<ucbdDETHI> onBANGDIEM_Click;
        public ucbdDETHI()
        {
            InitializeComponent();
            dateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            dateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
            this.Margin = new Padding(left: 20, top: 10, right: 30, bottom: 8);
            this.Paint += ucDeThi_Paint; // Đăng ký sự kiện vẽ

            foreach (Control c in this.Controls)
            {
                c.Click += ucbdDETHI_Click;
            }
        }

        private void ucbdDETHI_Click(object sender, EventArgs e)
        {
            onBANGDIEM_Click?.Invoke(this, this);
        }

        private void ucDeThi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trái
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trên
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Phải
                Color.DimGray, 2, ButtonBorderStyle.Solid); // Dưới
        }

        private void btnxemchitiet_Click(object sender, EventArgs e)
        {
            bdXemChiTiet bdXemChiTiet = new bdXemChiTiet(this.MaBaiThi);
            bdXemChiTiet.Show();
        }

        public string MaBaiThi
        {
            get => labelMaBaiThi.Text;
            set => labelMaBaiThi.Text = value;
        }
        public string TenBaiThi
        {
            get => labelTenDeThi.Text;
            set => labelTenDeThi.Text = value;
        }
        public DateTime NgayBatDau
        {
            get => dateNgayBatDau.Value;
            set => dateNgayBatDau.Value = value;
        }
        public DateTime NgayKetThuc
        {
            get => dateNgayKetThuc.Value;
            set => dateNgayKetThuc.Value = value;
        }
        public string Status
        {
            get => labelstatus.Text;
            set => labelstatus.Text = value;
        }
        public string Soluongsinhviendalam
        {
            get => labelsoluongsinhvien.Text;
            set => labelsoluongsinhvien.Text = value;
        }
    }
}
