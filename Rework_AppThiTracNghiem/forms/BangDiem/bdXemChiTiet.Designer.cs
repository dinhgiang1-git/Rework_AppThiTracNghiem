namespace Rework_AppThiTracNghiem.forms.BangDiem
{
    partial class bdXemChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bdXemChiTiet));
            dataBangDiem = new DataGridView();
            bdgroupbox = new GroupBox();
            btnLoad = new Button();
            btnXuatFile = new Button();
            bdtxtTimKiem = new TextBox();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioSortDiem = new RadioButton();
            radioSortName = new RadioButton();
            bdbtnTimKiem = new Button();
            label4 = new Label();
            bdcbDeThi = new ComboBox();
            labelTenDeThi = new Label();
            ((System.ComponentModel.ISupportInitialize)dataBangDiem).BeginInit();
            bdgroupbox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataBangDiem
            // 
            dataBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataBangDiem.BackgroundColor = Color.FromArgb(241, 245, 249);
            dataBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataBangDiem.GridColor = Color.FromArgb(250, 209, 207);
            dataBangDiem.Location = new Point(378, 59);
            dataBangDiem.Margin = new Padding(4);
            dataBangDiem.Name = "dataBangDiem";
            dataBangDiem.RowHeadersWidth = 45;
            dataBangDiem.Size = new Size(1180, 877);
            dataBangDiem.TabIndex = 13;
            dataBangDiem.TabStop = false;
            // 
            // bdgroupbox
            // 
            bdgroupbox.Controls.Add(btnLoad);
            bdgroupbox.Controls.Add(btnXuatFile);
            bdgroupbox.Controls.Add(bdtxtTimKiem);
            bdgroupbox.Controls.Add(groupBox1);
            bdgroupbox.Controls.Add(bdbtnTimKiem);
            bdgroupbox.Controls.Add(label4);
            bdgroupbox.Controls.Add(bdcbDeThi);
            bdgroupbox.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bdgroupbox.ForeColor = Color.Black;
            bdgroupbox.Location = new Point(25, 14);
            bdgroupbox.Margin = new Padding(4);
            bdgroupbox.Name = "bdgroupbox";
            bdgroupbox.Padding = new Padding(4);
            bdgroupbox.Size = new Size(345, 922);
            bdgroupbox.TabIndex = 12;
            bdgroupbox.TabStop = false;
            bdgroupbox.Text = "Chi tiết bảng điểm Lớp 73DCHT23";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(205, 233, 214);
            btnLoad.FlatStyle = FlatStyle.Popup;
            btnLoad.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoad.ForeColor = Color.Black;
            btnLoad.Location = new Point(144, 102);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(123, 32);
            btnLoad.TabIndex = 28;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.BackColor = Color.FromArgb(205, 233, 214);
            btnXuatFile.FlatStyle = FlatStyle.Popup;
            btnXuatFile.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatFile.ForeColor = Color.Black;
            btnXuatFile.Location = new Point(15, 102);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(123, 32);
            btnXuatFile.TabIndex = 27;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = false;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // bdtxtTimKiem
            // 
            bdtxtTimKiem.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            bdtxtTimKiem.Location = new Point(15, 164);
            bdtxtTimKiem.Name = "bdtxtTimKiem";
            bdtxtTimKiem.Size = new Size(323, 29);
            bdtxtTimKiem.TabIndex = 26;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioSortDiem);
            groupBox1.Controls.Add(radioSortName);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(15, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(323, 172);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lọc";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.ForeColor = Color.Black;
            radioButton3.Location = new Point(6, 130);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(14, 13);
            radioButton3.TabIndex = 29;
            radioButton3.TabStop = true;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioSortDiem
            // 
            radioSortDiem.AutoSize = true;
            radioSortDiem.ForeColor = Color.Black;
            radioSortDiem.Location = new Point(6, 81);
            radioSortDiem.Name = "radioSortDiem";
            radioSortDiem.Size = new Size(187, 24);
            radioSortDiem.TabIndex = 28;
            radioSortDiem.TabStop = true;
            radioSortDiem.Text = "Sắp xếp điểm giảm dần";
            radioSortDiem.UseVisualStyleBackColor = true;
            radioSortDiem.CheckedChanged += radioSortDiem_CheckedChanged;
            // 
            // radioSortName
            // 
            radioSortName.AutoSize = true;
            radioSortName.ForeColor = Color.Black;
            radioSortName.Location = new Point(6, 34);
            radioSortName.Name = "radioSortName";
            radioSortName.Size = new Size(236, 24);
            radioSortName.TabIndex = 27;
            radioSortName.TabStop = true;
            radioSortName.Text = "Sắp xếp A-Z theo tên sinh viên";
            radioSortName.UseVisualStyleBackColor = true;
            radioSortName.CheckedChanged += radioSortName_CheckedChanged;
            // 
            // bdbtnTimKiem
            // 
            bdbtnTimKiem.BackColor = Color.FromArgb(205, 233, 214);
            bdbtnTimKiem.FlatStyle = FlatStyle.Popup;
            bdbtnTimKiem.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bdbtnTimKiem.ForeColor = Color.Black;
            bdbtnTimKiem.Location = new Point(15, 199);
            bdbtnTimKiem.Name = "bdbtnTimKiem";
            bdbtnTimKiem.Size = new Size(123, 32);
            bdbtnTimKiem.TabIndex = 25;
            bdbtnTimKiem.Text = "Tìm kiếm";
            bdbtnTimKiem.UseVisualStyleBackColor = false;
            bdbtnTimKiem.Click += bdbtnTimKiem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(15, 45);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 18;
            label4.Text = "Chọn đề";
            // 
            // bdcbDeThi
            // 
            bdcbDeThi.FormattingEnabled = true;
            bdcbDeThi.Location = new Point(15, 68);
            bdcbDeThi.Name = "bdcbDeThi";
            bdcbDeThi.Size = new Size(323, 28);
            bdcbDeThi.TabIndex = 16;
            bdcbDeThi.SelectedIndexChanged += bdcbDeThi_SelectedIndexChanged;
            // 
            // labelTenDeThi
            // 
            labelTenDeThi.AutoSize = true;
            labelTenDeThi.Location = new Point(794, 25);
            labelTenDeThi.Name = "labelTenDeThi";
            labelTenDeThi.Size = new Size(81, 21);
            labelTenDeThi.TabIndex = 27;
            labelTenDeThi.Text = "Tên đề thi";
            // 
            // bdXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 243, 244);
            ClientSize = new Size(1571, 950);
            Controls.Add(labelTenDeThi);
            Controls.Add(dataBangDiem);
            Controls.Add(bdgroupbox);
            Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "bdXemChiTiet";
            Text = "Xem chi tiết bảng điểm";
            ((System.ComponentModel.ISupportInitialize)dataBangDiem).EndInit();
            bdgroupbox.ResumeLayout(false);
            bdgroupbox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataBangDiem;
        private GroupBox bdgroupbox;
        private ComboBox bdcbDeThi;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox bdtxtTimKiem;
        private RadioButton radioButton3;
        private RadioButton radioSortDiem;
        private RadioButton radioSortName;
        private Label labelTenDeThi;
        private Button btnXuatFile;
        private Button btnLoad;
        private Button bdbtnTimKiem;
    }
}