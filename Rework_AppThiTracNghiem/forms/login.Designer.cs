namespace Rework_AppThiTracNghiem
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            pictureBox1 = new PictureBox();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            logintxtTenDangNhap = new TextBox();
            label1 = new Label();
            label2 = new Label();
            logintxtMatKhau = new TextBox();
            logincbChonVaiTro = new ComboBox();
            loginbtnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 168);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(325, 219);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI Semibold", 19.6981125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = SystemColors.ButtonFace;
            bigLabel1.Location = new Point(32, 45);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(742, 40);
            bigLabel1.TabIndex = 1;
            bigLabel1.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI";
            // 
            // bigLabel2
            // 
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = Color.Transparent;
            bigLabel2.Font = new Font("Segoe UI Semibold", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = SystemColors.ButtonFace;
            bigLabel2.Location = new Point(243, 10);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(314, 35);
            bigLabel2.TabIndex = 2;
            bigLabel2.Text = "BỘ GIAO THÔNG VẬN TẢI";
            // 
            // bigLabel3
            // 
            bigLabel3.AutoSize = true;
            bigLabel3.BackColor = Color.Transparent;
            bigLabel3.Font = new Font("Segoe UI Semibold", 16.3018875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel3.ForeColor = SystemColors.ButtonFace;
            bigLabel3.Location = new Point(146, 85);
            bigLabel3.Name = "bigLabel3";
            bigLabel3.Size = new Size(509, 35);
            bigLabel3.TabIndex = 3;
            bigLabel3.Text = "UNIVERSITY OF TRANSPORT TECHNOLOGY";
            // 
            // logintxtTenDangNhap
            // 
            logintxtTenDangNhap.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            logintxtTenDangNhap.ForeColor = Color.FromArgb(155, 161, 165);
            logintxtTenDangNhap.Location = new Point(394, 185);
            logintxtTenDangNhap.Name = "logintxtTenDangNhap";
            logintxtTenDangNhap.Size = new Size(330, 29);
            logintxtTenDangNhap.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(394, 157);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 21;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(394, 233);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 23;
            label2.Text = "Mật khẩu";
            // 
            // logintxtMatKhau
            // 
            logintxtMatKhau.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            logintxtMatKhau.ForeColor = Color.FromArgb(155, 161, 165);
            logintxtMatKhau.Location = new Point(394, 261);
            logintxtMatKhau.Name = "logintxtMatKhau";
            logintxtMatKhau.PasswordChar = '*';
            logintxtMatKhau.Size = new Size(330, 29);
            logintxtMatKhau.TabIndex = 22;
            // 
            // logincbChonVaiTro
            // 
            logincbChonVaiTro.Font = new Font("Segoe UI Semibold", 10.8679247F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            logincbChonVaiTro.ForeColor = Color.FromArgb(155, 161, 165);
            logincbChonVaiTro.FormattingEnabled = true;
            logincbChonVaiTro.Items.AddRange(new object[] { "--Chọn vai trò--", "Thí sinh", "Admin" });
            logincbChonVaiTro.Location = new Point(394, 327);
            logincbChonVaiTro.Name = "logincbChonVaiTro";
            logincbChonVaiTro.Size = new Size(330, 29);
            logincbChonVaiTro.TabIndex = 24;
            // 
            // loginbtnLogin
            // 
            loginbtnLogin.BackColor = Color.FromArgb(32, 191, 107);
            loginbtnLogin.FlatStyle = FlatStyle.Popup;
            loginbtnLogin.Font = new Font("Segoe UI", 8.830189F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtnLogin.ForeColor = Color.FromArgb(0, 31, 31);
            loginbtnLogin.Location = new Point(459, 379);
            loginbtnLogin.Name = "loginbtnLogin";
            loginbtnLogin.Size = new Size(210, 41);
            loginbtnLogin.TabIndex = 25;
            loginbtnLogin.Text = "Đăng nhập";
            loginbtnLogin.UseVisualStyleBackColor = false;
            loginbtnLogin.Click += loginbtnLogin_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Coral;
            ClientSize = new Size(800, 450);
            Controls.Add(loginbtnLogin);
            Controls.Add(logincbChonVaiTro);
            Controls.Add(label2);
            Controls.Add(logintxtMatKhau);
            Controls.Add(label1);
            Controls.Add(logintxtTenDangNhap);
            Controls.Add(bigLabel3);
            Controls.Add(bigLabel2);
            Controls.Add(bigLabel1);
            Controls.Add(pictureBox1);
            ForeColor = Color.FromArgb(255, 245, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 491);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosed += login_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private TextBox logintxtTenDangNhap;
        private Label label1;
        private Label label2;
        private TextBox logintxtMatKhau;
        private ComboBox logincbChonVaiTro;
        private Button loginbtnLogin;
    }
}