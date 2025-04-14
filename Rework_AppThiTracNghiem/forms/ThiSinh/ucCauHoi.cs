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
        public ucCauHoi()
        {
            InitializeComponent();
            this.Margin = new Padding(left: 20, top: 10, right: 30, bottom: 30);
            this.AutoScaleMode = AutoScaleMode.Font; // Hoặc AutoScaleMode.Dpi

            
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
