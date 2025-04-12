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

namespace Rework_AppThiTracNghiem.forms.QuanLyDeThi
{
    public partial class ucDeThi : UserControl
    {
        public event EventHandler<ucDeThi> onDeThi_Click;
        public ucDeThi()
        {
            InitializeComponent();
            dateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            dateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
            this.Margin = new Padding(left: 20, top: 10, right: 30, bottom: 8);
            this.Paint += ucDeThi_Paint; // Đăng ký sự kiện vẽ

            foreach (Control c in this.Controls)
            {
                c.Click += ucDeThi_Click;
            }

        }
        private void ucDeThi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trái
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trên
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Phải
                Color.DimGray, 2, ButtonBorderStyle.Solid); // Dưới
        }
        public string TenDeThi
        {
            get => labelTenDeThi.Text;
            set => labelTenDeThi.Text = value;
        }

        public string MaDeThi
        {
            get => labelMaDeThi.Text;
            set => labelMaDeThi.Text = value;
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

        private void ucDeThi_Click(object sender, EventArgs e)
        {
            onDeThi_Click?.Invoke(this, this);
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            XemChiTietDeThi xemchitietdethi = new XemChiTietDeThi(this.MaDeThi);
            xemchitietdethi.Show();
        }
    }
}
