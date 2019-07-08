using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using Exel = Microsoft.Office.Interop.Excel;


namespace DOTNETTHANGTIEN
{
    public partial class Hocsinh_Thongtinnhanthan : Form
    {
        public Hocsinh_Thongtinnhanthan()
        {
            InitializeComponent();
        }
        DataClasses3DataContext db = new DataClasses3DataContext();


        public void setQuyen1(string quyen, string acc)
        {
            if (quyen == "Cán Bộ")
            {
                if (acc == "admin") loadKhoi();
                if (acc != "admin")
                {
                    string lps = "";
                    string tlpcn = "";
                    var x = from gv in db.BANGGIAOVIENs
                            where (gv.Mã_giáo_viên == acc)
                            select new
                            {
                                chủ_nhiệm = gv.Chủ_nhiệm,
                                lớp_cn = gv.Mã_lớp,
                                dạy_lớp = gv.Dạy_lớp,
                                tên_môn_học = gv.BANGMONHOC.Tên_môn_học
                            };
                    foreach (var item in x)
                    {
                        string lpcn = item.lớp_cn;
                        var y = from lp in db.BANGLOPHOCs
                                where lp.Mã_lớp == lpcn
                                select new
                                {
                                    lp.Tên_lớp,
                                    lp.BANGKHOI.Tên_khối
                                };
                        foreach (var item1 in y)
                        {
                            cbKhoi.SelectedItem = item1.Tên_khối;
                            cbLop.SelectedItem = item1.Tên_lớp;
                            cbKhoi.Enabled = false;
                            cbLop.Enabled = false;
                            bShow.Visible = false;
                            Show();
                        }
                    }       
                }
            }
            if(quyen == "Học Sinh")
            {
                cbLop.Enabled = false;
                cbKhoi.Enabled = false;
                bAdd.Visible = false;
                bUpdate.Visible = false;
                bDel.Visible = false;
                var x = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        where hs.Mã_học_sinh == acc
                        select new
                        {
                            hs.Mã_học_sinh,
                            hs.Tên_học_sinh,
                            hs.Giới_tính,
                            hs.Ngày_sinh,
                            hs.Hộ_khẩu_thường_trú,
                            kh.Tên_khối,
                            lp.Tên_lớp,
                            hs.Họ_và_tên_cha,
                            hs.Nghề_nghiệp_cha,
                            hs.Họ_và_tên_mẹ,
                            hs.Nghề_nghiệp_mẹ,
                            hs.Sổ_hộ_nghèo,
                            hs.Khuyết_tật
                        };
                dataGridView1.DataSource = x.ToList();

                cbKhoi.Text = dataGridView1.Rows[0].Cells["Tên_khối"].Value.ToString();
                cbLop.Text= dataGridView1.Rows[0].Cells["Tên_lớp"].Value.ToString();
                txtMHS.Text = acc;
                txtAddress.Text = dataGridView1.Rows[0].Cells["Hộ_khẩu_thường_trú"].Value.ToString();
                txtName.Text = dataGridView1.Rows[0].Cells["Tên_học_sinh"].Value.ToString(); 
                txtNameCha.Text = dataGridView1.Rows[0].Cells["Họ_và_tên_cha"].Value.ToString();
                txtNameMe.Text = dataGridView1.Rows[0].Cells["Họ_và_tên_mẹ"].Value.ToString();
                txtNgheCha.Text = dataGridView1.Rows[0].Cells["Nghề_nghiệp_cha"].Value.ToString(); 
                txtNgheMe.Text = dataGridView1.Rows[0].Cells["Nghề_nghiệp_mẹ"].Value.ToString(); 
                checkHoNgheo.Checked = Convert.ToBoolean(dataGridView1.Rows[0].Cells["Sổ_hộ_nghèo"].Value.ToString());
                checkKhuyetTat.Checked = Convert.ToBoolean(dataGridView1.Rows[0].Cells["Khuyết_tật"].Value.ToString());
                if (dataGridView1.Rows[0].Cells["Giới_tính"].Value.ToString() == "True")
                {
                    rNam.Checked = true;
                }
                else rNu.Checked = true;
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[0].Cells["Ngày_sinh"].Value);

                var z = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        where hs.Mã_học_sinh == acc
                        select new
                        {
                            hs.BANGLOPHOC.BANGGIAOVIEN.Tên_giáo_viên
                        };
            foreach(var itemgv in z)
            {
                    txtNameGV.Text = itemgv.Tên_giáo_viên;
            }
            }
        }

        //load CB Khoi
        void loadKhoi()
        {
            var x = from kh in db.BANGKHOIs
                    select kh.Tên_khối;
            cbKhoi.DataSource = x.ToList();
            cbKhoi.SelectedItem = null;
        }

