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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qllXemChiTiet));
            dataThanhVien = new ReaLTaiizor.Controls.PoisonDataGridView();
            qllbtnXoaThanhVien = new ReaLTaiizor.Controls.PoisonButton();
            qllgroupbox = new GroupBox();
            qllbtnTim = new ReaLTaiizor.Controls.PoisonButton();
            qlltxtTimKiem = new ReaLTaiizor.Controls.FoxTextBox();
            qllbtnSuaThanhVien = new ReaLTaiizor.Controls.PoisonButton();
            qllbtnThemThanhVien = new ReaLTaiizor.Controls.PoisonButton();
            ((System.ComponentModel.ISupportInitialize)dataThanhVien).BeginInit();
            qllgroupbox.SuspendLayout();
            SuspendLayout();
            // 
            // dataThanhVien
            // 
            dataThanhVien.AllowUserToResizeRows = false;
            dataThanhVien.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataThanhVien.BorderStyle = BorderStyle.None;
            dataThanhVien.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataThanhVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataThanhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataThanhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataThanhVien.DefaultCellStyle = dataGridViewCellStyle2;
            dataThanhVien.EnableHeadersVisualStyles = false;
            dataThanhVien.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataThanhVien.GridColor = Color.FromArgb(255, 255, 255);
            dataThanhVien.Location = new Point(12, 153);
            dataThanhVien.Name = "dataThanhVien";
            dataThanhVien.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataThanhVien.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataThanhVien.RowHeadersWidth = 45;
            dataThanhVien.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataThanhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataThanhVien.Size = new Size(1255, 604);
            dataThanhVien.TabIndex = 0;
            // 
            // qllbtnXoaThanhVien
            // 
            qllbtnXoaThanhVien.BackColor = Color.Transparent;
            qllbtnXoaThanhVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnXoaThanhVien.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnXoaThanhVien.Image = (Image)resources.GetObject("qllbtnXoaThanhVien.Image");
            qllbtnXoaThanhVien.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnXoaThanhVien.Location = new Point(1108, 35);
            qllbtnXoaThanhVien.Name = "qllbtnXoaThanhVien";
            qllbtnXoaThanhVien.Size = new Size(123, 32);
            qllbtnXoaThanhVien.TabIndex = 9;
            qllbtnXoaThanhVien.Text = "Xoá thành viên";
            qllbtnXoaThanhVien.UseSelectable = true;
            qllbtnXoaThanhVien.UseVisualStyleBackColor = false;
            // 
            // qllgroupbox
            // 
            qllgroupbox.Controls.Add(qllbtnTim);
            qllgroupbox.Controls.Add(qlltxtTimKiem);
            qllgroupbox.Controls.Add(qllbtnSuaThanhVien);
            qllgroupbox.Controls.Add(qllbtnThemThanhVien);
            qllgroupbox.Controls.Add(qllbtnXoaThanhVien);
            qllgroupbox.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qllgroupbox.ForeColor = Color.White;
            qllgroupbox.Location = new Point(12, 12);
            qllgroupbox.Name = "qllgroupbox";
            qllgroupbox.Size = new Size(1255, 102);
            qllgroupbox.TabIndex = 10;
            qllgroupbox.TabStop = false;
            qllgroupbox.Text = "Chi tiết lớp";
            // 
            // qllbtnTim
            // 
            qllbtnTim.BackColor = Color.Transparent;
            qllbtnTim.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnTim.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnTim.Image = (Image)resources.GetObject("qllbtnTim.Image");
            qllbtnTim.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnTim.Location = new Point(314, 35);
            qllbtnTim.Name = "qllbtnTim";
            qllbtnTim.Size = new Size(123, 32);
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
            qlltxtTimKiem.Location = new Point(6, 35);
            qlltxtTimKiem.MaxLength = 32767;
            qlltxtTimKiem.MultiLine = false;
            qlltxtTimKiem.Name = "qlltxtTimKiem";
            qlltxtTimKiem.ReadOnly = false;
            qlltxtTimKiem.Size = new Size(302, 32);
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
            qllbtnSuaThanhVien.Location = new Point(954, 35);
            qllbtnSuaThanhVien.Name = "qllbtnSuaThanhVien";
            qllbtnSuaThanhVien.Size = new Size(123, 32);
            qllbtnSuaThanhVien.TabIndex = 12;
            qllbtnSuaThanhVien.Text = "Sửa thành viên";
            qllbtnSuaThanhVien.UseSelectable = true;
            qllbtnSuaThanhVien.UseVisualStyleBackColor = false;
            // 
            // qllbtnThemThanhVien
            // 
            qllbtnThemThanhVien.BackColor = Color.Transparent;
            qllbtnThemThanhVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnThemThanhVien.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnThemThanhVien.Image = (Image)resources.GetObject("qllbtnThemThanhVien.Image");
            qllbtnThemThanhVien.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnThemThanhVien.Location = new Point(795, 35);
            qllbtnThemThanhVien.Name = "qllbtnThemThanhVien";
            qllbtnThemThanhVien.Size = new Size(123, 32);
            qllbtnThemThanhVien.TabIndex = 11;
            qllbtnThemThanhVien.Text = "Thêm thành viên";
            qllbtnThemThanhVien.UseSelectable = true;
            qllbtnThemThanhVien.UseVisualStyleBackColor = false;
            // 
            // qllXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Coral;
            ClientSize = new Size(1279, 769);
            Controls.Add(qllgroupbox);
            Controls.Add(dataThanhVien);
            Name = "qllXemChiTiet";
            Text = "Chi tiết lớp học";
            ((System.ComponentModel.ISupportInitialize)dataThanhVien).EndInit();
            qllgroupbox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView dataThanhVien;
        private ReaLTaiizor.Controls.PoisonButton qllbtnXoaThanhVien;
        private GroupBox qllgroupbox;
        private ReaLTaiizor.Controls.PoisonButton qllbtnThemThanhVien;
        private ReaLTaiizor.Controls.PoisonButton qllbtnSuaThanhVien;
        private ReaLTaiizor.Controls.PoisonButton qllbtnTim;
        private ReaLTaiizor.Controls.FoxTextBox qlltxtTimKiem;
    }
}