namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH
{
    partial class nhchXemChiTiet
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
            dataCAUHOI = new DataGridView();
            idk = new GroupBox();
            button1 = new Button();
            btnNhapFile = new Button();
            sdtbtnHuy = new Button();
            btnThem = new Button();
            button2 = new Button();
            btnXuatFile = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCAUHOI).BeginInit();
            idk.SuspendLayout();
            SuspendLayout();
            // 
            // dataCAUHOI
            // 
            dataCAUHOI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataCAUHOI.BackgroundColor = Color.FromArgb(241, 245, 249);
            dataCAUHOI.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCAUHOI.GridColor = Color.FromArgb(250, 209, 207);
            dataCAUHOI.Location = new Point(399, 22);
            dataCAUHOI.Margin = new Padding(5, 4, 5, 4);
            dataCAUHOI.Name = "dataCAUHOI";
            dataCAUHOI.RowHeadersWidth = 45;
            dataCAUHOI.Size = new Size(1276, 1032);
            dataCAUHOI.TabIndex = 13;
            dataCAUHOI.TabStop = false;
            dataCAUHOI.CellClick += dataCAUHOI_CellClick;
            // 
            // idk
            // 
            idk.Controls.Add(button1);
            idk.Controls.Add(btnNhapFile);
            idk.Controls.Add(sdtbtnHuy);
            idk.Controls.Add(btnThem);
            idk.Controls.Add(button2);
            idk.Controls.Add(btnXuatFile);
            idk.Controls.Add(txtTimKiem);
            idk.Controls.Add(btnTimKiem);
            idk.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idk.ForeColor = Color.Black;
            idk.Location = new Point(19, 13);
            idk.Margin = new Padding(5, 4, 5, 4);
            idk.Name = "idk";
            idk.Padding = new Padding(5, 4, 5, 4);
            idk.Size = new Size(370, 1041);
            idk.TabIndex = 12;
            idk.TabStop = false;
            idk.Text = "Chi tiết ngân hàng câu hỏi";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(233, 67, 55);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(145, 282);
            button1.Name = "button1";
            button1.Size = new Size(209, 36);
            button1.TabIndex = 82;
            button1.Text = "Xoá câu hỏi";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnNhapFile
            // 
            btnNhapFile.BackColor = Color.FromArgb(205, 233, 214);
            btnNhapFile.FlatStyle = FlatStyle.Popup;
            btnNhapFile.ForeColor = Color.Black;
            btnNhapFile.Location = new Point(8, 168);
            btnNhapFile.Name = "btnNhapFile";
            btnNhapFile.Size = new Size(117, 36);
            btnNhapFile.TabIndex = 78;
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
            sdtbtnHuy.Location = new Point(145, 225);
            sdtbtnHuy.Name = "sdtbtnHuy";
            sdtbtnHuy.Size = new Size(209, 36);
            sdtbtnHuy.TabIndex = 81;
            sdtbtnHuy.Text = "Sửa câu hỏi";
            sdtbtnHuy.UseVisualStyleBackColor = false;
            sdtbtnHuy.Click += sdtbtnHuy_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(30, 64, 175);
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(145, 167);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(209, 36);
            btnThem.TabIndex = 80;
            btnThem.Text = "Thêm câu hỏi thủ công";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(205, 233, 214);
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(8, 282);
            button2.Name = "button2";
            button2.Size = new Size(117, 34);
            button2.TabIndex = 83;
            button2.Text = "Làm mới";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnXuatFile
            // 
            btnXuatFile.BackColor = Color.FromArgb(205, 233, 214);
            btnXuatFile.FlatStyle = FlatStyle.Popup;
            btnXuatFile.ForeColor = Color.Black;
            btnXuatFile.Location = new Point(8, 226);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(117, 36);
            btnXuatFile.TabIndex = 79;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = false;
            btnXuatFile.Click += btnXuatFile_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(8, 44);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(346, 29);
            txtTimKiem.TabIndex = 29;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(205, 233, 214);
            btnTimKiem.FlatStyle = FlatStyle.Popup;
            btnTimKiem.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(237, 79);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(117, 36);
            btnTimKiem.TabIndex = 28;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // nhchXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 243, 244);
            ClientSize = new Size(1689, 1067);
            Controls.Add(dataCAUHOI);
            Controls.Add(idk);
            Font = new Font("Segoe UI Semibold", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "nhchXemChiTiet";
            Text = "Chi tiết ngân hàng câu hỏi";
            ((System.ComponentModel.ISupportInitialize)dataCAUHOI).EndInit();
            idk.ResumeLayout(false);
            idk.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataCAUHOI;
        private GroupBox idk;
        private ReaLTaiizor.Controls.PoisonButton nhchbtnLamMoi;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button button1;
        private Button btnNhapFile;
        private Button sdtbtnHuy;
        private Button btnThem;
        private Button button2;
        private Button btnXuatFile;
    }
}