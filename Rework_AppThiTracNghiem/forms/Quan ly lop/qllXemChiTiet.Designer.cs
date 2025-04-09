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
            qllbtnXoaThanhVien = new ReaLTaiizor.Controls.PoisonButton();
            qllgroupbox = new GroupBox();
            qllbtnLamMoi = new ReaLTaiizor.Controls.PoisonButton();
            qllbtnTim = new ReaLTaiizor.Controls.PoisonButton();
            qlltxtTimKiem = new ReaLTaiizor.Controls.FoxTextBox();
            qllbtnSuaThanhVien = new ReaLTaiizor.Controls.PoisonButton();
            qllbtnThemThanhVien = new ReaLTaiizor.Controls.PoisonButton();
            dataThanhVien = new DataGridView();
            qllgroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataThanhVien).BeginInit();
            SuspendLayout();
            // 
            // qllbtnXoaThanhVien
            // 
            qllbtnXoaThanhVien.BackColor = Color.Transparent;
            qllbtnXoaThanhVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnXoaThanhVien.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnXoaThanhVien.Image = (Image)resources.GetObject("qllbtnXoaThanhVien.Image");
            qllbtnXoaThanhVien.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnXoaThanhVien.Location = new Point(1354, 49);
            qllbtnXoaThanhVien.Margin = new Padding(4);
            qllbtnXoaThanhVien.Name = "qllbtnXoaThanhVien";
            qllbtnXoaThanhVien.Size = new Size(158, 40);
            qllbtnXoaThanhVien.TabIndex = 9;
            qllbtnXoaThanhVien.Text = "Xoá thành viên";
            qllbtnXoaThanhVien.UseSelectable = true;
            qllbtnXoaThanhVien.UseVisualStyleBackColor = false;
            qllbtnXoaThanhVien.Click += qllbtnXoaThanhVien_Click;
            // 
            // qllgroupbox
            // 
            qllgroupbox.Controls.Add(qllbtnLamMoi);
            qllgroupbox.Controls.Add(qllbtnTim);
            qllgroupbox.Controls.Add(qlltxtTimKiem);
            qllgroupbox.Controls.Add(qllbtnSuaThanhVien);
            qllgroupbox.Controls.Add(qllbtnThemThanhVien);
            qllgroupbox.Controls.Add(qllbtnXoaThanhVien);
            qllgroupbox.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qllgroupbox.ForeColor = Color.White;
            qllgroupbox.Location = new Point(25, 15);
            qllgroupbox.Margin = new Padding(4);
            qllgroupbox.Name = "qllgroupbox";
            qllgroupbox.Padding = new Padding(4);
            qllgroupbox.Size = new Size(1521, 138);
            qllgroupbox.TabIndex = 10;
            qllgroupbox.TabStop = false;
            qllgroupbox.Text = "Chi tiết lớp";
            // 
            // qllbtnLamMoi
            // 
            qllbtnLamMoi.BackColor = Color.Transparent;
            qllbtnLamMoi.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnLamMoi.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnLamMoi.Image = (Image)resources.GetObject("qllbtnLamMoi.Image");
            qllbtnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnLamMoi.Location = new Point(728, 49);
            qllbtnLamMoi.Margin = new Padding(4);
            qllbtnLamMoi.Name = "qllbtnLamMoi";
            qllbtnLamMoi.Size = new Size(158, 40);
            qllbtnLamMoi.TabIndex = 15;
            qllbtnLamMoi.Text = "Làm mới";
            qllbtnLamMoi.UseSelectable = true;
            qllbtnLamMoi.UseVisualStyleBackColor = false;
            qllbtnLamMoi.Click += qllbtnLamMoi_Click;
            // 
            // qllbtnTim
            // 
            qllbtnTim.BackColor = Color.Transparent;
            qllbtnTim.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnTim.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnTim.Image = (Image)resources.GetObject("qllbtnTim.Image");
            qllbtnTim.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnTim.Location = new Point(404, 49);
            qllbtnTim.Margin = new Padding(4);
            qllbtnTim.Name = "qllbtnTim";
            qllbtnTim.Size = new Size(158, 40);
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
            qlltxtTimKiem.Location = new Point(8, 49);
            qlltxtTimKiem.Margin = new Padding(4);
            qlltxtTimKiem.MaxLength = 32767;
            qlltxtTimKiem.MultiLine = false;
            qlltxtTimKiem.Name = "qlltxtTimKiem";
            qlltxtTimKiem.ReadOnly = false;
            qlltxtTimKiem.Size = new Size(388, 40);
            qlltxtTimKiem.TabIndex = 13;
            qlltxtTimKiem.Text = "Tìm kiếm";
            qlltxtTimKiem.TextAlign = HorizontalAlignment.Left;
            qlltxtTimKiem.UseSystemPasswordChar = false;
            // 
            // qllbtnSuaThanhVien
            // 
            qllbtnSuaThanhVien.BackColor = Color.Transparent;
            qllbtnSuaThanhVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnSuaThanhVien.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnSuaThanhVien.Image = (Image)resources.GetObject("qllbtnSuaThanhVien.Image");
            qllbtnSuaThanhVien.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnSuaThanhVien.Location = new Point(1188, 49);
            qllbtnSuaThanhVien.Margin = new Padding(4);
            qllbtnSuaThanhVien.Name = "qllbtnSuaThanhVien";
            qllbtnSuaThanhVien.Size = new Size(158, 40);
            qllbtnSuaThanhVien.TabIndex = 12;
            qllbtnSuaThanhVien.Text = "Sửa thành viên";
            qllbtnSuaThanhVien.UseSelectable = true;
            qllbtnSuaThanhVien.UseVisualStyleBackColor = false;
            qllbtnSuaThanhVien.Click += qllbtnSuaThanhVien_Click;
            // 
            // qllbtnThemThanhVien
            // 
            qllbtnThemThanhVien.BackColor = Color.Transparent;
            qllbtnThemThanhVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnThemThanhVien.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnThemThanhVien.Image = (Image)resources.GetObject("qllbtnThemThanhVien.Image");
            qllbtnThemThanhVien.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnThemThanhVien.Location = new Point(1022, 49);
            qllbtnThemThanhVien.Margin = new Padding(4);
            qllbtnThemThanhVien.Name = "qllbtnThemThanhVien";
            qllbtnThemThanhVien.Size = new Size(158, 40);
            qllbtnThemThanhVien.TabIndex = 11;
            qllbtnThemThanhVien.Text = "Thêm thành viên";
            qllbtnThemThanhVien.UseSelectable = true;
            qllbtnThemThanhVien.UseVisualStyleBackColor = false;
            qllbtnThemThanhVien.Click += qllbtnThemThanhVien_Click;
            // 
            // dataThanhVien
            // 
            dataThanhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataThanhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataThanhVien.Location = new Point(25, 208);
            dataThanhVien.Margin = new Padding(4);
            dataThanhVien.Name = "dataThanhVien";
            dataThanhVien.RowHeadersWidth = 45;
            dataThanhVien.Size = new Size(1521, 729);
            dataThanhVien.TabIndex = 11;
            dataThanhVien.TabStop = false;
            dataThanhVien.CellClick += dataThanhVien_CellClick;
            // 
            // qllXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 63, 74);
            ClientSize = new Size(1571, 950);
            Controls.Add(dataThanhVien);
            Controls.Add(qllgroupbox);
            Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "qllXemChiTiet";
            Text = "Chi tiết lớp học";
            qllgroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataThanhVien).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.PoisonButton qllbtnXoaThanhVien;
        private GroupBox qllgroupbox;
        private ReaLTaiizor.Controls.PoisonButton qllbtnThemThanhVien;
        private ReaLTaiizor.Controls.PoisonButton qllbtnSuaThanhVien;
        private ReaLTaiizor.Controls.PoisonButton qllbtnTim;
        private ReaLTaiizor.Controls.FoxTextBox qlltxtTimKiem;
        private ReaLTaiizor.Controls.PoisonButton qllbtnLamMoi;
        private DataGridView dataThanhVien;
    }
}