        //hàm show datagridview
        void Show()
        {
            if (cbLop.SelectedIndex >= 0)
            {
                string s = cbLop.SelectedItem.ToString();
                var x = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        where lp.Tên_lớp == s
                        select new
                        {
                            hs.Mã_học_sinh,
                            hs.Tên_học_sinh,
                            hs.Giới_tính,
                            hs.Ngày_sinh,
                            hs.Hộ_khẩu_thường_trú,
                            kh.Tên_khối,
                            lp.Tên_lớp,
                            hs.Họ_và_tên_cha,
                            hs.Nghề_nghiệp_cha,
                            hs.Họ_và_tên_mẹ,
                            hs.Nghề_nghiệp_mẹ,
                            hs.Sổ_hộ_nghèo,
                            hs.Khuyết_tật
                        };
                dataGridView1.DataSource = x.ToList();
            }
            if (cbLop.SelectedIndex < 0)
            {
                string s = cbKhoi.SelectedItem.ToString();
                var x = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        join gv in db.BANGGIAOVIENs
                        on hs.Mã_giáo_viên equals gv.Mã_giáo_viên
                        where kh.Tên_khối == s
                        select new
                        {
                            hs.Mã_học_sinh,
                            hs.Tên_học_sinh,
                            hs.Giới_tính,
                            hs.Ngày_sinh,
                            hs.Hộ_khẩu_thường_trú,
                            kh.Tên_khối,
                            lp.Tên_lớp,
                            hs.Họ_và_tên_cha,
                            hs.Nghề_nghiệp_cha,
                            hs.Họ_và_tên_mẹ,
                            hs.Nghề_nghiệp_mẹ,
                            hs.Sổ_hộ_nghèo,
                            hs.Khuyết_tật,
                        };
                dataGridView1.DataSource = x.ToList();
            }
        }

        //đặt lại tất cả ==null
        void ClearForm()
        {
            txtMHS.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtNameCha.Text = "";
            txtNgheCha.Text = "";
            txtNameMe.Text = "";
            txtNgheMe.Text = "";
            txtNameGV.Text = "";
            checkHoNgheo.Checked = false;
            checkKhuyetTat.Checked = false;
            rNam.Checked = false;
            rNu.Checked = false;
        }

