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
    public partial class DoiPass : Form
    {

        DataClasses3DataContext db = new DataClasses3DataContext();
        public DoiPass()
        {
            InitializeComponent();
            textBox4.Enabled = false;
        }

        public void funData(TextBox txtForm1)
        {
            textBox4.Text = txtForm1.Text;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") MessageBox.Show("Vui lòng nhập mật khẩu cũ");
                if (textBox2.Text == "") MessageBox.Show("Vui lòng nhập mật khẩu mới");
                if (textBox3.Text == "") MessageBox.Show("Vui lòng xác nhập lại mật khẩu mới");
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    var x = from d in db.ACCOUNTs
                            where (d.Tên_người_dùng == textBox4.Text && d.Password == textBox1.Text)
                            select d;
                    if (x.Any())
                    {
                        if (textBox2.Text.Length < 8) MessageBox.Show("Vui lòng nhập mật khẩu lớn hơn 8 kí tự");
                        if (textBox2.Text.Length >= 8)
                        {
                            if (textBox3.Text != textBox2.Text) MessageBox.Show("Vui lòng kiểm tra lại mật khẩu xác nhận");
                            if (textBox3.Text == textBox2.Text)
                            {
                                var y = db.ACCOUNTs.Where(p => p.Tên_người_dùng == textBox4.Text).Single();
                                y.Password = textBox2.Text;
                                db.SubmitChanges();
                                MessageBox.Show("Mật khẩu đã thay đổi thành công");
                                this.Hide();
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
