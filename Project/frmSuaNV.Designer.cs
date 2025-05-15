namespace nhom8
{
    partial class frmSuaNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaNV));
            this.btSua = new System.Windows.Forms.Button();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbViTri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.Label();
            this.tbMaNV = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.Color.PaleGreen;
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(193, 421);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(151, 42);
            this.btSua.TabIndex = 43;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // tbMK
            // 
            this.tbMK.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMK.Location = new System.Drawing.Point(309, 361);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(167, 30);
            this.tbMK.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 41;
            this.label4.Text = "Mật khẩu";
            // 
            // tbSDT
            // 
            this.tbSDT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSDT.Location = new System.Drawing.Point(309, 291);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(167, 30);
            this.tbSDT.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Số điện thoại";
            // 
            // cbViTri
            // 
            this.cbViTri.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.cbViTri.Items.AddRange(new object[] {
            "Nhân viên bán hàng",
            "Nhân viên thu ngân",
            "Nhân viên kho",
            "Quản lý"});
            this.cbViTri.Location = new System.Drawing.Point(309, 226);
            this.cbViTri.Name = "cbViTri";
            this.cbViTri.Size = new System.Drawing.Size(167, 28);
            this.cbViTri.TabIndex = 38;
            this.cbViTri.Text = "Danh sách vị trí";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Vị trí";
            // 
            // tbTen
            // 
            this.tbTen.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(309, 162);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(167, 30);
            this.tbTen.TabIndex = 36;
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(67, 165);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(137, 25);
            this.txtTen.TabIndex = 35;
            this.txtTen.Text = "Tên nhân viên";
            // 
            // tbMaNV
            // 
            this.tbMaNV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMaNV.Enabled = false;
            this.tbMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaNV.Location = new System.Drawing.Point(309, 100);
            this.tbMaNV.Name = "tbMaNV";
            this.tbMaNV.ReadOnly = true;
            this.tbMaNV.Size = new System.Drawing.Size(167, 30);
            this.tbMaNV.TabIndex = 34;
            // 
            // txtMaNV
            // 
            this.txtMaNV.AutoSize = true;
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(67, 103);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(130, 25);
            this.txtMaNV.TabIndex = 33;
            this.txtMaNV.Text = "Mã nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(479, 37);
            this.label3.TabIndex = 32;
            this.label3.Text = "SỬA THÔNG TIN NHÂN VIÊN";
            // 
            // frmSuaNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(543, 494);
            this.Controls.Add(this.btSua);
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
            this.Name = "frmSuaNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa thông tin nhân viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbViTri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.TextBox tbMaNV;
        private System.Windows.Forms.Label txtMaNV;
        private System.Windows.Forms.Label label3;
    }
}