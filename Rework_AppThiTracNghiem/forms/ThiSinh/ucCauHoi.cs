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
    public partial class ucCauHoi : UserControl
    {
        private string dapAnDung;
        private string dapAnChonDaChon;
        public ucCauHoi()
        {
            InitializeComponent();           
            this.Margin = new Padding(left: 20, top: 10, right: 30, bottom: 30);
            this.AutoScaleMode = AutoScaleMode.Font; // Hoặc AutoScaleMode.Dpi

            
        }
        public string DapAnDung
        {
            get => dapAnDung;
            set
            {
                dapAnDung = value;
                // Hiển thị đáp án đúng bằng cách đổi màu chữ (ví dụ: màu xanh lá)
                if (value == "A") radioNoiDungDapAnA.ForeColor = Color.Green;
                else if (value == "B") radioNoiDungDapAnB.ForeColor = Color.Green;
                else if (value == "C") radioNoiDungDapAnC.ForeColor = Color.Green;
                else if (value == "D") radioNoiDungDapAnD.ForeColor = Color.Green;
            }
        }
        public string DapAnChonDaChon
        {
            get => dapAnChonDaChon;
            set
            {
                dapAnChonDaChon = value;
                // Hiển thị đáp án đã chọn
                if (!string.IsNullOrEmpty(value))
                {
                    if (value == "A") radioNoiDungDapAnA.Checked = true;
                    else if (value == "B") radioNoiDungDapAnB.Checked = true;
                    else if (value == "C") radioNoiDungDapAnC.Checked = true;
                    else if (value == "D") radioNoiDungDapAnD.Checked = true;
                }
            }
        }
        public string MaCauHoi
        {
            get => labelMaCauHoi.Text;
            set => labelMaCauHoi.Text = value;
        }
        public string NoiDungCauHoi
        {
            get => labelNoiDungCauHoi.Text;
            set => labelNoiDungCauHoi.Text = value;
        }
        public string NoiDungDapAnA
        {
            get => radioNoiDungDapAnA.Text;
            set => radioNoiDungDapAnA.Text = value;
        }
        public string NoiDungDapAnB
        {
            get => radioNoiDungDapAnB.Text;
            set => radioNoiDungDapAnB.Text = value;
        }
        public string NoiDungDapAnC
        {
            get => radioNoiDungDapAnC.Text;
            set => radioNoiDungDapAnC.Text = value;
        }
        public string NoiDungDapAnD
        {
            get => radioNoiDungDapAnD.Text;
            set => radioNoiDungDapAnD.Text = value;
        }
        public bool DapAnA
        {
            get => radioNoiDungDapAnA.Checked;
            set => radioNoiDungDapAnA.Checked = value;
        }
        public bool DapAnB
        {
            get => radioNoiDungDapAnB.Checked;
            set => radioNoiDungDapAnB.Checked = value;
        }
        public bool DapAnC
        {
            get => radioNoiDungDapAnC.Checked;
            set => radioNoiDungDapAnC.Checked = value;
        }
        public bool DapAnD
        {
            get => radioNoiDungDapAnD.Checked;
            set => radioNoiDungDapAnD.Checked = value;
        }
        public string DapAnChon
        {
            get
            {
                if (radioNoiDungDapAnA.Checked) return "A";
                if (radioNoiDungDapAnB.Checked) return "B";
                if (radioNoiDungDapAnC.Checked) return "C";
                if (radioNoiDungDapAnD.Checked) return "D";
                return null; // Hoặc "" nếu chưa chọn đáp án
            }
        }
        public string Index
        {
            get => grouboxIndex.Text;
            set => grouboxIndex.Text = value;
        }
        public void SetAnswerColor(string selectedAnswer, bool isCorrect, string correctAnswer)
        {
            // Đổi màu chữ của đáp án đã chọn
            if (!string.IsNullOrEmpty(selectedAnswer))
            {
                if (selectedAnswer == "A")
                {
                    radioNoiDungDapAnA.ForeColor = isCorrect ? Color.Green : Color.Red;
                }
                else if (selectedAnswer == "B")
                {
                    radioNoiDungDapAnB.ForeColor = isCorrect ? Color.Green : Color.Red;
                }
                else if (selectedAnswer == "C")
                {
                    radioNoiDungDapAnC.ForeColor = isCorrect ? Color.Green : Color.Red;
                }
                else if (selectedAnswer == "D")
                {
                    radioNoiDungDapAnD.ForeColor = isCorrect ? Color.Green : Color.Red;
                }
            }

            // Đổi màu chữ của đáp án đúng thành màu xanh (nếu câu sai hoặc chưa chọn đáp án)
            if (!isCorrect || string.IsNullOrEmpty(selectedAnswer))
            {
                if (correctAnswer == "A") radioNoiDungDapAnA.ForeColor = Color.Green;
                else if (correctAnswer == "B") radioNoiDungDapAnB.ForeColor = Color.Green;
                else if (correctAnswer == "C") radioNoiDungDapAnC.ForeColor = Color.Green;
                else if (correctAnswer == "D") radioNoiDungDapAnD.ForeColor = Color.Green;
            }
        }

        public void DisableRadioButtons()
        {
            radioNoiDungDapAnA.Enabled = false;
            radioNoiDungDapAnB.Enabled = false;
            radioNoiDungDapAnC.Enabled = false;
            radioNoiDungDapAnD.Enabled = false;
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                // Gọi phương thức cập nhật trạng thái trong form cha
                if (this.ParentForm is BaiKiemTra parentForm)
                {
                    int questionNumber = int.Parse(this.Index.Replace("Câu: ", "").Trim());
                    parentForm.UpdateQuestionStatus(questionNumber, true);
                }
            }
        }

        private void radioNoiDungDapAnA_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_CheckedChanged(sender, e);
        }

        private void radioNoiDungDapAnB_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_CheckedChanged(sender, e);
        }

        private void radioNoiDungDapAnC_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_CheckedChanged(sender, e);
        }

        private void radioNoiDungDapAnD_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_CheckedChanged(sender, e);
        }
    }
}
