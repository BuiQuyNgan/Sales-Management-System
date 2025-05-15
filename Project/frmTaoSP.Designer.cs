namespace nhom8
{
    partial class frmTaoSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoSP));
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.Label();
            this.tbMaSP = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.txtDV = new System.Windows.Forms.Label();
            this.txtLH = new System.Windows.Forms.Label();
            this.cbLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtHSD = new System.Windows.Forms.Label();
            this.tbHSD = new System.Windows.Forms.TextBox();
            this.btTao = new System.Windows.Forms.Button();
            this.cbDonVi = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "TẠO SẢN PHẨM MỚI";
            // 
            // txtMaSP
            // 
            this.txtMaSP.AutoSize = true;
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(70, 99);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(131, 25);
            this.txtMaSP.TabIndex = 6;
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
            this.tbMaSP.TabIndex = 7;
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(70, 161);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(138, 25);
            this.txtTen.TabIndex = 8;
            this.txtTen.Text = "Tên sản phẩm";
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
            // txtDV
            // 
            this.txtDV.AutoSize = true;
            this.txtDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDV.Location = new System.Drawing.Point(70, 225);
            this.txtDV.Name = "txtDV";
            this.txtDV.Size = new System.Drawing.Size(67, 25);
            this.txtDV.TabIndex = 10;
            this.txtDV.Text = "Đơn vị";
            // 
            // txtLH
            // 
            this.txtLH.AutoSize = true;
            this.txtLH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLH.Location = new System.Drawing.Point(70, 290);
            this.txtLH.Name = "txtLH";
            this.txtLH.Size = new System.Drawing.Size(98, 25);
            this.txtLH.TabIndex = 12;
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
            this.cbLoaiHang.TabIndex = 17;
            this.cbLoaiHang.Text = "Loại sản phẩm";
            // 
            // txtHSD
            // 
            this.txtHSD.AutoSize = true;
            this.txtHSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSD.Location = new System.Drawing.Point(70, 355);
            this.txtHSD.Name = "txtHSD";
            this.txtHSD.Size = new System.Drawing.Size(123, 25);
            this.txtHSD.TabIndex = 18;
            this.txtHSD.Text = "Hạn sử dụng";
            // 
            // tbHSD
            // 
            this.tbHSD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbHSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHSD.Location = new System.Drawing.Point(312, 352);
            this.tbHSD.Name = "tbHSD";
            this.tbHSD.Size = new System.Drawing.Size(167, 30);
            this.tbHSD.TabIndex = 19;
            // 
            // btTao
            // 
            this.btTao.BackColor = System.Drawing.Color.PaleGreen;
            this.btTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTao.Location = new System.Drawing.Point(196, 420);
            this.btTao.Name = "btTao";
            this.btTao.Size = new System.Drawing.Size(151, 42);
            this.btTao.TabIndex = 24;
            this.btTao.Text = "Tạo mới";
            this.btTao.UseVisualStyleBackColor = false;
            this.btTao.Click += new System.EventHandler(this.btTao_Click);
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
            this.cbDonVi.TabIndex = 25;
            this.cbDonVi.Text = "Loại đơn vị";
            // 
            // frmTaoSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 492);
            this.Controls.Add(this.cbDonVi);
            this.Controls.Add(this.btTao);
            this.Controls.Add(this.tbHSD);
            this.Controls.Add(this.txtHSD);
            this.Controls.Add(this.cbLoaiHang);
            this.Controls.Add(this.txtLH);
            this.Controls.Add(this.txtDV);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.tbMaSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaoSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo sản phẩm mới";
            this.Load += new System.EventHandler(this.frmTaoSP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtMaSP;
        private System.Windows.Forms.TextBox tbMaSP;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label txtDV;
        private System.Windows.Forms.Label txtLH;
        private System.Windows.Forms.ComboBox cbLoaiHang;
        private System.Windows.Forms.Label txtHSD;
        private System.Windows.Forms.TextBox tbHSD;
        private System.Windows.Forms.Button btTao;
        private System.Windows.Forms.ComboBox cbDonVi;
    }
}