namespace Rework_AppThiTracNghiem.forms.ThiSinh
{
    partial class ucKetQua
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
            label1 = new Label();
            labelTenBaiThi = new Label();
            labelSoCauTraLoiDung = new Label();
            labelDiemSo = new Label();
            btnXemLaiBaiLam = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 19.6981125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(241, 68);
            label1.Name = "label1";
            label1.Size = new Size(340, 40);
            label1.TabIndex = 0;
            label1.Text = "BẠN ĐÃ HOÀN THÀNH !";
            // 
            // labelTenBaiThi
            // 
            labelTenBaiThi.AutoSize = true;
            labelTenBaiThi.Font = new Font("SF Mono", 14.2641506F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenBaiThi.Location = new Point(334, 127);
            labelTenBaiThi.Name = "labelTenBaiThi";
            labelTenBaiThi.Size = new Size(155, 25);
            labelTenBaiThi.TabIndex = 1;
            labelTenBaiThi.Text = "Tên bài thi";
            // 
            // labelSoCauTraLoiDung
            // 
            labelSoCauTraLoiDung.AutoSize = true;
            labelSoCauTraLoiDung.Font = new Font("SF Mono", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSoCauTraLoiDung.Location = new Point(275, 234);
            labelSoCauTraLoiDung.Name = "labelSoCauTraLoiDung";
            labelSoCauTraLoiDung.Size = new Size(285, 21);
            labelSoCauTraLoiDung.TabIndex = 2;
            labelSoCauTraLoiDung.Text = "Bạn đã làm đúng 0/10 câu.";
            // 
            // labelDiemSo
            // 
            labelDiemSo.AutoSize = true;
            labelDiemSo.Font = new Font("SF Mono", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDiemSo.Location = new Point(296, 285);
            labelDiemSo.Name = "labelDiemSo";
            labelDiemSo.Size = new Size(230, 21);
            labelDiemSo.TabIndex = 3;
            labelDiemSo.Text = "Số điểm của bạn 0.0đ";
            // 
            // btnXemLaiBaiLam
            // 
            btnXemLaiBaiLam.FlatStyle = FlatStyle.Popup;
            btnXemLaiBaiLam.Location = new Point(287, 360);
            btnXemLaiBaiLam.Name = "btnXemLaiBaiLam";
            btnXemLaiBaiLam.Size = new Size(248, 61);
            btnXemLaiBaiLam.TabIndex = 4;
            btnXemLaiBaiLam.Text = "Xem lại bài làm";
            btnXemLaiBaiLam.UseVisualStyleBackColor = true;
            // 
            // ucKetQua
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXemLaiBaiLam);
            Controls.Add(labelDiemSo);
            Controls.Add(labelSoCauTraLoiDung);
            Controls.Add(labelTenBaiThi);
            Controls.Add(label1);
            Font = new Font("SF Mono", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucKetQua";
            Size = new Size(822, 472);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelTenBaiThi;
        private Label labelSoCauTraLoiDung;
        private Label labelDiemSo;
        private Button btnXemLaiBaiLam;
    }
}
