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
    public partial class AddHocSinh : Form
    {
        public delegate void SendData(string trave);
        public SendData dataSender;
        public AddHocSinh()
        {
            InitializeComponent();
        }
        DataClasses3DataContext db = new DataClasses3DataContext();
        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //var studs1 = db.BANGHOCSINHs.Where(p => p.Mã_học_sinh).SingleOrDefault();
                if (cbKhoi1.SelectedIndex < 0) MessageBox.Show("Vui long chon khoi");
                if (cbLop1.SelectedIndex < 0) MessageBox.Show("Vui long chon lop");
                if (rNam.Checked == true && rNu.Checked == true || rNam.Checked == false && rNu.Checked == false) MessageBox.Show("Vui long chon gioi tinh");
                //if (txtMHS == null || txtMHS.Text == studs1.Mã_học_sinh) MessageBox.Show("Vui long kiem tra ma so hoc sinh");
                if (txtAddress == null) MessageBox.Show("Vui long dien dia chi hoc sinh");
                if (txtName == null) MessageBox.Show("Vui long dien ten hoc sinh");
                if (dateTimePicker1.Value == null) MessageBox.Show("Vui long chon ngay thanh nam sinh cua hoc sinh");
                if (cbKhoi1.SelectedIndex >= 0 && cbLop1.SelectedIndex >= 0 && txtAddress != null && txtName != null && dateTimePicker1.Value != null)
                {
                    var s = db.BANGLOPHOCs.Where(p => p.Tên_lớp == cbLop1.SelectedItem.ToString()).SingleOrDefault();

                    BANGHOCSINH studs = new BANGHOCSINH()
                    {
                        Mã_học_sinh = txtMHS.Text,
                        Tên_học_sinh = txtName.Text,
                        Giới_tính = rNam.Checked,
                        Hộ_khẩu_thường_trú = txtAddress.Text,
                        Họ_và_tên_cha = txtNameCha.Text,
                        Nghề_nghiệp_cha = txtNgheCha.Text,
                        Họ_và_tên_mẹ = txtNameMe.Text,
                        Nghề_nghiệp_mẹ = txtNgheMe.Text,
                        Ngày_sinh = dateTimePicker1.Value,
                        Sổ_hộ_nghèo = checkHoNgheo.Checked,
                        Khuyết_tật = checkKhuyetTat.Checked,
                        Mã_giáo_viên = s.Mã_giáo_viên,
                        Mã_lớp = s.Mã_lớp,
                        Mã_khối = s.Mã_khối
                    };
                    db.BANGHOCSINHs.InsertOnSubmit(studs);
                    db.SubmitChanges();
                }
                MessageBox.Show("thành công");
                string trave = "1";
                this.dataSender(trave);
                this.Hide();
            }
            catch { }
        }

        private void AddHocSinh_Load(object sender, EventArgs e)
        {
            loadKhoi1();
        }
        void loadKhoi1()
        {
            var x = from kh in db.BANGKHOIs
                    select kh.Tên_khối;
            cbKhoi1.DataSource = x.ToList();
            cbKhoi1.SelectedItem = null;
        }

        private void cbKhoi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbLop1.DataSource = null;
                string ss = cbKhoi1.SelectedItem.ToString();
                var x = from lop in db.BANGLOPHOCs
                        join kh in db.BANGKHOIs
                        on lop.Mã_khối equals kh.Mã_khối
                        where kh.Tên_khối == ss
                        select lop.Tên_lớp;
                cbLop1.DataSource = x.ToList();
                cbLop1.Text = null;
            }
            catch { }
        }
    }

}

