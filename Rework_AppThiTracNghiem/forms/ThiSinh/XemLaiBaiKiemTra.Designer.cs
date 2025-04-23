namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    partial class XemLaiBaiKiemTra
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XemLaiBaiKiemTra));
            flowCauHoi = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            labelTenBaiThi = new Label();
            labelMaSinhVien = new Label();
            labelHoTen = new Label();
            listviewDanhSachCauHoi = new ListView();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // flowCauHoi
            // 
            flowCauHoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowCauHoi.AutoScroll = true;
            flowCauHoi.BackColor = Color.White;
            flowCauHoi.Location = new Point(365, 115);
            flowCauHoi.Name = "flowCauHoi";
            flowCauHoi.Size = new Size(1254, 702);
            flowCauHoi.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(labelTenBaiThi);
            groupBox1.Controls.Add(labelMaSinhVien);
            groupBox1.Controls.Add(labelHoTen);
            groupBox1.Location = new Point(365, 7);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1253, 102);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin bài thi";
            // 
            // labelTenBaiThi
            // 
            labelTenBaiThi.AutoSize = true;
            labelTenBaiThi.Location = new Point(311, 33);
            labelTenBaiThi.Name = "labelTenBaiThi";
            labelTenBaiThi.Size = new Size(233, 18);
            labelTenBaiThi.TabIndex = 2;
            labelTenBaiThi.Text = "Bài thi: Kiểm tra giữa kỳ";
            // 
            // labelMaSinhVien
            // 
            labelMaSinhVien.AutoSize = true;
            labelMaSinhVien.Location = new Point(8, 69);
            labelMaSinhVien.Name = "labelMaSinhVien";
            labelMaSinhVien.Size = new Size(71, 18);
            labelMaSinhVien.TabIndex = 1;
            labelMaSinhVien.Text = "Mã: qwe";
            // 
            // labelHoTen
            // 
            labelHoTen.AutoSize = true;
            labelHoTen.Location = new Point(8, 33);
            labelHoTen.Name = "labelHoTen";
            labelHoTen.Size = new Size(224, 18);
            labelHoTen.TabIndex = 0;
            labelHoTen.Text = "Họ Tên: Nguyên Sinh Viên";
            // 
            // listviewDanhSachCauHoi
            // 
            listviewDanhSachCauHoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listviewDanhSachCauHoi.Location = new Point(14, 17);
            listviewDanhSachCauHoi.Margin = new Padding(4, 3, 4, 3);
            listviewDanhSachCauHoi.Name = "listviewDanhSachCauHoi";
            listviewDanhSachCauHoi.Size = new Size(343, 800);
            listviewDanhSachCauHoi.TabIndex = 3;
            listviewDanhSachCauHoi.UseCompatibleStateImageBehavior = false;
            // 
            // XemLaiBaiKiemTra
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1632, 825);
            Controls.Add(flowCauHoi);
            Controls.Add(groupBox1);
            Controls.Add(listviewDanhSachCauHoi);
            Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "XemLaiBaiKiemTra";
            Text = "Xem Lại Bài Kiểm Tra";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCauHoi;
        private GroupBox groupBox1;
        private Label labelTenBaiThi;
        private Label labelMaSinhVien;
        private Label labelHoTen;
        private ListView listviewDanhSachCauHoi;
    }
}