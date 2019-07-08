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
    public partial class Diem : Form
    {
        DataClasses3DataContext db = new DataClasses3DataContext();
        public Diem()
        {
            InitializeComponent();
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void Diem_Load(object sender, EventArgs e)
        {
            cbYear.SelectedItem = cbYear.Items[0];
            //if (cbKhoi.SelectedIndex < 0) treeView1.Nodes.Clear();
        }

        //phan quyen
        public void setQuyen(string quyen, string acc)
        {
            try
            {
                if (quyen == "Cán Bộ")
                {
                    if (acc != "admin")
                    {
                        cbYear.SelectedItem = cbYear.Items[0].ToString();
                        cbYear.Enabled = false;
                        string lps = "";
                        string mh = "";
                        var x = from gv in db.BANGGIAOVIENs
                                where (gv.Mã_giáo_viên == acc)
                                select new
                                {
                                    chủ_nhiệm = gv.Chủ_nhiệm,
                                    lớp_cn = gv.Mã_lớp,
                                    dạy_lớp = gv.Dạy_lớp,
                                    tên_môn_học = gv.BANGMONHOC.Tên_môn_học,
                                    mã_môn_học = gv.BANGMONHOC.Mã_môn_học
                                };
                        //load lại cbkhoi cblop
                        int i = 0;
                        foreach (var item in x)
                        {
                            
                            textBox2.Text = item.mã_môn_học;
                            textBox1.Text = item.lớp_cn.Substring(0, 1) + "-" + item.lớp_cn.Substring(1, 1);
                            lps = item.dạy_lớp;
                            while (i <= lps.Length)
                            {
                                comboBox1.Items.Add(lps.Substring(i, 3));
                                i += 4;
                            }
                            //load cbkhoi
                            string lopcn = item.lớp_cn;
                            var z = from kh in db.BANGKHOIs
                                    join lp in db.BANGLOPHOCs
                                    on kh.Mã_khối equals lp.Mã_khối
                                    where (lp.Mã_lớp == lopcn)
                                    select new
                                    {
                                        khoi = kh.Tên_khối,
                                        lop = lp.Tên_lớp
                                    };
                            loadKhoi();
                            foreach (var item2 in z)
                            {
                                cbKhoi.SelectedItem = item2.khoi;
                                cbKhoi.SelectedIndex = Convert.ToInt32(item2.khoi) - 1;
                                treeView1.Nodes.Clear();
                                cbKhoi.Enabled = false;
                                textBox3.Text = item2.lop;
                            }
                        }
                    }
                    if (acc == "admin")
                    {
                        textBox1.Text = "admin";
                        comboBox1.Visible = false;
                        loadKhoi();
                        cbKhoi.Text = null;
                        treeView1.Nodes.Clear();
                    }
                }
                else if (quyen == "Học Sinh")
                {

                    bAdd.Visible = false;
                    bUpdate.Visible = false;
                    bDel.Visible = false;
                    //comboBox1.Visible = false;
                    var x = from hs in db.BANGHOCSINHs
                            where (hs.Mã_học_sinh == acc)
                            select new
                            {
                                
                                lớp = hs.BANGLOPHOC.Tên_lớp,
                                khối = hs.BANGLOPHOC.BANGKHOI.Tên_khối,
                                tên = hs.Tên_học_sinh
                            };
                    loadKhoi();        

                    treeView1.Nodes.Clear();
                    foreach (var item in x)
                    {
                        TreeNode root = new TreeNode();
                        treeView1.Nodes.Add(item.tên);
                        //cbKhoi.Text = item.khối;
                        string lp = item.lớp;
                        comboBox1.Text = lp;
                        cbKhoi.Enabled = false;
                        comboBox1.Enabled = false;
                    }
                }
            }
            catch { }
        }

        //load combobox Khối
        void loadKhoi()
        {
            var x = from kh in db.BANGKHOIs
                    select kh.Tên_khối;
            cbKhoi.DataSource = x.ToList();
            //cbKhoi.SelectedItem = null;
        }

        //event selected combobox khối
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

                    //thêm tên hs vào treeview
                    if (cbKhoi.SelectedIndex >= 0)
                {

                    treeView1.Nodes.Clear();
                    TreeNode root = new TreeNode();
                    root.Text = "Chọn học sinh";
                    treeView1.Nodes.Add(root);

                    var y = from hs in db.BANGHOCSINHs
                            where hs.BANGLOPHOC.BANGKHOI.Tên_khối == cbKhoi.SelectedItem.ToString()
                            select hs.Tên_học_sinh;
                    foreach (var item in y)
                    {
                        treeView1.Nodes.Add(item.ToString());
                    }
                }
            }
            catch { }
        }


        //thêm tên học sinh khi chọn lớp
        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode root = new TreeNode();
                root.Text = "Chọn học sinh";
                treeView1.Nodes.Add(root);

                var x = from hs in db.BANGHOCSINHs
                        where (hs.BANGLOPHOC.Tên_lớp == cbLop.SelectedItem.ToString())
                        select hs.Tên_học_sinh;
                foreach (var item in x)
                {
                    treeView1.Nodes.Add(item.ToString());
                }
            }
            catch { }          
        }

        double? DtbCacMon(int? a, int? b)
        {
            double? x = (a + b) / 2;
            return x;
        }

        //diem trung binh cho lớp 1
        double DTBNam12(double a, double b, double c, double d, double e, double f, double g)
        {
            double x = (a + b + c + d + e + f + g) / 7;
            return x;
        }

        double DTBNam3(double a, double b, double c, double d, double e, double f, double g, double h, double i)
        {
            double x = (a + b + c + d + e + f + g + h + i) / 9;
            return x;
        }
        double DTBNam45(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k)
        {
            double x = (a + b + c + d + e + f + g + h + i + j + k) / 11;
            return x;
        }

        //hàm tính điểm
        void xuatdiem1(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_1_I >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giữa_kì_1_I,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_1_I,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_1_I, d.Điểm_cuối_kì_1_I),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_2_I >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_2_I,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_2_I,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_2_I, d.Điểm_cuối_kì_2_I),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }

        void xuatdiem2(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_3_II >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giữa_kì_3_II,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_3_II,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_3_II, d.Điểm_cuối_kì_3_II),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_4_II >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_4_II,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_4_II,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_4_II, d.Điểm_cuối_kì_4_II),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }


        void xuatdiem3(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_5_III >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_5_III,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_5_III,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_5_III, d.Điểm_cuối_kì_5_III),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_6_III >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_6_III,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_6_III,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_6_III, d.Điểm_cuối_kì_6_III),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }

        void xuatdiem4(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                    join mh in db.BANGMONHOCs
                    on d.Mã_môn_học equals mh.Mã_môn_học
                    join hs in db.BANGHOCSINHs
                    on d.Mã_học_sinh equals hs.Mã_học_sinh
                    where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_7_IV >= 0)
                    select new
                    {
                        Tên_môn_học = mh.Tên_môn_học,
                        Điểm_giữa_kì_1 = d.Điểm_giữa_kì_7_IV,
                        Điểm_cuối_kì_1 = d.Điểm_cuối_kì_7_IV,
                        ĐTB = DtbCacMon(d.Điểm_giữa_kì_7_IV, d.Điểm_cuối_kì_7_IV),
                    };
            dataGridView2.DataSource = x.ToList();
            }
            else {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_8_IV >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_8_IV,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_8_IV,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_8_IV, d.Điểm_cuối_kì_8_IV),
                        };
                dataGridView2.DataSource = x.ToList();
            }      
        }
        void xuatdiem5(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giũa_kì_9_V >= 0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giũa_kì_9_V,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_9_V,
                            ĐTB = DtbCacMon(d.Điểm_giũa_kì_9_V, d.Điểm_cuối_kì_9_V),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_10_V >=0)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_10_V,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_10_V,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_10_V, d.Điểm_cuối_kì_10_V),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }

        //node mouse click
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode node = e.Node;
                string ten = node.Text;
                txtName.Text = ten;
                if (cbYear.Enabled == true)
                {
                    //if (cbYear.SelectedIndex < 0) MessageBox.Show("vui lòng chọn năm");
                    if (cbKi.SelectedIndex < 0) cbKi.SelectedIndex = 0;
                    if (cbYear.SelectedIndex >= 0 && cbKi.SelectedIndex >= 0)
                    {
                        string ki = cbKi.Text;
                        if (cbYear.SelectedIndex == 0)
                        {
                            if (cbKhoi.SelectedIndex == 4) xuatdiem5(ten, ki);
                            if (cbKhoi.SelectedIndex == 3) xuatdiem4(ten, ki);
                            if (cbKhoi.SelectedIndex == 2) xuatdiem3(ten, ki);
                            if (cbKhoi.SelectedIndex == 1) xuatdiem2(ten, ki);
                            if (cbKhoi.SelectedIndex == 0) xuatdiem1(ten, ki);
                        }
                        if (cbYear.SelectedIndex == 1)
                        {
                            if (cbKhoi.SelectedIndex == 4) xuatdiem4(ten, ki);
                            if (cbKhoi.SelectedIndex == 3) xuatdiem3(ten, ki);
                            if (cbKhoi.SelectedIndex == 2) xuatdiem2(ten, ki);
                            if (cbKhoi.SelectedIndex == 1) xuatdiem1(ten, ki);
                            if (cbKhoi.SelectedIndex == 0) dataGridView2.DataSource = null;
                        }
                        if (cbYear.SelectedIndex == 2)
                        {
                            if (cbKhoi.SelectedIndex == 4) xuatdiem3(ten, ki);
                            if (cbKhoi.SelectedIndex == 3) xuatdiem2(ten, ki);
                            if (cbKhoi.SelectedIndex == 2) xuatdiem1(ten, ki);
                            if (cbKhoi.SelectedIndex == 1) dataGridView2.DataSource = null;
                            if (cbKhoi.SelectedIndex == 0) dataGridView2.DataSource = null;
                        }
                        if (cbYear.SelectedIndex == 3)
                        {
                            if (cbKhoi.SelectedIndex == 4) xuatdiem2(ten, ki);
                            if (cbKhoi.SelectedIndex == 3) xuatdiem1(ten, ki);
                            if (cbKhoi.SelectedIndex == 2) dataGridView2.DataSource = null;
                            if (cbKhoi.SelectedIndex == 1) dataGridView2.DataSource = null;
                            if (cbKhoi.SelectedIndex == 0) dataGridView2.DataSource = null;
                        }
                        if (cbYear.SelectedIndex == 4)
                        {
                            if (cbKhoi.SelectedIndex == 4) xuatdiem1(ten, ki);
                            if (cbKhoi.SelectedIndex == 3) dataGridView2.DataSource = null;
                            if (cbKhoi.SelectedIndex == 2) dataGridView2.DataSource = null;
                            if (cbKhoi.SelectedIndex == 1) dataGridView2.DataSource = null;
                            if (cbKhoi.SelectedIndex == 0) dataGridView2.DataSource = null;
                        }
                        calculate();
                    }
                }
                if (cbYear.Enabled == false)
                {
                    string lps = comboBox1.SelectedItem.ToString();
                    string lop = textBox1.Text;
                    string ki = cbKi.Text;
                    if (comboBox1.SelectedItem.ToString() != lop)
                    {
                        if (cbKhoi.SelectedIndex == 4) xuatdiem52(ten, ki);
                        if (cbKhoi.SelectedIndex == 3) xuatdiem42(ten, ki);
                        if (cbKhoi.SelectedIndex == 2) xuatdiem32(ten, ki);
                        if (cbKhoi.SelectedIndex == 1) xuatdiem22(ten, ki);
                        if (cbKhoi.SelectedIndex == 0) xuatdiem12(ten, ki);
                        calculate();
                    }
                    if (comboBox1.SelectedItem.ToString().Substring(0, 3) == lop.Substring(0,3))
                    {
                        if (cbKhoi.SelectedIndex == 4) xuatdiem5(ten, ki);
                        if (cbKhoi.SelectedIndex == 3) xuatdiem4(ten, ki);
                        if (cbKhoi.SelectedIndex == 2) xuatdiem3(ten, ki);
                        if (cbKhoi.SelectedIndex == 1) xuatdiem2(ten, ki);
                        if (cbKhoi.SelectedIndex == 0) xuatdiem1(ten, ki);
                        calculate();
                    }

                }
            }
            catch { }
        }

        void calculate()
        {
            double dtb1 = 0;
            double dtb = 0;
            int dem = dataGridView2.Rows.Count;
                dtb1 = Convert.ToDouble(dataGridView2.Rows[0].Cells["ĐTB"].Value.ToString()) + Convert.ToDouble(dataGridView2.Rows[1].Cells["ĐTB"].Value.ToString());
            dtb = dtb1 / 2;
            if (dtb >= 9.5) txtXepLoai.Text = "Xuất Sắc";
            if (dtb >= 9.0 && dtb < 9.5) txtXepLoai.Text = "Giỏi";
            if (dtb >= 7.0 && dtb < 9.0) txtXepLoai.Text = "Khá";
            if (dtb < 7.0 && dtb >= 0.0) txtXepLoai.Text = "Trung Bình - Yếu";
            txtDTB.Text = (dtb1 / 2).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

        }

        private void bUpdate_Click(object sender, EventArgs e)
        {

        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKi.Text = null;
        }

        private void cbKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                TreeNode root = new TreeNode();
                root.Text = "Chọn học sinh";
                treeView1.Nodes.Add(root);

                var x = from hs in db.BANGHOCSINHs
                        where (hs.BANGLOPHOC.Tên_lớp == comboBox1.SelectedItem.ToString())
                        select hs.Tên_học_sinh;
                foreach (var item in x)
                {
                    treeView1.Nodes.Add(item.ToString());
                }
            }
            catch { }
        }

        void xuatdiem12(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_1_I >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giữa_kì_1_I,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_1_I,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_1_I, d.Điểm_cuối_kì_1_I),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_2_I >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_2_I,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_2_I,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_2_I, d.Điểm_cuối_kì_2_I),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }

        void xuatdiem22(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_3_II >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giữa_kì_3_II,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_3_II,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_3_II, d.Điểm_cuối_kì_3_II),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_4_II >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_4_II,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_4_II,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_4_II, d.Điểm_cuối_kì_4_II),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }


        void xuatdiem32(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_5_III >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_5_III,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_5_III,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_5_III, d.Điểm_cuối_kì_5_III),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_6_III >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_6_III,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_6_III,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_6_III, d.Điểm_cuối_kì_6_III),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }

        void xuatdiem42(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_7_IV >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giữa_kì_7_IV,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_7_IV,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_7_IV, d.Điểm_cuối_kì_7_IV),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_8_IV >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_8_IV,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_8_IV,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_8_IV, d.Điểm_cuối_kì_8_IV),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }
        void xuatdiem52(string ten, string ki)
        {
            if (ki == "Kì I")
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giũa_kì_9_V >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_1 = d.Điểm_giũa_kì_9_V,
                            Điểm_cuối_kì_1 = d.Điểm_cuối_kì_9_V,
                            ĐTB = DtbCacMon(d.Điểm_giũa_kì_9_V, d.Điểm_cuối_kì_9_V),
                        };
                dataGridView2.DataSource = x.ToList();
            }
            else
            {
                var x = from d in db.BANGDIEMs
                        join mh in db.BANGMONHOCs
                        on d.Mã_môn_học equals mh.Mã_môn_học
                        join hs in db.BANGHOCSINHs
                        on d.Mã_học_sinh equals hs.Mã_học_sinh
                        where (hs.Tên_học_sinh == ten && d.Điểm_giữa_kì_10_V >= 0 && d.Mã_môn_học == textBox2.Text)
                        select new
                        {
                            Tên_môn_học = mh.Tên_môn_học,
                            Điểm_giữa_kì_2 = d.Điểm_giữa_kì_10_V,
                            Điểm_cuối_kì_2 = d.Điểm_cuối_kì_10_V,
                            ĐTB = DtbCacMon(d.Điểm_giữa_kì_10_V, d.Điểm_cuối_kì_10_V),
                        };
                dataGridView2.DataSource = x.ToList();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void bDel_Click(object sender, EventArgs e)
        {

        }
    }
}
