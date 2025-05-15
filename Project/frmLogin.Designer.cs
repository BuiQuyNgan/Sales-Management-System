namespace nhom8
{
    partial class frmLogin
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
            this.pnĐN = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.TCN = new System.Windows.Forms.Label();
            this.ĐN = new System.Windows.Forms.Label();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.txtTDN = new System.Windows.Forms.TextBox();
            this.rbtLuuMK = new System.Windows.Forms.RadioButton();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.pnĐN.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnĐN
            // 
            this.pnĐN.BackColor = System.Drawing.Color.White;
            this.pnĐN.Controls.Add(this.btnLogin);
            this.pnĐN.Controls.Add(this.TCN);
            this.pnĐN.Controls.Add(this.ĐN);
            this.pnĐN.Controls.Add(this.lblForgotPassword);
            this.pnĐN.Controls.Add(this.txtTDN);
            this.pnĐN.Controls.Add(this.rbtLuuMK);
            this.pnĐN.Controls.Add(this.txtMK);
            this.pnĐN.ForeColor = System.Drawing.Color.Black;
            this.pnĐN.Location = new System.Drawing.Point(457, 135);
            this.pnĐN.Name = "pnĐN";
            this.pnĐN.Size = new System.Drawing.Size(504, 475);
            this.pnĐN.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(120, 388);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(265, 55);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
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
            // ĐN
            // 
            this.ĐN.AutoSize = true;
            this.ĐN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ĐN.Location = new System.Drawing.Point(137, 119);
            this.ĐN.Name = "ĐN";
            this.ĐN.Size = new System.Drawing.Size(230, 46);
            this.ĐN.TabIndex = 1;
            this.ĐN.Text = "Đăng Nhập";
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.Location = new System.Drawing.Point(263, 329);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(174, 29);
            this.lblForgotPassword.TabIndex = 5;
            this.lblForgotPassword.Text = "Quên mật khẩu";
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // txtTDN
            // 
            this.txtTDN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDN.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTDN.Location = new System.Drawing.Point(67, 211);
            this.txtTDN.Name = "txtTDN";
            this.txtTDN.Size = new System.Drawing.Size(370, 31);
            this.txtTDN.TabIndex = 2;
            this.txtTDN.Text = "Tên đăng nhập";
            this.txtTDN.Enter += new System.EventHandler(this.txtTDN_Enter);
            this.txtTDN.Leave += new System.EventHandler(this.txtTDN_Leave);
            // 
            // rbtLuuMK
            // 
            this.rbtLuuMK.AutoSize = true;
            this.rbtLuuMK.BackColor = System.Drawing.SystemColors.Control;
            this.rbtLuuMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtLuuMK.Location = new System.Drawing.Point(67, 330);
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
            this.txtMK.Location = new System.Drawing.Point(67, 271);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(370, 31);
            this.txtMK.TabIndex = 3;
            this.txtMK.Text = "Mật khẩu";
            this.txtMK.Enter += new System.EventHandler(this.txtMK_Enter);
            this.txtMK.Leave += new System.EventHandler(this.txtMK_Leave);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::nhom8.Properties.Resources._466912892_540152862191167_6637889668452298431_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1418, 744);
            this.Controls.Add(this.pnĐN);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 800);
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnĐN.ResumeLayout(false);
            this.pnĐN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnĐN;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.RadioButton rbtLuuMK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtTDN;
        private System.Windows.Forms.Label ĐN;
        private System.Windows.Forms.Label TCN;
    }
}