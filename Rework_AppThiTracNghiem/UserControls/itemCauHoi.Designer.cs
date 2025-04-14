namespace Rework_AppThiTracNghiem.UserControls
{
    partial class itemCauHoi
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
            rdoChonA = new RadioButton();
            rdoChonC = new RadioButton();
            groupChon = new GroupBox();
            rdoChonD = new RadioButton();
            rdoChonB = new RadioButton();
            txtDeBai = new Label();
            groupChon.SuspendLayout();
            SuspendLayout();
            // 
            // rdoChonA
            // 
            rdoChonA.BackColor = Color.FromArgb(192, 255, 255);
            rdoChonA.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoChonA.Location = new Point(6, 22);
            rdoChonA.Name = "rdoChonA";
            rdoChonA.Size = new Size(582, 50);
            rdoChonA.TabIndex = 0;
            rdoChonA.TabStop = true;
            rdoChonA.Text = "hinh nhu em co dieu muon noi cu ngap ngung roi thoi";
            rdoChonA.UseVisualStyleBackColor = false;
            rdoChonA.CheckedChanged += radioButton_CheckedChanged;
            // 
            // rdoChonC
            // 
            rdoChonC.BackColor = Color.FromArgb(192, 255, 255);
            rdoChonC.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoChonC.Location = new Point(6, 78);
            rdoChonC.Name = "rdoChonC";
            rdoChonC.Size = new Size(582, 51);
            rdoChonC.TabIndex = 1;
            rdoChonC.TabStop = true;
            rdoChonC.Text = "radioButton2";
            rdoChonC.UseVisualStyleBackColor = false;
            rdoChonC.CheckedChanged += radioButton_CheckedChanged;
            // 
            // groupChon
            // 
            groupChon.AutoSize = true;
            groupChon.BackColor = Color.White;
            groupChon.Controls.Add(rdoChonD);
            groupChon.Controls.Add(rdoChonB);
            groupChon.Controls.Add(rdoChonA);
            groupChon.Controls.Add(rdoChonC);
            groupChon.Location = new Point(3, 85);
            groupChon.Name = "groupChon";
            groupChon.Size = new Size(1115, 151);
            groupChon.TabIndex = 2;
            groupChon.TabStop = false;
            groupChon.Enter += groupBox1_Enter;
            // 
            // rdoChonD
            // 
            rdoChonD.BackColor = Color.FromArgb(192, 255, 255);
            rdoChonD.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoChonD.Location = new Point(594, 78);
            rdoChonD.Name = "rdoChonD";
            rdoChonD.Size = new Size(512, 51);
            rdoChonD.TabIndex = 3;
            rdoChonD.TabStop = true;
            rdoChonD.Text = "radioButton4";
            rdoChonD.UseVisualStyleBackColor = false;
            rdoChonD.CheckedChanged += radioButton_CheckedChanged;
            // 
            // rdoChonB
            // 
            rdoChonB.BackColor = Color.FromArgb(192, 255, 255);
            rdoChonB.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoChonB.Location = new Point(594, 22);
            rdoChonB.Name = "rdoChonB";
            rdoChonB.Size = new Size(515, 50);
            rdoChonB.TabIndex = 2;
            rdoChonB.TabStop = true;
            rdoChonB.Text = "radioButton3";
            rdoChonB.UseVisualStyleBackColor = false;
            rdoChonB.CheckedChanged += radioButton_CheckedChanged;
            // 
            // txtDeBai
            // 
            txtDeBai.BackColor = Color.White;
            txtDeBai.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeBai.Location = new Point(3, 0);
            txtDeBai.Name = "txtDeBai";
            txtDeBai.Size = new Size(1115, 104);
            txtDeBai.TabIndex = 3;
            txtDeBai.Text = "dăubndăubfu9ăbfăb făbfăbfabfbừabuabfuabfuabfauiwfbàbưabfâf";
            txtDeBai.Click += txtDeBai_Click;
            // 
            // itemCauHoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(txtDeBai);
            Controls.Add(groupChon);
            Name = "itemCauHoi";
            Size = new Size(1110, 236);
            groupChon.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rdoChonA;
        private RadioButton rdoChonC;
        private GroupBox groupChon;
        private RadioButton rdoChonD;
        private RadioButton rdoChonB;
        private Label txtDeBai;
    }
}
