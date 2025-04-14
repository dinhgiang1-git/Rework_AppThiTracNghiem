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
        private Dictionary<int, string> dapAnDaChon = new Dictionary<int, string>();
        private int currentIndex;

        public itemCauHoi()
        {
            InitializeComponent();
            
        }

        public void BindData(CauHoi cauhoi, int index)
        {
            currentIndex = index;  // Store the current index
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
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rdo && rdo.Checked)
            {
                string selectedAnswer = "";
                if (rdo == rdoChonA) selectedAnswer = rdoChonA.Text;
                else if (rdo == rdoChonB) selectedAnswer = rdoChonB.Text;
                else if (rdo == rdoChonC) selectedAnswer = rdoChonC.Text;
                else if (rdo == rdoChonD) selectedAnswer = rdoChonD.Text;
                    
                if (!dapAnDaChon.ContainsKey(currentIndex))
                {
                    dapAnDaChon.Add(currentIndex, selectedAnswer);
                }
                else
                {
                    dapAnDaChon[currentIndex] = selectedAnswer;
                }
                DapAnChanged?.Invoke(this, currentIndex);
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


        // Add new method for displaying results
        public void BindDataKetQua(CauHoi cauHoi, int index, string selectedAnswer)
        {
            txtDeBai.Text = $"Câu {index + 1}: {cauHoi.NoiDungCauHoi}";

            rdoChonA.Text = cauHoi.DapAnA;
            rdoChonB.Text = cauHoi.DapAnB;
            rdoChonC.Text = cauHoi.DapAnC;
            rdoChonD.Text = cauHoi.DapAnD;
            dapAnDung = cauHoi.DapAnDung;

            // Set the selected answer
            if (rdoChonA.Text == selectedAnswer) rdoChonA.Checked = true;
            else if (rdoChonB.Text == selectedAnswer) rdoChonB.Checked = true;
            else if (rdoChonC.Text == selectedAnswer) rdoChonC.Checked = true;
            else if (rdoChonD.Text == selectedAnswer) rdoChonD.Checked = true;

            // Color the answers
            RadioButton selectedRdo = GetSelectedRadioButton();
            if (selectedRdo != null)
            {
                if (selectedRdo.Text == cauHoi.DapAnDung)
                {
                    selectedRdo.BackColor = Color.LightGreen;
                }
                else
                {
                    selectedRdo.BackColor = Color.LightPink;
                    // Highlight correct answer
                    foreach (RadioButton rdo in new[] { rdoChonA, rdoChonB, rdoChonC, rdoChonD })
                    {
                        if (rdo.Text == cauHoi.DapAnDung)
                        {
                            rdo.BackColor = Color.LightGreen;
                            break;
                        }
                    }
                }
            }

            // Disable all radio buttons
            rdoChonA.Enabled = false;
            rdoChonB.Enabled = false;
            rdoChonC.Enabled = false;
            rdoChonD.Enabled = false;
        }

        private RadioButton GetRadioButtonByAnswer(string answer)
        {
            switch (answer)
            {
                case "A": return rdoChonA;
                case "B": return rdoChonB;
                case "C": return rdoChonC;
                case "D": return rdoChonD;
                default: return null;
            }
        }

        private RadioButton GetSelectedRadioButton()
        {
            if (rdoChonA.Checked) return rdoChonA;
            if (rdoChonB.Checked) return rdoChonB;
            if (rdoChonC.Checked) return rdoChonC;
            if (rdoChonD.Checked) return rdoChonD;
            return null;
        }

        public string GetSelectedAnswer()
        {
            RadioButton selectedRdo = GetSelectedRadioButton();
            return selectedRdo?.Text ?? "";
        }
    }
}
