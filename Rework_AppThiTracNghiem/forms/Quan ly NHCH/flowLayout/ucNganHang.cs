using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rework_AppThiTracNghiem.forms.Quan_ly_lop.flowLayout;

namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.flowLayout
{
    public partial class ucNganHang : UserControl
    {
        public event EventHandler<ucNganHang> OnFlowNHCHClick;
        public ucNganHang()
        {
            InitializeComponent();
            this.Margin = new Padding(left: 30, top: 10, right: 30, bottom: 8);
            this.Paint += flowLop_Paint; // Đăng ký sự kiện vẽ
            foreach (Control c in this.Controls)
            {
                c.Click += ucNganHang_Click;
            }
        }
        public string TenNganHang
        {
            get => ucTenNganHang.Text;
            set => ucTenNganHang.Text = value;
        }

        public string SoLuongCauHoi
        {
            get => ucSoLuongCauHoi.Text;
            set => ucSoLuongCauHoi.Text = value;
        }

        public string MaNganHang
        {
            get => ucMaNganHang.Text;
            set => ucMaNganHang.Text = value;
        }

        private void flowLop_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trái
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trên
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Phải
                Color.DimGray, 2, ButtonBorderStyle.Solid); // Dưới
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            nhchXemChiTiet xemchitiet = new nhchXemChiTiet(this.ucMaNganHang.Text, this.ucTenNganHang.Text);
            xemchitiet.Show();
        }

        private void ucNganHang_Click(object sender, EventArgs e)
        {
            OnFlowNHCHClick?.Invoke(this, this);
        }
    }
}
