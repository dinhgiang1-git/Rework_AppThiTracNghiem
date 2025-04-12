using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop.flowLayout
{
    public partial class ucLop : UserControl
    {
        public event EventHandler<ucLop> OnFlowLopClick;
        public ucLop()
        {
            InitializeComponent();
            this.Margin = new Padding(left: 10, top: 10, right: 30, bottom: 8);
            this.Paint += flowLop_Paint; // Đăng ký sự kiện vẽ
            this.Click += flowLop_Click;
            foreach (Control c in this.Controls)
            {
                c.Click += flowLop_Click;
            }
        }
        public string MaLop
        {
            get => flowlopMaLop.Text;
            set => flowlopMaLop.Text = value;
        }

        public string TenLop
        {
            get => flowlopTenLop.Text;
            set => flowlopTenLop.Text = value;
        }

        public string SiSo
        {
            get => flowlopSiSo.Text;
            set => flowlopSiSo.Text = value;
        }

        private void flowLop_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trái
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Trên
                Color.DimGray, 2, ButtonBorderStyle.Solid,  // Phải
                Color.DimGray, 2, ButtonBorderStyle.Solid); // Dưới
        }

        private void flowLopXemChiTiet_Click(object sender, EventArgs e)
        {
            qllXemChiTiet xemchitiet = new qllXemChiTiet(this.flowlopMaLop.Text);
            xemchitiet.Show();
        }

        private void flowLop_Click(object sender, EventArgs e)
        {
            OnFlowLopClick?.Invoke(this, this);
        }
    }
}
