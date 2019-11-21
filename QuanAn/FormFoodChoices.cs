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
            TabControl tab = new TabControl();
            var listCategory = BLMenu.GetListCategory();
            tab.Location = new Point(10, 65);
            tab.Size = new Size(545, 445);
            int sizebtn = 120;
            for (int i=0;i<listCategory.Count;i++)
            {
                TabPage tp = new TabPage(listCategory[i].Name);
                tp.Location = new Point(10, 58);
                tp.BackColor = Color.Transparent;
                var listFood = BLMenu.GetFoodByCategory(listCategory[i].ID);
                FlowLayoutPanel fl = new FlowLayoutPanel();
              //  fl.Margin = new Padding(20); 
                fl.Location = new Point(0,0);
                fl.BackColor = Color.Transparent;
                fl.AutoScroll = true;
                fl.Size = new Size(545, 445);

                for (int j = 0; j < listFood.Count; j++)
                {
                    
                    Button btn = new Button();
                    btn.Text = listFood[j].Name;
                    btn.Margin = new Padding(20);
                    btn.Size = new Size(sizebtn, sizebtn);
                   
                    fl.Controls.Add(btn);
                }
                tab.TabPages.Add(tp);
                tp.Controls.Add(fl);
            }
            this.Controls.Add(tab);
            tab.BringToFront();
        }

    }
}
