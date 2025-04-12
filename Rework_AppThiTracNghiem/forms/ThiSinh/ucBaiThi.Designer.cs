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
            txtTenDeThi = new Label();
            dateNgayBatDau = new DateTimePicker();
            dateNgayKetThuc = new DateTimePicker();
            label2 = new Label();
            txtSoCau = new Label();
            txtThoiLuong = new Label();
            btnLamBai = new Button();
            SuspendLayout();
            // 
            // txtTenDeThi
            // 
            txtTenDeThi.AutoSize = true;
            txtTenDeThi.Location = new Point(17, 15);
            txtTenDeThi.Margin = new Padding(4, 0, 4, 0);
            txtTenDeThi.Name = "txtTenDeThi";
            txtTenDeThi.Size = new Size(69, 19);
            txtTenDeThi.TabIndex = 0;
            txtTenDeThi.Text = "label1";
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
            // txtSoCau
            // 
            txtSoCau.AutoSize = true;
            txtSoCau.Location = new Point(550, 66);
            txtSoCau.Name = "txtSoCau";
            txtSoCau.Size = new Size(69, 19);
            txtSoCau.TabIndex = 5;
            txtSoCau.Text = "label3";
            // 
            // txtThoiLuong
            // 
            txtThoiLuong.AutoSize = true;
            txtThoiLuong.Location = new Point(698, 66);
            txtThoiLuong.Name = "txtThoiLuong";
            txtThoiLuong.Size = new Size(69, 19);
            txtThoiLuong.TabIndex = 6;
            txtThoiLuong.Text = "label3";
            // 
            // btnLamBai
            // 
            btnLamBai.FlatStyle = FlatStyle.Popup;
            btnLamBai.Location = new Point(853, 34);
            btnLamBai.Name = "btnLamBai";
            btnLamBai.Size = new Size(164, 34);
            btnLamBai.TabIndex = 7;
            btnLamBai.Text = "Làm bài";
            btnLamBai.UseVisualStyleBackColor = true;
            // 
            // ucBaiThi
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLamBai);
            Controls.Add(txtThoiLuong);
            Controls.Add(txtSoCau);
            Controls.Add(label2);
            Controls.Add(dateNgayKetThuc);
            Controls.Add(dateNgayBatDau);
            Controls.Add(txtTenDeThi);
            Font = new Font("SF Mono", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucBaiThi";
            Size = new Size(1031, 103);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtTenDeThi;
        private DateTimePicker dateNgayBatDau;
        private DateTimePicker dateNgayKetThuc;
        private Label label2;
        private Label txtSoCau;
        private Label txtThoiLuong;
        private Button btnLamBai;
    }
}
