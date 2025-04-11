namespace Rework_AppThiTracNghiem.forms.Quan_ly_NHCH
{
    partial class nhchSuaNHCH
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
            idk = new Label();
            nhchbtnHuy = new ReaLTaiizor.Controls.FoxButton();
            nhchbtnSua = new ReaLTaiizor.Controls.FoxButton();
            nhchbtnSuaDong = new ReaLTaiizor.Controls.FoxButton();
            nhchtxtTenNganHang = new ReaLTaiizor.Controls.PoisonTextBox();
            foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            SuspendLayout();
            // 
            // idk
            // 
            idk.AutoSize = true;
            idk.ForeColor = Color.White;
            idk.Location = new Point(148, 22);
            idk.Name = "idk";
            idk.Size = new Size(53, 17);
            idk.TabIndex = 16;
            idk.Text = "preview";
            // 
            // nhchbtnHuy
            // 
            nhchbtnHuy.BackColor = Color.Transparent;
            nhchbtnHuy.BaseColor = Color.FromArgb(249, 249, 249);
            nhchbtnHuy.BorderColor = Color.FromArgb(193, 193, 193);
            nhchbtnHuy.DisabledBaseColor = Color.FromArgb(249, 249, 249);
            nhchbtnHuy.DisabledBorderColor = Color.FromArgb(209, 209, 209);
            nhchbtnHuy.DisabledTextColor = Color.FromArgb(166, 178, 190);
            nhchbtnHuy.DownColor = Color.FromArgb(232, 232, 232);
            nhchbtnHuy.EnabledCalc = true;
            nhchbtnHuy.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nhchbtnHuy.ForeColor = Color.FromArgb(66, 78, 90);
            nhchbtnHuy.Location = new Point(148, 103);
            nhchbtnHuy.Name = "nhchbtnHuy";
            nhchbtnHuy.OverColor = Color.FromArgb(242, 242, 242);
            nhchbtnHuy.Size = new Size(101, 32);
            nhchbtnHuy.TabIndex = 15;
            nhchbtnHuy.Text = "Huỷ";
            nhchbtnHuy.Click += nhchbtnHuy_Click;
            // 
            // nhchbtnSua
            // 
            nhchbtnSua.BackColor = Color.Transparent;
            nhchbtnSua.BaseColor = Color.Gray;
            nhchbtnSua.BorderColor = Color.FromArgb(193, 193, 193);
            nhchbtnSua.DisabledBaseColor = Color.FromArgb(249, 249, 249);
            nhchbtnSua.DisabledBorderColor = Color.FromArgb(209, 209, 209);
            nhchbtnSua.DisabledTextColor = Color.FromArgb(166, 178, 190);
            nhchbtnSua.DownColor = Color.FromArgb(232, 232, 232);
            nhchbtnSua.EnabledCalc = true;
            nhchbtnSua.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nhchbtnSua.ForeColor = Color.White;
            nhchbtnSua.Location = new Point(267, 103);
            nhchbtnSua.Name = "nhchbtnSua";
            nhchbtnSua.OverColor = Color.FromArgb(242, 242, 242);
            nhchbtnSua.Size = new Size(101, 32);
            nhchbtnSua.TabIndex = 14;
            nhchbtnSua.Text = "Sửa";
            nhchbtnSua.Click += nhchbtnSua_Click;
            // 
            // nhchbtnSuaDong
            // 
            nhchbtnSuaDong.BackColor = Color.Transparent;
            nhchbtnSuaDong.BaseColor = Color.FromArgb(128, 255, 128);
            nhchbtnSuaDong.BorderColor = Color.FromArgb(193, 193, 193);
            nhchbtnSuaDong.DisabledBaseColor = Color.FromArgb(249, 249, 249);
            nhchbtnSuaDong.DisabledBorderColor = Color.FromArgb(209, 209, 209);
            nhchbtnSuaDong.DisabledTextColor = Color.FromArgb(166, 178, 190);
            nhchbtnSuaDong.DownColor = Color.FromArgb(232, 232, 232);
            nhchbtnSuaDong.EnabledCalc = true;
            nhchbtnSuaDong.Font = new Font("Segoe UI Semibold", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nhchbtnSuaDong.ForeColor = Color.Black;
            nhchbtnSuaDong.Location = new Point(389, 103);
            nhchbtnSuaDong.Name = "nhchbtnSuaDong";
            nhchbtnSuaDong.OverColor = Color.FromArgb(242, 242, 242);
            nhchbtnSuaDong.Size = new Size(109, 32);
            nhchbtnSuaDong.TabIndex = 13;
            nhchbtnSuaDong.Text = "Sửa và đóng";
            nhchbtnSuaDong.Click += nhchbtnSuaDong_Click;
            // 
            // nhchtxtTenNganHang
            // 
            // 
            // 
            // 
            nhchtxtTenNganHang.CustomButton.Image = null;
            nhchtxtTenNganHang.CustomButton.Location = new Point(462, 1);
            nhchtxtTenNganHang.CustomButton.Name = "";
            nhchtxtTenNganHang.CustomButton.Size = new Size(23, 23);
            nhchtxtTenNganHang.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            nhchtxtTenNganHang.CustomButton.TabIndex = 1;
            nhchtxtTenNganHang.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            nhchtxtTenNganHang.CustomButton.UseSelectable = true;
            nhchtxtTenNganHang.CustomButton.Visible = false;
            nhchtxtTenNganHang.Location = new Point(12, 49);
            nhchtxtTenNganHang.MaxLength = 32767;
            nhchtxtTenNganHang.Name = "nhchtxtTenNganHang";
            nhchtxtTenNganHang.PasswordChar = '\0';
            nhchtxtTenNganHang.ScrollBars = ScrollBars.None;
            nhchtxtTenNganHang.SelectedText = "";
            nhchtxtTenNganHang.SelectionLength = 0;
            nhchtxtTenNganHang.SelectionStart = 0;
            nhchtxtTenNganHang.ShortcutsEnabled = true;
            nhchtxtTenNganHang.Size = new Size(486, 25);
            nhchtxtTenNganHang.TabIndex = 12;
            nhchtxtTenNganHang.UseSelectable = true;
            nhchtxtTenNganHang.WaterMarkColor = Color.FromArgb(109, 109, 109);
            nhchtxtTenNganHang.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // foxLabel1
            // 
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            foxLabel1.ForeColor = Color.White;
            foxLabel1.Location = new Point(12, 22);
            foxLabel1.Name = "foxLabel1";
            foxLabel1.Size = new Size(387, 21);
            foxLabel1.TabIndex = 11;
            foxLabel1.Text = "Tên môn học ";
            // 
            // nhchSuaNHCH
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 63, 74);
            ClientSize = new Size(529, 163);
            Controls.Add(idk);
            Controls.Add(nhchbtnHuy);
            Controls.Add(nhchbtnSua);
            Controls.Add(nhchbtnSuaDong);
            Controls.Add(nhchtxtTenNganHang);
            Controls.Add(foxLabel1);
            Name = "nhchSuaNHCH";
            Text = "Sửa NHCH";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idk;
        private ReaLTaiizor.Controls.FoxButton nhchbtnHuy;
        private ReaLTaiizor.Controls.FoxButton nhchbtnSua;
        private ReaLTaiizor.Controls.FoxButton nhchbtnSuaDong;
        private ReaLTaiizor.Controls.PoisonTextBox nhchtxtTenNganHang;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
    }
}