        //button Show
        private void bShow_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                if (cbKhoi.SelectedIndex < 0) MessageBox.Show("Vui long chon khoi");
                else Show();

                
            }
            catch { }
    }

        //Load form
        private void Hocsinh_Thongtinnhanthan_Load(object sender, EventArgs e)
        {
            loadKhoi();
        }

        //load CB lop
        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                var studs = db.BANGHOCSINHs.Where(p => p.Mã_học_sinh == row.Cells["Mã_học_sinh"].Value.ToString()).SingleOrDefault();
                txtMHS.Text = studs.Mã_học_sinh;
                txtName.Text = studs.Tên_học_sinh;
                cbLop.SelectedItem = studs.BANGLOPHOC.Tên_lớp;
                if (studs.Giới_tính == true) rNam.Checked = true;
                else rNu.Checked = true;
                txtAddress.Text = studs.Hộ_khẩu_thường_trú;
                txtNameCha.Text = studs.Họ_và_tên_cha;
                txtNgheCha.Text = studs.Nghề_nghiệp_cha;
                txtNameMe.Text = studs.Họ_và_tên_mẹ;
                txtNgheMe.Text = studs.Nghề_nghiệp_mẹ;
                dateTimePicker1.Value = studs.Ngày_sinh;
                checkHoNgheo.Checked = studs.Sổ_hộ_nghèo;
                checkKhuyetTat.Checked = studs.Khuyết_tật;
                txtNameGV.Text = studs.BANGLOPHOC.BANGGIAOVIEN.Tên_giáo_viên;
            }
            catch { }          
        }

        //button DEL
        private void bDel_Click(object sender, EventArgs e)
        {
            try { 
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                var studs1 = db.BANGHOCSINHs.Where(p => p.Mã_học_sinh == row.Cells["Mã_học_sinh"].Value.ToString()).SingleOrDefault();
                db.BANGHOCSINHs.DeleteOnSubmit(studs1);
                db.SubmitChanges();
                ClearForm();
                Show();
            }
            catch { }
        }
        
        //nếu add thành công thì refresh lại datagridview
        public void setData(string trave)
        {
            string s = "1";
            if (s == trave)
            {
                Show();
            }
        }

        //button ADD
        private void bAdd_Click(object sender, EventArgs e)
        {
            AddHocSinh add = new AddHocSinh();
            add.Show();
            add.dataSender = new AddHocSinh.SendData(setData);
            ClearForm();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbKhoi.SelectedIndex < 0) MessageBox.Show("Vui long chon khoi");
                if (cbLop.SelectedIndex < 0) MessageBox.Show("Vui long chon lop");
                if (rNam.Checked == true && rNu.Checked == true || rNam.Checked == false && rNu.Checked == false) MessageBox.Show("Vui long chon gioi tinh");
                //if (txtMHS == null || txtMHS.Text == studs1.Mã_học_sinh) MessageBox.Show("Vui long kiem tra ma so hoc sinh");
                if (txtAddress == null) MessageBox.Show("Vui long dien dia chi hoc sinh");
                if (txtName == null) MessageBox.Show("Vui long dien ten hoc sinh");
                if (dateTimePicker1.Value == null) MessageBox.Show("Vui long chon ngay thanh nam sinh cua hoc sinh");
                if (cbKhoi.SelectedIndex >= 0 && cbLop.SelectedIndex >= 0 && txtAddress != null && txtName != null && dateTimePicker1.Value != null)
                {
                    var s = db.BANGLOPHOCs.Where(p => p.Tên_lớp == cbLop.SelectedItem.ToString()).SingleOrDefault();
                    var x = db.BANGHOCSINHs.Where(p => p.Mã_học_sinh == txtMHS.Text).SingleOrDefault();
                    x.Tên_học_sinh = txtName.Text;
                    x.Giới_tính = rNam.Checked;
                    x.Hộ_khẩu_thường_trú = txtAddress.Text;
                    x.Họ_và_tên_cha = txtNameCha.Text;
                    x.Nghề_nghiệp_cha = txtNgheCha.Text;
                    x.Họ_và_tên_mẹ = txtNameMe.Text;
                    x.Nghề_nghiệp_mẹ = txtNgheMe.Text;
                    x.Ngày_sinh = dateTimePicker1.Value;
                    x.Sổ_hộ_nghèo = checkHoNgheo.Checked;
                    x.Khuyết_tật = checkKhuyetTat.Checked;
                    x.Mã_giáo_viên = s.Mã_giáo_viên;
                    x.Mã_lớp = s.Mã_lớp;
                    x.Mã_khối = s.Mã_khối;

                    db.SubmitChanges();
                }
                Show();
            }
            catch { }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (cbLop.SelectedIndex < 0 && cbKhoi.SelectedIndex >=0)
            {
                var x = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        join gv in db.BANGGIAOVIENs
                        on hs.Mã_giáo_viên equals gv.Mã_giáo_viên
                        where (hs.Tên_học_sinh.Contains(txtSearch.Text) && kh.Tên_khối == cbKhoi.SelectedItem.ToString())
                        select new
                        {
                            hs.Mã_học_sinh,
                            hs.Tên_học_sinh,
                            hs.Giới_tính,
                            hs.Ngày_sinh,
                            hs.Hộ_khẩu_thường_trú,
                            kh.Tên_khối,
                            lp.Tên_lớp,
                            hs.Họ_và_tên_cha,
                            hs.Nghề_nghiệp_cha,
                            hs.Họ_và_tên_mẹ,
                            hs.Nghề_nghiệp_mẹ,
                            hs.Sổ_hộ_nghèo,
                            hs.Khuyết_tật,
                        };
                dataGridView1.DataSource = x.ToList();
            }
            if (cbLop.SelectedIndex >= 0)
            {
                var x = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        join gv in db.BANGGIAOVIENs
                        on hs.Mã_giáo_viên equals gv.Mã_giáo_viên
                        where (hs.Tên_học_sinh.Contains(txtSearch.Text) && lp.Tên_lớp == cbLop.SelectedItem.ToString())
                        select new
                        {
                            hs.Mã_học_sinh,
                            hs.Tên_học_sinh,
                            hs.Giới_tính,
                            hs.Ngày_sinh,
                            hs.Hộ_khẩu_thường_trú,
                            kh.Tên_khối,
                            lp.Tên_lớp,
                            hs.Họ_và_tên_cha,
                            hs.Nghề_nghiệp_cha,
                            hs.Họ_và_tên_mẹ,
                            hs.Nghề_nghiệp_mẹ,
                            hs.Sổ_hộ_nghèo,
                            hs.Khuyết_tật,
                        };
                dataGridView1.DataSource = x.ToList();
            }
            if (cbLop.SelectedIndex < 0 && cbKhoi.SelectedIndex < 0)
            {
                var x = from hs in db.BANGHOCSINHs
                        join lp in db.BANGLOPHOCs
                        on hs.Mã_lớp equals lp.Mã_lớp
                        join kh in db.BANGKHOIs
                        on hs.Mã_khối equals kh.Mã_khối
                        join gv in db.BANGGIAOVIENs
                        on hs.Mã_giáo_viên equals gv.Mã_giáo_viên
                        where (hs.Tên_học_sinh.Contains(txtSearch.Text))
                        select new
                        {
                            hs.Mã_học_sinh,
                            hs.Tên_học_sinh,
                            hs.Giới_tính,
                            hs.Ngày_sinh,
                            hs.Hộ_khẩu_thường_trú,
                            kh.Tên_khối,
                            lp.Tên_lớp,
                            hs.Họ_và_tên_cha,
                            hs.Nghề_nghiệp_cha,
                            hs.Họ_và_tên_mẹ,
                            hs.Nghề_nghiệp_mẹ,
                            hs.Sổ_hộ_nghèo,
                            hs.Khuyết_tật,
                        };
                dataGridView1.DataSource = x.ToList();
            }
        }
    }
}
