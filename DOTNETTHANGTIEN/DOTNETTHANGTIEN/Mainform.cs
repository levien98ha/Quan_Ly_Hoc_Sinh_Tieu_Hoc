using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOTNETTHANGTIEN
{
    public partial class Mainform : Form
    {
        public delegate void SendQuyen(string quyen, string acc);
        public SendQuyen dataQuyen;

        public delegate void SendQuyen1(string quyen, string acc);
        public SendQuyen1 dataQuyen1;

        public delegate void delPassData(TextBox text);

        DataClasses3DataContext db = new DataClasses3DataContext();
        public Mainform()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danhmuc_Danhsachhocsinh da = new Danhmuc_Danhsachhocsinh();
            da.Show();
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danhmuc_Giaovien dm_gv = new Danhmuc_Giaovien();
            dm_gv.Show();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            btdangxuat.Visible = false;
            menuStrip1.Enabled = false;
            bPass.Visible = false;
        }

        void khoachucnang()
        {
            label1.Visible = false;
            label2.Visible = false;
            txtmadangnhap.Visible = false;
            txtpassword.Visible = false;
            btdangnhap.Visible = false;
            btdangxuat.Visible = true;
            comboBox1.Visible = false;
            menuStrip1.Enabled = true;
            bPass.Visible = true;
        }
        private void btdangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex < 0) MessageBox.Show("vui lòng chọn quyền");
                string acc = txtmadangnhap.Text;
                string pass = txtpassword.Text;
                string quyen = comboBox1.SelectedItem.ToString();
                
                var x = from d in db.ACCOUNTs
                        where (d.Tên_người_dùng == acc && d.Password == pass)
                        select d;
                if (x.Any())
                {
                    if (comboBox1.SelectedItem.ToString() == "Cán Bộ")
                    {
                        if (acc == "admin")
                        {
                            khoachucnang();
                        }
                        else
                        {
                            var y = from gv in db.BANGGIAOVIENs
                                    where gv.Mã_giáo_viên == acc
                                    select gv;
                            if (y.Any()) khoachucnang();
                            else MessageBox.Show("Vui lòng chọn lại chức danh");
                        }
                    }
                    else if(comboBox1.SelectedItem.ToString() =="Học Sinh")
                    {
                        var z = from hs in db.BANGHOCSINHs
                                where hs.Mã_học_sinh == acc
                                select hs;
                        if (z.Any()) khoachucnang();
                        else MessageBox.Show("Vui lòng chọn lại chức danh");
                    }
                }
                else MessageBox.Show("Kiểm tra lại tên đăng nhập và password");
      
            }
            catch { }
        }

        private void btdangxuat_Click(object sender, EventArgs e)
        {
            try
            {
                Mainform mf = new Mainform();
                mf.Show();
                this.Hide();
            }
            catch { }
        }

        //dang nhap
        //
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Hocsinh_Thongtinnhanthan hs = new Hocsinh_Thongtinnhanthan();
                hs.Show();
                string acc = txtmadangnhap.Text;
                string pass = txtpassword.Text;
                string quyen = comboBox1.SelectedItem.ToString();
                hs.setQuyen1(quyen, acc);

                this.dataQuyen1(quyen, acc);
            }
            catch { }
        }

        private void ghiChúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thongke_Hongheo hn = new Thongke_Hongheo();
                hn.Show();
            }
            catch { }
        }

        private void khuyếtTậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thongke_Khuyettat kt = new Thongke_Khuyettat();
                kt.Show();
            }
            catch { }
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Diem d = new Diem();
                d.Show();
                string acc = txtmadangnhap.Text;
                string pass = txtpassword.Text;
                string quyen = comboBox1.SelectedItem.ToString();
                d.setQuyen(quyen,acc);
                
                this.dataQuyen(quyen, acc);
            }
            catch { }
        }

        private void họcLựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                thongkehoctap tk = new thongkehoctap();
                tk.Show();
            }
            catch { }
        }


        private void bPass_Click(object sender, EventArgs e)
        {
            try
            {
                DoiPass dp = new DoiPass();
                delPassData del = new delPassData(dp.funData);
                del(this.txtmadangnhap);
                dp.Show();
            }
            catch { }
        }
    }
}
