
namespace Rework_AppThiTracNghiem.forms
{
    partial class LamDeThi
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
            splitContainer1 = new SplitContainer();
            pnlDanhSachCau = new FlowLayoutPanel();
            lblTimer = new Label();
            btnNopBai = new Button();
            FlowCauHoi = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(lblTimer);
            splitContainer1.Panel1.Controls.Add(btnNopBai);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(FlowCauHoi);
            splitContainer1.Size = new Size(1679, 909);
            splitContainer1.SplitterDistance = 376;
            splitContainer1.TabIndex = 0;
            // 
            // pnlDanhSachCau
            // 
            pnlDanhSachCau.Location = new Point(3, 3);
            pnlDanhSachCau.Name = "pnlDanhSachCau";
            pnlDanhSachCau.Size = new Size(370, 770);
            pnlDanhSachCau.TabIndex = 3;
            // 
            // lblTimer
            // 
            lblTimer.Font = new Font("Unispace", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.Location = new Point(216, 819);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(111, 35);
            lblTimer.TabIndex = 2;
            lblTimer.Text = "60:00";
            lblTimer.Click += label1_Click;
            // 
            // btnNopBai
            // 
            btnNopBai.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNopBai.Location = new Point(12, 802);
            btnNopBai.Name = "btnNopBai";
            btnNopBai.Size = new Size(169, 61);
            btnNopBai.TabIndex = 1;
            btnNopBai.Text = "Nộp bài";
            btnNopBai.UseVisualStyleBackColor = true;
            btnNopBai.Click += btnNopBai_Click;
            // 
            // FlowCauHoi
            // 
            FlowCauHoi.AutoScroll = true;
            FlowCauHoi.Dock = DockStyle.Fill;
            FlowCauHoi.Location = new Point(0, 0);
            FlowCauHoi.Name = "FlowCauHoi";
            FlowCauHoi.Size = new Size(1299, 909);
            FlowCauHoi.TabIndex = 0;
            // 
            // LamDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1679, 909);
            Controls.Add(splitContainer1);
            Name = "LamDeThi";
            Text = "LamDeThi";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel FlowCauHoi;
        private Label lblTimer;
        private Button btnNopBai;
        private FlowLayoutPanel pnlDanhSachCau;
    }
}