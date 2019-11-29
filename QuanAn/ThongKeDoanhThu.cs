using QuanAn.BL;
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
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.Font = new Font("UTM", 10, FontStyle.Regular);
            textBox1.Font= new Font("UTM", 10, FontStyle.Bold);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = BLBill.LietKe(dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridView1.Columns["Total"].DefaultCellStyle.Format = "#,##0";
                textBox1.Text = string.Format("{0:#,##0}", BLBill.ThongKe(dateTimePicker1.Value, dateTimePicker2.Value));
            }
            catch { }
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {

        }
    }
}
