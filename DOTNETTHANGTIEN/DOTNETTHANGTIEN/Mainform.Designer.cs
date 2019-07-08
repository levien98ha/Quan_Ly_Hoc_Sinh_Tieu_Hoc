namespace DOTNETTHANGTIEN
{
    partial class Mainform
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giáoViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.họcSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ghiChúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khuyếtTậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.họcLựcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btdangnhap = new System.Windows.Forms.Button();
            this.txtmadangnhap = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btdangxuat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bPass = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.họcSinhToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1214, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giáoViênToolStripMenuItem,
            this.lớpToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources.quantridanhmuc;
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // giáoViênToolStripMenuItem
            // 
            this.giáoViênToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources._21578646fd7f1ed;
            this.giáoViênToolStripMenuItem.Name = "giáoViênToolStripMenuItem";
            this.giáoViênToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.giáoViênToolStripMenuItem.Text = "Giáo viên";
            this.giáoViênToolStripMenuItem.Click += new System.EventHandler(this.giáoViênToolStripMenuItem_Click);
            // 
            // lớpToolStripMenuItem
            // 
            this.lớpToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources._4321a06f42a24f9a7ac1d17cdac9ec2c;
            this.lớpToolStripMenuItem.Name = "lớpToolStripMenuItem";
            this.lớpToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.lớpToolStripMenuItem.Text = "Danh sách học sinh";
            this.lớpToolStripMenuItem.Click += new System.EventHandler(this.lớpToolStripMenuItem_Click);
            // 
            // họcSinhToolStripMenuItem
            // 
            this.họcSinhToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.họcSinhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.điểmToolStripMenuItem});
            this.họcSinhToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources.pngtree_dr__cartoon_png_clipart_980138;
            this.họcSinhToolStripMenuItem.Name = "họcSinhToolStripMenuItem";
            this.họcSinhToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.họcSinhToolStripMenuItem.Text = "Học sinh";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources._2257ee7cad008e0;
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // điểmToolStripMenuItem
            // 
            this.điểmToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources.hinh_anh_hoc_sinh_tang_hoa_co_giao_15;
            this.điểmToolStripMenuItem.Name = "điểmToolStripMenuItem";
            this.điểmToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.điểmToolStripMenuItem.Text = "Điểm";
            this.điểmToolStripMenuItem.Click += new System.EventHandler(this.điểmToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ghiChúToolStripMenuItem,
            this.khuyếtTậtToolStripMenuItem,
            this.họcLựcToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Image = global::DOTNETTHANGTIEN.Properties.Resources.statis;
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // ghiChúToolStripMenuItem
            // 
            this.ghiChúToolStripMenuItem.Name = "ghiChúToolStripMenuItem";
            this.ghiChúToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.ghiChúToolStripMenuItem.Text = "Hộ nghèo";
            this.ghiChúToolStripMenuItem.Click += new System.EventHandler(this.ghiChúToolStripMenuItem_Click);
            // 
            // khuyếtTậtToolStripMenuItem
            // 
            this.khuyếtTậtToolStripMenuItem.Name = "khuyếtTậtToolStripMenuItem";
            this.khuyếtTậtToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.khuyếtTậtToolStripMenuItem.Text = "Khuyết tật";
            this.khuyếtTậtToolStripMenuItem.Click += new System.EventHandler(this.khuyếtTậtToolStripMenuItem_Click);
            // 
            // họcLựcToolStripMenuItem
            // 
            this.họcLựcToolStripMenuItem.Name = "họcLựcToolStripMenuItem";
            this.họcLựcToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.họcLựcToolStripMenuItem.Text = "Học lực";
            this.họcLựcToolStripMenuItem.Click += new System.EventHandler(this.họcLựcToolStripMenuItem_Click);
            // 
            // btdangnhap
            // 
            this.btdangnhap.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btdangnhap.Location = new System.Drawing.Point(1010, 1);
            this.btdangnhap.Name = "btdangnhap";
            this.btdangnhap.Size = new System.Drawing.Size(93, 26);
            this.btdangnhap.TabIndex = 1;
            this.btdangnhap.Text = "Đăng nhập";
            this.btdangnhap.UseVisualStyleBackColor = true;
            this.btdangnhap.Click += new System.EventHandler(this.btdangnhap_Click);
            // 
            // txtmadangnhap
            // 
            this.txtmadangnhap.Location = new System.Drawing.Point(503, 2);
            this.txtmadangnhap.Name = "txtmadangnhap";
            this.txtmadangnhap.Size = new System.Drawing.Size(121, 22);
            this.txtmadangnhap.TabIndex = 2;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(734, 3);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(131, 22);
            this.txtpassword.TabIndex = 3;
            // 
            // btdangxuat
            // 
            this.btdangxuat.Location = new System.Drawing.Point(1119, 1);
            this.btdangxuat.Name = "btdangxuat";
            this.btdangxuat.Size = new System.Drawing.Size(83, 23);
            this.btdangxuat.TabIndex = 4;
            this.btdangxuat.Text = "Đăng xuất";
            this.btdangxuat.UseVisualStyleBackColor = true;
            this.btdangxuat.Click += new System.EventHandler(this.btdangxuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(386, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(644, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cán Bộ",
            "Học Sinh"});
            this.comboBox1.Location = new System.Drawing.Point(883, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // bPass
            // 
            this.bPass.Location = new System.Drawing.Point(923, 3);
            this.bPass.Name = "bPass";
            this.bPass.Size = new System.Drawing.Size(180, 25);
            this.bPass.TabIndex = 8;
            this.bPass.Text = "Đổi Mật Khẩu";
            this.bPass.UseVisualStyleBackColor = true;
            this.bPass.Click += new System.EventHandler(this.bPass_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImage = global::DOTNETTHANGTIEN.Properties.Resources._MGL571752;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1214, 453);
            this.Controls.Add(this.bPass);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btdangxuat);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtmadangnhap);
            this.Controls.Add(this.btdangnhap);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.Text = "QUẢN LÍ THÔNG TIN VÀ ĐIỂM HỌC SINH TIỂU HỌC";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giáoViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem họcSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem điểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ghiChúToolStripMenuItem;
        private System.Windows.Forms.Button btdangnhap;
        private System.Windows.Forms.TextBox txtmadangnhap;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btdangxuat;
        private System.Windows.Forms.ToolStripMenuItem khuyếtTậtToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem họcLựcToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bPass;
    }
}

