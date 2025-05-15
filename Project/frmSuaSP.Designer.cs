namespace nhom8
{
    partial class frmSuaSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaSP));
            this.txtTilte = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.Label();
            this.tbMaSP = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.txtDV = new System.Windows.Forms.Label();
            this.cbDonVi = new System.Windows.Forms.ComboBox();
            this.txtLH = new System.Windows.Forms.Label();
            this.cbLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtHSD = new System.Windows.Forms.Label();
            this.tbHSD = new System.Windows.Forms.TextBox();
            this.btSua = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTilte
            // 
            this.txtTilte.AutoSize = true;
            this.txtTilte.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTilte.Location = new System.Drawing.Point(37, 27);
            this.txtTilte.Name = "txtTilte";
            this.txtTilte.Size = new System.Drawing.Size(469, 37);
            this.txtTilte.TabIndex = 6;
            this.txtTilte.Text = "SỬA THÔNG TIN SẢN PHẨM";
            // 
            // txtMaSP
            // 
            this.txtMaSP.AutoSize = true;
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(70, 99);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(131, 25);
            this.txtMaSP.TabIndex = 7;
            this.txtMaSP.Text = "Mã sản phẩm";
            // 
            // tbMaSP
            // 
            this.tbMaSP.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMaSP.Enabled = false;
            this.tbMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaSP.Location = new System.Drawing.Point(312, 96);
            this.tbMaSP.Name = "tbMaSP";
            this.tbMaSP.ReadOnly = true;
            this.tbMaSP.Size = new System.Drawing.Size(167, 30);
            this.tbMaSP.TabIndex = 8;
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(70, 161);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(138, 25);
            this.txtTen.TabIndex = 9;
            this.txtTen.Text = "Tên sản phẩm";
            // 
            // tbTen
            // 
            this.tbTen.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(312, 158);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(167, 30);
            this.tbTen.TabIndex = 10;
            // 
            // txtDV
            // 
            this.txtDV.AutoSize = true;
            this.txtDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDV.Location = new System.Drawing.Point(70, 225);
            this.txtDV.Name = "txtDV";
            this.txtDV.Size = new System.Drawing.Size(67, 25);
            this.txtDV.TabIndex = 11;
            this.txtDV.Text = "Đơn vị";
            // 
            // cbDonVi
            // 
            this.cbDonVi.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.cbDonVi.Items.AddRange(new object[] {
            "Hộp",
            "Thùng"});
            this.cbDonVi.Location = new System.Drawing.Point(312, 222);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Size = new System.Drawing.Size(167, 28);
            this.cbDonVi.TabIndex = 26;
            this.cbDonVi.Text = "Loại đơn vị";
            // 
            // txtLH
            // 
            this.txtLH.AutoSize = true;
            this.txtLH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLH.Location = new System.Drawing.Point(70, 290);
            this.txtLH.Name = "txtLH";
            this.txtLH.Size = new System.Drawing.Size(98, 25);
            this.txtLH.TabIndex = 27;
            this.txtLH.Text = "Loại hàng";
            // 
            // cbLoaiHang
            // 
            this.cbLoaiHang.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.cbLoaiHang.Items.AddRange(new object[] {
            "AV",
            "Sữa",
            "ĐH",
            "GV",
            "LT"});
            this.cbLoaiHang.Location = new System.Drawing.Point(312, 287);
            this.cbLoaiHang.Name = "cbLoaiHang";
            this.cbLoaiHang.Size = new System.Drawing.Size(167, 28);
            this.cbLoaiHang.TabIndex = 28;
            this.cbLoaiHang.Text = "Loại sản phẩm";
            // 
            // txtHSD
            // 
            this.txtHSD.AutoSize = true;
            this.txtHSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSD.Location = new System.Drawing.Point(70, 355);
            this.txtHSD.Name = "txtHSD";
            this.txtHSD.Size = new System.Drawing.Size(123, 25);
            this.txtHSD.TabIndex = 29;
            this.txtHSD.Text = "Hạn sử dụng";
            // 
            // tbHSD
            // 
            this.tbHSD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbHSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHSD.Location = new System.Drawing.Point(312, 352);
            this.tbHSD.Name = "tbHSD";
            this.tbHSD.Size = new System.Drawing.Size(167, 30);
            this.tbHSD.TabIndex = 30;
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.Color.PaleGreen;
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(196, 420);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(151, 42);
            this.btSua.TabIndex = 31;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // frmSuaSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 492);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.tbHSD);
            this.Controls.Add(this.txtHSD);
            this.Controls.Add(this.cbLoaiHang);
            this.Controls.Add(this.txtLH);
            this.Controls.Add(this.cbDonVi);
            this.Controls.Add(this.txtDV);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.tbMaSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.txtTilte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuaSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa thông tin sản phẩm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTilte;
        private System.Windows.Forms.Label txtMaSP;
        private System.Windows.Forms.TextBox tbMaSP;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label txtDV;
        private System.Windows.Forms.ComboBox cbDonVi;
        private System.Windows.Forms.Label txtLH;
        private System.Windows.Forms.ComboBox cbLoaiHang;
        private System.Windows.Forms.Label txtHSD;
        private System.Windows.Forms.TextBox tbHSD;
        private System.Windows.Forms.Button btSua;
    }
}