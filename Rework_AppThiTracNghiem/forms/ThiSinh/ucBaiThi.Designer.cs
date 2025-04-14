namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    partial class ucBaiThi
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
            labelTenDeThi = new Label();
            dateNgayBatDau = new DateTimePicker();
            dateNgayKetThuc = new DateTimePicker();
            label2 = new Label();
            labelSoCau = new Label();
            labelThoiLuong = new Label();
            btnLamBai = new Button();
            labelMaBaiThi = new Label();
            SuspendLayout();
            // 
            // labelTenDeThi
            // 
            labelTenDeThi.AutoSize = true;
            labelTenDeThi.Location = new Point(17, 15);
            labelTenDeThi.Margin = new Padding(4, 0, 4, 0);
            labelTenDeThi.Name = "labelTenDeThi";
            labelTenDeThi.Size = new Size(69, 19);
            labelTenDeThi.TabIndex = 0;
            labelTenDeThi.Text = "label1";
            // 
            // dateNgayBatDau
            // 
            dateNgayBatDau.Format = DateTimePickerFormat.Custom;
            dateNgayBatDau.Location = new Point(17, 60);
            dateNgayBatDau.Name = "dateNgayBatDau";
            dateNgayBatDau.Size = new Size(221, 27);
            dateNgayBatDau.TabIndex = 2;
            // 
            // dateNgayKetThuc
            // 
            dateNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dateNgayKetThuc.Location = new Point(290, 60);
            dateNgayKetThuc.Name = "dateNgayKetThuc";
            dateNgayKetThuc.Size = new Size(221, 27);
            dateNgayKetThuc.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(19, 19);
            label2.TabIndex = 4;
            label2.Text = "-";
            // 
            // labelSoCau
            // 
            labelSoCau.AutoSize = true;
            labelSoCau.Location = new Point(517, 68);
            labelSoCau.Name = "labelSoCau";
            labelSoCau.Size = new Size(69, 19);
            labelSoCau.TabIndex = 5;
            labelSoCau.Text = "label3";
            // 
            // labelThoiLuong
            // 
            labelThoiLuong.AutoSize = true;
            labelThoiLuong.Location = new Point(814, 68);
            labelThoiLuong.Name = "labelThoiLuong";
            labelThoiLuong.Size = new Size(69, 19);
            labelThoiLuong.TabIndex = 6;
            labelThoiLuong.Text = "label3";
            // 
            // btnLamBai
            // 
            btnLamBai.FlatStyle = FlatStyle.Popup;
            btnLamBai.Location = new Point(946, 53);
            btnLamBai.Name = "btnLamBai";
            btnLamBai.Size = new Size(164, 34);
            btnLamBai.TabIndex = 7;
            btnLamBai.Text = "Làm bài";
            btnLamBai.UseVisualStyleBackColor = true;
            btnLamBai.Click += btnLamBai_Click;
            // 
            // labelMaBaiThi
            // 
            labelMaBaiThi.AutoSize = true;
            labelMaBaiThi.Location = new Point(946, 31);
            labelMaBaiThi.Name = "labelMaBaiThi";
            labelMaBaiThi.Size = new Size(69, 19);
            labelMaBaiThi.TabIndex = 8;
            labelMaBaiThi.Text = "label1";
            labelMaBaiThi.Visible = false;
            // 
            // ucBaiThi
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelMaBaiThi);
            Controls.Add(btnLamBai);
            Controls.Add(labelThoiLuong);
            Controls.Add(labelSoCau);
            Controls.Add(label2);
            Controls.Add(dateNgayKetThuc);
            Controls.Add(dateNgayBatDau);
            Controls.Add(labelTenDeThi);
            Font = new Font("SF Mono", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucBaiThi";
            Size = new Size(1127, 103);
            Click += ucBaiThi_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenDeThi;
        private DateTimePicker dateNgayBatDau;
        private DateTimePicker dateNgayKetThuc;
        private Label label2;
        private Label labelSoCau;
        private Label labelThoiLuong;
        private Button btnLamBai;
        private Label labelMaBaiThi;
    }
}
