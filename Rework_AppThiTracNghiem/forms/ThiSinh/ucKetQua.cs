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
    public partial class ucKetQua : UserControl
    {
        string g_maDeThi = "";
        string g_maSinhVien = "";
        public ucKetQua(string maDeThi, string maSinhVien)
        {
            InitializeComponent();
            g_maDeThi = maDeThi;
            g_maSinhVien = maSinhVien;
        }
        public string TenBaiThi
        {
            get => labelTenBaiThi.Text;
            set => labelTenBaiThi.Text = value;
        }
        public string SoCauTraLoiDung
        {
            get => labelSoCauTraLoiDung.Text;
            set => labelSoCauTraLoiDung.Text = value;
        }
        public string DiemSo
        {
            get => labelDiemSo.Text;
            set => labelDiemSo.Text = value;
        }

        private void btnXemLaiBaiLam_Click(object sender, EventArgs e)
        {
            XemLaiBaiKiemTra xemlaibaikiemtra = new XemLaiBaiKiemTra(g_maDeThi, g_maSinhVien);
            xemlaibaikiemtra.Show();
        }
    }
}
