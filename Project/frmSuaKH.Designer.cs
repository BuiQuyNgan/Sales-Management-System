namespace nhom8
{
    partial class frmSuaKH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaKH));
            this.btSuaKH = new System.Windows.Forms.Button();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.Label();
            this.tbMaKH = new System.Windows.Forms.TextBox();
            this.txtMaNPP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSuaKH
            // 
            this.btSuaKH.BackColor = System.Drawing.Color.PaleGreen;
            this.btSuaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSuaKH.Location = new System.Drawing.Point(193, 374);
            this.btSuaKH.Name = "btSuaKH";
            this.btSuaKH.Size = new System.Drawing.Size(151, 42);
            this.btSuaKH.TabIndex = 24;
            this.btSuaKH.Text = "Sửa";
            this.btSuaKH.UseVisualStyleBackColor = false;
            this.btSuaKH.Click += new System.EventHandler(this.btSuaKH_Click);
            // 
            // tbSDT
            // 
            this.tbSDT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSDT.Location = new System.Drawing.Point(309, 288);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(167, 30);
            this.tbSDT.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Số điện thoại";
            // 
            // tbDC
            // 
            this.tbDC.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDC.Location = new System.Drawing.Point(309, 223);
            this.tbDC.Name = "tbDC";
            this.tbDC.Size = new System.Drawing.Size(167, 30);
            this.tbDC.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Địa chỉ ";
            // 
            // tbTen
            // 
            this.tbTen.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(309, 159);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(167, 30);
            this.tbTen.TabIndex = 19;
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(67, 162);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(154, 25);
            this.txtTen.TabIndex = 18;
            this.txtTen.Text = "Tên khách hàng";
            // 
            // tbMaKH
            // 
            this.tbMaKH.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMaKH.Enabled = false;
            this.tbMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaKH.Location = new System.Drawing.Point(309, 97);
            this.tbMaKH.Name = "tbMaKH";
            this.tbMaKH.ReadOnly = true;
            this.tbMaKH.Size = new System.Drawing.Size(167, 30);
            this.tbMaKH.TabIndex = 17;
            // 
            // txtMaNPP
            // 
            this.txtMaNPP.AutoSize = true;
            this.txtMaNPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNPP.Location = new System.Drawing.Point(67, 100);
            this.txtMaNPP.Name = "txtMaNPP";
            this.txtMaNPP.Size = new System.Drawing.Size(147, 25);
            this.txtMaNPP.TabIndex = 16;
            this.txtMaNPP.Text = "Mã khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "SỬA KHÁCH HÀNG";
            // 
            // frmSuaKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(543, 444);
            this.Controls.Add(this.btSuaKH);
            this.Controls.Add(this.tbSDT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.tbMaKH);
            this.Controls.Add(this.txtMaNPP);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(565, 500);
            this.MinimizeBox = false;
            this.Name = "frmSuaKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa thông tin khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSuaKH;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.TextBox tbMaKH;
        private System.Windows.Forms.Label txtMaNPP;
        private System.Windows.Forms.Label label3;
    }
}