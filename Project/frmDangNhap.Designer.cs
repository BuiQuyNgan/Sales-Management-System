namespace QuenMk
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.pnĐN = new System.Windows.Forms.Panel();
            this.btĐN = new System.Windows.Forms.Button();
            this.lbQMK = new System.Windows.Forms.Label();
            this.rbtLuuMK = new System.Windows.Forms.RadioButton();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtTDN = new System.Windows.Forms.TextBox();
            this.ĐN = new System.Windows.Forms.Label();
            this.TCN = new System.Windows.Forms.Label();
            this.pnĐN.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnĐN
            // 
            this.pnĐN.BackColor = System.Drawing.Color.White;
            this.pnĐN.Controls.Add(this.btĐN);
            this.pnĐN.Controls.Add(this.lbQMK);
            this.pnĐN.Controls.Add(this.rbtLuuMK);
            this.pnĐN.Controls.Add(this.txtMK);
            this.pnĐN.Controls.Add(this.txtTDN);
            this.pnĐN.Controls.Add(this.ĐN);
            this.pnĐN.Controls.Add(this.TCN);
            this.pnĐN.ForeColor = System.Drawing.Color.Black;
            this.pnĐN.Location = new System.Drawing.Point(423, 145);
            this.pnĐN.Name = "pnĐN";
            this.pnĐN.Size = new System.Drawing.Size(455, 441);
            this.pnĐN.TabIndex = 1;
            this.pnĐN.Resize += new System.EventHandler(this.pnĐN_Resize);
            // 
            // btĐN
            // 
            this.btĐN.BackColor = System.Drawing.Color.SeaGreen;
            this.btĐN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btĐN.Location = new System.Drawing.Point(104, 352);
            this.btĐN.Name = "btĐN";
            this.btĐN.Size = new System.Drawing.Size(265, 55);
            this.btĐN.TabIndex = 6;
            this.btĐN.Text = "Đăng nhập";
            this.btĐN.UseVisualStyleBackColor = false;
            this.btĐN.Click += new System.EventHandler(this.btĐN_Click);
            // 
            // lbQMK
            // 
            this.lbQMK.AutoSize = true;
            this.lbQMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQMK.Location = new System.Drawing.Point(268, 306);
            this.lbQMK.Name = "lbQMK";
            this.lbQMK.Size = new System.Drawing.Size(174, 29);
            this.lbQMK.TabIndex = 5;
            this.lbQMK.Text = "Quên mật khẩu";
            this.lbQMK.Click += new System.EventHandler(this.lbQMK_Click);
            // 
            // rbtLuuMK
            // 
            this.rbtLuuMK.AutoSize = true;
            this.rbtLuuMK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rbtLuuMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtLuuMK.Location = new System.Drawing.Point(50, 306);
            this.rbtLuuMK.Name = "rbtLuuMK";
            this.rbtLuuMK.Size = new System.Drawing.Size(167, 29);
            this.rbtLuuMK.TabIndex = 4;
            this.rbtLuuMK.TabStop = true;
            this.rbtLuuMK.Text = "Lưu mật khẩu";
            this.rbtLuuMK.UseVisualStyleBackColor = false;
            // 
            // txtMK
            // 
            this.txtMK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMK.Location = new System.Drawing.Point(72, 248);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(321, 31);
            this.txtMK.TabIndex = 3;
            this.txtMK.Text = "Mật khẩu";
            this.txtMK.Enter += new System.EventHandler(this.txtMK_Enter);
            this.txtMK.Leave += new System.EventHandler(this.txtMK_Leave);
            // 
            // txtTDN
            // 
            this.txtTDN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDN.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTDN.Location = new System.Drawing.Point(72, 189);
            this.txtTDN.Name = "txtTDN";
            this.txtTDN.Size = new System.Drawing.Size(321, 31);
            this.txtTDN.TabIndex = 2;
            this.txtTDN.Text = "Tên đăng nhập";
            this.txtTDN.Enter += new System.EventHandler(this.txtTDN_Enter);
            this.txtTDN.Leave += new System.EventHandler(this.txtTDN_Leave);
            // 
            // ĐN
            // 
            this.ĐN.AutoSize = true;
            this.ĐN.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ĐN.Location = new System.Drawing.Point(126, 102);
            this.ĐN.Name = "ĐN";
            this.ĐN.Size = new System.Drawing.Size(230, 46);
            this.ĐN.TabIndex = 1;
            this.ĐN.Text = "Đăng Nhập";
            // 
            // TCN
            // 
            this.TCN.AutoSize = true;
            this.TCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCN.Location = new System.Drawing.Point(54, 38);
            this.TCN.Name = "TCN";
            this.TCN.Size = new System.Drawing.Size(365, 52);
            this.TCN.TabIndex = 0;
            this.TCN.Text = "Tạp hóa Thúy Vi";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuenMk.Properties.Resources.Đổi_mật_khẩu_3;
            this.ClientSize = new System.Drawing.Size(1418, 744);
            this.Controls.Add(this.pnĐN);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.pnĐN.ResumeLayout(false);
            this.pnĐN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnĐN;
        private System.Windows.Forms.Button btĐN;
        private System.Windows.Forms.Label lbQMK;
        private System.Windows.Forms.RadioButton rbtLuuMK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTDN;
        private System.Windows.Forms.Label ĐN;
        private System.Windows.Forms.Label TCN;
    }
}