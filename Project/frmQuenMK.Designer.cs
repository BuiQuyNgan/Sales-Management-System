namespace nhom8
{
    partial class frmQuenMK
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
            this.pnQMK = new System.Windows.Forms.Panel();
            this.btGui = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtMNV = new System.Windows.Forms.TextBox();
            this.ĐN = new System.Windows.Forms.Label();
            this.TCN = new System.Windows.Forms.Label();
            this.pnQMK.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnQMK
            // 
            this.pnQMK.BackColor = System.Drawing.Color.White;
            this.pnQMK.Controls.Add(this.btGui);
            this.pnQMK.Controls.Add(this.txtSDT);
            this.pnQMK.Controls.Add(this.txtMNV);
            this.pnQMK.Controls.Add(this.ĐN);
            this.pnQMK.Controls.Add(this.TCN);
            this.pnQMK.ForeColor = System.Drawing.Color.Black;
            this.pnQMK.Location = new System.Drawing.Point(457, 135);
            this.pnQMK.Name = "pnQMK";
            this.pnQMK.Size = new System.Drawing.Size(504, 475);
            this.pnQMK.TabIndex = 2;
            // 
            // btGui
            // 
            this.btGui.BackColor = System.Drawing.Color.SeaGreen;
            this.btGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGui.Location = new System.Drawing.Point(120, 352);
            this.btGui.Name = "btGui";
            this.btGui.Size = new System.Drawing.Size(265, 55);
            this.btGui.TabIndex = 6;
            this.btGui.Text = "Gửi";
            this.btGui.UseVisualStyleBackColor = false;
            this.btGui.Click += new System.EventHandler(this.btGui_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSDT.Location = new System.Drawing.Point(67, 271);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(370, 31);
            this.txtSDT.TabIndex = 3;
            this.txtSDT.Text = "Số điện thoại";
            this.txtSDT.Enter += new System.EventHandler(this.txtSDT_Enter);
            this.txtSDT.Leave += new System.EventHandler(this.txtSDT_Leave);
            // 
            // txtMNV
            // 
            this.txtMNV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMNV.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMNV.Location = new System.Drawing.Point(67, 211);
            this.txtMNV.Name = "txtMNV";
            this.txtMNV.Size = new System.Drawing.Size(370, 31);
            this.txtMNV.TabIndex = 2;
            this.txtMNV.Text = "Mã nhân viên";
            this.txtMNV.Enter += new System.EventHandler(this.txtMNV_Enter);
            this.txtMNV.Leave += new System.EventHandler(this.txtMNV_Leave);
            // 
            // ĐN
            // 
            this.ĐN.AutoSize = true;
            this.ĐN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ĐN.Location = new System.Drawing.Point(85, 119);
            this.ĐN.Name = "ĐN";
            this.ĐN.Size = new System.Drawing.Size(334, 46);
            this.ĐN.TabIndex = 1;
            this.ĐN.Text = "Cấp lại mật khẩu";
            // 
            // TCN
            // 
            this.TCN.AutoSize = true;
            this.TCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCN.Location = new System.Drawing.Point(70, 33);
            this.TCN.Name = "TCN";
            this.TCN.Size = new System.Drawing.Size(365, 52);
            this.TCN.TabIndex = 0;
            this.TCN.Text = "Tạp hóa Thúy Vi";
            // 
            // frmQuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackgroundImage = global::nhom8.Properties.Resources._466912892_540152862191167_6637889668452298431_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1418, 744);
            this.Controls.Add(this.pnQMK);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 800);
            this.Name = "frmQuenMK";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.Load += new System.EventHandler(this.frmQuenMK_Load);
            this.pnQMK.ResumeLayout(false);
            this.pnQMK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnQMK;
        private System.Windows.Forms.Button btGui;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtMNV;
        private System.Windows.Forms.Label ĐN;
        private System.Windows.Forms.Label TCN;
    }
}