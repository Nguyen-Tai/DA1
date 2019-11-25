using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class FormManage : Form
    {
        public FormManage()
        {
            InitializeComponent();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormEmployee f = new FormEmployee();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormEmployee f = new FormEmployee();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormCustomer f = new FormCustomer();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCustomer f = new FormCustomer();
            this.Hide();
            f.ShowDialog();
        }

     

        private void FormManage_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FoodManager f = new FoodManager();
            this.Hide();
            f.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FoodManager f = new FoodManager();
            this.Hide();
            f.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormLoginManage f = new FormLoginManage();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormLoginManage f = new FormLoginManage();
            this.Hide();
            f.ShowDialog();
        }
    }
}
