namespace Rework_AppThiTracNghiem.forms.Quan_ly_lop.flowLayout
{
    partial class ucLop
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
            flowlopMaLop = new Label();
            flowlopSiSo = new Label();
            flowlopTenLop = new Label();
            flowLopXemChiTiet = new Button();
            SuspendLayout();
            // 
            // flowlopMaLop
            // 
            flowlopMaLop.AutoSize = true;
            flowlopMaLop.Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowlopMaLop.Location = new Point(360, 11);
            flowlopMaLop.Margin = new Padding(4, 0, 4, 0);
            flowlopMaLop.Name = "flowlopMaLop";
            flowlopMaLop.Size = new Size(62, 18);
            flowlopMaLop.TabIndex = 0;
            flowlopMaLop.Text = "mã lớp";
            // 
            // flowlopSiSo
            // 
            flowlopSiSo.AutoSize = true;
            flowlopSiSo.Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowlopSiSo.Location = new Point(19, 44);
            flowlopSiSo.Margin = new Padding(4, 0, 4, 0);
            flowlopSiSo.Name = "flowlopSiSo";
            flowlopSiSo.Size = new Size(44, 18);
            flowlopSiSo.TabIndex = 1;
            flowlopSiSo.Text = "siso";
            // 
            // flowlopTenLop
            // 
            flowlopTenLop.AutoSize = true;
            flowlopTenLop.Font = new Font("SF Mono", 12.2264156F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowlopTenLop.Location = new Point(19, 8);
            flowlopTenLop.Margin = new Padding(4, 0, 4, 0);
            flowlopTenLop.Name = "flowlopTenLop";
            flowlopTenLop.Size = new Size(87, 21);
            flowlopTenLop.TabIndex = 2;
            flowlopTenLop.Text = "Tên lớp";
            // 
            // flowLopXemChiTiet
            // 
            flowLopXemChiTiet.FlatStyle = FlatStyle.Popup;
            flowLopXemChiTiet.Location = new Point(360, 36);
            flowLopXemChiTiet.Name = "flowLopXemChiTiet";
            flowLopXemChiTiet.Size = new Size(135, 34);
            flowLopXemChiTiet.TabIndex = 3;
            flowLopXemChiTiet.Text = "Xem chi tiết";
            flowLopXemChiTiet.UseVisualStyleBackColor = true;
            flowLopXemChiTiet.Click += flowLopXemChiTiet_Click;
            // 
            // ucLop
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLopXemChiTiet);
            Controls.Add(flowlopTenLop);
            Controls.Add(flowlopSiSo);
            Controls.Add(flowlopMaLop);
            Font = new Font("SF Mono", 10.18868F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucLop";
            Size = new Size(512, 79);
            Click += flowLop_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label flowlopMaLop;
        private Label flowlopSiSo;
        private Label flowlopTenLop;
        private Button flowLopXemChiTiet;
    }
}
