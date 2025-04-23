namespace Rework_AppThiTracNghiem.forms.BangDiem
{
    partial class ucbdDETHI
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
            labelMaBaiThi = new Label();
            btnxemchitiet = new Button();
            labelstatus = new Label();
            label2 = new Label();
            dateNgayKetThuc = new DateTimePicker();
            dateNgayBatDau = new DateTimePicker();
            labelTenDeThi = new Label();
            labelsoluongsinhvien = new Label();
            SuspendLayout();
            // 
            // labelMaBaiThi
            // 
            labelMaBaiThi.AutoSize = true;
            labelMaBaiThi.Location = new Point(946, 31);
            labelMaBaiThi.Name = "labelMaBaiThi";
            labelMaBaiThi.Size = new Size(69, 19);
            labelMaBaiThi.TabIndex = 16;
            labelMaBaiThi.Text = "label1";
            labelMaBaiThi.Visible = false;
            // 
            // btnxemchitiet
            // 
            btnxemchitiet.FlatStyle = FlatStyle.Popup;
            btnxemchitiet.Location = new Point(946, 53);
            btnxemchitiet.Name = "btnxemchitiet";
            btnxemchitiet.Size = new Size(164, 34);
            btnxemchitiet.TabIndex = 15;
            btnxemchitiet.Text = "Xem chi tiết";
            btnxemchitiet.UseVisualStyleBackColor = true;
            btnxemchitiet.Click += btnxemchitiet_Click;
            // 
            // labelstatus
            // 
            labelstatus.AutoSize = true;
            labelstatus.Location = new Point(529, 66);
            labelstatus.Name = "labelstatus";
            labelstatus.Size = new Size(79, 19);
            labelstatus.TabIndex = 14;
            labelstatus.Text = "Hết hạn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(19, 19);
            label2.TabIndex = 12;
            label2.Text = "-";
            // 
            // dateNgayKetThuc
            // 
            dateNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dateNgayKetThuc.Location = new Point(290, 60);
            dateNgayKetThuc.Name = "dateNgayKetThuc";
            dateNgayKetThuc.Size = new Size(221, 27);
            dateNgayKetThuc.TabIndex = 11;
            // 
            // dateNgayBatDau
            // 
            dateNgayBatDau.Format = DateTimePickerFormat.Custom;
            dateNgayBatDau.Location = new Point(17, 60);
            dateNgayBatDau.Name = "dateNgayBatDau";
            dateNgayBatDau.Size = new Size(221, 27);
            dateNgayBatDau.TabIndex = 10;
            // 
            // labelTenDeThi
            // 
            labelTenDeThi.AutoSize = true;
            labelTenDeThi.Font = new Font("SF Mono", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenDeThi.Location = new Point(17, 18);
            labelTenDeThi.Margin = new Padding(4, 0, 4, 0);
            labelTenDeThi.Name = "labelTenDeThi";
            labelTenDeThi.Size = new Size(76, 21);
            labelTenDeThi.TabIndex = 9;
            labelTenDeThi.Text = "label1";
            // 
            // labelsoluongsinhvien
            // 
            labelsoluongsinhvien.AutoSize = true;
            labelsoluongsinhvien.Location = new Point(786, 66);
            labelsoluongsinhvien.Name = "labelsoluongsinhvien";
            labelsoluongsinhvien.Size = new Size(79, 19);
            labelsoluongsinhvien.TabIndex = 17;
            labelsoluongsinhvien.Text = "Hết hạn";
            // 
            // ucbdDETHI
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelsoluongsinhvien);
            Controls.Add(labelMaBaiThi);
            Controls.Add(btnxemchitiet);
            Controls.Add(labelstatus);
            Controls.Add(label2);
            Controls.Add(dateNgayKetThuc);
            Controls.Add(dateNgayBatDau);
            Controls.Add(labelTenDeThi);
            Font = new Font("SF Mono", 10.8679247F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucbdDETHI";
            Size = new Size(1127, 103);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMaBaiThi;
        private Button btnxemchitiet;
        private Label labelstatus;
        private Label label2;
        private DateTimePicker dateNgayKetThuc;
        private DateTimePicker dateNgayBatDau;
        private Label labelTenDeThi;
        private Label labelsoluongsinhvien;
    }
}
