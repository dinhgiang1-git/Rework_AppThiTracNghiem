namespace Rework_AppThiTracNghiem.UserControls
{
    partial class itemDethi
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
            btnThi = new ReaLTaiizor.Controls.Button();
            lblTenbaithi = new ReaLTaiizor.Controls.BigLabel();
            tenDeThi = new ReaLTaiizor.Controls.BigLabel();
            dateNgaydong = new Label();
            dateNgaymo = new Label();
            label1 = new Label();
            label2 = new Label();
            txtDuration = new Label();
            thoiGianLam = new Label();
            SuspendLayout();
            // 
            // btnThi
            // 
            btnThi.BackColor = Color.FromArgb(255, 192, 192);
            btnThi.BorderColor = Color.FromArgb(32, 34, 37);
            btnThi.Cursor = Cursors.Hand;
            btnThi.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnThi.EnteredColor = Color.FromArgb(32, 34, 37);
            btnThi.Font = new Font("Microsoft Sans Serif", 12F);
            btnThi.Image = null;
            btnThi.ImageAlign = ContentAlignment.MiddleLeft;
            btnThi.InactiveColor = Color.FromArgb(32, 34, 37);
            btnThi.Location = new Point(1224, 35);
            btnThi.Name = "btnThi";
            btnThi.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnThi.PressedColor = Color.FromArgb(165, 37, 37);
            btnThi.Size = new Size(120, 40);
            btnThi.TabIndex = 0;
            btnThi.Text = "Làm bài thi";
            btnThi.TextAlignment = StringAlignment.Center;
            btnThi.Click += button1_Click;
            // 
            // lblTenbaithi
            // 
            lblTenbaithi.AutoSize = true;
            lblTenbaithi.BackColor = Color.Transparent;
            lblTenbaithi.Font = new Font("Segoe UI", 25F);
            lblTenbaithi.ForeColor = Color.FromArgb(80, 80, 80);
            lblTenbaithi.Location = new Point(0, -1);
            lblTenbaithi.Name = "lblTenbaithi";
            lblTenbaithi.Size = new Size(174, 46);
            lblTenbaithi.TabIndex = 2;
            lblTenbaithi.Text = "Tên bài thi";
            lblTenbaithi.TextAlign = ContentAlignment.TopCenter;
            // 
            // tenDeThi
            // 
            tenDeThi.AutoSize = true;
            tenDeThi.BackColor = Color.Transparent;
            tenDeThi.Font = new Font("Segoe UI", 25F);
            tenDeThi.ForeColor = Color.FromArgb(80, 80, 80);
            tenDeThi.Location = new Point(0, 0);
            tenDeThi.Name = "tenDeThi";
            tenDeThi.Size = new Size(425, 46);
            tenDeThi.TabIndex = 4;
            tenDeThi.Text = "Đề thi Hệ Thống Thông Tin";
            // 
            // dateNgaydong
            // 
            dateNgaydong.AutoSize = true;
            dateNgaydong.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateNgaydong.Location = new Point(377, 67);
            dateNgaydong.Name = "dateNgaydong";
            dateNgaydong.Size = new Size(68, 30);
            dateNgaydong.TabIndex = 7;
            dateNgaydong.Text = "label1";
            // 
            // dateNgaymo
            // 
            dateNgaymo.AutoSize = true;
            dateNgaymo.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateNgaymo.Location = new Point(99, 67);
            dateNgaymo.Name = "dateNgaymo";
            dateNgaymo.Size = new Size(68, 30);
            dateNgaymo.TabIndex = 8;
            dateNgaymo.Text = "label2";
            dateNgaymo.Click += dateNgaymo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(84, 17);
            label1.TabIndex = 9;
            label1.Text = "Ngày bắt đầu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(283, 69);
            label2.Name = "label2";
            label2.Size = new Size(88, 17);
            label2.TabIndex = 10;
            label2.Text = "Ngày kết thúc:";
            // 
            // txtDuration
            // 
            txtDuration.AutoSize = true;
            txtDuration.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDuration.Location = new Point(547, 67);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(62, 17);
            txtDuration.TabIndex = 11;
            txtDuration.Text = "Thời gian:";
            // 
            // thoiGianLam
            // 
            thoiGianLam.AutoSize = true;
            thoiGianLam.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            thoiGianLam.Location = new Point(612, 69);
            thoiGianLam.Name = "thoiGianLam";
            thoiGianLam.Size = new Size(82, 30);
            thoiGianLam.TabIndex = 12;
            thoiGianLam.Text = "60 CÂU";
            // 
            // itemDethi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(thoiGianLam);
            Controls.Add(txtDuration);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateNgaymo);
            Controls.Add(dateNgaydong);
            Controls.Add(tenDeThi);
            Controls.Add(lblTenbaithi);
            Controls.Add(btnThi);
            Name = "itemDethi";
            Size = new Size(1392, 99);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.Button btnThi;
        private ReaLTaiizor.Controls.BigLabel lblTenbaithi;
        private ReaLTaiizor.Controls.BigLabel tenDeThi;
        private ReaLTaiizor.Controls.FoxBigLabel dateNgaythi;
        private Label dateNgaydong;
        private Label dateNgaymo;
        private Label label1;
        private Label label2;
        private Label txtDuration;
        private Label thoiGianLam;
    }
}
