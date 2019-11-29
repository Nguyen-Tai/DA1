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
    public partial class FormLogin : Form
    {
        int EmployeeID;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IsUser(txtUsername.Text,txtPassword.Text, rbAdmin.Checked))
            {
                if (rbAdmin.Checked)
                {
                    FormManage f1 = new FormManage();
                    this.Hide();
                    f1.ShowDialog();
                }
                if (rbEmployee.Checked)
                {
                    FormFoodChoices f1 = new FormFoodChoices(EmployeeID);
                    this.Hide();
                    f1.ShowDialog();
                }
            }
        }
        private bool IsUser(string username, string password, bool quyen)
        {
            StoreContext db = new StoreContext();
            var q = (from p in db.Accounts
                    where p.Username == username
                    && p.Password == password && p.IsAdmin==quyen
                    select p).SingleOrDefault();
            if (q != null)
            {
                EmployeeID = q.Employee_ID;
                return true;
            }
            else return false;
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }
    }
}
