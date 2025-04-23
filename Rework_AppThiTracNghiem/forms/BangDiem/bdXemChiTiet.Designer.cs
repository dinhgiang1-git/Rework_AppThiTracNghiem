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
            bdcbDeThi = new ComboBox();
            qllbtnLamMoi = new ReaLTaiizor.Controls.PoisonButton();
            bdbtnTim = new ReaLTaiizor.Controls.PoisonButton();
            bdtxtTim = new ReaLTaiizor.Controls.FoxTextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataBangDiem).BeginInit();
            bdgroupbox.SuspendLayout();
            SuspendLayout();
            // 
            // dataBangDiem
            // 
            dataBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataBangDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataBangDiem.Location = new Point(25, 160);
            dataBangDiem.Margin = new Padding(4);
            dataBangDiem.Name = "dataBangDiem";
            dataBangDiem.RowHeadersWidth = 45;
            dataBangDiem.Size = new Size(1521, 776);
            dataBangDiem.TabIndex = 13;
            dataBangDiem.TabStop = false;
            // 
            // bdgroupbox
            // 
            bdgroupbox.Controls.Add(label4);
            bdgroupbox.Controls.Add(bdcbDeThi);
            bdgroupbox.Controls.Add(qllbtnLamMoi);
            bdgroupbox.Controls.Add(bdbtnTim);
            bdgroupbox.Controls.Add(bdtxtTim);
            bdgroupbox.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bdgroupbox.ForeColor = Color.White;
            bdgroupbox.Location = new Point(25, 14);
            bdgroupbox.Margin = new Padding(4);
            bdgroupbox.Name = "bdgroupbox";
            bdgroupbox.Padding = new Padding(4);
            bdgroupbox.Size = new Size(1521, 138);
            bdgroupbox.TabIndex = 12;
            bdgroupbox.TabStop = false;
            bdgroupbox.Text = "Chi tiết bảng điểm Lớp 73DCHT23";
            // 
            // bdcbDeThi
            // 
            bdcbDeThi.FormattingEnabled = true;
            bdcbDeThi.Location = new Point(80, 97);
            bdcbDeThi.Name = "bdcbDeThi";
            bdcbDeThi.Size = new Size(316, 28);
            bdcbDeThi.TabIndex = 16;
            // 
            // qllbtnLamMoi
            // 
            qllbtnLamMoi.BackColor = Color.Transparent;
            qllbtnLamMoi.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            qllbtnLamMoi.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            qllbtnLamMoi.Image = (Image)resources.GetObject("qllbtnLamMoi.Image");
            qllbtnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            qllbtnLamMoi.Location = new Point(404, 85);
            qllbtnLamMoi.Margin = new Padding(4);
            qllbtnLamMoi.Name = "qllbtnLamMoi";
            qllbtnLamMoi.Size = new Size(158, 40);
            qllbtnLamMoi.TabIndex = 15;
            qllbtnLamMoi.Text = "Làm mới";
            qllbtnLamMoi.UseSelectable = true;
            qllbtnLamMoi.UseVisualStyleBackColor = false;
            // 
            // bdbtnTim
            // 
            bdbtnTim.BackColor = Color.Transparent;
            bdbtnTim.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
            bdbtnTim.FontSize = ReaLTaiizor.Extension.Poison.PoisonButtonSize.Medium;
            bdbtnTim.Image = (Image)resources.GetObject("bdbtnTim.Image");
            bdbtnTim.ImageAlign = ContentAlignment.MiddleLeft;
            bdbtnTim.Location = new Point(404, 37);
            bdbtnTim.Margin = new Padding(4);
            bdbtnTim.Name = "bdbtnTim";
            bdbtnTim.Size = new Size(158, 40);
            bdbtnTim.TabIndex = 14;
            bdbtnTim.Text = "Tìm";
            bdbtnTim.UseSelectable = true;
            bdbtnTim.UseVisualStyleBackColor = false;
            // 
            // bdtxtTim
            // 
            bdtxtTim.BackColor = Color.White;
            bdtxtTim.EnabledCalc = true;
            bdtxtTim.Font = new Font("Segoe UI", 10F);
            bdtxtTim.ForeColor = Color.Black;
            bdtxtTim.Location = new Point(8, 37);
            bdtxtTim.Margin = new Padding(4);
            bdtxtTim.MaxLength = 32767;
            bdtxtTim.MultiLine = false;
            bdtxtTim.Name = "bdtxtTim";
            bdtxtTim.ReadOnly = false;
            bdtxtTim.Size = new Size(388, 40);
            bdtxtTim.TabIndex = 13;
            bdtxtTim.Text = "Tìm kiếm";
            bdtxtTim.TextAlign = HorizontalAlignment.Left;
            bdtxtTim.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(8, 100);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 18;
            label4.Text = "Chọn đề";
            // 
            // bdXemChiTiet
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 63, 74);
            ClientSize = new Size(1571, 950);
            Controls.Add(dataBangDiem);
            Controls.Add(bdgroupbox);
            Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "bdXemChiTiet";
            Text = "bdXemChiTiet";
            ((System.ComponentModel.ISupportInitialize)dataBangDiem).EndInit();
            bdgroupbox.ResumeLayout(false);
            bdgroupbox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataBangDiem;
        private GroupBox bdgroupbox;
        private ReaLTaiizor.Controls.PoisonButton qllbtnLamMoi;
        private ReaLTaiizor.Controls.PoisonButton bdbtnTim;
        private ReaLTaiizor.Controls.FoxTextBox bdtxtTim;
        private ComboBox bdcbDeThi;
        private Label label4;
    }
}