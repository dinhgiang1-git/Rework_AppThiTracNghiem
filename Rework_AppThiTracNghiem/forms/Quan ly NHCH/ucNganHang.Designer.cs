namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH.flowLayout
{
    partial class ucNganHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucTenNganHang = new Label();
            ucSoLuongCauHoi = new Label();
            btnXemChiTiet = new Button();
            ucMaNganHang = new Label();
            SuspendLayout();
            // 
            // ucTenNganHang
            // 
            ucTenNganHang.AutoSize = true;
            ucTenNganHang.Font = new Font("SF Mono", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ucTenNganHang.Location = new Point(17, 22);
            ucTenNganHang.Name = "ucTenNganHang";
            ucTenNganHang.Size = new Size(139, 19);
            ucTenNganHang.TabIndex = 0;
            ucTenNganHang.Text = "Tên ngân hàng";
            // 
            // ucSoLuongCauHoi
            // 
            ucSoLuongCauHoi.AutoSize = true;
            ucSoLuongCauHoi.Font = new Font("SF Mono", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ucSoLuongCauHoi.Location = new Point(17, 69);
            ucSoLuongCauHoi.Name = "ucSoLuongCauHoi";
            ucSoLuongCauHoi.Size = new Size(151, 16);
            ucSoLuongCauHoi.TabIndex = 1;
            ucSoLuongCauHoi.Text = "Số lượng câu hỏi: ";
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.FlatStyle = FlatStyle.Popup;
            btnXemChiTiet.Location = new Point(287, 58);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(168, 34);
            btnXemChiTiet.TabIndex = 2;
            btnXemChiTiet.Text = "Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = true;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // ucMaNganHang
            // 
            ucMaNganHang.AutoSize = true;
            ucMaNganHang.Font = new Font("SF Mono", 8.150944F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ucMaNganHang.ForeColor = Color.White;
            ucMaNganHang.Location = new Point(266, 69);
            ucMaNganHang.Name = "ucMaNganHang";
            ucMaNganHang.Size = new Size(15, 16);
            ucMaNganHang.TabIndex = 3;
            ucMaNganHang.Text = "1";
            // 
            // ucNganHang
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucMaNganHang);
            Controls.Add(btnXemChiTiet);
            Controls.Add(ucSoLuongCauHoi);
            Controls.Add(ucTenNganHang);
            Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucNganHang";
            Size = new Size(471, 104);
            Click += ucNganHang_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ucTenNganHang;
        private Label ucSoLuongCauHoi;
        private Button btnXemChiTiet;
        private Label ucMaNganHang;
    }
}
