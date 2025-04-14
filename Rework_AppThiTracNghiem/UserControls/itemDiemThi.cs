using Rework_AppThiTracNghiem.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rework_AppThiTracNghiem.UserControls
{
    public partial class itemDiemThi : UserControl
    {
        public itemDiemThi()
        {
            InitializeComponent();
        }
        public void BindData(KetQua ketqua)
        {
            lblTenbaithi.Text = ketqua.TenDeThi;
            lblMark.Text = ketqua.Diem.ToString();
            dateNgayLam.Text = ketqua.NgayThi.ToString();
        }
    }
}
