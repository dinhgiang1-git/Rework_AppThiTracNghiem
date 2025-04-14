using Microsoft.Data.SqlClient;
using Rework_AppThiTracNghiem.Class;
using Rework_AppThiTracNghiem.DataAccess;
using Rework_AppThiTracNghiem.UserControls;
using System;
using System.Configuration;

namespace Rework_AppThiTracNghiem.forms
{
    public partial class KetQuaThi : Form
    {
        private List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private Dictionary<int, string> dapAnDaChon = new Dictionary<int, string>();
        private Dictionary<int, Button> buttonCauHoi = new Dictionary<int, Button>();
        private int soCauDung = 0;
        // Change from string to double
        private double diem;

        public KetQuaThi(List<CauHoi> dsCauHoi, Dictionary<int, string> selectedAnswers, double finalScore)
        {
            InitializeComponent();
            danhSachCauHoi = dsCauHoi;
            dapAnDaChon = selectedAnswers;
            diem = finalScore;  // Remove ToString()
            btnThoat.Click += btnThoat_Click;
            BindData();
            lblMark.Text = $"Điểm: {diem:F2} ({soCauDung}/{danhSachCauHoi.Count} câu đúng)";
        }


        private void BindData()
        {
            // Create buttons
            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                Button btn = new Button
                {
                    Text = (i + 1).ToString(),
                    Width = 30,
                    Height = 30,
                    Margin = new Padding(5),
                    Tag = i
                };

                // Set button color based on correct/incorrect answer
                bool isCorrect = CheckDapAn(danhSachCauHoi[i], dapAnDaChon[i]);
                btn.BackColor = isCorrect ? Color.LightGreen : Color.LightPink;

                btn.Click += (s, e) =>
                {
                    int index = (int)((Button)s).Tag;
                    FlowCauHoi.ScrollControlIntoView(FlowCauHoi.Controls[index]);
                };
                buttonCauHoi.Add(i, btn);
                pnlDanhSachCau.Controls.Add(btn);
            }

            // Create question items
            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                var itemCauHoi = new itemCauHoi();
                itemCauHoi.BindDataKetQua(danhSachCauHoi[i], i, dapAnDaChon[i]);
                FlowCauHoi.Controls.Add(itemCauHoi);

                if (CheckDapAn(danhSachCauHoi[i], dapAnDaChon[i]))
                {
                    soCauDung++;
                }
            }
        }

        private bool CheckDapAn(CauHoi cauHoi, string dapAnChon)
        {
            return cauHoi.DapAnDung == dapAnChon;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
