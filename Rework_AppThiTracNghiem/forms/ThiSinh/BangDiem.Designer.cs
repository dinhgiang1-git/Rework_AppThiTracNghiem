namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    partial class BangDiem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTenBaiThi = new Label();
            labelDiem = new Label();
            btnXemChiTiet = new Button();
            dateThoiGianNopBai = new DateTimePicker();
            label3 = new Label();
            labelMaDeThi = new Label();
            SuspendLayout();
            // 
            // labelTenBaiThi
            // 
            labelTenBaiThi.AutoSize = true;
            labelTenBaiThi.Font = new Font("SF Mono", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenBaiThi.Location = new Point(3, 17);
            labelTenBaiThi.Name = "labelTenBaiThi";
            labelTenBaiThi.Size = new Size(131, 21);
            labelTenBaiThi.TabIndex = 0;
            labelTenBaiThi.Text = "Tên bài thi";
            // 
            // labelDiem
            // 
            labelDiem.AutoSize = true;
            labelDiem.Location = new Point(3, 66);
            labelDiem.Name = "labelDiem";
            labelDiem.Size = new Size(89, 18);
            labelDiem.TabIndex = 1;
            labelDiem.Text = "Điểm 7.0đ";
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.FlatStyle = FlatStyle.Popup;
            btnXemChiTiet.Location = new Point(946, 58);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(157, 35);
            btnXemChiTiet.TabIndex = 2;
            btnXemChiTiet.Text = "Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = true;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // dateThoiGianNopBai
            // 
            dateThoiGianNopBai.Format = DateTimePickerFormat.Custom;
            dateThoiGianNopBai.Location = new Point(478, 61);
            dateThoiGianNopBai.Name = "dateThoiGianNopBai";
            dateThoiGianNopBai.Size = new Size(221, 25);
            dateThoiGianNopBai.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(302, 66);
            label3.Name = "label3";
            label3.Size = new Size(170, 18);
            label3.TabIndex = 4;
            label3.Text = "Thời gian nộp bài:";
            // 
            // labelMaDeThi
            // 
            labelMaDeThi.AutoSize = true;
            labelMaDeThi.Location = new Point(878, 75);
            labelMaDeThi.Name = "labelMaDeThi";
            labelMaDeThi.Size = new Size(62, 18);
            labelMaDeThi.TabIndex = 5;
            labelMaDeThi.Text = "label1";
            labelMaDeThi.Visible = false;
            // 
            // BangDiem
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelMaDeThi);
            Controls.Add(label3);
            Controls.Add(dateThoiGianNopBai);
            Controls.Add(btnXemChiTiet);
            Controls.Add(labelDiem);
            Controls.Add(labelTenBaiThi);
            Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "BangDiem";
            Size = new Size(1127, 103);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenBaiThi;
        private Label labelDiem;
        private Button btnXemChiTiet;
        private DateTimePicker dateThoiGianNopBai;
        private Label label3;
        private Label labelMaDeThi;
    }
}
