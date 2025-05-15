namespace nhom8
{
    partial class frmTaoNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoNV));
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.Label();
            this.tbMaNV = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbViTri = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.btTao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "TẠO NHÂN VIÊN";
            // 
            // txtMaNV
            // 
            this.txtMaNV.AutoSize = true;
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(70, 99);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(130, 25);
            this.txtMaNV.TabIndex = 6;
            this.txtMaNV.Text = "Mã nhân viên";
            // 
            // tbMaNV
            // 
            this.tbMaNV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMaNV.Enabled = false;
            this.tbMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaNV.Location = new System.Drawing.Point(312, 96);
            this.tbMaNV.Name = "tbMaNV";
            this.tbMaNV.ReadOnly = true;
            this.tbMaNV.Size = new System.Drawing.Size(167, 30);
            this.tbMaNV.TabIndex = 7;
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(70, 161);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(137, 25);
            this.txtTen.TabIndex = 8;
            this.txtTen.Text = "Tên nhân viên";
            // 
            // tbTen
            // 
            this.tbTen.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(312, 158);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(167, 30);
            this.tbTen.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vị trí";
            // 
            // cbViTri
            // 
            this.cbViTri.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.cbViTri.Items.AddRange(new object[] {
            "Nhân viên bán hàng",
            "Nhân viên thu ngân",
            "Nhân viên kho",
            "Quản lý"});
            this.cbViTri.Location = new System.Drawing.Point(312, 222);
            this.cbViTri.Name = "cbViTri";
            this.cbViTri.Size = new System.Drawing.Size(167, 28);
            this.cbViTri.TabIndex = 26;
            this.cbViTri.Text = "Danh sách vị trí";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Số điện thoại";
            // 
            // tbSDT
            // 
            this.tbSDT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSDT.Location = new System.Drawing.Point(312, 287);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(167, 30);
            this.tbSDT.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 29;
            this.label4.Text = "Mật khẩu";
            // 
            // tbMK
            // 
            this.tbMK.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMK.Location = new System.Drawing.Point(312, 357);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(167, 30);
            this.tbMK.TabIndex = 30;
            // 
            // btTao
            // 
            this.btTao.BackColor = System.Drawing.Color.PaleGreen;
            this.btTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTao.Location = new System.Drawing.Point(196, 417);
            this.btTao.Name = "btTao";
            this.btTao.Size = new System.Drawing.Size(151, 42);
            this.btTao.TabIndex = 31;
            this.btTao.Text = "Tạo mới";
            this.btTao.UseVisualStyleBackColor = false;
            this.btTao.Click += new System.EventHandler(this.btTao_Click);
            // 
            // frmTaoNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(543, 494);
            this.Controls.Add(this.btTao);
            this.Controls.Add(this.tbMK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSDT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbViTri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.tbMaNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(565, 550);
            this.MinimizeBox = false;
            this.Name = "frmTaoNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo nhân viên mới";
            this.Load += new System.EventHandler(this.frmTaoNV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtMaNV;
        private System.Windows.Forms.TextBox tbMaNV;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbViTri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.Button btTao;
    }
}