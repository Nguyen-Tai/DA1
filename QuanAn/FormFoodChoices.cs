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
    public partial class FormFoodChoices : Form
    {
        int ID_Bill;
        public FormFoodChoices()
        {
            InitializeComponent();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            f.ShowDialog();
        }


        private void FormFoodChoices_Load(object sender, EventArgs e)
        {
            #region Dymamic Menu
            TabControl tab = new TabControl();
            var listCategory = BLMenu.GetListCategory();
            tab.Location = new Point(10, 65);
            tab.Size = new Size(545, 445);
            tab.Font = new Font("UTM Bebas", 12, FontStyle.Regular);
            for (int i = 0; i < listCategory.Count; i++)
            {
                TabPage tp = new TabPage(listCategory[i].Name);
                tp.Location = new Point(10, 58);
                tp.BackColor = Color.Transparent;

                var listFood = BLMenu.GetFoodByCategory(listCategory[i].ID);
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Location = new Point(0, 0);
                fl.BackColor = Color.Transparent;
                fl.AutoScroll = true;

                fl.Size = new Size(545, 445);

                for (int j = 0; j < listFood.Count; j++)
                {
                    Panel pn = new Panel();
                    pn.Size = new Size(170, 250);
                    pn.BackColor = Color.DarkGray;
                    PictureBox pc = new PictureBox();
                    pc.Location = new Point(20, 10);
                    pc.Size = new Size(130, 120);
                    pc.Image = Image.FromFile(@"C:\Users\TNT\Desktop\image_186656.jpg");
                    pc.SizeMode = PictureBoxSizeMode.StretchImage;
                    Label name = new Label();
                    Label lbGia = new Label();
                    Label VND = new Label();
                    Label sl = new Label();
                    NumericUpDown numeric = new NumericUpDown();
                    Button btnChon = new Button();
                    Button btnBoChon = new Button();

                    btnChon.Text = "Chọn";
                    btnBoChon.Text = "Bỏ Chọn";
                    btnChon.Font = new Font("UTM Bebas", 10, FontStyle.Regular);
                    btnBoChon.Font = new Font("UTM Bebas", 10, FontStyle.Regular);
                    btnChon.Tag = listFood[j].ID;
                    btnBoChon.Tag = listFood[j].ID;
                    btnChon.Click += new EventHandler(this.chon_Click);
                    btnBoChon.Click += new EventHandler(this.bochon_Click);
                    btnBoChon.Size = new Size(55, 30);
                    btnChon.Size = new Size(55, 30);
                    btnChon.Location = new Point(30, pn.Height - 5 - btnChon.Height);
                    btnBoChon.Location = new Point(30 + btnChon.Width, pn.Height - 5 - btnBoChon.Height);
                    btnBoChon.BackColor = Color.Transparent;
                    btnChon.BackColor = Color.Transparent;

                    sl.Text = "Số Lượng";
                    sl.Location = new Point(btnChon.Location.X, btnChon.Location.Y - 25);
                    sl.Size = new Size(60, 30);
                    numeric.Value = 0;
                    numeric.Name = "SL";
                    numeric.Font = new Font("UTM Bebas", 10, FontStyle.Regular);
                    numeric.Size = new Size(50, 25);
                    numeric.Location = new Point(sl.Location.X + sl.Width, sl.Location.Y);
                    pn.Controls.Add(btnBoChon);
                    pn.Controls.Add(btnChon);
                    pn.Controls.Add(sl);
                    pn.Controls.Add(numeric);
                    lbGia.Text = "100.000";
                    lbGia.Location = new Point(sl.Location.X, sl.Location.Y - sl.Height);
                    pn.Controls.Add(lbGia);

                    VND.Text = "VND";
                    VND.Location = new Point(numeric.Location.X + numeric.Width - 30, sl.Location.Y - sl.Height);

                    pn.Controls.Add(pc);
                    pn.Controls.Add(VND);
                    VND.BringToFront();

                    name.Text = "Bánh mì chả cá";
                    name.Size = new Size(120, 20);
                    name.Font = new Font("UTM Bebas", 10, FontStyle.Regular);
                    name.Location = new Point(lbGia.Location.X, lbGia.Location.Y - lbGia.Height);
                    name.TextAlign = ContentAlignment.MiddleCenter;
                    pn.Controls.Add(name);
                    fl.Controls.Add(pn);
                }
                tab.TabPages.Add(tp);
                tp.Controls.Add(fl);
            }
            this.Controls.Add(tab);
            tab.BringToFront();
            #endregion
            ID_Bill= BLBill.AddBill();
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.Font = new Font("UTM",10, FontStyle.Regular);           
        }

        private void chon_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            ///  MessageBox.Show(b.Tag.ToString());
            var pr = b.Parent;
            var num = pr.Controls.Find("SL", false).First() as NumericUpDown;
            if (num.Value > 0)
            {
                BLDetails.AddOrUpdateDetail(Convert.ToInt32(b.Tag.ToString()), ID_Bill, Convert.ToInt32(num.Value));
                pr.BackColor = Color.Yellow;
                dataGridView1.DataSource = BLBill.GetBill(ID_Bill);
            }
        }
        private void bochon_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            var pr = b.Parent;
            var num = pr.Controls.Find("SL", false).First() as NumericUpDown;
            num.Value = 0;
            try
            {
                BLDetails.DeleteDetail(Convert.ToInt32(b.Tag.ToString()), ID_Bill);
                pr.BackColor = Color.DarkGray;
                dataGridView1.DataSource = BLBill.GetBill(ID_Bill);
            }
            catch { }
        }

        private void FormFoodChoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = false;
                BLBill.DeleteBillIfNotExist(ID_Bill);
            } 
            else
                e.Cancel = true;
           
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Report rp = new Report(ID_Bill);
            rp.ShowDialog();
        }
    }
}
