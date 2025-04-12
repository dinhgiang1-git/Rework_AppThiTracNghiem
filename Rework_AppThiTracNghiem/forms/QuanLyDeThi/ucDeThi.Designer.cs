namespace Rework_AppThiTracNghiem.forms.QuanLyDeThi
{
    partial class ucDeThi
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
            label1 = new Label();
            btnXemChiTiet = new Button();
            labelMaDeThi = new Label();
            SuspendLayout();
            // 
            // labelTenDeThi
            // 
            labelTenDeThi.AutoSize = true;
            labelTenDeThi.Font = new Font("SF Mono", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenDeThi.Location = new Point(13, 25);
            labelTenDeThi.Margin = new Padding(4, 0, 4, 0);
            labelTenDeThi.Name = "labelTenDeThi";
            labelTenDeThi.Size = new Size(69, 19);
            labelTenDeThi.TabIndex = 0;
            labelTenDeThi.Text = "label1";
            // 
            // dateNgayBatDau
            // 
            dateNgayBatDau.Enabled = false;
            dateNgayBatDau.Format = DateTimePickerFormat.Custom;
            dateNgayBatDau.Location = new Point(13, 59);
            dateNgayBatDau.Name = "dateNgayBatDau";
            dateNgayBatDau.Size = new Size(221, 25);
            dateNgayBatDau.TabIndex = 1;
            // 
            // dateNgayKetThuc
            // 
            dateNgayKetThuc.Enabled = false;
            dateNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dateNgayKetThuc.Location = new Point(263, 59);
            dateNgayKetThuc.Name = "dateNgayKetThuc";
            dateNgayKetThuc.Size = new Size(221, 25);
            dateNgayKetThuc.TabIndex = 2;
            dateNgayKetThuc.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 64);
            label1.Name = "label1";
            label1.Size = new Size(17, 18);
            label1.TabIndex = 3;
            label1.Text = "-";
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.FlatStyle = FlatStyle.Popup;
            btnXemChiTiet.Location = new Point(13, 99);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(167, 31);
            btnXemChiTiet.TabIndex = 4;
            btnXemChiTiet.Text = "Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = true;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // labelMaDeThi
            // 
            labelMaDeThi.AutoSize = true;
            labelMaDeThi.ForeColor = Color.FromArgb(241, 245, 249);
            labelMaDeThi.Location = new Point(186, 112);
            labelMaDeThi.Name = "labelMaDeThi";
            labelMaDeThi.Size = new Size(62, 18);
            labelMaDeThi.TabIndex = 5;
            labelMaDeThi.Text = "label2";
            labelMaDeThi.Visible = false;
            // 
            // ucDeThi
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelMaDeThi);
            Controls.Add(btnXemChiTiet);
            Controls.Add(label1);
            Controls.Add(dateNgayKetThuc);
            Controls.Add(dateNgayBatDau);
            Controls.Add(labelTenDeThi);
            Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucDeThi";
            Size = new Size(496, 144);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenDeThi;
        private DateTimePicker dateNgayBatDau;
        private DateTimePicker dateNgayKetThuc;
        private Label label1;
        private Button btnXemChiTiet;
        private Label labelMaDeThi;
    }
}
