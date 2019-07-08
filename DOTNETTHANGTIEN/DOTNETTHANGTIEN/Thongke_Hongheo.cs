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
    public partial class Thongke_Hongheo : Form
    {
        DataClasses3DataContext db = new DataClasses3DataContext();
        public Thongke_Hongheo()
        {
            InitializeComponent();
        }

        void loadKhoi()
        {
            var x = from kh in db.BANGKHOIs
                    select kh.Tên_khối;
            cbKhoi.DataSource = x.ToList();
            cbKhoi.SelectedItem = null;
        }

        void LoadSchool()
        {
            var x = from hs in db.BANGHOCSINHs
                    where hs.Sổ_hộ_nghèo == true
                    select new
                    {
                        hs.Tên_học_sinh,
                        hs.BANGLOPHOC.Tên_lớp,
                        hs.Giới_tính,
                        hs.Hộ_khẩu_thường_trú
                    };
            dataGridView1.DataSource = x.ToList();
        }
        private void Thongke_Hongheo_Load(object sender, EventArgs e)
        {
            loadKhoi();
            LoadSchool();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSchool();
        }

        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbLop.DataSource = null;
                string s = cbKhoi.SelectedItem.ToString();
                var x = from lp in db.BANGLOPHOCs
                        join kh in db.BANGKHOIs
                        on lp.Mã_khối equals kh.Mã_khối
                        where kh.Tên_khối == s
                        select lp.Tên_lớp;
                cbLop.DataSource = x.ToList();
                cbLop.Text = null;

                var y = from hs in db.BANGHOCSINHs
                        where (hs.Sổ_hộ_nghèo == true && hs.BANGLOPHOC.BANGKHOI.Tên_khối == cbKhoi.SelectedItem.ToString())
                        select new
                        {
                            hs.Tên_học_sinh,
                            hs.BANGLOPHOC.Tên_lớp,
                            hs.Giới_tính,
                            hs.Hộ_khẩu_thường_trú
                        };
                dataGridView1.DataSource = y.ToList();
            }
            catch { }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var y = from hs in db.BANGHOCSINHs
                        where (hs.Sổ_hộ_nghèo == true && hs.BANGLOPHOC.Tên_lớp == cbLop.SelectedItem.ToString())
                        select new
                        {
                            hs.Tên_học_sinh,
                            hs.BANGLOPHOC.Tên_lớp,
                            hs.Giới_tính,
                            hs.Hộ_khẩu_thường_trú
                        };
                dataGridView1.DataSource = y.ToList();
            }
            catch { }
        }
    }
}
