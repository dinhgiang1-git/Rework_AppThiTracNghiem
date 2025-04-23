namespace Rework_AppThiTracNghiem.forms
{
    partial class qllXemChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qllXemChiTiet));
            qllgroupbox = new GroupBox();
            button1 = new Button();
            btnNhapFile = new Button();
            sdtbtnHuy = new Button();
            btnTimKiem = new Button();
            sdtbtnThemDong = new Button();
            txtTimKiem = new TextBox();
            button2 = new Button();
            btnXuatFile = new Button();
            dataThanhVien = new DataGridView();
            qllgroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataThanhVien).BeginInit();
            SuspendLayout();
            // 
            // qllgroupbox
            // 
            qllgroupbox.Controls.Add(button1);
            qllgroupbox.Controls.Add(btnNhapFile);
            qllgroupbox.Controls.Add(sdtbtnHuy);
            qllgroupbox.Controls.Add(btnTimKiem);
            qllgroupbox.Controls.Add(sdtbtnThemDong);
            qllgroupbox.Controls.Add(txtTimKiem);
            qllgroupbox.Controls.Add(button2);
            qllgroupbox.Controls.Add(btnXuatFile);
            qllgroupbox.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qllgroupbox.ForeColor = Color.Black;
            qllgroupbox.Location = new Point(13, 15);
            qllgroupbox.Margin = new Padding(4);
            qllgroupbox.Name = "qllgroupbox";
            qllgroupbox.Padding = new Padding(4);
            qllgroupbox.Size = new Size(305, 922);
            qllgroupbox.TabIndex = 10;
            qllgroupbox.TabStop = false;
            qllgroupbox.Text = "Chi tiết lớp";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(233, 67, 55);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(10, 265);
            button1.Name = "button1";
            button1.Size = new Size(158, 36);
            button1.TabIndex = 76;
            button1.Text = "Xoá thành viên";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnNhapFile
            // 
            btnNhapFile.BackColor = Color.FromArgb(205, 233, 214);
            btnNhapFile.FlatStyle = FlatStyle.Popup;
            btnNhapFile.ForeColor = Color.Black;
            btnNhapFile.Location = new Point(177, 151);
            btnNhapFile.Name = "btnNhapFile";
            btnNhapFile.Size = new Size(122, 36);
            btnNhapFile.TabIndex = 16;
            btnNhapFile.Text = "Nhập file";
            btnNhapFile.UseVisualStyleBackColor = false;
            btnNhapFile.Click += btnNhapFile_Click;
            // 
            // sdtbtnHuy
            // 
            sdtbtnHuy.BackColor = Color.FromArgb(244, 193, 158);
            sdtbtnHuy.FlatStyle = FlatStyle.Popup;
            sdtbtnHuy.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sdtbtnHuy.ForeColor = Color.Black;
            sdtbtnHuy.Location = new Point(10, 209);
            sdtbtnHuy.Name = "sdtbtnHuy";
            sdtbtnHuy.Size = new Size(158, 36);
            sdtbtnHuy.TabIndex = 75;
            sdtbtnHuy.Text = "Sửa thành viên";
            sdtbtnHuy.UseVisualStyleBackColor = false;
            sdtbtnHuy.Click += sdtbtnHuy_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(205, 233, 214);
            btnTimKiem.FlatStyle = FlatStyle.Popup;
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(176, 75);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(122, 34);
            btnTimKiem.TabIndex = 78;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // sdtbtnThemDong
            // 
            sdtbtnThemDong.BackColor = Color.FromArgb(30, 64, 175);
            sdtbtnThemDong.FlatStyle = FlatStyle.Popup;
            sdtbtnThemDong.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sdtbtnThemDong.ForeColor = Color.White;
            sdtbtnThemDong.Location = new Point(10, 151);
            sdtbtnThemDong.Name = "sdtbtnThemDong";
            sdtbtnThemDong.Size = new Size(158, 36);
            sdtbtnThemDong.TabIndex = 73;
            sdtbtnThemDong.Text = "Thêm thành viên";
            sdtbtnThemDong.UseVisualStyleBackColor = false;
            sdtbtnThemDong.Click += sdtbtnThemDong_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(10, 40);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(288, 29);
            txtTimKiem.TabIndex = 79;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(205, 233, 214);
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(177, 265);
            button2.Name = "button2";
            button2.Size = new Size(122, 34);
            button2.TabIndex = 77;
            button2.Text = "Làm mới";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.BackColor = Color.FromArgb(205, 233, 214);
            btnXuatFile.FlatStyle = FlatStyle.Popup;
            btnXuatFile.ForeColor = Color.Black;
            btnXuatFile.Location = new Point(177, 209);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(122, 36);
            btnXuatFile.TabIndex = 17;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = false;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // dataThanhVien
            // 
            dataThanhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataThanhVien.BackgroundColor = Color.FromArgb(241, 245, 249);
            dataThanhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataThanhVien.GridColor = Color.FromArgb(250, 209, 207);
            dataThanhVien.Location = new Point(326, 23);
            dataThanhVien.Margin = new Padding(4);
            dataThanhVien.Name = "dataThanhVien";
            dataThanhVien.RowHeadersWidth = 45;
            dataThanhVien.Size = new Size(1232, 914);
            dataThanhVien.TabIndex = 11;
            dataThanhVien.TabStop = false;
            dataThanhVien.CellClick += dataThanhVien_CellClick;
            // 
            // qllXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 243, 244);
            ClientSize = new Size(1571, 950);
            Controls.Add(dataThanhVien);
            Controls.Add(qllgroupbox);
            Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "qllXemChiTiet";
            Text = "Danh sách lớp";
            qllgroupbox.ResumeLayout(false);
            qllgroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataThanhVien).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox qllgroupbox;
        private DataGridView dataThanhVien;
        private Button btnNhapFile;
        private Button btnXuatFile;
        private Button sdtbtnThemDong;
        private Button sdtbtnHuy;
        private Button button1;
        private Button button2;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
    }
}