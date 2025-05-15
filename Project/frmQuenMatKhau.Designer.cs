namespace QuenMk
{
    partial class frmQuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuenMatKhau));
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
            this.pnQMK.Location = new System.Drawing.Point(423, 145);
            this.pnQMK.Name = "pnQMK";
            this.pnQMK.Size = new System.Drawing.Size(455, 441);
            this.pnQMK.TabIndex = 1;
            this.pnQMK.Resize += new System.EventHandler(this.pnQMK_Resize);
            // 
            // btGui
            // 
            this.btGui.BackColor = System.Drawing.Color.SeaGreen;
            this.btGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGui.Location = new System.Drawing.Point(104, 352);
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
            this.txtSDT.Location = new System.Drawing.Point(72, 266);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(321, 31);
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
            this.txtMNV.Location = new System.Drawing.Point(72, 191);
            this.txtMNV.Name = "txtMNV";
            this.txtMNV.Size = new System.Drawing.Size(321, 31);
            this.txtMNV.TabIndex = 2;
            this.txtMNV.Text = "Mã nhân viên";
            this.txtMNV.Enter += new System.EventHandler(this.txtMNV_Enter);
            this.txtMNV.Leave += new System.EventHandler(this.txtMNV_Leave);
            // 
            // ĐN
            // 
            this.ĐN.AutoSize = true;
            this.ĐN.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ĐN.Location = new System.Drawing.Point(66, 102);
            this.ĐN.Name = "ĐN";
            this.ĐN.Size = new System.Drawing.Size(334, 46);
            this.ĐN.TabIndex = 1;
            this.ĐN.Text = "Cấp lại mật khẩu";
            // 
            // TCN
            // 
            this.TCN.AutoSize = true;
            this.TCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCN.Location = new System.Drawing.Point(53, 38);
            this.TCN.Name = "TCN";
            this.TCN.Size = new System.Drawing.Size(365, 52);
            this.TCN.TabIndex = 0;
            this.TCN.Text = "Tạp hóa Thúy Vi";
            // 
            // frmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuenMk.Properties.Resources.Đổi_mật_khẩu_3;
            this.ClientSize = new System.Drawing.Size(1418, 744);
            this.Controls.Add(this.pnQMK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên Mật Khẩu";
            this.Load += new System.EventHandler(this.frmQuenMatKhau_Load);
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

