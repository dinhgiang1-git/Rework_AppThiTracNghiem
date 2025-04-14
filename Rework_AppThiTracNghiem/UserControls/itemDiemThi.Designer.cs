namespace Rework_AppThiTracNghiem.UserControls
{
    partial class itemDiemThi
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
            l = new Label();
            dateNgayLam = new Label();
            tenDeThi = new ReaLTaiizor.Controls.BigLabel();
            lblTenbaithi = new ReaLTaiizor.Controls.BigLabel();
            lblMark = new Label();
            SuspendLayout();
            // 
            // l
            // 
            l.AutoSize = true;
            l.Font = new Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l.Location = new Point(11, 69);
            l.Name = "l";
            l.Size = new Size(63, 17);
            l.TabIndex = 18;
            l.Text = "Ngày làm:";
            // 
            // dateNgayLam
            // 
            dateNgayLam.AutoSize = true;
            dateNgayLam.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateNgayLam.Location = new Point(98, 69);
            dateNgayLam.Name = "dateNgayLam";
            dateNgayLam.Size = new Size(65, 30);
            dateNgayLam.TabIndex = 17;
            dateNgayLam.Text = "20/10";
            // 
            // tenDeThi
            // 
            tenDeThi.AutoSize = true;
            tenDeThi.BackColor = Color.Transparent;
            tenDeThi.Font = new Font("Segoe UI", 25F);
            tenDeThi.ForeColor = Color.FromArgb(80, 80, 80);
            tenDeThi.Location = new Point(-1, 2);
            tenDeThi.Name = "tenDeThi";
            tenDeThi.Size = new Size(425, 46);
            tenDeThi.TabIndex = 15;
            tenDeThi.Text = "Đề thi Hệ Thống Thông Tin";
            // 
            // lblTenbaithi
            // 
            lblTenbaithi.AutoSize = true;
            lblTenbaithi.BackColor = Color.Transparent;
            lblTenbaithi.Font = new Font("Segoe UI", 25F);
            lblTenbaithi.ForeColor = Color.FromArgb(80, 80, 80);
            lblTenbaithi.Location = new Point(-1, 1);
            lblTenbaithi.Name = "lblTenbaithi";
            lblTenbaithi.Size = new Size(174, 46);
            lblTenbaithi.TabIndex = 14;
            lblTenbaithi.Text = "Tên bài thi";
            lblTenbaithi.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblMark
            // 
            lblMark.BorderStyle = BorderStyle.FixedSingle;
            lblMark.Font = new Font("Calibri", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMark.ForeColor = Color.DarkGreen;
            lblMark.Location = new Point(1186, 17);
            lblMark.Name = "lblMark";
            lblMark.Size = new Size(125, 60);
            lblMark.TabIndex = 19;
            lblMark.Text = "9.5";
            lblMark.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // itemDiemThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblMark);
            Controls.Add(l);
            Controls.Add(dateNgayLam);
            Controls.Add(tenDeThi);
            Controls.Add(lblTenbaithi);
            Name = "itemDiemThi";
            Size = new Size(1383, 101);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label thoiGianLam;
        private Label txtDuration;
        private Label label2;
        private Label l;
        private Label dateNgayLam;
        private Label dateNgaydong;
        private ReaLTaiizor.Controls.BigLabel tenDeThi;
        private ReaLTaiizor.Controls.BigLabel lblTenbaithi;
        private Label lblMark;
        private ReaLTaiizor.Controls.Button btnThi;
    }
}
