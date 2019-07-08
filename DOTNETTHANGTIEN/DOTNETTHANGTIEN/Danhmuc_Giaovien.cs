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
    public partial class Danhmuc_Giaovien : Form
    {
        public Danhmuc_Giaovien()
        {
            InitializeComponent();
            loadKhoi();
            MonHoc();
        }

        DataClasses3DataContext db = new DataClasses3DataContext();

        //load khoi
        void loadKhoi()
        {
            var x = from kh in db.BANGKHOIs
                    select kh.Tên_khối;
            cbKhoi.DataSource = x.ToList();
            cbKhoi.SelectedItem = null;
        }

        //load lớp
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
            }
            catch { }
        }

        //load mon
        void MonHoc()
        {
            try
            {
                var x = from mh in db.BANGMONHOCs
                        select mh.Tên_môn_học;
                cbMonHoc.DataSource = x.ToList();
                cbMonHoc.SelectedItem = null;
            }
            catch { }
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            try
            {
                cbMonHoc.SelectedItem = null;
                cbLop.SelectedItem = null;
                cbKhoi.SelectedItem = null;
                cbChuNhiem.Checked = false;
                txttengiaovien.Text = null;

            }
            catch { }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttengiaovien.Text == "")
                {
                    if (cbKhoi.SelectedIndex < 0)
                    {
                        if (cbLop.SelectedIndex < 0)
                        {
                            if (cbMonHoc.SelectedIndex < 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            orderby gv.Tên_giáo_viên ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }

                                if (cbChuNhiem.Checked == true)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            where gv.Chủ_nhiệm == true
                                            orderby lp.Tên_lớp ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }

                            if (cbMonHoc.SelectedIndex >= 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            orderby gv.Tên_giáo_viên ascending
                                            where gv.BANGMONHOC.Tên_môn_học == mh
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == true)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            orderby gv.Tên_giáo_viên ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Chủ_nhiệm == true)
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                        }
                    }
                    if (cbKhoi.SelectedIndex >= 0)
                    {
                        if (cbLop.SelectedIndex < 0)
                        {
                            if (cbMonHoc.SelectedIndex < 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            where gv.Dạy_lớp.Contains(cbKhoi.SelectedItem.ToString().Substring(0, 1) + "-")
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,

                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == true)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            where (gv.Chủ_nhiệm == true && lp.BANGKHOI.Tên_khối == cbKhoi.SelectedItem.ToString())
                                            orderby lp.Tên_lớp ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                            if (cbMonHoc.SelectedIndex >= 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.Dạy_lớp.Contains(cbKhoi.SelectedItem.ToString().Substring(0, 1) + "-") && gv.BANGMONHOC.Tên_môn_học == mh)
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,

                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == true)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            orderby lp.Tên_lớp ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Chủ_nhiệm == true && lp.BANGKHOI.Tên_khối == cbKhoi.SelectedItem.ToString())
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp,
                                                lp.BANGKHOI.Tên_khối
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                        }
                        if (cbLop.SelectedIndex >= 0)
                        {
                            if (cbMonHoc.SelectedIndex < 0)
                            {
                                if (cbChuNhiem.Checked == true)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            where (gv.Chủ_nhiệm == true && lp.Tên_lớp == cbLop.SelectedItem.ToString())
                                            orderby lp.Tên_lớp ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == false)
                                {
                                    string lp = cbLop.SelectedItem.ToString();
                                    int i = 0;
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.Dạy_lớp.Contains(cbLop.SelectedItem.ToString().Substring(0, 3)))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                            if (cbMonHoc.SelectedIndex >= 0)
                            {
                                if (cbChuNhiem.Checked == true)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            orderby lp.Tên_lớp ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Chủ_nhiệm == true && lp.Tên_lớp == cbLop.SelectedItem.ToString())
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == false)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Dạy_lớp.Contains(cbLop.SelectedItem.ToString().Substring(0, 3)))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                        }
                    }
                }
                if (txttengiaovien.Text != "")
                {
                    if (cbKhoi.SelectedIndex < 0)
                    {
                        if (cbLop.SelectedIndex < 0)
                        {
                            if (cbMonHoc.SelectedIndex < 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            orderby gv.Tên_giáo_viên ascending
                                            where gv.Tên_giáo_viên.Contains(txttengiaovien.Text)
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }

                                if (cbChuNhiem.Checked == true)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            where (gv.Chủ_nhiệm == true && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            orderby lp.Tên_lớp ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }

                            if (cbMonHoc.SelectedIndex >= 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            orderby gv.Tên_giáo_viên ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == true)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            orderby gv.Tên_giáo_viên ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Chủ_nhiệm == true && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                        }
                    }
                    if (cbKhoi.SelectedIndex >= 0)
                    {
                        if (cbLop.SelectedIndex < 0)
                        {
                            if (cbMonHoc.SelectedIndex < 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.Dạy_lớp.Contains(cbKhoi.SelectedItem.ToString().Substring(0, 1) + "-") && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == true)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            where (gv.Chủ_nhiệm == true && lp.BANGKHOI.Tên_khối == cbKhoi.SelectedItem.ToString() && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            orderby lp.Tên_lớp ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp,
                                                lp.BANGKHOI.Tên_khối
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                            if (cbMonHoc.SelectedIndex >= 0)
                            {
                                if (cbChuNhiem.Checked == false)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.Dạy_lớp.Contains(cbKhoi.SelectedItem.ToString().Substring(0, 1) + "-") && gv.BANGMONHOC.Tên_môn_học == mh && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == true)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            orderby lp.Tên_lớp ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Chủ_nhiệm == true && lp.BANGKHOI.Tên_khối == cbKhoi.SelectedItem.ToString() && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                                lp.Tên_lớp,
                                                lp.BANGKHOI.Tên_khối
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                        }
                        if (cbLop.SelectedIndex >= 0)
                        {
                            if (cbMonHoc.SelectedIndex < 0)
                            {
                                if (cbChuNhiem.Checked == true)
                                {
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            where (gv.Chủ_nhiệm == true && lp.Tên_lớp == cbLop.SelectedItem.ToString() && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            orderby lp.Tên_lớp ascending
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == false)
                                {
                                    string lp = cbLop.SelectedItem.ToString();
                                    int i = 0;
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.Dạy_lớp.Contains(cbLop.SelectedItem.ToString().Substring(0, 3)) && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                            if (cbMonHoc.SelectedIndex >= 0)
                            {
                                if (cbChuNhiem.Checked == true)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            join lp in db.BANGLOPHOCs
                                            on gv.Mã_lớp equals lp.Mã_lớp
                                            orderby lp.Tên_lớp ascending
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Chủ_nhiệm == true && lp.Tên_lớp == cbLop.SelectedItem.ToString() && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                                if (cbChuNhiem.Checked == false)
                                {
                                    string mh = cbMonHoc.SelectedItem.ToString();
                                    var x = from gv in db.BANGGIAOVIENs
                                            where (gv.BANGMONHOC.Tên_môn_học == mh && gv.Dạy_lớp.Contains(cbLop.SelectedItem.ToString().Substring(0, 3)) && gv.Tên_giáo_viên.Contains(txttengiaovien.Text))
                                            select new
                                            {
                                                gv.Tên_giáo_viên,
                                                gv.BANGMONHOC.Tên_môn_học,
                                            };
                                    dataGridView1.DataSource = x.ToList();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
