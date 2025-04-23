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
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            bdbtnTimKiem = new Button();
            label4 = new Label();
            bdcbDeThi = new ComboBox();
            bdtxtTimKiem = new TextBox();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = Color.Gray;
            groupBox1.Location = new Point(15, 220);
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
            radioButton3.Size = new Size(117, 24);
            radioButton3.TabIndex = 29;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = Color.Black;
            radioButton2.Location = new Point(6, 81);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(117, 24);
            radioButton2.TabIndex = 28;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = Color.Black;
            radioButton1.Location = new Point(6, 34);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(115, 24);
            radioButton1.TabIndex = 27;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // bdbtnTimKiem
            // 
            bdbtnTimKiem.BackColor = Color.FromArgb(205, 233, 214);
            bdbtnTimKiem.FlatStyle = FlatStyle.Popup;
            bdbtnTimKiem.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bdbtnTimKiem.ForeColor = Color.Black;
            bdbtnTimKiem.Location = new Point(208, 168);
            bdbtnTimKiem.Name = "bdbtnTimKiem";
            bdbtnTimKiem.Size = new Size(123, 32);
            bdbtnTimKiem.TabIndex = 25;
            bdbtnTimKiem.Text = "Tìm kiếm";
            bdbtnTimKiem.UseVisualStyleBackColor = false;
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
            bdcbDeThi.Size = new Size(316, 28);
            bdcbDeThi.TabIndex = 16;
            // 
            // bdtxtTimKiem
            // 
            bdtxtTimKiem.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            bdtxtTimKiem.Location = new Point(40, 147);
            bdtxtTimKiem.Name = "bdtxtTimKiem";
            bdtxtTimKiem.Size = new Size(316, 29);
            bdtxtTimKiem.TabIndex = 26;
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
            Controls.Add(bdtxtTimKiem);
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
        private Button bdbtnTimKiem;
        private TextBox bdtxtTimKiem;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label labelTenDeThi;
    }
}