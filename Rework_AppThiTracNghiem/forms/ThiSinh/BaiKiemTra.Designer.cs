namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    partial class BaiKiemTra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaiKiemTra));
            listviewDanhSachCauHoi = new ListView();
            groupBox1 = new GroupBox();
            btnNopBai = new Button();
            checkboxnopbai = new CheckBox();
            txtThoiGianConLai = new TextBox();
            label3 = new Label();
            labelTenBaiThi = new Label();
            labelMaSinhVien = new Label();
            labelHoTen = new Label();
            flowCauHoi = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listviewDanhSachCauHoi
            // 
            listviewDanhSachCauHoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listviewDanhSachCauHoi.Location = new Point(15, 13);
            listviewDanhSachCauHoi.Margin = new Padding(4, 3, 4, 3);
            listviewDanhSachCauHoi.Name = "listviewDanhSachCauHoi";
            listviewDanhSachCauHoi.Size = new Size(343, 800);
            listviewDanhSachCauHoi.TabIndex = 0;
            listviewDanhSachCauHoi.UseCompatibleStateImageBehavior = false;
            listviewDanhSachCauHoi.SelectedIndexChanged += listviewDanhSachCauHoi_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnNopBai);
            groupBox1.Controls.Add(checkboxnopbai);
            groupBox1.Controls.Add(txtThoiGianConLai);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(labelTenBaiThi);
            groupBox1.Controls.Add(labelMaSinhVien);
            groupBox1.Controls.Add(labelHoTen);
            groupBox1.Location = new Point(366, 3);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1253, 102);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin bài thi";
            // 
            // btnNopBai
            // 
            btnNopBai.BackColor = Color.FromArgb(53, 196, 121);
            btnNopBai.FlatStyle = FlatStyle.Popup;
            btnNopBai.ForeColor = Color.White;
            btnNopBai.Location = new Point(1125, 66);
            btnNopBai.Name = "btnNopBai";
            btnNopBai.Size = new Size(121, 30);
            btnNopBai.TabIndex = 6;
            btnNopBai.Text = "NỘP BÀI";
            btnNopBai.UseVisualStyleBackColor = false;
            btnNopBai.Click += btnNopBai_Click;
            // 
            // checkboxnopbai
            // 
            checkboxnopbai.AutoSize = true;
            checkboxnopbai.Location = new Point(948, 74);
            checkboxnopbai.Name = "checkboxnopbai";
            checkboxnopbai.Size = new Size(171, 22);
            checkboxnopbai.TabIndex = 5;
            checkboxnopbai.Text = "Tôi muốn nộp bài";
            checkboxnopbai.UseVisualStyleBackColor = true;
            // 
            // txtThoiGianConLai
            // 
            txtThoiGianConLai.Location = new Point(495, 66);
            txtThoiGianConLai.Name = "txtThoiGianConLai";
            txtThoiGianConLai.Size = new Size(110, 25);
            txtThoiGianConLai.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 69);
            label3.Name = "label3";
            label3.Size = new Size(179, 18);
            label3.TabIndex = 3;
            label3.Text = "Thời gian còn lại: ";
            // 
            // labelTenBaiThi
            // 
            labelTenBaiThi.AutoSize = true;
            labelTenBaiThi.Location = new Point(310, 33);
            labelTenBaiThi.Name = "labelTenBaiThi";
            labelTenBaiThi.Size = new Size(233, 18);
            labelTenBaiThi.TabIndex = 2;
            labelTenBaiThi.Text = "Bài thi: Kiểm tra giữa kỳ";
            // 
            // labelMaSinhVien
            // 
            labelMaSinhVien.AutoSize = true;
            labelMaSinhVien.Location = new Point(7, 69);
            labelMaSinhVien.Name = "labelMaSinhVien";
            labelMaSinhVien.Size = new Size(71, 18);
            labelMaSinhVien.TabIndex = 1;
            labelMaSinhVien.Text = "Mã: qwe";
            // 
            // labelHoTen
            // 
            labelHoTen.AutoSize = true;
            labelHoTen.Location = new Point(7, 33);
            labelHoTen.Name = "labelHoTen";
            labelHoTen.Size = new Size(224, 18);
            labelHoTen.TabIndex = 0;
            labelHoTen.Text = "Họ Tên: Nguyên Sinh Viên";
            // 
            // flowCauHoi
            // 
            flowCauHoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowCauHoi.AutoScroll = true;
            flowCauHoi.BackColor = Color.White;
            flowCauHoi.Location = new Point(366, 111);
            flowCauHoi.Name = "flowCauHoi";
            flowCauHoi.Size = new Size(1254, 702);
            flowCauHoi.TabIndex = 2;
            // 
            // BaiKiemTra
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
            Name = "BaiKiemTra";
            Text = "Bài kiểm tra";
            WindowState = FormWindowState.Maximized;
            FormClosing += BaiKiemTra_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView listviewDanhSachCauHoi;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowCauHoi;
        private TextBox txtThoiGianConLai;
        private Label label3;
        private Label labelTenBaiThi;
        private Label labelMaSinhVien;
        private Label labelHoTen;
        private Button btnNopBai;
        private CheckBox checkboxnopbai;
    }
}