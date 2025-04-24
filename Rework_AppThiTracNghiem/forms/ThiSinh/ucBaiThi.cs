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
using Rework_AppThiTracNghiem.forms.QuanLyDeThi;

namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    public partial class ucBaiThi : UserControl
    {
        public event EventHandler onDeThi_Click;
        string g_maSinhVien = "";
        string strConn = DBHelpercs.strConn;
        public ucBaiThi(string maSinhVien)
        {
            InitializeComponent();
            g_maSinhVien = maSinhVien;
            dateNgayBatDau.CustomFormat = "MM/dd/yyyy HH:mm";
            dateNgayKetThuc.CustomFormat = "MM/dd/yyyy HH:mm";
            this.Margin = new Padding(left: 20, top: 10, right: 30, bottom: 8);
            this.Paint += ucDeThi_Paint; // Đăng ký sự kiện vẽ

            foreach (Control c in this.Controls)
            {
                c.Click += ucBaiThi_Click;
            }
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
        public string ThoiLuong
        {
            get => labelThoiLuong.Text;
            set => labelThoiLuong.Text = value;
        }
        public string SoCau
        {
            get => labelSoCau.Text;
            set => labelSoCau.Text = value;
        }
        private void ucDeThi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trái
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trên
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Phải
                Color.DimGray, 2, ButtonBorderStyle.Solid); // Dưới
        }

        private void ucBaiThi_Click(object sender, EventArgs e)
        {
            onDeThi_Click?.Invoke(this, EventArgs.Empty);
        }

        private void btnLamBai_Click(object sender, EventArgs e)
        {
            DateTime check = DateTime.Now;

            //if (check < this.NgayBatDau)
            //{
            //    MessageBox.Show("Chưa tới thời gian làm bài vui lòng quay lại sau!");
            //    return;
            //}

            //if (check > this.NgayKetThuc)
            //{
            //    MessageBox.Show("Đề thi này đã quá hạn!");
            //    return;
            //}

            BaiKiemTra baikiemtra = new BaiKiemTra(g_maSinhVien, this.MaBaiThi);
            baikiemtra.Show();
        }
    }
}
