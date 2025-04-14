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
    public partial class itemCauHoi : UserControl
    {
        private string g_macauhoi = "";
        private int cauHoiIndex;
        public event EventHandler<int> DapAnChanged;
        private string dapAnDung;
        private Dictionary<RadioButton, string> dapAnMapping = new Dictionary<RadioButton, string>();
        private Random random = new Random();
        public itemCauHoi()
        {
            InitializeComponent();
        }
        public void BindData(CauHoi cauhoi, int index)
        {
            txtDeBai.Text = $"Câu {index + 1}: {cauhoi.NoiDungCauHoi}";
            rdoChonA.Text = cauhoi.DapAnA;
            rdoChonB.Text = cauhoi.DapAnB;
            rdoChonC.Text = cauhoi.DapAnC;
            rdoChonD.Text = cauhoi.DapAnD;
            dapAnDung = cauhoi.DapAnDung;

            // Tạo danh sách đáp án và trộn ngẫu nhiên
            var dapAn = new List<(RadioButton radio, string value, string text)>
            {
                (rdoChonA, cauhoi.DapAnA, cauhoi.DapAnA),
                (rdoChonB, cauhoi.DapAnB, cauhoi.DapAnB),
                (rdoChonC, cauhoi.DapAnC, cauhoi.DapAnC),
                (rdoChonD, cauhoi.DapAnD, cauhoi.DapAnD)
            };

            // Trộn ngẫu nhiên danh sách đáp án
            //int n = dapAn.Count;
            //while (n > 1)
            //{
            //    n--;
            //    int k = random.Next(n + 1);
            //    var temp = dapAn[k];
            //    dapAn[k] = dapAn[n];
            //    dapAn[n] = temp;
            //}

            // Gán text cho các RadioButton theo thứ tự ngẫu nhiên
            dapAnMapping.Clear();
            for (int i = 0; i < dapAn.Count; i++)
            {
                var (radio, value, text) = dapAn[i];
                radio.Text = text;
                dapAnMapping[radio] = value;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDeBai_Click(object sender, EventArgs e)
        {

        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DapAnChanged?.Invoke(this, cauHoiIndex);
            }
        }
        public bool CheckDapAn()
            {
                foreach (RadioButton radio in new[] { rdoChonA, rdoChonB, rdoChonC, rdoChonD })
                {
                    if (radio.Checked)
                    {
                        return dapAnMapping[radio] == dapAnDung;
                    }
                }
                return false; // Không có đáp án nào được chọn
            }
    }
}
