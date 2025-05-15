namespace nhom8
{
    partial class frmNPP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNPP));
            this.label3 = new System.Windows.Forms.Label();
            this.btnTaoNPP = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DanhMuc = new System.Windows.Forms.MenuStrip();
            this.SanPhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NhaPhanPhoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HoaDonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HoaDonNhapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HoaDonXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HoaDonNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuat = new System.Windows.Forms.MenuStrip();
            this.DangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbChucVu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTenNV = new System.Windows.Forms.TextBox();
            this.sidebar = new System.Windows.Forms.Panel();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.btTim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.DanhMuc.SuspendLayout();
            this.DangXuat.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(224, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "NHÀ PHÂN PHỐI";
            // 
            // btnTaoNPP
            // 
            this.btnTaoNPP.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTaoNPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoNPP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTaoNPP.Location = new System.Drawing.Point(231, 55);
            this.btnTaoNPP.Name = "btnTaoNPP";
            this.btnTaoNPP.Size = new System.Drawing.Size(108, 39);
            this.btnTaoNPP.TabIndex = 5;
            this.btnTaoNPP.Text = "Tạo mới";
            this.btnTaoNPP.UseVisualStyleBackColor = false;
            this.btnTaoNPP.Click += new System.EventHandler(this.btnTaoNPP_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(211, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1195, 649);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH MỤC";
            // 
            // DanhMuc
            // 
            this.DanhMuc.Dock = System.Windows.Forms.DockStyle.None;
            this.DanhMuc.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.DanhMuc.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.DanhMuc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SanPhamToolStripMenuItem,
            this.NhanVienToolStripMenuItem,
            this.KhachHangToolStripMenuItem,
            this.NhaPhanPhoiToolStripMenuItem,
            this.HoaDonToolStripMenuItem1});
            this.DanhMuc.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.DanhMuc.Location = new System.Drawing.Point(7, 185);
            this.DanhMuc.Name = "DanhMuc";
            this.DanhMuc.Size = new System.Drawing.Size(186, 279);
            this.DanhMuc.TabIndex = 1;
            this.DanhMuc.Text = "DanhMuc";
            this.DanhMuc.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // SanPhamToolStripMenuItem
            // 
            this.SanPhamToolStripMenuItem.Image = global::nhom8.Properties.Resources.cart;
            this.SanPhamToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SanPhamToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.SanPhamToolStripMenuItem.Name = "SanPhamToolStripMenuItem";
            this.SanPhamToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.SanPhamToolStripMenuItem.Text = "Sản phẩm";
            this.SanPhamToolStripMenuItem.Click += new System.EventHandler(this.SanPhamToolStripMenuItem_Click);
            // 
            // NhanVienToolStripMenuItem
            // 
            this.NhanVienToolStripMenuItem.Image = global::nhom8.Properties.Resources.account;
            this.NhanVienToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NhanVienToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.NhanVienToolStripMenuItem.Name = "NhanVienToolStripMenuItem";
            this.NhanVienToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.NhanVienToolStripMenuItem.Text = "Nhân viên";
            this.NhanVienToolStripMenuItem.Click += new System.EventHandler(this.NhanVienToolStripMenuItem_Click);
            // 
            // KhachHangToolStripMenuItem
            // 
            this.KhachHangToolStripMenuItem.Image = global::nhom8.Properties.Resources.user_profile_02;
            this.KhachHangToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KhachHangToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.KhachHangToolStripMenuItem.Name = "KhachHangToolStripMenuItem";
            this.KhachHangToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.KhachHangToolStripMenuItem.Text = "Khách hàng";
            this.KhachHangToolStripMenuItem.Click += new System.EventHandler(this.KhachHangToolStripMenuItem_Click);
            // 
            // NhaPhanPhoiToolStripMenuItem
            // 
            this.NhaPhanPhoiToolStripMenuItem.BackColor = System.Drawing.Color.LightGreen;
            this.NhaPhanPhoiToolStripMenuItem.Image = global::nhom8.Properties.Resources.truck;
            this.NhaPhanPhoiToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NhaPhanPhoiToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.NhaPhanPhoiToolStripMenuItem.Name = "NhaPhanPhoiToolStripMenuItem";
            this.NhaPhanPhoiToolStripMenuItem.Size = new System.Drawing.Size(179, 29);
            this.NhaPhanPhoiToolStripMenuItem.Text = "Nhà phân phối";
            // 
            // HoaDonToolStripMenuItem1
            // 
            this.HoaDonToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HoaDonNhapToolStripMenuItem,
            this.HoaDonXuatToolStripMenuItem,
            this.HoaDonNoToolStripMenuItem});
            this.HoaDonToolStripMenuItem1.Image = global::nhom8.Properties.Resources.Icon__1_;
            this.HoaDonToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HoaDonToolStripMenuItem1.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.HoaDonToolStripMenuItem1.Name = "HoaDonToolStripMenuItem1";
            this.HoaDonToolStripMenuItem1.Size = new System.Drawing.Size(179, 29);
            this.HoaDonToolStripMenuItem1.Text = "Hoá đơn";
            // 
            // HoaDonNhapToolStripMenuItem
            // 
            this.HoaDonNhapToolStripMenuItem.Name = "HoaDonNhapToolStripMenuItem";
            this.HoaDonNhapToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.HoaDonNhapToolStripMenuItem.Text = "Hoá đơn nhập";
            this.HoaDonNhapToolStripMenuItem.Click += new System.EventHandler(this.HoaDonNhapToolStripMenuItem_Click);
            // 
            // HoaDonXuatToolStripMenuItem
            // 
            this.HoaDonXuatToolStripMenuItem.Name = "HoaDonXuatToolStripMenuItem";
            this.HoaDonXuatToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.HoaDonXuatToolStripMenuItem.Text = "Hoá đơn xuất";
            this.HoaDonXuatToolStripMenuItem.Click += new System.EventHandler(this.HoaDonXuatToolStripMenuItem_Click);
            // 
            // HoaDonNoToolStripMenuItem
            // 
            this.HoaDonNoToolStripMenuItem.Name = "HoaDonNoToolStripMenuItem";
            this.HoaDonNoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.HoaDonNoToolStripMenuItem.Text = "Hoá đơn nợ";
            this.HoaDonNoToolStripMenuItem.Click += new System.EventHandler(this.HoaDonNoToolStripMenuItem_Click);
            // 
            // DangXuat
            // 
            this.DangXuat.Dock = System.Windows.Forms.DockStyle.None;
            this.DangXuat.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.DangXuat.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.DangXuat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DangXuatToolStripMenuItem});
            this.DangXuat.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.DangXuat.Location = new System.Drawing.Point(7, 694);
            this.DangXuat.Name = "DangXuat";
            this.DangXuat.Size = new System.Drawing.Size(139, 35);
            this.DangXuat.TabIndex = 1;
            this.DangXuat.Text = "menuStrip2";
            // 
            // DangXuatToolStripMenuItem
            // 
            this.DangXuatToolStripMenuItem.Image = global::nhom8.Properties.Resources.Log_out;
            this.DangXuatToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DangXuatToolStripMenuItem.Name = "DangXuatToolStripMenuItem";
            this.DangXuatToolStripMenuItem.Size = new System.Drawing.Size(132, 29);
            this.DangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.DangXuatToolStripMenuItem.Click += new System.EventHandler(this.DangXuatToolStripMenuItem_Click);
            // 
            // tbChucVu
            // 
            this.tbChucVu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbChucVu.Enabled = false;
            this.tbChucVu.Location = new System.Drawing.Point(50, 19);
            this.tbChucVu.Name = "tbChucVu";
            this.tbChucVu.ReadOnly = true;
            this.tbChucVu.Size = new System.Drawing.Size(100, 26);
            this.tbChucVu.TabIndex = 1;
            this.tbChucVu.TabStop = false;
            this.tbChucVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "                                                  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-5, 661);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "                                                  ";
            // 
            // tbTenNV
            // 
            this.tbTenNV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTenNV.Enabled = false;
            this.tbTenNV.Location = new System.Drawing.Point(27, 60);
            this.tbTenNV.Name = "tbTenNV";
            this.tbTenNV.ReadOnly = true;
            this.tbTenNV.Size = new System.Drawing.Size(147, 26);
            this.tbTenNV.TabIndex = 2;
            this.tbTenNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sidebar
            // 
            this.sidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sidebar.Controls.Add(this.tbTenNV);
            this.sidebar.Controls.Add(this.label4);
            this.sidebar.Controls.Add(this.label2);
            this.sidebar.Controls.Add(this.tbChucVu);
            this.sidebar.Controls.Add(this.DangXuat);
            this.sidebar.Controls.Add(this.DanhMuc);
            this.sidebar.Controls.Add(this.label1);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(200, 744);
            this.sidebar.TabIndex = 0;
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiem.Location = new System.Drawing.Point(992, 59);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(285, 30);
            this.tbTimKiem.TabIndex = 8;
            // 
            // btTim
            // 
            this.btTim.BackColor = System.Drawing.Color.PaleGreen;
            this.btTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btTim.Location = new System.Drawing.Point(1294, 55);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(66, 39);
            this.btTim.TabIndex = 9;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = false;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // frmNPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1418, 744);
            this.Controls.Add(this.btTim);
            this.Controls.Add(this.tbTimKiem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTaoNPP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sidebar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.DangXuat;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 800);
            this.Name = "frmNPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà phân phối";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNPP_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.DanhMuc.ResumeLayout(false);
            this.DanhMuc.PerformLayout();
            this.DangXuat.ResumeLayout(false);
            this.DangXuat.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
         private System.Windows.Forms.Button btnTaoNPP;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip DanhMuc;
        private System.Windows.Forms.ToolStripMenuItem SanPhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KhachHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NhaPhanPhoiToolStripMenuItem;
        private System.Windows.Forms.MenuStrip DangXuat;
        private System.Windows.Forms.ToolStripMenuItem DangXuatToolStripMenuItem;
        private System.Windows.Forms.TextBox tbChucVu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTenNV;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.ToolStripMenuItem HoaDonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HoaDonNhapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HoaDonXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HoaDonNoToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Button btTim;
    }
}

