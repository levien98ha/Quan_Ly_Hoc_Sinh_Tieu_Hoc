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
    public partial class thongkehoctap : Form
    {
        DataClasses3DataContext db = new DataClasses3DataContext();
        public thongkehoctap()
        {
            InitializeComponent();
            dataGridView2.Visible = false;
        }

        private void bXem_Click(object sender, EventArgs e)
        {
            try
            {
                thongke();
                calculate();
            }
            catch { }
        }

        private void thongkehoctap_Load(object sender, EventArgs e)
        {
            if (cbKi.SelectedIndex < 0) cbKi.Text = cbKi.Items[0].ToString();
            loadKhoi();
        }

        //load combobox Khối
        void loadKhoi()
        {
            var x = from kh in db.BANGKHOIs
                    select kh.Tên_khối;
            cbKhoi.DataSource = x.ToList();
            cbKhoi.SelectedItem = null;
        }

        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // load combobox lớp
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

        double? DtbCacMon(double? a, double? b)
        {
            double? x = (a + b) / 2;
            return x;
        }

        void calculate()
        {
            try
            {
                int xs = 0, g = 0, kh = 0, tb = 0;
                double dtb1=0;
                if (cbKhoi.SelectedIndex == 0 || cbKhoi.SelectedIndex == 1)
                {
                    int i = 0, j = 7, d = 0;
                    double dtb = 0;
                    int dem = dataGridView2.Rows.Count;
                    DataTable da = new DataTable();
                    da.Columns.Add("Tên học sinh", typeof(string));
                    da.Columns.Add("Điểm trung bình", typeof(string));
                    for (j = 7; j <= dataGridView2.Rows.Count; j += 7)
                    {
                        dtb = Convert.ToDouble(dataGridView2.Rows[j-7].Cells["ĐTB"].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[j - 6].Cells["ĐTB"].Value.ToString());
                        string s = Math.Round(dtb / 2).ToString();
                        dtb1 = Math.Round(dtb / 2);
                        if (dtb1 >= 9.5) xs += 1;
                        if (dtb1 >= 9.0 && dtb1 < 9.5) g += 1;
                        if (dtb1 >= 7.0 && dtb1 < 9.0) kh+=1;
                        if (dtb1 < 7.0 && dtb1 >= 0.0) tb += 1;
                        string ten = dataGridView2.Rows[j - 1].Cells["Tên_học_sinh"].Value.ToString();
                        da.Rows.Add(ten, s);
                        dataGridView1.DataSource = da;
                    }
                    txtXS.Text = xs.ToString();
                    txtG.Text = g.ToString();
                    txtK.Text = kh.ToString();
                    txtTB.Text = tb.ToString();
                }
                if (cbKhoi.SelectedIndex == 2)
                {
                    int i = 0, j = 9, d = 0;
                    double dtb = 0;
                    int dem = dataGridView2.Rows.Count;
                    DataTable da = new DataTable();
                    da.Columns.Add("Tên học sinh", typeof(string));
                    da.Columns.Add("Điểm trung bình", typeof(string));
                    for (j = 9; j <= dataGridView2.Rows.Count; j += 9)
                    {
                        dtb = Convert.ToDouble(dataGridView2.Rows[j - 9].Cells["ĐTB"].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[j - 8].Cells["ĐTB"].Value.ToString());

                        string s = Math.Round(dtb / 2).ToString();
                        dtb1 = Math.Round(dtb / 2);
                        if (dtb1 >= 9.5) xs += 1;
                        if (dtb1 >= 9.0 && dtb1 < 9.5) g += 1;
                        if (dtb1 >= 7.0 && dtb1 < 9.0) kh += 1;
                        if (dtb1 < 7.0 && dtb1 >= 0.0) tb += 1;
                        string ten = dataGridView2.Rows[j - 1].Cells["Tên_học_sinh"].Value.ToString();
                        da.Rows.Add(ten, s);
                        dataGridView1.DataSource = da;
                    }
                    txtXS.Text = xs.ToString();
                    txtG.Text = g.ToString();
                    txtK.Text = kh.ToString();
                    txtTB.Text = tb.ToString();
                }
                if (cbKhoi.SelectedIndex == 3 || cbKhoi.SelectedIndex == 4)
                {
                    int i = 0, j = 11, d = 0;
                    double dtb = 0;
                    int dem = dataGridView2.Rows.Count;
                    DataTable da = new DataTable();
                    da.Columns.Add("Tên học sinh", typeof(string));
                    da.Columns.Add("Điểm trung bình", typeof(string));
                    for (j = 11; j <= dataGridView2.Rows.Count; j += 11)
                    {

                        dtb = Convert.ToDouble(dataGridView2.Rows[j - 11].Cells["ĐTB"].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[j - 10].Cells["ĐTB"].Value.ToString());

                        string s = Math.Round(dtb / 2).ToString();
                        dtb1 = Math.Round(dtb / 2);
                        if (dtb1 >= 9.5) xs += 1;
                        if (dtb1 >= 9.0 && dtb1 < 9.5) g += 1;
                        if (dtb1 >= 7.0 && dtb1 < 9.0) kh += 1;
                        if (dtb1 < 7.0 && dtb1 >= 0.0) tb += 1;
                        string ten = dataGridView2.Rows[j - 1].Cells["Tên_học_sinh"].Value.ToString();
                        da.Rows.Add(ten, s);
                        dataGridView1.DataSource = da;
                    }
                    txtXS.Text = xs.ToString();
                    txtG.Text = g.ToString();
                    txtK.Text = kh.ToString();
                    txtTB.Text = tb.ToString();
                }
            }
            catch { }
        }
        void thongke()
        {
            try
            {
                if (cbKhoi.SelectedIndex < 0) MessageBox.Show("Vui lòng chọn khối");
                if (cbLop.SelectedIndex >= 0)
                {
                    string khoi = cbKhoi.SelectedItem.ToString();
                    string lop = cbLop.SelectedItem.ToString();
                    string ki = cbKi.SelectedItem.ToString();
                    if (cbKhoi.SelectedIndex == 4) xuatdiem5(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 3) xuatdiem4(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 2) xuatdiem3(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 1) xuatdiem2(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 0) xuatdiem1(khoi, lop, ki);
                }
                if (cbLop.SelectedIndex < 0)
                {
                    string khoi = cbKhoi.SelectedItem.ToString();
                    string lop = "";
                    string ki = cbKi.SelectedItem.ToString();
                    if (cbKhoi.SelectedIndex == 4) xuatdiem5(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 3) xuatdiem4(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 2) xuatdiem3(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 1) xuatdiem2(khoi, lop, ki);
                    if (cbKhoi.SelectedIndex == 0) xuatdiem1(khoi, lop, ki);
                }
            }
            catch { }
}


        //khoi1
        void xuatdiem1(string khoi, string lop, string ki)
        {
            if (ki == "Kì I")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_1_I >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_1_I, d.Điểm_cuối_kì_1_I),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_1_I >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_1_I, d.Điểm_cuối_kì_1_I),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Kì II")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_2_I >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_2_I, d.Điểm_cuối_kì_2_I),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_2_I >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_2_I, d.Điểm_cuối_kì_2_I),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Cả Năm")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_2_I >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_1_I, d.Điểm_cuối_kì_1_I), DtbCacMon(d.Điểm_giữa_kì_2_I, d.Điểm_cuối_kì_2_I))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_2_I >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_1_I, d.Điểm_cuối_kì_1_I), DtbCacMon(d.Điểm_giữa_kì_2_I, d.Điểm_cuối_kì_2_I))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
        }

        //khoi 2
        void xuatdiem2(string khoi, string lop, string ki)
        {
            if (ki == "Kì I")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_3_II >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_3_II, d.Điểm_cuối_kì_3_II),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_4_II >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_3_II, d.Điểm_cuối_kì_3_II),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Kì II")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_4_II >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_4_II, d.Điểm_cuối_kì_4_II),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_4_II >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_4_II, d.Điểm_cuối_kì_4_II),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Cả Năm")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_4_II >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_3_II, d.Điểm_cuối_kì_3_II), DtbCacMon(d.Điểm_giữa_kì_4_II, d.Điểm_cuối_kì_4_II))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_4_II >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_3_II, d.Điểm_cuối_kì_3_II), DtbCacMon(d.Điểm_giữa_kì_4_II, d.Điểm_cuối_kì_4_II))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
        }

        //khoi 3
        void xuatdiem3(string khoi, string lop, string ki)
        {
            if (ki == "Kì I")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_5_III >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_5_III, d.Điểm_cuối_kì_5_III),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_5_III >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_5_III, d.Điểm_cuối_kì_5_III),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Kì II")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_6_III >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_6_III, d.Điểm_cuối_kì_6_III),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_6_III >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_6_III, d.Điểm_cuối_kì_6_III),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Cả Năm")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_6_III >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_5_III, d.Điểm_cuối_kì_5_III), DtbCacMon(d.Điểm_giữa_kì_6_III, d.Điểm_cuối_kì_6_III))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_5_III >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_5_III, d.Điểm_cuối_kì_5_III), DtbCacMon(d.Điểm_giữa_kì_6_III, d.Điểm_cuối_kì_6_III))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
        }

        //khoi 4
        void xuatdiem4(string khoi, string lop, string ki)
        {
            if (ki == "Kì I")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_7_IV >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_7_IV, d.Điểm_cuối_kì_7_IV),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_7_IV >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_7_IV, d.Điểm_cuối_kì_7_IV),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Kì II")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_8_IV >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_8_IV, d.Điểm_cuối_kì_8_IV),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_8_IV >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_8_IV, d.Điểm_cuối_kì_8_IV),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Cả Năm")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_8_IV >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_7_IV, d.Điểm_cuối_kì_7_IV), DtbCacMon(d.Điểm_giữa_kì_8_IV, d.Điểm_cuối_kì_8_IV))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_8_IV >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giữa_kì_7_IV, d.Điểm_cuối_kì_7_IV), DtbCacMon(d.Điểm_giữa_kì_8_IV, d.Điểm_cuối_kì_8_IV))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
        }

        void xuatdiem5(string khoi, string lop, string ki)
        {
            if (ki == "Kì I")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giũa_kì_9_V >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giũa_kì_9_V, d.Điểm_cuối_kì_9_V),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giũa_kì_9_V >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giũa_kì_9_V, d.Điểm_cuối_kì_9_V),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Kì II")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_10_V >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_10_V, d.Điểm_cuối_kì_10_V),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_10_V >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(d.Điểm_giữa_kì_10_V, d.Điểm_cuối_kì_10_V),
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
            if (ki == "Cả Năm")
            {
                if (cbLop.SelectedIndex < 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.BANGKHOI.Tên_khối == khoi && d.Điểm_giữa_kì_10_V >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giũa_kì_9_V, d.Điểm_cuối_kì_9_V), DtbCacMon(d.Điểm_giữa_kì_10_V, d.Điểm_cuối_kì_10_V))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
                if (cbLop.SelectedIndex >= 0)
                {
                    var x = from d in db.BANGDIEMs
                            join mh in db.BANGMONHOCs
                            on d.Mã_môn_học equals mh.Mã_môn_học
                            join hs in db.BANGHOCSINHs
                            on d.Mã_học_sinh equals hs.Mã_học_sinh
                            where (d.BANGHOCSINH.BANGLOPHOC.Tên_lớp == lop && d.Điểm_giữa_kì_10_V >= 0)
                            select new
                            {
                                Tên_học_sinh = d.BANGHOCSINH.Tên_học_sinh,
                                ĐTB = DtbCacMon(DtbCacMon(d.Điểm_giũa_kì_9_V, d.Điểm_cuối_kì_9_V), DtbCacMon(d.Điểm_giữa_kì_10_V, d.Điểm_cuối_kì_10_V))
                            };
                    dataGridView2.DataSource = x.ToList();
                }
            }
        }
    }
}
