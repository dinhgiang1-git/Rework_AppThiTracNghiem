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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nhchXemChiTiet));
            dataCAUHOI = new DataGridView();
            idk = new GroupBox();
            poisonButton2 = new ReaLTaiizor.Controls.PoisonButton();
            poisonButton1 = new ReaLTaiizor.Controls.PoisonButton();
            nhchbtnLamMoi = new ReaLTaiizor.Controls.PoisonButton();
            qllbtnTim = new ReaLTaiizor.Controls.PoisonButton();
            qlltxtTimKiem = new ReaLTaiizor.Controls.FoxTextBox();
            nhchbtnSuaCauHoi = new ReaLTaiizor.Controls.PoisonButton();
            nhchbtnThemThuCong = new ReaLTaiizor.Controls.PoisonButton();
            nhchbtnXoaCauHoi = new ReaLTaiizor.Controls.PoisonButton();
            ((System.ComponentModel.ISupportInitialize)dataCAUHOI).BeginInit();
            idk.SuspendLayout();
            SuspendLayout();
            // 
            // dataCAUHOI
            // 
            dataCAUHOI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataCAUHOI.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCAUHOI.Location = new Point(19, 223);
            dataCAUHOI.Margin = new Padding(5, 4, 5, 4);
            dataCAUHOI.Name = "dataCAUHOI";
            dataCAUHOI.RowHeadersWidth = 45;
            dataCAUHOI.Size = new Size(1656, 831);
            dataCAUHOI.TabIndex = 13;
            dataCAUHOI.TabStop = false;
            dataCAUHOI.CellClick += dataCAUHOI_CellClick;
            // 
            // idk
            // 
            idk.Controls.Add(poisonButton2);
            idk.Controls.Add(poisonButton1);
            idk.Controls.Add(nhchbtnLamMoi);
            idk.Controls.Add(qllbtnTim);
            idk.Controls.Add(qlltxtTimKiem);
            idk.Controls.Add(nhchbtnSuaCauHoi);
            idk.Controls.Add(nhchbtnThemThuCong);
            idk.Controls.Add(nhchbtnXoaCauHoi);
            idk.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idk.ForeColor = Color.White;
            idk.Location = new Point(19, 13);
            idk.Margin = new Padding(5, 4, 5, 4);
            idk.Name = "idk";
            idk.Padding = new Padding(5, 4, 5, 4);
            idk.Size = new Size(1656, 138);
            idk.TabIndex = 12;
            idk.TabStop = false;
            idk.Text = "Chi tiết ngân hàng câu hỏi";
            // 
            // poisonButton2
            // 
            poisonButton2.BackColor = Color.Transparent;
            poisonButton2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            poisonButton2.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            poisonButton2.Image = (Image)resources.GetObject("poisonButton2.Image");
            poisonButton2.ImageAlign = ContentAlignment.MiddleLeft;
            poisonButton2.Location = new Point(1251, 76);
            poisonButton2.Margin = new Padding(5, 4, 5, 4);
            poisonButton2.Name = "poisonButton2";
            poisonButton2.Size = new Size(181, 40);
            poisonButton2.TabIndex = 17;
            poisonButton2.Text = "Xuất file";
            poisonButton2.UseSelectable = true;
            poisonButton2.UseVisualStyleBackColor = false;
            // 
            // poisonButton1
            // 
            poisonButton1.BackColor = Color.Transparent;
            poisonButton1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            poisonButton1.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            poisonButton1.Image = (Image)resources.GetObject("poisonButton1.Image");
            poisonButton1.ImageAlign = ContentAlignment.MiddleLeft;
            poisonButton1.Location = new Point(1061, 76);
            poisonButton1.Margin = new Padding(5, 4, 5, 4);
            poisonButton1.Name = "poisonButton1";
            poisonButton1.Size = new Size(181, 40);
            poisonButton1.TabIndex = 16;
            poisonButton1.Text = "Nhập file";
            poisonButton1.UseSelectable = true;
            poisonButton1.UseVisualStyleBackColor = false;
            poisonButton1.Click += poisonButton1_Click;
            // 
            // nhchbtnLamMoi
            // 
            nhchbtnLamMoi.BackColor = Color.Transparent;
            nhchbtnLamMoi.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            nhchbtnLamMoi.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            nhchbtnLamMoi.Image = (Image)resources.GetObject("nhchbtnLamMoi.Image");
            nhchbtnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            nhchbtnLamMoi.Location = new Point(737, 49);
            nhchbtnLamMoi.Margin = new Padding(5, 4, 5, 4);
            nhchbtnLamMoi.Name = "nhchbtnLamMoi";
            nhchbtnLamMoi.Size = new Size(181, 40);
            nhchbtnLamMoi.TabIndex = 15;
            nhchbtnLamMoi.Text = "Làm mới";
            nhchbtnLamMoi.UseSelectable = true;
            nhchbtnLamMoi.UseVisualStyleBackColor = false;
            nhchbtnLamMoi.Click += nhchbtnLamMoi_Click;
            // 
            // qllbtnTim
            // 
            qllbtnTim.BackColor = Color.Transparent;
            qllbtnTim.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnTim.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnTim.Image = (Image)resources.GetObject("qllbtnTim.Image");
            qllbtnTim.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnTim.Location = new Point(462, 49);
            qllbtnTim.Margin = new Padding(5, 4, 5, 4);
            qllbtnTim.Name = "qllbtnTim";
            qllbtnTim.Size = new Size(181, 40);
            qllbtnTim.TabIndex = 14;
            qllbtnTim.Text = "Tìm";
            qllbtnTim.UseSelectable = true;
            qllbtnTim.UseVisualStyleBackColor = false;
            // 
            // qlltxtTimKiem
            // 
            qlltxtTimKiem.BackColor = Color.White;
            qlltxtTimKiem.EnabledCalc = true;
            qlltxtTimKiem.Font = new Font("Segoe UI", 10F);
            qlltxtTimKiem.ForeColor = Color.Black;
            qlltxtTimKiem.Location = new Point(9, 49);
            qlltxtTimKiem.Margin = new Padding(5, 4, 5, 4);
            qlltxtTimKiem.MaxLength = 32767;
            qlltxtTimKiem.MultiLine = false;
            qlltxtTimKiem.Name = "qlltxtTimKiem";
            qlltxtTimKiem.ReadOnly = false;
            qlltxtTimKiem.Size = new Size(443, 40);
            qlltxtTimKiem.TabIndex = 13;
            qlltxtTimKiem.Text = "Tìm kiếm";
            qlltxtTimKiem.TextAlign = HorizontalAlignment.Left;
            qlltxtTimKiem.UseSystemPasswordChar = false;
            // 
            // nhchbtnSuaCauHoi
            // 
            nhchbtnSuaCauHoi.BackColor = Color.Transparent;
            nhchbtnSuaCauHoi.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            nhchbtnSuaCauHoi.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            nhchbtnSuaCauHoi.Image = (Image)resources.GetObject("nhchbtnSuaCauHoi.Image");
            nhchbtnSuaCauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            nhchbtnSuaCauHoi.Location = new Point(1251, 28);
            nhchbtnSuaCauHoi.Margin = new Padding(5, 4, 5, 4);
            nhchbtnSuaCauHoi.Name = "nhchbtnSuaCauHoi";
            nhchbtnSuaCauHoi.Size = new Size(181, 40);
            nhchbtnSuaCauHoi.TabIndex = 12;
            nhchbtnSuaCauHoi.Text = "Sửa câu hỏi";
            nhchbtnSuaCauHoi.UseSelectable = true;
            nhchbtnSuaCauHoi.UseVisualStyleBackColor = false;
            nhchbtnSuaCauHoi.Click += nhchbtnSuaCauHoi_Click;
            // 
            // nhchbtnThemThuCong
            // 
            nhchbtnThemThuCong.BackColor = Color.Transparent;
            nhchbtnThemThuCong.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            nhchbtnThemThuCong.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            nhchbtnThemThuCong.Image = (Image)resources.GetObject("nhchbtnThemThuCong.Image");
            nhchbtnThemThuCong.ImageAlign = ContentAlignment.MiddleLeft;
            nhchbtnThemThuCong.Location = new Point(1061, 28);
            nhchbtnThemThuCong.Margin = new Padding(5, 4, 5, 4);
            nhchbtnThemThuCong.Name = "nhchbtnThemThuCong";
            nhchbtnThemThuCong.Size = new Size(181, 40);
            nhchbtnThemThuCong.TabIndex = 11;
            nhchbtnThemThuCong.Text = "Thêm câu hỏi thủ công";
            nhchbtnThemThuCong.UseSelectable = true;
            nhchbtnThemThuCong.UseVisualStyleBackColor = false;
            nhchbtnThemThuCong.Click += nhchbtnThemThuCong_Click;
            // 
            // nhchbtnXoaCauHoi
            // 
            nhchbtnXoaCauHoi.BackColor = Color.Transparent;
            nhchbtnXoaCauHoi.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            nhchbtnXoaCauHoi.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            nhchbtnXoaCauHoi.Image = (Image)resources.GetObject("nhchbtnXoaCauHoi.Image");
            nhchbtnXoaCauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            nhchbtnXoaCauHoi.Location = new Point(1440, 28);
            nhchbtnXoaCauHoi.Margin = new Padding(5, 4, 5, 4);
            nhchbtnXoaCauHoi.Name = "nhchbtnXoaCauHoi";
            nhchbtnXoaCauHoi.Size = new Size(181, 40);
            nhchbtnXoaCauHoi.TabIndex = 9;
            nhchbtnXoaCauHoi.Text = "Xoá câu hỏi";
            nhchbtnXoaCauHoi.UseSelectable = true;
            nhchbtnXoaCauHoi.UseVisualStyleBackColor = false;
            nhchbtnXoaCauHoi.Click += nhchbtnXoaCauHoi_Click;
            // 
            // nhchXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 63, 74);
            ClientSize = new Size(1689, 1067);
            Controls.Add(dataCAUHOI);
            Controls.Add(idk);
            Font = new Font("Segoe UI Semibold", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "nhchXemChiTiet";
            Text = "Chi tiết ngân hàng câu hỏi";
            ((System.ComponentModel.ISupportInitialize)dataCAUHOI).EndInit();
            idk.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataCAUHOI;
        private GroupBox idk;
        private ReaLTaiizor.Controls.PoisonButton poisonButton1;
        private ReaLTaiizor.Controls.PoisonButton nhchbtnLamMoi;
        private ReaLTaiizor.Controls.PoisonButton qllbtnTim;
        private ReaLTaiizor.Controls.FoxTextBox qlltxtTimKiem;
        private ReaLTaiizor.Controls.PoisonButton nhchbtnSuaCauHoi;
        private ReaLTaiizor.Controls.PoisonButton nhchbtnThemThuCong;
        private ReaLTaiizor.Controls.PoisonButton nhchbtnXoaCauHoi;
        private ReaLTaiizor.Controls.PoisonButton poisonButton2;
    }
}