namespace Rework_AppThiTracNghiem.forms
{
    partial class KetQuaThi
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
            FlowCauHoi = new FlowLayoutPanel();
            splitContainer1 = new SplitContainer();
            pnlDanhSachCau = new FlowLayoutPanel();
            lblMark = new Label();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // FlowCauHoi
            // 
            FlowCauHoi.AutoScroll = true;
            FlowCauHoi.Dock = DockStyle.Fill;
            FlowCauHoi.Location = new Point(0, 0);
            FlowCauHoi.Name = "FlowCauHoi";
            FlowCauHoi.Size = new Size(1270, 909);
            FlowCauHoi.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Top;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(192, 255, 255);
            splitContainer1.Panel1.Controls.Add(pnlDanhSachCau);
            splitContainer1.Panel1.Controls.Add(lblMark);
            splitContainer1.Panel1.Controls.Add(btnThoat);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(FlowCauHoi);
            splitContainer1.Size = new Size(1641, 909);
            splitContainer1.SplitterDistance = 367;
            splitContainer1.TabIndex = 1;
            // 
            // pnlDanhSachCau
            // 
            pnlDanhSachCau.Location = new Point(3, 3);
            pnlDanhSachCau.Name = "pnlDanhSachCau";
            pnlDanhSachCau.Size = new Size(370, 770);
            pnlDanhSachCau.TabIndex = 3;
            // 
            // lblMark
            // 
            lblMark.AutoSize = true;
            lblMark.Font = new Font("Unispace", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMark.Location = new Point(39, 839);
            lblMark.Name = "lblMark";
            lblMark.Size = new Size(105, 35);
            lblMark.TabIndex = 2;
            lblMark.Text = "60:00";
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(34, 779);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(153, 42);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // KetQuaThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1641, 910);
            Controls.Add(splitContainer1);
            Name = "KetQuaThi";
            Text = "KetQuaThi";
            Load += KetQuaThi_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel FlowCauHoi;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel pnlDanhSachCau;
        private Label lblMark;
        private Button btnThoat;
    }
}